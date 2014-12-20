using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Text;
using System.Data.SQLite;
using System.Globalization;

namespace Data
{
    public class DataHelper
    {
        public static DbProviderFactory Database
        {
            get
            {

                return SQLiteFactory.Instance;
            }
        }

        public static DbCommand GetCommand(string query)
        {

            return new SQLiteCommand(query);
        }

        //public static void SetParameter(DbCommand cmd, string parameterName, DbType type, object value)
        //{
        //    cmd.Parameters.Add(new NpgsqlParameter(parameterName, value));
        //}

        public static DbConnection GetConnection()
        {
            DbConnection cn = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["VetStationConnection"].ConnectionString);
            return cn;
        }
        public static DbConnection GetConnection(string connectionString)
        {
            DbConnection cn = new SQLiteConnection(connectionString);
            return cn;
        }
        public static DbCommand GetStoredProcCommand(string spName)
        {
            DbCommand cmd = Database.CreateCommand();
            cmd.CommandText = spName;
            cmd.CommandType = CommandType.StoredProcedure;

            return cmd;
        }
        public static DbCommand GetSqlStringCommand(string sql)
        {
            DbCommand cmd = Database.CreateCommand();
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;

            return cmd;
        }
        public static DbParameter AddInParameter(DbCommand cmd, string paramName, DbType paramType, object value)
        {
            DbParameter p = Database.CreateParameter();
            p.Direction = ParameterDirection.Input;
            p.ParameterName = paramName;
            p.DbType = paramType;
            p.Value = value;

            cmd.Parameters.Add(p);

            return p;
        }
       
        public static void FillTable(DataTable tbl, DbCommand cmd)
        {
            DbConnection cn = GetConnection();
            try
            {
                
                cn.Open();
                cmd.Connection = cn;
                DbDataAdapter adapter = Database.CreateDataAdapter();
                adapter.SelectCommand = cmd;
                //adapter.SelectCommand.CommandTimeout = 60;
                adapter.Fill(tbl);
            }
            finally
            {
                cn.Close();
            }
        }

        public static void FillTable(DataTable tbl, DbCommand cmd,DbConnection cn)
        {
            try
            {
                cmd.Connection = cn;
                DbDataAdapter adapter = Database.CreateDataAdapter();
                adapter.SelectCommand = cmd;
                //adapter.SelectCommand.CommandTimeout = 60;
                adapter.Fill(tbl);
            }
            catch(Exception ex)
            {
                
            }
        }

        public static void FillTable(DataTable tbl, DbCommand cmd, int maxRows)
        {
            DbConnection cn = GetConnection();
            try
            {
                cn.Open();

                cmd.Connection = cn;

                DbDataAdapter adapter = Database.CreateDataAdapter();

                adapter.SelectCommand = cmd;
                adapter.Fill(0, maxRows, tbl);
            }
            finally
            {
                cn.Close();
            }
        }
        public static void FillTable(DataSet ds, DbCommand cmd)
        {
            DbConnection cn = GetConnection();
            try
            {
                cn.Open();

                cmd.Connection = cn;

                DbDataAdapter adapter = Database.CreateDataAdapter();
                adapter.SelectCommand = cmd;

                adapter.Fill(ds);
            }
            finally
            {
                cn.Close();
            }
        }

        public static DataTable GetTable(DbCommand cmd)
        {
            DataTable tbl = new DataTable();
            DbConnection cn = GetConnection();
            try
            {
                cn.Open();
                cmd.Connection = cn;
                DbDataAdapter adapter = Database.CreateDataAdapter();
                adapter.SelectCommand = cmd;
                adapter.Fill(tbl);
             
            }
            finally
            {
                cn.Close();
            }

            return tbl;
        }
        public static DataTable GetTable(DbCommand cmd, int maxRows)
        {
            DataTable tbl = new DataTable();
            DbConnection cn = GetConnection();
            try
            {
                cn.Open();

                cmd.Connection = cn;

                DbDataAdapter adapter = Database.CreateDataAdapter();

                adapter.SelectCommand = cmd;
                adapter.Fill(0, maxRows, tbl);
            }
            finally
            {
                cn.Close();
            }

            return tbl;
        }
        public static DataTable GetTable(DbCommand cmd, DbConnection cn, DbTransaction trans)
        {
            DataTable tbl = new DataTable();
            bool close = false;
            if (cn == null)
            {
                cn = GetConnection();

                cn.Open();
                close = true;
            }

            try
            {
                cmd.Connection = cn;
                if (trans != null)
                    cmd.Transaction = trans;

                DbDataAdapter adapter = Database.CreateDataAdapter();
                adapter.SelectCommand = cmd;

                adapter.Fill(tbl);
            }
            finally
            {
                if (close)
                    cn.Close();
            }
            return tbl;
        }

        public static object ExecuteScalar(DbCommand cmd)
        {
            object result = null;

            DbConnection cn = GetConnection();
            try
            {
                cn.Open();

                cmd.Connection = cn;

                result = cmd.ExecuteScalar();

                if (result == DBNull.Value)
                    result = null;
            }
            finally
            {
                cn.Close();
            }

