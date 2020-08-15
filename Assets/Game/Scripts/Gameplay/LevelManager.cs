using UnityEngine;
using Utilities.Animation;

namespace ColorBump
{
    public class LevelManager : Singleton<LevelManager>
    {
        public GameSettings settings;
        public LevelSettings[] levels;

        int CurrentLevel = 1;

        public void StartLevel()
        {
            var anim = GetLevel().cameraAnimation;
            Camera.main.transform.AnimationPlay(anim);
        }

        public LevelSettings GetLevel()
        {
            return levels[CurrentLevel - 1];
        }
    }
}
