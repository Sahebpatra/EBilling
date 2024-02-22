using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for LovDetailsListEntity
/// </summary>
public class LovDetailsListEntity
{
    //public LovDetailsListEntity()
    //{
    //    //
    //    // TODO: Add constructor logic here
    //    //
    //}

    private string lov_type;
    private string lov_code;
    private string lov_value;
    private string lov_shrt_desc;
    private int lov_value_seq;
    private string lov_field1_value;
    private string lov_field2_value;
    private string lov_field3_value;
    private string created_user;
    private DateTime created_date;
    private string modified_user;
    private DateTime modified_date;
    private string active;

    public LovDetailsListEntity()
    {
        lov_type = string.Empty;
        lov_code = string.Empty;
        lov_value = string.Empty;
        lov_shrt_desc = string.Empty;
        lov_value_seq = int.MinValue;
        lov_field1_value = string.Empty;
        lov_field2_value = string.Empty;
        lov_field3_value = string.Empty;
        created_user = string.Empty;
        created_date = DateTime.MinValue;
        modified_user = string.Empty;
        modified_date = DateTime.MinValue;
        active = string.Empty;
    }

    public string lovtype
    {
        get
        {
            return lov_type;
        }
        set
        {
            lov_type = value;
        }
    }

    public string lovcode
    {
        get
        {
            return lov_code;
        }
        set
        {
            lov_code = value;
        }
    }

    public string lovvalue
    {
        get
        {
            return lov_value;
        }
        set
        {
            lov_value = value;
        }
    }

    public string lovshrtdesc
    {
        get
        {
            return lov_shrt_desc;
        }
        set
        {
            lov_shrt_desc = value;
        }
    }

    public int lovvalueseq
    {
        get
        {
            return lov_value_seq;
        }
        set
        {
            lov_value_seq = value;
        }
    }
    public string field1_value
    {
        get
        {
            return lov_field1_value;
        }
        set
        {
            lov_field1_value = value;
        }
    }
    public string field2_value
    {
        get
        {
            return lov_field2_value;
        }
        set
        {
            lov_field2_value = value;
        }
    }
    public string field3_value
    {
        get
        {
            return lov_field3_value;
        }
        set
        {
            lov_field3_value = value;
        }
    }

    public string createduser
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

    public DateTime createddate
    {
        get
        {
            return created_date;
        }
        set
        {
            created_date = value;
        }
    }

    public string modifieduser
    {
        get
        {
            return modified_user;
        }
        set
        {
            modified_user = value;
        }
    }

    public DateTime modifieddate
    {
        get
        {
            return created_date;
        }
        set
        {
            created_date = value;
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