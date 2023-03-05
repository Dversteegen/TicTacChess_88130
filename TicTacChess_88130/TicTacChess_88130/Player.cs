using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacChess_88130
{
    class Player
    {
        List<Piece> allCurrentPieces;

        public Player(List<Piece> allPieces)
        {
            allCurrentPieces = allPieces;
        }        
    }
}
