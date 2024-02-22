<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FormMenuMaster.aspx.cs" Inherits="FormMenuMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="Scripts/FunctionValidator.js"></script>
    <%string timestamp = DateTime.Now.ToString("yyyy.MM.dd-HH.mm.ss.fff");%>
    <script src="Scripts/ValidateFormMenuMaster.js?time=<%=timestamp%>" type="text/javascript"></script>
    <script type="text/javascript">
        function RedirectToListScreen() {
            window.location.href = "FormMenuMaster.aspx";
            return false;
        }
        function ShowPopup() {
            $("#myModal").addClass("modal fade in show");
            $('#myModal').modal('show');
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ul class="breadcrumb no-border no-radius b-b b-light pull-in">
        <li><a href="Dashboard.aspx" style="color: blue; font-weight: bold;"><i class="fa fa-home"></i>Home</a></li>
        <li class="active font-bold">Form Menu Master</li>
    </ul>

    <div class="content">
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="card-header">
                            <h4 class="card-title font-bold card-header-text ">Form Menu Master</h4>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group" aling="center;">
                                        <asp:Label runat="server" class="form-label font-bold">Filter By Parent Form</asp:Label>
                                        <asp:DropDownList ID="ddlParentForm" CssClass="select2 w-full" runat="server" AutoPostBack="true">
                                            <asp:ListItem Text="Select" Value=""></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div id="notes"></div>
                            <div id="messages"></div>
                            <div class="row">
                                <div class="col-md-12">
                                    <asp:UpdatePanel ID="UpdatePanetxtFrmNamel1" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="gvFormList" runat="server"
                                                AutoGenerateColumns="False" EmptyDataText="No record(s) found."
                                                AllowPaging="true" ShowFooter="true" PageSize="15" CssClass="table table-bordered table-md m-0" 
                                                OnRowDataBound="gvFormList_RowDataBound" 
                                                OnSelectedIndexChanged="ddlParentForm_SelectedIndexChanged" 
                                                OnRowCommand="gvFormList_RowCommand" 
                                                OnRowCancelingEdit="gvFormList_RowCancelingEdit" 
                                                OnRowUpdating="gvFormList_RowUpdating" 
                                                OnRowEditing="gvFormList_RowEditing" 
                                                OnPageIndexChanging="gvFormList_PageIndexChanging">
                                                <RowStyle CssClass="tlrowlight" Font-Size="Smaller" />
                                                <AlternatingRowStyle CssClass="tlrowdark" />
                                                <PagerStyle CssClass="grid_pagger" Font-Size="Smaller" HorizontalAlign="right" />
                                                <HeaderStyle CssClass="grid_header" Font-Size="Smaller" />
                                                <FooterStyle CssClass="tlheader_1" ForeColor="#000" HorizontalAlign="Center" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="#" HeaderStyle-HorizontalAlign="center">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSrl" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                                            <asp:HiddenField ID="hdnId" runat="server" Value='<%# Bind("fmm_id") %>'></asp:HiddenField>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:Label ID="lblSrl_ftr" runat="server"></asp:Label>
                                                            <%--<%#Container.DisplayIndex%>--%>
                                                        </FooterTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Parent Form" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblParent" runat="server" Text='<%# Bind("parentFormName") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:DropDownList ID="ddlParent" runat="server" CssClass="select2 w-full">
                                                            </asp:DropDownList>
                                                        </EditItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:DropDownList ID="ddlParent_ftr" runat="server" CssClass="select2 w-full">
                                                            </asp:DropDownList>
                                                        </FooterTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="20%" />
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="20%" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Form Name" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblFrmName" runat="server" Text='<%# Bind("fmm_name") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtFrmName" runat="server" Width="90%" Text='<%# Bind("fmm_name") %>' CssClass="txtBox"></asp:TextBox>
                                                        </EditItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:TextBox ID="txtFrmName_ftr" runat="server" Width="90%" CssClass="txtBox"></asp:TextBox>
                                                        </FooterTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="20%" />
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="20%" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Form Link" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblFrmLink" runat="server" Text='<%# Bind("fmm_link") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtFrmLink" runat="server" Width="90%" Text='<%# Bind("fmm_link") %>' CssClass="txtBox"></asp:TextBox>
                                                        </EditItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:TextBox ID="txtFrmLink_ftr" runat="server" Width="90%" CssClass="txtBox"></asp:TextBox>
                                                        </FooterTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="20%" />
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="20%" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Sequence" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblFrmSeq" runat="server" Text='<%# Bind("fmm_sequence") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtFrmSeq" runat="server" Width="90%" Text='<%# Bind("fmm_sequence") %>' CssClass="txtBox"></asp:TextBox>
                                                        </EditItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:TextBox ID="txtFrmSeq_ftr" runat="server" Width="90%" CssClass="txtBox"></asp:TextBox>
                                                        </FooterTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" />
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Active" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblActive" runat="server" Text='<%# Bind("activeDesc") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:DropDownList ID="ddlActive" runat="server" CssClass="select2 w-full">
                                                                <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </EditItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:DropDownList ID="ddlActive_ftr" runat="server" CssClass="select2 w-full">
                                                                <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </FooterTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" />
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Edit" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:Button ID="btnEdit" CommandName="Edit" Width="55%" CssClass="btn btn-sm btn-primary" runat="server"
                                                                Text="Edit" />
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:Button ID="btnUpdate" CommandName="Update" Width="55%" CssClass="btn btn-sm btn-success" runat="server"
                                                                Text="Update" />
                                                            <asp:Button ID="btnCancel" CommandName="Cancel" Width="55%" CssClass="btn btn-sm btn-danger" runat="server"
                                                                Text="Cancel" />
                                                        </EditItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:Button ID="btnSubmit" CommandName="Submit" Width="55%" CssClass="btn btn-sm btn-success" runat="server"
                                                                Text="Submit" />
                                                        </FooterTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>

                                        </ContentTemplate>
                                        <Triggers>
                                            <%-- <asp:PostBackTrigger ControlID="btnEdit" />--%>
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="clearfix"></div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group" style="text-align: center;">

                                        <asp:LinkButton ID="btnBack" runat="server" CssClass="btn btn-sm btn-danger" PostBackUrl="~/Dashboard.aspx"> <i class="fa fa-arrow-left mr-2"></i>Back</asp:LinkButton>
                                    </div>
                                    <div class="form-group" style="text-align: left">
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
                            <h5 class="modal-title" id="ModalLabel">Message: Form Menu Master</h5>
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

