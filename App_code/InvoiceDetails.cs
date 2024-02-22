using EBilling.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for InvoiceDetails
/// </summary>
public class InvoiceDetails
{
    public InvoiceDetails()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int SaveInvoice(string CustomerName, string CAddress, string CMobbileno, string EMail, string ExtraCharges,DataTable itemDetails,string userID, SqlConnection sqlConn,SqlTransaction sqlTrans)
    {
        int result = 0;
        SqlCommand sqlCmd = new SqlCommand();
        sqlCmd.Connection = sqlConn;
        sqlCmd.Transaction = sqlTrans;
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.CommandText = "SP_SaveInvoiceDetails";
        sqlCmd.Parameters.AddWithValue("@Name", CustomerName);
        sqlCmd.Parameters.AddWithValue("@Address", CAddress);
        sqlCmd.Parameters.AddWithValue("@PhNo", CMobbileno);
        sqlCmd.Parameters.AddWithValue("@EmailId", EMail);
        sqlCmd.Parameters.AddWithValue("@LoginUserId", userID);
        sqlCmd.Parameters.AddWithValue("@ItemDetails", itemDetails);
        sqlCmd.Parameters.AddWithValue("@ExtraCharges", ExtraCharges);
        result = sqlCmd.ExecuteNonQuery();

        return result;
    }

    public DataSet GetInvoiceDetails(string LoginUserId)
    {
        System.Data.DataSet DS;
        SqlParameter[] sqlParams ={
                                   new SqlParameter("@LoginUserId",LoginUserId),
                                  };
        DS = DBFactory.GetHelper().ExecuteDataSet("SP_GetInvoiceDetails", System.Data.CommandType.StoredProcedure, sqlParams);
        return DS;
    }

    public DataSet PrintInvoiceDetails(Int64 InvoiceId)
    {
        System.Data.DataSet DS;
        SqlParameter[] sqlParams ={
                                   new SqlParameter("@InvoiceId",InvoiceId),
                                  };
        DS = DBFactory.GetHelper().ExecuteDataSet("SP_GetInvoicePrint", System.Data.CommandType.StoredProcedure, sqlParams);
        return DS;
    }
}