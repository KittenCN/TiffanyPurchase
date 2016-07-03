using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using BHair.Business.BaseData;
using XLuSharpLibrary.DbAccess;
using System.Data.OleDb;
using System.Security.Cryptography;

namespace BHair.Business.Table
{
    /// <summary>转货表信息。</summary>
    public class ApplicationInfo
    {
        #region 构造函数...

        /// <summary>转货表</summary>
        public ApplicationInfo()
        { }



        #endregion

        #region 属性...

        private int _ID;
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        //交易号
        private string _transNo;
        public string TransNo
        {
            get { return _transNo; }
            set { _transNo = value; }
        }
        //申请人
        private string _applicants;
        public string Applicants
        {
            get { return _applicants; }
            set { _applicants = value; }
        }
        //申请人姓名
        private string _applicantsName;
        public string ApplicantsName
        {
            get { return _applicantsName; }
            set { _applicantsName = value; }
        }
        //申请人号码
        private string _applicantsNo;
        public string ApplicantsNo
        {
            get { return _applicantsNo; }
            set { _applicantsNo = value; }
        }
        //申请人职位
        private string _applicantsPos;
        public string ApplicantsPos
        {
            get { return _applicantsPos; }
            set { _applicantsPos = value; }
        }
        //员工所在店铺/办公室
        private string _location;
        public string Location
        {
            get { return _location; }
            set { _location = value; }
        }
        //申请日期
        private string _applicantsDate;
        public string ApplicantsDate
        {
            get { return _applicantsDate; }
            set { _applicantsDate = value; }
        }
        //购买地点
        private string _purchaseLocation;
        public string PurchaseLocation
        {
            get { return _purchaseLocation; }
            set { _purchaseLocation = value; }
        }
        //审批人（商品部
        private string _approvalName;
        public string ApprovalName
        {
            get { return _approvalName; }
            set { _approvalName = value; }
        }
        //审批时间（商品部
        private string _approvalDate;
        public string ApprovalDate
        {
            get { return _approvalDate; }
            set { _approvalDate = value; }
        }
        //审批人（经理
        private string _approvalName2;
        public string ApprovalName2
        {
            get { return _approvalName2; }
            set { _approvalName2 = value; }
        }
        //审批时间（经理
        private string _approvalDate2;
        public string ApprovalDate2
        {
            get { return _approvalDate2; }
            set { _approvalDate2 = value; }
        }
        //审批人（财务
        private string _approvalName3;
        public string ApprovalName3
        {
            get { return _approvalName3; }
            set { _approvalName3 = value; }
        }
        //审批时间（财务
        private string _approvalDate3;
        public string ApprovalDate3
        {
            get { return _approvalDate3; }
            set { _approvalDate3 = value; }
        }
        //店面确认状态
        private string _staffApproval;
        public string StaffApproval
        {
            get { return _staffApproval; }
            set { _staffApproval = value; }
        }
        //店面确认检查人
        private string _staffName;
        public string StaffName
        {
            get { return _staffName; }
            set { _staffName = value; }
        }
        //店面确认检查人ID
        private string _staffID;
        public string StaffID
        {
            get { return _staffID; }
            set { _staffID = value; }
        }
        //唯一码
        private string _unCode;
        public string UnCode
        {
            get { return _unCode; }
            set { _unCode = value; }
        }
        //销售日期
        private string _salesDate;
        public string SalesDate
        {
            get { return _salesDate; }
            set { _salesDate = value; }
        }
        //流程状态
        private int _appState;
        public int AppState
        {
            get { return _appState; }
            set { _appState = value; }
        }
        //修改原因
        private string _editReason;
        public string EditReason
        {
            get { return _editReason; }
            set { _editReason = value; }
        }
        //货币单位
        private int _moneyUnit;
        public int MoneyUnit
        {
            get { return _moneyUnit; }
            set { _moneyUnit = value; }
        }
        //修改/撤销备注
        private string _editRemark;
        public string EditRemark
        {
            get { return _editRemark; }
            set { _editRemark = value; }
        }
        //最终确认有无问题
        private int finalException;
        public int FinalException
        {
            get { return finalException; }
            set { finalException = value; }
        }


        public DataTable applicationDT = new DataTable();

