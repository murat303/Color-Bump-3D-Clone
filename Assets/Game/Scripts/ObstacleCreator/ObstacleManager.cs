using UnityEngine;

namespace ColorBump
{
    public class ObstacleManager : Singleton<ObstacleManager>
    {
        public Obstacle[] obstacles;
    }

    [System.Serializable]
    public class Obstacle
    {
        public ObstacleType type;
        public GameObject prefab;
    }
}

