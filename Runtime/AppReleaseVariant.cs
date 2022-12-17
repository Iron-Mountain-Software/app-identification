using System;
using UnityEngine;

namespace SpellBoundAR.AppIdentification
{
    [Serializable]
    public class AppReleaseVariant : MonoBehaviour
    {
        public string ProductName { get; }
        public string ApplicationIdentifier { get; }
        public string IconPath { get; }

        public AppReleaseVariant(string productName, string applicationIdentifier, string iconPath)
        {
            ProductName = productName;
            ApplicationIdentifier = applicationIdentifier;
            IconPath = iconPath;
        }
    }
}
