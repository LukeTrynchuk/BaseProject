using DogHouse.Core.Services;

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
        #region Public Variables
        #endregion

        #region Private Variables
        private bool m_isLoading = false;
        #endregion

        #region Main Methods
        public void SetDisplay(bool value)
        {
            m_isLoading = value;
        }
        #endregion

        #region Utility Methods
        #endregion
    }
}
