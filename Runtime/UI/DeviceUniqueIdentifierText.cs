using UnityEngine;
using UnityEngine.UI;

namespace SpellBoundAR.AppIdentification.UI
{
    [ExecuteAlways]
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Text))]
    public class DeviceUniqueIdentifierText : MonoBehaviour
    {
        [Header("Cache")]
        private Text _text;
    
        private void Awake() => _text = GetComponent<Text>();
        private void OnEnable() => RefreshText();
        private void OnValidate() => RefreshText();

        private void RefreshText()
        {
            if (_text) _text.text = SystemInfo.deviceUniqueIdentifier;
        }
    }
}

