





var firstErrorControl;
var errMsg;

function ValidateDetails(txtOldPassword, txtNewPassword, txtReTypedNewPassword, lblValidationMessage, btnSubmit) {
    firstErrorControl = "";
    errMsg = "";
    debugger;
    ValidateRequired(txtOldPassword, "Please enter your old password.");
    ValidateRequired(txtNewPassword, "Please enter your new password.");
    ValidateRequired(txtReTypedNewPassword, "Please re-enter your new password.");

    if (firstErrorControl != "") {
        SetControlFocus(firstErrorControl);
        errMsg = "<table>" + errMsg + "</table>";
        document.getElementById(lblValidationMessage).innerHTML = errMsg;
        return false;
    }
    else {

        document.getElementById(lblValidationMessage).innerHTML = '';
        if (confirm('Are you sure to submit?')) {
            //document.getElementById(btnSubmit).disabled = true;
            ////document.getElementById(btnSave).click();
            //__doPostBack(document.getElementById(btnSubmit).name, '');
            //document.getElementById(btnSave).disabled = true;
            return true;
        }
        else {
            return false;
        }
    }
}