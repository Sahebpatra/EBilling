<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrgRegister.aspx.cs" Inherits="Login" %>
	<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
		<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
		<html xmlns="http://www.w3.org/1999/xhtml" lang="en" class="bg-dark" style="background-image: url(images/backimg.jpg)">

		<head id="Head1" runat="server">
			<title>E-Billing ERP</title>
			<link rel="shortcut icon" href="favicon.ico" type="image/x-icon" />
			<link rel="icon" href="favicon.ico" type="image/x-icon" />
			<meta name="description" content="e-billing,billing softwate" />
			<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
			<link rel="stylesheet" href="Theme/css/bootstrap.css" type="text/css" />
			<link rel="stylesheet" href="Theme/css/animate.css" type="text/css" />
			<link rel="stylesheet" href="Theme/css/font-awesome.min.css" type="text/css" />
			<link rel="stylesheet" href="Theme/css/font.css" type="text/css" />
			<link rel="stylesheet" href="Theme/css/app.css" type="text/css" />
			<%--<script src="Scripts/FunctionValidator.js?time=<%= DateTime.Now.ToString(" yyyy.MM.dd-HH.mm.ss.fff ") %>" type="text/javascript"></script>--%>
<%--			<script src="Scripts/ValidateUserLogin.js?time=<%= DateTime.Now.ToString(" yyyy.MM.dd-HH.mm.ss.fff ") %>" type="text/javascript"></script>--%>
		</head>
		<body>
			<section id="content" class="m-t-lg wrapper-md">
				<div class="container aside-xxl" style="padding-top:5%;">
						<section class="panel panel-default bg-white m-t-lg">
							<form id="Form1" runat="server" class="panel-body wrapper-lg">
								<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
								<asp:UpdatePanel ID="UpdatePanel2" runat="server">
									<ContentTemplate>
										<div class="form-group">
											<label class="control-label">Org Name</label>
											<asp:TextBox runat="server" id="txtbxUserId" placeholder="Enter Org Name" maxlength="20" class="form-control input-lg"></asp:TextBox>
										</div>
										<div class="form-group">
											<label class="control-label">Owner Name</label>
											<asp:TextBox runat="server" id="TextBox1" placeholder="Enter Owner Name" maxlength="20" class="form-control input-lg"></asp:TextBox>
										</div>
										<div class="form-group">
											<label class="control-label">Mobile Name</label>
											<asp:TextBox runat="server" id="TextBox2" placeholder="Enter Mobile Name" maxlength="20" class="form-control input-lg"></asp:TextBox>
										</div>
										<div class="form-group">
											<label class="control-label">Email ID</label>
											<asp:TextBox runat="server" id="TextBox3" placeholder="Enter Email ID" maxlength="20" class="form-control input-lg"></asp:TextBox>
										</div>
										<div class="form-group">
											<label class="control-label">Address</label>
											<textarea id="TextArea1" cols="20" rows="2" placeholder="Enter Address" maxlength="20" class="form-control input-lg"></textarea>
										</div>
										<%--<div class="form-group">
											<label class="control-label">Password</label>
											<asp:TextBox id="txtbxUserPassword" runat="server" TextMode="Password" data-required="true" placeholder="Password" maxlength="20" class="form-control input-lg"></asp:TextBox>
										</div> --%>
										<%--<div class="line line-dashed"></div>
                                            <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" CssClass="btn btn-facebook btn-block m-b-sm" Text="Login" />
											<div class="line line-dashed"></div>
											<div class="alert alert-danger" id="divAlert" runat="server" style="display:none"> <i class="fa fa-ban-circle"></i><strong><asp:Label ID="lblMessage" runat="server" Text=""></asp:Label></strong> 
									    </div>--%>
									</ContentTemplate>
								</asp:UpdatePanel>
							</form>
						</section>
				</div>
			</section>
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