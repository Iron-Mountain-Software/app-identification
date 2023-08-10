using UnityEngine;

namespace SpellBoundAR.AppIdentification
{
    public interface IAppReleaseVariant
    {
        public string ProductName { get; }
        public string ApplicationIdentifier { get; }
        public Texture2D Icon { get; }
        public AppLogos Logos { get; }
        public string RemoteConfigEnvironmentID { get; }

        public string ToString();
    }
}
