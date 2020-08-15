using UnityEngine;

namespace ColorBump
{
    public class ObjectMover : MonoBehaviour
    {
        public enum MoveType { Update, FixedUpdate }

        [SerializeField] MoveType moveType;
        [SerializeField] public float speed = 1;
        [SerializeField] public Vector3 direction = new Vector3(0, 0, 1);

        bool started;

        public void Move(float _speed)
        {
            speed = _speed;
            started = true;
        }

        void Update()
        {
            if(moveType == MoveType.Update && started)
                transform.Translate(direction * speed * Time.deltaTime, Space.World);
        }

        void FixedUpdate()
        {
            if (moveType == MoveType.FixedUpdate && started)
                transform.Translate(direction * speed * Time.fixedDeltaTime, Space.World);
        }
    }
}
