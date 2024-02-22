using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace EBilling
{
    public class UserProfile
    {
        public string UserId { get; set; }
        public string UserPassword { get; set; }
        public string UserFirstName { get; set; }
        public string UserMiddleName { get; set; }
        public string UserLastName { get; set; }
        public string GroupCode { get; set; }
        public string Desig { get; set; }
        public string Dept { get; set; }
        public string MailId { get; set; }
        public string MobileNo { get; set; }
        public SqlDateTime DOB { get; set; }
        public SqlDateTime? DOJ { get; set; }
        public string CreatedUser { get; set; }
        public DateTime? CreatedDate { get; set; }
       // set value
        public Int64 Company_Id { get; set; }


        public string Active { get; set; }
        public string UserNewPassword { get; set; }
        public string SeconadaryMobileNo { get; set; }
        public string usp_gender { get; set; }
        public string usp_interest { get; set; }
        public string SelectedDealer { get; set; }
        public string SelectedDealerName { get; set; }
        public string usp_profile_pic { get; set; }
        public CompanyDetail company_detail { get; set; }
        public string usp_force_login_yn { get; set; }
        public string blood_group { get; set; }
    }

    public class CompanyDetail
    {
        public long cd_id { get; set; }
        public string cd_company_name { get; set; }
        public string cd_company_name_short { get; set; }
        public string cd_add1 { get; set; }
        public string cd_add2 { get; set; }
        public string cd_city { get; set; }
        public string cd_pin { get; set; }
        public string cd_state { get; set; }
        public string cd_country { get; set; }
        public string cd_mob1 { get; set; }
        public string cd_mob2 { get; set; }
        public string cd_mail_id { get; set; }
        public string created_user { get; set; }
        public string active { get; set; }
    }
}