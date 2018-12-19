using System;
using UnityEngine;
using System.Collections.Generic;
using DogHouse.Core.Services;

namespace DogHouse.Services
{
    /// <summary>
    /// CameraFinder is an implementation of the 
    /// ICameraFinder interface. The Camera Finder
    /// service is responsible for keeping track 
    /// of the Main camera in the scene. 
    /// </summary>
    public class CameraFinder : BaseService<ICameraFinder>, ICameraFinder
    {
        #region Public Variables
        public Camera Camera => FetchCamera();
        public event Action<Camera> OnNewCameraFound;
        #endregion

        #region Private Variables
        private Camera m_camera;

        private delegate Camera CameraDelegate();
        private List<CameraDelegate> CameraFetchDelegates;
        #endregion

        #region Main Methods
        void Start()
        {
            CameraFetchDelegates = new List<CameraDelegate>();
            CameraFetchDelegates.Add(new CameraDelegate(FetchMainCamera));
            CameraFetchDelegates.Add(new CameraDelegate(FetchAnyCamera));
        }

        private Camera FetchCamera()
        {
            if(m_camera != null) return m_camera;

            foreach(CameraDelegate cameraDelegate in CameraFetchDelegates)
            {
                m_camera = cameraDelegate.Invoke();
                if (m_camera == null) continue;

                OnNewCameraFound?.Invoke(m_camera);
                return m_camera;
            }

            return m_camera;
        }

        void Update()
        {
            if (m_camera != null) return;
            m_camera = FetchCamera();
        }
        #endregion

        #region Utility Methods
        private Camera FetchMainCamera() => Camera.main;

        private Camera FetchAnyCamera()
        {
            Camera[] cameras = GameObject.FindObjectsOfType<Camera>();
            return cameras.Length > 0 ? cameras[0] : null;
        }
        #endregion
    }
}