        #endregion

        #region 自定义函数...

        /// <summary>
        /// 根据申请人ID查询订单ApplicationInfo表
        /// </summary>
        /// <param name="Applicants">申请人ID</param>
        /// <returns>Application表</returns>
        public DataTable SelectApplicationByApplicants(string Applicants,string sql)
        {
            AccessHelper ah = new AccessHelper();
            string sqlString = string.Format("select * from ApplicationInfo where IsDelete = 0 and AppState<5 and AppState<>4 and Applicants = '{0}' {1} order by [ApplicantsDate] desc", Applicants, sql);
            DataTable Result = ah.SelectToDataTable(sqlString);
            ah.Close();
            return Result;
        }

        /// <summary>
        /// 根据申请人ID查询历史订单ApplicationInfo表
        /// </summary>
        /// <param name="Applicants">申请人ID</param>
        /// <returns>Application表</returns>
        public DataTable SelectHistoryApplicationByApplicants(string Applicants, string sql)
        {
            AccessHelper ah = new AccessHelper();
            string sqlString = string.Format("select * from ApplicationInfo where IsDelete = 0 and AppState=9 and Applicants = '{0}' {1} order by [ApplicantsDate] desc", Applicants, sql);
            DataTable Result = ah.SelectToDataTable(sqlString);
            ah.Close();
            return Result;
        }

        /// <summary>
        /// 根据申请人ID查询生成唯一码后的ApplicationInfo表
        /// </summary>
        /// <param name="Applicants">申请人ID</param>
        /// <returns>Application表</returns>
        public DataTable SelectPassedApplicationByApplicants(string Applicants, string sql)
        {
            AccessHelper ah = new AccessHelper();
            string sqlString = string.Format("select * from ApplicationInfo where IsDelete = 0 and AppState>3 and AppState<9 and Applicants = '{0}' {1} order by [ApplicantsDate] desc", Applicants, sql);
            DataTable Result = ah.SelectToDataTable(sqlString);
            ah.Close();
            return Result;
        }

        /// <summary>
        /// 根据TransNo查询订单ApplicationInfo表
        /// </summary>
        /// <param name="Applicants">申请人ID</param>
        /// <returns>Application表</returns>
        public DataTable SelectApplicationByTransNo(string TransNo)
        {
            AccessHelper ah = new AccessHelper();
            string sqlString = string.Format("select * from ApplicationInfo where IsDelete = 0 and  TransNo = '{0}'", TransNo);
            DataTable Result = ah.SelectToDataTable(sqlString);
            ah.Close();
            return Result;
        }

        /// <summary>
        /// 商品部查询ApplicationInfo
        /// </summary>
        /// <returns></returns>
        public DataTable SelectApplicationByApproval(string sql)
        {
            AccessHelper ah = new AccessHelper();
            string sqlString = string.Format("select * from ApplicationInfo where IsDelete = 0 and AppState=1 {0} order by [ApplicantsDate] desc", sql);
            DataTable Result = ah.SelectToDataTable(sqlString);
            ah.Close();
            return Result;
        }

        /// <summary>
        /// 财务部查询ApplicationInfo
        /// </summary>
        /// <returns></returns>
        public DataTable cwSelectApplicationByApproval(string sql)
        {
            AccessHelper ah = new AccessHelper();
            string sqlString = string.Format("select * from ApplicationInfo where IsDelete = 0 and AppState=2 {0} order by [ApplicantsDate] desc", sql);
            DataTable Result = ah.SelectToDataTable(sqlString);
            ah.Close();
            return Result;
        }

        /// <summary>
        /// 商品部查询生成唯一码未确认购买
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable SelectUnCodedApplication(string sql)
        {
            AccessHelper ah = new AccessHelper();
            string sqlString = string.Format("select * from ApplicationInfo where IsDelete = 0 and AppState>=4 and AppState<6 {0} order by [ApplicantsDate] desc", sql);
            DataTable Result = ah.SelectToDataTable(sqlString);
            ah.Close();
            return Result;
        }


