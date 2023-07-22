

function HideButton(object) {
    $(object.id).css('display') == 'none'

}
function OpenPostCreation(strLocationAutoId, strClientCode, strAsmtId) {

    var backBtnVisible = false;
    var add = "Add";
    var pageName = "../Sales/ClientAsmtPost.aspx?LocationAutoID=" + strLocationAutoId + "&ClientCode=" + strClientCode + "&AsmtId=" + strAsmtId + "&BackBtnVisible=" + backBtnVisible + "&AddPost=" + add;
    var winW = 950;
    var winH = 500;
    var winX = (screen.availWidth - winW) / 2;
    var winY = (screen.availHeight - winH) / 2;
    var features = 'left=' + winX + ',top=' + winY + ',height=' + winH + ',' + 'width=' + winW + ',status=yes,' + 'toolbar=no,menubar=no,location=no';
    window.open(pageName, 'Search', features);

}
function OpenSODeploymentPattern(strLocationAutoId, strSoNo, strSoAmendNo, strSoLineNo, strSoStatus, strIsMaxsoAmendNo, strHours, strNoOfPost, strChargeRatePerHrs, strPayRatePerHrs, strOtherAllowances, strIsAllowanceBillable, strRemainingDays, strBillingPattern, strChecked, strBillable, strPayRateType) {
    window.showModalDialog('../Sales/SOLineDeptShifts.aspx?LocationAutoID=' + strLocationAutoId + '&SoNo=' + strSoNo + '&SOAmendNO=' + strSoAmendNo + '&SOLineNo=' + strSoLineNo + '&SOStatus=' + strSoStatus + '&IsMAXSOAmendNo=' + strIsMaxsoAmendNo + '&Hours=' + strHours + '&NoOfPost=' + strNoOfPost + '&ChargeRatePerHrs=' + strChargeRatePerHrs + '&PayRatePerHrs=' + strPayRatePerHrs + '&OtherAllowances=' + strOtherAllowances + '&IsAllowanceBillable=' + strIsAllowanceBillable + '&RemainingDays=' + strRemainingDays + '&BillingPattern=' + strBillingPattern + '&Checked=' + strChecked + '&IsBillable=' + strBillable + '&PayRateType=' + strPayRateType, null, 'status:off;center:yes;scroll:no;dialogWidth:1250px;dialogheight:600px;help:no;');
}
function OpenSOSkills(strLocationAutoId, strSoNo, strSoAmendNo, strSoLineNo, strSoStatus, strIsMaxsoAmendNo, strChecked) {
    window.showModalDialog('../Sales/SOLineSkillSet.aspx?LocationAutoID=' + strLocationAutoId + '&SoNo=' + strSoNo + '&SOAmendNO=' + strSoAmendNo + '&SOLineNo=' + strSoLineNo + '&SOStatus=' + strSoStatus + '&IsMAXSOAmendNo=' + strIsMaxsoAmendNo + '&Checked=' + strChecked, null, 'status:off;center:yes;scroll:no;dialogWidth:1200px;dialogheight:600px;help:no;');
}
function ParentWindowFunction() {
    var a = new ControlInitializer();
    $(a.btnLoadParentPage).click();
    
}

