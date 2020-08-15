using UnityEngine;

namespace ColorBump
{
    public class Level : MonoBehaviour
    {
        [Header("Visual")]
        public Color colorPlayer;
        public Color colorGround;
        public Color colorBackground;

        [Header("Settings")]
        public float camSpeed = 1.5f;

        [Header("References")]
        public Transform startLine;
        public Transform finishLine;
    }
}
