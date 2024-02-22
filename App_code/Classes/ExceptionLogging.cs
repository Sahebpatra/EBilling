using System;
using System.IO;
using System.Net;
using System.Configuration;
using context = System.Web.HttpContext;
using System.Globalization;
using EBilling;

/// <summary>  
/// Summary description for ExceptionLogging  
/// </summary>  
public static class ExceptionLogging
{

    private static String ErrorlineNo, Errormsg, extype, exurl, hostIp, ErrorLocation;

    public static byte[] Combine(byte[] first, byte[] second)
    {
        byte[] ret = new byte[first.Length + second.Length];
        Buffer.BlockCopy(first, 0, ret, 0, first.Length);
        Buffer.BlockCopy(second, 0, ret, first.Length, second.Length);
        return ret;
    }

    public static byte[] ReadStream(Stream responseStream)
    {
        byte[] buffer = new byte[16 * 1024];
        using (MemoryStream ms = new MemoryStream())
        {
            int read;
            while ((read = responseStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                ms.Write(buffer, 0, read);
            }
            return ms.ToArray();
        }
    }
    //public static void SendErrorToText(Exception ex, RFQUserEntity userinfo)
    //{
    //    var line = Environment.NewLine + Environment.NewLine;

    //    ErrorlineNo = ex.StackTrace.Substring(ex.StackTrace.Length - 8, 7);
    //    Errormsg = ex.GetType().Name.ToString();
    //    extype = ex.GetType().ToString();
    //    exurl = context.Current.Request.Url.ToString();
    //    ErrorLocation = ex.Message.ToString();
    //    hostIp = Dns.GetHostEntry(Dns.GetHostName()).AddressList.GetValue(1).ToString();

    //    string abspath = ConfigurationManager.AppSettings["UPLOAD_DOCS_EXCEPTION_LOG_PATH"] as string;

    //    string filepath = abspath;  //Text File Path       

    //    try
    //    {

    //        if (!Directory.Exists(filepath))
    //        {
    //            Directory.CreateDirectory(filepath);
    //        }
    //        filepath = filepath + DateTime.Today.ToString("dd-MM-yy") + ".txt";   //Text File Name
    //        if (!File.Exists(filepath))
    //        {
    //            File.Create(filepath).Dispose();
    //        }

    //        using (StreamWriter sw = File.AppendText(filepath))
    //        {
    //            string error = "Log Written Date:" + " " + DateTime.Now.ToString() + line + "Error Line No :" + " " + ErrorlineNo + line + "Error Message:" + " " + Errormsg + line + "Exception Type:" + " " + extype + line + "Error Location :" + " " + ErrorLocation + line + " Error Page Url:" + " " + exurl + line + "User Host IP:" + " " + hostIp + line + "User Id:" + " " + userinfo.userFirstNameEntity + " " + userinfo.userLastNameEntity + "(" + userinfo.userIDEntity + ")" + line;
    //            sw.WriteLine("-----------Activity Details on " + " " + DateTime.Now.ToString() + "-----------------");
    //            sw.WriteLine("-------------------------------------------------------------------------------------");
    //            sw.WriteLine(line);
    //            sw.WriteLine(error);
    //            sw.WriteLine("--------------------------------*End*------------------------------------------");
    //            sw.WriteLine(line);
    //            sw.Flush();
    //            sw.Close();
    //        }

    //    }
    //    catch (Exception)
    //    {

    //    }
    //}

    public static void SendErrorToText(Exception ex)
    {
        var line = Environment.NewLine + Environment.NewLine;

        ErrorlineNo = ex.StackTrace.Substring(ex.StackTrace.Length - 8, 7);
        Errormsg = ex.GetType().Name.ToString();
        extype = ex.GetType().ToString();
        exurl = context.Current.Request.Url.ToString();
        ErrorLocation = ex.Message.ToString();
        hostIp = Dns.GetHostEntry(Dns.GetHostName()).AddressList.GetValue(1).ToString();

        string abspath = ConfigurationManager.AppSettings["UPLOAD_DOCS_EXCEPTION_LOG_PATH"] as string;

        string filepath = abspath;  //Text File Path      

        try
        {
            if (!Directory.Exists(filepath))
            {
                Directory.CreateDirectory(filepath);
            }
            filepath = filepath + DateTime.Today.ToString("dd-MM-yy") + ".txt";   //Text File Name
            if (!File.Exists(filepath))
            {
                File.Create(filepath).Dispose();
            }

            using (StreamWriter sw = File.AppendText(filepath))
            {
                string error = "Log Written Date:" + " " + DateTime.Now.ToString() + line + "Error Line No :" + " " + ErrorlineNo + line + "Error Message:" + " " + Errormsg + line + "Exception Type:" + " " + extype + line + "Error Location :" + " " + ErrorLocation + line + " Error Page Url:" + " " + exurl + line + "User Host IP:" + " " + hostIp + line;
                sw.WriteLine("-----------Activity Details on " + " " + DateTime.Now.ToString() + "-----------------");
                sw.WriteLine("-------------------------------------------------------------------------------------");
                sw.WriteLine(line);
                sw.WriteLine(error);
                sw.WriteLine("--------------------------------*End*------------------------------------------");
                sw.WriteLine(line);
                sw.Flush();
                sw.Close(); 
            }
        }
        catch (Exception)
        {

        }
    }

}