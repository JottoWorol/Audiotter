using UnityEngine;

namespace Audiotter.Runtime
{
    public static class SettingsLoader
    {
        public static AudiotterSettings GetSettings()
        {
            _audiotterSettings ??= Resources.Load<AudiotterSettings>(AudiotterSettings.AssetName);
            return _audiotterSettings;
        }

        private static AudiotterSettings _audiotterSettings;
    }
}