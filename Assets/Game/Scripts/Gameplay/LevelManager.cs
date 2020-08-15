﻿using UnityEngine;
using Utilities.Animation;

namespace ColorBump
{
    public class LevelManager : Singleton<LevelManager>
    {
        //Level parca parca yuklenebilir, arkamizda kalanlar temizlenebilir (Kameranın arkasina object disabler)

        public GameSettings settings;
        public LevelSettings[] levels;

        int CurrentLevel = 1;
        public bool IsGameOver { get; set; }

        public void StartLevel()
        {
            var anim = GetLevel().cameraAnimation;
            Camera.main.transform.AnimationPlay(anim);

            Messenger.UnRegisterAll(this);
            Messenger.Register<PlayerDied>(OnPlayerDied);
        }

        void OnPlayerDied(PlayerDied e)
        {
            IsGameOver = true;
            Debug.Log("Player Died!!!");
        }

        public LevelSettings GetLevel()
        {
            return levels[CurrentLevel - 1];
        }
    }
}
