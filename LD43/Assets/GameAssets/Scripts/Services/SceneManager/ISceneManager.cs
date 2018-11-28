using DogHouse.Core.Services;
using UnityEngine;

namespace DogHouse.Services
{
    /// <summary>
    /// ISceneManager is an interface for a
    /// scene manager. The Scene Manager is 
    /// responsible for containing all string
    /// literals of the different scene names
    /// and exposing public methods to allow the
    /// loading of the different scenes.
    /// </summary>
    public interface ISceneManager : IService
    {
        void LoadSlideShowScene();
    }
}
