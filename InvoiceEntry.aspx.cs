using EBilling;
using EBilling.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class InvoiceEntry : System.Web.UI.Page
{
    UserProfile userInfo = new UserProfile();
    DataTable dtItems = new DataTable();
    private object helper;
    private object sqlConn;
    private readonly object sqlTrans;

    public int TotalSellingAmount { get; private set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Response.Write("<script>alert('Hello');</script>");
            PopulateInvoiceDetails();
            BindGrid();
        }
    }
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
        if (e.CommandName == "Cancel")
        {
            //CheckLogin();

            //Button btnUpdate = (gvFormList.FooterRow.FindControl("btnSubmit") as Button);
            //TextBox txtFrmName = (gvFormList.FooterRow.FindControl("txtFrmName_ftr") as TextBox);
            //TextBox txtFrmLink = (gvFormList.FooterRow.FindControl("txtFrmLink_ftr") as TextBox);
            //DropDownList ddlParent = (gvFormList.FooterRow.FindControl("ddlParent_ftr") as DropDownList);
            //TextBox txtFrmSeq = (gvFormList.FooterRow.FindControl("txtFrmSeq_ftr") as TextBox);
            //DropDownList ddlActive = (gvFormList.FooterRow.FindControl("ddlActive_ftr") as DropDownList);
            ////SqlConnection sqlConn = null/* TODO Change to default(_) if this is not a reference type */;
            ////SqlTransaction sqlTrans = null/* TODO Change to default(_) if this is not a reference type */;
            ////sqlConn = (SqlConnection)DBFactory.GetHelper().OpenConnection();
            ////sqlTrans = sqlConn.BeginTransaction();
            //int numberroweffect = 0;
            //try
            //{
            //    FormMenuMasterEntity entity = new FormMenuMasterEntity();
            //    FormMenuMasterClass obj = new FormMenuMasterClass();
            //    entity.fmm_name = txtFrmName.Text.Trim().ToString();
            //    entity.fmm_link = txtFrmLink.Text.Trim();
            //    entity.fmm_parent_id = Convert.ToInt32(ddlParent.SelectedValue);
            //    entity.fmm_sequence = Convert.ToInt32(txtFrmSeq.Text.Trim());
            //    entity.active = ddlActive.SelectedValue;
            //    entity.created_user = userInfo.UserId;
            //    numberroweffect = obj.InsertFormMenu(entity);
            //    if (numberroweffect > 0)
            //    {
            //        //sqlTrans.Commit();
            //        lblPopMessage.Text = "Submited Successfully.";
            //    }
            //    else
            //    {
            //        //sqlTrans.Rollback();
            //        lblPopMessage.Text = "Some Error Occured.";
            //    }
            //}
            //catch (Exception ex)
            //{
            //    // Throw ex
            //    lblPopMessage.Text = ex.ToString();
            //}
            //finally
            //{
            //    //sqlConn.Close();
            //    gvFormList.EditIndex = -1;
            //    BindGrid();
            //    ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
            //}
            Response.Write("hIO");
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
                //PopulateParent(ddlParent);
                ddlParent.SelectedValue = rowview["fmm_parent_id"].ToString();
                ddlActive.SelectedValue = rowview["active"].ToString();
                txtFrmSeq.Attributes.Add("onkeypress", "KeyPressNumeric()");
                btnUpdate.Attributes.Add("onclick", "return ValidateSubmit('"
                                                                        + txtFrmName.ClientID + "','"
                                                                        + txtFrmLink.ClientID + "','"
                                                                        + ddlParent.ClientID + "','"
                                                                        + txtFrmSeq.ClientID + "','"
                                                                        + btnUpdate.ClientID + "','"
                                                                        + 0 + "') ");
            }
        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            //Label lblSrl_ftr = (e.Row.FindControl("lblSrl_ftr") as Label);
            //lblSrl_ftr.Text = (gvFormList.Rows.Count + 1).ToString();
            //Button btnUpdate = (e.Row.FindControl("btnSubmit") as Button);
            //TextBox txtFrmName = (e.Row.FindControl("txtFrmName_ftr") as TextBox);
            //TextBox txtFrmLink = (e.Row.FindControl("txtFrmLink_ftr") as TextBox);
            //DropDownList ddlParent = (e.Row.FindControl("ddlParent_ftr") as DropDownList);
            //TextBox txtFrmSeq = (e.Row.FindControl("txtFrmSeq_ftr") as TextBox);
            //DropDownList ddlActive = (e.Row.FindControl("ddlActive_ftr") as DropDownList);
            ////PopulateParent(ddlParent);
            //txtFrmSeq.Attributes.Add("onkeypress", "KeyPressNumeric()");
            //btnUpdate.Attributes.Add("onclick", "return ValidateSubmit('"
            //                                                  + txtFrmName.ClientID + "','"
            //                                                  + txtFrmLink.ClientID + "','"
            //                                                  + ddlParent.ClientID + "','"
            //                                                  + txtFrmSeq.ClientID + "','"
            //                                                  + btnUpdate.ClientID + "','"
            //                                                  + 0 + "') ");
        }
    }
    protected void gvFormList_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        gvFormList.EditIndex = e.NewEditIndex;
        BindGrid();
    }
    protected void gvFormList_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
    {
        try
        {

            CheckLogin();
            int Index = gvFormList.EditIndex;
            var txttemName = (gvFormList.Rows[Index].FindControl("txttemName") as TextBox).Text;
            var txtItemDescription = (gvFormList.Rows[Index].FindControl("txtItemDescription") as TextBox).Text;
            var txtItemCode = (gvFormList.Rows[Index].FindControl("txtItemCode") as TextBox).Text;
            var txtHSNBCNo = (gvFormList.Rows[Index].FindControl("txtHSNBCNo") as TextBox).Text;
            var txtSellingAmount = (gvFormList.Rows[Index].FindControl("txtSellingAmount") as TextBox).Text;
            var txtSellingQty = (gvFormList.Rows[Index].FindControl("txtSellingQty") as TextBox).Text;
            var txtCGST = (gvFormList.Rows[Index].FindControl("txtCGST") as TextBox).Text;
            var txtSGST = (gvFormList.Rows[Index].FindControl("txtSGST") as TextBox).Text;
            var txtIGST = (gvFormList.Rows[Index].FindControl("txtIGST") as TextBox).Text;
            var txtTotalSellingAmount = (gvFormList.Rows[Index].FindControl("txtTotalSellingAmount") as TextBox).Text;
            dtItems.Rows[Index]["ItemName"] = txttemName;
            dtItems.Rows[Index]["ItemDescription"] = txtItemDescription;
            dtItems.Rows[Index]["ItemCode"] = txtItemCode;
            dtItems.Rows[Index]["HSNBCNo"] = txtHSNBCNo;
            dtItems.Rows[Index]["SellingAmount"] = txtSellingAmount;
            dtItems.Rows[Index]["Quantity"] = txtSellingQty;
            dtItems.Rows[Index]["CGST"] = txtCGST;
            dtItems.Rows[Index]["SGST"] = txtSGST;
            dtItems.Rows[Index]["IGST"] = txtIGST;
            dtItems.Rows[Index]["TotalSellingAmount"] = txtTotalSellingAmount;
            Session["InvoiceDetails"] = dtItems;
        }
        catch (Exception ex)
        {
            lblPopMessage.Text = ex.ToString();
        }
        finally
        {
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

    public void BindGrid()
    {
        CheckLogin();
        FormMenuMasterClass Obj = new FormMenuMasterClass();
        string parentId = string.Empty;


        if (Session["InvoiceDetails"] != null)
        {
            dtItems = (DataTable)Session["InvoiceDetails"];
            gvFormList.DataSource = dtItems;
            gvFormList.DataBind();
        }
        else
        {
            gvFormList.DataSource = dtItems;
            gvFormList.DataBind();
        }
    }
    protected void btnInvoiceGenerate_Click(object sender, EventArgs e)
    {
        decimal TotalAmount;
        decimal CGST = 0;
        decimal SGST = 0;
        decimal IGST = 0;
        decimal SellingAmount;
        int SellingQuantity;

        string ItemName = txtItemName.Text.Trim();
        string ItemDescription = txtItemDescription.Value;
        string ItemCode = txtItemCode.Text.Trim();
        string HSNBCNo = txtHSNBCNo.Text.Trim();
        //decimal SellingAmount = Convert.ToDecimal(txtSellingAmount.Text.Trim());

        if (txtSellingAmount.Text.Trim() != "")
        {
            SellingAmount = Convert.ToDecimal(txtSellingAmount.Text.Trim());
        }
        else
        {
            SellingAmount = 0;
        }
        if (txtSellingQty.Text.Trim() != "")
        {
            SellingQuantity = Convert.ToInt32(txtSellingQty.Text.Trim());
        }
        else
        {
            SellingQuantity = 0;
        }

        //decimal GST = Convert.ToDecimal(txtGST.Text.Trim()) / 2;

        //if (txtGST.Text.Trim() != "")
        //{
        //    GST = Convert.ToDecimal(txtGST.Text.Trim()) / 2;
        //}
        //else
        //{
        //    GST = 0;
        //}

        if (ddlGstType.SelectedValue == "1")
        {
            if (!string.IsNullOrEmpty(txtGST.Text))
            {
                CGST = Convert.ToDecimal(txtGST.Text.Trim()) / 2;
                SGST = Convert.ToDecimal(txtGST.Text.Trim()) / 2;
            }
            else
            {
                CGST = 0;
                SGST = 0;
            }
        }
        else if (ddlGstType.SelectedValue == "1")
        {
            if (!string.IsNullOrEmpty(txtGST.Text))
            {
                IGST = Convert.ToDecimal(txtGST.Text.Trim());
            }
            else
            {
                IGST = 0;
            }
        }

        //decimal TotalAmount = Convert.ToDecimal(txtTotalAmount.Text.Trim());
        if (txtTotalAmount.Text.Trim() != "")
        {

            TotalAmount = Convert.ToDecimal(txtTotalAmount.Text.Trim());
        }
        else
        {
            TotalAmount = 0;
        }

        if (ItemName == "")
        {
            Response.Write("<script>alert('Enter Your Item Name');</script>");
            return;
        }
        //if (ItemDescription == "")
        //{
        //    Response.Write("<script>alert('Enter Your Item Description');</script>");
        //    return;
        //}
        //if (GST == 0)
        //{
        //    Response.Write("<script>alert('Enter Your GST %');</script>");
        //    return;
        //}
        if (SellingAmount == 0)
        {
            Response.Write("<script>alert('Enter Your Selling Price');</script>");
            return;
        }
        if (SellingQuantity == 0)
        {
            Response.Write("<script>alert('Enter Your Selling Quantity');</script>");
            return;
        }
        if (TotalAmount == 0)
        {
            Response.Write("<script>alert('Enter Total Selling Amount');</script>");
            return;
        }

        if (Session["InvoiceDetails"] == null)
        {
            dtItems.Columns.AddRange(new DataColumn[11] {
                            new DataColumn("Id", typeof(int)),
                            new DataColumn("ItemName", typeof(string)),
                            new DataColumn("ItemDescription",typeof(string)),
                            new DataColumn("ItemCode",typeof(string)),
                            new DataColumn("HSNBCNo",typeof(string)),
                            new DataColumn("SellingAmount",typeof(string)),
                            new DataColumn("Quantity",typeof(string)),
                            new DataColumn("CGST",typeof(string)),
                            new DataColumn("SGST",typeof(string)),
                            new DataColumn("IGST",typeof(string)),
                            new DataColumn("TotalSellingAmount",typeof(string))
            });
            dtItems.Rows.Add(0, ItemName, ItemDescription, ItemCode, HSNBCNo, SellingAmount, SellingQuantity, Convert.ToString(CGST), Convert.ToString(SGST), Convert.ToString(IGST), Convert.ToString(TotalAmount));
            Session["InvoiceDetails"] = dtItems;
        }
        else
        {
            dtItems = (DataTable)Session["InvoiceDetails"];
            dtItems.Rows.Add(0, ItemName, ItemDescription, ItemCode, HSNBCNo, SellingAmount, SellingQuantity, Convert.ToString(CGST), Convert.ToString(SGST), Convert.ToString(IGST), Convert.ToString(TotalAmount));
            Session["InvoiceDetails"] = dtItems;
        }
        BindGrid();

        txtItemName.Text = "";
        txtItemDescription.InnerText = "";
        txtItemCode.Text = "";
        txtHSNBCNo.Text = "";
        txtSellingAmount.Text = "";
        txtSellingQty.Text = "";
        txtGST.Text = "";
        txtTotalAmount.Text = "";
    }

    protected void btnSaveBillingDetails_Click(object sender, EventArgs e)
    {
        try
        {
            CheckLogin();

            if (Session["InvoiceDetails"] != null)
            {
                SqlConnection sqlConn = null;
                InvoiceDetails helper = null;
                sqlConn = (SqlConnection)DBFactory.GetHelper().OpenConnection();
                SqlTransaction sqlTrans = null;

                string CustomerName = txtcustomername.Text.Trim();
                string CAddress = txtcAddress.Text.Trim();
                string CMobbileno = txtcmobbileno.Text.Trim();
                string EMail = txtCemail.Text.Trim();
                string ExtraCharges = textExtraCharges.Text.Trim();

                if (CustomerName == "")
                {
                    Response.Write("<script>alert('Enter Your Customer Name');</script>");
                    return;
                }
                if (CMobbileno == "")
                {
                    Response.Write("<script>alert('Enter Your Mobbile No');</script>");
                    return;
                }
                DataTable dataSet = (DataTable)Session["InvoiceDetails"];

                DataTable itemDetails = new DataTable();
                itemDetails.Columns.Add("SLNo", typeof(int));
                itemDetails.Columns.Add("ItemName", typeof(string));
                itemDetails.Columns.Add("ItemDescription", typeof(string));
                itemDetails.Columns.Add("ItemCode", typeof(string));
                itemDetails.Columns.Add("HSBCNo", typeof(string));
                itemDetails.Columns.Add("Sellingprice", typeof(decimal));
                itemDetails.Columns.Add("Quantity", typeof(decimal));
                itemDetails.Columns.Add("IGSTPer", typeof(decimal));
                itemDetails.Columns.Add("IGSTVal", typeof(decimal));
                itemDetails.Columns.Add("CGSTPer", typeof(decimal));
                itemDetails.Columns.Add("CGSTVal", typeof(decimal));
                itemDetails.Columns.Add("SGSTPer", typeof(decimal));
                itemDetails.Columns.Add("SGSTVal", typeof(decimal));
                itemDetails.Columns.Add("OthersCost", typeof(decimal));
                itemDetails.Columns.Add("TotalItemCost", typeof(decimal));

                if (dataSet != null && dataSet.Rows.Count > 0)
                {
                    for (int i = 0; i < dataSet.Rows.Count; i++)
                    {
                        DataRow dr = itemDetails.NewRow();

                        dr["SLNo"] = i + 1;
                        dr["ItemName"] = dataSet.Rows[i]["ItemName"];
                        dr["ItemDescription"] = dataSet.Rows[i]["ItemDescription"];
                        dr["ItemCode"] = dataSet.Rows[i]["ItemCode"];
                        dr["HSBCNo"] = dataSet.Rows[i]["HSNBCNo"];
                        dr["Sellingprice"] = dataSet.Rows[i]["SellingAmount"];
                        dr["Quantity"] = dataSet.Rows[i]["Quantity"];
                        dr["IGSTPer"] = dataSet.Rows[i]["IGST"];
                        dr["IGSTVal"] = 0;
                        dr["CGSTPer"] = dataSet.Rows[i]["CGST"];
                        dr["CGSTVal"] = 0;
                        dr["SGSTPer"] = dataSet.Rows[i]["SGST"];
                        dr["SGSTVal"] = 0;
                        dr["OthersCost"] = 0;
                        dr["TotalItemCost"] = dataSet.Rows[i]["TotalSellingAmount"];
                        itemDetails.Rows.Add(dr);
                    }
                }
                helper = new InvoiceDetails();
                int returnResult = helper.SaveInvoice(CustomerName, CAddress, CMobbileno, EMail, ExtraCharges, itemDetails, userInfo.UserId, sqlConn, sqlTrans);

                if (returnResult > 0)
                {
                    PopulateInvoiceDetails();
                    Session["InvoiceDetails"] = null;
                    BindGrid();
                    txtcustomername.Text = "";
                    txtcAddress.Text = "";
                    txtcmobbileno.Text = "";
                    txtCemail.Text = "";
                    textExtraCharges.Text = "";
                    //Response.Write("<script>alert('Invoice Save successfully');</script>");
                    lblPopMessage.Text = "Invoice Save successfully";
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
                }
                else
                {
                    lblPopMessage.Text = "Something Going Wrong. Please contact to Administrator";
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
                }
            }
        }
        catch (Exception ex)
        {

        }
        finally
        {

        }
    }

    private void PopulateInvoiceDetails()
    {
        CheckLogin();
        DataSet ds = new DataSet();
        InvoiceDetails Obj = new InvoiceDetails();
        ds = Obj.GetInvoiceDetails(userInfo.UserId);
        if ((!(ds.Tables[0] == null) && ds.Tables[0].Rows.Count > 0))
        {
            gdInvoiceList.DataSource = ds.Tables[0];
            gdInvoiceList.DataBind();
        }
        else
        {
            gdInvoiceList.DataSource = null;
            gdInvoiceList.DataBind();
        }

    }
}