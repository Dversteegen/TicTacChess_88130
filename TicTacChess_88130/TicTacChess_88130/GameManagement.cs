using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacChess_88130
{
    class GameManagement
    {
        private List<Square> allSquares;
        private List<Piece> allPieces;
        //private List<Player> allPlayers;

        private string currentColor;
        private bool allPiecesSet;

        public GameManagement()
        {
            currentColor = "White";

            allSquares = new List<Square>();
            allPieces = new List<Piece>();
            //allPlayers = new List<Player>();
        }

        #region StartUp

        /// <summary>
        /// Adds squares to the list
        /// </summary>
        /// <param name="newSquare"></param>
        public void AddSquare(Square newSquare)
        {
            allSquares.Add(newSquare);
        }

        /// <summary>
        /// Adds a piece to the list
        /// </summary>
        /// <param name="newPiece"></param>
        public void AddPiece(Piece newPiece)
        {
            allPieces.Add(newPiece);
        }

        public void AddPlayer(Player newPlayer)
        {
            //allPlayers.Add(newPlayer);
        }

        #endregion

        #region SetUp

        /// <summary>
        /// Keeps track of the color for setting up the board
        /// </summary>
        /// <param name="newColor"></param>
        public void ChangeColor(string newColor)
        {
            currentColor = newColor;
        }

        /// <summary>
        /// Returns all the pieces which are already set based on the color who's turn it is
        /// </summary>
        /// <returns></returns>
        public List<Piece> GetAllSetPieces()
        {
            List<Piece> allSetPieces = allSquares
                .Where(square => square.GetCurrentPiece() != null && square.GetCurrentPiece().GetPieceColor() == currentColor)
                .Select(square => square.GetCurrentPiece())
                .ToList();

            return allSetPieces;
        }

        /// <summary>
        /// Returns all the indexes of the starting positions based on the color
        /// </summary>
        /// <returns></returns>
        public int[] GetOpenStartingPositions()
        {
            IEnumerable<int> allOpenPosition = allSquares
                .Where(square => square.GetCurrentPiece() == null)
                .Select(square => square.GetSquarePosition());

            int[] currentStartingPositions;
            if (currentColor == "White")
            {
                currentStartingPositions = new int[] { 0, 1, 2 };
            }
            else
            {
                currentStartingPositions = new int[] { 6, 7, 8 };
            }

            int[] allOpenStartingPositions = allOpenPosition.Intersect(currentStartingPositions).Select(position => position).ToArray();
            return allOpenStartingPositions;
        }

        /// <summary>
        /// Assigns a piece to a square
        /// </summary>
        /// <param name="indexOfPosition"></param>
        /// <param name="pictureBoxName"></param>
        public void UpdateSquare(int indexOfPosition, string pictureBoxName)
        {
            string pieceType = pictureBoxName.Substring(3);
            Piece currentPiece = allPieces.Where(piece => piece.GetPieceColor() == currentColor && piece.GetPieceType() == pieceType).Single();

            allSquares[indexOfPosition].UpdatePiece(currentPiece);
            CheckBoardForStart();
        }

        public void CheckBoardForStart()
        {
            List<Piece> allSetPieces = allSquares
                .Where(square => square.GetCurrentPiece() != null)
                .Select(square => square.GetCurrentPiece())
                .ToList();

            if (allSetPieces.Count == 6)
            {
                allPiecesSet = true;
            }
            else
            {
                allPiecesSet = false;
            }
        }

        public bool CanGameStart()
        {
            return allPiecesSet;
        }

        #endregion

        #region InGame

        public int[] GetAllAvailablePositions()
        {
            return allSquares
                .Where(square => square.GetCurrentPiece() == null)
                .Select(square => square.GetSquarePosition())
                .ToArray();
        }

        #endregion

        #region ResetGame

        public void ResetSquares()
        {
            foreach (Square square in allSquares)
            {
                square.ResetSquare();
            }
            allPiecesSet = false;
        }



        #endregion

        #region ToBeChecked

        /// <summary>
        /// Returns all the pieces belonging to the color
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        //public List<Piece> GetPiecesOfColor(string color)
        //{
        //    return allPieces.Where(piece => piece.GetPieceColor() == color).ToList();
        //}



        #endregion
    }
}
