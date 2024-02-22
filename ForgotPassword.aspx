<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ForgotPassword.aspx.cs" Inherits="ForgotPassword" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" lang="en" class="bg-dark" style="background-image: url(images/backimg.jpg)">
<head id="Head1" runat="server">
    <title>:: Welcome to Mi Wingo Portal ::</title>
    <link rel="shortcut icon" href="favicon.ico" type="image/x-icon" />
    <link rel="icon" href="favicon.ico" type="image/x-icon" />
    <meta name="description" content="app, web app, responsive, admin dashboard, admin, flat, flat ui, ui kit, off screen nav" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <link rel="stylesheet" href="Theme/css/bootstrap.css" type="text/css" />
    <link rel="stylesheet" href="Theme/css/animate.css" type="text/css" />
    <link rel="stylesheet" href="Theme/css/font-awesome.min.css" type="text/css" />
    <link rel="stylesheet" href="Theme/css/font.css" type="text/css" />
    <link rel="stylesheet" href="Theme/css/app.css" type="text/css" />
    <script src="Scripts/FunctionValidator.js?time=<%= DateTime.Now.ToString("yyyy.MM.dd-HH.mm.ss.fff") %>" type="text/javascript"></script>
    <script src="Scripts/ValidateForgotPassword.js?time=<%= DateTime.Now.ToString("yyyy.MM.dd-HH.mm.ss.fff") %>" type="text/javascript"></script>
    <style type="text/css">
        .popupBackground {
            background-color: #999999;
            filter: alpha(opacity=70);
            opacity: 0.7;
        }

        .popup {
            border: 2px solid #009933;
            border-collapse: collapse;
            z-index: 9999;
            width: 400px;
            height: auto;
            background-color: #f2f2f2;
            padding: 0px;
        }

        .popupImage {
            /*background-color:#999999;
    filter:alpha(opacity=70);
    opacity:1;
     z-index:9999;*/
            background: rgb(0, 0, 0) transparent; /* Fallback for web browsers that doesn't support RGBa */
            background: rgba(0, 0, 0, 0); /* RGBa with 0.6 opacity */
            filter: progid:DXImageTransform.Microsoft.gradient(startColorstr=#00000000, endColorstr=#00000000); /* For IE 5.5 - 7*/
            -ms-filter: "progid:DXImageTransform.Microsoft.gradient(startColorstr=#00000000, endColorstr=#00000000)"; /* For IE 8*/
        }

        .popupForm {
            border: 2px solid #7f0037;
            z-index: 9999;
            width: 500px;
            background-color: #f2f2f2;
            padding: 0px;
        }

        .popupLabel {
            background-color: teal;
            filter: -webkit-gradient(linear, right top, right bottom, color-stop(0%,#80C0C0), color-stop(50%,teal),color-stop(100%,#80C0C0));
            /*background-image: -webkit-gradient(linear, right top, right bottom, color-stop(0%,#80C0C0), color-stop(50%,teal),color-stop(100%,#80C0C0));*/
            /*height: 15px;*/
            text-align: left;
            padding: 5px;
            color: White;
            width: 504px;
        }
    </style>
</head>
<body>
    <section id="content" class="m-t-lg wrapper-md">    
    <div class="container aside-xxl" style="padding-top:5%;">
     <%-- <a class="navbar-brand block" href="#">British Paints Ltd.</a>--%>
      <section class="panel panel-default bg-white m-t-lg">
        <header class="panel-heading text-center" style="background-color:#f5f5f5;">
          <img src="Theme/images/mi_wingo_l.jpg" style="width:200px;height:117px;">
        </header>
        <form id="Form1" runat="server" class="panel-body wrapper-lg">
           <ajaxToolkit:ToolkitScriptManager ID="toolkitScriptManager1" runat="server"></ajaxToolkit:ToolkitScriptManager> 
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:HiddenField ID="hdnMobileNo" runat="server" />
                    <asp:HiddenField ID="hdnUserID" runat="server" />
          <div class="form-group">
            <label class="control-label">Enter Your Registered Mobile No</label>
            <asp:TextBox runat="server" id="txtMobileNo" placeholder="Enter Mobile No" maxlength="10" TextMode="Phone" class="form-control input-lg" ></asp:TextBox>
          </div>
          <asp:Button ID="btnSendOTP" runat="server" OnClick="btnSendOTP_Click" CssClass="btn btn-facebook btn-block m-b-sm" Text="Send OTP" />
          <div class="line line-dashed"></div>
          <p class="text-muted text-center"><small>Do you want to login?</small></p>
           <a href="Login.aspx" class="btn btn-default btn-block">Sign in</a>
            <div class="alert alert-danger" id="divAlert" runat="server" style="display:none">
                <i class="fa fa-ban-circle"></i><strong><asp:Label ID="lblMessage" runat="server" Text=""></asp:Label></strong> 
            </div>
           </ContentTemplate>
                </asp:UpdatePanel>

            <asp:UpdatePanel ID="UpdatePanel105" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="hdnMyModal" runat="server" />
            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderMessage" runat="server" OkControlID="btnModalok"
                PopupControlID="pnlMessageBox" TargetControlID="hdnMyModal" CancelControlID="btnModalok"
                BackgroundCssClass="popupBackground">
            </ajaxToolkit:ModalPopupExtender>
            <asp:Panel ID="pnlMessageBox" runat="server" CssClass="popup" Width="508px" HorizontalAlign="Center" Style="z-index: 1001">
                <div class="popupLabel">
                    <asp:Label ID="Label2" runat="server" ForeColor="White" Text="Forgot Password"></asp:Label>
                </div>
                <div class="panel-body" style="padding: 15px; height: 150px; overflow-y: auto;">
                    <div class="text-left">
                        <asp:Label ID="lblPopMessage" runat="server"></asp:Label>
                    </div>
                    <br />
                    <br />
                    <br />
                    <div class="text-center">
                        <asp:UpdatePanel ID="UpdatePanel33" runat="server">
                            <ContentTemplate>
                                 <asp:Button ID="btnValidateOTP" runat="server" OnClick="btnValidateOTP_Click" CssClass="btn btn-success" Text="Validate OTP" />
                                <asp:Button ID="btnModalok" runat="server" CssClass="btn btn-warning" Text="Close" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
      </section>
    </div>
  </section>
    <!-- footer -->
    <footer id="footer">
    <div class="text-center padder">
      <p>
        <small style="color: azure;">&copy Copyright By 2021 Login Port.<br />
            <a href="#" style="color: indigo;"></a>
        </small>
      </p>
    </div>
  </footer>
    <!-- / footer -->
    <script src="Theme/js/jquery.min.js" type="text/javascript"></script>
    <!-- Bootstrap -->
    <script src="Theme/js/bootstrap.js" type="text/javascript"></script>
    <!-- App -->
    <script src="Theme/js/app.js" type="text/javascript"></script>
    <script src="Theme/js/app.plugin.js" type="text/javascript"></script>
    <script src="Theme/js/slimscroll/jquery.slimscroll.min.js" type="text/javascript"></script>

    <!-- parsley -->
    <script src="Theme/js/parsley/parsley.min.js" type="text/javascript"></script>
    <script src="Theme/js/parsley/parsley.extend.js" type="text/javascript"></script>
</body>
</html>
