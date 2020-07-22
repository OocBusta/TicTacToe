using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class GameLogic
    {
        UserInput userInput;
        Board gameBoard;

        bool isPlayerOne = true;
        bool isChanged = false;
        bool isTie = false;
        public bool isGameOver = false;

        string validUserInput;

        int turnCount = 1;

        public void Game()
        {
            validUserInput = userInput.GetUserInput(isPlayerOne, gameBoard, turnCount);
            isChanged = gameBoard.SetTicTacBoard(isPlayerOne, validUserInput);
            isGameOver = gameBoard.VictoryCheck(isPlayerOne);
            isTie = TieCheck(turnCount);


            if (isGameOver)
            {
                isGameOver = userInput.CheckReplay(gameBoard, isPlayerOne, isTie);
                this.turnCount = 1;
                gameBoard.ResetBoard();
            }
            else
            {
                isPlayerOne = PlayerSwap(isPlayerOne);
            }
        }

        private bool TieCheck(int turnCount)
        {
            bool result = false;
            if (this.isChanged)
            {
                if (turnCount == 9)
                {
                    this.turnCount = 1;
                    result = true;
                }
                else
                {
                    this.turnCount++;
                }
            }

            return result;
        }

        private bool PlayerSwap(bool isPlayerOne)
        {
            bool choice = false;

            if (isChanged)
            {
                if (isPlayerOne)
                {
                    choice = false;
                }
                else
                {
                    choice = true;
                }
            }

            return choice;
        }

        public GameLogic()
        {
            userInput = new UserInput();
            gameBoard = new Board();
        }
    }
}
