using System.Collections.Generic;
using Borodar.RainbowCore.Editor;
using UnityEditor;
using UnityEngine;
using KeyType = Borodar.RainbowHierarchy.HierarchyItem.KeyType; 

namespace Borodar.RainbowHierarchy
{
    public class RainbowHierarchyPopup : DraggablePopupWindow
    {
        private const float PADDING = 8f;
        private const float SPACING = 2f;
        private const float LINE_HEIGHT = 16f;
        private const float LABELS_WIDTH = 80f;
        private const float BUTTON_WIDTH = 55f;
        private const float ICON_WIDTH_SMALL = 16f;

        private const float WINDOW_WIDTH = 300f;
        private const float WINDOW_HEIGHT = 137f;

        private static readonly Vector2 WINDOW_SIZE = new Vector2(WINDOW_WIDTH, WINDOW_HEIGHT);

        private Rect _windowRect;
        private Rect _backgroundRect;

        private List<GameObject> _selectedObjects;
        private GameObject _currentObject;
        private RainbowHierarchySceneConf _rainbowHierarchySceneConf;
        private HierarchyItem _currentHierarchyItem;

        //---------------------------------------------------------------------
        // Public
        //---------------------------------------------------------------------

        public static RainbowHierarchyPopup GetDraggableWindow()
        {
            return GetDraggableWindow<RainbowHierarchyPopup>();
        }

        public void ShowWithParams(Vector2 inPosition, List<GameObject> selectedObjects, int firstSelected)
        {
            _selectedObjects = selectedObjects;

            var scene = selectedObjects[0].scene;
            _rainbowHierarchySceneConf = RainbowHierarchySceneConf.GetConfByScene(scene, true);

            _currentObject = selectedObjects[firstSelected];
            
            var item = _rainbowHierarchySceneConf.GetItem(_currentObject);

            _currentHierarchyItem = item == null ? 
                new HierarchyItem(KeyType.Object, _currentObject, _currentObject.name) : 
                new HierarchyItem(item);
            
            _currentHierarchyItem.GameObject = _currentObject;

            // Resize
                        
            var customIconHeight = (_currentHierarchyItem.IsIconCustom) ? LINE_HEIGHT : 0f;
            var customBackgroundHeight = (_currentHierarchyItem.IsBackgroundCustom) ? LINE_HEIGHT : 0f;

            var rect = new Rect(inPosition, WINDOW_SIZE)
            {
                height = WINDOW_HEIGHT + customIconHeight + customBackgroundHeight
            };

            _windowRect = new Rect(Vector2.zero, rect.size);
            _backgroundRect = new Rect(Vector2.one, rect.size - new Vector2(2f, 2f));

            Show<RainbowHierarchyPopup>(rect);
        }

        //---------------------------------------------------------------------
        // Messages
        //---------------------------------------------------------------------

