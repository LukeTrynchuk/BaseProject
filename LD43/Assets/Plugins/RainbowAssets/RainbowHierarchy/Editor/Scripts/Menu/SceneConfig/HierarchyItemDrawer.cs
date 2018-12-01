using UnityEditor;
using UnityEngine;

namespace Borodar.RainbowHierarchy.SceneConfig
{
    [CustomPropertyDrawer(typeof(HierarchyItem))]
    public class HierarchyItemDrawer: PropertyDrawer
    {
        private const float PADDING = 8f;
        private const float LINE_HEIGHT = 16f;
        private const float LABELS_WIDTH = 100f;
        private const float PROPERTY_HEIGHT = 115f;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var originalPosition = position;

            var itemType = property.FindPropertyRelative("Type");            
            
            var name = property.FindPropertyRelative("Name");
            var hierarchyObject = property.FindPropertyRelative("GameObject");
            
            var icon = property.FindPropertyRelative("Icon");
            var isIconRecursive = property.FindPropertyRelative("IsIconRecursive");
            
            var background = property.FindPropertyRelative("Background");
            var isBackgroundRecursive = property.FindPropertyRelative("IsBackgroundRecursive");

            // Labels

            position.y += PADDING;
            position.width = LABELS_WIDTH;
            position.height = LINE_HEIGHT;

            EditorGUI.LabelField(position, "Type");
            position.y += LINE_HEIGHT;
            EditorGUI.LabelField(position, itemType.intValue == 0 ? "Game Object" : "Name");
            position.y += LINE_HEIGHT + 2f;
            EditorGUI.LabelField(position, "Icon");
            position.y += LINE_HEIGHT;
            EditorGUI.LabelField(position, "Recursive");
            position.y += LINE_HEIGHT + 2f;
            EditorGUI.LabelField(position, "Background");
            position.y += LINE_HEIGHT;
            EditorGUI.LabelField(position, "Recursive");

            // Values

            position.x += LABELS_WIDTH;
            position.y = originalPosition.y + PADDING;
            position.width = originalPosition.width - LABELS_WIDTH - PADDING;

            EditorGUI.PropertyField(position, itemType, GUIContent.none);
            position.y += LINE_HEIGHT;
            EditorGUI.PropertyField(position,  itemType.intValue == 0 ? hierarchyObject : name, GUIContent.none);
            position.y += LINE_HEIGHT + 2f;
            EditorGUI.PropertyField(position, icon, GUIContent.none);
            position.y += LINE_HEIGHT;
            EditorGUI.PropertyField(position, isIconRecursive, GUIContent.none);
            position.y += LINE_HEIGHT + 2f;
            EditorGUI.PropertyField(position, background, GUIContent.none);
            position.y += LINE_HEIGHT;
            EditorGUI.PropertyField(position, isBackgroundRecursive, GUIContent.none);
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return PROPERTY_HEIGHT;
        }
    }
}