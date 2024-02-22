using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ComplaintTypeEntity
/// </summary>
public class ComplaintTypeEntity
{
    public Int32 ct_id { get; set; }
    public string ct_complaint_type { get; set; }
    public string created_user { get; set; }
    public string active { get; set; }
    public string action { get; set; }
}