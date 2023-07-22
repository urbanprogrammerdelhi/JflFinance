/*
This file contains javascript functions which are used called on right click action in scheduling screen.
*/


//// ************ Functions related to adjustment entries ********************************

function funcHoursAdjustment(ops) {
    InitalizeControls();
    $(document).ready(function () {
        var gvScheduleRoster = ControlIntializer.gvScheduleRoster;
        var columnIndex = parseInt(ControlIntializer.MouseClickColumnID.value) - 1;
        var rowClientId = gvScheduleRoster.rows[parseInt(ControlIntializer.MouseClickRowID.value) + 1].cells[0].childNodes[1];
        var strDutyDate = "lblHeaderDutyDate" + columnIndex;
        strDutyDate = document.getElementById('gvScheduleRoster_ctl01_' + strDutyDate).innerText;

        var schRosterAutoId = "HFSchRosterAutoID" + columnIndex;
        var strEmployee = "txtEmpNumberDutyDate"; //"HFOrgEmployeeNumber";
        strEmployee = document.getElementById(getClientId(rowClientId, strEmployee)).value;
        schRosterAutoId = document.getElementById(getClientId(rowClientId, schRosterAutoId)).value;

        var adjustmentHrs = ControlIntializer.txtAdjustmentHrs.value;
        var adjustmentType = ControlIntializer.AdjType.value;
        var adjustmentRemark = ControlIntializer.txtAdjustmentRemark.value;

        var post = ddlPost.get_selectedItem().get_value();
        if (strEmployee == "") {
            CloseAdjustment();
            return;
        }

        if (ops == "I") {
            if (adjustmentHrs == "00:00" || adjustmentHrs == "00.00" || strEmployee == "" || adjustmentHrs == "") {
                alert("Invalid Hours");
                return;
            }

            $.ajax({
                type: "POST",
                url: "../Webservices/WebMethods.asmx/AdjustmentHoursInsert",
                data: { connectionString: ControlIntializer.connectionKey.value, clientCode: ddlClient.get_selectedItem().get_value(), asmtId: ddAssignment.get_selectedItem().get_value(),
                    postCode: post, locationAutoId: VariableIntializer.SessionLocationAutoId, adjustmentDate: DateInFormat(strDutyDate), employeeNumber: strEmployee,
                    adjustmentFromDate: DateInFormat(strDutyDate), adjustmentHours: adjustmentHrs, adjustmentHead: adjustmentType, remark: adjustmentRemark,
                    modifiedBy: VariableIntializer.SessionUserId
                },
                ////contentType: "application/text; charset=utf-8",
                async: false,
                success: OnAdjustmentHoursSaved,
                error: OnWSRequestFailed
            });


        } else if (ops == "D") {
            if (adjustmentHrs == "00:00" || adjustmentHrs == "00.00") {
                alert("Invalid Hours");
                return;
            }

            $.ajax({
                type: "POST",
                url: "../Webservices/WebMethods.asmx/AdjustmentHoursDelete",
                data: { connectionString: ControlIntializer.connectionKey.value, clientCode: ddlClient.get_selectedItem().get_value(), asmtId: ddAssignment.get_selectedItem().get_value(),
                    postCode: post, adjustmentDate: DateInFormat(strDutyDate), employeeNumber: strEmployee
                },
                ////contentType: "application/text; charset=utf-8",
                async: false,
                success: OnAdjustmentHoursDeleted,
                error: OnWSRequestFailed
            });

        } else if (ops == "R") {
            var lblSelect = "lblSelect" + columnIndex;
            var lyr = ControlIntializer.divAdjustment;
            var coors = findPos(document.getElementById(getClientId(rowClientId, lblSelect)));
            lyr.style.top = coors[1] + 20 + 'px';
            lyr.style.left = coors[0] - 1 + 'px';

            $.ajax({
                type: "GET",
                url: "../Webservices/WebMethods.asmx/AdjustmentHoursGet",
                data: { connectionString: ControlIntializer.connectionKey.value, clientCode: ddlClient.get_selectedItem().get_value(), asmtId: ddAssignment.get_selectedItem().get_value(),
                    postCode: post, adjustmentDate: DateInFormat(strDutyDate), employeeNumber: strEmployee
                },
                contentType: "application/text; charset=utf-8",
                async: false,
                success: OnGetAdjustmentHours,
                error: OnWSRequestFailed
            });

        }
    });
}

