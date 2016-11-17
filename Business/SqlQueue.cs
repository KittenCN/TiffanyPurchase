using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Configuration;

namespace BHair.Business
{
    public class SqlQueue
    {

        public OleDbConnection Conn;
        //public string ConnString=@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\转货数据库.accdb";//连接字符串   
        public string ConnString = ConfigurationSettings.AppSettings["SqlConnectionStrings"];//连接字符串  
        //public string AccessPath ;
        /**//// <summary>    
        /// 构造函数    
        /// </summary>    
        /// <param name="Dbpath">ACCESS数据库路径</param>    
        public SqlQueue()
        {
            Conn = new OleDbConnection(ConnString);
            Conn.Open();
        }

        /**//// <summary>    
            /// 打开数据源链接    
            /// </summary>    
            /// <returns></returns>    
        public OleDbConnection DbConn()
        {
            Conn.Open();
            return Conn;
        }

        /**//// <summary>    
            /// 请在数据传递完毕后调用该函数，关闭数据链接。    
            /// </summary>    
        public void Close()
        {
            Conn.Close();
        }




        /**//// <summary>    
            /// 根据SQL命令返回数据DataTable数据表,    
            /// 可直接作为dataGridView的数据源    
            /// </summary>    
            /// <param name="SQL"></param>    
            /// <returns></returns>    
        public DataTable SelectToDataTable(string SQL)
        {
            DataTable Dt = new DataTable();
            try
            {
                OleDbDataAdapter adapter = new OleDbDataAdapter();
                OleDbCommand command = new OleDbCommand(SQL, Conn);
                adapter.SelectCommand = command;
                adapter.Fill(Dt);
                return Dt;
            }
            catch (Exception ex)
            {
                Close();
                return Dt;
            }
        }

        /**//// <summary>    
            /// 根据SQL命令返回数据DataSet数据集，其中的表可直接作为dataGridView的数据源。    
            /// </summary>    
            /// <param name="SQL"></param>    
            /// <param name="subtableName">在返回的数据集中所添加的表的名称</param>    
            /// <returns></returns>    
        public DataSet SelectToDataSet(string SQL, string subtableName)
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            OleDbCommand command = new OleDbCommand(SQL, Conn);
            adapter.SelectCommand = command;
            DataSet Ds = new DataSet();
            Ds.Tables.Add(subtableName);
            adapter.Fill(Ds, subtableName);
            return Ds;
        }

