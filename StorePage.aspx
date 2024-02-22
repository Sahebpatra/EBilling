<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="StorePage.aspx.cs" Inherits="StorePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ul class="breadcrumb no-border no-radius b-b b-light pull-in">
        <li><a href="index.html"><i class="fa fa-home"></i>Home</a></li>
        <li><a href="#">Product Upload</a></li>
    </ul>
    <div class="row">
        <div class="col-sm-12">
            <div class="panel panel-default">
                <header class="panel-heading font-bold">Product Upload: </header>
                <div class="panel-body">
                    <div class="col-sm-3">
                        <div class="form-group">
                            <span class="form-label font-bold">Org Name :</span>
                            <asp:UpdatePanel ID="UpdatePanel29" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlorgname" runat="server" CssClass="form-control m-t select2" Style="margin-top: 3px;">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <div class="form-group">
                            <span class="form-label font-bold">Page Name :</span>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlPageName" runat="server" CssClass="form-control m-t select2" Style="margin-top: 3px;">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <div class="form-group">
                            <span class="form-label font-bold">Section Name :</span>
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlSectionName" runat="server" CssClass="form-control m-t select2" Style="margin-top: 3px;">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <div class="form-group">
                            <label>Product Name : </label>
                            <asp:TextBox ID="txtProductName" type="text" class="form-control" placeholder="Enter Product Name" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <div class="form-group">
                            <label>Product Price : </label>
                            <asp:TextBox ID="txtProductPrice" type="text" class="form-control" placeholder="Enter Product Price" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <div class="form-group">
                            <label>Buy Now Link : </label>
                            <asp:TextBox ID="txtBuyNowLink" type="link" class="form-control" placeholder="Enter Buy Now Link" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <div class="form-group">
                            <label>Product Description: </label>
                            <asp:TextBox ID="txtProductDescription" type="text" class="form-control" placeholder="Enter Product Description" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <div class="form-group">
                            <label>Upload Product: </label>
                            <asp:FileUpload ID="FUProductPhoto" type="file" accept=".png, .jpg, .jpeg" class="btn btn-default active" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <section class="panel panel-default">
        <footer class="panel-footer">
            <div class="row">
                <div class="col-sm-4 hidden-xs">
                </div>
                <div class="col-sm-4 text-center">
                    <asp:Button ID="Storepagebutton" class="btn btn-success" runat="server" Style="text-align: center;" Text="Submit Data" OnClick="Store_page_button" />
                </div>
                <div class="col-sm-4 text-right text-center-xs">
                </div>
            </div>
        </footer>
    </section>
    <div class="row">
        <div class="col-sm-12">
            <div class="panel panel-default">
                <header class="panel-heading font-bold">Store Page Details: </header>
                <div class="panel-body">
                    <div class="table-responsive" style="overflow: scroll;">
                        <div class="row">
                            <div class="col-md-12">
                                <asp:GridView ID="GrdStorePage" runat="server" AutoGenerateColumns="False"
                                    EmptyDataText="No record(s) found."
                                    AllowPaging="true" PageSize="150" CssClass="table table-bordered" DataKeyNames="id">
                                    <RowStyle CssClass="tlrowlight" Font-Size="x-small" />
                                    <AlternatingRowStyle CssClass="tlrowdark" />
                                    <PagerStyle CssClass="grid_pagger" Font-Size="Smaller" HorizontalAlign="right" />
                                    <HeaderStyle CssClass="grid_header" Font-Size="Smaller" />
                                    <FooterStyle CssClass="tlheader_1" ForeColor="#000" HorizontalAlign="Center" />
                                    <Columns>

                                        <asp:TemplateField HeaderText="ID" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblid" runat="server" Text='<%# Bind("id") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="6%" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="6%" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Page Name" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPageName" runat="server" Text='<%# Bind("TDpageName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="6%" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="6%" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Name" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblName" runat="server" Text='<%# Bind("TDsectionName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="6%" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="6%" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Product Name" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblProductName" runat="server" Text='<%# Bind("TDproductName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="6%" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="6%" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Product Price" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblProductPrice" runat="server" Text='<%# Bind("TDproductPrice") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="6%" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="6%" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Link" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblLink" runat="server" Text='<%# Bind("TDbuyNowLink") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="6%" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="6%" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Product Description" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblProductDescription" runat="server" Text='<%# Bind("TDproductDescription") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="6%" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="6%" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Product Photo" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Image ID="lblProductPhoto" runat="server" ImageUrl='<%# Eval("TDuploadProduct") %>' Height="50px" Width="50px" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="6%" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="6%" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Action" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkDeleteAction" runat="server" Text="Delete" OnClick="btnDelete" OnClientClick="return confirm('Are you sure you want to delete this event?');" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="1%" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="1%" />
                                        </asp:TemplateField>

                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

