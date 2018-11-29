using DogHouse.Core.Services;

namespace DogHouse.Services
{
    /// <summary>
    /// IAudioService is an interface that all
    /// audio services must implement. The Audio
    /// Service is responsible for keeping track
    /// of many audio sources and playing general 
    /// Audio accessible from any part in the code
    /// base.
    /// </summary>
    public interface IAudioService : IService
    {
        void Play(string AssetID);
    }

    [System.Serializable]
    public enum AudioChannel
    {
        MUSIC,
        SFX
    }
}
