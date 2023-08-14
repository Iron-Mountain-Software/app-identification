using System;
using UnityEngine;

namespace SpellBoundAR.AppIdentification
{
    public static class AppReleaseVariantsManager
    {
        public static event Action OnCurrentAppReleaseVariantChanged;

        private static IAppReleaseVariant _currentAppReleaseVariant;
        
        public static IAppReleaseVariant CurrentAppReleaseVariant
        {
            get => _currentAppReleaseVariant;
            set
            {
                if (_currentAppReleaseVariant == value) return;
                _currentAppReleaseVariant = value;
                _currentAppReleaseVariant?.Activate();
                OnCurrentAppReleaseVariantChanged?.Invoke();
            }
        }
        
        public static bool Initialized { get; private set; }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void StartInitialization()
        {
            if (Initialized) return;
            InitializeCurrentAppReleaseVariant();
            RemoteConfiguration.RemoteConfigurationManager.OnInitialized += ActivateRemoteEnvironment;
            Initialized = true;
        }

        private static void InitializeCurrentAppReleaseVariant()
        {
            if (_currentAppReleaseVariant != null) return;
            if (!Database.Instance) return;
            if (Database.Instance.AppReleaseVariants.list.Count == 0) return;
            CurrentAppReleaseVariant = Database.Instance.AppReleaseVariants.list.Find(
                appReleaseVariant =>
                    appReleaseVariant != null
                    && appReleaseVariant.ApplicationIdentifier == Application.identifier);
            if (_currentAppReleaseVariant != null) return;
            CurrentAppReleaseVariant = Database.Instance.AppReleaseVariants.list[0];
        }

        public static void ActivateRemoteEnvironment()
        {
            if (CurrentAppReleaseVariant == null || !CurrentAppReleaseVariant.RemoteConfigurationEnvironment) return;
            CurrentAppReleaseVariant.RemoteConfigurationEnvironment.ActivateEnvironment();
        }
    }
}