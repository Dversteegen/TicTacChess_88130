using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacChess_88130
{
    class Piece
    {
        private string type;
        private string color;
        private int currentPosition;
        private int[] startingPositions;

        public Piece(string pieceType, string pieceColor, int[] availablePositions)
        {
            type = pieceType;
            color = pieceColor;
            currentPosition = 0;
            startingPositions = availablePositions;
        }

        #region GetFunctions

        public string GetPieceColor()
        {
            return color;
        }

        public int[] GetStartPositions()
        {
            return startingPositions;
        }

        #endregion
    }
}
