using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TicTacChess_88130
{
    public partial class Board : Form
    {
        GameManagement myGameManagement = null;

        PictureBox currentPictureBox = null;
        PictureBox newPictureBox = null;
        ConnectionForm connectionForm = new ConnectionForm();

        int[] horizontalPositions = new int[] { 320, 400, 570, 850, 900, 1040, 1330, 1400, 1520 };
        int[] rotationPositions = new int[] { 20, 135, 245, 0, 110, 200, 0, 95, 175 };

        public Board()
        {
            InitializeComponent();

            SetUpData();
            PictureBoxesAllowDrop();
        }

        #region StartUp        

        private void SetUpData()
        {
            myGameManagement = new GameManagement();

            SetUpPieces();
            SetUpSquares();
            SetUpWinPositions();
            PictureBoxesAllowDrop();
        }

        /// <summary>
        /// Allows dropping images on the pictureboxes in the board
        /// </summary>
        private void PictureBoxesAllowDrop()
        {
            foreach (PictureBox pictureBox in pnlBoard.Controls.OfType<PictureBox>())
            {
                pictureBox.AllowDrop = true;
            }
        }

        /// <summary>
        /// Defines all the pieces for both colors
        /// </summary>
        private void SetUpPieces()
        {
            string[] pieceTypes = new string[] { "Queen", "Rook", "Knight" };
            string currentColor = "white";

            for (int count = 0; count < 6; count++)
            {
                string pieceType = "";
                if (count < 3)
                {
                    pieceType = pieceTypes[count];
                }
                else
                {
                    pieceType = pieceTypes[count - 3];
                    currentColor = "black";
                }

                Piece newPiece = new Piece(pieceType, currentColor);
                myGameManagement.AddPiece(newPiece);
            }
        }

        /// <summary>
        /// Defines all the squares on the board
        /// </summary>
        private void SetUpSquares()
        {
            for (int count = 0; count < 9; count++)
            {
                Square newSquare = new Square(count, horizontalPositions[count], rotationPositions[count], null);
                myGameManagement.AddSquare(newSquare);
            }
        }

        /// <summary>
        /// Defines all the possible win positions
        /// </summary>
        private void SetUpWinPositions()
        {
            WinPosition newWinposition = new WinPosition(0, 1, 2);
            myGameManagement.AddWinPosition(newWinposition);
            newWinposition = new WinPosition(3, 4, 5);
            myGameManagement.AddWinPosition(newWinposition);
            newWinposition = new WinPosition(6, 7, 8);
            myGameManagement.AddWinPosition(newWinposition);

            newWinposition = new WinPosition(0, 3, 6);
            myGameManagement.AddWinPosition(newWinposition);
            newWinposition = new WinPosition(1, 4, 7);
            myGameManagement.AddWinPosition(newWinposition);
            newWinposition = new WinPosition(2, 5, 8);
            myGameManagement.AddWinPosition(newWinposition);

            newWinposition = new WinPosition(0, 4, 8);
            myGameManagement.AddWinPosition(newWinposition);
            newWinposition = new WinPosition(2, 4, 6);
            myGameManagement.AddWinPosition(newWinposition);
        }

        #endregion

        #region ShowCorrectPieces

        /// <summary>
        /// Depending on which radio button is checked, show the correct colored pieces
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtAny_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtBlack.Checked == true)
            {
                myGameManagement.ChangeColor("black");
                ShowBlackPieces();
            }
            else if (rbtWhite.Checked == true)
            {
                myGameManagement.ChangeColor("white");
                ShowWhitePieces();
            }
        }

        /// <summary>
        /// Shows the white pieces when setting up the board
        /// </summary>
        private void ShowWhitePieces()
        {
            pbxQueen.Image = Properties.Resources.White_queen;
            pbxRook.Image = Properties.Resources.White_rook;
            pbxKnight.Image = Properties.Resources.White_knight;

            CheckAvailablePieces();
        }

        /// <summary>
        /// Shows the black pieces when setting up the board
        /// </summary>
        private void ShowBlackPieces()
        {
            pbxQueen.Image = Properties.Resources.Black_queen;
            pbxRook.Image = Properties.Resources.Black_rook;
            pbxKnight.Image = Properties.Resources.Black_knight;

            CheckAvailablePieces();
        }

        /// <summary>
        /// Resets the background color of the piece pictureboxes and makes the one already placed red.
        /// </summary>
        private void CheckAvailablePieces()
        {
            TogglePiecePictureBoxes("Reset");
            List<Piece> allSetPieces = myGameManagement.GetAllSetPieces();

            foreach (Piece piece in allSetPieces)
            {
                if (piece.GetPieceType().Contains("Queen") == true)
                {
                    pbxQueen.BackColor = Color.Red;
                }
                else if (piece.GetPieceType().Contains("Rook") == true)
                {
                    pbxRook.BackColor = Color.Red;
                }
                else if (piece.GetPieceType().Contains("Knight") == true)
                {
                    pbxKnight.BackColor = Color.Red;
                }
            }
        }

        /// <summary>
        /// Toggle the piece pictureboxes for setting up the board
        /// </summary>
        private void TogglePiecePictureBoxes(string status)
        {
            if (status.Contains("Reset") == true)
            {
                pbxQueen.BackColor = Color.FromArgb(64, 64, 64);
                pbxRook.BackColor = Color.FromArgb(64, 64, 64);
                pbxKnight.BackColor = Color.FromArgb(64, 64, 64);
            }
        }

        #endregion

        #region Moving

        #region EventHandlers

        /// <summary>
        /// Registers when a picturebox for setting up the pieces is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbxAllPieces_MouseDown(object sender, MouseEventArgs e)
        {
            currentPictureBox = (PictureBox)sender;
            if (currentPictureBox.BackColor != Color.Red)
            {
                ShowOpenStartingPositions();
                currentPictureBox.DoDragDrop(currentPictureBox.Image, DragDropEffects.Copy);
            }
        }

        /// <summary>
        /// Makes it possible to copy the image of the selected picturebox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbxSquare_DragOver(object sender, DragEventArgs e)
        {
            newPictureBox = (PictureBox)sender;
            e.Effect = DragDropEffects.Copy;
        }

        /// <summary>
        /// Registers when a picturebox for setting up the pieces is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbxSquare_MouseDown(object sender, MouseEventArgs e)
        {
            if (myGameManagement.GetGameState() == "playing")
            {
                currentPictureBox = (PictureBox)sender;
                int index = GetAllBoardPictureBoxes().FindIndex(pictureBox => pictureBox.Name == currentPictureBox.Name);

                if (myGameManagement.CheckColor(index) == true)
                {
                    if (currentPictureBox.Image != null)
                    {
                        ShowOpenPositions();
                        currentPictureBox.DoDragDrop(currentPictureBox.Image, DragDropEffects.Copy);
                    }
                }
            }
        }

        /// <summary>
        /// Changes the image of the picturebox to the one selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbxSquare_DragDrop(object sender, DragEventArgs e)
        {
            newPictureBox = (PictureBox)sender;

            if (newPictureBox.Image == null && newPictureBox.BackColor == Color.Green)
            {
                if (myGameManagement.GetGameState() == "setUp")
                {
                    currentPictureBox.BackColor = Color.Red;
                    RegisterMove(newPictureBox.Name);
                }
                else
                {
                    currentPictureBox.Image = null;
                    RegisterMove(newPictureBox.Name);
                }

                Image newPicture = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
                newPictureBox.Image = newPicture;
            }

            MakeBoardWhite();
        }

        #endregion

        #region DefaultFunctions

        /// <summary>
        /// Changes the color of the pictureboxes on the board for available starting positions to green
        /// </summary>
        private void ShowOpenStartingPositions()
        {
            List<PictureBox> allBoardPictureBoxes = GetAllBoardPictureBoxes();
            int[] allStartingPositions = myGameManagement.GetOpenStartingPositions();

            foreach (int position in allStartingPositions)
            {
                allBoardPictureBoxes[position].BackColor = Color.Green;
            }
        }

        /// <summary>
        /// Shows all possible positions the chosen piece can move to
        /// </summary>
        private void ShowOpenPositions()
        {
            List<PictureBox> allBoardPictureBoxes = GetAllBoardPictureBoxes();
            int index = allBoardPictureBoxes.FindIndex(pictureBox => pictureBox.Name == currentPictureBox.Name);
            Piece currentPiece = myGameManagement.GetCurrentPiece(index);

            int[] allStartingPositions = myGameManagement.GetAllAvailablePositions(index, currentPiece);

            foreach (int position in allStartingPositions)
            {
                allBoardPictureBoxes[position].BackColor = Color.Green;
            }
        }

        /// <summary>
        /// Returns the index of the picturebox on the board
        /// </summary>
        /// <param name="pictureBoxName"></param>
        /// <returns></returns>
        private int GetIndexOfPictureBox(string pictureBoxName)
        {
            int index = 0;
            foreach (PictureBox pictureBox in GetAllBoardPictureBoxes())
            {
                if (pictureBox.Name == pictureBoxName)
                {
                    return index;
                }
                index++;
            }
            return 0;
        }

        /// <summary>
        /// Assigns the piece to the square in the class
        /// </summary>
        /// <param name="pictureBoxName"></param>
        private void RegisterMove(string pictureBoxName)
        {
            int indexOfNewPictureBox = GetIndexOfPictureBox(pictureBoxName);
            if (myGameManagement.GetGameState() == "setUp")
            {
                myGameManagement.UpdateStartSquare(indexOfNewPictureBox, currentPictureBox.Name);
                if (myGameManagement.CanGameStart() == true)
                {
                    UpdateStatusLabel("ready");
                }
            }
            else if (myGameManagement.GetGameState() == "playing")
            {
                int indexOfOldPictureBox = GetIndexOfPictureBox(currentPictureBox.Name);
                myGameManagement.UpdatePlaySquare(indexOfNewPictureBox, indexOfOldPictureBox);
                OperateArm(indexOfOldPictureBox, indexOfNewPictureBox);
            }
        }

        /// <summary>
        /// Resets the color of the pictureboxes in the board to default color
        /// </summary>
        private void MakeBoardWhite()
        {
            //TODO: Change this possibly
            foreach (PictureBox pictureBox in GetAllBoardPictureBoxes())
            {
                pictureBox.BackColor = Color.White;
            }
        }

        #endregion

        #endregion

        #region Restart

        private void btnRestartGame_Click(object sender, EventArgs e)
        {
            RestartSquares();

            foreach (PictureBox square in pnlBoard.Controls)
            {
                square.Image = null;
                square.BackColor = Color.White;
            }

            lblGameStatus.Text = "Set up board";
            rbtWhite.Checked = true;
        }

        /// <summary>
        /// Resets the whole board and classes
        /// </summary>
        private void RestartSquares()
        {
            myGameManagement.ResetSquares();
            TogglePiecePictureBoxes("Reset");
        }

        #endregion

        #region GlobalFunctions

        /// <summary>
        /// Returns all pictureboxes in the board
        /// </summary>
        /// <returns></returns>
        private List<PictureBox> GetAllBoardPictureBoxes()
        {
            List<PictureBox> allBoardPictureBoxes = new List<PictureBox>();
            foreach (PictureBox pictureBox in pnlBoard.Controls)
            {
                allBoardPictureBoxes.Add(pictureBox);
            }
            return allBoardPictureBoxes;
        }

        /// <summary>
        /// Updates the status label
        /// </summary>
        /// <param name="status"></param>
        private void UpdateStatusLabel(string status)
        {
            string statusBegin = "";
            string statusEnd = "to play";
            string color = myGameManagement.GetCurrentColor();

            switch (status)
            {
                case "ready":
                    myGameManagement.ChangeColor("white");
                    statusBegin = char.ToUpper(color[0]) + color.Substring(1);
                    break;

                case "moved":
                    if (myGameManagement.GetCurrentColor() == "white")
                    {
                        myGameManagement.ChangeColor("black");
                    }
                    else
                    {
                        myGameManagement.ChangeColor("white");
                    }
                    statusBegin = char.ToUpper(color[0]) + color.Substring(1);
                    break;

                case "waiting":
                    if (lblGameStatus.Text.Contains("..."))
                    {
                        statusEnd = "Waiting for arm.";
                    }
                    if (lblGameStatus.Text.Contains(".."))
                    {
                        statusEnd = "Waiting for arm...";
                    }
                    if (lblGameStatus.Text.Contains("..."))
                    {
                        statusEnd = "Waiting for arm.";
                    }
                    break;

                case "finished":
                    statusEnd = " has won the game!";
                    break;
            }
                        
            lblGameStatus.Text = $"{statusBegin} {statusEnd}";
        }

        #endregion

        #region OpenConnectionForm       

        /// <summary>
        /// Shows and hides the connection form with the use of a checkbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxMakeConnection_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxMakeConnection.Checked == true)
            {
                connectionForm.Show();
            }
            else
            {
                connectionForm.Hide();
            }
        }

        #region ArmFunctions

        /// <summary>
        /// Sends the coordinates to the connection form for the arm to work
        /// </summary>
        /// <param name="oldPosition"></param>
        /// <param name="newPosition"></param>
        private void OperateArm(int oldPosition, int newPosition)
        {
            Tuple<int, int> previousArmPositions = myGameManagement.GetPositionsForArm(oldPosition);
            Tuple<int, int> newArmPositions = myGameManagement.GetPositionsForArm(newPosition);

            connectionForm.AddCommands(previousArmPositions, newArmPositions);
            myGameManagement.UpdateWaitingForArm(true);
            ToggleBoard("disable");
        }

        #endregion

        #endregion

        #region Exit

        private void btnExitApplication_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

        private void timerArm_Tick(object sender, EventArgs e)
        {
            if (connectionForm.GetArmStatus() == true && myGameManagement.IsWaitingForArm() == true)
            {
                if (myGameManagement.GetGameState() == "finished")
                {
                    UpdateStatusLabel("finished");
                }
                else
                {
                    UpdateStatusLabel("moved");
                }
                myGameManagement.UpdateArmStatus();
                myGameManagement.UpdateWaitingForArm(false);
                ToggleBoard("enable");
            }
            else if (myGameManagement.IsWaitingForArm() == true)
            {
                UpdateStatusLabel("moved");
            }
        }

        private void ToggleBoard(string status)
        {
            bool enable = true;
            if (status == "disable")
            {
                enable = false;
            }

            List<PictureBox> allSquares = GetAllBoardPictureBoxes();
            foreach (PictureBox pictureBox in allSquares)
            {
                pictureBox.Enabled = enable;
            }
        }
    }
}
