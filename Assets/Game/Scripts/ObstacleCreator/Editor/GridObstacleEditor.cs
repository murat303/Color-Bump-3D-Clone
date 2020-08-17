using UnityEditor;
using UnityEngine;

namespace ColorBump
{
    [CustomEditor(typeof(GridObstacle))]
    public class GridObstacleEditor : GridEnumEditor<ObjectType>
    {
        protected override int CellWidth { get { return 28; } }

        protected override int CellHeight { get { return 16; } }
    }
}