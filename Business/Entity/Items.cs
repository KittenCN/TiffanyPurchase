using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using XLuSharpLibrary.DbAccess;
using System.Data.OleDb; 

namespace BHair.Business.BaseData
{
    /// <summary>商品。</summary>
    public class Items
    {
        #region 构造函数...

        /// <summary>商品。</summary>
        public Items()
        { 
        }


        #endregion

        #region 属性...

        public DataTable ItemsDT = new DataTable();

        #endregion

        #region 自定义函数...

        /// <summary>
        /// 查询所有商品Item表
        /// </summary>
        /// <returns></returns>
        public DataTable SelectAllItem()
        {
            AccessHelper ah = new AccessHelper();
            string sqlString = string.Format("select * from Items where IsDelete=0 ");
            DataTable Result = ah.SelectToDataTable(sqlString);
            ah.Close();
            return Result;
        }
        public DataTable SelectAllItem(string sql)
        {
            AccessHelper ah = new AccessHelper();
            string sqlString = string.Format("select * from Items where IsDelete=0 {0}", sql);
            DataTable Result = ah.SelectToDataTable(sqlString);
            ah.Close();
            return Result;
        }

        /// <summary>
        /// 通过货号查询Item表
        /// </summary>
        /// <param name="ItemID"></param>
        /// <returns></returns>
        public DataTable SelectItemByItemID(string ItemID)
        {
            AccessHelper ah = new AccessHelper();
            string sqlString = string.Format("select * from Items where ItemID='{0}' ", ItemID);
            DataTable Result = ah.SelectToDataTable(sqlString);
            ah.Close();
            return Result;
        }

        /// <summary>
        /// 添加商品表数据Items
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public int InsertItems(DataTable dt)
        {
            int rows = 0;

            try
            {
                SqlQueue sq = new SqlQueue();
                foreach(DataRow dr in dt.Rows)
                {
                    StringBuilder insertSql=new StringBuilder();
                    insertSql.Append("Insert into [Items]");
                    insertSql.Append(" ([ItemID],[Price],[Price2],[Price3],[Price4],[Price5],[Price6],[Price7],[Price8],[Price9],[Price10],[Detail],[IsDelete],[IsSpecial],[ItemName]) ");
                    insertSql.Append("values");
                    insertSql.AppendFormat(" ('{0}',{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},'{11}',{12},{13},'{14}')", dr["ItemID"], dr["Price"], dr["Price2"], dr["Price3"], dr["Price4"], dr["Price5"], dr["Price6"], dr["Price7"], dr["Price8"], dr["Price9"], dr["Price10"], dr["Detail"], dr["IsDelete"], dr["IsSpecial"], dr["ItemName"]);
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
        }

        /// <summary>
        /// 修改商品表数据Items
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public int UpdateItems(DataTable dt)
        {
            int rows = 0;
            try
            {
                SqlQueue sq = new SqlQueue();
                foreach (DataRow dr in dt.Rows)
                {
                    StringBuilder insertSql = new StringBuilder();
                    insertSql.Append("Update [Items] set ");
                    insertSql.AppendFormat(" [ItemID]='{0}',", dr["ItemID"]);
                    insertSql.AppendFormat(" [Price]={0},", dr["Price"]);
                    insertSql.AppendFormat(" [Price2]={0},", dr["Price2"]);
                    insertSql.AppendFormat(" [Price3]={0},", dr["Price3"]);
                    insertSql.AppendFormat(" [Price4]={0},", dr["Price4"]);
                    insertSql.AppendFormat(" [Price5]={0},", dr["Price5"]);
                    insertSql.AppendFormat(" [Price6]={0},", dr["Price6"]);
                    insertSql.AppendFormat(" [Price7]={0},", dr["Price7"]);
                    insertSql.AppendFormat(" [Price8]={0},", dr["Price8"]);
                    insertSql.AppendFormat(" [Price9]={0},", dr["Price9"]);
                    insertSql.AppendFormat(" [Price10]={0},", dr["Price10"]);
                    insertSql.AppendFormat(" [Detail]='{0}',", dr["Detail"]);
                    insertSql.AppendFormat(" [IsDelete]={0},", dr["IsDelete"]);
                    insertSql.AppendFormat(" [IsSpecial]={0},", dr["IsSpecial"]);
                    insertSql.AppendFormat(" [ItemName]='{0}'", dr["ItemName"]);
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

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="UID"></param>
        /// <returns></returns>
        public int DeleteItem(string ID)
        {
            int rows = 0;
            try
            {
                SqlQueue sq = new SqlQueue();
                string sql = string.Format("Update Items Set IsDelete =1 Where ID={0}", ID);
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
        /// 立即插入商品表
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public int QuickInsertItems(DataTable dt)
        {
            int rows = 0;
            AccessHelper ah = new AccessHelper();
            try
            {
                OleDbDataAdapter adapt = new OleDbDataAdapter("select * from Items", ah.Conn);
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

        /// <summary>
        /// 备份货物表
        /// </summary>
        /// <returns></returns>
        public bool BackupItem()
        {
            bool Result = true;
            AccessHelper ah = new AccessHelper();
            string sqlString = string.Format("Select * into   Items_bak{0}   FROM   Items", DateTime.Now.ToString("yyyyMMddHHmmss"));
            Result = ah.ExecuteSQLNonquery(sqlString);
            ah.Close();
            return Result;
        }

        /// <summary>
        /// 清空货物表
        /// </summary>
        /// <returns></returns>
        public bool ClearItem()
        {
            bool Result = true;
            AccessHelper ah = new AccessHelper();
            string sqlString = string.Format("Delete from  Items");
            Result = ah.ExecuteSQLNonquery(sqlString);
            ah.Close();
            return Result;
        }

        #endregion
    }
}
