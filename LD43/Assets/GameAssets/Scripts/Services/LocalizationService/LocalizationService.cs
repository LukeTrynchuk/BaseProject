using System;
using DogHouse.Core.Services;
using UnityEngine;
using static DogHouse.Core.Services.ServiceLocator;

namespace DogHouse.Services
{
    /// <summary>
    /// LocalizationService is an implementation of 
    /// the ILocalizationService. The localization service
    /// is responsible for syncing with a remote csv and
    /// interpretting the data as localized text.
    /// </summary>
    public class LocalizationService : MonoBehaviour, ILocalizationService
    {
        #region Public Variables
        public event Action OnLocalizationSynced;

        public bool IsSynced => m_synced;
        #endregion

        #region Private Variables
        private bool m_synced = false;

        private ServiceReference<IRemoteCSVReader> m_remoteCSVReader 
            = new ServiceReference<IRemoteCSVReader>();

        private ServiceReference<IRemoteSettingsService> m_remoteSettingsService
            = new ServiceReference<IRemoteSettingsService>();

        private const string LOCALIZATION_ID = "LOCALIZATION_CSV";
        private string m_localizationUrl;
        #endregion

        #region Main Methods

        public string FetchLocalizedText(string LanguageID, string TextID)
        {
            throw new NotImplementedException();
        }

        void OnEnable() 
        {
            RegisterService();

            m_remoteSettingsService
                .AddRegistrationHandle(HandleRemoteSettingsServiceRegistered);
        }

        void OnDisable()
        {
            UnregisterService();
        }

        public void RegisterService() => Register<ILocalizationService>(this);
        public void UnregisterService() => Unregister<ILocalizationService>(this);
        #endregion

        #region Utility Methods
        private void HandleRemoteSettingsServiceRegistered()
        {
            m_localizationUrl = m_remoteSettingsService.Reference
                                        .FetchSetting<string>(LOCALIZATION_ID);

            m_remoteCSVReader
                .AddRegistrationHandle(HandleRemoteCSVReaderRegistered);
        }

        private void HandleRemoteCSVReaderRegistered()
        {
            string[][] csv = m_remoteCSVReader.Reference
                                    ?.FetchRemoteCSV(m_localizationUrl);

            InterpretCSV(csv);
            OnLocalizationSynced?.Invoke();
        }

        private void InterpretCSV(string[][] data)
        {
            foreach(string[] row in data)
            {
                foreach(string col in row)
                {
                    //Debug.Log(col);
                }
            }

        }
        #endregion

    }
}
