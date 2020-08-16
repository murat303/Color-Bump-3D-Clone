using UnityEditor;
using System.Linq;

namespace ColorBump
{
    public class GridEnumEditor<T> : GridEditor
    {
        protected override int CellWidth { get { return 70; } }
        protected override int CellHeight { get { return 16; } }

        protected override void SetValue(SerializedProperty cell, int i, int j)
        {
            T[,] previousCells = (target as Grid<T>).GetCells();
            int width = previousCells.GetLength(1);

            cell.enumValueIndex = 0;

            if (i < gridSize.vector2IntValue.y && j < gridSize.vector2IntValue.x)
            {
                cell.enumValueIndex = previousCells.Cast<int>().ToArray()[i * width + j];
            }
        }
    }
}