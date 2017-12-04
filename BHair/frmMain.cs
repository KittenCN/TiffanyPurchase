using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WinFormsUI.Docking;
using BHair.Base;
using BHair.Business;
using BHair.SystemSet;
using BHair.Business.Table;
using System.Threading;

namespace BHair
{

    public partial class frmMain : Form
    {
        ApplicationInfo applicationInfo = new ApplicationInfo();
        public Boolean boolNorLogin = false;
        public frmMain()
        {
            InitializeComponent();
            this.Text = "员工内购系统 " + " V " + Application.ProductVersion + " 最后编译时间 " + System.IO.File.GetLastWriteTime(this.GetType().Assembly.Location);

            this.tssrMain_Timer.Text = DateTime.Now.ToString();
            this.dPanelMain_AutoSize();

            //toolStripButton4.Visible = false;
            //toolStripButton5.Visible = false;
            //toolStripSeparator2.Visible = false;

            menuMain_Table.Visible = false;

            Login login = new Login();
            if (login.ShowDialog() == DialogResult.OK)
            {
                this.InitMenu();
            }

        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (boolNorLogin)
            {
                int intLoginNum;
                AccessHelper ah = new AccessHelper();
                string strSQL = "select top 1 * from SetupConfig";
                DataTable dtSQL = ah.SelectToDataTable(strSQL);
                if (dtSQL.Rows[0]["LoginNum"].ToString() != "")
                {
                    intLoginNum = int.Parse(dtSQL.Rows[0]["LoginNum"].ToString());
                }
                else
                {
                    intLoginNum = 0;
                }
                intLoginNum--;
                strSQL = "update SetupConfig set LoginNum=" + intLoginNum;
                ah.ExecuteNonQuery(strSQL);
                ah.Close();
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //frmPays_List objfrmPaysList = new frmPays_List();
            //this.ShowWindows_Click(objfrmPaysList);

            //取消邮件功能
            //if (Login.LoginUser.Character == 1)
            //{
            //    AlertTimer.Enabled = true;
            //    AlertTimer.Interval = 43200000;
            //}
            //else
            //{
            //    AlertTimer.Enabled = false;
            //}

            timer_Close.Enabled = true;
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            this.dPanelMain_AutoSize();
        }

        private void dPanelMain_AutoSize()
        {
            this.dPanelMain.Width = this.ClientSize.Width;
            this.dPanelMain.Height = this.ClientSize.Height - 45;
        }

        #region 检查选项卡是否存在...

        /// <summary>检查选项卡是否存在。</summary>
        /// <param name="text">选项卡名称</param>
        /// <returns></returns>
        private IDockContent FindTab(string text)
        {
            if (this.dPanelMain.DocumentStyle == DocumentStyle.SystemMdi)
            {
                foreach (Form form in MdiChildren)
                {
                    if (form.Text == text)
                    {
                        return form as IDockContent;
                    }
                }
            }
            else
            {
                foreach (IDockContent content in this.dPanelMain.Documents)
                {
                    if (content.DockHandler.TabText == text)
                    {
                        return content;
                    }
                }
            }
            return null;
        }

        #endregion

        #region 打开选项卡窗体..

        /// <summary>打开窗体</summary>
        /// <param name="form">窗体实例</param>
        private void ShowWindows_Click(DockContent form)
        {
            string strText = form.Text;
            if (this.FindTab(strText) == null)
            {
                form.Show(this.dPanelMain);
            }
            else
            {
                this.FindTab(strText).DockHandler.Show();
            }
        }

        #endregion

        private void tmrMain_Tick(object sender, EventArgs e)
        {
            this.tssrMain_Timer.Text = DateTime.Now.ToString();
        }

        #region 日常操作...


        private void menuMain_System_Member_Click(object sender, EventArgs e)
        {
            frmMember_List objfrmMemberList = new frmMember_List();
            this.ShowWindows_Click(objfrmMemberList);
        }


        #endregion



        #region 转货流程

        /// <summary>
        /// 申请转货
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuMain_Flow_add_Click(object sender, EventArgs e)
        {
            //if (Login.LoginUser.MoneyUnit == 1)
            //{
            frmAddApplication objfrmAddApp = new frmAddApplication();
            objfrmAddApp.Show();
            //}
            //else
            //{
            //    frmAddApplicationEn objfrmAddAppEn = new frmAddApplicationEn();
            //    objfrmAddAppEn.Show();
            //}
        }

        /// <summary>
        /// 店面申请单状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuMain_Manage_StoreApp_Click(object sender, EventArgs e)
        {
            frmAppStaff objfrmStoreApp = new frmAppStaff();
            this.ShowWindows_Click(objfrmStoreApp);
        }

        /// <summary>
        /// 经理审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuMain_Manage_Approval2App_Click(object sender, EventArgs e)
        {
            frmAppAproval2 objfrmAppAproval2 = new frmAppAproval2();
            this.ShowWindows_Click(objfrmAppAproval2);
        }

        /// <summary>
        /// 财务部审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 财务部审核ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAppAproval3 objfrmAppAproval3 = new frmAppAproval3();
            this.ShowWindows_Click(objfrmAppAproval3);
        }

