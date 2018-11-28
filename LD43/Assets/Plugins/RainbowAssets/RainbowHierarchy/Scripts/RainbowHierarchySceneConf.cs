using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using KeyType = Borodar.RainbowHierarchy.HierarchyItem.KeyType;

namespace Borodar.RainbowHierarchy
{
	[ExecuteInEditMode]
	[HelpURL(AssetInfo.HELP_URL)]
	public class RainbowHierarchySceneConf : MonoBehaviour
	{
		private const string SCENE_CONF_NAME = "RainbowHierarchyConf";
		
		public static List<RainbowHierarchySceneConf> Instances = new List<RainbowHierarchySceneConf>();
				
		public List<HierarchyItem> HierarchyItems = new List<HierarchyItem>();
		public bool ShowContent = false;
		
		private Scene _scene;
		
		//---------------------------------------------------------------------
		// Messages
		//---------------------------------------------------------------------

		private void Awake()
		{
			if (!Application.isEditor && Application.isPlaying)		
			{
				Instances.Remove(this);
				DestroyImmediate(gameObject);
				return;
			}

			_scene = gameObject.scene;
			Instances.RemoveAll(item => item == null);
			if (!Instances.Contains(this)) Instances.Add(this);
		}

		private void OnEnable()
		{
			_scene = gameObject.scene;
			if (!Instances.Contains(this)) Instances.Add(this);
		}
		
		//---------------------------------------------------------------------
		// Public
		//---------------------------------------------------------------------

		public static RainbowHierarchySceneConf GetConfByScene(Scene scene, bool createIfNotExist = false)
		{
			var existingConf = Instances.FirstOrDefault(sceneConf => sceneConf._scene == scene);
			if (existingConf != null || !createIfNotExist) return existingConf;
			
			var newSceneConf = CreateSceneConf(scene);
			return newSceneConf;
		}

		public HierarchyItem GetItem(GameObject match)
		{
			for (var i = HierarchyItems.Count - 1; i >= 0; i--)
			{
				var currentItem = HierarchyItems[i];
				
				if (currentItem.Type == KeyType.Name) continue;
				
				if (currentItem.GameObject == match) return currentItem;
			}
			for (var i = HierarchyItems.Count - 1; i >= 0; i--)
			{
				var currentItem = HierarchyItems[i];
				
				if (currentItem.Type == KeyType.Object) continue;
				
				if (currentItem.Name == match.name) return currentItem;
			}

			return null;
		}

		public void AddItem(HierarchyItem hierarchyItem)
		{
			var item = new HierarchyItem(hierarchyItem);

			HierarchyItems.Add(item);
		}

		public void RemoveAll(GameObject match, KeyType type)
		{
			if (match == null) return;
			
			HierarchyItems.RemoveAll(x => 
				type == KeyType.Object && x.GameObject == match || 
				type == KeyType.Name && x.Name == match.name);
		}

		public void UpdateItem(GameObject selectedObject, HierarchyItem hierarchyItem)
		{
			var existingItem = GetItem(selectedObject);
			
			if (existingItem != null)
			{
				if (hierarchyItem.HasAtLeastOneTexture())
				{
					existingItem.CopyFrom(hierarchyItem);
				}
				else
				{
					RemoveAll(selectedObject, existingItem.Type);
				}
			}
			else
			{
				if (hierarchyItem.HasAtLeastOneTexture()) AddItem(hierarchyItem);
			}
		}
		
		//---------------------------------------------------------------------
		// Helpers
		//---------------------------------------------------------------------

		private static RainbowHierarchySceneConf CreateSceneConf(Scene scene)
		{
			var sceneConfObject = new GameObject {name = SCENE_CONF_NAME};
			if (sceneConfObject.scene != scene) SceneManager.MoveGameObjectToScene(sceneConfObject, scene);
			
			var sceneConf = sceneConfObject.AddComponent<RainbowHierarchySceneConf>();
			sceneConf.gameObject.tag = "EditorOnly";
			return sceneConf;
		}
	}
}
