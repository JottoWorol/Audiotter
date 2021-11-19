using System.IO;
using Audiotter.Runtime;
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
            const string projectResourcePath = assetsFolder + "/" + resourceFolder;
            const string localPath = "Packages/com.jottoworol.audiotter/Assets/Runtime";
            const string settingsName = "/" + AudiotterSettings.AssetName + ".asset";

            if (!AssetDatabase.IsValidFolder(projectResourcePath))
                AssetDatabase.CreateFolder(assetsFolder, resourceFolder);

            if (!File.Exists(Application.dataPath + "/" + resourceFolder + settingsName))
                AssetDatabase.CopyAsset(localPath + settingsName, projectResourcePath + settingsName);
        }
    }
}