// Example Basic
$("#example-basic").steps({    
	headerTag: "h3",
	bodyTag: "section",
	transitionEffect: "slideLeft",
	autoFocus: true,
	onStepChanging: function (event, currentIndex, newIndex) {	  
	    if (currentIndex > newIndex) {
	        return true;
	    }
	    if (currentIndex == 0)
	    {
	        return ValidateUserDetails();
	    }
	    if (currentIndex == 1)
	    {
	        return ValidateOrg();
	    }
	    if (currentIndex == 2) {
	        return ValidateVendor();
	    }
	    
	},
	onFinishing: function (event, currentIndex) {
	    debugger;
	    if (currentIndex == 2) {
	        return ValidateVendor();
	    }
	},
	onFinished: function (event, currentIndex) {
	}
});


// Example Form

$("#example-form").steps({

	headerTag: "h3",
	bodyTag: "section",
	transitionEffect: "slideLeft",
	autoFocus: true,
	
});


// Example Vertical
$("#example-vertical").steps({
	headerTag: "h3",
	bodyTag: "section",
	transitionEffect: "slideLeft",
	stepsOrientation: "vertical"
});


function ValidateUserDetails() {
   firstErrorControl = "";
    errMsg = "";
    document.getElementById("ctl00_ContentPlaceHolder1_lblValidationMessage").innerHTML = "";
    var UserGrp =  document.getElementById("ctl00_ContentPlaceHolder1_ddlUserGroup").value;
    ValidateRequired("ctl00_ContentPlaceHolder1_txtUserId", "Please enter user id .");
    ValidateRequired("ctl00_ContentPlaceHolder1_txtFName", "Please enter employee first name .");
   
    ValidateAutoDropDown("ctl00_ContentPlaceHolder1_ddlUserGroup", "Please select user group .");
    
    
    if (document.getElementById("ctl00_ContentPlaceHolder1_txtEmail").value != "") {
        ValidateEmail("ctl00_ContentPlaceHolder1_txtEmail", "Invalid email Id.Please enter valid email Id .");
    }
    if (document.getElementById("ctl00_ContentPlaceHolder1_txtPhone").value != "") {
        ValidateMobile("ctl00_ContentPlaceHolder1_txtPhone", "Please enter 10 digite mobile no.")
    }
      
    if (UserGrp != "VENDOR") {
        ValidateRequired("ctl00_ContentPlaceHolder1_txtEmpId", "Please enter employee id .");
        ValidateAutoDropDown("ctl00_ContentPlaceHolder1_ddlDepartment", "Please select department .");
        ValidateRequired("ctl00_ContentPlaceHolder1_txtDesignation", "Please enter designation .");
        if (ValidateRequired("ctl00_ContentPlaceHolder1_txtJoinDate", "Please enter join date.")) {
            //(CheckDateFormat("ctl00_ContentPlaceHolder1_txtJoinDate", "Check Date Format ."))
        }
    }
    if (firstErrorControl != "") {
        SetControlFocus(firstErrorControl);
        errMsg = "<table>" + errMsg + "</table>";
        document.getElementById("ctl00_ContentPlaceHolder1_lblValidationMessage").innerHTML = errMsg;

        return false;
    }
    else {
        return true;
    }
}

function ValidateOrg()
{
    firstErrorControl = "";
    errMsg = "";
    
    document.getElementById("ctl00_ContentPlaceHolder1_lblValidationMessage").innerHTML = ""; 
    var UserGrp = document.getElementById("ctl00_ContentPlaceHolder1_ddlUserGroup").value;
    if (UserGrp != "VENDOR") {
        if (document.getElementById("ctl00_ContentPlaceHolder1_chkAllOrg").checked != true) {
            validateChekbox("ctl00_ContentPlaceHolder1_chkbxListApplDepots", 'Select atleast one applicable depot .');
        }
    }
    
    if (firstErrorControl != "") {
        SetControlFocus(firstErrorControl);
        errMsg = "<table>" + errMsg + "</table>";
        document.getElementById("ctl00_ContentPlaceHolder1_lblValidationMessage").innerHTML = errMsg;

        return false;
    }
    else {
        return true;
    }

}

function ValidateVendor() {
    firstErrorControl = "";
    errMsg = "";

    document.getElementById("ctl00_ContentPlaceHolder1_lblValidationMessage").innerHTML = "";
    var UserGrp = document.getElementById("ctl00_ContentPlaceHolder1_ddlUserGroup").value;
    if (UserGrp != "VENDOR") {
        if (document.getElementById("ctl00_ContentPlaceHolder1_ChkAllVendors").checked != true) {
            validateChekbox("ctl00_ContentPlaceHolder1_chkbxListApplVendors", 'Select atleast one applicable vendor .');
        }
    }
    
    if (firstErrorControl != "") {
        SetControlFocus(firstErrorControl);
        errMsg = "<table>" + errMsg + "</table>";
        document.getElementById("ctl00_ContentPlaceHolder1_lblValidationMessage").innerHTML = errMsg;

        return false;
    }
    else {
        return true;
    }

}