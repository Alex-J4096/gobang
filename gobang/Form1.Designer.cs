
namespace gobang
{
    partial class Form1
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.游戏ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建对局ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.人机对战ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.人人对战ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chessBoard = new System.Windows.Forms.PictureBox();
            this.btn_Start = new System.Windows.Forms.Button();
            this.btn_Load = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.TxboxComposInfo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chessBoard)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.游戏ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(774, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 游戏ToolStripMenuItem
            // 
            this.游戏ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建对局ToolStripMenuItem,
            this.人机对战ToolStripMenuItem,
            this.人人对战ToolStripMenuItem});
            this.游戏ToolStripMenuItem.Name = "游戏ToolStripMenuItem";
            this.游戏ToolStripMenuItem.Size = new System.Drawing.Size(53, 26);
            this.游戏ToolStripMenuItem.Text = "游戏";
            // 
            // 新建对局ToolStripMenuItem
            // 
            this.新建对局ToolStripMenuItem.Name = "新建对局ToolStripMenuItem";
            this.新建对局ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.新建对局ToolStripMenuItem.Text = "新建对局";
            // 
            // 人机对战ToolStripMenuItem
            // 
            this.人机对战ToolStripMenuItem.Name = "人机对战ToolStripMenuItem";
            this.人机对战ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.人机对战ToolStripMenuItem.Text = "人机对战";
            this.人机对战ToolStripMenuItem.Click += new System.EventHandler(this.人机对战ToolStripMenuItem_Click);
            // 
            // 人人对战ToolStripMenuItem
            // 
            this.人人对战ToolStripMenuItem.Name = "人人对战ToolStripMenuItem";
            this.人人对战ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.人人对战ToolStripMenuItem.Text = "人人对战";
            this.人人对战ToolStripMenuItem.Click += new System.EventHandler(this.人人对战ToolStripMenuItem_Click);
            // 
            // chessBoard
            // 
            this.chessBoard.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.chessBoard.Location = new System.Drawing.Point(40, 60);
            this.chessBoard.Name = "chessBoard";
            this.chessBoard.Size = new System.Drawing.Size(337, 303);
            this.chessBoard.TabIndex = 1;
            this.chessBoard.TabStop = false;
            this.chessBoard.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chessBoard_MouseClick);
            // 
            // btn_Start
            // 
            this.btn_Start.Location = new System.Drawing.Point(466, 203);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(89, 32);
            this.btn_Start.TabIndex = 3;
            this.btn_Start.Text = "开始";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // btn_Load
            // 
            this.btn_Load.Enabled = false;
            this.btn_Load.Location = new System.Drawing.Point(466, 299);
            this.btn_Load.Name = "btn_Load";
            this.btn_Load.Size = new System.Drawing.Size(89, 32);
            this.btn_Load.TabIndex = 5;
            this.btn_Load.Text = "读取";
            this.btn_Load.UseVisualStyleBackColor = true;
            this.btn_Load.Click += new System.EventHandler(this.btn_Load_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Enabled = false;
            this.btn_Save.Location = new System.Drawing.Point(466, 250);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(89, 32);
            this.btn_Save.TabIndex = 4;
            this.btn_Save.Text = "保存";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // TxboxComposInfo
            // 
            this.TxboxComposInfo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.TxboxComposInfo.Location = new System.Drawing.Point(466, 60);
            this.TxboxComposInfo.Multiline = true;
            this.TxboxComposInfo.Name = "TxboxComposInfo";
            this.TxboxComposInfo.ReadOnly = true;
            this.TxboxComposInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxboxComposInfo.Size = new System.Drawing.Size(242, 93);
            this.TxboxComposInfo.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(565, 203);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "  玩家已用时：00:00";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(595, 238);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "AI已用时：00:00";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 486);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.TxboxComposInfo);
            this.Controls.Add(this.btn_Load);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.btn_Start);
            this.Controls.Add(this.chessBoard);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chessBoard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 游戏ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新建对局ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 人机对战ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 人人对战ToolStripMenuItem;
        private System.Windows.Forms.PictureBox chessBoard;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.Button btn_Load;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.TextBox TxboxComposInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;
    }
}

