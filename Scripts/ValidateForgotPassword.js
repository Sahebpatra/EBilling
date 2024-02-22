var firstErrorControl;
var errMsg;
function ValidateDetails(txtMobileNo, lblValidationMessage, btnSubmit) {
    firstErrorControl = "";
    errMsg = "";
    document.getElementById("divAlert").style.display = "none";

    if (ValidateRequired(txtMobileNo, "Please provide registered mobile no.")) {
        ValidateMobile(txtMobileNo,"Please provide valid mobile no.")
    }

    if (firstErrorControl != "") {
        SetControlFocus(firstErrorControl);
        errMsg = "<table>" + errMsg + "</table>";
        document.getElementById(lblValidationMessage).innerHTML = errMsg;
        document.getElementById(lblValidationMessage).style.borderColor = "Red";
        document.getElementById(lblValidationMessage).style.color = "red";
        document.getElementById("divAlert").style.display = "block";
        return false;
    }
    else {
        document.getElementById(lblValidationMessage).innerHTML = '';
        document.getElementById(btnSubmit).disabled = true;
        __doPostBack(document.getElementById(btnSubmit).name, '');
        document.getElementById("divAlert").style.display = "none";
        return true;
    }
}

function ValidateOTP(txtOTP, lblValidationMessage, btnSubmit) {
    firstErrorControl = "";
    errMsg = "";
    document.getElementById("divAlert").style.display = "none";

    ValidateRequired(txtOTP, "Please provide OTP.")

    if (firstErrorControl != "") {
        SetControlFocus(firstErrorControl);
        errMsg = "<table>" + errMsg + "</table>";
        document.getElementById(lblValidationMessage).innerHTML = errMsg;
        document.getElementById(lblValidationMessage).style.borderColor = "Red";
        document.getElementById(lblValidationMessage).style.color = "red";
        document.getElementById("divAlert").style.display = "block";
        return false;
    }
    else {
        document.getElementById(lblValidationMessage).innerHTML = '';
        document.getElementById(btnSubmit).disabled = true;
        __doPostBack(document.getElementById(btnSubmit).name, '');
        document.getElementById("divAlert").style.display = "none";
        return true;
    }
}