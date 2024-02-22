using System.Net;
using System.Net.Mail;
using System.IO;
using System;
using System.Data;
using System.Text;
using System.Configuration;

namespace EBilling.EmailSms
{
    public class Settings
    {
        public string SMTP_HOST = ConfigurationManager.AppSettings.Get("SMTP_HOST");
        public int SMTP_PORT = Convert.ToInt16(ConfigurationManager.AppSettings.Get("SMTP_PORT"));
        public string EmailId = ConfigurationManager.AppSettings.Get("EMAIL_ADDRESS");
        public string Password = ConfigurationManager.AppSettings.Get("EMAIL_PSW");

        public const string SMS_ID = "";
        public string SMS_USER = ConfigurationManager.AppSettings.Get("SMS_USER");
        public string SMS_PSW = ConfigurationManager.AppSettings.Get("SMS_PSW");
        public string SMS_PREFIX = ConfigurationManager.AppSettings.Get("SMS_PREFIX");

        public string user = ConfigurationManager.AppSettings.Get("SMSUSER");
        public string msgSender = ConfigurationManager.AppSettings.Get("SENDERNAME");
        public string msgApiKey = ConfigurationManager.AppSettings.Get("MESSAGEAPIKEY");
        public string SMTPTYPE = ConfigurationManager.AppSettings.Get("SMTPTYPE");
    }
    public class EmailSMSsender
    {
        public string GetSMSID()
        {
            return Settings.SMS_ID;
        }
        public string GetSMSUser()
        {
            Settings settings = new Settings();
            return settings.user;
        }
        public string GetSMSPassword()
        {
            Settings settings = new Settings();
            return settings.SMS_PSW;
        }
        public string GetSMSPrefix()
        {
            Settings settings = new Settings();
            return settings.SMS_PREFIX;
        }
        public string GetEmail()
        {
            Settings settings = new Settings();
            return settings.EmailId;
        }
        public string GetPwd()
        {
            Settings settings = new Settings();
            return settings.Password;
        }

        public string GetMessageSender()
        {
            Settings settings = new Settings();
            return settings.msgSender;
        }

        public string GetSMTPTYPE()
        {
            Settings settings = new Settings();
            return settings.SMTPTYPE;
        }

        public string GetMessageAPIKey()
        {
            Settings settings = new Settings();
            return settings.msgApiKey;
        }

