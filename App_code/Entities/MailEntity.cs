using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MailEntity
/// </summary>
namespace EBilling.EmailSms
{
    public class MailEntity
    {
        private string _FromAdd = string.Empty;
        private string _ToAdd = string.Empty;
        private string _CCAdd = string.Empty;
        private string _BccAdd = string.Empty;
        private string _Subject = string.Empty;
        private string _Body = string.Empty;
        private string _Attachment = string.Empty;

        public string FromAddress
        {
            get
            {
                return _FromAdd;
            }
            set
            {
                _FromAdd = value;
            }
        }
        public string ToAddress
        {
            get
            {
                return _ToAdd;
            }
            set
            {
                _ToAdd = value;
            }
        }
        public string CCAddress
        {
            get
            {
                return _CCAdd;
            }
            set
            {
                _CCAdd = value;
            }
        }
        public string BCCAddress
        {
            get
            {
                return _BccAdd;
            }
            set
            {
                _BccAdd = value;
            }
        }
        public string MailSubject
        {
            get
            {
                return _Subject;
            }
            set
            {
                _Subject = value;
            }
        }
        public string MailBody
        {
            get
            {
                return _Body;
            }
            set
            {
                _Body = value;
            }
        }
        public string Attachment_Path
        {
            get
            {
                return _Attachment;
            }
            set
            {
                _Attachment = value;
            }
        }
    }
}