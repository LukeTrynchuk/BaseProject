using DogHouse.Core.Services;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.SceneManagement.SceneManager;

namespace DogHouse.Services
{
    /// <summary>
    /// UnityBuiltInSceneManager will use the built
    /// in Unity Scene Manager to load new scenes.
    /// </summary>
    public class UnityBuiltInSceneManager : BaseService<ISceneManager>, ISceneManager
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

        private ServiceReference<ILoadingScreenService> m_loadingScreenService
            = new ServiceReference<ILoadingScreenService>();

        private ServiceReference<ILogService> m_logService 
            = new ServiceReference<ILogService>();

        private const string PRELOAD_SCENE = "Preload";
        private const string LOGO_SCENE = "LogoSlideShow";
        private const string MAIN_MENU = "MainMenu";
        private const string GAME_SCENE = "Game";
        private const string EMPTY_BUFFER = "_EmptySwitchBuffer";
        private const float FADE_TIME_SCALAR = 0.75f;
        private const float LOAD_OVERLAP_TIME = 2.5f;

        private string m_currentScene = "";

        private float m_audioMixTime => m_fadeTime * FADE_TIME_SCALAR;
        private SceneManagerState m_state = SceneManagerState.IDLE;
        #endregion

        #region Main Methods
        public override void OnEnable() 
        {
            base.OnEnable();
            sceneLoaded -= HandleSceneLoaded;
            sceneLoaded += HandleSceneLoaded;
        }

        public override void OnDisable() 
        {
            base.OnDisable();
            sceneLoaded -= HandleSceneLoaded;
            CancelInvoke();
        }

        public void LoadSlideShowScene() 
        {
            if (!CheckCanLoad()) return;
            Load(LOGO_SCENE);
        }

        public void LoadMainMenuScene()
        {
            if (!CheckCanLoad()) return;
            Load(MAIN_MENU);
        }

        public void LoadGameScene() 
        {
            if (!CheckCanLoad()) return;
            Load(GAME_SCENE);
        }
        #endregion

        #region Utility Methods
        private void Load(string sceneName)
        {
            m_state = SceneManagerState.LOADING;
            m_loadingScreenService.Reference?.SetDisplay(true);
            m_currentScene = sceneName;
            m_audioMixerService.Reference?.TransitionToTransitionMix(m_audioMixTime);
            m_cameraTransition.Reference?.FadeIn(m_fadeTime, LoadIntoEmptyBuffer);
        }

        private void ExecuteLoad()
        {
            OnAboutToLoadNewScene?.Invoke();
            LoadSceneAsync(m_currentScene);
        }

        private void HandleSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (scene.name.Equals(PRELOAD_SCENE)) return;

            if(scene.name.Equals(EMPTY_BUFFER))
            {
                ExecuteLoad();
                return;
            }

            Invoke(nameof(HandleTargetSceneLoaded), LOAD_OVERLAP_TIME);
        }

        private void HandleTargetSceneLoaded()
        {
            m_cameraTransition.Reference?.FadeOut(m_fadeTime);
            m_audioMixerService.Reference?.TransitionToGameMix(m_audioMixTime);
            m_analytcsService.Reference?.SendSceneLoadedEvent(m_currentScene);
            m_currentScene = default(string);
            m_loadingScreenService.Reference?.SetDisplay(false);
            m_state = SceneManagerState.IDLE;
        }

        private void LoadIntoEmptyBuffer()
        {
            if (m_state == SceneManagerState.IDLE) return;
            LoadSceneAsync(EMPTY_BUFFER);
        }

        private bool CheckCanLoad()
        {
            if (m_state != SceneManagerState.IDLE)
            {
                m_logService.Reference?.LogError("SCENE ALREADY BEING LOADED");
                return false;
            }

            return true;
        }
        #endregion
    }
}
