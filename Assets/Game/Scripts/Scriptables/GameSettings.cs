using UnityEngine;

namespace ColorBump
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Scriptables/GameSettings", order = 1)]
    public class GameSettings : ScriptableObject
    {
        [Header("Game")]
        public float wallDistance;
        public float minCamDistance;
    }
}
