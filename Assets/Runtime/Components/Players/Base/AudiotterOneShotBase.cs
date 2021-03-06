using System.Collections.Generic;
using Audiotter.Runtime.Attributes;
using UnityEngine;

namespace Audiotter.Runtime.Components
{
    public abstract class AudiotterOneShotBase : AudiotterPlayerBase
    {
        [Space(10)] public bool IsDelayed;

        [Min(0f)] public float Delay;

        [Space(10)] public bool UseMinTimeBetweenShots;

        [ShowIf(nameof(UseMinTimeBetweenShots))][Min(0f)] public float MinTimeBetweenShots;

        [Space(10)] [Button(nameof(Play))] [SerializeField]
        private bool _playButton;

        private readonly List<float> _delayTimers = new List<float>();
        private AudioSource _audioSource;
        private float _betweenShotsTimer;

        protected new void Update()
        {
            base.Update();

            if (UseMinTimeBetweenShots)
                _betweenShotsTimer -= Time.deltaTime;

            if (IsDelayed)
            {
                for (var i = 0; i < _delayTimers.Count; i++)
                {
                    _delayTimers[i] -= Time.deltaTime;
                    if (_delayTimers[i] <= 0)
                        PlayOneShot();
                }

                ClearZeroDelayTimers();
            }
        }

        public override void Play()
        {
            base.Play();

            if (IsDelayed)
            {
                if (!Application.isPlaying)
                    Debug.LogWarning("Delayed playback is available during playmode only");
                _delayTimers.Add(Delay);
            }
            else
            {
                PlayOneShot();
            }
        }

        public override void Stop()
        {
            _audioSource.Stop();
        }

        public override bool IsPlaying() => _audioSource.isPlaying;

        protected override void Initialize()
        {
            if (!TryGetComponent(out _audioSource) ||
                _audioSource.outputAudioMixerGroup == null ||
                !_audioSource.outputAudioMixerGroup.Equals(GetMixerGroup()))
            {
                _audioSource = gameObject.AddComponent<AudioSource>();
                _audioSource.outputAudioMixerGroup = GetMixerGroup();
                _audioSource.playOnAwake = false;
            }

            base.Initialize();
        }

        protected abstract bool TryGetClip(out AudioClip audioClip);

        private void PlayOneShot()
        {
            _audioSource.pitch = Pitch;
            if (TryGetClip(out var audioClip))
                if (_betweenShotsTimer <= 0)
                {
                    _audioSource.PlayOneShot(audioClip, Volume);

                    if (UseMinTimeBetweenShots)
                        _betweenShotsTimer = MinTimeBetweenShots;
                }
        }

        private void ClearZeroDelayTimers()
        {
            foreach (var delayTimer in _delayTimers)
            {
                if (delayTimer <= 0)
                {
                    _delayTimers.Remove(delayTimer);
                    ClearZeroDelayTimers();
                    return;
                }
            }
        }
    }
}