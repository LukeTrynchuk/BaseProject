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
        public string m_ID;
        public AudioClip m_audioClip;
        public bool m_stopOnSceneLoad;
        public bool m_loop;
        public AudioChannel m_type;

        [Range(0,256)]
        public float m_priority;
        #endregion
    }
}
