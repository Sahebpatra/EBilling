<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="InvoiceEntry.aspx.cs" Inherits="InvoiceEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Service Entry Invoice</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ul class="breadcrumb no-border no-radius b-b b-light pull-in">
        <li><a href="index.html"><i class="fa fa-home"></i>Home</a></li>
        <li><a href="#">Invoice Entry</a></li>
    </ul>
    <div class="row">
        <div class="col-sm-12">
            <section class="panel panel-default">
                <header class="panel-heading font-bold">Customer Details: </header>
                <div class="panel-body">
                    <div class="col-sm-3">
                        <div class="form-group">
                            <label>Customer Name : </label>
                            <asp:TextBox ID="txtcustomername" type="text" class="form-control" placeholder="Enter Customer Name" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <div class="form-group">
                            <label>Address: </label>
                            <asp:TextBox ID="txtcAddress" type="text" class="form-control" placeholder="Enter Customer Address" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <div class="form-group">
                            <label>Mobile No: </label>
                            <asp:TextBox ID="txtcmobbileno" type="number" class="form-control" placeholder="Enter Customer Mobbile No" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <div class="form-group">
                            <label>E-mail Id: </label>
                            <asp:TextBox ID="txtCemail" type="mail" class="form-control" placeholder="Enter Customer Email Id" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </section>
        </div>
    </div>

    <%--Invoice Item Add panel --%>

    <div>
        <section class="panel panel-default">
            <header class="panel-heading">Service and Product Entry :</header>
            <div class="table-responsive" style="overflow: scroll;">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <table class="table table-striped b-t b-light">
                            <thead>
                                <tr>
                                    <th>Item Name</th>
                                    <th>Item Description</th>
                                    <th>Item Code</th>
                                    <th>HSNBC No</th>
                                    <th>Selling Rs</th>
                                    <th>Quantity</th>
                                    <th>GST Type</th>
                                    <th>GST %</th>
                                    <th>Total</th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtItemName" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <textarea id="txtItemDescription" cols="20" rows="2" style="height: 28px;" runat="server"></textarea>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtItemCode" runat="server" Style="width: 90px;"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtHSNBCNo" runat="server" Style="width: 90px;"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox type="number" ID="txtSellingAmount" runat="server" Style="width: 90px;" onkeyup="calculateTotalAddMode()" min="0"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox type="number" ID="txtSellingQty" runat="server" Style="width: 90px;" onkeyup="calculateTotalAddMode()" min="0"></asp:TextBox>
                                    </td>
                                    <%--<asp:TextBox ID="txtGST" runat="server" Style="width: 80px;"></asp:TextBox></td>--%>
                                    <td>
                                        <asp:DropDownList ID="ddlGstType" runat="server" onchange="calculateTotalAddMode()">
                                            <asp:ListItem Enabled="true" Text="No GST" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="CGST+SGST" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="IGST" Value="2"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox type="number" ID="txtGST" runat="server" Style="width: 90px;" onkeyup="calculateTotalAddMode()" min="0"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtTotalAmount" runat="server" Style="width: 90px;" min="0"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnInvoiceGenerate" runat="server" Text="Add" class="btn btn-Primary" OnClick="btnInvoiceGenerate_Click" />
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnInvoiceGenerate" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
            <div style="overflow: scroll;">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="gvFormList" runat="server"
                            AutoGenerateColumns="False" EmptyDataText="No record(s) found."
                            AllowPaging="true" PageSize="15" CssClass="table table-bordered table-md m-0"
                            OnRowDataBound="gvFormList_RowDataBound"
                            OnSelectedIndexChanged="ddlParentForm_SelectedIndexChanged"
                            OnRowCancelingEdit="gvFormList_RowCancelingEdit"
                            OnRowUpdating="gvFormList_RowUpdating"
                            OnRowEditing="gvFormList_RowEditing"
                            OnPageIndexChanging="gvFormList_PageIndexChanging">
                            <RowStyle CssClass="tlrowlight" Font-Size="Smaller" />
                            <AlternatingRowStyle CssClass="tlrowdark" />
                            <PagerStyle CssClass="grid_pagger" Font-Size="Smaller" HorizontalAlign="right" />
                            <HeaderStyle CssClass="grid_header" Font-Size="Smaller" />
                            <FooterStyle CssClass="tlheader_1" ForeColor="#000" HorizontalAlign="Center" />
                            <Columns>

                                <asp:TemplateField HeaderText="#" HeaderStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSrl" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                        <asp:HiddenField ID="hdnId" runat="server" Value='<%# Bind("Id") %>'></asp:HiddenField>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Item Name" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblItemName" runat="server" Text='<%# Bind("ItemName") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txttemName" runat="server" Width="95%" Text='<%# Bind("ItemName") %>' CssClass="txtBox"></asp:TextBox>
                                    </EditItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="15%" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="15%" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Item Description" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblItemDescription" runat="server" Text='<%# Bind("ItemDescription") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtItemDescription" runat="server" Width="95%" Text='<%# Bind("ItemDescription") %>' CssClass="txtBox"></asp:TextBox>
                                    </EditItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="17%" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="17%" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Item Code" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblItemCode" runat="server" Text='<%# Bind("ItemCode") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtItemCode" runat="server" Width="95%" Text='<%# Bind("ItemCode") %>' CssClass="txtBox"></asp:TextBox>
                                    </EditItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="8%" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="8%" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="HSNBC No" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblHSNBCNo" runat="server" Type="Integer" Text='<%# Bind("HSNBCNo") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtHSNBCNo" runat="server" Width="95%" Type="Integer" Text='<%# Bind("HSNBCNo") %>' CssClass="txtBox"></asp:TextBox>
                                    </EditItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Selling Rs" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSellingAmount" runat="server" Text='<%# Bind("SellingAmount") %>'> </asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox type="number"  ID="txtSellingAmount" runat="server" Width="95%" Text='<%# Bind("SellingAmount") %>' CssClass="txtBox" onkeyup="calculateTotalEditMode()" min="0"></asp:TextBox>
                                    </EditItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="7%" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="7%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Quantity" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSellingQty" runat="server" Text='<%# Bind("Quantity") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox type="number" ID="txtSellingQty" runat="server" Width="95%" Text='<%# Bind("Quantity") %>' CssClass="txtBox" onkeyup="calculateTotalEditMode()" min="0"></asp:TextBox>
                                    </EditItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="CGST" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCGST" runat="server" Text='<%# Bind("CGST") %>'></asp:Label>

                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox type="number" ID="txtCGST" runat="server" Width="95%" Text='<%# Bind("CGST") %>' CssClass="txtBox" onkeyup="calculateTotalEditMode()" min="0"></asp:TextBox>
                                    </EditItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="SGST" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSGST" runat="server" Text='<%# Bind("SGST") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox type="number" ID="txtSGST" runat="server" Width="95%" Text='<%# Bind("SGST") %>' CssClass="txtBox" onkeyup="calculateTotalEditMode()" min="0"></asp:TextBox>
                                    </EditItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="IGST" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIGST" runat="server" Text='<%# Bind("IGST") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox type="number" ID="txtIGST" runat="server" Width="95%" Text='<%# Bind("IGST") %>' CssClass="txtBox" onkeyup="calculateTotalEditMode()" min="0"></asp:TextBox>
                                    </EditItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Total" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label type="number" ID="lblTotalSellingAmount" runat="server" Text='<%# Bind("TotalSellingAmount") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtTotalSellingAmount" runat="server" Width="95%" Text='<%# Bind("TotalSellingAmount") %>' CssClass="txtBox" min="0"></asp:TextBox>
                                    </EditItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="15%" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="15%" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Edit" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Button ID="btnEdit" CommandName="Edit" Width="100%" CssClass="btn btn-sm btn-primary" runat="server"
                                            Text="Edit" />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:Button ID="btnUpdate" CommandName="Update" Width="100%" CssClass="btn btn-sm btn-success" runat="server"
                                            Text="Update" />
                                        <asp:Button ID="btnCancel" CommandName="Cancel" Width="100%" CssClass="btn btn-sm btn-danger" runat="server" CausesValidation="false"
                                            Text="Cancel" />
                                    </EditItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="30%" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="30%" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <footer class="panel-footer">
                <div class="row">
                    <div class="col-sm-4 hidden-xs">
                    </div>
                    <div class="col-sm-4 text-center">
                        <asp:TextBox ID="textExtraCharges" runat="server" Style="width: 100px; height: 32px;" placeholder="Extra Charges" ></asp:TextBox>
                        <asp:Button ID="btnSaveBillingDetails" runat="server" Text="Save Data" class="btn btn-success" data-toggle="modal" Style="text-align: center;" OnClick="btnSaveBillingDetails_Click" />
                    </div>
                    <div class="col-sm-4 text-right text-center-xs">
                    </div>
                </div>



                <div class="row">
                    <div class="col-sm-12 text-center">
                        <div style="overflow: scroll;">
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="gdInvoiceList" runat="server"
                                        AutoGenerateColumns="False" EmptyDataText="No record(s) found."
                                        AllowPaging="true" PageSize="15" CssClass="table table-bordered table-md m-0">
                                        <RowStyle CssClass="tlrowlight" Font-Size="Smaller" />
                                        <AlternatingRowStyle CssClass="tlrowdark" />
                                        <PagerStyle CssClass="grid_pagger" Font-Size="Smaller" HorizontalAlign="right" />
                                        <HeaderStyle CssClass="grid_header" Font-Size="Smaller" />
                                        <FooterStyle CssClass="tlheader_1" ForeColor="#000" HorizontalAlign="Center" />
                                        <Columns>

                                            <asp:TemplateField HeaderText="#" HeaderStyle-HorizontalAlign="center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSrl" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                                    <asp:HiddenField ID="hdnId" runat="server" Value='<%# Bind("InvoiceID") %>'></asp:HiddenField>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Customer Name" HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="20%" />
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="20%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Ph No." HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPhNo" runat="server" Text='<%# Bind("PhNo") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="20%" />
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="20%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="CGST" HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCGST" runat="server" Text='<%# Bind("CGSTPer") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" />
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="SGST" HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSGST" runat="server" Type="Integer" Text='<%# Bind("SGSTPer") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="20%" />
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="20%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Others Charges" HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblOthersCost" runat="server" Text='<%# Bind("OthersCost") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" />
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Total Amount" HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblInvoiceAmount" runat="server" Text='<%# Bind("InvoiceAmount") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" />
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Print Invoice" HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="lnlName" runat="server" Target="_blank" Text="Print" NavigateUrl='<%# Eval("InvoiceID", "~/InvoicePrint.aspx?id={0}") %>'></asp:HyperLink>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" />
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>

                    </div>
                </div>


            </footer>
        </section>
    </div>
    <!-- Modal -->

    <div class="modal fade" id="myModal" runat="server" tabindex="-1" role="dialog" aria-labelledby="ModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="card card-signup card-plain">
                    <div class="modal-header">
                        <div class="card-header card-header-primary  text-center" style="width: 100%;">
                            <h5 class="modal-title" id="ModalLabel">Message: Invoice Master</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                    </div>
                    <div class="modal-body">
                        <asp:Label ID="lblPopMessage" runat="server"></asp:Label>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-danger" data-dismiss="modal">
                            <span aria-hidden="true">&times;</span>Close</button>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>

    <script>
        function calculateTotalAddMode() {
            var SelllingAmnt = $("#ctl00_ContentPlaceHolder1_txtSellingAmount").val();
            var Qty = $("#ctl00_ContentPlaceHolder1_txtSellingQty").val();
            var GSTType = $("#ctl00_ContentPlaceHolder1_ddlGstType").val();
            var GSTPercetage = $("#ctl00_ContentPlaceHolder1_txtGST").val();
            var Total = SelllingAmnt * Qty;
            Total = GSTType != 0 ? (Total + (Total * GSTPercetage / 100)) : Total;
            console.log(Total)
            $("#ctl00_ContentPlaceHolder1_txtTotalAmount").val(Total);
        }
        function calculateTotalEditMode() {
            var SelllingAmnt = $("#ctl00_ContentPlaceHolder1_gvFormList_ctl02_txtSellingAmount").val();
            var Qty = $("#ctl00_ContentPlaceHolder1_gvFormList_ctl02_txtSellingQty").val();
            console.log(Qty)
            var GSTPercetage = parseInt($("#ctl00_ContentPlaceHolder1_gvFormList_ctl02_txtCGST").val()) + parseInt($("#ctl00_ContentPlaceHolder1_gvFormList_ctl02_txtSGST").val()) + parseInt($("#ctl00_ContentPlaceHolder1_gvFormList_ctl02_txtIGST").val());
            var Total = SelllingAmnt * Qty;
            console.log(Total)
            Total = GSTPercetage != 0 ? (Total + (Total * (GSTPercetage / 100))) : Total;
            console.log(GSTPercetage)
            console.log(Total * (GSTPercetage / 100))
            console.log(Total)
            $("#ctl00_ContentPlaceHolder1_gvFormList_ctl02_txtTotalSellingAmount").val(Total)
        }
    </script>
</asp:Content>


