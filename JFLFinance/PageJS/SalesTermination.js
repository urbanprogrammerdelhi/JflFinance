var currentLoadingPanel = null;
var currentUpdatedControl = null;

function RequestStart(sender, args) {
    var a = new ControlInitializer();
    currentLoadingPanel = $(a.currentLoadingPanel);
    currentUpdatedControl = $(a.currentUpdatedControl);
    currentLoadingPanel.show(currentUpdatedControl);
}
function ResponseEnd() {
    if (currentLoadingPanel !== null) currentLoadingPanel.hide(currentUpdatedControl);
    currentUpdatedControl = null;
    currentLoadingPanel = null;
}
function OpenRadWindow(checked, status) {
    var a = new ControlInitializer();
    a.SaveButtonText.value = status;
    if (checked === true) {
        CloseRadPopUp();
    } else {
        a.RadWindow.show();

    }
}
function OpenRadWindowForSingleEntry(obj) {
    var a = new ControlInitializer();
    OpenRadWindow(document.getElementById(obj).checked, 'Single');
}
function OpenRadWindowForBulkEntry(obj) {
    var a = new ControlInitializer();
    OpenRadWindow(false, 'Bulk');
}
function CloseRadPopUp() {
    var a = new ControlInitializer();
    if (a.txtTerminationReason.value.length > 0 && a.txtWithEffectiveDate.value.length > 0){
        a.RadWindow.Close();
    }
    //alert(a.txtTerminationReason.value.length + a.txtWithEffectiveDate.value.length);
}
function ClosePopUp(sender, eventArgs) {
    var a = new ControlInitializer();
    //if ((a.clicks) === "Single") {
        (a.gv.click());
    //}
    a.RadWindow.Close();
    //CloseRadPopUp();
}
function CloseRadWindow(sender, eventArgs) {
    var a = new ControlInitializer();
    if ((a.clicks) === "Single") {
        (a.gv.click());
    }
    ClosePopUp(sender, eventArgs);

}
function Count(Object, Num) {
    var a = new ControlInitializer();
    var len = a.txtTerminationReason.value.trim().length;
    a.txtTerminationReason.value = a.txtTerminationReason.value.substring(0, maxlength);
    var maxlength = Num;
    if (len > maxlength) {
        a.txtTerminationReason.value = a.txtTerminationReason.value.substring(0, maxlength);
        var CheckBoxMessage = confirm("Limit exceeded");
    }
}
function showRowID(rowid, pageIndex, pageSize) {
    var a = new ControlInitializer();
    a.RI.value = rowid;
    if (pageIndex > 0) {
        var sumPageSi = (pageSize * pageIndex);
        var rowPageI = sumPageSi + rowid;
        a.RI.value = rowPageI;
    }
}