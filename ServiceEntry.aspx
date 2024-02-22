<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ServiceEntry.aspx.cs" Inherits="ServiceEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <ul class="breadcrumb no-border no-radius b-b b-light pull-in">
                <li><a href="index.html"><i class="fa fa-home"></i> Home</a></li>
                <li><a href="#">Invoice Details</a></li>
              </ul>
              <div class="row">
                <div class="col-sm-12">
                  <section class="panel panel-default">
                    <header class="panel-heading font-bold">Invoice Details: </header>
                    <div class="panel-body">
                        <div class="col-sm-3">
                            <div class="form-group">
                              <label>Name of Customer : </label>
                                <asp:TextBox ID="txtCustomerName" type="text" class="form-control" placeholder="Enter Name" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                              <label>Addresss : </label>
                                <asp:TextBox ID="textAddress" type="text" class="form-control" placeholder="Enter Address" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                              <label>Nearby Addresss : </label>
                                <asp:TextBox ID="textNearbyAddress" type="text" class="form-control" placeholder="Enter Nearby Address" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                              <label>Name of Attendent : </label>
                                <asp:TextBox ID="txtAttendentName" type="text" class="form-control" placeholder="Enter Attendent Name" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                              <label>Requirement Type : </label>
                                <asp:TextBox ID="txtRequirementType" type="text" class="form-control" placeholder="Enter Requirement Type" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                              <label>Booking Duration Time : </label>
                                <asp:TextBox ID="txtBookingDurationTime" type="text" class="form-control" placeholder="Enter Booking Duration Time" runat="server"></asp:TextBox>
                            </div>
                        </div>
                         <div class="col-sm-3">
                            <div class="form-group">
                              <label>Doctor's Name : </label>
                                <asp:TextBox ID="txtDoctorName" type="text" class="form-control" placeholder="Enter Doctor's Name" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                              <label>P Service Rendered Rs : </label>
                                <asp:TextBox ID="txtPsrr" type="text" class="form-control" placeholder="Enter Service Rs" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-2">
		                  <div class="form-group"> <span class="form-label font-bold">Charges :</span>
			                <select name="pdnc" id="txtpdnc" class="form-control m-t select2" style="margin-top: 6px;">
				                <option value="0">All</option>
				                <option value="1">Per Day</option>
				                <option value="2">Per Night</option>
			                </select>
		                 </div>
	                   </div>
                        <div class="col-sm-2">
                            <div class="form-group">
                              <label>For the Period : </label>
                                <asp:TextBox ID="TextBox2" type="text" class="form-control" placeholder="Enter Service Rs" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-2">
		                    <div class="form-group"> <span class="form-label font-bold">Day From :</span>
			                    <input name="txtDayFrom" type="date" id="DayFrom" class="form-control" placeholder="To Date (DD/MM/YYYY)" style="margin-top: 6px;">
		                    </div>
	                    </div>
                        <div class="col-md-2">
		                    <div class="form-group"> <span class="form-label font-bold">To Date :</span>
			                    <input name="txtDayTo" type="date" id="DayTo" class="form-control" placeholder="To Date (DD/MM/YYYY)" style="margin-top: 6px;">
		                    </div>
	                    </div>
                         <div class="col-sm-2">
                            <div class="form-group">
                              <label>Total Day : </label>
                                <asp:TextBox ID="TxtTotalDay" type="text" class="form-control" placeholder="Enter Total Day" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-2">
		                    <div class="form-group"> <span class="form-label font-bold">Night From :</span>
			                    <input name="txtNightFrom" type="date" id="NightFrom" class="form-control" placeholder="To Date (DD/MM/YYYY)" style="margin-top: 6px;">
		                    </div>
	                    </div>
                        <div class="col-md-2">
		                    <div class="form-group"> <span class="form-label font-bold">Night To :</span>
			                    <input name="txtNightTo" type="date" id="NightTo" class="form-control" placeholder="To Date (DD/MM/YYYY)" style="margin-top: 6px;">
		                    </div>
	                    </div>
                        <div class="col-sm-2">
                            <div class="form-group">
                              <label>Total Night : </label>
                                <asp:TextBox ID="TextTotalNight" type="text" class="form-control" placeholder="Enter Total Night" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                              <label>Extra Wages : </label>
                                <asp:TextBox ID="txtExtraWages" type="text" class="form-control" placeholder="Enter Extra Wages" runat="server"></asp:TextBox>
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

