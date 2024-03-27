using System;
using UnityEngine;
using UnityEngine.UI;

namespace IronMountain.AppIdentification.UI
{
    [ExecuteAlways]
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Text))]
    public class ApplicationIdentifierText : MonoBehaviour
    {
        [SerializeField] private Text text;
    
        private void Awake() => Refresh();
        private void OnValidate() => Refresh();
        
        private void OnEnable()
        {
            AppReleaseVariantsManager.OnCurrentAppReleaseVariantChanged += Refresh;
            Refresh();
        }

        private void OnDisable()
        {
            AppReleaseVariantsManager.OnCurrentAppReleaseVariantChanged -= Refresh;
        }

        private void Refresh()
        {
            if (!text) text = GetComponent<Text>();
            if (text) text.text = Application.identifier;
        }
    }
}