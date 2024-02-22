using EBilling;
using EBilling.DataAccess;
using EBilling.EmailSms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class ForgotPassword : System.Web.UI.Page
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
                ClearControl();
                txtMobileNo.Focus();
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendErrorToText(ex);
        }
    }
    #endregion

    #region Event Handler
    protected void btnSendOTP_Click(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(txtMobileNo.Text.Trim())) {
                lblMessage.Text = "Please enter mobile no";
                divAlert.Attributes.Add("style", "block");
                return;
            }

            ValidateMobileNo();
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendErrorToText(ex);
        }
    }
    protected void btnValidateOTP_Click(object sender, EventArgs e)
    {
        try
        {
            var returnUrl = string.Format("~/ValidateOTP.aspx?UID={0}&MNo={1}", Encryption.encrypt(hdnUserID.Value), Encryption.encrypt(hdnMobileNo.Value));
            Response.Redirect(returnUrl, false);
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
            btnSendOTP.OnClientClick = "return ValidateDetails('" + txtMobileNo.ClientID + "','" + lblMessage.ClientID + "','" + btnSendOTP.ClientID + "');";
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void ValidateMobileNo()
    {
        UserOTPDetailsEntity otpEntity = null;
        try
        {
            UserProfileClass helper = new UserProfileClass();
            var returnDS = helper.ValidateMobileNo(txtMobileNo.Text.Trim());

            if (returnDS == null)
            {
                lblMessage.Text = "Invalid mobile no.";
                divAlert.Attributes.Add("style", "block");
                return;
            }

            if (returnDS.Tables== null)
            {
                lblMessage.Text = "Invalid mobile no.";
                divAlert.Attributes.Add("style", "block");
                return;
            }

            if (Convert.ToInt32(returnDS.Tables[0].Rows[0]["error_code"])<0)
            {
                lblMessage.Text =Convert.ToString(returnDS.Tables[0].Rows[0]["error_msg"]);
                divAlert.Attributes.Add("style", "block");
                return;
            }

            otpEntity = new UserOTPDetailsEntity();
            otpEntity.uod_user_id = Convert.ToString(returnDS.Tables[0].Rows[0]["usp_user_id"]);
            otpEntity.created_user = Convert.ToString(returnDS.Tables[0].Rows[0]["usp_user_id"]);
            otpEntity.active = Constant.Common.ActiveStatus;
            otpEntity.uod_mobile_no = Convert.ToString(returnDS.Tables[0].Rows[0]["usp_mobile"]);

            hdnUserID.Value = Convert.ToString(returnDS.Tables[0].Rows[0]["usp_user_id"]);
            hdnMobileNo.Value = Convert.ToString(returnDS.Tables[0].Rows[0]["usp_mobile"]);

            SendOTP(otpEntity);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void SendOTP(UserOTPDetailsEntity entity)
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

                lblPopMessage.Text = "OTP has been sent to your registered mobile no.";
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
            txtMobileNo.Text = string.Empty;
            hdnUserID.Value = string.Empty;
            hdnMobileNo.Value = string.Empty;
        }
        catch (Exception ex)
        {
            throw ex;
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