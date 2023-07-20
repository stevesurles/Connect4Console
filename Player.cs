using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4Console
{
    internal class Player
    {
        private String name;
        private GridPosition piece;

        public Player(String name, GridPosition piece)
        {
            this.name = name;
            this.piece = piece;
        }

        public String GetName()
        {
            return this.name;
        }

        public GridPosition GetPieceColor()
        {
            return this.piece;
        }
    }
}
