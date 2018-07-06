using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DTU模块测试软件
{
    public partial class module : UserControl
    {
        protected override CreateParams CreateParams
        {
            get
            {
                var parms = base.CreateParams;
                parms.Style &= ~0x02000000; // Turn off WS_CLIPCHILDREN 
                return parms;
            }
        }
        /// <summary>
        /// 自定义控件需要展示的数据
        /// </summary>
        public struct mod
        {
            /// <summary>
            /// 模块状态:正常,错误(有很多种)
            /// </summary>
            public string la1;
            /// <summary>
            /// 模块编号
            /// </summary>
            public string ID;
            /// <summary>
            /// 模块物联网卡号
            /// </summary>
            public string CardID;
            /// <summary>
            /// 模块网络状态
            /// </summary>
            public string NetState;
            /// <summary>
            /// 模块无线信号强度
            /// </summary>
            public string signal;
            /// <summary>
            /// 模块与服务器的心跳计数
            /// </summary>
            public string heartBeats;
            /// <summary>
            /// 电脑与模块的通信状态
            /// </summary>
            public string link;
            /// <summary>
            /// 重启按键启用
            /// </summary>
            public bool b1;
            public bool b2;
            public bool b3;
            public bool b4;
        }
        /// <summary>
        /// 自定义控件数据结构体
        /// </summary>
        public static mod a=new mod();
        /// <summary>
        /// 更新自定义控件数据
        /// </summary>
        public mod par
        {
            get
            {
                return par;
            }
            set
            {
                a = par;
                la1.Text = a.la1;
                ID.Text = "设备编号:" + a.ID;
                CardID.Text = "物联网卡号:" + a.CardID;
                NetState.Text = a.NetState;
                signal.Text = "信号强度:" + a.signal;
                heartBeats.Text = "心跳计数:" + a.heartBeats;
                link.Text = "通信状态:" + a.link;
                button1.Enabled = a.b1;
                base.Refresh();
            }
        }
        public module()
        {
            InitializeComponent();
        }
        //重新启动通信芯片
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
        }
        //打开日志文件
        private void button2_Click(object sender, EventArgs e)
        {
            //用记事本打开日志文件
            System.Diagnostics.Process.Start("notepad.exe", "D:\\a.txt");
        }
        //打开调试窗口
        private void button3_Click(object sender, EventArgs e)
        {
            Debug D = new Debug();
            D.ID = a.ID;
            D.CardID = a.CardID;
            D.NetState = a.NetState;
            D.signal = a.signal;
            D.heartBeats = a.heartBeats;
            D.la1 = a.la1;
            D.link = a.link;
            D.Show();
        }
        //更新控件展示信息
        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
