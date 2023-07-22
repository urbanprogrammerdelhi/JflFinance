// JScript File

var HttpGroupCode,strDDLName,HttpSaveBR1,HttpSaveBR2
function GetGroupCode(ddlName,GroupCode)
{

HttpGroupCode=GetXmlHttpObject()
strDDLName = ddlName

if (HttpGroupCode==null)
{
alert ("Browser does not support HTTP Request")
return
}

var url="getGroupCodeAjax.aspx"
url=url+"?ddlName="+ddlName
url=url+"&GroupCode="+GroupCode.value
HttpGroupCode.onreadystatechange=stateGroupCode;

HttpGroupCode.open("POST",url,true)
HttpGroupCode.setRequestHeader("Content-Type", "application/x-www-form-urlencoded" )
HttpGroupCode.send(null)

}

function stateGroupCode()
{ 
    if (HttpGroupCode.readyState==4 || HttpGroupCode.readyState=="complete")
	{ 
		if(strDDLName == 'Religion')
		{
			document.getElementById('divReligion').innerHTML="";	
			document.getElementById('divReligion').innerHTML = HttpGroupCode.responseText;
		}
		else if(strDDLName == 'Nationality')
		{
			document.getElementById('divNationality').innerHTML="";	
			document.getElementById('divNationality').innerHTML = HttpGroupCode.responseText;
		}
		else if(strDDLName == 'JobType')
		{
			document.getElementById('divJobType').innerHTML="";	
			document.getElementById('divJobType').innerHTML = HttpGroupCode.responseText;
		}	
		else if(strDDLName == 'JobClass')
		{
			document.getElementById('divJobClass').innerHTML="";	
			document.getElementById('divJobClass').innerHTML = HttpGroupCode.responseText;
		}	
		else if(strDDLName == 'Category')
		{
			document.getElementById('divCategory').innerHTML="";	
			document.getElementById('divCategory').innerHTML = HttpGroupCode.responseText;
		}					
		else if(strDDLName == 'Designation')
		{
			document.getElementById('divDesignation').innerHTML="";	
			document.getElementById('divDesignation').innerHTML = HttpGroupCode.responseText;
		}							
		else if(strDDLName == 'Department')
		{
			document.getElementById('divDepartment').innerHTML="";	
			document.getElementById('divDepartment').innerHTML = HttpGroupCode.responseText;
		}									
		else if(strDDLName == 'Gender')
		{
			document.getElementById('divGender').innerHTML="";	
			document.getElementById('divGender').innerHTML = HttpGroupCode.responseText;
		}											
	}
} 

