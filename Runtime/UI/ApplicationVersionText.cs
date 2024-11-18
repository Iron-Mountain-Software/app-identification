using UnityEngine;

namespace IronMountain.AppIdentification.UI
{
    public class ApplicationVersionText : ApplicationText
    {
        protected override string Value => Application.version;
    }
}