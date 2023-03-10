using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacChess_88130
{
    public partial class Form1 : Form
    {
        GameManagement myGameManagement;

        PictureBox currentPictureBox = null;
        PictureBox newPictureBox = null;

        public Form1()
        {
            InitializeComponent();

            SetUpData();
            PictureBoxesAllowDrop();
        }

        #region StartUp

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

        private void SetUpData()
        {
            myGameManagement = new GameManagement();

            SetUpPieces();
            SetUpSquares();
            //SetUpPlayers();            
        }

        /// <summary>
        /// Defines all the pieces for both colors
        /// </summary>
        private void SetUpPieces()
        {
            string[] pieceTypes = new string[] { "Queen", "Rook", "Knight" };
            int[] startingPositions = new int[] { 1, 2, 3 };

            string currentColor = "White";

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
                    currentColor = "Black";
                    startingPositions = new int[] { 7, 8, 9 };
                }

                Piece newPiece = new Piece(pieceType, currentColor, startingPositions);
                myGameManagement.AddPiece(newPiece);
            }
        }

        /// <summary>
        /// Defines both players
        /// </summary>
        private void SetUpPlayers()
        {
            //Player newPlayer = new Player(myGameManagement.GetPiecesOfColor("White"));
            //myGameManagement.AddPlayer(newPlayer);

            //newPlayer = new Player(myGameManagement.GetPiecesOfColor("Black"));
            //myGameManagement.AddPlayer(newPlayer);
        }

        /// <summary>
        /// Defines all the squares on the board
        /// </summary>
        private void SetUpSquares()
        {
            for (int count = 0; count < 9; count++)
            {
                Square newSquare = new Square(count, null);
                myGameManagement.AddSquare(newSquare);
            }
        }

        #endregion                

        #region SetupBoard

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
        /// Changes the image of the picturebox to the one selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbxSquare_DragDrop(object sender, DragEventArgs e)
        {
            newPictureBox = (PictureBox)sender;

            if (newPictureBox.Image == null && newPictureBox.BackColor == Color.Green)
            {
                currentPictureBox.BackColor = Color.Red;
                RegisterMove(newPictureBox.Name);
                Image newPicture = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
                newPictureBox.Image = newPicture;
            }
            MakeBoardWhite();
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

        #endregion

        #region DefaultFunctions

        #region ShowCorrectPieces

        private void rbtAny_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtBlack.Checked == true)
            {
                myGameManagement.ChangeColor("Black");
                ShowBlackPieces();
            }
            else if (rbtWhite.Checked == true)
            {
                myGameManagement.ChangeColor("White");
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

        #endregion

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

        /// <summary>
        /// Assigns the piece to the square in the class
        /// </summary>
        /// <param name="pictureBoxName"></param>
        private void RegisterMove(string pictureBoxName)
        {
            int indexOfPictureBox = GetIndexOfPictureBox(pictureBoxName);
            myGameManagement.UpdateSquare(indexOfPictureBox, currentPictureBox.Name);
            if (myGameManagement.CanGameStart() == true)
            {
                UpdateStatusLabel();
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

        private void UpdateStatusLabel()
        {
            lblGameStatus.Text = "White play";
            //TODO: Do something about the color maybe
        }

        #endregion

        #endregion

        #region GeneralFunctions

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

        #region Playing

        /// <summary>
        /// Registers when a picturebox for setting up the pieces is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbxSquare_MouseDown(object sender, MouseEventArgs e)
        {
            currentPictureBox = (PictureBox)sender;
            if (currentPictureBox.BackColor != Color.Red)
            {
                //ShowOpenStartingPositions();
                currentPictureBox.DoDragDrop(currentPictureBox.Image, DragDropEffects.Copy);
            }
        }

        private void ShowAvailablePositions()
        {
            List<PictureBox> allBoardPictureBoxes = GetAllBoardPictureBoxes();
            int[] allStartingPositions = myGameManagement.GetAllAvailablePositions();

            foreach (int position in allStartingPositions)
            {
                allBoardPictureBoxes[position].BackColor = Color.Green;
            }
        }

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

        private void RestartSquares()
        {
            myGameManagement.ResetSquares();
            TogglePiecePictureBoxes("Reset");
        }

        #endregion

        #region Exit

        private void btnExitApplication_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion        
    }
}
