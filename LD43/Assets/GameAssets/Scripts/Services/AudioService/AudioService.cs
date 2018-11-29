using System.Collections.Generic;
using DogHouse.Core.Services;
using UnityEngine;
using DogHouse.Core.Audio;
using System.Linq;
using UnityEngine.Audio;
using System;

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
        #region Private Variables
        [SerializeField]
        private int m_numberOfChannels;

        [SerializeField]
        private AudioAsset[] m_audioAssets;

        [SerializeField]
        private AudioMixerGroup m_musicGroup;

        [SerializeField]
        private AudioMixerGroup m_sfxGroup;

        private List<AudioAsset> m_stopOnSceneLoadAssets
            = new List<AudioAsset>();

        private List<AudioSource> m_sources 
            = new List<AudioSource>();

        private ServiceReference<ISceneManager> m_sceneManager 
            = new ServiceReference<ISceneManager>();
        #endregion

        #region Main Methods
        void OnEnable()
        {
            GenerateAudioChannels();
            FindStopOnLoadAudioAssets();
            RegisterService();
            m_sceneManager.AddRegistrationHandle(HandleSceneManagerRegistered);
        }

        void OnDisable()
        {
            UnregisterService();

            if(m_sceneManager.isRegistered())
            {
                m_sceneManager.Reference.OnAboutToLoadNewScene -= OnAboutToLoadScene;
            }
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
            if (m_sources.Count != 0) return;
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

        private void FindStopOnLoadAudioAssets()
        {
            if (m_stopOnSceneLoadAssets.Count != 0) return;

            m_stopOnSceneLoadAssets = m_audioAssets
                                .Where(x => x.m_stopOnSceneLoad == true)
                                .ToList();
        }

        private void Play(AudioSource source, AudioAsset asset)
        {
            source.clip = asset.m_audioClip;
            source.priority = (int)asset.m_priority;
            source.loop = asset.m_loop;

            if(asset.m_type == AudioChannel.MUSIC)
            {
                source.outputAudioMixerGroup = m_musicGroup;
            }

            if(asset.m_type == AudioChannel.SFX)
            {
                source.outputAudioMixerGroup = m_sfxGroup;
            }

            source.Play();
        }

        private void HandleSceneManagerRegistered()
        {
            m_sceneManager.Reference.OnAboutToLoadNewScene -= OnAboutToLoadScene;
            m_sceneManager.Reference.OnAboutToLoadNewScene += OnAboutToLoadScene;
        }

        private void OnAboutToLoadScene()
        {
            foreach(AudioAsset asset in m_stopOnSceneLoadAssets)
            {
                AudioSource[] sources = sourcesPlayingAsset(asset);
                StopSources(sources);
            }
        }

        private AudioSource[] sourcesPlayingAsset(AudioAsset asset)
        {
            List<AudioSource> sourcesPlaying = m_sources
                .Where(x => x.isPlaying)
                .Where(x => x.clip == asset.m_audioClip)
                .ToList();

            return sourcesPlaying.ToArray();
        }

        private void StopSources(AudioSource[] sources)
        {
            foreach(AudioSource source in sources)
            {
                source.Stop();
                source.loop = false;
                source.clip = null;
            }
        }
        #endregion
    }
}
