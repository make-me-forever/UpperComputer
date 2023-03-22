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
    public partial class Server : Form {
        

        public Server()
        {
            InitializeComponent();
        }



        Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private Dictionary<string, Socket> Clientlist = new Dictionary<string, Socket>();
        private void button_Accpet_Click(object sender, EventArgs e)
        {
            IPEndPoint point = new IPEndPoint(IPAddress.Parse(textBox_Addr.Text), int.Parse(textBox_Port.Text));
            try {
                server.Bind(point);
            } catch (Exception ex) {
                MessageBox.Show("无法启动服务器：" + ex.Message);
            }
            server.Listen(3);

            Task.Factory.StartNew(new Action(() => {
                ListenSocket();
            }));
            MessageBox.Show("服务器启动成功");
            button_Accpet.Enabled = false;
        }

        private void ListenSocket()
        {
            while (true) {
                Socket Client = server.Accept();
                string client = Client.RemoteEndPoint.ToString();
                Log(client + ":连接了服务器");
                Clientlist.Add(client, Client);
                OnlineClient(client, true);
                Task.Factory.StartNew(new Action(() => {
                    ReceiveMsg(Client);
                }));
            }
        }

        private void PwrOnClient_Click(object sender, EventArgs e)
        {
            Form frm = new Client();
            frm.Show();
        }

        private void OnlineClient(string client, bool p)
        {
            if (comboBox1.InvokeRequired) {
                Invoke(new Action(() => {
                    if (p) {
                        comboBox1.Items.Add(client);
                    } else {
                        foreach (string item in comboBox1.Items) {
                            if (item == client) {
                                comboBox1.Items.Add(client);
                                break;
                            }

                        }
                    }
                }));
            } else {
                if (p) {
                    comboBox1.Items.Add(client);
                } else {
                    foreach (string item in comboBox1.Items) {
                        if (item == client) {
                            comboBox1.Items.Add(client);
                            break;
                        }

                    }
                }
            }
        }

        private void ReceiveMsg(Socket Client)
        {
            while (true) {
                byte [] b = new byte [1024 * 1024 * 2];
                int length = 0;
                string client = Client.RemoteEndPoint.ToString(); // 获取已连接到的客服
                try {
                    length = Client.Receive(b);
                } catch {
                    OnlineClient(client, false);
                    Log(client + ":失去连接");
                    Clientlist.Remove(client);
                    break;
                }
                if (length > 0) {
                    string msg = Encoding.Default.GetString(b, 0, length);
                    Log(client + ":" + msg);
                } else {
                    OnlineClient(client, false);
                    Log(client + ":失去连接");
                    Clientlist.Remove(client);
                }
            }
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
            if(comboBox1.SelectedItem != null){
                Log("服务器:" + richTextBox_Send.Text.Trim());
                string client = comboBox1.SelectedItem.ToString();
                Clientlist [client].Send(Encoding.Default.GetBytes(richTextBox_Send.Text.Trim()));
            }else{
                MessageBox.Show("请选择客户端");
            }
        }

        private void Server_FromClosing(object sender, FromClosingEventArgs e)
        {
            server.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Items.Count > 0) {
                Log("服务器：" + richTextBox_Send.Text.Trim());
                foreach (string item in comboBox1.Items) {
                    Clientlist [item].Send(Encoding.Default.GetBytes(richTextBox_Send.Text));
                }
            } else {
                MessageBox.Show("没有客户端连接到服务器");
            }
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            server.Close();     //关闭用于通信的套接字  
            //OnlineClient.Close();   //关闭用于连接的套接字
            //socketAccept.Close();   //关闭与客户端绑定的套接字
            button_Accpet.Enabled = true;
        }






        #region 注释
        //        int CFlag = 0;
//        int SFlag = 0;

//        public Form1()
//        {
//            InitializeComponent();
//        }

//        private void Form1_Load(object sender, EventArgs e)
//        {
//            Control.CheckForIllegalCrossThreadCalls = false; //执行新线程时跨线程资源访问检查会提示报错，所以这里关闭检测
//        }

///*****************************************************************/
//        #region 连接客户端（绑定按钮事件）
//        private void button_Accpet_Click(object sender, EventArgs e)
//        {

//            Socket ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);     //创建用于通信的套接字
            
//            richTextBox_Receive.Text += "正在连接...\n";
//            button_Accpet.Enabled = false;  //禁止操作接收按钮
           
//            //1.绑定IP和Port
//            IPAddress IP = IPAddress.Parse(textBox_Addr.Text);
//            int Port = int.Parse(textBox_Port.Text);

//            //IPAddress ip = IPAddress.Any;
//            IPEndPoint iPEndPoint = new IPEndPoint(IP, Port);

//            try
//            {
//                //2.使用Bind()进行绑定
//                ServerSocket.Bind(iPEndPoint);
//                //3.开启监听
//                //Listen(int backlog); backlog:监听数量 
//                ServerSocket.Listen(10);

//                /*
//                 * tip：
//                 * Accept会阻碍主线程的运行，一直在等待客户端的请求，
//                 * 客户端如果不接入，它就会一直在这里等着，主线程卡死
//                 * 所以开启一个新线程接收客户单请求
//                 */

