using UnityEngine;
using UnityEditor;
using Sirenix.OdinInspector.Editor;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using System.IO;
using System.Linq;
using System.Text;

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
        [OnInspectorGUI(nameof(MyGUI), true)]
        public List<ReleaseData> Values;
        #endregion

        #region Private Variables
        private string m_allReleaseNotes = "";

        private const string WINDOW_TITLE = "Release Notes";
        private const string SAVE_BUTTON_NAME = "Save Data";
        private const string FILE_DIRECTORY = "/GameAssets/Resources/Core/ReleaseNotes/";
        private const string FILE_EXTENSION_URL = FILE_DIRECTORY + "ReleaseNotes";
        #endregion

        #region Main Methods
        [MenuItem("Tools/Core/Build/Release Notes")]
        public static void ShowWindow()
        {
            GetWindow<ReleaseNotes>(WINDOW_TITLE).Show();
        }

        public void MyGUI() 
        {
            if (GUILayout.Button("Save Data")) SaveData();

            GUILayout.Label("CURRENT NOTES : ");
            GUILayout.Space(15);
            GUILayout.Label(m_allReleaseNotes);
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            LoadData();
        }

        private void OnDisable()
        {
            SaveData();
        }

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
            LoadAllReleaseNotes();

            string data = ReadData(GetReleaseNotesURL());
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

        private void LoadAllReleaseNotes()
        {
            string[] files = GetAllFilePaths();
            StringBuilder releaseData = new StringBuilder();
            foreach(string file in files)
            {
                releaseData.Append(ReadData(file));
            }
            m_allReleaseNotes = releaseData.ToString();
        }
        #endregion

        #region Low Level Functions
        private string ReadData(string path) 
        {
            if(!File.Exists(path))
            {
                File.Create(path);
            }

            return File.ReadAllText(path);
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

        private string[] GetAllFilePaths()
            => Directory.GetFiles(Application.dataPath + FILE_DIRECTORY)
                     .Where(x => x.EndsWith(".meta") == false).ToArray();
        #endregion
    }
}
