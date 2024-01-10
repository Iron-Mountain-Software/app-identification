using UnityEngine;
using UnityEngine.UI;

namespace SpellBoundAR.AppIdentification.UI
{
    [ExecuteAlways]
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Text))]
    public class ApplicationVersionText : MonoBehaviour
    {
        [SerializeField] private Text text;
    
        private void Awake() => Refresh();
        private void OnEnable() => Refresh();
        private void OnValidate() => Refresh();

        private void Refresh()
        {
            if (!text) text = GetComponent<Text>();
            if (text) text.text = Application.version;
        }
    }
}