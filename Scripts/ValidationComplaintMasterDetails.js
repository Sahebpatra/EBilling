function ValidateForm(ddlComplaintType, txtSubject, txtDescription, ddlUserGroup, chkboxListApplicableUser, lblErrorMessage, btnSubmit) {
    firstErrorControl = "";
    errMsg = "";

    
    ValidateRequired(txtSubject, "Please write subject.")
    ValidateRequired(txtDescription, "Please write description.")
    if (ValidateRequired(ddlComplaintType, "Please select Complaint Type.")) {
        var select = document.querySelector("#" + ddlComplaintType + "+ .select2-container .selection .select2-selection");
        if (select != null) {
            select.style.backgroundColor = "white";
        }
    }
    else {
        firstErrorControl = ddlComplaintType;
        var select = document.querySelector("#" + ddlComplaintType + "+ .select2-container .selection .select2-selection");
        if (select != null) {
            select.style.backgroundColor = "yellow";
        }
    }
  
    //if (validateCheckBoxList(ddlUserGroup, "Please select User Group.")) {
    //    var select = document.querySelector("#" + ddlUserGroup + "+ .select2-container .selection .select2-selection");
    //    if (select != null) {
    //        select.style.backgroundColor = "white";
    //    }
    //}
    //else {
    //    firstErrorControl = ddlUserGroup;
    //    var select = document.querySelector("#" + ddlUserGroup + "+ .select2-container .selection .select2-selection");
    //    if (select != null) {
    //        select.style.backgroundColor = "yellow";
    //    }
    //};

    ValidateCheckBoxList(ddlUserGroup, "Please select User Group.")
    //ValidateCheckBoxList(chkboxListApplicableUser, "Please select at least one user to continue...")

 
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