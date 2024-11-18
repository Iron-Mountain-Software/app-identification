using UnityEngine;

namespace IronMountain.AppIdentification.UI
{
    public class ApplicationProductNameText : ApplicationText
    {
        protected override string Value => Application.productName;
    }
}