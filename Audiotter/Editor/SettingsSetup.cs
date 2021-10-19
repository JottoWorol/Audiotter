using System.IO;
using UnityEditor;
using UnityEngine;

namespace Audiotter.Editor
{
    public static class SettingsSetup
    {
        [InitializeOnLoadMethod]
        private static void Initialize()
        {
            const string assetsFolder = "Assets";
            const string resourceFolder = "Resources";
            const string fullFolderName = assetsFolder + "/" + resourceFolder;
            const string assetPath = fullFolderName + "/AudiotterSettings.asset";
            const string settingsPath = "Packages/com.jottoworol.audiotter/Audiotter/Runtime/AudiotterSettings.asset";

            if (!AssetDatabase.IsValidFolder(fullFolderName))
                AssetDatabase.CreateFolder(assetsFolder, resourceFolder);

            if (!File.Exists(Application.dataPath + "/Resources/AudiotterSettings.asset"))
                AssetDatabase.CopyAsset(settingsPath, assetPath);
        }

        private static void TryCopySettings()
        {
            if (!File.Exists(Application.dataPath + "/Resources/AudiotterSettings.asset"))
            {
                if (AssetDatabase.CopyAsset(
                    "Assets/Audiotter/AudiotterSettings.asset",
                    "Assets/Resources/AudiotterSettings.asset"))
                    Debug.Log("Copied Audiotter settings");
                else
                    Debug.Log("Failed to copy Audiotter settings");
            }
            else
            {
                Debug.Log("Already here");
            }
        }

        private static void SetVoicingSettings()
        {
            var settings = AudioSettings.GetConfiguration();
            settings.numRealVoices = 4;
            AudioSettings.Reset(settings);
        }
    }
}