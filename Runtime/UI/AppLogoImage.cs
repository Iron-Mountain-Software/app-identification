using UnityEngine;
using UnityEngine.UI;

namespace SpellBoundAR.AppIdentification.UI
{
    [ExecuteAlways]
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Image))]
    public class AppLogoImage : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private AppLogos.Type type = AppLogos.Type.HorizontalLight;
        
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
            if (!image) image = GetComponent<Image>();
            if (image) image.sprite = AppReleaseVariantsManager.CurrentAppReleaseVariant?.Logos.GetLogo(type);
        }
    }
}