using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace Server {
    public partial class Client : Form {


        public Client()
        {
            InitializeComponent();
        }



        Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private Dictionary<string, Socket> Clientlist = new Dictionary<string, Socket>();
        private void button_Accpet_Click(object sender, EventArgs e)
        {
            IPEndPoint point = new IPEndPoint(IPAddress.Parse(textBox_Addr.Text), int.Parse(textBox_Port.Text));
            //IPEndPoint point = IPEndPoint.Parse("192.168.43.227:1234");
            try {
                client.Connect(point);
            } catch (Exception ex) {
                MessageBox.Show("无法连接服务器：" + ex.Message);
                return;
            }

            Task.Factory.StartNew(new Action(() => {
                RcvMsg();
            }));
            MessageBox.Show("服务器连接成功");
            textBox_Port.Text = textBox_Port.Text;
            button_Accpet.Enabled = false;
        }

        string time = DateTime.Now.ToString("yyyy-MM-dd_hhmmss ffff >");
        private void Log(string info)
        {
            if (!listView1.InvokeRequired) {
                ListViewItem lst = new ListViewItem(time);
                lst.SubItems.Add(info);
                listView1.Items.Insert(listView1.Items.Count, lst);
            } else {
                Invoke(new Action(() => {
                    ListViewItem lst = new ListViewItem(" " + time + info);
                    lst.SubItems.Add(info);
                    listView1.Items.Insert(listView1.Items.Count, lst);
                }));
            }
        }

        private void button_Send_Click(object sender, EventArgs e)
        {
            if (client != null) {
                try {
                    Log("客户机:" + richTextBox_Send.Text.Trim());
                    client.Send(Encoding.Default.GetBytes(richTextBox_Send.Text.Trim()));
                } catch (Exception ex){
                    MessageBox.Show("出现错误：" + ex.Message);
                }
            }
        }
        private void RcvMsg()
        {
            while (true) {
                byte [] b = new byte [1024 * 1024 * 2];
                int length = 0;
                try {
                    length = client.Receive(b);
                } catch {
                    Log("服务器断开连接");
                }
                if (length > 0) {
                    string msg = Encoding.Default.GetString(b, 0, length);
                    Log(msg);
                }
            }
        }
    }
}
