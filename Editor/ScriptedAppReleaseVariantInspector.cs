using System;
using UnityEditor;
using UnityEngine;

namespace SpellBoundAR.AppIdentification.Editor
{
    [CustomEditor(typeof(ScriptedAppReleaseVariant), true)]
    public class ScriptedAppReleaseVariantInspector : UnityEditor.Editor
    {
        [Header("Cache")]
        private ScriptedAppReleaseVariant _scriptedAppReleaseVariant;

        private void OnEnable()
        {
            _scriptedAppReleaseVariant = (ScriptedAppReleaseVariant) target;
        }

        public override void OnInspectorGUI()
        {
            if (GUILayout.Button("Activate") && _scriptedAppReleaseVariant)
            {
                AppIdentificationEditor.ChangeAppReleaseVariant(_scriptedAppReleaseVariant);
            }
            base.OnInspectorGUI();
        }
    }
}