using DogHouse.Core.Services;
using UnityEngine;
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
        #region Private Variables
        [SerializeField]
        private bool m_displayDebugs = false;
        #endregion

        #region Main Methods
        public void Log(string message)
        {
            if (!m_displayDebugs) return;
            ConsoleLog(message);
        }

        public void LogError(string message)
        {
            if (!m_displayDebugs) return;
            ConsoleLogError(message);
        }

        public void LogWarning(string message)
        {
            if (!m_displayDebugs) return;
            ConsoleLogWarning(message);
        }
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
