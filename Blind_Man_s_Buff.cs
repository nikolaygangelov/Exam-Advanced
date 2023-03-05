using System;
using System.Linq;

namespace SecondProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowAndCols = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int lengthOfRows = rowAndCols[0];
            int lengthOfCols = rowAndCols[1];

            char[,] matrix = new char[lengthOfRows, lengthOfCols];

            int rowNumber = 0;
            int colNumber = 0;

            for (int row = 0; row < lengthOfRows; row++)
            {
                char[] inputOfMatrix = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                for (int col = 0; col < lengthOfCols; col++)
                {
                    matrix[row, col] = inputOfMatrix[col];
                    char currentLetter = inputOfMatrix[col];
                    if (currentLetter == 'B')
                    {
                        rowNumber = row;
                        colNumber = col;
                        matrix[rowNumber, colNumber] = '-';
                    }
                }
            }


            int countOfTouches = 0;
            int countOfMoves = 0;

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Finish" && countOfTouches < 3)
            {
                if (command == "up")
                {
                    if (rowNumber - 1 < 0)
                    {
                        continue;
                    }

                    if (matrix[rowNumber - 1,colNumber] == 'O')
                    {
                        continue;
                    }

                    rowNumber--;
                    if (matrix[rowNumber, colNumber] == '-')
                    {
                        countOfMoves++;
                    }
                    else if (matrix[rowNumber, colNumber] == 'P')
                    {
                        countOfTouches++;
                        countOfMoves++;
                        matrix[rowNumber, colNumber] = '-';
                    }

                }
                else if (command == "down")
                {
                    if (rowNumber + 1 >= lengthOfRows)
                    {
                        continue;
                    }

                    if (matrix[rowNumber + 1, colNumber] == 'O')
                    {
                        continue;
                    }

                    rowNumber++;
                    if (matrix[rowNumber, colNumber] == '-')
                    {
                        countOfMoves++;
                    }
                    else if (matrix[rowNumber, colNumber] == 'P')
                    {
                        countOfTouches++;
                        countOfMoves++;
                        matrix[rowNumber, colNumber] = '-';
                    }
                }
                else if (command == "right")
                {
                    if (colNumber + 1 >= lengthOfCols)
                    {
                        continue;
                    }

                    if (matrix[rowNumber, colNumber + 1] == 'O')
                    {
                        continue;
                    }

                    colNumber++;
                    if (matrix[rowNumber, colNumber] == '-')
                    {
                        countOfMoves++;
                    }
                    else if (matrix[rowNumber, colNumber] == 'P')
                    {
                        countOfTouches++;
                        countOfMoves++;
                        matrix[rowNumber, colNumber] = '-';
                    }
                }
                else if (command == "left")
                {
                    if (colNumber - 1 < 0)
                    {
                        continue;
                    }

                    if (matrix[rowNumber, colNumber - 1] == 'O')
                    {
                        continue;
                    }

                    colNumber--;
                    if (matrix[rowNumber, colNumber] == '-')
                    {
                        countOfMoves++;
                    }
                    else if (matrix[rowNumber, colNumber] == 'P')
                    {
                        countOfTouches++;
                        countOfMoves++;
                        matrix[rowNumber, colNumber] = '-';
                    }
                }

            }

            Console.WriteLine("Game over!");
            Console.WriteLine($"Touched opponents: {countOfTouches} Moves made: {countOfMoves}");

        }
    }
}
