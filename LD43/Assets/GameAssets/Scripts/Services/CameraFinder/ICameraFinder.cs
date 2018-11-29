using DogHouse.Core.Services;

namespace DogHouse.Services
{
    /// <summary>
    /// ICameraFinder is an interface that
    /// all Camera Finders must implement. A 
    /// camera finder is responsible for knowing
    /// the current main camera of the scene.
    /// </summary>
    public interface ICameraFinder : IService
    {
        UnityEngine.Camera Camera { get; }
    }
}
