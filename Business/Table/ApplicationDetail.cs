using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using BHair.Business.BaseData;
using XLuSharpLibrary.DbAccess;
using System.Data.OleDb;

namespace BHair.Business.Table
{
    /// <summary>转货详情表信息。</summary>
    public class ApplicationDetail
    {
        #region 构造函数...

        /// <summary>转货详情表</summary>
        public ApplicationDetail()
        { }



        #endregion

        #region 属性...

        private int _ID;
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        //控制号
        private string _ctrlID;
        public string CtrlID
        {
            get { return _ctrlID; }
            set { _ctrlID = value; }
        }
        //部门
        private string _department;
        public string Department
        {
            get { return _department; }
            set { _department = value; }
        }
        //级别
        private string _level;
        public string Level
        {
            get { return _level; }
            set { _level = value; }
        }
        //货号
        private string _itemID;
        public string ItemID
        {
            get { return _itemID; }
            set { _itemID = value; }
        }
        //双货号
        private string _itemID2;
        public string ItemID2
        {
            get { return _itemID2; }
            set { _itemID2 = value; }
        }
        //产品描述
        private string _detail;
        public string Detail
        {
            get { return _detail; }
            set { _detail = value; }
        }
        //单价
        private int _price;
        public int Price
        {
            get { return _price; }
            set { _price = value; }
        }
        //数量
        private int _count;
        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }
        //假删
        private int _isDelete;
        public int IsDelete
        {
            get { return _isDelete; }
            set { _isDelete = value; }
        }

        public DataTable dataTable = new DataTable();

        #endregion

        #region 自定义函数...

        /// <summary>
        /// 根据控制号查询订单详情ApplicationDetail表
        /// </summary>
        /// <param name="CtrlID"></param>
        /// <returns></returns>
        public DataTable SelectAppDetailByTransNo(string TransNo, string sql)
        {
            AccessHelper ah = new AccessHelper();
            string sqlString = string.Format("select * from ApplicationDetail where IsDelete = 0 and TransNo = '{0}' {1}", TransNo, sql);
            DataTable Result = ah.SelectToDataTable(sqlString);
            ah.Close();
            return Result;
        }



        /// <summary>
        /// 添加ApplicationDetail数据
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public int SubmitApplicationDetail(DataTable dt, double douTotalPrice, string strUID,int intFlag)
        {
            int rows = 0;
            try
            {
                SqlQueue sq = new SqlQueue();
                foreach (DataRow dr in dt.Rows)
                {
                    StringBuilder insertSql = new StringBuilder();
                    insertSql.Append("Insert into [ApplicationDetail]");
                    insertSql.Append(" ([CodeID],[TransNo],[ItemID],[Detail],[Price],[MoneyUnit],[Count],[IsDelete],[SelforGift],[ApprovalCount],[ApprovalDiscount],[FinalPrice],[Recipient],[Relationship],[Reason],[IsSuccess],[PhoneNum]) ");
                    insertSql.Append("values");
                    insertSql.AppendFormat(" ('{0}','{1}','{2}','{3}',{4},{5},{6},{7},{8},{9},{10},{11},'{12}','{13}','{14}',{15},'{16}')", dr["CodeID"], dr["TransNo"], dr["ItemID"], dr["Detail"], dr["Price"], dr["MoneyUnit"], dr["Count"], dr["IsDelete"], dr["SelforGift"], dr["ApprovalCount"], dr["ApprovalDiscount"], dr["FinalPrice"], dr["Recipient"], dr["Relationship"], dr["Reason"], dr["IsSuccess"], dr["PhoneNum"]);
                    sq.InsertQuery(insertSql.ToString(), "Cache" + strUID, dr["TransNo"].ToString(), douTotalPrice, intFlag);
                }
                sq.Close();
                return 1;
            }
            catch (Exception)
            {
                //throw ex;

                return 0;
            }
            return rows;
        }


