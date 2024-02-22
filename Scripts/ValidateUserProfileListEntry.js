function ValidateForm(userID, FirstName, LastName, UserGroup, Department, txtEmail, txtMobile, Designation, joindate, depot, message, btnSubmit) {

    firstErrorControl = "";
    errMsg = "";
    
    document.getElementById(message).innerHTML = "";
    if (document.getElementById(btnSubmit).value == "Submit") 
    {
        ValidateRequired(userID, "Please enter User Id .");
        ValidateRequired(FirstName, "Please enter employee first name .");
//        ValidateRequired(LastName, "Please enter employee last name .");

     
        ValidateRequired(Designation, "Please enter Designation");
        if (ValidateRequired(UserGroup, "Please enter User Group.")) {
            var select = document.querySelector("#" + UserGroup + "+ .select2-container .selection .select2-selection");
            if (select != null) {
                select.style.backgroundColor = "white";
            }
        }
        else {
            firstErrorControl = UserGroup;
            var select = document.querySelector("#" + UserGroup + "+ .select2-container .selection .select2-selection");
            if (select != null) {
                select.style.backgroundColor = "yellow";
            }
        }
      

        if (ValidateRequired(joindate, "Please enter Join Date.")) {
           (CheckDateFormat(joindate, "Check Date Format")) 
        }
        ValidateRequired(txtMobile, "Please enter Mobile No .");
        
        
        ValidateRequired(depot, "Please select Depot");

        if (document.getElementById(txtEmail).value != "") {
            ValidateEmail(txtEmail, "Invalid email Id.Please enter valid email Id .");
        }

        validateCheckBoxList("ctl00_ContentPlaceHolder1_chkbxListApplSbls", "Please select business line.");

        if (firstErrorControl != "") {
            SetControlFocus(firstErrorControl);
            errMsg = "<table>" + errMsg + "</table>";
            document.getElementById(message).innerHTML = errMsg;

            return false;
        }
        else 
        {
            var n = document.getElementById(btnSubmit).value;
            if (confirm("Are you sure to submit?")) 
            {
                document.getElementById(message).innerHTML = "";
                return true;
            }
            else 
            {
                return false;
            }
        }
    }
    else {

        ValidateRequired(userID, "Please enter User Id .");
        ValidateRequired(FirstName, "Please enter employee first name .");
//        ValidateRequired(LastName, "Please enter employee last name .");
        
    
        if (ValidateRequired(UserGroup, "Please enter User Group.")) {
            var select = document.querySelector("#" + UserGroup + "+ .select2-container .selection .select2-selection");
            if (select != null) {
                select.style.backgroundColor = "white";
            }
        }
        else {
            firstErrorControl = UserGroup;
            var select = document.querySelector("#" + UserGroup + "+ .select2-container .selection .select2-selection");
            if (select != null) {
                select.style.backgroundColor = "yellow";
            }
        }
        ValidateRequired(Designation, "Please enter Designation");
        ValidateRequired(joindate, "Please enter Join Date");
        if (ValidateRequired(depot, "Please select Depot.")) {
            var select = document.querySelector("#" + depot + "+ .select2-container .selection .select2-selection");
            if (select != null) {
                select.style.backgroundColor = "white";
            }
        }
        else {
            firstErrorControl = depot;
            var select = document.querySelector("#" + depot + "+ .select2-container .selection .select2-selection");
            if (select != null) {
                select.style.backgroundColor = "yellow";
            }
        }
     
     

        if (document.getElementById(txtEmail).value != "") {
            ValidateEmail(txtEmail, "Invalid email Id.Please enter valid email Id .");
        }

        ValidateRequired(txtMobile, "Please enter Mobile No .");

        validateCheckBoxList("ctl00_ContentPlaceHolder1_chkbxListApplSbls", "Please select business line.");

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
    //Set UserID in Upper Case
    function ValidateUserID(userID) 
    {
    var a = document.getElementById(userID).value;
    document.getElementById(userID).value = a.toUpperCase();
}

function compareUserID(txtUserID) {
    CreateXMLHTTP5();
    if (xmlHttp5) {
        var requestURL = "AjaxServices.aspx?";
        requestURL += "Code=";
        requestURL += "UserID";
        requestURL += "&prjCode=";
        requestURL += txtUserID;
        var tempDate = new Date();
        var tempDay = tempDate.getDate();
        var tempMonth = tempDate.getMonth();
        var tempYear = tempDate.getFullYear();
        var tempHour = tempDate.getHours();
        var tempMin = tempDate.getMinutes();
        var tempSec = tempDate.getSeconds();
        var tempMil = tempDate.getMilliseconds();

        var tempDateString = tempDay + ":" + tempMonth + ":" + tempYear + ':' + tempHour + ':' + tempMin + ':' + tempSec + ':' + tempMil;

        requestURL += "&timeStamp=";
        requestURL += tempDateString;

        xmlHttp5.onreadystatechange = doUserIdExists;
        xmlHttp5.open("GET", requestURL, true);
        xmlHttp5.send(null);
    }
    return true;
}

function doUserIdExists() {
    if (xmlHttp5.readyState == 4 || xmlHttp5.readyState == 'complete') {
        if (xmlHttp5.status == 200) {

            if (xmlHttp5.responseText == "False") {
                document.getElementById("ctl00_ContentPlaceHolder1_lblValidateUserId").innerHTML = "";
                document.getElementById("ctl00_ContentPlaceHolder1_txtEmployeesFirstName").focus();       
            }
            else 
            {
                document.getElementById("ctl00_ContentPlaceHolder1_lblValidateUserId").innerHTML = "UserID already exists";
                document.getElementById("ctl00_ContentPlaceHolder1_txtUserID").focus();
            }
        }
        else {
            alert("There was a problem retrieving data from the server.");
        }
    }
    return true;
}

function ValidateGrNo(controlName1, errorMessage) {
    var expMonth = document.getElementById(controlName1).value;

    if (parseInt(expMonth) > "12") {
        var controlID = controlName1;
        //if(firstErrorControl == '') 
        firstErrorControl = controlID;
        errMsg += GetErrorRow(controlID, errorMessage);
        SetErrorColor(controlID, false);
        return false;
    }
    else {
        SetErrorColor(controlID, true);
        return true;
    }
}




function ValidateMobileNo(txtMobile) {
    var valueToValidate = ltrim(document.getElementById(txtMobile).value);
    if (valueToValidate != "") {
        var val = new Number(valueToValidate);
        if (val.toString() != "NaN") {
            document.getElementById(txtMobile).value = val;

            if (document.getElementById(txtMobile).value.length < "10") {
                alert("Please enter 10 digit mobile no.");

                document.getElementById(txtMobile).style.backgroundColor = "yellow";
                document.getElementById(txtMobile).value = "";
            }
            else {
                document.getElementById(txtMobile).value = val;
            }
        }
        else {
            alert("Mobile entered is not valid. Please enter a numeric value.");
            document.getElementById(txtMobile).style.backgroundColor = "yellow";
            document.getElementById(txtMobile).value = "";
        }
    }
    else {
        return false;

    }
}

function ltrim(valuetotrim) {
    var textaftertrim = "";

    for (var j = 0; j <= valuetotrim.length - 1; j++) {
        if (valuetotrim.charAt(j) != " ") {
            textaftertrim += valuetotrim.charAt(j);
        }
    }

    return textaftertrim;
}

function validateCheckBoxList(controlName1, errorMessage) {
    var isAnyCheckBoxChecked = false;
    var checkBoxes = document.getElementById(controlName1).getElementsByTagName("input");
    for (var i = 0; i < checkBoxes.length; i++) {
        if (checkBoxes[i].type == "checkbox") {
            if (checkBoxes[i].checked) {
                isAnyCheckBoxChecked = true;
                break;
            }
        }
    }
    if (!isAnyCheckBoxChecked) {
        var controlID = controlName1;
        //if(firstErrorControl == '') 
        firstErrorControl = controlID;
        errMsg += GetErrorRow(controlID, errorMessage);
        SetErrorColor(controlID, false);
        return false;
    }
    else {
        SetErrorColor(controlID, true);
        return true;
    }
}