using UnityEngine;
using UnityEditor;
using Sirenix.OdinInspector.Editor;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor.Drawers;
using System.IO;
using System;

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
        [TableList]
        [OnInspectorGUI("MyGUI", false)]
        public List<ReleaseData> Values;
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

        private void OnEnable()
        {
            LoadData();
        }

        private void OnDisable()
        {
            SaveData();
        }

        [LabelWidth(100)]
        [Button(Expanded = false, Name = "Save Data", Style = ButtonStyle.CompactBox)]
        public void SaveData()
        {
            Debug.Log(ReadData());
        }
        #endregion

        #region Utility Methods
        private void LoadData()
        {
            string data = ReadData();
            string[] lines = ExtractLines(data);
            FillReleaseDataList(lines);
        }

        private void FillReleaseDataList(string[] lines)
        {
            List<ReleaseData> releaseDatas = new List<ReleaseData>();
            foreach(string line in lines)
            {
                ReleaseData data = new ReleaseData();
                data.Message = line;
                releaseDatas.Add(data);
            }
            Values = releaseDatas;
        }
        #endregion

        #region Low Level Functions
        private string ReadData()
        {
            TextAsset releaseData
                = (TextAsset)Resources.Load("Core/ReleaseNotes");

            return releaseData.text;
        }

        private string[] ExtractLines(string input)
        {
            string[] lines = input.Split(new char[] { '\n' });
            return lines;
        }
        #endregion
    }

    public class ReleaseData
    {
        public string Message;
    }
}
