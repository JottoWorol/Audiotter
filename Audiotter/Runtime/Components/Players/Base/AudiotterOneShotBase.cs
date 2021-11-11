using System;
using Audiotter.Attributes;
using UnityEngine;

namespace Audiotter.Runtime.Components.Players.Base
{
    public abstract class AudiotterOneShotBase : AudiotterPlayerBase
    {
        [SerializeField] protected bool _delayed;

        [ShowIf(nameof(_delayed))] [SerializeField]
        protected float _delay;

        private AudioSource _audioSource;

        private float _waitingTimer;
        private bool _waitingToPlay;

        private void Update()
        {
            if (!_waitingToPlay) return;

            _waitingTimer -= Time.deltaTime;

            if (_waitingTimer <= 0)
            {
                PlayOneShot();
                _waitingToPlay = false;
            }
        }

        public override void Play()
        {
            base.Play();

            if (_delayed)
            {
                _waitingTimer = _delay;
                _waitingToPlay = true;
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

        public override bool IsPlaying()
        {
            return _audioSource.isPlaying;
        }

        protected override void Initialize()
        {
            if (!TryGetComponent(out _audioSource) ||
                _audioSource.outputAudioMixerGroup == null ||
                !_audioSource.outputAudioMixerGroup.Equals(GetMixerGroup()))
            {
                _audioSource = gameObject.AddComponent<AudioSource>();
                _audioSource.outputAudioMixerGroup = GetMixerGroup();
            }

            base.Initialize();
        }

        protected abstract bool TryGetClip(out AudioClip audioClip);

        private void PlayOneShot()
        {
            if (TryGetClip(out var audioClip)) _audioSource.PlayOneShot(audioClip, Volume);
        }

        public struct Point
        {
            public double X { get; set; }
            public double Y { get; set; }
            public readonly double Distance => Math.Sqrt(X * X + Y * Y);

            public override readonly string ToString()
            {
                return $"({X}, {Y}) is {Distance} from the origin";
            }

            public void Translate(int xOffset, int yOffset)
            {
                X += xOffset;
                Y += yOffset;
            }
        }
    }
}