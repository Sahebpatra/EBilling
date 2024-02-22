//JScript file for Validate New Inquiry
//Created by Benimadhab on 27/10/2014

function Validatesubmit() {
    firstErrorControl = "";
    errMsg = "";

    if (ValidateRequired("ctl00_ContentPlaceHolder1_ddlFinyr", "Select Fin year.")) {
        var select = document.querySelector("#" + "ctl00_ContentPlaceHolder1_ddlFinyr" + "+ .select2-container .selection .select2-selection");
        if (select != null) {
            select.style.backgroundColor = "white";
        }
    }
    else {
        firstErrorControl = "ctl00_ContentPlaceHolder1_ddlFinyr";
        var select = document.querySelector("#" + "ctl00_ContentPlaceHolder1_ddlFinyr" + "+ .select2-container .selection .select2-selection");
        if (select != null) {
            select.style.backgroundColor = "yellow";
        }
    }
//    ValidateRequired("ctl00_ContentPlaceHolder1_chkbxListApplDepots", "Please Choose depot");
    if (ValidateRequired("ctl00_ContentPlaceHolder1_txtJoinDate", "Please enter Date")) {

        if (document.getElementById("ctl00_ContentPlaceHolder1_txtJoinDate").value != "") {

            CheckDateFormat("ctl00_ContentPlaceHolder1_txtJoinDate", "Check Date Format");

        }
    }

    ValidateChkBoxList("ctl00_ContentPlaceHolder1_chkbxListApplDepots", "Please select atleast one depot code.")

    if (firstErrorControl != "") {
        SetControlFocus(firstErrorControl);
        errMsg = "<table>" + errMsg + "</table>";
        document.getElementById("ctl00_ContentPlaceHolder1_lblValidationMessage").innerHTML = errMsg;
        //        document.getElementById("ctl00_ContentPlaceHolder1_lblErrorMessage").innerHTML = "";

        return false;
    }
    else {
        document.getElementById("ctl00_ContentPlaceHolder1_lblValidationMessage").innerHTML = "";
        if (confirm('Are you sure to submit?')) {
            document.getElementById('ctl00_ContentPlaceHolder1_btnSubmit').disabled = true;
          //  __doPostBack(document.getElementById('ctl00_ContentPlaceHolder1_btnSubmit').name, '');
        }
        else {
            return false;
        }

    }
}



function ValidateRequire() {
    firstErrorControl = "";
    errMsg = "";

    if (ValidateRequired("ctl00_ContentPlaceHolder1_ddlFinyr", "Select Fin year.")) {
        var select = document.querySelector("#" + "ctl00_ContentPlaceHolder1_ddlFinyr" + "+ .select2-container .selection .select2-selection");
        if (select != null) {
            select.style.backgroundColor = "white";
        }
    }
    else {
        firstErrorControl = "ctl00_ContentPlaceHolder1_ddlFinyr";
        var select = document.querySelector("#" + "ctl00_ContentPlaceHolder1_ddlFinyr" + "+ .select2-container .selection .select2-selection");
        if (select != null) {
            select.style.backgroundColor = "yellow";
        }
    }
  

    if (firstErrorControl != "") {
        SetControlFocus(firstErrorControl);
        errMsg = "<table>" + errMsg + "</table>";
        document.getElementById("ctl00_ContentPlaceHolder1_lblValidationMessage").innerHTML = errMsg;
  
        return false;
    }
    else {
        document.getElementById("ctl00_ContentPlaceHolder1_lblValidationMessage").innerHTML = "";
            }
}


function ValidateChkBoxList(controlName, errorMessage) {

    var cnt = 0;
    var checkList = document.getElementById(controlName);
    var checkBoxList = checkList.getElementsByTagName("input");
    var checkBoxSelectedItems = new Array();
    for (var i = 0; i < checkBoxList.length; i++) {
        if (checkBoxList[i].checked) {
            cnt++;
            //            return true;
            break;
        }
    }
    //    if (cnt == 0) {
    //        document.getElementById('ctl00_ContentPlaceHolder1_lblValidationMessage').innerHTML = 'Atleast 1 Territory Should be Selected..';
    //        return false;

    //    }

    var controlID = controlName;
    if (cnt == 0) {
        //if(firstErrorControl == '') 
        firstErrorControl = controlID;
        errMsg += GetErrorRow(controlID, errorMessage);
        SetErrorColor(controlID, false);
        return false;
    }
    else {
        SetErrorColor(controlID, true);
        return true;
    }


}


function ltrim(valuetotrim) {
    var textaftertrim = "";

    for (var j = 0; j <= valuetotrim.length - 1; j++) {
        if (valuetotrim.charAt(j) != " ") {
            textaftertrim += valuetotrim.charAt(j);
        }
    }

    return textaftertrim;
}