function OnAdjustmentHoursDeleted(result) {
    CloseAdjustment();
    InitalizeControls();
    var gvScheduleRoster = ControlIntializer.gvScheduleRoster;
    var columnIndex = parseInt(ControlIntializer.MouseClickColumnID.value) - 1;
    var rowClientId = gvScheduleRoster.rows[parseInt(ControlIntializer.MouseClickRowID.value) + 1].cells[0].childNodes[1];

    var adjustmentImage = "adjustmentImage" + ControlIntializer.MouseClickRowID.value + (parseInt(columnIndex) + 1);
    document.getElementById(getClientId(rowClientId, adjustmentImage)).style.display = "none";

}

function OnAdjustmentHoursSaved(result) {
    InitalizeControls();
    var gvScheduleRoster = ControlIntializer.gvScheduleRoster;
    var columnIndex = parseInt(ControlIntializer.MouseClickColumnID.value) - 1;
    var rowClientId = gvScheduleRoster.rows[parseInt(ControlIntializer.MouseClickRowID.value) + 1].cells[0].childNodes[1];
    var adjustmentImage = "adjustmentImage" + ControlIntializer.MouseClickRowID.value + (parseInt(columnIndex) + 1);
    var arr = new Array;
    arr = result.documentElement.textContent.split("$");
    if (arr[0].toString() == "error") {
        alert(arr[1].toString());
        return;
    }
    try {
        document.getElementById(getClientId(rowClientId, adjustmentImage)).style.display = "block";
    } catch(error) {
    }
    CloseAdjustment();

}

function OnGetAdjustmentHours(result) {
    InitalizeControls();
    var xmlDoc = jQuery.parseXML(result.documentElement.textContent);

    if (xmlDoc && $(xmlDoc).find('AdjHeadCode').text().length > 0) {

        ControlIntializer.AdjType.value = $(xmlDoc).find('AdjHeadCode').text();
        ControlIntializer.txtAdjustmentHrs.value = $(xmlDoc).find('HrsAdjusted').text();
        if ($(xmlDoc).find('Remark').text() != null) {
            ControlIntializer.txtAdjustmentRemark.value = $(xmlDoc).find('Remark').text();
        }
        ControlIntializer.DeleteAdjustment.style.display = "block";
        ControlIntializer.SaveAdjustment.innerHTML = "Update";
    }
    else {
        ControlIntializer.txtAdjustmentHrs.value = "00:00";
        ControlIntializer.txtAdjustmentRemark.value = "";
        ControlIntializer.DeleteAdjustment.style.display = "none";
        ControlIntializer.SaveAdjustment.innerHTML = "Save";

    }
    ControlIntializer.divAdjustment.style.display = "block";

}

//// *************End Functions related to adjustment entries******************************

