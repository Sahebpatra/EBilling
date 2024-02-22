using EBilling.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FormMenuMasterClass
/// </summary>
public class FormMenuMasterClass
{
    public FormMenuMasterClass()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataSet GetParentFormList()
    {
        DataSet DS;

        DS = DBFactory.GetHelper().ExecuteDataSet("[FormMenu_GetParentFormList]", System.Data.CommandType.StoredProcedure);
        return DS;
    }

    public DataSet GetFormMenuList(string ParentId)
    {
        System.Data.DataSet DS;
        SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@fmm_parent_id",SqlDbType.VarChar){Value=CommonModule.DBNullValueorStringIfNotNull(ParentId)}
            };

        DS = DBFactory.GetHelper().ExecuteDataSet("[FormMenu_GetList]", System.Data.CommandType.StoredProcedure, sqlParams);
        return DS;
    }

    public int InsertFormMenu(FormMenuMasterEntity entity)
    {
        int result = 0;

        SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@fmm_id",SqlDbType.VarChar){Value=CommonModule.DBNullValueorStringIfNotNull("")},
                new SqlParameter("@fmm_name",SqlDbType.VarChar){Value=CommonModule.DBNullValueorStringIfNotNull(entity.fmm_name)},
                new SqlParameter("@fmm_link",SqlDbType.VarChar){Value=CommonModule.DBNullValueorStringIfNotNull(entity.fmm_link)},
                new SqlParameter("@fmm_parent_id",SqlDbType.VarChar){Value=entity.fmm_parent_id},
                new SqlParameter("@fmm_sequence",SqlDbType.VarChar){Value=entity.fmm_sequence},
                new SqlParameter("@icon",SqlDbType.VarChar){Value=CommonModule.DBNullValueorStringIfNotNull("")},
                new SqlParameter("@created_user",SqlDbType.VarChar){Value=CommonModule.DBNullValueorStringIfNotNull(entity.created_user)},
                new SqlParameter("@active",SqlDbType.VarChar){Value=CommonModule.DBNullValueorStringIfNotNull(entity.active)}
            };
        result = DBFactory.GetHelper().ExecuteNonQuery("FormMenu_Insert", System.Data.CommandType.StoredProcedure, sqlParams);
        return result;
    }

    public int UpdateFormMenu(FormMenuMasterEntity entity)
    {
        int result = 0;

        SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@fmm_id",SqlDbType.VarChar){Value=entity.fmm_id},
                new SqlParameter("@fmm_name",SqlDbType.VarChar){Value=CommonModule.DBNullValueorStringIfNotNull(entity.fmm_name)},
                new SqlParameter("@fmm_link",SqlDbType.VarChar){Value=CommonModule.DBNullValueorStringIfNotNull(entity.fmm_link)},
                new SqlParameter("@fmm_parent_id",SqlDbType.VarChar){Value=entity.fmm_parent_id},
                new SqlParameter("@fmm_sequence",SqlDbType.VarChar){Value=entity.fmm_sequence},
                new SqlParameter("@icon",SqlDbType.VarChar){Value=CommonModule.DBNullValueorStringIfNotNull("")},
                new SqlParameter("@created_user",SqlDbType.VarChar){Value=CommonModule.DBNullValueorStringIfNotNull(entity.created_user)},
                new SqlParameter("@active",SqlDbType.VarChar){Value=CommonModule.DBNullValueorStringIfNotNull(entity.active)}
            };
        result = DBFactory.GetHelper().ExecuteNonQuery("FormMenu_Update", System.Data.CommandType.StoredProcedure, sqlParams);
        return result;
    }

    public DataSet GetGenealogyDetails(string LoginUserId)
    {
        System.Data.DataSet DS;
        SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@pLoginUserId",SqlDbType.VarChar){Value=CommonModule.DBNullValueorStringIfNotNull(LoginUserId)}
            };

        DS = DBFactory.GetHelper().ExecuteDataSet("[GetGenealogyDetails]", System.Data.CommandType.StoredProcedure, sqlParams);
        return DS;
    }

    public DataSet GetInvoiceDetails(string InvoiceId)
    {
        System.Data.DataSet DS;
        SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@pPurchasedId",SqlDbType.VarChar){Value=CommonModule.DBNullValueorStringIfNotNull(InvoiceId)}
            };

        DS = DBFactory.GetHelper().ExecuteDataSet("[GetInvoiceDetails]", System.Data.CommandType.StoredProcedure, sqlParams);
        return DS;
    }


}