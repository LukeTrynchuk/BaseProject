using System.Collections.Generic;
using DogHouse.Core.Services;
using UnityEngine;
using UnityEngine.Analytics;

namespace DogHouse.Services
{
    /// <summary>
    /// UnityAnalyticsService is an implementation
    /// of the Analytics Service. The Analytics service
    /// is responsible for implementing a system to
    /// send analytics data to a remote server.
    /// </summary>
    public class UnityAnalyticsService : MonoBehaviour, IAnalyticsService
    {
        #region Public Variables
        #endregion

        #region Private Variables
        private const string m_version = "0.1";
        private const string VERSION_KEY = "Version";

        private const string GAME_START = "Game Started";
        private const string LOGO_START = "Logo Started";
        private const string LOGO_END = "Logo End";
        private const string SCENE_LOADED = "Scene Loaded";
        private const string LEVEL_STARTED = "Level Started";
        private const string START_BUTTON = "Start Button";
        #endregion

        #region Main Methods
        void OnEnable() => RegisterService();
        void OnDisable() => UnregisterService();

        public void RegisterService()
        {
            ServiceLocator.Register<IAnalyticsService>(this);
        }

        public void UnregisterService()
        {
            ServiceLocator.Unregister<IAnalyticsService>(this);
        }

        public void SendGameStartEvent() => SendEvent(GAME_START);
        public void SendLogosStartEvent() => SendEvent(LOGO_START);
        public void SendLogosEndEvent() => SendEvent(LOGO_END);
        public void SendStartButtonClickedEvent() => SendEvent(START_BUTTON);

        public void SendSceneLoadedEvent(string sceneName)
        {
            SendEvent(SCENE_LOADED,
                      new Dictionary<string, object>
                      {
                        {"Scene Name", sceneName}
                      });
        }

        public void SendLevelStartedEvent(string levelName)
        {
            SendEvent(LEVEL_STARTED,
                      new Dictionary<string, object>
                      {
                        {"Level Name", levelName}
                      });
        }

        public void SendLevelFinishedEvent(string levelName)
        {
            SendEvent(LEVEL_STARTED,
                      new Dictionary<string, object>
                      {
                        {"Level Name", levelName}
                      });
        }
        #endregion

        #region Utility Methods
        private void SendEvent(string EventID, 
                               Dictionary<string, object> parameters = null)
        {
            Dictionary<string, object> eventParams 
                = new Dictionary<string, object>();

            if (parameters != null) eventParams = parameters;

            eventParams.Add(VERSION_KEY, m_version);

            Analytics.CustomEvent(EventID, eventParams);
        }
        #endregion
    }
}
