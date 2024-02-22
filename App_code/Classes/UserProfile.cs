using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using EBilling.DataAccess;
using System.Web;
using System.Configuration;

namespace EBilling
{
    public class UserProfileClass
    {
        public UserProfile LoginUserDetails(string userName, string password)
        {
            string relativePath = ConfigurationManager.AppSettings["UPLOAD_DOCS_FOLDER_REL_PATH"];
            DataSet userSet = null;
            UserProfile userInfo = null;

            SqlParameter[] sqlParams = new SqlParameter[2];

            sqlParams[0] = new SqlParameter();
            sqlParams[0].ParameterName = "@usp_user_id";
            sqlParams[0].DbType = DbType.String;
            sqlParams[0].Direction = System.Data.ParameterDirection.Input;
            sqlParams[0].Value = userName;

            sqlParams[1] = new SqlParameter();
            sqlParams[1].ParameterName = "@usp_pswd";
            sqlParams[1].DbType = DbType.String;
            sqlParams[1].Direction = System.Data.ParameterDirection.Input;
            sqlParams[1].Value = password;

            userSet = DBFactory.GetHelper().ExecuteDataSet("LoginUser_Get", System.Data.CommandType.StoredProcedure, sqlParams);

            if ((userSet != null) && (userSet.Tables.Count > 0))
            {
                if ((userSet.Tables[0] != null) && (userSet.Tables[0].Rows.Count > 0))
                {
                    userInfo = new UserProfile();
                    foreach (DataRow dr in userSet.Tables[0].Rows)
                    {
                        userInfo.UserId = dr["usp_user_id"].ToString();
                        userInfo.UserPassword = dr["usp_pswd"].ToString();

                        userInfo.UserFirstName = dr["usp_first_name"].ToString();
                        userInfo.UserLastName = dr["usp_last_name"].ToString();

                        userInfo.GroupCode = dr["usp_group_code"].ToString();
                        userInfo.Desig = dr["usp_desig"].ToString();
                        userInfo.Dept = dr["usp_dept"].ToString();
                        userInfo.MailId = dr["usp_mailid"].ToString();
                        userInfo.MobileNo = dr["usp_mobile"].ToString();
                        userInfo.blood_group = dr["usp_blood_group"].ToString();
                        //test id
                        userInfo.Company_Id = Convert.ToInt64(dr["CompanyId"].ToString());



                        if (CommonModule.IsDate(dr["usp_dob"]))
                        {
                            userInfo.DOB = Convert.ToDateTime(dr["usp_dob"].ToString());
                        }
                        if (CommonModule.IsDate(dr["usp_doj"]))
                        {
                            userInfo.DOJ = Convert.ToDateTime(dr["usp_doj"].ToString());
                        }
                        userInfo.CreatedUser = dr["created_user"].ToString();
                        if (CommonModule.IsDate(dr["created_date"]))
                        {
                            userInfo.CreatedDate = Convert.ToDateTime(dr["created_date"].ToString());
                        }
                        userInfo.Active = dr["active"].ToString();
                        if (dr["usp_group_code"].ToString() == "DEALER")
                        {
                            userInfo.SelectedDealer = dr["usp_user_id"].ToString();
                        }
                        else
                        {
                            userInfo.SelectedDealer = "";
                        }

                        if (dr["usp_profile_pic"].ToString() == "")
                        {
                            userInfo.usp_profile_pic = "Theme/images/avatar.jpg";
                        }
                        else
                        {
                            userInfo.usp_profile_pic = relativePath + "PROFILEPIC/" + dr["usp_profile_pic"].ToString();
                        }

                       
                    }
                    userInfo.company_detail = new CompanyDetail();
                    userInfo.company_detail.cd_company_name = userSet.Tables[1].Rows[0]["cd_company_name"].ToString();
                    userInfo.company_detail.cd_company_name_short = userSet.Tables[1].Rows[0]["cd_company_name_short"].ToString();
                    userInfo.company_detail.cd_add1 = userSet.Tables[1].Rows[0]["cd_add1"].ToString();
                    userInfo.company_detail.cd_add2 = userSet.Tables[1].Rows[0]["cd_add2"].ToString();
                    userInfo.company_detail.cd_city = userSet.Tables[1].Rows[0]["cd_city"].ToString();
                    userInfo.company_detail.cd_pin = userSet.Tables[1].Rows[0]["cd_pin"].ToString();
                    userInfo.company_detail.cd_state = userSet.Tables[1].Rows[0]["cd_state"].ToString();
                    userInfo.company_detail.cd_country = userSet.Tables[1].Rows[0]["cd_country"].ToString();
                    userInfo.company_detail.cd_mob1 = userSet.Tables[1].Rows[0]["cd_mob1"].ToString();
                    userInfo.company_detail.cd_mob2 = userSet.Tables[1].Rows[0]["cd_mob2"].ToString();
                    userInfo.company_detail.cd_mail_id = userSet.Tables[1].Rows[0]["cd_mail_id"].ToString();
                    userInfo.usp_force_login_yn = userSet.Tables[0].Rows[0]["usp_force_login_yn"].ToString();

                    UserHistoryInsert(userInfo.UserId, userInfo.GroupCode, GetIPAddress());
                }
            }

            return userInfo;
        }

