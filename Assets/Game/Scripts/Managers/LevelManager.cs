namespace ColorBump
{
    public class LevelManager : Singleton<LevelManager>
    {
        public GameSettings settings;
        public LevelSettings[] levels;

        int CurrentLevel = 1;

        public LevelSettings GetLevel()
        {
            return levels[CurrentLevel - 1];
        }
    }
}
