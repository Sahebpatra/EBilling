using NPOI.HPSF;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SMSResponseEntity
/// </summary>
public class SMSResponseEntity
{
    public SMSResponseEntity()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string responseCode { get; set; }
    public long msgid { get; set; }
}