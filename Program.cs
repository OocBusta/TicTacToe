using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            GameLogic game = new GameLogic();
            while (game.isGameOver == false){
                game.Game();
            }
        }
    }
}
