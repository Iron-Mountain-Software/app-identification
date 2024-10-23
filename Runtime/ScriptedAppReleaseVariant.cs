using UnityEngine;

namespace IronMountain.AppIdentification
{
    [CreateAssetMenu(menuName = "Scriptable Objects/App Release Variants/App Release Variant")]
    public class ScriptedAppReleaseVariant : ScriptableObject, IAppReleaseVariant
    {
        [SerializeField] private string id;
        [SerializeField] private string productName;
        [SerializeField] private ApplicationIdentifiers applicationIdentifiers;
        [SerializeField] private Texture2D icon;
        [SerializeField] private AppLogos logos;
        [SerializeField] private string[] iOSUrlSchemes;
        [SerializeField] private string androidDeeplink;

        public string ID => id;
        public string ProductName => productName;
        public ApplicationIdentifiers ApplicationIdentifiers => applicationIdentifiers;
        public Texture2D Icon => icon;
        public AppLogos Logos => logos;
        public string[] IOSUrlSchemes => iOSUrlSchemes;
        public string AndroidDeeplink => androidDeeplink;

        private string IconName => icon ? icon.name : "null";

        public override string ToString()
        {
            return $"ProductName: {ProductName}\n" +
                   $"Icon: {IconName}";
        }

        public virtual void Activate() { }
        public virtual void Deactivate() { }
        
#if UNITY_EDITOR
        
        public virtual void Reset()
        {
            GenerateNewID();
        }

        [ContextMenu("Generate New ID")]
        private void GenerateNewID()
        {
            id = UnityEditor.GUID.Generate().ToString();
        }

#endif
    }
}