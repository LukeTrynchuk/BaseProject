using DogHouse.Core.Services;
using DogHouse.Services;
using UnityEngine;

namespace DogHouse.General
{
    /// <summary>
    /// CallLoadSlideShowScene is a component that can be
    /// used to easily access the SceneManager and call the
    /// Load Slide Show Scene method.
    /// </summary>
    public class CallLoadSlideShowScene : MonoBehaviour 
    {
        #region Private Variables
        private ServiceReference<ISceneManager> m_sceneManager 
            = new ServiceReference<ISceneManager>();
        #endregion
        
        #region Main Methods
        public void LoadSlideShowScene()
        {
            m_sceneManager.Reference?.LoadSlideShowScene();
        }
        #endregion
    }
}
