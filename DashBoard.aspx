<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DashBoard.aspx.cs" Inherits="DashBoard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section id="content">
       <%-- <section class="vbox">
            <section class="scrollable wrapper">
                <div class="row">
                    <div class="col-sm-3">
                        <section class="panel panel-info">
                            <div class="panel-body">
                                <a href="#" class="thumb pull-right m-l">
                                    <i class="fa fa-home fa-5x" aria-hidden="true" style="color: #0e9052"></i>
                                </a>
                                <div class="clear">
                                    <h5>Home</h5>
                                    <small class="block text-muted"></small>
                                    <a href="#" class="btn btn-xs btn-success m-t-xs">See More</a>
                                </div>
                            </div>
                        </section>
                    </div>
                    <div class="col-sm-3">
                        <section class="panel panel-info">
                            <div class="panel-body">
                                <a href="#" class="thumb pull-right m-l">
                                    <i class="fa fa-user fa-5x" aria-hidden="true" style="color: #0e9052"></i>
                                </a>
                                <div class="clear">
                                    <h5>Profile</h5>
                                    <small class="block text-muted"></small>
                                    <a href="#" class="btn btn-xs btn-success m-t-xs">See More</a>
                                </div>
                            </div>
                        </section>
                    </div>
                    <div class="col-sm-3">
                        <section class="panel panel-info">
                            <div class="panel-body">
                                <a href="#" class="thumb pull-right m-l">
                                    <i class="fa fa-crosshairs fa-5x" aria-hidden="true" style="color: #0e9052"></i>
                                </a>
                                <div class="clear">
                                    <h5>My Account</h5>
                                    <small class="block text-muted"></small>
                                    <a href="#" class="btn btn-xs btn-success m-t-xs">See More</a>
                                </div>
                            </div>
                        </section>
                    </div>
                    <div class="col-sm-3">
                        <section class="panel panel-info">
                            <div class="panel-body">
                                <a href="#" class="thumb pull-right m-l">
                                    <i class="fa fa-usd fa-5x" aria-hidden="true" style="color: #0e9052"></i>
                                </a>
                                <div class="clear">
                                    <h5>My Balance</h5>
                                    <h4>00</h4>
                                </div>
                            </div>
                        </section>
                    </div>
                </div>
            </section>
        </section>--%><br/><br/>
            <section id="">
                <div class="row m-n">
                    <div class="col-sm-4 col-sm-offset-4">
                        <div class="text-center m-b-lg">
                            <h6 class="h text-white animated fadeInDownBig" style="font-size: 30px;">Welcome to Login Portal</h6>
                        </div>
                        <div class="list-group m-b-sm bg-white m-b-lg">
                            <a href="#" class="list-group-item">
                                <i class="fa fa-chevron-right icon-muted"></i>
                                <i class="fa fa-fw fa-home icon-muted"></i>Goto homepage
                            </a>
                            <a href="#" class="list-group-item">
                                <i class="fa fa-chevron-right icon-muted"></i>
                                <i class="fa fa-fw fa-question icon-muted"></i>Send us a tip
                            </a>
                            <a href="#" class="list-group-item">
                                <i class="fa fa-chevron-right icon-muted"></i>
                                <span class="badge">Our Support Team</span>
                                <i class="fa fa-fw fa-phone icon-muted"></i>Call us
                           </a>
                        </div>
                    </div>
                </div>
            </section>
        <a href="#" class="hide nav-off-screen-block" data-toggle="class:nav-off-screen" data-target="#nav"></a>
    </section>
</asp:Content>

