using UnityEngine;

namespace ColorBump
{
    public class UIManager : MonoBehaviour
    {
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
            if (!gameOver.isWin) gameOverScreen.Show();
        }
    }
}
