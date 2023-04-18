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
            foreach (PictureBox pictureBox in GetAllBoardPictureBoxes())
            {
                pictureBox.AllowDrop = true;
            }
        }

        /// <summary>
        /// Defines all the pieces for both colors
        /// </summary>
        private void SetUpPieces()
        {
            string[] pieceTypes = new string[] { "Queen", "Rook", "Knight", "King", "Wizard" };
            Bitmap[] pieceImages = new Bitmap[] {
                Properties.Resources.White_king,
            Properties.Resources.White_rook,
            Properties.Resources.White_knight,
            Properties.Resources.White_queen,
            Properties.Resources.White_wizard,
            Properties.Resources.Black_king,
            Properties.Resources.Black_rook,
            Properties.Resources.Black_knight,
            Properties.Resources.Black_queen,
            Properties.Resources.Black_wizard, };
            string currentColor = "white";

            for (int count = 0; count < 10; count++)
            {
                string pieceType = "";
                if (count < 5)
                {
                    pieceType = pieceTypes[count];
                }
                else
                {
                    pieceType = pieceTypes[count - 5];
                    currentColor = "black";
                }

                Piece newPiece = new Piece(pieceType, currentColor, pieceImages[count]);
                myGameManagement.AddPiece(newPiece);
            }
        }

        /// <summary>
        /// Defines all the squares on the board
        /// </summary>
        private void SetUpSquares()
        {
            myGameManagement.AddSquare(new Square(0, new int[] { 1 }, 320, 20, null));
            myGameManagement.AddSquare(new Square(1, new int[] { 1, 2 }, 400, 135, null));
            myGameManagement.AddSquare(new Square(2, new int[] { 2 }, 570, 245, null));
            myGameManagement.AddSquare(new Square(3, new int[] { 1, 3 }, 850, 0, null));
            myGameManagement.AddSquare(new Square(4, new int[] { 1, 2, 3, 4 }, 900, 110, null));
            myGameManagement.AddSquare(new Square(5, new int[] { 2, 4 }, 1040, 200, null));
            myGameManagement.AddSquare(new Square(6, new int[] { 3 }, 1330, 0, null));
            myGameManagement.AddSquare(new Square(7, new int[] { 3, 4 }, 1400, 95, null));
            myGameManagement.AddSquare(new Square(8, new int[] { 4 }, 1520, 175, null));
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
            pbxKing.Image = Properties.Resources.White_king;
            pbxWizard.Image = Properties.Resources.White_wizard;
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
            pbxKing.Image = Properties.Resources.Black_king;
            pbxWizard.Image = Properties.Resources.Black_wizard;
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
                else if (piece.GetPieceType().Contains("King") == true)
                {
                    pbxKing.BackColor = Color.Red;
                }
                else if (piece.GetPieceType().Contains("Wizard") == true)
                {
                    pbxWizard.BackColor = Color.Red;
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
                pbxKing.BackColor = Color.FromArgb(64, 64, 64);
                pbxWizard.BackColor = Color.FromArgb(64, 64, 64);
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

                if ((myGameManagement.CheckColor(index) == true && currentPictureBox.BackColor == Color.FromArgb(64, 64, 64)) || 
                    (currentPictureBox.Image != null && currentPictureBox.BackColor == Color.Green))
                    //If a picturebox has no image but the color is green, you can still drag it
                {
                    if (currentPictureBox.Image != null)
                    {
                        MakeBoardWhite();
                        DisplayCurrentTurn();
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

            if (newPictureBox.BackColor == Color.Green)
            {
                if (myGameManagement.GetGameState() == "setUp")
                {
                    Image newPicture = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
                    newPictureBox.Image = newPicture;
                    RegisterMove(newPictureBox.Name);
                    currentPictureBox.BackColor = Color.Red;
                }
                else
                {
                    if (newPictureBox.Image != null)
                    {
                        SwapPieces();
                        string status = myGameManagement.GetGameState() == "finished" ? "finished" : "moved";
                        UpdateStatusLabel(status);
                    }
                    else
                    {
                        currentPictureBox.Image = null;
                        Image newPicture = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
                        newPictureBox.Image = newPicture;
                        RegisterMove(newPictureBox.Name);
                    }
                }

                MakeBoardWhite();
                DisplayCurrentTurn();
            }
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
                    if (connectionForm.IsArmDone() == true)
                    {
                        UpdateStatusLabel("ready");
                    }
                    else
                    {
                        myGameManagement.UpdateWaitingForArm(true);
                        myGameManagement.ChangeGameState("ready");
                        UpdateStatusLabel("waiting");
                    }
                }
            }
            else if (myGameManagement.GetGameState() == "playing")
            {
                int indexOfOldPictureBox = GetIndexOfPictureBox(currentPictureBox.Name);
                myGameManagement.UpdatePlaySquare(indexOfNewPictureBox, indexOfOldPictureBox);
                if (myGameManagement.IsConnectedToArm())
                {
                    OperateArm(indexOfOldPictureBox, indexOfNewPictureBox);
                }
                else
                {
                    string status = myGameManagement.GetGameState() == "finished" ? "finished" : "moved";
                    UpdateStatusLabel(status);
                }
            }
        }

        /// <summary>
        /// Gives the board its default color
        /// </summary>
        private void MakeBoardWhite()
        {
            foreach (PictureBox pictureBox in GetAllBoardPictureBoxes())
            {
                pictureBox.BackColor = Color.FromArgb(128, 128, 128);
            }
        }

        /// <summary>
        /// Swaps the pieces based on the index of the pictureboxes
        /// </summary>
        private void SwapPieces()
        {
            int indexOfNewPictureBox = GetIndexOfPictureBox(newPictureBox.Name);
            int indexOfOldPictureBox = GetIndexOfPictureBox(currentPictureBox.Name);

            Tuple<Bitmap, Bitmap> swappedPieces = myGameManagement.SwapPieces(indexOfOldPictureBox, indexOfNewPictureBox);
            currentPictureBox.Image = swappedPieces.Item2;
            newPictureBox.Image = swappedPieces.Item1;
        }

        /// <summary>
        /// Gives the squares of the play who's turn it is a color
        /// </summary>
        private void DisplayCurrentTurn()
        {
            if ((myGameManagement.GetGameState() == "playing" || myGameManagement.GetGameState() == "ready") && (myGameManagement.IsConnectedToArm() == false || connectionForm.IsArmDone()))
            {
                int count = 0;
                foreach (PictureBox pictureBox in GetAllBoardPictureBoxes())
                {
                    if (myGameManagement.CheckColor(count))
                    {
                        pictureBox.BackColor = Color.FromArgb(64, 64, 64);
                    }
                    else
                    {
                        pictureBox.BackColor = Color.FromArgb(128, 128, 128);
                    }
                    count++;
                }
            }
        }

        #endregion

        #endregion

        #region Restart

        //Restarts the game
        private void btnRestartGame_Click(object sender, EventArgs e)
        {
            RestartSquares();

            foreach (PictureBox square in pnlBoard.Controls)
            {
                square.Image = null;
                square.BackColor = Color.FromArgb(128, 128, 128);
            }

            lblGameStatus.Text = "Set up board";
            rbtWhite.Checked = true;
            rbtWhite.Enabled = true;
            rbtBlack.Enabled = true;

            if (myGameManagement.IsConnectedToArm())
            {
                tmrArm.Enabled = true;
            }
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

            switch (status)
            {
                case "ready":
                    myGameManagement.ChangeColor("white");
                    lblGameStatus.Text = $"White {statusEnd}";
                    rbtWhite.Checked = true;
                    rbtWhite.Enabled = false;
                    rbtBlack.Enabled = false;
                    MakeBoardWhite();
                    DisplayCurrentTurn();
                    myGameManagement.ChangeGameState("playing");
                    break;

                case "moved":
                    myGameManagement.ToggleColor();
                    DisplayCurrentTurn();
                    string color = myGameManagement.GetCurrentColor();
                    statusBegin = char.ToUpper(color[0]) + color.Substring(1);
                    lblGameStatus.Text = $"{statusBegin} {statusEnd}";
                    break;

                case "waiting":
                    statusEnd = GetWaitingText();
                    lblGameStatus.Text = $"{statusBegin} {statusEnd}";
                    break;

                case "finished":
                    ShowMessageBox();
                    break;
            }
        }

        /// <summary>
        /// Generate the waiting text when waiting for the arm
        /// </summary>
        /// <returns></returns>
        private string GetWaitingText()
        {
            string status = "Waiting";
            for (int count = 0; count < myGameManagement.GetDotCount(); count++)
            {
                status += ".";
            }
            myGameManagement.IncreaseDotCount();
            return status;
        }

        /// <summary>
        /// Shows the messagebox with the winner
        /// </summary>
        private void ShowMessageBox()
        {
            tmrArm.Enabled = false;
            string color = myGameManagement.GetCurrentColor();
            color = char.ToUpper(color[0]) + color.Substring(1);
            lblGameStatus.Text = $"{color} won!!";
            MessageBox.Show($"{color} won!!");
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
                tmrArm.Enabled = true;
                myGameManagement.SetConnectedToArm(true);
                connectionForm.Show();
            }
            else
            {
                tmrArm.Enabled = false;
                myGameManagement.SetConnectedToArm(false);
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

            myGameManagement.UpdateWaitingForArm(true);
            connectionForm.AddCommands(previousArmPositions, newArmPositions);
        }

        /// <summary>
        /// Does something when the arm is done moving
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrArm_Tick(object sender, EventArgs e)
        {
            if (connectionForm.IsArmDone() == true && myGameManagement.IsWaitingForArm() == true)
            {
                if (myGameManagement.GetGameState() == "ready")
                {
                    UpdateStatusLabel("ready");
                }
                else if (myGameManagement.GetGameState() == "finished")
                {
                    UpdateStatusLabel("finished");
                }
                else
                {
                    UpdateStatusLabel("moved");
                }
                myGameManagement.UpdateWaitingForArm(false);
            }
            else if (myGameManagement.IsWaitingForArm() == true)
            {
                UpdateStatusLabel("waiting");
            }
        }

        #endregion

        #endregion

        #region Exit

        private void btnExitApplication_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion               
    }
}
