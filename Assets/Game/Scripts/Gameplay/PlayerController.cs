using UnityEngine;

namespace ColorBump
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float forcePower = 100;
        [SerializeField] FracturedObject fracturedPrefab;

        Camera mainCamera;
        Rigidbody myRigidbody;
        float wallDistance;
        float minCamDistance;

        Vector2 lastMousePos; //for finger xy position a frame ago

        void Awake()
        {
            myRigidbody = GetComponent<Rigidbody>();
            mainCamera = Camera.main;

            wallDistance = LevelManager.ins.settings.wallDistance;
            minCamDistance = LevelManager.ins.settings.minCamDistance;
        }

        void Update()
        {
            CalculateForce();
        }

        void LateUpdate()
        {
            CheckLimits(); //First Calculate Force than Check Limits (Late Update)
        }

        /// <summary>
        /// Calculate and Add Force to Object
        /// </summary>
        void CalculateForce()
        {
            Vector2 deltaPos = Vector2.zero; //force Direction

            if (Input.GetMouseButton(0))
            {
                Vector2 currentMousePos = Input.mousePosition;

                if (lastMousePos == Vector2.zero)
                {
                    lastMousePos = currentMousePos;
                    LevelManager.ins.StartLevel();
                }

                deltaPos = currentMousePos - lastMousePos;
                lastMousePos = currentMousePos;

                var force = new Vector3(deltaPos.x, 0, deltaPos.y) * forcePower;
                myRigidbody.AddForce(force);
            }
            else
                lastMousePos = Vector2.zero;
        }

        /// <summary>
        /// Check Move Limits
        /// </summary>
        void CheckLimits()
        {
            var pos = transform.position;

            if (pos.x < -wallDistance)
                pos.x = -wallDistance;
            else if (pos.x > wallDistance)
                pos.x = wallDistance;

            var backLimit = mainCamera.transform.position.z + minCamDistance;
            if (transform.position.z < backLimit)
                pos.z = backLimit;

            transform.position = pos;
        }

        void OnCollisionEnter(Collision collision)
        {
            if (LevelManager.ins.IsGameOver) return;

            if (collision.collider.CompareTag("Obstacle"))
            {
                var fracture = Instantiate(fracturedPrefab, transform.position, Quaternion.identity);
                fracture.Init(myRigidbody.velocity);

                gameObject.SetActive(false);

                Messenger.Send(new PlayerDied());
            }
        }
    }
}
