using EBilling.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Microsoft.VisualBasic;

/// <summary>
/// Summary description for UserGroupClass
/// </summary>
public class UserGroupClass
{
    public UserGroupClass()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static object DBNullValueorStringIfNotNull(string value)
    {
        object o;
        if (value == string.Empty || value == null)
        {
            o = DBNull.Value;
        }
        else
        {
            o = value;
        }
        return o;
    }
    public DataSet GetUserGroupList(string Company)
    {
        System.Data.DataSet UserGroupList;
        SqlParameter[] sqlParams = new SqlParameter[1];

        sqlParams[0] = new SqlParameter();
        sqlParams[0].ParameterName = "@company";
        sqlParams[0].DbType = DbType.String;
        sqlParams[0].Direction = System.Data.ParameterDirection.Input;
        sqlParams[0].Value = DBNullValueorStringIfNotNull(Company);

        UserGroupList = DBFactory.GetHelper().ExecuteDataSet("[dbo].[UserGroup_getList]", System.Data.CommandType.StoredProcedure, sqlParams);
        return UserGroupList;
    }

    public int InsertUserGroupDetails(UserGroupEntity entity, SqlConnection sqlConn, SqlTransaction sqlTrans)
    {
        int returnResult = 0;
        try
        {
            SqlParameter[] sqlParams = new SqlParameter[8];

            sqlParams[0] = new SqlParameter();
            sqlParams[0].ParameterName = "@grp_user_company";
            sqlParams[0].DbType = DbType.String;
            sqlParams[0].Direction = System.Data.ParameterDirection.Input;
            sqlParams[0].Value = entity.companyCode;

            sqlParams[1] = new SqlParameter();
            sqlParams[1].ParameterName = "@grp_user_group_code";
            sqlParams[1].DbType = DbType.String;
            sqlParams[1].Direction = System.Data.ParameterDirection.Input;
            sqlParams[1].Value = entity.userGroupCode;

            sqlParams[2] = new SqlParameter();
            sqlParams[2].ParameterName = "@grp_user_group_desc";
            sqlParams[2].DbType = DbType.String;
            sqlParams[2].Direction = System.Data.ParameterDirection.Input;
            sqlParams[2].Value = entity.userGroupDesc;

            sqlParams[3] = new SqlParameter();
            sqlParams[3].ParameterName = "@grp_user_group_type";
            sqlParams[3].DbType = DbType.String;
            sqlParams[3].Direction = System.Data.ParameterDirection.Input;
            sqlParams[3].Value = entity.userGroupType;

            sqlParams[4] = new SqlParameter();
            sqlParams[4].ParameterName = "@grp_approv_level";
            sqlParams[4].DbType = DbType.Int32;
            sqlParams[4].Direction = System.Data.ParameterDirection.Input;
            sqlParams[4].Value = entity.userGroupLevel;

            sqlParams[5] = new SqlParameter();
            sqlParams[5].ParameterName = "@created_user";
            sqlParams[5].DbType = DbType.String;
            sqlParams[5].Direction = System.Data.ParameterDirection.Input;
            sqlParams[5].Value = entity.createdUser;

            sqlParams[6] = new SqlParameter();
            sqlParams[6].ParameterName = "@active";
            sqlParams[6].DbType = DbType.String;
            sqlParams[6].Direction = System.Data.ParameterDirection.Input;
            sqlParams[6].Value = entity.statusActive;            

            sqlParams[7] = new SqlParameter();
            sqlParams[7].ParameterName = "@output";
            sqlParams[7].DbType = DbType.Int32;
            sqlParams[7].Direction = System.Data.ParameterDirection.Output;
            sqlParams[7].Size = 100;

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = sqlConn;
            sqlCmd.Transaction = sqlTrans;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "[dbo].[UserGroup_Insert]";
            sqlCmd.Parameters.AddRange(sqlParams);
            returnResult = sqlCmd.ExecuteNonQuery();
            returnResult = Convert.ToInt32(sqlParams[7].Value);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return returnResult;
    }

    public int UpdatetUserGroupDetails(UserGroupEntity entity, SqlConnection sqlConn, SqlTransaction sqlTrans)
    {
        int returnResult = 0;
        try
        {
            SqlParameter[] sqlParams = new SqlParameter[7];

            sqlParams[0] = new SqlParameter();
            sqlParams[0].ParameterName = "@grp_user_company";
            sqlParams[0].DbType = DbType.String;
            sqlParams[0].Direction = System.Data.ParameterDirection.Input;
            sqlParams[0].Value = entity.companyCode;

            sqlParams[1] = new SqlParameter();
            sqlParams[1].ParameterName = "@grp_user_group_code";
            sqlParams[1].DbType = DbType.String;
            sqlParams[1].Direction = System.Data.ParameterDirection.Input;
            sqlParams[1].Value = entity.userGroupCode;

            sqlParams[2] = new SqlParameter();
            sqlParams[2].ParameterName = "@grp_user_group_desc";
            sqlParams[2].DbType = DbType.String;
            sqlParams[2].Direction = System.Data.ParameterDirection.Input;
            sqlParams[2].Value = entity.userGroupDesc;

            sqlParams[3] = new SqlParameter();
            sqlParams[3].ParameterName = "@grp_user_group_type";
            sqlParams[3].DbType = DbType.String;
            sqlParams[3].Direction = System.Data.ParameterDirection.Input;
            sqlParams[3].Value = entity.userGroupType;

            sqlParams[4] = new SqlParameter();
            sqlParams[4].ParameterName = "@grp_approv_level";
            sqlParams[4].DbType = DbType.Int32;
            sqlParams[4].Direction = System.Data.ParameterDirection.Input;
            sqlParams[4].Value = entity.userGroupLevel;

            sqlParams[5] = new SqlParameter();
            sqlParams[5].ParameterName = "@created_user";
            sqlParams[5].DbType = DbType.String;
            sqlParams[5].Direction = System.Data.ParameterDirection.Input;
            sqlParams[5].Value = entity.createdUser;

            sqlParams[6] = new SqlParameter();
            sqlParams[6].ParameterName = "@active";
            sqlParams[6].DbType = DbType.String;
            sqlParams[6].Direction = System.Data.ParameterDirection.Input;
            sqlParams[6].Value = entity.statusActive;

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = sqlConn;
            sqlCmd.Transaction = sqlTrans;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "[dbo].[UserGroup_Update]";
            sqlCmd.Parameters.AddRange(sqlParams);
            returnResult = sqlCmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return returnResult;
    }
}