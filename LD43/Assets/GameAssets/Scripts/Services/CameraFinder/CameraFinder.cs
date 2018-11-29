using DogHouse.Core.Services;
using UnityEngine;

namespace DogHouse.Services
{
    /// <summary>
    /// CameraFinder is an implementation of the 
    /// ICameraFinder interface. The Camera Finder
    /// service is responsible for keeping track 
    /// of the Main camera in the scene. 
    /// </summary>
    public class CameraFinder : MonoBehaviour, ICameraFinder
    {
        #region Public Variables
        public Camera Camera => GetCamera();
        #endregion

        #region Private Variables
        private Camera m_camera;
        #endregion

        #region Main Methods
        void OnEnable() => RegisterService();
        void OnDisable() => UnregisterService();

        public void RegisterService()
        {
            ServiceLocator.Register<ICameraFinder>(this);
        }

        public void UnregisterService()
        {
            ServiceLocator.Unregister<ICameraFinder>(this);
        }

        private Camera GetCamera()
        {
            if(m_camera != null) 
            {
                return m_camera;
            }

            m_camera = GetMainCamera();
            if(m_camera != null)
            {
                return m_camera;
            }

            m_camera = GetAnyCamera();
            return m_camera;
        }
        #endregion

        #region Utility Methods
        private Camera GetMainCamera()
        {
            return Camera.main;
        }

        private Camera GetAnyCamera()
        {
            Camera[] cameras = GameObject.FindObjectsOfType<Camera>();
            if (cameras.Length > 0) return cameras[0];
            return null;
        }
        #endregion
    }
}
