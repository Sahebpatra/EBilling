using EBilling.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for contact_page_class
/// </summary>
public class contact_page_class
{
    public contact_page_class()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public long CompanyId { get; private set; }
    public DataSet GetContactWebFrom(long company_Id)
    {
        DataSet ResultSet = new DataSet();
        SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@CompanyId",SqlDbType.BigInt){Value=CommonModule.DBNullValueorInt64IfNotNull(CompanyId)},

            };
        ResultSet = DBFactory.GetHelper().ExecuteDataSet("[sp_GetWebRegiViewDetails]", System.Data.CommandType.StoredProcedure, sqlParams);
        return ResultSet;
    }
}