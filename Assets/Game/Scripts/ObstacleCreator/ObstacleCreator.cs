using System.Linq;
using UnityEngine;
using Utilities.Animation;
using Utilities.Attributes;

namespace ColorBump
{
    public class ObstacleCreator : MonoBehaviour
    {
        [SerializeField] GridObstacle gridObstacle;

        [SerializeField] ObstacleType objectType;
        [SerializeField] ObstacleType obstacleType;
        [SerializeField] AnimationBase objectAnimation;
        [SerializeField] AnimationBase obstacleAnimation;

        [SerializeField] float intervalX = 1;
        [SerializeField] float intervalY = 1;

        void Create()
        {
            ClearChildrens();

            var cells = gridObstacle.GetCells();
            var prefabObject = ObstacleManager.ins.obstacles.Where(x => x.type == objectType).First().prefab;
            var prefabObstacle = ObstacleManager.ins.obstacles.Where(x => x.type == obstacleType).First().prefab;

            int half = gridObstacle.GridSize.x / 2;
            //int middle = gridObstacle.GridSize.x % 2;
            
            for (int y = 0; y < gridObstacle.GridSize.y; y++)
            {
                int xCount = 1;
                float _intervalX;

                for (int x = 0; x < gridObstacle.GridSize.x; x++)
                {
                    if (xCount <= half)
                        _intervalX = intervalX * (half - x) * -1;
                    else
                        _intervalX = intervalX * (x - half);

                    xCount++;

                    if (cells[y, x] == ObjectType.Obstacle)
                    {
                        GameObject obstacle = Instantiate(prefabObstacle, transform);
                        obstacle.transform.localPosition = new Vector3(_intervalX, 0, y * -intervalY);
                        obstacle.transform.GetChild(0).tag = "Obstacle";
                        obstacle.transform.GetChild(0).GetComponent<MeshRenderer>().material = LevelManager.ins.settings.materialObstacle;
                        obstacle.name = "(" + y + ", " + x + ")";

                        if (obstacleAnimation!=null)
                        {
                            obstacle.transform.GetChild(0).gameObject.AddComponent<AnimationPlay>().anim = obstacleAnimation;
                            obstacle.transform.GetChild(0).gameObject.GetComponent<Rigidbody>().isKinematic = true;
                            obstacle.transform.GetChild(0).gameObject.GetComponent<Collider>().isTrigger = true;
                        }
                    }
                    else if (cells[y, x] == ObjectType.Normal)
                    {
                        GameObject obstacle = Instantiate(prefabObject, transform);
                        obstacle.transform.localPosition = new Vector3(_intervalX, 0, y * -intervalY);
                        obstacle.name = "(" + y + ", " + x + ")";

                        if (objectAnimation != null)
                        {
                            obstacle.transform.GetChild(0).gameObject.AddComponent<AnimationPlay>().anim = objectAnimation;
                            obstacle.transform.GetChild(0).gameObject.GetComponent<Rigidbody>().isKinematic = true;
                            obstacle.transform.GetChild(0).gameObject.GetComponent<Collider>().isTrigger = true;
                        }
                    }
                }
            }
        }

        [Button("Clear Obstacles")]
        void ClearChildrens()
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
        }

        [Button("Create Obstacles")]
        void CreateObstacles()
        {
            Create();
        }
    }
}