        /// <summary>
        /// 商品部查询全部ApplicationInfo
        /// </summary>
        /// <returns></returns>
        public DataTable SelectAllApplication(string sql)
        {
            AccessHelper ah = new AccessHelper();
            string sqlString = string.Format("select * from ApplicationInfo where IsDelete = 0 {0} order by [ApplicantsDate] desc", sql);
            DataTable Result = ah.SelectToDataTable(sqlString);
            ah.Close();
            return Result;
        }

        /// <summary>
        /// 商品部查询店面确认购买后的ApplicationInfo
        /// </summary>
        /// <returns></returns>
        public DataTable SelectNotPassedApplication(string sql)
        {
            AccessHelper ah = new AccessHelper();
            string sqlString = string.Format("select * from ApplicationInfo where IsDelete = 0 and AppState>3 and AppState<>5 and AppState<9  {0}order by [ApplicantsDate] desc", sql);
            DataTable Result = ah.SelectToDataTable(sqlString);
            ah.Close();
            return Result;
        }

        /// <summary>
        /// 经理查询自己下属ApplicationInfo
        /// </summary>
        /// <returns></returns>
        public DataTable SelectApplicationByApproval2(string Approval2,string sql)
        {
            AccessHelper ah = new AccessHelper();
            string sqlString = string.Format("select * from ApplicationInfo where IsDelete = 0 and AppState=0 and Approval2='{1}' {0} order by [ApplicantsDate] desc", sql, Approval2);
            DataTable Result = ah.SelectToDataTable(sqlString);
            ah.Close();
            return Result;
        }

        /// <summary>
        /// 财务查询自己下属ApplicationInfo
        /// </summary>
        /// <returns></returns>
        public DataTable SelectApplicationByApproval3(string Approval2, string sql)
        {
            AccessHelper ah = new AccessHelper();
            string sqlString = string.Format("select * from ApplicationInfo where IsDelete = 0 and AppState=2 {0} order by [ApplicantsDate] desc", sql);
            DataTable Result = ah.SelectToDataTable(sqlString);
            ah.Close();
            return Result;
        }

        /// <summary>
        /// 经理查询所有申请ApplicationInfo
        /// </summary>
        /// <returns></returns>
        public DataTable SelectAllApplicationByApproval2(string sql)
        {
            AccessHelper ah = new AccessHelper();
            string sqlString = string.Format("select * from ApplicationInfo where IsDelete = 0 and AppState=0 {0} order by [ApplicantsDate] desc", sql);
            DataTable Result = ah.SelectToDataTable(sqlString);
            ah.Close();
            return Result;
        }

        /// <summary>
        /// 经理查询已审核ApplicationInfo
        /// </summary>
        /// <returns></returns>
        public DataTable SelectHistoryApplicationByApproval2(string sql,Users users)
        {
            AccessHelper ah = new AccessHelper();
            string sqlString = string.Format("select * from ApplicationInfo where IsDelete = 0 and AppState>0 and Approval2='{1}'  {0} order by [ApplicantsDate] desc", sql, users.UID);
            DataTable Result = ah.SelectToDataTable(sqlString);
            ah.Close();
            return Result;
        }

        /// <summary>
        /// 财务查询已审核ApplicationInfo
        /// </summary>
        /// <returns></returns>
        public DataTable SelectHistoryApplicationByApproval3(string sql, Users users)
        {
            AccessHelper ah = new AccessHelper();
            string sqlString = string.Format("select * from ApplicationInfo where IsDelete = 0 and AppState>0 and Approval3='{1}'  {0} order by [ApplicantsDate] desc", sql, users.UID);
            DataTable Result = ah.SelectToDataTable(sqlString);
            ah.Close();
            return Result;
        }


        /// <summary>
        /// 确认店面根据唯一码查询ApplicationInfo
        /// </summary>
        /// <param name="Store"></param>
        /// <returns></returns>
        public DataTable SelectApplicationByStoreStaff(string Uncode,string sql)
        {
            AccessHelper ah = new AccessHelper();
            string sqlString = string.Format("select * from ApplicationInfo where IsDelete = 0 and AppState>3 and Uncode= '{0}' {1}", Uncode, sql);
            DataTable Result = ah.SelectToDataTable(sqlString);
            ah.Close();
            return Result;
        }

