using DogHouse.Core.Services;
using System.IO;

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
        #endregion
    }
}
