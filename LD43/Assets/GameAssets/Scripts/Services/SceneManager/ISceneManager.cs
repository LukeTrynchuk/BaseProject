using DogHouse.Core.Services;
using UnityEngine;
using System;

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
        event Action OnAboutToLoadNewScene;

        void LoadSlideShowScene();
        void LoadMainMenuScene();
        void LoadGameScene();
    }
}
