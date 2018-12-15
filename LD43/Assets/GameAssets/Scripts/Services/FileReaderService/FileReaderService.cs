using DogHouse.Core.Services;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace DogHouse.Services
{
    /// <summary>
    /// FileReaderService is a concrete implementation
    /// of the File Reader Service interface. The 
    /// File Reeader Service is responsible for reading
    /// files from the hard drive.
    /// </summary>
    public class FileReaderService : BaseService<IFileReaderService>, IFileReaderService
    {
        #region Main Methods
        public string ReadFile(string path)
        {
            if (!File.Exists(path)) return default(string);
            return File.ReadAllText(path);
        }

        public string[] ReadDirectory(string directoryPath, string[] omittedFileExtensions = null)
        {
            if (!Directory.Exists(directoryPath)) return default(string[]);
            string[] paths = FetchFilePaths(directoryPath, omittedFileExtensions);
            string[] files = new string[paths.Length];

            for (int i = 0; i < paths.Length; i++)
                files[i] = ReadFile(paths[i]);

            return files;
        }
        #endregion

        #region Utility Methods
        private string[] FetchFilePaths(string directoryPath, string[] omittedFileExtensions = null)
        {
            if (!Directory.Exists(directoryPath)) return default(string[]);
            List<string> paths = Directory.GetFiles(directoryPath).ToList();
            if (omittedFileExtensions == null) return paths.ToArray();

            paths = paths.Where(x => !omittedFileExtensions.Any(x.EndsWith)).ToList();
            return paths.ToArray();
        }
        #endregion
    }
}
