using UnityEngine;

namespace ColorBump
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "Obstacle", menuName = "Obstacle/Create")]
    public class GridObstacle : Grid<ObjectType>
    {
        public ObstacleType objectType;
        public ObstacleType obstacleType;
        [SerializeField] CellRowExampleEnum[] cells = new CellRowExampleEnum[Consts.defaultGridSize];

        protected override CellRow<ObjectType> GetCellRow(int idx)
        {
            return cells[idx];
        }
    }

    [System.Serializable]
    public class CellRowExampleEnum : CellRow<ObjectType> { }
}