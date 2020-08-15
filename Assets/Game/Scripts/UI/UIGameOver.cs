using UnityEngine;
using UnityEngine.SceneManagement;
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

        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
