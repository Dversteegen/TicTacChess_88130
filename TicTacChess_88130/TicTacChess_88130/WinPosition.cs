using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacChess_88130
{
    class WinPosition
    {
        private int firstPosition = 0;
        private int secondPosition = 0;
        private int thirdPosition = 0;
        //private string winningColor = "";

        public WinPosition(int c_firstPosition, int c_secondPosition, int c_thirdPosition)
        {
            firstPosition = c_firstPosition;
            secondPosition = c_secondPosition;
            thirdPosition = c_thirdPosition;
        }

        public WinPosition(int c_firstPosition, int c_secondPosition, int c_thirdPosition, string c_winningColor)
        {
            firstPosition = c_firstPosition;
            secondPosition = c_secondPosition;
            thirdPosition = c_thirdPosition;
            //winningColor = c_winningColor;
        }

        public int GetFirstPosition()
        {
            return firstPosition;
        }

        public int GetSecondPosition()
        {
            return secondPosition;
        }

        public int GetThirdPosition()
        {
            return thirdPosition;
        }
        //public string GetWinningColor()
        //{
        //    return winningColor;
        //}

    }
}
