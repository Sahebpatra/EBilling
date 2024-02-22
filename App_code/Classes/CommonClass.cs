using EBilling.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CommonClass
/// </summary>
public class CommonClass
{
    public DataSet GetLovDetails(string LovType, String LovStatus)
    {
        DataSet LovDetails = new DataSet();
        SqlParameter[] sqlParams = new SqlParameter[2];

        sqlParams[0] = new SqlParameter();
        sqlParams[0].ParameterName = "@lov_type";
        sqlParams[0].DbType = DbType.String;
        sqlParams[0].Direction = System.Data.ParameterDirection.Input;
        sqlParams[0].Value = LovType;

        sqlParams[1] = new SqlParameter();
        sqlParams[1].ParameterName = "@lov_status";
        sqlParams[1].DbType = DbType.String;
        sqlParams[1].Direction = System.Data.ParameterDirection.Input;
        sqlParams[1].Value = LovStatus;

        LovDetails = DBFactory.GetHelper().ExecuteDataSet("Lov_Details_Get", System.Data.CommandType.StoredProcedure, sqlParams);
        return LovDetails;

    }

    public DataSet GetStateList()
    {
        try
        {
            return DBFactory.GetHelper().ExecuteDataSet("get_all_state", System.Data.CommandType.StoredProcedure);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataSet GetCityList(string stateCode)
    {
        try
        {
            SqlParameter[] sqlParams = new SqlParameter[1];

            sqlParams[0] = new SqlParameter();
            sqlParams[0].ParameterName = "@state_code";
            sqlParams[0].DbType = DbType.String;
            sqlParams[0].Direction = System.Data.ParameterDirection.Input;
            sqlParams[0].Value = stateCode;

            return DBFactory.GetHelper().ExecuteDataSet("city_detail_get", System.Data.CommandType.StoredProcedure, sqlParams);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public int UpdatePassword(string user_id, string old_password, string new_password, SqlConnection sqlConn, SqlTransaction sqlTrans)
    {
        int result = 0;

        SqlParameter[] sqlParams = new SqlParameter[4];

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

        sqlParams[3] = new SqlParameter();
        sqlParams[3].ParameterName = "@error_code";
        sqlParams[3].DbType = DbType.String;
        sqlParams[3].Size = 100;
        sqlParams[3].Direction = System.Data.ParameterDirection.Output;

        SqlCommand sqlCmd = new SqlCommand();
        sqlCmd.Connection = sqlConn;
        sqlCmd.Transaction = sqlTrans;
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.CommandText = "Update_ChangePassword";
        sqlCmd.Parameters.AddRange(sqlParams);
        result = sqlCmd.ExecuteNonQuery();
        return result;
    }
    public DataSet SearchUser(string searchKeyword, string userGroup)
    {
        try
        {
            SqlParameter[] sqlParams = new SqlParameter[2];

            sqlParams[0] = new SqlParameter();
            sqlParams[0].ParameterName = "@user_group";
            sqlParams[0].DbType = DbType.String;
            sqlParams[0].Direction = System.Data.ParameterDirection.Input;
            sqlParams[0].Value = userGroup;

            sqlParams[1] = new SqlParameter();
            sqlParams[1].ParameterName = "@search_keyword";
            sqlParams[1].DbType = DbType.String;
            sqlParams[1].Direction = System.Data.ParameterDirection.Input;
            sqlParams[1].Value = searchKeyword;

            return DBFactory.GetHelper().ExecuteDataSet("search_user_get", System.Data.CommandType.StoredProcedure, sqlParams);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}