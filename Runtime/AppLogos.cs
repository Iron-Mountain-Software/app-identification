using System;
using UnityEngine;

namespace IronMountain.AppIdentification
{
    [Serializable]
    public struct AppLogos
    {
        public enum Type
        {
            HorizontalLight,
            HorizontalDark,
            SquareLight,
            SquareDark,
            IconLight,
            IconDark,
            BackgroundLight,
            BackgroundDark
        }
        
        [SerializeField] private Sprite horizontalLight;
        [SerializeField] private Sprite horizontalDark;
        [SerializeField] private Sprite squareLight;
        [SerializeField] private Sprite squareDark;
        [SerializeField] private Sprite iconLight;
        [SerializeField] private Sprite iconDark;
        [SerializeField] private Sprite backgroundLight;
        [SerializeField] private Sprite backgroundDark;

        public Sprite HorizontalLight => horizontalLight;
        public Sprite HorizontalDark => horizontalDark;
        public Sprite SquareLight => squareLight;
        public Sprite SquareDark => squareDark;
        public Sprite IconLight => iconLight;
        public Sprite IconDark => iconDark;
        public Sprite BackgroundLight => backgroundLight;
        public Sprite BackgroundDark => backgroundDark;

        public Sprite GetLogo(Type type)
        {
            switch (type)
            {
                case Type.HorizontalLight:
                    return HorizontalLight;
                case Type.HorizontalDark:
                    return HorizontalDark;
                case Type.SquareLight:
                    return SquareLight;
                case Type.SquareDark:
                    return SquareDark;                
                case Type.IconLight:
                    return IconLight;
                case Type.IconDark:
                    return IconDark;
                case Type.BackgroundLight:
                    return BackgroundLight;
                case Type.BackgroundDark:
                    return BackgroundDark;
                default:
                    return null;
            }
        }
    }
}