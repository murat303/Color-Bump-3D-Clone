using UnityEngine;

namespace ColorBump
{
    public class ObjectDisabler : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            other.gameObject.SetActive(false);
        }
    }
}
