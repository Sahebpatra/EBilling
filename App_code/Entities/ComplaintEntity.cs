using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ComplaintEntity
/// </summary>
public class ComplaintEntity
{
    public ComplaintEntity()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public long cm_complaint_id { get; set; }
    public string cm_complaint_type { get; set; }
    public SqlDateTime cm_complaint_date { get; set; }
    public string cm_complaint_desc { get; set; }
    public string cm_complaint_raised_by { get; set; }
    public string cm_complaint_status { get; set; }
    public string cm_remarks { get; set; }
    public string created_user { get; set; }
    public string active { get; set; }
    public string user_action { get; set; }
}