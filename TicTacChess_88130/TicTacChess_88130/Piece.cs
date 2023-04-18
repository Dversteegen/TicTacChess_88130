using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacChess_88130
{    
    class Piece
    {        
        private string type;
        private string color;

        //Image of the piece
        private Bitmap image;

        public Piece(string c_type, string c_color, Bitmap c_image)
        {
            type = c_type;
            color = c_color;
            image = c_image;
        }

        #region GetFunctions

        public string GetPieceColor()
        {
            return color;
        }

        public string GetPieceType()
        {
            return type;
        }

        public Bitmap GetPieceImage()
        {
            return image;
        }

        #endregion
    }
}
