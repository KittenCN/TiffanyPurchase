using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BHair.Base;
using BHair.Business;
using BHair.SystemSet;
using BHair.Business.Table;
using System.Threading;

namespace BHair.Base
{
    public partial class frmAdvDataControl : Form
    {
        private delegate void SetPos(int ipos);
        public static DataTable dtAI;
        public static DataTable dtAD;
        public int intAll = 0;
        public int intCurr = 0;
        public frmAdvDataControl()
        {
            InitializeComponent();
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            AccessHelper ah = new AccessHelper();
            string strSQL = "select ID,TransNo from ApplicationInfo where IsDelete=0 and TransNo in (select  TransNo from  ApplicationInfo group  by TransNo  having count(TransNo) > 1) order by ID";
            dtAI = ah.SelectToDataTable(strSQL);
            //dgvAI.AutoGenerateColumns = false;
            dgvAI.DataSource = dtAI;
            if (dtAI.Rows.Count > 0)
            {
                strSQL = "select ID,CodeID,TransNo from ApplicationDetail where IsDelete=0 and TransNo in (select TransNo from ApplicationInfo where IsDelete=0 and TransNo in (select  TransNo from  ApplicationInfo group  by TransNo  having count(TransNo) > 1)) order by ID";
                dtAD = ah.SelectToDataTable(strSQL);
                //dgvAD.AutoGenerateColumns = false;
                dgvAD.DataSource = dtAD;
                btnProcess.Enabled = true;
            }
            else
            {
                dgvAD.DataSource = null;
                btnProcess.Enabled = false;
            }
            ah.Close();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            //pbProcess.Visible = true;

            int intLastID = 0;
            int intLastCodeID = 0;
            int intCurrID = 0;
            int intCurrCodeID = 0;
            string strRandom = "";

            intAll = dtAD.Rows.Count;
            //Thread fThread = new Thread(new ThreadStart(SleepT));//开辟一个新的线程
            //fThread.Start();

            try
            {
                for (int x = 0; x < dtAI.Rows.Count; x++)
                {
                    Boolean boolFlag = false;
                    Random ro = new Random(10);
                    long tick = DateTime.Now.Ticks;
                    Random ran = new Random((int)(tick & 0xffffffffL) | (int)(tick >> 32));
                    strRandom = ran.Next().ToString().Substring(0,4);
                    intCurrID = int.Parse(dtAI.Rows[x]["ID"].ToString());
                    string strTransNoAI = dtAI.Rows[x]["TransNo"].ToString();
                    DataRow[] dr = dtAD.Select(" ID>" + intLastID + " and TransNo='" + strTransNoAI + "' ");
                    if (dr.Length > 0)
                    {
                        for (int y = 0; y < dr.Length; y++)
                        {
                            intCurr++;
                            string strTransNoAD = dr[y]["TransNo"].ToString();
                            intCurrCodeID = int.Parse(dr[y]["CodeID"].ToString());
                            if (intCurrCodeID > intLastCodeID || boolFlag == false)
                            {
                                boolFlag = true;
                                intLastID = int.Parse(dr[y]["ID"].ToString());
                                intLastCodeID = intCurrCodeID;
                                string strSQLAD = "update ApplicationDetail set TransNo='" + strTransNoAD + strRandom + "' where ID=" + intLastID;
                                AccessHelper ahAD = new AccessHelper();
                                ahAD.ExecuteSQLNonquery(strSQLAD);
                                //System.Threading.Thread.Sleep(500);
                                ahAD.Close();
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    string strSQLAI = "update ApplicationInfo set TransNo='" + strTransNoAI + strRandom + "' where ID=" + intCurrID;
                    AccessHelper ahAI = new AccessHelper();
                    ahAI.ExecuteSQLNonquery(strSQLAI);
                    //System.Threading.Thread.Sleep(500);
                    ahAI.Close();
                }
                MessageBox.Show("处理完毕", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("发生错误::" + intCurrID + "::" + intLastID + "::" + intCurrCodeID + "::" + intLastCodeID + "::" + ex.ToString(), "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            btnLoadData_Click(null, null);
        }
        private void SetTextMessage(int ipos)
        {
            if (this.InvokeRequired)
            {
                SetPos setpos = new SetPos(SetTextMessage);
                this.Invoke(setpos, new object[] { ipos });
            }
            else
            {
                this.label2.Text = ipos.ToString() + "%";
                this.pbProcess.Value = Convert.ToInt32(ipos);
            }
        }

        private void SleepT()
        {
            System.Threading.Thread.Sleep(100);//没什么意思，单纯的执行延时
            SetTextMessage(intCurr/intAll*100);
        }
    }
}
