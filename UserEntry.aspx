<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UserEntry.aspx.cs" Inherits="UserEntry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>User Entry :</title>
    <script type="text/javascript" src="Scripts/FunctionValidator.js"></script>
    <script src="Scripts/RegEX.js"></script>
    <script src="Scripts/date.js"></script>
    <script type="text/javascript" src="Scripts/ValidateLoanEntryData.js?time=<%= DateTime.Now.ToString("yyyy.MM.dd-HH.mm.ss.fff") %>"></script>
    <script type="text/javascript">

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

        .badge {
            background-color: #974b4b !important;
        }

        .bg_bisque {
            background-color: bisque !important;
        }

        .p-l-0 {
            padding-left: 0px !important;
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ul class="breadcrumb no-border no-radius b-b b-light pull-in">
        <li><a href="index.html"><i class="fa fa-home"></i>Home</a></li>
        <li><a href="#">Company Registratiton</a></li>
        <asp:HiddenField ID="hdnCompanyId" runat="server" />
    </ul>
    <div class="row">
        <div class="col-sm-12">
            <section class="panel panel-default">
                <header class="panel-heading font-bold">User Details: </header>
                <div class="panel-body">
                    <div class="col-sm-3">
                        <div class="form-group">
                            <label>User ID : </label>
                            <asp:TextBox ID="txtUserId" type="text" class="form-control" placeholder="Enter User ID" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <div class="form-group">
                            <label>Password : </label>
                            <asp:TextBox ID="txtPassword" type="Password" class="form-control" placeholder="Enter Password" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <div class="form-group">
                            <label>First Name: </label>
                            <asp:TextBox ID="txtFirstName" class="form-control" placeholder="Enter First Name" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <div class="form-group">
                            <label>Last Name: </label>
                            <asp:TextBox ID="txtLastName" class="form-control" placeholder="Enter Last Name" runat="server"></asp:TextBox>
                        </div>
                    </div> 
                    <div class="col-sm-3">
                        <div class="form-group">
                            <label>Signature: </label>
                            <asp:FileUpload id="FileUpload1" runat="server" />
                        </div>
                    </div>

                </div>
            </section>
        </div>

    </div>
    <section class="panel panel-default">
        <footer class="panel-footer">
            <div class="row">
                <div class="col-sm-4 hidden-xs">
                </div>
                <div class="col-sm-4 text-center">
                    <asp:Button ID="btnUserEnty" class="btn btn-success" runat="server" Style="text-align: center;" Text="Submit Data" OnClick="btnUserEnty_Click"/>
                </div>
                <div class="col-sm-4 text-right text-center-xs">
                </div>
            </div>
        </footer>
    </section>
    <div class="row">
        <div class="col-sm-12">
            <div class="panel panel-default">
                <header class="panel-heading font-bold">User List: </header>
                <div class="panel-body">
                    <div class="table-responsive" style="overflow: scroll;">
                        <div class="row">
                            <div class="col-md-12">
                                <asp:UpdatePanel ID="UpdatePanetxtFrmNamel1" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="Grd_UserList" runat="server"
                                            AutoGenerateColumns="False" EmptyDataText="No record(s) found."
                                            AllowPaging="true" PageSize="150" CssClass="table table-bordered ">
                                            <RowStyle CssClass="tlrowlight" Font-Size="Smaller" />
                                            <AlternatingRowStyle CssClass="tlrowdark" />
                                            <PagerStyle CssClass="grid_pagger" Font-Size="Smaller" HorizontalAlign="right" />
                                            <HeaderStyle CssClass="grid_header" Font-Size="Smaller" />
                                            <FooterStyle CssClass="tlheader_1" ForeColor="#000" HorizontalAlign="Center" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="User Name" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblParent" runat="server" Text='<%# Bind("User_Full_Name") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="User Id" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblUserId" runat="server" Text='<%# Bind("usp_user_id") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Password" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblParent" runat="server" Text='<%# Bind("usp_pswd") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                </asp:TemplateField>
                                                
                                            </Columns>
                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Modal -->

    <div class="modal fade" id="myModal" runat="server" tabindex="-1" role="dialog" aria-labelledby="ModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="card card-signup card-plain">
                    <div class="modal-header">
                        <div class="card-header card-header-primary  text-center" style="width: 100%;">
                            <h5 class="modal-title" id="ModalLabel">Message: Invoice Master</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                    </div>
                    <div class="modal-body">
                        <asp:Label ID="lblPopMessage" runat="server"></asp:Label>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-danger" data-dismiss="modal">
                            <span aria-hidden="true">&times;</span>Close</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