function validategridsubmit(txtdate, txtpurpose, message, btnupdate,action) {

    firstErrorControl = "";
    errMsg = "";
    var status = ""
    document.getElementById(message).innerHTML = "";
    if( document.getElementById(btnupdate).value == "SAVE")
    {
    ValidateRequired(txtdate, "Visit Date is mandatory .");
    ValidateRequired(txtpurpose, "Visit Purpose is mandatory .");
    }

    if (document.getElementById(btnupdate).value == "Update") {

        ValidateRequired(action, "action is mandatory .");

    }


    if (firstErrorControl != "") {
        SetControlFocus(firstErrorControl);
        errMsg = "<table>" + errMsg + "</table>";
        document.getElementById(message).innerHTML = errMsg;

        return false;
    }
    else {
        document.getElementById(message).innerHTML = '';
        if (confirm('Are you sure to Submit?')) {
            document.getElementById(btnupdate).disabled = true;
            __doPostBack(document.getElementById(btnupdate).name, '');

            return true;
        }
        else {
            return false;
        }
    }



}

function rwslctToggleSelect(clkdCheckBox, message)
{

    var theGridView = document.getElementById('ctl00_ContentPlaceHolder1_gvUserProfileList');

    var flag = 0;

    var chkbxcntrl_id = null;
    var txtdatecntrl_id = null;
    var txtpurposecntrl_id = null;
    var btneditcntrl_id = null;

    if (document.getElementById(clkdCheckBox).checked == true) {

        document.getElementById(clkdCheckBox).parentNode.parentNode.parentNode.style.backgroundColor = "lightgreen";
    }
    else {
        document.getElementById(clkdCheckBox).parentNode.parentNode.parentNode.style.backgroundColor = "";
    }
    for (var rowCount = 1; rowCount < theGridView.rows.length; rowCount++) {
        if (theGridView.rows[rowCount].cells[0].children[0].children[0] != null) {

            chkbxcntrl_id = theGridView.rows[rowCount].cells[0].children[0].children[0].id;
            if (document.getElementById(chkbxcntrl_id).checked == true) 
            {
                flag = 1;

                txtdatecntrl_id = theGridView.rows[rowCount].cells[8].children[0].id;
                txtpurposecntrl_id = theGridView.rows[rowCount].cells[9].children[0].id;
                btneditcntrl_id = theGridView.rows[rowCount].cells[12].children[0].id;
                document.getElementById(txtdatecntrl_id).disabled = false;
                document.getElementById(txtpurposecntrl_id).disabled = false;
                document.getElementById(btneditcntrl_id).disabled = false;
                document.getElementById(txtdatecntrl_id).focus();

            }
            else 
            {
                flag = 0;
                txtdatecntrl_id = theGridView.rows[rowCount].cells[8].children[0].id;
                txtpurposecntrl_id = theGridView.rows[rowCount].cells[9].children[0].id;
                btneditcntrl_id = theGridView.rows[rowCount].cells[12].children[0].id;

                if (document.getElementById(btneditcntrl_id).value == "Update") 
                {
                    document.getElementById(txtdatecntrl_id).disabled = true;
                    document.getElementById(txtpurposecntrl_id).disabled = true;
                    document.getElementById(btneditcntrl_id).disabled = false;
                }
                if (document.getElementById(btneditcntrl_id).value == "SAVE")
                {
                    document.getElementById(txtdatecntrl_id).disabled = true;
                    document.getElementById(txtpurposecntrl_id).disabled = true;
                    document.getElementById(btneditcntrl_id).disabled = true;
                }
                
                      document.getElementById(message).innerHTML = '';




            }
        }

    }


}


function ValidateSearch() {
    document.getElementById("ctl00_ContentPlaceHolder1_lblValidationMsg").innerHTML = "";
    firstErrorControl = "";
    errMsg = "";
    ValidateDropDown1("ctl00_ContentPlaceHolder1_ddlDepot", "Select Depot Code");
    ValidateDropDown1("ctl00_ContentPlaceHolder1_ddlYear", "Select Year");
    ValidateDropDown1("ctl00_ContentPlaceHolder1_ddlMonth", "Select Month");

    if (firstErrorControl != "") {
        SetControlFocus(firstErrorControl);
        errMsg = "<table>" + errMsg + "</table>";
        document.getElementById("ctl00_ContentPlaceHolder1_lblValidationMsg").innerHTML = errMsg;

        return false;
    }
    else {
        document.getElementById("ctl00_ContentPlaceHolder1_lblValidationMsg").innerHTML = ''
        return true;
    }
}
