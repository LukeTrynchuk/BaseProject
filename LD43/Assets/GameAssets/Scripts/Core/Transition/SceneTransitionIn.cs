using DogHouse.Core.Services;
using DogHouse.Services;
using UnityEngine;
using UnityEngine.Events;

namespace DogHouse.Core.Transition
{
    /// <summary>
    /// SceneTransitionIn will transition the 
    /// camera into the new scene on start.
    /// </summary>
    public class SceneTransitionIn : MonoBehaviour 
    {
        #region Private Variables
        [SerializeField]
        private UnityEvent m_onFadeInFinished;

        [SerializeField]
        private float m_fadeInTime;

        private ServiceReference<ICameraTransition> m_cameraTransition
            = new ServiceReference<ICameraTransition>();
        #endregion

        #region Main Methods
        private void Start()
        {
            if (!m_cameraTransition.isRegistered())
            {
                Debug.Log("No Camera Transition Found");
                return;
            }
            m_cameraTransition.Reference.FadeOut(m_fadeInTime, FadeInFinished);
        }
        #endregion

        #region Utility Methods
        private void FadeInFinished() => m_onFadeInFinished?.Invoke();
        #endregion
    }
}
