using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TronGame
{
    class TronGame
    {
        static int right = 0;
        static int left = 1;
        static int up = 2;
        static int down = 3;

        static int firstPlayerScore = 0;
        static int firstPlayerDirection = right;
        static int firstPlayerColumn = 0; //col
        static int firstPlayerRow = 0; //row

        static int secondPlayerScore = 0;
        static int secondPlayerDirection = left;
        static int secondPlayerColumn = 40;
        static int secondPlayerRow = 5;

        static bool[,] isUsed;

        static void Main(string[] args)
        {
            SetGameField();
            isUsed = new bool[Console.WindowWidth, Console.WindowHeight];

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    ChangePlayerDirection(key);
                }
                MovePlayers();

                bool firstPlayerLooses = DoesPlayerLoose(firstPlayerRow, firstPlayerColumn);
                bool secondPlayerLooses = DoesPlayerLoose(secondPlayerRow, secondPlayerColumn);

                if (firstPlayerLooses && secondPlayerLooses)
                {
                    firstPlayerScore++;
                    secondPlayerScore++;
                    Console.WriteLine();
                    Console.WriteLine("Game Over");
                    Console.WriteLine("Draw game!!!");
                    Console.WriteLine("Current score: {0} - {1}", firstPlayerScore, secondPlayerScore);
                    ResetGame();
                }
                if (firstPlayerLooses)
                {
                    secondPlayerScore++;
                    Console.WriteLine();
                    Console.WriteLine("Game Over");
                    Console.WriteLine("Second Player wins!!!");
                    Console.WriteLine("Current score: {0} - {1}", firstPlayerScore, secondPlayerScore);
                    ResetGame();
                }
                if (secondPlayerLooses)
                {
                    firstPlayerScore++;
                    Console.WriteLine();
                    Console.WriteLine("Game Over");
                    Console.WriteLine("First Player wins!!!");
                    Console.WriteLine("Current score: {0} - {1}", firstPlayerScore, secondPlayerScore);
                    ResetGame();
                }


                isUsed[firstPlayerColumn, firstPlayerRow] = true;
                isUsed[secondPlayerColumn, secondPlayerRow] = true;

                WriteOnPosition(firstPlayerColumn, firstPlayerRow, '*', ConsoleColor.Cyan);
                WriteOnPosition(secondPlayerColumn, secondPlayerRow, '*', ConsoleColor.DarkRed);
                Thread.Sleep(100);

            }
        }
        static void ResetGame()
        {
            isUsed = new bool[Console.WindowWidth, Console.WindowHeight];
            SetGameField();
            firstPlayerDirection = right;
            secondPlayerDirection = left;

            Console.WriteLine("Press any key to start again...");
            Console.ReadKey();
            Console.Clear();
            MovePlayers();
        }

        static bool DoesPlayerLoose(int row, int col)
        {
            if (row < 0)
            {
                return true;
            }
            if (col < 0)
            {
                return true;
            }
            if (row >= Console.WindowHeight)
            {
                return true;
            }
            if (col >= Console.WindowWidth)
            {
                return true;
            }

            if (isUsed[col, row])
            {
                return true;
            }

            return false;
        }


        static void SetGameField()
        {
            Console.WindowHeight = 30;
            Console.BufferHeight = 30;

            Console.WindowWidth = 100;
            Console.BufferWidth = 100;

            firstPlayerColumn = 0;
            firstPlayerRow = Console.WindowHeight / 2;

            secondPlayerColumn = Console.WindowWidth - 1;
            secondPlayerRow = Console.WindowHeight / 2;
        }

        static void MovePlayers()
        {
            if (firstPlayerDirection == right)
            {
                firstPlayerColumn = firstPlayerColumn + 1;
            }
            if (firstPlayerDirection == left)
            {
                firstPlayerColumn = firstPlayerColumn - 1;
            }
            if (firstPlayerDirection == up)
            {
                firstPlayerRow--;
            }
            if (firstPlayerDirection == down)
            {
                firstPlayerRow++;
            }


            if (secondPlayerDirection == right)
            {
                secondPlayerColumn = secondPlayerColumn + 1;
            }
            if (secondPlayerDirection == left)
            {
                secondPlayerColumn = secondPlayerColumn - 1;
            }
            if (secondPlayerDirection == up)
            {
                secondPlayerRow--;
            }
            if (secondPlayerDirection == down)
            {
                secondPlayerRow++;
            }

        }

        static void WriteOnPosition(int x, int y, char ch, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(x, y);
            Console.Write(ch);
        }

        static void ChangePlayerDirection(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.W)
            {
                firstPlayerDirection = up;
            }
            if (key.Key == ConsoleKey.A)
            {
                firstPlayerDirection = left;
            }
            if (key.Key == ConsoleKey.D)
            {
                firstPlayerDirection = right;
            }
            if (key.Key == ConsoleKey.S)
            {
                firstPlayerDirection = down;
            }

            if (key.Key == ConsoleKey.UpArrow)
            {
                secondPlayerDirection = up;
            }
            if (key.Key == ConsoleKey.LeftArrow)
            {
                secondPlayerDirection = left;
            }
            if (key.Key == ConsoleKey.RightArrow)
            {
                secondPlayerDirection = right;
            }
            if (key.Key == ConsoleKey.DownArrow)
            {
                secondPlayerDirection = down;
            }
        }
    }
}