var GlobRightClickWeekOfClick;
var GlobRowNumber1;
//// This function is used to mark Week OFF when used right click on grid view and click Mark Week Off Option
function MarkWeekOff() {

    InitalizeControls();

    var gvScheduleRoster = ControlIntializer.gvScheduleRoster;
    var rowClientId = gvScheduleRoster.rows[parseInt(ControlIntializer.MouseClickRowID.value) + 1].cells[0].childNodes[1];
    var strRowNumber = "lblRowID";
    var strEmployee = "txtEmpNumberDutyDate";
    var strShiftPatternCode = "txtShiftPatternCode";
    var strPatternPosition = "txtPatternPosition";
    GlobShiftPatternCode = getClientId(rowClientId, strShiftPatternCode);
    GlobPatternPosition = getClientId(rowClientId, strPatternPosition);
    GlobEmployeeNumber = getClientId(rowClientId, strEmployee);
    var cellShiftPatternCode = document.getElementById(GlobShiftPatternCode).value;
    var cellPatternPosition = document.getElementById(GlobPatternPosition).value;
    var cellEmployeeNumber = document.getElementById(GlobEmployeeNumber).value;
    var cellRowNumber = document.getElementById(getClientId(rowClientId, strRowNumber)).innerText;
    GlobRowNumber = getClientId(rowClientId, strRowNumber);

    var cellDefaultSite;
    var columnIndex = parseInt(ControlIntializer.MouseClickColumnID.value) - 1;
    var strDutyDate = "lblHeaderDutyDate" + columnIndex;
    var dutyDate = 'gvScheduleRoster_ctl01_' + strDutyDate;
    var rowNumber = parseInt(ControlIntializer.MouseClickRowID.value) + 1;
    if (gvScheduleRoster != null) {
        var cell = gvScheduleRoster.rows[rowNumber].cells;
        if (cell != null)
            try {
                if (cell[columnIndex].style.backgroundColor.toLowerCase() == "DeepSkyBlue".toLowerCase()) {
                    alert("Please Delete/Cancel leave.");
                    return;
                }
            }
            catch (error) { }
    }

    var strScheduleRosterAutoId = "HFSchRosterAutoID" + columnIndex;
    GlobEmployeeSchRosterAutoID = getClientId(rowClientId, strScheduleRosterAutoId);
    var cellRosterAutoId = document.getElementById(GlobEmployeeSchRosterAutoID).value;
    if (cellRosterAutoId == "") {
        cellRosterAutoId = "0";
    }
    var varDutyDate = document.getElementById(dutyDate).innerText;
    if (cellShiftPatternCode == "")
    { cellDefaultSite = "0"; }
    else
    { cellDefaultSite = "1"; }

    if (cellEmployeeNumber == "") {
        alert(VariableIntializer.InvalidEmpCode); 
        return; }

    GlobEmployeeShiftCode = "";
    GlobEmployeeTimeFrom = "";
    GlobEmployeeTimeTo = "";
    GlobEmployeeDetails = "";

    // 
    var strScreenType;
    if (ddlAttendanceType.get_selectedItem().get_value() == 'Act') {

        strScreenType = 'ACT';
    } else {
        strScreenType = 'SCH';
    }

    GlobRightClickWeekOfClick = 1;
    ControlIntializer.HFRowIndex.value = "";
    $.ajax({
        type: "POST",
        url: "../Webservices/WebMethods.asmx/GetEmployeeDetail",
        data: { connectionString: ControlIntializer.connectionKey.value, employeeNumber: cellEmployeeNumber, clientCode: ddlClient.get_selectedItem().get_value(),
            asmtId: ddAssignment.get_selectedItem().get_value(), fromDate: DateInFormat(varDutyDate), toDate: DateInFormat(varDutyDate),
            postCode: ddlPost.get_selectedItem().get_value(), insertStatus: "SINGLE", areaId: ddlArea.get_selectedItem().get_value(),
            areaInchargeNumber: VariableIntializer.SessionAreaInchargeNumber, isAreaIncharge: VariableIntializer.IsAreaIncharge, screenType: strScreenType,
            companyCode: VariableIntializer.SessionCompanyCode, hrLocationCode: VariableIntializer.SessionHrLocationCode,
            locationAutoId: VariableIntializer.SessionLocationAutoId, modifiedBy: VariableIntializer.SessionUserId
        },
        /// contentType: "application/text; charset=utf-8",
        async: false,
        success: OnGetEmployeeDetailComplete,
        error: OnWSRequestFailed
    });



}

function OnAppliedWO(result) {
    var xmlDoc1 = loadXMLString(result);
    if (xmlDoc1.getElementsByTagName("MessageID")[0].childNodes[0].nodeValue == "1") {
        alert(xmlDoc1.getElementsByTagName("MessageDesc")[0].childNodes[0].nodeValue);
    }
    else if (xmlDoc1.getElementsByTagName("MessageID")[0].childNodes[0].nodeValue == "3") {

        alert(xmlDoc1.getElementsByTagName("MessageDesc")[0].childNodes[0].nodeValue);
    }
    else if (xmlDoc1.getElementsByTagName("MessageID")[0].childNodes[0].nodeValue == "4") {
        alert(xmlDoc1.getElementsByTagName("MessageDesc")[0].childNodes[0].nodeValue);
    }

    else {
        EnableProceedAndClick();
    }
}

//// *************End Functions related to Weekly Off entries******************************


