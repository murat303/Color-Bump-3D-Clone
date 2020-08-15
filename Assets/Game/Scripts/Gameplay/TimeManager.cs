using UnityEngine;

namespace ColorBump
{
    /// <summary>
    /// For Slow Motion Effect
    /// </summary>
    public class TimeManager : MonoBehaviour
    {
        [SerializeField] float slowMotionFactor = 0.1f;
        [SerializeField] float lerpTime = 1;
        private float timeStamp;
        private bool isActive;

        void Start()
        {
            Messenger.Register<GameOver>(OnGameOver);
            Time.timeScale = 1;
            Time.fixedDeltaTime = 0.02f;
        }
        void OnDestroy()
        {
            Messenger.UnRegisterAll(this);
        }

        void OnGameOver(GameOver gameOver)
        {
            if (!gameOver.isWin)
            {
                timeStamp = Time.unscaledTime;
                isActive = true;
            }
        }

        void Update()
        {
            if (isActive)
            {
                // Lerps from normal to slow motion time
                Time.timeScale = Mathf.Lerp(1, slowMotionFactor, (Time.unscaledTime - timeStamp) / lerpTime);
                Time.fixedDeltaTime = 0.02f * Time.timeScale;
            }
        }
    }
}
