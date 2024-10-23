using System.IO;
using UnityEditor;
using UnityEngine;

namespace IronMountain.AppIdentification.Editor
{
    public static class AppIdentificationEditor
    {
        private static string androidManifestPath = "Assets/Plugins/Android/AndroidManifest.xml";

        public static void ChangeAppReleaseVariant(IAppReleaseVariant variant)
        {
            if (variant == null) return;
            ChangeIcons(variant.Icon);
            PlayerSettings.productName = variant.ProductName;
            PlayerSettings.SetApplicationIdentifier(BuildTargetGroup.iOS, variant.ApplicationIdentifiers.IOS);
            PlayerSettings.SetApplicationIdentifier(BuildTargetGroup.Android, variant.ApplicationIdentifiers.Android);
            PlayerSettings.iOS.iOSUrlSchemes = variant.IOSUrlSchemes;
            if (!string.IsNullOrWhiteSpace(variant.AndroidDeeplink))
            {
                ChangeAndroidDeepLink(variant.AndroidDeeplink);
            }
            else RemoveDeepLink();
            AppReleaseVariantsManager.CurrentAppReleaseVariant = variant;
            variant.Activate();
        }

        private static void ChangeIcons(Texture2D icon)
        {
            Texture2D[] icons1 = { icon };
            Texture2D[] icons2 = { icon, icon };
            Texture2D[] icons4 = { icon, icon, icon, icon };
            Texture2D[] icons5 = { icon, icon, icon, icon, icon };
            Texture2D[] icons6 = { icon, icon, icon, icon, icon, icon };

            PlayerSettings.SetIconsForTargetGroup(BuildTargetGroup.Unknown, icons1, IconKind.Application);
            PlayerSettings.SetIconsForTargetGroup(BuildTargetGroup.iOS, icons4, IconKind.Any);
            PlayerSettings.SetIconsForTargetGroup(BuildTargetGroup.iOS, icons5, IconKind.Application);
            PlayerSettings.SetIconsForTargetGroup(BuildTargetGroup.iOS, icons4, IconKind.Notification);
            PlayerSettings.SetIconsForTargetGroup(BuildTargetGroup.iOS, icons5, IconKind.Settings);
            PlayerSettings.SetIconsForTargetGroup(BuildTargetGroup.iOS, icons4, IconKind.Spotlight);
            PlayerSettings.SetIconsForTargetGroup(BuildTargetGroup.iOS, icons1, IconKind.Store);
            PlayerSettings.SetIconsForTargetGroup(BuildTargetGroup.Android, icons6, IconKind.Application);

            var kind = UnityEditor.Android.AndroidPlatformIconKind.Adaptive;
            var icons = PlayerSettings.GetPlatformIcons(BuildTargetGroup.Android, kind);

            for (int i = 0; i < icons.Length; i++)
            {
                icons[i].SetTextures(icons2);
            }
            
            PlayerSettings.SetPlatformIcons(BuildTargetGroup.Android, kind, icons);
        }
        
        private static void ChangeAndroidDeepLink(string deepLink)
        {
            if (!File.Exists(androidManifestPath))
            {
                Debug.LogError("AndroidManifest.xml not found at: " + androidManifestPath);
                return;
            }

            // Load the AndroidManifest.xml file
            string manifestContent = File.ReadAllText(androidManifestPath);

            // Modify the intent-filter for deep linking
            string deepLinkIntentFilter = $@"
            <intent-filter>
                <action android:name=""android.intent.action.VIEW"" />
                <category android:name=""android.intent.category.DEFAULT"" />
                <category android:name=""android.intent.category.BROWSABLE"" />
                <data android:scheme=""{deepLink}"" />
            </intent-filter>";

            // Replace existing deep link or add it if not present
            if (manifestContent.Contains("<data android:scheme="))
            {
                manifestContent = System.Text.RegularExpressions.Regex.Replace(manifestContent, @"<data android:scheme=""[^""]+"" />", $@"<data android:scheme=""{deepLink}"" />");
            }
            else
            {
                // Add the intent-filter for deep linking under the <activity> tag
                manifestContent = manifestContent.Replace("</activity>", deepLinkIntentFilter + "\n</activity>");
            }

            // Save changes back to the AndroidManifest.xml file
            File.WriteAllText(androidManifestPath, manifestContent);

            Debug.Log("Deep link URL updated in AndroidManifest.xml to: " + deepLink);
        }
        
        private static void RemoveDeepLink()
        {
            if (!File.Exists(androidManifestPath))
            {
                Debug.LogError("AndroidManifest.xml not found at: " + androidManifestPath);
                return;
            }

            // Load the AndroidManifest.xml file
            string manifestContent = File.ReadAllText(androidManifestPath);

            // Find and remove the intent-filter block related to deep linking
            string deepLinkIntentFilterPattern = @"<intent-filter>\s*<action android:name=""android.intent.action.VIEW"" />\s*<category android:name=""android.intent.category.DEFAULT"" />\s*<category android:name=""android.intent.category.BROWSABLE"" />\s*<data android:scheme=""[^""]+"" />\s*</intent-filter>";

            if (System.Text.RegularExpressions.Regex.IsMatch(manifestContent, deepLinkIntentFilterPattern))
            {
                manifestContent = System.Text.RegularExpressions.Regex.Replace(manifestContent, deepLinkIntentFilterPattern, string.Empty);
                File.WriteAllText(androidManifestPath, manifestContent);
                Debug.Log("Deep link intent-filter removed from AndroidManifest.xml");
            }
            else
            {
                Debug.LogWarning("No deep link intent-filter found in AndroidManifest.xml");
            }
        }
    }
}