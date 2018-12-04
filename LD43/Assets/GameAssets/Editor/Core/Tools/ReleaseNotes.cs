using UnityEngine;
using UnityEditor;
using Sirenix.OdinInspector.Editor;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor.Drawers;
using System.IO;
using System;
using System.Linq;

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
            string[] lines = GenerateReleaseLines();
            string data = CompactLines(lines);
            SaveReleaseData(data);
        }
        #endregion

        #region Utility Methods
        private void LoadData()
        {
            string data = ReadData();
            Debug.Log($"Read Data {data}");
            string[] lines = ExtractLines(data);
            FillReleaseDataList(lines);
        }

        private void SaveReleaseData(string data)
        {
            string url = GetReleaseNotesURL();
            WriteFile(url, data);
            LoadData();
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
            return GetResourceNotesAsset().text;
        }

        private string[] ExtractLines(string input)
        {
            string[] lines = input.Split(new char[] { '\n' }).Where(x => x != "").ToArray();
            return lines;
        }

        private string[] GenerateReleaseLines()
        {
            List<string> lines = new List<string>();
            foreach (ReleaseData data in Values)
                lines.Add(data.Message + "\n");

            Debug.Log(lines.Count);
            return lines.ToArray();
        }

        private string CompactLines(string[] lines)
        {
            string value = "";
            foreach (string line in lines)
                value += line;
            return value;
        }

        private TextAsset GetResourceNotesAsset()
        {
            TextAsset releaseData
                = (TextAsset)Resources.Load("Core/ReleaseNotes");
            return releaseData;
        }

        private string GetReleaseNotesURL()
        {
            string url = Application.dataPath;
            url += "/GameAssets/Resources/Core/ReleaseNotes.txt";

            Debug.Log(Application.dataPath);
            Debug.Log(Application.absoluteURL);
            Debug.Log(url);

            return url;
        }

        private void WriteFile(string url, string content)
        {
            Debug.Log(File.Exists(url));
            File.WriteAllText(@url, content);
        }
        #endregion
    }

    public class ReleaseData
    {
        public string Message;
    }
}
