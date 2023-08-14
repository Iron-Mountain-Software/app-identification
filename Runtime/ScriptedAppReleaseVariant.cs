using SpellBoundAR.AssetManagement;
using UnityEngine;

namespace SpellBoundAR.AppIdentification
{
    [CreateAssetMenu(menuName = "Scriptable Objects/App Release Variants/App Release Variant")]
    public class ScriptedAppReleaseVariant : IdentifiableScriptableObject, IAppReleaseVariant
    {
        [SerializeField] private string productName;
        [SerializeField] private string applicationIdentifier;
        [SerializeField] private Texture2D icon;
        [SerializeField] private AppLogos logos;

        public string ProductName => productName;
        public string ApplicationIdentifier => applicationIdentifier;
        public Texture2D Icon => icon;
        public AppLogos Logos => logos;

        private string IconName => icon ? icon.name : "null";

        public override string ToString()
        {
            return $"ProductName: {ProductName}\n" +
                   $"ApplicationIdentifier: {ApplicationIdentifier}\n" +
                   $"Icon: {IconName}";
        }

        public virtual void Activate() { }
        public virtual void Deactivate() { }
    }
}