        /// <summary>
        /// 修改申请表详情数据ApplicationDetail
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public int UpdateApplicationDetail(DataTable dt, double douTotalPrice,string strUID,int intFlag)
        {
            int rows = 0;
            DataTable insertDT = dt.Clone();
            try
            {
                SqlQueue sq = new SqlQueue();
                foreach (DataRow dr in dt.Rows)
                {
                    StringBuilder insertSql = new StringBuilder();
                    if (dr.RowState == DataRowState.Added)
                    {
                        insertSql.Append("Insert into [ApplicationDetail]");
                        insertSql.Append(" ([CodeID],[TransNo],[ItemID],[Detail],[Price],[MoneyUnit],[Count],[IsDelete],[SelforGift],[ApprovalCount],[ApprovalDiscount],[FinalPrice],[Recipient],[Relationship],[Reason],[IsSuccess],[PhoneNum]) ");
                        insertSql.Append("values");
                        insertSql.AppendFormat(" ('{0}','{1}','{2}','{3}',{4},{5},{6},{7},{8},{9},{10},{11},'{12}','{13}','{14}',{15},'{16}')", dr["CodeID"], dr["TransNo"], dr["ItemID"], dr["Detail"], dr["Price"], dr["MoneyUnit"], dr["Count"], dr["IsDelete"], dr["SelforGift"], dr["ApprovalCount"], dr["ApprovalDiscount"], dr["FinalPrice"], dr["Recipient"], dr["Relationship"], dr["Reason"], dr["IsSuccess"], dr["PhoneNum"]);

                    }
                    else if (dr.RowState == DataRowState.Deleted)
                    {
                        dr.RejectChanges();
                        insertSql.AppendFormat("Delete from [ApplicationDetail] where [ID]={0}", dr["ID"]);
                    }
                    else
                    {

                        insertSql.Append("Update [ApplicationDetail] set ");
                        insertSql.AppendFormat(" [CodeID]='{0}',", dr["CodeID"]);
                        insertSql.AppendFormat(" [TransNo]='{0}',", dr["TransNo"]);
                        insertSql.AppendFormat(" [ItemID]='{0}',", dr["ItemID"]);
                        insertSql.AppendFormat(" [Detail]='{0}',", dr["Detail"]);
                        insertSql.AppendFormat(" [Price]={0},", dr["Price"]);
                        insertSql.AppendFormat(" [MoneyUnit]={0},", dr["MoneyUnit"]);
                        insertSql.AppendFormat(" [Count]={0},", dr["Count"]);
                        insertSql.AppendFormat(" [IsDelete]={0},", dr["IsDelete"]);
                        insertSql.AppendFormat(" [SelforGift]={0},", dr["SelforGift"]);
                        insertSql.AppendFormat(" [ApprovalCount]={0},", dr["ApprovalCount"]);
                        insertSql.AppendFormat(" [ApprovalDiscount]={0},", dr["ApprovalDiscount"]);
                        insertSql.AppendFormat(" [FinalPrice]={0},", dr["FinalPrice"]);
                        insertSql.AppendFormat(" [Recipient]='{0}',", dr["Recipient"]);
                        insertSql.AppendFormat(" [Relationship]='{0}',", dr["Relationship"]);
                        insertSql.AppendFormat(" [Reason]='{0}',", dr["Reason"]);
                        insertSql.AppendFormat(" [IsSuccess]='{0}',", dr["IsSuccess"]);
                        insertSql.AppendFormat(" [PhoneNum]='{0}'", dr["PhoneNum"]);
                        insertSql.AppendFormat(" where [ID]={0}", dr["ID"]);
                    }
                    if (insertSql.ToString().ToLower().Substring(0, 6) == "insert".Substring(0, 6) || insertSql.ToString().ToLower().Substring(0, 6) == "update".Substring(0, 6))
                    {
                        sq.InsertQuery(insertSql.ToString(), "Cache" + strUID, dr["TransNo"].ToString(), douTotalPrice, intFlag);
                    }
                    else
                    {
                        sq.InsertQuery(insertSql.ToString(), "", "", 0, 0);
                    }
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
        /// 购买确认详情
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public int UpdateBuyApplicationDetail(DataTable dt, string TransNo)
        {
            int rows = 0;
            DataTable insertDT = dt.Clone();
            try
            {
                SqlQueue sq = new SqlQueue();
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["IsSuccess"].ToString() == "1")
                    {
                        StringBuilder insertSql = new StringBuilder();

                        insertSql.Append("Update [ApplicationDetail] set ");
                        insertSql.AppendFormat(" [CodeID]='{0}',", dr["CodeID"]);
                        insertSql.AppendFormat(" [TransNo]='{0}',", dr["TransNo"]);
                        insertSql.AppendFormat(" [ItemID]='{0}',", dr["ItemID"]);
                        insertSql.AppendFormat(" [Detail]='{0}',", dr["Detail"]);
                        insertSql.AppendFormat(" [Price]={0},", dr["Price"]);
                        insertSql.AppendFormat(" [MoneyUnit]={0},", dr["MoneyUnit"]);
                        insertSql.AppendFormat(" [Count]={0},", dr["Count"]);
                        insertSql.AppendFormat(" [IsDelete]={0},", dr["IsDelete"]);
                        insertSql.AppendFormat(" [SelforGift]={0},", dr["SelforGift"]);
                        insertSql.AppendFormat(" [ApprovalCount]={0},", dr["ApprovalCount"]);
                        insertSql.AppendFormat(" [ApprovalDiscount]={0},", dr["ApprovalDiscount"]);
                        insertSql.AppendFormat(" [FinalPrice]={0},", dr["FinalPrice"]);
                        insertSql.AppendFormat(" [Recipient]='{0}',", dr["Recipient"]);
                        insertSql.AppendFormat(" [Relationship]='{0}',", dr["Relationship"]);
                        insertSql.AppendFormat(" [Reason]='{0}',", dr["Reason"]);
                        insertSql.AppendFormat(" [IsSuccess]='{0}',", dr["IsSuccess"]);
                        insertSql.AppendFormat(" [PhoneNum]='{0}'", dr["PhoneNum"]);
                        insertSql.AppendFormat(" where [ID]={0}", dr["ID"]);

                        sq.InsertQuery(insertSql.ToString(), "确认唯一码", TransNo, 1, int.Parse(dr["ID"].ToString()));
                    }
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
        /// 删除订单详情表数据
        /// </summary>
        /// <param name="CtrlID"></param>
        /// <returns></returns>
        public int DeleteApplicaionDetail(string TransNo)
        {
            int rows = 0;
            try
            {
                SqlQueue sq = new SqlQueue();
                string sql = string.Format("Update ApplicationDetail Set IsDelete =1 Where TransNo='{0}'", TransNo);
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
    }
}
