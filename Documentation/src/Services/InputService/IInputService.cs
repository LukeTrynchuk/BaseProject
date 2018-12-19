using System.Collections;
using System.Collections.Generic;
using DogHouse.Core.Services;
using DogHouse.Services;
using UnityEngine;
using System;

namespace DogHouse.Services
{
    /// <summary>
    /// IInputService is an interface that all
    /// input services must implement. An input
    /// service is responsible for detecting input
    /// and sending out events when it has occured.
    /// </summary>
    public interface IInputService : IService
    {
        event Action<Vector2> OnMovementVectorCalculated;
        event Action OnConfirmButtonPressed;
        event Action OnDeclineButtonPressed;
    }
}