//                //开启线程Accept进行通信的客户端socket
//                Thread th1 = new Thread(Listen);   //线程绑定Listen函数
//                th1.IsBackground = true;    //运行线程在后台执行
//                th1.Start(ServerSocket);    //Start里面的参数是Listen函数所需要的参数，这里传送的是用于通信的Socket对象
//                Console.WriteLine("1");
//            }
//            catch
//            {
//                MessageBox.Show("服务器出问题了");
//            }
//        }
//        #endregion
//        /*****************************************************************/

//        /*****************************************************************/
//        #region 建立与客户端的连接
//        void Listen(Object sk) 
//        {
//            Socket socketAccept = sk as Socket;    //创建一个与客户端对接的套接字
            
//            try
//            {
//               while (true) 
//               {
//                   //GNFlag如果为1就进行中断连接，使用在标志为是为了保证能够顺利关闭服务器端
//                   /*
//                    * 当客户端关闭一次后，如果没有这个标志位会使得服务器端一直卡在中断的位置
//                    * 如果服务器端一直卡在中断的位置就不能顺利关闭服务器端
//                    */

//                    //4.阻塞到有client连接
//                    Socket socket = socketAccept.Accept();

//                    CFlag = 0;  //连接成功，将客户端关闭标志设置为0
//                    SFlag = 1;  //当连接成功，将连接成功标志设置为1

//                    richTextBox_Receive.Text += DateTime.Now.ToString("yy-MM-dd hh:mm:ss  ") + textBox_Addr.Text + "连接成功";
//                    richTextBox_Receive.Text += "\r\n";

//                    //开启第二个线程接收客户端数据
//                    Thread th2 = new Thread(Receive);  //线程绑定Receive函数
//                    th2.IsBackground = true;    //运行线程在后台执行
//                    th2.Start(socket);    //Start里面的参数是Listen函数所需要的参数，这里传送的是用于通信的Socket对象
//               }
//            }
//            catch 
//            {
//                //MessageBox.Show("没有连接上客户端");   
//            }
//        }
//        #endregion
//        /*****************************************************************/

//        /*****************************************************************/
//        #region 接收客户端数据
//        void Receive(Object sk)
//        {
//            Socket socket = sk as Socket;  //创建用于通信的套接字

//            while (true)
//            {
//                try
//                {
//                    if (CFlag == 0 && SFlag == 1)
//                    {
//                        //5.接收数据
//                        byte[] recieve = new byte[1024];
//                        int len = socket.Receive(recieve);

//                        //6.打印接收数据
//                        if (recieve.Length > 0)
//                        {
//                            //如果接收到客户端停止的标志
//                            if (Encoding.ASCII.GetString(recieve, 0, len) == "*close*")
//                            {
//                                richTextBox_Receive.Text += DateTime.Now.ToString("yy-MM-dd hh:mm:ss  ") + "客户端已退出" + "\n";
//                                CFlag = 1;      //将客户端关闭标志设置为1

//                                break;      //退出循环
//                            }

//                            //打印接收数据
//                            richTextBox_Receive.Text += DateTime.Now.ToString("yy-MM-dd hh:mm:ss  ") + "接收：";
//                            richTextBox_Receive.Text += Encoding.ASCII.GetString(recieve, 0, len);  //将字节数据根据ASCII码转成字符串
//                            richTextBox_Receive.Text += "\r\n";
//                        }
//                    }
//                    else
//                    {
//                        break;  //跳出循环
//                    } 
//                }
//                catch
//                {
//                    MessageBox.Show("收不到信息");
//                }  
//            }  
//        }
//        #endregion
//        /*****************************************************************/

//        /*****************************************************************/
//        #region 向客户端发送数据
//        private void button_Send_Click(object sender, EventArgs e)
//        {
//            Socket socket = new Socket();  //创建用于通信的套接字
//            //SFlag标志连接成功，同时当客户端是打开的时候才能发送数据
//            if(SFlag == 1 && CFlag == 0)
//            {
//                byte[] send = new byte[1024];
//                send = Encoding.ASCII.GetBytes(richTextBox_Send.Text);    //将字符串转成字节格式发送
//                socket.Send(send);  //调用Send()向客户端发送数据

//                //打印发送时间和发送的数据
//                richTextBox_Receive.Text += DateTime.Now.ToString("yy-MM-dd hh:mm:ss  ") + "发送：";
//                richTextBox_Receive.Text += richTextBox_Send.Text + "\n";
//                richTextBox_Send.Clear();   //清除发送框
//            } 
//        }
//        #endregion
//        /*****************************************************************/

//        /*****************************************************************/
//        #region 关闭服务器端
//        private void button_Close_Click(object sender, EventArgs e)
//        {
//            //若连接上了客户端需要关闭线程2和socket，没连接上客户端直接关闭线程1和其他套接字
//            if(CFlag == 1)
//            {
//                th2.Abort();        //关闭线程2
//                socket.Close();     //关闭用于通信的套接字
//            }
            
//            ServerSocket.Close();   //关闭用于连接的套接字
//            socketAccept.Close();   //关闭与客户端绑定的套接字
//            th1.Abort();    //关闭线程1

//            CFlag = 0;  //将客户端标志重新设置为0,在进行连接时表示是打开的状态
//            SFlag = 0;  //将连接成功标志程序设置为0，表示退出连接
//            button_Accpet.Enabled = true;
//            richTextBox_Receive.Text += DateTime.Now.ToString("yy-MM-dd hh:mm:ss  ");
//            richTextBox_Receive.Text += "服务器已关闭" + "\n";
//            MessageBox.Show("服务器已关闭");
//        }
//        #endregion
        //        /*****************************************************************/
        #endregion
    }
}
