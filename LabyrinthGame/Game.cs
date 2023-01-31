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
                case ConsoleKey.W:
                    if (MyWorld.CanPlayerWalk(CurrentPlayer.X, CurrentPlayer.Y - 1))
                    {
                        CurrentPlayer.Y -= 1;
                    }
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    if (MyWorld.CanPlayerWalk(CurrentPlayer.X, CurrentPlayer.Y + 1))
                    {
                        CurrentPlayer.Y += 1;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    if (MyWorld.CanPlayerWalk(CurrentPlayer.X - 1, CurrentPlayer.Y))
                    {
                        CurrentPlayer.X -= 1;
                    }
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    if (MyWorld.CanPlayerWalk(CurrentPlayer.X + 1, CurrentPlayer.Y))
                    {
                        CurrentPlayer.X += 1;
                    }
                    break;
                case ConsoleKey.Escape:
                    Clear();
                    Mainmenu start = new Mainmenu();
                    start.RunGameMenu();
                    break;
                default:
                    break;
            }
        }
        private void GameLoop()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            while(true)
            {
                DrawFrame();
                PlayerInput();

                string elementAtPlayerPos = MyWorld.GetElementAt(CurrentPlayer.X, CurrentPlayer.Y);
                if (elementAtPlayerPos == "X")
                {
                    Clear();
                    watch.Stop();

                    string Won = "Good Work. You Won.";
                    string time = "Time: "+(watch.ElapsedMilliseconds/1000).ToString()+" sec";
                    string pressEnt = "Press any key to contiune....";
                    WriteLine("\n");
                    SetCursorPosition((WindowWidth - Won.Length) / 2, CursorTop);
                    WriteLine(Won);
                    
                    SetCursorPosition((WindowWidth - time.Length) / 2, CursorTop);
                    WriteLine(time);
                    WriteLine("\n");
                    System.Threading.Thread.Sleep(1000);
                    SetCursorPosition((WindowWidth - pressEnt.Length) / 2, CursorTop);
                    WriteLine(pressEnt);
                    ReadKey(true);
                    Clear();

                    Mainmenu start = new Mainmenu();
                    start.RunGameMenu();
                    break;
                }

                System.Threading.Thread.Sleep(20);
            }
        }
    }
}
