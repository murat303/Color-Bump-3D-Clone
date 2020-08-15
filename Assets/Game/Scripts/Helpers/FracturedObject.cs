using UnityEngine;

namespace ColorBump
{
    /// <summary>
    /// Handles adding force to all elements of fractured object
    /// </summary>
    public class FracturedObject : MonoBehaviour
    {
        [SerializeField] Rigidbody[] _fractures = default;
        [SerializeField] float _force = 1.2f;

        public FracturedObject Init(Vector3 dir)
        {
            dir = dir.normalized;
            for (int i = 0; i < _fractures.Length; i++)
            {
                _fractures[i].velocity = dir * _force;
            }

            return this;
        }
    }
}
