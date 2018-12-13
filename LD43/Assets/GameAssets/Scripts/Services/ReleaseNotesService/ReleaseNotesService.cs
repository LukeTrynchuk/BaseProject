﻿using DogHouse.Core.Services;
using UnityEngine;
using System.Linq;
using System.Text;
using System.IO;

namespace DogHouse.Services
{
    /// <summary>
    /// ReleaseNotesService is a concrete 
    /// implementation of the IReleaseNotesService.
    /// The ReleaseNotesService is responsible for
    /// reading all the release notes and producing
    /// a finalized version for other objects to fetch.
    /// </summary>
    public class ReleaseNotesService : BaseService<IReleaseNotesService>, IReleaseNotesService
    {
        #region Private Variables
        private string m_releaseNotes = "";
        private const string FILE_DIRECTORY = "/GameAssets/Resources/Core/ReleaseNotes/";
        #endregion

        #region Main Methods
        public string FetchReleaseNotes() => m_releaseNotes;
     
        void Start()
        {
            string[] files = GetAllFilePaths();
            StringBuilder releaseData = new StringBuilder();
            foreach(string file in files)
            {
                releaseData.Append(ReadFile(file));
            }
            m_releaseNotes = releaseData.ToString();
        }
        #endregion

        #region Utility Methods
        private string ReadFile(string path)
        {
            if (!File.Exists(path)) return default(string);
            return File.ReadAllText(path);
        }

        private string[] GetAllFilePaths() =>
            Directory.GetFiles(Application.dataPath + FILE_DIRECTORY)
                     .Where(x => x.EndsWith(".meta") == false).ToArray();
        #endregion
    }
}