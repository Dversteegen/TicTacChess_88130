using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacChess_88130
{
    class Command
    {
        string commandName = "";
        string commandString = "";

        public Command(string c_commandName, string c_commandString)
        {
            commandName = c_commandName;
            commandString = c_commandString;
        }

        public string GetCommandName()
        {
            return commandName;
        }

        public string GetCommandString()
        {
            return commandString;
        }
    }
}
