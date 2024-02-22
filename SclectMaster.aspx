<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SclectMaster.aspx.cs" Inherits="SclectMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <ul class="breadcrumb no-border no-radius b-b b-light pull-in">
        <li><a href="#"><i class="fa fa-home"></i>Home</a></li>
        <li><a href="#">Sclect Master</a></li>
    </ul>
    <section class="panel panel-default">
        <header class="panel-heading">Sclect Master :</header>
        <div class="table-responsive" <%--style=" overflow: scroll;"--%>>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <table class="table table-striped b-t b-light">
                        <thead>
                            <tr>
                                <th>Org Name :</th>
                                <th>Section Name :</th>
                                <th>Page Name :</th>
                                <th>Website Name :</th>
                                <th></th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtOrgName" runat="server"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtSectionName" cols="20" Rows="2" Style="height: 28px;" runat="server"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtPageName" runat="server" Style="width: 180px;"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtWebsiteName" runat="server" Style="width: 180px;"></asp:TextBox></td>
                                <td>
                                    <asp:Button ID="btnScelctMaster" runat="server" Text="Add" class="btn btn-default" OnClick="btnScelctMaster_btn" /></td>
                            </tr>
                        </tbody>
                    </table>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnScelctMaster" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
        <div style=" overflow: scroll;">
            <asp:UpdatePanel ID="UpdatePanetxtFrmNamel1" runat="server">
            <ContentTemplate>
                <asp:GridView ID="GridViewDataSetReturn" runat="server"
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
                                <asp:Label ID="lblParent" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Org Name" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblParent" runat="server" Text='<%# Bind("TOrgName") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Section Name" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblParent" runat="server" Text='<%# Bind("TSectionName") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Page Name" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblParent" runat="server" Text='<%# Bind("TPageName") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Website Name" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblParent" runat="server" Text='<%# Bind("TWebsiteName") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
 
        </div>
      </section>
</asp:Content>