        /**//// <summary>    
            /// 在指定的数据集中添加带有指定名称的表，由于存在覆盖已有名称表的危险，返回操作之前的数据集。    
            /// </summary>    
            /// <param name="SQL"></param>    
            /// <param name="subtableName">添加的表名</param>    
            /// <param name="DataSetName">被添加的数据集名</param>    
            /// <returns></returns>    
        public DataSet SelectToDataSet(string SQL, string subtableName, DataSet DataSetName)
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            OleDbCommand command = new OleDbCommand(SQL, Conn);
            adapter.SelectCommand = command;
            DataTable Dt = new DataTable();
            DataSet Ds = new DataSet();
            Ds = DataSetName;
            adapter.Fill(DataSetName, subtableName);
            return Ds;
        }

        /**//// <summary>    
            /// 根据SQL命令返回OleDbDataAdapter，    
            /// 使用前请在主程序中添加命名空间System.Data.OleDb    
            /// </summary>    
            /// <param name="SQL"></param>    
            /// <returns></returns>    
        public OleDbDataAdapter SelectToOleDbDataAdapter(string SQL)
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            OleDbCommand command = new OleDbCommand(SQL, Conn);
            adapter.SelectCommand = command;
            return adapter;
        }

        /**//// <summary>    
            /// 执行SQL命令，不需要返回数据的修改，删除可以使用本函数    
            /// </summary>    
            /// <param name="SQL"></param>    
            /// <returns></returns>    
        public bool ExecuteSQLNonquery(string SQL)
        {
            OleDbCommand cmd = new OleDbCommand(SQL, Conn);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                Close();
                return false;
            }
        }

        public bool InsertQuery(string sql, string operation, string transNo, int buy, int detailID)
        {
            string sqlString = string.Format("Insert into [AccessQueue] ([SqlStr],[operation],[TransNo],[Buy],[DetailID]) values (\"{0}\",\"{1}\",\"{2}\",{3},{4})", sql, operation, transNo, buy, detailID);
            try
            {
                return ExecuteSQLNonquery(sqlString);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool InsertQuery(string sql, string operation, string transNo, double buy, int detailID)
        {
            string sqlString = string.Format("Insert into [AccessQueue] ([SqlStr],[operation],[TransNo],[Buy],[DetailID]) values (\"{0}\",\"{1}\",\"{2}\",{3},{4})", sql, operation, transNo, buy, detailID);
            try
            {
                return ExecuteSQLNonquery(sqlString);
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        #region 执行队列

        public void ExecuteSqlQuery(DataRow dr)
        {
            //string sqlString = string.Format("select * from AccessQueue order by [ID] asc");
            //DataTable SqlQuery = SelectToDataTable(sqlString);
            try
            {
                AccessHelper ah = new AccessHelper();
                //foreach (DataRow dr in SqlQuery.Rows)
                //{
                if (dr["operation"].ToString() == "确认唯一码")
                {
                    try
                    {
                        string str = string.Format("select * from ApplicationInfo where IsDelete = 0 and AppState>5 and [TransNo]='{0}'  ", dr["TransNo"].ToString());
                        DataTable Result = ah.SelectToDataTable(str);
                        if (Result.Rows.Count > 0)
                        {
                            if (dr["Buy"].ToString() == "1")//重复购买
                            {
                                bool successed = false;
                                string selectSql = string.Format("select * from ApplicationDetail where  [ID] = {0}", dr["DetailID"]);
                                DataTable dt = ah.SelectToDataTable(selectSql);
                                if (dt.Rows.Count > 0)
                                {
                                    dt.Rows[0]["ID"] = DBNull.Value;
                                    dt.Rows[0]["IsRepetition"] = 1;
                                    StringBuilder insertSql = new StringBuilder();
                                    insertSql.Append("Insert into [ApplicationDetail]");
                                    insertSql.Append(" ([CodeID],[TransNo],[ItemID],[Detail],[Price],[MoneyUnit],[Count],[IsDelete],[SelforGift],[ApprovalCount],[ApprovalDiscount],[FinalPrice],[Recipient],[Relationship],[Reason],[IsSuccess],[IsRepetition]) ");
                                    insertSql.Append("values");
                                    insertSql.AppendFormat(" ('{0}','{1}','{2}','{3}',{4},{5},{6},{7},{8},{9},{10},{11},'{12}','{13}','{14}',{15},{16})", dt.Rows[0]["CodeID"], dt.Rows[0]["TransNo"], dt.Rows[0]["ItemID"], dt.Rows[0]["Detail"], dt.Rows[0]["Price"], dt.Rows[0]["MoneyUnit"], dt.Rows[0]["Count"], dt.Rows[0]["IsDelete"], dt.Rows[0]["SelforGift"], dt.Rows[0]["ApprovalCount"], dt.Rows[0]["ApprovalDiscount"], dt.Rows[0]["FinalPrice"], dt.Rows[0]["Recipient"], dt.Rows[0]["Relationship"], dt.Rows[0]["Reason"], dt.Rows[0]["IsSuccess"], dt.Rows[0]["IsRepetition"]);
                                    successed = ah.ExecuteSQLNonquery(insertSql.ToString());
                                    if (successed)
                                    {
                                        string delSql = string.Format("delete from AccessQueue where [ID]={0}", dr["ID"]);//执行成功后删除队列
                                        ExecuteSQLNonquery(delSql);
                                    }
                                }
                                string excString = string.Format("Update ApplicationInfo Set FinalException=1 where IsDelete = 0 and TransNo='{0}'", dr["TransNo"].ToString());
                                ah.ExecuteSQLNonquery(excString);
                            }
                            else
                            {
                                bool successed = false;
                                string exeSql = dr["SqlStr"].ToString();
                                successed = ah.ExecuteSQLNonquery(exeSql);//执行sql
                                if (successed)
                                {
                                    string delSql = string.Format("delete from AccessQueue where [ID]={0}", dr["ID"]);//执行成功后删除队列
                                    ExecuteSQLNonquery(delSql);
                                }
                            }
                        }
                        else
                        {
                            bool successed = false;
                            string exeSql = dr["SqlStr"].ToString();
                            successed = ah.ExecuteSQLNonquery(exeSql);//执行sql
                            if (successed)
                            {
                                string delSql = string.Format("delete from AccessQueue where [ID]={0}", dr["ID"]);//执行成功后删除队列
                                ExecuteSQLNonquery(delSql);
                            }
                        }
                    }
                    catch
                    {

                    }
                }
                else
                {
                    bool successed = false;
                    string exeSql = dr["SqlStr"].ToString();
                    successed = ah.ExecuteSQLNonquery(exeSql);//执行sql
                    if (successed)
                    {
                        string delSql = string.Format("delete from AccessQueue where [ID]={0}", dr["ID"]);//执行成功后删除队列
                        ExecuteSQLNonquery(delSql);
                    }
                }
                //}
                ah.Close();
            }
            catch (Exception ex)
            {

            }
        }

        private void InsertDBtoCache(DataRow dr)
        {
            bool boolRunResult = false;
            try
            {
                //string sqlString = string.Format("select * from AccessQueue order by [ID] asc");
                //DataTable SqlQuery = SelectToDataTable(sqlString);
                CacheHelper ch = new Business.CacheHelper();
                //foreach (DataRow dr in SqlQuery.Rows)
                //{
                //string strSQL = "insert into AccessQueue(SqlStr,operation,TransNo,Buy,DetailID) ";
                //strSQL = strSQL + " values('" + dr["SqlStr"].ToString() + "','" + dr["operation"].ToString() + "','" + dr["TransNo"].ToString() + "'," + dr["Buy"].ToString() + "," + dr["DetailID"].ToString() + ") ";
                string strSQL = string.Format("Insert into [AccessQueue] ([SqlStr],[operation],[TransNo],[Buy],[DetailID]) values (\"{0}\",\"{1}\",\"{2}\",{3},{4})", dr["SqlStr"].ToString(), dr["operation"].ToString(), dr["TransNo"].ToString(), dr["Buy"].ToString(), dr["DetailID"].ToString());
                boolRunResult = ch.ExecuteSQLNonquery(strSQL);
                if (boolRunResult)
                {
                    string delSql = string.Format("delete from AccessQueue where [ID]={0}", dr["ID"]);//执行成功后删除队列
                    ExecuteSQLNonquery(delSql);
                }
                //}
            }
            catch (Exception ex)
            {

            }
        }



        //立即执行
        public void QuickExecuteSqlQuery()
        {
            string sqlString = string.Format("select * from AccessQueue order by [ID] asc");
            DataTable SqlQuery = SelectToDataTable(sqlString);
            foreach (DataRow dr in SqlQuery.Rows)
            {
                if(dr["operation"].ToString().Count()>5 && dr["operation"].ToString().Substring(0,5) == "Cache" && dr["DetailID"].ToString() != "2")
                {
                    InsertDBtoCache(dr);
                }
                else
                {
                    ExecuteSqlQuery(dr);
                }
            }
            //ExecuteSqlQuery();
            //InsertDBtoCache();
        }

        #endregion



    }
}

