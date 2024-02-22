using EBilling.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CompanyRegistrationClass
/// </summary>
public class CompanyRegistrationClass
{

    public CompanyRegistrationClass()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataSet GetCompanyRegisterList()
    {
        System.Data.DataSet DS;
        DS = DBFactory.GetHelper().ExecuteDataSet("[SP_CompanyregisterGridView]", System.Data.CommandType.StoredProcedure);
        return DS;
    }

    public int NewCompanyRegistration(string TCompanyName, string TMobbileNo, string TMailID, string TWebsiteLink, string TGstId, string TBusinessName, string TBusinessType, string TSclectCountry, string TSclectSate, string TCityName, string TPinCode, string TFullAddress, string TNearby, string fileName, string websiteLink,string UserId, SqlConnection sqlConn, SqlTransaction sqlTrans)
    {
        int result = 0;
        SqlCommand sqlCmd = new SqlCommand();
        sqlCmd.Connection = sqlConn;
        sqlCmd.Transaction = sqlTrans;
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.CommandText = "SP_ComapanyRegister";
        sqlCmd.Parameters.AddWithValue("@TCompanyName", TCompanyName);
        sqlCmd.Parameters.AddWithValue("@TMobbileNo", TMobbileNo);
        sqlCmd.Parameters.AddWithValue("@TMailID", TMailID);
        sqlCmd.Parameters.AddWithValue("@TWebsiteLink", TWebsiteLink);
        sqlCmd.Parameters.AddWithValue("@TGstId", TGstId);
        sqlCmd.Parameters.AddWithValue("@TBusinessName", TBusinessName);
        sqlCmd.Parameters.AddWithValue("@TBusinessType", TBusinessType);
        sqlCmd.Parameters.AddWithValue("@TSclectCountry", TSclectCountry);
        sqlCmd.Parameters.AddWithValue("@TSclectSate", TSclectSate);
        sqlCmd.Parameters.AddWithValue("@TCityName", TCityName);
        sqlCmd.Parameters.AddWithValue("@TPinCode", TPinCode);
        sqlCmd.Parameters.AddWithValue("@TFullAddress", TFullAddress);
        sqlCmd.Parameters.AddWithValue("@TNearby", TNearby);
        sqlCmd.Parameters.AddWithValue("@WebURL", websiteLink);
        sqlCmd.Parameters.AddWithValue("@LoginUser", UserId);
        sqlCmd.Parameters.AddWithValue("@fileName", fileName);
        result = sqlCmd.ExecuteNonQuery();

        return result;
    }
    public DataSet GetStatelistList()
    {
        System.Data.DataSet DS;
        DS = DBFactory.GetHelper().ExecuteDataSet("[SP_statemastercall]", System.Data.CommandType.StoredProcedure);
        return DS;
    }
    public DataSet CitylistList(string statecode)
    {
        System.Data.DataSet DS;
        SqlParameter[] sqlParams ={
                                   new SqlParameter("@statecodesclect",statecode),
                                  };
        DS = DBFactory.GetHelper().ExecuteDataSet("SP_citymastercall", System.Data.CommandType.StoredProcedure, sqlParams);
        return DS;
    }


    public DataSet GetNewUserListList(int CompanyId)
    {
        System.Data.DataSet DS;
        SqlParameter[] sqlParams ={
                                   new SqlParameter("@CompanyId",CompanyId),
                                  };
        DS = DBFactory.GetHelper().ExecuteDataSet("SP_GetNewUserLit", System.Data.CommandType.StoredProcedure, sqlParams);
        return DS;
    }

    public DataSet SaveNewUserDEtails(string usp_user_id,string usp_pswd,string usp_first_name,string usp_last_name,string created_user,int CompanyId,string fileName)
    {
        System.Data.DataSet DS;
        SqlParameter[] sqlParams ={
                                   new SqlParameter("@usp_user_id",usp_user_id),
                                   new SqlParameter("@usp_pswd",usp_pswd),
                                   new SqlParameter("@usp_first_name",usp_first_name),
                                   new SqlParameter("@usp_last_name",usp_last_name),
                                   new SqlParameter("@created_user",created_user),
                                   new SqlParameter("@CompanyId",CompanyId),
                                   new SqlParameter("@Signature",fileName),
                                  };
        DS = DBFactory.GetHelper().ExecuteDataSet("SP_SaveNewUser", System.Data.CommandType.StoredProcedure, sqlParams);
        return DS;
    }

}