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
                _currentAppReleaseVariant?.Deactivate();
                _currentAppReleaseVariant = value;
                _currentAppReleaseVariant?.Activate();
                OnCurrentAppReleaseVariantChanged?.Invoke();
            }
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void StartInitialization()
        {
            if (CurrentAppReleaseVariant != null) return;
            if (!Database.Instance) return;
            if (Database.Instance.AppReleaseVariants.list.Count == 0) return;
            CurrentAppReleaseVariant = Database.Instance.AppReleaseVariants.list.Find(
                appReleaseVariant =>
                    appReleaseVariant != null
                    && appReleaseVariant.ApplicationIdentifiers != null
                    && appReleaseVariant.ApplicationIdentifiers.Contains(Application.identifier));
            if (_currentAppReleaseVariant != null) return;
            CurrentAppReleaseVariant = Database.Instance.AppReleaseVariants.list[0];
        }
    }
}