        #region Making to Send SMS
        public string SMSSender(string mobileNos, string message)
        {
            string formatingString = string.Empty;
            try
            {
                string[] address = mobileNos.Split(',');
                foreach (string mNo in address)
                {
                    if (string.IsNullOrEmpty(mNo))
                    {
                        continue;
                    }
                    formatingString = string.Concat("91", mNo);
                    SendSMS(formatingString, message);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return "done";
        }
        #endregion

        #region Send SMS
        public string SendSMS(string mobileNumber, string message)
        {
            //mobileNumber = "8013628024";       
            string functionReturnValue = string.Empty;
            string stringResult = string.Empty;
            HttpWebRequest httpWebRequest = null;
            HttpWebResponse httpWebResponse = null;
            StreamWriter streamWriter = null;
            StreamReader streamReader = null;
            WebProxy webProxy = null;
            try
            {
                object stringPost = string.Format("username={0}&message={1}&sendername={2}&smstype={3}&numbers={4}&apikey={5}", GetSMSUser(), message.ToString(), GetMessageSender(), GetSMTPTYPE(), mobileNumber, GetMessageAPIKey());
                httpWebRequest = (HttpWebRequest)WebRequest.Create("http://login.aquasms.com/sendSMS?");
                httpWebRequest.Method = "POST";
                httpWebRequest.Proxy = webProxy;
                httpWebRequest.ContentType = "application/x-www-form-urlencoded";
                streamWriter = new StreamWriter(httpWebRequest.GetRequestStream());
                streamWriter.Write(stringPost);
                streamWriter.Flush();
                streamWriter.Close();
                httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                streamReader = new StreamReader(httpWebResponse.GetResponseStream());
                stringResult = streamReader.ReadToEnd();
                streamReader.Close();
                return (stringResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                streamWriter.Close();
                streamReader.Close();
                httpWebRequest = null;
                httpWebResponse = null;
                webProxy = null;
            }
        }
        #endregion

        #region Send Email 
        public string sendMailHTML(MailEntity mailEntity)
        {
            string sendingreport = string.Empty;
            Settings Setting = new Settings();
            DataSet ds = new DataSet();
            MailMessage mail = new MailMessage();
            try
            {
                string[] mailaddress = new string[100];
                mail.From = new MailAddress(Setting.EmailId, "PSSSFOA MAIL SERVICE");
                string[] mailTo = mailEntity.ToAddress.Split(',');
                if (mailTo == null)
                {
                    return string.Empty;
                }
                foreach (string mTo in mailTo)
                {
                    if (mTo == null || string.IsNullOrEmpty(mTo))
                    {
                        continue;
                    }
                    mail.To.Add(new MailAddress(mTo));
                }

                if (mailEntity.CCAddress.Length > 0)
                {
                    string[] engCC = mailEntity.CCAddress.Split(',');
                    if (engCC == null)
                    {
                        return string.Empty;
                    }
                    foreach (string ccAdd in engCC)
                    {
                        if (ccAdd == null || string.IsNullOrEmpty(ccAdd))
                        {
                            continue;
                        }
                        mail.CC.Add(new MailAddress(ccAdd));
                    }
                }

                if (mailEntity.BCCAddress.Length > 0)
                {
                    string[] bccAdd = mailEntity.BCCAddress.Split(',');
                    if (bccAdd == null)
                    {
                        return string.Empty;
                    }
                    foreach (string bccA in bccAdd)
                    {
                        if (bccA == null || string.IsNullOrEmpty(bccA))
                        {
                            continue;
                        }
                        mail.Bcc.Add(new MailAddress(bccA));
                    }
                }

                mail.Subject = mailEntity.MailSubject;
                mail.BodyEncoding = Encoding.UTF8;
                mail.Body = mailEntity.MailBody;

                mail.IsBodyHtml = false;
                if (!string.IsNullOrEmpty(mailEntity.Attachment_Path))
                {
                    string[] atchPath = mailEntity.Attachment_Path.Split(';');
                    if (atchPath != null)
                    {
                        foreach (string item in atchPath)
                        {
                            if (item == null || string.IsNullOrEmpty(item))
                            {
                                continue;
                            }
                            mail.Attachments.Add(new Attachment(item.Trim()));
                          
                        }
                    }
                }

                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(mailEntity.MailBody, null, "text/html");
                mail.AlternateViews.Add(htmlView);

                var serv = new SmtpClient();
                serv.DeliveryMethod = SmtpDeliveryMethod.Network;
                serv.Host = Setting.SMTP_HOST;
                serv.Port = Setting.SMTP_PORT;
                serv.Credentials = new NetworkCredential(Setting.EmailId, Setting.Password);
                serv.EnableSsl = false;
                serv.Send(mail);

            }
            catch (Exception ex)
            {
                return "Email Sent Failed";
                throw ex;
            }
            finally
            {
                mail = null;
            }
            return "Email Sent Successfully";
        }
        #endregion

        #region Send Email With Attachment
        public string sendMailHTMLWithAttachment(MailEntity mailEntity, string path)
        {
            string sendingreport = string.Empty;
            Settings Setting = new Settings();
            DataSet ds = new DataSet();
            MailMessage mail = new MailMessage();
            try
            {
                string[] mailaddress = new string[100];
                mail.From = new MailAddress(Setting.EmailId, "PSSSFOA MAIL SERVICE");
                string[] mailTo = mailEntity.ToAddress.Split(',');
                if (mailTo == null)
                {
                    return string.Empty;
                }
                foreach (string mTo in mailTo)
                {
                    if (mTo == null || string.IsNullOrEmpty(mTo))
                    {
                        continue;
                    }
                    mail.To.Add(new MailAddress(mTo));
                }

                if (mailEntity.CCAddress.Length > 0)
                {
                    string[] engCC = mailEntity.CCAddress.Split(',');
                    if (engCC == null)
                    {
                        return string.Empty;
                    }
                    foreach (string ccAdd in engCC)
                    {
                        if (ccAdd == null || string.IsNullOrEmpty(ccAdd))
                        {
                            continue;
                        }
                        mail.CC.Add(new MailAddress(ccAdd));
                    }
                }

                if (mailEntity.BCCAddress.Length > 0)
                {
                    string[] bccAdd = mailEntity.BCCAddress.Split(',');
                    if (bccAdd == null)
                    {
                        return string.Empty;
                    }
                    foreach (string bccA in bccAdd)
                    {
                        if (bccA == null || string.IsNullOrEmpty(bccA))
                        {
                            continue;
                        }
                        mail.Bcc.Add(new MailAddress(bccA));
                    }
                }

                mail.Subject = mailEntity.MailSubject;
                mail.BodyEncoding = Encoding.UTF8;
                mail.Body = mailEntity.MailBody;

                mail.IsBodyHtml = false;
                if (!string.IsNullOrEmpty(mailEntity.Attachment_Path))
                {
                    string[] atchPath = mailEntity.Attachment_Path.Split(';');
                    if (atchPath != null)
                    {
                        foreach (string item in atchPath)
                        {                          
                            mail.Attachments.Add(new System.Net.Mail.Attachment(path));
                        }
                    }
                }

                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(mailEntity.MailBody, null, "text/html");
                mail.AlternateViews.Add(htmlView);

                var serv = new SmtpClient();
                serv.DeliveryMethod = SmtpDeliveryMethod.Network;
                serv.Host = Setting.SMTP_HOST;
                serv.Port = Setting.SMTP_PORT;
                serv.Credentials = new NetworkCredential(Setting.EmailId, Setting.Password);
                serv.EnableSsl = false;
                serv.Send(mail);

            }
            catch (Exception ex)
            {
                return "Email Sent Failed";
                throw ex;
            }
            finally
            {
                mail = null;
            }
            return "Email Sent Successfully";
        }
        #endregion
    }
}