using EBilling.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Microsoft.VisualBasic;


/// <summary>
/// Summary description for LovDetailsClass
/// </summary>
public class LovDetailsClass
{
    public LovDetailsClass()
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
    public DataSet GetLovTypeDetails()
    {
        System.Data.DataSet LovDetails;
        LovDetails = DBFactory.GetHelper().ExecuteDataSet("dbo.LovDetails_getLovType", System.Data.CommandType.StoredProcedure);
        return LovDetails;
    }
    public DataSet GetLovDetailsList(string lovtype)
    {
        System.Data.DataSet LovDetailsDetails;
        SqlParameter[] sqlParams = new SqlParameter[1];

        sqlParams[0] = new SqlParameter();
        sqlParams[0].ParameterName = "@lovtype";
        sqlParams[0].DbType = DbType.String;
        sqlParams[0].Direction = System.Data.ParameterDirection.Input;
        sqlParams[0].Value = DBNullValueorStringIfNotNull(lovtype);

        LovDetailsDetails = DBFactory.GetHelper().ExecuteDataSet("dbo.Lov_Details_List", System.Data.CommandType.StoredProcedure, sqlParams);
        return LovDetailsDetails;
    }

    public DataSet EditLovDetails(string lov_type, string lov_code)
    {
        System.Data.DataSet ds;
        SqlParameter[] sqlParams = new SqlParameter[2];

        sqlParams[0] = new SqlParameter();
        sqlParams[0].ParameterName = "@lov_type";
        sqlParams[0].DbType = DbType.String;
        sqlParams[0].Direction = System.Data.ParameterDirection.Input;
        sqlParams[0].Value = lov_type;

        sqlParams[1] = new SqlParameter();
        sqlParams[1].ParameterName = "@lov_code";
        sqlParams[1].DbType = DbType.String;
        sqlParams[1].Direction = System.Data.ParameterDirection.Input;
        sqlParams[1].Value = lov_code;
        ds = DBFactory.GetHelper().ExecuteDataSet("dbo.LovDetails_getLovDetails", System.Data.CommandType.StoredProcedure, sqlParams);
        return ds;
    }

