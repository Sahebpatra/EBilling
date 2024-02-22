using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserTransactionCredentialEntity
/// </summary>
public class UserTransactionCredentialEntity
{
    public UserTransactionCredentialEntity()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string utc_user_id { get; set; }
    public string utc_transaction_password { get; set; }
    public string utc_transaction_password_old1 { get; set; }
    public string utc_transaction_password_old2 { get; set; }
    public string utc_transaction_password_old3 { get; set; }
    public string created_user { get; set; }
    public string active { get; set; }
    public string account_password { get; set; }
    public string utc_old_transaction_password { get; set; }
}