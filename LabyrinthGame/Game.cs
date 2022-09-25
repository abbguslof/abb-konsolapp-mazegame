using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace LabyrinthGame
{
    class Game
    {
        private World MyWorld;
        private Player CurrentPlayer;
        public void Start(string filepath)
        {
            string[,] grid = LevelParser.ParseFileArray(filepath);
           
            MyWorld = new World(grid);
            MyWorld.Draw();

            CurrentPlayer = new Player(1, 1);

            GameLoop();
        }
        private void DrawFrame()
        {
            MyWorld.DrawAroundPlayer(CurrentPlayer.X, CurrentPlayer.Y);
            CurrentPlayer.DrawPlayer();
        }
        private void PlayerInput()
        {
            ConsoleKey key;
            do
            {
                ConsoleKeyInfo Keyinfo = ReadKey(true);
                key = Keyinfo.Key;
            } while (KeyAvailable);

            switch(key)
            {
                case ConsoleKey.UpArrow:
                    if (MyWorld.CanPlayerWalk(CurrentPlayer.X, CurrentPlayer.Y - 1))
                    {
                        CurrentPlayer.Y -= 1;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (MyWorld.CanPlayerWalk(CurrentPlayer.X, CurrentPlayer.Y + 1))
                    {
                        CurrentPlayer.Y += 1;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (MyWorld.CanPlayerWalk(CurrentPlayer.X - 1, CurrentPlayer.Y))
                    {
                        CurrentPlayer.X -= 1;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (MyWorld.CanPlayerWalk(CurrentPlayer.X + 1, CurrentPlayer.Y))
                    {
                        CurrentPlayer.X += 1;
                    }
                    break;
                case ConsoleKey.Escape:
                    Mainmenu start = new Mainmenu();
                    start.RunGameMenu();
                    break;
                default:
                    break;
            }
        }
        private void GameLoop()
        {
            while(true)
            {
                DrawFrame();

                PlayerInput();

                string elementAtPlayerPos = MyWorld.GetElementAt(CurrentPlayer.X, CurrentPlayer.Y);
                if (elementAtPlayerPos == "X")
                {
                    break;
                }

                System.Threading.Thread.Sleep(20);
            }
        }
    }
}
