<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ComplaintList.aspx.cs" Inherits="ComplaintList" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function RedirectToListScreen() {
            window.location.href = "ComplaintList.aspx";
            return false;
        }
        function ShowPopup() {
            $("#myModal").addClass("modal fade in show");
            $('#myModal').modal('show');
        }
    </script>
    <style type="text/css">
        .grid-display {
            display: none;
        }

        .popover-title {
            background-color: brown !important;
            color: white;
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

        #ctl00_ContentPlaceHolder1_gvComplaintList {
            margin-bottom: 5px !important;
        }

        .card-title {
            font-size: 1.5rem;
            font-weight: 700;
            line-height: 100%;
            color: #063f84;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ul class="breadcrumb no-border no-radius b-b b-light pull-in">
        <li><a href="DashBoard.aspx" style="color: blue; font-weight: bold;"><i class="fa fa-home"></i>Home</a></li>
        <li class="active font-bold">Complaint List</li>
    </ul>

    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
        <ContentTemplate>
            <div class="content">
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="card">
                                <div class="card-header">
                                    <h4 class="card-title font-bold card-header-text">Complaint List</h4>
                                </div>
                                <div class="card-body">
                                    <div class="row">
                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <asp:Label runat="server" class="form-label font-bold">Complaint Type</asp:Label>
                                                <asp:DropDownList ID="ddlComplaintType" CssClass="select2 w-full" runat="server">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <asp:Label runat="server" class="form-label font-bold">Complaint Status</asp:Label>
                                                <asp:DropDownList ID="ddlComplaintStatus" CssClass="select2 w-full" runat="server">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <asp:Label runat="server" class="form-label font-bold">Description</asp:Label>
                                                <asp:TextBox runat="server" ID="txtComplaitDescription" class="form-control" MaxLength="100" placeholder="Complaint Description"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <asp:Label runat="server" class="form-label font-bold">Status</asp:Label>
                                                <asp:DropDownList runat="server" ID="ddlActive" class="form-control select2 w-full" data-live-search="true">
                                                    <asp:ListItem Value="">Select Active Status</asp:ListItem>
                                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                    <asp:ListItem Value="N">No</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-md-3 ml-0 pl-0" style="margin-top: 13px;">
                                            <div class="form-group">
                                                <asp:LinkButton ID="btnSearch" runat="server" CssClass="btn btn-success" OnClick="btnSearch_Click" ToolTip="Click to search"> <i class="fa fa-search mr-2"></i> Search</asp:LinkButton>
                                                <asp:LinkButton ID="lnkbtnAddMember" runat="server" OnClick="btnAdd_Click" CssClass="btn btn-info" ToolTip="Click to generate new complaint"> <i class="fa fa-plus mr-2"></i> Add New</asp:LinkButton>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-12 table-responsive">
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                                    <asp:GridView ID="gvComplaintList" runat="server"
                                                        AutoGenerateColumns="False" EmptyDataText="No record(s) found."
                                                        AllowPaging="true" ShowFooter="False" PageSize="15" CssClass="table table-bordered table-md m-0" OnPageIndexChanging="gvComplaintList_PageIndexChanging" OnRowCommand="gvComplaintList_RowCommand">
                                                        <RowStyle CssClass="tlrowlight" Font-Size="Smaller" />
                                                        <AlternatingRowStyle CssClass="tlrowdark" />
                                                        <PagerStyle CssClass="grid_pagger" Font-Size="Smaller" HorizontalAlign="right" />
                                                        <HeaderStyle CssClass="grid_header" Font-Size="Smaller" />
                                                        <FooterStyle CssClass="tlheader_1" ForeColor="#000" HorizontalAlign="Center" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Id" HeaderStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnkView" CssClass="text-ul bg-primary badge badge-success box-shadow" runat="server" Text='<%# Bind("cm_complaint_id") %>' OnClick="lnkView_Click" CommandArgument='<%# string.Concat( Eval("cm_complaint_id")) %>'></asp:LinkButton>
                                                                    <asp:HiddenField ID="hdnComplaintId" runat="server" Value='<%# Bind("cm_complaint_id") %>' />
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Complaint Type" HeaderStyle-HorizontalAlign="center">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblComplaintType" runat="server" Text='<%# Bind("cm_complaint_type_text") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="15%" />
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="15%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Raised By" HeaderStyle-HorizontalAlign="center">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblRaisedBy" runat="server" Text='<%# Bind("cm_complaint_raised_name") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="15%" />
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="15%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Complaint Date" HeaderStyle-HorizontalAlign="center">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblComplaintDate" runat="server" Text='<%# Bind("cm_complaint_date") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" />
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Description" HeaderStyle-HorizontalAlign="center">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblDescription" runat="server" Text='<%# Bind("cm_complaint_desc") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="25%" />
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="25%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Status" HeaderStyle-HorizontalAlign="center">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnkViewLog" runat="server" CssClass="text-danger font-bold" Text='<%# Bind("cm_complaint_status_text") %>' OnClick="lnkViewLog_Click" CommandArgument='<%# string.Concat( Eval("cm_complaint_id")) %>'></asp:LinkButton>
                                                                    <asp:Label ID="lblComplaintStatus" Visible="false" runat="server" Text='<%# Bind("cm_complaint_status") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" />
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Status" HeaderStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblActive" runat="server" CssClass='<%# Eval("active").Equals(Constant.Common.ActiveStatus)?"badge bg-success":"badge bg-danger"  %>' Text='<%# Bind("active") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" />
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Action" HeaderStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <div class="global_editBtn">
                                                                        <asp:LinkButton ID="lnkStatusUpdate" runat="server" Visible='<%# Eval("cm_complaint_status").ToString().Equals(Constant.ComplaintStatus.PENDING.ToString())?true:false%>' CssClass="btn btn-danger btn-sm" Text="Delete" CommandArgument='<%# string.Concat( Eval("cm_complaint_id"),"|",Eval("active")) %>' CommandName="StatusChange" OnClientClick="return confirm('Are you sure to change status?')"><i class="fa fa-trash-o"></i></asp:LinkButton>
                                                                        <asp:LinkButton ID="lnkLogEntry" runat="server" Visible='<%# Eval("cm_complaint_status").ToString().Equals(Constant.ComplaintStatus.PENDING.ToString())||Eval("cm_complaint_status").ToString().Equals(Constant.ComplaintStatus.IN_PROGRESS.ToString())?true:false%>' CssClass="btn btn-success btn-sm" Text="Delete" CommandArgument='<%# string.Concat( Eval("cm_complaint_id"),"|",Eval("active")) %>' ToolTip="Click to add complaint log" CommandName="LogEntry"><i class="fa fa-plus-square"></i></asp:LinkButton>
                                                                    </div>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                        <small id="passwordHelpBlock" class="form-text text-muted" style="padding-left: 15px">Click on <b>STATUS</b> to view the complaint log history.
										</small>
                                        <div class="clearfix"></div>
                                    </div>
                                    <div class="row m-t">
                                        <div class="col-md-12 table-responsive">
                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always">
                                                <ContentTemplate>
                                                    <div class="card-header" runat="server" id="divComplaintLogHeader">
                                                        <div class="col-xl-4 col-lg-4 col-md-12 col-sm-12" style="float: left">
                                                            <div class="card-title m-t m-b">
                                                                <asp:Label ID="lblComplaintLogHeader" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="card-body" runat="server" id="divComplaintLogDetail">
                                                        <div class="row gutters">
                                                            <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12">
                                                                <div class="table-responsive">
                                                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:GridView ID="gvComplaintLogList" runat="server"
                                                                                AutoGenerateColumns="False" EmptyDataText="No record(s) found."
                                                                                AllowPaging="false" ShowFooter="False" CssClass="table table-bordered table-md m-0">

                                                                                <RowStyle CssClass="tlrowlight" />
                                                                                <AlternatingRowStyle CssClass="tlrowdark" />
                                                                                <PagerStyle CssClass="grid_pagger" HorizontalAlign="right" />
                                                                                <HeaderStyle CssClass="grid_header" />
                                                                                <FooterStyle CssClass="tlheader_1" ForeColor="#000" HorizontalAlign="Center" />
                                                                                <Columns>
                                                                                    <asp:TemplateField HeaderText="Id" HeaderStyle-HorizontalAlign="Center">
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="lnkComplaintLog" runat="server" Text='<%# Bind("cl_log_id") %>' OnClick="lnkComplaintLog_Click" CommandArgument='<%# string.Concat(Eval("cl_complaint_id"),"|", Eval("cl_log_id")) %>'></asp:LinkButton>
                                                                                            <asp:HiddenField ID="hdnComplaintLogId" runat="server" Value='<%# Bind("cl_complaint_id") %>' />
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Status" HeaderStyle-HorizontalAlign="center">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblComplaintLogStatus" runat="server" Text='<%# Bind("cl_complaint_status_text") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" />
                                                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Log Description" HeaderStyle-HorizontalAlign="center">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblLogDescription" runat="server" Text='<%# Bind("cl_log_desc") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="35%" />
                                                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="35%" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Log Remarks" HeaderStyle-HorizontalAlign="center">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblLogRemarks" runat="server" Text='<%# Bind("cl_remarks") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="20%" />
                                                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="20%" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Log By" HeaderStyle-HorizontalAlign="center">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblLogBy" runat="server" Text='<%# Bind("log_created_user_name") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="20%" />
                                                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="20%" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Log Date" HeaderStyle-HorizontalAlign="center">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblLogDate" runat="server" Text='<%# Bind("created_date") %>'></asp:Label>
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
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group" style="text-align: center;">
                                                <asp:LinkButton ID="btnBack" runat="server" CssClass="btn btn-danger" PostBackUrl="~/DashBoard.aspx"> <i class="fa fa-arrow-left mr-2"></i>Back</asp:LinkButton>
                                            </div>
                                            <div class="form-group" style="text-align: left">
                                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                    <ContentTemplate>
                                                        <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red" Text=""></asp:Label>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <!-- Modal -->

    <%--<div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="ModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="card card-signup card-plain">
                    <div class="modal-header">
                        <div class="card-header card-header-primary  text-center" style="width: 100%;">
                            <h5 class="modal-title" id="ModalLabel">User Profile List</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                    </div>
                    <div class="modal-body">
                        <asp:Label ID="lblPopMessage" runat="server"></asp:Label>
                    </div>
                    <div class="modal-footer">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:Button ID="btnModalok" runat="server" CssClass="btn btn-success" Text="Ok" OnClientClick="RedirectToListScreen()" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
    </div>--%>
    <asp:UpdatePanel ID="UpdatePanel105" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="hdnMyModal" runat="server" />
            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderMessage" runat="server" OkControlID="btnModalok"
                PopupControlID="pnlMessageBox" TargetControlID="hdnMyModal" CancelControlID="btnModalok"
                BackgroundCssClass="popupBackground">
            </ajaxToolkit:ModalPopupExtender>
            <asp:Panel ID="pnlMessageBox" runat="server" CssClass="popup" Width="508px" HorizontalAlign="Center" Style="z-index: 1001">
                <div class="popupLabel">
                    <asp:Label ID="Label2" runat="server" ForeColor="White" Text="Complaint List"></asp:Label>
                </div>
                <div class="panel-body" style="padding: 15px; height: 150px; overflow-y: auto;">
                    <div class="text-left">
                        <asp:Label ID="lblPopMessage" runat="server"></asp:Label>
                    </div>
                    <br />
                    <br />
                    <br />
                    <div class="text-center">
                        <asp:UpdatePanel ID="UpdatePanel21" runat="server">
                            <ContentTemplate>
                                <asp:Button ID="btnModalok" runat="server" CssClass="btn btn-info" Text="Close" OnClick="btnModalok_Click" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">

</script>
</asp:Content>

