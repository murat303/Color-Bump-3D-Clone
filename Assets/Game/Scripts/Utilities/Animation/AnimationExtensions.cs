using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

namespace Utilities.Animation
{
    public static class AnimationExtensions
    {
        public static Sequence AnimationPlay(this Transform transform, AnimationBase animation, UnityEvent onComplete = null)
        {
            Sequence sequence = DOTween.Sequence();
            foreach (var anim in animation.animations)
            {
                var tween = HandleTween(transform, anim);

                if (anim.join) sequence.Join(tween);
                else sequence.Append(tween);
            }

            if (animation.delay > 0)
                sequence.SetDelay(animation.delay);

            if (animation.loop)
                sequence.SetLoops(animation.loopCount, animation.loopType);

            sequence.OnComplete(() => { onComplete?.Invoke(); });
            sequence.Play();
            return sequence;
        }
        public static void AnimationStop(Sequence sequence)
        {
            sequence.Kill();
        }

        static Tween HandleTween(Transform transform, AnimationBase.Animation animation)
        {
            Tween tween = null;
            switch (animation.animationType)
            {
                case AnimationType.Fade:
                    tween = Fade(transform, animation);
                    break;
                case AnimationType.Move:
                    tween = Move(transform, animation);
                    break;
                case AnimationType.Scale:
                    tween = Scale(transform, animation);
                    break;
                case AnimationType.Rotate:
                    tween = Rotate(transform, animation);
                    break;
            }

            if (animation.delay > 0)
                tween.SetDelay(animation.delay);

            if(animation.animationEaseType == AnimationEaseType.Ease)
                tween.SetEase(animation.ease);
            else if (animation.animationEaseType == AnimationEaseType.AnimationCurve)
                tween.SetEase(animation.curve);

            return tween;
        }

        static Tween Fade(Transform transform, AnimationBase.Animation animation)
        {
            var renderer = transform.gameObject.GetComponent<MeshRenderer>();
            if (renderer != null)
            {
                return renderer.material.DOFade(animation.fadeTo, animation.duration);
            }
            else //UI
            {
                if (transform.gameObject.GetComponent<CanvasGroup>() == null)
                    transform.gameObject.AddComponent<CanvasGroup>();

                if (animation.enableFrom)
                    transform.gameObject.GetComponent<CanvasGroup>().alpha = animation.fadeFrom;

                return transform.gameObject.GetComponent<CanvasGroup>().DOFade(animation.fadeTo, animation.duration);
            }
        }

        static Tween Move(Transform transform, AnimationBase.Animation animation)
        {
            Tween tween = null;

            if (animation.enableFrom)
            {
                transform.position = animation.from;
                if (animation.relative)
                    transform.position += animation.from;
            }

            if (animation.moveLocal)
                tween = transform.DOLocalMove(animation.to, animation.duration).SetRelative(true);
            else
                tween = transform.DOMove(animation.to, animation.duration);

            if (animation.relative) tween.SetRelative(true);
            return tween;
        }

        static Tween Scale(Transform transform, AnimationBase.Animation animation)
        {
            if (animation.enableFrom) transform.localScale = animation.from;

            Tween tween = transform.DOScale(animation.to, animation.duration);
            if (animation.relative) tween.SetRelative(true);
            return tween;
        }

        static Tween Rotate(Transform transform, AnimationBase.Animation animation)
        {
            if (animation.enableFrom) transform.eulerAngles = animation.from;

            Tween tween = null;
            if (animation.rotateLocal)
                tween = transform.DOLocalRotate(animation.to, animation.duration, animation.rotateMode);
            else
                tween = transform.DORotate(animation.to, animation.duration, animation.rotateMode);

            if (animation.relative) tween.SetRelative(true);
            return tween;
        }
    }

}