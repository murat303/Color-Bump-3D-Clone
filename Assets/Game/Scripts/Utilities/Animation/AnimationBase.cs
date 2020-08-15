using DG.Tweening;
using System;
using UnityEngine;
using Utilities.Attributes;

namespace Utilities.Animation
{
    public enum AnimationType
    {
        Fade = 0, Scale = 1, Move = 2, Rotate = 3
    }
    public enum AnimationEaseType
    {
        Ease = 0, AnimationCurve = 1
    }

    [CreateAssetMenu(fileName = "Animation", menuName = "Scriptables/Animation", order = 1)]
    public class AnimationBase : ScriptableObject
    {
        public float delay = 0;

        public bool loop;
        [DrawIf("loop", true)]
        public LoopType loopType;
        [DrawIf("loop", true)]
        public int loopCount = -1;

        public Animation[] animations;

        [Serializable]
        public class Animation
        {
            public AnimationType animationType;
            public AnimationEaseType animationEaseType;

            [DrawIf("animationEaseType", AnimationEaseType.Ease)]
            public Ease ease = Ease.OutQuad;
            [DrawIf("animationEaseType", AnimationEaseType.Ease, DrawIfAttribute.Type.DontDraw)]
            public AnimationCurve curve;

            public bool relative = false; //the endValue will be calculated as startValue + endValue instead of being used directly
            public bool join = true; //inserts the given tween at the same time position of the last tween
            public float duration = 1;
            public float delay = 0;

            [DrawIf("animationType", AnimationType.Rotate)]
            public RotateMode rotateMode;

            [DrawIf("animationType", AnimationType.Rotate)]
            public bool rotateLocal;

            [DrawIf("animationType", AnimationType.Move)]
            public bool moveLocal;

            public bool enableFrom;

            [DrawIf("animationType", AnimationType.Fade, DrawIfAttribute.Type.DontDraw)]
            public Vector3 from;

            [DrawIf("animationType", AnimationType.Fade, DrawIfAttribute.Type.DontDraw)]
            public Vector3 to;

            [DrawIf("animationType", AnimationType.Fade)]
            public float fadeFrom;

            [DrawIf("animationType", AnimationType.Fade)]
            public float fadeTo;
        }
    }
}