using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using EBilling.DataAccess;

/// <summary>
/// Summary description for TransactionPassword
/// </summary>
public class TransactionPassword
{
    public TransactionPassword()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataSet CheckOldTransactionPassword(UserTransactionCredentialEntity entity)
    {
        System.Data.DataSet EmpDetails;
        SqlParameter[] sqlParams = new SqlParameter[2];

        sqlParams[0] = new SqlParameter();
        sqlParams[0].ParameterName = "@user_id";
        sqlParams[0].DbType = DbType.String;
        sqlParams[0].Direction = System.Data.ParameterDirection.Input;
        sqlParams[0].Value = entity.utc_user_id;

        sqlParams[1] = new SqlParameter();
        sqlParams[1].ParameterName = "@old_trans_password";
        sqlParams[1].DbType = DbType.String;
        sqlParams[1].Direction = System.Data.ParameterDirection.Input;
        sqlParams[1].Value = entity.utc_old_transaction_password;

        EmpDetails = DBFactory.GetHelper().ExecuteDataSet("[check_transaction_password]", System.Data.CommandType.StoredProcedure, sqlParams);
        return EmpDetails;
    }

    public int UpdateTransactionPassword(UserTransactionCredentialEntity entity, SqlConnection sqlConn, SqlTransaction sqlTrans)
    {
        int numRowsAffected = 0;
        SqlParameter[] sqlParams = {
                                       new SqlParameter("@utc_user_id",CommonModule.DBNullValueorStringIfNotNull(entity.utc_user_id)),
                                       new SqlParameter("@utc_transaction_password",CommonModule.DBNullValueorStringIfNotNull(entity.utc_transaction_password)),
                                       new SqlParameter("@created_user",CommonModule.DBNullValueorStringIfNotNull(entity.created_user)),
                                       new SqlParameter("@active",CommonModule.DBNullValueorStringIfNotNull(entity.active)),
                                       new SqlParameter("@old_trans_password",CommonModule.DBNullValueorStringIfNotNull(entity.utc_old_transaction_password))
                                   };
        SqlCommand sqlCmd = new SqlCommand();
        sqlCmd.Connection = sqlConn;
        sqlCmd.Transaction = sqlTrans;
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.CommandText = "dbo.user_transaction_credential_Insert_Update";
        sqlCmd.Parameters.AddRange(sqlParams);
        numRowsAffected = sqlCmd.ExecuteNonQuery();
        return numRowsAffected;
    }

    public DataSet ForgotTransactionPassword(UserTransactionCredentialEntity entity)
    {
        System.Data.DataSet EmpDetails;
        SqlParameter[] sqlParams = new SqlParameter[2];

        sqlParams[0] = new SqlParameter();
        sqlParams[0].ParameterName = "@user_id";
        sqlParams[0].DbType = DbType.String;
        sqlParams[0].Direction = System.Data.ParameterDirection.Input;
        sqlParams[0].Value = entity.utc_user_id;

        sqlParams[1] = new SqlParameter();
        sqlParams[1].ParameterName = "@account_password";
        sqlParams[1].DbType = DbType.String;
        sqlParams[1].Direction = System.Data.ParameterDirection.Input;
        sqlParams[1].Value = entity.account_password;

        EmpDetails = DBFactory.GetHelper().ExecuteDataSet("[forgot_user_transaction_password]", System.Data.CommandType.StoredProcedure, sqlParams);
        return EmpDetails;
    }

    public DataSet CheckOTP(UserOTPDetailsEntity entity)
    {
        System.Data.DataSet EmpDetails;
        SqlParameter[] sqlParams = new SqlParameter[2];

        sqlParams[0] = new SqlParameter();
        sqlParams[0].ParameterName = "@user_id";
        sqlParams[0].DbType = DbType.String;
        sqlParams[0].Direction = System.Data.ParameterDirection.Input;
        sqlParams[0].Value = entity.uod_user_id;

        sqlParams[1] = new SqlParameter();
        sqlParams[1].ParameterName = "@otp";
        sqlParams[1].DbType = DbType.String;
        sqlParams[1].Direction = System.Data.ParameterDirection.Input;
        sqlParams[1].Value = entity.uod_otp;

        EmpDetails = DBFactory.GetHelper().ExecuteDataSet("[check_user_otp]", System.Data.CommandType.StoredProcedure, sqlParams);
        return EmpDetails;
    }

    public Int64 SetUserOTPDetails(UserOTPDetailsEntity entity, SqlConnection sqlConn, SqlTransaction sqlTrans)
    {
        Int64 returnUserID = 0;
        try
        {
            SqlParameter[] sqlParams = new SqlParameter[8];

            sqlParams[0] = new SqlParameter();
            sqlParams[0].ParameterName = "@uod_id";
            sqlParams[0].DbType = DbType.Int64;
            sqlParams[0].Direction = System.Data.ParameterDirection.Input;
            sqlParams[0].Value = CommonModule.DBNullValueorInt64IfNotNull(entity.uod_id);

            sqlParams[1] = new SqlParameter();
            sqlParams[1].ParameterName = "@uod_user_id";
            sqlParams[1].DbType = DbType.String;
            sqlParams[1].Direction = System.Data.ParameterDirection.Input;
            sqlParams[1].Value = CommonModule.DBNullValueorStringIfNotNull(entity.uod_user_id);

            sqlParams[2] = new SqlParameter();
            sqlParams[2].ParameterName = "@uod_mobile_no";
            sqlParams[2].DbType = DbType.String;
            sqlParams[2].Direction = System.Data.ParameterDirection.Input;
            sqlParams[2].Value = CommonModule.DBNullValueorStringIfNotNull(entity.uod_mobile_no);

            sqlParams[3] = new SqlParameter();
            sqlParams[3].ParameterName = "@uod_otp";
            sqlParams[3].DbType = DbType.Int32;
            sqlParams[3].Direction = System.Data.ParameterDirection.Input;
            sqlParams[3].Value = CommonModule.DBNullValueorInt32IfNotNull(entity.uod_otp);

            sqlParams[4] = new SqlParameter();
            sqlParams[4].ParameterName = "@uod_status";
            sqlParams[4].DbType = DbType.String;
            sqlParams[4].Direction = System.Data.ParameterDirection.Input;
            sqlParams[4].Value = CommonModule.DBNullValueorStringIfNotNull(entity.uod_status);

            sqlParams[5] = new SqlParameter();
            sqlParams[5].ParameterName = "@created_user";
            sqlParams[5].DbType = DbType.String;
            sqlParams[5].Direction = System.Data.ParameterDirection.Input;
            sqlParams[5].Value = CommonModule.DBNullValueorStringIfNotNull(entity.created_user);

            sqlParams[6] = new SqlParameter();
            sqlParams[6].ParameterName = "@active";
            sqlParams[6].DbType = DbType.String;
            sqlParams[6].Direction = System.Data.ParameterDirection.Input;
            sqlParams[6].Value = CommonModule.DBNullValueorStringIfNotNull(entity.active);

            sqlParams[7] = new SqlParameter();
            sqlParams[7].ParameterName = "@return_id";
            sqlParams[7].DbType = DbType.Int64;
            sqlParams[7].Size = 100;
            sqlParams[7].Direction = System.Data.ParameterDirection.Output;

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = sqlConn;
            sqlCmd.Transaction = sqlTrans;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "user_otp_details_insert_update";
            sqlCmd.Parameters.AddRange(sqlParams);
            sqlCmd.ExecuteNonQuery();

            returnUserID = (long)sqlCmd.Parameters["@return_id"].Value;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return returnUserID;
    }
}