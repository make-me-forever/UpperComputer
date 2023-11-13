using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UDP
{
        public partial class UdpMain : Form
        {
                bool debug = false;
                const int DEBUG_W = 1;//警告
                const int DEBUG_I = 2;//信息
                const int DEBUG_E = 3;//错误
                const int DEBUG_S = 4;//统计
                [DllImport("kernel32.dll")]
                public static extern Boolean AllocConsole();
                [DllImport("kernel32.dll")]
                public static extern Boolean FreeConsole();

                private void DebugWriteLine(string p, int type)
                {
                        if (debug)
                        {
                                Console.BackgroundColor = ConsoleColor.Black;
                                switch (type)
                                {
                                        case DEBUG_E://错误
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                break;
                                        case DEBUG_W://警告
                                                Console.ForegroundColor = ConsoleColor.Yellow;
                                                break;
                                        case DEBUG_S://统计
                                                Console.ForegroundColor = ConsoleColor.Blue;
                                                break;
                                        case DEBUG_I://信息
                                                Console.ForegroundColor = ConsoleColor.White;
                                                break;
                                }
                                Console.WriteLine(p);
                                Console.ForegroundColor = ConsoleColor.White;
                        }
                }

                public const int RECEIVE = 1;
                public const int SEND = 2;

                delegate void AddMessageToListCallback(string name, byte[] content, int type);//安全调用
                delegate void timeCallback(object sender, System.Timers.ElapsedEventArgs e);

                static Socket serverSocket;//服务器套接字
                bool isServer = false;//是否开启了服务
                Thread receiveTh;//监听线程

                bool isSyncSet = false;

                long countR=0, countT=0;

                public UdpMain()
                {
                        InitializeComponent();//初始化界面
                        if (debug)
                        {
                                AllocConsole();
                                DebugWriteLine("控制台已打开！\n时间："+DateTime.Now.ToString(
                                        "[yyyy-MM-dd HH:mm:ss.fff] "), DEBUG_I);
                        }
                        InitIntfaceData();

                        //定时器
                        System.Timers.Timer timer = new System.Timers.Timer();
                        timer.Enabled = true;
                        timer.Interval = 1000; //执行间隔时间,单位为毫秒; 这里实际间隔为10分钟  
                        timer.Start();
                        timer.Elapsed += new System.Timers.ElapsedEventHandler(time); 
                }

                private void time(object sender, System.Timers.ElapsedEventArgs e)
                {
                        if (lbSendState.IsDisposed)
                        {
                                return;
                        }

                        //处理InvokeRequired，安全调用
                        if (this.lbSendState.InvokeRequired)
                        {
                                timeCallback d = new timeCallback(time);
                                this.Invoke(d, new object[] { sender, e});
                        }
                        else
                        {
                                lbSendState.Text = DateTime.Now.ToString("时间  HH:mm:ss");
                                lbSendState.Refresh();
                        }
                }


                private void InitIntfaceData()
                {
                        string HostName = Dns.GetHostName(); //得到主机名
                        if (debug)
                        {
                                DebugWriteLine("主机名：" + HostName, DEBUG_I);
                        }
                        IPHostEntry IpEntry = Dns.GetHostEntry(HostName);//通过主机名获取IP

                        ArrayList addressList = new ArrayList();//可变数组

                        addressList.Add("0.0.0.0");
                        addressList.Add("127.0.0.1");

                        for (int i = 0; i < IpEntry.AddressList.Length; i++)
                        {
                                //从IP地址列表中筛选出IPv4类型的IP地址
                                //AddressFamily.InterNetwork表示此IP为IPv4,
                                //AddressFamily.InterNetworkV6表示此地址为IPv6类型
                                if (IpEntry.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                                {
                                        if (debug)
                                        {
                                                DebugWriteLine("IPV4:" + IpEntry.AddressList[i].ToString(), DEBUG_I);
                                        }
                                        addressList.Add(IpEntry.AddressList[i].ToString());
                                }
                        }

                        addressList.TrimToSize();//固定大小

                        object[] adList = new object[addressList.Count];

                        for (int i = 0; i < addressList.Count; i++)
                        {
                                adList[i] = addressList[i];
                        }
                        
                        this.cbMyAddress.Items.AddRange(adList);
                        this.cbServerAddress.Items.AddRange(adList);
                        this.cbMyAddress.SelectedIndex = 0;
                        this.cbServerAddress.SelectedIndex = 0;
                }

                //给消息列表添加消息
                private void AddMessageToList(string name,byte[] content,int type)
                {

                        if (rtbMessageList.IsDisposed)
                        {
                                return;
                        }

                        //处理InvokeRequired，安全调用
                        if (this.rtbMessageList.InvokeRequired)
                        {
                                AddMessageToListCallback d = new AddMessageToListCallback(AddMessageToList);
                                this.Invoke(d, new object[] { name,content,type });
                        }
                        else
                        {

                                lbSendState.Text = "产生消息";
                                lbSendState.Refresh();
                                string str = "";


                                string show = "";
                                int i = 0;

                                if (cbHex.Checked)
                                {
                                        StringBuilder sb = new StringBuilder();
                                        for (i = 0; i < content.Length && content[i] != 0; i++)
                                        {
                                                sb.Append(content[i].ToString("X2"));
                                                sb.Append(" ");
                                        }
                                        show = sb.ToString();
                                }
                                else
                                {
                                        for (i = 0;i<content.Length && content[i] != 0; i++) { }
                                        show = Encoding.UTF8.GetString(content, 0, i);
                                }

                                if (debug)
                                {
                                        DebugWriteLine("共"+i+"个字符",DEBUG_I);
                                }

                                //构建消息头
                                switch(type)
                                {
                                        case RECEIVE:
                                                countR += i;
                                                this.rtbMessageList.SelectionColor = Color.Red;
                                                str = DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss.fff] ") + " 收到：" + name + "\n";
                                                break;
                                        case SEND:
                                                countT += i;
                                                this.rtbMessageList.SelectionColor = Color.Orange;
                                                str = DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss.fff] ") + " 发自：" + name + "\n";
                                                break;
                                }

                                //写入消息头
                                this.rtbMessageList.AppendText(str);

                                //写入消息内容
                                this.rtbMessageList.SelectionColor = Color.Black;

                                this.rtbMessageList.AppendText(show);
                                this.rtbMessageList.AppendText("\r\n");

                                this.lbCount.Text = "接收：" + countR + " 发送：" + countT;
                                lbSendState.Text = "";

                                if (debug)
                                {
                                        if (type == SEND)
                                        {
                                                DebugWriteLine("发送消息！发到：" + name + "    内容：" + show, DEBUG_I);
                                        }
                                        else
                                        {
                                                DebugWriteLine("收到消息！来自：" + name + "    内容：" + show, DEBUG_I);
                                        }
                                }
                        }
                }

                //点击“开启服务按钮”
                private void btnOpenServer_Click(object sender, EventArgs e)
                {
                        btnOpenServer.Enabled = false;//停用按钮，防止多次点击
                        if (debug)
                        {
                                DebugWriteLine("停用按钮！", DEBUG_I);
                        }
                        if (isServer)//如果服务是打开的
                        {
                                lbSendState.Text = "关闭服务器";

                                if (debug)
                                {
                                        DebugWriteLine("服务器处于打开状态！", DEBUG_S);
                                }

                                if (serverSocket != null)//如果套接字不为空
                                {
                                        receiveTh.Abort();//先关闭线程，再关闭服务器

                                        if (debug)
                                        {
                                                DebugWriteLine("关闭服务器！", DEBUG_I);
                                        }

                                        serverSocket.Close();//关闭
                                }

                                //设置界面为服务关闭状态
                                this.lbServerState.Text = "服务器已关闭";
                                this.lbServerState.ForeColor = Color.Blue;
                                this.btnOpenServer.Text = "打开服务";
                                this.pbServerState.BackgroundImage = global::UDP.Properties.Resources.close;
                                this.tbServerPort.ReadOnly = false;//允许编辑端口
                                this.cbServerAddress.Enabled = true;//允许编辑地址

                                cbSyncServer.Checked = false;//关闭同步

                                //设置服务为关闭状态
                                isServer = false;
                                lbSendState.Text = "";
                        }
                        else//如果服务是关闭的
                        {
                                lbSendState.Text = "开启服务器";
                                serverSocket = null;
                                if (debug)
                                {
                                        DebugWriteLine("服务器处于关闭状态！", DEBUG_S);
                                }

                                string ip = getIPAddress(cbServerAddress.Text);//获取地址
                                if (ip == null)
                                {
                                        if (debug)
                                        {
                                                DebugWriteLine("服务器地址不正确", DEBUG_E);
                                        }
                                        MessageBox.Show("服务器地址不正确，请输入IP或者域名！\n域名需要有DNS服务器！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        DebugWriteLine("启用按钮！", DEBUG_I);
                                        btnOpenServer.Enabled = true;
                                        return;
                                }
                                if (debug)
                                {
                                        DebugWriteLine("服务器地址：" + ip, DEBUG_S);
                                }

                                int port = getPort(tbServerPort.Text);
                                if (port == -1)
                                {
                                        if (debug)
                                        {
                                                DebugWriteLine("服务器端口格式不对！", DEBUG_E);
                                        }
                                        MessageBox.Show("服务器端口格式不对！（值：0 - 65535）", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                        if (debug)
                                        {
                                                DebugWriteLine("启用按钮！", DEBUG_I);
                                        }

                                        btnOpenServer.Enabled = true;
                                        return;
                                }

                                if (debug)
                                {
                                        DebugWriteLine("服务器端口：" + port, DEBUG_S);
                                }

                                try
                                {
                                        if (debug)
                                        {
                                                DebugWriteLine("服务器打开中......", DEBUG_I);
                                        }

                                        serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);//创建套接字，以UDP的方式
                                        serverSocket.Bind(new IPEndPoint(IPAddress.Parse(ip), port));//绑定端口号和IP
                                }
                                catch (SocketException es)//出现异常
                                {
                                        if (debug)
                                        {
                                                DebugWriteLine("出现异常：" + es.ErrorCode + "！", DEBUG_E);
                                        }

                                        MessageBox.Show("绑定端口时出现异常：" + es.ErrorCode + "！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                finally
                                {
                                        if (debug)
                                        {
                                                DebugWriteLine("启用按钮！", DEBUG_S);
                                        }
                                        //按钮启用
                                        btnOpenServer.Enabled = true;
                                }

                                if (serverSocket != null && serverSocket.IsBound)//如果打开了并且绑定端口了
                                {
                                        if (debug)
                                        {
                                                DebugWriteLine("服务器开启成功！", DEBUG_I);
                                        }

                                        //设置界面为服务打开状态
                                        this.lbServerState.Text = "服务器已开启";
                                        this.lbServerState.ForeColor = Color.Red;
                                        this.btnOpenServer.Text = "关闭服务";
                                        this.pbServerState.BackgroundImage = global::UDP.Properties.Resources.open;
                                        this.tbServerPort.ReadOnly = true;//不允许编辑端口
                                        this.cbServerAddress.Enabled = false;//不允许编辑地址
                                        //设置服务为打开状态
                                        isServer = true;

                                        //开启接收消息线程
                                        receiveTh = new Thread(ReciveMsg);
                                        receiveTh.Start();

                                        //打开同步
                                        cbSyncServer.Checked = true;
                                }
                        }

                        if (debug)
                        {
                                DebugWriteLine("启用按钮！", DEBUG_S);
                        }

                        btnOpenServer.Enabled = true;
                        lbSendState.Text = "";
                }

                //发送数据报
                private void btnSendMessage_Click(object sender, EventArgs e)
                {
                        lbSendState.Text = "发送数据报";
                        bool isUseServer = false;//表示这个是不是服务器的套接字
                        Socket clientSocket = null;

                        btnSendMessage.Enabled = false;//停用按钮，防止多次点击

                        if (debug)
                        {
                                DebugWriteLine("停用按钮！", DEBUG_S);
                        }

                        if (isServer //如果服务是打开的
                                && (serverSocket != null)
                                &&cbServerAddress.Text.Equals(cbMyAddress.Text) //并且服务器和发送的设置是一样的
                                && tbServerPort.Text.Equals(tbMyPort.Text))
                        {
                                isUseServer = true;
                                clientSocket = serverSocket;//直接使用服务器的套接字
                        }
                        else//如果服务是关闭的,或者设置不同
                        {
                                string myIp = getIPAddress(cbMyAddress.Text);//获取地址
                                if (myIp == null)
                                {
                                        if (debug)
                                        {
                                                DebugWriteLine("发送端地址不正确", DEBUG_E);
                                        }

                                        MessageBox.Show("发送端地址不正确，请输入IP或者域名！\n域名需要有DNS服务器！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        DebugWriteLine("启用按钮！", DEBUG_I);
                                        btnSendMessage.Enabled = true;
                                        return;
                                }

                                if (debug)
                                {
                                        DebugWriteLine("发送端地址：" + myIp, DEBUG_S);
                                }

                                int myPort = getPort(tbMyPort.Text);
                                if (myPort == -1)
                                {
                                        if (debug)
                                        {
                                                DebugWriteLine("发送端端口格式不对！", DEBUG_E);
                                        }

                                        MessageBox.Show("发送端端口格式不对！（值：0 - 65535）", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                        if (debug)
                                        {
                                                DebugWriteLine("启用按钮！", DEBUG_I);
                                        }

                                        btnSendMessage.Enabled = true;
                                        return;
                                }

                                if (debug)
                                {
                                        DebugWriteLine("发送端端口：" + myPort, DEBUG_S);
                                }

                                clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);//创建套接字
                                clientSocket.Bind(new IPEndPoint(IPAddress.Parse(myIp), myPort));//绑定端口号和IP
                        }

                        string adIp = getIPAddress(tbAbverseIp.Text);//获取地址
                        if (adIp == null)
                        {
                                if (debug)
                                {
                                        DebugWriteLine("对方主机地址不正确", DEBUG_E);
                                }

                                MessageBox.Show("对方主机地址不正确，请输入IP或者域名！\n域名需要有DNS服务器！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                if (debug)
                                {
                                        DebugWriteLine("启用按钮！", DEBUG_I);
                                }

                                btnSendMessage.Enabled = true;
                                return;
                        }

                        if (debug)
                        {
                                DebugWriteLine("对方主机地址：" + adIp, DEBUG_S);
                        }

                        int adPort = getPort(tbAbversePort.Text);//对方端口
                        if (adPort == -1)
                        {
                                if (debug)
                                {
                                        DebugWriteLine("对方主机端口格式不对！", DEBUG_E);
                                }

                                MessageBox.Show("对方主机端口格式不对！（值：0 - 65535）", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                if (debug)
                                {
                                        DebugWriteLine("启用按钮！", DEBUG_I);
                                }

                                btnSendMessage.Enabled = true;
                                return;
                        }

                        if (debug)
                        {
                                DebugWriteLine("接收端端口：" + adPort, DEBUG_S);
                        }

                        EndPoint adversePoint = new IPEndPoint(IPAddress.Parse(adIp), adPort); //设置好地址

                        try
                        {
                                string msg = tbInput.Text;
                                if (!string.IsNullOrEmpty(msg))//如果不为空
                                {
                                        byte[] bmsg = Encoding.UTF8.GetBytes(msg);
                                        if (bmsg != null)
                                        {
                                                if (cbAddRN.Checked)
                                                {
                                                        byte[] rn = new byte[2];
                                                        rn[0] = 0x0d;//13,\r
                                                        rn[1] = 0x0a;//10,\n

                                                        bmsg = bmsg.Concat(rn).ToArray();
                                                }
                                        }
                                        clientSocket.SendTo(bmsg, adversePoint);//发送数据包
                                        AddMessageToList(adversePoint.ToString(), bmsg, SEND);//UI显示
                                }
                        }
                        catch (SocketException es)
                        {
                                if (debug)
                                {
                                        DebugWriteLine("出现异常：" + es.ErrorCode + "！", DEBUG_E);
                                }

                                MessageBox.Show("发送数据报时出现异常：" + es.ErrorCode + "！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        if (!isUseServer)//如果是新开的套接字
                        {
                                if (clientSocket != null)
                                {
                                        clientSocket.Close();//用完之后关掉
                                }
                        }

                        if (debug)
                        {
                                DebugWriteLine("启用按钮！", DEBUG_S);
                        }

                        btnSendMessage.Enabled = true;
                        lbSendState.Text = "";
                }

                // 接收发送给本机IP对应端口号的数据报
                private void ReciveMsg()
                {
                        try
                        {
                                while (isServer)
                                {
                                        EndPoint point = new IPEndPoint(IPAddress.Any, 0);//用来保存发送方的IP和端口号
                                        byte[] buffer = new byte[2048];//消息缓存区申请
                                        int length = serverSocket.ReceiveFrom(buffer, ref point);//接收数据报

                                        //显示在消息列表里
                                        AddMessageToList(point.ToString(), buffer, RECEIVE);
                                }
                        }
                        catch(SocketException e)
                        {
                                DebugWriteLine(e.Message, DEBUG_E);
                        }
                }


                //窗口关闭事件委托，在窗口关闭事件前处理
                private void UdpForm_FormClosing(object sender, FormClosingEventArgs e)
                {
                        isServer = false;

                        if (receiveTh != null)
                        {
                                if (debug)
                                {
                                        DebugWriteLine("关闭接收线程！", DEBUG_I);
                                }

                                receiveTh.Abort();
                        }

                        if (serverSocket != null)
                        {
                                if (debug)
                                {
                                        DebugWriteLine("关闭服务器！", DEBUG_I);
                                }

                                serverSocket.Close();
                        }

                        if (debug)
                        {
                                DebugWriteLine("关闭窗口！", DEBUG_I);
                        }
                }

                //清空消息列表
                private void btnClearList_Click(object sender, EventArgs e)
                {
                        if (debug)
                        {
                                DebugWriteLine("清空消息列表！", DEBUG_I);
                        }

                        rtbMessageList.Text = "";
                }

                //清空输入框
                private void btnClearInput_Click(object sender, EventArgs e)
                {
                        if (debug)
                        {
                                DebugWriteLine("清空输入框！", DEBUG_I);
                        }

                        tbInput.Text = "";
                }

                //根据字符串获取端口
                private int getPort(string str)
                {
                        if (!IsPort(str))//不是端口
                        {
                                return -1;
                        }

                        int port = Convert.ToInt32(str);//转换成整型

                        if (port >= 0 && port <= 65535)//如果是合法端口
                        {
                                return port;
                        }
                        else//不是合法端口
                        {
                                return -1;
                        }
                }

                //根据字符串获取IP地址
                string getIPAddress(string str)
                {
                        if (!IsIP(str))//如果不是IP
                        {
                                if (IsDomain(str))//如果是域名
                                {
                                        try
                                        {
                                                //解析域名
                                                IPAddress[] host = Dns.GetHostAddresses(str);//域名解析的IP地址
                                                IPAddress ipAddress = host[0];
                                                str = ipAddress.ToString();//改成IP地址
                                        }
                                        catch
                                        {
                                                return null;
                                        }
                                }
                                else
                                {
                                         return null;
                                }
                        }
                        return str;//返回IP地址
                }

                // 验证字符串是否是域名
                public bool IsDomain(string str)
                {
                        string pattern = @"^(?=^.{3,255}$)[a-zA-Z0-9][-a-zA-Z0-9]{0,62}(\.[a-zA-Z0-9][-a-zA-Z0-9]{0,62})+$";
                        return IsMatch(pattern, str);
                }

                // 验证字符串是否是IP
                bool IsIP(string str)
                {
                        string pattern = @"(25[0-5]|2[0-4]\d|[0-1]\d{2}|[1-9]?\d)\.(25[0-5]|2[0-4]\d|[0-1]\d{2}|[1-9]?\d)\.(25[0-5]|2[0-4]\d|[0-1]\d{2}|[1-9]?\d)\.(25[0-5]|2[0-4]\d|[0-1]\d{2}|[1-9]?\d)";
                        return IsMatch(pattern, str);
                }

                //判断是否为0-65535的数字
                bool IsPort(string str)
                {
                        string pattern = @"^([0-9]|[1-9]\d|[1-9]\d{2}|[1-9]\d{3}|[1-5]\d{4}|6[0-4]\d{3}|65[0-4]\d{2}|655[0-2]\d|6553[0-5])$";
                        return IsMatch(pattern, str);
                }

                // 判断一个字符串，是否匹配指定的表达式(区分大小写的情况下)
                public bool IsMatch(string expression, string str)
                {
                        Regex reg = new Regex(expression);
                        if (string.IsNullOrEmpty(str))
                        {
                                return false;
                        }
                        return reg.IsMatch(str);
                }

                //勾选与取消勾选“与服务器同步设置”
                private void cbSyncServer_CheckedChanged(object sender, EventArgs e)
                {
                        CheckBox cb = (CheckBox)sender;
                        if (cb.Equals(cbSyncServer))
                        {
                                if (cb.Checked)//同步设置
                                {
                                        isSyncSet = true;
                                        cbMyAddress.Enabled = false;
                                        tbMyPort.ReadOnly = true;

                                        cbMyAddress.Text = cbServerAddress.Text;//复制服务器的地址
                                        tbMyPort.Text = tbServerPort.Text;//复制服务器的端口
                                }
                                else//不同步设置
                                {
                                        isSyncSet = false;
                                        cbMyAddress.Enabled = true;
                                        tbMyPort.ReadOnly = false;
                                }
                        }
                }

                //同步地址事件
                private void cbServerAddress_TextChanged(object sender, EventArgs e)
                {
                        if (isSyncSet)
                        {
                                cbMyAddress.Text = cbServerAddress.Text;//复制服务器的地址
                        }
                }
                
                //同步端口事件
                private void tbServerPort_TextChanged(object sender, EventArgs e)
                {
                        if (isSyncSet)
                        {
                                tbMyPort.Text = tbServerPort.Text;//复制服务器的端口
                        }
                }
                /// <summary>
                /// 实现自动下拉
                /// </summary>
                /// <param name="sender"></param>
                /// <param name="e"></param>
                private void rtbMessageList_TextChanged(object sender, EventArgs e)
                {
                        rtbMessageList.SelectionStart = rtbMessageList.Text.Length;
                        rtbMessageList.ScrollToCaret(); 
                }

                private void lbHelp_Click(object sender, EventArgs e)
                {
                        MessageBox.Show("这个程序是一个UDP收发器，能接收和发送UDP报文。\nUDP广播地址：***.***.***.255\n2020-4 Minuy.top 网络编程作业\n开源地址：https://gitee.com/minuy/udp-transceiver", "帮助", MessageBoxButtons.OK);
                }

        }
}
