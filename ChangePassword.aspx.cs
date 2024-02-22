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

public partial class ChangePassword : System.Web.UI.Page
{
    UserProfile UserInfo = new UserProfile();
    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            CheckLogin();
            AddAttribute();
            if (!IsPostBack)
            {
                ModalPopupExtenderMessage.Hide();
            }
        }
        catch (Exception ex) {
            ExceptionLogging.SendErrorToText(ex);
        }       
    }
    #endregion
    #region Custom Method
    private void CheckLogin()
    {
        if (Session[Constant.SessionKeys.UserInfo] != null)
        {
            UserInfo = (UserProfile)Session[Constant.SessionKeys.UserInfo];
        }
        else
        {
            Response.Redirect("~/Login.aspx", true);
        }
    }
    private void AddAttribute()
    {
        lnkbtnChangePassword.Attributes.Add("OnClick", "return ValidateChangePassSubmit('" + txtOldPassword.ClientID + "','" + txtNewPassword.ClientID + "','" + txtConfirmPassword.ClientID + "','" + lblValidationMessage.ClientID + "','" + lnkbtnChangePassword.UniqueID + "');");
    }
    #endregion
    public void Clear()
    {
        txtOldPassword.Text = string.Empty;
        txtNewPassword.Text = string.Empty;
        txtConfirmPassword.Text = string.Empty;
    }
    #region Event Handler 
    protected void lnkbtnChangePassword_Click(object sender, EventArgs e)
    {
        SqlConnection sqlConn = null;
        SqlTransaction sqlTrans = null;
        CommonClass helper = null;
        string successErrorMsg = string.Empty;
        try
        {
            if (txtNewPassword.Text.Trim() != txtConfirmPassword.Text.Trim())
            {
                successErrorMsg = "New password and confirm password should be same.";
                //ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "Script", "ShowSuccessMessage('" + successErrorMsg + "');", true);
                lblPopMessage.Text = successErrorMsg;
                lblPopMessage.ForeColor = System.Drawing.Color.Red;
                lblPopMessage.Font.Bold = true;
                return;
            }

            if (!string.IsNullOrEmpty(txtOldPassword.Text) && !string.IsNullOrEmpty(txtNewPassword.Text) && !string.IsNullOrEmpty(txtConfirmPassword.Text))
            {
                sqlConn = (SqlConnection)DBFactory.GetHelper().OpenConnection();
                sqlTrans = sqlConn.BeginTransaction();

                helper = new CommonClass();
                var returnResult = helper.UpdatePassword(UserInfo.UserId, txtOldPassword.Text.Trim(), txtNewPassword.Text.Trim(), sqlConn,sqlTrans);
                if (returnResult == -1)
                {
                    sqlTrans.Rollback();
                    successErrorMsg = "You have entered wrong password.";
                    //ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "Script", "ShowSuccessMessage('" + successErrorMsg + "');", true);
                    lblPopMessage.Text = successErrorMsg;
                    lblPopMessage.ForeColor = System.Drawing.Color.Red;
                    lblPopMessage.Font.Bold = true;
                    return;
                }
                else if (returnResult == 0)
                {
                    sqlTrans.Rollback();
                    successErrorMsg = "Invalid password";
                    lblPopMessage.Text = successErrorMsg;
                    lblPopMessage.ForeColor = System.Drawing.Color.Red;
                    lblPopMessage.Font.Bold = true;
                    //ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "Script", "ShowSuccessMessage('" + successErrorMsg + "');", true);

                    return;
                }

                sqlTrans.Commit();
                Clear();
                successErrorMsg = "Password changed successfully.";
                //ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "Script", "ShowSuccessMessage('" + successErrorMsg + "');", true);
                lblPopMessage.Text = successErrorMsg;
                lblPopMessage.ForeColor = System.Drawing.Color.Green;
                lblPopMessage.Font.Bold = true;
                Response.Redirect("~/Logout.aspx", false);
            }
            else
            {
                successErrorMsg = "Required fields cannot be blank.";
                //ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "Script", "ShowSuccessMessage('" + successErrorMsg + "');", true);
                lblPopMessage.Text = successErrorMsg;
                lblPopMessage.ForeColor = System.Drawing.Color.Red;
                lblPopMessage.Font.Bold = true;
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendErrorToText(ex);
            if (sqlTrans != null)
            {
                sqlTrans.Rollback();
            }
            ExceptionLogging.SendErrorToText(ex);
            string returnUrl = "~/ExceptionPage.aspx";
            Session[Constant.SessionKeys.ErrMessage] = ex.ToString();
            Response.Redirect(returnUrl);
        }
        finally
        {
            if (sqlConn != null)
            {
                sqlConn.Close();
            }
            ModalPopupExtenderMessage.Show();            
        }
    }
    protected void btnModalok_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Logout.aspx", false);
    }
    #endregion
}