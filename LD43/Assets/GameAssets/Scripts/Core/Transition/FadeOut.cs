using DogHouse.Core.Services;
using DogHouse.Services;
using UnityEngine;
using UnityEngine.Events;

namespace DogHouse.Core.Transition
{
    /// <summary>
    /// FadeOut will call the Fadeout 
    /// the camera when used.
    /// </summary>
    public class FadeOut : MonoBehaviour 
    {
        #region Public Variables
        #endregion

        #region Private Variables
        [SerializeField]
        private UnityEvent m_onFadeOutComplete;

        [SerializeField]
        private float m_fadeOutTime;

        private ServiceReference<ICameraTransition> m_cameraTransition 
            = new ServiceReference<ICameraTransition>();
        #endregion
        
        #region Main Methods
        public void FadeCameraOut()
        {
            m_cameraTransition.Reference?.FadeIn(m_fadeOutTime, FadeOutFinished);
        }
        #endregion

        #region Utility Methods
        private void FadeOutFinished() => m_onFadeOutComplete?.Invoke();
        #endregion
    }
}
