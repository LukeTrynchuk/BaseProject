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
        #region Private Variables
        [SerializeField]
        private float m_fadeTime;

        private ServiceReference<ICameraTransition> m_cameraTransition
            = new ServiceReference<ICameraTransition>();

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
            m_cameraTransition.Reference?.FadeIn(m_fadeTime, ExecuteLoad);
        }

        private void ExecuteLoad()
        {
            SceneManager.LoadScene(m_currentScene);
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            m_cameraTransition.Reference?.FadeOut(m_fadeTime);
        }
        #endregion
    }
}
