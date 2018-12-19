using DogHouse.Core.Services;
using UnityEngine;

namespace DogHouse.Services
{
    /// <summary>
    /// RemoteCSVReaderBackdoor is a backdoor
    /// to the RemoteCSVReader service. 
    /// </summary>
    public class RemoteCSVReaderBackdoor : MonoBehaviour, IRemoteCSVReader
    {
        #region Private Variables
        private ServiceReference<IRemoteCSVReader> m_remoteCSVReader 
            = new ServiceReference<IRemoteCSVReader>();
        #endregion

        #region Main Methods
        public string[][] FetchRemoteCSV(string url)
        {
            return m_remoteCSVReader.Reference?.FetchRemoteCSV(url);
        }
        
        public void RegisterService() {}
        #endregion
    }
}
