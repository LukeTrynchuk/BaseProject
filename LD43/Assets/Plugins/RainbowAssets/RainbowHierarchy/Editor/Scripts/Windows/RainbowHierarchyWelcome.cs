using Borodar.RainbowCore.Editor;
using UnityEditor;
using UnityEngine;

namespace Borodar.RainbowHierarchy
{
    public class RainbowHierarchyWelcome : DraggablePopupWindow
    {
        public const string PREF_KEY = "RainbowHierarchy.IsWelcomeShown";

        private const float WINDOW_WIDTH = 325f;
        private const float WINDOW_HEIGHT = 275f;

        private static readonly Vector2 WINDOW_SIZE = new Vector2(WINDOW_WIDTH, WINDOW_HEIGHT);
        private static readonly Rect WINDOW_RECT = new Rect(Vector2.zero, WINDOW_SIZE);
        private static readonly Rect BACKGROUND_RECT = new Rect(Vector2.one, WINDOW_SIZE - new Vector2(2f, 2f));

        //---------------------------------------------------------------------
        // Public
        //---------------------------------------------------------------------

        public static void ShowWindow()
        {
            var position = new Rect(CalcWindowPosition(), WINDOW_SIZE);
            var window = GetDraggableWindow<RainbowHierarchyWelcome>();
            window.Show<RainbowHierarchyWelcome>(position);
        }

        //---------------------------------------------------------------------
        // Messages
        //---------------------------------------------------------------------

        public override void OnGUI()
        {
            base.OnGUI();

            // Background

            var borderColor = EditorGUIUtility.isProSkin ? new Color(0.13f, 0.13f, 0.13f) : new Color(0.51f, 0.51f, 0.51f);
            EditorGUI.DrawRect(WINDOW_RECT, borderColor);

            var backgroundColor = EditorGUIUtility.isProSkin ? new Color(0.18f, 0.18f, 0.18f) : new Color(0.83f, 0.83f, 0.83f);
            EditorGUI.DrawRect(BACKGROUND_RECT, backgroundColor);

            // Content
            GUI.skin.label.wordWrap = true;
            GUILayout.Label("Welcome!", EditorStyles.boldLabel);
            GUILayout.Label("• With \"Rainbow Hierarchy\" you can set custom icon and background for any object in the Hierarchy window.");
            GUILayout.Label("• Just hold the Alt key and click on any object in your scene.");
            GUILayout.Label("• Configuration dialogue will appear, and you'll be able to assign custom icon and background to the corresponding object, your own ones or chose from dozens of presets.");
            GUILayout.Label("• To revert the icon and background to the default, just Alt-click on it, then press the red cross button in configuration dialogue and apply changes.");
            GUILayout.Label("• You can also edit multiple objects at once, just select them all and Alt-click at one of them.\n");

            GUILayout.BeginHorizontal();
            {
                GUILayout.FlexibleSpace();
                if (GUILayout.Button("More Info", GUILayout.Width(100f))) Application.OpenURL(AssetInfo.HELP_URL);;
                if (GUILayout.Button("Close", GUILayout.Width(100f))) Close();
                GUILayout.FlexibleSpace();
            }
            GUILayout.EndHorizontal();
        }

        //---------------------------------------------------------------------
        // Helpers
        //---------------------------------------------------------------------

        private static Vector2 CalcWindowPosition()
        {
            return RainbowHierarchyEditorUtility.GetHierarchyWindow().position.position + new Vector2(10f, 30f);
        }

        
    }
}