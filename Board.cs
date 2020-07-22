using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class Board
    {
        private string[,] ticTacBoard;

        public void ResetBoard()
        {
            this.ticTacBoard = new string[,]
            {
                { "1", "2", "3" },
                { "4", "5", "6" },
                { "7", "8", "9" }
            };
        }

        public void DisplayBoard()
        {
            Console.WriteLine(" {0} | {1} | {2} \n" +
                              "-----------\n" +
                              " {3} | {4} | {5} \n" +
                              "-----------\n" +
                              " {6} | {7} | {8} \n",
                              ticTacBoard[0, 0], ticTacBoard[0, 1], ticTacBoard[0, 2],
                              ticTacBoard[1, 0], ticTacBoard[1, 1], ticTacBoard[1, 2],
                              ticTacBoard[2, 0], ticTacBoard[2, 1], ticTacBoard[2, 2]);
        }

        public string[,] GetTicTacBoard()
        {
            return ticTacBoard;
        }

        public bool SetTicTacBoard(bool isPlayerOne, string selection)
        {
            string boardMod = DeterminePlayerChar(isPlayerOne);

            bool isChanged = false;

            switch (selection)
            {
                case "1":
                    isChanged = ValidBoardCheck(0, 0, boardMod);
                    break;
                case "2":
                    isChanged = ValidBoardCheck(0, 1, boardMod);
                    break;
                case "3":
                    isChanged = ValidBoardCheck(0, 2, boardMod);
                    break;
                case "4":
                    isChanged = ValidBoardCheck(1, 0, boardMod);
                    break;
                case "5":
                    isChanged = ValidBoardCheck(1, 1, boardMod);
                    break;
                case "6":
                    isChanged = ValidBoardCheck(1, 2, boardMod);
                    break;
                case "7":
                    isChanged = ValidBoardCheck(2, 0, boardMod);
                    break;
                case "8":
                    isChanged = ValidBoardCheck(2, 1, boardMod);
                    break;
                case "9":
                    isChanged = ValidBoardCheck(2, 2, boardMod);
                    break;
                default:
                    Console.WriteLine("Not a valid choice. Please input select a number available on the board.");
                    break;
            }

            return isChanged;
        }

        private string DeterminePlayerChar(bool isPlayerOne)
        {
            if (isPlayerOne == true)
            {
                return "X";
            }
            else
            {
                return "O";
            }

        }

        private bool ValidBoardCheck(int x, int y, string input)
        {
            bool isChanged = false;

            if (ticTacBoard[x, y] == "X" || ticTacBoard[x, y] == "O")
            {
                DisplayBoard();
                Console.WriteLine("That space has already been selected.\n" +
                                  "Hit any key to return.");
                Console.ReadKey();
                Console.Clear();
                isChanged = false;
            }
            else
            {
                ticTacBoard[x, y] = input;
                isChanged = true;
            }

            return isChanged;
        }

        public bool VictoryCheck(bool isPlayerOne)
        {
            /* Potential Wins:
             * Row 1: 0, 0 | 0, 1 | 0, 2
             * Row 2: 1, 0 | 1, 1 | 1, 2
             * Row 3: 2, 0 | 2, 1 | 2, 2
             * Col 1: 0, 0 | 1, 0 | 2, 0
             * Col 2: 0, 1 | 1, 1 | 2, 1
             * Col 3: 0, 2 | 1, 2 | 2, 2
             * Forward Cross: 0, 0 | 1, 1 | 2, 2
             * Backward Cross: 0, 2 | 1, 1 | 2, 0
             * 
             * {00,01,02},
             */

            string boardMod = DeterminePlayerChar(isPlayerOne);

            bool result;

            if(ticTacBoard[0,0] == boardMod && ticTacBoard[0,1] == boardMod && ticTacBoard[0,2] == boardMod)
            {
                result = true;
            } 
            else if(ticTacBoard[1, 0] == boardMod && ticTacBoard[1, 1] == boardMod && ticTacBoard[1, 2] == boardMod)
            {
                result = true;
            }
            else if (ticTacBoard[2, 0] == boardMod && ticTacBoard[2, 1] == boardMod && ticTacBoard[2, 2] == boardMod)
            {
                result = true;
            }
            else if (ticTacBoard[0, 0] == boardMod && ticTacBoard[1, 0] == boardMod && ticTacBoard[2, 0] == boardMod)
            {
                result = true;
            }
            else if(ticTacBoard[0, 1] == boardMod && ticTacBoard[1, 1] == boardMod && ticTacBoard[2, 1] == boardMod)
            {
                result = true;
            }
            else if (ticTacBoard[0, 2] == boardMod && ticTacBoard[1, 2] == boardMod && ticTacBoard[2, 2] == boardMod)
            {
                result = true;
            }
            else if (ticTacBoard[0, 0] == boardMod && ticTacBoard[1, 1] == boardMod && ticTacBoard[2, 2] == boardMod)
            {
                result = true;
            }
            else if (ticTacBoard[0, 2] == boardMod && ticTacBoard[1, 1] == boardMod && ticTacBoard[2, 0] == boardMod)
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return result;

        }

        public Board()
        {
            ResetBoard();
        }
    }
}
