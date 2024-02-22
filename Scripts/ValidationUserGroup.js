function ValidateUpdate(txtUserGroupDesc, btnUpdate, lblErrorMessage) {
    firstErrorControl = "";
    errMsg = "";

    ValidateRequired(txtUserGroupDesc, "Please write user group description.")

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

function ValidateSubmit(txtUserGroupCode, txtUserGroupDesc, btnSubmit, lblErrorMessage) {
    firstErrorControl = "";
    errMsg = "";

    ValidateRequired(txtUserGroupCode, "Please write user group code.")
    ValidateRequired(txtUserGroupDesc, "Please write user group description.")

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