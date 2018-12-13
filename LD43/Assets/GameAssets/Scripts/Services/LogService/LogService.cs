using DogHouse.Core.Services;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

namespace DogHouse.Services
{
    /// <summary>
    /// LogService is a concrete implementation
    /// of the ILogService. The Log Service will
    /// send Logs to the Unity Console.
    /// </summary>
    public class LogService : BaseService<ILogService>, ILogService
    {
        #region Main Methods
        public void Log(string message) => ConsoleLog(message);
        public void LogError(string message) => ConsoleLogError(message);
        public void LogWarning(string message) => ConsoleLogWarning(message);
        #endregion

        #region Utility Methods
        [Conditional("ENABLE_LOGS")]
        private void ConsoleLog(string message) => Debug.Log(message);

        [Conditional("ENABLE_LOGS")]
        private void ConsoleLogWarning(string message) => Debug.LogWarning(message);

        [Conditional("ENABLE_LOGS")]
        private void ConsoleLogError(string message) => Debug.LogError(message);
        #endregion
    }
}
