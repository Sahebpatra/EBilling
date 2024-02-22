<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ExceptionPage.aspx.cs" Inherits="ExceptionPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section id="content">
    <div class="row m-n">
      <div class="col-sm-4 col-sm-offset-4">
        <div class="text-center m-b-lg"><br/>
          <h1 class="h text-white animated fadeInDownBig">404</h1>
        </div>
        <div class="list-group m-b-sm bg-white m-b-lg">
          <a href="DashBoard.aspx" class="list-group-item">
            <i class="fa fa-chevron-right icon-muted"></i>
            <i class="fa fa-fw fa-home icon-muted"></i> Goto homepage
          </a>
        </div>
      </div>
    </div>
  </section>
</asp:Content>

