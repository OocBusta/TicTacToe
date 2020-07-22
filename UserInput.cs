using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class UserInput
    {
        public string GetUserInput(bool isPlayerOne, Board currentBoard, int turnCount)
        {

            bool isValid = false;

            string userInput;
            string playerNumber;

            if (isPlayerOne)
            {
                playerNumber = "Player One";
            } else
            {
                playerNumber = "Player Two";
            }

            do
            {
                currentBoard.DisplayBoard();
                Console.WriteLine("{0}: Please input a number listed on the board.\n" + "This is turn {1}", playerNumber, turnCount);
                userInput = Console.ReadLine();
                userInput = userInput.Trim();

                if (int.TryParse(userInput, out int x))
                {
                    if (x > 0 && x <= 9)
                    {
                        isValid = true;
                        Console.Clear();
                    } else
                    {
                        Console.Clear();
                        currentBoard.DisplayBoard();
                        DisplayWarning();
                    }
                } else
                {
                    DisplayWarning();
                }
            } while (isValid == false);

            return userInput;
            
        }

        public bool CheckReplay(Board currentBoard, bool isPlayerOne, bool isTie)
        {
            string player;
            string userInput;

            bool isValid = false;
            bool choice = false;

            if (isPlayerOne)
            {
                player = "Player One";
            }
            else
            {
                player = "Player Two";
            }

            while (isValid == false)
            {
                Console.Clear();
                currentBoard.DisplayBoard();
                if (isTie == false)
                {
                    Console.WriteLine("{0} has won the game.\n" +
                                      "Would you like to play again?" +
                                      "(Y)es or (N)o.", player);

                    userInput = Console.ReadLine();
                    userInput = userInput.ToLower();
                } else
                {
                    Console.WriteLine("The game is a tie.\n" +
                                      "Would you like to play again?" +
                                      "(Y)es or (N)o.");

                    userInput = Console.ReadLine();
                    userInput = userInput.ToLower();
                }

                if (userInput == "y" || userInput == "yes")
                {
                    Console.Clear();
                    isValid = true;
                    choice = false;
                }
                else if (userInput == "n" || userInput == "no")
                {
                    Console.Clear();
                    isValid = true;
                    choice = true;
                }
                else
                {
                    DisplayWarning();
                    isValid = false;
                    choice = false;

                }
            }
            return choice;
        }

        private void DisplayWarning()
        {
            Console.WriteLine("That is not a valid choice.\n" +
                              "Hit any Key to return.");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
