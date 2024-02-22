using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using EBilling.DataAccess;

/// <summary>
/// Summary description for menuClass
/// </summary>
public class menuClass
{
    public DataSet GetMenu(string groupCode,string userId)
    {
        DataSet ResultSet = new DataSet();
        SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@logingrpid",SqlDbType.VarChar){Value=CommonModule.DBNullValueorStringIfNotNull(groupCode.ToString())},
                new SqlParameter("@loginuserid",SqlDbType.VarChar){Value=CommonModule.DBNullValueorStringIfNotNull(userId.ToString())}
            };
        ResultSet = DBFactory.GetHelper().ExecuteDataSet("[Get_Menu]", System.Data.CommandType.StoredProcedure, sqlParams);
        return ResultSet;
    }
}