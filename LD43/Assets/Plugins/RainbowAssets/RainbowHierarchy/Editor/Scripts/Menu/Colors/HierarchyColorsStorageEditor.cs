using Borodar.RainbowAssets.Core.Games.Collections;
using UnityEditor;
using UnityEngine;

namespace Borodar.RainbowHierarchy
{
    [CustomEditor(typeof(HierarchyColorsStorage))]
    public class HierarchyColorsStorageEditor : Editor
    {
        private const string PROP_NAME_FOLDERS = "ColorHierarchyIcons";

        private SerializedProperty _foldersProperty;

        protected void OnEnable()
        {
            _foldersProperty = serializedObject.FindProperty(PROP_NAME_FOLDERS);
        }

        public override void OnInspectorGUI()
        {
            GUI.enabled = false;
            EditorGUILayout.HelpBox("This is internal file for Rainbow Hierarchy. Do not edit.", MessageType.Warning);

            serializedObject.Update();
            ReorderableListGUI.Title("Internal storage of colored object icons");
            ReorderableListGUI.ListField(_foldersProperty);
            serializedObject.ApplyModifiedProperties();
        }
    }
}