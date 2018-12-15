using DogHouse.Core.Services;

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

        string[] ReadDirectory(string directoryPath, string[] omittedFileExtensions = null);
    }
}
