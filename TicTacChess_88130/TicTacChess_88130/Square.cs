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
        private int squareHorizontal;
        private int squareRotation;
        private Piece currentPiece;

        public Square(int c_squarePosition, int c_squareHorizontal, int c_squareRotation, Piece c_piece)
        {
            squarePosition = c_squarePosition;
            squareHorizontal = c_squareHorizontal;
            squareRotation = c_squareRotation;
            currentPiece = c_piece;
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

        public Tuple<int, int> GetArmPositions()
        {
            return Tuple.Create(squareHorizontal, squareRotation);
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