function onClickInsertPayRate1(CompanyCode,txtPayRateCode,txtPayRateDesc,
chkUnitInDays,
rdoMonthly,
rdoFortNightly,
rdoWeekly,
txtStartDay,
txtEndDay,
rdoCurrent,
rdoPrevious,
txtOTStartDay,
txtOTEndDay,
chkIsTimeBasedRegOTHrs,
chkIsBreakHrs,
chkOT1,
chkOT2,
rdoBreakHrsFix,
rdoBreakHrsTimeBased,
txtMonthlyHours,
txtMinDutyHrs,
txtRegHrs,
ddlHrsHeadReg,
txtOTAfter,
ddlHrsHeadOT,
txtAddOTAfter,
ddlHrsHeadAddOT,
txtOT1,
ddlHrsHeadOT1,
txtOT2,
ddlHrsHeadOT2,
txtMinDutyHrsReqForBrk,
txtFixedBrkHours,
ddlHoursHeadFixed,
ddlHoursHeadFixed1,
txtBrkTimeFrom,
txtBrkTimeTo,
chkHoliday,
chkTimeBasedHoliday,
chkHolOT1,
chkHolOT2,
txtHolRegHrsNotWork,
ddlHolHrsHeadNotWork,
txtHolRegHrsWork,
ddlHolHrsHeadWork,
txtHolOT,
ddlHolOTHrsHead,
txtAddHolOTHrs,
ddlHolAddOTHrsHead,
ddlHolidayConstraints,
txtConsqDays,
txtMinHolDutyHrsOT1,
ddlHrsHeadHolOT1,
txtMinHolDutyHrsOT2,
ddlHrsHeadHolOT2,
chkHolRegActual,
chkHolOTActual,
chkWeekOff,
chkTimeBasedWo,
chkWOOT1,
chkWOOT2,
txtWORegHrsNotWork,
ddlWORegHrsNotWork,
txtWORegHrsWork,
ddlWORegHrsWork,
txtWOOTHrsAfter,
ddlWOOTHrsAfter,
txtWOAddOTHrsAfter,
ddlWOAddOTHrsAfter,
txtMinDutyHrsWOOT1,
ddlWOHrsHeadOT1,
txtMinDutyHrsWOOT2,
ddlWOHrsHeadOT2,
chkWORegHrsActual,
chkWOOTHrsActual,
chkLeave)
{
var strPayPeriod="";
var strOTMonth = "";
var strBrkHrsHead = "";

if(document.getElementById(rdoMonthly).checked==true)
{
    strPayPeriod = "M";
}
else if(document.getElementById(rdoFortNightly).checked==true)
{
    strPayPeriod = "F";
}
else if(document.getElementById(rdoWeekly).checked==true)
{
    strPayPeriod = "W";
}

if(document.getElementById(rdoCurrent).checked==true)
{
    strOTMonth = "C";
}
else if(document.getElementById(rdoPrevious).checked==true)
{
    strOTMonth = "P";
}
if(document.getElementById(rdoBreakHrsFix).checked==true)
{
    strBrkHrsHead = document.getElementById(ddlHoursHeadFixed).value;
}
else
{
    strBrkHrsHead = document.getElementById(ddlHoursHeadFixed1).value;
}

HttpSaveBR1=GetXmlHttpObject()

if (HttpSaveBR1==null)
{
alert ("Browser does not support HTTP Request")
return
}
var url="BusinessRuleInsertPayRate1Ajax.aspx"
url=url+"?CompanyCode="+CompanyCode
url=url+"&txtPayRateCode="+document.getElementById(txtPayRateCode).value
url=url+"&txtPayRateDesc="+document.getElementById(txtPayRateDesc).value
url=url+"&chkUnitInDays="+document.getElementById(chkUnitInDays).checked
url=url+"&strPayPeriod="+strPayPeriod
url=url+"&txtStartDay="+document.getElementById(txtStartDay).value
url=url+"&txtEndDay="+document.getElementById(txtEndDay).value
url=url+"&strOTMonth="+strOTMonth
url=url+"&txtOTStartDay="+document.getElementById(txtOTStartDay).value
url=url+"&txtOTEndDay="+document.getElementById(txtOTEndDay).value
url=url+"&chkIsTimeBasedRegOTHrs="+document.getElementById(chkIsTimeBasedRegOTHrs).checked
url=url+"&chkIsBreakHrs="+document.getElementById(chkIsBreakHrs).checked
url=url+"&chkOT1="+document.getElementById(chkOT1).checked
url=url+"&chkOT2="+document.getElementById(chkOT2).checked
url=url+"&rdoBreakHrsFix="+document.getElementById(rdoBreakHrsFix).checked
url=url+"&rdoBreakHrsTimeBased="+document.getElementById(rdoBreakHrsTimeBased).checked
url=url+"&txtMonthlyHours="+document.getElementById(txtMonthlyHours).value
url=url+"&txtMinDutyHrs="+document.getElementById(txtMinDutyHrs).value
url=url+"&txtRegHrs="+document.getElementById(txtRegHrs).value
url=url+"&ddlHrsHeadReg="+document.getElementById(ddlHrsHeadReg).value
url=url+"&txtOTAfter="+document.getElementById(txtOTAfter).value
url=url+"&ddlHrsHeadOT="+document.getElementById(ddlHrsHeadOT).value
url=url+"&txtAddOTAfter="+document.getElementById(txtAddOTAfter).value
url=url+"&ddlHrsHeadAddOT="+document.getElementById(ddlHrsHeadAddOT).value
url=url+"&txtOT1="+document.getElementById(txtOT1).value
url=url+"&ddlHrsHeadOT1="+document.getElementById(ddlHrsHeadOT1).value
url=url+"&txtOT2="+document.getElementById(txtOT2).value
url=url+"&ddlHrsHeadOT2="+document.getElementById(ddlHrsHeadOT2).value
url=url+"&txtMinDutyHrsReqForBrk="+document.getElementById(txtMinDutyHrsReqForBrk).value
url=url+"&txtFixedBrkHours="+document.getElementById(txtFixedBrkHours).value
url=url+"&strBrkHrsHead="+strBrkHrsHead
url=url+"&txtBrkTimeFrom="+document.getElementById(txtBrkTimeFrom).value
url=url+"&txtBrkTimeTo="+document.getElementById(txtBrkTimeTo).value
url=url+"&chkHoliday="+document.getElementById(chkHoliday).checked
url=url+"&chkTimeBasedHoliday="+document.getElementById(chkTimeBasedHoliday).checked
url=url+"&chkHolOT1="+document.getElementById(chkHolOT1).checked
url=url+"&chkHolOT2="+document.getElementById(chkHolOT2).checked
url=url+"&txtHolRegHrsNotWork="+document.getElementById(txtHolRegHrsNotWork).value
url=url+"&ddlHolHrsHeadNotWork="+document.getElementById(ddlHolHrsHeadNotWork).value
url=url+"&txtHolRegHrsWork="+document.getElementById(txtHolRegHrsWork).value
url=url+"&ddlHolHrsHeadWork="+document.getElementById(ddlHolHrsHeadWork).value
url=url+"&txtHolOT="+document.getElementById(txtHolOT).value
url=url+"&ddlHolOTHrsHead="+document.getElementById(ddlHolOTHrsHead).value
url=url+"&txtAddHolOTHrs="+document.getElementById(txtAddHolOTHrs).value
url=url+"&ddlHolAddOTHrsHead="+document.getElementById(ddlHolAddOTHrsHead).value
url=url+"&ddlHolidayConstraints="+document.getElementById(ddlHolidayConstraints).value
url=url+"&txtConsqDays="+document.getElementById(txtConsqDays).value
url=url+"&txtMinHolDutyHrsOT1="+document.getElementById(txtMinHolDutyHrsOT1).value
url=url+"&ddlHrsHeadHolOT1="+document.getElementById(ddlHrsHeadHolOT1).value
url=url+"&txtMinHolDutyHrsOT2="+document.getElementById(txtMinHolDutyHrsOT2).value
url=url+"&ddlHrsHeadHolOT2="+document.getElementById(ddlHrsHeadHolOT2).value
url=url+"&chkHolRegActual="+document.getElementById(chkHolRegActual).checked
url=url+"&chkHolOTActual="+document.getElementById(chkHolOTActual).checked
url=url+"&chkWeekOff="+document.getElementById(chkWeekOff).checked
url=url+"&chkTimeBasedWo="+document.getElementById(chkTimeBasedWo).checked
url=url+"&chkWOOT1="+document.getElementById(chkWOOT1).checked
url=url+"&chkWOOT2="+document.getElementById(chkWOOT2).checked
url=url+"&txtWORegHrsNotWork="+document.getElementById(txtWORegHrsNotWork).value
url=url+"&ddlWORegHrsNotWork="+document.getElementById(ddlWORegHrsNotWork).value
url=url+"&txtWORegHrsWork="+document.getElementById(txtWORegHrsWork).value
url=url+"&ddlWORegHrsWork="+document.getElementById(ddlWORegHrsWork).value
url=url+"&txtWOOTHrsAfter="+document.getElementById(txtWOOTHrsAfter).value
url=url+"&ddlWOOTHrsAfter="+document.getElementById(ddlWOOTHrsAfter).value
url=url+"&txtWOAddOTHrsAfter="+document.getElementById(txtWOAddOTHrsAfter).value
url=url+"&ddlWOAddOTHrsAfter="+document.getElementById(ddlWOAddOTHrsAfter).value
url=url+"&txtMinDutyHrsWOOT1="+document.getElementById(txtMinDutyHrsWOOT1).value
url=url+"&ddlWOHrsHeadOT1="+document.getElementById(ddlWOHrsHeadOT1).value
url=url+"&txtMinDutyHrsWOOT2="+document.getElementById(txtMinDutyHrsWOOT2).value
url=url+"&ddlWOHrsHeadOT2="+document.getElementById(ddlWOHrsHeadOT2).value
url=url+"&chkWORegHrsActual="+document.getElementById(chkWORegHrsActual).checked
url=url+"&chkWOOTHrsActual="+document.getElementById(chkWOOTHrsActual).checked
url=url+"&chkLeave="+document.getElementById(chkLeave).checked
 HttpSaveBR1.onreadystatechange=stateSaveBR1;

 HttpSaveBR1.open("POST",url,true)
 HttpSaveBR1.setRequestHeader("Content-Type", "application/x-www-form-urlencoded" )
 HttpSaveBR1.send(null)

}

