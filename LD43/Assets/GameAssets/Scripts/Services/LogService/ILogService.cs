using DogHouse.Core.Services;

namespace DogHouse.Services
{
    /// <summary>
    /// ILogService is an interface that all log
    /// services must implement. A log service is 
    /// responsible for receiving Debug logs and
    /// printing them out to a console.
    /// </summary>
    public interface ILogService : IService 
    {
        void Log(string message);
        void LogWarning(string message);
        void LogError(string message);
    }
}