        public override void OnGUI()
        {
            base.OnGUI();
            ChangeWindowSize(_currentHierarchyItem.IsIconCustom, _currentHierarchyItem.IsBackgroundCustom);
            var rect = _windowRect;

            // Window Background

            var borderColor = EditorGUIUtility.isProSkin ? new Color(0.13f, 0.13f, 0.13f) : new Color(0.51f, 0.51f, 0.51f);           
            EditorGUI.DrawRect(_windowRect, borderColor);

            var backgroundColor = EditorGUIUtility.isProSkin ? new Color(0.18f, 0.18f, 0.18f) : new Color(0.83f, 0.83f, 0.83f);
            EditorGUI.DrawRect(_backgroundRect, backgroundColor);
            
            // Type 
            
            rect.x += 0.5f * PADDING;
            rect.y += PADDING;
            rect.width = LABELS_WIDTH - PADDING;
            rect.height = LINE_HEIGHT;
            
            _currentHierarchyItem.Type = (KeyType) EditorGUI.EnumPopup(rect, _currentHierarchyItem.Type);
                 
            rect.x += LABELS_WIDTH;
            rect.y = _windowRect.y + PADDING;
            rect.width = _windowRect.width - LABELS_WIDTH - PADDING;
            
            GUI.enabled = false;
            if (_selectedObjects.Count == 1)
                if (_currentHierarchyItem.Type == KeyType.Object)
                {
                    EditorGUI.ObjectField(rect, _currentObject, typeof(GameObject), true);
                }
                else
                {
                    EditorGUI.TextField(rect, _currentObject.name);
                }
            else
                EditorGUI.TextField(rect, GUIContent.none, _selectedObjects.Count + " selected");
            GUI.enabled = true;
            
            // Icon     
            
            rect.x = 0.5f * PADDING;
            rect.y += LINE_HEIGHT + SPACING * 4f;
            EditorGUI.LabelField(rect, "Icon");
            
            rect.x += 0.5f * PADDING;
            rect.y += LINE_HEIGHT + SPACING;
            rect.width = ICON_WIDTH_SMALL;
            if (_currentHierarchyItem.HasIcon())
            {
                GUI.DrawTexture(rect, _currentHierarchyItem.Icon);
            }

            rect.width = _windowRect.width - LABELS_WIDTH - PADDING;
            rect.x += LABELS_WIDTH - 0.5f * PADDING;
            rect.y -= LINE_HEIGHT + 1.5f * SPACING;
            DrawIconPopupMenu(rect);
            
            // Custom Icon Field
            if (_currentHierarchyItem.IsIconCustom)
            {
                rect.y += LINE_HEIGHT + 2f;
                _currentHierarchyItem.Icon = (Texture2D) EditorGUI.ObjectField(rect, _currentHierarchyItem.Icon, typeof(Texture2D), false);
            }

            rect.y += _currentHierarchyItem.IsIconCustom ? LINE_HEIGHT + 0.2f * SPACING : LINE_HEIGHT + SPACING;
            _currentHierarchyItem.IsIconRecursive = EditorGUI.Toggle(rect, _currentHierarchyItem.IsIconRecursive);
            
            rect.x += ICON_WIDTH_SMALL;
            EditorGUI.LabelField(rect, "Recursive");
            
            // Background
            
            rect.x = 0.5f * PADDING;
            rect.y += LINE_HEIGHT + SPACING * 3;
            EditorGUI.LabelField(rect, "Background");
            
            rect.x += 0.5f * PADDING;
            rect.y += LINE_HEIGHT + SPACING;
            rect.width = ICON_WIDTH_SMALL * 3f;
            if (_currentHierarchyItem.HasBackground())
            {
                GUI.DrawTexture(rect, _currentHierarchyItem.Background);
            }

            rect.width = _windowRect.width - LABELS_WIDTH - PADDING;
            rect.x += LABELS_WIDTH - 0.5f * PADDING;
            rect.y -= LINE_HEIGHT + 1.5f * SPACING;
            DrawBackgroundPopupMenu(rect);
            
            // Custom Icon Field
            if (_currentHierarchyItem.IsBackgroundCustom)
            {
                rect.y += LINE_HEIGHT + 2f * SPACING;
                _currentHierarchyItem.Background =
                    (Texture2D) EditorGUI.ObjectField(rect, _currentHierarchyItem.Background, typeof(Texture2D), false);
            }
            
            rect.y += _currentHierarchyItem.IsBackgroundCustom ? LINE_HEIGHT + 0.2f * SPACING : LINE_HEIGHT + SPACING;
            _currentHierarchyItem.IsBackgroundRecursive = EditorGUI.Toggle(rect, _currentHierarchyItem.IsBackgroundRecursive);
            
            rect.x += ICON_WIDTH_SMALL;
            EditorGUI.LabelField(rect, "Recursive");
            
            // Buttons
            
            rect.x = PADDING;
            rect.y = position.height - LINE_HEIGHT - 0.75f * PADDING;            
            rect.width = ICON_WIDTH_SMALL;
            ButtonSettings(rect);
            
            rect.x += ICON_WIDTH_SMALL + 0.75f * PADDING;
            ButtonDefault(rect);

            rect.x = WINDOW_WIDTH - 2f * (BUTTON_WIDTH + PADDING);
            rect.width = BUTTON_WIDTH;
            ButtonCancel(rect);

            rect.x = WINDOW_WIDTH - BUTTON_WIDTH - PADDING;
            ButtonApply(rect);
        }

