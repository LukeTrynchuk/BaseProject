using System;
using System.Collections.Generic;
using UnityEngine;
using static DogHouse.Core.Services.ServiceLocator;
using static UnityEngine.RemoteSettings;

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
            Updated -= HandleRemoteSettingsUpdated;
            Updated += HandleRemoteSettingsUpdated;
            ForceUpdate();
        }

        void OnDisable()
        {
            Updated -= HandleRemoteSettingsUpdated;
            UnregisterService();
        }

        public T FetchSetting<T>(string SettingID) =>
            (T)m_remoteSettings[SettingID];

        public void RegisterService()   => Register<IRemoteSettingsService>(this);
        public void UnregisterService() => Unregister<IRemoteSettingsService>(this);
        #endregion

        #region Utility Methods
        private void HandleRemoteSettingsUpdated()
        {
            m_remoteSettings.Add(SHOW_MENU_OPTIONS_ID,
                                 GetBool(SHOW_MENU_OPTIONS_ID));

            m_remoteSettings.Add(LOCALIZATION_URL,
                                 GetString(LOCALIZATION_URL));

            RegisterService();
            OnRemoteSettingsUpdated?.Invoke();
        }
        #endregion
    }
}