//// ***** This function is called when user right click and cclick on various duty type *******
function ChangeDutyType(strDutyType) {

    InitalizeControls();
    var strEmployee = "txtEmpNumberDutyDate";
    var gvScheduleRoster = ControlIntializer.gvScheduleRoster;
    var rowClientId = gvScheduleRoster.rows[parseInt(ControlIntializer.MouseClickRowID.value) + 1].cells[0].childNodes[1];
    var cellEmployeeNumber = document.getElementById(getClientId(rowClientId, strEmployee)).value;
    var columnIndex = parseInt(ControlIntializer.MouseClickColumnID.value) - 1;
    var schRosterAutoId = "HFSchRosterAutoID" + columnIndex;
    var cellScheduleRosterAutoId = document.getElementById(getClientId(rowClientId, schRosterAutoId)).value;
    var strShiftCode = "txtEmpShiftDutyDate" + columnIndex;
    if (cellEmployeeNumber == "")
    { alert(VariableIntializer.InvalidEmpCode); return; }

    //Added SAT#036
//    if (ControlIntializer.HFSOBillable.value == "False") {
//        alert(VariableIntializer.MsgComplimentaryDutyTypeCannotChanged);
//        return;
//    }
    //End

    if (ddlAttendanceType.get_selectedItem().get_value() == 'Act' && ControlIntializer.HFOTReason.value == '1' && strDutyType == "DT0009") {
        if (ControlIntializer.HFOTReason.value == '1' && strDutyType == "DT0009") {
            OTReason(strDutyType);
        }
    }
    else {
        if (document.getElementById(getClientId(rowClientId, strShiftCode)).value != "0") {
            if (cellScheduleRosterAutoId != "" && cellScheduleRosterAutoId != "0" && cellScheduleRosterAutoId != "0.00") {

                $(document).ready(function () {
                    $.ajax({
                        type: "POST",
                        url: "../Webservices/WebMethods.asmx/ChangeDutyType",
                        data: { strCon: ControlIntializer.connectionKey.value, strSchAutoId: cellScheduleRosterAutoId, strDutyType: strDutyType,
                            strAttendanceType: ddlAttendanceType.get_selectedItem().get_value(), strModifiedBy: VariableIntializer.SessionUserId, companyCode: VariableIntializer.SessionCompanyCode
                        },
                        ////contentType: "application/text; charset=utf-8",
                        async: false,
                        success: OnDutyTypeChanged,
                        error: OnWSRequestFailed
                    });
                });

            }
        }
    }

}

function OnDutyTypeChanged(result) {
    var xmlDoc = jQuery.parseXML(result.documentElement.textContent);
    var grid = ControlIntializer.gvScheduleRoster;
    var columnIndex = parseInt(ControlIntializer.MouseClickColumnID.value) - 1;
    var rowClientId = parseInt(ControlIntializer.MouseClickRowID.value) + 1;

    if (grid != null) {
        var cell = grid.rows[rowClientId].cells;
        if (cell != null)
            try {
                cell[columnIndex].style.backgroundColor = $(xmlDoc).find('ColorCode').text();
            }
            catch (error) { }
    }
}

//// *************End Functions related change Duty Type ******************************


