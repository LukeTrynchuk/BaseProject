using DogHouse.Core.Services;

namespace DogHouse.Services
{
    /// <summary>
    /// IRemoteCSVReader is an interface
    /// that all remote csv readers must
    /// implement. A remote csv reader
    /// will read a csv on some remote 
    /// server.
    /// </summary>
    public interface IRemoteCSVReader : IService
    {
        string[][] FetchRemoteCSV(string url);
    }
}
