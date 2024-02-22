using EBilling;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Contact : System.Web.UI.Page
{
    UserProfile userInfo = new UserProfile();
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckLogin();
        if (!IsPostBack)
        {
            ContactPagegridview();
        }
    }

    private void ContactPagegridview()
    {
        contact_page_class contact_Page_Class = new contact_page_class();
        DataSet dataSet = new DataSet();
        dataSet = contact_Page_Class.GetContactWebFrom(userInfo.Company_Id);

        WebContactReport.DataSource = dataSet.Tables[0];
        WebContactReport.DataBind();
    }
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
}