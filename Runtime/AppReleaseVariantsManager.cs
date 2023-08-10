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
            get
            {
                if (_currentAppReleaseVariant == null
                    && Database.Instance)
                {
                    CurrentAppReleaseVariant = Database.Instance.AppReleaseVariants.list.Find(
                        test =>
                            test
                            && test.ApplicationIdentifier == Application.identifier);
                }
                else if (_currentAppReleaseVariant == null
                         && Database.Instance
                         && Database.Instance.AppReleaseVariants.list.Count > 0)
                {
                    CurrentAppReleaseVariant = Database.Instance.AppReleaseVariants.list[0];
                }
                return _currentAppReleaseVariant;
            }
            set
            {
                if (_currentAppReleaseVariant == value) return;
                _currentAppReleaseVariant = value;
                OnCurrentAppReleaseVariantChanged?.Invoke();
            }
        }
    }
}