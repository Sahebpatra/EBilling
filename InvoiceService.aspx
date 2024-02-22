<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InvoiceService.aspx.cs" Inherits="InvoiceService" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<style>
    body {
        background-image: url("/images/CentrePhoto.jpg");
        /* background-color: #cccccc; */
        background-size: 702px 440px;
        background-repeat: no-repeat;
    }
    .invoiceno{
        font-size: 12px;
        position: fixed;
        top: 32px;
        left: 55px;
    }
    .invoicedate{
        font-size: 12px;
        position: fixed;
        top: 32px;
        left: 586px;
    }
    .name{
        position: fixed;
        top: 168px;
        left: 145px;
    }
    .address{
        position: fixed;
        top: 185px;
        left: 86px;
    }
    .nearby{
        position: fixed;
        top: 202px;
        left: 37px;
    }
    .attendent{
        position: fixed;
        top: 219px;
        left: 147px;
    }
    .requirementtype{
        position: fixed;
        top: 235px;
        left: 144px;
    }
    .bookingtime{
        position: fixed;
        top: 253px;
        left: 186px;
    }
    .doctorname{
        position: fixed;
        top: 270px;
        left: 130px;
    }
    .servicecharges{
        position: fixed;
        top: 286px;
        left: 264px;
    }
    .perdaynightcharges {
        position: fixed;
        top: 290px;
        left: 358px;
    }
    .period{
        position: fixed;
        top: 304px;
        left: 128px;
    }
    .dayfrom{
        position: fixed;
        top: 321px;
        left: 114px;
    }
    .dayto {
        position: fixed;
        top: 321px;
        left: 249px;
    }
    .totalday {
        position: fixed;
        top: 321px;
        left: 388px;
    }
    .nightfrom{
        position: fixed;
        top: 338px;
        left: 115px;
    }
    .nightto {
        position: fixed;
        top: 338px;
        left: 250px;
    }
    .totalnigh {
        position: fixed;
        top: 338px;
        left: 388px;
    }
    .inword{
        position: fixed;
        top: 355px;
        left: 85px;
    }
    .rstotal{
         font-size: 14px;
         position: fixed;
         top: 310px;
         left: 515px;
    }
    .extra{
        position: fixed;
        top: 330px;
        left: 505px;
    }
    .total{
        position: fixed;
        top: 359px;
        left: 519px;
        font-size: 9px;
    }
</style>
</head>
<body>
  <asp:Label class="invoiceno" ID="lblinvoicenumber" runat="server"></asp:Label>
  <asp:Label class="invoicedate" ID="lblinvoicedate" runat="server"></asp:Label>
  <asp:Label class="name" ID="lblname" runat="server"></asp:Label>
  <asp:Label class="address" ID="lbladdress" runat="server"></asp:Label>
  <asp:Label class="nearby" ID="lblnearby" runat="server"></asp:Label>
  <asp:Label class="attendent" ID="lblattendent" runat="server"></asp:Label>
  <asp:Label class="requirementtype" ID="lblrequirementtype" runat="server"></asp:Label>
  <asp:Label class="bookingtime" ID="lblbookingtime" runat="server"></asp:Label>
  <asp:Label class="doctorname" ID="lbldoctorname" runat="server"></asp:Label>
  <asp:Label class="servicecharges" ID="lblservicecharges" runat="server"></asp:Label>
  <asp:Label class="perdaynightcharges" ID="lblperdaynightcharges" runat="server"></asp:Label>
  <asp:Label class="period" ID="lblperiod" runat="server"></asp:Label>
  <asp:Label class="dayfrom" ID="lbldayfrom" runat="server"></asp:Label>
  <asp:Label class="dayto" ID="lbldayto" runat="server"></asp:Label>
  <asp:Label class="totalday" ID="lbltotalday" runat="server"></asp:Label>
  <asp:Label class="nightfrom" ID="lblnightfrom" runat="server"></asp:Label>
  <asp:Label class="nightto" ID="lblnightto" runat="server"></asp:Label>
  <asp:Label class="totalnigh" ID="lbltotalnigh" runat="server"></asp:Label>
  <asp:Label class="inword" ID="lblinword" runat="server"></asp:Label>
  <asp:Label class="rstotal" ID="lblrstotal" runat="server"></asp:Label>
  <asp:Label class="extra" ID="lblextra" runat="server"></asp:Label>
  <asp:Label class="total" ID="lbltotal" runat="server"></asp:Label>

</body>
</html>

