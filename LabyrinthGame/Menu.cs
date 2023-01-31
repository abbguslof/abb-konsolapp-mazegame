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

        public void clearLines(int lines)
        {
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth)); 
            Console.SetCursorPosition(0, Console.CursorTop - lines);
        }

        private void DisplayMenu()
        {
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
            WriteLine(Prompt);
            WriteLine('\n');
            ConsoleKey keyPressed;
            do
            {
                DisplayMenu();

                ConsoleKeyInfo keyInfo = ReadKey(true);
                keyPressed = keyInfo.Key;

                if(keyPressed == ConsoleKey.UpArrow || keyPressed == ConsoleKey.W)
                {
                    clearLines(Options.Length+1);
                    IndexSelected--;
                    if (IndexSelected == -1)
                    {
                        IndexSelected = Options.Length - 1;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow || keyPressed == ConsoleKey.S)
                {
                    clearLines(Options.Length+1);
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
