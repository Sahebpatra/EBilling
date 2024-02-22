<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="User_Form_Access.aspx.cs" Inherits="User_Form_Access" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function RedirectToListScreen() {
            window.location.href = "User_Form_Access.aspx";
            return false;
        }
        function ShowPopup() {
            $("#myModal").addClass("modal fade in show");
            $('#myModal').modal('show');
        }
    </script>
    <script type="text/javascript">

        function confirmSubmit() {
            if (confirm("Are you sure to Submit?") == true)
                return true;
            else
                return false;
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <ul class="breadcrumb no-border no-radius b-b b-light pull-in">
        <li><a href="Dashboard.aspx" style="color: blue; font-weight: bold;"><i class="fa fa-home"></i>Home</a></li>
        <li class="active font-bold">User Form Access</li>
    </ul>
    <div class="content">
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="card-header">
                            <h4 class="card-title font-bold card-header-text">User Form Access</h4>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group" aling="center;">
                                        <asp:Label runat="server" class="form-label font-bold">User Group</asp:Label>
                                        <asp:DropDownList ID="ddlUsrGrp" CssClass="select2 w-full" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlUsrGrp_SelectedIndexChanged">
                                            <asp:ListItem Text="Select" Value=""></asp:ListItem>
                                        </asp:DropDownList>

                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group" aling="center;">
                                        <asp:Label runat="server" class="form-label font-bold">User ID</asp:Label>
                                        <asp:DropDownList ID="ddlUsrID" CssClass="select2 w-full" runat="server" AutoPostBack="true" OnSelectedIndexChanged="lstUserid_SelectedIndexChanged">
                                            <asp:ListItem Text="Select" Value=""></asp:ListItem>
                                        </asp:DropDownList>

                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-5">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <div class="code-editor-single responsive-mg-b-30" style="height: 300px; border-radius: 10px; margin: 20px;">
                                                <h4 class="font-bold">Applicable Forms</h4>
                                                <asp:ListBox ID="LstApplFrms" SelectionMode="Multiple" Height="220px" Width="100%" Style="font-size: 13px; padding: 10px 5px;" runat="server"></asp:ListBox>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="col-md-2">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <div class="text-center" style="height: 300px; margin: 0 auto; vertical-align: middle; display: table-cell;">
                                                <asp:Button ID="btnRL" runat="server" OnClick="btnRL_Click" Text="<<" Width="95px" CssClass="btn btn-info btn-sm btn-rounded" Style="margin-bottom: 20px;" />
                                                <asp:Button ID="btnLR" runat="server" OnClick="btnLR_Click" Text=">>" Width="95px" CssClass="btn btn-info btn-sm btn-rounded" />
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="col-md-5">
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                        <ContentTemplate>
                                            <div class="code-editor-single shadow-reset" style="height: 300px; border-radius: 10px; margin: 20px;">
                                                <h4 class="font-bold">Available Forms</h4>
                                                <asp:ListBox ID="LstAvlbFrms" SelectionMode="Multiple" Height="220px" Width="100%" Style="font-size: 13px; padding: 10px 5px;" runat="server"></asp:ListBox>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-12">
                                    <div class="text-center">
                                        <asp:LinkButton ID="btnSubmit" runat="server" CssClass="btn btn-sm btn-success" OnClick="lnkBtnSubmit_Click" > <i class="fa fa-save mr-2"></i>Submit</asp:LinkButton>
                                        <asp:LinkButton ID="btnReset" runat="server" CssClass="btn btn-sm btn-info"> <i class="fa fa-refresh mr-2"></i>Reset</asp:LinkButton>
                                        <asp:LinkButton ID="btnCancel" runat="server" CssClass="btn btn-sm btn-danger" OnClick="lnkBtnBack_Click"> <i class="fa fa-arrow-left mr-2"></i>Back</asp:LinkButton>
                                    </div>
                                    <div class="form-group" style="text-align: left">
                                        <asp:Label ID="Label2" runat="server" ForeColor="Red" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                            </div>
                            <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12">
                                <div id="notes"></div>
                                <div id="messages"></div>
                                <div class="row">
                                    <div class="col-lg-12">
                                        <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red" Text=""></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- Modal -->

    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="ModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="card card-signup card-plain">
                    <div class="modal-header">
                        <div class="card-header card-header-primary  text-center" style="width: 100%;">
                            <h5 class="modal-title" id="ModalLabel">Message: User Form Access</h5>
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
    <br />
    <br />
</asp:Content>