        /// <summary>
        /// 商品部审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuMain_Manage_ApprovalApp_Click(object sender, EventArgs e)
        {
            frmAppAproval objfrmAppAproval = new frmAppAproval();
            this.ShowWindows_Click(objfrmAppAproval);
        }

        /// <summary>
        /// 店面确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 购买确认ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmStoreApplication objfrmStoreApplication = new frmStoreApplication();
            //objfrmStoreApplication.Show();
            frmStoreApplicationInfo objfrmStoreApplicationInfo = new frmStoreApplicationInfo();
            this.ShowWindows_Click(objfrmStoreApplicationInfo);
        }

        #endregion

        #region 查询

        /// <summary>
        /// 历史查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuMain_Manage_History_Click(object sender, EventArgs e)
        {
            frmHistoryInfo objfrmHisApp = new frmHistoryInfo();
            this.ShowWindows_Click(objfrmHisApp);
        }

        #endregion




        #region 统计报表...



        /// <summary>员工工资统计</summary>
        private void menuMain_Table_Salary_Click(object sender, EventArgs e)
        {
            //frmSalary objfrmSalary = new frmSalary();
            //this.ShowWindows_Click(objfrmSalary);
        }



        #endregion

        #region 系统维护...

        /// <summary>商品信息管理</summary>
        private void menuMain_System_Item_Click(object sender, EventArgs e)
        {
            frmItem_List objfrmItemsList = new frmItem_List();
            this.ShowWindows_Click(objfrmItemsList);
        }

        /// <summary>
        /// 店面管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuMain_Manage_Store_Click(object sender, EventArgs e)
        {
            frmStore_List objfrmStoreList = new frmStore_List();
            this.ShowWindows_Click(objfrmStoreList);
        }




        /// <summary>系统设置</summary>
        private void menuMain_System_Config_Click(object sender, EventArgs e)
        {
            Login objfrmLogin = new Login();
            InitMenu();
            CloseAllTab();
            if (objfrmLogin.ShowDialog() == DialogResult.OK)
            {
                this.InitMenu();
            }
        }

        private void menuMain_System_Log_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 修改个人信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuMain_System_Pwd_Click(object sender, EventArgs e)
        {
            frmMember objfrmMember = new frmMember(Login.LoginUser.UID);
            objfrmMember.Show();
        }

