using UnityEngine;
using Utilities.Animation;

namespace ColorBump
{
    public class UIGameOver : MonoBehaviour
    {
        public AnimationBase enableAnimation;

        void OnEnable()
        {
            transform.AnimationPlay(enableAnimation);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Restart()
        {
            LevelManager.ins.RestartLevel();
        }
    }
}
