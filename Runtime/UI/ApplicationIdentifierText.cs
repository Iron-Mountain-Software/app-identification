using UnityEngine;

namespace IronMountain.AppIdentification.UI
{
    public class ApplicationIdentifierText : ApplicationText
    {
        protected override string Value => Application.identifier;
    }
}