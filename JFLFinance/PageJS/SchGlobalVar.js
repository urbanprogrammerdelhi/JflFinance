/*
    This file contains golobal variables and common functions only used in scheduling screen    
*/


var GlobEmployeeNumber;
var globBorrowedEmployeeStatus;
var GlobEmployeeName;
var GlobEmployeeDesgDesc;
var GlobEmployeeDesgCode;
var GlobEmployeeDutyDate;
var GlobEmployeeTimeFrom;
var GlobEmployeeTimeTo;
var GlobEmployeeSchRosterAutoID;
var GlobEmployeeShiftCode;
var GlobEmployeeDetails;
var GlobColumnType;
var GlobPatternPosition;
var GlobShiftPatternCode;
var GlobOverwriteStatus;
var GlobStrCopyRange;
var GlobRowNumber;
var GlobObject;
var globCopyStatus; // If Insert Key is pressed this will have "1" as its value otherwise "0" as its value
var GlobalOldObject;
var globalClientCode;
var globalAsmtId;
var globalPostCode;
var ddlAttendanceType;
var ddlScheduleType;
var ddlPostSearch;
var ddlMonth;
var txtYear;
var ddlWeek;
var ddlArea;
var ddlClient;
var ddAssignment;
var ddlPost;
var btnProceed;
var connectionKeyValue;
var VariableIntializer;
var ControlIntializer;
var globArea;
var GlobKeyCode;
var tmpGlobObject;
var GlobalOldShiftPatternObject;
var GlobSavedEmployeeNumber;
var globPost = "";
var oldTextAry = new Array();
var dutyReplacementAutoID;
var refreshStatus = "";
var updateshiftPatternSeq = "";

function InitalizeControlsAndVariables(objControlIntializer, objVariableIntializer) {

    VariableIntializer = objVariableIntializer;
    ControlIntializer = objControlIntializer;
    ddlMonth = objControlIntializer.ddlMonth;
    ddlWeek = objControlIntializer.ddlWeek;
    txtYear = objControlIntializer.txtYear;
    ddlArea = objControlIntializer.ddlArea;
    ddlClient = objControlIntializer.ddlClient;
    ddAssignment = objControlIntializer.ddAssignment;
    ddlPost = objControlIntializer.ddlPost;
    btnProceed = objControlIntializer.btnProceed;
    ddlAttendanceType = objControlIntializer.ddlAttendanceType;
    ddlScheduleType = objControlIntializer.ddlScheduleType;
    ddlPostSearch = objControlIntializer.ddlPostSearch;
}

function InitalizeControls() {
    var objControls = new window.ControlsInitialization();
    ControlIntializer = objControls;
}


