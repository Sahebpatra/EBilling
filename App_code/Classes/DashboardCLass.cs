using EBilling.DataAccess;
using System;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// Summary description for DashboardCLass
/// </summary>
public class DashboardCLass
{
    public DashboardCLass()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataSet GetDashboardData(string userId)
    {
        DataSet userDetails;
        SqlParameter[] sqlParams = new SqlParameter[1];

        sqlParams[0] = new SqlParameter();
        sqlParams[0].ParameterName = "@user_id";
        sqlParams[0].DbType = DbType.String;
        sqlParams[0].Direction = System.Data.ParameterDirection.Input;
        sqlParams[0].Value = CommonModule.DBNullValueorStringIfNotNull(userId);

        userDetails = DBFactory.GetHelper().ExecuteDataSet("[dashboard_detail_get]", System.Data.CommandType.StoredProcedure, sqlParams);
        return userDetails;
    }
}