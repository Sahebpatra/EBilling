using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserOTPDetailsEntity
/// </summary>
public class UserOTPDetailsEntity
{
    public UserOTPDetailsEntity()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public long uod_id { get; set; }
    public string uod_user_id { get; set; }
    public string uod_mobile_no { get; set; }
    public Int32 uod_otp { get; set; }
    public string uod_status { get; set; }
    public SqlDateTime uod_otp_expiry { get; set; }
    public string created_user { get; set; }
    public string active { get; set; }
}