//// ******  This function is used to open JobBreakDownSummary Window *******************
function JobBreakDownSummary() {

    InitalizeControls();

    var columnIndex = parseInt(ControlIntializer.MouseClickColumnID.value) - 1;
    var schRosterAutoId = "HFSchRosterAutoID" + columnIndex;
    var gvScheduleRoster = ControlIntializer.gvScheduleRoster;
    var rowClientId = gvScheduleRoster.rows[parseInt(ControlIntializer.MouseClickRowID.value) + 1].cells[0].childNodes[1];
    var cellScheduleRosterAutoId = document.getElementById(getClientId(rowClientId, schRosterAutoId)).value;

    var strEmployee = "txtEmpNumberDutyDate";
    var employeeName = "txtEmpNameDutyDate";

    var strDutyDate = "lblHeaderDutyDate" + columnIndex;

    var strRowNumber = "lblRowID";

    var cellRowNumber = document.getElementById(getClientId(rowClientId, strRowNumber)).innerText;
    var cellEmployeeNumber = document.getElementById(getClientId(rowClientId, strEmployee)).value;
    var cellEmployeeName = document.getElementById(getClientId(rowClientId, employeeName)).value;
    var dutyDate = document.getElementById('gvScheduleRoster_ctl01_' + strDutyDate).innerText;

    var strShiftCode = "txtEmpShiftDutyDate" + columnIndex;
    var converted = 0;
    if (document.getElementById(getClientId(rowClientId, strShiftCode)).disabled == true) {
        converted = 1;
    }

    var clientCode = ddlClient.get_selectedItem().get_value();
    var asmtId = ddAssignment.get_selectedItem().get_value();
    var postCode = ddlPost.get_selectedItem().get_value();

    var clientName = ddlClient.get_selectedItem().get_value();
    var assignmentName = ddAssignment.get_selectedItem().get_value();
    var postDesc = ddlPost.get_selectedItem().get_value();
    refreshStatus = "1";

    var weekNo = ddlWeek.get_selectedItem().get_value();

    // ALLOWANCE PATCH STARTS

    if (ddlAttendanceType.get_selectedItem().get_value() == 'Act') {
        if (cellScheduleRosterAutoId == '0' || cellScheduleRosterAutoId == '') {
            cellScheduleRosterAutoId = '-1';
        }
    }

    // ALLOWANCE PATCH END
    if (cellEmployeeNumber == "")
    { alert(VariableIntializer.InvalidEmpCode); return; }
    if (cellScheduleRosterAutoId != '0' && cellScheduleRosterAutoId != '') {

        var strPageName = "../Transactions/JobBreakDownSummary.aspx?ScheduleRosterAutoID=" + cellScheduleRosterAutoId + "&AttendanceType=" + ddlAttendanceType.get_selectedItem().get_value() + "&AreaID=" + ddlArea.get_selectedItem().get_value() + "&FromDate=" + DateInFormat(ControlIntializer.HFFromDate.value) + "&ToDate=" + DateInFormat(ControlIntializer.HFToDate.value) + "&Converted=" + converted + "&ClientCode=" + clientCode + "&AsmtID=" + asmtId + "&PostCode=" + encodeURIComponent(postCode) + "&ClientName=" + encodeURIComponent(clientName) + "&AssignmentName=" + encodeURIComponent(assignmentName) + "&PostDesc=" + encodeURIComponent(postDesc) + "&WeekNo=" + weekNo + "&DutyDate=" + encodeURIComponent(DateInFormat(dutyDate)) + "&EmployeeName=" + encodeURIComponent(cellEmployeeName) + "&EmployeeNumber=" + encodeURIComponent(cellEmployeeNumber) + "&RowNumber=" + encodeURIComponent(cellRowNumber);
        var manager = ControlIntializer.RadWindowManager1;
        manager.open(strPageName, "RadWindow");

    }
}

function CloseJobBreakDown() {

    var radToolTipJobBreakDown = ControlIntializer.RadToolTipJobBreakDown;
    radToolTipJobBreakDown.hide();
}
function OTReason(dutyType) {

    InitalizeControls();

    var gvScheduleRoster = ControlIntializer.gvScheduleRoster;
    var rowClientId = gvScheduleRoster.rows[parseInt(ControlIntializer.MouseClickRowID.value) + 1].cells[0].childNodes[1];
    var columnIndex = parseInt(ControlIntializer.MouseClickColumnID.value) - 1;
    var schRosterAutoId = "HFSchRosterAutoID" + columnIndex;


    var cellScheduleRosterAutoId = document.getElementById(getClientId(rowClientId, schRosterAutoId)).value;

    if (ddlAttendanceType.get_selectedItem().get_value() == 'Act') {
        if (ControlIntializer.HFOTReason.value == '1') {
            if (cellScheduleRosterAutoId != '') {
                var pageName = "../Transactions/OTReaasonTransaction.aspx?ScheduleRosterAutoID=" + cellScheduleRosterAutoId + "&AttendanceType=" + ddlAttendanceType.get_selectedItem().get_value() + "&ClientCode=" + ddlClient.get_selectedItem().get_value() + "&AsmtCode=" + ddAssignment.get_selectedItem().get_value() + "&strPost=" + encodeURIComponent(ddlPost.get_selectedItem().get_value());
                refreshStatus = "1";
                window.radopen(pageName, "RadWindow");
            }
        }
    }
    else {
        ChangeDutyType(dutyType);
    }
}


