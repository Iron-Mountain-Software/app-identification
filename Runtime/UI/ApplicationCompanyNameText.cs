using UnityEngine;

namespace IronMountain.AppIdentification.UI
{
    public class ApplicationCompanyNameText : ApplicationText
    {
        protected override string Value => Application.companyName;
    }
}