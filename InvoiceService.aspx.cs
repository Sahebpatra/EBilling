using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class InvoiceService : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //1.first click and generare methord
        invoicebindingmethord();
    }
    //2.generare methord
    private void invoicebindingmethord()
    {
        //3. binding all lavel 
        lblinvoicenumber.Text = "123";
        lblinvoicedate.Text = "07-01-2022";
        lblname.Text = "Suprovat Naskar";
        lbladdress.Text = "Sonarpur, Kolakta";
        lblnearby.Text = "Gangajoara Primary School";
        lblattendent.Text = "Attendent Name";
        lblrequirementtype.Text = "Nurse, Aya";
        lblbookingtime.Text = "24H";
        lbldoctorname.Text = "Dr. T k Dorma";
        lblservicecharges.Text = "250";
        lblperdaynightcharges.Text = "Per Day Charges";
        lblperiod.Text = "15 Days";
        lbldayfrom.Text = "07-01-2022";
        lbldayto.Text = "10-01-2022";
        lbltotalday.Text = "4";
        lblnightfrom.Text = "07-01-2022";
        lblnightto.Text = "10-01-2022";
        lbltotalnigh.Text = "3";
        lblinword.Text = "One - Thousand";
        lblrstotal.Text = "4 X 500 = 1000";
        lblextra.Text = "Extra Wages: 930";
        lbltotal.Text = "1930";

    }
}