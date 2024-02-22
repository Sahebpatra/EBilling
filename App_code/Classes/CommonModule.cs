using System;
using System.Data;
using System.Web;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlTypes;
using System.Collections;
using Microsoft.VisualBasic;
using System.Security.Permissions;
using Microsoft.Win32;
using System.IO;
using System.Text;
using System.Globalization;
using System.Web.Script.Serialization;
using System.Net;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography;
using EBilling.EmailSms;
using System.ComponentModel;
using System.Drawing.Imaging;
using ZXing;
using ZXing.Common;
using EBilling.DataAccess;

/// <summary>
/// Summary description for CommonModule
/// </summary>
public static class CommonModule
{

    static string fcmAPIKey = ConfigurationManager.AppSettings.Get("FCMAPIKey");
    static string fcmProjectNumber = ConfigurationManager.AppSettings.Get("FCMProjectNumber");
    public static bool IsNumeric(this string text)
    {
        double test;
        return double.TryParse(text, out test);
    }
    public static T IIf<T>(bool expression, T truePart, T falsePart)
    { return expression ? truePart : falsePart; }
    public static bool IsDate(object inputDate)
    {
        if (inputDate == null)
        {
            return false;
        }
        DateTime dt;
        bool isdate = DateTime.TryParse(inputDate.ToString(), out dt);
        return isdate;
    }
    public static SqlDateTime FormatDate(string stringdate)
    {
        if (string.IsNullOrEmpty(stringdate))
        {
            return SqlDateTime.MinValue;
        }
        string[] ddate = stringdate.Split(new char[] { '/', '-' }, StringSplitOptions.RemoveEmptyEntries);
        ArrayList arrlist = new ArrayList();
        int index = 0;

        while (index <= ddate.Length - 1)
        {
            arrlist.Add(ddate[index]);
            Math.Min(System.Threading.Interlocked.Increment(ref index), index - 1);
        }

        string dateString = string.Concat(arrlist[0], "-", arrlist[1], "-", arrlist[2], " ", "00:00");
        string format = "yyyy-MM-dd HH:mm";

        DateTime dt = DateTime.ParseExact(dateString, format, CultureInfo.InvariantCulture);
        return dt;
    }
    public static string GetMIMEType(string filepath)
    {
        RegistryPermission regPerm = new RegistryPermission(RegistryPermissionAccess.Read, "\\HKEY_CLASSES_ROOT");
        RegistryKey classesRoot = Registry.ClassesRoot;
        var fileInfo = new FileInfo(filepath);
        string dotExt = (fileInfo.Extension).ToLower();
        RegistryKey typeKey = classesRoot.OpenSubKey(@"MIME\Database\Content Type");
        foreach (string keyname in typeKey.GetSubKeyNames())
        {
            RegistryKey curKey = classesRoot.OpenSubKey(@"MIME\Database\Content Type\" + keyname);
            if (curKey.GetValue("Extension") == null)
            {
                continue;
            }
            if (string.Compare(curKey.GetValue("Extension").ToString(), dotExt, StringComparison.CurrentCultureIgnoreCase) == 0)
            {
                return keyname;
            }
        }
        return string.Empty;
    }

    internal static object DBNullValueorStringIfNotNull(object fmm_PageName)
    {
        throw new NotImplementedException();
    }

    public static string EncodeDecodedText(string description, string type)
    {
        string returnString = string.Empty;
        try
        {
            if (string.IsNullOrEmpty(description))
            {
                return returnString;
            }
            switch (type)
            {
                case "ENCODE":
                    byte[] byteEncode = System.Text.Encoding.UTF8.GetBytes(description);
                    returnString = Convert.ToBase64String(byteEncode);
                    break;
                case "DECODE":
                    byte[] byteDecode = Convert.FromBase64String(description);
                    returnString = Encoding.UTF8.GetString(byteDecode);
                    break;
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return returnString;
    }
    public static string GetCommaseparatedString(CheckBoxList chkListItem)
    {
        string returnString = string.Empty;
        try
        {
            if (chkListItem == null)
            {
                return returnString;
            }
            foreach (ListItem item in chkListItem.Items)
            {
                if (item == null)
                {
                    continue;
                }
                if (item.Selected)
                {
                    returnString = string.IsNullOrEmpty(returnString) ? item.Value : string.Concat(returnString, ",", item.Value);
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return returnString;
    }
    public static string[] GetFileName(FileUpload fileUpload, string pageName, string docType, string productName)
    {
        string[] returnString = new string[2];
        string fileName = string.Empty;
        string extension = string.Empty;
        try
        {
            if (!fileUpload.HasFile)
            {
                return null;
            }
            fileName = Path.GetFileName(fileUpload.PostedFile.FileName);

            if (fileName.LastIndexOf(".") >= 0)
            {
                extension = fileName.Substring(fileName.LastIndexOf(".") + 1);
                var date = DateTime.Now.ToString("yyMMdd");
                var time = DateTime.Now.ToString("HHmmss");
                docType = Regex.Replace(docType, @"[^\w\d]", "_");
                productName = Regex.Replace(productName, @"[^\w\d]", "_");
                fileName = string.IsNullOrEmpty(productName) ? string.Format("{0}_{1}_{2}_{3}.{4}", pageName.Replace(" ", "_"), docType.Replace(" ", "_"), date, time, extension).ToString() : string.Format("{0}_{1}_{2}_{3}_{4}.{5}", pageName.Replace(" ", "_").Trim(), docType.Replace(" ", "_").Trim(), productName.Length > 100 ? productName.Substring(0, 99).ToString().Replace(" ", "_").Trim() : productName.Replace(" ", "_").Trim(), date, time, extension).ToString();
            }

            returnString[0] = fileName;
            returnString[1] = extension;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return returnString;
    }
    public static string GetTempOTP(int length)
    {
        StringBuilder returnPassword = null;
        try
        {
            const string valid = "1234567890";
            returnPassword = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                returnPassword.Append(valid[rnd.Next(valid.Length)]);
            }
            return returnPassword.ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public static DataTable ToDataTable<T>(List<T> items)
    {
        DataTable dataTable = new DataTable(typeof(T).Name);
        PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        foreach (PropertyInfo prop in Props)
        {
            dataTable.Columns.Add(prop.Name);
        }
        foreach (T item in items)
        {
            var values = new object[Props.Length];
            for (int i = 0; i < Props.Length; i++)
            {
                values[i] = Props[i].GetValue(item, null);
            }
            dataTable.Rows.Add(values);
        }
        return dataTable;
    }
    public static string ShowPopup(string modalName, string type)
    {
        try
        {
            StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$(function () {");
            sb.Append("$('#" + modalName + "').modal('" + type + "');});");
            sb.Append(@"</script>");
            return sb.ToString();
        }
        catch (Exception ex) { throw ex; }
    }
    public static string GetRandomPasswordUsingGUID(int length)
    {
        try
        {
            string guidResult = Guid.NewGuid().ToString();
            guidResult = guidResult.Replace("-", string.Empty);
            if (length <= 0 || length > guidResult.Length)
                throw new ArgumentException("Length must be between 1 and " + guidResult.Length);

            return guidResult.Substring(0, length);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public static string SendPushNotification(string regId, string msgTitle, string msgDesc)
    {
        string functionReturnValue = null;
        string ReturnVal = "Error";
        try
        {
            WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
            tRequest.Method = "post";
            tRequest.ContentType = "application/json";
            var data = new
            {
                to = regId,
                notification = new
                {
                    body = msgDesc,
                    title = msgTitle,
                    sound = "default"
                }
            };

            var serializer = new JavaScriptSerializer();
            var json = serializer.Serialize(data);
            Byte[] byteArray = Encoding.UTF8.GetBytes(json);
            tRequest.Headers.Add(string.Format("Authorization: key={0}", fcmAPIKey.ToString()));
            tRequest.Headers.Add(string.Format("Sender: id={0}", fcmProjectNumber.ToString()));
            tRequest.ContentLength = byteArray.Length;

            using (Stream dataStream = tRequest.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
                using (WebResponse tResponse = tRequest.GetResponse())
                {
                    using (Stream dataStreamResponse = tResponse.GetResponseStream())
                    {
                        using (StreamReader tReader = new StreamReader(dataStreamResponse))
                        {
                            string responseFromServer = tReader.ReadToEnd();
                            serializer = new JavaScriptSerializer();
                            dynamic objectDynamic = serializer.Deserialize(responseFromServer, typeof(object));
                            if (objectDynamic["success"] > 0)
                            {
                                ReturnVal = "Success";
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            ReturnVal = "Exception";
            throw ex;
        }
        finally
        {
            functionReturnValue = ReturnVal;
        }
        return functionReturnValue;
    }
    public static string GenerateOTP()
    {
        string numbers = "1234567890";
        string characters = numbers;
        characters += Convert.ToString(numbers);

        int length = 6;
        string otp = string.Empty;
        for (int i = 0; i <= length - 1; i++)
        {
            string character = string.Empty;
            do
            {
                int index = new Random().Next(0, characters.Length);
                character = characters.ToCharArray()[index].ToString();
            }
            while (otp.IndexOf(character) != -1);
            otp += character;
        }
        return otp;
    }
    public static string GetUniqueKey(int KeyLength)
    {
        string a = "ABCDEFGHJKLMNOPQRSTUVWXYZ234567890";
        char[] chars = new char[(a.Length) - 1 + 1];
        chars = a.ToCharArray();
        byte[] data = new byte[(KeyLength) - 1 + 1];
        RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
        crypto.GetNonZeroBytes(data);
        StringBuilder result = new StringBuilder(KeyLength);
        foreach (byte b in data)
            result.Append(chars[b % (chars.Length - 1)]);
        return result.ToString();
    }
    public static string GetRandomPasswordUsingGUID()
    {
        int length = 6;
        // Get the GUID
        string guidResult = System.Guid.NewGuid().ToString();

        // Remove the hyphens
        guidResult = guidResult.Replace("-", string.Empty);

        // Make sure length is valid
        if (length <= 0 || length > guidResult.Length)
            throw new ArgumentException("Length must be between 1 and " + guidResult.Length);

        // Return the first length bytes
        return guidResult.Substring(0, length);
    }
    public static void SendRegistrationMobileSMS(string MobileNo, string Password)
    {
        EmailSMSsender smsObj = new EmailSMSsender();
        string mobNos, smsMsg;
        mobNos = MobileNo;
        smsMsg = "Your ECF User Id is " + MobileNo + " and Password is " + Password;
        smsObj.SMSSender(mobNos, smsMsg);
    }
    public static DataTable GenericListToDataTable(object genericList)
    {
        DataTable dataTable = null;
        Type listType = genericList.GetType();

        if (listType.IsGenericType & (genericList != null))
        {
            Type elementType = listType.GetGenericArguments()[0];
            dataTable = new DataTable(elementType.Name + "List");
            MemberInfo[] memberInfos = elementType.GetMembers(BindingFlags.Public | BindingFlags.Instance);

            foreach (MemberInfo memberInfo in memberInfos)
            {
                if (memberInfo.MemberType == MemberTypes.Property)
                {
                    PropertyInfo propertyInfo = memberInfo as PropertyInfo;

                    if (IsNullableType(propertyInfo.PropertyType))
                        dataTable.Columns.Add(propertyInfo.Name, new NullableConverter(propertyInfo.PropertyType).UnderlyingType);
                    else
                        dataTable.Columns.Add(propertyInfo.Name, propertyInfo.PropertyType);
                }
                else if (memberInfo.MemberType == MemberTypes.Field)
                {
                    FieldInfo fieldInfo = memberInfo as FieldInfo;
                    dataTable.Columns.Add(fieldInfo.Name, fieldInfo.FieldType);
                }
            }

            IList listData = genericList as IList;

            foreach (object record in listData)
            {
                int index = 0;
                object[] fieldValues = new object[dataTable.Columns.Count - 1 + 1];

                foreach (DataColumn columnData in dataTable.Columns)
                {
                    MemberInfo memberInfo = elementType.GetMember(columnData.ColumnName)[0];

                    if (memberInfo.MemberType == MemberTypes.Property)
                    {
                        PropertyInfo propertyInfo = memberInfo as PropertyInfo;
                        fieldValues[index] = propertyInfo.GetValue(record, null);
                    }
                    else if (memberInfo.MemberType == MemberTypes.Field)
                    {
                        FieldInfo fieldInfo = memberInfo as FieldInfo;
                        fieldValues[index] = fieldInfo.GetValue(record);
                    }

                    index += 1;
                }

                dataTable.Rows.Add(fieldValues);
            }
        }
        return dataTable;
    }
    private static bool IsNullableType(Type propertyType)
    {
        return (propertyType.IsGenericType) && (object.ReferenceEquals(propertyType.GetGenericTypeDefinition(), typeof(Nullable<>)));
    }
    //public static byte[] GenerateQRCode(string transationDetail)
    //{
    //    BarcodeWriter _writer = new BarcodeWriter();
    //    _writer.Format = BarcodeFormat.QR_CODE;
    //    _writer.Options.Height = 400;
    //    _writer.Options.Width = 400;
    //    _writer.Options.Margin = 1;
    //    byte[] barcodeByte;
    //    var barcodeImage = _writer.Write(transationDetail);
    //    using (MemoryStream memStream = new MemoryStream())
    //    {
    //        barcodeImage.Save(memStream, ImageFormat.Jpeg);
    //        barcodeByte = memStream.ToArray();
    //    }
    //    return barcodeByte;
    //}

    public static string GenerateQRAsBase64String(string content)
    {
        var barcodeWriter = new BarcodeWriter
        {
            Format = BarcodeFormat.QR_CODE,
            Options = new EncodingOptions
            {
                Height = 250,
                Width = 250,
                Margin = 2
            }
        };

        using (var bitmap = barcodeWriter.Write(content))
        using (var stream = new MemoryStream())
        {
            bitmap.Save(stream, ImageFormat.Gif);
            return String.Format("data:image/gif;base64,{0}", Convert.ToBase64String(stream.ToArray()));
        }
    }

    public static void SendMail(UserProfileEntity entity)
    {
        //for (var i = 0; i <= 10; i++) {
        //    break;
        //}
        //DataSet ds;
        //UserProfileListClass mstr = new UserProfileListClass();
        //ds = mstr.GetUserDetails(entity);
        //if ((!(ds == null) && ds.Tables.Count > 0 && !(ds.Tables[0] == null) && ds.Tables[0].Rows.Count > 0))
        //{
        //    try
        //    {
        //        EmailSMSsender mailobj = new EmailSMSsender();
        //        MailEntity mailEntity = new MailEntity();
        //        mailEntity.ToAddress = ds.Tables[0].Rows[0]["usp_mailid"].ToString();
        //        mailEntity.BCCAddress = "";
        //        mailEntity.CCAddress = ds.Tables[0].Rows[0]["email_cc"].ToString();
        //        mailEntity.MailSubject = "E-Biding App Login Credential";
        //        string mailBody;
        //        //----------------------------------------
        //        if (ds.Tables[0].Rows[0]["usp_group_code"].ToString() == "MANPOWER" || ds.Tables[0].Rows[0]["usp_group_code"].ToString() == "SUPERVISOR")
        //        {
                    
        //            mailBody = "Dear " + ds.Tables[0].Rows[0]["usp_first_name"].ToString() + " " + ds.Tables[0].Rows[0]["usp_last_name"].ToString()
        //            + ",<br /><br />" + "This has reference to your Registration Request for the Mobile Application.<br /><br />"
        //            + "Your's OGA App credentials are as given below.<br /><br />" + "User ID: " + ds.Tables[0].Rows[0]["usp_user_id"].ToString()
        //            + "<br />" + "Password: " + ds.Tables[0].Rows[0]["usp_pswd"].ToString() + "<br /> To download click on this link : https://play.google.com/store/apps/details?id=com.berger.app.ecf. <br />" + "<strong>OGA Admin</strong><br /><br /><hr>"
        //            + "<strong>Disclaimer:-</strong> This is a system generated email. Please do not reply to this email.<br />"
        //            + "*** This message is intended only for the person or entity to which it is addressed and may contain confidential and/or privileged information. If you have received this message in error, please notify the sender immediately and delete this message from your system ***";/* TODO ERROR: Skipped SkippedTokensTrivia */
        //        }
        //        else
        //        {
        //            mailBody = "Dear " + ds.Tables[0].Rows[0]["usp_first_name"].ToString() + " " + ds.Tables[0].Rows[0]["usp_last_name"].ToString()
        //            + ",<br /><br />" + "This has reference to your Registration Request for the Mobile Application.<br /><br />"
        //            + "Your's OGA App credentials are as given below.<br /><br />" + "User ID: " + ds.Tables[0].Rows[0]["usp_user_id"].ToString()
        //            + "<br />" + "Password: " + ds.Tables[0].Rows[0]["usp_pswd"].ToString() + "<br /><br />" + "<strong>OGA Admin</strong><br /><br /><hr>"
        //            + "<strong>Disclaimer:-</strong> This is a system generated email. Please do not reply to this email.<br />"
        //            + "*** This message is intended only for the person or entity to which it is addressed and may contain confidential and/or privileged information. If you have received this message in error, please notify the sender immediately and delete this message from your system ***";/* TODO ERROR: Skipped SkippedTokensTrivia */
        //        }
        //        //----------------------------------------
        //        mailEntity.MailBody = mailBody;
        //        string recipNo = mailobj.sendMailHTML(mailEntity);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }

    internal static object DBNullValueorStringIfNotNull()
    {
        throw new NotImplementedException();
    }

    public static void SendSMS(UserProfileEntity entity)
    {
        DataSet ds;
        UserPhotoUploaded mstr = new UserPhotoUploaded();

        ds = mstr.GetUserDetails(entity);

        if ((!(ds == null) && ds.Tables.Count > 0 && !(ds.Tables[0] == null) && ds.Tables[0].Rows.Count > 0))
        {
            try
            {
                EmailSMSsender smsObj = new EmailSMSsender();
                string mobNos, smsMsg;
                mobNos = ds.Tables[0].Rows[0]["usp_mobile"].ToString();
                smsMsg = "MiWinGo Portal User Id : " + ds.Tables[0].Rows[0]["usp_user_id"].ToString() + " and Password : " + ds.Tables[0].Rows[0]["usp_pswd"].ToString() + ".";

                smsObj.SMSSender(mobNos, smsMsg);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public static object DBNullValueorStringIfNotNull(string value)
    {
        object o;
        if (value == string.Empty || value == null)
        {
            o = DBNull.Value;
        }
        else
        {
            o = value;
        }
        return o;
    }

    public static object DBNullValueorlongIfNotNull(long value)
    {
        object o;
        if (value == 0)
        {
            o = DBNull.Value;
        }
        else
        {
            o = value;
        }
        return o;
    }

    public static int UpdatePassword(string user_id, string old_password, string new_password)
    {
        int result = 0;

        SqlParameter[] sqlParams = new SqlParameter[3];

        sqlParams[0] = new SqlParameter();
        sqlParams[0].ParameterName = "@user_id";
        sqlParams[0].DbType = DbType.String;
        sqlParams[0].Direction = System.Data.ParameterDirection.Input;
        sqlParams[0].Value = user_id;

        sqlParams[1] = new SqlParameter();
        sqlParams[1].ParameterName = "@old_password";
        sqlParams[1].DbType = DbType.String;
        sqlParams[1].Direction = System.Data.ParameterDirection.Input;
        sqlParams[1].Value = old_password;

        sqlParams[2] = new SqlParameter();
        sqlParams[2].ParameterName = "@new_password";
        sqlParams[2].DbType = DbType.String;
        sqlParams[2].Direction = System.Data.ParameterDirection.Input;
        sqlParams[2].Value = new_password;

        result = DBFactory.GetHelper().ExecuteNonQuery("Update_ChangePassword", System.Data.CommandType.StoredProcedure, sqlParams);
        return result;
    }

    public static DataSet GetServerDateTime()
    {
        return DBFactory.GetHelper().ExecuteDataSet("Server_Datetime_Get", System.Data.CommandType.StoredProcedure);
    }

    //public DataSet GetLovDetails(string LovType, String LovStatus)
    //{
    //    DataSet LovDetails = new DataSet();
    //    SqlParameter[] sqlParams = new SqlParameter[2];

    //    sqlParams[0] = new SqlParameter();
    //    sqlParams[0].ParameterName = "@lov_type";
    //    sqlParams[0].DbType = DbType.String;
    //    sqlParams[0].Direction = System.Data.ParameterDirection.Input;
    //    sqlParams[0].Value = LovType;

    //    sqlParams[1] = new SqlParameter();
    //    sqlParams[1].ParameterName = "@lov_status";
    //    sqlParams[1].DbType = DbType.String;
    //    sqlParams[1].Direction = System.Data.ParameterDirection.Input;
    //    sqlParams[1].Value = LovStatus;

    //    LovDetails = DBFactory.GetHelper().ExecuteDataSet("Lov_Details_Get", System.Data.CommandType.StoredProcedure, sqlParams);
    //    return LovDetails;

    //}

    public static object DBNullValueorDatetTimeIfNotNull(SqlDateTime value)
    {
        object o;
        if (value == SqlDateTime.MinValue)
        {
            o = DBNull.Value;
        }
        else
        {
            o = value;
        }
        return o;
    }
    public static object DBNullValueorInt32IfNotNull(Int32 value)
    {
        object o;
        if (value == 0)
        {
            o = DBNull.Value;
        }
        else
        {
            o = value;
        }
        return o;
    }
    public static object DBNullValueorDecimalIfNotNull(decimal value)
    {
        object o;
        if (value == 0)
        {
            o = DBNull.Value;
        }
        else
        {
            o = value;
        }
        return o;
    }
    public static object DBNullValueorInt64IfNotNull(Int64 value)
    {
        object o;
        if (value == 0)
        {
            o = DBNull.Value;
        }
        else
        {
            o = value;
        }
        return o;
    }

    internal static object DBNullValueorInt64IfNotNull(object companyId)
    {
        throw new NotImplementedException();
    }
}