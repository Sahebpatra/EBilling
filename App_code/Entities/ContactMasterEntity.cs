using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ContactMasterEntity
/// </summary>
public class ContactMasterEntity
{
    public Int32 cm_id { get; set; }
    public string contact_name { get; set; }
    public string contact_number { get; set; }
    public string contact_seq { get; set; }
    public string created_user { get; set; }
    public string active { get; set; }
    public string action { get; set; }
}