using System;
using System.Collections;
using UnityEngine;
using DogHouse.Core.UI;
using DogHouse.Core.Services;
using static UnityEngine.Mathf;
using static UnityEngine.Time;

namespace DogHouse.Services
{
    /// <summary>
    /// CameraTransition is an implementation of the
    /// ICameraTransition service. The Camera Transition
    /// is responsible for creating a fade in/out effect
    /// on the current main camera. This can be used
    /// for things such as transitioning between scenes
    /// or menus.
    /// </summary>
    public class CameraTransition : BaseService<ICameraTransition>, ICameraTransition
    {
        #region Public Variables
        public CameraTransitionState State => m_state;
        #endregion

        #region Private Variables
        [SerializeField]
        private GameObject m_fadeObject = null;

        private CameraTransitionState m_state 
                = CameraTransitionState.IDLE_IN;

        private ImageColorController m_imageColorController;
        private float m_alpha = 0f;

        private bool CanFadeIn => m_state == CameraTransitionState.IDLE_OUT;
        private bool CanFadeOut => m_state == CameraTransitionState.IDLE_IN;
        #endregion

        #region Main Methods
        void Start()
        {
            m_imageColorController = m_fadeObject
                .GetComponent<ImageColorController>();
        }

        public void FadeIn(float Time)
        {
            if (!CanFadeIn) return;
            StartCoroutine(TransitionCamera(Time, true));
        }

        public void FadeIn(float Time, Action callback)
        {
            if (!CanFadeIn) return;
            StartCoroutine(TransitionCamera(Time, true, callback));
        }

        public void FadeOut(float Time)
        {
            if (!CanFadeOut) return;
            StartCoroutine(TransitionCamera(Time, false));
        }

        public void FadeOut(float Time, Action callback)
        {
            if (!CanFadeOut) return;
            StartCoroutine(TransitionCamera(Time, false, callback));
        }
        #endregion

        #region Utility Methods
        private IEnumerator TransitionCamera(float time, bool isFadingIn, Action callback = null)
        {
            m_state = CameraTransitionState.TRANSITIONING;
            float totalTime = 0f;
            float t = 0f;
            float alpha = 0f;

            do
            {
                totalTime += deltaTime;
                t = totalTime / time;
                alpha = (isFadingIn) ? Lerp(0, 1, t) : Lerp(1, 0, t);
                SetBackgroundAlpha(alpha);

                yield return null;

            } while (t < 1f);

            m_state = (isFadingIn) ? CameraTransitionState.IDLE_IN 
                                   : CameraTransitionState.IDLE_OUT;

            callback?.Invoke();
        }

        private void SetBackgroundAlpha(float alpha)
        {
            if (m_imageColorController == null) return;

            m_alpha = alpha;
            Color imageColor = m_imageColorController.ImageColor;
            imageColor.a = m_alpha;
            m_imageColorController.SetColor(imageColor);
        }
        #endregion
    }
}
