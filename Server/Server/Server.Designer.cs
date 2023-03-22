namespace Server {
    partial class Server {
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
            if (disposing && (components != null)) {
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
            this.textBox_Addr = new System.Windows.Forms.TextBox();
            this.textBox_Port = new System.Windows.Forms.TextBox();
            this.button_Accpet = new System.Windows.Forms.Button();
            this.button_Close = new System.Windows.Forms.Button();
            this.button_Send = new System.Windows.Forms.Button();
            this.Tilttle = new System.Windows.Forms.RichTextBox();
            this.richTextBox_Send = new System.Windows.Forms.RichTextBox();
            this.PwrOnClient = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_Addr
            // 
            this.textBox_Addr.Location = new System.Drawing.Point(96, 62);
            this.textBox_Addr.Name = "textBox_Addr";
            this.textBox_Addr.Size = new System.Drawing.Size(160, 21);
            this.textBox_Addr.TabIndex = 0;
            this.textBox_Addr.Text = "127.0.0.1";
            // 
            // textBox_Port
            // 
            this.textBox_Port.Location = new System.Drawing.Point(96, 99);
            this.textBox_Port.Name = "textBox_Port";
            this.textBox_Port.Size = new System.Drawing.Size(160, 21);
            this.textBox_Port.TabIndex = 1;
            this.textBox_Port.Text = "8009";
            // 
            // button_Accpet
            // 
            this.button_Accpet.Location = new System.Drawing.Point(96, 175);
            this.button_Accpet.Name = "button_Accpet";
            this.button_Accpet.Size = new System.Drawing.Size(75, 23);
            this.button_Accpet.TabIndex = 2;
            this.button_Accpet.Text = "Receive";
            this.button_Accpet.UseVisualStyleBackColor = true;
            this.button_Accpet.Click += new System.EventHandler(this.button_Accpet_Click);
            // 
            // button_Close
            // 
            this.button_Close.Location = new System.Drawing.Point(181, 175);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(75, 23);
            this.button_Close.TabIndex = 3;
            this.button_Close.Text = "Close";
            this.button_Close.UseVisualStyleBackColor = true;
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // button_Send
            // 
            this.button_Send.Location = new System.Drawing.Point(96, 468);
            this.button_Send.Name = "button_Send";
            this.button_Send.Size = new System.Drawing.Size(160, 23);
            this.button_Send.TabIndex = 4;
            this.button_Send.Text = "Send";
            this.button_Send.UseVisualStyleBackColor = true;
            this.button_Send.Click += new System.EventHandler(this.button_Send_Click);
            // 
            // Tilttle
            // 
            this.Tilttle.Location = new System.Drawing.Point(96, 326);
            this.Tilttle.Name = "Tilttle";
            this.Tilttle.Size = new System.Drawing.Size(160, 28);
            this.Tilttle.TabIndex = 5;
            this.Tilttle.Text = "";
            // 
            // richTextBox_Send
            // 
            this.richTextBox_Send.Location = new System.Drawing.Point(292, 406);
            this.richTextBox_Send.Name = "richTextBox_Send";
            this.richTextBox_Send.Size = new System.Drawing.Size(673, 123);
            this.richTextBox_Send.TabIndex = 6;
            this.richTextBox_Send.Text = "";
            // 
            // PwrOnClient
            // 
            this.PwrOnClient.Location = new System.Drawing.Point(96, 257);
            this.PwrOnClient.Name = "PwrOnClient";
            this.PwrOnClient.Size = new System.Drawing.Size(75, 23);
            this.PwrOnClient.TabIndex = 7;
            this.PwrOnClient.Text = "启动客户端";
            this.PwrOnClient.UseVisualStyleBackColor = true;
            this.PwrOnClient.Click += new System.EventHandler(this.PwrOnClient_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(96, 140);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 8;
            // 
            // listView1
            // 
            this.listView1.CheckBoxes = true;
            this.listView1.Location = new System.Drawing.Point(292, 42);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(673, 312);
            this.listView1.TabIndex = 9;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(96, 505);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "群发送";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 564);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.PwrOnClient);
            this.Controls.Add(this.richTextBox_Send);
            this.Controls.Add(this.Tilttle);
            this.Controls.Add(this.button_Send);
            this.Controls.Add(this.button_Close);
            this.Controls.Add(this.button_Accpet);
            this.Controls.Add(this.textBox_Port);
            this.Controls.Add(this.textBox_Addr);
            this.Name = "Server";
            this.Text = "Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Addr;
        private System.Windows.Forms.TextBox textBox_Port;
        private System.Windows.Forms.Button button_Accpet;
        private System.Windows.Forms.Button button_Close;
        private System.Windows.Forms.Button button_Send;
        private System.Windows.Forms.RichTextBox Tilttle;
        private System.Windows.Forms.RichTextBox richTextBox_Send;
        private System.Windows.Forms.Button PwrOnClient;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button button1;
    }
}

