using Assets.Attributes;
using UnityEngine;

namespace Audiotter.Components.Players.Base
{
    public abstract class AudiotterOneShotBase : AudiotterPlayerBase
    {
        [SerializeField] protected bool _delayed = false;
        [ShowIf(nameof(_delayed))][SerializeField] protected float _delay = 0;

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

        public override bool IsPlaying() => _audioSource.isPlaying;

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

        private void PlayOneShot()
        {
            if (TryGetClip(out AudioClip audioClip))
            {
                _audioSource.PlayOneShot(audioClip, Volume);
            }
        }

        private float _waitingTimer;
        private bool _waitingToPlay = false;
        
        private AudioSource _audioSource;
    }
}