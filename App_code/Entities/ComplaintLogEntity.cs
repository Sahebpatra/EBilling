using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ComplaintLogEntity
/// </summary>
public class ComplaintLogEntity
{
    public ComplaintLogEntity()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public long cl_log_id { get; set; }
    public long cl_complaint_id { get; set; }
    public string cl_log_desc { get; set; }
    public string cl_complaint_status { get; set; }
    public string cl_remarks { get; set; }
    public string created_user { get; set; }
    public string active { get; set; }
}