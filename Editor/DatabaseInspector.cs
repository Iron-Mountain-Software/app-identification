using UnityEditor;
using UnityEngine;

namespace IronMountain.AppIdentification.Editor
{
    [CustomEditor(typeof(Database), true)]
    public class DatabaseInspector : UnityEditor.Editor
    {
        private Database _database;

        private void OnEnable()
        {
            _database = (Database) target;
        }

        public override void OnInspectorGUI()
        {
            EditorGUILayout.Space();

            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Rebuild"))
            {
                RebuildSceneList();
                _database.SortList();
                _database.RebuildDictionary();
            }
            if (GUILayout.Button("Log & Copy Data"))
            {
                string data = _database.ToString();
                EditorGUIUtility.systemCopyBuffer = data;
                Debug.Log(data);
            }
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.Space();

            EditorGUILayout.BeginHorizontal();
            SerializedProperty appReleaseVariants = serializedObject.FindProperty("appReleaseVariants");
            EditorGUILayout.PropertyField(appReleaseVariants);
            EditorGUILayout.BeginVertical(GUILayout.Width(75));
            if (appReleaseVariants.isExpanded)
            {
                GUILayout.Space(EditorGUIUtility.singleLineHeight * 1.5f);
                foreach (ScriptedAppReleaseVariant appReleaseVariant in _database.AppReleaseVariants)
                {
                    EditorGUI.BeginDisabledGroup(!appReleaseVariant);
                    if (GUILayout.Button("Activate", GUILayout.ExpandWidth(true), GUILayout.MaxHeight(EditorGUIUtility.singleLineHeight)))
                    {
                        if (appReleaseVariant)
                        {
                            AppIdentificationEditor.ChangeAppReleaseVariant(appReleaseVariant);
                        }
                    }
                    EditorGUI.EndDisabledGroup();
                }
            }
            EditorGUILayout.EndVertical();
            EditorGUILayout.EndHorizontal();
            
            serializedObject.ApplyModifiedProperties();
        }

        private void RebuildSceneList()
        {
            _database.AppReleaseVariants.Clear();
            string[] guids = AssetDatabase.FindAssets($"t:{typeof(ScriptedAppReleaseVariant)}");
            for( int i = 0; i < guids.Length; i++ )
            {
                string assetPath = AssetDatabase.GUIDToAssetPath( guids[i] );
                ScriptedAppReleaseVariant asset = AssetDatabase.LoadAssetAtPath<ScriptedAppReleaseVariant>( assetPath );
                if (asset) _database.AppReleaseVariants.Add(asset);
            }
            EditorUtility.SetDirty(_database);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
    }
}