using System.Collections.Generic;
using UnityEngine;

namespace IronMountain.AppIdentification
{
    [ExecuteAlways]
    public class AppReleaseVariantDependantGameObject : MonoBehaviour
    {
        [SerializeField] private GameObject controlledObject;
        [SerializeField] private bool defaultState = true;
        [SerializeField] private List<ScriptedAppReleaseVariant> variantsWhereActive = new ();
        [SerializeField] private List<ScriptedAppReleaseVariant> variantsWhereNotActive = new ();

        private void OnValidate()
        {
            if (!controlledObject) controlledObject = gameObject;
            Refresh();
        }

        private void Awake() => Refresh();
        
        private void OnEnable()
        {
            AppReleaseVariantsManager.OnCurrentAppReleaseVariantChanged += Refresh;
            Refresh();
        }

        private void OnDisable()
        {
            AppReleaseVariantsManager.OnCurrentAppReleaseVariantChanged -= Refresh;
        }

        public void Refresh()
        {
            switch (AppReleaseVariantsManager.CurrentAppReleaseVariant)
            {
                case ScriptedAppReleaseVariant appReleaseVariant 
                    when appReleaseVariant
                         && variantsWhereActive != null 
                         && variantsWhereActive.Contains(appReleaseVariant):
                    SetControlledObject(true);
                    break;
                case ScriptedAppReleaseVariant appReleaseVariant
                    when appReleaseVariant
                         && variantsWhereNotActive != null 
                         && variantsWhereNotActive.Contains(appReleaseVariant):
                    SetControlledObject(false);
                    break;
                default:
                    SetControlledObject(defaultState);
                    break;
            }
        }

        private void SetControlledObject(bool state)
        {
            if (controlledObject) controlledObject.SetActive(state);
        }
    }
}