        public string GetIPAddress()
        {
            HttpContext context = HttpContext.Current;
            string SIPAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(SIPAddress))
                return context.Request.ServerVariables["REMOTE_ADDR"];
            else
            {
                string[] ipArray = SIPAddress.Split(new Char[] { ',' });
                return ipArray[0];
            }
        }

        public int UserHistoryInsert(string userId, string groupCode, string ip)
        {
            SqlConnection sqlConn = null;
            //sqlTrans checks the type of operation to be performed for a particular Sql transaction
            SqlTransaction sqlTrans = null;
            int numRowsAffected = 0;
            SqlParameter[] sqlParams = new SqlParameter[3];
            try
            {
                sqlConn = (SqlConnection)DBFactory.GetHelper().OpenConnection();
                sqlTrans = sqlConn.BeginTransaction();

                sqlParams[0] = new SqlParameter();
                sqlParams[0].ParameterName = "@uh_userid";
                sqlParams[0].DbType = DbType.String;
                sqlParams[0].Direction = System.Data.ParameterDirection.Input;
                sqlParams[0].Value = userId;

                sqlParams[1] = new SqlParameter();
                sqlParams[1].ParameterName = "@uh_user_group";
                sqlParams[1].DbType = DbType.String;
                sqlParams[1].Direction = System.Data.ParameterDirection.Input;
                sqlParams[1].Value = groupCode;

                sqlParams[2] = new SqlParameter();
                sqlParams[2].ParameterName = "@uh_logged_ip";
                sqlParams[2].DbType = DbType.String;
                sqlParams[2].Direction = System.Data.ParameterDirection.Input;
                sqlParams[2].Value = ip;

                //sqlCmd is the object instance of the SqlCommand 
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlConn;
                sqlCmd.Transaction = sqlTrans;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UserHistory_Insert";
                sqlCmd.Parameters.AddRange(sqlParams);
                numRowsAffected = sqlCmd.ExecuteNonQuery();

                //SqlTrans is set to commit to save the transaction
                sqlTrans.Commit();
            }
            catch (Exception ex)
            {
                if (sqlTrans != null)
                {
                    //SqlTrans is set to Rollback to go back to the beginning of the transaction
                    sqlTrans.Rollback();
                    throw ex;
                }
            }
            finally
            {
                if (sqlConn != null)
                {
                    //sqlConn is set to close state after completing the transaction
                    sqlConn.Close();
                }
            }
            return numRowsAffected;
        }

        public DataSet GetUserFormMenu(string loginGroupId, string loginUserId)
        {
            SqlParameter[] sqlParams ={
                                   new SqlParameter("@logingrpid",loginGroupId),
                                   new SqlParameter("@loginuserid",loginUserId)
                                  };
            DataSet returnDS = DBFactory.GetHelper().ExecuteDataSet("Get_Menu", System.Data.CommandType.StoredProcedure, sqlParams);
            return returnDS;
        }

        public DataSet Get_Mail_Details(string UserID)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] sqlparams = new SqlParameter[1];
                sqlparams[0] = new SqlParameter();
                sqlparams[0].ParameterName = "@UserID";
                sqlparams[0].DbType = DbType.String;
                sqlparams[0].Direction = ParameterDirection.Input;
                sqlparams[0].Value = UserID;
                ds = DBFactory.GetHelper().ExecuteDataSet("dbo.UserProfile_getDetailsForEmail", System.Data.CommandType.StoredProcedure, sqlparams);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetUserGroup(string UserID)
        {
            DataSet userDetails;
            SqlParameter[] sqlParams = new SqlParameter[1];

            sqlParams[0] = new SqlParameter();
            sqlParams[0].ParameterName = "@userId";
            sqlParams[0].DbType = DbType.String;
            sqlParams[0].Direction = System.Data.ParameterDirection.Input;
            sqlParams[0].Value = UserID;

            userDetails = DBFactory.GetHelper().ExecuteDataSet("[dbo].[Get_User_Group]", System.Data.CommandType.StoredProcedure, sqlParams);
            return userDetails;
        }

        public DataSet ValidateMobileNo(string mobileNo)
        {
            DataSet userSet = null;

            SqlParameter[] sqlParams = new SqlParameter[1];

            sqlParams[0] = new SqlParameter();
            sqlParams[0].ParameterName = "@mobile_no";
            sqlParams[0].DbType = DbType.String;
            sqlParams[0].Direction = System.Data.ParameterDirection.Input;
            sqlParams[0].Value = mobileNo;

            userSet = DBFactory.GetHelper().ExecuteDataSet("validate_mobile_no", System.Data.CommandType.StoredProcedure, sqlParams);

            return userSet;
        }

        public int SetForceLogin(string userid, string mobileNo, string otp, SqlConnection sqlConn, SqlTransaction sqlTrans)
        {
            int numRowsAffected = 0;
            try
            {                
                SqlParameter[] sqlParams = {
                                       new SqlParameter("@user_id",userid),
                                       new SqlParameter("@mobile_no",mobileNo),
                                       new SqlParameter("@otp",otp)
                                   };
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlConn;
                sqlCmd.Transaction = sqlTrans;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "dbo.forgot_password_update_user_profile";
                sqlCmd.Parameters.AddRange(sqlParams);
                numRowsAffected = sqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendErrorToText(ex);
            }
            return numRowsAffected;
        }
    }
}