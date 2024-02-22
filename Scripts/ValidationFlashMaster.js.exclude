//'*************************************************************
//'Copyright	: AGROIII, MCC, KOLKATA
//'Source	    : Scripts/ValidationFlashMaster.js
//'Created Date	: 05-January-2007
//'Created By	: Saravanan
//'Version	    : R02.00.00
//'Description	: Flash News Master

//'Modified By       Modified On       Version         Reason

//'*************************************************************


// JScript File

function ValidateFlashNewsMasterControls()
{
    firstErrorControl ="";
    errMsg= "";

    if (document.getElementById("ctl00_ContentPlaceHolder1_txtMsg1").value != '')
        if (ValidateRequired("ctl00_ContentPlaceHolder1_txtDoExp1", missingDoE))
            if (CheckDateFormat("ctl00_ContentPlaceHolder1_txtDoExp1", invalidTillDate))
                ValidatetwoDates("ctl00_ContentPlaceHolder1_txtDoE1", "ctl00_ContentPlaceHolder1_txtDoExp1", greaterTillDate)

            if (document.getElementById("ctl00_ContentPlaceHolder1_txtMsg2").value != '')
                if (ValidateRequired("ctl00_ContentPlaceHolder1_txtDoExp2", missingDoE))
                    if (CheckDateFormat("ctl00_ContentPlaceHolder1_txtDoExp2", invalidTillDate))
                        ValidatetwoDates("ctl00_ContentPlaceHolder1_txtDoE2", "ctl00_ContentPlaceHolder1_txtDoExp2", greaterTillDate)

                    if (document.getElementById("ctl00_ContentPlaceHolder1_txtMsg3").value != '')
                        if (ValidateRequired("ctl00_ContentPlaceHolder1_txtDoExp3", missingDoE))
                            if (CheckDateFormat("ctl00_ContentPlaceHolder1_txtDoExp3", invalidTillDate))
                                ValidatetwoDates("ctl00_ContentPlaceHolder1_txtDoE3", "ctl00_ContentPlaceHolder1_txtDoExp3", greaterTillDate)

                            if (document.getElementById("ctl00_ContentPlaceHolder1_txtMsg4").value != '')
                                if (ValidateRequired("ctl00_ContentPlaceHolder1_txtDoExp4", missingDoE))
                                    if (CheckDateFormat("ctl00_ContentPlaceHolder1_txtDoExp4", invalidTillDate))
                                        ValidatetwoDates("ctl00_ContentPlaceHolder1_txtDoE4", "ctl00_ContentPlaceHolder1_txtDoExp4", greaterTillDate)

                                    if (document.getElementById("ctl00_ContentPlaceHolder1_txtMsg5").value != '')
                                        if (ValidateRequired("ctl00_ContentPlaceHolder1_txtDoExp5", missingDoE))
                                            if (CheckDateFormat("ctl00_ContentPlaceHolder1_txtDoExp5", invalidTillDate))
                                                ValidatetwoDates("ctl00_ContentPlaceHolder1_txtDoE5", "ctl00_ContentPlaceHolder1_txtDoExp5", greaterTillDate)

                                            if (document.getElementById("ctl00_ContentPlaceHolder1_txtMsg6").value != '')
                                                if (ValidateRequired("ctl00_ContentPlaceHolder1_txtDoExp6", missingDoE))
                                                    if (CheckDateFormat("ctl00_ContentPlaceHolder1_txtDoExp6", invalidTillDate))
                                                        ValidatetwoDates("ctl00_ContentPlaceHolder1_txtDoE6", "ctl00_ContentPlaceHolder1_txtDoExp6", greaterTillDate)

                                                    if (document.getElementById("ctl00_ContentPlaceHolder1_txtMsg7").value != '')
                                                        if (ValidateRequired("ctl00_ContentPlaceHolder1_txtDoExp7", missingDoE))
                                                            if (CheckDateFormat("ctl00_ContentPlaceHolder1_txtDoExp7", invalidTillDate))
                                                                ValidatetwoDates("ctl00_ContentPlaceHolder1_txtDoE7", "ctl00_ContentPlaceHolder1_txtDoExp7", greaterTillDate)

                                                            if (document.getElementById("ctl00_ContentPlaceHolder1_txtMsg8").value != '')
                                                                if (ValidateRequired("ctl00_ContentPlaceHolder1_txtDoExp8", missingDoE))
                                                                    if (CheckDateFormat("ctl00_ContentPlaceHolder1_txtDoExp8", invalidTillDate))
                                                                        ValidatetwoDates("ctl00_ContentPlaceHolder1_txtDoE8", "ctl00_ContentPlaceHolder1_txtDoExp8", greaterTillDate)

                                                                    if (document.getElementById("ctl00_ContentPlaceHolder1_txtMsg9").value != '')
                                                                        if (ValidateRequired("ctl00_ContentPlaceHolder1_txtDoExp9", missingDoE))
                                                                            if (CheckDateFormat("ctl00_ContentPlaceHolder1_txtDoExp9", invalidTillDate))
                                                                                ValidatetwoDates("ctl00_ContentPlaceHolder1_txtDoE9", "ctl00_ContentPlaceHolder1_txtDoExp9", greaterTillDate)

                                                                            if (document.getElementById("ctl00_ContentPlaceHolder1_txtMsg10").value != '')
                                                                                if (ValidateRequired("ctl00_ContentPlaceHolder1_txtDoExp10", missingDoE))
                                                                                    if (CheckDateFormat("ctl00_ContentPlaceHolder1_txtDoExp10", invalidTillDate))
                                                                                        ValidatetwoDates("ctl00_ContentPlaceHolder1_txtDoE10", "ctl00_ContentPlaceHolder1_txtDoExp10", greaterTillDate)
                
    if(firstErrorControl!="")
    {        
        SetControlFocus(firstErrorControl);
        errMsg = "<table>" + errMsg + "</table>";
        document.getElementById("ctl00_ContentPlaceHolder1_divErrorMessage").innerHTML = errMsg;
        return false;    
    }
    else
    {      
      return confirm ('Are you sure to submit?')   
    }

}


