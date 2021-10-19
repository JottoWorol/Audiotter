﻿using UnityEngine;

namespace Audiotter.Runtime.Components.Players.Base
{
    public abstract class AudiotterLoopBase : AudiotterPlayerBase
    {
        public override void Play()
        {
            base.Play();

            TryPlayLoop();
        }

        public override void Stop()
        {
            AudioSource.Stop();
        }

        public override bool IsPlaying()
        {
            return AudioSource.isPlaying;
        }

        protected abstract void TryPlayLoop();

        protected override void Initialize()
        {
            AudioSource = gameObject.AddComponent<AudioSource>();
            AudioSource.volume = Volume;
            AudioSource.outputAudioMixerGroup = GetMixerGroup();
            base.Initialize();
        }

        private void OnEnable()
        {
            LocalVolumeChanged += OnLocalVolumeChanged;
        }

        private void OnDisable()
        {
            LocalVolumeChanged -= OnLocalVolumeChanged;
        }

        private void OnLocalVolumeChanged()
        {
            AudioSource.volume = Volume;
        }

        protected AudioSource AudioSource;
    }
}