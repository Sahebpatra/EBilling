function ValidateUpdate(txtNoOfWeekForEdit, txtStartDateForEdit, txtEndDateForEdit, ddlActive, btnUpdate, lblErrorMessage) 
{
    firstErrorControl = "";
    errMsg = "";

    if (ValidateRequired(txtNoOfWeekForEdit, "Please Enter Number of Week")) {
        ValidateNumbers(txtNoOfWeekForEdit, "Please Enter Integer Only");
    }
    
//    ValidateRequired(txtStartDateForEdit, "Please Enter Start Date");
//    ValidateRequired(txtEndDateForEdit, "Please Enter End Date");

//    if (document.getElementById(txtStartDateForEdit).value != "" && document.getElementById(txtStartDateForEdit).value != "") {
//        DateComparision(txtStartDateForEdit, txtEndDateForEdit, 'End Date Connot be Smaller then Start date')
    //    }

    if (ValidateRequired(txtStartDateForEdit, "Please Enter Start Date.")) {
        if (CheckDateFormat(txtStartDateForEdit, "Check Date Format")) {
            if (ValidateRequired(txtEndDateForEdit, "Please Enter End Date.")) {
                if (CheckDateFormat(txtEndDateForEdit, "Check Date Format")) {
                    ValidatetwoDates(txtStartDateForEdit, txtEndDateForEdit, 'End Date Connot be Smaller then Start date')
                }
            }
        }
    }
    
    ValidateDropDown(ddlActive, "Please Select Status");
    
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
        else 
        {
            return false;
        }
    }
}

function ValidateAdd(txtFinYearForAdd, txtNoOfWeekForAdd, txtStartDateForAdd, txtEndDateForAdd, ddlActive, btnUpdate, lblErrorMessage) {
    firstErrorControl = "";
    errMsg = "";

    if (ValidateRequired(txtFinYearForAdd, "Please Enter Current Year")) {
        ValidateNumbers(txtFinYearForAdd, "Please Enter Integer Only");
    }

    if (ValidateRequired(txtNoOfWeekForAdd, "Please Enter Number of Week")) {
        ValidateNumbers(txtNoOfWeekForAdd, "Please Enter Integer Only");
    };

//    ValidateRequired(txtStartDateForAdd, "Please Enter End Date");
    //    ValidateRequired(txtEndDateForAdd, "Please Enter End Date");

    if (ValidateRequired(txtStartDateForAdd, "Please Enter Start Date.")) {
        if (CheckDateFormat(txtStartDateForAdd, "Check Date Format")) {
            if (ValidateRequired(txtEndDateForAdd, "Please Enter End Date.")) {
                if (CheckDateFormat(txtEndDateForAdd, "Check Date Format")) {
                    ValidatetwoDates(txtStartDateForAdd, txtEndDateForAdd, 'End Date Connot be Smaller then Start date')
                }
            }
        }
    }

    if (document.getElementById(txtStartDateForAdd).value != "" && document.getElementById(txtStartDateForAdd).value != "")
    {
       DateComparision(txtStartDateForAdd, txtEndDateForAdd, 'End Date Connot be Smaller then Start date')
    }

    ValidateDropDown(ddlActive, "Please Select Status");
    
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