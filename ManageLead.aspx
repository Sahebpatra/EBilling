<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManageLead.aspx.cs" Inherits="ManageLead" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Manage Lead </title>
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
                    <div class="col-sm-2">
                        <div class="form-group">
                            <span class="form-label font-bold">Lead Sorce :</span>
                            <asp:DropDownList ID="ddlkkk" runat="server" class="form-control m-t select2" Style="margin-top: 3px;">
                                <asp:ListItem Selected="True" Value="White"> Select Type</asp:ListItem>
                                <asp:ListItem Value="White"> FaceBook </asp:ListItem>
                                <asp:ListItem Value="White"> WhatsApp </asp:ListItem>
                                <asp:ListItem Value="White"> Refer </asp:ListItem>
                                <asp:ListItem Value="White"> Paper </asp:ListItem>
                                <asp:ListItem Value="White"> Unknown </asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-2">
                        <div class="form-group">
                            <span class="form-label font-bold">Country :</span>
                            <asp:UpdatePanel ID="UpdatePanel29" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlorgname" runat="server" CssClass="form-control m-t select2" Style="margin-top: 3px;">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div class="col-sm-2">
                        <div class="form-group">
                            <span class="form-label font-bold">City :</span>
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlSectionName" runat="server" CssClass="form-control m-t select2" Style="margin-top: 3px;">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div class="col-sm-2">
                        <div class="form-group">
                            <label>Pin Code : </label>
                            <asp:TextBox ID="TextBox2" type="text" class="form-control" placeholder="Enter Pin Code" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-2">
                        <div class="form-group">
                            <span class="form-label font-bold">Enqury Type :</span>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control m-t select2" Style="margin-top: 3px;">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div class="col-sm-2">
                        <div class="form-group">
                            <span class="form-label font-bold">Customer Business :</span>
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control m-t select2" Style="margin-top: 3px;">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div class="col-sm-4">
                        <div class="form-group">
                            <label>Mobile Number : </label>
                            <asp:TextBox ID="txtProductName" type="text" class="form-control" placeholder="Enter Product Name" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="form-group">
                            <label>Email-ID : </label>
                            <textarea id="TextBox1" type="text" class="form-control" placeholder="Enquiry" runat="server" cols="20" rows="3"></textarea>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="form-group">
                            <label>Address : </label>
                            <textarea id="Textarea1" type="text" class="form-control" placeholder="Solution" runat="server" cols="20" rows="3"></textarea>
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
                    <asp:Button ID="Storepagebutton" class="btn btn-success" runat="server" Style="text-align: center;" Text="Submit Data" />
                </div>
                <div class="col-sm-4 text-right text-center-xs">
                </div>
            </div>
        </footer>
    </section>
</asp:Content>

