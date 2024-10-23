using UnityEngine;

namespace IronMountain.AppIdentification
{
    public interface IAppReleaseVariant
    {
        public string ID { get; }
        public string ProductName { get; }
        public ApplicationIdentifiers ApplicationIdentifiers { get; }
        public Texture2D Icon { get; }
        public AppLogos Logos { get; }
        public string[] IOSUrlSchemes { get; }
        public string AndroidDeeplink { get; }
        public string ToString();
        public void Activate();
        public void Deactivate();
    }
}