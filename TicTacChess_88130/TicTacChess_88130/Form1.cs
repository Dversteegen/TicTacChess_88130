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
            SetUpPlayers();
        }

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

        private void SetUpPlayers()
        {
            Player newPlayer = new Player(myGameManagement.GetPiecesOfColor("White"));
            myGameManagement.AddPlayer(newPlayer);

            newPlayer = new Player(myGameManagement.GetPiecesOfColor("Black"));
            myGameManagement.AddPlayer(newPlayer);
        }

        #endregion

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
        }

        /// <summary>
        /// Shows the black pieces when setting up the board
        /// </summary>
        private void ShowBlackPieces()
        {
            pbxQueen.Image = Properties.Resources.Black_queen;
            pbxRook.Image = Properties.Resources.Black_rook;
            pbxKnight.Image = Properties.Resources.Black_knight;
        }

        #endregion

        #region SetupBoard

        #region EventHandlers

        /// <summary>
        /// Registers when a picturebox for setting up the pieces is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pcbAllPieces_MouseDown(object sender, MouseEventArgs e)
        {           
            currentPictureBox = (PictureBox)sender;
            if( currentPictureBox.BackColor != Color.Red)
            {
                ShowOpenPositions();
                currentPictureBox.DoDragDrop(currentPictureBox.Image, DragDropEffects.Copy);
            }            
        }

        /// <summary>
        /// Changes the image of the picturebox to the one selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pcbBoard_DragDrop(object sender, DragEventArgs e)
        {            
            newPictureBox = (PictureBox)sender;

            if (newPictureBox.Image == null)
            {
                currentPictureBox.BackColor = Color.Red;

                Image newPicture = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
                newPictureBox.Image = newPicture;
            }            
        }

        /// <summary>
        /// Makes it possible to copy the image of the selected picturebox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pcbBoard_DragOver(object sender, DragEventArgs e)
        {
            newPictureBox = (PictureBox)sender;
            e.Effect = DragDropEffects.Copy;
        }

        #endregion

        #region DefaultFunctions

        private void ShowOpenPositions()
        {
            int[] allStartingPositions =  myGameManagement.GetStartingPositions();
            foreach (int position in allStartingPositions)
            {

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
