var firstErrorControl;
var errMsg;
function ValidateDetails(txtEmailId, txtPassword, lblValidationMessage, btnSubmit) {
    firstErrorControl = "";
    errMsg = "";
    document.getElementById("divAlert").style.display = "none";

    ValidateRequired(txtEmailId, "Please provide user id!");
    ValidateRequired(txtPassword, "Please provide password!");

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