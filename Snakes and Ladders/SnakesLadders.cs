using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snakes_and_Ladders
{
    class SnakesLadders
    {
        List<int[]> ladders;
        List<int[]> snakes;
        Player player1;
        Player player2;
        Player currentPlayer;
        bool endGame;

        public SnakesLadders()
        {
            ladders = new List<int[]>() { new int[] { 2, 38 }, new int[] { 7, 14 }, new int[] { 8, 31 },
                new int[] { 15, 26 }, new int[] { 28, 84 }, new int[] { 21, 42 }, new int[] { 36, 44 },
                new int[] { 51, 67 }, new int[] { 71, 91 }, new int[] { 78, 98 }, new int[] { 87, 94 } };

            snakes = new List<int[]>() { new int[] { 6, 16 }, new int[] { 11, 49 }, new int[] { 19, 62 },
                new int[] { 25, 46 }, new int[] { 53, 74 }, new int[] { 60, 64 }, new int[] { 68, 89 },
                new int[] { 75, 95 }, new int[] { 80, 99 }, new int[] { 88, 92 } };

            player1 = new Player
            { number = 1, currentSquare = 0, doubleThrow = false };

            player2 = new Player
            { number = 2, currentSquare = 0, doubleThrow = false };
            endGame = false;
            currentPlayer = player1;
        }
        public string play(int die1, int die2)
        {
            if (endGame) return "Game over!";
            currentPlayer.doubleThrow = die1 == die2 ? true : false;
            currentPlayer.currentSquare += die1 + die2;

            if (currentPlayer.currentSquare == 100)
            {
                endGame = true;
                string outStr = $"Player {currentPlayer.number} Wins!";
                currentPlayer = GetNextPlayer(currentPlayer);
                return outStr;
            }

            if (currentPlayer.currentSquare > 100)
                currentPlayer.currentSquare = 200 - currentPlayer.currentSquare;

            if (ladders.Exists(l => l[0] == currentPlayer.currentSquare))
            {
                currentPlayer.currentSquare = ladders.Find(l => l[0] == currentPlayer.currentSquare)[1];
                string outStr = $"Player {currentPlayer.number} is on square {currentPlayer.currentSquare}";
                currentPlayer = GetNextPlayer(currentPlayer);
                return outStr;
            }

            if (snakes.Exists(l => l[1] == currentPlayer.currentSquare))
            {
                currentPlayer.currentSquare = snakes.Find(l => l[1] == currentPlayer.currentSquare)[0];
                string outStr = $"Player {currentPlayer.number} is on square {currentPlayer.currentSquare}";
                currentPlayer = GetNextPlayer(currentPlayer);
                return outStr;
            }
            string outStr1 = $"Player {currentPlayer.number} is on square {currentPlayer.currentSquare}";
            currentPlayer = GetNextPlayer(currentPlayer);

            return outStr1;

        }

        Player GetNextPlayer(Player currentPlayer)
        {
            if (currentPlayer.doubleThrow)
            {
                currentPlayer.doubleThrow = false;
                return currentPlayer;
            }
            return currentPlayer == player1 ? player2 : player1;
        }
    }
}
