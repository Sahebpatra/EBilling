function ValidateSubmit(txtCode, txtDesc, txtValue, txtSeq, ddlActive, btnSubmit, lblErrorMessage) {
    firstErrorControl = "";
    errMsg = "";

//    ValidateRequired(txtCode, "Please Enter Code");
//    ValidateRequired(txtDesc, "Please Enter Description");
    ValidateRequired(txtValue, "Please Enter Value");
    
//    ValidateDropDown(ddlActive, "Please Select Status");
    if (ValidateRequired(txtSeq, "Please Enter Sequence")) {
        ValidateNumbers(txtSeq, "Please Enter Integer Only");
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
            __doPostBack(document.getElementById(btnSubmit).name, '');
            //            document.getElementById('btnAdd').click()
            return true;
        }
        else {
            return false;
        }
    }

}