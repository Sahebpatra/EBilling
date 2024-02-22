using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using EBilling.DataAccess;

/// <summary>
/// Summary description for ChangePasswordClass
/// </summary>
public class ChangePasswordClass
{
    //public ChangePasswordClass()
    //{
    //    //
    //    // TODO: Add constructor logic here
    //    //
    //}

    public DataSet CheckOldPassword( string userid, string password)
    {
        System.Data.DataSet EmpDetails;
        SqlParameter[] sqlParams = new SqlParameter[2];

        sqlParams[0] = new SqlParameter();
        sqlParams[0].ParameterName = "@userid";
        sqlParams[0].DbType = DbType.String;
        sqlParams[0].Direction = System.Data.ParameterDirection.Input;
        sqlParams[0].Value = userid;

        sqlParams[1] = new SqlParameter();
        sqlParams[1].ParameterName = "@password";
        sqlParams[1].DbType = DbType.String;
        sqlParams[1].Direction = System.Data.ParameterDirection.Input;
        sqlParams[1].Value = password;

        EmpDetails = DBFactory.GetHelper().ExecuteDataSet("[check_password]", System.Data.CommandType.StoredProcedure, sqlParams);
        return EmpDetails;
    }
    public int Password_Change(string userid, string oldpassword, string newpassword, SqlConnection sqlConn,SqlTransaction sqlTrans)
    {
        int numRowsAffected = 0;
        SqlParameter[] sqlParams = {
                                       new SqlParameter("@userid",userid),
                                       new SqlParameter("@oldpassword",oldpassword),
                                       new SqlParameter("@newpassword",newpassword)
                                   };
        SqlCommand sqlCmd = new SqlCommand();
        sqlCmd.Connection = sqlConn;
        sqlCmd.Transaction = sqlTrans;
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.CommandText = "dbo.update_password";
        sqlCmd.Parameters.AddRange(sqlParams);
        numRowsAffected = sqlCmd.ExecuteNonQuery();
        return numRowsAffected;
    }
}