            return result;
        }

        public static int ExecuteNonQuery(DbCommand cmd)
        {
            int result = 0;
            DbConnection cn = GetConnection();
            try
            {
                cn.Open();

                cmd.Connection = cn;
                result = cmd.ExecuteNonQuery();
            }
            finally
            {
                cn.Close();
            }
            return result;
        }

        public static void SetParameterValue(DbCommand cmd, string paramName, object paramValue)
        {
            cmd.Parameters[paramName].Value = paramValue;
        }

        public static void SetParameterInt32Value(DbCommand cmd, string paramName, string paramValue)
        {
            if (!String.IsNullOrEmpty(paramValue))
                cmd.Parameters[paramName].Value = Convert.ToInt32(paramValue);
            else
                cmd.Parameters[paramName].Value = DBNull.Value;
        }

        public static void SetParameterDecimalValue(DbCommand cmd, string paramName, string paramValue)
        {
            if (!String.IsNullOrEmpty(paramValue))
            {
                decimal dec = decimal.Parse(paramValue, CultureInfo.InvariantCulture);

                cmd.Parameters[paramName].Value = dec;
            }
            else
                cmd.Parameters[paramName].Value = DBNull.Value;
        }

        public static void SetParameterBooleanValue(DbCommand cmd, string paramName, string paramValue)
        {
            if (!String.IsNullOrEmpty(paramValue))
            {
                bool val = false;
                if (paramValue == "1" || paramValue.ToUpper() == "TRUE" || paramValue.ToUpper() == "YES")
                    val = true;

                cmd.Parameters[paramName].Value = val;
            }
            else
                cmd.Parameters[paramName].Value = DBNull.Value;
        }

        public static void SetParameterDateTimeValue(DbCommand cmd, string paramName, string paramValue,
            string format, IFormatProvider formatProvider)
        {
            if (!String.IsNullOrEmpty(paramValue))
                cmd.Parameters[paramName].Value = DateTime.ParseExact(paramValue, format, formatProvider);
            else
                cmd.Parameters[paramName].Value = DBNull.Value;
        }

        public static void SetParameterStringValue(DbCommand cmd, string paramName, string paramValue)
        {
            if (!String.IsNullOrEmpty(paramValue))
                cmd.Parameters[paramName].Value = paramValue;
            else
                cmd.Parameters[paramName].Value = DBNull.Value;
        }

        public static DbDataReader ExecuteReader(DbCommand cmd)
        {
            throw new Exception("Method not implemented!");
        //    DbConnection cn = GetConnection();
        //    try
        //    {
        //        cn.Open();

        //        cmd.Connection = cn;

        //        return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        //    }
        //    catch (Exception)
        //    {
        //        cn.Close();
        //        throw;
        //    }
        }

        public static void FillTable(DataTable tbl, DbCommand cmd, DbConnection cn, DbTransaction trans)
        {
            bool close = false;
            if (cn == null)
            {
                cn = GetConnection();
                
                cn.Open();
                close = true;
            }

            try
            {
                cmd.Connection = cn;
                if (trans != null)
                    cmd.Transaction = trans;

                DbDataAdapter adapter = Database.CreateDataAdapter();
                adapter.SelectCommand = cmd;

                adapter.Fill(tbl);
            }
            finally
            {
                if (close)
                    cn.Close();
            }
        }

        public static int ExecuteNonQuery(DbCommand cmd, DbConnection cn, DbTransaction trans)
        {
            cmd.Connection = cn;
            if (trans != null)
                cmd.Transaction = trans;

            return cmd.ExecuteNonQuery();
        }

        public static object ExecuteScalar(DbCommand cmd, DbConnection cn, DbTransaction trans)
        {
            cmd.Connection = cn;
            if (trans != null)
                cmd.Transaction = trans;

            return cmd.ExecuteScalar();
        }

        public static int ExecuteSqlCommand(string sql, DbConnection cn, DbTransaction trans,
            params object[] parameters)
        {
            DbCommand cmd = GetSqlStringCommand(sql);

            if (parameters != null)
            {
                for (int i = 0; i < parameters.Length - 1; i += 2)
                {
                    DbParameter par = Database.CreateParameter();
                    par.Direction = ParameterDirection.Input;
                    par.ParameterName = "Param" + (i / 2).ToString();
                    par.Value = parameters[i];
                    par.DbType = (DbType)parameters[i + 1];

                    cmd.Parameters.Add(par);
                }
            }

            cmd.Connection = cn;
            cmd.Transaction = trans;

            return cmd.ExecuteNonQuery();
        }

        public static int ExecuteSqlCommand(string sql, params object[] parameters)
        {
            DbConnection cn = GetConnection();
            try
            {
                cn.Open();

                return ExecuteSqlCommand(sql, cn, null, parameters);
            }
            finally
            {
                cn.Close();
            }
        }

        public static DbCommand GetTextCommand(DbConnection cn, DbTransaction tx)
        {
            DbCommand cmd = Database.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            //cmd.CommandTimeout = 60;
            cmd.Connection = cn;
            cmd.Transaction = tx;

            return cmd;
        }
    }
}