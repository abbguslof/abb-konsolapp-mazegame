using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace LabyrinthGame
{
    class Mainmenu
    {
        private string prompt = @"
          _____   _                _               _                      _           _     _     
         |_   _| | |__     ___    | |       __ _  | |__    _   _   _ __  (_)  _ __   | |_  | |__  
           | |   | '_ \   / _ \   | |      / _` | | '_ \  | | | | | '__| | | | '_ \  | __| | '_ \ 
           | |   | | | | |  __/   | |___  | (_| | | |_) | | |_| | | |    | | | | | | | |_  | | | |
           |_|   |_| |_|  \___|   |_____|  \__,_| |_.__/   \__, | |_|    |_| |_| |_|  \__| |_| |_|
                                                           |___/                                  
                                        ";

        public void RunGameMenu()
        {
            Title = "The Labyrinth";
            CursorVisible = false;
            string[] options = { "Play", "Exit" };
            Menu mainmenu = new Menu(prompt, options);
            int IndexSelected = mainmenu.Runmenu();
            switch (IndexSelected)
            {
                case 0:
                    SelectDifficulty();
                    break;
                case 1:
                    ExitGame();
                    break;
            }
        }
        private void SelectDifficulty()
        {
            string[] difoptions = { "Easy", "Medium", "Hard", "Expert", "Back" };
            Menu difficultuMenu = new Menu(prompt, difoptions);
            int IndexSelected = difficultuMenu.Runmenu();
            Game currentGame = new Game();

            switch (IndexSelected)
            {
                case 0:
                    Clear();
                    currentGame.Start("EasyMaze.txt");
                    break;
                case 1:
                    Clear();
                    currentGame.Start("MediumMaze.txt");
                    break;
                case 2:
                    Clear();
                    currentGame.Start("HardMaze.txt");
                    break;
                case 3:
                    Clear();
                    currentGame.Start("ExtremeMaze.txt");
                    break;
                case 4:
                    RunGameMenu();
                    break;
            }
        }
        private void ExitGame()
        {
            string bye = "Goodbye.";
            SetCursorPosition((WindowWidth - bye.Length) / 2, CursorTop);
            WriteLine(bye);
            System.Threading.Thread.Sleep(350);
            Environment.Exit(0);
        }
    }
}
