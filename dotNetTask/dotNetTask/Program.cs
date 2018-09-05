using System;

namespace dotNetTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = CheckAllBoards() ? "OK!" : "One or more board failed to check.";
            Console.WriteLine(result);
            Console.ReadLine();
        }

        /// <summary>
        /// Insert your code here
        /// </summary>
        /// <param name="array">9*9 char array</param>
        /// <returns></returns>
        static bool CheckBoardIfSudoku(char[,] array)
        {
            // 1st condition
            if (array.Length != 81)
                return false;

            // 2nd and 4th condiions
            foreach(char chNum in array)
            {
                if (chNum != '1' && chNum != '2' && chNum != '3' && chNum != '4' && chNum != '5'
                    && chNum != '6' && chNum != '7' && chNum != '8' && chNum != '9' && chNum != '.')
                    return false;
            }

            // 3rd condition
            int rows = array.GetUpperBound(0) + 1,
                columns = array.Length / rows;

            for(int i = 0; i < rows; i++)
            {
                for(int j = 0; j < columns; j++)
                {
                    // this row
                    for(int thisRow = i + 1; thisRow < columns; thisRow++)
                    {
                        if (array[i, j] == array[thisRow, j] && array[i, j] != '.')
                            return false;
                    }

                    // this column
                    for(int thisColumn = j + 1; thisColumn < columns; thisColumn++)
                    {
                        if (array[i, j] == array[i, thisColumn] && array[i, j] != '.')
                            return false;
                    }

                    // this 3x3 cube
                    int firstCubeRow = (i < 3) ? 0 : (i < 6) ? 3 : 6,
                        firstCubeColumn = (j < 3) ? 0 : (j < 6) ? 3 : 6;

                    for (int miniI = firstCubeRow; miniI < firstCubeRow + 3; miniI++)
                    {
                        for(int miniJ = firstCubeColumn; miniJ < firstCubeColumn + 3; miniJ++)
                        {
                            if (i == miniI && j == miniJ)   
                                continue;

                            if (array[i, j] == array[miniI, miniJ] && array[i, j] != '.')
                                return false;
                        }
                    }
                }
            }

            return true;
        }
        static bool CheckAllBoards()
        {
            var boardValid1 = new char[9, 9]{    { '5', '3', '.', '.', '7', '.', '.', '.', '.' },
                                                 { '6', '.', '.', '1', '9', '5', '.', '.', '.' },
                                                 { '.', '9', '8', '.', '.', '.', '.', '6', '.' },
                                                 { '8', '.', '.', '.', '6', '.', '.', '.', '3' },
                                                 { '4', '.', '.', '8', '.', '3', '.', '.', '1' },
                                                 { '7', '.', '.', '.', '2', '.', '.', '.', '6' },
                                                 { '.', '6', '.', '.', '.', '.', '2', '8', '.' },
                                                 { '.', '.', '.', '4', '1', '9', '.', '.', '5' },
                                                 { '.', '.', '.', '.', '8', '.', '.', '7', '9' } };
            var trueResult = CheckBoardIfSudoku(boardValid1);
            var boardValid2 = new char[9, 9]{    { '.', '.', '.', '.', '.', '.', '.', '.', '.' },
                                                 { '.', '.', '.', '.', '.', '.', '.', '.', '.' },
                                                 { '.', '.', '.', '.', '.', '.', '.', '.', '.' },
                                                 { '.', '.', '.', '.', '.', '.', '.', '.', '.' },
                                                 { '.', '.', '.', '.', '.', '.', '.', '.', '.' },
                                                 { '.', '.', '.', '.', '.', '.', '.', '.', '.' },
                                                 { '.', '.', '.', '.', '.', '.', '.', '.', '.' },
                                                 { '.', '.', '.', '.', '.', '.', '.', '.', '.' },
                                                 { '.', '.', '.', '.', '.', '.', '.', '.', '.' } };
            var trueResult2 = CheckBoardIfSudoku(boardValid2);
            var boardInValid1 = new char[9, 9]{  { '5', '3', '.', '.', '7', '.', '.', '.', '.' },
                                                 { '6', '.', '5', '1', '9', '5', '.', '.', '.' },
                                                 { '.', '9', '8', '.', '.', '.', '.', '6', '.' },
                                                 { '8', '.', '.', '.', '6', '.', '.', '.', '3' },
                                                 { '4', '.', '.', '8', '.', '3', '.', '.', '1' },
                                                 { '7', '.', '.', '.', '2', '.', '.', '.', '6' },
                                                 { '.', '6', '.', '.', '.', '.', '2', '8', '.' },
                                                 { '.', '.', '.', '4', '1', '9', '.', '.', '5' },
                                                 { '.', '.', '.', '.', '8', '.', '.', '7', '9' } };
            var falseResult1 = CheckBoardIfSudoku(boardInValid1);
            var boardInValid2 = new char[9, 9]{  { '5', '3', '.', '.', '7', '.', '.', '.', '.' },
                                                 { '6', '.', '2', '1', '9', '5', '.', '.', '.' },
                                                 { '.', '9', '8', '.', '.', '.', '.', '6', '.' },
                                                 { '8', '.', '.', '.', '6', '.', '.', '.', '3' },
                                                 { '4', '.', '.', '8', '.', '3', '.', '.', '1' },
                                                 { '7', '.', '.', '.', '2', '.', '.', '.', '6' },
                                                 { '.', '6', '.', '.', '.', '.', '2', '8', '.' },
                                                 { '.', '.', '.', '4', '1', '9', '.', '.', '5' },
                                                 { '6', '.', '.', '.', '8', '.', '.', '7', '9' } };
            var falseResult2 = CheckBoardIfSudoku(boardInValid2);
            var boardInValid3 = new char[9, 9]{  { '5', '3', '.', '.', '7', '.', '.', '.', '3' },
                                                 { '6', '.', '5', '1', '9', '5', '.', '.', '.' },
                                                 { '.', '9', '8', '.', '.', '.', '.', '6', '.' },
                                                 { '8', '.', '.', '.', '6', '.', '.', '.', '3' },
                                                 { '4', '.', '.', '8', '.', '3', '.', '.', '1' },
                                                 { '7', '.', '.', '.', '2', '.', '.', '.', '6' },
                                                 { '.', '6', '.', '.', '.', '.', '2', '8', '.' },
                                                 { '.', '.', '.', '4', '1', '9', '.', '.', '5' },
                                                 { '.', '.', '.', '.', '8', '.', '.', '7', '9' } };
            var falseResult3 = CheckBoardIfSudoku(boardInValid3);
            var boardInValid4 = new char[9, 9]{  { '.', '.', '.', '.', '.', '.', '.', '.', '.' },
                                                 { '.', '.', '.', '.', '.', '.', '.', '.', '.' },
                                                 { '.', '.', '.', '.', '.', '.', '.', '.', '.' },
                                                 { '.', '.', '.', '.', '.', '.', '.', '.', '.' },
                                                 { '.', '.', '.', '.', '.', '.', '.', '.', '.' },
                                                 { '.', '.', '.', '.', '.', '.', '.', '.', '.' },
                                                 { '.', '.', '.', '.', '.', '.', '1', '.', '.' },
                                                 { '.', '.', '.', '.', '.', '.', '.', '.', '.' },
                                                 { '.', '.', '.', '.', '.', '.', '.', '.', '1' } };
            var falseResult4 = CheckBoardIfSudoku(boardInValid4);
            return trueResult && trueResult2 && !falseResult1 && !falseResult2 && !falseResult3 && !falseResult4;
        }
    }
}