        /// <summary>
        /// 确认店面查询报表
        /// </summary>
        /// <param name="Store"></param>
        /// <returns></returns>
        public DataTable SelectHisApplicationByStore(string sql,string Store)
        {
            AccessHelper ah = new AccessHelper();
            string sqlString = string.Format("select ApplicationInfo.TransNo,ApplicationInfo.ApplicantsDate,ApplicationInfo.ApplicantsName,ApplicationDetail.ItemID,ApplicationDetail.ApprovalCount,ApplicationDetail.FinalPrice,ApplicationDetail.MoneyUnit from ApplicationDetail left join ApplicationInfo on ApplicationDetail.TransNo=ApplicationInfo.TransNo where ApplicationInfo.AppState=4 and  ApplicationInfo.IsDelete=0 and ApplicationInfo.PurchaseLocation='{1}' {0}", sql, Store);
            DataTable Result = ah.SelectToDataTable(sqlString);
            ah.Close();
            return Result;
        }

        /// <summary>
        /// 确认店面查询报表
        /// </summary>
        /// <param name="Store"></param>
        /// <returns></returns>
        public DataTable SelectHisApplicationByStore1(string sql)
        {
            AccessHelper ah = new AccessHelper();
            string sqlString = string.Format("select ApplicationInfo.TransNo,ApplicationInfo.ApplicantsDate,ApplicationInfo.ApplicantsName,ApplicationDetail.ItemID,ApplicationDetail.ApprovalCount,ApplicationDetail.FinalPrice,ApplicationDetail.MoneyUnit from ApplicationDetail left join ApplicationInfo on ApplicationDetail.TransNo=ApplicationInfo.TransNo where ApplicationInfo.AppState=9 and  ApplicationInfo.IsDelete=0  {0}", sql);
            DataTable Result = ah.SelectToDataTable(sqlString);
            ah.Close();
            return Result;
        }

        /// <summary>
        /// 查询历史订单ApplicationInfo表
        /// </summary>
        /// <returns>Application表</returns>
        public DataTable SelectHistoryApplication(string sql)
        {
            AccessHelper ah = new AccessHelper();
            string sqlString = string.Format("select * from ApplicationInfo where IsDelete = 0 and AppState = 9  {0} order by [ApplicantsDate] desc", sql);
            DataTable Result = ah.SelectToDataTable(sqlString);
            ah.Close();
            return Result;
        }