//=======================================
//Function To Change The Date Fromat
//=======================================
function DateInFormat(str) {
    if (str == "") {
        return str;
    }
    else {
        var arr = str.split("-");
        var strMonthName;
        var strDay, strYear;

        strMonthName = arr[1];
        strDay = arr[0];
        strYear = arr[2];

        var dateReturn;

        if (strMonthName.toUpperCase() == VariableIntializer.January.toUpperCase() || strMonthName.toUpperCase() == "JAN" || strMonthName.toUpperCase() == VariableIntializer.January.substring(0, 3).toUpperCase()) {
            if (strDay > 31) {
                strDay = 1;
                dateReturn = strDay + "-FEB-" + strYear;
            }
            else {
                dateReturn = strDay + "-JAN-" + strYear;
            }

        }
        else if (strMonthName.toUpperCase() == VariableIntializer.February.toUpperCase() || strMonthName.toUpperCase() == "FEB" || strMonthName.toUpperCase() == VariableIntializer.February.substring(0, 3).toUpperCase()) {
            if (strDay > 28) {
                strDay = 1;
                dateReturn = strDay + "-MAR-" + strYear;
            }
            else {
                dateReturn = strDay + "-FEB-" + strYear;
            }
        }
        else if (strMonthName.toUpperCase() == VariableIntializer.March.toUpperCase() || strMonthName.toUpperCase() == "MAR" || strMonthName.toUpperCase() == VariableIntializer.March.substring(0, 3).toUpperCase()) {
            if (strDay > 31) {
                strDay = 1;
                dateReturn = strDay + "-APR-" + strYear;
            }
            else {
                dateReturn = strDay + "-MAR-" + strYear;
            }

        }
        else if (strMonthName.toUpperCase() == VariableIntializer.April.toUpperCase() || strMonthName.toUpperCase() == "APR" || strMonthName.toUpperCase() == VariableIntializer.April.substring(0, 3).toUpperCase()) {
            if (strDay > 30) {
                strDay = 1;
                dateReturn = strDay + "-MAY-" + strYear;
            }
            else {
                dateReturn = strDay + "-APR-" + strYear;
            }
        }
        else if (strMonthName.toUpperCase() == VariableIntializer.May.toUpperCase() || strMonthName.toUpperCase() == "MAY" || strMonthName.toUpperCase() == VariableIntializer.May.substring(0, 3).toUpperCase()) {
            if (strDay > 31) {
                strDay = 1;
                dateReturn = strDay + "-JUN-" + strYear;
            }
            else {
                dateReturn = strDay + "-MAY-" + strYear;
            }
        }
        else if (strMonthName.toUpperCase() == VariableIntializer.June.toUpperCase() || strMonthName.toUpperCase() == "JUN" || strMonthName.toUpperCase() == VariableIntializer.June.substring(0, 3).toUpperCase()) {
            if (strDay > 30) {
                strDay = 1;
                dateReturn = strDay + "-JUL-" + strYear;
            }
            else {
                dateReturn = strDay + "-JUN-" + strYear;
            }
        }
        else if (strMonthName.toUpperCase() == VariableIntializer.July.toUpperCase() || strMonthName.toUpperCase() == "JUL" || strMonthName.toUpperCase() == VariableIntializer.July.substring(0, 3).toUpperCase()) {
            if (strDay > 31) {
                strDay = 1;
                dateReturn = strDay + "-AUG-" + strYear;
            }
            else {
                dateReturn = strDay + "-JUL-" + strYear;
            }
        }
        else if (strMonthName.toUpperCase() == VariableIntializer.August.toUpperCase() || strMonthName.toUpperCase() == "AUG" || strMonthName.toUpperCase() == VariableIntializer.August.substring(0, 3).toUpperCase()) {
            if (strDay > 31) {
                strDay = 1;
                dateReturn = strDay + "-SEP-" + strYear;
            }
            else {
                dateReturn = strDay + "-AUG-" + strYear;
            }
        }
        else if (strMonthName.toUpperCase() == VariableIntializer.September.toUpperCase() || strMonthName.toUpperCase() == "SEP" || strMonthName.toUpperCase() == VariableIntializer.September.substring(0, 3).toUpperCase()) {
            if (strDay > 30) {
                strDay = 1;
                dateReturn = strDay + "-OCT-" + strYear;
            }
            else {
                dateReturn = strDay + "-SEP-" + strYear;
            }
        }
        else if (strMonthName.toUpperCase() == VariableIntializer.October.toUpperCase() || strMonthName.toUpperCase() == "OCT" || strMonthName.toUpperCase() == VariableIntializer.October.substring(0, 3).toUpperCase()) {
            if (strDay > 31) {
                strDay = 1;
                dateReturn = strDay + "-NOV-" + strYear;
            }
            else {
                dateReturn = strDay + "-OCT-" + strYear;
            }
        }
        else if (strMonthName.toUpperCase() == VariableIntializer.November.toUpperCase() || strMonthName.toUpperCase() == "NOV" || strMonthName.toUpperCase() == VariableIntializer.November.substring(0, 3).toUpperCase()) {
            if (strDay > 30) {
                strDay = 1;
                dateReturn = strDay + "-DEC-" + strYear;
            }
            else {
                dateReturn = strDay + "-NOV-" + strYear;
            }
        }
        else if (strMonthName.toUpperCase() == VariableIntializer.December.toUpperCase() || strMonthName.toUpperCase() == "DEC" || strMonthName.toUpperCase() == VariableIntializer.December.substring(0, 3).toUpperCase()) {
            if (strDay > 31) {
                strDay = 1;
                dateReturn = strDay + "-JAN-" + strYear;
            }
            else {
                dateReturn = strDay + "-DEC-" + strYear;
            }
        }

        return dateReturn;

    }
}

