function ValidateUpdate(txtAreaFlashMsg, txtFlashTo, txtflashRetainTill, ddlActive, btnUpdate, lblErrorMessage) {
    firstErrorControl = "";
    errMsg = "";

    ValidateRequired(txtAreaFlashMsg, "Please write message")

    if (ValidateRequired(txtFlashTo, "Please enter start Date.")) {
        if (CheckDateFormat(txtFlashTo, "Check start date format")) {
            if (ValidateRequired(txtflashRetainTill, "Please enter end date.")) {
                if (CheckDateFormat(txtflashRetainTill, "Check end date format")) {
                    ValidatetwoDates(txtFlashTo, txtflashRetainTill, 'End date cannot be smaller then start date')
                }
            }
        }
    }

    ValidateDropDown(ddlActive, "Please select status");

    if (firstErrorControl != "") {
        SetControlFocus(firstErrorControl);
        errMsg = "<table>" + errMsg + "</table>";
        document.getElementById(lblErrorMessage).innerHTML = errMsg;
        return false;
    }

    else {
        document.getElementById(lblErrorMessage).innerHTML = '';
        if (confirm('Are you sure to Submit?')) {
            document.getElementById(btnUpdate).disabled = true;
            __doPostBack(document.getElementById(btnUpdate).name, '');
            return true;
        }
        else {
            return false;
        }
    }
}

function ValidateSubmit(txtAreaFlashMsg, txtFlashTo, txtflashRetainTill, ddlActive, btnUpdate, lblErrorMessage) {
    firstErrorControl = "";
    errMsg = "";

    ValidateRequired(txtAreaFlashMsg, "Please write message")

    if (ValidateRequired(txtFlashTo, "Please enter start Date.")) 
    {
        if (CheckDateFormat(txtFlashTo, "Check start date format")) {
            if (ValidateRequired(txtflashRetainTill, "Please enter end date.")) {
                if (CheckDateFormat(txtflashRetainTill, "Check end date format")) {
                    ValidatetwoDates(txtFlashTo, txtflashRetainTill, 'End date cannot be smaller then start date')
                }
            }
        }
    }

    ValidateDropDown(ddlActive, "Please select status");

    if (firstErrorControl != "") {
        SetControlFocus(firstErrorControl);
        errMsg = "<table>" + errMsg + "</table>";
        document.getElementById(lblErrorMessage).innerHTML = errMsg;
        return false;
    }

    else {
        document.getElementById(lblErrorMessage).innerHTML = '';
        if (confirm('Are you sure to Submit?')) {
            document.getElementById(btnUpdate).disabled = true;
            __doPostBack(document.getElementById(btnUpdate).name, '');
            return true;
        }
        else {
            return false;
        }
    }
}