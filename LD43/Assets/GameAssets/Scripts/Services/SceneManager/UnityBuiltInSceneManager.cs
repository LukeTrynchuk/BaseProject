using DogHouse.Core.Services;
using UnityEngine;
using UnityEngine.SceneManagement;
using static DogHouse.Core.Services.ServiceLocator;
using static UnityEngine.SceneManagement.SceneManager;

namespace DogHouse.Services
{
    /// <summary>
    /// UnityBuiltInSceneManager will use the built
    /// in Unity Scene Manager to load new scenes.
    /// </summary>
    public class UnityBuiltInSceneManager : MonoBehaviour, ISceneManager
    {
        #region Public Variables
        public event System.Action OnAboutToLoadNewScene;
        #endregion

        #region Private Variables
        [SerializeField]
        private float m_fadeTime = 0f;

        private ServiceReference<ICameraTransition> m_cameraTransition
            = new ServiceReference<ICameraTransition>();

        private ServiceReference<IAudioMixerService> m_audioMixerService
            = new ServiceReference<IAudioMixerService>();

        private ServiceReference<IAnalyticsService> m_analytcsService
            = new ServiceReference<IAnalyticsService>();

        private const string LOGO_SCENE = "LogoSlideShow";
        private const string MAIN_MENU = "MainMenu";
        private const string GAME_SCENE = "Game";
        private const float FADE_TIME_SCALAR = 0.75f;

        private string m_currentScene = "";

        private float m_audioMixTime => m_fadeTime * FADE_TIME_SCALAR;
        #endregion

        #region Main Methods
        void OnEnable() 
        {
            RegisterService();
            sceneLoaded -= HandleSceneLoaded;
            sceneLoaded += HandleSceneLoaded;
        }

        void OnDisable() 
        {
            UnregisterService();
            sceneLoaded -= HandleSceneLoaded;
        }

        public void LoadSlideShowScene() => Load(LOGO_SCENE);
        public void LoadMainMenuScene() => Load(MAIN_MENU);
        public void LoadGameScene() => Load(GAME_SCENE);
        public void RegisterService() => Register<ISceneManager>(this);
        public void UnregisterService() => Unregister<ISceneManager>(this);
        #endregion

        #region Utility Methods
        private void Load(string sceneName)
        {
            m_currentScene = sceneName;
            m_audioMixerService.Reference?.TransitionToTransitionMix(m_audioMixTime);
            m_cameraTransition.Reference?.FadeIn(m_fadeTime, ExecuteLoad);
        }

        private void ExecuteLoad()
        {
            OnAboutToLoadNewScene?.Invoke();
            LoadScene(m_currentScene);
        }

        private void HandleSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            m_cameraTransition.Reference?.FadeOut(m_fadeTime);
            m_audioMixerService.Reference?.TransitionToGameMix(m_audioMixTime);
            m_analytcsService.Reference?.SendSceneLoadedEvent(scene.name);
        }
        #endregion
    }
}
