using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacChess_88130
{
    class Square
    {
        private int squarePosition;
        private Piece currentPiece;

        public Square(int position, Piece piece)
        {
            squarePosition = position;
            currentPiece = piece;
        }

        #region GetFunctions

        public int GetSquarePosition()
        {
            return squarePosition;
        }

        public Piece GetCurrentPiece()
        {
            return currentPiece;
        }        

        #endregion

        #region Methods
        public void UpdatePiece(Piece newPiece)
        {
            currentPiece = newPiece;
        }

        public void ResetSquare()
        {
            currentPiece = null;
        }

        #endregion
    }
}
