using System;

namespace BrickBreaker
{
    [Serializable]
    public class Game
    {
        public Level level;
        public int currentLevel;
        public  int Lives { get; set; }
        public static bool Loaded; 
        public Game() { }

        public Game(Level level)
        {
            this.level = level;
        }

        public void StartNewGame(int lv = 0)
        {
            Lives = 3;
            currentLevel = lv;
            level.StartNextLevel(currentLevel);
            level.SetBlocks();
        }
        public void LoadGame()
        {

            level.SetBlocks();
        }

        public bool CheckLevel()
        {
            return level.LevelComplete();
        }

        public bool NextLevel()
        {

            if (level.StartNextLevel(currentLevel))
            {
                level.SetBlocks();
                return true;
            }
            return false;
        }

    }
}