function OpenJobBreakDown(obj) {
    InitalizeControls();
    $(document).ready(function () {
        var columnIndex = parseInt(ControlIntializer.MouseClickColumnID.value) - 1;
        var schRosterAutoId = "HFSchRosterAutoID" + columnIndex;
        var gvScheduleRoster = ControlIntializer.gvScheduleRoster;
        var rowClientId = gvScheduleRoster.rows[parseInt(ControlIntializer.MouseClickRowID.value) + 1].cells[0].childNodes[1];
        var strDutyDate = "lblHeaderDutyDate" + columnIndex;
        var dutyDate = document.getElementById('gvScheduleRoster_ctl01_' + strDutyDate).innerText;
        var strEmployee = "txtEmpNumberDutyDate";
        var cellEmployeeNumber = document.getElementById(getClientId(rowClientId, strEmployee)).value;
        GlobEmployeeSchRosterAutoID = getClientId(rowClientId, schRosterAutoId);
        var cellScheduleRosterAutoId = document.getElementById(GlobEmployeeSchRosterAutoID).value;

        $.ajax({
            type: "GET",
            url: "../Webservices/WebMethods.asmx/GetJobBreakDownSummary",
            data: { strCon: ControlIntializer.connectionKey.value, strCompanyCode: VariableIntializer.SessionCompanyCode, strHrLocationCode: VariableIntializer.SessionHrLocationCode,
                strLocationCode: VariableIntializer.SessionLocationCode, strSchRosterAutoId: cellScheduleRosterAutoId, strAttendanceType: ddlAttendanceType.get_selectedItem().get_value(),
                strAreaID: ddlArea.get_selectedItem().get_value(), strAreaIncharge: VariableIntializer.SessionAreaInchargeNumber, strIsAreaIncharge: VariableIntializer.IsAreaIncharge,
                strFromDate: DateInFormat(ControlIntializer.HFFromDate.value), strToDate: DateInFormat(ControlIntializer.HFToDate.value), selectedDate: DateInFormat(dutyDate),
                clientCode: ddlClient.get_selectedItem().get_value(), asmtid: ddAssignment.get_selectedItem().get_value(), postCode: ddlPost.get_selectedItem().get_value(),
                employeeNumber: cellEmployeeNumber
            },
            ////contentType: "application/text; charset=utf-8",
            async: false,
            success: OnGetJobBreakDownComplete,
            error: OnWSRequestFailed
        });


    });
}

function OnGetJobBreakDownComplete(result, obj) {

    ControlIntializer.SpanjobBreakDownSummary.innerHTML = '';
    var xmlDoc = jQuery.parseXML(result.documentElement.textContent);
    var strTable;
    strTable = "<table border='0' cellpadding=0 cellspacing=1 style='font-size:11px' > ";
    strTable = strTable + "<tr style='background-color:#B7CEEC' >";
    strTable = strTable + "<td width=150px>Job Desc</td>";
    strTable = strTable + "<td width=80px>Time From</td>";
    strTable = strTable + "<td width=80px>Time To</td>";
    strTable = strTable + "<td width=80px>Unit</td>";
    strTable = strTable + "</tr>";

    if (xmlDoc) {
        $(xmlDoc).find('Table').each(function () {
            strTable = strTable + "<tr><td>";
            strTable = strTable + $(this).find('JobDesc').text() + "</td><td>";
            if ($(this).find('TimeFrom').text() == "BLANK") {
                strTable = strTable + "" + "</td><td>";
                strTable = strTable + "" + "</td><td>";
                strTable = strTable + $(this).find('Unit').text() + "</td></tr>";
            } else {
                strTable = strTable + $(this).find('TimeFrom').text() + "</td><td>";
                strTable = strTable + $(this).find('TimeTo').text() + "</td><td>";
                strTable = strTable + "" + "</td></tr>";
            }
        });
    }

    strTable = strTable + "</table>";

    ControlIntializer.SpanjobBreakDownSummary.innerHTML = strTable;
    var radToolTipJobBreakDown = ControlIntializer.RadToolTipJobBreakDown;
    var gvScheduleRoster = ControlIntializer.gvScheduleRoster;
    var columnIndex = parseInt(ControlIntializer.MouseClickColumnID.value) - 1;
    var rowClientId = gvScheduleRoster.rows[parseInt(ControlIntializer.MouseClickRowID.value) + 1].cells[0].childNodes[1];
    var lblSelect = "lblSelect" + columnIndex;
    radToolTipJobBreakDown.set_targetControl(document.getElementById(getClientId(rowClientId, lblSelect)));
    setTimeout(function () {
        radToolTipJobBreakDown.show();
    }, 20);
}

