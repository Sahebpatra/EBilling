using EBilling.DataAccess;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StandardParameterClass
/// </summary>
public class StandardParameterClass
{
    public SqlDateTime FormatDate(string stringdate)
    {
        if ((stringdate.Equals(string.Empty)))
        {
            return SqlDateTime.MinValue;
        }
        else
        {
            string[] ddate = stringdate.Split('/');
            ArrayList arrlist = new ArrayList();
            int index = 0;

            while (index <= ddate.Length - 1)
            {
                arrlist.Add(ddate[index]);
                System.Math.Min(System.Threading.Interlocked.Increment(ref index), index - 1);
            }
            int dd = System.Convert.ToInt32(arrlist[0]);
            int mm = System.Convert.ToInt32(arrlist[1]);
            int yyyy = System.Convert.ToInt32(arrlist[2]);

            SqlDateTime dt = new SqlDateTime(yyyy, mm, dd);

            return dt;
        }
    }

    public SqlDateTime FormatDateUpdate(string stringdate)
    {
        if ((stringdate.Equals(string.Empty)))
        {
            return SqlDateTime.MinValue;
        }
        else
        {
            string[] ddate = stringdate.Split('/');
            ArrayList arrlist = new ArrayList();
            int index = 0;

            while (index <= ddate.Length - 1)
            {
                arrlist.Add(ddate[index]);
                System.Math.Min(System.Threading.Interlocked.Increment(ref index), index - 1);
            }
            int dd = System.Convert.ToInt32(arrlist[0]);
            int mm = System.Convert.ToInt32(arrlist[1]);
            int yyyy = System.Convert.ToInt32(arrlist[2]);

            SqlDateTime dt = new SqlDateTime(yyyy, mm, dd);

            return dt;
        }
    }
    public DataSet GetStandaredParameterList(string name)
    {
        DataSet formMenuDs;
        SqlParameter[] sqlParams = new SqlParameter[1];

        sqlParams[0] = new SqlParameter();
        sqlParams[0].ParameterName = "@parm_name";
        sqlParams[0].DbType = DbType.String;
        sqlParams[0].Direction = System.Data.ParameterDirection.Input;
        sqlParams[0].Value = (string.IsNullOrEmpty(name) ? (object)DBNull.Value : name); 

        formMenuDs = DBFactory.GetHelper().ExecuteDataSet("[dbo].[StandardParameter_Get]", System.Data.CommandType.StoredProcedure, sqlParams);
        return formMenuDs;
    }
    public int InsertStandardParam(string Name, string status, decimal decimalVal, string charVal, string date, string time, string Created_User, string Active_Status)
    {
        int result = 0;
        SqlConnection sqlConn = null;
        SqlTransaction sqlTrans = null;
        try
        {
            SqlParameter[] sqlParams = new SqlParameter[9];
            sqlConn = (SqlConnection)DBFactory.GetHelper().OpenConnection();
            sqlTrans = sqlConn.BeginTransaction();

            sqlParams[0] = new SqlParameter();
            sqlParams[0].ParameterName = "@parm_name";
            sqlParams[0].DbType = DbType.String;
            sqlParams[0].Direction = System.Data.ParameterDirection.Input;
            sqlParams[0].Value = Name;

            sqlParams[1] = new SqlParameter();
            sqlParams[1].ParameterName = "@param_status";
            sqlParams[1].DbType = DbType.String;
            sqlParams[1].Direction = System.Data.ParameterDirection.Input;
            sqlParams[1].Value = status;

            sqlParams[2] = new SqlParameter();
            sqlParams[2].ParameterName = "@param_decimal_value";
            sqlParams[2].DbType = DbType.Decimal;
            sqlParams[2].Direction = System.Data.ParameterDirection.Input;
            sqlParams[2].Value = decimalVal;

            sqlParams[3] = new SqlParameter();
            sqlParams[3].ParameterName = "@param_char_value";
            sqlParams[3].DbType = DbType.String;
            sqlParams[3].Direction = System.Data.ParameterDirection.Input;
            sqlParams[3].Value = charVal;

            sqlParams[4] = new SqlParameter();
            sqlParams[4].ParameterName = "@param_datetime_value";
            sqlParams[4].SqlDbType = SqlDbType.DateTime;
            sqlParams[4].Direction = System.Data.ParameterDirection.Input;
            sqlParams[4].Value = FormatDate(date);

            sqlParams[5] = new SqlParameter();
            sqlParams[5].ParameterName = "@param_time_value";
            sqlParams[5].DbType = DbType.String;
            sqlParams[5].Direction = System.Data.ParameterDirection.Input;
            sqlParams[5].Value = time;

            sqlParams[6] = new SqlParameter();
            sqlParams[6].ParameterName = "@created_user";
            sqlParams[6].DbType = DbType.String;
            sqlParams[6].Direction = System.Data.ParameterDirection.Input;
            sqlParams[6].Value = Created_User;

            sqlParams[7] = new SqlParameter();
            sqlParams[7].ParameterName = "@active";
            sqlParams[7].DbType = DbType.String;
            sqlParams[7].Direction = System.Data.ParameterDirection.Input;
            sqlParams[7].Value = Active_Status;

            sqlParams[8] = new SqlParameter();
            sqlParams[8].ParameterName = "@output";
            sqlParams[8].DbType = DbType.Int32;
            sqlParams[8].Direction = System.Data.ParameterDirection.Output;

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = sqlConn;
            sqlCmd.Transaction = sqlTrans;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "[dbo].[StandardParameter_Insert]";
            sqlCmd.Parameters.AddRange(sqlParams);
            result = sqlCmd.ExecuteNonQuery();
            result = Convert.ToInt32(sqlParams[8].Value);
            if (result > 0)
            {
                sqlTrans.Commit();
            }
            else
            {
                sqlTrans.Rollback();
            }
        }
        catch (Exception ex)
        {   
            sqlTrans.Rollback();
            throw ex;
        }
        return result;
    }

