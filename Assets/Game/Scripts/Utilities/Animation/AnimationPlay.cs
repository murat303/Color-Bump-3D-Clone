using UnityEngine;
using UnityEngine.Events;

namespace Utilities.Animation
{
    public class AnimationPlay : MonoBehaviour
    {
        public AnimationBase anim;
        public UnityEvent onComplete;

        void Start()
        {
            transform.AnimationPlay(anim, onComplete);
        }
    }
}

