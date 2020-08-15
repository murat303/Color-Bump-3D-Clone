using UnityEngine;

namespace ColorBump
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Scriptables/GameSettings", order = 1)]
    public class GameSettings : ScriptableObject
    {
        [Header("Game")]
        public float wallDistance;
        public float minCamDistance;

        [Header("Materials")]
        public Material materialPlayer;
        public Material materialGround;

        [Header("Debug")]
        public bool showLogs;
        public bool showDistanceLog;
    }
}
