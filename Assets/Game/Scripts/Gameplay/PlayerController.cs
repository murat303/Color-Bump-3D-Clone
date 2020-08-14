using UnityEngine;

namespace ColorBump
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float speed;
        [SerializeField] float maxSpeedAtDistance;
        [SerializeField] float planeHeight;

        Vector3 mousePosition;
        Vector3 mouseOffset;
        Vector3 targetPosition;

        Camera mainCamera;
        Rigidbody myRigidbody;
        float wallDistance;
        float minCamDistance;

        void Awake()
        {
            myRigidbody = GetComponent<Rigidbody>();
            mainCamera = Camera.main;

            wallDistance = LevelManager.ins.settings.wallDistance;
            minCamDistance = LevelManager.ins.settings.minCamDistance;
        }

        void Start()
        {
            mousePosition = mainCamera.WorldToScreenPoint(transform.position + Vector3.forward * 0.5f);
            mouseOffset = Vector3.zero;
        }

        void FixedUpdate()
        {
            var forceVector = targetPosition - myRigidbody.position;
            myRigidbody.AddForce(forceVector.normalized * Mathf.Clamp01(forceVector.magnitude / maxSpeedAtDistance) * (speed * 100));
        }

        void Update()
        {
            CheckMousePos();
            CheckLimits();
        }

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

        void CheckMousePos()
        {
            Vector3 newMousePosition = Input.mousePosition;

            if (Input.GetMouseButton(0))
            {
                mousePosition = newMousePosition;
            }

            if (Input.GetMouseButtonDown(0))
            {
                var ballPos = mainCamera.WorldToScreenPoint(transform.position + Vector3.forward * 0.5f);
                mouseOffset = ballPos - Input.mousePosition;
            }

            Ray mouseRay = mainCamera.ScreenPointToRay(mousePosition + mouseOffset);
            float planeHeight = this.planeHeight;
            float dst = (this.planeHeight - mouseRay.origin.y) / mouseRay.direction.y;

            targetPosition = mouseRay.GetPoint(dst);
        }
    }
}
