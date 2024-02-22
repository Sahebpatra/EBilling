using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using EBilling.DataAccess;

/// <summary>
/// Summary description for UserFormAccessClass
/// </summary>
public class UserFormAccessClass
{
    //public UserFormAccessClass()
    //{
    //    //
    //    // TODO: Add constructor logic here
    //    //
    //}

    //public DataSet UserGroup_Get()
    //{
    //    DataSet UserGroupSet;
    //    UserGroupSet = DBFactory.GetHelper().ExecuteDataSet("dbo.User_Form_Access_Get_User_Group", System.Data.CommandType.StoredProcedure);
    //    return UserGroupSet;
    //}

    public DataSet UserGroup_Get_Against_Company(string company)
    {
        DataSet userGrp = new DataSet();

        SqlParameter[] sqlParams = new SqlParameter[1];

        sqlParams[0] = new SqlParameter();
        sqlParams[0].ParameterName = "@userCompanyCode";
        sqlParams[0].DbType = DbType.String;
        sqlParams[0].Direction = System.Data.ParameterDirection.Input;
        sqlParams[0].Value = company;
        userGrp = DBFactory.GetHelper().ExecuteDataSet("[dbo].[UserFormAccess_getGetUserGroupByCompany]", System.Data.CommandType.StoredProcedure, sqlParams);
        return userGrp;
    }
    public DataSet UserID_Get(string usrgrp)
    {
        DataSet userGrp = new DataSet();

        SqlParameter[] sqlParams = new SqlParameter[1];

        sqlParams[0] = new SqlParameter();
        sqlParams[0].ParameterName = "@usrgrp";
        sqlParams[0].DbType = DbType.String;
        sqlParams[0].Direction = System.Data.ParameterDirection.Input;
        sqlParams[0].Value = usrgrp;
        userGrp = DBFactory.GetHelper().ExecuteDataSet("dbo.User_Form_Access_Get_User_Id", System.Data.CommandType.StoredProcedure, sqlParams);
        return userGrp;
    }

    public DataSet UserForms_Get(string usrgrp, string usrid)
    {
        DataSet userGrp = new DataSet();

        SqlParameter[] sqlParams = new SqlParameter[2];

        sqlParams[0] = new SqlParameter();
        sqlParams[0].ParameterName = "@usrgrp";
        sqlParams[0].DbType = DbType.String;
        sqlParams[0].Direction = System.Data.ParameterDirection.Input;
        sqlParams[0].Value = usrgrp;

        sqlParams[1] = new SqlParameter();
        sqlParams[1].ParameterName = "@usrid";
        sqlParams[1].DbType = DbType.String;
        sqlParams[1].Direction = System.Data.ParameterDirection.Input;
        sqlParams[1].Value = usrid;

        userGrp = DBFactory.GetHelper().ExecuteDataSet("dbo.User_Form_Access_Get_Avlble_Forms", System.Data.CommandType.StoredProcedure, sqlParams);
        return userGrp;
    }

    public DataSet UserApplForms_Get(string UsrGrp, string UsrID)
    {
        DataSet UserGroupSet = new DataSet();

        SqlParameter[] sqlParams = new SqlParameter[2];

        sqlParams[0] = new SqlParameter();
        sqlParams[0].ParameterName = "@usrgrp";
        sqlParams[0].DbType = DbType.String;
        sqlParams[0].Direction = System.Data.ParameterDirection.Input;
        sqlParams[0].Value = UsrGrp;

        sqlParams[1] = new SqlParameter();
        sqlParams[1].ParameterName = "@usrid";
        sqlParams[1].DbType = DbType.String;
        sqlParams[1].Direction = System.Data.ParameterDirection.Input;
        sqlParams[1].Value = UsrID;

        UserGroupSet = DBFactory.GetHelper().ExecuteDataSet("dbo.User_Form_Access_Get_Applicable_Forms", System.Data.CommandType.StoredProcedure, sqlParams);
        return UserGroupSet;
    }

    public int InsertUsrFrm(string Desc, string Code, string User, string GroupCode, string UserID)
    {
        int result = 0;

        SqlParameter[] sqlParams = new SqlParameter[5];

        sqlParams[0] = new SqlParameter();
        sqlParams[0].ParameterName = "@desc";
        sqlParams[0].DbType = DbType.String;
        sqlParams[0].Direction = System.Data.ParameterDirection.Input;
        sqlParams[0].Value = Desc;

        sqlParams[1] = new SqlParameter();
        sqlParams[1].ParameterName = "@code";
        sqlParams[1].DbType = DbType.String;
        sqlParams[1].Direction = System.Data.ParameterDirection.Input;
        sqlParams[1].Value = Code;

        sqlParams[2] = new SqlParameter();
        sqlParams[2].ParameterName = "@user";
        sqlParams[2].DbType = DbType.String;
        sqlParams[2].Direction = System.Data.ParameterDirection.Input;
        sqlParams[2].Value = User;

        sqlParams[3] = new SqlParameter();
        sqlParams[3].ParameterName = "@Groupcode";
        sqlParams[3].DbType = DbType.String;
        sqlParams[3].Direction = System.Data.ParameterDirection.Input;
        sqlParams[3].Value = GroupCode;

        sqlParams[4] = new SqlParameter();
        sqlParams[4].ParameterName = "@userid";
        sqlParams[4].DbType = DbType.String;
        sqlParams[4].Direction = System.Data.ParameterDirection.Input;
        sqlParams[4].Value = UserID;

      
        result = DBFactory.GetHelper().ExecuteNonQuery("dbo.User_Form_Access_Insert", System.Data.CommandType.StoredProcedure, sqlParams);
        return result;
    }

    public int DeleteUsrFrm(string GroupCode, string UserID)
    {
        int result = 0;

        SqlParameter[] sqlParams = new SqlParameter[2];

        sqlParams[0] = new SqlParameter();
        sqlParams[0].ParameterName = "@groupcode";
        sqlParams[0].DbType = DbType.String;
        sqlParams[0].Direction = System.Data.ParameterDirection.Input;
        sqlParams[0].Value = GroupCode;

        sqlParams[1] = new SqlParameter();
        sqlParams[1].ParameterName = "@userid";
        sqlParams[1].DbType = DbType.String;
        sqlParams[1].Direction = System.Data.ParameterDirection.Input;
        sqlParams[1].Value = UserID;


        result = DBFactory.GetHelper().ExecuteNonQuery("dbo.User_Form_Access_Delete", System.Data.CommandType.StoredProcedure, sqlParams);
        return result;
    }
  
}