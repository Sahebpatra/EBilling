using EBilling.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SectionMaster
/// </summary>
public class SectionMaster
{
    public SectionMaster()
    {
      
    }
    public DataSet GetSectionDetails()
    {
        System.Data.DataSet DS;
        DS = DBFactory.GetHelper().ExecuteDataSet("[sp_GetViewDetails]", System.Data.CommandType.StoredProcedure);
        return DS;
    }


    public int NewsclectMaster(string TOrgName, string TSectionName, string TPageName, string TWebsiteName, SqlConnection sqlConn, SqlTransaction sqlTrans)
    {
        int result = 0;
        SqlParameter[] sqlParams = new SqlParameter[4];

        sqlParams[0] = new SqlParameter();
        sqlParams[0].ParameterName = "@TOrgName";
        sqlParams[0].DbType = System.Data.DbType.String;
        sqlParams[0].Direction = System.Data.ParameterDirection.Input;
        sqlParams[0].Value = TOrgName;

        sqlParams[1] = new SqlParameter();
        sqlParams[1].ParameterName = "@TSectionName";
        sqlParams[1].DbType = DbType.String;
        sqlParams[1].Direction = System.Data.ParameterDirection.Input;
        sqlParams[1].Value = TSectionName;

        sqlParams[2] = new SqlParameter();
        sqlParams[2].ParameterName = "@TPageName";
        sqlParams[2].DbType = DbType.String;
        sqlParams[2].Direction = System.Data.ParameterDirection.Input;
        sqlParams[2].Value = TPageName;

        sqlParams[3] = new SqlParameter();
        sqlParams[3].ParameterName = "@TWebsiteName";
        sqlParams[3].DbType = DbType.String;
        sqlParams[3].Direction = System.Data.ParameterDirection.Input;
        sqlParams[3].Value = TWebsiteName;

        SqlCommand sqlCmd = new SqlCommand();
        sqlCmd.Connection = sqlConn;
        sqlCmd.Transaction = sqlTrans;
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.CommandText = "SelectMaster_sp";
        sqlCmd.Parameters.AddRange(sqlParams);
        result = sqlCmd.ExecuteNonQuery();
        return result;
    }
}