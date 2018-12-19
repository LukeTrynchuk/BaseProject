using DogHouse.Core.Services;
using UnityEngine;
using System.Text;

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
        private ServiceReference<IFileReaderService> m_fileReader 
            = new ServiceReference<IFileReaderService>();

        private string m_releaseNotes = default(string);
        private const string FILE_DIRECTORY = "/GameAssets/Resources/Core/ReleaseNotes/";
        private string[] m_omitExtensions = { ".meta" };
        #endregion

        #region Main Methods
        public string FetchReleaseNotes() => m_releaseNotes;
     
        void Start()
        {
            m_fileReader.AddRegistrationHandle(HandleFileReaderRegistered);
        }
        #endregion

        #region Utility Methods
        private void HandleFileReaderRegistered()
        {
            string directory = Application.dataPath + FILE_DIRECTORY;
            m_fileReader.Reference?.ReadDirectoryAsync(directory, 
                                                       HandleDirectoryRead, 
                                                       m_omitExtensions);
        }

        private void HandleDirectoryRead(string[] fileContents)
        {
            m_releaseNotes = BuildReleaseNotes(fileContents);
        }

        private string BuildReleaseNotes(string[] fileContents)
        {
            StringBuilder releaseData = new StringBuilder();
            foreach (string file in fileContents)
                releaseData.Append(file);

            return releaseData.ToString();
        }
        #endregion
    }
}
