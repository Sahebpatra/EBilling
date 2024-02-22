using EBilling.DataAccess;
using System.Data;
using System.Data.SqlClient;

public class UserProfileListClass
{
    public UserProfileListClass()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataSet GetUserGroupList()
    {
        DataSet ResultSet = new DataSet();
        ResultSet = DBFactory.GetHelper().ExecuteDataSet("[UserProfile_getUserGroupCode]", System.Data.CommandType.StoredProcedure);
        return ResultSet;
    }
    public DataSet UserProfileListGet(string UserGroup, string UserName, string UserDepot, string UserId)
    {
        DataSet ResultSet = new DataSet();
        SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@usp_group_code",SqlDbType.VarChar){Value=CommonModule.DBNullValueorStringIfNotNull(UserGroup)},
                new SqlParameter("@user_name",SqlDbType.VarChar){Value=CommonModule.DBNullValueorStringIfNotNull(UserName)},
                new SqlParameter("@usp_depot",SqlDbType.VarChar){Value=CommonModule.DBNullValueorStringIfNotNull(UserDepot)},
                new SqlParameter("@usp_user_ID",SqlDbType.VarChar){Value=CommonModule.DBNullValueorStringIfNotNull(UserId)}
            };
        ResultSet = DBFactory.GetHelper().ExecuteDataSet("[UserProfile_getUserProfile_List]", System.Data.CommandType.StoredProcedure, sqlParams);
        return ResultSet;
    }
}