        /// <summary>退出</summary>
        private void menuMain_System_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            menuMain_System_Member_Click(null, null);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            menuMain_Manage_History_Click(null, null);
        }

        /// <summary>
        /// 申请转货
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            menuMain_Flow_add_Click(null, null);
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            menuMain_Table_Salary_Click(null, null);
        }



        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            menuMain_System_Item_Click(null, null);
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            menuMain_System_Config_Click(null, null);
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            menuMain_Manage_StoreApp_Click(null, null);
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            购买确认ToolStripMenuItem_Click(null, null);
        }

        private void toolStripButton5_Click_1(object sender, EventArgs e)
        {
            menuMain_Manage_ApprovalApp_Click(null, null);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            menuMain_Manage_Approval2App_Click(null, null);
        }

        private void 登陆ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            CloseAllTab();
            if (login.ShowDialog() == DialogResult.OK)
            {
                this.InitMenu();
            }
        }

        bool IsLogin()
        {
            if (Login.LoginUser.UID != null && Login.LoginUser.UID != "")
            {

                return true;
            }
            else
            {
                MessageBox.Show("请先登录", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }


        #region
        /// <summary>
        /// 权限按钮
        /// </summary>
        void InitMenu()
        {
            //初始化
            menuMain_Flow_add.Visible = false;
            menuMain_Manage_StoreApp.Visible = false;
            menuMain_Manage_Approval2App.Visible = false;
            menuMain_Manage_ApprovalApp.Visible = false;
            menuMain_Manage_History.Visible = false;
            menuMain_System_Member.Visible = false;
            menuMain_Manage_Store.Visible = false;
            menuMain_System_Item.Visible = false;
            menuMain_System_Log.Visible = false;
            购买确认ToolStripMenuItem.Visible = false;
            menuMain_System_Setup.Visible = false;
            menuMain_Table.Visible = false;
            menuMain_System_Pwd.Visible = false;
            财务部审核ToolStripMenuItem.Visible = false;

            toolStripButton4.Visible = false;
            toolStripButton12.Visible = false;
            toolStripButton1.Visible = false;
            toolStripButton3.Visible = false;
            toolStripButton8.Visible = false;
            toolStripButton2.Visible = false;
            toolStripButton13.Visible = false;
            toolStripButton5.Visible = false;
            toolStripButton6.Visible = false;
            tsbtnCW.Visible = false;
            toolStripButton7.Visible = false;
            toolStripButton10.Visible = false;

            if (Login.LoginUser.UID == null || Login.LoginUser.UID == "")
            {
                boolNorLogin = false;
                menuMain_Flow_add.Visible = false;
                menuMain_Manage_StoreApp.Visible = false;
                menuMain_Manage_Approval2App.Visible = false;
                menuMain_Manage_ApprovalApp.Visible = false;
                menuMain_Manage_History.Visible = false;
                menuMain_System_Member.Visible = false;
                menuMain_Manage_Store.Visible = false;
                menuMain_System_Item.Visible = false;
                menuMain_System_Log.Visible = false;
                购买确认ToolStripMenuItem.Visible = false;
                menuMain_System_Setup.Visible = false;
                menuMain_Table.Visible = false;
                menuMain_System_Pwd.Visible = false;

                toolStripButton4.Visible = false;
                toolStripButton12.Visible = false;
                toolStripButton1.Visible = false;
                toolStripButton3.Visible = false;
                toolStripButton8.Visible = false;
                toolStripButton2.Visible = false;
                toolStripButton13.Visible = false;
                toolStripButton13.Visible = false;
                toolStripButton5.Visible = false;
                toolStripButton6.Visible = false;
                toolStripButton7.Visible = false;
                toolStripButton10.Visible = false;
            }
            else if (Login.LoginUser.Character == 1)
            {
                boolNorLogin = true;
                menuMain_Flow_add.Visible = true;
                menuMain_Manage_StoreApp.Visible = true;
                menuMain_Manage_Approval2App.Visible = true;
                menuMain_Manage_ApprovalApp.Visible = true;
                menuMain_Manage_History.Visible = true;
                menuMain_Table.Visible = true;
                menuMain_System_Pwd.Visible = true;
                menuMain_System_Item.Visible = true;

                if (Login.LoginUser.IsAdmin == 1)
                {
                    menuMain_System_Member.Visible = true;
                    menuMain_Manage_Store.Visible = true;
                    menuMain_System_Item.Visible = true;
                    menuMain_System_Log.Visible = true;
                    购买确认ToolStripMenuItem.Visible = true;
                    财务部审核ToolStripMenuItem.Visible = true;
                    tsbtnCW.Visible = true;
                    toolStripButton13.Visible = true;
                    toolStripButton8.Visible = true;
                    toolStripButton2.Visible = true;
                    menuMain_System_Setup.Visible = true;
                    toolStripButton7.Visible = true;
                }
                else
                {
                    menuMain_System_Member.Visible = false;
                    menuMain_Manage_Store.Visible = false;
                    //menuMain_System_Item.Visible = false;
                    menuMain_System_Log.Visible = false;
                    购买确认ToolStripMenuItem.Visible = false;
                    toolStripButton13.Visible = false;
                    //toolStripButton8.Visible = false;
                    //toolStripButton2.Visible = false;
                    menuMain_System_Setup.Visible = false;
                }

                toolStripButton4.Visible = true;
                toolStripButton12.Visible = true;
                toolStripButton1.Visible = true;
                toolStripButton3.Visible = true;
                toolStripButton5.Visible = true;
                toolStripButton6.Visible = true;
                toolStripButton8.Visible = true;
            }
            else if (Login.LoginUser.Character == 2)
            {
                boolNorLogin = true;
                menuMain_Flow_add.Visible = true;
                menuMain_Manage_StoreApp.Visible = true;
                menuMain_Manage_Approval2App.Visible = true;
                menuMain_Manage_ApprovalApp.Visible = false;
                menuMain_Manage_History.Visible = true;
                menuMain_System_Member.Visible = false;
                menuMain_Manage_Store.Visible = false;
                menuMain_System_Item.Visible = false;
                menuMain_System_Log.Visible = false;
                购买确认ToolStripMenuItem.Visible = false;
                menuMain_System_Setup.Visible = false;
                menuMain_Table.Visible = false;
                menuMain_System_Pwd.Visible = true;

                toolStripButton4.Visible = true;
                toolStripButton12.Visible = true;
                toolStripButton1.Visible = true;
                toolStripButton3.Visible = false;
                toolStripButton8.Visible = false;
                toolStripButton2.Visible = false;
                toolStripButton13.Visible = false;
                toolStripButton5.Visible = false;
                toolStripButton6.Visible = true;
            }
            else if (Login.LoginUser.Character == 3)
            {
                boolNorLogin = true;
                menuMain_Flow_add.Visible = true;
                menuMain_Manage_StoreApp.Visible = true;
                menuMain_Manage_Approval2App.Visible = false;
                menuMain_Manage_ApprovalApp.Visible = false;
                menuMain_Manage_History.Visible = true;
                menuMain_System_Member.Visible = false;
                menuMain_Manage_Store.Visible = false;
                menuMain_System_Item.Visible = false;
                menuMain_System_Log.Visible = false;
                购买确认ToolStripMenuItem.Visible = false;
                menuMain_System_Setup.Visible = false;
                menuMain_Table.Visible = false;
                menuMain_System_Pwd.Visible = true;

                toolStripButton4.Visible = true;
                toolStripButton12.Visible = true;
                toolStripButton1.Visible = false;
                toolStripButton3.Visible = false;
                toolStripButton8.Visible = false;
                toolStripButton2.Visible = false;
                toolStripButton13.Visible = false;
                toolStripButton5.Visible = false;
                toolStripButton6.Visible = true;
            }
            else if (Login.LoginUser.Character == 4)
            {
                boolNorLogin = true;
                menuMain_Flow_add.Visible = false;
                menuMain_Manage_StoreApp.Visible = false;
                menuMain_Manage_Approval2App.Visible = false;
                menuMain_Manage_ApprovalApp.Visible = false;
                menuMain_Manage_History.Visible = false;
                menuMain_System_Member.Visible = false;
                menuMain_Manage_Store.Visible = false;
                menuMain_System_Item.Visible = false;
                menuMain_System_Log.Visible = false;
                购买确认ToolStripMenuItem.Visible = true;
                menuMain_System_Setup.Visible = false;
                menuMain_Table.Visible = false;
                menuMain_System_Pwd.Visible = true;

                toolStripButton4.Visible = true;
                toolStripButton12.Visible = true;
                toolStripButton1.Visible = false;
                toolStripButton3.Visible = false;
                toolStripButton8.Visible = false;
                toolStripButton2.Visible = false;
                toolStripButton13.Visible = true;
                toolStripButton5.Visible = false;
                toolStripButton6.Visible = true;
            }
            else if (Login.LoginUser.Character == 5)
            {
                boolNorLogin = true;
                menuMain_Flow_add.Visible = false;
                menuMain_Manage_StoreApp.Visible = false;
                menuMain_Manage_Approval2App.Visible = false;
                menuMain_Manage_ApprovalApp.Visible = false;
                menuMain_Manage_History.Visible = false;
                menuMain_System_Member.Visible = false;
                menuMain_Manage_Store.Visible = false;
                menuMain_System_Item.Visible = false;
                menuMain_System_Log.Visible = false;
                购买确认ToolStripMenuItem.Visible = false;
                menuMain_System_Setup.Visible = false;
                menuMain_Table.Visible = false;
                menuMain_System_Pwd.Visible = true;

                toolStripButton4.Visible = true;
                toolStripButton12.Visible = true;
                toolStripButton1.Visible = false;
                toolStripButton3.Visible = false;
                toolStripButton8.Visible = false;
                toolStripButton2.Visible = true;
                toolStripButton13.Visible = false;
                toolStripButton5.Visible = false;
                toolStripButton6.Visible = true;
            }
            else if (Login.LoginUser.Character == 6)  //    财务
            {
                boolNorLogin = true;
                menuMain_Flow_add.Visible = false;
                menuMain_Manage_StoreApp.Visible = false;
                menuMain_Manage_Approval2App.Visible = false;
                menuMain_Manage_ApprovalApp.Visible = false;
                menuMain_Manage_History.Visible = false;
                menuMain_System_Member.Visible = false;
                menuMain_Manage_Store.Visible = false;
                menuMain_System_Item.Visible = false;
                menuMain_System_Log.Visible = false;
                购买确认ToolStripMenuItem.Visible = false;
                menuMain_System_Setup.Visible = false;
                menuMain_Table.Visible = false;
                menuMain_System_Pwd.Visible = true;
                财务部审核ToolStripMenuItem.Visible = true;

                toolStripButton4.Visible = true;
                toolStripButton12.Visible = true;
                toolStripButton1.Visible = false;
                toolStripButton3.Visible = false;
                toolStripButton8.Visible = false;
                toolStripButton2.Visible = false;
                toolStripButton13.Visible = false;
                toolStripButton5.Visible = false;
                toolStripButton6.Visible = true;
                tsbtnCW.Visible = true;
            }
            else if (Login.LoginUser.Character == 7)  //IT
            {
                boolNorLogin = true;
                menuMain_Flow_add.Visible = false;
                menuMain_Manage_StoreApp.Visible = false;
                menuMain_Manage_Approval2App.Visible = false;
                menuMain_Manage_ApprovalApp.Visible = false;
                menuMain_Manage_History.Visible = false;
                menuMain_System_Member.Visible = false;
                menuMain_Manage_Store.Visible = false;
                menuMain_System_Item.Visible = false;
                menuMain_System_Log.Visible = false;
                购买确认ToolStripMenuItem.Visible = false;
                menuMain_System_Setup.Visible = false;
                menuMain_Table.Visible = false;
                menuMain_System_Pwd.Visible = true;

                toolStripButton4.Visible = false;
                toolStripButton12.Visible = false;
                toolStripButton1.Visible = false;
                toolStripButton3.Visible = false;
                toolStripButton8.Visible = false;
                toolStripButton2.Visible = true;
                toolStripButton13.Visible = false;
                toolStripButton5.Visible = false;
                toolStripButton6.Visible = true;
            }
            else
            {
                boolNorLogin = false;
                menuMain_Flow_add.Visible = false;
                menuMain_Manage_StoreApp.Visible = false;
                menuMain_Manage_Approval2App.Visible = false;
                menuMain_Manage_ApprovalApp.Visible = false;
                menuMain_Manage_History.Visible = false;
                menuMain_System_Member.Visible = false;
                menuMain_Manage_Store.Visible = false;
                menuMain_System_Item.Visible = false;
                menuMain_System_Log.Visible = false;
                购买确认ToolStripMenuItem.Visible = false;
                menuMain_System_Setup.Visible = false;
                menuMain_Table.Visible = false;
                menuMain_System_Pwd.Visible = false;

                toolStripButton4.Visible = false;
                toolStripButton12.Visible = false;
                toolStripButton1.Visible = false;
                toolStripButton3.Visible = false;
                toolStripButton8.Visible = false;
                toolStripButton2.Visible = false;
                toolStripButton13.Visible = false;
                toolStripButton5.Visible = false;
                toolStripButton6.Visible = false;
                toolStripButton10.Visible = false;
                toolStripButton7.Visible = false;
            }
            ExcelHelper eh = new ExcelHelper();
            if (eh.boolIsManager(Login.LoginUser.UID))
            {
                boolNorLogin = true;
                menuMain_Flow_add.Visible = true;
                menuMain_Manage_StoreApp.Visible = true;
                menuMain_Manage_Approval2App.Visible = true;
                menuMain_Manage_History.Visible = true;
                menuMain_System_Pwd.Visible = true;

                //toolStripButton4.Visible = true;
                toolStripButton1.Visible = true;
                toolStripButton6.Visible = true;
            }
            else
            {
                toolStripButton1.Visible = false;
                menuMain_Manage_Approval2App.Visible = false;
            }

            if (Login.LoginUser.IsAdmin == 1)
            {
                boolNorLogin = true;
                menuMain_System_Member.Visible = true;
                menuMain_Manage_Store.Visible = true;
                menuMain_System_Item.Visible = true;
                menuMain_System_Log.Visible = true;
                购买确认ToolStripMenuItem.Visible = true;
                财务部审核ToolStripMenuItem.Visible = true;
                tsbtnCW.Visible = true;
                toolStripButton13.Visible = true;
                toolStripButton8.Visible = true;
                toolStripButton2.Visible = true;
                menuMain_System_Setup.Visible = true;

                menuMain_Flow_add.Visible = true;
                menuMain_Manage_StoreApp.Visible = true;
                menuMain_Manage_Approval2App.Visible = true;
                menuMain_Manage_ApprovalApp.Visible = true;
                menuMain_Manage_History.Visible = true;
                menuMain_System_Member.Visible = true;
                menuMain_Manage_Store.Visible = true;
                menuMain_System_Item.Visible = true;
                menuMain_System_Log.Visible = true;
                购买确认ToolStripMenuItem.Visible = true;
                menuMain_System_Setup.Visible = true;
                menuMain_Table.Visible = true;
                menuMain_System_Pwd.Visible = true;

                toolStripButton4.Visible = true;
                toolStripButton12.Visible = true;
                toolStripButton1.Visible = true;
                toolStripButton3.Visible = true;
                toolStripButton8.Visible = true;
                toolStripButton2.Visible = true;
                toolStripButton13.Visible = true;
                toolStripButton5.Visible = true;
                toolStripButton6.Visible = true;
                toolStripButton7.Visible = true;
                toolStripButton10.Visible = true;
            }
        }
        #endregion

        private void menuMain_System_Setup_Click(object sender, EventArgs e)
        {
            frmConfig fc = new frmConfig();
            fc.Show();
        }

        private void AccessQueueTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                SqlQueue sq = new SqlQueue();
                //sq.ExecuteSqlQuery();
                sq.QuickExecuteSqlQuery();
                sq.Close();
            }
            catch (Exception)
            {

            }

        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            bool connSuccess = false;
            try
            {
                AccessHelper ah = new AccessHelper();
                ah.Close();
                connSuccess = true;
            }
            catch
            {
                MessageBox.Show("远程缓存同步失败", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                connSuccess = false;
            }
            if (connSuccess)
            {
                try
                {
                    SqlQueue sq = new SqlQueue();
                    sq.QuickExecuteSqlQuery();
                    sq.Close();
                    //MessageBox.Show("远程缓存同步完成,远程服务器每小时轮询处理一次,在此期间,您无法查看到新处理的结果,请勿重复操作!", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show("远程缓存同步完成", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {

                }
            }
        }

        void CloseAllTab()
        {
            IDockContent[] documents = this.dPanelMain.DocumentsToArray();
            foreach (IDockContent content in documents)
            {
                content.DockHandler.Close();
            }
        }

        private void AlertTimer_Tick(object sender, EventArgs e)
        {
            ///不需要超时提醒
            //if (Login.LoginUser.IsAdmin == 1)
            //{
            //    Thread thread = new Thread(new ThreadStart(SendEmail));
            //    thread.Start();
            //}
        }

        void SendEmail()
        {
            //申请批准后超时提醒
            DataTable alertApprovalDT = applicationInfo.SelectAlertApproval();
            if (alertApprovalDT.Rows.Count > 0)
            {
                foreach (DataRow dr in alertApprovalDT.Rows)
                {
                    try
                    {
                        EmailControl.ApplicationAlert(dr["TransNo"].ToString(), dr["ApplicantsName"].ToString(), dr["ApplicantsDate"].ToString());
                    }
                    catch
                    {
                        EmailControl.AlertException(dr["TransNo"].ToString(), dr["ApplicantsName"].ToString(), dr["ApplicantsDate"].ToString());
                    }
                }
            }
        }

        private void tsbtnCW_Click(object sender, EventArgs e)
        {
            财务部审核ToolStripMenuItem_Click(null, null);
        }

        private void menuMain_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton7_Click_1(object sender, EventArgs e)
        {
            frmAdvDataControl fadc = new frmAdvDataControl();
            fadc.Show();
        }

        private void timer_Close_Tick(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch
            {
                System.Environment.Exit(0);
            }
        }
        private Boolean CheckSpecial(string itemID)
        {
            Boolean boolResult = false;
            try
            {
                string strSQL = "select * from Items where itemID = '" + itemID + "'";
                AccessHelper ah = new AccessHelper();
                DataTable dt = ah.SelectToDataTable(strSQL);
                ah.Close();
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["IsSpecial"].ToString() == "1")
                    {
                        boolResult = true;
                    }
                }
            }
            catch
            {
                boolResult = false;
            }
            return boolResult;
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            double douDefBon = 100000.00;
            DateTime dtBeginDate = DateTime.Parse(DateTime.Now.Year.ToString() + "-2-1");
            DateTime dtEndDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            //double douCurrUsed;
            string strDebug = "--";

            try
            {
                #region init all user's bonefit
                strDebug = "init...";
                //string strInitSQL = "update Users set UsedAmount=0,RestAmount=" + douDefBon;
                AccessHelper ah = new AccessHelper();
                //ah.ExecuteSQLNonquery(strInitSQL);
                //ah.Close();
                string strMaxEmpDate = DateTime.Now.AddDays(-180).ToShortDateString();
                string strBeginDate = DateTime.Now.Year.ToString() + "/2/1";
                string strEndDate = DateTime.Parse(DateTime.Now.Year.ToString() + "/08/01 00:00:00").AddDays(-1).ToShortDateString();
                string strBeginDate2 = DateTime.Now.Year.ToString() + "/8/1";
                string strEndDate2 = DateTime.Parse(DateTime.Now.AddYears(1).Year.ToString() + "/02/01 00:00:00").AddDays(-1).ToShortDateString();
                string strSQL = "update Users set UsedAmount = 0, RestAmount = 50000 where EmpDate <=#" + strMaxEmpDate + "# and EmpDate < #" + strBeginDate + "# ";
                ah.ExecuteNonQuery(strSQL);
                Thread.Sleep(3000);
                ah.Close();
                strSQL = "update Users set UsedAmount = 0, RestAmount = 50000 * (datediff('d', EmpDate, #" + strEndDate + "#) / 180) where EmpDate <=#" + strMaxEmpDate + "# and EmpDate >= #" + strBeginDate + "# ";
                ah.ExecuteNonQuery(strSQL);
                Thread.Sleep(3000);
                ah.Close();
                strSQL = "update Users set UsedAmount = 0, RestAmount = 0 where EmpDate >#" + strMaxEmpDate + "#";
                ah.ExecuteNonQuery(strSQL);
                Thread.Sleep(3000);
                ah.Close();
                if (DateTime.Now.Month >= 7 || DateTime.Now.Month == 1)
                {
                    strSQL = "update Users set RestAmount = RestAmount + 50000 where EmpDate <=#" + strMaxEmpDate + "# and EmpDate < #" + strBeginDate2 + "# ";
                    ah.ExecuteNonQuery(strSQL);
                    Thread.Sleep(3000);
                    ah.Close();
                    strSQL = "update Users set UsedAmount = 0, RestAmount = RestAmount + (50000 * (datediff('d', EmpDate, #" + strEndDate + "#) / 180)) where EmpDate <=#" + strMaxEmpDate + "# and EmpDate  >=#" + strBeginDate2 + "#";
                    ah.ExecuteNonQuery(strSQL);
                    Thread.Sleep(3000);
                    ah.Close();
                    //strSQL = "update Users set UsedAmount = 0, RestAmount = 50000 * (datediff('d', EmpDate, #" + strEndDate2 + "#) / 180) where EmpDate =#" + strMaxEmpDate + "# and EmpDate >= #" + strBeginDate2 + "#";
                    //ah.ExecuteNonQuery(strSQL);
                    //ah.Close();
                    strSQL = "update Users set UsedAmount = 0, RestAmount = 0 where EmpDate >#" + strMaxEmpDate + "#";
                    ah.ExecuteNonQuery(strSQL);
                    Thread.Sleep(3000);
                    ah.Close();
                }
                #endregion

                strDebug = "Get All Data...";
                string strSelectSQL = "select * from Users where IsDelete=0 and IsAble=1";
                AccessHelper ah2 = new AccessHelper();
                DataTable dtSelectSQL = ah2.SelectToDataTable(strSelectSQL);
                ah2.Close();
                foreach (DataRow dr in dtSelectSQL.Rows)
                {
                    double douUsed = 0.00;
                    string UID = dr["UID"].ToString();
                    douDefBon = double.Parse(dr["RestAmount"].ToString());
                    strDebug = "Get Price from " + UID + " ";
                    string strGetAllSQL = "select * from ApplicationInfo where IsDelete=0 and SalesDate>=#" + dtBeginDate.ToShortDateString() + "# and SalesDate<#" + DateTime.Now.AddDays(1) + "# and Applicants='" + UID + "' ";
                    AccessHelper ahIN = new AccessHelper();
                    DataTable dtIN = ahIN.SelectToDataTable(strGetAllSQL);
                    ahIN.Close();
                    for (int i = 0; i < dtIN.Rows.Count; i++)
                    {
                        double douTotalPrice = 0.00;
                        string strGetDetail = "select * from ApplicationDetail where TransNo = '" + dtIN.Rows[i]["TransNo"].ToString() + "'";
                        AccessHelper ahGetDetail = new AccessHelper();
                        DataTable dtDetail = ahGetDetail.SelectToDataTable(strGetDetail);
                        ahGetDetail.Close();
                        for (int ii = 0; ii < dtDetail.Rows.Count; ii++)
                        {
                            if (dtDetail.Rows[ii]["IsSuccess"].ToString() == "1")
                            {
                                decimal MoneyDiscont = 1;
                                switch (dtDetail.Rows[ii]["MoneyUnit"].ToString())
                                {
                                    case "1":
                                    default:
                                        MoneyDiscont = 1;
                                        break;
                                    case "2":
                                        MoneyDiscont = EmailControl.config.USrate;
                                        break;
                                    case "3":
                                        MoneyDiscont = EmailControl.config.HKrate;
                                        break;
                                    case "4":
                                        MoneyDiscont = EmailControl.config.MOPrate;
                                        break;
                                    case "5":
                                        MoneyDiscont = EmailControl.config.SGDrate;
                                        break;
                                    case "6":
                                        MoneyDiscont = EmailControl.config.MYRrate;
                                        break;
                                    case "7":
                                        MoneyDiscont = EmailControl.config.GBPrate;
                                        break;
                                    case "8":
                                        MoneyDiscont = EmailControl.config.EURrate;
                                        break;
                                    case "9":
                                        MoneyDiscont = EmailControl.config.JPYrate;
                                        break;
                                    case "10":
                                        MoneyDiscont = EmailControl.config.TWDrate;
                                        break;
                                }
                                if (!CheckSpecial(dtDetail.Rows[ii]["ItemID"].ToString()) && int.Parse(dtIN.Rows[i]["AppState"].ToString()) >= 6)
                                {
                                    douUsed += double.Parse(dtDetail.Rows[ii]["FinalPrice"].ToString()) * double.Parse(MoneyDiscont.ToString());
                                }
                                if (int.Parse(dtDetail.Rows[ii]["IsRepetition"].ToString()) == 1)
                                {
                                    douTotalPrice += double.Parse(dtDetail.Rows[ii]["FinalPrice"].ToString()) * double.Parse(MoneyDiscont.ToString());
                                }
                            }
                        }
                        string strUpdate = "update ApplicationInfo set TotalPrice = " + douTotalPrice + " where TransNo = '" + dtIN.Rows[i]["TransNo"].ToString() + "'";
                        AccessHelper ahup = new AccessHelper();
                        ahup.ExecuteSQLNonquery(strUpdate);
                        Thread.Sleep(500);
                        ahup.Close();
                        douTotalPrice = 0.00;
                    }
                    strDebug = "Update data to " + UID + " ";
                    double douRest = douDefBon - douUsed;
                    string strUpdateSQL = "update Users set UsedAmount=" + douUsed + ",RestAmount=" + douRest + " where UID='" + UID + "' ";
                    AccessHelper ahRunRest = new AccessHelper();
                    ahRunRest.ExecuteSQLNonquery(strUpdateSQL);
                    Thread.Sleep(500);
                    ahRunRest.Close();
                    //if (dtIN != null && dtIN.Rows.Count>0)
                    //{
                    //    if(dtIN.Rows[0][0].ToString() != null && dtIN.Rows[0][0].ToString() != "")
                    //    {
                    //        douCurrUsed = double.Parse(dtIN.Rows[0][0].ToString());
                    //    }
                    //    else
                    //    {
                    //        douCurrUsed = 0.0;
                    //    }
                    //    if(douCurrUsed > 0)
                    //    {
                    //        strDebug = "Update data to " + UID + " ";
                    //        double douRest = douDefBon - douCurrUsed;
                    //        string strUpdateSQL = "update Users set UsedAmount=" + douCurrUsed + ",RestAmount=" + douRest + " where UID='" + UID + "' ";
                    //        AccessHelper ahRunRest = new AccessHelper();
                    //        ahRunRest.ExecuteSQLNonquery(strUpdateSQL);
                    //        ahRunRest.Close();
                    //        //System.Threading.Thread.Sleep(500);
                    //    }
                    //}
                }
                MessageBox.Show("重新计算成功!", "通知!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("重新计算失败::" + strDebug + "::" + ex.Message, "警告!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}
