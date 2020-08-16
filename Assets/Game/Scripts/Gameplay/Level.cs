using TMPro;
using UnityEngine;

namespace ColorBump
{
    public class Level : MonoBehaviour
    {
        [HideInInspector] public int level;

        [Header("Visual")]
        public Color colorPlayer;
        public Color colorGround;
        public Color colorBackground;
        public Color colorObstacles;

        [Header("Settings")]
        public float camSpeed = 1.5f;

        [Header("References")]
        public Transform startLine;
        public Transform finishLine;
        public TextMeshPro txtStage;
    }
}
