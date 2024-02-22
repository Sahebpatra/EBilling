<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MemberEntry.aspx.cs" Inherits="MemberEntry" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
            <title>TATA Steel</title>
    <script type="text/javascript" src="Scripts/FunctionValidator.js"></script>
    <script src="Scripts/RegEX.js"></script>
    <script src="Scripts/date.js"></script>
    <script type="text/javascript" src="Scripts/ValidateNewRegister.js?time=<%= DateTime.Now.ToString("yyyy.MM.dd-HH.mm.ss.fff") %>"></script>
    <script type="text/javascript">
        function RedirectToListScreen() {
            window.location.href = "NewRegister.aspx";
            return false;
        }
        function ShowPopup() {
            $("#myModal").addClass("modal fade in show");
            $('#myModal').modal('show');
        }
    </script>
    <style type="text/css">
        #ctl00_ContentPlaceHolder1_lblSchemeId {
            float: right;
            font-weight: 500;
        }

        #ctl00_ContentPlaceHolder1_rdoGender tr > td > label {
            padding-left: 10px;
            padding-right: 5px;
        }

        #ctl00_ContentPlaceHolder1_rdoMaritalStatus tr > td > label {
            padding-left: 10px;
            padding-right: 5px;
        }

        #ctl00_ContentPlaceHolder1_rdoAccountType tr > td > label {
            padding-left: 10px;
            padding-right: 5px;
        }

        #ctl00_ContentPlaceHolder1_lblValidationMessage > table > tbody > tr > td {
            font-size: 11px !important;
        }
    </style>
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
    <style>
        .TextBoxBorder {
            border: 1px solid #ccc;
        }

        #ctl00_ContentPlaceHolder1_rdoGender_0, #ctl00_ContentPlaceHolder1_rdoGender_1, #ctl00_ContentPlaceHolder1_rdoMaritalStatus_0, #ctl00_ContentPlaceHolder1_rdoMaritalStatus_1, #ctl00_ContentPlaceHolder1_RadioButtonList1_0, #ctl00_ContentPlaceHolder1_RadioButtonList1_1 {
            height: 23px !important;
        }

        #ctl00_ContentPlaceHolder1_RadioButtonList1 {
            border: 0 !important;
        }

        #ctl00_ContentPlaceHolder1_chkTermsCondition {
            height: 15px !important;
            width: 8% !important;
            text-align: right !important;
        }

        /*#ctl00_ContentPlaceHolder1_btnSubmit {
            margin-top: -9px !important;
            margin-left: -9%;
        }*/
        /*.checkbx {
            width:45% !important;
            float:right !important;
        }*/
        .checkbx > span {
            display:inline !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumb-area bg-contactus text-center">
        <div class="container">
            <h1>New Registration</h1>
            <nav aria-label="breadcrumb">
                <ul class="breadcrumb">
                    <li class="breadcrumb-item"><a href="#">Registration</a>
                    </li>
                    <li class="breadcrumb-item active" aria-current="page">Register with us</li>
                </ul>
            </nav>
        </div>
    </div>
    <div class="contact-area fix">
        <div class="contact-form pt-80" style="float: none; width: auto;">
            <h1 class="contact-title">Register Form</h1>

            <form runat="server" class="contact-form1" style="border: 1px solid; padding: 15px;">
               
                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                    <ContentTemplate>
                        <asp:HiddenField ID="hdnReportingMailId" runat="server" />
                        <asp:HiddenField ID="hdnUserID" runat="server" />
                        <asp:HiddenField ID="hdnBankId" runat="server" />
                        <asp:HiddenField ID="hdnSponsorDesignation" runat="server" />
                    </ContentTemplate>
                </asp:UpdatePanel>

                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                <ContentTemplate>
                                    <label class="font-bold">Sponsor Name <span style="color: red">*</span> :</label>
                                    <asp:Label ID="lblSponsorName" runat="server" CssClass="badge badge-hollow"></asp:Label>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                <ContentTemplate>
                                    <label class="font-bold">Upline Name :</label>
                                    <asp:Label ID="lblUplineName" runat="server" CssClass="badge badge-hollow"></asp:Label>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label class="font-bold">Title <span style="color: red">*</span> :</label>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlSalutaion" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label class="font-bold">Applicant Name <span style="color: red">*</span> :</label>
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                    <asp:TextBox ID="txtApplicantName" MaxLength="100" runat="server" CssClass="form-control text-uc" data-required="true" placeholder="Applicant Name"></asp:TextBox>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label class="font-bold">Date Of Birth (DD/MM/YYYY) <span style="color: red">*</span> :</label>
                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                <ContentTemplate>
                                    <asp:TextBox ID="txtDOB" runat="server" CssClass="form-control" TextMode="date" data-required="true" placeholder="Date Of Birth (DD/MM/YYYY)"></asp:TextBox>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label class="font-bold">Blood Group :</label>
                            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlBloodGroup" runat="server" CssClass="form-control m-t select2">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label class="font-bold">Gender <span style="color: red">*</span> :</label>
                            <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                                <ContentTemplate>
                                    <asp:RadioButtonList ID="rdoGender" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Text="Male" Value="M"></asp:ListItem>
                                        <asp:ListItem Text="Female" Value="F"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label class="font-bold">Marital Status :</label>
                            <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                                <ContentTemplate>
                                    <asp:RadioButtonList ID="rdoMaritalStatus" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Text="Married" Value="M"></asp:ListItem>
                                        <asp:ListItem Text="Unmarried" Value="U"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label class="font-bold">Profession/Occupation :</label>
                            <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlProfession" runat="server" CssClass="form-control m-t select2">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group">
                            <label class="font-bold">Address <span style="color: red">*</span> :</label>
                            <asp:UpdatePanel ID="UpdatePanel24" runat="server">
                                <ContentTemplate>
                                    <asp:TextBox ID="txtAddress" MaxLength="500" Rows="3" TextMode="MultiLine" runat="server" CssClass="form-control" data-required="true" placeholder="Address"></asp:TextBox>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label class="font-bold">Country <span style="color: red">*</span> :</label>
                            <asp:UpdatePanel ID="UpdatePanel30" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlCountry" runat="server" CssClass="form-control m-t select2">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group">
                            <label class="font-bold">State <span style="color: red">*</span> :</label>
                            <asp:UpdatePanel ID="UpdatePanel29" runat="server">
                                <ContentTemplate>
                                   
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label class="font-bold">City <span style="color: red">*</span> :</label>
                            <asp:UpdatePanel ID="UpdatePanel28" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-control m-t select2">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label class="font-bold">Pincode <span style="color: red">*</span> :</label>
                            <asp:UpdatePanel ID="UpdatePanel31" runat="server">
                                <ContentTemplate>
                                    <asp:TextBox ID="txtPinCode" runat="server" CssClass="form-control" TextMode="Number" data-required="true" placeholder="Pin Code"></asp:TextBox>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label class="font-bold">E-mail :</label>
                            <asp:UpdatePanel ID="UpdatePanel32" runat="server">
                                <ContentTemplate>
                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" data-required="true" placeholder="E-mail"></asp:TextBox>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label class="font-bold">Mobile No. <span style="color: red">*</span> :</label>
                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                <ContentTemplate>
                                    <asp:TextBox ID="txtMobileNo" MaxLength="10" runat="server" TextMode="Phone" CssClass="form-control" data-required="true" placeholder="Mobile No."></asp:TextBox>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label class="font-bold">Confirm Mobile No. <span style="color: red">*</span> :</label>
                            <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                <ContentTemplate>
                                    <asp:TextBox ID="txtConfirmMobileNo" MaxLength="10" runat="server" TextMode="Phone" CssClass="form-control" data-required="true" placeholder="Mobile No."></asp:TextBox>
                                    <div class="alert alert-danger" id="divAlertMobile" runat="server" style="display: none">
                                        <asp:Label ID="lblMobileValidationMsg" runat="server" ForeColor="Red" Text=""></asp:Label>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label class="font-bold">Nominee Name <span style="color: red">*</span> :</label>
                            <asp:UpdatePanel ID="UpdatePanel22" runat="server">
                                <ContentTemplate>
                                    <asp:TextBox ID="txtNomineeName" MaxLength="100" runat="server" CssClass="form-control" data-required="true" placeholder="Nominee Name"></asp:TextBox>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label class="font-bold">Nominee Relation <span style="color: red">*</span> :</label>
                            <asp:UpdatePanel ID="UpdatePanel23" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlNomineeRelation" runat="server" CssClass="form-control m-t select2">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group">
                            <label class="font-bold">Nominee Age :</label>
                            <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                                <ContentTemplate>
                                    <asp:TextBox ID="txtNomineeAge" MaxLength="2" TextMod="Number" runat="server" CssClass="form-control" data-required="true" placeholder="Nominee Age"></asp:TextBox>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div class="col-md-3"></div>
                    <div class="col-md-3">
                        <span class="checkbx" style="vertical-align:sub;"><asp:CheckBox ID="chkTermsCondition" runat="server" /> I accept terms & condition</span>
                    </div>
                    <div class="col-md-6">
                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                            <ContentTemplate>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="form-group" style="text-align: left">
                    <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                        <ContentTemplate>
                            <div class="alert alert-danger" id="divAlertValidation" runat="server" style="display: none">
                                <asp:Label ID="lblValidationMessage" runat="server" ForeColor="Red" Text=""></asp:Label>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <p class="form-messege"></p>

                <asp:UpdatePanel ID="UpdatePanel105" runat="server">
                    <ContentTemplate>
                        <asp:HiddenField ID="hdnMyModal" runat="server" />
                        <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderMessage" runat="server" OkControlID="btnModalok"
                            PopupControlID="pnlMessageBox" TargetControlID="hdnMyModal" CancelControlID="btnModalok"
                            BackgroundCssClass="popupBackground">
                        </ajaxToolkit:ModalPopupExtender>
                        <asp:Panel ID="pnlMessageBox" runat="server" CssClass="popup" Width="508px" HorizontalAlign="Center" Style="z-index: 1001">
                            <div class="popupLabel">
                                <asp:Label ID="Label2" runat="server" ForeColor="White" Text="Register Form"></asp:Label>
                            </div>
                            <div class="panel-body" style="padding: 15px; overflow-y: auto;">
                                <div class="text-left">
                                    <asp:Label ID="lblPopMessage" runat="server"></asp:Label>
                                </div>
                                <br />
                                <br />
                                <br />
                                <div class="text-center">
                                    <asp:UpdatePanel ID="UpdatePanel33" runat="server">
                                        <ContentTemplate>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:PostBackTrigger ControlID="btnModalok" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </form>
        </div>
    </div>

</asp:Content>

