using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oppgaver
{
    internal class Oppgave315F: IOppgaver
    {
        private readonly int[,] _valuesArray = new int[3, 3];
        private int _count = 0;
        public ConsoleKey KeyPressed = ConsoleKey.None;
        private bool _gameSolved = false;
        public void Run()
        {
            _valuesArray[0, 0] = 0;
            _valuesArray[0, 1] = 1;
            _valuesArray[0, 2] = 3;
            _valuesArray[1, 0] = 4;
            _valuesArray[1, 1] = 2;
            _valuesArray[1, 2] = 5;
            _valuesArray[2, 0] = 7;
            _valuesArray[2, 1] = 8;
            _valuesArray[2, 2] = 6;

            Console.WriteLine("Arrange the numbers from 1-8 and then 0 at the last position. Use arrow keys to move 0 on the board.");

            while (_gameSolved==false)
            {
                if (_count==0)
                {
                    GameConsole();
                }
                KeyDowns();
            }
            
        }

        public void GameConsole()
        {
            var zeroIndex = FindZeroIndex(_valuesArray);

            MoveZero(_valuesArray, zeroIndex.row, zeroIndex.column);
            CreateBoard(_valuesArray);
            Console.WriteLine(string.Empty);
            WinCondition(_valuesArray);

        }

        public void CreateBoard(int[,] array)
        {
            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    System.Console.Write(array[i, j]);
                }

                System.Console.WriteLine();
            }
        }

        public void KeyDowns()
        {
            var keyInfo = Console.ReadKey();
            KeyPressed = keyInfo.Key;
            _count++;
            GameConsole();
        }

        public (int row, int column) FindZeroIndex(int[,] array)
        {
            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    if (array[i, j] == 0)
                    {
                        return (i, j);
                    }
                }
            }
            return (-1, -1);
        }

        public void MoveZero(int[,] array, int row, int column)
        {
            int previousValue;
            int newColumn = PositionChecker(column);
            int newRow = PositionChecker(row);

            if (KeyPressed == ConsoleKey.RightArrow)
            {
                previousValue = array[row, newColumn+1];
                array[row, column] = previousValue;
                array[row, newColumn+1] = 0;

            } else if (KeyPressed == ConsoleKey.LeftArrow)
            {
                previousValue = array[row, newColumn - 1];
                array[row, column] = previousValue;
                array[row, newColumn - 1] = 0;

            } else if (KeyPressed == ConsoleKey.DownArrow)
            {
                previousValue = array[newRow +1, column];
                array[row, column] = previousValue;
                array[newRow +1, column] = 0;

            } else if (KeyPressed == ConsoleKey.UpArrow)
            {
                previousValue = array[newRow - 1, column];
                array[row, column] = previousValue;
                array[newRow - 1, column] = 0;
            }
        }

        public void WinCondition(int[,] array)
        {
            var answerArray = new int[3,3]
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 0 }
            };

            var answerArrayStr = ArrayToString(answerArray);
            var solutionArrayStr = ArrayToString(array);

            if (solutionArrayStr != answerArrayStr) return;
            _gameSolved = true;
            Console.WriteLine("You win!");
            Console.WriteLine($"You solved the puzzle in {_count} moves");
        }

        public string ArrayToString(int[,] array)
        {
            var arrayString = string.Empty;

            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    arrayString += array[i,j].ToString();
                }
            }
            return arrayString;
        }

        public int PositionChecker(int rowOrColumn)
        {
            var position = rowOrColumn;
            if (rowOrColumn == 0 && KeyPressed == ConsoleKey.LeftArrow) position = 1;
            if (rowOrColumn == 2 && KeyPressed == ConsoleKey.RightArrow) position = 1;
            if (rowOrColumn == 0 && KeyPressed == ConsoleKey.UpArrow) position = 1;
            if (rowOrColumn == 2 && KeyPressed == ConsoleKey.DownArrow) position = 1;


            return position;
        }
    }
}
