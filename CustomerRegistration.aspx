<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CustomerRegistration.aspx.cs" Inherits="CustomerRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
            <ul class="breadcrumb no-border no-radius b-b b-light pull-in">
                <li><a href="index.html"><i class="fa fa-home"></i> Home</a></li>
                <li><a href="#">Customer Registratiton</a></li>
              </ul>
              <div class="row">
                <div class="col-sm-12">
                  <section class="panel panel-default">
                    <header class="panel-heading font-bold">Customer Details: </header>
                    <div class="panel-body">
                        <div class="col-sm-3">
                            <div class="form-group">
                              <label>Customer ID : </label>
                               <asp:TextBox ID="CustomerId" type="text" class="form-control" placeholder="Customer ID" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                              <label>Customer Name : </label>
                               <asp:TextBox ID="Customername" type="text" class="form-control" placeholder="Enter Customer Name" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                              <label>Mobile No: </label>
                                <asp:TextBox ID="mobbileno" type="number" class="form-control" placeholder="Enter Mobbile No" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                              <label>E-mail Id: </label>
                                <asp:TextBox ID="email" type="email" class="form-control" placeholder="Enter Email Id" runat="server"></asp:TextBox>
                            </div>
                        </div> 
                        <div class="col-sm-3">
                            <div class="form-group">
                              <label>Website: </label>
                                <asp:TextBox ID="website" type="url" class="form-control" placeholder="Enter Website" runat="server"></asp:TextBox>
                            </div>
                        </div> 
                        <div class="col-sm-3">
                            <div class="form-group">
                              <label>Gst Id: </label>
                                <asp:TextBox ID="gstid" type="" class="form-control" placeholder="Enter Gst Id" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                              <label>Date Of Birth: </label>
                                <asp:TextBox ID="DateOfBirth" type="" class="form-control" placeholder="Enter Date Of Birth" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                              <label>Gender : </label>
                                <asp:TextBox ID="Gender" type="" class="form-control" placeholder="Sclect Gender" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                  </section>
                </div>
                <div class="col-sm-12">
                  <section class="panel panel-default">
                    <header class="panel-heading font-bold">Customer Address Details: </header>
                    <div class="panel-body">
                        <div class="col-sm-3">
                            <div class="form-group">
                              <label>Select Your Country : </label>
                                <asp:TextBox ID="SclectCountry" type="text" class="form-control" placeholder="Select Your Country" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                              <label>Select Your State : </label>
                                <asp:TextBox ID="SclectSate" type="text" class="form-control" placeholder="Select Your State" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                              <label>City Name: </label>
                                <asp:TextBox ID="CityName" type="number" class="form-control" placeholder="Enter City Name" runat="server" Style="margin-top: 3px;"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                              <label>Pin Code: </label>
                                <asp:TextBox ID="PinCode" type="mail" class="form-control" placeholder="Enter Pin Code" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <textarea id="Address" cols="20" rows="2" placeholder="Enter Your Address" style="width: 280px;"></textarea>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <textarea id="AlternativeAddress" cols="20" rows="2" placeholder="Enter your Alternative Address" style="width: 280px;"></textarea>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <textarea id="Nearby" cols="20" rows="2" placeholder="Enter Nearby Address" style="width: 280px;"></textarea>
                            </div>
                        </div>
                    </div>
                  </section>
                </div>
              </div>
              <section class="panel panel-default">
                  <footer class="panel-footer">
                  <div class="row">
                    <div class="col-sm-4 hidden-xs">
                    </div>
                    <div class="col-sm-4 text-center">
                        <a href="#modal-form"  type="number" class="btn btn-success" data-toggle="modal"  style="text-align: center;">Submit Data</a>
                    </div>
                    <div class="col-sm-4 text-right text-center-xs">                
                    </div>
                  </div>
                </footer>
              </section>
</asp:Content>

