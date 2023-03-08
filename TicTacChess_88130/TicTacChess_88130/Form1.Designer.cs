
namespace TicTacChess_88130
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbxRook = new System.Windows.Forms.PictureBox();
            this.pbxKnight = new System.Windows.Forms.PictureBox();
            this.pbxQueen = new System.Windows.Forms.PictureBox();
            this.pbxOne = new System.Windows.Forms.PictureBox();
            this.rbtBlack = new System.Windows.Forms.RadioButton();
            this.rbtWhite = new System.Windows.Forms.RadioButton();
            this.gbxBoard = new System.Windows.Forms.GroupBox();
            this.pnlBoard = new System.Windows.Forms.Panel();
            this.pbxNine = new System.Windows.Forms.PictureBox();
            this.pbxEight = new System.Windows.Forms.PictureBox();
            this.pbxSeven = new System.Windows.Forms.PictureBox();
            this.pbxSix = new System.Windows.Forms.PictureBox();
            this.pbxFive = new System.Windows.Forms.PictureBox();
            this.pbxFour = new System.Windows.Forms.PictureBox();
            this.pbxThree = new System.Windows.Forms.PictureBox();
            this.pbxTwo = new System.Windows.Forms.PictureBox();
            this.btnExitApplication = new System.Windows.Forms.Button();
            this.btnRestartGame = new System.Windows.Forms.Button();
            this.lblGameStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbxRook)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxKnight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxQueen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxOne)).BeginInit();
            this.gbxBoard.SuspendLayout();
            this.pnlBoard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxNine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxEight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxSeven)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxSix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxFive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxFour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxThree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxTwo)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxRook
            // 
            this.pbxRook.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pbxRook.Image = global::TicTacChess_88130.Properties.Resources.White_rook;
            this.pbxRook.Location = new System.Drawing.Point(15, 268);
            this.pbxRook.Margin = new System.Windows.Forms.Padding(5);
            this.pbxRook.Name = "pbxRook";
            this.pbxRook.Size = new System.Drawing.Size(150, 150);
            this.pbxRook.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxRook.TabIndex = 3;
            this.pbxRook.TabStop = false;
            this.pbxRook.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbxAllPieces_MouseDown);
            // 
            // pbxKnight
            // 
            this.pbxKnight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pbxKnight.Image = global::TicTacChess_88130.Properties.Resources.White_knight;
            this.pbxKnight.Location = new System.Drawing.Point(15, 428);
            this.pbxKnight.Margin = new System.Windows.Forms.Padding(5);
            this.pbxKnight.Name = "pbxKnight";
            this.pbxKnight.Size = new System.Drawing.Size(150, 150);
            this.pbxKnight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxKnight.TabIndex = 2;
            this.pbxKnight.TabStop = false;
            this.pbxKnight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbxAllPieces_MouseDown);
            // 
            // pbxQueen
            // 
            this.pbxQueen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pbxQueen.Image = global::TicTacChess_88130.Properties.Resources.White_queen;
            this.pbxQueen.Location = new System.Drawing.Point(15, 108);
            this.pbxQueen.Margin = new System.Windows.Forms.Padding(5);
            this.pbxQueen.Name = "pbxQueen";
            this.pbxQueen.Size = new System.Drawing.Size(150, 150);
            this.pbxQueen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxQueen.TabIndex = 1;
            this.pbxQueen.TabStop = false;
            this.pbxQueen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbxAllPieces_MouseDown);
            // 
            // pbxOne
            // 
            this.pbxOne.BackColor = System.Drawing.Color.White;
            this.pbxOne.Location = new System.Drawing.Point(5, 5);
            this.pbxOne.Margin = new System.Windows.Forms.Padding(5);
            this.pbxOne.Name = "pbxOne";
            this.pbxOne.Size = new System.Drawing.Size(150, 150);
            this.pbxOne.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxOne.TabIndex = 0;
            this.pbxOne.TabStop = false;
            this.pbxOne.DragDrop += new System.Windows.Forms.DragEventHandler(this.pbxSquare_DragDrop);
            this.pbxOne.DragOver += new System.Windows.Forms.DragEventHandler(this.pbxSquare_DragOver);
            // 
            // rbtBlack
            // 
            this.rbtBlack.AutoSize = true;
            this.rbtBlack.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtBlack.ForeColor = System.Drawing.Color.White;
            this.rbtBlack.Location = new System.Drawing.Point(15, 62);
            this.rbtBlack.Margin = new System.Windows.Forms.Padding(5);
            this.rbtBlack.Name = "rbtBlack";
            this.rbtBlack.Size = new System.Drawing.Size(121, 38);
            this.rbtBlack.TabIndex = 4;
            this.rbtBlack.Text = "Black";
            this.rbtBlack.UseVisualStyleBackColor = true;
            this.rbtBlack.CheckedChanged += new System.EventHandler(this.rbtAny_CheckedChanged);
            // 
            // rbtWhite
            // 
            this.rbtWhite.AutoSize = true;
            this.rbtWhite.Checked = true;
            this.rbtWhite.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtWhite.ForeColor = System.Drawing.Color.White;
            this.rbtWhite.Location = new System.Drawing.Point(15, 14);
            this.rbtWhite.Margin = new System.Windows.Forms.Padding(5);
            this.rbtWhite.Name = "rbtWhite";
            this.rbtWhite.Size = new System.Drawing.Size(130, 38);
            this.rbtWhite.TabIndex = 5;
            this.rbtWhite.TabStop = true;
            this.rbtWhite.Text = "White";
            this.rbtWhite.UseVisualStyleBackColor = true;
            this.rbtWhite.CheckedChanged += new System.EventHandler(this.rbtAny_CheckedChanged);
            // 
            // gbxBoard
            // 
            this.gbxBoard.BackColor = System.Drawing.Color.Transparent;
            this.gbxBoard.Controls.Add(this.pnlBoard);
            this.gbxBoard.ForeColor = System.Drawing.Color.White;
            this.gbxBoard.Location = new System.Drawing.Point(208, 72);
            this.gbxBoard.Name = "gbxBoard";
            this.gbxBoard.Size = new System.Drawing.Size(491, 522);
            this.gbxBoard.TabIndex = 6;
            this.gbxBoard.TabStop = false;
            this.gbxBoard.Text = "Board";
            // 
            // pnlBoard
            // 
            this.pnlBoard.BackColor = System.Drawing.Color.Black;
            this.pnlBoard.Controls.Add(this.pbxNine);
            this.pnlBoard.Controls.Add(this.pbxEight);
            this.pnlBoard.Controls.Add(this.pbxSeven);
            this.pnlBoard.Controls.Add(this.pbxSix);
            this.pnlBoard.Controls.Add(this.pbxFive);
            this.pnlBoard.Controls.Add(this.pbxFour);
            this.pnlBoard.Controls.Add(this.pbxThree);
            this.pnlBoard.Controls.Add(this.pbxTwo);
            this.pnlBoard.Controls.Add(this.pbxOne);
            this.pnlBoard.Location = new System.Drawing.Point(6, 31);
            this.pnlBoard.Name = "pnlBoard";
            this.pnlBoard.Size = new System.Drawing.Size(480, 485);
            this.pnlBoard.TabIndex = 0;
            // 
            // pbxNine
            // 
            this.pbxNine.BackColor = System.Drawing.Color.White;
            this.pbxNine.Location = new System.Drawing.Point(325, 325);
            this.pbxNine.Margin = new System.Windows.Forms.Padding(5);
            this.pbxNine.Name = "pbxNine";
            this.pbxNine.Size = new System.Drawing.Size(150, 150);
            this.pbxNine.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxNine.TabIndex = 8;
            this.pbxNine.TabStop = false;
            this.pbxNine.DragDrop += new System.Windows.Forms.DragEventHandler(this.pbxSquare_DragDrop);
            this.pbxNine.DragOver += new System.Windows.Forms.DragEventHandler(this.pbxSquare_DragOver);
            // 
            // pbxEight
            // 
            this.pbxEight.BackColor = System.Drawing.Color.White;
            this.pbxEight.Location = new System.Drawing.Point(165, 325);
            this.pbxEight.Margin = new System.Windows.Forms.Padding(5);
            this.pbxEight.Name = "pbxEight";
            this.pbxEight.Size = new System.Drawing.Size(150, 150);
            this.pbxEight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxEight.TabIndex = 7;
            this.pbxEight.TabStop = false;
            this.pbxEight.DragDrop += new System.Windows.Forms.DragEventHandler(this.pbxSquare_DragDrop);
            this.pbxEight.DragOver += new System.Windows.Forms.DragEventHandler(this.pbxSquare_DragOver);
            // 
            // pbxSeven
            // 
            this.pbxSeven.BackColor = System.Drawing.Color.White;
            this.pbxSeven.Location = new System.Drawing.Point(5, 325);
            this.pbxSeven.Margin = new System.Windows.Forms.Padding(5);
            this.pbxSeven.Name = "pbxSeven";
            this.pbxSeven.Size = new System.Drawing.Size(150, 150);
            this.pbxSeven.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxSeven.TabIndex = 6;
            this.pbxSeven.TabStop = false;
            this.pbxSeven.DragDrop += new System.Windows.Forms.DragEventHandler(this.pbxSquare_DragDrop);
            this.pbxSeven.DragOver += new System.Windows.Forms.DragEventHandler(this.pbxSquare_DragOver);
            // 
            // pbxSix
            // 
            this.pbxSix.BackColor = System.Drawing.Color.White;
            this.pbxSix.Location = new System.Drawing.Point(325, 165);
            this.pbxSix.Margin = new System.Windows.Forms.Padding(5);
            this.pbxSix.Name = "pbxSix";
            this.pbxSix.Size = new System.Drawing.Size(150, 150);
            this.pbxSix.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxSix.TabIndex = 5;
            this.pbxSix.TabStop = false;
            this.pbxSix.DragDrop += new System.Windows.Forms.DragEventHandler(this.pbxSquare_DragDrop);
            this.pbxSix.DragOver += new System.Windows.Forms.DragEventHandler(this.pbxSquare_DragOver);
            // 
            // pbxFive
            // 
            this.pbxFive.BackColor = System.Drawing.Color.White;
            this.pbxFive.Location = new System.Drawing.Point(165, 165);
            this.pbxFive.Margin = new System.Windows.Forms.Padding(5);
            this.pbxFive.Name = "pbxFive";
            this.pbxFive.Size = new System.Drawing.Size(150, 150);
            this.pbxFive.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxFive.TabIndex = 4;
            this.pbxFive.TabStop = false;
            this.pbxFive.DragDrop += new System.Windows.Forms.DragEventHandler(this.pbxSquare_DragDrop);
            this.pbxFive.DragOver += new System.Windows.Forms.DragEventHandler(this.pbxSquare_DragOver);
            // 
            // pbxFour
            // 
            this.pbxFour.BackColor = System.Drawing.Color.White;
            this.pbxFour.Location = new System.Drawing.Point(5, 165);
            this.pbxFour.Margin = new System.Windows.Forms.Padding(5);
            this.pbxFour.Name = "pbxFour";
            this.pbxFour.Size = new System.Drawing.Size(150, 150);
            this.pbxFour.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxFour.TabIndex = 3;
            this.pbxFour.TabStop = false;
            this.pbxFour.DragDrop += new System.Windows.Forms.DragEventHandler(this.pbxSquare_DragDrop);
            this.pbxFour.DragOver += new System.Windows.Forms.DragEventHandler(this.pbxSquare_DragOver);
            // 
            // pbxThree
            // 
            this.pbxThree.BackColor = System.Drawing.Color.White;
            this.pbxThree.Location = new System.Drawing.Point(325, 5);
            this.pbxThree.Margin = new System.Windows.Forms.Padding(5);
            this.pbxThree.Name = "pbxThree";
            this.pbxThree.Size = new System.Drawing.Size(150, 150);
            this.pbxThree.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxThree.TabIndex = 2;
            this.pbxThree.TabStop = false;
            this.pbxThree.DragDrop += new System.Windows.Forms.DragEventHandler(this.pbxSquare_DragDrop);
            this.pbxThree.DragOver += new System.Windows.Forms.DragEventHandler(this.pbxSquare_DragOver);
            // 
            // pbxTwo
            // 
            this.pbxTwo.BackColor = System.Drawing.Color.White;
            this.pbxTwo.Location = new System.Drawing.Point(165, 5);
            this.pbxTwo.Margin = new System.Windows.Forms.Padding(5);
            this.pbxTwo.Name = "pbxTwo";
            this.pbxTwo.Size = new System.Drawing.Size(150, 150);
            this.pbxTwo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxTwo.TabIndex = 1;
            this.pbxTwo.TabStop = false;
            this.pbxTwo.DragDrop += new System.Windows.Forms.DragEventHandler(this.pbxSquare_DragDrop);
            this.pbxTwo.DragOver += new System.Windows.Forms.DragEventHandler(this.pbxSquare_DragOver);
            // 
            // btnExitApplication
            // 
            this.btnExitApplication.BackColor = System.Drawing.Color.Maroon;
            this.btnExitApplication.ForeColor = System.Drawing.Color.White;
            this.btnExitApplication.Location = new System.Drawing.Point(559, 624);
            this.btnExitApplication.Name = "btnExitApplication";
            this.btnExitApplication.Size = new System.Drawing.Size(140, 47);
            this.btnExitApplication.TabIndex = 7;
            this.btnExitApplication.Text = "Exit";
            this.btnExitApplication.UseVisualStyleBackColor = false;
            this.btnExitApplication.Click += new System.EventHandler(this.btnExitApplication_Click);
            // 
            // btnRestartGame
            // 
            this.btnRestartGame.BackColor = System.Drawing.Color.Navy;
            this.btnRestartGame.ForeColor = System.Drawing.Color.White;
            this.btnRestartGame.Location = new System.Drawing.Point(15, 624);
            this.btnRestartGame.Name = "btnRestartGame";
            this.btnRestartGame.Size = new System.Drawing.Size(140, 47);
            this.btnRestartGame.TabIndex = 9;
            this.btnRestartGame.Text = "Restart";
            this.btnRestartGame.UseVisualStyleBackColor = false;
            this.btnRestartGame.Click += new System.EventHandler(this.btnRestartGame_Click);
            // 
            // lblGameStatus
            // 
            this.lblGameStatus.AutoSize = true;
            this.lblGameStatus.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameStatus.ForeColor = System.Drawing.Color.White;
            this.lblGameStatus.Location = new System.Drawing.Point(338, 35);
            this.lblGameStatus.Name = "lblGameStatus";
            this.lblGameStatus.Size = new System.Drawing.Size(219, 34);
            this.lblGameStatus.TabIndex = 10;
            this.lblGameStatus.Text = "Set up board";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(722, 685);
            this.ControlBox = false;
            this.Controls.Add(this.lblGameStatus);
            this.Controls.Add(this.btnRestartGame);
            this.Controls.Add(this.btnExitApplication);
            this.Controls.Add(this.gbxBoard);
            this.Controls.Add(this.rbtWhite);
            this.Controls.Add(this.rbtBlack);
            this.Controls.Add(this.pbxRook);
            this.Controls.Add(this.pbxKnight);
            this.Controls.Add(this.pbxQueen);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "rrrr";
            ((System.ComponentModel.ISupportInitialize)(this.pbxRook)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxKnight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxQueen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxOne)).EndInit();
            this.gbxBoard.ResumeLayout(false);
            this.pnlBoard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxNine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxEight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxSeven)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxSix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxFive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxFour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxThree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxTwo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxOne;
        private System.Windows.Forms.PictureBox pbxQueen;
        private System.Windows.Forms.PictureBox pbxKnight;
        private System.Windows.Forms.PictureBox pbxRook;
        private System.Windows.Forms.RadioButton rbtBlack;
        private System.Windows.Forms.RadioButton rbtWhite;
        private System.Windows.Forms.GroupBox gbxBoard;
        private System.Windows.Forms.Panel pnlBoard;
        private System.Windows.Forms.PictureBox pbxNine;
        private System.Windows.Forms.PictureBox pbxEight;
        private System.Windows.Forms.PictureBox pbxSeven;
        private System.Windows.Forms.PictureBox pbxSix;
        private System.Windows.Forms.PictureBox pbxFive;
        private System.Windows.Forms.PictureBox pbxFour;
        private System.Windows.Forms.PictureBox pbxThree;
        private System.Windows.Forms.PictureBox pbxTwo;
        private System.Windows.Forms.Button btnExitApplication;
        private System.Windows.Forms.Button btnRestartGame;
        private System.Windows.Forms.Label lblGameStatus;
    }
}

