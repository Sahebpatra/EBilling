using EBilling;
using EBilling.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserEntry : System.Web.UI.Page
{
    UserProfile userInfo = new UserProfile();
    DataTable dtItems = new DataTable();
    private object helper;
    private object sqlConn;
    private readonly object sqlTrans;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int CompanyId = 0;
            if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
            {
                CompanyId = Convert.ToInt32(Request.QueryString["id"]);
                hdnCompanyId.Value = Convert.ToString(CompanyId);
            }
            CompanyRegisterGrd(CompanyId);
            CheckLogin();
        }
    }

    private void CompanyRegisterGrd(int CompanyId)
    {
        CompanyRegistrationClass contact_Page_Class = new CompanyRegistrationClass();
        DataSet dataSet = new DataSet();
        dataSet = contact_Page_Class.GetNewUserListList(CompanyId);

        Grd_UserList.DataSource = dataSet.Tables[0];
        Grd_UserList.DataBind();
    }

    protected void btnUserEnty_Click(object sender, EventArgs e)
    {
        CheckLogin();
        SqlConnection sqlConn = null;
        SqlTransaction sqlTrans = null;
        CompanyRegistrationClass helper = null;
        sqlConn = (SqlConnection)DBFactory.GetHelper().OpenConnection();
        string fileName = FileUpload1.FileName;
        string fileExtension = Path.GetExtension(fileName);
        var UploadPath = "public/Signature/";
        string[] acceptedFileTypes = { ".jpg", ".jpeg" };
        var fileNamaWithExtension = "";
        sqlTrans = sqlConn.BeginTransaction();
        try
        {
            if (string.IsNullOrEmpty(txtUserId.Text.Trim()))
            {
                Response.Write("<script>alert('Please Enter User Id');</script>");
                return;
            }
            if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                Response.Write("<script>alert('Enter Password');</script>");
                return;
            }
            if (string.IsNullOrEmpty(txtFirstName.Text.Trim()))
            {
                Response.Write("<script>alert('Enter First Name');</script>");
                return;
            }
            if (string.IsNullOrEmpty(txtLastName.Text.Trim()))
            {
                Response.Write("<script>alert('Enter Last Name');</script>");
                return;
            }
            if (!FileUpload1.HasFile)
            {
                lblPopMessage.Text = "Please upload a Logo.";
                return;
            }
            else
            {
                fileNamaWithExtension = UploadPath + fileName;
                if (File.Exists(Server.MapPath(fileNamaWithExtension)))
                {
                    Response.Write("<script>alert('File already exists on the server.');</script>");
                    return;
                }
                FileUpload1.SaveAs(Server.MapPath(fileNamaWithExtension));
            }
                helper = new CompanyRegistrationClass();
            DataSet dataSet= helper.SaveNewUserDEtails(txtUserId.Text.Trim(), txtPassword.Text.Trim(), txtFirstName.Text.Trim(), txtLastName.Text.Trim(), userInfo.UserId, Convert.ToInt32(hdnCompanyId.Value), fileName);
            if (dataSet.Tables[0].Rows.Count > 0 && Convert.ToInt32(dataSet.Tables[0].Rows[0][0])==1)
            {
                lblPopMessage.Text = "User Save successfully";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
            }
            else if (dataSet.Tables[0].Rows.Count > 0 && Convert.ToInt32(dataSet.Tables[0].Rows[0][0]) == 2)
            {
                lblPopMessage.Text = "User Already Exists. Please check with another username";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
            }
            else
            {
                lblPopMessage.Text = "Something Going Wrong. Please contact to Administrator";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (sqlConn != null)
            {
                sqlTrans.Commit();
                sqlConn.Close();
            }
        }

        CompanyRegisterGrd(Convert.ToInt32(hdnCompanyId.Value));
    }


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
}