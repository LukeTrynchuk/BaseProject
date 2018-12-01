using UnityEditor;
using UnityEngine;

namespace Borodar.RainbowHierarchy
{
    [CustomPropertyDrawer(typeof(HierarchyColor))]
    public class HierarchyColorDrawer : PropertyDrawer
    {
        private const float PADDING = 8f;
        private const float LINE_HEIGHT = 16f;
        private const float LABELS_WIDTH = 100f;
        private const float PROPERTY_HEIGHT = 64f;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var originalPosition = position;

            var folderType = property.FindPropertyRelative("Color");
            var icon = property.FindPropertyRelative("Icon");
            var background = property.FindPropertyRelative("Background");

            // Labels

            position.y += PADDING;
            position.width = LABELS_WIDTH;
            position.height = LINE_HEIGHT;

            EditorGUI.LabelField(position, "Color");
            position.y += LINE_HEIGHT;
            EditorGUI.LabelField(position, "Icon");
            position.y += LINE_HEIGHT;
            EditorGUI.LabelField(position, "Background");

            // Values

            position.x += LABELS_WIDTH;
            position.y = originalPosition.y + PADDING;
            position.width = originalPosition.width - LABELS_WIDTH - PADDING;

            EditorGUI.PropertyField(position, folderType, GUIContent.none);
            position.y += LINE_HEIGHT;
            EditorGUI.PropertyField(position, icon, GUIContent.none);
            position.y += LINE_HEIGHT;
            EditorGUI.PropertyField(position, background, GUIContent.none);
        }
        
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return PROPERTY_HEIGHT;
        }
    }
}