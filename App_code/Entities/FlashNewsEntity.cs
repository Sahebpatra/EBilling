using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FlashNewsEntity
/// </summary>
public class FlashNewsEntity
{
    public FlashNewsEntity()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public Int32 flash_srlno { get; set; }
    public string flash_company { get; set; }
    public string flash_userid { get; set; }
    public string flash_msg { get; set; }
    public SqlDateTime flash_to { get; set; }
    public SqlDateTime flash_retain_till { get; set; }
    public string created_user { get; set; }
    public string active { get; set; }
    public string flash_title { get; set; }
}