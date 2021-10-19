﻿using System.Collections.Generic;
using Audiotter.Attributes;
using Audiotter.Runtime.Components.Players.Base;
using UnityEngine;

namespace Audiotter.Runtime.Components.Players
{
    [AddComponentMenu("Audiotter/Players/Audiotter Random Loop")]
    public class AudiotterRandomLoop : AudiotterLoopBase
    {
        [SerializeField] private List<AudioClip> _audioClipBank = new List<AudioClip>();
        [SerializeField] private bool _changeEveryLoop = false;

        [ShowIf(nameof(_changeEveryLoop))] [SerializeField]
        private bool _noRepetitions = false;

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

        private AudioClip GetRandomClip()
        {
            return _audioClipBank[Random.Range(0, _audioClipBank.Count)];
        }

        private void Update()
        {
            if (_isWaitingForStop && !AudioSource.isPlaying)
                PlayNextClip();
        }

        private AudioClip _fixedAudioClip;
        private bool _isWaitingForStop = false;
    }
}