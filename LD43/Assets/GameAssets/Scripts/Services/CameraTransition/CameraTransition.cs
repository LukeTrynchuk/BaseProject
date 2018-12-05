using System;
using System.Collections;
using DogHouse.Core.Services;
using UnityEngine;
using DogHouse.Core.UI;

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
    public class CameraTransition : MonoBehaviour, ICameraTransition
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
        public void OnEnable() 
        {
            RegisterService();
            m_imageColorController = m_fadeObject
                .GetComponent<ImageColorController>();
        }
        void OnDisable() 
        {
            UnregisterService();
        }

        public void RegisterService()
        {
            ServiceLocator.Register<ICameraTransition>(this);
        }

        public void UnregisterService()
        {
            ServiceLocator.Unregister<ICameraTransition>(this);
        }

        public void FadeIn(float Time)
        {
            if (!CanFadeIn) return;
            StartCoroutine(TransitionCamera(Time, true));
        }

        public void FadeOut(float Time)
        {
            if (!CanFadeOut) return;
            StartCoroutine(TransitionCamera(Time, false));
        }

        public void FadeIn(float Time, Action callback)
        {
            if (!CanFadeIn) return;
            StartCoroutine(TransitionCamera(Time, true, callback));
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
                totalTime += Time.deltaTime;
                t = totalTime / time;

                alpha = (isFadingIn) 
                    ? Mathf.Lerp(0, 1, t)
                    : Mathf.Lerp(1, 0, t);

                SetBackgroundAlpha(alpha);
                yield return null;

            } while (t < 1f);

            m_state = (isFadingIn) ? CameraTransitionState.IDLE_IN 
                                   : CameraTransitionState.IDLE_OUT;

            callback?.Invoke();
        }

        private void SetBackgroundAlpha(float alpha)
        {
            m_alpha = alpha;
            if (m_imageColorController == null) return;
            Color imageColor = m_imageColorController.ImageColor;
            imageColor.a = m_alpha;
            m_imageColorController.SetColor(imageColor);
        }
        #endregion
    }
}
