namespace XLuSharpLibrary.DbAccess
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.OleDb;
    using System.Data.SqlClient;
    using System.Runtime.InteropServices;

    public class SQLHelper
    {
        private IDbCommand _DbCommand;
        private IDbDataAdapter _DbDataAdapter;
        private IDbTransaction _DbTransaction;

        public SQLHelper()
        {
            if ((DbConfig.DbConnection == "") || (DbConfig.DbConnection == null))
            {
                throw new Exception("链接字符串不能为空！");
            }
            switch (DbConfig.DbType)
            {
                case DBType.SQLServer:
                    this._DbCommand = new SqlCommand();
                    this._DbCommand.Connection = new SqlConnection(DbConfig.DbConnection);
                    this._DbDataAdapter = new SqlDataAdapter();
                    break;

                case DBType.Access:
                    this._DbCommand = new OleDbCommand();
                    this._DbCommand.Connection = new OleDbConnection(DbConfig.DbConnection);
                    this._DbDataAdapter = new OleDbDataAdapter();
                    break;
            }
        }

        public SQLHelper(string strConn, DBType dbtype)
        {
            switch (dbtype)
            {
                case DBType.SQLServer:
                    this._DbCommand = new SqlCommand();
                    this._DbCommand.Connection = new SqlConnection(strConn);
                    this._DbDataAdapter = new SqlDataAdapter();
                    break;

                case DBType.Access:
                    this._DbCommand = new OleDbCommand();
                    this._DbCommand.Connection = new OleDbConnection(strConn);
                    this._DbDataAdapter = new OleDbDataAdapter();
                    break;
            }
        }

        private void CloseConnection()
        {
            if (this._DbCommand.Connection.State == ConnectionState.Open)
            {
                this._DbCommand.Connection.Close();
            }
            if (this._DbCommand != null)
            {
                this._DbCommand.Dispose();
            }
        }

        public int ExecuteProc(string procName)
        {
            int num;
            try
            {
                this._DbCommand.CommandText = procName;
                this._DbCommand.CommandType = CommandType.StoredProcedure;
                this.OpenConnection();
                num = this._DbCommand.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                this.CloseConnection();
                throw new Exception(exception.Message);
            }
            finally
            {
                this.CloseConnection();
            }
            return num;
        }

        public void ExecuteProc(string procName, out DataTable dt)
        {
            try
            {
                this._DbCommand.CommandText = procName;
                this._DbCommand.CommandType = CommandType.StoredProcedure;
                this._DbDataAdapter.SelectCommand = this._DbCommand;
                DataSet dataSet = new DataSet();
                this._DbDataAdapter.Fill(dataSet);
                dt = dataSet.Tables[0];
            }
            catch (Exception exception)
            {
                this.CloseConnection();
                throw new Exception(exception.Message);
            }
        }

        public int ExecuteProc(string procName, IDataParameter[] cmdParameters)
        {
            int num;
            try
            {
                this._DbCommand.CommandText = procName;
                this._DbCommand.CommandType = CommandType.StoredProcedure;
                foreach (IDataParameter parameter in cmdParameters)
                {
                    this._DbCommand.Parameters.Add(parameter);
                }
                this.OpenConnection();
                num = this._DbCommand.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                this.CloseConnection();
                throw new Exception(exception.Message);
            }
            finally
            {
                this.CloseConnection();
            }
            return num;
        }

        public void ExecuteProc(string procName, IDataParameter[] cmdParameters, out DataTable dt)
        {
            try
            {
                this._DbCommand.CommandText = procName;
                this._DbCommand.CommandType = CommandType.StoredProcedure;
                foreach (IDataParameter parameter in cmdParameters)
                {
                    this._DbCommand.Parameters.Add(parameter);
                }
                this._DbDataAdapter.SelectCommand = this._DbCommand;
                DataSet dataSet = new DataSet();
                this._DbDataAdapter.Fill(dataSet);
                dt = dataSet.Tables[0];
            }
            catch (Exception exception)
            {
                this.CloseConnection();
                throw new Exception(exception.Message);
            }
        }

        public int ExecuteSql(string cmdText)
        {
            int num;
            try
            {
                this._DbCommand.CommandText = cmdText;
                this.OpenConnection();
                num = this._DbCommand.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                this.CloseConnection();
                throw new Exception(exception.Message);
            }
            finally
            {
                this.CloseConnection();
            }
            return num;
        }

        public int ExecuteSql(string cmdText, IDataParameter[] cmdParameters)
        {
            int num;
            try
            {
                this._DbCommand.CommandText = cmdText;
                foreach (IDataParameter parameter in cmdParameters)
                {
                    this._DbCommand.Parameters.Add(parameter);
                }
                this.OpenConnection();
                num = this._DbCommand.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                this.CloseConnection();
                throw new Exception(exception.Message);
            }
            finally
            {
                this.CloseConnection();
            }
            return num;
        }

        public void ExecuteSql(string cmdText, out DataTable dt)
        {
            try
            {
                this._DbCommand.CommandText = cmdText;
                this._DbDataAdapter.SelectCommand = this._DbCommand;
                DataSet dataSet = new DataSet();
                this._DbDataAdapter.Fill(dataSet);
                dt = dataSet.Tables[0];
            }
            catch (Exception exception)
            {
                this.CloseConnection();
                throw new Exception(exception.Message);
            }
        }

        public void ExecuteSql(string cmdText, IDataParameter[] cmdParameters, out DataTable dt)
        {
            try
            {
                this._DbCommand.CommandText = cmdText;
                foreach (IDataParameter parameter in cmdParameters)
                {
                    this._DbCommand.Parameters.Add(parameter);
                }
                this._DbDataAdapter.SelectCommand = this._DbCommand;
                DataSet dataSet = new DataSet();
                this._DbDataAdapter.Fill(dataSet);
                dt = dataSet.Tables[0];
            }
            catch (Exception exception)
            {
                this.CloseConnection();
                throw new Exception(exception.Message);
            }
        }

        public bool ExecuteTransaction(string[] cmdTexts)
        {
            try
            {
                this.OpenConnection();
                this._DbTransaction = this._DbCommand.Connection.BeginTransaction();
                this._DbCommand.Transaction = this._DbTransaction;
                foreach (string str in cmdTexts)
                {
                    this._DbCommand.CommandText = str;
                    this._DbCommand.ExecuteNonQuery();
                }
                this._DbTransaction.Commit();
            }
            catch
            {
                this._DbTransaction.Rollback();
                this.CloseConnection();
                return false;
            }
            return true;
        }

        public bool ExecuteTransaction(string[] cmdTexts, List<IDataParameter[]> lstParameter, int count)
        {
            try
            {
                this.OpenConnection();
                this._DbTransaction = this._DbCommand.Connection.BeginTransaction();
                this._DbCommand.Transaction = this._DbTransaction;
                for (int i = 0; i < count; i++)
                {
                    this._DbCommand.CommandText = cmdTexts[i];
                    foreach (IDataParameter parameter in lstParameter[i])
                    {
                        this._DbCommand.Parameters.Add(parameter);
                    }
                    this._DbCommand.ExecuteNonQuery();
                }
                this._DbTransaction.Commit();
            }
            catch
            {
                this._DbTransaction.Rollback();
                this.CloseConnection();
                return false;
            }
            return true;
        }

        private void OpenConnection()
        {
            try
            {
                if (this._DbCommand.Connection.State == ConnectionState.Closed)
                {
                    this._DbCommand.Connection.Open();
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}

