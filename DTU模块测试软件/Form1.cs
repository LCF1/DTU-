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
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
            load();
        }
        /// <summary>
        /// 加载自定义控件
        /// </summary>
        void load()
        {
            int x =80, y = 30,n=1;
            for (int i = 0; i < 100; i++)
            {
                //自定义控件信息
                module  a1 = new module();
                a1.Name = "M" + i.ToString();//控件名称,
                if (i == 4 * n)
                { x = 80;n++; y = y + 130;}
                a1.Location = new Point(x, y);//控件加载位置
                
                //a1.load(i);
                splitContainer1.Panel2.Controls.Add(a1);
                if(i < 4*n )
                {  x += 300;}
                
            }
           
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // Turn on WS_EX_COMPOSITED 
                return cp;
            }
        }
    }
    


}
