function ValidateSubmit(txtFrmName,txtFrmLink,ddlParent,txtFrmSeq,btnUpdate,lblErrMsg) {
    firstErrorControl = "";
    errMsg = "";

    ValidateRequired(txtFrmName, "Please Enter Form Name");
    ValidateRequired(txtFrmLink, "Please Enter Form Link");
    ValidateDropDown(ddlParent, "Please Select Parent Form");
    if (ValidateRequired(txtFrmSeq, "Please Enter Sequence")) {
        ValidateNumbers(txtFrmSeq, "Please Enter Integer Only");
    }
    if (firstErrorControl != "") {
        SetControlFocus(firstErrorControl);
        errMsg = "<table>" + errMsg + "</table>";
        document.getElementById(lblErrMsg).innerHTML = errMsg;

        return false;
    }

    else {
        document.getElementById(lblErrMsg).innerHTML = '';
       if (confirm('Are you sure to Submit?')) {
           document.getElementById(btnUpdate).disabled = true;
           __doPostBack(document.getElementById(btnUpdate).name, '');
            //            document.getElementById('btnAdd').click()
            return true;
        }
        else {
            return false;
        }
    }

}


