using EBilling;
using EBilling.DataAccess;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;

public partial class User_Form_Access : System.Web.UI.Page
{
    UserProfile UserInfo = new UserProfile();
    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckLogin();
        AddAttribute();
        try
        {
            if (!IsPostBack)
            {
                populateUserGroupCode();
                populateUserID();
                populateAvlbForms();
                populateApplForms();
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendErrorToText(ex);
            string returnUrl = "~/ExceptionPage.aspx";
            Session[Constant.SessionKeys.ErrMessage] = ex.ToString();
            Response.Redirect(returnUrl);
        }
    }
    #endregion
    #region Custom Method
    private void AddAttribute()
    {
        btnSubmit.Attributes.Add("OnClick", "return ValidateUserFormAccess('" + ddlUsrGrp.ClientID + "','" + ddlUsrID.ClientID + "','" + lblErrorMessage.ClientID + "','" + btnSubmit.UniqueID + "');");
        //lnkBtnSubmit.OnClientClick = "showConfirmPopUp('fa fa-exclamation', 'Are you sure?', 'If you click confirm the record will be submitted. To cancel please press cancel button.', 'orange', 'modern', '" + lnkBtnSubmit.ClientID + "');";
    }
    private void CheckLogin()
    {
        if (Session[Constant.SessionKeys.UserInfo] != null)
        {
            UserInfo = (UserProfile)Session[Constant.SessionKeys.UserInfo];
        }
        else
        {
            Response.Redirect("~/", true);
        }
    }
    public void populateUserGroupCode()
    {
        UserProfileListClass helper = null;
         
        try
        {
            ddlUsrGrp.DataSource = null;
            ddlUsrGrp.DataBind();

            helper = new UserProfileListClass();
            DataSet ds = helper.GetUserGroupList();
            if ((ds != null && ds.Tables.Count > 0) && (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0))
            {
                ddlUsrGrp.DataSource = ds.Tables[0];
                ddlUsrGrp.DataTextField = "usp_group_desc";
                ddlUsrGrp.DataValueField = "usp_group_code";
                ddlUsrGrp.DataBind();
            }

            ddlUsrGrp.Items.Insert(0, new ListItem("Select", String.Empty));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void populateUserID()
    {
        try
        {
            ddlUsrID.Items.Clear();
            UserFormAccessClass helper = new UserFormAccessClass();
            DataSet UserIDSet = new DataSet();
            UserIDSet = helper.UserID_Get(ddlUsrGrp.SelectedValue);
            if ((!(UserIDSet == null) & UserIDSet.Tables.Count > 0 && !(UserIDSet.Tables[0] == null) && UserIDSet.Tables[0].Rows.Count > 0))
            {
                ddlUsrID.DataSource = UserIDSet.Tables[0];
                ddlUsrID.DataTextField = "usp_user_id";
                ddlUsrID.DataValueField = "usp_user_id";
                ddlUsrID.DataBind();
            }
            ddlUsrID.Items.Insert(0, new ListItem("All User", "All", true));
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendErrorToText(ex);
            string returnUrl = "~/ExceptionPage.aspx";
            Session[Constant.SessionKeys.ErrMessage] = ex.ToString();
            Response.Redirect(returnUrl);
        }
    }
    public void populateAvlbForms()
    {
        UserFormAccessClass ObjDocumentType = new UserFormAccessClass();
        DataSet UserFormsSet = new DataSet();
        UserFormsSet = ObjDocumentType.UserForms_Get(ddlUsrGrp.SelectedValue, ddlUsrID.SelectedValue);
        if ((!(UserFormsSet == null) && UserFormsSet.Tables.Count > 0 && !(UserFormsSet.Tables[0] == null)))
        {
            LstAvlbFrms.DataSource = UserFormsSet.Tables[0];
            LstAvlbFrms.DataTextField = "form_desc";
            LstAvlbFrms.DataValueField = "form_code";
            LstAvlbFrms.DataBind();
        }
    }
    public void populateApplForms()
    {
        LstApplFrms.Items.Clear();
        UserFormAccessClass ObjDocumentType = new UserFormAccessClass();
        DataSet UserFormSet = new DataSet();
        UserFormSet = ObjDocumentType.UserApplForms_Get(ddlUsrGrp.SelectedValue, ddlUsrID.SelectedValue);
        if ((!(UserFormSet == null) && UserFormSet.Tables.Count > 0 && !(UserFormSet.Tables[0] == null)))
        {
            LstApplFrms.DataSource = UserFormSet.Tables[0];
            LstApplFrms.DataTextField = "form_desc";
            LstApplFrms.DataValueField = "form_code";
            LstApplFrms.DataBind();
        }
    }
    #endregion
    #region Event Handler
    protected void btnRL_Click(object sender, System.EventArgs e)
    {
        List<ListItem> removeItemsList = new List<ListItem>();
        foreach (ListItem item in LstAvlbFrms.Items)
        {
            if (item.Selected == true)
                removeItemsList.Add(item);
        }
        foreach (ListItem listItem in removeItemsList)
        {
            LstAvlbFrms.Items.Remove(listItem);
            LstApplFrms.Items.Add(listItem);
        }
    }
    protected void btnLR_Click(object sender, System.EventArgs e)
    {
        List<ListItem> removeItemsList = new List<ListItem>();
        foreach (ListItem item in LstApplFrms.Items)
        {
            if (item.Selected == true)
                removeItemsList.Add(item);
        }
        foreach (ListItem listItem in removeItemsList)
        {
            LstApplFrms.Items.Remove(listItem);
            LstAvlbFrms.Items.Add(listItem);
        }
    }
    protected void ddlUsrGrp_SelectedIndexChanged(object sender, EventArgs e)
    {
        populateUserID();
        populateAvlbForms();
        populateApplForms();
    }
    protected void lnkBtnSubmit_Click(object sender, System.EventArgs e)
    {
        string groupcode = ddlUsrGrp.SelectedValue;
        string desc;
        string code;
        SqlConnection sqlConn = null;
        SqlTransaction sqlTrans = null;
        try
        {
            string successErrorMsg = "";
            if (string.IsNullOrEmpty(groupcode))
            {
                successErrorMsg = "Please select user group.";
                ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "Script", "ShowSuccessMessage('" + successErrorMsg + "');", true);
                return;
            }
            // if (string.IsNullOrEmpty(userid))
            if (ddlUsrID.SelectedIndex <= -1)
            {
                successErrorMsg = "Please select user.";
                ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "Script", "ShowSuccessMessage('" + successErrorMsg + "');", true);
                return;
            }
            if (LstApplFrms.Items.Count == 0)
            {
                successErrorMsg = "Please add some applicable forms.";
                ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "Script", "ShowSuccessMessage('" + successErrorMsg + "');", true);
                return;
            }

            int i;
            int Numrowsaffected = 0;
            int Numrowsdeleted;
            UserFormAccessClass UsrFrmDel = new UserFormAccessClass();
            if (ddlUsrID.SelectedIndex == 0)
            {
                Numrowsdeleted = UsrFrmDel.DeleteUsrFrm(groupcode, ddlUsrID.SelectedValue);
                for (i = 0; i <= LstApplFrms.Items.Count - 1; i++)
                {
                    desc = LstApplFrms.Items[i].Text;
                    code = LstApplFrms.Items[i].Value;

                    UserFormAccessClass UsrFrmAdd = new UserFormAccessClass();
                    Numrowsaffected = UsrFrmAdd.InsertUsrFrm(desc, code, UserInfo.UserId, groupcode, ddlUsrID.SelectedValue);
                    if (!(Numrowsaffected > 0))
                    {
                        if (sqlTrans != null)
                        {
                            sqlTrans.Rollback();
                        }
                        successErrorMsg = "Error occured. Contact administrator.";
                        ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "Script", "ShowSuccessMessage('" + successErrorMsg + "');", true);
                    }
                }
            }
            else
            {
                foreach (ListItem item in ddlUsrID.Items)
                {
                    if (item.Selected)
                    {
                        Numrowsdeleted = UsrFrmDel.DeleteUsrFrm(groupcode, item.Value);
                        for (i = 0; i <= LstApplFrms.Items.Count - 1; i++)
                        {
                            desc = LstApplFrms.Items[i].Text;
                            code = LstApplFrms.Items[i].Value;

                            UserFormAccessClass UsrFrmAdd = new UserFormAccessClass();
                            Numrowsaffected = UsrFrmAdd.InsertUsrFrm(desc, code, UserInfo.UserId, groupcode, item.Value);
                            if (!(Numrowsaffected > 0))
                            {
                                if (sqlTrans != null)
                                {
                                    sqlTrans.Rollback();
                                }
                                successErrorMsg = "Error occured. Contact administrator.";
                                ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "Script", "ShowSuccessMessage('" + successErrorMsg + "');", true);
                            }
                        }
                    }
                }
            }

            if (sqlTrans != null)
            {
                sqlTrans.Commit();
            }
            successErrorMsg = "Record saved successfully.";
            ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "Script", "ShowSuccessMessage('" + successErrorMsg + "');", true);
        }
        catch (Exception ex)
        {
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
        }
    }
    protected void lnkBtnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Dashboard.aspx");
    }
    protected void lstUserid_SelectedIndexChanged(object sender, EventArgs e)
    {
        populateApplForms();
    }
    #endregion
}