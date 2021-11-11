using UnityEngine;
using UnityEngine.Audio;

namespace Audiotter.Runtime
{
    public static class AudiotterMixer
    {
        private const string MusicVolumeKey = "AudiotterMusicVolume";
        private const string SoundVolumeKey = "AudiotterSoundVolume";
        private const string MasterVolumeKey = "AudiotterMasterVolume";
        public static AudioMixer Mixer => AudiotterSettings.AudioMixer;
        public static AudioMixerGroup MusicMixerGroup => AudiotterSettings.MusicMixerGroup;
        public static AudioMixerGroup SoundMixerGroup => AudiotterSettings.SoundMixerGroup;

        public static float MasterVolume
        {
            get => PlayerPrefs.GetFloat(MasterVolumeKey, 1);
            set
            {
                PlayerPrefs.SetFloat(MasterVolumeKey, value);
                PlayerPrefs.Save();
                UpdateMasterVolume();
            }
        }

        public static float SoundVolume
        {
            get => PlayerPrefs.GetFloat(SoundVolumeKey, 1);
            set
            {
                PlayerPrefs.SetFloat(SoundVolumeKey, value);
                PlayerPrefs.Save();
                UpdateSoundVolume();
            }
        }

        public static float MusicVolume
        {
            get => PlayerPrefs.GetFloat(MusicVolumeKey, 1);
            set
            {
                PlayerPrefs.SetFloat(MusicVolumeKey, value);
                PlayerPrefs.Save();
                UpdateMusicVolume();
            }
        }

        private static AudiotterSettings AudiotterSettings => SettingsLoader.GetSettings();

        private static void UpdateMasterVolume()
        {
            Mixer.SetFloat(MasterVolumeKey, ConvertToDb(MasterVolume));
        }

        private static void UpdateMusicVolume()
        {
            Mixer.SetFloat(MusicVolumeKey, ConvertToDb(MusicVolume));
        }

        private static void UpdateSoundVolume()
        {
            Mixer.SetFloat(SoundVolumeKey, ConvertToDb(SoundVolume));
        }

        private static float ConvertToDb(float volume)
        {
            return Mathf.Lerp(SettingsLoader.GetSettings().MinVolume, 0f, volume);
        }
    }
}