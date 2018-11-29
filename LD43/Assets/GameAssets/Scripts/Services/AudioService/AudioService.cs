using System.Collections.Generic;
using DogHouse.Core.Services;
using UnityEngine;
using DogHouse.Core.Audio;
using System.Linq;

namespace DogHouse.Services
{
    /// <summary>
    /// AudioService is an implementation of the 
    /// Audio Service interface. This concrete
    /// implementation uses several children objects
    /// each with an audio source to play multiple
    /// audio files at once.
    /// </summary>
    public class AudioService : MonoBehaviour, IAudioService
    {
        #region Public Variables
        #endregion

        #region Private Variables
        [SerializeField]
        private int m_numberOfChannels;

        [SerializeField]
        private AudioAsset[] m_audioAssets;

        private List<AudioSource> m_sources 
            = new List<AudioSource>();
        #endregion

        #region Main Methods
        void OnEnable()
        {
            GenerateAudioChannels();
            RegisterService();
        }

        void OnDisable()
        {
            UnregisterService();
        }

        public void UnregisterService()
        {
            ServiceLocator.Unregister<IAudioService>(this);
        }

        public void RegisterService()
        {
            ServiceLocator.Register<IAudioService>(this);
        }

        public void Play(string AssetID)
        {
            AudioSource source = GetAvailableAudioChannel();
            AudioAsset asset = FindAudioAsset(AssetID);

            if (source == null || asset == null) return;
            Play(source, asset);
        }
        #endregion

        #region Utility Methods
        private void GenerateAudioChannels()
        {
            for (int i = 0; i < m_numberOfChannels; i++)
            {
                CreateAudioChannel();
            }
        }

        private void CreateAudioChannel()
        {
            GameObject channel = new GameObject();
            AudioSource source = channel.AddComponent<AudioSource>();
            source.playOnAwake = false;
            m_sources.Add(source);
            channel.transform.parent = transform;
        }

        private AudioSource GetAvailableAudioChannel()
        {
            AudioSource source = m_sources
                                    .Where(x => x.isPlaying == false)
                                    .FirstOrDefault();

            return source;
        }

        private AudioAsset FindAudioAsset(string id)
        {
            AudioAsset asset = m_audioAssets
                                .Where(x => x.m_ID.Equals(id))
                                .FirstOrDefault();

            return asset;
        }

        private void Play(AudioSource source, AudioAsset asset)
        {
            source.clip = asset.m_audioClip;
            source.priority = (int)asset.m_priority;
            source.loop = asset.m_loop;
            source.Play();
        }
        #endregion
    }
}
