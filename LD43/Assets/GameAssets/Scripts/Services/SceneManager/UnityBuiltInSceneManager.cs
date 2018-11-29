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
        private const string LOGO_SCENE = "LogoSlideShow";
        private const string MAIN_MENU = "MainMenu";
        #endregion

        #region Main Methods
        void OnEnable() => RegisterService();

        void OnDisable() => UnregisterService();

        public void LoadSlideShowScene() => Load(LOGO_SCENE);
        public void LoadMainMenuScene() => Load(MAIN_MENU);

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
            SceneManager.LoadScene(sceneName);
        }
        #endregion
    }
}