//// *************End Functions related to Break down summary ******************************


//Swap Duty
function SwapDuty() {

    InitalizeControls();

    //Added SAT#036
//    if (ControlIntializer.HFSOBillable.value == "False") {
//        alert(VariableIntializer.MsgComplimentaryDutyTypeCannotChanged);
//        return;
//    }
    //End
    var gvScheduleRoster = ControlIntializer.gvScheduleRoster;
    var rowClientId = gvScheduleRoster.rows[parseInt(ControlIntializer.MouseClickRowID.value) + 1].cells[0].childNodes[1];
    var columnIndex = parseInt(ControlIntializer.MouseClickColumnID.value) - 1;
    var schRosterAutoId = "HFSchRosterAutoID" + columnIndex;
    var cellScheduleRosterAutoId = document.getElementById(getClientId(rowClientId, schRosterAutoId)).value;
    if (cellScheduleRosterAutoId != '' && cellScheduleRosterAutoId != '0') {
        var strPageName = "../Transactions/SwapDuty.aspx?ScheduleRosterAutoID=" + cellScheduleRosterAutoId + "&AttendanceType=" + ddlAttendanceType.get_selectedItem().get_value() + "&Area=" + ddlArea.get_selectedItem().get_value() + "&ClientName=" + encodeURIComponent(ddlClient.get_selectedItem().get_text()) + "&AsmtName=" + encodeURIComponent(ddAssignment.get_selectedItem().get_text()) + "&PostDesc=" + encodeURIComponent(ddlPost.get_selectedItem().get_text());
        refreshStatus = "1";
        window.radopen(strPageName, "RadWindow");
    }
}

function DutyReplacement() {
    InitalizeControls();
    var gvScheduleRoster = ControlIntializer.gvScheduleRoster;
    var rowClientId = gvScheduleRoster.rows[parseInt(ControlIntializer.MouseClickRowID.value) + 1].cells[0].childNodes[1];
    var columnIndex = parseInt(ControlIntializer.MouseClickColumnID.value) - 1;

    var strScheduleRosterAutoId = "HFSchRosterAutoID" + columnIndex;
    GlobEmployeeSchRosterAutoID = getClientId(rowClientId, strScheduleRosterAutoId);
    var cellRosterAutoId = document.getElementById(GlobEmployeeSchRosterAutoID).value;

    var fromDate = DateInFormat(ControlIntializer.HFFromDate.value);
    var toDate = DateInFormat(ControlIntializer.HFToDate.value);

    if (cellRosterAutoId != "") {
        var pageName = "../Transactions/DutyReplacement.aspx?FromDate=" + fromDate + "&ToDate=" + toDate + "&Area=" + ddlArea.get_selectedItem().get_value() + "&AutoID=" + cellRosterAutoId + "&ClientCode=" + ddlClient.get_selectedItem().get_value() + "&AsmtID=" + ddAssignment.get_selectedItem().get_value() + "&PostAutoID=" + encodeURIComponent(ddlPost.get_selectedItem().get_value());
        refreshStatus = "1";
        window.radopen(pageName, "RadWindow");
    }

}

function OpenDutyReplacement(replacementValue, obj) {

    InitalizeControls();
    $(document).ready(function () {
        ControlIntializer.divDutyReplacement.style.display = "block";
        var gvScheduleRoster = ControlIntializer.gvScheduleRoster;
        var columnIndex = parseInt(ControlIntializer.MouseClickColumnID.value) - 1;
        var rowClientId = gvScheduleRoster.rows[parseInt(ControlIntializer.MouseClickRowID.value) + 1].cells[0].childNodes[1];
        var lblSelect = "lblSelect" + columnIndex;
        var lyr = document.getElementById('divDutyReplacement');
        var coors = findPos(document.getElementById(getClientId(rowClientId, lblSelect)));
        lyr.style.top = coors[1] + 20 + 'px';
        lyr.style.left = coors[0] - 1 + 'px';

        dutyReplacementAutoID = obj;
        ControlIntializer.ddlDutyReplacement.value = replacementValue;
    });

}

