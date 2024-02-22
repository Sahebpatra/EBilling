using EBilling.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PageSclectMasterClass
/// </summary>
public class PageSclectMasterClass
{
    public PageSclectMasterClass()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int InsertFormMenu(FormMenuMasterEntity entity)
    {
        int result = 0;

        SqlParameter[] sqlParams = new SqlParameter[]
            {
                //new SqlParameter("@fmm_id",SqlDbType.VarChar){Value=entity.fmm_id},
                new SqlParameter("@fmm_OrgName",SqlDbType.VarChar){Value=CommonModule.DBNullValueorStringIfNotNull(entity.fmm_OrgName)},
                new SqlParameter("@fmm_SectionName",SqlDbType.VarChar){Value=CommonModule.DBNullValueorStringIfNotNull(entity.fmm_SectionName)},
                new SqlParameter("@fmm_PageName",SqlDbType.VarChar){Value=CommonModule.DBNullValueorStringIfNotNull(entity.fmm_PageName)},
                new SqlParameter("@fmm_WebsiteName",SqlDbType.VarChar){Value=CommonModule.DBNullValueorStringIfNotNull(entity.fmm_WebsiteName)},

                //new SqlParameter("@fmm_sequence",SqlDbType.VarChar){Value=entity.fmm_sequence},
                //new SqlParameter("@icon",SqlDbType.VarChar){Value=CommonModule.DBNullValueorStringIfNotNull("")},
                //new SqlParameter("@created_user",SqlDbType.VarChar){Value=CommonModule.DBNullValueorStringIfNotNull(entity.created_user)},
                //new SqlParameter("@active",SqlDbType.VarChar){Value=CommonModule.DBNullValueorStringIfNotNull(entity.active)}
            };
        result = DBFactory.GetHelper().ExecuteNonQuery("SelectMaster_sp", System.Data.CommandType.StoredProcedure, sqlParams);
        return result;
    }

    public DataSet GetFormMenuList(string parentId)
    {
        throw new NotImplementedException();
    }
}