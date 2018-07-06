using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DTU模块测试软件
{
    public partial class Debug : Form
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
      
        public Debug()
        {
            InitializeComponent();
        }
    }
}
