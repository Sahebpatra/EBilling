using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserProfileEntity
/// </summary>
public class UserProfileEntity
{
    public UserProfileEntity()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string usppswd { get; set; }
    public string uspuserid { get; set; }
    public string createduser { get; set; }
    public string modifieduser { get; set; }
    public string uspfirstname { get; set; }
    public string usplastname { get; set; }
    public string uspgroupcode { get; set; }
    public string uspdept { get; set; }
    public string uspmailid { get; set; }
    public string uspmobile { get; set; }
    public string uspdesig { get; set; }
    public SqlDateTime uspdob { get; set; }
    public SqlDateTime uspdoj { get; set; }
    public string uspdepot { get; set; }
    public string statusActive { get; set; }
    public string uspemployeeid { get; set; }
    public string usptrackingYN { get; set; }
    public string FileName { get; set; }
    public string HasFile { get; set; }

    //public string statusActive { get; set; }
    //public string statusActive { get; set; }
    public string usp_employee_id { get; set; }
    public string usp_gender { get; set; }
    public string usp_address1 { get; set; }
    public string usp_address2 { get; set; }
    public string usp_city { get; set; }
    public string usp_state { get; set; }
    public string usp_aadhar_no { get; set; }
    public string usp_pan_no { get; set; }
    public string usp_admin_approve_yn { get; set; }
    public string usp_admin_approve_by { get; set; }
    public string usp_sms_sent_yn { get; set; }
    public string usp_mail_sent_yn { get; set; }
    public string usp_reporting_head { get; set; }
    public string usp_reporting_desig { get; set; }
    public string usp_reporting_mailid { get; set; }
    public string usp_action { get; set; }
    public string usp_marital_status { get; set; }
    public string usp_profession { get; set; }
    public string usp_qualification { get; set; }
    public string usp_country { get; set; }
    public string usp_pincode { get; set; }
    public string sponsor_id { get; set; }
    public string upline_id { get; set; }
    public string father_name { get; set; }
    public string usp_blood_group { get; set; }
    public string usp_service_provider { get; set; }
    public string usp_service_provider_state { get; set; }
    public string usp_profile_pic { get; set; }
    public string usp_transaction_password { get; set; }
    public string usp_salutation { get; set; }
}