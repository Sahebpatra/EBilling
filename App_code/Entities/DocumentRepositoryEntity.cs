using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DocumentRepositoryEntity
/// </summary>
public class DocumentRepositoryEntity
{
    public long dr_doc_id { get; set; }
    public string dr_doc_type { get; set; }
    public string dr_doc_name { get; set; }
    public string dr_doc_path { get; set; }
    public string dr_remarks { get; set; }
    public string created_user { get; set; }
    public string active { get; set; }
    public string action { get; set; }
}