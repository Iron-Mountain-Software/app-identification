using System.Net;
using SpellBoundAR.AssetManagement.Editor;
using UnityEditor;
using UnityEngine;

namespace SpellBoundAR.AppIdentification.Editor
{
    [CustomEditor(typeof(Database), true)]
    public class DatabaseInspector : SingletonDatabaseInspector
    {
        protected override void RebuildLists()
        {
            Utilities.FillWithAssetsOfType(((Database) target).AppReleaseVariants.list, target);
        }

        protected override void SortLists()
        {
            ((Database)target).AppReleaseVariants.SortList();
        }

        protected override void RebuildDictionaries()
        {
            ((Database)target).AppReleaseVariants.RebuildDictionary();
        }

        public override string ToString()
        {
            return ((Database)target).AppReleaseVariants.ToString("App Release Variants");
        }

        public override void OnInspectorGUI()
        {
            foreach (ScriptedAppReleaseVariant appReleaseVariant in ((Database)target).AppReleaseVariants.list)
            {
                if (!appReleaseVariant) continue;
                if (GUILayout.Button("Switch to " + appReleaseVariant.ProductName, GUILayout.MinHeight(40)))
                {
                    AppIdentificationEditor.ChangeAppReleaseVariant(appReleaseVariant);
                }
            }
            base.OnInspectorGUI();
        }
    }
}