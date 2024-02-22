using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FormMenuMasterEntity
/// </summary>
public class FormMenuMasterEntity
{
    public object fmm_PageName;
    public string fmm_WebsiteName;
    public string fmm_SectionName;
    public string fmm_OrgName;

    public FormMenuMasterEntity()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int fmm_id { get; set; }
    public string fmm_name { get; set; }
    public string fmm_link { get; set; }
    public int fmm_parent_id { get; set; }
    public int fmm_sequence { get; set; }
    public string created_user { get; set; }
    public DateTime created_date { get; set; }
    public string modified_user { get; set; }
    public DateTime modified_date { get; set; }
    public string deleted_user { get; set; }
    public DateTime deleted_date { get; set; }
    public string active { get; set; }

}