using UnityEngine;

namespace SpellBoundAR.AppIdentification
{
    public static class AppReleaseVariantsManager
    {
        public static IAppReleaseVariant GetCurrentAppReleaseVariant()
        {
            return Database.Instance.AppReleaseVariants.list.Find(
                test =>
                    test
                    && test.ApplicationIdentifier == Application.identifier);
        }
    }
}