// This function is used to open leave window
function ApplyLeave() {
    InitalizeControls();
    var gvScheduleRoster = ControlIntializer.gvScheduleRoster;
    var rowClientId = gvScheduleRoster.rows[parseInt(ControlIntializer.MouseClickRowID.value) + 1].cells[0].childNodes[1];
    var strEmployee = "txtEmpNumberDutyDate";
    var strShiftPatternCode = "txtShiftPatternCode";
    var strPatternPosition = "txtPatternPosition";
    var cellEmployeeNumber = getClientId(rowClientId, strEmployee);
    var cellShiftPatternCode = getClientId(rowClientId, strShiftPatternCode);
    var cellPatternPosition = getClientId(rowClientId, strPatternPosition);
    var columnIndex = parseInt(ControlIntializer.MouseClickColumnID.value) - 1;
    var strDutyDate = "lblHeaderDutyDate" + columnIndex;
    var dutyDate = 'gvScheduleRoster_ctl01_' + strDutyDate;
    var strRowNumber = "lblRowID";
    var cellRowNumber = document.getElementById(getClientId(rowClientId, strRowNumber)).innerText;

    if (document.getElementById(dutyDate).innerText != "" && document.getElementById(cellEmployeeNumber).value != "") {

        var pageName = "../HRManagement/LeaveApplicationAndPosting.aspx?EmployeeNumber=" + document.getElementById(cellEmployeeNumber).value +
                                "&DutyDate=" + encodeURIComponent(document.getElementById(dutyDate).innerText) +
                                "&AsmtID=" + ddAssignment.get_selectedItem().get_value() +
                                "&ShiftPatternCode=" + document.getElementById(cellShiftPatternCode).value +
                                "&PatternCode=" + document.getElementById(cellPatternPosition).value +
                                "&ClientCode=" + ddlClient.get_selectedItem().get_value() +
                                "&RowNumber=" + cellRowNumber +
                                "&AttendanceType=" + ddlAttendanceType.get_selectedItem().get_value() +
                                "&Post=" + encodeURIComponent(ddlPost.get_selectedItem().get_value());
        refreshStatus = "1";
        window.radopen(pageName, "RadWindow");
    }
}


// This function is used to Open Create pattern sequence window
function CreatePatternSeq() {
    var pageName = "../Transactions/CreateShiftPatternSeq.aspx?ClientCode=" + ddlClient.get_selectedItem().get_value() + "&AsmtID=" + ddAssignment.get_selectedItem().get_value() + "&Post=" + encodeURIComponent(ddlPost.get_selectedItem().get_value()) + "&FromDate=" + DateInFormat(ControlIntializer.HFFromDate.value) + "&ToDate=" + DateInFormat(ControlIntializer.HFToDate.value);
    refreshStatus = "";
    updateshiftPatternSeq = "1";
    window.radopen(pageName, "RadWindow");
}

function UpdateDutyReplacement() {
    $.ajax({
        type: "GET",
        url: "../Webservices/WebMethods.asmx/DutyReplacementUpdate",
        data: { connectionString: ControlIntializer.connectionKey.value, autoId: document.getElementById(dutyReplacementAutoID).value, reason: ControlIntializer.ddlDutyReplacement.value },
        ////contentType: "application/text; charset=utf-8",
        async: false,
        success: OnDutyReplacementUpdate,
        error: OnWSRequestFailed
    });

}

function DeleteDutyReplacement() {
    $.ajax({
        type: "GET",
        url: "../Webservices/WebMethods.asmx/DutyReplacementDelete",
        data: { connectionString: ControlIntializer.connectionKey.value, autoId: document.getElementById(dutyReplacementAutoID).value },
        ////contentType: "application/text; charset=utf-8",
        async: false,
        success: OnDutyReplacementDeleted,
        error: OnWSRequestFailed
    });
}

function OnDutyReplacementUpdate(result) {
    CloseDutyReplacement();
}

function OnDutyReplacementDeleted(result) {

    InitalizeControls();
    CloseDutyReplacement();
    var gvScheduleRoster = ControlIntializer.gvScheduleRoster;
    var columnIndex = parseInt(ControlIntializer.MouseClickColumnID.value) - 1;
    var rowClientId = gvScheduleRoster.rows[parseInt(ControlIntializer.MouseClickRowID.value) + 1].cells[0].childNodes[1];

    var dutyReplacementImage = "dutyReplacementImage" + ControlIntializer.MouseClickRowID.value + (parseInt(columnIndex) + 1);
    document.getElementById(getClientId(rowClientId, dutyReplacementImage)).style.display = "none";
}