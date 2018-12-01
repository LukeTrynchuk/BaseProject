using System;
using UnityEditor;
using UnityEngine;

namespace Borodar.RainbowHierarchy
{
    public class RainbowHierarchyPreferences
    {
        private const string HOME_FOLDER_PREF_KEY = "Borodar.RainbowHierarchy.HomeFolder.";
        private const string HOME_FOLDER_DEFAULT = "Assets/Plugins/RainbowAssets/RainbowHierarchy";
        private const string HOME_FOLDER_HINT = "Change this setting to the new location of the \"Rainbow Hierarchy\" if you move the folder around in your project.";

        private const string MOD_KEY_PREF_KEY = "Borodar.RainbowHierarchy.EditMod.";
        private const EventModifiers MOD_KEY_DEFAULT = EventModifiers.Alt;
        private const string MOD_KEY_HINT = "Modifier key that is used to show configuration dialogue when clicking on an object in the hierarchy";

        private const string HIDE_CONFIG_PREF_KEY = "Borodar.RainbowHierarchy.HideConfig.";
        private const bool HIDE_CONFIG_DEFAULT = false;
        private const string HIDE_CONFIG_HINT = "Change this settings to show/hide the RainbowHierarchyConf object in the hierarchy window.";

        private static readonly EditorPrefsString HOME_FOLDER_PREF;
        private static readonly EditorPrefsModifierKey MODIFIER_KEY_PREF ;
        private static readonly EditorPrefsBoolean HIDE_CONFIG_PREF;

        public static string HomeFolder;
        public static EventModifiers ModifierKey;
        public static bool HideConfig;

        static RainbowHierarchyPreferences()
        {
            var homeLabel = new GUIContent("Folder Location", HOME_FOLDER_HINT);
            HOME_FOLDER_PREF = new EditorPrefsString(HOME_FOLDER_PREF_KEY + ProjectName, homeLabel, HOME_FOLDER_DEFAULT);
            HomeFolder = HOME_FOLDER_PREF.Value;

            var modifierLabel = new GUIContent("Modifier Key", MOD_KEY_HINT);
            MODIFIER_KEY_PREF = new EditorPrefsModifierKey(MOD_KEY_PREF_KEY + ProjectName, modifierLabel, MOD_KEY_DEFAULT);
            ModifierKey = MODIFIER_KEY_PREF.Value;
            
            var hideConfigLabel = new GUIContent("Hide Config", HIDE_CONFIG_HINT);
            HIDE_CONFIG_PREF = new EditorPrefsBoolean(HIDE_CONFIG_PREF_KEY + ProjectName, hideConfigLabel, HIDE_CONFIG_DEFAULT);
            HideConfig = HIDE_CONFIG_PREF.Value;
        }

        //---------------------------------------------------------------------
        // Messages
        //---------------------------------------------------------------------

        [PreferenceItem("Rainbow Hierarchy")]
        public static void EditorPreferences()
        {
            EditorGUILayout.Separator();
            HOME_FOLDER_PREF.Draw();
            HomeFolder = HOME_FOLDER_PREF.Value;

            EditorGUILayout.Separator();
            MODIFIER_KEY_PREF.Draw();
            ModifierKey = MODIFIER_KEY_PREF.Value;
            
            EditorGUILayout.Separator();
            HIDE_CONFIG_PREF.Draw();
            HideConfig = HIDE_CONFIG_PREF.Value;

            GUILayout.FlexibleSpace();
            EditorGUILayout.LabelField("Version " + AssetInfo.VERSION, EditorStyles.centeredGreyMiniLabel);
        }

        //---------------------------------------------------------------------
        // Helpers
        //---------------------------------------------------------------------

        private static string ProjectName
        {
            get
            {
                var s = Application.dataPath.Split('/');
                var p = s[s.Length - 2];
                return p;
            }
        }

        //---------------------------------------------------------------------
        // Nested
        //---------------------------------------------------------------------

        public abstract class EditorPrefsItem<T>
        {
            public string Key;
            public GUIContent Label;
            public T DefaultValue;

            protected EditorPrefsItem(string key, GUIContent label, T defaultValue)
            {
                if (string.IsNullOrEmpty(key))
                {
                    throw new ArgumentNullException("key");
                }

                Key = key;
                Label = label;
                DefaultValue = defaultValue;
            }

            public abstract T Value { get; set; }
            public abstract void Draw();

            public static implicit operator T(EditorPrefsItem<T> s)
            {
                return s.Value;
            }
        }

        public class EditorPrefsString : EditorPrefsItem<string>
        {
            public EditorPrefsString(string key, GUIContent label, string defaultValue)
                : base(key, label, defaultValue) { }

            public override string Value
            {
                get { return EditorPrefs.GetString(Key, DefaultValue); }
                set { EditorPrefs.SetString(Key, value); }
            }

            public override void Draw()
            {
                EditorGUIUtility.labelWidth = 100f;
                Value = EditorGUILayout.TextField(Label, Value);
            }
        }

        public class EditorPrefsBoolean : EditorPrefsItem<bool>
        {
            public EditorPrefsBoolean(string key, GUIContent label, bool defaultValue) 
                : base(key, label, defaultValue) { }

            public override bool Value
            {
                get { return EditorPrefs.GetBool(Key, DefaultValue); }
                set
                {
                    var isChanged = Value != value;
                    
                    EditorPrefs.SetBool(Key, value);
                    
                    if (isChanged)
                    {
                        RainbowHierarchyEditorUtility.UpdateSceneConfigVisibility(!value);
                    }
                }
            }

            public override void Draw()
            {
                EditorGUIUtility.labelWidth = 100f;
                Value = EditorGUILayout.Toggle(Label, Value);
            }
        }

        private class EditorPrefsModifierKey : EditorPrefsItem<EventModifiers> {

            public EditorPrefsModifierKey(string key, GUIContent label, EventModifiers defaultValue)
                : base( key, label, defaultValue ) { }

            public override EventModifiers Value {
                get
                {
                    var index = EditorPrefs.GetInt(Key, (int) DefaultValue);
                    return (Enum.IsDefined(typeof(EventModifiers), index)) ? (EventModifiers) index : DefaultValue;
                }
                set
                {
                    EditorPrefs.SetInt(Key, (int) value);
                }
            }

            public override void Draw() {
                Value = (EventModifiers) EditorGUILayout.EnumPopup(Label, Value);
            }
        }
    }
}