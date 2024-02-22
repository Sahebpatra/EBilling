function ValidateChangePassSubmit(txtoldpass, txtnewpass, txtconfirmpass, lblErrorMessage, btnSubmit) {
    firstErrorControl = "";
    errMsg = "";
    document.getElementById("ctl00_ContentPlaceHolder1_divAlert").style.display = "none";

    ValidateRequired(txtoldpass, "Enter old password!");
    ValidateRequired(txtnewpass, "Enter new password!");
    ValidateRequired(txtconfirmpass, "Enter confirm password!");
    CheckMaxlength(txtnewpass, 10, "Password can not be greater than 10 digit!");
    Validatepassword(txtnewpass, "Password Must Have A Combination Of alpha + numeric + 1 Special character!  (i.e 'Sample@123')");

    if (firstErrorControl != "") {
        SetControlFocus(firstErrorControl);
        errMsg = "<table>" + errMsg + "</table>";
        document.getElementById(lblErrorMessage).innerHTML = errMsg;
        document.getElementById(lblErrorMessage).style.borderColor = "Red";
        document.getElementById(lblErrorMessage).style.color = "red";
        document.getElementById("ctl00_ContentPlaceHolder1_divAlert").style.display = "block";
        return false;
    }
    else {
        if (confirm("Are you sure to submit?")) {
            document.getElementById(lblErrorMessage).innerHTML = "";
            document.getElementById("ctl00_ContentPlaceHolder1_divAlert").style.display = "none";
            return true;
        }
        else {
            return false;
        }
    }
}

function Validatepassword(controlID, errorMessage) {

    var charValue = document.getElementById(controlID).value;
    var charRegEx = /^(?=.*\d)(?=.*[!@#$%^&*])(?=.*[A-Za-z]).{3,10}$/;
    if (!charRegEx.test(charValue)) {

        //if(firstErrorControl == '')
        firstErrorControl = controlID;
        errMsg += GetErrorRow(controlID, errorMessage);
        SetErrorColor(controlID, false);
        return false;
    }
    else {
        SetErrorColor(controlID, true);
    }
}

function ValidateForgotPassword(txtAccountPassword, lblErrorMessage, btnSubmit) {
    firstErrorControl = "";
    errMsg = "";
    document.getElementById("ctl00_ContentPlaceHolder1_divForgotPassword").style.display = "none";
    
    ValidateRequired(txtAccountPassword, "Please provide account password.");

    if (firstErrorControl != "") {
        SetControlFocus(firstErrorControl);
        errMsg = "<table>" + errMsg + "</table>";
        document.getElementById(lblErrorMessage).innerHTML = errMsg;
        document.getElementById(lblErrorMessage).style.borderColor = "Red";
        document.getElementById(lblErrorMessage).style.color = "red";
        document.getElementById("ctl00_ContentPlaceHolder1_divForgotPassword").style.display = "block";
        return false;
    }
    else {
        if (confirm("Are you sure to submit?")) {
            document.getElementById(lblErrorMessage).innerHTML = "";
            document.getElementById("ctl00_ContentPlaceHolder1_divForgotPassword").style.display = "none";
            return true;
        }
        else {
            return false;
        }
    }
}

function ValidateOTP(txtOTP, lblErrorMessage, btnSubmit) {
    firstErrorControl = "";
    errMsg = "";
    document.getElementById("ctl00_ContentPlaceHolder1_divValidateOTP").style.display = "none";

    ValidateRequired(txtOTP, "Please provide valid otp.");

    if (firstErrorControl != "") {
        SetControlFocus(firstErrorControl);
        errMsg = "<table>" + errMsg + "</table>";
        document.getElementById(lblErrorMessage).innerHTML = errMsg;
        document.getElementById(lblErrorMessage).style.borderColor = "Red";
        document.getElementById(lblErrorMessage).style.color = "red";
        document.getElementById("ctl00_ContentPlaceHolder1_divValidateOTP").style.display = "block";
        return false;
    }
    else {
        if (confirm("Are you sure to submit?")) {
            document.getElementById(lblErrorMessage).innerHTML = "";
            document.getElementById("ctl00_ContentPlaceHolder1_divValidateOTP").style.display = "none";
            return true;
        }
        else {
            return false;
        }
    }
}