using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utilities.Animation;

namespace ColorBump
{
    public class LevelManager : Singleton<LevelManager>
    {
        //Level parca parca yuklenebilir, arkamizda kalanlar temizlenebilir (Kameranın arkasina object disabler)

        public GameSettings settings;
        Level[] levels;

        int CurrentLevel = 1;
        public bool IsGameOver { get; set; }
        public bool IsGameStarted { get; set; }

        void Awake()
        {
            levels = GetComponentsInChildren<Level>();
        }

        public void StartLevel()
        {
            IsGameStarted = true;
            var anim = GetLevel().cameraAnimation;
            Camera.main.transform.AnimationPlay(anim);

            Messenger.Register<GameOver>(OnGameOver);
        }
        void OnDestroy()
        {
            Messenger.UnRegisterAll(this);
        }

        public void RestartLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        void OnGameOver(GameOver gameOver)
        {
            IsGameOver = true;

            if (gameOver.isWin)
            {
                Invoke("RestartLevel", 2);
                Debug.Log("Level Complete!");
            }
            else
                Debug.Log("Player Died!!!");
        }

        public Level GetLevel()
        {
            return levels[CurrentLevel - 1];
        }
    }
}
