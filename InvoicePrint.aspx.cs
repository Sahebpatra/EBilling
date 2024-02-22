using EBilling;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class InvoicePrint : System.Web.UI.Page
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

            Int64 id = Convert.ToInt64(Request.QueryString["id"]);

            LoadInvoiveDetails(id);
        }
    }

    private void LoadInvoiveDetails(Int64 id)
    {
        CheckLogin();

        var imgURL= "~/update/record.png";
        InvoiceDetails helper = new InvoiceDetails();
        DataSet dataSet = helper.PrintInvoiceDetails(id);
       
        if (dataSet != null && dataSet.Tables.Count>0)
        {
            imgLogo.ImageUrl = Convert.ToString(dataSet.Tables[1].Rows[0]["Logo_Path"]) == "" ? imgURL : "~/public/Logo/"+Convert.ToString(dataSet.Tables[1].Rows[0]["Logo_Path"]);
            lblCompanyName.Text = Convert.ToString(dataSet.Tables[1].Rows[0]["cd_company_name"]);
            lblCompanyAddress.Text = Convert.ToString(dataSet.Tables[1].Rows[0]["cd_add1"]) +", "+ Convert.ToString(dataSet.Tables[1].Rows[0]["cd_add2"]);
            lblComapyPhoneNo.Text = Convert.ToString(dataSet.Tables[1].Rows[0]["cd_mob1"]);
            lblCompanyEmailId.Text = Convert.ToString(dataSet.Tables[1].Rows[0]["cd_mail_id"]);
            lblCompanyEwbsite.Text = Convert.ToString(dataSet.Tables[1].Rows[0]["cd_url"]);
            CustomarName.Text = Convert.ToString(dataSet.Tables[0].Rows[0]["Name"]);
            CustomarAddress.Text = Convert.ToString(dataSet.Tables[0].Rows[0]["Address"]);
            CustomarPHNo.Text = Convert.ToString(dataSet.Tables[0].Rows[0]["PhNo"]);
            CustomarEmail.Text = Convert.ToString(dataSet.Tables[0].Rows[0]["EmailId"]);

            grdInvoiceDetails.DataSource = dataSet.Tables[3];
            grdInvoiceDetails.DataBind();
        }
      
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