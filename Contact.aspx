<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Web Contact</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ul class="breadcrumb no-border no-radius b-b b-light pull-in">
        <li><a href="#"><i class="fa fa-home"></i>Home</a></li>
        <li><a href="#">Web Contact Page Details</a></li>
    </ul>
    <div class="row">
        <div class="col-sm-12">
            <div class="panel panel-default">
                <header class="panel-heading font-bold">Product Upload: </header>
                <div class="panel-body">
                    <div class="table-responsive" style="overflow: scroll;">
                        <div class="row">
                            <div class="col-md-12">
                                <asp:UpdatePanel ID="UpdatePanetxtFrmNamel1" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="WebContactReport" runat="server"
                                            AutoGenerateColumns="False" EmptyDataText="No record(s) found."
                                            AllowPaging="true" PageSize="150" CssClass="table table-bordered ">
                                            <RowStyle CssClass="tlrowlight" Font-Size="Smaller" />
                                            <AlternatingRowStyle CssClass="tlrowdark" />
                                            <PagerStyle CssClass="grid_pagger" Font-Size="Smaller" HorizontalAlign="right" />
                                            <HeaderStyle CssClass="grid_header" Font-Size="Smaller" />
                                            <FooterStyle CssClass="tlheader_1" ForeColor="#000" HorizontalAlign="Center" />
                                            <Columns>
                                                <asp:TemplateField HeaderText=" ID" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblParent" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Name" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblParent" runat="server" Text='<%# Bind("ContactName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Mobile No" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblParent" runat="server" Text='<%# Bind("ContactMobileNo") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Email" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblParent" runat="server" Text='<%# Bind("ContactEmail") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Request Type" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblParent" runat="server" Text='<%# Bind("RequestType") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Message Type" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblParent" runat="server" Text='<%# Bind("MessageType") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Service Name" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblParent" runat="server" Text='<%# Bind("ServiceName") %>'></asp:Label>
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
</asp:Content>

