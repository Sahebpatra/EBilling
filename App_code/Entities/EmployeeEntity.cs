using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for EmployeeEntity
/// </summary>
public class EmployeeEntity
{
    public EmployeeEntity()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public long ed_emp_id { get; set; }
    public string ed_name { get; set; }
    public string ed_address { get; set; }
    public string ed_department { get; set; }
    public string ed_designation { get; set; }
    public string ed_mobile_no { get; set; }
    public string ed_email_id { get; set; }
    public SqlDateTime ed_joining_date { get; set; }
    public string created_user { get; set; }
    public string active { get; set; }
    public Int32 ed_category_id { get; set; }
    public SqlDateTime ed_date_of_leaving { get; set; }
    public string ed_employee_under_code { get; set; }
    public string ed_third_party_name { get; set; }
    public decimal ed_salary { get; set; }
    public string user_action { get; set; }
}