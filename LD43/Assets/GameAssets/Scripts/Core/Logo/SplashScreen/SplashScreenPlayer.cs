using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using DogHouse.Core.Data;
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
        private Logos m_logos;

        //Logo Player
            //Image Displayer
                //Camera Package
                    [SerializeField]
                    private Camera m_camera = null;
                    private Color m_backgroundColor = black;

                //Image Field
                    [SerializeField]
                    private Image m_image = null;

            //Splash Screen Content
                //Logo(s)
                    [SerializeField]
                    private SplashScreen[] m_splashImages = null;

                //Logo Settings
                    private const float BACKGROUND_LERP_TIME = 1f;
                    private const float IMAGE_LERP_TIME = 0.5f;
        
        //Event Package
        [SerializeField]
        private UnityEvent m_onFinishedSplashImages = null;
        #endregion

        #region Main Methods
        private void Start() => StartCoroutine(_PlaySequence());
        #endregion

        #region Utility Methods
        //Normally, a method should only have up to 1 level of indentation. I
        //make the exception for Coroutines.
        private IEnumerator _PlaySequence()
        {
            float tValue = 0f;
            Color startColor = m_backgroundColor;

            m_image.color = new Color(m_image.color.r, 
                                      m_image.color.g, 
                                      m_image.color.b, 
                                      0f);

            for (int i = 0; i < m_splashImages.Length; i++)
            {
                do
                {
                    LerpBackgroundColor(ref tValue, startColor, m_splashImages[i].BackgroundColor);
                    yield return null;
                } while (tValue < 1f);

                m_image.overrideSprite = m_splashImages[i].Image;
                m_image.rectTransform.sizeDelta = m_splashImages[i].m_imageSize;
                tValue = 0f;

                do
                {
                    LerpImageIn(ref tValue);
                    yield return null;
                } while (tValue < 1f);

                yield return new WaitForSeconds(m_splashImages[i].TimeOnScreen);

                tValue = 0f;

                do
                {
                    LerpImageOut(ref tValue);
                    yield return null;
                } while (tValue < 1f);

                startColor = m_camera.backgroundColor;
                tValue = 0f;
            }

            do
            {
                LerpBackgroundColor(ref tValue, startColor, black);
                yield return null;
            } while (tValue < 1f);
                

            m_onFinishedSplashImages?.Invoke();
        }

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
