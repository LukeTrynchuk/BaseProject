using DogHouse.Core.Services;

namespace DogHouse.Services
{
    /// <summary>
    /// IAudioMixerService is an interface that 
    /// all audio mixers must implement. An audio mixer
    /// gives high level control to other scripts to
    /// tune and mix the audio levels.
    /// </summary>
    public interface IAudioMixerService : IService
    {
        void TransitionToGameMix(float time, System.Action callback = null);
        void TransitionToTransitionMix(float time, System.Action callback = null);
    }
}
