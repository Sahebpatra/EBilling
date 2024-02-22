using EBilling.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Common
/// </summary>
public static class Common
{
    public static object DBNullValueorStringIfNotNull(string value)
    {
        object o;
        if (value == string.Empty || value == null)
        {
            o = DBNull.Value;
        }
        else
        {
            o = value;
        }
        return o;
    }

    public static object DBNullValueorlongIfNotNull(long value)
    {
        object o;
        if (value == 0)
        {
            o = DBNull.Value;
        }
        else
        {
            o = value;
        }
        return o;
    }

    public static int UpdatePassword(string user_id, string old_password, string new_password)
    {
        int result = 0;

        SqlParameter[] sqlParams = new SqlParameter[3];

        sqlParams[0] = new SqlParameter();
        sqlParams[0].ParameterName = "@user_id";
        sqlParams[0].DbType = DbType.String;
        sqlParams[0].Direction = System.Data.ParameterDirection.Input;
        sqlParams[0].Value = user_id;

        sqlParams[1] = new SqlParameter();
        sqlParams[1].ParameterName = "@old_password";
        sqlParams[1].DbType = DbType.String;
        sqlParams[1].Direction = System.Data.ParameterDirection.Input;
        sqlParams[1].Value = old_password;

        sqlParams[2] = new SqlParameter();
        sqlParams[2].ParameterName = "@new_password";
        sqlParams[2].DbType = DbType.String;
        sqlParams[2].Direction = System.Data.ParameterDirection.Input;
        sqlParams[2].Value = new_password;

        result = DBFactory.GetHelper().ExecuteNonQuery("Update_ChangePassword", System.Data.CommandType.StoredProcedure, sqlParams);
        return result;
    }

    public static DataSet GetServerDateTime()
    {
        return DBFactory.GetHelper().ExecuteDataSet("Server_Datetime_Get", System.Data.CommandType.StoredProcedure);
    }

    //public DataSet GetLovDetails(string LovType, String LovStatus)
    //{
    //    DataSet LovDetails = new DataSet();
    //    SqlParameter[] sqlParams = new SqlParameter[2];

    //    sqlParams[0] = new SqlParameter();
    //    sqlParams[0].ParameterName = "@lov_type";
    //    sqlParams[0].DbType = DbType.String;
    //    sqlParams[0].Direction = System.Data.ParameterDirection.Input;
    //    sqlParams[0].Value = LovType;

    //    sqlParams[1] = new SqlParameter();
    //    sqlParams[1].ParameterName = "@lov_status";
    //    sqlParams[1].DbType = DbType.String;
    //    sqlParams[1].Direction = System.Data.ParameterDirection.Input;
    //    sqlParams[1].Value = LovStatus;

    //    LovDetails = DBFactory.GetHelper().ExecuteDataSet("Lov_Details_Get", System.Data.CommandType.StoredProcedure, sqlParams);
    //    return LovDetails;

    //}

    public static object DBNullValueorDatetTimeIfNotNull(SqlDateTime value)
    {
        object o;
        if (value == SqlDateTime.MinValue)
        {
            o = DBNull.Value;
        }
        else
        {
            o = value;
        }
        return o;
    }
    public static object DBNullValueorInt32IfNotNull(Int32 value)
    {
        object o;
        if (value == 0)
        {
            o = DBNull.Value;
        }
        else
        {
            o = value;
        }
        return o;
    }
    public static object DBNullValueorDecimalIfNotNull(decimal value)
    {
        object o;
        if (value == 0)
        {
            o = DBNull.Value;
        }
        else
        {
            o = value;
        }
        return o;
    }
    public static object DBNullValueorInt64IfNotNull(Int64 value)
    {
        object o;
        if (value == 0)
        {
            o = DBNull.Value;
        }
        else
        {
            o = value;
        }
        return o;
    }
}