    public int InsertLovDetails(LovDetailsListEntity entity, SqlConnection sqlConn, SqlTransaction sqlTrans)
    {
        int returnResult = 0;
        try
        {
            SqlParameter[] sqlParams = new SqlParameter[11];

            sqlParams[0] = new SqlParameter();
            sqlParams[0].ParameterName = "@type";
            sqlParams[0].DbType = DbType.String;
            sqlParams[0].Direction = System.Data.ParameterDirection.Input;
            sqlParams[0].Value = entity.lovtype;

            sqlParams[1] = new SqlParameter();
            sqlParams[1].ParameterName = "@desc";
            sqlParams[1].DbType = DbType.String;
            sqlParams[1].Direction = System.Data.ParameterDirection.Input;
            sqlParams[1].Value = entity.lovshrtdesc;

            sqlParams[2] = new SqlParameter();
            sqlParams[2].ParameterName = "@value";
            sqlParams[2].DbType = DbType.String;
            sqlParams[2].Direction = System.Data.ParameterDirection.Input;
            sqlParams[2].Value = entity.lovvalue;

            sqlParams[3] = new SqlParameter();
            sqlParams[3].ParameterName = "@seq";
            sqlParams[3].DbType = DbType.Int32;
            sqlParams[3].Direction = System.Data.ParameterDirection.Input;
            sqlParams[3].Value = entity.lovvalueseq;

            sqlParams[4] = new SqlParameter();
            sqlParams[4].ParameterName = "@field1";
            sqlParams[4].DbType = DbType.String;
            sqlParams[4].Direction = System.Data.ParameterDirection.Input;
            sqlParams[4].Value = entity.field1_value;

            sqlParams[5] = new SqlParameter();
            sqlParams[5].ParameterName = "@field2";
            sqlParams[5].DbType = DbType.String;
            sqlParams[5].Direction = System.Data.ParameterDirection.Input;
            sqlParams[5].Value = entity.field2_value;

            sqlParams[6] = new SqlParameter();
            sqlParams[6].ParameterName = "@field3";
            sqlParams[6].DbType = DbType.String;
            sqlParams[6].Direction = System.Data.ParameterDirection.Input;
            sqlParams[6].Value = entity.field3_value;

            sqlParams[7] = new SqlParameter();
            sqlParams[7].ParameterName = "@active";
            sqlParams[7].DbType = DbType.String;
            sqlParams[7].Direction = System.Data.ParameterDirection.Input;
            sqlParams[7].Value = entity.statusActive;

            sqlParams[8] = new SqlParameter();
            sqlParams[8].ParameterName = "@userid";
            sqlParams[8].DbType = DbType.String;
            sqlParams[8].Direction = System.Data.ParameterDirection.Input;
            sqlParams[8].Value = entity.createduser;

            sqlParams[9] = new SqlParameter();
            sqlParams[9].ParameterName = "@code";
            sqlParams[9].DbType = DbType.String;
            sqlParams[9].Direction = System.Data.ParameterDirection.Input;
            sqlParams[9].Value = entity.lovcode;

            sqlParams[10] = new SqlParameter();
            sqlParams[10].ParameterName = "@output";
            sqlParams[10].DbType = DbType.Int32;
            sqlParams[10].Direction = System.Data.ParameterDirection.Output;
            sqlParams[10].Size = 100;

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = sqlConn;
            sqlCmd.Transaction = sqlTrans;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "dbo.Lov_Details_Insert";
            sqlCmd.Parameters.AddRange(sqlParams);
            returnResult = sqlCmd.ExecuteNonQuery();
            returnResult = Convert.ToInt32(sqlParams[10].Value);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return returnResult;
    }

    public int LovDetailsUpdate(LovDetailsListEntity entity, string newLovCode, SqlConnection sqlConn, SqlTransaction sqlTrans)
    {
        int returnResult = 0;
        try
        {
            SqlParameter[] sqlParams = new SqlParameter[11];

            sqlParams[0] = new SqlParameter();
            sqlParams[0].ParameterName = "@lov_type";
            sqlParams[0].DbType = DbType.String;
            sqlParams[0].Direction = System.Data.ParameterDirection.Input;
            sqlParams[0].Value = entity.lovtype;

            sqlParams[1] = new SqlParameter();
            sqlParams[1].ParameterName = "@lov_shrt_desc";
            sqlParams[1].DbType = DbType.String;
            sqlParams[1].Direction = System.Data.ParameterDirection.Input;
            sqlParams[1].Value = DBNullValueorStringIfNotNull(entity.lovshrtdesc);

            sqlParams[2] = new SqlParameter();
            sqlParams[2].ParameterName = "@lov_value";
            sqlParams[2].DbType = DbType.String;
            sqlParams[2].Direction = System.Data.ParameterDirection.Input;
            sqlParams[2].Value = DBNullValueorStringIfNotNull(entity.lovvalue);

            sqlParams[3] = new SqlParameter();
            sqlParams[3].ParameterName = "@lov_value_seq";
            sqlParams[3].DbType = DbType.Int32;
            sqlParams[3].Direction = System.Data.ParameterDirection.Input;
            sqlParams[3].Value = entity.lovvalueseq;

            sqlParams[4] = new SqlParameter();
            sqlParams[4].ParameterName = "@lov_field1_value";
            sqlParams[4].DbType = DbType.String;
            sqlParams[4].Direction = System.Data.ParameterDirection.Input;
            sqlParams[4].Value = DBNullValueorStringIfNotNull(entity.field1_value);

            sqlParams[5] = new SqlParameter();
            sqlParams[5].ParameterName = "@lov_field2_value";
            sqlParams[5].DbType = DbType.String;
            sqlParams[5].Direction = System.Data.ParameterDirection.Input;
            sqlParams[5].Value = entity.field2_value;

            sqlParams[6] = new SqlParameter();
            sqlParams[6].ParameterName = "@lov_field3_value";
            sqlParams[6].DbType = DbType.String;
            sqlParams[6].Direction = System.Data.ParameterDirection.Input;
            sqlParams[6].Value = entity.field3_value;

            sqlParams[7] = new SqlParameter();
            sqlParams[7].ParameterName = "@active";
            sqlParams[7].DbType = DbType.String;
            sqlParams[7].Direction = System.Data.ParameterDirection.Input;
            sqlParams[7].Value = entity.statusActive;

            sqlParams[8] = new SqlParameter();
            sqlParams[8].ParameterName = "@created_user";
            sqlParams[8].DbType = DbType.String;
            sqlParams[8].Direction = System.Data.ParameterDirection.Input;
            sqlParams[8].Value = entity.createduser;

            sqlParams[9] = new SqlParameter();
            sqlParams[9].ParameterName = "@lov_code";
            sqlParams[9].DbType = DbType.String;
            sqlParams[9].Direction = System.Data.ParameterDirection.Input;
            sqlParams[9].Value = entity.lovcode;

            sqlParams[10] = new SqlParameter();
            sqlParams[10].ParameterName = "@new_lov_code";
            sqlParams[10].DbType = DbType.String;
            sqlParams[10].Direction = System.Data.ParameterDirection.Input;
            sqlParams[10].Value = newLovCode;

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = sqlConn;
            sqlCmd.Transaction = sqlTrans;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "dbo.Lov_Details_Update";
            sqlCmd.Parameters.AddRange(sqlParams);
            returnResult = sqlCmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return returnResult;
    }
    
    public DataSet CheckLovDetails(string lov_type, string lov_code)
    {
        System.Data.DataSet ds;
        SqlParameter[] sqlParams = new SqlParameter[2];

        sqlParams[0] = new SqlParameter();
        sqlParams[0].ParameterName = "@lov_type";
        sqlParams[0].DbType = DbType.String;
        sqlParams[0].Direction = System.Data.ParameterDirection.Input;
        sqlParams[0].Value = lov_type;

        sqlParams[1] = new SqlParameter();
        sqlParams[1].ParameterName = "@lov_code";
        sqlParams[1].DbType = DbType.String;
        sqlParams[1].Direction = System.Data.ParameterDirection.Input;
        sqlParams[1].Value = lov_code;
        ds = DBFactory.GetHelper().ExecuteDataSet("dbo.LovDetails_checkLovDetails", System.Data.CommandType.StoredProcedure, sqlParams);
        return ds;
    }    
}