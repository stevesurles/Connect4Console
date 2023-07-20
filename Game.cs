using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4Console
{
    internal class Game
    {
        private Grid grid;
        private int connectN;
        private Player[] players;
        private Dictionary<string, int> score;
        private int targetScore;

        public Game(Grid grid, int connectN, int targetScore)
        {
            this.grid = grid;
            this.connectN = connectN;
            this.targetScore = targetScore;

            this.players = new Player[] {
            new Player("Player 1", GridPosition.YELLOW),
            new Player("Player 2", GridPosition.RED)
        };

            this.score = new Dictionary<string, int>();
            foreach (Player player in this.players)
            {
                this.score.Add(player.GetName(), 0);
            }
        }

        private void printBoard()
        {
            Console.WriteLine("Board:");
            var grid = this.grid.GetGrid();
            for (int i = 0; i < grid.Length; i++)
            {
                String row = "";
                foreach (var piece in grid[i])
                {
                    if (piece == GridPosition.EMPTY)
                    {
                        row += "0 ";
                    }
                    else if (piece == GridPosition.YELLOW)
                    {
                        row += "Y ";
                    }
                    else if (piece == GridPosition.RED)
                    {
                        row += "R ";
                    }
                }
                Console.WriteLine(row);
            }
            Console.WriteLine();
        }

        private int[] PlayMove(Player player)
        {
            printBoard();
            Console.WriteLine(player.GetName() + "'s turn");
            int colCnt = this.grid.GetColumnCount();
            Console.WriteLine($"Enter column between 0 and {colCnt - 1} to add piece: ");
            string input = Console.ReadLine();

        
            int moveColumn = int.Parse(input);
            int moveRow = this.grid.PlacePiece(moveColumn, player.GetPieceColor());
            return new int[] { moveRow, moveColumn };
        }

        private Player playRound()
        {
            while (true)
            {
                foreach (Player player in this.players)
                {
                    int[] pos = PlayMove(player);
                    int row = pos[0];
                    int col = pos[1];
                    GridPosition pieceColor = player.GetPieceColor();
                    if (this.grid.CheckWin(this.connectN, row, col, pieceColor))
                    {
                        if (!this.score.ContainsKey(player.GetName()))
                        {
                            this.score.Add(player.GetName(), 1);
                        }
                        else
                        {
                            this.score[player.GetName()] += 1;
                        }
                        
                        return player;
                    }
                }
            }
        }

        public void play()
        {
            int maxScore = 0;
            Player winner = null;
            while (maxScore < this.targetScore)
            {
                winner = playRound();
                Console.WriteLine(winner.GetName() + " won the round");
                maxScore = Math.Max(this.score[winner.GetName()], maxScore);

                this.grid.InitGrid(); // reset grid
            }
            Console.WriteLine(winner.GetName() + " won the game");
        }
    }
}
