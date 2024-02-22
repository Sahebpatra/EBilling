using EBilling.DataAccess;
using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for ComplaintClass
/// </summary>
public class ComplaintClass
{
    public ComplaintClass()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataSet GetComplaintData(ComplaintEntity entity)
    {
        DataSet userDetails;
        SqlParameter[] sqlParams = new SqlParameter[6];

        sqlParams[0] = new SqlParameter();
        sqlParams[0].ParameterName = "@user_id";
        sqlParams[0].DbType = DbType.String;
        sqlParams[0].Direction = System.Data.ParameterDirection.Input;
        sqlParams[0].Value = CommonModule.DBNullValueorStringIfNotNull(entity.created_user);

        sqlParams[1] = new SqlParameter();
        sqlParams[1].ParameterName = "@cm_complaint_id";
        sqlParams[1].DbType = DbType.Int64;
        sqlParams[1].Direction = System.Data.ParameterDirection.Input;
        sqlParams[1].Value = CommonModule.DBNullValueorlongIfNotNull(entity.cm_complaint_id);

        sqlParams[2] = new SqlParameter();
        sqlParams[2].ParameterName = "@cm_complaint_type";
        sqlParams[2].DbType = DbType.String;
        sqlParams[2].Direction = System.Data.ParameterDirection.Input;
        sqlParams[2].Value = CommonModule.DBNullValueorStringIfNotNull(entity.cm_complaint_type);

        sqlParams[3] = new SqlParameter();
        sqlParams[3].ParameterName = "@cm_complaint_status";
        sqlParams[3].DbType = DbType.String;
        sqlParams[3].Direction = System.Data.ParameterDirection.Input;
        sqlParams[3].Value = CommonModule.DBNullValueorStringIfNotNull(entity.cm_complaint_status);

        sqlParams[4] = new SqlParameter();
        sqlParams[4].ParameterName = "@cm_complaint_desc";
        sqlParams[4].DbType = DbType.String;
        sqlParams[4].Direction = System.Data.ParameterDirection.Input;
        sqlParams[4].Value = CommonModule.DBNullValueorStringIfNotNull(entity.cm_complaint_desc);

        sqlParams[5] = new SqlParameter();
        sqlParams[5].ParameterName = "@actice";
        sqlParams[5].DbType = DbType.String;
        sqlParams[5].Direction = System.Data.ParameterDirection.Input;
        sqlParams[5].Value = CommonModule.DBNullValueorStringIfNotNull(entity.active);

        userDetails = DBFactory.GetHelper().ExecuteDataSet("[complaint_mstr_get]", System.Data.CommandType.StoredProcedure, sqlParams);
        return userDetails;
    }
    public int SetComplaintData(ComplaintEntity entity, SqlConnection sqlConn, SqlTransaction sqlTrans)
    {
        int numrowsaffceted = 0;
        try
        {
            SqlParameter[] sqlParams = new SqlParameter[10];

            sqlParams[0] = new SqlParameter();
            sqlParams[0].ParameterName = "@cm_complaint_id";
            sqlParams[0].DbType = DbType.Int64;
            sqlParams[0].Direction = System.Data.ParameterDirection.Input;
            sqlParams[0].Value = CommonModule.DBNullValueorlongIfNotNull(entity.cm_complaint_id);

            sqlParams[1] = new SqlParameter();
            sqlParams[1].ParameterName = "@cm_complaint_type";
            sqlParams[1].DbType = DbType.String;
            sqlParams[1].Direction = System.Data.ParameterDirection.Input;
            sqlParams[1].Value = CommonModule.DBNullValueorStringIfNotNull(entity.cm_complaint_type);

            sqlParams[2] = new SqlParameter();
            sqlParams[2].ParameterName = "@cm_complaint_date";
            sqlParams[2].DbType = DbType.DateTime;
            sqlParams[2].Direction = System.Data.ParameterDirection.Input;
            sqlParams[2].Value = CommonModule.DBNullValueorDatetTimeIfNotNull(entity.cm_complaint_date);

            sqlParams[3] = new SqlParameter();
            sqlParams[3].ParameterName = "@cm_complaint_desc";
            sqlParams[3].DbType = DbType.String;
            sqlParams[3].Direction = System.Data.ParameterDirection.Input;
            sqlParams[3].Value = CommonModule.DBNullValueorStringIfNotNull(entity.cm_complaint_desc);

            sqlParams[4] = new SqlParameter();
            sqlParams[4].ParameterName = "@cm_complaint_raised_by";
            sqlParams[4].DbType = DbType.String;
            sqlParams[4].Direction = System.Data.ParameterDirection.Input;
            sqlParams[4].Value = CommonModule.DBNullValueorStringIfNotNull(entity.cm_complaint_raised_by);

            sqlParams[5] = new SqlParameter();
            sqlParams[5].ParameterName = "@cm_complaint_status";
            sqlParams[5].DbType = DbType.String;
            sqlParams[5].Direction = System.Data.ParameterDirection.Input;
            sqlParams[5].Value = CommonModule.DBNullValueorStringIfNotNull(entity.cm_complaint_status);

            sqlParams[6] = new SqlParameter();
            sqlParams[6].ParameterName = "@cm_remarks";
            sqlParams[6].DbType = DbType.String;
            sqlParams[6].Direction = System.Data.ParameterDirection.Input;
            sqlParams[6].Value = CommonModule.DBNullValueorStringIfNotNull(entity.cm_remarks);

            sqlParams[7] = new SqlParameter();
            sqlParams[7].ParameterName = "@created_user";
            sqlParams[7].DbType = DbType.String;
            sqlParams[7].Direction = System.Data.ParameterDirection.Input;
            sqlParams[7].Value = CommonModule.DBNullValueorStringIfNotNull(entity.created_user);

            sqlParams[8] = new SqlParameter();
            sqlParams[8].ParameterName = "@active";
            sqlParams[8].DbType = DbType.String;
            sqlParams[8].Direction = System.Data.ParameterDirection.Input;
            sqlParams[8].Value = CommonModule.DBNullValueorStringIfNotNull(entity.active);

            sqlParams[9] = new SqlParameter();
            sqlParams[9].ParameterName = "@action";
            sqlParams[9].DbType = DbType.String;
            sqlParams[9].Direction = System.Data.ParameterDirection.Input;
            sqlParams[9].Value = CommonModule.DBNullValueorStringIfNotNull(entity.user_action);

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = sqlConn;
            sqlCmd.Transaction = sqlTrans;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "complaint_mstr_insert_update";
            sqlCmd.Parameters.AddRange(sqlParams);
            numrowsaffceted = sqlCmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return numrowsaffceted;
    }

    public DataSet GetComplaintType(string complaintType, String Status)
    {
        DataSet ComplaintTypeDetails = new DataSet();
        SqlParameter[] sqlParams = new SqlParameter[2];

        sqlParams[0] = new SqlParameter();
        sqlParams[0].ParameterName = "@complaint_type";
        sqlParams[0].DbType = DbType.String;
        sqlParams[0].Direction = System.Data.ParameterDirection.Input;
        sqlParams[0].Value = CommonModule.DBNullValueorStringIfNotNull(complaintType);

        sqlParams[1] = new SqlParameter();
        sqlParams[1].ParameterName = "@active";
        sqlParams[1].DbType = DbType.String;
        sqlParams[1].Direction = System.Data.ParameterDirection.Input;
        sqlParams[1].Value = CommonModule.DBNullValueorStringIfNotNull(Status);

        ComplaintTypeDetails = DBFactory.GetHelper().ExecuteDataSet("ComplaintType_Get", System.Data.CommandType.StoredProcedure, sqlParams);
        return ComplaintTypeDetails;

    }
    public int SetComplaintType(ComplaintTypeEntity entity, SqlConnection sqlConn, SqlTransaction sqlTrans)
    {
        int numrowsaffceted = 0;
        try
        {
            SqlParameter[] sqlParams = new SqlParameter[5];

            sqlParams[0] = new SqlParameter();
            sqlParams[0].ParameterName = "@ct_id";
            sqlParams[0].DbType = DbType.Int64;
            sqlParams[0].Direction = System.Data.ParameterDirection.Input;
            sqlParams[0].Value = CommonModule.DBNullValueorlongIfNotNull(entity.ct_id);

            sqlParams[1] = new SqlParameter();
            sqlParams[1].ParameterName = "@ct_complaint_type";
            sqlParams[1].DbType = DbType.String;
            sqlParams[1].Direction = System.Data.ParameterDirection.Input;
            sqlParams[1].Value = CommonModule.DBNullValueorStringIfNotNull(entity.ct_complaint_type);

            sqlParams[2] = new SqlParameter();
            sqlParams[2].ParameterName = "@created_user";
            sqlParams[2].DbType = DbType.String;
            sqlParams[2].Direction = System.Data.ParameterDirection.Input;
            sqlParams[2].Value = CommonModule.DBNullValueorStringIfNotNull(entity.created_user);

            sqlParams[3] = new SqlParameter();
            sqlParams[3].ParameterName = "@active";
            sqlParams[3].DbType = DbType.String;
            sqlParams[3].Direction = System.Data.ParameterDirection.Input;
            sqlParams[3].Value = CommonModule.DBNullValueorStringIfNotNull(entity.active);

            sqlParams[4] = new SqlParameter();
            sqlParams[4].ParameterName = "@action";
            sqlParams[4].DbType = DbType.String;
            sqlParams[4].Direction = System.Data.ParameterDirection.Input;
            sqlParams[4].Value = CommonModule.DBNullValueorStringIfNotNull(entity.action);

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = sqlConn;
            sqlCmd.Transaction = sqlTrans;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "complainttype_dtls_Insert_Update";
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