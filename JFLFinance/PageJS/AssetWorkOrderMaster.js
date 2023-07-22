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
function OpenWOServiceLineDept(strLocationAutoId, strAssetWoNo, strAssetWoAmendNo, strAssetWoLineNo, strWoStatus, strIsMaxAssetWoAmendNo, strIsActive) {
    window.showModalDialog('../Sales/AssetWorkOrderLineDept.aspx?LocationAutoID=' + strLocationAutoId + '&AssetWoNo=' + strAssetWoNo + '&AssetWoAmendNo=' + strAssetWoAmendNo + '&AssetWOLineNo=' + strAssetWoLineNo + '&WOStatus=' + strWoStatus + '&IsMAXAssetWOAmendNo=' + strIsMaxAssetWoAmendNo + '&IsActive=' + strIsActive, null, 'status:off;center:yes;scroll:no;dialogWidth:1250px;dialogheight:600px;help:no;');
}
function OpenWOSkills(strLocationAutoId, strAssetWoNo, strAssetWoAmendNo, strAssetWoLineNo, strWoStatus, strIsMaxAssetWoAmendNo, strIsActive) {
    window.showModalDialog('../Sales/AssetWorkOrderLineSkillSet.aspx?LocationAutoID=' + strLocationAutoId + '&AssetWoNo=' + strAssetWoNo + '&AssetWOAmendNO=' + strAssetWoAmendNo + '&AssetWOLineNo=' + strAssetWoLineNo + '&WOStatus=' + strWoStatus + '&IsMAXAssetWOAmendNo=' + strIsMaxAssetWoAmendNo + '&IsActive=' + strIsActive, null, 'status:off;center:yes;scroll:no;dialogWidth:1200px;dialogheight:600px;help:no;');
}
function ParentWindowFunction() {
    var a = new ControlInitializer();
    $(a.btnLoadParentPage).click();

}

