using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using XLuSharpLibrary.DbAccess;
using System.Data.OleDb; 

namespace BHair.Business.BaseData
{
    /// <summary>用户。</summary>
    public class Users
    {
        #region 构造函数...

        /// <summary>用户。</summary>
        public Users()
        { }


        #endregion

        #region 属性...

        private int _ID;
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        //用户账号
        private string _UID;
        public string UID
        {
            get { return _UID; }
            set { _UID = value; }
        }
        // 用户编号
        private string _employeeID;
        public string EmployeeID
        {
            get { return _employeeID; }
            set { _employeeID = value; }
        }
        //用户姓名
        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        //用户密码
        private string _userPwd;
        public string UserPwd
        {
            get { return _userPwd; }
            set { _userPwd = value; }
        }
        //电话
        private string _tel;
        public string Tel
        {
            get { return _tel; }
            set { _tel = value; }
        }
        //Email
        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        //职位
        private string _position;
        public string Position
        {
            get { return _position; }
            set { _position = value; }
        }
        //部门
        private string _department;
        public string Department
        {
            get { return _department; }
            set { _department = value; }
        }
        //所属店面
        private string _store;
        public string Store
        {
            get { return _store; }
            set { _store = value; }
        }
        //用户信息描述
        private string _detail;
        public string Detail
        {
            get { return _detail; }
            set { _detail = value; }
        }
        //创建时间
        private DateTime _createTime;
        public DateTime CreateTime
        {
            get { return _createTime; }
            set { _createTime = value; }
        }
        //登陆时间
        private DateTime _loginTime;
        public DateTime LoginTime
        {
            get { return _loginTime; }
            set { _loginTime = value; }
        }
        //上次登录时间
        private DateTime _lastLoginTime;
        public DateTime LastLoginTime
        {
            get { return _lastLoginTime; }
            set { _lastLoginTime = value; }
        }
        //是否为管理员
        private int _isAdmin;
        public int IsAdmin
        {
            get { return _isAdmin; }
            set { _isAdmin = value; }
        }
        //所属角色 1=商品部（可审批可修改）；2=经理（只可审批）；3=店面用户（提交申请和确认申请）
        private int _character;
        public int Character
        {
            get { return _character; }
            set { _character = value; }
        }
        //上属经理
        private string _managerID;
        public string ManagerID
        {
            get { return _managerID; }
            set { _managerID = value; }
        }
        //是否被删除 1=被删除
        private int _isDelete;
        public int IsDelete
        {
            get { return _isDelete; }
            set { _isDelete = value; }
        }
        //当年总额
        private double _totalAmount;
        public double TotalAmount
        {
            get { return _totalAmount; }
            set { _totalAmount = value; }
        }
        //当年已用额度
        private double _usedAmount;
        public double UsedAmount
        {
            get { return _usedAmount; }
            set { _usedAmount = value; }
        }
        //当年剩余额度
        private double _restAmount;
        public double RestAmount
        {
            get { return _restAmount; }
            set { _restAmount = value; }
        }
        //货币单位
        private int _moneyUnit;
        public int MoneyUnit
        {
            get { return _moneyUnit; }
            set { _moneyUnit = value; }
        }
        //是否被冻结 0=被冻结
        private int _isAble;
        public int IsAble
        {
            get { return _isAble; }
            set { _isAble = value; }
        }

        private int _AbleMode;
        public int AbleMode
        {
            get { return _AbleMode; }
            set { _AbleMode = value; }
        }

        public DataTable UsersDT = new DataTable();

        #endregion

        #region 自定义函数...

        /// <summary>
        /// 查询所有用户
        /// </summary>
        /// <param name="CtrlID"></param>
        /// <returns></returns>
        public DataTable SelectAllUsers(string sql)
        {
            AccessHelper ah = new AccessHelper();
            string sqlString = string.Format("select * from [Users] where IsDelete = 0 {0}",sql);
            DataTable Result = ah.SelectToDataTable(sqlString);
            ah.Close();
            return Result;
        }

        /// <summary>
        /// 通过账户查询用户
        /// </summary>
        /// <param name="CtrlID"></param>
        /// <returns></returns>
        public DataTable SelectUsersByUID(string UID)
        {
            AccessHelper ah = new AccessHelper();
            string sqlString = string.Format("select * from Users where IsDelete = 0 and UID='{0}'", UID);
            DataTable Result = ah.SelectToDataTable(sqlString);
            ah.Close();
            return Result;
        }

        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="CtrlID"></param>
        /// <returns></returns>
        public DataTable Login(string UID, string UserPwd)
        {
            AccessHelper ah = new AccessHelper();
            string sqlString = string.Format("select * from Users where IsDelete = 0 and UID = '{0}' and UserPwd='{1}'", UID, UserPwd);
            DataTable Result = ah.SelectToDataTable(sqlString);
            ah.Close();
            return Result;
        }
        public DataTable Login(string UID)
        {
            AccessHelper ah = new AccessHelper();
            string sqlString = string.Format("select * from Users where IsDelete = 0 and UID = '{0}'", UID);
            DataTable Result = ah.SelectToDataTable(sqlString);
            ah.Close();
            return Result;
        }