        //---------------------------------------------------------------------
        // Helpers
        //---------------------------------------------------------------------
        
        private void ButtonSettings(Rect rect)
        {
            var icon = RainbowHierarchyEditorUtility.GetSettingsButtonIcon();
            if (!GUI.Button(rect, new GUIContent(icon, "Settings"), GUIStyle.none)) return;
            Selection.activeObject = _rainbowHierarchySceneConf;
            Close();
        }
        
        private void ButtonDefault(Rect rect)
        {
            var icon = RainbowHierarchyEditorUtility.GetDeleteButtonIcon();
            if (!GUI.Button(rect, new GUIContent(icon, "Revert to Default"), GUIStyle.none)) return;
            _currentHierarchyItem.Icon = null;
            _currentHierarchyItem.IsIconRecursive = false;
            _currentHierarchyItem.IsIconCustom = false;
            _currentHierarchyItem.Background = null;
            _currentHierarchyItem.IsBackgroundRecursive = false;
        }

        private void ButtonCancel(Rect rect)
        {
            if (!GUI.Button(rect, "Cancel")) return;
            Close();
        }

        private void ButtonApply(Rect rect)
        {
            if (!GUI.Button(rect, "Apply")) return;
            
            var scene = _currentObject.scene;
            var sceneConf = RainbowHierarchySceneConf.GetConfByScene(scene, true);

            foreach (var selectedObject in _selectedObjects)
            {
                _currentHierarchyItem.GameObject = _currentHierarchyItem.Type == KeyType.Name ? null : selectedObject;
                _currentHierarchyItem.Name = _currentHierarchyItem.Type == KeyType.Name ? selectedObject.name : null;
                Undo.RecordObject(sceneConf, "Scene Config Changes");
                sceneConf.UpdateItem(selectedObject, _currentHierarchyItem);
            }   

            Close();
        }
        
        private void ChangeWindowSize(bool hasCustomIcon, bool hasCustomBackground)
        {
            var rect = position;
            var customIconHeight = (hasCustomIcon) ? LINE_HEIGHT : 0f;
            var customBackgroundHeight = (hasCustomBackground) ? LINE_HEIGHT : 0f;

            var resizeHeight = WINDOW_HEIGHT + customIconHeight + customBackgroundHeight;
            if (resizeHeight == rect.height) return;
            
            rect.height = resizeHeight;            
            position = rect;

            _windowRect.height = rect.height;
            _backgroundRect.height = rect.height - 2f;
        }
        
        private void DrawIconPopupMenu(Rect rect)
        {
            string menuName;
            if (_currentHierarchyItem.IsIconCustom)
            {
                menuName = "Custom";
            }
            else
            {
                menuName = _currentHierarchyItem.Icon != null ? _currentHierarchyItem.Icon.name : "None";
            }
            if (GUI.Button(rect, new GUIContent(menuName), "popup"))
            {
                RainbowHierarchyIconsMenu.ShowDropDown(rect, _currentHierarchyItem);
            }
        }        
        
        private void DrawBackgroundPopupMenu(Rect rect)
        {
            var  menuName = _currentHierarchyItem.Background != null ? _currentHierarchyItem.Background.name : "None";
           
            if (GUI.Button(rect, new GUIContent(menuName), "popup"))
            {
                RainbowHierarchyBackgroundsMenu.ShowDropDown(rect, _currentHierarchyItem);
            }
        }
        
    }
}