using UnityEngine;
using UnityEditor;
using Sirenix.OdinInspector.Editor;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using System.IO;
using System.Linq;

namespace DogHouse.Core.Tools
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
        [OnInspectorGUI(nameof(MyGUI), false)]
        public List<ReleaseData> Values;
        #endregion

        #region Private Variables
        private const string WINDOW_TITLE = "Release Notes";
        private const string SAVE_BUTTON_NAME = "Save Data";
        private const string FILE_EXTENSION_URL = "/GameAssets/Resources/Core/ReleaseNotes/ReleaseNotes";
        #endregion

        #region Main Methods
        [MenuItem("Tools/Core/Build/Release Notes")]
        public static void ShowWindow()
        {
            GetWindow<ReleaseNotes>(WINDOW_TITLE).Show();
        }

        public void MyGUI() {}

        protected override void OnEnable()
        {
            base.OnEnable();
            LoadData();
        }

        private void OnDisable()
        {
            SaveData();
        }

        [LabelWidth(100)]
        [Button(Expanded = false, Name = SAVE_BUTTON_NAME, Style = ButtonStyle.CompactBox)]
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
            if(!File.Exists(GetReleaseNotesURL()))
            {
                File.Create(GetReleaseNotesURL());
            }

            return File.ReadAllText(GetReleaseNotesURL());
        }

        private string[] ExtractLines(string input)
        {
            string[] lines = input.Split(new char[] { '\n' })
                                  .Where(x => x != "").ToArray();
            return lines;
        }

        private string[] GenerateReleaseLines()
        {
            List<string> lines = new List<string>();
            foreach (ReleaseData data in Values)
                lines.Add(data.Message + "\n");
                
            return lines.ToArray();
        }

        private string CompactLines(string[] lines) => string.Concat(lines);

        private string GetReleaseNotesURL() =>
            Application.dataPath + GetURL();

        private void WriteFile(string url, string content) => 
            File.WriteAllText(@url, content);

        private string GetURL() => $"{FILE_EXTENSION_URL}{SystemInfo.deviceUniqueIdentifier}.txt";
        #endregion
    }

    public class ReleaseData
    {
        public string Message;
    }
}
