using UnityEngine;
using UnityEngine.Audio;

namespace Audiotter.Runtime
{
    [CreateAssetMenu(fileName = AssetName, menuName = "Audiotter/Audiotter Settings", order = 1)]
    public class AudiotterSettings : ScriptableObject
    {
        public const string AssetName = "AudiotterSettings";
        [SerializeField] private AudioMixer _audioMixer;
        [SerializeField] private AudioMixerGroup _soundMixerGroup;
        [SerializeField] private AudioMixerGroup _musicMixerGroup;
        [Range(-80f, 0f)] [SerializeField] private float _minVolume = -80f;

        public AudioMixer AudioMixer => _audioMixer;
        public AudioMixerGroup SoundMixerGroup => _soundMixerGroup;
        public AudioMixerGroup MusicMixerGroup => _musicMixerGroup;
        public float MinVolume => _minVolume;
    }
}