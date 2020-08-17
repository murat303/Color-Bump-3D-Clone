using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

namespace Utilities.Animation
{
    public class AnimationPlay : MonoBehaviour
    {
        public AnimationBase anim;
        public UnityEvent onComplete;
        Sequence sequence;

        void OnEnable()
        {
            sequence = transform.AnimationPlay(anim, onComplete);
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                sequence.Kill();
                GetComponent<Collider>().isTrigger = false;
                GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }
}

