using UnityEngine;
using UnityEngine.UI;

namespace IronMountain.AppIdentification.UI
{
    [ExecuteAlways]
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Text))]
    public class DeviceUniqueIdentifierText : MonoBehaviour
    {
        [SerializeField] private Text text;
    
        private void Awake() => Refresh();
        private void OnValidate() => Refresh();
        private void OnEnable() => Refresh();

        private void Refresh()
        {
            if (!text) text = GetComponent<Text>();
            if (text) text.text = SystemInfo.deviceUniqueIdentifier;
        }
    }
}