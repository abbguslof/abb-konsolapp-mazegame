using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace LabyrinthGame
{
    class Menu
    {
        private int IndexSelected;
        private string[] Options;
        private string Prompt;

        public Menu(string prompt, string[] options)
        {
            Prompt = prompt;
            Options = options;
            IndexSelected = 0;
        }

        private void DisplayMenu()
        {
            WriteLine(String.Format("{0," + WindowWidth / 2 + "}", Prompt));
            for (int i = 0; i < Options.Length; i++)
            {
                string currentOption = Options[i];
                string prefix;
                string suffix;
                if (i == IndexSelected)
                {
                    prefix = " ";
                    suffix = " ";
                    ForegroundColor = ConsoleColor.Black;
                    BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    prefix = " ";
                    suffix = " ";
                    ForegroundColor = ConsoleColor.White;
                    BackgroundColor = ConsoleColor.Black;
                }
                string currentoption = $"{prefix}<< {currentOption} >>{suffix}";
                SetCursorPosition((WindowWidth - currentoption.Length) / 2, CursorTop);
                WriteLine(currentoption);
            }
            ResetColor();
        }

        public int Runmenu()
        {
            ConsoleKey keyPressed;
            do
            {
                Clear();
                DisplayMenu();

                ConsoleKeyInfo keyInfo = ReadKey(true);
                keyPressed = keyInfo.Key;

                if(keyPressed == ConsoleKey.UpArrow)
                {
                    IndexSelected--;
                    if (IndexSelected == -1)
                    {
                        IndexSelected = Options.Length - 1;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    IndexSelected++;
                    if (IndexSelected == Options.Length)
                    {
                        IndexSelected = 0;
                    }
                }
            } while (keyPressed != ConsoleKey.Enter);

            return IndexSelected;
        }
    }
}
