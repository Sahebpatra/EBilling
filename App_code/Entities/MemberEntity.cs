using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MemberEntity
/// </summary>
public class MemberEntity
{
    public MemberEntity()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string MemberGuid { get; set; }
    public string MemberNo { get; set; }
    public string MemberSalutation { get; set; }
    public string MemberFirstName { get; set; }
    public string MemberMiddleName { get; set; }
    public string MemberLastName { get; set; }
    public string MemberFathersName { get; set; }
    public SqlDateTime MemberDateOfAppointment { get; set; }
    public Int32 DesignationId { get; set; }
    public Int32 DepartmentId { get; set; }
    public Int32 PersonalNo { get; set; }
    public SqlDateTime DateOfBirth { get; set; }
    public string PFAccountNo { get; set; }
    public Int32 SalaryAccountNo { get; set; }
    public string PayRollNo { get; set; }
    public string CreatedUser { get; set; }
    public SqlDateTime CreatedDate { get; set; }
    public bool IsActive { get; set; }
    public string ModifiedUser { get; set; }
}