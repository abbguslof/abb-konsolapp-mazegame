using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace LabyrinthGame
{
    class World
    {
        private string[,] Grid;
        private int Rows;
        private int Cols;

        public World(string[,] grid)
        {
            Grid = grid;
            Rows = Grid.GetLength(0);
            Cols = Grid.GetLength(1);
        }
        public void Draw()
        {
            for (int y = 0; y < Rows; y++)
            {
                for (int x = 0; x < Cols; x++)
                {
                    string element = Grid[y ,x];
                    SetCursorPosition(x, y);

                    if (element == "X")
                    {
                        ForegroundColor = ConsoleColor.Blue;
                    }
                    else
                    {
                        ForegroundColor = ConsoleColor.White;
                    }
                    Write(element);
                }
            }
        }
        public void DrawAroundPlayer(int a, int b)
        {
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {   
                    if (a > 0 && b > 0)
                    {
                        string element = Grid[b-1+y, a-1+x];
                        SetCursorPosition(a-1+x, b-1+y);
                        if (element == "X")
                        {
                            ForegroundColor = ConsoleColor.Blue;
                        }
                        else
                        {
                            ForegroundColor = ConsoleColor.White;
                        }
                        Write(element);
                    }
                }
            }
        }
        public string GetElementAt(int x, int y)
        {
            return Grid[y, x];
        }
        public bool CanPlayerWalk(int x, int y)
        {
            if (x < 0 || y < 0 || x >= Cols || y >= Rows)
            {
                return false;
            }

            return Grid[y, x] == " " || Grid[y, x] == "X";
        }
    }
}
