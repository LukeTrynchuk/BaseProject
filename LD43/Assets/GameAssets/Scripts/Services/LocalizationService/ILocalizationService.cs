using DogHouse.Core.Services;

namespace DogHouse.Services
{
    /// <summary>
    /// ILocalizationService is an interface that
    /// all localization services must implement. A
    /// localization service is responsible for implementing
    /// a method to localize the text of the game.
    /// </summary>
    public interface ILocalizationService : IService
    {
        event System.Action OnLocalizationSynced;
        bool IsSynced { get; }

        string LocalizeText(string LanguageID, string TextID);
    }
}
