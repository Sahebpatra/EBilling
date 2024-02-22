using EBilling;
using EBilling.DataAccess;
using EBilling.EmailSms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ValidateOTP : System.Web.UI.Page
{
    private bool _refreshState;
    private bool _isRefresh;
    public bool IsRefresh
    {
        get
        {
            return _isRefresh;
        }
    }
    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            AddAttribute();
            lblMessage.BorderColor = System.Drawing.Color.White;
            if (!IsPostBack)
            {
                txtOTP.Focus();
                if (!(Request.QueryString["UID"] == null) && Request.QueryString["MNo"] != null)
                {
                    hdnUserID.Value = Encryption.Decrypt(Request.QueryString["UID"]);
                    hdnMobileNo.Value = Encryption.Decrypt(Request.QueryString["MNo"]);
                }
                else
                {
                    Response.Redirect("~/ForgotPassword.aspx", false);
                }
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendErrorToText(ex);
        }
    }
    #endregion

    #region Event Handler
    protected void btnValidateOTP_Click(object sender, EventArgs e)
    {
        TransactionPassword helper = null;
        UserOTPDetailsEntity entity = null;
        try
        {
            entity = new UserOTPDetailsEntity();
            entity.uod_otp = Convert.ToInt32(txtOTP.Text.Trim());
            entity.uod_user_id = hdnUserID.Value;

            helper = new TransactionPassword();
            var returnDS = helper.CheckOTP(entity);

            if (returnDS == null)
            {
                lblPopMessage.Text = "Invalid OTP";
                lblPopMessage.ForeColor = System.Drawing.Color.Red;
                lblPopMessage.Font.Bold = true;
                ModalPopupExtenderMessage.Show();
                return;
            }

            if (Convert.ToInt32(returnDS.Tables[0].Rows[0]["return_result"]) == -1 || Convert.ToInt32(returnDS.Tables[0].Rows[0]["return_result"]) == -2)
            {
                lblPopMessage.Text = returnDS.Tables[0].Rows[0]["otp_message"].ToString();
                lblPopMessage.ForeColor = System.Drawing.Color.Red;
                lblPopMessage.Font.Bold = true;
                ModalPopupExtenderMessage.Show();
                return;
            }

            SetForgotPassword();

        }
        catch (Exception ex)
        {
            ExceptionLogging.SendErrorToText(ex);
        }
    }
    protected void btnResendOTP_Click(object sender, EventArgs e)
    {
        UserOTPDetailsEntity otpEntity = null;
        try
        {
            otpEntity = new UserOTPDetailsEntity();
            otpEntity.uod_user_id = hdnUserID.Value;
            otpEntity.created_user = hdnUserID.Value;
            otpEntity.active = Constant.Common.ActiveStatus;
            otpEntity.uod_mobile_no = hdnMobileNo.Value;

            ReSendOTP(otpEntity);
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendErrorToText(ex);
        }
    }
    #endregion

    #region Custom Method
    private void AddAttribute()
    {
        try
        {
            btnValidateOTP.OnClientClick = "return ValidateOTP('" + txtOTP.ClientID + "','" + lblMessage.ClientID + "','" + btnValidateOTP.ClientID + "');";
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void ReSendOTP(UserOTPDetailsEntity entity)
    {
        SqlConnection sqlConn = null;
        SqlTransaction sqlTrans = null;
        EmailSMSsender smshelper = null;
        TransactionPassword helper = null;
        List<SMSResponseEntity> JsonEntity = null;
        try
        {
            entity.uod_otp = Convert.ToInt32(CommonModule.GenerateOTP());
            var messageContent = String.Format("{0} Your One-Time-Password (OTP) is {1} for Forgot Password. Please note do not share this password with anyone - MiWinGo", DateTime.Now.ToString("dd/MMM HH:MM"), entity.uod_otp);
            smshelper = new EmailSMSsender();
            var returnResult = smshelper.SendSMS(entity.uod_mobile_no, messageContent.ToString().Trim());
            JsonEntity = JsonConvert.DeserializeObject<List<SMSResponseEntity>>(returnResult);
            if (JsonEntity == null)
            {
                return;
            }

            if (JsonEntity[0].responseCode.ToString().Trim().Contains("SuccessFully"))
            {
                entity.uod_status = Constant.Common.InActiveStatus;


                sqlConn = (SqlConnection)DBFactory.GetHelper().OpenConnection();
                sqlTrans = sqlConn.BeginTransaction();

                helper = new TransactionPassword();
                var returnUserId = helper.SetUserOTPDetails(entity, sqlConn, sqlTrans);
                if (returnUserId <= 0)
                {
                    sqlTrans.Rollback();
                    sqlConn.Close();
                    return;
                }

                lblPopMessage.Text = "OTP has been send to your registered mobile no.";
                lblPopMessage.ForeColor = System.Drawing.Color.Green;
                lblPopMessage.Font.Bold = true;
                ModalPopupExtenderMessage.Show();

                sqlTrans.Commit();
            }
        }
        catch (Exception ex)
        {
            if (!(sqlTrans == null))
                sqlTrans.Rollback();
            throw ex;
        }
        finally
        {
            if (!(sqlConn == null))
                sqlConn.Close();
        }
    }
    private void ClearControl()
    {
        try
        {
            txtOTP.Text = string.Empty;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void SetForgotPassword()
    {
        SqlConnection sqlConn = null;
        SqlTransaction sqlTrans = null;
        UserProfileClass helper = null;
        try
        {
            sqlConn = (SqlConnection)DBFactory.GetHelper().OpenConnection();
            sqlTrans = sqlConn.BeginTransaction();

            helper = new UserProfileClass();
            var returnResult = helper.SetForceLogin(hdnUserID.Value, hdnMobileNo.Value, txtOTP.Text.Trim(), sqlConn, sqlTrans);
            if (returnResult <= 0)
            {
                sqlTrans.Rollback();
                lblPopMessage.Text = Constant.ErrorMessages.GeneralError;
                lblPopMessage.ForeColor = System.Drawing.Color.Red;
                lblPopMessage.Font.Bold = true;
                ModalPopupExtenderMessage.Show();
                return;
            }

            sqlTrans.Commit();

        }
        catch (Exception ex)
        {
            if (sqlTrans != null)
            {
                sqlTrans.Rollback();
            }
            ExceptionLogging.SendErrorToText(ex);
        }
        finally
        {
            if (sqlConn != null)
            {
                sqlConn.Close();
            }
            RedirectToChangePasswordPage();
        }
    }
    private void RedirectToChangePasswordPage()
    {
        UserProfile userInfo = null;
        try
        {
            userInfo = new UserProfile();
            userInfo.UserId = hdnUserID.Value;
            userInfo.usp_force_login_yn = "Y";
            Session[Constant.SessionKeys.UserInfo] = userInfo;

            FormsAuthentication.Initialize();

            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, hdnUserID.Value.Trim(), DateTime.Now, DateTime.Now.AddMinutes(720), false, "Roles", FormsAuthentication.FormsCookiePath);

            //Encrypt the cookie using the machine key for secure transport
            string hash = FormsAuthentication.Encrypt(ticket);
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash);

            //Set the cookie's expiration time to the tickets expiration time
            if (ticket.IsPersistent)
            {
                cookie.Expires = ticket.Expiration;
            }

            //Add the cookie to the list for outgoing response
            Response.Cookies.Add(cookie);

            Response.Cookies["userid"].Value = hdnUserID.Value;
            Response.Cookies["userid"].Expires = DateTime.Now.AddDays(15);

            //Redirect to requested URL, or homepage if no previous page requested
            string returnUrl = string.Empty;
            returnUrl = "~/ChangePassword.aspx";

            Response.Redirect(returnUrl, false);

        }
        catch (Exception ex)
        {
            ExceptionLogging.SendErrorToText(ex);
        }
    }
    protected override object SaveViewState()
    {
        Session["__ISREFRESH"] = _refreshState;
        object[] allStates = new object[2];
        allStates[0] = base.SaveViewState();
        allStates[1] = !_refreshState;
        return allStates;
    }
    protected override void LoadViewState(object savedState)
    {
        object[] allStates = (object[])savedState;
        base.LoadViewState(allStates[0]);
        _refreshState = (bool)allStates[1];
        if (Session["__ISREFRESH"] != null)
        {
            _isRefresh = _refreshState == (bool)Session["__ISREFRESH"];
        }
    }
    #endregion       
}