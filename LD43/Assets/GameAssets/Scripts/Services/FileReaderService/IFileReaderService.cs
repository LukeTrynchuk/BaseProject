using DogHouse.Core.Services;
using System;

namespace DogHouse.Services
{
    /// <summary>
    /// IFileReaderService is an interface that
    /// all File Reader Services must implement.
    /// A file reader service is responsible for
    /// reading files from the hard drive.
    /// </summary>
    public interface IFileReaderService : IService
    {
        string ReadFile(string path);
        void ReadFileAsync(string path, Action<string> callback);

        string[] ReadDirectory(string directoryPath, string[] omittedFileExtensions = null);
        void ReadDirectoryAsync(string directoryPath, Action<string[]> callback, string[] omittedFileExtensions = null);
    }
}
