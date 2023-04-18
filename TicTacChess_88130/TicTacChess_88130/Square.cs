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
        private int squareHorizontalArm;
        private int squareRotationArm;

        //I have divided the board in 4 blocks, I use these blocks for the king movement
        private int[] squareBlock;
        private Piece currentPiece;
        
        public Square(int c_squarePosition, int[] c_squareBlock, int c_squareHorizontalArm, int c_squareRotationArm, Piece c_piece)
        {
            squarePosition = c_squarePosition;
            squareBlock = c_squareBlock;
            squareHorizontalArm = c_squareHorizontalArm;
            squareRotationArm = c_squareRotationArm;
            currentPiece = c_piece;
        }

        #region GetFunctions

        public int GetSquarePosition()
        {
            return squarePosition;
        }

        public int[] GetSquareBlocks()
        {
            return squareBlock;
        }

        public Piece GetCurrentPiece()
        {
            return currentPiece;
        }        

        public Tuple<int, int> GetArmPositions()
        {
            return Tuple.Create(squareHorizontalArm, squareRotationArm);
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
