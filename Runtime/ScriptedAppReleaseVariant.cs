using SpellBoundAR.AssetManagement;
using SpellBoundAR.RemoteConfiguration;
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
        [SerializeField] private ScriptedRemoteConfigurationEnvironment remoteConfigurationEnvironment;

        public string ProductName => productName;
        public string ApplicationIdentifier => applicationIdentifier;
        public Texture2D Icon => icon;
        public AppLogos Logos => logos;
        public ScriptedRemoteConfigurationEnvironment RemoteConfigurationEnvironment => remoteConfigurationEnvironment;

        private string IconName => icon ? icon.name : "null";

        public override string ToString()
        {
            return $"ProductName: {ProductName}\n" +
                   $"ApplicationIdentifier: {ApplicationIdentifier}\n" +
                   $"Icon: {IconName}";
        }

        public virtual void Activate()
        {
            AppReleaseVariantsManager.ActivateRemoteEnvironment();
        }
    }
}