using UnityEngine;
using UnityEngine.UI;

namespace SpellBoundAR.AppIdentification.UI
{
    [ExecuteAlways]
    [RequireComponent(typeof(Text))]
    public class AppVersionText : MonoBehaviour
    {
        [Header("Cache")]
        private Text _text;
    
        private void Awake() => _text = GetComponent<Text>();
        private void OnEnable() => RefreshText();
        private void OnValidate() => RefreshText();

        private void RefreshText()
        {
            if (!_text) return;
            _text.text = Application.version;
        }
    }
}