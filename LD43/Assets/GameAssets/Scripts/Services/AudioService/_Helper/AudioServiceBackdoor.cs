using DogHouse.Core.Services;
using UnityEngine;

namespace DogHouse.Services
{
    /// <summary>
    /// AudioServiceBackdoor is a backdoor component that
    /// gives access to the methods of the AudioService.
    /// </summary>
    public class AudioServiceBackdoor : MonoBehaviour, IAudioService
    {
        #region Private Variables
        private ServiceReference<IAudioService> m_audioService 
                = new ServiceReference<IAudioService>();
        #endregion

        #region Main Methods
        public void Play(string AssetID)
        {
            m_audioService.Reference?.Play(AssetID);
        }
        
        public void RegisterService() {}
        #endregion
    }
}
