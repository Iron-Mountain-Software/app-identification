using UnityEditor;

namespace IronMountain.AppIdentification.Editor
{
    [CustomEditor(typeof(AppReleaseVariantDependantGameObject), true)]
    public class AppReleaseVariantDependantGameObjectInspector : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            EditorGUI.BeginDisabledGroup(true);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("m_Script"));
            EditorGUI.EndDisabledGroup();
            EditorGUILayout.PropertyField(serializedObject.FindProperty("controlledObject"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("defaultState"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("defaultState").boolValue 
                ? serializedObject.FindProperty("variantsWhereNotActive")
                : serializedObject.FindProperty("variantsWhereActive"));
            serializedObject.ApplyModifiedProperties();
        }
    }
}
