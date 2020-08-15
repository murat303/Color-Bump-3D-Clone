using UnityEngine;
using Utilities.Animation;

namespace ColorBump
{
    public class Level : MonoBehaviour
    {
        [Header("Animation")]
        public AnimationBase cameraAnimation;

        [Header("Visual")]
        public Color ballColor;
        public Color groundColor;
        public Color backgroundColor;
    }
}