function stateSaveBR1()
{   
    if (HttpSaveBR1.readyState==4 || HttpSaveBR1.readyState=="complete")
	{
		
	}
}

function onClickInsertPayRate2(CompanyCode,
txtPayRateCode,
txtPayRateDesc,
chkEmpReligion,
ddlReligion,
chkNationality,
ddlNationality,
chkJobType,
ddlJobType,
chkJobClass,
ddlJobClass,
chkCategory,
ddlCategory,
chkDesignation,
ddlDesignation,
chkDepartment,
ddlDepartment,
chkGender,
ddlGender,
chkException,
chkTimeBasedException,
chkEXOT1,
chkEXOT2,
txtPeriodFrom,
txtPeriodTo,
txtMinExceptDutyHrs,
txtExpRegHrs,
ddlExpRegHrs,
txtExpOTHrs,
ddlExpOTHrs,
txtExpAddOTHrs,
ddlExpAddOTHrs,
txtDutyHrsEXOT1,
ddlEXOT1HrsHead,
txtDutyHrsEXOT2,
ddlEXOT2HrsHead
)
{

HttpSaveBR2=GetXmlHttpObject()

if (HttpSaveBR2==null)
{
alert ("Browser does not support HTTP Request")
return
}
var url="BusinessRuleInsertPayRate2Ajax.aspx"
url=url+"?CompanyCode="+CompanyCode
url=url+"&txtPayRateCode="+document.getElementById(txtPayRateCode).value
url=url+"&txtPayRateDesc="+document.getElementById(txtPayRateDesc).value
url=url+"&chkEmpReligion="+document.getElementById(chkEmpReligion).checked
url=url+"&ddlReligion="+document.getElementById(ddlReligion).value
url=url+"&chkNationality="+document.getElementById(chkNationality).checked
url=url+"&ddlNationality="+document.getElementById(ddlNationality).value
url=url+"&chkJobType="+document.getElementById(chkJobType).checked
url=url+"&ddlJobType="+document.getElementById(ddlJobType).value
url=url+"&chkJobClass="+document.getElementById(chkJobClass).checked
url=url+"&ddlJobClass="+document.getElementById(ddlJobClass).value
url=url+"&chkCategory="+document.getElementById(chkCategory).checked
url=url+"&ddlCategory="+document.getElementById(ddlCategory).value
url=url+"&chkDesignation="+document.getElementById(chkDesignation).checked
url=url+"&ddlDesignation="+document.getElementById(ddlDesignation).value
url=url+"&chkDepartment="+document.getElementById(chkDepartment).checked
url=url+"&ddlDepartment="+document.getElementById(ddlDepartment).value
url=url+"&chkGender="+document.getElementById(chkGender).checked
url=url+"&ddlGender="+document.getElementById(ddlGender).value
url=url+"&chkException="+document.getElementById(chkException).checked
url=url+"&chkTimeBasedException="+document.getElementById(chkTimeBasedException).checked
url=url+"&chkEXOT1="+document.getElementById(chkEXOT1).checked
url=url+"&chkEXOT2="+document.getElementById(chkEXOT2).checked
url=url+"&txtPeriodFrom="+document.getElementById(txtPeriodFrom).value
url=url+"&txtPeriodTo="+document.getElementById(txtPeriodTo).value
url=url+"&txtMinExceptDutyHrs="+document.getElementById(txtMinExceptDutyHrs).value
url=url+"&txtExpRegHrs="+document.getElementById(txtExpRegHrs).value
url=url+"&ddlExpRegHrs="+document.getElementById(ddlExpRegHrs).value
url=url+"&txtExpOTHrs="+document.getElementById(txtExpOTHrs).value
url=url+"&ddlExpOTHrs="+document.getElementById(ddlExpOTHrs).value
url=url+"&txtExpAddOTHrs="+document.getElementById(txtExpAddOTHrs).value
url=url+"&ddlExpAddOTHrs="+document.getElementById(ddlExpAddOTHrs).value
url=url+"&txtDutyHrsEXOT1="+document.getElementById(txtDutyHrsEXOT1).value
url=url+"&ddlEXOT1HrsHead="+document.getElementById(ddlEXOT1HrsHead).value
url=url+"&txtDutyHrsEXOT2="+document.getElementById(txtDutyHrsEXOT2).value
url=url+"&ddlEXOT2HrsHead="+document.getElementById(ddlEXOT2HrsHead).value

 HttpSaveBR2.onreadystatechange=stateSaveBR2;

 HttpSaveBR2.open("POST",url,true)
 HttpSaveBR2.setRequestHeader("Content-Type", "application/x-www-form-urlencoded" )
 HttpSaveBR2.send(null)

}
function stateSaveBR2()
{ 
    if (HttpSaveBR2.readyState==4 || HttpSaveBR2.readyState=="complete")
	{
		
	}
}
function GetXmlHttpObject()
{ 
var objXMLHttp=null
if (window.XMLHttpRequest)
{
objXMLHttp=new XMLHttpRequest()
}
else if (window.ActiveXObject)
{
objXMLHttp=new ActiveXObject("Microsoft.XMLHTTP")
}
return objXMLHttp
}