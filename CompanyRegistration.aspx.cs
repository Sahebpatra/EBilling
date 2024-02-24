using EBilling;
using EBilling.DataAccess;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CompanyRegistration : System.Web.UI.Page
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
            CheckLogin();
            getstatemasterdetails();
            //getcitmasterdetails();
            //Response.Write("<script>alert('Hello');</script>");
            CompanyRegisterGrd();
        }
    }

    private void CompanyRegisterGrd()
    {
        CompanyRegistrationClass contact_Page_Class = new CompanyRegistrationClass();
        DataSet dataSet = new DataSet();
     
            var UserId = Convert.ToString(userInfo.UserId);
      
        dataSet = contact_Page_Class.GetCompanyRegisterList(UserId);

        Grd_CompanyRegisterList.DataSource = dataSet.Tables[0];
        Grd_CompanyRegisterList.DataBind();
    }

    private void getcitmasterdetails(string statecode)
    {
        CheckLogin();
        DataSet ds = new DataSet();
        CompanyRegistrationClass Obj = new CompanyRegistrationClass();
        ds = Obj.CitylistList(statecode);
        if ((!(ds.Tables[0] == null) && ds.Tables[0].Rows.Count > 0))
        {
            ddlCitySclect.DataSource = ds.Tables[0];
            ddlCitySclect.DataTextField = "City";
            ddlCitySclect.DataValueField = "Id";
            ddlCitySclect.DataBind();
            ddlCitySclect.Items.Insert(0, new ListItem(Constant.Common.Selec, string.Empty, true));
        }
        else
            ddlCitySclect.Items.Insert(0, new ListItem(Constant.Common.Selec, string.Empty, true));
    }
    private void getstatemasterdetails()
    {
         CheckLogin();
        DataSet ds = new DataSet();
        CompanyRegistrationClass Obj = new CompanyRegistrationClass();
        ds = Obj.GetStatelistList();

        if ((!(ds.Tables[0] == null) && ds.Tables[0].Rows.Count > 0))
        {
            ddlstatename.DataSource = ds.Tables[0];
            ddlstatename.DataTextField = "state_name";
            ddlstatename.DataValueField = "state_code";
            ddlstatename.DataBind();
            ddlstatename.Items.Insert(0, new ListItem(Constant.Common.Selec, string.Empty, true));
        }
        else
            ddlstatename.Items.Insert(0, new ListItem(Constant.Common.Selec, string.Empty, true));
    }

    //protected void ddlstatename_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    getcitmasterdetails(Convert.ToInt32(ddlstatename.SelectedValue));
    //    //getcitmasterdetails(ddlstatename.SelectedValue);
    //}
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            getcitmasterdetails(ddlstatename.SelectedValue);
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendErrorToText(ex);
            //lblPopMessage.Text = Constant.ErrorMessages.GeneralError;
            //lblPopMessage.Font.Bold = true;
            //lblPopMessage.ForeColor = System.Drawing.Color.Red;
            //ModalPopupExtenderMessage.Show();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        CheckLogin();
        SqlConnection sqlConn = null;
        SqlTransaction sqlTrans = null;
        CompanyRegistrationClass helper = null;
        sqlConn = (SqlConnection)DBFactory.GetHelper().OpenConnection();
        sqlTrans = sqlConn.BeginTransaction();
        try
        {
            string CompanyName = txtcompanyname.Text.Trim();
            string MobbileNo = txtmobbileno.Text.Trim();
            string MailID = txtemail.Text.Trim();
            string WebsiteLink = txtwebsite.Text.Trim();
            string GstId = txtgstid.Text.Trim();
            string BusinessName = txtBusinessName.Text.Trim();
            string BusinessType = txtBusinessType.Text.Trim();
            string SclectCountry = ddlCountyName.SelectedValue;
            string SclectSate = ddlstatename.SelectedValue;
            string CityName = ddlCitySclect.SelectedValue;
            string PinCode = txtPinCode.Text.Trim();
            string FullAddress = txtFullAddress.Value.Trim();
            //string AlternativeAddress = txtAlternativeAddress.Value.Trim();
            string Nearby = txtNearby.Value.Trim();
            string fileName = FileUpload1.FileName;
            string fileExtension = Path.GetExtension(fileName);
            var UploadPath = "public/Logo/";
            string[] acceptedFileTypes = { ".jpg", ".jpeg" };
            var fileNamaWithExtension="";
            if (BusinessName == "")
            {
                Response.Write("<script>alert('Enter Your Business Name');</script>");
                return;
            }
            if (BusinessType == "")
            {
                Response.Write("<script>alert('Enter Your Business Type');</script>");
                return;
            }
            if (SclectCountry == "")
            {
                Response.Write("<script>alert('Enter Your Country');</script>");
                return;
            }
            if (SclectSate == "")
            {
                Response.Write("<script>alert('Enter Your Sate');</script>");
                return;
            }
            if (SclectSate == "")
            {
                Response.Write("<script>alert('Enter Your State');</script>");
                return;
            }
            if (CityName == "")
            {
                Response.Write("<script>alert('Enter City Name');</script>");
                return;
            }
            if (PinCode == "")
            {
                Response.Write("<script>alert('Enter Pin Code');</script>");
                return;
            }
            if (!FileUpload1.HasFile)
            {
                lblPopMessage.Text = "Please upload a Logo.";
                return;
            }
            else{
                fileNamaWithExtension = UploadPath + fileName;
                if (File.Exists(Server.MapPath(fileNamaWithExtension)))
                {
                    Response.Write("<script>alert('File already exists on the server.');</script>");
                    return;
                }
                //int fileSize = FileUpload1.PostedFile.ContentLength;
                //if (fileSize > 1024)
                //{
                //    lblPopMessage.Text = "Filesize of image is too large. Maximum file size permitted is 1 MB";
                //    return;
                ////}
                //if (acceptedFileTypes.Any(a=>a!= fileExtension.ToLower()))
                //{
                //    lblPopMessage.Text = "The file you are trying to upload is not a permitted file type!";
                //}

                FileUpload1.SaveAs(Server.MapPath(fileNamaWithExtension));
            }
            helper = new CompanyRegistrationClass();
            var returnResult = helper.NewCompanyRegistration(CompanyName, MobbileNo, MailID, WebsiteLink, GstId, BusinessName, BusinessType, SclectCountry, SclectSate, CityName, PinCode, FullAddress, Nearby, fileName, txtwebsite.Text,userInfo.UserId, sqlConn, sqlTrans);
            if (returnResult > 0)
            {
                lblPopMessage.Text = "Company Save successfully";

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

        txtcompanyname.Text = "";
        txtmobbileno.Text = "";
        txtemail.Text = "";
        txtwebsite.Text = "";
        txtgstid.Text = "";
        txtBusinessName.Text = "";
        txtBusinessType.Text = "";
        ddlCountyName.Text = "";
        ddlstatename.Text = "";
        ddlCitySclect.Text = "";
        txtPinCode.Text = "";
        txtFullAddress.InnerText = "";
        txtNearby.InnerText = "";
        CompanyRegisterGrd();
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