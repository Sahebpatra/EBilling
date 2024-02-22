using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MemberAddressEntity
/// </summary>
public class MemberAddressEntity
{
    public MemberAddressEntity()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string MemberGuid { get; set; }
    public string AddressLine1 { get; set; }
    public string AddressLine2 { get; set; }
    public string AddressLine3 { get; set; }
    public string City { get; set; }
    public string DistrictName { get; set; }
    public Int32 StateId { get; set; }
    public Int32 PinCode { get; set; }
    public bool IsPrimary { get; set; }
    public string CreatedUser { get; set; }
    public SqlDateTime CreatedDate { get; set; }
    public bool IsActive { get; set; }
}