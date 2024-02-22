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

public partial class StorePage : System.Web.UI.Page
{
    public object StorePhoto { get; private set; }
    UserProfile userInfo = new UserProfile();
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckLogin();
        if (!IsPostBack)
        {
            GetOrgDetails();
            GetPageName();
            GetPageSection();
            StorePageListView();
        }
    }
    private void StorePageListView()
    {
        StorePageSclect storepageGridView_Class = new StorePageSclect();
        DataSet dataSet = new DataSet();
        dataSet = storepageGridView_Class.StorepageGridView(userInfo.Company_Id);

        GrdStorePage.DataSource = dataSet.Tables[0];
        GrdStorePage.DataBind();
    }
    private void GetPageSection()
    {
        DataSet ds = new DataSet();
        StorePageSclect Obj = new StorePageSclect();
        ds = Obj.getPageSectionDetails();
        if ((!(ds.Tables[0] == null) && ds.Tables[0].Rows.Count > 0))
        {
            ddlSectionName.DataSource = ds.Tables[0];
            ddlSectionName.DataTextField = "TSectionName";
            ddlSectionName.DataBind();
            ddlSectionName.Items.Insert(0, new ListItem(Constant.Common.Selec, string.Empty, true));
        }
        else
            ddlSectionName.Items.Insert(0, new ListItem(Constant.Common.Selec, string.Empty, true));
    }
    private void GetPageName()
    {

        DataSet ds = new DataSet();
        StorePageSclect Obj = new StorePageSclect();
        ds = Obj.getPageNameDetailslist();
        if ((!(ds.Tables[0] == null) && ds.Tables[0].Rows.Count > 0))
        {
            ddlPageName.DataSource = ds.Tables[0];
            ddlPageName.DataTextField = "TPageName";
            ddlPageName.DataBind();
            ddlPageName.Items.Insert(0, new ListItem(Constant.Common.Selec, string.Empty, true));
        }
        else
            ddlPageName.Items.Insert(0, new ListItem(Constant.Common.Selec, string.Empty, true));
    }
    private void GetOrgDetails()
    {

        // CheckLogin();
        DataSet ds = new DataSet();
        StorePageSclect Obj = new StorePageSclect();
        ds = Obj.getOrgDetailslist();
        if ((!(ds.Tables[0] == null) && ds.Tables[0].Rows.Count > 0))
        {
            ddlorgname.DataSource = ds.Tables[0];
            ddlorgname.DataTextField = "TCompanyName";
            ddlorgname.DataValueField = "ID";
            ddlorgname.DataBind();
            //ddlorgname.Items.Insert(0, new ListItem(Constant.Common.Selec, string.Empty, true));
            ddlorgname.SelectedValue=Convert.ToString(userInfo.Company_Id);
            ddlorgname.Enabled = false;
        }
        else
            ddlorgname.Items.Insert(0, new ListItem(Constant.Common.Selec, string.Empty, true));

    }
    protected void btnDelete(object sender, EventArgs e)
    {
        SqlConnection sqlConn = null;
        SqlTransaction sqlTrans = null;
        StorePageSclect helper = null;
        sqlConn = (SqlConnection)DBFactory.GetHelper().OpenConnection();

        LinkButton btn = sender as LinkButton;
        GridViewRow row = btn.NamingContainer as GridViewRow;
        Int64 StoreId = Convert.ToInt64(Convert.ToString(GrdStorePage.DataKeys[row.RowIndex].Values[0]));

        if (StoreId > 0)
        {
            helper = new StorePageSclect();
            var returnResult = helper.DeleteStoreDetails(StoreId, sqlConn, sqlTrans);
            StorePageListView();
        }
    }
    protected void Store_page_button(object sender, EventArgs e)
    {
        SqlConnection sqlConn = null;
        SqlTransaction sqlTrans = null;
        StorePageSclect helper = null;
        sqlConn = (SqlConnection)DBFactory.GetHelper().OpenConnection();
        sqlTrans = sqlConn.BeginTransaction();
        try
        {
            string OrgName = ddlorgname.SelectedValue;
            string PageName = ddlPageName.SelectedValue;
            string SectionName = ddlSectionName.SelectedValue;
            string ProductName = txtProductName.Text.Trim();
            string ProductPrice = txtProductPrice.Text.Trim();
            string BuyNowLink = txtBuyNowLink.Text.Trim();
            string ProductDescription = txtProductDescription.Text.Trim();
            string fileName = string.Empty;

            //string fileName = string.Empty;
            if (FUProductPhoto.HasFile)
            {
                if (FUProductPhoto != null && FUProductPhoto.PostedFile != null && FUProductPhoto.PostedFile.ContentLength > 0)
                {
                    string abspath = ConfigurationManager.AppSettings["UPLOAD_DOCS_FOLDER_ABS_PATH"];
                    string DateString = DateTime.Now.ToString("dd-MM-yyyy_HH-mm");
                    string saveLocation = string.Empty;
                    fileName = DateString + '_' + FUProductPhoto.PostedFile.FileName;
                    saveLocation = abspath + "\\" + fileName;
                    string savefolder = abspath + "\\" + "";
                    if (!Directory.Exists(savefolder))
                    {
                        Directory.CreateDirectory(savefolder);
                    }
                    FUProductPhoto.SaveAs(saveLocation);

                    string abcd = fileName;

                }
            }

            ///string UploadProduct = FUProductPhoto.ToString();
            if (OrgName == "")
            {
                Response.Write("<script>alert('Sclect Your Org Name');</script>");
                return;
            }
            if (PageName == "")
            {
                Response.Write("<script>alert('Sclect Page Name');</script>");
                return;
            }
            if (SectionName == "")
            {
                Response.Write("<script>alert('Sclect Section Name');</script>");
                return;
            }
            if (ProductName == "")
            {
                Response.Write("<script>alert('Enter Product Name');</script>");
                return;
            }
            if (ProductPrice == "")
            {
                Response.Write("<script>alert('Enter Product Price');</script>");
                return;
            }
            if (BuyNowLink == "")
            {
                Response.Write("<script>alert('Enter Link');</script>");
                return;
            }
            if (ProductDescription == "")
            {
                Response.Write("<script>alert('Enter Product Description');</script>");
                return;
            }
            if (fileName == "")
            {
                Response.Write("<script>alert('Upload Photo');</script>");
                return;
            }

            helper = new StorePageSclect();

            var returnResult = helper.NewStorePageSclect(OrgName, PageName, SectionName, ProductName, ProductPrice, BuyNowLink, ProductDescription, fileName, userInfo.Company_Id, sqlConn, sqlTrans);
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
                Response.Redirect("/DashBoard.aspx");
            }
        }

        ddlorgname.Text = "";
        ddlPageName.Text = "";
        ddlSectionName.Text = "";
        txtProductName.Text = "";
        txtProductPrice.Text = "";
        txtBuyNowLink.Text = "";
        txtProductDescription.Text = "";
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