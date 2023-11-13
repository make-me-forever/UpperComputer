namespace UDP
{
    partial class UdpMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
                        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UdpMain));
                        this.btnOpenServer = new System.Windows.Forms.Button();
                        this.plServer = new System.Windows.Forms.Panel();
                        this.lbHelp = new System.Windows.Forms.Label();
                        this.cbServerAddress = new System.Windows.Forms.ComboBox();
                        this.lbServerAddress = new System.Windows.Forms.Label();
                        this.pbServerState = new System.Windows.Forms.PictureBox();
                        this.lbServerState = new System.Windows.Forms.Label();
                        this.tbServerPort = new System.Windows.Forms.TextBox();
                        this.lbServerPort = new System.Windows.Forms.Label();
                        this.plMessage = new System.Windows.Forms.Panel();
                        this.cbHex = new System.Windows.Forms.CheckBox();
                        this.lbCount = new System.Windows.Forms.Label();
                        this.rtbMessageList = new System.Windows.Forms.RichTextBox();
                        this.btnClearList = new System.Windows.Forms.Label();
                        this.lbMessageList = new System.Windows.Forms.Label();
                        this.plSend = new System.Windows.Forms.Panel();
                        this.cbAddRN = new System.Windows.Forms.CheckBox();
                        this.lbSendState = new System.Windows.Forms.Label();
                        this.cbSyncServer = new System.Windows.Forms.CheckBox();
                        this.tbMyPort = new System.Windows.Forms.TextBox();
                        this.lbMyColon = new System.Windows.Forms.Label();
                        this.cbMyAddress = new System.Windows.Forms.ComboBox();
                        this.lbMyAddress = new System.Windows.Forms.Label();
                        this.tbAbversePort = new System.Windows.Forms.TextBox();
                        this.lbAdversColon = new System.Windows.Forms.Label();
                        this.tbAbverseIp = new System.Windows.Forms.TextBox();
                        this.lbAbverseAddress = new System.Windows.Forms.Label();
                        this.btnClearInput = new System.Windows.Forms.Button();
                        this.tbInput = new System.Windows.Forms.TextBox();
                        this.btnSendMessage = new System.Windows.Forms.Button();
                        this.plServer.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.pbServerState)).BeginInit();
                        this.plMessage.SuspendLayout();
                        this.plSend.SuspendLayout();
                        this.SuspendLayout();
                        // 
                        // btnOpenServer
                        // 
                        this.btnOpenServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.btnOpenServer.Cursor = System.Windows.Forms.Cursors.Hand;
                        this.btnOpenServer.Location = new System.Drawing.Point(2, 224);
                        this.btnOpenServer.Name = "btnOpenServer";
                        this.btnOpenServer.Size = new System.Drawing.Size(124, 31);
                        this.btnOpenServer.TabIndex = 1;
                        this.btnOpenServer.Text = "打开服务";
                        this.btnOpenServer.UseVisualStyleBackColor = true;
                        this.btnOpenServer.Click += new System.EventHandler(this.btnOpenServer_Click);
                        // 
                        // plServer
                        // 
                        this.plServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.plServer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                        this.plServer.Controls.Add(this.lbHelp);
                        this.plServer.Controls.Add(this.cbServerAddress);
                        this.plServer.Controls.Add(this.lbServerAddress);
                        this.plServer.Controls.Add(this.pbServerState);
                        this.plServer.Controls.Add(this.lbServerState);
                        this.plServer.Controls.Add(this.tbServerPort);
                        this.plServer.Controls.Add(this.lbServerPort);
                        this.plServer.Controls.Add(this.btnOpenServer);
                        this.plServer.Location = new System.Drawing.Point(389, 12);
                        this.plServer.Name = "plServer";
                        this.plServer.Size = new System.Drawing.Size(131, 275);
                        this.plServer.TabIndex = 2;
                        // 
                        // lbHelp
                        // 
                        this.lbHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                        this.lbHelp.AutoSize = true;
                        this.lbHelp.Cursor = System.Windows.Forms.Cursors.Hand;
                        this.lbHelp.ForeColor = System.Drawing.SystemColors.HotTrack;
                        this.lbHelp.Location = new System.Drawing.Point(97, 258);
                        this.lbHelp.Name = "lbHelp";
                        this.lbHelp.Size = new System.Drawing.Size(29, 12);
                        this.lbHelp.TabIndex = 8;
                        this.lbHelp.Text = "帮助";
                        this.lbHelp.Click += new System.EventHandler(this.lbHelp_Click);
                        // 
                        // cbServerAddress
                        // 
                        this.cbServerAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.cbServerAddress.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                        this.cbServerAddress.FormattingEnabled = true;
                        this.cbServerAddress.Location = new System.Drawing.Point(3, 132);
                        this.cbServerAddress.Name = "cbServerAddress";
                        this.cbServerAddress.Size = new System.Drawing.Size(123, 20);
                        this.cbServerAddress.TabIndex = 7;
                        this.cbServerAddress.TextChanged += new System.EventHandler(this.cbServerAddress_TextChanged);
                        // 
                        // lbServerAddress
                        // 
                        this.lbServerAddress.AutoSize = true;
                        this.lbServerAddress.Location = new System.Drawing.Point(3, 117);
                        this.lbServerAddress.Name = "lbServerAddress";
                        this.lbServerAddress.Size = new System.Drawing.Size(53, 12);
                        this.lbServerAddress.TabIndex = 6;
                        this.lbServerAddress.Text = "服务地址";
                        // 
                        // pbServerState
                        // 
                        this.pbServerState.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.pbServerState.BackgroundImage = global::UDP.Properties.Resources.close;
                        this.pbServerState.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                        this.pbServerState.Location = new System.Drawing.Point(3, 3);
                        this.pbServerState.Name = "pbServerState";
                        this.pbServerState.Size = new System.Drawing.Size(123, 104);
                        this.pbServerState.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
                        this.pbServerState.TabIndex = 5;
                        this.pbServerState.TabStop = false;
                        // 
                        // lbServerState
                        // 
                        this.lbServerState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                        this.lbServerState.AutoSize = true;
                        this.lbServerState.ForeColor = System.Drawing.SystemColors.HotTrack;
                        this.lbServerState.Location = new System.Drawing.Point(3, 258);
                        this.lbServerState.Name = "lbServerState";
                        this.lbServerState.Size = new System.Drawing.Size(77, 12);
                        this.lbServerState.TabIndex = 4;
                        this.lbServerState.Text = "服务器已关闭";
                        // 
                        // tbServerPort
                        // 
                        this.tbServerPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.tbServerPort.Location = new System.Drawing.Point(3, 170);
                        this.tbServerPort.Name = "tbServerPort";
                        this.tbServerPort.Size = new System.Drawing.Size(123, 21);
                        this.tbServerPort.TabIndex = 0;
                        this.tbServerPort.Text = "17217";
                        this.tbServerPort.TextChanged += new System.EventHandler(this.tbServerPort_TextChanged);
                        // 
                        // lbServerPort
                        // 
                        this.lbServerPort.AutoSize = true;
                        this.lbServerPort.Font = new System.Drawing.Font("宋体", 9F);
                        this.lbServerPort.Location = new System.Drawing.Point(3, 155);
                        this.lbServerPort.Name = "lbServerPort";
                        this.lbServerPort.Size = new System.Drawing.Size(53, 12);
                        this.lbServerPort.TabIndex = 2;
                        this.lbServerPort.Text = "服务端口";
                        // 
                        // plMessage
                        // 
                        this.plMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.plMessage.AutoScroll = true;
                        this.plMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                        this.plMessage.Controls.Add(this.cbHex);
                        this.plMessage.Controls.Add(this.lbCount);
                        this.plMessage.Controls.Add(this.rtbMessageList);
                        this.plMessage.Controls.Add(this.btnClearList);
                        this.plMessage.Controls.Add(this.lbMessageList);
                        this.plMessage.Controls.Add(this.plSend);
                        this.plMessage.Location = new System.Drawing.Point(12, 12);
                        this.plMessage.Name = "plMessage";
                        this.plMessage.Size = new System.Drawing.Size(375, 275);
                        this.plMessage.TabIndex = 3;
                        // 
                        // cbHex
                        // 
                        this.cbHex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                        this.cbHex.AutoSize = true;
                        this.cbHex.Location = new System.Drawing.Point(239, 3);
                        this.cbHex.Name = "cbHex";
                        this.cbHex.Size = new System.Drawing.Size(96, 16);
                        this.cbHex.TabIndex = 8;
                        this.cbHex.Text = "十六进制显示";
                        this.cbHex.UseVisualStyleBackColor = true;
                        // 
                        // lbCount
                        // 
                        this.lbCount.AutoSize = true;
                        this.lbCount.Location = new System.Drawing.Point(75, 4);
                        this.lbCount.Name = "lbCount";
                        this.lbCount.Size = new System.Drawing.Size(95, 12);
                        this.lbCount.TabIndex = 7;
                        this.lbCount.Text = "接收：0 发送：0";
                        // 
                        // rtbMessageList
                        // 
                        this.rtbMessageList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.rtbMessageList.Cursor = System.Windows.Forms.Cursors.IBeam;
                        this.rtbMessageList.Location = new System.Drawing.Point(3, 20);
                        this.rtbMessageList.Name = "rtbMessageList";
                        this.rtbMessageList.ReadOnly = true;
                        this.rtbMessageList.Size = new System.Drawing.Size(364, 139);
                        this.rtbMessageList.TabIndex = 6;
                        this.rtbMessageList.Text = "";
                        this.rtbMessageList.TextChanged += new System.EventHandler(this.rtbMessageList_TextChanged);
                        // 
                        // btnClearList
                        // 
                        this.btnClearList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                        this.btnClearList.AutoSize = true;
                        this.btnClearList.Cursor = System.Windows.Forms.Cursors.Hand;
                        this.btnClearList.ForeColor = System.Drawing.SystemColors.HotTrack;
                        this.btnClearList.Location = new System.Drawing.Point(341, 4);
                        this.btnClearList.Name = "btnClearList";
                        this.btnClearList.Size = new System.Drawing.Size(29, 12);
                        this.btnClearList.TabIndex = 5;
                        this.btnClearList.Text = "清空";
                        this.btnClearList.Click += new System.EventHandler(this.btnClearList_Click);
                        // 
                        // lbMessageList
                        // 
                        this.lbMessageList.AutoSize = true;
                        this.lbMessageList.Location = new System.Drawing.Point(4, 4);
                        this.lbMessageList.Name = "lbMessageList";
                        this.lbMessageList.Size = new System.Drawing.Size(65, 12);
                        this.lbMessageList.TabIndex = 4;
                        this.lbMessageList.Text = "消息列表：";
                        // 
                        // plSend
                        // 
                        this.plSend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.plSend.Controls.Add(this.cbAddRN);
                        this.plSend.Controls.Add(this.lbSendState);
                        this.plSend.Controls.Add(this.cbSyncServer);
                        this.plSend.Controls.Add(this.tbMyPort);
                        this.plSend.Controls.Add(this.lbMyColon);
                        this.plSend.Controls.Add(this.cbMyAddress);
                        this.plSend.Controls.Add(this.lbMyAddress);
                        this.plSend.Controls.Add(this.tbAbversePort);
                        this.plSend.Controls.Add(this.lbAdversColon);
                        this.plSend.Controls.Add(this.tbAbverseIp);
                        this.plSend.Controls.Add(this.lbAbverseAddress);
                        this.plSend.Controls.Add(this.btnClearInput);
                        this.plSend.Controls.Add(this.tbInput);
                        this.plSend.Controls.Add(this.btnSendMessage);
                        this.plSend.Location = new System.Drawing.Point(-1, 162);
                        this.plSend.Name = "plSend";
                        this.plSend.Size = new System.Drawing.Size(375, 112);
                        this.plSend.TabIndex = 2;
                        // 
                        // cbAddRN
                        // 
                        this.cbAddRN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                        this.cbAddRN.AutoSize = true;
                        this.cbAddRN.Location = new System.Drawing.Point(320, 60);
                        this.cbAddRN.Name = "cbAddRN";
                        this.cbAddRN.Size = new System.Drawing.Size(48, 16);
                        this.cbAddRN.TabIndex = 14;
                        this.cbAddRN.Text = "\\r\\n";
                        this.cbAddRN.UseVisualStyleBackColor = true;
                        // 
                        // lbSendState
                        // 
                        this.lbSendState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                        this.lbSendState.AutoSize = true;
                        this.lbSendState.Location = new System.Drawing.Point(274, 9);
                        this.lbSendState.Name = "lbSendState";
                        this.lbSendState.Size = new System.Drawing.Size(0, 12);
                        this.lbSendState.TabIndex = 13;
                        // 
                        // cbSyncServer
                        // 
                        this.cbSyncServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                        this.cbSyncServer.AutoSize = true;
                        this.cbSyncServer.Location = new System.Drawing.Point(276, 33);
                        this.cbSyncServer.Name = "cbSyncServer";
                        this.cbSyncServer.Size = new System.Drawing.Size(96, 16);
                        this.cbSyncServer.TabIndex = 12;
                        this.cbSyncServer.Text = "使用服务地址";
                        this.cbSyncServer.UseVisualStyleBackColor = true;
                        this.cbSyncServer.CheckedChanged += new System.EventHandler(this.cbSyncServer_CheckedChanged);
                        // 
                        // tbMyPort
                        // 
                        this.tbMyPort.Location = new System.Drawing.Point(219, 29);
                        this.tbMyPort.Name = "tbMyPort";
                        this.tbMyPort.Size = new System.Drawing.Size(42, 21);
                        this.tbMyPort.TabIndex = 11;
                        this.tbMyPort.Text = "7217";
                        // 
                        // lbMyColon
                        // 
                        this.lbMyColon.AutoSize = true;
                        this.lbMyColon.Location = new System.Drawing.Point(201, 34);
                        this.lbMyColon.Name = "lbMyColon";
                        this.lbMyColon.Size = new System.Drawing.Size(11, 12);
                        this.lbMyColon.TabIndex = 10;
                        this.lbMyColon.Text = ":";
                        // 
                        // cbMyAddress
                        // 
                        this.cbMyAddress.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                        this.cbMyAddress.FormattingEnabled = true;
                        this.cbMyAddress.Location = new System.Drawing.Point(74, 31);
                        this.cbMyAddress.Name = "cbMyAddress";
                        this.cbMyAddress.Size = new System.Drawing.Size(121, 20);
                        this.cbMyAddress.TabIndex = 9;
                        // 
                        // lbMyAddress
                        // 
                        this.lbMyAddress.AutoSize = true;
                        this.lbMyAddress.Location = new System.Drawing.Point(3, 34);
                        this.lbMyAddress.Name = "lbMyAddress";
                        this.lbMyAddress.Size = new System.Drawing.Size(65, 12);
                        this.lbMyAddress.TabIndex = 8;
                        this.lbMyAddress.Text = "我方地址：";
                        // 
                        // tbAbversePort
                        // 
                        this.tbAbversePort.Location = new System.Drawing.Point(219, 3);
                        this.tbAbversePort.Name = "tbAbversePort";
                        this.tbAbversePort.Size = new System.Drawing.Size(42, 21);
                        this.tbAbversePort.TabIndex = 7;
                        this.tbAbversePort.Text = "17217";
                        // 
                        // lbAdversColon
                        // 
                        this.lbAdversColon.AutoSize = true;
                        this.lbAdversColon.Location = new System.Drawing.Point(201, 6);
                        this.lbAdversColon.Name = "lbAdversColon";
                        this.lbAdversColon.Size = new System.Drawing.Size(11, 12);
                        this.lbAdversColon.TabIndex = 6;
                        this.lbAdversColon.Text = ":";
                        // 
                        // tbAbverseIp
                        // 
                        this.tbAbverseIp.Location = new System.Drawing.Point(74, 3);
                        this.tbAbverseIp.Name = "tbAbverseIp";
                        this.tbAbverseIp.Size = new System.Drawing.Size(121, 21);
                        this.tbAbverseIp.TabIndex = 2;
                        this.tbAbverseIp.Text = "127.0.0.1";
                        // 
                        // lbAbverseAddress
                        // 
                        this.lbAbverseAddress.AutoSize = true;
                        this.lbAbverseAddress.Location = new System.Drawing.Point(3, 9);
                        this.lbAbverseAddress.Name = "lbAbverseAddress";
                        this.lbAbverseAddress.Size = new System.Drawing.Size(65, 12);
                        this.lbAbverseAddress.TabIndex = 3;
                        this.lbAbverseAddress.Text = "对方地址：";
                        // 
                        // btnClearInput
                        // 
                        this.btnClearInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                        this.btnClearInput.Cursor = System.Windows.Forms.Cursors.Hand;
                        this.btnClearInput.Location = new System.Drawing.Point(291, 56);
                        this.btnClearInput.Name = "btnClearInput";
                        this.btnClearInput.Size = new System.Drawing.Size(23, 23);
                        this.btnClearInput.TabIndex = 5;
                        this.btnClearInput.Text = "X";
                        this.btnClearInput.UseVisualStyleBackColor = true;
                        this.btnClearInput.Click += new System.EventHandler(this.btnClearInput_Click);
                        // 
                        // tbInput
                        // 
                        this.tbInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.tbInput.Location = new System.Drawing.Point(5, 56);
                        this.tbInput.Multiline = true;
                        this.tbInput.Name = "tbInput";
                        this.tbInput.Size = new System.Drawing.Size(280, 53);
                        this.tbInput.TabIndex = 3;
                        // 
                        // btnSendMessage
                        // 
                        this.btnSendMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                        this.btnSendMessage.Cursor = System.Windows.Forms.Cursors.Hand;
                        this.btnSendMessage.Location = new System.Drawing.Point(291, 85);
                        this.btnSendMessage.Name = "btnSendMessage";
                        this.btnSendMessage.Size = new System.Drawing.Size(81, 24);
                        this.btnSendMessage.TabIndex = 4;
                        this.btnSendMessage.Text = "发送";
                        this.btnSendMessage.UseVisualStyleBackColor = true;
                        this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
                        // 
                        // UdpMain
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.ClientSize = new System.Drawing.Size(532, 299);
                        this.Controls.Add(this.plMessage);
                        this.Controls.Add(this.plServer);
                        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
                        this.MinimumSize = new System.Drawing.Size(548, 314);
                        this.Name = "UdpMain";
                        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                        this.Text = "UDP测试 V1";
                        this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UdpForm_FormClosing);
                        this.plServer.ResumeLayout(false);
                        this.plServer.PerformLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.pbServerState)).EndInit();
                        this.plMessage.ResumeLayout(false);
                        this.plMessage.PerformLayout();
                        this.plSend.ResumeLayout(false);
                        this.plSend.PerformLayout();
                        this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOpenServer;
        private System.Windows.Forms.Panel plServer;
        private System.Windows.Forms.TextBox tbServerPort;
        private System.Windows.Forms.Label lbServerPort;
        private System.Windows.Forms.Panel plMessage;
        private System.Windows.Forms.Button btnSendMessage;
        private System.Windows.Forms.TextBox tbInput;
        private System.Windows.Forms.Panel plSend;
        private System.Windows.Forms.Label lbAbverseAddress;
        private System.Windows.Forms.Button btnClearInput;
        private System.Windows.Forms.TextBox tbAbverseIp;
        private System.Windows.Forms.Label lbMessageList;
        private System.Windows.Forms.Label lbServerState;
        private System.Windows.Forms.PictureBox pbServerState;
        private System.Windows.Forms.Label btnClearList;
        private System.Windows.Forms.RichTextBox rtbMessageList;
        private System.Windows.Forms.TextBox tbAbversePort;
        private System.Windows.Forms.Label lbAdversColon;
        private System.Windows.Forms.ComboBox cbServerAddress;
        private System.Windows.Forms.Label lbServerAddress;
        private System.Windows.Forms.CheckBox cbSyncServer;
        private System.Windows.Forms.TextBox tbMyPort;
        private System.Windows.Forms.Label lbMyColon;
        private System.Windows.Forms.ComboBox cbMyAddress;
        private System.Windows.Forms.Label lbMyAddress;
        private System.Windows.Forms.Label lbSendState;
        private System.Windows.Forms.Label lbCount;
        private System.Windows.Forms.Label lbHelp;
        private System.Windows.Forms.CheckBox cbAddRN;
        private System.Windows.Forms.CheckBox cbHex;
    }
}

