using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using static UnityEngine.Time;
using static UnityEngine.Color;

namespace DogHouse.Core.Logo
{
    /// <summary>
    /// The Splash Screen Player will play a series of 
    /// splash images in order and invoke an event when
    /// all the images are finished playing.
    /// </summary>
    public class SplashScreenPlayer : MonoBehaviour
    {
        #region Private Variables
        [SerializeField]
        private Camera m_camera = null;

        [SerializeField]
        private Image m_image = null;

        [SerializeField]
        private SplashScreen[] m_splashImages = null;

        [SerializeField]
        private UnityEvent m_onFinishedSplashImages = null;

        private Color m_backgroundColor = black;

        private const float BACKGROUND_LERP_TIME = 1f;
        private const float IMAGE_LERP_TIME = 0.5f;
        private float m_tValue = 0f;
        private Color m_startColor;
        #endregion

        #region Main Methods
        private void Awake() => m_startColor = m_backgroundColor;

        private void Start() => StartCoroutine(_PlaySequence());
        #endregion

        #region Utility Methods
        private IEnumerator _PlaySequence()
        {
            m_image.color = new Color(m_image.color.r,
                                      m_image.color.g,
                                      m_image.color.b,
                                      0f);
            yield return SequenceLogos();
            yield return FadeBackgroundToBlack();
            m_onFinishedSplashImages?.Invoke();
        }

        private IEnumerator SequenceLogos()
        {
            for (int i = 0; i < m_splashImages.Length; i++)
            {
                yield return SequenceLogo(i);
            }
        }

        private IEnumerator SequenceLogo(int i)
        {
            yield return FadeBackgroundIn(i);
            SetLogoImage(i);
            yield return FadeLogoIn();
            yield return Wait(m_splashImages[i].TimeOnScreen);
            yield return FadeLogoOut();

            m_startColor = m_camera.backgroundColor;
            m_tValue = 0f;
        }

        private void SetLogoImage(int i)
        {
            m_image.overrideSprite = m_splashImages[i].Image;
            m_image.rectTransform.sizeDelta = m_splashImages[i].m_imageSize;
            m_tValue = 0f;
        }

        private IEnumerator FadeBackgroundIn(int i)
        {
            do
            {
                LerpBackgroundColor(ref m_tValue, m_startColor, 
                                    m_splashImages[i].BackgroundColor);

                yield return null;
            } while (m_tValue < 1f);
        }

        private IEnumerator FadeBackgroundToBlack()
        {
            do
            {
                LerpBackgroundColor(ref m_tValue, m_startColor, black);
                yield return null;
            } while (m_tValue < 1f);
        }

        private IEnumerator FadeLogoIn()
        {
            do
            {
                LerpImageIn(ref m_tValue);
                yield return null;
            } while (m_tValue < 1f);

            m_tValue = 0f;
        }

        private IEnumerator Wait(float time)
        {
            yield return new WaitForSeconds(time);
        }

        private IEnumerator FadeLogoOut()
        {
            do
            {
                LerpImageOut(ref m_tValue);
                yield return null;
            } while (m_tValue < 1f);
        }
        #endregion

        #region Low Level Functions
        private void LerpBackgroundColor(ref float TValue, Color StartColor, Color TargetColor)
        {
            TValue += deltaTime / BACKGROUND_LERP_TIME;
            m_backgroundColor = Lerp(StartColor, TargetColor, TValue);
            m_camera.backgroundColor = m_backgroundColor;
        }

        private void LerpImageOut(ref float TValue)
        {
            TValue += deltaTime / IMAGE_LERP_TIME;
            m_image.color = new Color(m_image.color.r, 
                                      m_image.color.g, 
                                      m_image.color.b, 
                                      1f - TValue);
        }

        private void LerpImageIn(ref float TValue)
        {
            TValue += deltaTime / IMAGE_LERP_TIME;
            m_image.color = new Color(m_image.color.r,
                                      m_image.color.g, 
                                      m_image.color.b, 
                                      TValue);
        }
        #endregion
    }
}
