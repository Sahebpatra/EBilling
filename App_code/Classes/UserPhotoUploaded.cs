
using EBilling.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserProfileListClass
/// </summary>
public class UserPhotoUploaded
{
    public UserPhotoUploaded()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataSet GetUserGroupList()
    {
        DataSet ResultSet = new DataSet();
        ResultSet = DBFactory.GetHelper().ExecuteDataSet("[UserProfile_getUserGroupCode]", System.Data.CommandType.StoredProcedure);
        return ResultSet;
    }

    public DataSet UserProfileListGet(string UserGroup, string UserName, string UserDepot, string UserId)
    {
        DataSet ResultSet = new DataSet();
        SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@usp_group_code",SqlDbType.VarChar){Value=CommonModule.DBNullValueorStringIfNotNull(UserGroup)},
                new SqlParameter("@user_name",SqlDbType.VarChar){Value=CommonModule.DBNullValueorStringIfNotNull(UserName)},
                new SqlParameter("@usp_depot",SqlDbType.VarChar){Value=CommonModule.DBNullValueorStringIfNotNull(UserDepot)},
                new SqlParameter("@usp_user_ID",SqlDbType.VarChar){Value=CommonModule.DBNullValueorStringIfNotNull(UserId)}
            };
        ResultSet = DBFactory.GetHelper().ExecuteDataSet("[UserProfile_getUserProfile_List]", System.Data.CommandType.StoredProcedure, sqlParams);
        return ResultSet;
    }
    public DataSet CheckExistingUserID(string UserId)
    {
        DataSet ResultSet = new DataSet();
        SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@usp_user_id",SqlDbType.VarChar){Value=CommonModule.DBNullValueorStringIfNotNull(UserId)}
            };
        ResultSet = DBFactory.GetHelper().ExecuteDataSet("[userProfile_CheckExistingUserId]", System.Data.CommandType.StoredProcedure, sqlParams);
        return ResultSet;
    }
    public int ResetPassword(UserProfileEntity user, SqlConnection sqlConn, SqlTransaction sqlTrans)
    {
        int numRowsAffected;
        SqlParameter[] sqlParams = new SqlParameter[3];
        try
        {
            sqlConn = (SqlConnection)DBFactory.GetHelper().OpenConnection();
            sqlTrans = sqlConn.BeginTransaction();

            sqlParams[0] = new SqlParameter();
            sqlParams[0].ParameterName = "@usp_user_id";
            sqlParams[0].DbType = DbType.String;
            sqlParams[0].Direction = System.Data.ParameterDirection.Input;
            sqlParams[0].Value = user.uspuserid;

            sqlParams[1] = new SqlParameter();
            sqlParams[1].ParameterName = "@usp_user_pass";
            sqlParams[1].DbType = DbType.String;
            sqlParams[1].Direction = System.Data.ParameterDirection.Input;
            sqlParams[1].Value = user.usppswd;

            sqlParams[2] = new SqlParameter();
            sqlParams[2].ParameterName = "@modified_user";
            sqlParams[2].DbType = DbType.String;
            sqlParams[2].Direction = System.Data.ParameterDirection.Input;
            sqlParams[2].Value = user.createduser;

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = sqlConn;
            sqlCmd.Transaction = sqlTrans;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "dbo.UserProfile_resetPassword";
            sqlCmd.Parameters.AddRange(sqlParams);
            numRowsAffected = sqlCmd.ExecuteNonQuery();
            sqlTrans.Commit();
        }
        catch (Exception ex)
        {
            if (!(sqlTrans == null))
                // SqlTrans is set to Rollback to go back to the beginning of the transaction
                sqlTrans.Rollback();
            throw ex;
        }
        finally
        {
            if (!(sqlConn == null))
                // sqlConn is set to close state after completing the transaction
                sqlConn.Close();
        }
        return numRowsAffected;
    }

    public string SetUserProfileData(UserProfileEntity entity, SqlConnection sqlConn, SqlTransaction sqlTrans)
    {
        string returnUserID = string.Empty;
        try
        {
            SqlParameter[] sqlParams = new SqlParameter[39];

            sqlParams[0] = new SqlParameter();
            sqlParams[0].ParameterName = "@usp_user_id";
            sqlParams[0].DbType = DbType.String;
            sqlParams[0].Direction = System.Data.ParameterDirection.Input;
            sqlParams[0].Value = CommonModule.DBNullValueorStringIfNotNull(entity.uspuserid);

            sqlParams[1] = new SqlParameter();
            sqlParams[1].ParameterName = "@usp_first_name";
            sqlParams[1].DbType = DbType.String;
            sqlParams[1].Direction = System.Data.ParameterDirection.Input;
            sqlParams[1].Value = CommonModule.DBNullValueorStringIfNotNull(entity.uspfirstname);

            sqlParams[2] = new SqlParameter();
            sqlParams[2].ParameterName = "@usp_last_name";
            sqlParams[2].DbType = DbType.String;
            sqlParams[2].Direction = System.Data.ParameterDirection.Input;
            sqlParams[2].Value = CommonModule.DBNullValueorStringIfNotNull(entity.usplastname);

            sqlParams[3] = new SqlParameter();
            sqlParams[3].ParameterName = "@usp_group_code";
            sqlParams[3].DbType = DbType.String;
            sqlParams[3].Direction = System.Data.ParameterDirection.Input;
            sqlParams[3].Value = CommonModule.DBNullValueorStringIfNotNull(entity.uspgroupcode);

            sqlParams[4] = new SqlParameter();
            sqlParams[4].ParameterName = "@usp_pswd";
            sqlParams[4].DbType = DbType.String;
            sqlParams[4].Direction = System.Data.ParameterDirection.Input;
            sqlParams[4].Value = CommonModule.DBNullValueorStringIfNotNull(entity.usppswd);

            sqlParams[5] = new SqlParameter();
            sqlParams[5].ParameterName = "@usp_mailid";
            sqlParams[5].DbType = DbType.String;
            sqlParams[5].Direction = System.Data.ParameterDirection.Input;
            sqlParams[5].Value = CommonModule.DBNullValueorStringIfNotNull(entity.uspmailid);

            sqlParams[6] = new SqlParameter();
            sqlParams[6].ParameterName = "@usp_mobile";
            sqlParams[6].DbType = DbType.String;
            sqlParams[6].Direction = System.Data.ParameterDirection.Input;
            sqlParams[6].Value = CommonModule.DBNullValueorStringIfNotNull(entity.uspmobile);

            sqlParams[7] = new SqlParameter();
            sqlParams[7].ParameterName = "@usp_dob";
            sqlParams[7].DbType = DbType.DateTime;
            sqlParams[7].Direction = System.Data.ParameterDirection.Input;
            sqlParams[7].Value = CommonModule.DBNullValueorDatetTimeIfNotNull(entity.uspdob);

            sqlParams[8] = new SqlParameter();
            sqlParams[8].ParameterName = "@usp_doj";
            sqlParams[8].DbType = DbType.DateTime;
            sqlParams[8].Direction = System.Data.ParameterDirection.Input;
            sqlParams[8].Value = CommonModule.DBNullValueorDatetTimeIfNotNull(entity.uspdoj);

            sqlParams[9] = new SqlParameter();
            sqlParams[9].ParameterName = "@usp_reporting_head";
            sqlParams[9].DbType = DbType.String;
            sqlParams[9].Direction = System.Data.ParameterDirection.Input;
            sqlParams[9].Value = CommonModule.DBNullValueorStringIfNotNull(entity.usp_reporting_head);

            sqlParams[10] = new SqlParameter();
            sqlParams[10].ParameterName = "@usp_reporting_desig";
            sqlParams[10].DbType = DbType.String;
            sqlParams[10].Direction = System.Data.ParameterDirection.Input;
            sqlParams[10].Value = CommonModule.DBNullValueorStringIfNotNull(entity.usp_reporting_desig);

            sqlParams[11] = new SqlParameter();
            sqlParams[11].ParameterName = "@usp_reporting_mailid";
            sqlParams[11].DbType = DbType.String;
            sqlParams[11].Direction = System.Data.ParameterDirection.Input;
            sqlParams[11].Value = CommonModule.DBNullValueorStringIfNotNull(entity.usp_reporting_mailid);

            sqlParams[12] = new SqlParameter();
            sqlParams[12].ParameterName = "@created_user";
            sqlParams[12].DbType = DbType.String;
            sqlParams[12].Direction = System.Data.ParameterDirection.Input;
            sqlParams[12].Value = CommonModule.DBNullValueorStringIfNotNull(entity.createduser);

            sqlParams[13] = new SqlParameter();
            sqlParams[13].ParameterName = "@active";
            sqlParams[13].DbType = DbType.String;
            sqlParams[13].Direction = System.Data.ParameterDirection.Input;
            sqlParams[13].Value = CommonModule.DBNullValueorStringIfNotNull(entity.statusActive);

            sqlParams[14] = new SqlParameter();
            sqlParams[14].ParameterName = "@usp_employee_id";
            sqlParams[14].DbType = DbType.String;
            sqlParams[14].Direction = System.Data.ParameterDirection.Input;
            sqlParams[14].Value = CommonModule.DBNullValueorStringIfNotNull(entity.usp_employee_id);

            sqlParams[15] = new SqlParameter();
            sqlParams[15].ParameterName = "@usp_gender";
            sqlParams[15].DbType = DbType.String;
            sqlParams[15].Direction = System.Data.ParameterDirection.Input;
            sqlParams[15].Value = CommonModule.DBNullValueorStringIfNotNull(entity.usp_gender);

            sqlParams[16] = new SqlParameter();
            sqlParams[16].ParameterName = "@usp_address1";
            sqlParams[16].DbType = DbType.String;
            sqlParams[16].Direction = System.Data.ParameterDirection.Input;
            sqlParams[16].Value = CommonModule.DBNullValueorStringIfNotNull(entity.usp_address1);

            sqlParams[17] = new SqlParameter();
            sqlParams[17].ParameterName = "@usp_address2";
            sqlParams[17].DbType = DbType.String;
            sqlParams[17].Direction = System.Data.ParameterDirection.Input;
            sqlParams[17].Value = CommonModule.DBNullValueorStringIfNotNull(entity.usp_address2);

            sqlParams[18] = new SqlParameter();
            sqlParams[18].ParameterName = "@usp_city";
            sqlParams[18].DbType = DbType.String;
            sqlParams[18].Direction = System.Data.ParameterDirection.Input;
            sqlParams[18].Value = CommonModule.DBNullValueorStringIfNotNull(entity.usp_city);

            sqlParams[19] = new SqlParameter();
            sqlParams[19].ParameterName = "@usp_state";
            sqlParams[19].DbType = DbType.String;
            sqlParams[19].Direction = System.Data.ParameterDirection.Input;
            sqlParams[19].Value = CommonModule.DBNullValueorStringIfNotNull(entity.usp_state);

            sqlParams[20] = new SqlParameter();
            sqlParams[20].ParameterName = "@user_action";
            sqlParams[20].DbType = DbType.String;
            sqlParams[20].Direction = System.Data.ParameterDirection.Input;
            sqlParams[20].Value = CommonModule.DBNullValueorStringIfNotNull(entity.usp_action);

            sqlParams[21] = new SqlParameter();
            sqlParams[21].ParameterName = "@usp_aadhar_no";
            sqlParams[21].DbType = DbType.String;
            sqlParams[21].Direction = System.Data.ParameterDirection.Input;
            sqlParams[21].Value = CommonModule.DBNullValueorStringIfNotNull(entity.usp_aadhar_no);

            sqlParams[22] = new SqlParameter();
            sqlParams[22].ParameterName = "@usp_pan_no";
            sqlParams[22].DbType = DbType.String;
            sqlParams[22].Direction = System.Data.ParameterDirection.Input;
            sqlParams[22].Value = CommonModule.DBNullValueorStringIfNotNull(entity.usp_pan_no);

            sqlParams[23] = new SqlParameter();
            sqlParams[23].ParameterName = "@usp_desig";
            sqlParams[23].DbType = DbType.String;
            sqlParams[23].Direction = System.Data.ParameterDirection.Input;
            sqlParams[23].Value = CommonModule.DBNullValueorStringIfNotNull(entity.uspdesig);

            sqlParams[24] = new SqlParameter();
            sqlParams[24].ParameterName = "@epin";
            sqlParams[24].DbType = DbType.String;
            sqlParams[24].Direction = System.Data.ParameterDirection.Input;
            sqlParams[24].Value = CommonModule.DBNullValueorStringIfNotNull(string.Empty);

            sqlParams[25] = new SqlParameter();
            sqlParams[25].ParameterName = "@user_id_out";
            sqlParams[25].DbType = DbType.String;
            sqlParams[25].Size = 100;
            sqlParams[25].Direction = System.Data.ParameterDirection.Output;

            sqlParams[26] = new SqlParameter();
            sqlParams[26].ParameterName = "@usp_marital_status";
            sqlParams[26].DbType = DbType.String;
            sqlParams[26].Direction = System.Data.ParameterDirection.Input;
            sqlParams[26].Value = CommonModule.DBNullValueorStringIfNotNull(entity.usp_marital_status);

            sqlParams[27] = new SqlParameter();
            sqlParams[27].ParameterName = "@usp_profession";
            sqlParams[27].DbType = DbType.String;
            sqlParams[27].Direction = System.Data.ParameterDirection.Input;
            sqlParams[27].Value = CommonModule.DBNullValueorStringIfNotNull(entity.usp_profession);

            sqlParams[28] = new SqlParameter();
            sqlParams[28].ParameterName = "@usp_qualification";
            sqlParams[28].DbType = DbType.String;
            sqlParams[28].Direction = System.Data.ParameterDirection.Input;
            sqlParams[28].Value = CommonModule.DBNullValueorStringIfNotNull(entity.usp_qualification);

            sqlParams[29] = new SqlParameter();
            sqlParams[29].ParameterName = "@usp_country";
            sqlParams[29].DbType = DbType.String;
            sqlParams[29].Direction = System.Data.ParameterDirection.Input;
            sqlParams[29].Value = CommonModule.DBNullValueorStringIfNotNull(entity.usp_country);

            sqlParams[30] = new SqlParameter();
            sqlParams[30].ParameterName = "@usp_pincode";
            sqlParams[30].DbType = DbType.String;
            sqlParams[30].Direction = System.Data.ParameterDirection.Input;
            sqlParams[30].Value = CommonModule.DBNullValueorStringIfNotNull(entity.usp_pincode);

            sqlParams[31] = new SqlParameter();
            sqlParams[31].ParameterName = "@sponsor_id";
            sqlParams[31].DbType = DbType.String;
            sqlParams[31].Direction = System.Data.ParameterDirection.Input;
            sqlParams[31].Value = CommonModule.DBNullValueorStringIfNotNull(entity.sponsor_id);

            sqlParams[32] = new SqlParameter();
            sqlParams[32].ParameterName = "@ajd_upline_id";
            sqlParams[32].DbType = DbType.String;
            sqlParams[32].Direction = System.Data.ParameterDirection.Input;
            sqlParams[32].Value = CommonModule.DBNullValueorStringIfNotNull(entity.upline_id);

            sqlParams[33] = new SqlParameter();
            sqlParams[33].ParameterName = "@usp_father_name";
            sqlParams[33].DbType = DbType.String;
            sqlParams[33].Direction = System.Data.ParameterDirection.Input;
            sqlParams[33].Value = CommonModule.DBNullValueorStringIfNotNull(entity.father_name);

            sqlParams[34] = new SqlParameter();
            sqlParams[34].ParameterName = "@usp_blood_group";
            sqlParams[34].DbType = DbType.String;
            sqlParams[34].Direction = System.Data.ParameterDirection.Input;
            sqlParams[34].Value = CommonModule.DBNullValueorStringIfNotNull(entity.usp_blood_group);

            sqlParams[35] = new SqlParameter();
            sqlParams[35].ParameterName = "@usp_service_provider";
            sqlParams[35].DbType = DbType.String;
            sqlParams[35].Direction = System.Data.ParameterDirection.Input;
            sqlParams[35].Value = CommonModule.DBNullValueorStringIfNotNull(entity.usp_service_provider);

            sqlParams[36] = new SqlParameter();
            sqlParams[36].ParameterName = "@usp_service_provider_state";
            sqlParams[36].DbType = DbType.String;
            sqlParams[36].Direction = System.Data.ParameterDirection.Input;
            sqlParams[36].Value = CommonModule.DBNullValueorStringIfNotNull(entity.usp_service_provider_state);

            sqlParams[37] = new SqlParameter();
            sqlParams[37].ParameterName = "@utc_transaction_password";
            sqlParams[37].DbType = DbType.String;
            sqlParams[37].Direction = System.Data.ParameterDirection.Input;
            sqlParams[37].Value = CommonModule.DBNullValueorStringIfNotNull(entity.usp_transaction_password);

            sqlParams[38] = new SqlParameter();
            sqlParams[38].ParameterName = "@usp_salutation";
            sqlParams[38].DbType = DbType.String;
            sqlParams[38].Direction = System.Data.ParameterDirection.Input;
            sqlParams[38].Value = CommonModule.DBNullValueorStringIfNotNull(entity.usp_salutation);

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = sqlConn;
            sqlCmd.Transaction = sqlTrans;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "UserProfile_Insert";
            sqlCmd.Parameters.AddRange(sqlParams);
            sqlCmd.ExecuteNonQuery();

            returnUserID =(string)sqlCmd.Parameters["@user_id_out"].Value;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return returnUserID;
    }

    public int UpdateUserProfileData(UserProfileEntity entity, SqlConnection sqlConn, SqlTransaction sqlTrans)
    {
        int returnResult = 0;
        try
        {
            SqlParameter[] sqlParams ={
                                   new SqlParameter("@usp_user_id",entity.uspuserid),
                                   new SqlParameter("@usp_first_name",entity.uspfirstname),
                                   new SqlParameter("@usp_last_name",entity.usplastname),
                                   new SqlParameter("@usp_group_code",entity.uspgroupcode),
                                   new SqlParameter("@usp_dept",entity.uspdept),
                                   new SqlParameter("@usp_mailid",entity.uspmailid),
                                   new SqlParameter("@usp_mobile",entity.uspmobile),
                                   new SqlParameter("@usp_desig",entity.uspdesig),
                                   new SqlParameter("@usp_doj",entity.uspdoj==SqlDateTime.MinValue?(object)DBNull.Value:entity.uspdoj),
                                   new SqlParameter("@usp_depot",entity.uspdepot),
                                   new SqlParameter("@usp_terr_assigned_yn",(object)DBNull.Value),
                                   new SqlParameter("@usp_terr_assigned",(object)DBNull.Value),
                                   new SqlParameter("@usp_terr_assigned_date",(object)DBNull.Value),
                                   new SqlParameter("@usp_job_handled",(object)DBNull.Value),
                                   new SqlParameter("@usp_reporting_head",(object)DBNull.Value),
                                   new SqlParameter("@usp_reporting_desig",(object)DBNull.Value),
                                   new SqlParameter("@usp_reporting_mailid",(object)DBNull.Value),
                                   new SqlParameter("@modified_user",entity.modifieduser),
                                   new SqlParameter("@active",entity.statusActive),
                                   new SqlParameter("@usp_employee_id",entity.uspemployeeid),
                                   new SqlParameter("@HasFile",entity.HasFile),
                                   new SqlParameter("@usp_file_name",entity.FileName==string.Empty?(object)DBNull.Value:entity.FileName),
                                  };
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = sqlConn;
            sqlCmd.Transaction = sqlTrans;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "UserProfile_Update";
            sqlCmd.Parameters.AddRange(sqlParams);
            returnResult = sqlCmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return returnResult;
    }

    public int UpdateUserProfileStatus(UserProfileEntity entity, SqlConnection sqlConn, SqlTransaction sqlTrans)
    {
        int returnResult = 0;
        try
        {
            SqlParameter[] sqlParams ={
                                   new SqlParameter("@usp_user_id",entity.uspuserid),                                
                                   new SqlParameter("@modified_user",entity.modifieduser),
                                   new SqlParameter("@active",entity.statusActive),                                 
                                  };
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = sqlConn;
            sqlCmd.Transaction = sqlTrans;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "UserProfile_StatusUpdate";
            sqlCmd.Parameters.AddRange(sqlParams);
            returnResult = sqlCmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return returnResult;
    }

    public DataSet GetUserDetails(UserProfileEntity entity)
    {
        SqlParameter[] sqlParams ={
                                   new SqlParameter("@usp_group_code",CommonModule.DBNullValueorStringIfNotNull(entity.uspgroupcode)),
                                   new SqlParameter("@user_name", CommonModule.DBNullValueorStringIfNotNull(entity.uspfirstname)),
                                   new SqlParameter("@usp_user_ID", CommonModule.DBNullValueorStringIfNotNull(entity.uspuserid)),
                                   new SqlParameter("@status", CommonModule.DBNullValueorStringIfNotNull(entity.statusActive)),
                                  };
        return DBFactory.GetHelper().ExecuteDataSet("user_profile_get_list", System.Data.CommandType.StoredProcedure, sqlParams);
    }
    public  string GeneratePassword(int Length, int NonAlphaNumericChars)
    {
        string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";
        string allowedNonAlphaNum = "!@#$%^&*()_-+=[{]};:<>|./?";
        string pass = "";
        Random rd = new Random(DateTime.Now.Millisecond);
        for (int i = 0; i < Length; i++)
        {
            int t = rd.Next(1);
            if (i == (Length - 1) && NonAlphaNumericChars > 0)
            {
                pass += allowedNonAlphaNum[rd.Next(allowedNonAlphaNum.Length)];
                NonAlphaNumericChars--;
            }
            else
            {
                pass += allowedChars[rd.Next(allowedChars.Length)];
            }
        }
        return pass;
    }

    //public int SetUserBankInfoData(BankInfoEntity entity, SqlConnection sqlConn, SqlTransaction sqlTrans)
    //{
    //    int returnResult = 0;
    //    try
    //    {
    //        SqlParameter[] sqlParams ={
    //                               new SqlParameter("@ubi_bank_id",CommonModule.DBNullValueorInt64IfNotNull(entity.ubi_bank_id)),
    //                               new SqlParameter("@ubi_user_id",CommonModule.DBNullValueorStringIfNotNull(entity.ubi_user_id)),
    //                               new SqlParameter("@ubi_bank_name",CommonModule.DBNullValueorStringIfNotNull(entity.ubi_bank_name)),
    //                               new SqlParameter("@ubi_branch_name",CommonModule.DBNullValueorStringIfNotNull(entity.ubi_branch_name)),
    //                               new SqlParameter("@ubi_address",CommonModule.DBNullValueorStringIfNotNull(entity.ubi_address)),
    //                               new SqlParameter("@ubi_ifsc",CommonModule.DBNullValueorStringIfNotNull(entity.ubi_ifsc)),
    //                               new SqlParameter("@ubi_ac_type",CommonModule.DBNullValueorStringIfNotNull(entity.ubi_ac_type)),
    //                               new SqlParameter("@ubi_ac_holder_name",CommonModule.DBNullValueorStringIfNotNull(entity.ubi_ac_holder_name)),
    //                               new SqlParameter("@ubi_account_no",CommonModule.DBNullValueorStringIfNotNull(entity.ubi_account_no)),
    //                               new SqlParameter("@created_user",CommonModule.DBNullValueorStringIfNotNull(entity.created_user)),
    //                               new SqlParameter("@active",CommonModule.DBNullValueorStringIfNotNull(entity.active)),                                  
    //                              };
    //        SqlCommand sqlCmd = new SqlCommand();
    //        sqlCmd.Connection = sqlConn;
    //        sqlCmd.Transaction = sqlTrans;
    //        sqlCmd.CommandType = CommandType.StoredProcedure;
    //        sqlCmd.CommandText = "user_bank_info_Insert_Update";
    //        sqlCmd.Parameters.AddRange(sqlParams);
    //        returnResult = sqlCmd.ExecuteNonQuery();
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    return returnResult;
    //}

    //public int SetNomineeDetailData(NomineeDetailEntity entity, SqlConnection sqlConn, SqlTransaction sqlTrans)
    //{
    //    int returnResult = 0;
    //    try
    //    {
    //        SqlParameter[] sqlParams ={
    //                               new SqlParameter("@nd_user_id",CommonModule.DBNullValueorStringIfNotNull(entity.nd_user_id)),
    //                               new SqlParameter("@nd_nominee_name",CommonModule.DBNullValueorStringIfNotNull(entity.nd_nominee_name )),
    //                               new SqlParameter("@nd_relation_type",CommonModule.DBNullValueorStringIfNotNull(entity.nd_relation_type)),                                  
    //                               new SqlParameter("@created_user",CommonModule.DBNullValueorStringIfNotNull(entity.created_user)),
    //                               new SqlParameter("@active",CommonModule.DBNullValueorStringIfNotNull(entity.active)),
    //                               new SqlParameter("@nd_age",CommonModule.DBNullValueorInt32IfNotNull(entity.nd_age)),
    //                              };
    //        SqlCommand sqlCmd = new SqlCommand();
    //        sqlCmd.Connection = sqlConn;
    //        sqlCmd.Transaction = sqlTrans;
    //        sqlCmd.CommandType = CommandType.StoredProcedure;
    //        sqlCmd.CommandText = "nominee_detail_Insert_Update";
    //        sqlCmd.Parameters.AddRange(sqlParams);
    //        returnResult = sqlCmd.ExecuteNonQuery();
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    return returnResult;
    //}

    public int UpdateSMSSentFlag(UserProfileEntity entity, SqlConnection sqlConn, SqlTransaction sqlTrans)
    {
        int returnResult = 0;
        try
        {
            SqlParameter[] sqlParams ={
                                   new SqlParameter("@usp_user_id",entity.uspuserid),
                                   new SqlParameter("@created_user",entity.createduser),
                                   new SqlParameter("@usp_sms_sent_yn",entity.usp_sms_sent_yn),
                                  };
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = sqlConn;
            sqlCmd.Transaction = sqlTrans;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "user_profile_sms_sent_update";
            sqlCmd.Parameters.AddRange(sqlParams);
            returnResult = sqlCmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return returnResult;
    }

    public DataSet GetUserDetailEditMode(String userID)
    {
        SqlParameter[] sqlParams ={
                                   new SqlParameter("@user_id",CommonModule.DBNullValueorStringIfNotNull(userID)),
                                  };
        return DBFactory.GetHelper().ExecuteDataSet("user_profile_detail_get", System.Data.CommandType.StoredProcedure, sqlParams);
    }

    public DataSet GetUserKYCDetail(String userID,string kyc_name)
    {
        SqlParameter[] sqlParams ={
                                   new SqlParameter("@pusp_user_id",CommonModule.DBNullValueorStringIfNotNull(userID)),
                                   new SqlParameter("@pkyc_name",CommonModule.DBNullValueorStringIfNotNull(kyc_name)),
                                  };
        return DBFactory.GetHelper().ExecuteDataSet("GET_User_KYCDetails", System.Data.CommandType.StoredProcedure, sqlParams);
    }

    public int UpdateProfilePhoto(UserProfileEntity entity, SqlConnection sqlConn, SqlTransaction sqlTrans)
    {
        int returnResult = 0;
        try
        {
            SqlParameter[] sqlParams ={
                                   new SqlParameter("@user_id",entity.uspuserid),
                                   new SqlParameter("@file_name",entity.usp_profile_pic),
                                  };
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = sqlConn;
            sqlCmd.Transaction = sqlTrans;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "profile_photo_upload";
            sqlCmd.Parameters.AddRange(sqlParams);
            returnResult = sqlCmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return returnResult;
    }

    //public int InsertUpdateKYCDetails(KYCEntity entity, SqlConnection sqlConn, SqlTransaction sqlTrans)
    //{
    //    int returnResult = 0;
    //    try
    //    {
    //        SqlParameter[] sqlParams ={
    //                               new SqlParameter("@pusp_user_id",entity.pusp_user_id),
    //                               new SqlParameter("@pkyc_name",entity.kyc_name),
    //                               new SqlParameter("@pkyc_path",entity.kyc_path),
    //                               new SqlParameter("@pcreated_user",entity.pusp_user_id),
    //                              };
    //        SqlCommand sqlCmd = new SqlCommand();
    //        sqlCmd.Connection = sqlConn;
    //        sqlCmd.Transaction = sqlTrans;
    //        sqlCmd.CommandType = CommandType.StoredProcedure;
    //        sqlCmd.CommandText = "user_kyc_InsertUpdate";
    //        sqlCmd.Parameters.AddRange(sqlParams);
    //        returnResult = sqlCmd.ExecuteNonQuery();
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    return returnResult;
    //}

    public DataSet GetUserDetailByGroupCode(String userGroupCode,string userId)
    {
        SqlParameter[] sqlParams ={
                                   new SqlParameter("@user_group",CommonModule.DBNullValueorStringIfNotNull(userId)),
                                   new SqlParameter("@user_id",CommonModule.DBNullValueorStringIfNotNull(userGroupCode)),
                                  };
        return DBFactory.GetHelper().ExecuteDataSet("user_group_applicable_user_list_get", System.Data.CommandType.StoredProcedure, sqlParams);
    }

}