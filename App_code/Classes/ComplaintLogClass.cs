using EBilling.DataAccess;
using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for ComplaintLogClass
/// </summary>
public class ComplaintLogClass
{
    public ComplaintLogClass()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataSet GetComplaintLogData(ComplaintLogEntity entity)
    {
        DataSet userDetails;
        SqlParameter[] sqlParams = new SqlParameter[2];

        sqlParams[0] = new SqlParameter();
        sqlParams[0].ParameterName = "@cl_complaint_id";
        sqlParams[0].DbType = DbType.Int64;
        sqlParams[0].Direction = System.Data.ParameterDirection.Input;
        sqlParams[0].Value = CommonModule.DBNullValueorlongIfNotNull(entity.cl_complaint_id);

        sqlParams[1] = new SqlParameter();
        sqlParams[1].ParameterName = "@cl_log_id";
        sqlParams[1].DbType = DbType.Int64;
        sqlParams[1].Direction = System.Data.ParameterDirection.Input;
        sqlParams[1].Value = CommonModule.DBNullValueorlongIfNotNull(entity.cl_log_id);

        userDetails = DBFactory.GetHelper().ExecuteDataSet("[complaint_log_get]", System.Data.CommandType.StoredProcedure, sqlParams);
        return userDetails;
    }
    public int SetComplaintLogData(ComplaintLogEntity entity, SqlConnection sqlConn, SqlTransaction sqlTrans)
    {
        int numrowsaffceted = 0;
        try
        {
            SqlParameter[] sqlParams = new SqlParameter[6];

            sqlParams[0] = new SqlParameter();
            sqlParams[0].ParameterName = "@cl_complaint_id";
            sqlParams[0].DbType = DbType.Int64;
            sqlParams[0].Direction = System.Data.ParameterDirection.Input;
            sqlParams[0].Value = CommonModule.DBNullValueorlongIfNotNull(entity.cl_complaint_id);

            sqlParams[1] = new SqlParameter();
            sqlParams[1].ParameterName = "@cl_log_desc";
            sqlParams[1].DbType = DbType.String;
            sqlParams[1].Direction = System.Data.ParameterDirection.Input;
            sqlParams[1].Value = CommonModule.DBNullValueorStringIfNotNull(entity.cl_log_desc);

            sqlParams[2] = new SqlParameter();
            sqlParams[2].ParameterName = "@cl_complaint_status";
            sqlParams[2].DbType = DbType.String;
            sqlParams[2].Direction = System.Data.ParameterDirection.Input;
            sqlParams[2].Value = CommonModule.DBNullValueorStringIfNotNull(entity.cl_complaint_status);

            sqlParams[3] = new SqlParameter();
            sqlParams[3].ParameterName = "@cl_remarks";
            sqlParams[3].DbType = DbType.String;
            sqlParams[3].Direction = System.Data.ParameterDirection.Input;
            sqlParams[3].Value = CommonModule.DBNullValueorStringIfNotNull(entity.cl_remarks);

            sqlParams[4] = new SqlParameter();
            sqlParams[4].ParameterName = "@created_user";
            sqlParams[4].DbType = DbType.String;
            sqlParams[4].Direction = System.Data.ParameterDirection.Input;
            sqlParams[4].Value = CommonModule.DBNullValueorStringIfNotNull(entity.created_user);

            sqlParams[5] = new SqlParameter();
            sqlParams[5].ParameterName = "@active";
            sqlParams[5].DbType = DbType.String;
            sqlParams[5].Direction = System.Data.ParameterDirection.Input;
            sqlParams[5].Value = CommonModule.DBNullValueorStringIfNotNull(entity.active);

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = sqlConn;
            sqlCmd.Transaction = sqlTrans;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "complaint_log_insert";
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