using DG.Tweening;
using UnityEngine;

namespace ColorBump
{
    public class UIManager : MonoBehaviour
    {
        public Animator animatorFlashFx;
        public GameObject gameOverScreen;
        

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
            if (!gameOver.isWin) gameOverScreen.gameObject.SetActive(true);
        }

        void ShakeCamera()
        {
            Camera.main.transform.DOShakePosition(0.5f, new Vector3(0.5f, 0.5f, 0));
        }

        public void Restart()
        {
            LevelManager.ins.RestartLevel();
        }
    }
}
