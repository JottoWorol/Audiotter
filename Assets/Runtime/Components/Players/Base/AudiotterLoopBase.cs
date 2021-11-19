using UnityEngine;

namespace Audiotter.Runtime.Components
{
    public abstract class AudiotterLoopBase : AudiotterPlayerBase
    {
        protected AudioSource AudioSource { get; private set; }

        protected void OnEnable()
        {
            VolumeChanged += OnVolumeChanged;
            PitchChanged += OnPitchChanged;
        }

        protected void OnDisable()
        {
            VolumeChanged -= OnVolumeChanged;
            PitchChanged -= OnPitchChanged;
        }

        public override void Play()
        {
            base.Play();

            TryPlayLoop();
        }

        public override void Stop()
        {
            AudioSource.Stop();
        }

        public override bool IsPlaying() => AudioSource.isPlaying;

        protected abstract void TryPlayLoop();

        protected override void Initialize()
        {
            AudioSource = gameObject.AddComponent<AudioSource>();
            AudioSource.volume = Volume;
            AudioSource.outputAudioMixerGroup = GetMixerGroup();
            AudioSource.playOnAwake = false;
            base.Initialize();
        }

        private void OnVolumeChanged()
        {
            AudioSource.volume = Volume;
        }

        private void OnPitchChanged()
        {
            AudioSource.pitch = Pitch;
        }
    }
}