function DisableEnterKey(sender, eventArgs) {
    $(document).ready(function () {
        var key = eventArgs.get_keyCode();
        if (key && key == 13)
            eventArgs.set_cancel(true);
    });
}

function CloseAdjustment() {
    ControlIntializer.divAdjustment.style.display = "none";
}

function CloseDutyReplacement() {
    ControlIntializer.divDutyReplacement.style.display = "none";
}

// This function Hids all DIVS 
function HideDivs() {
    if (ControlIntializer.divShift == "[object]") {
        if (ControlIntializer.divShift.style.display != "none") {
            ControlIntializer.divShift.style.display = "none";
        }
    }

    if (ControlIntializer.divEmployeeContainer == "[object]") {
        if (ControlIntializer.divEmployeeContainer.style.display != "none") {
            ControlIntializer.divEmployeeContainer.style.display = "none";
        }
    }
    if (ControlIntializer.DivShiftPatterns == "[object]") {
        if (ControlIntializer.DivShiftPatterns.style.display != "none") {
            ControlIntializer.DivShiftPatterns.style.display = "none";
        }
    }

    if (ControlIntializer.divEmployeeList == "[object]") {
        if (ControlIntializer.divEmployeeList.style.display != "none") {
            ControlIntializer.divEmployeeList.style.display = "none";
        }
    }

}

//=======================================
// Find The position to display the dropdown
//=======================================
function findPos(obj) {
    var curtop;
    var curleft = curtop = 0;
    try {
        if (obj.offsetParent) {
            curleft = obj.offsetLeft;
            curtop = obj.offsetTop;
            while (obj = obj.offsetParent) {
                curleft += obj.offsetLeft;
                curtop += obj.offsetTop;
            }
        }
        return [curleft, curtop];
    }
    catch (error) { return; }
}
//============================
//Function Used to Get The Client ID Of Control
//=======================================

function getClientId(obj, cId) {
    var arr = new Array;
    var clId = "";  // clientId
    arr = obj.id.split("_");
    for (var i = 0; i < arr.length - 1; i++) {
        clId = clId + arr[i] + "_";
    }
    clId = clId + cId;
    return clId;
}

