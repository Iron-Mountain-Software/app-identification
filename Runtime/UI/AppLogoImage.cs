using UnityEngine;
using UnityEngine.UI;

namespace SpellBoundAR.AppIdentification.UI
{
    [ExecuteAlways]
    [RequireComponent(typeof(Image))]
    public class AppLogoImage : MonoBehaviour
    {
        [SerializeField] private AppLogos.Type type = AppLogos.Type.HorizontalLight;
        
        [Header("Cache")]
        private Image _image;
        
        private void Awake()
        {
            _image = GetComponent<Image>();
        }

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
            if (!_image) return;
            _image.sprite = AppReleaseVariantsManager.CurrentAppReleaseVariant?.Logos.GetLogo(type);
        }

        private void OnValidate()
        {
            Refresh();
        }
    }
}