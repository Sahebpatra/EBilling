using EBilling;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebRegisterFrom : System.Web.UI.Page
{
    UserProfile userInfo = new UserProfile();
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckLogin();
        if (!IsPostBack)
        {
            Webgridview();
        }
    }
    private void Webgridview()
    {
        WebGridView_Class webGridView_Class = new WebGridView_Class();
        DataSet dataSet = new DataSet();
        dataSet = webGridView_Class.GetDataSetWebFrom(userInfo.Company_Id);

        GRDWebRegisterFrom.DataSource = dataSet.Tables[0];
        GRDWebRegisterFrom.DataBind();

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