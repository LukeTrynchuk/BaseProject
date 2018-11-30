using DogHouse.Core.Services;
using UnityEngine;

namespace DogHouse.Services
{
    /// <summary>
    /// AnalyticsServiceBackdoor is a backdoor implementation
    /// of the analytics service. Other objects can use this
    /// to easily implement analytics service features.
    /// </summary>
    public class AnalyticsServiceBackdoor : MonoBehaviour, IAnalyticsService
    {
        #region Private Variables
        private ServiceReference<IAnalyticsService> m_analyticsService
            = new ServiceReference<IAnalyticsService>();
        #endregion

        #region Main Methods
        public void RegisterService() {}

        public void SendGameStartEvent() 
            => m_analyticsService.Reference?.SendGameStartEvent();

        public void SendLevelFinishedEvent(string levelName)
            => m_analyticsService.Reference?.SendLevelFinishedEvent(levelName);

        public void SendLevelStartedEvent(string levelName)
            => m_analyticsService.Reference?.SendLevelStartedEvent(levelName);

        public void SendLogosEndEvent()
            => m_analyticsService.Reference?.SendLogosEndEvent();

        public void SendLogosStartEvent()
            => m_analyticsService.Reference?.SendLogosStartEvent();

        public void SendSceneLoadedEvent(string sceneName)
            => m_analyticsService.Reference?.SendSceneLoadedEvent(sceneName);

        public void SendStartButtonClickedEvent()
            => m_analyticsService.Reference?.SendStartButtonClickedEvent();
        #endregion
    }
}
