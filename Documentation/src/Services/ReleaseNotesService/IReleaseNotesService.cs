using DogHouse.Core.Services;

namespace DogHouse.Services
{
    /// <summary>
    /// IReleaseNotesService is an interface that 
    /// all release note services must implement.
    /// A release note service is responsible for 
    /// reading the release notes and combining
    /// the data into a string ready for other
    /// objects to read.
    /// </summary>
    public interface IReleaseNotesService : IService 
    {
        string FetchReleaseNotes();
    }
}
