
namespace TicTacChess_88130
{
    partial class ConnectionForm
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
            this.components = new System.ComponentModel.Container();
            this.lbxLogs = new System.Windows.Forms.ListBox();
            this.gbxConnection = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxPorts = new System.Windows.Forms.ComboBox();
            this.btnOpenPort = new System.Windows.Forms.Button();
            this.btnScanPorts = new System.Windows.Forms.Button();
            this.gbxCommunication = new System.Windows.Forms.GroupBox();
            this.btnClearCommand = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxMessages = new System.Windows.Forms.ComboBox();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.serialPortArduino = new System.IO.Ports.SerialPort(this.components);
            this.arduinoTimer = new System.Windows.Forms.Timer(this.components);
            this.gbxConnection.SuspendLayout();
            this.gbxCommunication.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbxLogs
            // 
            this.lbxLogs.FormattingEnabled = true;
            this.lbxLogs.ItemHeight = 25;
            this.lbxLogs.Location = new System.Drawing.Point(310, 12);
            this.lbxLogs.Name = "lbxLogs";
            this.lbxLogs.Size = new System.Drawing.Size(649, 454);
            this.lbxLogs.TabIndex = 0;
            // 
            // gbxConnection
            // 
            this.gbxConnection.Controls.Add(this.label1);
            this.gbxConnection.Controls.Add(this.cbxPorts);
            this.gbxConnection.Controls.Add(this.btnOpenPort);
            this.gbxConnection.Controls.Add(this.btnScanPorts);
            this.gbxConnection.ForeColor = System.Drawing.Color.White;
            this.gbxConnection.Location = new System.Drawing.Point(12, 12);
            this.gbxConnection.Name = "gbxConnection";
            this.gbxConnection.Size = new System.Drawing.Size(279, 218);
            this.gbxConnection.TabIndex = 1;
            this.gbxConnection.TabStop = false;
            this.gbxConnection.Text = "Connection";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Port:";
            // 
            // cbxPorts
            // 
            this.cbxPorts.BackColor = System.Drawing.Color.Navy;
            this.cbxPorts.ForeColor = System.Drawing.Color.White;
            this.cbxPorts.FormattingEnabled = true;
            this.cbxPorts.Location = new System.Drawing.Point(80, 105);
            this.cbxPorts.Name = "cbxPorts";
            this.cbxPorts.Size = new System.Drawing.Size(193, 33);
            this.cbxPorts.TabIndex = 3;
            this.cbxPorts.SelectedIndexChanged += new System.EventHandler(this.cbxPorts_SelectedIndexChanged);
            // 
            // btnOpenPort
            // 
            this.btnOpenPort.BackColor = System.Drawing.Color.Navy;
            this.btnOpenPort.Location = new System.Drawing.Point(6, 161);
            this.btnOpenPort.Name = "btnOpenPort";
            this.btnOpenPort.Size = new System.Drawing.Size(267, 47);
            this.btnOpenPort.TabIndex = 2;
            this.btnOpenPort.Text = "Open port";
            this.btnOpenPort.UseVisualStyleBackColor = false;
            this.btnOpenPort.Click += new System.EventHandler(this.btnOpenPort_Click);
            // 
            // btnScanPorts
            // 
            this.btnScanPorts.BackColor = System.Drawing.Color.Navy;
            this.btnScanPorts.Location = new System.Drawing.Point(6, 31);
            this.btnScanPorts.Name = "btnScanPorts";
            this.btnScanPorts.Size = new System.Drawing.Size(267, 47);
            this.btnScanPorts.TabIndex = 0;
            this.btnScanPorts.Text = "Scan ports";
            this.btnScanPorts.UseVisualStyleBackColor = false;
            this.btnScanPorts.Click += new System.EventHandler(this.btnScanPorts_Click);
            // 
            // gbxCommunication
            // 
            this.gbxCommunication.Controls.Add(this.btnClearCommand);
            this.gbxCommunication.Controls.Add(this.label2);
            this.gbxCommunication.Controls.Add(this.cbxMessages);
            this.gbxCommunication.Controls.Add(this.btnSendMessage);
            this.gbxCommunication.ForeColor = System.Drawing.Color.White;
            this.gbxCommunication.Location = new System.Drawing.Point(12, 236);
            this.gbxCommunication.Name = "gbxCommunication";
            this.gbxCommunication.Size = new System.Drawing.Size(279, 223);
            this.gbxCommunication.TabIndex = 2;
            this.gbxCommunication.TabStop = false;
            this.gbxCommunication.Text = "Communication";
            // 
            // btnClearCommand
            // 
            this.btnClearCommand.BackColor = System.Drawing.Color.Navy;
            this.btnClearCommand.Location = new System.Drawing.Point(11, 168);
            this.btnClearCommand.Name = "btnClearCommand";
            this.btnClearCommand.Size = new System.Drawing.Size(256, 47);
            this.btnClearCommand.TabIndex = 6;
            this.btnClearCommand.Text = "Clear command";
            this.btnClearCommand.UseVisualStyleBackColor = false;
            this.btnClearCommand.Click += new System.EventHandler(this.btnClearCommand_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Messages:";
            // 
            // cbxMessages
            // 
            this.cbxMessages.BackColor = System.Drawing.Color.Navy;
            this.cbxMessages.ForeColor = System.Drawing.Color.White;
            this.cbxMessages.FormattingEnabled = true;
            this.cbxMessages.Items.AddRange(new object[] {
            "Vertical",
            "Horizontal",
            "Rotation",
            "Compressor off",
            "Compressor on",
            "Suction off",
            "Suction on",
            "Zero all",
            "Zero vertical",
            "Zero horizontal",
            "Zero rotation"});
            this.cbxMessages.Location = new System.Drawing.Point(11, 67);
            this.cbxMessages.Name = "cbxMessages";
            this.cbxMessages.Size = new System.Drawing.Size(256, 33);
            this.cbxMessages.TabIndex = 4;
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.BackColor = System.Drawing.Color.Navy;
            this.btnSendMessage.Location = new System.Drawing.Point(11, 115);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(256, 47);
            this.btnSendMessage.TabIndex = 1;
            this.btnSendMessage.Text = "Send message";
            this.btnSendMessage.UseVisualStyleBackColor = false;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // serialPortArduino
            // 
            this.serialPortArduino.BaudRate = 115200;
            this.serialPortArduino.DtrEnable = true;
            this.serialPortArduino.ReadBufferSize = 19200;
            this.serialPortArduino.ReadTimeout = 5000;
            this.serialPortArduino.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPortArduino_DataReceived);
            // 
            // arduinoTimer
            // 
            this.arduinoTimer.Enabled = true;
            this.arduinoTimer.Interval = 1000;
            this.arduinoTimer.Tick += new System.EventHandler(this.arduinoTimer_Tick);
            // 
            // ConnectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(971, 498);
            this.ControlBox = false;
            this.Controls.Add(this.gbxCommunication);
            this.Controls.Add(this.gbxConnection);
            this.Controls.Add(this.lbxLogs);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ConnectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ConnectionForm";
            this.gbxConnection.ResumeLayout(false);
            this.gbxConnection.PerformLayout();
            this.gbxCommunication.ResumeLayout(false);
            this.gbxCommunication.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbxLogs;
        private System.Windows.Forms.GroupBox gbxConnection;
        private System.Windows.Forms.Button btnScanPorts;
        private System.Windows.Forms.Button btnOpenPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxPorts;
        private System.Windows.Forms.GroupBox gbxCommunication;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxMessages;
        private System.Windows.Forms.Button btnSendMessage;
        private System.Windows.Forms.Button btnClearCommand;
        private System.IO.Ports.SerialPort serialPortArduino;
        private System.Windows.Forms.Timer arduinoTimer;
    }
}