using EBilling;
using System;
using System.Drawing;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using System.Configuration;
public partial class Login : System.Web.UI.Page
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
                txtbxUserId.Focus();
                if (Request.Cookies["userid"] != null)
                {
                    txtbxUserId.Text = Request.Cookies["userid"].Value;
                }
                if (Request.Cookies["pwd"] != null)
                {
                    txtbxUserId.Attributes.Add("value", Request.Cookies["pwd"].Value);
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion
    #region Event Handler
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            if (!IsRefresh)
            {
                if (ValidateData())
                {
                    GetUserDetail();
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion

    #region Custom Method
    private void AddAttribute()
    {
        try
        {
            btnLogin.OnClientClick = "return ValidateDetails('" + txtbxUserId.ClientID + "','" + txtbxUserPassword.ClientID + "','" + lblMessage.ClientID + "','" + btnLogin.ClientID + "');";
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private bool ValidateData()
    {
        try
        {
            if (string.IsNullOrEmpty(txtbxUserId.Text.Trim()))
            {
                lblMessage.Text = "Please provide valid user name!";
                lblMessage.Visible = true;
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.BorderColor = System.Drawing.Color.Red;
                txtbxUserId.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtbxUserPassword.Text.Trim()))
            {
                lblMessage.Text = "Please provide valid password!";
                lblMessage.Visible = true;
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.BorderColor = System.Drawing.Color.Red;
                txtbxUserPassword.Focus();
                return false;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return true;
    }
    private void GetUserDetail()
    {
        try
        {
            UserProfile userInfo = null;
            FormsAuthentication.Initialize();
            UserProfileClass userDetailsObject = new UserProfileClass();
            userInfo = userDetailsObject.LoginUserDetails(txtbxUserId.Text.Trim(), txtbxUserPassword.Text.Trim());
            if (userInfo == null)
            {
                //lblValidationMessage.Text = Constant.ErrorMessages.InvalidLoginMessage;
                //lblValidationMessage.ForeColor = System.Drawing.Color.Red;
                //lblValidationMessage.BorderColor = Color.Red;
                //lblValidationMessage.Visible = true;
                //ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "Script", "LoginShowErrorMessage('" + Constant.ErrorMessages.InvalidLoginMessage + "');", true);
                lblMessage.Text = Constant.ErrorMessages.InvalidLoginMessage;
                divAlert.Attributes.Add("style", "block");
                return;
            }

            Session[Constant.SessionKeys.UserInfo] = userInfo;
            //roles = userInfo.Role
            if (string.Compare(userInfo.Active, Constant.Common.InActiveStatus, StringComparison.CurrentCultureIgnoreCase) == 0)
            {
                //lblValidationMessage.Text = Constant.ErrorMessages.UserNotActiveMessage;
                //lblValidationMessage.ForeColor = System.Drawing.Color.Red;
                //lblValidationMessage.BorderColor = Color.Red;
                //lblValidationMessage.Visible = true;
                // ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "Script", "LoginShowErrorMessage('" + Constant.ErrorMessages.UserNotActiveMessage + "');", true);
                lblMessage.Text = Constant.ErrorMessages.UserNotActiveMessage;
                divAlert.Attributes.Add("style", "block");
                return;
            }
            else
            {
                //Create a new ticket used for authentication
                //Dim roleSet As System.Data.DataSet = userDetailsObject.GetRolePrivileges(userInfo.PartyID)
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, txtbxUserId.Text.Trim(), DateTime.Now, DateTime.Now.AddMinutes(720), false, "Roles", FormsAuthentication.FormsCookiePath);
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
                Response.Cookies["userid"].Value = txtbxUserId.Text;
                Response.Cookies["pwd"].Value = txtbxUserPassword.Text;
                Response.Cookies["usertype"].Expires = DateTime.Now.AddDays(15);
                Response.Cookies["userid"].Expires = DateTime.Now.AddDays(15);
                Response.Cookies["pwd"].Expires = DateTime.Now.AddDays(15);
                //Redirect to requested URL, or homepage if no previous page requested
                string returnUrl = string.Empty;
                if (userInfo.usp_force_login_yn.ToString().Equals(Constant.Common.ActiveStatus))
                {
                    returnUrl = "~/ChangePassword.aspx";
                }
                else
                {
                    returnUrl = "~/DashBoard.aspx";
                }

                Response.Redirect(returnUrl, false);
            }
            ClearControl();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void ClearControl()
    {
        try
        {
            txtbxUserId.Text = string.Empty;
            txtbxUserPassword.Text = string.Empty;
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