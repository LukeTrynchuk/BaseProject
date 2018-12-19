using DogHouse.Core.Services;
using UnityEngine;

namespace DogHouse.Services
{
    /// <summary>
    /// LoadingScreenService is an implementation of
    /// the loading screen service interface. The
    /// loading screen is responsible for displaying
    /// a loading screen to the user.
    /// </summary>
    public class LoadingScreenService : BaseService<ILoadingScreenService>, ILoadingScreenService
    {
        #region Private Variables
        [SerializeField]
        private Canvas m_loadingCanvas = default(Canvas);
        #endregion

        #region Main Methods
        public void SetDisplay(bool value) => m_loadingCanvas.enabled = value;
        #endregion
    }
}
