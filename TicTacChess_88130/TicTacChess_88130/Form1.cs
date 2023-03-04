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

        string currentColor = "White";

        PictureBox currentPictureBox = null;
        PictureBox newPictureBox = null;        

        public Form1()
        {
            InitializeComponent();
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
        
        #region ShowCorrectPieces

        private void rbtAny_CheckedChanged(object sender, EventArgs e)        
        {
            if (rbtBlack.Checked == true)
            {
                currentColor = "Black";
                ShowBlackPieces();
            }
            else if (rbtWhite.Checked == true)
            {
                currentColor = "White";
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

        private void ShowPossibleSpaces()
        {
            if (currentColor == "White")
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
