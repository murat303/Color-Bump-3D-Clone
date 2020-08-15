using UnityEngine;
using UnityEngine.SceneManagement;

namespace ColorBump
{
    public class LevelManager : Singleton<LevelManager>
    {
        //Level parca parca yuklenebilir, arkamizda kalanlar temizlenebilir (Kameranın arkasina object disabler)

        public GameSettings settings;

        public bool IsGameOver { get; private set; }
        public bool IsGameStarted { get; private set; }

        Level[] levels;
        Level currentLevel;
        ObjectMover cameraMover;

        void Awake()
        {
            levels = GetComponentsInChildren<Level>();
            cameraMover = Camera.main.GetComponent<ObjectMover>();

            GetLevel();
            SetLevelSettings();

            Messenger.UnRegisterAll(this);
            Messenger.Register<GameOver>(OnGameOver);
        }

        void OnDestroy()
        {
            Messenger.UnRegisterAll(this);
        }

        void SetLevelSettings()
        {
            //Level Settings
            cameraMover.speed = currentLevel.camSpeed;
            Camera.main.backgroundColor = currentLevel.colorBackground;
            settings.materialPlayer.color = currentLevel.colorPlayer;
            settings.materialGround.color = currentLevel.colorGround;
        }

        public void StartLevel()
        {
            cameraMover.Move(currentLevel.camSpeed);
            IsGameStarted = true;
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
            int level = PlayerPrefs.GetInt("CurrentLevel", 0);
            currentLevel = levels[level];
            return currentLevel;
        }
    }
}
