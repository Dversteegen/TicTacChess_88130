using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;

namespace TicTacChess_88130
{
    public partial class ConnectionForm : Form
    {
        private delegate void SafeCallDelegate();
        String receivedString = "";
        String receivedStringLast = "";        

        List<Command> allCommands = new List<Command>();
        List<string> allCurrentCommands = new List<string>();
        bool armIsDone = true;


        public ConnectionForm()
        {
            InitializeComponent();
            SetUpCommands();
        }

        #region SetUpCommands

        private void SetUpCommands()
        {
            Command newCommand = new Command("Vertical", "VS:");
            allCommands.Add(newCommand);

            newCommand = new Command("Horizontal", "HS:");
            allCommands.Add(newCommand);

            newCommand = new Command("Rotation", "RS:");
            allCommands.Add(newCommand);

            newCommand = new Command("Compressor off", "CS:0");
            allCommands.Add(newCommand);

            newCommand = new Command("Compressor on", "CS:1");
            allCommands.Add(newCommand);

            newCommand = new Command("Suction off", "SS:0");
            allCommands.Add(newCommand);

            newCommand = new Command("Suction on", "SS:1");
            allCommands.Add(newCommand);

            newCommand = new Command("Zero all", "ZS:0");
            allCommands.Add(newCommand);

            newCommand = new Command("Zero vertical", "ZS:1");
            allCommands.Add(newCommand);

            newCommand = new Command("Zero horizontal", "ZS:2");
            allCommands.Add(newCommand);

            newCommand = new Command("Zero rotation", "ZS:3");
            allCommands.Add(newCommand);

        }

        #endregion

        private void btnScanPorts_Click(object sender, EventArgs e)
        {
            String[] ports = SerialPort.GetPortNames();
            Array.Sort(ports);
            string m_portWithOutLastCharacter;
            lbxLogs.Items.Clear();

            //Close the connection if there already is one open
            if (serialPortArduino.IsOpen)
            {
                PrintLn("Connection was open. Closing..", "B");
                serialPortArduino.Close();
            }
            cbxPorts.Items.Clear();

            //Each port that is connected wil be shown in the combobox
            foreach (String port in ports)
            {
                m_portWithOutLastCharacter = port;

                cbxPorts.Items.Add(m_portWithOutLastCharacter);
                PrintLn("Found port:" + m_portWithOutLastCharacter.ToString(), "W");
            }
        }

        private void cbxPorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPortArduino.PortName = cbxPorts.Text;
            PrintLn("Port selected: " + serialPortArduino.PortName, "W");
            PrintLn("Default baudrate: " + serialPortArduino.BaudRate.ToString(), "W");
            btnOpenPort.Enabled = true;
        }

        private void btnOpenPort_Click(object sender, EventArgs e)
        {
            //This is to settup the default baudrate
            serialPortArduino.BaudRate = Convert.ToInt32(115200);
            PrintLn("Selected baudrate: " + serialPortArduino.BaudRate.ToString(), "W");

            //If there is no open connection the connection will be opened
            if (!serialPortArduino.IsOpen)
            {
                try
                {
                    serialPortArduino.Open();

                    Thread.Sleep(200); //wait 100 ms to open port

                    this.Text = "Main - using com port: " + cbxPorts.Text;
                    PrintLn("Using com port: " + cbxPorts.Text, "W");
                    btnSendMessage.Enabled = true;
                    cbxMessages.Enabled = true;
                    btnClearCommand.Enabled = true;
                }
                catch
                {
                    PrintLn("ERROR: Please make sure that the correct port was selected, and the device, plugged in.", "R");
                }
            }
        }

        /// <summary>
        /// Printing message to the listbox
        /// </summary>
        /// <param name="a_text"></param>
        /// <param name="a_color"></param>
        public void PrintLn(string a_text, string a_color)
        {
            lbxLogs.Items.Add(a_text);
            //lbxLogs.Items.Add("");

            //For auto scrolling the listbox
            int nItems = (int)(lbxLogs.Height / lbxLogs.ItemHeight);
            lbxLogs.TopIndex = lbxLogs.Items.Count - nItems;
        }

