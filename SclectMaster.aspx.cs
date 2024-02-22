using EBilling;
using EBilling.DataAccess;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SclectMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGridview();
        }

    }
    private void BindGridview()
    {
        //sectionMaster - dataSet  object name
        SectionMaster sectionMaster = new SectionMaster();
        DataSet dataSet = new DataSet();
        dataSet = sectionMaster.GetSectionDetails();

        GridViewDataSetReturn.DataSource = dataSet.Tables[0];
        GridViewDataSetReturn.DataBind();

    }
    //OLD START
    protected void btnScelctMaster_btn(object sender, EventArgs e)
    {
        SqlConnection sqlConn = null;
        SqlTransaction sqlTrans = null;
        SectionMaster helper = null;
        sqlConn = (SqlConnection)DBFactory.GetHelper().OpenConnection();
        sqlTrans = sqlConn.BeginTransaction();
        try
        {
            string OrgName = txtOrgName.Text.Trim();
            string SectionName = txtSectionName.Text.Trim();
            string PageName = txtPageName.Text.Trim();
            string WebsiteName = txtWebsiteName.Text.Trim();

            if (OrgName == "")
            {
                Response.Write("<script>alert('Enter Your Org Name');</script>");
                return;
            }
            if (SectionName == "")
            {
                Response.Write("<script>alert('Enter Your Section Name');</script>");
                return;
            }
            if (PageName == "")
            {
                Response.Write("<script>alert('Enter Your Page Name');</script>");
                return;
            }
            if (WebsiteName == "")
            {
                Response.Write("<script>alert('Enter Your Website Link');</script>");
                return;
            }
            helper = new SectionMaster();
            var returnResult = helper.NewsclectMaster(OrgName, SectionName, PageName, WebsiteName, sqlConn, sqlTrans);
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
            BindGridview();
        }

        txtOrgName.Text = "";
        txtSectionName.Text = "";
        txtPageName.Text = "";
        txtWebsiteName.Text = "";
    }
}