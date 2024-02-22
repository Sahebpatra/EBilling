<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ExpanceDetails.aspx.cs" Inherits="ExpanceDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ul class="breadcrumb no-border no-radius b-b b-light pull-in">
        <li><a href="#"><i class="fa fa-home"></i>Home</a></li>
        <li><a href="#">Expance Details</a></li>
    </ul>

    <div class="row">
        <div class="col-sm-12">
            <div class="panel panel-default">
                <header class="panel-heading font-bold">Expance Entry: </header>
                <div class="panel-body">

                    <div class="col-sm-2">
                        <div class="form-group">
                            <span class="form-label font-bold">Lead Type :</span>
                            <asp:DropDownList ID="DdlCallType" runat="server" class="form-control m-t select2" Style="margin-top: 3px;">
                                <asp:ListItem Selected="True" Value="none"> Select </asp:ListItem>
                                <asp:ListItem Value="Websie Design"> Websie Design </asp:ListItem>
                                <asp:ListItem Value="Website & Normal SEO"> Website + Normal SEO </asp:ListItem>
                                <asp:ListItem Value="Monthly SEO"> Monthly SEO </asp:ListItem>
                                <asp:ListItem Value="One Time SEO"> One Time SEO </asp:ListItem>
                                <asp:ListItem Value="Application"> Application </asp:ListItem>
                                <asp:ListItem Value="Application Maintaince"> Application Maintaince</asp:ListItem>
                                <asp:ListItem Value="Digital Marketing One Time"> Digital Marketing One Time </asp:ListItem>
                                <asp:ListItem Value="Digital Marketing Maintaince"> Digital Marketing Maintaince </asp:ListItem>
                                <asp:ListItem Value="Ad Campain"> Ad Campain </asp:ListItem>
                                <asp:ListItem Value="Hosting Service Yearly"> Hosting Service Yearly</asp:ListItem>
                                <asp:ListItem Value="Hosting Suspent Charges"> Hosting Suspent Charges </asp:ListItem>
                                <asp:ListItem Value="SMS Charges"> SMS Charges </asp:ListItem>
                                <asp:ListItem Value="CRM Application"> CRM Application </asp:ListItem>
                                <asp:ListItem Value="Extra Charges"> Extra Charges </asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-2">
                        <div class="form-group">
                            <span class="form-label font-bold">Lead Sorce :</span>
                            <asp:DropDownList ID="DropDownList1" runat="server" class="form-control m-t select2" Style="margin-top: 3px;">
                                <asp:ListItem Selected="True" Value="none"> Select </asp:ListItem>
                                <asp:ListItem Value="Facebook"> Facebook </asp:ListItem>
                                <asp:ListItem Value="WhatApps"> WhatApps </asp:ListItem>
                                <asp:ListItem Value="Mail"> Mail </asp:ListItem>
                                <asp:ListItem Value="Google Search"> Google Search </asp:ListItem>
                                <asp:ListItem Value="Referance"> Referance </asp:ListItem>
                                <asp:ListItem Value="Customer"> Customer </asp:ListItem>
                                <asp:ListItem Value="Friends Gole"> Friends Gole </asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-2">
                        <div class="form-group">
                            <span class="form-label font-bold">Location :</span>
                            <asp:DropDownList ID="DropDownList2" runat="server" class="form-control m-t select2" Style="margin-top: 3px;">
                                <asp:ListItem Selected="True" Value="none"> Select </asp:ListItem>
                                <asp:ListItem Value="India"> India </asp:ListItem>
                                <asp:ListItem Value="Bangladesh"> Bangladesh </asp:ListItem>
                                <asp:ListItem Value="Usa"> Usa </asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <div class="form-group">
                            <label>Full Address : </label>
                            <asp:TextBox ID="txtFullAddress" type="text" class="form-control" placeholder="Enter Full Address" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <div class="form-group">
                            <label>Payment Py By Name : </label>
                            <asp:TextBox ID="txtProductPrice" type="text" class="form-control" placeholder="Enter Product Price" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <div class="form-group">
                            <label>Customer Name : </label>
                            <asp:TextBox ID="TextBox1" type="text" class="form-control" placeholder="Enter Product Price" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <div class="form-group">
                            <label>Payment Amount : </label>
                            <asp:TextBox ID="txtBuyNowLink" type="link" class="form-control" placeholder="Enter Buy Now Link" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-2">
                        <div class="form-group">
                            <span class="form-label font-bold">Payment Payment :</span>
                            <asp:DropDownList ID="DropDownList3" runat="server" class="form-control m-t select2" Style="margin-top: 3px;">
                                <asp:ListItem Selected="True" Value="none"> Select </asp:ListItem>
                                <asp:ListItem Value="Paypal"> Paypal </asp:ListItem>
                                <asp:ListItem Value="PhPay"> PhPay </asp:ListItem>
                                <asp:ListItem Value="GooglePAy"> GooglePAy </asp:ListItem>
                                <asp:ListItem Value="Paytm"> Paytm </asp:ListItem>
                                <asp:ListItem Value="Razorpay"> Razorpay </asp:ListItem>
                                <asp:ListItem Value="WazerX"> WazerX </asp:ListItem>
                                <asp:ListItem Value="Bank to Bank"> Bank to Bank </asp:ListItem>
                                <asp:ListItem Value="Others Pay"> Others Pay </asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <div class="form-group">
                            <label>Service Expair Date: </label>
                            <asp:TextBox runat="server" ID="DtToDate" TextMode="date" class="form-control" placeholder="To Date (DD/MM/YYYY)"></asp:TextBox>
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
                    <%--<asp:Button ID="ExpanceButton" class="btn btn-success" runat="server" Style="text-align: center;" Text="Submit Data" onclick="store_page_button" />--%>
                </div>
                <div class="col-sm-4 text-right text-center-xs">
                </div>
            </div>
        </footer>
    </section>
</asp:Content>

