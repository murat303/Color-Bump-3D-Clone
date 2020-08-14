using UnityEngine;

namespace ColorBump
{
    [CreateAssetMenu(fileName = "Level", menuName = "Scriptables/LevelSettings", order = 2)]
    public class LevelSettings : ScriptableObject
    {
        [Header("Visual")]
        public Color ballColor;
        public Color groundColor;
        public Color backgroundColor;
    }
}
