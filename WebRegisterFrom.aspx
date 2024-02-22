<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="WebRegisterFrom.aspx.cs" Inherits="WebRegisterFrom" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ul class="breadcrumb no-border no-radius b-b b-light pull-in">
        <li><a href="#"><i class="fa fa-home"></i>Home</a></li>
        <li><a href="#">Website Register Details</a></li>
    </ul>
    <div class="row">
        <div class="col-sm-12">
            <div class="panel panel-default">
                <header class="panel-heading font-bold">Register Details: </header>
                <div class="panel-body">
                    <div class="table-responsive" style="overflow: scroll;">
                        <div class="row">
                            <div class="col-md-12">
                                <asp:UpdatePanel ID="UpdatePanetxtFrmNamel1" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="GRDWebRegisterFrom" runat="server"
                                            AutoGenerateColumns="False" EmptyDataText="No record(s) found."
                                            AllowPaging="true" PageSize="150" CssClass="table table-bordered ">
                                            <RowStyle CssClass="tlrowlight" Font-Size="x-small" />
                                            <AlternatingRowStyle CssClass="tlrowdark" />
                                            <PagerStyle CssClass="grid_pagger" Font-Size="Smaller" HorizontalAlign="right" />
                                            <HeaderStyle CssClass="grid_header" Font-Size="Smaller" />
                                            <FooterStyle CssClass="tlheader_1" ForeColor="#000" HorizontalAlign="Center" />
                                            <Columns>
                                                <asp:TemplateField HeaderText=" ID" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblParent" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Ticket ID" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblParent" runat="server" Text='<%# Bind("OrgId") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="6%" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="6%" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Name" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblParent" runat="server" Text='<%# Bind("ContactName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="15%" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="12%" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="WhatsApp No" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblParent" runat="server" Text='<%# Bind("ContactWhatsAppNo") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="15%" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="15%" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Guardian Name" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblParent" runat="server" Text='<%# Bind("GuardianName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="15%" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="15%" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Contact Email" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblParent" runat="server" Text='<%# Bind("ContactEmail") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="16%" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="16%" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Date Of Birth" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblParent" runat="server" Text='<%# Bind("DateOfBirth") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="15%" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="15%" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Marital Status" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblParent" runat="server" Text='<%# Bind("MaritalStatus") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="8%" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="8%" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Gender Name" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblParent" runat="server" Text='<%# Bind("GenderName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="7%" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="7%" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Permanent Contact Address" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblParent" runat="server" Text='<%# Bind("PContactAddress") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="City Name" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblParent" runat="server" Text='<%# Bind("PCityName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="State Name" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblParent" runat="server" Text='<%# Bind("PStateName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Country Name" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblParent" runat="server" Text='<%# Bind("PCountry") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Pincode" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblParent" runat="server" Text='<%# Bind("PPincode") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Current Address" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblParent" runat="server" Text='<%# Bind("CContactAddress") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="City Name" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblParent" runat="server" Text='<%# Bind("CCityName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="State Name" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblParent" runat="server" Text='<%# Bind("CStateName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Country Name" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblParent" runat="server" Text='<%# Bind("CCountry") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Pincode" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblParent" runat="server" Text='<%# Bind("CPincode") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Qualification" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblParent" runat="server" Text='<%# Bind("Qualification") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Education Stream" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblParent" runat="server" Text='<%# Bind("EducationStream") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Diploma" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblParent" runat="server" Text='<%# Bind("Diploma") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Language Known" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblParent" runat="server" Text='<%# Bind("LanguageKnown") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Current Designation" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblParent" runat="server" Text='<%# Bind("CurrentDesignation") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Experience Year" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblParent" runat="server" Text='<%# Bind("ExperienceYear") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Experience Month" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblParent" runat="server" Text='<%# Bind("ExperienceMonth") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Current Salary" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblParent" runat="server" Text='<%# Bind("CurrentSalary") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Expected Salary" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblParent" runat="server" Text='<%# Bind("ExpectedSalary") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Industry" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblParent" runat="server" Text='<%# Bind("Industry") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Prefer Location" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblParent" runat="server" Text='<%# Bind("PreferLocation") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                </asp:TemplateField>

                                            </columns>
                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

