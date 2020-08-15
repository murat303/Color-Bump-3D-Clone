using UnityEngine;
using UnityEngine.Events;

namespace Utilities.Animation
{
    public class AnimationPlay : MonoBehaviour
    {
        public AnimationBase anim;
        public UnityEvent onComplete;

        void OnEnable()
        {
            transform.AnimationPlay(anim, onComplete);
        }
    }
}

