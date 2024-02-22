using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZXing;

/// <summary>
/// Summary description for Constant
/// </summary>
public class Constant
{
    public class Common
    {

        public const string Company = "British";
        public const string ChangePwd = "9999";

        public const string ActiveStatus = "Y";
        public const string REGION = "REGION";
        public const string InActiveStatus = "N";
        public const string Active = "Active";
        public const string InActive = "InActive";

        public const string All = "All";
        public const string Selec = "Select";
        public const string Doc_Type = "DOC_TYPE";
        public const string Yes = "Yes";
        public const string No = "No";

        public const string SMTP_HOST = "216.12.200.133";
        public const int SMTP_PORT = 25;

        public const string MAIL_NETWORK_CREDENTIAL_USERNAME = "mailservice@bergerapps.in";
        public const string MAIL_NETWORK_CREDENTIAL_PASSWORD = "ram1653$";

        public const string UserGroup_Dealer = "DEALER";


        public const string RegistrationStatus_Pending = "Pending";
        public const string RegistrationStatus_Approved = "Approved";
        public const string RegistrationStatus_Rejected = "Rejected";

        public const string DBName = "[BRITISHDB].";
        public const string SCHEMA_COM = "[mstr].";
        public const string SCHEMA_APP = "[mobapp].";

        public const string login_url = "http://loginport.co.in/";
    }

    public class ErrorMessages
    {
        public const string GeneralError = "An error has ocurred.Contact Administrator.";
        public const string InvalidLoginMessage = "Enter valid user id/password.";
        public const string UserNotActiveMessage = "Your account is currently Inactive. Please contact Administrator.";
        public const string CommissionCalculationError = "An error has ocurred during commission calculation. Please contact Administrator.";
    }

    public class ReportName
    {
        public const string SOAReport = @"\SOAReport.rpt";
        public const string VoucherDetailsReport = @"\VoucherDetailsReport.rpt";
        public const string MoneyReceiptDetailsReport = @"\MoneyReceiptDetailsReport.rpt";
    }

    public class ReportView
    {
        public const string ReportFileLoc = "CrystalReport_Templates";
    }

    public const string ExceptionReturnUrl = "~/ExceptionPage.aspx";
    public const string DealerExceptionReturnUrl = "~/DealerExceptionPage.aspx";

    public class SessionKeys
    {
        public const string UserInfo = "UserInfo";
        public const string User = "User";
        public const string Company = "Company";
        public const string UID = "UID";
        public const string UFN = "UFN";
        public const string ULN = "ULN";
        public const string UEMAIL = "UEMAIL";
        public const string DEPT = "DEPT";
        public const string ErrMessage = "Err: Contact Administrator";
        public const string UserId = "UserId";
        public const string Roles = "Roles";
        public const string SelectedDealer = "SelectedDealer";
        public const string SelectedDealerName = "SelectedDealerName";
        public const string ProductDetails = "ProductDetails";

    }

    public class GeneralMessages
    {
        public const string SaveSuccess = "Data Saved Successfully";
        public const string UpdateSuccess = "Data Updated Successfully";
        public const string btnUpdate = "Update";
        public const string btnSubmit = "Submit";
        public const string AddNew = "New";
        public const string GenCode = "GenCode";
        public const string Submit = "Submit";
        public const string ProjectCode = "ProjectCode";
        public const string btnDelete = "Delete";
        public const string Back = "Back";
        public const string btnNexts = "Next ";
    }


    public enum FolderName
    {
        SCHEME_DOCS,
        PRODUCT_DETAILS_IMAGES,
        PRODUCT_COMPANY_LOGOS,
        PRODUCT_COMPARISON_IMAGES,
        PRODUCT_IMAGES,
        PRODUCT_SURFACE_IMAGES,
        MESSAGE_IMAGES,
        PAINTER_NOMINATION_IMAGES,
        MAPPING_CUSTOMER_IMAGE
    }

    public enum LovType
    {
        BLOOD_GROUP,
        COUNTRY,
        PROFESSION,
        SERVICE_PROVIDER,
        NOMI_RELATION,
        ADJUSTMENT_TYPE,
        SALUTATION,
        COMPLAINT_TYPE,
        COMPLAINT_STATUS,
        SUB_INVENTORY,
        NEW_LOCATER,
        RETURNED_LOCATER,
    }

    public enum UserGroupCode
    {
        ADMIN,
        ASSOCIATE,
        SUPERADMIN,
        SYSADMIN
    }

    public enum LovCode
    {
        ACCOUNT_MANAGEMENT
    }

    public enum PainterNominationStatus
    {
        Approved,
        Pending,
        Rejected
    }

    public enum AppName
    {
        SSMS,
        ECF
    }

    public enum GiftType
    {
        CN,
        Gift
    }
    public enum ColorMenuProductType
    {
        ALL,
        EMUL
    }
    public enum UserAction
    {
        INSERT,
        UPDATE,
        DELETE,
        ACTIVE_INACTIVE,
        VOUCHER_APPROVAL,
        VOUCHER_STATUS,
        CANCEL,
        APPROVE,
        REJECT
    }
    public enum FileType
    {
        PNG,
        JPEG,
        JPG,
        GIF,
        DOC,
        DOCS,
        PDF
    }
    public enum VendorType
    {
        Berger,
        OtherVendor
    }
    public enum PrevPage
    {
        VOUCHER_ENTRY,
        VOUCHER_RECONCILIATION
    }
    public enum VoucherApproval
    {
        PENDING,
        APPROVED
    }
    public enum VoucherStatus
    {
        PENDING,
        CLEARED
    }

    public enum PaymentStatus
    {
        PENDING,
        CLEARED,
        CANCEL
    }

    public enum ComplaintStatus
    {
        PENDING,
        CANCEL,
        CLOSED,
        IN_PROGRESS
    }
    public enum PaymentBy
    {
        OTHERS
    }
    public enum EmployeeUnder
    {
        OWN,
        THIRD_PARTY
    }
    public enum PaymentMode
    {
        CHEQUE,
        CASH
    }
    public enum PurchaseType
    {
        P,
        R
    }
    public enum AdjustmentType
    {
        P,
        R
    }

    public enum FranchiseStatus
    {
        P,
        A,
        R
    }

    public enum WalletType
    {
        RW,
        IW
    }

    public enum AdminUser
    {
        Admin
    }

    public enum ItemRequestStatus
    {
        PENDING,
        DESPATCHED,
        REJECTED,
        RECEIVED
    }

    public enum TransactionType
    {
        STOCK_IN,
        STOCK_OUT,
        STOCK_TRANSFER
    }
}