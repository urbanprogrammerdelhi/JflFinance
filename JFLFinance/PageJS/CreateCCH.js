function getReturnFieldName(el, fldName) {
var a = new ControlInitializer();
    if (el == '1') {
        a.txtReturnFld.value = fldName;
    }
    else {
        a.txtReturnFld2.value = fldName;
    }
}
function opensearch() {

    var PageName = "commonSearch.aspx?SearchId=CCH01&ControlId=" + '<% =txtSearchCode.ClientID %>' + "&company=G4FLKGRD&HrLocation=&Location=";
    window.open(PageName, null, 'status=off,center=yes,scrollbars=0,resizeable=1,Width=720px,Height=380px,help=no');
}