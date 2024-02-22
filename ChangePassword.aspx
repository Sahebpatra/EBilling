<%@ Page Title="Change Password" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="ChangePassword" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="Scripts/FunctionValidator.js"></script>
    <script src="Scripts/RegEX.js"></script>
    <script src="Scripts/date.js"></script>
    <%string timestamp = DateTime.Now.ToString("yyyy.MM.dd-HH.mm.ss.fff");%>
    <script src="Scripts/ValidateChangePassword.js?time=<%=timestamp%>"></script>
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ul class="breadcrumb no-border no-radius b-b b-light pull-in">
        <li><a href="DashBoard.aspx" style="color: blue; font-weight: bold;"><i class="fa fa-home"></i>Home</a></li>
        <li><i class="fa fa-lock"></i>Change Password</li>
    </ul>
    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
        <ContentTemplate>
            <section id="content">
                <div class="row">
                    <div class="col-md-4 col-lg-offset-4">
                        <section class="panel panel-default">
                            <header class="panel-heading">
                                CHANGE PASSWORD
                            </header>
                            <div class="panel-body">
                                <p class="text-muted">Please fill the information to continue</p>
                                <div class="form-group">
                                    <label>Old Password</label>
                                    <asp:TextBox ID="txtOldPassword" runat="server" TextMode="Password" CssClass="form-control" data-required="true" placeholder="Enter Old Password"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>New Password</label>
                                    <asp:TextBox class="form-control" data-required="true" TextMode="Password" ID="txtNewPassword" runat="server" placeholder="Enter New Password"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>Confirm Password</label>
                                    <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" class="form-control" data-equalto="#txtNewPassword" placeholder="Enter Confirm Password" data-required="true"></asp:TextBox>
                                </div>
                                <footer class="panel-footer text-right bg-light lter">
                                    <div id="notes"></div>
                                    <asp:LinkButton ID="lnkbtnChangePassword" OnClick="lnkbtnChangePassword_Click" runat="server" type="submit" class="btn btn-success btn-s-xs">Change Password</asp:LinkButton>
                                </footer>
                                <div class="alert alert-danger" id="divAlert" runat="server" style="display: none">
                                    <asp:Label ID="lblValidationMessage" runat="server" ForeColor="Red" Text=""></asp:Label>
                                </div>
                            </div>
                        </section>
                    </div>
                </div>
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
                    <asp:Label ID="Label2" runat="server" ForeColor="White" Text="Change Password"></asp:Label>
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
                                <asp:Button ID="btnModalok" runat="server" CssClass="btn btn-warning" Text="Close" OnClick="btnModalok_Click" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

