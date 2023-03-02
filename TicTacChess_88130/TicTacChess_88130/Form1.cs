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

        public Form1()
        {
            InitializeComponent();
        }

        private void btnExitApplication_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void rbtWhite_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbtBlack_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbtAny_Click(object sender, EventArgs e)
        {
            
        }
    }
}
