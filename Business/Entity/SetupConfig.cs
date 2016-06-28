using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using XLuSharpLibrary.DbAccess;
using System.Data.OleDb; 

namespace BHair.Business.BaseData
{
    /// <summary>设置。</summary>
    public class SetupConfig
    {
        #region 构造函数...

        /// <summary>设置。</summary>
        public SetupConfig()
        { }


        #endregion

        #region 属性...

        //Email账号
        private string _emailID;
        public string EmailID
        {
            get { return _emailID; }
            set { _emailID = value; }
        }
        //Email密码
        private string _emailPwd;
        public string EmailPwd
        {
            get { return _emailPwd; }
            set { _emailPwd = value; }
        }
        //Email地址
        private string _emailAddress;
        public string EmailAddress
        {
            get { return _emailAddress; }
            set { _emailAddress = value; }
        }
        //Email的STMP
        private string _emailSMTP;
        public string EmailSMTP
        {
            get { return _emailSMTP; }
            set { _emailSMTP = value; }
        }
        //港元送礼上限
        private decimal _HKD;
        public decimal HKD
        {
            get { return _HKD; }
            set { _HKD = value; }
        }
        //美元送礼上限
        private decimal _USD;
        public decimal USD
        {
            get { return _USD; }
            set { _USD = value; }
        }
        //人民币送礼上限
        private decimal _CNY;
        public decimal CNY
        {
            get { return _CNY; }
            set { _CNY = value; }
        }
        //美元汇率
        private decimal _USrate;
        public decimal USrate
        {
            get { return _USrate; }
            set { _USrate = value; }
        }
        //港币汇率
        private decimal _HKrate;
        public decimal HKrate
        {
            get { return _HKrate; }
            set { _HKrate = value; }
        }
        #endregion

        #region 自定义函数...

        /// <summary>
        /// 获取配置
        /// </summary>
        /// <param name="CtrlID"></param>
        /// <returns></returns>
        public DataTable GetConfig()
        {
            AccessHelper ah = new AccessHelper();
            string sqlString = string.Format("select * from [SetupConfig]");
            DataTable Result = ah.SelectToDataTable(sqlString);
            ah.Close();
            return Result;
        }

        /// <summary>
        /// 修改配置
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public int UpdateConfig()
        {
            int rows = 0;
            try
            {
                SqlQueue sq = new SqlQueue();

                    StringBuilder insertSql = new StringBuilder();
                    insertSql.Append("Update [SetupConfig] set ");
                    insertSql.AppendFormat(" [EmailID]='{0}',", EmailID);
                    insertSql.AppendFormat(" [EmailPwd]='{0}',", EmailPwd);
                    insertSql.AppendFormat(" [EmailAddress]='{0}',", EmailAddress);
                    insertSql.AppendFormat(" [EmailSMTP]='{0}',", EmailSMTP);
                    insertSql.AppendFormat(" [HKD]={0},", HKD);
                    insertSql.AppendFormat(" [USD]={0},", USD);
                    insertSql.AppendFormat(" [CNY]={0},", CNY);
                    insertSql.AppendFormat(" [USrate]={0},", USrate);
                    insertSql.AppendFormat(" [HKrate]={0}", HKrate);
                    //insertSql.AppendFormat(" where [ID]={0}", ID);
                    sq.InsertQuery(insertSql.ToString(), "", "", 0, 0);

                sq.Close();
                return 1;
            }
            catch (Exception ex)
            {
                //throw ex;
                return 0;
            }
            return rows;
        }
        #endregion
    }
}
