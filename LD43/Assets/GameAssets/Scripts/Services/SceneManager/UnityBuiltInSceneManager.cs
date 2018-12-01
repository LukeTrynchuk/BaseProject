using DogHouse.Core.Services;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        private float m_fadeTime;

        private ServiceReference<ICameraTransition> m_cameraTransition
            = new ServiceReference<ICameraTransition>();

        private ServiceReference<IAudioMixerService> m_audioMixerService
            = new ServiceReference<IAudioMixerService>();

        private ServiceReference<IAnalyticsService> m_analytcsService
            = new ServiceReference<IAnalyticsService>();

        private const string LOGO_SCENE = "LogoSlideShow";
        private const string MAIN_MENU = "MainMenu";
        private const string GAME_SCENE = "Game";

        private string m_currentScene = "";
        #endregion

        #region Main Methods
        void OnEnable() 
        {
            RegisterService();

            SceneManager.sceneLoaded -= OnSceneLoaded;
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        void OnDisable() => UnregisterService();

        public void LoadSlideShowScene() => Load(LOGO_SCENE);
        public void LoadMainMenuScene() => Load(MAIN_MENU);
        public void LoadGameScene() => Load(GAME_SCENE);

        public void RegisterService()
        {
            ServiceLocator.Register<ISceneManager>(this);
        }

        public void UnregisterService()
        {
            ServiceLocator.Unregister<ISceneManager>(this);
        }
        #endregion

        #region Utility Methods
        private void Load(string sceneName)
        {
            m_currentScene = sceneName;
            m_audioMixerService.Reference?.TransitionToTransitionMix(m_fadeTime * 0.75f);
            m_cameraTransition.Reference?.FadeIn(m_fadeTime, ExecuteLoad);
        }

        private void ExecuteLoad()
        {
            OnAboutToLoadNewScene?.Invoke();
            SceneManager.LoadScene(m_currentScene);
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            m_cameraTransition.Reference?.FadeOut(m_fadeTime);
            m_audioMixerService.Reference?.TransitionToGameMix(m_fadeTime * 0.75f);
            m_analytcsService.Reference?.SendSceneLoadedEvent(scene.name);
        }
        #endregion
    }
}
