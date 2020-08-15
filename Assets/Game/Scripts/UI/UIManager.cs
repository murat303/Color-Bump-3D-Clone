using DG.Tweening;
using UnityEngine;

namespace ColorBump
{
    public class UIManager : MonoBehaviour
    {
        public Animator animatorFlashFx;
        public UIGameOver gameOverScreen;
        

        void Start()
        {
            Messenger.Register<GameOver>(OnGameOver);
        }
        void OnDestroy()
        {
            Messenger.UnRegisterAll(this);
        }

        void OnGameOver(GameOver gameOver)
        {
            ShakeCamera();
            animatorFlashFx.SetTrigger("Flash");
            if (!gameOver.isWin) gameOverScreen.Show();
        }

        void ShakeCamera()
        {
            Camera.main.transform.DOShakePosition(0.5f, new Vector3(0.5f, 0.5f, 0));
        }
    }
}
