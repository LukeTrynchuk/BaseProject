using UnityEngine;
using DogHouse.Services;

namespace DogHouse.Core.Audio
{
    /// <summary>
    /// AudioAsset is a scriptable object that
    /// will contain serveral parameters that
    /// describe an audio file that can be
    /// played by the IAudioService.
    /// </summary>
    [CreateAssetMenu(fileName = "MyNewAudioAsset", menuName = "Core/Audio Asset")]
    public class AudioAsset : ScriptableObject
    {
        #region Public Variables
        public string AssetID;
        public AudioClip Clip;
        public bool StopOnSceneLoad;
        public bool Loop;
        public AudioChannel AudioType;

        [Range(0,256)]
        public float Priority;
        #endregion
    }
}
