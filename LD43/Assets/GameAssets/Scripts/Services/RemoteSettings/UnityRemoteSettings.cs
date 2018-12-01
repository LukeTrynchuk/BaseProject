using System;
using System.Collections;
using System.Collections.Generic;
using DogHouse.Core.Services;
using DogHouse.Services;
using UnityEngine;

namespace DogHouse.Services
{
    /// <summary>
    /// UnityRemoteSettings is a concrete implementation
    /// of the remote settings service. This implementation
    /// uses the unity remote settings provided in their free
    /// services.
    /// </summary>
    public class UnityRemoteSettings : MonoBehaviour, IRemoteSettingsService
    {
        #region Public Variables
        public event Action OnRemoteSettingsUpdated;
        #endregion

        #region Private Variables
        private Dictionary<string, System.Object> m_remoteSettings
            = new Dictionary<string, System.Object>();

        private const string SHOW_MENU_OPTIONS_ID = "DISPLAY_MENU_OPTIONS";
        private const string LOCALIZATION_URL = "LOCALIZATION_CSV";
        #endregion

        #region Main Methods
        void OnEnable() 
        {
            RemoteSettings.Updated -= HandleRemoteSettingsUpdated;
            RemoteSettings.Updated += HandleRemoteSettingsUpdated;
            RemoteSettings.ForceUpdate();
        }

        void OnDisable()
        {
            RemoteSettings.Updated -= HandleRemoteSettingsUpdated;
            UnregisterService();
        }

        public T GetSettings<T>(string SettingID) => 
            (T)m_remoteSettings[SettingID];

        public void RegisterService()
        {
            ServiceLocator.Register<IRemoteSettingsService>(this);
        }

        public void UnregisterService()
        {
            ServiceLocator.Unregister<IRemoteSettingsService>(this);
        }
        #endregion

        #region Utility Methods
        private void HandleRemoteSettingsUpdated()
        {
            m_remoteSettings.Add(SHOW_MENU_OPTIONS_ID,
                                 RemoteSettings.GetBool(SHOW_MENU_OPTIONS_ID));



            m_remoteSettings.Add(LOCALIZATION_URL,
                                 RemoteSettings.GetString(LOCALIZATION_URL));

            RegisterService();
            OnRemoteSettingsUpdated?.Invoke();
        }
        #endregion
    }
}
