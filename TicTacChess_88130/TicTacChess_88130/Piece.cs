using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacChess_88130
{    
    class Piece
    {        
        private string type;
        private string color;        

        public Piece(string c_type, string c_color)
        {
            type = c_type;
            color = c_color;            
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

        #endregion
    }
}
