using SpellBoundAR.AssetManagement;
using UnityEngine;

namespace SpellBoundAR.AppIdentification
{
    [CreateAssetMenu(menuName = "Scriptable Objects/App Release Variants/Database")]
    public class Database : SingletonDatabase<Database>
    {
        [SerializeField] private DatabaseTable<ScriptedAppReleaseVariant> appReleaseVariants = new ();
        public DatabaseTable<ScriptedAppReleaseVariant> AppReleaseVariants => appReleaseVariants;
    }
}
