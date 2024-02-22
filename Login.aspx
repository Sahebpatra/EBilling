<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" lang="en" class="bg-dark" style="background-image: url(images/backimg.jpg)">
<head id="Head1" runat="server">
    <title>Login Portal</title>
    <link rel="shortcut icon" href="favicon.ico" type="image/x-icon" />
    <link rel="icon" href="favicon.ico" type="image/x-icon" />
    <meta name="description" content="Login Your Secure Portal" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <link rel="stylesheet" href="Theme/css/bootstrap.css" type="text/css" />
    <link rel="stylesheet" href="Theme/css/animate.css" type="text/css" />
    <link rel="stylesheet" href="Theme/css/font-awesome.min.css" type="text/css" />
    <link rel="stylesheet" href="Theme/css/font.css" type="text/css" />
    <link rel="stylesheet" href="Theme/css/app.css" type="text/css" />
    <script src="Scripts/FunctionValidator.js?time=<%= DateTime.Now.ToString(" yyyy.MM.dd-HH.mm.ss.fff ") %>" type="text/javascript"></script>
    <script src="Scripts/ValidateUserLogin.js?time=<%= DateTime.Now.ToString(" yyyy.MM.dd-HH.mm.ss.fff ") %>" type="text/javascript"></script>
</head>
<body>
    <section id="content" class="m-t-lg wrapper-md">
        <div class="container aside-xxl" style="padding-top: 5%;">
            <section class="panel panel-default bg-white m-t-lg">
                <header class="panel-heading text-center" style="background-color: #f5f5f5;">
                    <img src="Theme/images/E-billing.png" style="width: 200px; height: 100px;">
                </header>
                <form id="Form1" runat="server" class="panel-body wrapper-lg">
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <div class="form-group">
                                <label class="control-label">User Id</label>
                                <asp:TextBox runat="server" ID="txtbxUserId" placeholder="Enter user Id" MaxLength="20" class="form-control input-lg"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label class="control-label">Password</label>
                                <asp:TextBox ID="txtbxUserPassword" runat="server" TextMode="Password" data-required="true" placeholder="Password" MaxLength="20" class="form-control input-lg"></asp:TextBox>
                            </div>
                            <a href="ForgotPassword.aspx" target="_parent" class="m-t-xs m-b"><small>Forgot password?</small></a>
                            <a href="OrgRegister.aspx" target="_parent" class="pull-right"><small>Register Now</small></a>
                            <div class="line line-dashed"></div>
                            <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" CssClass="btn btn-facebook btn-block m-b-sm" Text="Login" />
                            <div class="line line-dashed"></div>
                            <div class="alert alert-danger" id="divAlert" runat="server" style="display: none">
                                <i class="fa fa-ban-circle"></i><strong>
                                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label></strong>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </form>
            </section>
        </div>
    </section>
    <script src="Theme/js/jquery.min.js" type="text/javascript"></script>
    <script src="Theme/js/bootstrap.js" type="text/javascript"></script>
    <script src="Theme/js/app.js" type="text/javascript"></script>
    <script src="Theme/js/app.plugin.js" type="text/javascript"></script>
    <script src="Theme/js/slimscroll/jquery.slimscroll.min.js" type="text/javascript"></script>
    <script src="Theme/js/parsley/parsley.min.js" type="text/javascript"></script>
    <script src="Theme/js/parsley/parsley.extend.js" type="text/javascript"></script>
</body>
</html>
