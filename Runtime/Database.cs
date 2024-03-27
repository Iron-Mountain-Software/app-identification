using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace IronMountain.AppIdentification
{
    [CreateAssetMenu(menuName = "Scriptable Objects/App Release Variants/Database")]
    public class Database : ScriptableObject
    {
        private static Database _instance;

        public static Database Instance
        {
            get
            {
                if (_instance) return _instance;
                Database[] databases = Resources.LoadAll<Database>(string.Empty);
                if (databases == null || databases.Length == 0)
                {
                    throw new Exception("Resources: Could not find instance: " + typeof(Database).FullName);
                }
                if (databases.Length > 1)
                {
                    Debug.LogWarning("Resources: Multiple instances: " + typeof(Database).FullName);
                }
                _instance = databases[0];
                return _instance;
            }
        }
        
        [SerializeField] private List<ScriptedAppReleaseVariant> appReleaseVariants = new ();

        private Dictionary<string, ScriptedAppReleaseVariant> _dictionary;

        public List<ScriptedAppReleaseVariant> AppReleaseVariants => appReleaseVariants;

        public ScriptedAppReleaseVariant GetReleaseVariantByID(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) return null;
            if (_dictionary == null) RebuildDictionary();
            if (_dictionary.ContainsKey(id)) return _dictionary[id];
            return AppReleaseVariants.Find(
                test => test != null
                    && test.ApplicationIdentifiers != null
                    && test.ApplicationIdentifiers.Contains(id));
        }

        public void SortList()
        {
            appReleaseVariants.Sort((a, b) => string.Compare(a.name, b.name, StringComparison.OrdinalIgnoreCase));   
        }

        public void RebuildDictionary()
        {
            if (_dictionary != null) _dictionary.Clear();
            else _dictionary = new Dictionary<string, ScriptedAppReleaseVariant>();
            int failures = 0;
            foreach (ScriptedAppReleaseVariant appReleaseVariant in appReleaseVariants)
            {
                try  
                {
                    if (!appReleaseVariant) throw new Exception("Null App Release Variant");
                    if (string.IsNullOrWhiteSpace(appReleaseVariant.ID)) throw new Exception("App Release Variant with empty key: " + appReleaseVariant.name);
                    if (_dictionary.ContainsKey(appReleaseVariant.ID)) throw new Exception("App Release Variants with duplicate keys: " + appReleaseVariant.name + ", " + _dictionary[appReleaseVariant.ID].name);
                    _dictionary.Add(appReleaseVariant.ID, appReleaseVariant);
                }  
                catch (Exception exception)  
                {  
                    failures++;
                    if (appReleaseVariant) Debug.LogError(exception.Message, appReleaseVariant);
                    else Debug.LogError(exception.Message);
                }
            }
            Debug.Log("Rebuilt Dictionary: " + _dictionary.Count + " Successes, " + failures + " Failures");
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("<APP RELEASE VARIANTS>\n");
            foreach (ScriptedAppReleaseVariant appReleaseVariant in appReleaseVariants)
            {
                result.Append(appReleaseVariant.ID);
                result.Append("\t");
                result.Append(appReleaseVariant.name);
                result.Append("\n");
            }
            result.Append("</APP RELEASE VARIANTS>\n");
            return result.ToString();
        }
    }
}
