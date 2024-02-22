function Validatefile(controlName, errorMessage) {

    var errorCode = true;
    var controlID = controlName;
    var controlObject = document.getElementById(controlID);

    errorCode = fnCheckExt(controlObject)
    if (!errorCode) {
        //if(firstErrorControl == '')        
        firstErrorControl = controlID;

        errMsg += GetErrorRow(controlID, errorMessage);

        SetErrorColor(controlID, false);

        return false;
    }
    else
        SetErrorColor(controlID, true);

    return true;
}

function fnCheckExt(controlObject) {

    if (controlObject.value != "") {
        var Exntsn = controlObject.value;
        var fileName = Exntsn

        var Extension = fileName.substr(fileName.lastIndexOf(".") + 1, fileName.length);
        Extension = Extension.toUpperCase();
        if (Extension != "TXT") {
            //alert("Choose a Valid File");
            //document.getElementById("sch_fld").focus()
            //SetErrorColor("sch_fld", false);
            return false;
        }
        else
            return true;
    }
}

function ValidateUpload() {
    document.getElementById("ctl00_ContentPlaceHolder1_lblValidationMessage").innerHTML = "";
    firstErrorControl = "";
    errMsg = "";

    if (ValidateRequired("ctl00_ContentPlaceHolder1_fileUploadBritishApp", "Select a File to Upload .")) {
        Validatefile("ctl00_ContentPlaceHolder1_fileUploadBritishApp", "Choose a Valid File .")
    }

   
    if (firstErrorControl != "") {
        SetControlFocus(firstErrorControl);
        errMsg = "<table>" + errMsg + "</table>";
        document.getElementById("ctl00_ContentPlaceHolder1_lblValidationMessage").innerHTML = errMsg;
        document.getElementById("ctl00_ContentPlaceHolder1_lblMessage").innerHTML = "";

        return false;
    }
    else {
        document.getElementById("ctl00_ContentPlaceHolder1_lblValidationMessage").innerHTML = "";
        if (confirm("Are you sure to submit?")) {
            document.getElementById("ctl00_ContentPlaceHolder1_btnSave").disabled = true;
            document.getElementById("ctl00_ContentPlaceHolder1_lblupload").style.display = 'block';
            document.getElementById("ctl00_ContentPlaceHolder1_progressbar").style.display = 'block';
            __doPostBack(document.getElementById("ctl00_ContentPlaceHolder1_btnSave").name, "");
            //document.getElementById(btnSave).disabled = true;
            return true;

        }
        else {
            return false;
        }

    }
}



