function ValidateAdd(txtGroupName, ddlFtUserID, btnSubmit, lblErrorMessage) {
    firstErrorControl = "";
    errMsg = "";


    ValidateRequired(txtGroupName, "Please Enter Group Name");

    if (ValidateRequired(ddlFtUserID, "Please select User Name.")) {
        var select = document.querySelector("#" + ddlFtUserID + "+ .select2-container .selection .select2-selection");
        if (select != null) {
            select.style.backgroundColor = "white";
        }
    }
    else {
        firstErrorControl = ddlFtUserID;
        var select = document.querySelector("#" + ddlFtUserID + "+ .select2-container .selection .select2-selection");
        if (select != null) {
            select.style.backgroundColor = "yellow";
        }
    }
    if (firstErrorControl != "") {
        SetControlFocus(firstErrorControl);
        errMsg = "<table>" + errMsg + "</table>";
        document.getElementById(lblErrorMessage).innerHTML = errMsg;

        return false;
    }

    else {
        document.getElementById(lblErrorMessage).innerHTML = '';
        if (confirm('Are you sure to Submit?')) {
            document.getElementById(btnSubmit).disabled = true;

            //            document.getElementById('btnAdd').click()
            return true;
        }
        else {
            return false;
        }
    }

}

function ValidateGroupData(txtGroupName, chkboxListApplicableUser, lblErrorMessage, btnSubmit) {
    firstErrorControl = "";
    errMsg = "";

    ValidateRequired(txtGroupName, "Please provide group name");

    if (!(document.getElementById("ctl00_ContentPlaceHolder1_chkUserAll").checked)) {
        if (document.getElementById(chkboxListApplicableUser)) {
            ValidateCheckBoxList(chkboxListApplicableUser, "Please select atleast one user to continue.")
        }
    }

    if (firstErrorControl != "") {
        SetControlFocus(firstErrorControl);
        errMsg = "<table>" + errMsg + "</table>";
        document.getElementById(lblErrorMessage).innerHTML = errMsg;
        return false;
    }
    else {
        document.getElementById(lblErrorMessage).innerHTML = '';
        if (confirm('Are you sure to Submit?')) {
            document.getElementById(btnSubmit).disabled = true;
            return true;
        }
        else {
            return false;
        }
    }
}