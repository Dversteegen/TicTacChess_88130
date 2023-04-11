using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacChess_88130
{
    class GameManagement
    {
        private List<Square> allSquares = null;
        private List<Piece> allPieces = null;
        private List<WinPosition> allWinPositions = null;

        private string currentColor = "white";
        private string gameState = "setUp";
        
        private bool allPiecesSet = false;
        private bool waitingForArm = false;
        private bool connectedToArm = false;

        public GameManagement()
        {
            allSquares = new List<Square>();
            allPieces = new List<Piece>();
            allWinPositions = new List<WinPosition>();
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

        /// <summary>
        /// Adds a win position to the list
        /// </summary>
        /// <param name="newWinPosition"></param>
        public void AddWinPosition(WinPosition newWinPosition)
        {
            allWinPositions.Add(newWinPosition);
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
            if (currentColor == "white")
            {
                currentStartingPositions = new int[] { 6, 7, 8 };
            }
            else
            {
                currentStartingPositions = new int[] { 0, 1, 2 };
            }

            int[] allOpenStartingPositions = allOpenPosition.Intersect(currentStartingPositions).Select(position => position).ToArray();
            return allOpenStartingPositions;
        }

        /// <summary>
        /// Assigns a piece to a square
        /// </summary>
        /// <param name="indexOfPosition"></param>
        /// <param name="pictureBoxName"></param>
        public void UpdateStartSquare(int indexOfPosition, string pictureBoxName)
        {
            string pieceType = pictureBoxName.Substring(3);
            Piece currentPiece = allPieces.Where(piece => piece.GetPieceColor() == currentColor && piece.GetPieceType() == pieceType).Single();

            allSquares[indexOfPosition].UpdatePiece(currentPiece);
            CheckBoardForStart();
        }

        /// <summary>
        /// Check if all six pieces have been place
        /// </summary>
        public void CheckBoardForStart()
        {
            List<Piece> allSetPieces = allSquares
                .Where(square => square.GetCurrentPiece() != null)
                .Select(square => square.GetCurrentPiece())
                .ToList();

            if (allSetPieces.Count == 6)
            {
                allPiecesSet = true;
                gameState = "playing";
            }
            else
            {
                allPiecesSet = false;
            }
        }

        /// <summary>
        /// Returns if the game can start
        /// </summary>
        /// <returns></returns>
        public bool CanGameStart()
        {
            return allPiecesSet;
        }

        #endregion

        #region InGame        

        #region Form

        /// <summary>
        /// Returns the piece on the square belonging to the given index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Piece GetCurrentPiece(int index)
        {
            return allSquares[index].GetCurrentPiece();
        }

        #region GetPositions

        /// <summary>
        /// Returns all the possible squares a piece can move to
        /// </summary>
        /// <param name="index"></param>
        /// <param name="currentPiece"></param>
        /// <returns></returns>
        public int[] GetAllAvailablePositions(int index, Piece currentPiece)
        {
            switch (currentPiece.GetPieceType())
            {
                case "Queen":
                    return GetAvailablePositionsForQueen(index);

                case "Rook":
                    return GetAvailablePositionsForRook(index);

                case "Knight":
                    return GetAvailablePositionsForKnight(index);
            }
            return null;
        }

        /// <summary>
        /// Returns all the possible positions the queen at the given index can move to
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public int[] GetAvailablePositionsForQueen(int index)
        {
            if ((index == 0 || index == 2 || index == 6 || index == 8) && CheckSquare(index, 4) == true)
            {
                return GetHorizontalPositions(index).Concat(GetVerticalPositions(index)).Except(GetAllTakenSqaures()).ToArray(); ;
            }
            else
            {
                return GetHorizontalPositions(index).Concat(GetVerticalPositions(index)).Concat(GetDiagonalPositions(index)).Except(GetAllTakenSqaures()).ToArray(); ;
            }

        }

        /// <summary>
        /// Returns all the possible positions the Rook at the given index can move to
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public int[] GetAvailablePositionsForRook(int index)
        {
            return GetHorizontalPositions(index).Concat(GetVerticalPositions(index)).Except(GetAllTakenSqaures()).ToArray();
        }

        /// <summary>
        /// Returns all the possible positions the knight at the given index can move to
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public int[] GetAvailablePositionsForKnight(int index)
        {
            return GetKnightPositions(index).Except(GetAllTakenSqaures()).ToArray();
        }

        /// <summary>
        /// Returns an array of indexes which already have a piece on it
        /// </summary>
        /// <returns></returns>
        public int[] GetAllTakenSqaures()
        {
            return allSquares.Where(square => square.GetCurrentPiece() != null).Select(square => square.GetSquarePosition()).ToArray();
        }

        /// <summary>
        /// Returns all the possible indexes where a piece can move to from the passed index horizontally
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public int[] GetHorizontalPositions(int index)
        {
            if (index < 3)
            {
                if (CheckSquare(index, 1) == false)
                {
                    return new int[] { 0, 1, 2 };
                }
            }
            else if (index < 6)
            {
                if (CheckSquare(index, 4) == false)
                {
                    return new int[] { 3, 4, 5 };
                }
            }
            else if (CheckSquare(index, 7) == false)
            {
                return new int[] { 6, 7, 8 };
            }
            return new int[0];
        }

        /// <summary>
        /// Returns all the possible indexes where a piece can move to from the passed index vertically
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public int[] GetVerticalPositions(int index)
        {
            if (index % 3 == 0)
            {
                if (CheckSquare(index, 3) == false)
                {
                    return new int[] { 0, 3, 6 };
                }
            }
            else if (index % 3 == 1)
            {
                if (CheckSquare(index, 4) == false)
                {
                    return new int[] { 1, 4, 7 };
                }
            }
            else if (CheckSquare(index, 5) == false)
            {
                return new int[] { 2, 5, 8 };
            }
            return new int[0];
        }

        /// <summary>
        /// Returns all the possible indexes where a piece can move to from the passed index diagonally
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public int[] GetDiagonalPositions(int index)
        {
            switch (index)
            {
                case 0:
                    return new int[] { index + 4, index + 8 };

                case 1:
                case 2:
                    return new int[] { index + 2, index + 4 };

                case 3:
                    return new int[] { index - 2, index + 4 };

                case 4:
                    return new int[] { index - 4, index - 2, index + 2, index + 4 };

                case 5:
                    return new int[] { index - 4, index + 2 };

                case 6:
                case 7:
                    return new int[] { index - 4, index - 2 };

                case 8:
                    return new int[] { index - 8, index - 4 };
            }
            return null;
        }

        /// <summary>
        /// Returns all the possible indexes where a piece can move to if it's a knight
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public int[] GetKnightPositions(int index)
        {
            switch (index)
            {
                case 0:
                case 1:
                    return new int[] { index + 5, index + 7 };

                case 2:
                    return new int[] { index + 1, index + 5 };

                case 3:
                    return new int[] { index - 1, index + 5 };

                case 5:
                    return new int[] { index - 5, index + 1 };

                case 6:
                    return new int[] { index - 5, index - 1 };

                case 7:
                case 8:
                    return new int[] { index - 7, index - 5 };
            }
            return null;
        }

        #endregion

        #endregion

        /// <summary>
        /// Returns there's a piece at the square belonging to the index
        /// </summary>
        /// <param name="currentIndex"></param>
        /// <param name="blockinIndex"></param>
        /// <returns></returns>
        private bool CheckSquare(int currentIndex, int blockinIndex)
        {
            if (currentIndex != blockinIndex)
            {
                if (allSquares[blockinIndex].GetCurrentPiece() != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Updates the square the piece has moved to
        /// </summary>
        /// <param name="indexOfPosition"></param>
        /// <param name="indexOfOldPosition"></param>
        public void UpdatePlaySquare(int indexOfPosition, int indexOfOldPosition)
        {
            Piece currentPiece = allSquares.Where(square => square.GetSquarePosition() == indexOfOldPosition).Select(square => square.GetCurrentPiece()).Single();
            allSquares[indexOfOldPosition].ResetSquare();
            allSquares[indexOfPosition].UpdatePiece(currentPiece);
            CheckBoard();
        }

        /// <summary>
        /// Check is the clicked piece is of the correct color
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool CheckColor(int index)
        {
            Piece currentPiece = allSquares[index].GetCurrentPiece();
            if (currentPiece != null)
            {
                string color = currentPiece.GetPieceColor();
                if (color != null)
                {
                    if (color == currentColor)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        public void ToggleColor()
        {
            if (currentColor == "white")
            {
                currentColor = "black";
            }
            else
            {
                currentColor = "white";
            }
        }

        public string GetCurrentColor()
        {
            return currentColor;
        }

        public void SetConnectedToArm(bool newConnectionStatus)
        {
            connectedToArm = true;
        }

        public bool IsConnectedToArm()
        {
            return connectedToArm;
        }

        /// <summary>
        /// Checks if the game is finished
        /// </summary>
        public void CheckBoard()
        {
            int[] allCurrentPieces = allSquares.Where(square => square.GetCurrentPiece() != null && square.GetCurrentPiece().GetPieceColor() == currentColor).Select(square => square.GetSquarePosition()).ToArray();
            int count = 0;

            foreach (WinPosition winPosition in allWinPositions)
            {
                if (winPosition.GetFirstPosition() == allCurrentPieces[0]
                    && winPosition.GetSecondPosition() == allCurrentPieces[1]
                    && winPosition.GetThirdPosition() == allCurrentPieces[2])
                {
                    if ((count != 0 && currentColor != "white") || count != 2 && currentColor != "black")
                    {
                        gameState = "finished";
                        break;
                    }
                }
                count++;
            }
        }

        #region Arm

        /// <summary>
        /// Get coordinates for the arm
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Tuple<int, int> GetPositionsForArm(int index)
        {
            return allSquares[index].GetArmPositions();
        }

        #endregion

        #endregion

        #region ResetGame

        public void ResetSquares()
        {
            foreach (Square square in allSquares)
            {
                square.ResetSquare();
            }
            currentColor = "white";
            gameState = "setUp";
            allPiecesSet = false;
        }

        #endregion

        #region GameState

        public string GetGameState()
        {
            return gameState;
        }

        #endregion                

        //public void UpdateArmStatus()
        //{
        //    armIsDone = true;
        //}

        public bool IsWaitingForArm()
        {
            return waitingForArm;
        }

        public void UpdateWaitingForArm(bool status)
        {
            waitingForArm = status;
        }
    }
}