//=======================================
//Function Used To Validate Time
//=======================================
function IsValidTime(obj, txtBoxType) {
    var columnIndex;
    var strReversedString = obj.id.split('').reverse().join('');
    columnIndex = strReversedString.substring(0, 2);
    if (isNaN(columnIndex)) {
        columnIndex = strReversedString.substring(0, 1);
    }
    else {
        columnIndex = columnIndex.toString().split('').reverse().join('');
    }
    var strTime;
    if (txtBoxType == 'T') {
        strTime = "txtTimeTo" + columnIndex;
    }
    else {
        strTime = "txtTimeFrom" + columnIndex;
    }
    var timeStr = getClientId(obj, strTime);
    var timePat = /^(\d{2}):(\d{2})$/;
    var matchArray;
    var hour;
    var minute;
    if (document.getElementById(timeStr).value.length == 4 && document.getElementById(timeStr).value.charAt(2) != ":" && document.getElementById(timeStr).value.charAt(3) != ":") {
        document.getElementById(timeStr).value = document.getElementById(timeStr).value.substring(0, 2) + ":" + document.getElementById(timeStr).value.substring(2, 4);
        if (document.getElementById(timeStr).value != "") {
            matchArray = document.getElementById(timeStr).value.match(timePat);
            if (matchArray == null) {
                alert(VariableIntializer.TimeisNotInValidFormat);
                document.getElementById(timeStr).value = "";
                document.getElementById(timeStr).focus();
                return false;
            }
            hour = matchArray[1];
            minute = matchArray[2];

            if (hour < 0 || hour > 23) {
                alert(VariableIntializer.HourMustBeBetween0And23);
                document.getElementById(timeStr).value = "";
                document.getElementById(timeStr).focus();
                return false;
            }
            if (minute < 0 || minute > 59) {
                alert(VariableIntializer.MinuteMustBeBetween0And59);
                document.getElementById(timeStr).value = "";
                document.getElementById(timeStr).focus();
                return false;
            }
        }
        if (document.getElementById(timeStr).value == "") {
            document.getElementById(timeStr).value = "00:00";
            return true;
        }
        return true;
    }
    if (document.getElementById(timeStr).value.charAt(1) != ":" && document.getElementById(timeStr).value.charAt(2) != ":") {
        if (document.getElementById(timeStr).value.length == 1) {
            document.getElementById(timeStr).value = "0" + document.getElementById(timeStr).value + ":00";
            return true;
        }
        if (document.getElementById(timeStr).value.length == 2 && document.getElementById(timeStr).value < 24) {
            document.getElementById(timeStr).value = document.getElementById(timeStr).value + ":00";
            return true;
        }
    }

    if (document.getElementById(timeStr).value != "") {
        matchArray = document.getElementById(timeStr).value.match(timePat);
        if (matchArray == null) {
            alert(VariableIntializer.TimeisNotInValidFormat);
            document.getElementById(timeStr).value = "";
            document.getElementById(timeStr).focus();
            return false;
        }
        hour = matchArray[1];
        minute = matchArray[2];

        if (hour < 0 || hour > 23) {
            alert(VariableIntializer.HourMustBeBetween0And23);
            document.getElementById(timeStr).value = "";
            document.getElementById(timeStr).focus();
            return false;
        }
        if (minute < 0 || minute > 59) {
            alert(VariableIntializer.MinuteMustBeBetween0And59);
            document.getElementById(timeStr).value = "";
            document.getElementById(timeStr).focus();
            return false;
        }
    }
    if (document.getElementById(timeStr).value == "") {
        document.getElementById(timeStr).value = "00:00";
        return true;
    }
    return true;
}


function EnableProceedButton() {
    GlobalOldShiftPatternObject = "";
    InitalizeControls();
    $(document).ready(function () {
        window.EnableProceedButtonJS();
        if (ControlIntializer.gvScheduleRoster == '[object]') {
            ControlIntializer.gvScheduleRoster.style.display = 'none';
        }
    });
}

function EnableProceedAndClick() {
    InitalizeControls();
    ControlIntializer.btnProceed.set_enabled(true);
   // btnProceed.set_enabled(true);
    ControlIntializer.btnProceed.click();
}

function DisableProceedButton() {
    GlobalOldShiftPatternObject = "";
    InitalizeControls();
    $(document).ready(function () {
        if (ControlIntializer.gvScheduleRoster == '[object]') {

            ControlIntializer.gvScheduleRoster.style.display = 'none';
        }
        try {
            ControlIntializer.btnProceed.set_enabled(false);
        }
        catch (error) { }
    });
}

function changeText(fieldObj, newTexStr) {
    if (newTexStr == fieldObj.innerHTML) {
        fieldObj.innerHTML = oldTextAry[fieldObj.id];
    } else {
        oldTextAry[fieldObj.id] = fieldObj.innerHTML;
        fieldObj.innerHTML = newTexStr;
    }
}


// this function is called when user clicks on the column of the gridview to get the COLUMNID of the gridview
function GetColumnIndexOnMouseClick(strColumnIndex) {

    ControlIntializer.MouseClickColumnID.value = "";
    ControlIntializer.MouseClickColumnID.value = strColumnIndex;
}
// this function is called when user clicks on the row of the gridview to get the RowID of the gridview
function GetRowIDOnMouseClick(strRowId) {
    ControlIntializer.MouseClickRowID.value = "";
    ControlIntializer.MouseClickRowID.value = strRowId;
}

function OnWSRequestFailed(error) {
    var errorMsg = "Error: " + error.responseText;
    alert(errorMsg);
}

function ClientAndAsmtWiseTotalHours() {
    GetEmployeeCountClientWiseAndpostWise();
}

function KeyPress(sender, eventArgs) {
    InitalizeControls();
    ControlIntializer.HFUnSchEmployeeClickStatus.value = "1";
}