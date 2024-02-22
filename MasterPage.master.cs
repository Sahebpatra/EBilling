using EBilling;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class MasterPage : System.Web.UI.MasterPage
{
    UserProfile userInfo = new UserProfile();

    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        ClearControl();
        CheckLogin();        

        if (!IsPostBack)
        {
            if (!userInfo.usp_force_login_yn.ToString().Equals(Constant.Common.ActiveStatus))
            {
                PopulateUserBasicDetail();
                PopulateMenus();
            }
        }        
    }
    #endregion

    #region Event Handler

    #endregion

    #region Custom Method
    public void PopulateUserBasicDetail()
    {
        string shortName = string.Empty;
        try
        {
            lblUserName.Text = string.Concat(userInfo.UserFirstName, " ", userInfo.UserLastName);
            lblUserId.Text = string.Concat(userInfo.UserFirstName, " ", userInfo.UserLastName);

            //test
            lblCompanyId.Text = string.Concat(userInfo.Company_Id);

            shortName = userInfo.UserFirstName.ToString().Substring(0, 1);
            if (!string.IsNullOrEmpty(userInfo.UserLastName))
            {
                shortName = string.Concat(shortName, userInfo.UserLastName.ToString().Substring(0, 1));
            }
            //lblUserNameInShort.Text = shortName;
            //lblUserNameDropdown.Text = string.Concat(userInfo.UserFirstName, " ", userInfo.UserLastName);
            lblUserGroup.Text = userInfo.Desig;

            lblLeftUserName.Text= string.Concat(userInfo.UserFirstName, " ", userInfo.UserLastName);
            lblDesgination.Text= userInfo.Desig;
            headerlabel.Text = userInfo.company_detail.cd_company_name;
            imgLeftuserPic.Src = userInfo.usp_profile_pic;
            lblFooterCompanyName.Text = string.Format("Copyright By {0}", userInfo.company_detail.cd_company_name);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void ClearControl()
    {
        //lblUserName.Text = string.Empty;
        ////lblUserNameInShort.Text = string.Empty;
        //lblUserNameDropdown.Text = string.Empty;
        //lblUserDesignation.Text = string.Empty;
    }
    private void PopulateMenus()
    {
        menuClass loginDS = new menuClass();
        DataSet adminDataSet = new DataSet();
        StringBuilder sbMenu = new StringBuilder();
        imgProfileImage.ImageUrl = userInfo.usp_profile_pic;
        try
        {
            adminDataSet = loginDS.GetMenu(userInfo.GroupCode, userInfo.UserId);
            if ((adminDataSet != null && adminDataSet.Tables.Count > 0) && (adminDataSet.Tables[0] != null && adminDataSet.Tables[0].Rows.Count > 0))
            {
                StringBuilder strMenu = new StringBuilder();
                DataTable dt = new DataTable();
                dt = adminDataSet.Tables[0];
                strMenu.Append("<ul class='nav'>");
                var mainMenu = from menuCode in dt.AsEnumerable()
                               where menuCode.Field<int>("fmm_parent_id").Equals(0)
                               select new
                               {
                                   id = menuCode.Field<int>("fmm_id"),
                                   name = menuCode.Field<string>("fmm_name"),
                                   link = menuCode.Field<string>("fmm_link"),
                                   parent_id = menuCode.Field<int>("fmm_parent_id"),
                                   fmm_icon = menuCode.Field<string>("fmm_icon"),
                                   fmm_color = menuCode.Field<string>("fmm_color_icon")
                               };
                //int count = 0;

                foreach (var item in mainMenu)
                {
                    var menuStr = generateInnerTag(dt, item.id, item.name, item.link, item.parent_id, 1, item.fmm_icon, item.fmm_color);
                    strMenu.Append(menuStr);
                }

                strMenu.Append("</ul>");
                plcMenu.Text = strMenu.ToString();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private string generateInnerTag(DataTable dt, int frmId, string frmNme, string frmLink, int frmParentId, int depth, string frmicon, string fmmcolor)
    {
        var str = new StringBuilder();
        try
        {
            if (depth == 1)
            {
                depth += 1;
                str.Append("<li><a href='" + frmLink + "' target='_parent')><i class='" + frmicon + "'><b class='" + fmmcolor + "'></b></i><span class='pull-right'><i class='fa fa-angle-down text'></i><i class='fa fa-angle-up text-active'></i></span><span>" + frmNme + "</span></a>");
                int childCount = (from chld in dt.AsEnumerable()
                                  where chld.Field<int>("fmm_parent_id").Equals(frmId)
                                  select chld).Count();
                if (childCount > 0) {
                    str.Append("<ul class='nav lt'>");
                    var mainMenu = from menuCode in dt.AsEnumerable()
                                   where menuCode.Field<int>("fmm_parent_id").Equals(frmId)
                                   select new
                                   {
                                       id = menuCode.Field<int>("fmm_id"),
                                       name = menuCode.Field<string>("fmm_name"),
                                       link = menuCode.Field<string>("fmm_link"),
                                       parent_id = menuCode.Field<int>("fmm_parent_id"),
                                       fmm_icon = menuCode.Field<string>("fmm_icon"),
                                       fmm_color = menuCode.Field<string>("fmm_color_icon")
                                   };

                    foreach (var item in mainMenu)
                    {
                        var menuStr = generateInnerTag(dt, item.id, item.name, item.link, item.parent_id, depth, item.fmm_icon, item.fmm_color);
                        str.Append(menuStr);
                    }
                    str.Append("</ul>");
                }
                str.Append("</li>");
            }
            else {
                str.Append("<li> <a href='" + frmLink + "'><i class='fa fa-angle-right'></i><span>" + frmNme + "</span></a>");
                int childCount = (from chld in dt.AsEnumerable()
                                  where chld.Field<int>("fmm_parent_id").Equals(frmId)
                                  select chld).Count();
                if ((childCount > 0))
                {
                    str.Append("<ul class='nav lt'>");
                    var mainMenu = from menuCode in dt.AsEnumerable()
                                   where menuCode.Field<int>("fmm_parent_id").Equals(frmId)
                                   select new
                                   {
                                       id = menuCode.Field<int>("fmm_id"),
                                       name = menuCode.Field<string>("fmm_name"),
                                       link = menuCode.Field<string>("fmm_link"),
                                       parent_id = menuCode.Field<int>("fmm_parent_id"),
                                       fmm_icon = menuCode.Field<string>("fmm_icon"),
                                       fmm_color = menuCode.Field<string>("fmm_color_icon")
                                   };

                    foreach (var item in mainMenu)
                    {
                        var menuStr = generateInnerTag(dt, item.id, item.name, item.link, item.parent_id, depth, item.fmm_icon, item.fmm_color);
                        str.Append(menuStr);
                    }
                    str.Append("</ul>");
                }
                str.Append("</li>");
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return str.ToString();
    }
    private string generateInnerTaggg(DataTable dt, int frmId, string frmNme, string frmLink, int frmParentId)
    {
        StringBuilder str = new StringBuilder("");
        int childCount = (from chld in dt.AsEnumerable()
                          where chld.Field<int>("fmm_parent_id").Equals(frmId)
                          select chld).Count();

        if (childCount > 0)
        {
            str.Append("<ul class='dropdown-menu'>");
            var mainMenu = from menuCode in dt.AsEnumerable()
                           where menuCode.Field<int>("fmm_parent_id").Equals(frmId)
                           select new
                           {
                               id = menuCode.Field<int>("fmm_id"),
                               name = menuCode.Field<string>("fmm_name"),
                               link = menuCode.Field<string>("fmm_link"),
                               parent_id = menuCode.Field<int>("fmm_parent_id"),
                               icon = menuCode.Field<string>("fac_class_name")
                           };

            foreach (var item in mainMenu)
            {
                str.Append("<li>");
                str.Append("<a class='dropdown-item' href ='" + item.link + "?rand=" + DateTime.Now.ToString("dd/MM/yyyy-HH:mm:ss") + "'><i style='float:left;margin-top:2px' class='mdi " + item.icon + "'></i><span style='white-space: pre-wrap;width: 88%;display: inline-block; '>" + item.name + "<Spna></a>");
                str.Append("</li>");
            }

            str.Append("</ul>");
        }

        return str.ToString();
    }
    private void CheckLogin()
    {
        if (Session[Constant.SessionKeys.UserInfo] != null)
        {
            userInfo = (UserProfile)Session[Constant.SessionKeys.UserInfo];            
        }
        else
        {
            Response.Redirect("~/Login.aspx", true);
        }
    }
    #endregion

}
