using System;
using Audiotter.Runtime.Attributes;
using UnityEngine;
using UnityEngine.Audio;

namespace Audiotter.Runtime.Components
{
    public abstract class AudiotterPlayerBase : MonoBehaviour
    {
        [Range(0, 1f)] public float Volume = 1f;
        [Range(0, 3f)] public float Pitch = 1f;
        [SerializeField] private AudiotterMixerGroup _mixerGroup = AudiotterMixerGroup.Sound;
        [SerializeField] private bool PlayOnAwake;

        [Space(10)] [SerializeField] private bool _useCustomMixerGroup;

        [ShowIf(nameof(_useCustomMixerGroup))] [SerializeField]
        private AudioMixerGroup _customMixerGroup;

        private bool _isInitialized;
        private float _previousPitchValue;
        private float _previousVolumeValue;

        protected void Awake()
        {
            Initialize();

            if (PlayOnAwake)
                Play();
        }

        protected void Update()
        {
            if (Volume != _previousVolumeValue)
            {
                _previousVolumeValue = Volume;
                VolumeChanged?.Invoke();
            }

            if (Pitch != _previousPitchValue)
            {
                _previousPitchValue = Pitch;
                PitchChanged?.Invoke();
            }
        }

        public abstract bool IsPlaying();

        public virtual void Play()
        {
            if (!_isInitialized)
                Initialize();
        }

        public abstract void Stop();

        protected event Action VolumeChanged;
        protected event Action PitchChanged;

        protected virtual void Initialize()
        {
            VolumeChanged?.Invoke();
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
                _ => AudiotterMixer.SoundMixerGroup,
            };
        }

        private enum AudiotterMixerGroup
        {
            Music,
            Sound,
        }
    }
}