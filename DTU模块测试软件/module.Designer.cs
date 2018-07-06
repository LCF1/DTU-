namespace DTU模块测试软件
{
    partial class module
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.ID = new System.Windows.Forms.Label();
            this.CardID = new System.Windows.Forms.Label();
            this.NetState1 = new System.Windows.Forms.Label();
            this.heartBeats = new System.Windows.Forms.Label();
            this.NetState = new System.Windows.Forms.Label();
            this.signal = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.link = new System.Windows.Forms.Label();
            this.la1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 101);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(42, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "重启";
            this.toolTip1.SetToolTip(this.button1, "重启通信芯片");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ID
            // 
            this.ID.AutoSize = true;
            this.ID.Location = new System.Drawing.Point(3, 10);
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(59, 12);
            this.ID.TabIndex = 1;
            this.ID.Text = "设备编号:";
            // 
            // CardID
            // 
            this.CardID.AutoSize = true;
            this.CardID.Location = new System.Drawing.Point(3, 31);
            this.CardID.Name = "CardID";
            this.CardID.Size = new System.Drawing.Size(71, 12);
            this.CardID.TabIndex = 2;
            this.CardID.Text = "物联网卡号:";
            // 
            // NetState1
            // 
            this.NetState1.AutoSize = true;
            this.NetState1.Location = new System.Drawing.Point(3, 52);
            this.NetState1.Name = "NetState1";
            this.NetState1.Size = new System.Drawing.Size(59, 12);
            this.NetState1.TabIndex = 3;
            this.NetState1.Text = "网络状态:";
            // 
            // heartBeats
            // 
            this.heartBeats.AutoSize = true;
            this.heartBeats.Location = new System.Drawing.Point(3, 73);
            this.heartBeats.Name = "heartBeats";
            this.heartBeats.Size = new System.Drawing.Size(59, 12);
            this.heartBeats.TabIndex = 4;
            this.heartBeats.Text = "心跳计数:";
            // 
            // NetState
            // 
            this.NetState.AutoSize = true;
            this.NetState.ForeColor = System.Drawing.SystemColors.GrayText;
            this.NetState.Location = new System.Drawing.Point(60, 52);
            this.NetState.Name = "NetState";
            this.NetState.Size = new System.Drawing.Size(17, 12);
            this.NetState.TabIndex = 5;
            this.NetState.Text = "●";
            // 
            // signal
            // 
            this.signal.AutoSize = true;
            this.signal.Location = new System.Drawing.Point(148, 52);
            this.signal.Name = "signal";
            this.signal.Size = new System.Drawing.Size(59, 12);
            this.signal.TabIndex = 6;
            this.signal.Text = "信号强度:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(79, 101);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(42, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "日志";
            this.toolTip1.SetToolTip(this.button2, "打开日志文件");
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(145, 101);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(42, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "调试";
            this.toolTip1.SetToolTip(this.button3, "进入调试模式");
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(211, 101);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(42, 23);
            this.button4.TabIndex = 9;
            this.button4.Text = "刷新";
            this.toolTip1.SetToolTip(this.button4, "手动更新展示数据");
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // link
            // 
            this.link.AutoSize = true;
            this.link.Location = new System.Drawing.Point(148, 73);
            this.link.Name = "link";
            this.link.Size = new System.Drawing.Size(59, 12);
            this.link.TabIndex = 10;
            this.link.Text = "通信状态:";
            // 
            // la1
            // 
            this.la1.AutoSize = true;
            this.la1.Location = new System.Drawing.Point(200, 10);
            this.la1.Name = "la1";
            this.la1.Size = new System.Drawing.Size(53, 12);
            this.la1.TabIndex = 11;
            this.la1.Text = "模块状态";
            this.toolTip1.SetToolTip(this.la1, "显示模块状态");
            // 
            // module
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.la1);
            this.Controls.Add(this.link);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.signal);
            this.Controls.Add(this.NetState);
            this.Controls.Add(this.heartBeats);
            this.Controls.Add(this.NetState1);
            this.Controls.Add(this.CardID);
            this.Controls.Add(this.ID);
            this.Controls.Add(this.button1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "module";
            this.Size = new System.Drawing.Size(271, 129);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label ID;
        private System.Windows.Forms.Label CardID;
        private System.Windows.Forms.Label NetState1;
        private System.Windows.Forms.Label heartBeats;
        private System.Windows.Forms.Label NetState;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label signal;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label link;
        private System.Windows.Forms.Label la1;
    }
}
