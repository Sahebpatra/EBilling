using EBilling;
using EBilling.DataAccess;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ComplaintList : System.Web.UI.Page
{
    UserProfile userInfo = new UserProfile();

    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckLogin();
        try
        {
            if (!IsPostBack)
            {
                ControlSetting(false);
                PopulateComplaintType();
                PopulateComplaintStatus();
                PopulateComplaintDetailGrid();
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

    #region Event handler
    protected void lnkView_Click(object sender, EventArgs e)
    {
        try
        {
            string id = (sender as LinkButton).CommandArgument;
            if (userInfo.GroupCode.ToString().Equals("RESIDENTIAL"))
            {
                return;
            }
            Response.Redirect("ComplaintDetail.aspx?ComplaintId=" + Encryption.encrypt(id), false);
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendErrorToText(ex);
            string returnUrl = "~/ExceptionPage.aspx";
            Session[Constant.SessionKeys.ErrMessage] = ex.ToString();
            Response.Redirect(returnUrl);
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        PopulateComplaintDetailGrid();
        ControlSetting(false);
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ComplaintDetail.aspx", false);
    }
    protected void gvComplaintList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvComplaintList.PageIndex = e.NewPageIndex;
        PopulateComplaintDetailGrid();
    }
    protected void gvComplaintList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (userInfo.GroupCode.ToString().Equals("ASSOCIATE"))
        {
            return;
        }
        SqlConnection sqlConn = null;
        SqlTransaction sqlTrans = null;
        ComplaintClass helper = null;
        ComplaintEntity entity = null;
        int numberroweffect = 0;
        if ((e.CommandName == "StatusChange"))
        {
            try
            {
                string[] stringArr = e.CommandArgument.ToString().Split('|');
                sqlConn = (SqlConnection)DBFactory.GetHelper().OpenConnection();
                sqlTrans = sqlConn.BeginTransaction();
                entity = new ComplaintEntity();
                helper = new ComplaintClass();

                entity.cm_complaint_id = Convert.ToInt32(stringArr[0].ToString());

                entity.active = stringArr[1].ToString().Equals(Constant.Common.ActiveStatus) ? Constant.Common.InActiveStatus : Constant.Common.ActiveStatus;
                entity.created_user = userInfo.UserId;
                entity.user_action = Constant.UserAction.ACTIVE_INACTIVE.ToString();

                numberroweffect = helper.SetComplaintData(entity, sqlConn, sqlTrans);
                if (numberroweffect < 0)
                {
                    lblPopMessage.Text = "Failed! Some error occured during status changing!";
                    lblPopMessage.ForeColor = System.Drawing.Color.Red;
                    lblPopMessage.Font.Bold = true;
                    ModalPopupExtenderMessage.Show();
                    //ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "Script", "ShowDangerMessage('Failed! Some error occured during status changing!');", true);
                    sqlTrans.Rollback();
                    return;
                }

                sqlTrans.Commit();
                lblPopMessage.Text = "Complaint status has been changed successfully.";
                lblPopMessage.ForeColor = System.Drawing.Color.Green;
                lblPopMessage.Font.Bold = true;
                ModalPopupExtenderMessage.Show();
                //ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "Script", "ShowSuccessMessage('Complaint status has been changed successfully.');", true);
            }
            catch (Exception ex)
            {
                if (sqlTrans != null)
                {
                    sqlTrans.Rollback();
                }
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
                PopulateComplaintDetailGrid();
            }
        }
        else if ((e.CommandName == "LogEntry"))
        {
            string[] stringArr = e.CommandArgument.ToString().Split('|');
            if (stringArr == null)
            {
                return;
            }

            Response.Redirect("ComplaintLogDetail.aspx?ComplaintId=" + Encryption.encrypt(stringArr[0]), false);
        }
    }
    protected void lnkViewLog_Click(object sender, EventArgs e)
    {
        try
        {
            string id = (sender as LinkButton).CommandArgument;
            if (string.IsNullOrEmpty(id))
            {
                return;
            }

            PopulateComplaintLogList(Convert.ToInt64(id));
            lblComplaintLogHeader.Text = string.Format("Complaint Log History :: {0}", id);
            ControlSetting(true);
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendErrorToText(ex);
            string returnUrl = "~/ExceptionPage.aspx";
            Session[Constant.SessionKeys.ErrMessage] = ex.ToString();
            Response.Redirect(returnUrl);
        }
    }
    protected void lnkComplaintLog_Click(object sender, EventArgs e)
    {

    }
    protected void btnModalok_Click(object sender, EventArgs e)
    {
        ModalPopupExtenderMessage.Hide();
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

            Response.Redirect("~/Login.aspx", true);
        }
    }
    private void PopulateComplaintDetailGrid()
    {
        try
        {
            ComplaintEntity entity = new ComplaintEntity();
            entity.created_user = userInfo.UserId;
            entity.cm_complaint_type = ddlComplaintType.SelectedValue;
            entity.cm_complaint_status = ddlComplaintStatus.SelectedValue;
            entity.cm_complaint_desc = txtComplaitDescription.Text.Trim();
            entity.active = ddlActive.SelectedValue;

            ComplaintClass helper = new ComplaintClass();
            DataSet ds = helper.GetComplaintData(entity);
            if ((ds != null && ds.Tables.Count > 0) && (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0))
            {
                gvComplaintList.DataSource = ds.Tables[0];
                gvComplaintList.DataBind();
            }
            else
            {
                gvComplaintList.DataSource = null;
                gvComplaintList.DataBind();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    //private void PopulateComplaintType()
    //{
    //    try
    //    {
    //        Common helper = new Common();
    //        DataSet ds = helper.GetLovDetails(Constant.LovType.COMPLAINT_TYPE.ToString(), Constant.Common.ActiveStatus);
    //        if ((ds != null && ds.Tables.Count > 0) && (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0))
    //        {
    //            ddlComplaintType.DataSource = ds.Tables[0];
    //            ddlComplaintType.DataTextField = "lov_value";
    //            ddlComplaintType.DataValueField = "lov_code";
    //            ddlComplaintType.DataBind();
    //        }
    //        else
    //        {
    //            ddlComplaintType.DataSource = null;
    //            ddlComplaintType.DataBind();
    //        }
    //        ddlComplaintType.Items.Insert(0, new ListItem(Constant.Common.Selec, string.Empty, true));
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}
    private void PopulateComplaintType()
    {
        try
        {
            ComplaintClass helper = new ComplaintClass();
            DataSet ds = helper.GetComplaintType(string.Empty, Constant.Common.ActiveStatus);
            if ((ds != null && ds.Tables.Count > 0) && (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0))
            {
                ddlComplaintType.DataSource = ds.Tables[0];
                ddlComplaintType.DataTextField = "ct_complaint_type";
                ddlComplaintType.DataValueField = "ct_id";
                ddlComplaintType.DataBind();
            }
            else
            {
                ddlComplaintType.DataSource = null;
                ddlComplaintType.DataBind();
            }
            ddlComplaintType.Items.Insert(0, new ListItem(Constant.Common.Selec, string.Empty, true));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void PopulateComplaintStatus()
    {
        try
        {
            CommonClass helper = new CommonClass();
            DataSet ds = helper.GetLovDetails(Constant.LovType.COMPLAINT_STATUS.ToString(), Constant.Common.ActiveStatus);
            if ((ds != null && ds.Tables.Count > 0) && (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0))
            {
                ddlComplaintStatus.DataSource = ds.Tables[0];
                ddlComplaintStatus.DataTextField = "lov_value";
                ddlComplaintStatus.DataValueField = "lov_code";
                ddlComplaintStatus.DataBind();
            }
            else
            {
                ddlComplaintStatus.DataSource = null;
                ddlComplaintStatus.DataBind();
            }
            ddlComplaintStatus.Items.Insert(0, new ListItem(Constant.Common.Selec, string.Empty, true));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void ControlSetting(bool isVisible)
    {
        divComplaintLogHeader.Visible = isVisible;
        divComplaintLogDetail.Visible = isVisible;

    }
    private void PopulateComplaintLogList(long complaitId)
    {
        try
        {
            ComplaintLogEntity entity = new ComplaintLogEntity();
            entity.created_user = userInfo.UserId;
            entity.cl_complaint_id = complaitId;

            ComplaintLogClass helper = new ComplaintLogClass();
            DataSet ds = helper.GetComplaintLogData(entity);
            if ((ds != null && ds.Tables.Count > 0) && (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0))
            {
                gvComplaintLogList.DataSource = ds.Tables[0];
                gvComplaintLogList.DataBind();
            }
            else
            {
                gvComplaintLogList.DataSource = null;
                gvComplaintLogList.DataBind();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion
}