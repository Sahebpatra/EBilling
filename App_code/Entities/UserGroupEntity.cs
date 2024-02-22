using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserGroupEntity
/// </summary>
public class UserGroupEntity
{
    //public UserGroupEntity()
    //{
    //    //
    //    // TODO: Add constructor logic here
    //    //
    //}

    private string company_code;
    private string company_name;
    private string user_group_code;
    private string user_group_desc;
    private string user_group_type;
    private int user_group_level;
    private string created_user;
    private string active;

    public UserGroupEntity()
    {
        company_code = string.Empty;
        company_name = string.Empty;
        user_group_code = string.Empty;
        user_group_desc = string.Empty;
        user_group_type = string.Empty;
        user_group_level = int.MinValue;
        created_user = string.Empty;
        active = string.Empty;
    }

    public string companyCode
    {
        get
        {
            return company_code;
        }
        set
        {
            company_code = value;
        }
    }

    public string companyName
    {
        get
        {
            return company_name;
        }
        set
        {
            company_name = value;
        }
    }

    public string userGroupCode
    {
        get
        {
            return user_group_code;
        }
        set
        {
            user_group_code = value;
        }
    }

    public string userGroupDesc
    {
        get
        {
            return user_group_desc;
        }
        set
        {
            user_group_desc = value;
        }
    }

    public string userGroupType
    {
        get
        {
            return user_group_type;
        }
        set
        {
            user_group_type = value;
        }
    }

    public int userGroupLevel
    {
        get
        {
            return user_group_level;
        }
        set
        {
            user_group_level = value;
        }
    }

    public string createdUser
    {
        get
        {
            return created_user;
        }
        set
        {
            created_user = value;
        }
    }

    public string statusActive
    {
        get
        {
            return active;
        }
        set
        {
            active = value;
        }
    }
}