        /// <summary>
        /// 添加用户Users
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public int InsertUser(Users user)
        {
            int rows = 0;
            try
            {
                SqlQueue sq = new SqlQueue();

                    StringBuilder insertSql = new StringBuilder();
                    insertSql.Append("Insert into [Users]");
                    insertSql.Append(" ([UID],[EmployeeID],[UserName],[UserPwd],[Tel],[Email],[Position],[Department],[Detail],[IsAdmin],[Character],[IsDelete],[TotalAmount],[UsedAmount],[RestAmount],[MoneyUnit],[ManagerID],[IsAble],[Store]) ");
                    insertSql.Append("values");
                    insertSql.AppendFormat(" ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}',{9},{10},{11},{12},{13},{14},{15},'{16}',{17},'{18}')", user.UID, user.EmployeeID, user.UserName, user.UserPwd, user.Tel, user.Email, user.Position, user.Department, user.Detail, user.IsAdmin, user.Character, user.IsDelete, user.TotalAmount, user.UsedAmount, user.RestAmount, user.MoneyUnit, user.ManagerID,user.IsAble,user.Store);
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

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public int UpdateUser(Users user)
        {
            int rows = 0;
            try
            {
                SqlQueue sq = new SqlQueue();

                StringBuilder insertSql = new StringBuilder();
                insertSql.Append("Update [Users] set ");
                insertSql.AppendFormat(" [EmployeeID]='{0}',", user.EmployeeID);
                insertSql.AppendFormat(" [UserName]='{0}',", user.UserName);
                insertSql.AppendFormat(" [UserPwd]='{0}',", user.UserPwd);
                insertSql.AppendFormat(" [Tel]='{0}',", user.Tel);
                insertSql.AppendFormat(" [Email]='{0}',", user.Email);
                insertSql.AppendFormat(" [Position]='{0}',", user.Position);
                insertSql.AppendFormat(" [Department]='{0}',", user.Department);
                insertSql.AppendFormat(" [Detail]='{0}',", user.Detail);
                insertSql.AppendFormat(" [IsAdmin]={0},", user.IsAdmin);
                insertSql.AppendFormat(" [Character]={0},", user.Character);
                insertSql.AppendFormat(" [IsDelete]={0},", user.IsDelete);
                insertSql.AppendFormat(" [TotalAmount]={0},", user.TotalAmount);
                insertSql.AppendFormat(" [UsedAmount]={0},", user.UsedAmount);
                insertSql.AppendFormat(" [RestAmount]={0},", user.RestAmount);
                insertSql.AppendFormat(" [MoneyUnit]={0},", user.MoneyUnit);
                insertSql.AppendFormat(" [ManagerID]='{0}',", user.ManagerID);
                insertSql.AppendFormat(" [Store]='{0}',", user.Store);
                insertSql.AppendFormat(" [IsAble]={0},", user.IsAble);
                insertSql.AppendFormat(" [AbleMode]={0}", user.AbleMode);
                insertSql.AppendFormat(" where [UID]='{0}'", user.UID);
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

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="UID"></param>
        /// <returns></returns>
        public int DeleteUser(string UID)
        {
            int rows = 0;
            try
            {
                SqlQueue sq = new SqlQueue();
                string sql = string.Format("Update Users Set IsDelete =1 Where UID='{0}'", UID);
                sq.InsertQuery(sql, "", "", 0, 0);
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




        /// <summary>
        /// 清空用户表
        /// </summary>
        /// <returns></returns>
        public bool ClearUsers()
        {
            bool Result = true;
            AccessHelper ah = new AccessHelper();
            string sqlString = string.Format("Delete from  Users Where [UID]<>'Administrator'");
            Result = ah.ExecuteSQLNonquery(sqlString);
            ah.Close();
            return Result;
        }

        /// <summary>
        /// 导入用户表
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public int QuickImportUsers(DataTable dt)
        {
            int rows = 0;
            AccessHelper ah = new AccessHelper();
            try
            {
                OleDbDataAdapter adapt = new OleDbDataAdapter("select * from Users", ah.Conn);
                OleDbCommandBuilder odcb = new OleDbCommandBuilder(adapt);
                odcb.QuotePrefix = "[";
                odcb.QuoteSuffix = "]";
                rows += adapt.Update(dt);
            }
            catch (Exception ex)
            {
                //throw ex;
                ah.Close();
                return 0;
            }
            ah.Close();
            return rows;
        }





        public int UpdateEmployeeID(DataTable dt)
        {
            int rows = 0;
            AccessHelper ah = new AccessHelper();
            try
            {
                string resetSql = string.Format("Update Users Set [IsAble]=0 Where [UID]<>'Administrator'");
                OleDbCommand comm1 = new OleDbCommand(resetSql, ah.Conn);
                rows += comm1.ExecuteNonQuery();
                foreach (DataRow dr in dt.Rows)
                {
                    string sql = string.Format("Update Users Set [IsAble] =1 Where [ID]={0}", dr["ID"]);
                    OleDbCommand comm = new OleDbCommand(sql, ah.Conn);
                    rows += comm.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                //throw ex;
                ah.Close();
                return 0;
            }
            ah.Close();
            return rows;
        }


        public bool ResetPwd(string UserID)
        {
            bool Result = false;
            AccessHelper ah = new AccessHelper();
            try
            {
                string sql = string.Format("Update Users Set [UserPwd]='05B530AD0FB56286FE051D5F8BE5B8453F1CD93F' where [UID]='{0}'",UserID);
                Result=ah.ExecuteSQLNonquery(sql);
            }
            catch(Exception ex)
            {
                ah.Close();
                return false;
            }
            ah.Close();
            return Result;
        }


        #endregion
    }
}
