function isNumber(evt) {
    var iKeyCode = (evt.which) ? evt.which : evt.keyCode
    if (iKeyCode != 46 && iKeyCode > 31 && (iKeyCode < 48 || iKeyCode > 57)) {
        return false;
    }
    return true;
}

function ValidateForm(ddlComplaintType, txtComplaintDate, txtComplaintDescription, txtRemarks, message, btnSubmit) {
    firstErrorControl = "";
    errMsg = "";
    document.getElementById(message).innerHTML = "";
    document.getElementById("ctl00_ContentPlaceHolder1_divAlert").style.display = "none";

    ValidateDropDown(ddlComplaintType, "Please select complaint type.");
    ValidateRequired(txtComplaintDate, "Please enter valid complaint date.");
    ValidateRequired(txtComplaintDescription, "Please enter complaint description.");

    if (document.getElementById(btnSubmit).value == "Submit") {
        if (firstErrorControl != "") {
            SetControlFocus(firstErrorControl);
            errMsg = "<table>" + errMsg + "</table>";
            document.getElementById(message).innerHTML = errMsg;
            document.getElementById("ctl00_ContentPlaceHolder1_divAlert").style.display = "block";
            return false;
        }
        else {
            var n = document.getElementById(btnSubmit).value;
            if (confirm("Are you sure to submit?")) {
                document.getElementById(message).innerHTML = "";
                document.getElementById("ctl00_ContentPlaceHolder1_divAlert").style.display = "none";
                return true;
            }
            else {
                return false;
            }
        }
    }
    else {
        if (firstErrorControl != "") {
            SetControlFocus(firstErrorControl);
            errMsg = "<table>" + errMsg + "</table>";
            document.getElementById(message).innerHTML = errMsg;
            document.getElementById("ctl00_ContentPlaceHolder1_divAlert").style.display = "block";
            return false;
        }
        else {
            var n = document.getElementById(btnSubmit).value;
            if (confirm("Are you sure to Update?")) {
                document.getElementById(btnSubmit).name;
                document.getElementById(message).innerHTML = "";
                document.getElementById("ctl00_ContentPlaceHolder1_divAlert").style.display = "none";
                return true;
            }
            else {
                return false;
            }
        }
    }
}
function ValidateForm1(ComplaintType, message, btnSubmit) {
    firstErrorControl = "";
    errMsg = "";
    document.getElementById(message).innerHTML = "";
    ValidateRequired(ComplaintType, "Please enter complaint type.");

    if (document.getElementById(btnSubmit).value == "Submit") {
        if (firstErrorControl != "") {
            SetControlFocus(firstErrorControl);
            errMsg = "<table>" + errMsg + "</table>";
            document.getElementById(message).innerHTML = errMsg;

            return false;
        }
        else {
            var n = document.getElementById(btnSubmit).value;
            if (confirm("Are you sure to submit?")) {
                document.getElementById(message).innerHTML = "";
                return true;
            }
            else {
                return false;
            }
        }
    }
    else {
        if (firstErrorControl != "") {
            SetControlFocus(firstErrorControl);
            errMsg = "<table>" + errMsg + "</table>";
            document.getElementById(message).innerHTML = errMsg;

            return false;
        }
        else {
            var n = document.getElementById(btnSubmit).value;
            if (confirm("Are you sure to Update?")) {
                document.getElementById(btnSubmit).name;
                document.getElementById(message).innerHTML = "";
                return true;
            }
            else {
                return false;
            }
        }
    }
}