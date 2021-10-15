﻿using System;
using Assets.Attributes;
using UnityEngine;
using UnityEngine.Audio;

namespace Audiotter.Components.Players.Base
{
    public abstract class AudiotterPlayerBase : MonoBehaviour
    {
        [Range(0,1f)] public float Volume = 1f;
        [SerializeField] private AudiotterMixerGroup _mixerGroup = AudiotterMixerGroup.Sound;
        [SerializeField] private bool PlayOnAwake;
        [SerializeField] private bool _useCustomMixerGroup;

        [ShowIf(nameof(_useCustomMixerGroup))] [SerializeField]
        private AudioMixerGroup _customMixerGroup;

        public virtual bool IsPlaying() => false;

        public virtual void Play()
        {
            if(!_isInitialized)
                Initialize();
        }

        public abstract void Stop();
        
        protected event Action LocalVolumeChanged;

        protected virtual void Initialize()
        {
            LocalVolumeChanged?.Invoke();
            _isInitialized = true;
        }

        protected AudioMixerGroup GetMixerGroup()
        {
            if (_useCustomMixerGroup)
                return _customMixerGroup;
            
            return _mixerGroup switch
            {
                AudiotterMixerGroup.Music => AudiotterMixer.MusicMixerGroup,
                AudiotterMixerGroup.Sound => AudiotterMixer.SoundMixerGroup,
                _ => AudiotterMixer.SoundMixerGroup
            };
        }

        private void Awake()
        {
            Initialize();
            
            if(PlayOnAwake)
                Play();
        }

        private void Update()
        {
            if (Volume != _previousVolumeValue)
            {
                _previousVolumeValue = Volume;
                LocalVolumeChanged?.Invoke();
            }
        }

        private enum AudiotterMixerGroup
        {
            Music,
            Sound
        }
        
        private bool _isInitialized;
        private float _previousVolumeValue;
    }
}