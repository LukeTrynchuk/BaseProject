using DogHouse.Core.Services;
using System;

namespace DogHouse.Services
{
    /// <summary>
    /// ICameraTransition is an interface that controls
    /// the transitioning between fading in and out
    /// of black. This can be used for fading in and out
    /// between scenes or just as an effect.
    /// </summary>
    public interface ICameraTransition : IService 
    {
        CameraTransitionState State { get; }

        void FadeIn(float Time);
        void FadeOut(float Time);
        void FadeIn(float Time, Action callback);
        void FadeOut(float Time, Action callback);
    }

    public enum CameraTransitionState
    {
        TRANSITIONING,
        IDLE_IN,
        IDLE_OUT
    }
}
