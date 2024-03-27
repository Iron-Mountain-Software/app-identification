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
            SquareDark
        }
        
        [SerializeField] private Sprite horizontalLight;
        [SerializeField] private Sprite horizontalDark;
        [SerializeField] private Sprite squareLight;
        [SerializeField] private Sprite squareDark;

        public Sprite HorizontalLight => horizontalLight;
        public Sprite HorizontalDark => horizontalDark;
        public Sprite SquareLight => squareLight;
        public Sprite SquareDark => squareDark;

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
                default:
                    return null;
            }
        }
    }
}