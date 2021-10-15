using UnityEngine;
using UnityEngine.Audio;

namespace Audiotter
{
    [CreateAssetMenu(fileName = "AudiotterSettings", menuName = "Audiotter/Audiotter Settings", order = 1)]
    public class AudiotterSettings : ScriptableObject
    {
        [SerializeField] private AudioMixer _audioMixer;
        [SerializeField] private AudioMixerGroup _soundMixerGroup;
        [SerializeField] private AudioMixerGroup _musicMixerGroup;
        [SerializeField] private float _minVolume = -80f;

        public AudioMixer AudioMixer => _audioMixer;
        public AudioMixerGroup SoundMixerGroup => _soundMixerGroup;
        public AudioMixerGroup MusicMixerGroup => _musicMixerGroup;
        public float MinVolume => _minVolume;

        public static string AssetName = "AudiotterSettings";
    }
}