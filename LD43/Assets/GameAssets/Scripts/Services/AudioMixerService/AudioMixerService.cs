using System;
using System.Collections;
using DogHouse.Core.Services;
using UnityEngine;
using UnityEngine.Audio;

namespace DogHouse.Services
{
    /// <summary>
    /// AudioMixerService is an implementation of the
    /// audio mixer service. The audio mixer service uses
    /// the built in unity controls to control the audio
    /// levels.
    /// </summary>
    public class AudioMixerService : MonoBehaviour, IAudioMixerService
    {
        #region Public Variables
        #endregion

        #region Private Variables
        [SerializeField]
        private AudioMixerSnapshot m_gameMixSnapshot;

        [SerializeField]
        private AudioMixerSnapshot m_sceneTransitionSnapshot;

        #endregion

        #region Main Methods
        void OnEnable() => RegisterService();
        void OnDisable() => UnregisterService();

        public void RegisterService()
        {
            ServiceLocator.Register<IAudioMixerService>(this);
        }

        public void UnregisterService()
        {
            ServiceLocator.Unregister<IAudioMixerService>(this);
        }

        public void TransitionToGameMix(float time, Action callback = null)
        {
            Transition(time, m_gameMixSnapshot);
            if (callback != null) StartCoroutine(InvokeCallback(time, callback));
        }

        public void TransitionToTransitionMix(float time, Action callback = null)
        {
            Transition(time, m_sceneTransitionSnapshot);
            if (callback != null) StartCoroutine(InvokeCallback(time, callback));
        }
        #endregion

        #region Utility Methods
        private void Transition(float time, AudioMixerSnapshot snapshot)
        {
            snapshot.TransitionTo(time);
        }

        private IEnumerator InvokeCallback(float time, Action callback)
        {
            yield return new WaitForSeconds(time);
            callback?.Invoke();
        }
        #endregion
    }
}
