using DogHouse.Core.Services;

namespace DogHouse.Services
{
    /// <summary>
    /// ILoadingScreenService is an interface that all
    /// loading screen interfaces must implement. A loading
    /// screen service is responsible for displaying a loading
    /// screen so that the user knows that the game is loading
    /// assets.
    /// </summary>
    public interface ILoadingScreenService : IService 
    {
        void SetDisplay(bool value);
    }
}
