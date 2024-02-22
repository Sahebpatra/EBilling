<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CompanyRegistration.aspx.cs" Inherits="CompanyRegistration" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Company Registration :</title>
    <script type="text/javascript" src="Scripts/FunctionValidator.js"></script>
    <script src="Scripts/RegEX.js"></script>
    <script src="Scripts/date.js"></script>
    <script type="text/javascript" src="Scripts/ValidateLoanEntryData.js?time=<%= DateTime.Now.ToString("yyyy.MM.dd-HH.mm.ss.fff") %>"></script>
    <script type="text/javascript">
        function RedirectToListScreen() {
            window.location.href = "CustomerLoanList.aspx";
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
    </ul>
    <div class="row">
        <div class="col-sm-12">
            <section class="panel panel-default">
                <header class="panel-heading font-bold">Company Details: </header>
                <div class="panel-body">
                    <div class="col-sm-3">
                        <div class="form-group">
                            <label>Comapny ID : </label>
                            <asp:TextBox ID="txtCompanyId" type="text" class="form-control" placeholder="Company ID" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <div class="form-group">
                            <label>Comapny Name : </label>
                            <asp:TextBox ID="txtcompanyname" type="text" class="form-control" placeholder="Enter Company Name" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <div class="form-group">
                            <label>Mobile No: </label>
                            <asp:TextBox ID="txtmobbileno" type="number" class="form-control" placeholder="Enter Mobbile No" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <div class="form-group">
                            <label>E-mail Id: </label>
                            <asp:TextBox ID="txtemail" type="email" class="form-control" placeholder="Enter Email Id" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <div class="form-group">
                            <label>Website: </label>
                            <asp:TextBox ID="txtwebsite" class="form-control" placeholder="Enter Website" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <div class="form-group">
                            <label>Gst Id: </label>
                            <asp:TextBox ID="txtgstid" type="" class="form-control" placeholder="Enter Gst Id" runat="server" Style="text-transform: uppercase;"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <div class="form-group">
                            <label>Business Name: </label>
                            <asp:TextBox ID="txtBusinessName" type="" class="form-control" placeholder="Enter Business Name" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <div class="form-group">
                            <label>Business Type: </label>
                            <asp:TextBox ID="txtBusinessType" type="" class="form-control" placeholder="Sclect Business Type" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <div class="form-group">
                            <label>Company Logo: </label>
                           <asp:FileUpload id="FileUpload1" runat="server" />
                        </div>
                    </div>
                </div>
            </section>
        </div>
        <div class="col-sm-12" data-validate="parsley">
            <section class="panel panel-default">
                <header class="panel-heading font-bold">Company Address Details: </header>
                <div class="panel-body">
                    <div class="col-sm-3">
                        <div class="form-group">
                            <span class="form-label font-bold">Country Name :</span>
                            <asp:DropDownList ID="ddlCountyName" runat="server" class="form-control m-t select2" Style="margin-top: 3px;">
                                <asp:ListItem Selected="True" Value="White"> INDIA </asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-sm-3">
                        <div class="form-group">
                            <span class="form-label font-bold">State Name :</span>
                            <asp:UpdatePanel ID="UpdatePanel29" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlstatename" runat="server" CssClass="form-control m-t select2" AutoPostBack="true" OnSelectedIndexChanged="ddlState_SelectedIndexChanged" Style="margin-top: 3px;">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>

                    </div>
                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <div class="form-group">
                                    <span class="form-label font-bold">City Name :</span>
                                    <asp:DropDownList ID="ddlCitySclect" AutoPostBack="true" runat="server" class="form-control m-t select2" Style="margin-top: 3px;"></asp:DropDownList>
                                </div>
                            </ContentTemplate>

                        </asp:UpdatePanel>
                    </div>
                    <div class="col-sm-3">
                        <div class="form-group">
                            <label>Pin Code: </label>
                            <asp:TextBox ID="txtPinCode" type="mail" class="form-control" placeholder="Enter Pin Code" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <div class="form-group">
                            <textarea class="form-control parsley-validated" runat="server" id="txtFullAddress" rows="3" data-minwords="6" data-required="true" placeholder="Enter Your Address"></textarea>
                        </div>
                    </div>
                    <%--<div class="col-sm-3">
                            <div class="form-group">
                                <textarea class="form-control parsley-validated" runat="server" ID="txtAlternativeAddress" rows="3" data-minwords="6" data-required="true" placeholder="Enter Your Alternative Address"></textarea>
                            </div>
                        </div>--%>
                    <div class="col-sm-3">
                        <div class="form-group">
                            <textarea class="form-control parsley-validated" runat="server" id="txtNearby" rows="3" data-minwords="6" data-required="true" placeholder="Enter Nearby Address"></textarea>
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
                    <asp:Button ID="Button1" class="btn btn-success" runat="server" Style="text-align: center;" Text="Submit Data" OnClick="Button1_Click" />
                </div>
                <div class="col-sm-4 text-right text-center-xs">
                </div>
            </div>
        </footer>
    </section>
    <div class="row">
        <div class="col-sm-12">
            <div class="panel panel-default">
                <header class="panel-heading font-bold">Company Register List: </header>
                <div class="panel-body">
                    <div class="table-responsive" style="overflow: scroll;">
                        <div class="row">
                            <div class="col-md-12">
                                <asp:UpdatePanel ID="UpdatePanetxtFrmNamel1" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="Grd_CompanyRegisterList" runat="server"
                                            AutoGenerateColumns="False" EmptyDataText="No record(s) found."
                                            AllowPaging="true" PageSize="150" CssClass="table table-bordered ">
                                            <RowStyle CssClass="tlrowlight" Font-Size="Smaller" />
                                            <AlternatingRowStyle CssClass="tlrowdark" />
                                            <PagerStyle CssClass="grid_pagger" Font-Size="Smaller" HorizontalAlign="right" />
                                            <HeaderStyle CssClass="grid_header" Font-Size="Smaller" />
                                            <FooterStyle CssClass="tlheader_1" ForeColor="#000" HorizontalAlign="Center" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="ID" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblParent" runat="server" Text='<%# Bind("cd_id") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Company Name" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblParent" runat="server" Text='<%# Bind("cd_company_name") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Company Short Name" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblParent" runat="server" Text='<%# Bind("cd_company_name_short") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Address Line 1" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblParent" runat="server" Text='<%# Bind("cd_add1") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Address Line 2" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblParent" runat="server" Text='<%# Bind("cd_add2") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="City" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblParent" runat="server" Text='<%# Bind("cd_city") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Pin Code" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblParent" runat="server" Text='<%# Bind("cd_pin") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="State" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblParent" runat="server" Text='<%# Bind("cd_state") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Country" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblParent" runat="server" Text='<%# Bind("cd_country") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Mobile" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblParent" runat="server" Text='<%# Bind("cd_mob1") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Mail Id" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblParent" runat="server" Text='<%# Bind("cd_mail_id") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Action" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:HyperLink ID="lnlName" runat="server" Target="_blank" Text="Add User" NavigateUrl='<%# Eval("cd_id", "~/UserEntry.aspx?id={0}") %>'></asp:HyperLink>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" />
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
                            <h5 class="modal-title" id="ModalLabel">Error Message</h5>
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