        /// <summary>
        /// 将提交的申请表Info插入数据库ApplicationInfo，添加申请表数据
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public int SubmitApplicationInfo(DataTable dt)
        {
            int rows = 0;
            try
            {
                SqlQueue sq = new SqlQueue();
                foreach (DataRow dr in dt.Rows)
                {
                    StringBuilder insertSql = new StringBuilder();
                    insertSql.Append("Insert into [ApplicationInfo]");
                    insertSql.Append(" ([TransNo],[Applicants],[ApplicantsName],[ApplicantsNo],[Location],[ApplicantsDate],[Approval],[ApprovalName],[ApprovalDate],[Approval2],[ApprovalName2],[ApprovalDate2],[TotalPrice],[Deadline],[SalesDate],[PurchaseLocation],[Store],[StoreName],[ApprovalState],[ApprovalState2],[StaffApproval],[StaffID],[StaffName],[IsDelete],[AppState],[UnCode],[MoneyUnit],[EditRemark]) ");
                    insertSql.Append("values");
                    insertSql.AppendFormat(" ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}',{12},'{13}','{14}','{15}','{16}','{17}',{18},{19},{20},'{21}','{22}',{23},{24},'{25}',{26},'{27}')", dr["TransNo"], dr["Applicants"], dr["ApplicantsName"], dr["ApplicantsNo"], dr["Location"], dr["ApplicantsDate"], dr["Approval"], dr["ApprovalName"], dr["ApprovalDate"], dr["Approval2"], dr["ApprovalName2"], dr["ApprovalDate2"], dr["TotalPrice"], dr["Deadline"], dr["SalesDate"], dr["PurchaseLocation"], dr["Store"], dr["StoreName"], dr["ApprovalState"], dr["ApprovalState2"], dr["StaffApproval"], dr["StaffID"], dr["StaffName"], dr["IsDelete"], dr["AppState"], dr["UnCode"], dr["MoneyUnit"],dr["EditRemark"]);
                    sq.InsertQuery(insertSql.ToString(), "", "", 0, 0);
                }
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
        /// 修改申请表数据ApplicationInfo
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public int UpdateApplicationInfo(DataTable dt)
        {
            int rows = 0;
            DataTable insertDT = dt.Clone();
            try
            {
                SqlQueue sq = new SqlQueue();
                foreach (DataRow dr in dt.Rows)
                {
                    StringBuilder insertSql = new StringBuilder();
                    
                        insertSql.Append("Update [ApplicationInfo] set ");
                        insertSql.AppendFormat(" [TransNo]='{0}',", dr["TransNo"]);
                        insertSql.AppendFormat(" [Applicants]='{0}',", dr["Applicants"]);
                        insertSql.AppendFormat(" [ApplicantsName]='{0}',", dr["ApplicantsName"]);
                        insertSql.AppendFormat(" [ApplicantsNo]='{0}',", dr["ApplicantsNo"]);
                        insertSql.AppendFormat(" [Location]='{0}',", dr["Location"]);
                        insertSql.AppendFormat(" [ApplicantsDate]='{0}',", dr["ApplicantsDate"]);
                        insertSql.AppendFormat(" [Approval]='{0}',", dr["Approval"]);
                        insertSql.AppendFormat(" [ApprovalName]='{0}',", dr["ApprovalName"]);
                        insertSql.AppendFormat(" [ApprovalDate]='{0}',", dr["ApprovalDate"]);
                        insertSql.AppendFormat(" [Approval2]='{0}',", dr["Approval2"]);
                        insertSql.AppendFormat(" [ApprovalName2]='{0}',", dr["ApprovalName2"]);
                        insertSql.AppendFormat(" [ApprovalDate2]='{0}',", dr["ApprovalDate2"]);
                        insertSql.AppendFormat(" [TotalPrice]={0},", dr["TotalPrice"]);
                        insertSql.AppendFormat(" [Deadline]='{0}',", dr["Deadline"]);
                        insertSql.AppendFormat(" [SalesDate]='{0}',", dr["SalesDate"]);
                        insertSql.AppendFormat(" [PurchaseLocation]='{0}',", dr["PurchaseLocation"]);
                        insertSql.AppendFormat(" [Store]='{0}',", dr["Store"]);
                        insertSql.AppendFormat(" [StoreName]='{0}',", dr["StoreName"]);
                        insertSql.AppendFormat(" [ApprovalState]={0},", dr["ApprovalState"]);
                        insertSql.AppendFormat(" [ApprovalState2]={0},", dr["ApprovalState2"]);
                        insertSql.AppendFormat(" [StaffApproval]={0},", dr["StaffApproval"]);
                        insertSql.AppendFormat(" [StaffID]='{0}',", dr["StaffID"]);
                        insertSql.AppendFormat(" [StaffName]='{0}',", dr["StaffName"]);
                        insertSql.AppendFormat(" [IsDelete]={0},", dr["IsDelete"]);
                        insertSql.AppendFormat(" [AppState]={0},", dr["AppState"]);
                        insertSql.AppendFormat(" [EditReason]='{0}',", dr["EditReason"]);
                        insertSql.AppendFormat(" [MoneyUnit]={0},", dr["MoneyUnit"]);
                        insertSql.AppendFormat(" [EditRemark]='{0}',", dr["EditRemark"]);
                        insertSql.AppendFormat(" [UnCode]='{0}'", dr["UnCode"]);
                        insertSql.AppendFormat(" where [ID]={0}", dr["ID"]);


                        sq.InsertQuery(insertSql.ToString(), "", "", 0, 0);
                }
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

        ///// <summary>
        ///// 修改申请详情表Detail
        ///// </summary>
        ///// <param name="dt"></param>
        ///// <returns></returns>
        //public int UpdateApplicationDetail(DataTable dt)
        //{
        //    int rows = 0;
        //    AccessHelper ah = new AccessHelper();
        //    try
        //    {
        //        OleDbDataAdapter adapt = new OleDbDataAdapter("select * from ApplicationDetail", ah.Conn);
        //        OleDbCommandBuilder odcb = new OleDbCommandBuilder(adapt);
        //        odcb.QuotePrefix = "[";
        //        odcb.QuoteSuffix = "]";
        //        rows += adapt.Update(dt);
        //    }
        //    catch (Exception ex)
        //    {
        //        //throw ex;
        //        ah.Close();
        //        return 0;
        //    }
        //    ah.Close();
        //    return rows;
        //}

        /// <summary>
        /// 商品部审批
        /// </summary>
        /// <param name="CtrlID">控制号</param>
        /// <returns></returns>
        public int ApprovalApplication(string TransNo, Users users, int ApprovalState, DateTime dt)
        {
            //string unCode = GetSHA1(TransNo);
            int rows = 0;
            try
            {
                SqlQueue sq = new SqlQueue();
                string sql = string.Format("Update ApplicationInfo Set ApprovalDate = '{3}', AppState = 2 ,Approval='{1}' , ApprovalName='{2}' where   AppState=1 and IsDelete = 0 and TransNo='{0}'", TransNo, users.UID, users.UserName, dt);
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
        /// 财务部审批
        /// </summary>
        /// <param name="CtrlID">控制号</param>
        /// <returns></returns>
        public int ApprovalApplication3(string TransNo, Users users, int ApprovalState, DateTime dt)
        {
            string unCode = GetSHA1(TransNo);
            int rows = 0;
            try
            {
                SqlQueue sq = new SqlQueue();
                string sql = string.Format("Update ApplicationInfo Set ApprovalDate = '{3}', AppState = 4 ,Approval='{1}' , ApprovalName='{2}',UnCode='{4}' where   AppState=2 and IsDelete = 0 and TransNo='{0}'", TransNo, users.UID, users.UserName, dt, unCode);
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

        ///// <summary>
        ///// 商品部审批不通过
        ///// </summary>
        ///// <param name="CtrlID">控制号</param>
        ///// <returns></returns>
        //public int ApprovalNotApplication(string TransNo, string UID ,string UserName, int ApprovalState, DateTime dt)
        //{
        //    int rows = 0;
        //    AccessHelper ah = new AccessHelper();
        //    string sql;
        //    sql = string.Format("Update ApplicationInfo Set ApprovalDate = '{3}', AppState = 3,Approval='{1}' , ApprovalName='{2}' where   AppState=1 and IsDelete = 0 and TransNo='{0}'", TransNo, UID, UserName, dt);
        //    try
        //    {
        //        OleDbCommand comm = new OleDbCommand(sql, ah.Conn);
        //        rows = comm.ExecuteNonQuery();
        //    }
        //    catch (Exception ex)
        //    {
        //        ah.Close();
        //        return 0;
        //    }
        //    ah.Close();
        //    return rows;
        //}


        /// <summary>
        /// 员工确认商品部修改后的申请单
        /// </summary>
        /// <param name="CtrlID">控制号</param>
        /// <returns></returns>
        public int StaffApprovalApplication(string TransNo)
        {
            string unCode = GetSHA1(TransNo);
            int rows = 0;
            try
            {
                SqlQueue sq = new SqlQueue();
                string sql = string.Format("Update ApplicationInfo Set  AppState = 4,UnCode='{1}' where   AppState=3 and IsDelete = 0 and TransNo='{0}'", TransNo, unCode);
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
        /// 经理审批
        /// </summary>
        /// <param name="CtrlID">控制号</param>
        /// <returns></returns>
        public int ApprovalApplication2(string TransNo, Users users, int ApprovalState, DateTime dt)
        {
            int rows = 0;
            try
            {
                SqlQueue sq = new SqlQueue();
                string sql = string.Format("Update ApplicationInfo Set ApprovalDate2 = '{3}', AppState = 1 ,Approval2='{1}' , ApprovalName2='{2}' where   AppState=0 and IsDelete = 0 and TransNo='{0}'", TransNo, users.UID, users.UserName, dt);
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
        /// 确认店面确认
        /// </summary>
        /// <param name="CtrlID">控制号</param>
        /// <returns></returns>
        public int StoreConfirm(string TransNo,  Users user, DateTime dt)
        {
            int rows = 0;
            try
            {
                SqlQueue sq = new SqlQueue();
                string sql = string.Format("Update ApplicationInfo Set StaffName = '{0}' ,StaffID='{1}' ,SalesDate='{2}', AppState=6,StaffApproval=1  where  AppState<6 and IsDelete = 0 and TransNo='{3}'", user.UserName, user.UID, dt, TransNo);
                sq.InsertQuery(sql.ToString(), "确认唯一码", TransNo, 0, 0);
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
        /// 扣额度
        /// </summary>
        /// <param name="CtrlID">控制号</param>
        /// <returns></returns>
        public int StorePay(string TransNo, string check, string UID, double TotalPrice,double MoneyRate)
        {
            int rows = 0;
            try
            {
                double FinalPrice = TotalPrice * MoneyRate;
                SqlQueue sq = new SqlQueue();
                string sql = string.Format("Update [Users] Set [RestAmount] = ([RestAmount]-{0})  where  [UID]='{1}'", FinalPrice, UID);
                sq.InsertQuery(sql.ToString(), "确认唯一码", TransNo, 0, 0);
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
        /// 计算已用额度
        /// </summary>
        /// <param name="CtrlID">控制号</param>
        /// <returns></returns>
        public bool CanBuy(string TransNo, string check, string UID,double TotalPrice)
        {
            AccessHelper ah = new AccessHelper();
            try
            {
                string sql;
                string sqlString = string.Format("select * from Users where IsDelete = 0 and UID='{0}'", UID);
                DataTable Result = ah.SelectToDataTable(sqlString);
                if (Result.Rows.Count > 0)
                {
                    double RestMoney = double.Parse(Result.Rows[0]["RestAmount"].ToString());
                    RestMoney = RestMoney - TotalPrice;
                    if(RestMoney>0) return true;
                }
            }
            catch(Exception ex)
            {
                ah.Close();
                return false;
            }
            ah.Close();
            return false ;
        }

        /// <summary>
        /// 商品部最终确认
        /// </summary>
        /// <param name="CtrlID">控制号</param>
        /// <returns></returns>
        public int FinalConfirm(string TransNo)
        {
            int rows = 0;
            try
            {
                SqlQueue sq = new SqlQueue();
                string sql = string.Format("Update ApplicationInfo Set AppState=9 , FinalState=1 where IsDelete = 0 and TransNo='{0}'", TransNo);
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
        /// 最终确认异常
        /// </summary>
        /// <param name="CtrlID">控制号</param>
        /// <returns></returns>
        public int SetFinalException(string TransNo)
        {
            int rows = 0;
            try
            {
                SqlQueue sq = new SqlQueue();
                string sql = string.Format("Update ApplicationInfo Set FinalException=1 where IsDelete = 0 and TransNo='{0}'", TransNo);
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
        /// 删除订单表数据
        /// </summary>
        /// <param name="CtrlID"></param>
        /// <returns></returns>
        public int DeleteApplicaionInfo(string TransNo)
        {
            int rows = 0;
            try
            {
                SqlQueue sq = new SqlQueue();
                string sql = string.Format("Update ApplicationInfo Set IsDelete =1 Where TransNo='{0}'", TransNo);
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

        

        #endregion


        string GetSHA1(string mystr)
        {
            SHA1 sha = new SHA1CryptoServiceProvider();

            //将mystr转换成byte[]
            ASCIIEncoding enc = new ASCIIEncoding();
            byte[] dataToHash = enc.GetBytes(mystr);

            //Hash运算
            byte[] dataHashed = sha.ComputeHash(dataToHash);

            //将运算结果转换成string
            string hash = BitConverter.ToString(dataHashed).Replace("-", "");

            return hash;
        }



        /// <summary>
        /// 获取申请批准后超时提醒
        /// </summary>
        /// <param name="UID"></param>
        /// <returns></returns>
        public DataTable SelectAlertApproval()
        {
            AccessHelper ah = new AccessHelper();
            string sqlString = string.Format("select * from ApplicationInfo where [IsDelete]=0  and [AppState]<2 and [ApplicantsDate]<#{1}# ", DateTime.Now.AddHours(-72));
            DataTable Result = ah.SelectToDataTable(sqlString);
            ah.Close();
            return Result;
        }




    }
}
