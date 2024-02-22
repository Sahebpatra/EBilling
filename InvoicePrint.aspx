<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InvoicePrint.aspx.cs" Inherits="InvoicePrint" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="update/record.png" rel="icon" />
    <title>Invoice</title>
    <meta name="author" content="harnishdesign.net" />
    <link rel="stylesheet" type="text/css" href="update/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="update/all.min.css" />
    <link rel="stylesheet" type="text/css" href="update/stylesheet.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
</head>
<style>
    div.parent {
        position: relative;
        height: 200px;
        border: 3px solid red;
    }

    div.absolute {
        position: absolute;
        width: 10%;
        bottom: 10px;
    }
</style>
<body data-new-gr-c-s-check-loaded="14.1040.0" data-gr-ext-installed="">
    <form id="invoiceForm" runat="server">
        <div class="container-fluid invoice-container">
            <main>
                <div class="table-responsive">
                    <table class="table table-bordered text-1 table-sm">
                        <thead>
                            <tr>
                                <th>
                                    <asp:Image ID="imgLogo" runat="server" width="70px" Height="50px"/>
                                </th>
                                <th>
                                    <asp:Label ID="lblInvoiceNo" runat="server"></asp:Label></th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>
                                    <div>
                                        <asp:Label ID="lblCompanyName" runat="server"></asp:Label>
                                        <br />
                                        <asp:Label ID="lblCompanyAddress" runat="server"></asp:Label>
                                        <br />
                                        <asp:Label ID="lblComapyPhoneNo" runat="server"></asp:Label>
                                        <br />
                                        <asp:Label ID="lblCompanyEmailId" runat="server"></asp:Label>
                                        <br />
                                        <asp:Label ID="lblCompanyEwbsite" runat="server"></asp:Label>
                                    </div>
                                </td>
                                <td>
                                    <div>
                                        <b>Billing To:</b>
                                        <br />
                                        <asp:Label ID="CustomarName" runat="server"></asp:Label>
                                        <br />
                                        <asp:Label ID="CustomarAddress" runat="server"></asp:Label>
                                        <br />
                                        <asp:Label ID="CustomarPHNo" runat="server" Text=""></asp:Label>
                                        <br />
                                        <asp:Label ID="CustomarEmail" runat="server" Text="E-mail : info@swapnilit.com"></asp:Label>
                                    </div>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div class="table-responsive">
                    <%--<table class="table table-bordered text-1 table-sm table-striped">
                    <thead>
                        <tr>
                            <td colspan="5" class=""><span class="fw-600">Invoice Status</span>:<asp:Label ID="Label11" runat="server" Text="PAID"></asp:Label>
                                Paid 
                    <span class="float-end"><span class="fw-600">Invoice Date </span>:<asp:Label ID="lblInvoiceDate" runat="server" Text="05 Aug, 2020 at 06:50 PM"></asp:Label>
                    </span></td>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td class="fw-600 col-1">S. NO</td>
                            <td class="col-4">PRODUCT/SERVICE DETAILS</td>
                            <td class="fw-600 col-2">QTY</td>
                            <td class="col-2">GST</td>
                            <td class="col-2">AMOUNT</td>
                        </tr>
                        <tr>
                            <td class="fw-600">
                                <asp:Label ID="LblSerialNO" runat="server" Text="01"></asp:Label></td>
                            <td>
                                <asp:Label ID="LblServiceDetails" runat="server" Text="Ac Service"></asp:Label></td>
                            <td class="fw-600">
                                <asp:Label ID="LbltotalQuantity" runat="server" Text="20p"></asp:Label></td>
                            <td>
                                <asp:Label ID="LblGstPersentage" runat="server" Text="18 %"></asp:Label></td>
                            <td>
                                <asp:Label ID="LblServiceAmount" runat="server" Text="500"></asp:Label></td>
                        </tr>
                    </tbody>
                </table>--%>


                    <asp:GridView ID="grdInvoiceDetails" AutoGenerateColumns="false" runat="server">
                        <Columns>
                            <asp:TemplateField HeaderText="Item Name" HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblParent" runat="server" Text='<%# Bind("ItemName") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="HSN No" HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblParent" runat="server" Text='<%# Bind("HSBCNo") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Price" HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblParent" runat="server" Text='<%# Bind("Sellingprice") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="IGST%" HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblParent" runat="server" Text='<%# Bind("IGSTPer") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="CGST%" HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblParent" runat="server" Text='<%# Bind("CGSTPer") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="SGST%" HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblParent" runat="server" Text='<%# Bind("SGSTPer") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Total%" HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblParent" runat="server" Text='<%# Bind("TotalItemCost") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>


                </div>
                <div class="table-responsive">
                    <table class="table table-bordered">
                        <tbody>
                            <tr>
                                <td class="col-9 fw-500 text-end"><strong>Extara Charges:</strong></td>
                                <td class="col-3 text-end">
                                    <asp:Label ID="Label24" runat="server" Text="₹ 215"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="col-9 fw-500 text-end"><strong>Total Amount:</strong></td>
                                <td class="col-3 text-end">
                                    <asp:Label ID="Label25" runat="server" Text="₹ 1195.00"></asp:Label></td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div class="table-responsive">
                    <table class="table table-bordered text-1 table-sm">
                        <thead>
                            <tr>
                                <th>BANK DETAILS</th>
                                <th>OTHERS PAYMENT</th>
                                <th>Signature</th>
                                <tr>
                                    <tr>
                                        <th>
                                            <div>
                                                NAME :<asp:Label ID="Label18" runat="server" Text="Sapnil IT"></asp:Label>
                                                <br />
                                                IFSE CODE :<asp:Label ID="Label19" runat="server" Text="231654987"></asp:Label>
                                                <br />
                                                ACCOUNT NO :<asp:Label ID="Label20" runat="server" Text="info@swapnilit.com"></asp:Label>
                                                <br />
                                                BANNK NAME :<asp:Label ID="Label21" runat="server" Text="Kotak"></asp:Label>
                                                <br />
                                                BRANCH NAME :<asp:Label ID="Label22" runat="server" Text="Kotak"></asp:Label>
                                            </div>
                                        </th>
                                        <th>
                                            <div>
                                                PH Pay/G-PAY/PAY TM
                                            <br />
                                                UPI ID :<asp:Label ID="Label23" runat="server" Text="@2222222222"></asp:Label>
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                            </div>
                                        </th>
                                        <th>
                                            <img id="logo" src="update/sign.jpg" style="height: 50px;"></th>
                                    </tr>
                        </thead>
                    </table>
                </div>
                <footer class="text-center">
                    <p class="text-1"><strong>NOTE :</strong> This is computer generated receipt and does not require physical signature.</p>
                    <div class="btn-group btn-group-sm d-print-none">
                        <a href="javascript:window.print()" class="btn btn-light border text-black-50 shadow-none"><i class="fa fa-print"></i>Print</a>
                        <a href="#" class="btn btn-light border text-black-50 shadow-none"><i class="fa fa-download"></i>Download</a>
                    </div>
                </footer>
            </main>
        </div>
        <p class="text-center d-print-none"><a href="#">« Back to My Account</a></p>
    </form>

</body>
</html>
