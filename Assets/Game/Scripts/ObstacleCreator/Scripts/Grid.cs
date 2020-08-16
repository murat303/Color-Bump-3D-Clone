using UnityEngine;

namespace ColorBump
{
    public abstract class Grid<T> : ScriptableObject
    {

        [SerializeField]
        protected Vector2Int gridSize = Vector2Int.one * Consts.defaultGridSize;


        public Vector2Int GridSize { get { return gridSize; } }


        protected abstract CellRow<T> GetCellRow(int idx);


        public T[,] GetCells()
        {
            T[,] ret = new T[gridSize.y, gridSize.x];

            for (int i = 0; i < gridSize.y; i++)
            {
                for (int j = 0; j < gridSize.x; j++)
                {
                    ret[i, j] = GetCellRow(i)[j];
                }
            }

            return ret;
        }
    }

    [System.Serializable]
    public class CellRow<T>
    {
        [SerializeField]
        private T[] row = new T[Consts.defaultGridSize];


        public T this[int i]
        {
            get { return row[i]; }
        }
    }
}