function DisplayCurrentDate(DoEControlId, MsgtxtControlId, DoExpControlId, hdnCurrentDate)
{
   
   var checkCurrentdateObj = new Date();
    
    var y=checkCurrentdateObj.getFullYear()+"";
	var M=checkCurrentdateObj.getMonth()+1;
	var d=checkCurrentdateObj.getDate();
	
	//alert(y);
	
	var currDate ="";
	
	
//	if(parseInt(M) <= 9)
//	    currDate = d + "/" + "0" + M + "/" + y;
    
    if(parseInt(d) <= 9)
    {
        if(parseInt(M) <= 9)
        {
	        currDate = "0" + d + "/" + "0" + M + "/" + y;
	        
	    }else{
	       currDate = "0" + d + "/" + M + "/" + y;
	    }
	}
	else
	{
	    if(parseInt(M) <= 9)
        {
	        currDate =  d + "/" + "0" + M + "/" + y;
	        
	    }else{
	       currDate =  d + "/" + M + "/" + y;
	    }
	}	     
	     
    if(document.getElementById(MsgtxtControlId).value!='')
    {
        if (document.getElementById('ctl00_ContentPlaceHolder1_'+DoEControlId).value == '') 
        {
            document.getElementById('ctl00_ContentPlaceHolder1_' + DoEControlId).value = currDate;
            document.getElementById('ctl00_ContentPlaceHolder1_' + hdnCurrentDate).value = currDate;
          
            var tillDate = dateFormatChange(currDate,1,30);
            document.getElementById('ctl00_ContentPlaceHolder1_' + DoExpControlId).value = tillDate;
          
        }    
    }       
}