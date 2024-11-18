using UnityEngine;

namespace IronMountain.AppIdentification.UI
{
    public class ApplicationUnityVersionText : ApplicationText
    {
        protected override string Value => Application.unityVersion;
    }
}