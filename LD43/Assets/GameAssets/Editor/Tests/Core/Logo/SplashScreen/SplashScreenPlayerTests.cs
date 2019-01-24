using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using UnityEngine.UI;
using System.Diagnostics;
using DogHouse.Core.Logo;
using System;
using UnityEngine.Events;

namespace DogHouse.Tests
{
    /// <summary>
    /// SplashScreenPlayerTests houses all of the
    /// unit tests that ensure that the Splash Screen
    /// player is working properly. The following questions
    /// have been answered using the unit tests : 
    /// ===================================================
    /// -> The Specified Image's sprite is being set to the
    ///         given sprite.
    /// 
    /// -> The Splash Screen player will skip in the editor
    ///         if the user has specified. 
    /// 
    /// -> The Splash Screen Player will not play unless 
    ///         it has been given at least one image to play.
    /// 
    /// -> The splash screen player takes more time to complete
    ///         than the sum of all the logo times. There should be
    ///         more time used for transitions. 
    /// 
    /// -> A Logo will play even if it has already been specified.
    /// 
    /// -> The Logo player will not play a logo if the image is null
    ///         or the time to play is less than or equal to 0 seconds.
    /// 
    /// -> The Splash Screen Player invokes an event when the
    ///         logos are done playing.
    /// 
    /// -> The Splash Screen Player invokes an event when the user has
    ///         chosen to skip the logos.
    /// </summary>
    public class SplashScreenPlayerTests : MonoBehaviour
    {
        #region Private Variables
        private Camera m_camera;
        private Canvas m_canvas;
        private Image m_image;
        private SplashScreenPlayer m_player;
        #endregion

        #region Test Setup Teardown
        [UnitySetUp]
        public IEnumerator _Setup()
        {
            //Create The Camera
            GameObject cam = new GameObject();
            cam.AddComponent<Camera>();
            cam.tag = "MainCamera";

            //Create The Image
            GameObject canvas = new GameObject();
            canvas.AddComponent<Canvas>();
            canvas.AddComponent<CanvasScaler>();
            canvas.AddComponent<GraphicRaycaster>();

            GameObject image = new GameObject();
            image.AddComponent<Image>();
            image.transform.SetParent(canvas.transform);

            //Create The Splash Screen Player 
            GameObject splashScreenPlayer = new GameObject();
            splashScreenPlayer.AddComponent<SplashScreenPlayer>();

            m_camera = cam.GetComponent<Camera>();
            m_canvas = canvas.GetComponent<Canvas>();
            m_image = image.GetComponent<Image>();
            m_player = splashScreenPlayer.GetComponent<SplashScreenPlayer>();

            yield return null;
        }

        [UnityTearDown]
        public IEnumerator _Teardown()
        {
            DestroyImmediate(FindObjectOfType<Camera>().gameObject);
            DestroyImmediate(FindObjectOfType<Image>().gameObject);
            DestroyImmediate(FindObjectOfType<Canvas>().gameObject);
            DestroyImmediate(FindObjectOfType<SplashScreenPlayer>().gameObject);
            yield return null;
        }
        #endregion

        #region Tests
        /// <summary>
        /// This test ensures that given a logo to play,
        /// the player will set the image's sprite to that
        /// logo.
        /// </summary>
        [UnityTest]
        public IEnumerator _Images_Sprite_Being_Set_To_Given_Logo()
        {
            //Create splash screen
            SplashScreen screen = ScriptableObject.CreateInstance<SplashScreen>();
            screen.Image = Sprite.Create(default(Texture2D), default(Rect), default(Vector2));
            screen.BackgroundColor = Color.white;
            screen.TimeOnScreen = 1f;
            SplashScreen[] screens = new SplashScreen[] { screen };

            m_player.Setup(m_camera, m_image, screens, false);

            yield return Wait(0.3f);

            Assert.AreSame(screen.Image, m_image.sprite);
        }

        /// <summary>
        /// This test ensures that the player will skip the 
        /// slide show when it has been specified.
        /// </summary>
        [UnityTest]
        public IEnumerator _Will_Skip_When_Asked_To()
        {
            Image image = FindObjectOfType<Image>().GetComponent<Image>();

            SplashScreenPlayer player = FindObjectOfType<SplashScreenPlayer>()
                .GetComponent<SplashScreenPlayer>();

            Camera camera = FindObjectOfType<Camera>().GetComponent<Camera>();

            player.Setup(camera, image, null, false);

            Assert.True(false);

            yield return null;
        }

