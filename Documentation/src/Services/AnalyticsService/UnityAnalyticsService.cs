using System.Collections.Generic;
using UnityEngine.Analytics;
using DogHouse.Core.Services;

namespace DogHouse.Services
{
    /// <summary>
    /// UnityAnalyticsService is an implementation
    /// of the Analytics Service. The Analytics service
    /// is responsible for implementing a system to
    /// send analytics data to a remote server.
    /// </summary>
    public class UnityAnalyticsService : BaseService<IAnalyticsService>, IAnalyticsService
    {
        #region Private Variables
        private const string m_version = "0.1";                                 //TODO : This will be fetched from a VersionService in the future
        private const string VERSION_KEY = "Version";

        private const string GAME_START = "Game Started";
        private const string LOGO_START = "Logo Started";
        private const string LOGO_END = "Logo End";
        private const string SCENE_LOADED = "Scene Loaded";
        private const string LEVEL_STARTED = "Level Started";
        private const string START_BUTTON = "Start Button";

        private const string LEVEL_NAME_KEY = "Level Name";
        private const string SCENE_NAME_KEY = "Scene Name";
        #endregion

        #region Main Methods
        public void SendGameStartEvent()          => SendEvent(GAME_START);
        public void SendLogosStartEvent()         => SendEvent(LOGO_START);
        public void SendLogosEndEvent()           => SendEvent(LOGO_END);
        public void SendStartButtonClickedEvent() => SendEvent(START_BUTTON);

        public void SendSceneLoadedEvent(string sceneName)
        {
            SendEvent(SCENE_LOADED,
                      new Dictionary<string, object>
                      {
                        {SCENE_NAME_KEY, sceneName}
                      });
        }

        public void SendLevelStartedEvent(string levelName)
        {
            SendEvent(LEVEL_STARTED,
                      new Dictionary<string, object>
                      {
                        {LEVEL_NAME_KEY, levelName}
                      });
        }

        public void SendLevelFinishedEvent(string levelName)
        {
            SendEvent(LEVEL_STARTED,
                      new Dictionary<string, object>
                      {
                        {LEVEL_NAME_KEY, levelName}
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
