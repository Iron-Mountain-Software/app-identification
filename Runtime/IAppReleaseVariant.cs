using UnityEngine;

namespace SpellBoundAR.AppIdentification
{
    public interface IAppReleaseVariant
    {
        public string ProductName { get; }
        public ApplicationIdentifiers ApplicationIdentifiers { get; }
        public Texture2D Icon { get; }
        public AppLogos Logos { get; }
        public string ToString();
        public void Activate();
        public void Deactivate();
    }
}