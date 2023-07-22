// JScript File
   var xmlHttpEmpAvailability;
   function EmpAvailabilityAjax(emp,Date1,Date2,strAttendanceType)
   { 
    xmlHttpEmpAvailability=GetXmlHttpObject()

    if (xmlHttpEmpAvailability==null)
    {
    alert ("Browser does not support HTTP Request")
    return
    }
    var url="getEmpAvailabilityAjax.aspx"
    url=url+"?EmpNo="+emp
    url=url+"&Date1="+Date1
    url = url + "&Date2=" + Date2
    url = url + "&AttendanceType=" + strAttendanceType
    xmlHttpEmpAvailability.onreadystatechange=stateChanged1;
    xmlHttpEmpAvailability.open("POST",url,true)
    xmlHttpEmpAvailability.setRequestHeader("Content-Type", "application/x-www-form-urlencoded" )
    xmlHttpEmpAvailability.send(null)
   
   }

  function stateChanged1()
    { 
        if (xmlHttpEmpAvailability.readyState==4 || xmlHttpEmpAvailability.readyState=="complete")
	    {  
	        var strXML=xmlHttpEmpAvailability.responseText
	        document.getElementById('empAvailabitiltStatus').innerHTML = xmlHttpEmpAvailability.responseText;
		   	    
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