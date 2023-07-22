function ReturnEmpNo(empVal, contrlId) {
    try {
        window.opener.document.getElementById(contrlId).value = empVal;
        window.opener.document.getElementById(contrlId).focus();
        window.close();
    }
    catch (error) { return; }
}