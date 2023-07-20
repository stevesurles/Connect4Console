using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4Console
{
    enum GridPosition
    {
        EMPTY, YELLOW, RED
    }

    internal class Grid
    {
        private int rows;
        private int columns;
        private GridPosition[][] grid;

        public Grid(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            InitGrid();
        }
        public void InitGrid()
        {
            this.grid = new GridPosition[rows][];
            for (int i = 0; i < rows; i++)
            {
                grid[i] = new GridPosition[columns];
                for (int j = 0; j < columns; j++)
                {
                    grid[i][j] = GridPosition.EMPTY;
                }
            }
        }

        public GridPosition[][] GetGrid()
        {
            return this.grid;
        }

        public int GetColumnCount()
        {
            return this.columns;
        }
        public int PlacePiece(int column, GridPosition piece)
        {
            if (column < 0 || column >= this.columns)
            {
                throw new Exception("Invalid column");
            }
            if (piece == GridPosition.EMPTY)
            {
                throw new Exception("Invalid piece");
            }
            // Place piece in the lowest empty row
            for (int row = this.rows - 1; row >= 0; row--)
            {
                if (this.grid[row][column] == GridPosition.EMPTY)
                {
                    this.grid[row][column] = piece;
                    return row;
                }
            }
            return -1;
        }

        public bool CheckWin(int connectN, int row, int col, GridPosition piece)
        {
            // Check horizontal
            int count = 0;
            for (int c = 0; c < this.columns; c++)
            {
                if (this.grid[row][c] == piece)
                {
                    count++;
                }
                else
                {
                    count = 0;
                }
                if (count == connectN)
                {
                    return true;
                }
            }

            // Check vertical
            count = 0;
            for (int r = 0; r < this.rows; r++)
            {
                if (this.grid[r][col] == piece)
                {
                    count++;
                }
                else
                {
                    count = 0;
                }
                if (count == connectN)
                {
                    return true;
                }
            }

            // Check diagonal
            count = 0;
            for (int r = 0; r < this.rows; r++)
            {
                int c = row + col - r; // row + col = r + c, for a diagonal
                if (c >= 0 && c < this.columns && this.grid[r][c] == piece)
                {
                    count++;
                }
                else
                {
                    count = 0;
                }
                if (count == connectN)
                {
                    return true;
                }
            }

            // Check anti-diagonal
            count = 0;
            for (int r = 0; r < this.rows; r++)
            {
                int c = col - row + r; // row - col = r - c, for an anti-diagonal
                if (c >= 0 && c < this.columns && this.grid[r][c] == piece)
                {
                    count++;
                }
                else
                {
                    count = 0;
                }
                if (count == connectN)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
