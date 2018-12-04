using UnityEngine;
using UnityEditor;
using Sirenix.OdinInspector.Editor;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor.Drawers;

namespace DogHouse.Tools
{
    /// <summary>
    /// ReleaseNotes is an editor tool that 
    /// creates release notes that are displayed
    /// on the main menu.
    /// </summary>
    public class ReleaseNotes : OdinEditorWindow
    {
        #region Public Variables
        //public string[] Values;
        #endregion

        #region Private Variables
        private static string m_content;
        #endregion
        
        #region Main Methods
        [MenuItem("Tools/Core/Build/Release Notes")]
        public static void ShowWindow()
        {
            GetWindow<ReleaseNotes>("Release Notes").Show();
        }

        public void MyGUI()
        {
            GUILayout.Label("LABEL");
        }

        [TableList]
        [OnInspectorGUI("MyGUI", false)]
        public List<ReleaseData> Values;

        [LabelWidth(100)]
        [Button(Expanded = false, Name = "Save Data",Style = ButtonStyle.CompactBox)]
        public void SaveData() 
        { 
            foreach(ReleaseData data in Values)
            {
                Debug.Log(data.Message);
            }
        }

        #endregion

        #region Utility Methods
        private void OnEnable()
        {

        }

        private void OnDisable()
        {
            SaveData();
        }
        #endregion
    }

    public class ReleaseData
    {
        public string Message;
    }
}