    public int UpdateStandardParam(string Name, string status, decimal decimalVal, string charVal, string date, string time, string Created_User, string Active_Status)
    {
        int result = 0;
        SqlConnection sqlConn = null;
        SqlTransaction sqlTrans = null;
        try
        {
            SqlParameter[] sqlParams = new SqlParameter[9];
            sqlConn = (SqlConnection)DBFactory.GetHelper().OpenConnection();
            sqlTrans = sqlConn.BeginTransaction();

            sqlParams[0] = new SqlParameter();
            sqlParams[0].ParameterName = "@parm_name";
            sqlParams[0].DbType = DbType.String;
            sqlParams[0].Direction = System.Data.ParameterDirection.Input;
            sqlParams[0].Value = Name;

            sqlParams[1] = new SqlParameter();
            sqlParams[1].ParameterName = "@param_status";
            sqlParams[1].DbType = DbType.String;
            sqlParams[1].Direction = System.Data.ParameterDirection.Input;
            sqlParams[1].Value = status;

            sqlParams[2] = new SqlParameter();
            sqlParams[2].ParameterName = "@param_decimal_value";
            sqlParams[2].DbType = DbType.Decimal;
            sqlParams[2].Direction = System.Data.ParameterDirection.Input;
            sqlParams[2].Value = decimalVal;

            sqlParams[3] = new SqlParameter();
            sqlParams[3].ParameterName = "@param_char_value";
            sqlParams[3].DbType = DbType.String;
            sqlParams[3].Direction = System.Data.ParameterDirection.Input;
            sqlParams[3].Value = charVal;

            sqlParams[4] = new SqlParameter();
            sqlParams[4].ParameterName = "@param_datetime_value";
            sqlParams[4].SqlDbType = SqlDbType.DateTime;
            sqlParams[4].Direction = System.Data.ParameterDirection.Input;
            sqlParams[4].Value = FormatDateUpdate(date);

            sqlParams[5] = new SqlParameter();
            sqlParams[5].ParameterName = "@param_time_value";
            sqlParams[5].DbType = DbType.String;
            sqlParams[5].Direction = System.Data.ParameterDirection.Input;
            sqlParams[5].Value = time;

            sqlParams[6] = new SqlParameter();
            sqlParams[6].ParameterName = "@created_user";
            sqlParams[6].DbType = DbType.String;
            sqlParams[6].Direction = System.Data.ParameterDirection.Input;
            sqlParams[6].Value = Created_User;

            sqlParams[7] = new SqlParameter();
            sqlParams[7].ParameterName = "@active";
            sqlParams[7].DbType = DbType.String;
            sqlParams[7].Direction = System.Data.ParameterDirection.Input;
            sqlParams[7].Value = Active_Status;

            sqlParams[8] = new SqlParameter();
            sqlParams[8].ParameterName = "@output";
            sqlParams[8].DbType = DbType.Int32;
            sqlParams[8].Direction = System.Data.ParameterDirection.Output;

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = sqlConn;
            sqlCmd.Transaction = sqlTrans;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "[dbo].[StandardParameter_Update]";
            sqlCmd.Parameters.AddRange(sqlParams);
            result = sqlCmd.ExecuteNonQuery();
            result = Convert.ToInt32(sqlParams[8].Value);
            if (result > 0)
            {
                sqlTrans.Commit();
            }
            else
            {
                sqlTrans.Rollback();
            }
        }
        catch (Exception ex)
        {
            sqlTrans.Rollback();
            throw ex;
        }
        return result;
    }
}