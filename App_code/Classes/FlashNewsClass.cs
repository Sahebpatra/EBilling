using EBilling.DataAccess;
using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for FlashNewsClass
/// </summary>
public class FlashNewsClass
{
    public FlashNewsClass()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataSet GetFlashNewsData(FlashNewsEntity entity)
    {
        DataSet userDetails;
        SqlParameter[] sqlParams = new SqlParameter[4];

        sqlParams[0] = new SqlParameter();
        sqlParams[0].ParameterName = "@user_id";
        sqlParams[0].DbType = DbType.String;
        sqlParams[0].Direction = System.Data.ParameterDirection.Input;
        sqlParams[0].Value = CommonModule.DBNullValueorStringIfNotNull(entity.created_user);

        sqlParams[1] = new SqlParameter();
        sqlParams[1].ParameterName = "@flash_srlno";
        sqlParams[1].DbType = DbType.Int32;
        sqlParams[1].Direction = System.Data.ParameterDirection.Input;
        sqlParams[1].Value = CommonModule.DBNullValueorInt32IfNotNull(entity.flash_srlno);

        sqlParams[2] = new SqlParameter();
        sqlParams[2].ParameterName = "@flash_msg";
        sqlParams[2].DbType = DbType.String;
        sqlParams[2].Direction = System.Data.ParameterDirection.Input;
        sqlParams[2].Value = CommonModule.DBNullValueorStringIfNotNull(entity.flash_msg);

        sqlParams[3] = new SqlParameter();
        sqlParams[3].ParameterName = "@active";
        sqlParams[3].DbType = DbType.String;
        sqlParams[3].Direction = System.Data.ParameterDirection.Input;
        sqlParams[3].Value = CommonModule.DBNullValueorStringIfNotNull(entity.active);


        userDetails = DBFactory.GetHelper().ExecuteDataSet("[flash_news_get]", System.Data.CommandType.StoredProcedure, sqlParams);
        return userDetails;
    }
    public int SetFlashNewsData(FlashNewsEntity entity, SqlConnection sqlConn, SqlTransaction sqlTrans)
    {
        int numrowsaffceted = 0;
        try
        {
            SqlParameter[] sqlParams = new SqlParameter[8];

            sqlParams[0] = new SqlParameter();
            sqlParams[0].ParameterName = "@flash_srlno";
            sqlParams[0].DbType = DbType.Int32;
            sqlParams[0].Direction = System.Data.ParameterDirection.Input;
            sqlParams[0].Value = CommonModule.DBNullValueorInt32IfNotNull(entity.flash_srlno);

            sqlParams[1] = new SqlParameter();
            sqlParams[1].ParameterName = "@flash_userid";
            sqlParams[1].DbType = DbType.String;
            sqlParams[1].Direction = System.Data.ParameterDirection.Input;
            sqlParams[1].Value = CommonModule.DBNullValueorStringIfNotNull(entity.flash_userid);

            sqlParams[2] = new SqlParameter();
            sqlParams[2].ParameterName = "@flash_msg";
            sqlParams[2].DbType = DbType.String;
            sqlParams[2].Direction = System.Data.ParameterDirection.Input;
            sqlParams[2].Value = CommonModule.DBNullValueorStringIfNotNull(entity.flash_msg);

            sqlParams[3] = new SqlParameter();
            sqlParams[3].ParameterName = "@flash_to";
            sqlParams[3].DbType = DbType.DateTime;
            sqlParams[3].Direction = System.Data.ParameterDirection.Input;
            sqlParams[3].Value = CommonModule.DBNullValueorDatetTimeIfNotNull(entity.flash_to);

            sqlParams[4] = new SqlParameter();
            sqlParams[4].ParameterName = "@flash_retain_till";
            sqlParams[4].DbType = DbType.DateTime;
            sqlParams[4].Direction = System.Data.ParameterDirection.Input;
            sqlParams[4].Value = CommonModule.DBNullValueorDatetTimeIfNotNull(entity.flash_retain_till);

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
            sqlParams[7].ParameterName = "@flash_title";
            sqlParams[7].DbType = DbType.String;
            sqlParams[7].Direction = System.Data.ParameterDirection.Input;
            sqlParams[7].Value = CommonModule.DBNullValueorStringIfNotNull(entity.flash_title);

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = sqlConn;
            sqlCmd.Transaction = sqlTrans;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "flash_news_Insert_Update";
            sqlCmd.Parameters.AddRange(sqlParams);
            numrowsaffceted = sqlCmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return numrowsaffceted;
    }
}