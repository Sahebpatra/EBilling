using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Logout : System.Web.UI.Page
{
    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        SignOut();
    }
    #endregion

    #region Custom Method
    private void SignOut()
    {
        try
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            FormsAuthentication.Initialize();
            HttpContext context = HttpContext.Current;
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, string.Empty);
            cookie.Path = FormsAuthentication.FormsCookiePath;
            cookie.Expires = DateTime.Now;
            context.Response.Cookies.Remove(FormsAuthentication.FormsCookieName);
            context.Response.Cookies.Add(cookie);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        string nextpage = "../BD_PROLEAD";
        Response.Write("<Script language=javaScript >");
        Response.Write("{");
        Response.Write("var backhistory=history.length;");
        Response.Write("history.go(-(backhistory+backhistory+backhistory));");
        Response.Write(" window.location.href='" + nextpage + "'; ");
        Response.Write("}");
        Response.Write("</script>");
        Response.Redirect("~/Login.aspx");
    }
    #endregion
}