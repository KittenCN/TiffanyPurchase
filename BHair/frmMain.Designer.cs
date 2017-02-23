namespace BHair
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.dPanelMain = new WinFormsUI.Docking.DockPanel();
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.登陆ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMain_Day = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMain_Flow_add = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMain_Manage_StoreApp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMain_Manage_Approval2App = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMain_Manage_ApprovalApp = new System.Windows.Forms.ToolStripMenuItem();
            this.购买确认ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.财务部审核ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMain_Table = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMain_Manage_History = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMain_System = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMain_System_Member = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMain_Manage_Store = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMain_System_Item = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMain_System_Setup = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuMain_System_Config = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMain_System_Log = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMain_System_Pwd = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuMain_System_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.ssrMain = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssrMain_Timer = new System.Windows.Forms.ToolStripStatusLabel();
            this.tmrMain = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton12 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.tsbtnCW = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton13 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton9 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton10 = new System.Windows.Forms.ToolStripButton();
            this.AccessQueueTimer = new System.Windows.Forms.Timer(this.components);
            this.AlertTimer = new System.Windows.Forms.Timer(this.components);
            this.timer_Close = new System.Windows.Forms.Timer(this.components);
            this.menuMain.SuspendLayout();
            this.ssrMain.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dPanelMain
            // 
            this.dPanelMain.ActiveAutoHideContent = null;
            this.dPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dPanelMain.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.dPanelMain.Location = new System.Drawing.Point(0, 113);
            this.dPanelMain.Margin = new System.Windows.Forms.Padding(4);
            this.dPanelMain.Name = "dPanelMain";
            this.dPanelMain.Size = new System.Drawing.Size(1162, 549);
            this.dPanelMain.TabIndex = 0;
            // 
            // menuMain
            // 
            this.menuMain.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.登陆ToolStripMenuItem,
            this.menuMain_Day,
            this.menuMain_Table,
            this.menuMain_System});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuMain.Size = new System.Drawing.Size(1162, 34);
            this.menuMain.TabIndex = 3;
            this.menuMain.Text = "menuStrip1";
            this.menuMain.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuMain_ItemClicked);
            // 
            // 登陆ToolStripMenuItem
            // 
            this.登陆ToolStripMenuItem.Name = "登陆ToolStripMenuItem";
            this.登陆ToolStripMenuItem.Size = new System.Drawing.Size(79, 28);
            this.登陆ToolStripMenuItem.Text = "登陆(&L)";
            this.登陆ToolStripMenuItem.Click += new System.EventHandler(this.登陆ToolStripMenuItem_Click);
            // 
            // menuMain_Day
            // 
            this.menuMain_Day.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMain_Flow_add,
            this.menuMain_Manage_StoreApp,
            this.menuMain_Manage_Approval2App,
            this.menuMain_Manage_ApprovalApp,
            this.购买确认ToolStripMenuItem,
            this.财务部审核ToolStripMenuItem});
            this.menuMain_Day.Name = "menuMain_Day";
            this.menuMain_Day.Size = new System.Drawing.Size(120, 28);
            this.menuMain_Day.Text = "内购流程(&D)";
            // 
            // menuMain_Flow_add
            // 
            this.menuMain_Flow_add.Name = "menuMain_Flow_add";
            this.menuMain_Flow_add.Size = new System.Drawing.Size(260, 30);
            this.menuMain_Flow_add.Text = "内购申请(&P)";
            this.menuMain_Flow_add.Visible = false;
            this.menuMain_Flow_add.Click += new System.EventHandler(this.menuMain_Flow_add_Click);
            // 
            // menuMain_Manage_StoreApp
            // 
            this.menuMain_Manage_StoreApp.Name = "menuMain_Manage_StoreApp";
            this.menuMain_Manage_StoreApp.Size = new System.Drawing.Size(260, 30);
            this.menuMain_Manage_StoreApp.Text = "内购申请进度查看(&B)";
            this.menuMain_Manage_StoreApp.Visible = false;
            this.menuMain_Manage_StoreApp.Click += new System.EventHandler(this.menuMain_Manage_StoreApp_Click);
            // 
            // menuMain_Manage_Approval2App
            // 
            this.menuMain_Manage_Approval2App.Name = "menuMain_Manage_Approval2App";
            this.menuMain_Manage_Approval2App.Size = new System.Drawing.Size(260, 30);
            this.menuMain_Manage_Approval2App.Text = "经理审核(&F)";
            this.menuMain_Manage_Approval2App.Visible = false;
            this.menuMain_Manage_Approval2App.Click += new System.EventHandler(this.menuMain_Manage_Approval2App_Click);
            // 
            // menuMain_Manage_ApprovalApp
            // 
            this.menuMain_Manage_ApprovalApp.Name = "menuMain_Manage_ApprovalApp";
            this.menuMain_Manage_ApprovalApp.Size = new System.Drawing.Size(260, 30);
            this.menuMain_Manage_ApprovalApp.Text = "商品部审核(&C)";
            this.menuMain_Manage_ApprovalApp.Visible = false;
            this.menuMain_Manage_ApprovalApp.Click += new System.EventHandler(this.menuMain_Manage_ApprovalApp_Click);
            // 
            // 购买确认ToolStripMenuItem
            // 
            this.购买确认ToolStripMenuItem.Name = "购买确认ToolStripMenuItem";
            this.购买确认ToolStripMenuItem.Size = new System.Drawing.Size(260, 30);
            this.购买确认ToolStripMenuItem.Text = "店面购买确认(&G)";
            this.购买确认ToolStripMenuItem.Click += new System.EventHandler(this.购买确认ToolStripMenuItem_Click);
            // 
            // 财务部审核ToolStripMenuItem
            // 
            this.财务部审核ToolStripMenuItem.Name = "财务部审核ToolStripMenuItem";
            this.财务部审核ToolStripMenuItem.Size = new System.Drawing.Size(260, 30);
            this.财务部审核ToolStripMenuItem.Text = "财务部审核";
            this.财务部审核ToolStripMenuItem.Visible = false;
            this.财务部审核ToolStripMenuItem.Click += new System.EventHandler(this.财务部审核ToolStripMenuItem_Click);
            // 
            // menuMain_Table
            // 
            this.menuMain_Table.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMain_Manage_History});
            this.menuMain_Table.Name = "menuMain_Table";
            this.menuMain_Table.Size = new System.Drawing.Size(116, 28);
            this.menuMain_Table.Text = "历史查询(&T)";
            // 
            // menuMain_Manage_History
            // 
            this.menuMain_Manage_History.Name = "menuMain_Manage_History";
            this.menuMain_Manage_History.Size = new System.Drawing.Size(227, 30);
            this.menuMain_Manage_History.Text = "历史内购查询(&H)";
            this.menuMain_Manage_History.Visible = false;
            this.menuMain_Manage_History.Click += new System.EventHandler(this.menuMain_Manage_History_Click);
            // 
            // menuMain_System
            // 
            this.menuMain_System.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMain_System_Member,
            this.menuMain_Manage_Store,
            this.menuMain_System_Item,
            this.menuMain_System_Setup,
            this.toolStripMenuItem1,
            this.menuMain_System_Config,
            this.menuMain_System_Log,
            this.menuMain_System_Pwd,
            this.toolStripMenuItem2,
            this.menuMain_System_Exit});
            this.menuMain_System.Name = "menuMain_System";
            this.menuMain_System.Size = new System.Drawing.Size(116, 28);
            this.menuMain_System.Text = "系统维护(&S)";
            // 
            // menuMain_System_Member
            // 
            this.menuMain_System_Member.Name = "menuMain_System_Member";
            this.menuMain_System_Member.Size = new System.Drawing.Size(224, 30);
            this.menuMain_System_Member.Text = "会员管理(&M)";
            this.menuMain_System_Member.Visible = false;
            this.menuMain_System_Member.Click += new System.EventHandler(this.menuMain_System_Member_Click);
            // 
            // menuMain_Manage_Store
            // 
            this.menuMain_Manage_Store.Name = "menuMain_Manage_Store";
            this.menuMain_Manage_Store.Size = new System.Drawing.Size(224, 30);
            this.menuMain_Manage_Store.Text = "店面管理(&S)";
            this.menuMain_Manage_Store.Visible = false;
            this.menuMain_Manage_Store.Click += new System.EventHandler(this.menuMain_Manage_Store_Click);
            // 
            // menuMain_System_Item
            // 
            this.menuMain_System_Item.Name = "menuMain_System_Item";
            this.menuMain_System_Item.Size = new System.Drawing.Size(224, 30);
            this.menuMain_System_Item.Text = "商品信息管理(&I)";
            this.menuMain_System_Item.Visible = false;
            this.menuMain_System_Item.Click += new System.EventHandler(this.menuMain_System_Item_Click);
            // 
            // menuMain_System_Setup
            // 
            this.menuMain_System_Setup.Name = "menuMain_System_Setup";
            this.menuMain_System_Setup.Size = new System.Drawing.Size(224, 30);
            this.menuMain_System_Setup.Text = "系统设置(&D)";
            this.menuMain_System_Setup.Click += new System.EventHandler(this.menuMain_System_Setup_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(221, 6);
            // 
            // menuMain_System_Config
            // 
            this.menuMain_System_Config.Name = "menuMain_System_Config";
            this.menuMain_System_Config.Size = new System.Drawing.Size(224, 30);
            this.menuMain_System_Config.Text = "注销(&C)";
            this.menuMain_System_Config.Click += new System.EventHandler(this.menuMain_System_Config_Click);
            // 
            // menuMain_System_Log
            // 
            this.menuMain_System_Log.Name = "menuMain_System_Log";
            this.menuMain_System_Log.Size = new System.Drawing.Size(224, 30);
            this.menuMain_System_Log.Text = "查看日志(&L)";
            this.menuMain_System_Log.Visible = false;
            this.menuMain_System_Log.Click += new System.EventHandler(this.menuMain_System_Log_Click);
            // 
            // menuMain_System_Pwd
            // 
            this.menuMain_System_Pwd.Name = "menuMain_System_Pwd";
            this.menuMain_System_Pwd.Size = new System.Drawing.Size(224, 30);
            this.menuMain_System_Pwd.Text = "修改个人信息(&P)";
            this.menuMain_System_Pwd.Visible = false;
            this.menuMain_System_Pwd.Click += new System.EventHandler(this.menuMain_System_Pwd_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(221, 6);
            // 
            // menuMain_System_Exit
            // 
            this.menuMain_System_Exit.Name = "menuMain_System_Exit";
            this.menuMain_System_Exit.Size = new System.Drawing.Size(224, 30);
            this.menuMain_System_Exit.Text = "退出(&E)";
            this.menuMain_System_Exit.Click += new System.EventHandler(this.menuMain_System_Exit_Click);
            // 
            // ssrMain
            // 
            this.ssrMain.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.ssrMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tssrMain_Timer});
            this.ssrMain.Location = new System.Drawing.Point(0, 629);
            this.ssrMain.Name = "ssrMain";
            this.ssrMain.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.ssrMain.Size = new System.Drawing.Size(1162, 33);
            this.ssrMain.SizingGrip = false;
            this.ssrMain.TabIndex = 4;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(982, 28);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "员工内购系统";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tssrMain_Timer
            // 
            this.tssrMain_Timer.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.tssrMain_Timer.Name = "tssrMain_Timer";
            this.tssrMain_Timer.Size = new System.Drawing.Size(157, 28);
            this.tssrMain_Timer.Text = "[tssrMain_Timer]";
            // 
            // tmrMain
            // 
            this.tmrMain.Enabled = true;
            this.tmrMain.Interval = 1000;
            this.tmrMain.Tick += new System.EventHandler(this.tmrMain_Tick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.toolStripButton4,
            this.toolStripButton12,
            this.toolStripButton1,
            this.toolStripButton5,
            this.tsbtnCW,
            this.toolStripButton13,
            this.toolStripButton3,
            this.toolStripSeparator2,
            this.toolStripButton8,
            this.toolStripButton2,
            this.toolStripButton6,
            this.toolStripButton9,
            this.toolStripButton7,
            this.toolStripButton10});
            this.toolStrip1.Location = new System.Drawing.Point(0, 34);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip1.Size = new System.Drawing.Size(1162, 79);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 79);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(86, 76);
            this.toolStripButton4.Text = "内购申请";
            this.toolStripButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton4.Visible = false;
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripButton12
            // 
            this.toolStripButton12.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton12.Image")));
            this.toolStripButton12.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton12.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton12.Name = "toolStripButton12";
            this.toolStripButton12.Size = new System.Drawing.Size(122, 76);
            this.toolStripButton12.Text = "申请进度查看";
            this.toolStripButton12.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton12.ToolTipText = "店面申请单状态";
            this.toolStripButton12.Visible = false;
            this.toolStripButton12.Click += new System.EventHandler(this.toolStripButton12_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(86, 76);
            this.toolStripButton1.Text = "经理审核";
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton1.ToolTipText = "财务部审核";
            this.toolStripButton1.Visible = false;
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(104, 76);
            this.toolStripButton5.Text = "商品部审核";
            this.toolStripButton5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton5.ToolTipText = "商品部审核";
            this.toolStripButton5.Visible = false;
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click_1);
            // 
            // tsbtnCW
            // 
            this.tsbtnCW.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnCW.Image")));
            this.tsbtnCW.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnCW.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnCW.Name = "tsbtnCW";
            this.tsbtnCW.Size = new System.Drawing.Size(104, 76);
            this.tsbtnCW.Text = "财务部审核";
            this.tsbtnCW.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnCW.ToolTipText = "财务部审核";
            this.tsbtnCW.Visible = false;
            this.tsbtnCW.Click += new System.EventHandler(this.tsbtnCW_Click);
            // 
            // toolStripButton13
            // 
            this.toolStripButton13.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton13.Image")));
            this.toolStripButton13.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton13.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton13.Name = "toolStripButton13";
            this.toolStripButton13.Size = new System.Drawing.Size(122, 76);
            this.toolStripButton13.Text = "店面确认购买";
            this.toolStripButton13.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton13.ToolTipText = "店面确认购买";
            this.toolStripButton13.Visible = false;
            this.toolStripButton13.Click += new System.EventHandler(this.toolStripButton13_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(122, 76);
            this.toolStripButton3.Text = "历史记录查询";
            this.toolStripButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton3.Visible = false;
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 79);
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton8.Image")));
            this.toolStripButton8.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.Size = new System.Drawing.Size(86, 76);
            this.toolStripButton8.Text = "商品管理";
            this.toolStripButton8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton8.Visible = false;
            this.toolStripButton8.Click += new System.EventHandler(this.toolStripButton8_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(86, 76);
            this.toolStripButton2.Text = "会员管理";
            this.toolStripButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton2.Visible = false;
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(86, 76);
            this.toolStripButton6.Text = "立即同步";
            this.toolStripButton6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton6.Visible = false;
            this.toolStripButton6.Click += new System.EventHandler(this.toolStripButton6_Click);
            // 
            // toolStripButton9
            // 
            this.toolStripButton9.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton9.Image")));
            this.toolStripButton9.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton9.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton9.Name = "toolStripButton9";
            this.toolStripButton9.Size = new System.Drawing.Size(52, 76);
            this.toolStripButton9.Text = "退出";
            this.toolStripButton9.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton9.Click += new System.EventHandler(this.toolStripButton9_Click);
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton7.Image")));
            this.toolStripButton7.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(104, 76);
            this.toolStripButton7.Text = "数据库处理";
            this.toolStripButton7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton7.Visible = false;
            this.toolStripButton7.Click += new System.EventHandler(this.toolStripButton7_Click_1);
            // 
            // toolStripButton10
            // 
            this.toolStripButton10.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton10.Image")));
            this.toolStripButton10.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton10.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton10.Name = "toolStripButton10";
            this.toolStripButton10.Size = new System.Drawing.Size(86, 76);
            this.toolStripButton10.Text = "额度计算";
            this.toolStripButton10.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton10.Visible = false;
            this.toolStripButton10.Click += new System.EventHandler(this.toolStripButton10_Click);
            // 
            // AccessQueueTimer
            // 
            this.AccessQueueTimer.Enabled = true;
            this.AccessQueueTimer.Interval = 1800000;
            this.AccessQueueTimer.Tick += new System.EventHandler(this.AccessQueueTimer_Tick);
            // 
            // AlertTimer
            // 
            this.AlertTimer.Interval = 43200000;
            this.AlertTimer.Tick += new System.EventHandler(this.AlertTimer_Tick);
            // 
            // timer_Close
            // 
            this.timer_Close.Interval = 2700000;
            this.timer_Close.Tick += new System.EventHandler(this.timer_Close_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1162, 662);
            this.Controls.Add(this.ssrMain);
            this.Controls.Add(this.dPanelMain);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuMain;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1164, 684);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "员工内购系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.ssrMain.ResumeLayout(false);
            this.ssrMain.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WinFormsUI.Docking.DockPanel dPanelMain;
        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.StatusStrip ssrMain;
        private System.Windows.Forms.Timer tmrMain;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tssrMain_Timer;
        private System.Windows.Forms.ToolStripMenuItem menuMain_Day;
        private System.Windows.Forms.ToolStripMenuItem menuMain_Table;
        private System.Windows.Forms.ToolStripMenuItem menuMain_System;
        private System.Windows.Forms.ToolStripMenuItem menuMain_System_Item;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem menuMain_System_Config;
        private System.Windows.Forms.ToolStripMenuItem menuMain_System_Log;
        private System.Windows.Forms.ToolStripMenuItem menuMain_System_Pwd;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem menuMain_System_Exit;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton8;
        private System.Windows.Forms.ToolStripButton toolStripButton9;
        private System.Windows.Forms.ToolStripButton toolStripButton12;
        private System.Windows.Forms.ToolStripButton toolStripButton13;
        private System.Windows.Forms.ToolStripMenuItem menuMain_Flow_add;
        private System.Windows.Forms.ToolStripMenuItem menuMain_Manage_History;
        private System.Windows.Forms.ToolStripMenuItem menuMain_Manage_StoreApp;
        private System.Windows.Forms.ToolStripMenuItem menuMain_Manage_Approval2App;
        private System.Windows.Forms.ToolStripMenuItem menuMain_Manage_Store;
        private System.Windows.Forms.ToolStripMenuItem 登陆ToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem menuMain_Manage_ApprovalApp;
        private System.Windows.Forms.ToolStripMenuItem menuMain_System_Member;
        private System.Windows.Forms.ToolStripMenuItem 购买确认ToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripMenuItem menuMain_System_Setup;
        private System.Windows.Forms.Timer AccessQueueTimer;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.Timer AlertTimer;
        private System.Windows.Forms.ToolStripButton tsbtnCW;
        private System.Windows.Forms.ToolStripMenuItem 财务部审核ToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.Timer timer_Close;
        private System.Windows.Forms.ToolStripButton toolStripButton10;
    }
}