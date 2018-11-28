using Borodar.RainbowAssets.Core.Games.Collections;
using UnityEditor;
using UnityEngine;

namespace Borodar.RainbowHierarchy.SceneConfig
{
    [CustomEditor(typeof(RainbowHierarchySceneConf))]
    public class RainbowHierarchySceneConfEditor : Editor
    {
        private const string PROP_NAME_FOLDERS = "HierarchyItems";
        private const string PROP_NAME_SHOW_CONTENT = "ShowContent";

        private SerializedProperty _foldersProperty;
        private SerializedProperty _showContentProperty;

        protected void OnEnable()
        {
            _foldersProperty = serializedObject.FindProperty(PROP_NAME_FOLDERS);
            _showContentProperty = serializedObject.FindProperty(PROP_NAME_SHOW_CONTENT);
        }

        public override void OnInspectorGUI()
        {
//            GUI.enabled = false;
            EditorGUILayout.HelpBox("\n" +
                                    "This object is created automatically and managed by the Rainbow Hierarchy. It will not be included in the application build." + 
                                    "\n\n" +
                                    "It stores all the asset settings related to the current scene. You can safely remove it, but all the icons and backgrounds will be reset. Delete this object if you want to remove the Rainbow Hierarchy." +
                                    "\n\n" +
                                    "This object can be hidden by checking \"Hide Config\" in the preferences for the Rainbow Hierarchy.\n"
                , MessageType.Info, true);

            serializedObject.Update();
            if (_showContentProperty.boolValue)
            {
                if (GUI.Button(EditorGUILayout.GetControlRect(GUILayout.ExpandWidth(true), GUILayout.Height(20)),"Hide content"))
                {
                    _showContentProperty.boolValue = false;
                }
                DrawHierarchyList();
            }
            else
            {
                if (GUI.Button(EditorGUILayout.GetControlRect(GUILayout.ExpandWidth(true), GUILayout.Height(20)), "Show content"))
                {
                    _showContentProperty.boolValue = true;
                }
            }
            serializedObject.ApplyModifiedProperties();
        }

        private void DrawHierarchyList()
        {
            ReorderableListGUI.ListField(_foldersProperty);
        }
    }
}