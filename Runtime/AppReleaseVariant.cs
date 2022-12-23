using System;
using UnityEngine;

namespace SpellBoundAR.AppIdentification
{
    [Serializable]
    public class AppReleaseVariant : IAppReleaseVariant
    {
        [SerializeField] private string productName;
        [SerializeField] private string applicationIdentifier;
        [SerializeField] private string iconPath;
        [SerializeField] private string remoteConfigEnvironmentID;

        public string ProductName => productName;
        public string ApplicationIdentifier => applicationIdentifier;
        public Texture2D Icon => Resources.Load(iconPath) as Texture2D;
        public string RemoteConfigEnvironmentID => remoteConfigEnvironmentID;

        public override string ToString()
        {
            return $"ProductName: {ProductName}\n" +
                   $"ApplicationIdentifier: {ApplicationIdentifier}\n" +
                   $"IconPath: {iconPath}\n" +
                   $"RemoteConfigEnvironmentID: {RemoteConfigEnvironmentID}\n";
        }

        public AppReleaseVariant(
            string productName,
            string applicationIdentifier,
            string iconPath,
            string remoteConfigEnvironmentID)
        {
            this.productName = productName;
            this.applicationIdentifier = applicationIdentifier;
            this.iconPath = iconPath;
            this.remoteConfigEnvironmentID = remoteConfigEnvironmentID;
        }
    }
}