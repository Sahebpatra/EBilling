
function ValidateDesignationEntry(txtDesignation, lblValidationMessage) {
    firstErrorControl = "";
    errMsg = "";
    document.getElementById("ctl00_ContentPlaceHolder1_divAlertValidation").style.display = "none";

    ValidateRequired(txtDesignation, "Please provide Designation Name");

    if (firstErrorControl != "") {
        SetControlFocus(firstErrorControl);
        errMsg = "<table>" + errMsg + "</table>";
        document.getElementById(lblValidationMessage).innerHTML = errMsg;
        document.getElementById(lblValidationMessage).style.borderColor = "Red";
        document.getElementById(lblValidationMessage).style.color = "red";
        document.getElementById("ctl00_ContentPlaceHolder1_divAlertValidation").style.display = "block";
        return false;
    }
    else {
        document.getElementById(lblValidationMessage).innerHTML = "";
        if (confirm('Are you sure to submit?')) {
            document.getElementById(btnSubmit).disabled = true;
            document.getElementById("ctl00_ContentPlaceHolder1_divAlertValidation").style.display = "none";
            //_doPostBack(document.getElementById(btnSubmit).name, '');
        }
        else {
            return false;
        }
    }
}
