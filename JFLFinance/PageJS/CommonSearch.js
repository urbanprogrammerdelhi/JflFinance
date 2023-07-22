function ReturnVal(ReturnVal, ReturnVal2, ContrlId, ContrlId2) {
    if (window.opener.document.getElementById(ContrlId).type.indexOf('select') != -1 )
{
    window.opener.document.getElementById(ContrlId).value = ReturnVal;
    window.opener.__doPostBack(ContrlId,"");
}
else 
{
    window.opener.document.getElementById(ContrlId).innerText = ReturnVal;
}
if(ContrlId2 != '')
{
    if (window.opener.document.getElementById(ContrlId2).type.indexOf('select') != -1 )
    {
        window.opener.document.getElementById(ContrlId2).value = ReturnVal2;
        window.opener.__doPostBack(ContrlId2,"");
    }
    else 
    {
        window.opener.document.getElementById(ContrlId2).innerText = ReturnVal2;   
    }
}
window.opener.document.getElementById(ContrlId).focus();
window.close();
}
