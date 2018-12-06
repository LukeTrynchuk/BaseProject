using UnityEngine;
using static GoSheets;
using static DogHouse.Core.Services.ServiceLocator;

namespace DogHouse.Services
{
    /// <summary>
    /// GoogleSheetsRemoteCSVReader is an implementation
    /// of the IRemoteCSVReader. It uses the google
    /// sheets to read from a csv sheet.
    /// </summary>
    public class GoogleSheetsRemoteCSVReader : MonoBehaviour, IRemoteCSVReader
    {
        #region Main Methods
        public string[][] FetchRemoteCSV(string url) => GetGoogleSheet(url);
        void OnEnable() => RegisterService();
        void OnDisable() => UnregisterService();
        public void UnregisterService() => Unregister<IRemoteCSVReader>(this);
        public void RegisterService() => Register<IRemoteCSVReader>(this);
        #endregion
    }
}