        public void WriteArduino(string a_action)
        {
            int m_length = a_action.Length;
            char[] m_data = new char[m_length];

            String m_carriageReturn = "\r";
            char[] m_cr = new char[2];

            String m_newLine = "\n";
            char[] m_nl = new char[2];

            for (int m_index = 0; m_index < m_length; m_index++)
            {
                m_data[m_index] = Convert.ToChar(a_action[m_index]);
            }

            for (int m_index = 0; m_index < 1; m_index++)
            {
                m_cr[m_index] = Convert.ToChar(m_carriageReturn[m_index]);
            }

            for (int m_index = 0; m_index < 1; m_index++)
            {
                m_nl[m_index] = Convert.ToChar(m_newLine[m_index]);
            }

            if (serialPortArduino.IsOpen == true)
            {
                serialPortArduino.Write(m_data, 0, m_length);

                PrintLn("Transmitted message from Main: " + a_action, "Y");
            }
            else
            {
                PrintLn("ERROR. Please make sure that the correct port was selected, and the device, plugged in.", "R");
            }
        }

        private void serialPortArduino_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            HandleReceivedData();
        }

        private void HandleReceivedData()
        {
            if (serialPortArduino.IsOpen)
            {
                try
                {
                    //Check if this is the same thread
                    if (lbxLogs.InvokeRequired)
                    {
                        var d = new SafeCallDelegate(HandleReceivedData);
                        //Allow changes in this thread from another thread
                        lbxLogs.Invoke(d, new object[] { });
                    }
                    else
                    {
                        receivedString = serialPortArduino.ReadLine();
                        PrintLn(receivedString, "G");
                    }
                }
                catch
                {
                    PrintLn("ERROR: Time out of: " + serialPortArduino.ReadTimeout.ToString() + "ms. Data read failed", "R");
                }
            }
        }

        public string ReadArduino()
        {
            if (receivedString != receivedStringLast)
            {
                PrintLn(receivedString, "G");
            }
            receivedStringLast = receivedString;

            return receivedString;
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            if (cbxMessages.SelectedIndex >= 0)
            {
                string command = allCommands[cbxMessages.SelectedIndex].GetCommandString();
                WriteArduino(command);
            }
        }

        private void btnClearCommand_Click(object sender, EventArgs e)
        {
            WriteArduino("ZS:0");
        }

        /// <summary>
        /// Tells another function what commands to add to the list
        /// </summary>
        /// <param name="firstArmPositions"></param>
        /// <param name="secondArmPositions"></param>
        public void AddCommands(Tuple<int, int> firstArmPositions, Tuple<int, int> secondArmPositions)
        {
            AddMoveCommands(1, 1150, firstArmPositions, false);
            AddMoveCommands(0, 900, secondArmPositions, true);
        }

        /// <summary>
        /// Addd commands to the list
        /// </summary>
        /// <param name="suckStatus"></param>
        /// <param name="verticalheight"></param>
        /// <param name="armPositions"></param>
        /// <param name="piecePlaced"></param>
        private void AddMoveCommands(int suckStatus, int verticalheight, Tuple<int, int> armPositions, bool piecePlaced)
        {
            allCurrentCommands.Add($"RS:{armPositions.Item2}");
            allCurrentCommands.Add($"HS:{armPositions.Item1}");
            allCurrentCommands.Add($"VS:{verticalheight}");
            allCurrentCommands.Add($"CS:{suckStatus}");
            allCurrentCommands.Add($"SS:{suckStatus}");
            allCurrentCommands.Add($"VS:0900");
            if (piecePlaced)
            {
                ZeroArm();
            }
        }        

        /// <summary>
        /// Resets the arm after moving a piece
        /// </summary>
        public void ZeroArm()
        {
            allCurrentCommands.Add("ZS:1");
            allCurrentCommands.Add("ZS:2");
            allCurrentCommands.Add("ZS:3");
        }

        /// <summary>
        /// Ever tick it checks if there are any commands in the list, if yes it executes them
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void arduinoTimer_Tick(object sender, EventArgs e)
        {
            int amountOfcommands = allCurrentCommands.Count;

            if (amountOfcommands > 0 )                
            {
                armIsDone = false;
                if (lbxLogs.Items[lbxLogs.Items.Count - 1].ToString().Contains("Ready"))
                {
                    WriteArduino(allCurrentCommands[0]);
                    allCurrentCommands.RemoveAt(0);
                }
            } 
            else
            {
                armIsDone = true;
            }
        }

        private void btnUseCoords_Click(object sender, EventArgs e)
        {
            string horizontal = tbxHorizontal.Text;
            string rotation = tbxRot.Text;

            allCurrentCommands.Add($"RS:{rotation}");
            allCurrentCommands.Add($"HS:{horizontal}");            
            allCurrentCommands.Add($"VS:1150");
            ZeroArm();
        }

        public bool GetArmStatus()
        {
            return armIsDone;
        }
    }
}
