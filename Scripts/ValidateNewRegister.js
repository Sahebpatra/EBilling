
function ValidateMembarData(txtSponsorID,txtUplineID,txtApplicantName,txtDOB,ddlBloodGroup,rdoGender,rdoMaritalStatus,ddlProfession,txtAddress,ddlCountry,ddlState,ddlCity,txtPinCode,txtEmail,txtMobileNo,txtNomineeName,ddlNomineeRelation,txtConfirmMobileNo,txtNomineeAge,chkTermsCondition,ddlSalutaion, btnSubmit, lblValidationMessage) {
    debugger;

    firstErrorControl = "";
    errMsg = "";
    document.getElementById("ctl00_ContentPlaceHolder1_divAlertValidation").style.display = "none";

    if (document.getElementById(txtSponsorID).value == "") {
        alert('Please validate sponsor ID first.');
        return false;
    }
    debugger;
    ValidateRequired(txtSponsorID, "Please provide one sponsor");
    ValidateRequired(txtUplineID, "Please provide upline ID");
    ValidateDropDown(ddlSalutaion, "Please select salutation");
    ValidateRequired(txtApplicantName, "Please provide applicant name");
    //ValidateRequired(txtFatherName, "Please provide applicant's father name");
    ValidateRequired(txtDOB, "Please provide valid date of birth");

    ValidateRadioButton(rdoGender, "Please select gender");
    ValidateRequired(txtAddress, "Please provide address");

    ValidateDropDown(ddlCountry,"Please select country");
    ValidateDropDown(ddlState, "Please select state");
    ValidateDropDown(ddlCity, "Please select city");

    ValidateRequired(txtPinCode, "Please provide pin code");
    if (document.getElementById(txtEmail).value != "") {
        ValidateEmail(txtEmail, "Please provide email");
    }

    ValidateMobile(txtMobileNo, "Please provide mobile no");
    ValidateMobile(txtConfirmMobileNo, "Please provide confirm mobile no");

    ValidateRequired(txtNomineeName, "Please provide nominee name");
    ValidateDropDown(ddlNomineeRelation, "Please select nominee relation");

    ValidateCheckBox(chkTermsCondition, "Please check terms & conditions.")

    if (firstErrorControl != "") {
        SetControlFocus(firstErrorControl);
        errMsg = "<table>" + errMsg + "</table>";
        document.getElementById(lblValidationMessage).innerHTML = errMsg;
        document.getElementById(lblValidationMessage).style.borderColor = "Red";
        document.getElementById(lblValidationMessage).style.color = "red";
        document.getElementById("ctl00_ContentPlaceHolder1_divAlertValidation").style.display = "block";
        return false;
    }
    else {
        document.getElementById(lblValidationMessage).innerHTML = "";
        if (confirm('Are you sure to submit?')) {
            document.getElementById(btnSubmit).disabled = true;
            document.getElementById("ctl00_ContentPlaceHolder1_divAlertValidation").style.display = "none";
            //_doPostBack(document.getElementById(btnSubmit).name, '');
        }
        else {
            return false;
        }
    }
}

function ValidateSponsorID(txtSponsorID, txtUplineID, btnSubmit, lblValidationMessage) {
    firstErrorControl = "";
    errMsg = "";

    ValidateRequired(txtSponsorID, "Please provide one sponsor ID to validate");
    ValidateRequired(txtUplineID, "Please provide one upline ID to validate");

    if (firstErrorControl != "") {
        SetControlFocus(firstErrorControl);
        errMsg = "<table>" + errMsg + "</table>";
        document.getElementById(lblValidationMessage).innerHTML = errMsg;
        return false;
    }
    else {
        return true;
    }
}

function ValidateMObileNo(txtMobileNo, txtConfirmMobileNo, lblErrorMessage) {
    firstErrorControl = "";
    errMsg = "";
    document.getElementById("ctl00_ContentPlaceHolder1_divAlertMobile").style.display = "none";

    ValidateRequired(txtMobileNo, "Please provide mobile no.")
    if (firstErrorControl == "") {
        ValidateMobile(txtMobileNo, "Please provide valid mobile no.");
    }

    if (firstErrorControl == "") {
        var mobileNo = document.getElementById(txtMobileNo).value;
        var comfirmPassword = document.getElementById(txtConfirmMobileNo).value;
        if (mobileNo != comfirmPassword) {
            firstErrorControl = document.getElementById(txtMobileNo);
            SetErrorColor(document.getElementById(txtMobileNo), false);

            errMsg += GetErrorRow(document.getElementById(txtConfirmMobileNo), "Mobile no and confirm mobile no does not matched. Please try again!!!");
            SetErrorColor(document.getElementById(txtConfirmMobileNo), false);

        }
    }

    if (firstErrorControl != "") {
        SetControlFocus(firstErrorControl);
        errMsg = "<table>" + errMsg + "</table>";
        document.getElementById(lblErrorMessage).innerHTML = errMsg;
        document.getElementById(lblErrorMessage).style.borderColor = "Red";
        document.getElementById(lblErrorMessage).style.color = "red";
        document.getElementById("ctl00_ContentPlaceHolder1_divAlertMobile").style.display = "block";
        return false;
    }
    else {
        return true;
    }

}