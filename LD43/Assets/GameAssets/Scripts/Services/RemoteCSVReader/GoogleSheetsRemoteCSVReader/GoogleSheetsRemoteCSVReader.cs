using DogHouse.Core.Services;
using UnityEngine;

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
        public string[][] FetchRemoteCSV(string url)
        {
            string[][] sheet = GoSheets.GetGoogleSheet(url);
            return sheet;
        }

        void OnEnable() => RegisterService();
        void OnDisable() => UnregisterService();

        public void UnregisterService()
        {
            ServiceLocator.Unregister<IRemoteCSVReader>(this);
        }

        public void RegisterService()
        {
            ServiceLocator.Register<IRemoteCSVReader>(this);
        }
        #endregion
    }
}
