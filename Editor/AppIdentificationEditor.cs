using UnityEditor;
using UnityEngine;

namespace SpellBoundAR.AppIdentification.Editor
{
    public static class AppIdentificationEditor
    {
        public static void ChangeAppReleaseVariant(IAppReleaseVariant variant)
        {
            if (variant == null) return;
            ChangeIcons(variant.Icon);
            PlayerSettings.productName = variant.ProductName;
            PlayerSettings.SetApplicationIdentifier(BuildTargetGroup.iOS, variant.ApplicationIdentifier);
            PlayerSettings.SetApplicationIdentifier(BuildTargetGroup.Android, variant.ApplicationIdentifier);
            AppReleaseVariantsManager.CurrentAppReleaseVariant = variant;
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
    }
}