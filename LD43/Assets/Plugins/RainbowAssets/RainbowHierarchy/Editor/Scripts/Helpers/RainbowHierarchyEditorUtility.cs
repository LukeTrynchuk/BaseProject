using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Borodar.RainbowHierarchy
{
    [SuppressMessage("ReSharper", "ConvertIfStatementToNullCoalescingExpression")]
    public static class RainbowHierarchyEditorUtility
    {
        public static readonly Color32 BG_COLOR_FREE = new Color32(194, 194, 194, 255);
        public static readonly Color32 BG_COLOR_PRO = new Color32(56, 56, 56, 255);

        private const string LOAD_ASSET_ERROR_MSG = "Could not load {0}\n" +
                                                    "Did you move the \"Rainbow Hierarchy\" around in your project? " +
                                                    "Go to \"Preferences -> Rainbow Hierarchy\" and update the location of the asset.";
        
        private static Texture2D _editIconPro;
        private static Texture2D _editIconFree;

        private static Texture2D _settingsIcon;
        private static Texture2D _presetsIcon;
        private static Texture2D _deleteIcon;
        
        private static Texture2D _dividerIcon;
        private static Texture2D _assetLogo;

        //---------------------------------------------------------------------
        // Assets
        //---------------------------------------------------------------------

        /// <summary>
        /// Creates .asset file of the specified <see cref="UnityEngine.ScriptableObject"/>
        /// </summary>
        public static void CreateAsset<T>(string baseName, string forcedPath = "") where T : ScriptableObject
        {
            if (baseName.Contains("/"))
                throw new ArgumentException("Base name should not contain slashes");

            var asset = ScriptableObject.CreateInstance<T>();

            string path;
            if (!string.IsNullOrEmpty(forcedPath))
            {
                path = forcedPath;
                Directory.CreateDirectory(forcedPath);
            }
            else
            {
                path = AssetDatabase.GetAssetPath(Selection.activeObject);

                if (string.IsNullOrEmpty(path))
                {
                    path = "Assets";
                }
                else if (Path.GetExtension(path) != string.Empty)
                {
                    path = path.Replace(Path.GetFileName(path), string.Empty);
                }
            }

            var assetPathAndName = AssetDatabase.GenerateUniqueAssetPath(path + "/" + baseName + ".asset");

            AssetDatabase.CreateAsset(asset, assetPathAndName);
            AssetDatabase.SaveAssets();
            EditorUtility.FocusProjectWindow();
            Selection.activeObject = asset;
        }
        
        public static T LoadFromAsset<T>(string relativePath) where T : UnityEngine.Object
        {
            var assetPath = Path.Combine(RainbowHierarchyPreferences.HomeFolder, relativePath);
            var asset = AssetDatabase.LoadAssetAtPath<T>(assetPath);            
            if (!asset) Debug.LogError(string.Format(LOAD_ASSET_ERROR_MSG, assetPath));
            return asset;
        }
        
        //---------------------------------------------------------------------
        // Public
        //---------------------------------------------------------------------
        
        public static Texture2D GetEditIcon(bool isPro)
        {
            return isPro
                ? GetTexture(ref _editIconPro, "icon_edit_pro_16.png")
                : GetTexture(ref _editIconFree, "icon_edit_free_16.png");
        }
        
        public static Texture2D GetSettingsButtonIcon()
        {
            return GetTexture(ref _settingsIcon, "icon_settings_16.png");
        }
        
        public static Texture2D GetDeleteButtonIcon()
        {
            return GetTexture(ref _deleteIcon, "icon_delete_16.png");
        }

        public static Texture2D GetDividerIcon()
        {
            return GetTexture(ref _dividerIcon, "icon_divider.png");
        }

        //---------------------------------------------------------------------
        // Windows
        //---------------------------------------------------------------------
        
        public static EditorWindow GetHierarchyWindow()
        {
            return GetWindowByName("UnityEditor.SceneHierarchyWindow")
                ?? GetWindowByName("UnityEditor.ObjectBrowser")
                ?? GetWindowByName("UnityEditor.ProjectBrowser");
        }

        //---------------------------------------------------------------------
        // Public
        //---------------------------------------------------------------------
        
        public static void UpdateSceneConfigVisibility(bool isVisible)
        {
            var configInstances = RainbowHierarchySceneConf.Instances;
            if (configInstances == null || configInstances.Count < 1) return;
            
            foreach (var rainbowHierarchySceneConf in configInstances)
            {
                if (rainbowHierarchySceneConf == null) return;
                rainbowHierarchySceneConf.transform.hideFlags = isVisible
                    ? HideFlags.None
                    : HideFlags.HideInHierarchy;
            }
            
            EditorApplication.DirtyHierarchyWindowSorting();
        }
        
        //---------------------------------------------------------------------
        // Helpers
        //---------------------------------------------------------------------

        private static EditorWindow GetWindowByName(string pName)
        {
            var objectList = Resources.FindObjectsOfTypeAll(typeof(EditorWindow));
            return (from obj in objectList where obj.GetType().ToString() == pName select ((EditorWindow)obj)).FirstOrDefault();
        }
        
        private static Texture2D GetTexture(ref Texture2D texture, string fileName)
        {
            if (texture == null)
                texture = LoadFromAsset<Texture2D>("Editor/Textures/" + fileName);

            return texture;
        }

    }
}