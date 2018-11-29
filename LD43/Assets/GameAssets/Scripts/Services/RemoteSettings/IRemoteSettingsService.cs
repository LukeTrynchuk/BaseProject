using DogHouse.Core.Services;

namespace DogHouse.Services
{
    /// <summary>
    /// IRemoteSettingsService is an interface that all
    /// remote settings services must implement. A remote
    /// settings service is responsible for pulling and
    /// sending the remote settings to other systems
    /// and objects.
    /// </summary>
    public interface IRemoteSettingsService : IService
    {
        event System.Action OnRemoteSettingsUpdated;

        T GetSettings<T>(string SettingID);
    }
}
