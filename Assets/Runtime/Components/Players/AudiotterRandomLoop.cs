using System.Collections.Generic;
using Audiotter.Runtime.Attributes;
using UnityEngine;

namespace Audiotter.Runtime.Components
{
    [AddComponentMenu("Audiotter/Players/Audiotter Random Loop")]
    public class AudiotterRandomLoop : AudiotterLoopBase
    {
        [Space(10)] [SerializeField] private List<AudioClip> _audioClipBank = new List<AudioClip>();

        [SerializeField] private bool _changeEveryLoop;

        [ShowIf(nameof(_changeEveryLoop))] [SerializeField]
        private bool _noRepetitions;

        private AudioClip _fixedAudioClip;
        private bool _isWaitingForStop;

        protected new void Update()
        {
            base.Update();

            if (_isWaitingForStop && !AudioSource.isPlaying)
            {
                _isWaitingForStop = false;
                PlayNextClip();
            }
        }

        protected override void TryPlayLoop()
        {
            if (_audioClipBank.Count == 0)
                return;

            PlayNextClip();
        }

        private void PlayNextClip()
        {
            AudioSource.clip = GetNextClip();
            AudioSource.Play();
            _isWaitingForStop = true;
        }

        private AudioClip GetNextClip()
        {
            if (_changeEveryLoop)
            {
                var newClip = GetRandomClip();

                if (!_noRepetitions || AudioSource.clip == null || _audioClipBank.Count == 1)
                    return newClip;

                while (true)
                {
                    if (newClip != AudioSource.clip)
                        return newClip;

                    newClip = GetRandomClip();
                }
            }

            _fixedAudioClip ??= GetRandomClip();
            return _fixedAudioClip;
        }

        private AudioClip GetRandomClip() => _audioClipBank[Random.Range(0, _audioClipBank.Count)];
    }
}