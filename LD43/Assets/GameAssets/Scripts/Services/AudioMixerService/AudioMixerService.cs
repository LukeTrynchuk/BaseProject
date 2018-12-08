using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using DogHouse.Core.Services;

namespace DogHouse.Services
{
    /// <summary>
    /// AudioMixerService is an implementation of the
    /// audio mixer service. The audio mixer service uses
    /// the built in unity controls to control the audio
    /// levels.
    /// </summary>
    public class AudioMixerService : BaseService<IAudioMixerService>, IAudioMixerService
    {
        #region Private Variables
        [SerializeField]
        private AudioMixerSnapshot m_gameMixSnapshot = null;

        [SerializeField]
        private AudioMixerSnapshot m_sceneTransitionSnapshot = null;
        #endregion

        #region Main Methods
        public override void OnDisable() 
        {
            base.OnDisable();
            StopAllCoroutines();
        }

        public void TransitionToGameMix(float time, Action callback = null)
        {
            TransitionSnapshot(time, m_gameMixSnapshot);
            if (callback != null) StartCoroutine(InvokeCallback(time, callback));
        }

        public void TransitionToTransitionMix(float time, Action callback = null)
        {
            TransitionSnapshot(time, m_sceneTransitionSnapshot);
            if (callback != null) StartCoroutine(InvokeCallback(time, callback));
        }
        #endregion

        #region Utility Methods
        private void TransitionSnapshot(float time, AudioMixerSnapshot snapshot) =>
            snapshot.TransitionTo(time);

        private IEnumerator InvokeCallback(float time, Action callback)
        {
            yield return new WaitForSeconds(time);
            callback?.Invoke();
        }
        #endregion
    }
}
