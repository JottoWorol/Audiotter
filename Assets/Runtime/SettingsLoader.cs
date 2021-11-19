using UnityEngine;

namespace Audiotter.Runtime
{
    public static class SettingsLoader
    {
        private static AudiotterSettings _audiotterSettings;

        public static AudiotterSettings GetSettings()
        {
            _audiotterSettings ??= Resources.Load<AudiotterSettings>(AudiotterSettings.AssetName);

            return _audiotterSettings;
        }
    }
}