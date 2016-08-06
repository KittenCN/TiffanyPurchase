using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using XLuSharpLibrary.DbAccess;
using System.Data.OleDb; 

namespace BHair.Business.BaseData
{
    /// <summary>店面。</summary>
    public class Store
    {
        #region 构造函数...

        /// <summary>店面。</summary>
        public Store()
        { }


        #endregion

        #region 属性...

        public DataTable StoreDT = new DataTable();

        #endregion

        #region 自定义函数...

        /// <summary>
        /// 添加店面信息表StoreInfo
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public int InsertStoreInfo(DataTable dt)
        {
            int rows = 0;

            try
            {
                SqlQueue sq = new SqlQueue();
                foreach (DataRow dr in dt.Rows)
                {
                    StringBuilder insertSql = new StringBuilder();
                    insertSql.Append("Insert into [StoreInfo]");
                    insertSql.Append(" ([StoreName],[Address],[Contact],[Tel],[IsDelete]) ");
                    insertSql.Append("values");
                    insertSql.AppendFormat(" ('{0}','{1}','{2}','{3}',{4})", dr["StoreName"], dr["Address"], dr["Contact"], dr["Tel"], dr["IsDelete"]);
                    sq.InsertQuery(insertSql.ToString(), "","",0,0);
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
        /// 修改店面信息表StoreInfo
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public int UpdateStoreInfo(DataTable dt)
        {
            int rows = 0;
            try
            {
                SqlQueue sq = new SqlQueue();
                foreach (DataRow dr in dt.Rows)
                {
                    StringBuilder insertSql = new StringBuilder();
                    insertSql.Append("Update [StoreInfo] set ");
                    insertSql.AppendFormat(" [StoreName]='{0}',", dr["StoreName"]);
                    insertSql.AppendFormat(" [Address]='{0}',", dr["Address"]);
                    insertSql.AppendFormat(" [Contact]='{0}',", dr["Contact"]);
                    insertSql.AppendFormat(" [Tel]='{0}',", dr["Tel"]);
                    insertSql.AppendFormat(" [IsDelete]={0}", dr["IsDelete"]);
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
        /// 根据店名查询店面信息StoreInfo
        /// </summary>
        /// <param name="CtrlID"></param>
        /// <returns></returns>
        public DataTable SelectStoreInfoByStoreName(string StoreName)
        {
            AccessHelper ah = new AccessHelper();
            string sqlString = string.Format("select * from StoreInfo where IsDelete = 0 and StoreName='{0}'", StoreName);
            DataTable Result = ah.SelectToDataTable(sqlString);
            ah.Close();
            return Result;
        }

        /// <summary>
        /// 查询所有店面信息StoreInfo
        /// </summary>
        /// <param name="CtrlID"></param>
        /// <returns></returns>
        public DataTable SelectAllStoreInfo()
        {
            AccessHelper ah = new AccessHelper();
            string sqlString = string.Format("select * from StoreInfo where IsDelete = 0 ");
            DataTable Result = ah.SelectToDataTable(sqlString);
            ah.Close();
            return Result;
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="UID"></param>
        /// <returns></returns>
        public int DeleteStore(string ID)
        {
            int rows = 0;
            try
            {
                SqlQueue sq = new SqlQueue();
                string sql = string.Format("Update StoreInfo Set IsDelete =1 Where ID={0}", ID);
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
