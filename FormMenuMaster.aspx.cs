using EBilling;
using EBilling.DataAccess;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FormMenuMaster : System.Web.UI.Page
{
    UserProfile userInfo = new UserProfile();

    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckLogin();
        //ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "Script", "ShowSuccessMessage('Hello');", true);
        try
        {
            if (!IsPostBack)
            {
                PopulateParent(ddlParentForm);
                BindGrid();
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

    #region Event Handler
    protected void ddlParentForm_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindGrid();
    }
    protected void gvFormList_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
    {
        gvFormList.EditIndex = -1;
        BindGrid();
    }
    protected void gvFormList_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Submit")
        {
            CheckLogin();

            Button btnUpdate =( gvFormList.FooterRow.FindControl("btnSubmit") as Button);
            TextBox txtFrmName =( gvFormList.FooterRow.FindControl("txtFrmName_ftr") as TextBox);
            TextBox txtFrmLink =( gvFormList.FooterRow.FindControl("txtFrmLink_ftr") as TextBox);
            DropDownList ddlParent =( gvFormList.FooterRow.FindControl("ddlParent_ftr") as DropDownList);
            TextBox txtFrmSeq =( gvFormList.FooterRow.FindControl("txtFrmSeq_ftr") as TextBox);
            DropDownList ddlActive = (gvFormList.FooterRow.FindControl("ddlActive_ftr") as DropDownList);
            //SqlConnection sqlConn = null/* TODO Change to default(_) if this is not a reference type */;
            //SqlTransaction sqlTrans = null/* TODO Change to default(_) if this is not a reference type */;
            //sqlConn = (SqlConnection)DBFactory.GetHelper().OpenConnection();
            //sqlTrans = sqlConn.BeginTransaction();
            int numberroweffect = 0;
            try
            {
                FormMenuMasterEntity entity = new FormMenuMasterEntity();
                FormMenuMasterClass obj = new FormMenuMasterClass();
                entity.fmm_name = txtFrmName.Text.Trim().ToString();
                entity.fmm_link = txtFrmLink.Text.Trim();
                entity.fmm_parent_id = Convert.ToInt32(ddlParent.SelectedValue);
                entity.fmm_sequence = Convert.ToInt32(txtFrmSeq.Text.Trim());
                entity.active = ddlActive.SelectedValue;
                entity.created_user = userInfo.UserId;
                numberroweffect = obj.InsertFormMenu(entity);
                if (numberroweffect > 0)
                {
                    //sqlTrans.Commit();
                    lblPopMessage.Text = "Submited Successfully.";
                }
                else
                {
                    //sqlTrans.Rollback();
                    lblPopMessage.Text = "Some Error Occured.";
                }
            }
            catch (Exception ex)
            {
                // Throw ex
                lblPopMessage.Text =ex.ToString();
            }
            finally
            {
                //sqlConn.Close();
                gvFormList.EditIndex = -1;
                BindGrid();
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
            }
        }
    }
    protected void gvFormList_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView rowview = (DataRowView)e.Row.DataItem;
            Button btnEdit = (e.Row.FindControl("btnEdit") as Button);
            Button btnUpdate = (e.Row.FindControl("btnUpdate") as Button);
            Button btnCancel = (e.Row.FindControl("btnCancel") as Button);
            TextBox txtFrmName = (e.Row.FindControl("txtFrmName") as TextBox);
            TextBox txtFrmLink = (e.Row.FindControl("txtFrmLink") as TextBox);
            DropDownList ddlParent = (e.Row.FindControl("ddlParent") as DropDownList);
            TextBox txtFrmSeq = (e.Row.FindControl("txtFrmSeq") as TextBox);
            DropDownList ddlActive = (e.Row.FindControl("ddlActive") as DropDownList);
            if (ddlActive != null)
            {
                PopulateParent(ddlParent);
                ddlParent.SelectedValue = rowview["fmm_parent_id"].ToString();
                ddlActive.SelectedValue = rowview["active"].ToString();
                txtFrmSeq.Attributes.Add("onkeypress", "KeyPressNumeric()");
                btnUpdate.Attributes.Add("onclick", "return ValidateSubmit('"
                                                                        + txtFrmName.ClientID + "','"
                                                                        + txtFrmLink.ClientID + "','"
                                                                        + ddlParent.ClientID + "','"
                                                                        + txtFrmSeq.ClientID + "','"
                                                                        + btnUpdate.ClientID + "','"
                                                                        + lblErrorMessage.ClientID + "') ");
            }
        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblSrl_ftr = (e.Row.FindControl("lblSrl_ftr") as Label);
            lblSrl_ftr.Text =(gvFormList.Rows.Count + 1).ToString();
            Button btnUpdate = (e.Row.FindControl("btnSubmit") as Button);
            TextBox txtFrmName = (e.Row.FindControl("txtFrmName_ftr") as TextBox);
            TextBox txtFrmLink = (e.Row.FindControl("txtFrmLink_ftr") as TextBox);
            DropDownList ddlParent = (e.Row.FindControl("ddlParent_ftr") as DropDownList);
            TextBox txtFrmSeq = (e.Row.FindControl("txtFrmSeq_ftr") as TextBox);
            DropDownList ddlActive = (e.Row.FindControl("ddlActive_ftr") as DropDownList);
            PopulateParent(ddlParent);
            txtFrmSeq.Attributes.Add("onkeypress", "KeyPressNumeric()");
            btnUpdate.Attributes.Add("onclick", "return ValidateSubmit('"
                                                              + txtFrmName.ClientID + "','"
                                                              + txtFrmLink.ClientID + "','"
                                                              + ddlParent.ClientID + "','"
                                                              + txtFrmSeq.ClientID + "','"
                                                              + btnUpdate.ClientID + "','"
                                                              + lblErrorMessage.ClientID + "') ");
        }
    }
    protected void gvFormList_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        gvFormList.EditIndex = e.NewEditIndex;
        BindGrid();
    }
    protected void gvFormList_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
    {
        CheckLogin();
        int Index = gvFormList.EditIndex;

        Button btnUpdate =( gvFormList.Rows[Index].FindControl("btnUpdate") as Button);
        TextBox txtFrmName = (gvFormList.Rows[Index].FindControl("txtFrmName") as TextBox);
        TextBox txtFrmLink = (gvFormList.Rows[Index].FindControl("txtFrmLink") as TextBox);
        DropDownList ddlParent = (gvFormList.Rows[Index].FindControl("ddlParent") as DropDownList);
        TextBox txtFrmSeq = (gvFormList.Rows[Index].FindControl("txtFrmSeq") as TextBox);
        DropDownList ddlActive = (gvFormList.Rows[Index].FindControl("ddlActive") as DropDownList);
        HiddenField hdnId = (gvFormList.Rows[Index].FindControl("hdnId") as HiddenField);
        //SqlConnection sqlConn = null/* TODO Change to default(_) if this is not a reference type */;
        //SqlTransaction sqlTrans = null/* TODO Change to default(_) if this is not a reference type */;
        //sqlConn = DBFactory.GetHelper.OpenConnection();
        //sqlTrans = sqlConn.BeginTransaction();
        int numberroweffect = 0;
        try
        {
            FormMenuMasterEntity entity = new FormMenuMasterEntity();
            FormMenuMasterClass obj = new FormMenuMasterClass();
            entity.fmm_id = Convert.ToInt32(hdnId.Value);
            entity.fmm_name = txtFrmName.Text.Trim();
            entity.fmm_link = txtFrmLink.Text.Trim();
            entity.fmm_parent_id = Convert.ToInt32(ddlParent.SelectedValue);
            entity.fmm_sequence = Convert.ToInt32(txtFrmSeq.Text.Trim());
            entity.active = ddlActive.SelectedValue;
            entity.created_user = userInfo.UserId;
            numberroweffect = obj.UpdateFormMenu(entity);
            if (numberroweffect > 0)
            {
                //sqlTrans.Commit();
                lblPopMessage.Text = "Submited Successfully.";
            }
            else
            {
                //sqlTrans.Rollback();
                lblPopMessage.Text = "Some Error Occured.";
            }
        }
        catch (Exception ex)
        {
            // Throw ex
            lblPopMessage.Text = ex.ToString();
        }
        finally
        {
            //sqlConn.Close();
            gvFormList.EditIndex = -1;
            BindGrid();
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
        }
    }
    protected void gvUserProfileList_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
    {
        gvFormList.PageIndex = e.NewPageIndex;
        BindGrid();
    }
    protected void gvFormList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvFormList.PageIndex = e.NewPageIndex;
        BindGrid();
    }
    #endregion

    #region Custom Method
    private void CheckLogin()
    {
        if (Session[Constant.SessionKeys.UserInfo] != null)
        {
            userInfo = (UserProfile)Session[Constant.SessionKeys.UserInfo];
        }
        else
        {
            Response.Redirect("~/Login.aspx");
        }
    }
    private void PopulateParent(DropDownList ddl)
    {
        FormMenuMasterClass obj = new FormMenuMasterClass();
        DataSet ds;
        try
        {
            ds = obj.GetParentFormList();
            if ((!(ds == null) && ds.Tables.Count > 0))
            {
                if ((!(ds.Tables[0] == null) && ds.Tables[0].Rows.Count > 0))
                {
                    ddl.DataSource = ds.Tables[0];
                    ddl.DataTextField = "fmm_name";
                    ddl.DataValueField = "fmm_id";
                    ddl.DataBind();
                    ddl.Items.Insert(0, new ListItem(Constant.Common.Selec, string.Empty, true));
                }
                else
                    ddl.Items.Insert(0, new ListItem(Constant.Common.Selec, string.Empty, true));
            }
        }
        catch (Exception ex)
        {
            string returnUrl = "~/ExceptionPage.aspx";
            Session[Constant.SessionKeys.ErrMessage] =ex.ToString();
            Response.Redirect(returnUrl);
        }
    }

    public void BindGrid()
    {
        CheckLogin();
        DataSet ds = new DataSet();
        FormMenuMasterClass Obj = new FormMenuMasterClass();
        string parentId = string.Empty;
        if (ddlParentForm.SelectedValue != string.Empty)
            parentId = ddlParentForm.SelectedValue;
        ds = Obj.GetFormMenuList(parentId);

        if ((!(ds == null) && ds.Tables.Count > 0 && !(ds.Tables[0] == null) && ds.Tables[0].Rows.Count > 0))
        {
            gvFormList.DataSource = ds;
            gvFormList.DataBind();
        }
        else
        {
            gvFormList.DataSource = ds;
            gvFormList.DataBind();
        }
    }
    #endregion
}