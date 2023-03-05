using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacChess_88130
{
    class GameManagement
    {
        private string currentColor;

        private List<Piece> allPieces;
        private List<Player> allPlayers;

        public GameManagement()
        {
            currentColor = "White";

            allPieces = new List<Piece>();
            allPlayers = new List<Player>();            
        }

        #region Color

        public void ChangeColor(string newColor)
        {
            currentColor = newColor;
        }

        #endregion

        #region Pieces

        public void AddPiece(Piece newPiece)
        {
            allPieces.Add(newPiece);
        }

        public List<Piece> GetPiecesOfColor(string color)
        {
            return allPieces.Where(piece => piece.GetPieceColor() == color).ToList();
        }

        public int[] GetStartingPositions()
        {
            if (currentColor == "White")
            {
                return new int[] { 1, 2, 3 };
            }
            else
            {
                return new int[] { 7, 8, 9 };
            }            
        }

        #endregion

        #region Players

        public void AddPlayer(Player newPlayer)
        {
            allPlayers.Add(newPlayer);
        }

        #endregion
    }
}
