using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;


namespace Borodar.RainbowHierarchy
{

	[InitializeOnLoad]
	public class RainbowHierarchyIcons : MonoBehaviour
	{
		private static readonly List<GameObject> RecursiveList = new List<GameObject>();
		
		private static bool _multiSelection;

		static RainbowHierarchyIcons()
		{
			EditorApplication.projectWindowItemOnGUI += ShowWelcomeWindow;
			EditorApplication.hierarchyChanged += HierarchyWindowChanged;
			EditorApplication.hierarchyWindowItemOnGUI += DrawDividerIcon;
			EditorApplication.hierarchyWindowItemOnGUI += ReplaceHierarchyTextures;
			EditorApplication.hierarchyWindowItemOnGUI += DrawEditIcon;
		}

		//---------------------------------------------------------------------
		// Delegates
		//---------------------------------------------------------------------
		
		private static void HierarchyWindowChanged()
		{
			RainbowHierarchyEditorUtility.UpdateSceneConfigVisibility(!RainbowHierarchyPreferences.HideConfig);
		}

		private static void DrawDividerIcon(int instanceId, Rect selectionRect)
		{
			var gameObject = (GameObject)EditorUtility.InstanceIDToObject(instanceId);
			if (gameObject == null) return;
			
			var hasChildren = gameObject.transform.childCount > 0;
			if (hasChildren) return;
			
			var iconRect = new Rect(selectionRect) {width = 16f};
			if (IsShowInSearch(iconRect)) return;
			iconRect.x -= 16f;
			GUI.DrawTexture(iconRect, RainbowHierarchyEditorUtility.GetDividerIcon());
		}
		
		private static void ReplaceHierarchyTextures(int instanceId, Rect selectionRect)
		{
			var gameObject = (GameObject)EditorUtility.InstanceIDToObject(instanceId);
			if (gameObject == null) return;
			
			var currentScene = gameObject.scene;
			var sceneConf = RainbowHierarchySceneConf.GetConfByScene(currentScene);
			if (sceneConf == null || sceneConf.HierarchyItems.Count == 0) return;

			var hierarchyItem = sceneConf.GetItem(gameObject);

			if (hierarchyItem != null)
			{
				CheckRecursiveListUpdate(hierarchyItem, gameObject);
				DrawCustomIcon(hierarchyItem, selectionRect);
				DrawCustomBackground(hierarchyItem, selectionRect);
			}
			else
			{
				HandleRecursive(selectionRect, gameObject, sceneConf);
			}
		}

		private static void DrawEditIcon(int instanceId, Rect selectionRect)
		{
			if ((Event.current.modifiers & RainbowHierarchyPreferences.ModifierKey) == EventModifiers.None)
			{
				_multiSelection = false;
				return;
			}
			
			var gameObject = (GameObject)EditorUtility.InstanceIDToObject(instanceId);
			if (gameObject == null) return;
			
			var isMouseOver = selectionRect.Contains(Event.current.mousePosition);
			_multiSelection = IsSelected(gameObject) ? isMouseOver || _multiSelection : !isMouseOver && _multiSelection;

			// if mouse is not over current folder icon or selected group
			if (!isMouseOver && (!IsSelected(gameObject) || !_multiSelection)) return;

			var editIcon = RainbowHierarchyEditorUtility.GetEditIcon(EditorGUIUtility.isProSkin);
			DrawCustomIcon( editIcon, selectionRect);

			if (GUI.Button(selectionRect, GUIContent.none, GUIStyle.none))
			{
				ShowPopupWindow(selectionRect, gameObject);
			}

			EditorApplication.RepaintHierarchyWindow();
		}
		
		private static void ShowWelcomeWindow(string guid, Rect rect)
		{
			if (EditorPrefs.GetBool(RainbowHierarchyWelcome.PREF_KEY))
			{
				// ReSharper disable once DelegateSubtraction
				EditorApplication.projectWindowItemOnGUI -= ShowWelcomeWindow;
				return;
			}

			RainbowHierarchyWelcome.ShowWindow();
			EditorPrefs.SetBool(RainbowHierarchyWelcome.PREF_KEY, true);

		}
		
		//---------------------------------------------------------------------
		// Helpers
		//---------------------------------------------------------------------

		private static void DrawCustomIcon(HierarchyItem hierarchyItem, Rect selectionRect)
		{
			if (hierarchyItem == null || !hierarchyItem.HasIcon()) return;
			DrawCustomIcon(hierarchyItem.Icon, selectionRect);
		}
		
		private static void DrawCustomIcon(Texture2D icon, Rect selectionRect)
		{
			var iconRect = new Rect(selectionRect) {width = 16f};
			
			iconRect.x -= IsShowInSearch(iconRect) ? 16f : 30f;			
			GUI.DrawTexture(iconRect, icon);
		}

		private static void DrawCustomBackground(HierarchyItem hierarchyItem, Rect selectionRect)
		{
			if (hierarchyItem == null || !hierarchyItem.HasBackground()) return;
			selectionRect.x -= 1f;
			GUI.DrawTexture(selectionRect, hierarchyItem.Background);
		}
		
		private static void ShowPopupWindow(Rect selectionRect, GameObject currentObject)
		{
			var window = RainbowHierarchyPopup.GetDraggableWindow();
			var position = GUIUtility.GUIToScreenPoint(selectionRect.position + new Vector2(0, selectionRect.height + 2));

			if (_multiSelection)
			{
				var gameObjects = Selection.gameObjects.ToList();
				var index = gameObjects.IndexOf(currentObject);
				window.ShowWithParams(position, gameObjects, index);
			}
			else
			{
				window.ShowWithParams(position, new List<GameObject> {currentObject}, 0);
			}
		}

		private static void HandleRecursive(Rect selectionRect, GameObject gameObject, RainbowHierarchySceneConf sceneConf)
		{
			for (var i = RecursiveList.Count - 1; i >= 0; i--)
			{
				if (RecursiveList[i] == null)
				{
					RecursiveList.Remove(RecursiveList[i]);
					return;
				}
				if (!gameObject.transform.IsChildOf(RecursiveList[i].transform)) continue;
				
				var parentItem = sceneConf.GetItem(RecursiveList[i]);
				if (parentItem == null) return;
				
				if (parentItem.IsIconRecursive)
				{
					DrawCustomIcon(parentItem, selectionRect);
				}
				if (parentItem.IsBackgroundRecursive)
				{
					DrawCustomBackground(parentItem, selectionRect);
				}
				return;
			}
		}
		
		private static void CheckRecursiveListUpdate(HierarchyItem hierarchyItem, GameObject gameObject)
		{
			if (hierarchyItem.HasRecursive() && !RecursiveList.Contains(gameObject))
			{
				RecursiveList.Add(gameObject);
				RecursiveList.Sort(SortByParenting);
			}
			else if (!hierarchyItem.HasRecursive() && RecursiveList.Contains(gameObject))
			{
				RecursiveList.Remove(gameObject);
			}
		}
		
		private static int SortByParenting(GameObject o, GameObject o1)
		{
			if (o == null || o1 == null) return 0;
			return o.transform.IsChildOf(o1.transform) ? 1 : -1;
		}
		
		private static bool IsSelected(GameObject gameObject)
		{
			return Selection.gameObjects.Contains(gameObject);
		}

		private static bool IsShowInSearch(Rect iconRect)
		{
			return iconRect.x == 16f;
		}
	}
}
