<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="IncomingCall.aspx.cs" Inherits="IncomingCall" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <ul class="breadcrumb no-border no-radius b-b b-light pull-in">
                <li><a href="index.html"><i class="fa fa-home"></i> Home</a></li>
                <li><a href="#">Product Upload</a></li>
              </ul>
              <div class="row">
                <div class="col-sm-12">
                  <div class="panel panel-default">
                    <header class="panel-heading font-bold">Product Upload: </header>
                        <div class="panel-body">
                        <div class="col-sm-4">
                              <div class="form-group">
                                <span class="form-label font-bold">Call Type :</span>
                                <asp:DropDownList ID="ddlkkk" runat="server" class="form-control m-t select2" Style="margin-top: 3px;">
                                    <asp:ListItem Selected="True" Value="White"> Select call type </asp:ListItem>
                                    <asp:ListItem Value="White"> Incoming Call </asp:ListItem>
                                    <asp:ListItem Value="White"> Outgoing Call </asp:ListItem>
                                    <asp:ListItem Value="White"> Rejects Call </asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-sm-4">
                            <div class="form-group">
                                <span class="form-label font-bold">Select State :</span>
                                <asp:UpdatePanel ID="UpdatePanel29" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlorgname" runat="server" CssClass="form-control m-t select2"  style="margin-top: 3px;">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="col-sm-4">
                            <div class="form-group">
                                <span class="form-label font-bold">Select District :</span>
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlSectionName" runat="server" CssClass="form-control m-t select2" style="margin-top: 3px;">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="col-sm-4">
                            <div class="form-group">
                                <span class="form-label font-bold">Select Block :</span>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control m-t select2" style="margin-top: 3px;">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="col-sm-4">
                            <div class="form-group">
                                <span class="form-label font-bold">Select Gram Panchayet :</span>
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control m-t select2" style="margin-top: 3px;">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="col-sm-4">
                            <div class="form-group">
                              <label>Refer to : </label>
                               <asp:TextBox ID="txtProductName" type="text" class="form-control" placeholder="Enter Product Name" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="form-group">
                              <label>Enquiry : </label>
                                <textarea ID="TextBox1" type="text" class="form-control" placeholder="Enquiry" runat="server"  cols="20" rows="3"></textarea>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="form-group">
                              <label>Solution : </label>
                                <textarea ID="Textarea1" type="text" class="form-control" placeholder="Solution" runat="server"  cols="20" rows="3"></textarea>
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
                        <asp:Button ID="Storepagebutton" class="btn btn-success" runat="server" style="text-align: center;" Text="Submit Data" />
                    </div>
                    <div class="col-sm-4 text-right text-center-xs">                
                    </div>
                  </div>
                </footer>
              </section>
</asp:Content>

