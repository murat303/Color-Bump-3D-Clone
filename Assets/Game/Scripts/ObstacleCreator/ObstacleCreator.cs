using System.Linq;
using UnityEngine;
using Utilities.Attributes;

namespace ColorBump
{
    public class ObstacleCreator : MonoBehaviour
    {
        [SerializeField] GridObstacle gridObstacle;
        [SerializeField] float intervalX = 1;
        [SerializeField] float intervalY = 1;

        void Create()
        {
            var tempArray = new GameObject[transform.childCount];
            for (int i = 0; i < tempArray.Length; i++)
            {
                tempArray[i] = transform.GetChild(i).gameObject;
            }
            foreach (var child in tempArray)
            {
                DestroyImmediate(child);
            }

            var cells = gridObstacle.GetCells();
            var prefabObject = ObstacleManager.ins.obstacles.Where(x => x.type == gridObstacle.objectType).First().prefab;
            var prefabObstacle = ObstacleManager.ins.obstacles.Where(x => x.type == gridObstacle.obstacleType).First().prefab;

            for (int i = 0; i < gridObstacle.GridSize.y; i++)
            {
                for (int j = 0; j < gridObstacle.GridSize.x; j++)
                {
                    if (cells[i, j] == ObjectType.Obstacle)
                    {
                        GameObject obstacle = Instantiate(prefabObstacle, transform);
                        obstacle.transform.localPosition = new Vector3(i * intervalX, 0, j * intervalY);
                        obstacle.tag = "Obstacle";
                        obstacle.GetComponent<MeshRenderer>().material = LevelManager.ins.settings.materialObstacle;
                        obstacle.name = "(" + i + ", " + j + ")";
                    }
                    else if (cells[i, j] == ObjectType.Object)
                    {
                        GameObject obstacle = Instantiate(prefabObject, transform);
                        obstacle.transform.localPosition = new Vector3(i * intervalX, 0, j * intervalY);
                        obstacle.name = "(" + i + ", " + j + ")";
                    }
                }
            }
        }

        [Button("Create Obstacles")]
        void CreateObstacles()
        {
            Create();
        }
    }
}