        /// <summary>
        /// This test ensures that the player will not play anything when
        /// there are no logos given.
        /// </summary>
        [UnityTest]
        public IEnumerator _Will_Not_Play_When_There_Are_No_Logos()
        {
            Image image = FindObjectOfType<Image>().GetComponent<Image>();

            SplashScreenPlayer player = FindObjectOfType<SplashScreenPlayer>()
                .GetComponent<SplashScreenPlayer>();

            Camera camera = FindObjectOfType<Camera>().GetComponent<Camera>();

            player.Setup(camera, image, null, false);

            Assert.True(false);

            yield return null;
        }

        /// <summary>
        /// This test ensures that the player will play the logos in an
        /// expected manner. The time taken should increase when more 
        /// logos are added and the time should be greater than the sum
        /// of all the logo times.
        /// </summary>
        [UnityTest]
        public IEnumerator _Player_Plays_Logos_In_Appropriate_Time()
        {
            Image image = FindObjectOfType<Image>().GetComponent<Image>();

            SplashScreenPlayer player = FindObjectOfType<SplashScreenPlayer>()
                .GetComponent<SplashScreenPlayer>();

            Camera camera = FindObjectOfType<Camera>().GetComponent<Camera>();

            player.Setup(camera, image, null, false);

            Assert.True(false);

            yield return null;
        }

        /// <summary>
        /// This test ensures that the player will play a logo even
        /// if it has already been played.
        /// </summary>
        [UnityTest]
        public IEnumerator _Logos_Play_Even_When_Already_Played()
        {
            Image image = FindObjectOfType<Image>().GetComponent<Image>();

            SplashScreenPlayer player = FindObjectOfType<SplashScreenPlayer>()
                .GetComponent<SplashScreenPlayer>();

            Camera camera = FindObjectOfType<Camera>().GetComponent<Camera>();

            player.Setup(camera, image, null, false);

            Assert.True(false);

            yield return null;
        }

        /// <summary>
        /// This test ensures that the player will not play a logo
        /// if the splash screen object that has been provided contains
        /// a null image.
        /// </summary>
        [UnityTest]
        public IEnumerator _Logo_Will_Not_Play_If_Image_Is_Null()
        {
            Image image = FindObjectOfType<Image>().GetComponent<Image>();

            SplashScreenPlayer player = FindObjectOfType<SplashScreenPlayer>()
                .GetComponent<SplashScreenPlayer>();

            Camera camera = FindObjectOfType<Camera>().GetComponent<Camera>();

            player.Setup(camera, image, null, false);

            Assert.True(false);

            yield return null;
        }

        /// <summary>
        /// This test ensures that the player will not play a logo if the specified
        /// time is less than or equal to zero.
        /// </summary>
        [UnityTest]
        public IEnumerator _Logo_Will_Not_Play_If_Time_Is_Less_Than_Or_Equal_To_Zero()
        {
            Image image = FindObjectOfType<Image>().GetComponent<Image>();

            SplashScreenPlayer player = FindObjectOfType<SplashScreenPlayer>()
                .GetComponent<SplashScreenPlayer>();

            Camera camera = FindObjectOfType<Camera>().GetComponent<Camera>();

            player.Setup(camera, image, null, false);

            Assert.True(false);

            yield return null;
        }

        /// <summary>
        /// This test ensures that the player invokes an event when the 
        /// player is finished.
        /// </summary>
        [UnityTest]
        public IEnumerator _Event_Triggered_When_Logos_Are_Done_Playing()
        {
            SplashScreen screen = ScriptableObject.CreateInstance<SplashScreen>();
            screen.Image = Sprite.Create(default(Texture2D), default(Rect), default(Vector2));
            screen.BackgroundColor = Color.white;
            screen.TimeOnScreen = 1f;
            SplashScreen[] screens = { screen };

            bool finished = false;

            Action test = () =>
            {
                finished = true;
            };

            UnityAction action = new UnityAction(test);

            m_player.Setup(m_camera, m_image, screens, false, action);

            yield return Wait(8f);

            Assert.True(finished);
        }

        /// <summary>
        /// This test ensures that the player invokes an event even if the 
        /// player has skipped playing the logos.
        /// </summary>
        [UnityTest]
        public IEnumerator _Event_Triggered_When_Logos_Are_Skipped()
        {
            Image image = FindObjectOfType<Image>().GetComponent<Image>();

            SplashScreenPlayer player = FindObjectOfType<SplashScreenPlayer>()
                .GetComponent<SplashScreenPlayer>();

            Camera camera = FindObjectOfType<Camera>().GetComponent<Camera>();

            player.Setup(camera, image, null, false);

            Assert.True(false);

            yield return null;
        }
        #endregion

        #region Utility Methods
        private void Callback()
        {
            UnityEngine.Debug.Log("Finished");
        }

        private IEnumerator Wait(float seconds)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            do
            {
                yield return null;
            } while (stopwatch.ElapsedMilliseconds < seconds * 1000f);

            stopwatch.Stop();
        }
        #endregion
    }
}
