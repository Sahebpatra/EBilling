using EBilling.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StorePageSclect
/// </summary>
public class StorePageSclect
{
    public StorePageSclect()
    {

    }

    //public DataSet StorepageProductDelete()
    //{
    //    System.Data.DataSet DS;
    //    DS = DBFactory.GetHelper().ExecuteDataSet("[SP_DeleteStorePageDetails]", System.Data.CommandType.StoredProcedure);
    //    return DS;
    //}


    //public DataSet StorepageGridView()
    //{
    //    System.Data.DataSet DS;
    //    DS = DBFactory.GetHelper().ExecuteDataSet("SP_StorePageGridView", System.Data.CommandType.StoredProcedure);
    //    return DS;
    //}



    public DataSet StorepageGridView(Int64 CompanyId)
    {
        DataSet ResultSet = new DataSet();
        SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@CompanyId",SqlDbType.BigInt){Value=CommonModule.DBNullValueorInt64IfNotNull(CompanyId)},
              
            };
        ResultSet = DBFactory.GetHelper().ExecuteDataSet("[SP_StorePageGridView]", System.Data.CommandType.StoredProcedure, sqlParams);
        return ResultSet;
    }






    public object NewStorePageSclect(string TDorgName, string TDpageName, string TDsectionName, string TDproductName, string TDproductPrice, string TDbuyNowLink, string TDproductDescription, string TDuploadProduct,Int64 CompanyId, SqlConnection sqlConn, SqlTransaction sqlTrans)
    {


        int result = 0;

        SqlParameter[] sqlParams = new SqlParameter[9];

        sqlParams[0] = new SqlParameter();
        sqlParams[0].ParameterName = "@TDorgName";
        sqlParams[0].DbType = DbType.String;
        sqlParams[0].Direction = System.Data.ParameterDirection.Input;
        sqlParams[0].Value = TDorgName;

        sqlParams[1] = new SqlParameter();
        sqlParams[1].ParameterName = "@TDpageName";
        sqlParams[1].DbType = DbType.String;
        sqlParams[1].Direction = System.Data.ParameterDirection.Input;
        sqlParams[1].Value = TDpageName;

        sqlParams[2] = new SqlParameter();
        sqlParams[2].ParameterName = "@TDsectionName";
        sqlParams[2].DbType = DbType.String;
        sqlParams[2].Direction = System.Data.ParameterDirection.Input;
        sqlParams[2].Value = TDsectionName;

        sqlParams[3] = new SqlParameter();
        sqlParams[3].ParameterName = "@TDproductName";
        sqlParams[3].DbType = DbType.String;
        sqlParams[3].Direction = System.Data.ParameterDirection.Input;
        sqlParams[3].Value = TDproductName;

        sqlParams[4] = new SqlParameter();
        sqlParams[4].ParameterName = "@TDproductPrice";
        sqlParams[4].DbType = DbType.String;
        sqlParams[4].Direction = System.Data.ParameterDirection.Input;
        sqlParams[4].Value = TDproductPrice;

        sqlParams[5] = new SqlParameter();
        sqlParams[5].ParameterName = "@TDbuyNowLink";
        sqlParams[5].DbType = DbType.String;
        sqlParams[5].Direction = System.Data.ParameterDirection.Input;
        sqlParams[5].Value = TDbuyNowLink;

        sqlParams[6] = new SqlParameter();
        sqlParams[6].ParameterName = "@TDproductDescription";
        sqlParams[6].DbType = DbType.String;
        sqlParams[6].Direction = System.Data.ParameterDirection.Input;
        sqlParams[6].Value = TDproductDescription;

        sqlParams[7] = new SqlParameter();
        sqlParams[7].ParameterName = "@TDuploadProduct";
        sqlParams[7].DbType = DbType.String;
        sqlParams[7].Direction = System.Data.ParameterDirection.Input;
        sqlParams[7].Value = TDuploadProduct;

        sqlParams[8] = new SqlParameter();
        sqlParams[8].ParameterName = "@CompanyId";
        sqlParams[8].DbType = DbType.Int64;
        sqlParams[8].Direction = System.Data.ParameterDirection.Input;
        sqlParams[8].Value = CompanyId;


        SqlCommand sqlCmd = new SqlCommand();
        sqlCmd.Connection = sqlConn;
        sqlCmd.Transaction = sqlTrans;
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.CommandText = "Sp_StorePageTableMaster";
        sqlCmd.Parameters.AddRange(sqlParams);
        result = sqlCmd.ExecuteNonQuery();
        return result;
    }
   
    public DataSet getPageSectionDetails()
    {
        System.Data.DataSet DS;
        DS = DBFactory.GetHelper().ExecuteDataSet("[SP_PageSectionList]", System.Data.CommandType.StoredProcedure);
        return DS;
    }
    public DataSet getPageNameDetailslist()
    {
        System.Data.DataSet DS;
        DS = DBFactory.GetHelper().ExecuteDataSet("[SP_PageNameList]", System.Data.CommandType.StoredProcedure);
        return DS;
    }
    public DataSet getOrgDetailslist()
    {
        System.Data.DataSet DS;
        DS = DBFactory.GetHelper().ExecuteDataSet("[SP_GetCompanyList]", System.Data.CommandType.StoredProcedure);
        return DS;
    }

    public static implicit operator StorePageSclect(UserPhotoUploaded v)
    {
        throw new NotImplementedException();
    }

    public object DeleteStoreDetails(Int64 StoreId, SqlConnection sqlConn, SqlTransaction sqlTrans)
    {
        int result = 0;

        SqlParameter[] sqlParams = new SqlParameter[1];

        sqlParams[0] = new SqlParameter();
        sqlParams[0].ParameterName = "@Id";
        sqlParams[0].DbType = DbType.Int64;
        sqlParams[0].Direction = System.Data.ParameterDirection.Input;
        sqlParams[0].Value = StoreId;

        SqlCommand sqlCmd = new SqlCommand();
        sqlCmd.Connection = sqlConn;
        sqlCmd.Transaction = sqlTrans;
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.CommandText = "SP_DeleteStorePageDetails";
        sqlCmd.Parameters.AddRange(sqlParams);
        result = sqlCmd.ExecuteNonQuery();
        return result;
    }



}