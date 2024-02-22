using EBilling.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for WebGridView_Class
/// </summary>
public class WebGridView_Class
{
    public WebGridView_Class()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public long CompanyId { get; private set; }
    public DataSet GetDataSetWebFrom(long company_Id)
    {
        //System.Data.DataSet DS;
        //DS = DBFactory.GetHelper().ExecuteDataSet("[sp_GetWebRegiViewDetails]", System.Data.CommandType.StoredProcedure);
        //return DS;

        DataSet ResultSet = new DataSet();
        SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@CompanyId",SqlDbType.BigInt){Value=CommonModule.DBNullValueorInt64IfNotNull(CompanyId)},

            };
        ResultSet = DBFactory.GetHelper().ExecuteDataSet("[sp_GetWebRegiViewDetails]", System.Data.CommandType.StoredProcedure, sqlParams);
        return ResultSet;

    }
}