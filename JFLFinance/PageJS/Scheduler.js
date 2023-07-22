
function FillDateEvent(sender, eventsargs) {
    InitalizeControls();
    ControlIntializer.RadWindowEmployeeSearch_C_txtFromDate.value = ControlIntializer.HFMultilingualFromDate.value;
    ControlIntializer.RadWindowEmployeeSearch_C_txtToDate.value = ControlIntializer.HFMultilingualToDate.value;
}

//=======================================
//Function Used to select Shift After Searchin Drop Down
//=======================================
function SelectShift(obj) {
    $(document).ready(function () {
        var el = GlobEmployeeShiftCode;
        if (obj.selectedIndex >= 0) {
            var arr = new Array;
            arr = obj.options[obj.selectedIndex].text.split("[");
            var arr1 = new Array;
            arr1 = arr[1].split(']');
            var arrTimeDetail = arr1[0].split('-');
            document.getElementById(el).value = obj.options[obj.selectedIndex].text.substring(0, 1);
            document.getElementById(el).focus();
            document.getElementById(GlobEmployeeTimeFrom).value = arrTimeDetail[0];
            document.getElementById(GlobEmployeeTimeTo).value = arrTimeDetail[1];
            ControlIntializer.divShift.style.display = "none";
        }
        return;
    });
}

// This function is used to search Shift 
function SearchShift(obj) {
    var keyId = (window.event) ? event.keyCode : event.which;

    if (keyId == 45 || keyId == 46) { // Insert Key AND DELETE KEY Pressed to copy to next day
        return;
    }
    if (keyId == 9) {
        return;
    }
    var columnIndex;
    var strReversedString = obj.id.split('').reverse().join('');
    columnIndex = strReversedString.substring(0, 2);
    if (isNaN(columnIndex)) {
        columnIndex = strReversedString.substring(0, 1);
    }
    else {
        columnIndex = columnIndex.toString().split('').reverse().join('');
    }
    var strDutyDate = "lblHeaderDutyDate" + columnIndex;
    var dutyDate = 'gvScheduleRoster_ctl01_' + strDutyDate;
    GlobObject = obj;

    if (GlobalOldObject != GlobObject) {

        ControlIntializer.LBShift.length = 0;
        $.ajax({
            type: "POST",
            url: "../Webservices/WebMethods.asmx/GetAllShiftsOfDay",
            data: { strComnnectionString: ControlIntializer.connectionKey.value, clientCode: ddlClient.get_selectedItem().get_value(), asmtId: ddAssignment.get_selectedItem().get_value(),
                strLocationAutoID: VariableIntializer.SessionLocationAutoId, dutyDate: DateInFormat(document.getElementById(dutyDate).innerText), weekNumber: ddlWeek.get_selectedItem().get_value(),
                postCode: ddlPost.get_selectedItem().get_value()
            },
            ////contentType: "application/text; charset=utf-8",
            async: false,
            success: OnGetAllShiftWSRequestComplete,
            error: OnWSRequestFailed
        });
    }
    else {
        OnGetAllShiftWSRequestComplete('');
    }
    GlobKeyCode = keyId;
}
//=======================================
//Function Used to Search Shift In Drop Down
//=======================================

function OnGetAllShiftWSRequestComplete(result) {
    var elList = ControlIntializer.LBShift;
    var columnIndex;
    var strReversedString = GlobObject.id.split('').reverse().join('');
    GlobalOldObject = GlobObject;
    columnIndex = strReversedString.substring(0, 2);
    if (isNaN(columnIndex)) {
        columnIndex = strReversedString.substring(0, 1);
    }
    else {
        columnIndex = columnIndex.toString().split('').reverse().join('');
    }

    if (result != '') {
        var res1 = result;
        var xmlDoc = jQuery.parseXML(result.documentElement.textContent);
        if (xmlDoc) {
            $(xmlDoc).find('Table').each(function () {
                var option = document.createElement("OPTION");
                option.text = $(this).find('ShiftDetails').text();
                option.value = $(this).find('ShiftUID').text();
                ControlIntializer.LBShift.options.add(option);
            });
        }

        ControlIntializer.LBShift.selectedIndex = 0;
    }

    var lyr = ControlIntializer.divShift;
    var strTimeFrom = getClientId(GlobObject, "txtTimeFrom" + columnIndex);
    var strTimeTo = getClientId(GlobObject, "txtTimeTo" + columnIndex);
    GlobEmployeeTimeFrom = strTimeFrom;
    GlobEmployeeTimeTo = strTimeTo;
    var strShift = "txtEmpShiftDutyDate" + columnIndex;
    var elShift = getClientId(GlobObject, strShift);
    GlobEmployeeShiftCode = elShift;

    var coors = findPos(document.getElementById(elShift));
    lyr.style.top = coors[1] + 20 + 'px';
    lyr.style.left = coors[0] + 'px';
    $("#divShift").css("display", "block");
    if (GlobKeyCode == 138 || GlobKeyCode == 140) {
        elList.focus();
        return;
    }
    else {
        for (var i = 0; i < elList.length; i++) {
            if (elList.options[i].text.toLowerCase().substr(0, document.getElementById(elShift).value.length) == document.getElementById(elShift).value.toLowerCase()) {
                elList.options[i].selected = true;
                elList.focus();
                return;
            }
        }

    }
}

// Function to Copy data to next week when insert key is pressed
function CopyData(schRosterAutoId) {

    $.ajax({
        type: "POST",
        url: "../Webservices/WebMethods.asmx/CopyData",
        data: { connectionString: ControlIntializer.connectionKey.value, clientCode: ddlClient.get_selectedItem().get_value(), asmtId: ddAssignment.get_selectedItem().get_value(),
            postCode: ddlPost.get_selectedItem().get_value(), weekNo: ddlWeek.get_selectedItem().get_value(), schRosterAutoID: schRosterAutoId,
            screenType: ddlAttendanceType.get_selectedItem().get_value(), currentSession: ControlIntializer.HFCurrentSessionID.value,
            modifiedBy: VariableIntializer.SessionUserId, fromDate: DateInFormat(ControlIntializer.HFFromDate.value), toDate: DateInFormat(ControlIntializer.HFMaxDate.value),
            employeeNumber: document.getElementById(GlobEmployeeNumber).value, clientName: ddlClient.get_selectedItem().get_text(),
            asmtName: ddAssignment.get_selectedItem().get_text(), postDesc: ddlPost.get_selectedItem().get_text()
        },
        //  contentType: "application/text; charset=utf-8",
        async: false,
        success: OnInsertDataOfDateComplete,
        error: OnWSRequestFailed
    });
}


//=======================================
//Function Used to Search Shift Pattern In Drop Down
//=======================================
function SearchShiftPattern(obj) {
    InitalizeControls();
    $(document).ready(function () {
        if (ddlAttendanceType.get_selectedItem().get_value() == 'Act') {
            return;
        }

        var strShiftPatternCode = "txtShiftPatternCode";
        var elShiftPatternCode = getClientId(obj, strShiftPatternCode);
        GlobShiftPatternCode = elShiftPatternCode;
        GlobObject = obj;
        tmpGlobObject = obj.id;
        if (updateshiftPatternSeq == "1") {
            ControlIntializer.LBShiftPatterns.length = 0;
            updateshiftPatternSeq = "";
        }

        if (ControlIntializer.LBShiftPatterns.length == 0) {
            ControlIntializer.LBShiftPatterns.length = 0;

            $(document).ready(function () {
                $.ajax({
                    type: "POST",
                    url: "../Webservices/WebMethods.asmx/GetAllShiftPattern",
                    data: { connectionString: ControlIntializer.connectionKey.value, locationAutoId: VariableIntializer.SessionLocationAutoId, clientCode: ddlClient.get_selectedItem().get_value(),
                        asmtId: ddAssignment.get_selectedItem().get_value(), post: ddlPost.get_selectedItem().get_value()
                    },
                    ////contentType: "application/text; charset=utf-8",
                    async: false,
                    success: OnGetAllShiftPatternComplete,
                    error: OnWSRequestFailed
                });
            });

        } else {
            OnGetAllShiftPatternComplete('');
        }
    });
}


function OnGetAllShiftPatternComplete(result) {
    var keyId = (window.event) ? event.keyCode : event.which;
    var elList = ControlIntializer.LBShiftPatterns;
    var columnIndex;
    var strReversedString = GlobObject.id.split('').reverse().join('');
    GlobalOldShiftPatternObject = GlobObject.id;
    columnIndex = strReversedString.substring(0, 2);
    if (isNaN(columnIndex)) {
        columnIndex = strReversedString.substring(0, 1);
    }
    else {
        columnIndex = columnIndex.toString().split('').reverse().join('');
    }
    if (result !== '') {
        var xmlDoc = jQuery.parseXML(result.documentElement.textContent);
        try {
            ControlIntializer.LBShiftPatterns.length = 0;
            if (xmlDoc) {
                $(xmlDoc).find('Table').each(function () {
                    var option = document.createElement("OPTION");
                    option.text = $(this).find('ShiftPatternID').text();
                    option.value = $(this).find('ShiftPatternID').text();
                    option.title = $(this).find('PatternDetail').text();
                    ControlIntializer.LBShiftPatterns.options.add(option);
                });
            }

        }
        catch (error) { }

        ControlIntializer.LBShiftPatterns.selectedIndex = 0;
    }

    var lyr = ControlIntializer.DivShiftPatterns;
    var coors = findPos(document.getElementById(GlobShiftPatternCode));
    lyr.style.top = coors[1] + 20 + 'px';
    lyr.style.left = coors[0] + 'px';
    if (ControlIntializer.DivShiftPatterns.style.display == "none") {
        ControlIntializer.DivShiftPatterns.style.display = "block";
    }
    if (keyId == 38 || keyId == 40) {
        elList.focus();
        return;
    }
    else {
        for (var i = 0; i < elList.length; i++) {
            if (elList.options[i].text.toLowerCase().substr(0, document.getElementById(GlobShiftPatternCode).value.length) == document.getElementById(GlobShiftPatternCode).value.toLowerCase()) {
                elList.options[i].selected = true;
                return;
            }
            else {
            }
        }
    }
}
//=======================================
//Function Used to select Shift Pattern After Searchin Drop Down
//=======================================
function SelectShiftPattern(obj) {
    $(document).ready(function () {
        var el = GlobShiftPatternCode;
        if (obj.selectedIndex >= 0) {
            document.getElementById(el).value = obj.options[obj.selectedIndex].text;
            document.getElementById(el).focus();
            ControlIntializer.DivShiftPatterns.style.display = "none";
        }
        return;
    });
}

function ShortCutKeysJS() {
    $(document).ready(function () {
        var keyId = (window.event) ? event.keyCode : event.which;
        var key;
        var isCtrl;
        if (window.event) {
            key = window.event.keyCode;     //IE
            if (window.event.ctrlKey)
                isCtrl = true;
            else
                isCtrl = false;
        }
        else {
            key = e.which;     //firefox
            if (e.ctrlKey)
                isCtrl = true;
            else
                isCtrl = false;
        }
        if (isCtrl) {
            if (keyId == 77) {
                if (ddlAttendanceType.get_selectedItem().get_value() != 'Act') {
                    ControlIntializer.HFRowIndex.value = "";
                }
                EnableProceedAndClick();
            }
        }
        if (keyId == 45) //INSERT KEY PRESSD
        {

        }
        else if (keyId == 113)// F2 Pressed  Help Window
        {
            window.OpenHelpWindow();
        }
        else if (keyId == 119)// F8 Pressed  For New Pattern
        {
            if (ddlAttendanceType.get_selectedItem().get_value() == 'Sch') {
                CreatePatternSeq();
            }
        }
        else if (keyId == 118)// F7 Pressed Lock Functionality
        {
            ControlIntializer.HFRowIndex.value = "";
            if (ddlAttendanceType.get_selectedItem().get_value() == 'Act') {
                $(document).ready(function () {
                    $.ajax({
                        type: "POST",
                        url: "../Webservices/WebMethods.asmx/ConfirmAttendance",
                        data: {
                            connectionString: ControlIntializer.connectionKey.value, clientCode: ddlClient.get_selectedItem().get_value(),
                            asmtCode: ddAssignment.get_selectedItem().get_value(), postCode: ddlPost.get_selectedItem().get_value(),
                            fromDate: DateInFormat(ControlIntializer.HFFromDate.value), toDate: DateInFormat(ControlIntializer.HFToDate.value),
                            locationAutoId: VariableIntializer.SessionLocationAutoId, modifiedBy: VariableIntializer.SessionUserId
                        },
                        // contentType: "application/text; charset=utf-8",
                        async: false,
                        success: OnConfirmAttendanceComplete,
                        error: OnWSRequestFailed
                    });

                });
            }
            else {

                $(document).ready(function () {
                    $.ajax({
                        type: "POST",
                        url: "../Webservices/WebMethods.asmx/GetAllLockUnLockStatus",
                        data: {
                            strCon: ControlIntializer.connectionKey.value, clientCode: ddlClient.get_selectedItem().get_value(), asmtId: ddAssignment.get_selectedItem().get_value(),
                            locationAutoId: VariableIntializer.SessionLocationAutoId, fromDate: DateInFormat(ControlIntializer.HFFromDate.value), toDate: DateInFormat(ControlIntializer.HFToDate.value)
                        },
                        ////contentType: "application/text; charset=utf-8",
                        async: false,
                        success: OnGetLockUnLockStatus,
                        error: OnWSRequestFailed
                    });
                });
            }


        }
        else if (keyId == 121) // F10 Key Pressed
        {
            AllSkillMatchMismatch();
        }
        else if (keyId == 27) // ESC Key Pressed
        {
            HideDivs();
        }
        else if (keyId == 120) { // F9 to overwrite "not a prefered day messages"
            InitalizeControls();
            if (ControlIntializer.spanErrorMessage.innerHTML != "") {
                ShortCutOverWriteRecord();
            }
        }

    });
}


function OnConfirmAttendanceComplete(result) {
    EnableProceedAndClick();
}

// This function is called when Lock functionality has finished executing
function OnGetLockUnLockStatus(result) {
    var xmlDoc = jQuery.parseXML(result.documentElement.textContent);
    if (xmlDoc && ddlAttendanceType.get_selectedItem().get_value() == 'Sch') {
        if ($(xmlDoc).find('Status').text() == '1') {
            var returnValue = confirm('Are you sure you want to Lock the Schedule');
            if (returnValue) { LockScheduleEmpWise(); }
        }
    }
    else {
        alert(VariableIntializer.Lockingnotallowedpleasechangetheattendancetypeoftheassignment);
    }
}

//=======================================
// Function Called to lock employee schedule
//=======================================
function LockScheduleEmpWise() {
    InitalizeControls();

    $(document).ready(function () {
        $.ajax({
            type: "POST",
            url: "../Webservices/WebMethods.asmx/LockSchedule",
            data: { connectionString: ControlIntializer.connectionKey.value, clientCode: ddlClient.get_selectedItem().get_value(), asmtId: ddAssignment.get_selectedItem().get_value(),
                postCode: ddlPost.get_selectedItem().get_value(), fromDate: DateInFormat(ControlIntializer.HFFromDate.value), toDate: DateInFormat(ControlIntializer.HFToDate.value),
                locationAutoId: VariableIntializer.SessionLocationAutoId, modifiedBy: VariableIntializer.SessionUserId
            },
            //  contentType: "application/text; charset=utf-8",
            async: false,
            success: OnLockScheduleComplete,
            error: OnWSRequestFailed
        });
    });

}

function OnLockScheduleComplete(result) {
    var j = 0;
    ControlIntializer.spanConvertMessage.innerHTML = "";
    ControlIntializer.spanConvertMessage.innerHTML = result.documentElement.textContent;
    var radWindowMessage = ControlIntializer.RadWindowConvert;
    if (document.getElementById('lblMessage' + j).innerHTML == VariableIntializer.MsgSuccessfullyLocked) {
        EnableProceedAndClick();
        radWindowMessage.close();
        ControlIntializer.spanConvertMessage.innerHTML = "";
    }
    else {
        radWindowMessage.show();
    }
}


function OnClientEmployeeSearchDropDownOpening(sender, eventArgs) {

}

function RadWindowClose(sender, eventArgs) {
    $(document).ready(function () {
        InitalizeControls();
        ControlIntializer.spanEmployeeSchedule.innerHTML = "";
        var elList = ControlIntializer.lstBox_Employees;
        var items = elList.get_items();
        items.clear();

        ControlIntializer.search_txtEmployeeName.value = "";
        ControlIntializer.search_txtEmployeeNumber.value = "";
        ControlIntializer.divEmployeeList.style.display = "none";
        ControlIntializer.HFRowIndex.value = "";
        GlobalOldShiftPatternObject = "";
        if (refreshStatus == "1") {
            var integerValue = (parseInt(ControlIntializer.HFNumberOfRowsInGrid.value) + 3).toString();
            if (integerValue.length < 2) {

                integerValue = '0' + integerValue;
            }
            var ddlPageClientId = 'gvScheduleRoster_ctl' + integerValue + '_ddlPages';
            ControlIntializer.hfSelectedGridPageCountFinal.value = document.getElementById(ddlPageClientId).value;
            EnableProceedAndClick();
        }
        refreshStatus = "";
    });

}

function AssignPagingDropDownValue() {

    $(document).ready(function () {
        InitalizeControls();

        var integerValue = (parseInt(ControlIntializer.HFNumberOfRowsInGrid.value) + 3).toString();
        if (integerValue.length < 2) {

            integerValue = '0' + integerValue;
        }
        var ddlPageClientId = 'gvScheduleRoster_ctl' + integerValue + '_ddlPages';
        ControlIntializer.hfSelectedGridPageCountFinal.value = document.getElementById(ddlPageClientId).value;

    });
}

function RadWindowDuplicateClose(sender, eventArgs) {
    $(document).ready(function () {
        InitalizeControls();
        ControlIntializer.spanErrorMessage.innerHTML = "";
        var integerValue = (parseInt(ControlIntializer.HFNumberOfRowsInGrid.value) + 3).toString();
        if (integerValue.length < 2) {

            integerValue = '0' + integerValue;
        }
        var ddlPageClientId = 'gvScheduleRoster_ctl' + integerValue + '_ddlPages';
        ControlIntializer.hfSelectedGridPageCountFinal.value = document.getElementById(ddlPageClientId).value;
        EnableProceedAndClick();
    });
}


// this function is called when any key down event is done on gridview controls
function FunctionCallOnKeyDown(elName, obj) {
    InitalizeControls();
    $(document).ready(function () {
        var columnIndex;
        GlobObject = obj;

        var keyId = (window.event) ? event.keyCode : event.which;

        if (keyId == 9 || keyId == 46) { //TAB
            HideDivs();
        }

        var strReversedString = obj.id.split('').reverse().join('');
        columnIndex = strReversedString.substring(0, 2);
        if (isNaN(columnIndex)) {
            columnIndex = strReversedString.substring(0, 1);
        } else {
            columnIndex = columnIndex.toString().split('').reverse().join('');
        }

        var strDutyDate = "lblHeaderDutyDate" + columnIndex;
        var strEmpNumber = "txtEmpNumberDutyDate";
        var dutyDate = 'gvScheduleRoster_ctl01_' + strDutyDate;
        GlobEmployeeDutyDate = dutyDate;
        var strEmployeeName = "txtEmpNameDutyDate";
        var strEmpDesignationDesc = "txtEmpDesignationDesc";
        var strShiftPatternCode = "txtShiftPatternCode";
        var strPatternPosition = "txtPatternPosition";
        var hfOrgEmployeeNumber = "HFOrgEmployeeNumber";
        var strShiftCode = "txtEmpShiftDutyDate" + columnIndex;
        var strTimeFrom = "txtTimeFrom" + columnIndex;
        var strTimeTo = "txtTimeTo" + columnIndex;
        var strScheduleRosterAutoId = "HFSchRosterAutoID" + columnIndex;
        GlobRowNumber = getClientId(obj, "lblRowID");
        var empDetails = "lblDutyDate" + columnIndex;
        GlobEmployeeDetails = getClientId(obj, empDetails);

        if (document.getElementById(globBorrowedEmployeeStatus) == "[object]") {

            document.getElementById(globBorrowedEmployeeStatus).value = "";
        }

        var strSerialNumber = getClientId(obj, "lblSerialNumber");
        try {
            ControlIntializer.HFRowIndex.value = parseInt(document.getElementById(strSerialNumber).innerText) - 1;
        } catch (error) {
        }


        var strScreenType;
        if (ddlAttendanceType.get_selectedItem().get_value() == 'Act') {

            strScreenType = 'ACT';
        } else {
            strScreenType = 'SCH';
        }


        GlobEmployeeNumber = getClientId(obj, strEmpNumber);
        GlobEmployeeName = getClientId(obj, strEmployeeName);
        GlobEmployeeDesgDesc = getClientId(obj, strEmpDesignationDesc);
        GlobEmployeeShiftCode = getClientId(obj, strShiftCode);
        GlobEmployeeTimeFrom = getClientId(obj, strTimeFrom);
        GlobEmployeeTimeTo = getClientId(obj, strTimeTo);
        GlobEmployeeSchRosterAutoID = getClientId(obj, strScheduleRosterAutoId);
        GlobShiftPatternCode = getClientId(obj, strShiftPatternCode);
        GlobSavedEmployeeNumber = getClientId(obj, hfOrgEmployeeNumber);

        GlobPatternPosition = getClientId(obj, strPatternPosition);
        globBorrowedEmployeeStatus = getClientId(obj, "hfBorrowedEmployeeStatus");
        var savedShiftPatternCode = getClientId(obj, "HFShiftPatternCode");
        GlobRowNumber = getClientId(obj, "lblRowID");
        HideDivs();

        ControlIntializer.hfSelectedGridPageCountFinal.value = "0";
        var fromDate;
        var maxDate;
        var employeeNumber;
        var schRosterAutoId;
        var ReturnValue;
        var modifiedDate;
        var month;
        var day;
        var year;
        switch (elName) {
            case "EmployeeNumber":
                if (keyId == 120) { // F9


                    if (document.getElementById(GlobEmployeeNumber).value == '') {
                        GlobEmployeeNumber = getClientId(obj, strEmpNumber);
                        GlobEmployeeName = getClientId(obj, strEmployeeName);
                        GlobEmployeeDesgDesc = getClientId(obj, strEmpDesignationDesc);
                        GetUnSchEmp(GlobEmployeeNumber);
                        return;
                    } else {
                        GetUnSchEmp('');
                    }
                } else if (keyId == 13) // ENTER Key
                {

                    $(document).ready(function () {
                        $.ajax({
                            type: "POST",
                            url: "../Webservices/WebMethods.asmx/GetEmployeeDetail",
                            data: { connectionString: ControlIntializer.connectionKey.value, employeeNumber: document.getElementById(GlobEmployeeNumber).value, clientCode: ddlClient.get_selectedItem().get_value(),
                                asmtId: ddAssignment.get_selectedItem().get_value(), fromDate: DateInFormat(ControlIntializer.HFFromDate.value), toDate: DateInFormat(ControlIntializer.HFToDate.value),
                                postCode: ddlPost.get_selectedItem().get_value(), insertStatus: "EmployeeNumber", areaId: ddlArea.get_selectedItem().get_value(),
                                areaInchargeNumber: VariableIntializer.SessionAreaInchargeNumber, isAreaIncharge: VariableIntializer.IsAreaIncharge, screenType: strScreenType,
                                companyCode: VariableIntializer.SessionCompanyCode, hrLocationCode: VariableIntializer.SessionHrLocationCode,
                                locationAutoId: VariableIntializer.SessionLocationAutoId, modifiedBy: VariableIntializer.SessionUserId
                            },
                            ///// contentType: "application/text; charset=utf-8",
                            async: false,
                            success: OnGetEmployeeDetailComplete,
                            error: OnWSRequestFailed
                        });
                    });

                    return;

                } else if (keyId == 46) { //delete Key Pressed
                    if (ddlAttendanceType.get_selectedItem().get_value() == "Act") {
                        if (ControlIntializer.HFActualDutyReplacement.value == "1") {
                            alert(VariableIntializer.Deletenotallowedpleaseaddreplacementduty);
                            return;
                        }
                    }
                    fromDate = DateInFormat(ControlIntializer.HFFromDate.value);
                    maxDate = DateInFormat(ControlIntializer.HFMaxDate.value);
                    employeeNumber = document.getElementById(GlobEmployeeNumber).value;
                    strPatternPosition = document.getElementById(GlobPatternPosition).value;
                    schRosterAutoId = "0";
                    ControlIntializer.HFRowIndex.value = "";

                    $(document).ready(function () {
                        $.ajax({
                            type: "POST",
                            url: "../Webservices/WebMethods.asmx/DeleteSchedule",
                            data: { strCon: ControlIntializer.connectionKey.value, scheduleRosterAutoID: schRosterAutoId, employeeNumber: employeeNumber,
                                fromDate: fromDate, toDate: maxDate, clientCode: ddlClient.get_selectedItem().get_value(), asmtId: ddAssignment.get_selectedItem().get_value(),
                                postCode: ddlPost.get_selectedItem().get_value(), shiftPatternCode: document.getElementById(GlobShiftPatternCode).value,
                                patternPosition: strPatternPosition, rowNumber: document.getElementById(GlobRowNumber).innerText, attendanceType: ddlAttendanceType.get_selectedItem().get_value()
                            },
                            //  contentType: "application/text; charset=utf-8",
                            async: false,
                            success: OnDeleteRecordsComplete,
                            error: OnWSRequestFailed
                        });
                    });

                } else if (keyId == 16) //select
                {
                    obj.select();
                    return;
                } else if (keyId == 9) {
                    if (document.getElementById(GlobEmployeeNumber).value != "") {

                        $(document).ready(function () {
                            $.ajax({
                                type: "POST",
                                url: "../Webservices/WebMethods.asmx/GetEmployeeDetail",
                                data: { connectionString: ControlIntializer.connectionKey.value, employeeNumber: document.getElementById(GlobEmployeeNumber).value, clientCode: ddlClient.get_selectedItem().get_value(),
                                    asmtId: ddAssignment.get_selectedItem().get_value(), fromDate: DateInFormat(ControlIntializer.HFFromDate.value), toDate: DateInFormat(ControlIntializer.HFToDate.value),
                                    postCode: ddlPost.get_selectedItem().get_value(), insertStatus: "EmployeeNumber", areaId: ddlArea.get_selectedItem().get_value(),
                                    areaInchargeNumber: VariableIntializer.SessionAreaInchargeNumber, isAreaIncharge: VariableIntializer.IsAreaIncharge, screenType: strScreenType,
                                    companyCode: VariableIntializer.SessionCompanyCode, hrLocationCode: VariableIntializer.SessionHrLocationCode,
                                    locationAutoId: VariableIntializer.SessionLocationAutoId, modifiedBy: VariableIntializer.SessionUserId
                                },
                                ////   contentType: "application/text; charset=utf-8",
                                async: false,
                                success: OnGetEmployeeDetailComplete,
                                error: OnWSRequestFailed
                            });
                        });

                    }
                } else {
                    return;
                }
                break;
            case "TimeFrom":
                if (keyId == 9) {
                    IsValidTime(obj, 'F');
                }

                if (keyId == 13) //select
                {
                    if (document.getElementById(savedShiftPatternCode).value === "") {
                        if (CheckValidShiftPattern() === false) {

                            document.getElementById(GlobShiftPatternCode).value = "";
                        }
                    }


                    ReturnValue = IsValidTime(obj, 'F');
                    if (ReturnValue) {

                        $(document).ready(function () {
                            $.ajax({
                                type: "POST",
                                url: "../Webservices/WebMethods.asmx/GetEmployeeDetail",
                                data: { connectionString: ControlIntializer.connectionKey.value, employeeNumber: document.getElementById(GlobEmployeeNumber).value, clientCode: ddlClient.get_selectedItem().get_value(),
                                    asmtId: ddAssignment.get_selectedItem().get_value(), fromDate: DateInFormat(document.getElementById(dutyDate).innerText), toDate: DateInFormat(document.getElementById(dutyDate).innerText),
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
                        });
                        return;
                    }
                }

                if (keyId == 45) { // Insert Key Pressed to copy to next day

                    if (document.getElementById(savedShiftPatternCode).value === "") {
                        if (CheckValidShiftPattern() === false) {

                            document.getElementById(GlobShiftPatternCode).value = "";
                        }
                    }
                    var arr = document.getElementById(dutyDate).innerText.split("-");

                    month = arr[1];
                    day = parseInt(arr[0], 10) + 1;
                    year = arr[2];
                    modifiedDate = day + "-" + month + "-" + year;

                    $(document).ready(function () {
                        $.ajax({
                            type: "POST",
                            url: "../Webservices/WebMethods.asmx/GetEmployeeDetail",
                            data: { connectionString: ControlIntializer.connectionKey.value, employeeNumber: document.getElementById(GlobEmployeeNumber).value, clientCode: ddlClient.get_selectedItem().get_value(),
                                asmtId: ddAssignment.get_selectedItem().get_value(), fromDate: DateInFormat(modifiedDate), toDate: DateInFormat(modifiedDate),
                                postCode: ddlPost.get_selectedItem().get_value(), insertStatus: "COPY", areaId: ddlArea.get_selectedItem().get_value(),
                                areaInchargeNumber: VariableIntializer.SessionAreaInchargeNumber, isAreaIncharge: VariableIntializer.IsAreaIncharge, screenType: strScreenType,
                                companyCode: VariableIntializer.SessionCompanyCode, hrLocationCode: VariableIntializer.SessionHrLocationCode,
                                locationAutoId: VariableIntializer.SessionLocationAutoId, modifiedBy: VariableIntializer.SessionUserId
                            },
                            //  contentType: "application/text; charset=utf-8",
                            async: false,
                            success: OnGetEmployeeDetailComplete,
                            error: OnWSRequestFailed
                        });
                    });

                    return;
                }

                break;
            case "TimeTo":
                if (keyId == 9) {
                    IsValidTime(obj, 'T');
                }
                if (keyId == 13) //select
                {
                    if (document.getElementById(savedShiftPatternCode).value === "") {
                        if (CheckValidShiftPattern() === false) {

                            document.getElementById(GlobShiftPatternCode).value = "";
                        }
                    }
                    ReturnValue = IsValidTime(obj, 'T');
                    if (ReturnValue) {

                        $(document).ready(function () {
                            $.ajax({
                                type: "POST",
                                url: "../Webservices/WebMethods.asmx/GetEmployeeDetail",
                                data: { connectionString: ControlIntializer.connectionKey.value, employeeNumber: document.getElementById(GlobEmployeeNumber).value, clientCode: ddlClient.get_selectedItem().get_value(),
                                    asmtId: ddAssignment.get_selectedItem().get_value(), fromDate: DateInFormat(document.getElementById(dutyDate).innerText), toDate: DateInFormat(document.getElementById(dutyDate).innerText),
                                    postCode: ddlPost.get_selectedItem().get_value(), insertStatus: "SINGLE", areaId: ddlArea.get_selectedItem().get_value(),
                                    areaInchargeNumber: VariableIntializer.SessionAreaInchargeNumber, isAreaIncharge: VariableIntializer.IsAreaIncharge, screenType: strScreenType,
                                    companyCode: VariableIntializer.SessionCompanyCode, hrLocationCode: VariableIntializer.SessionHrLocationCode,
                                    locationAutoId: VariableIntializer.SessionLocationAutoId, modifiedBy: VariableIntializer.SessionUserId
                                },
                                //    contentType: "application/text; charset=utf-8",
                                async: false,
                                success: OnGetEmployeeDetailComplete,
                                error: OnWSRequestFailed
                            });
                        });
                        return;
                    }
                }

                if (keyId == 45) { // Insert Key Pressed to copy to next day
                    if (document.getElementById(savedShiftPatternCode).value === "") {
                        if (CheckValidShiftPattern() === false) {

                            document.getElementById(GlobShiftPatternCode).value = "";
                        }
                    }
                    var arr = document.getElementById(dutyDate).innerText.split("-");

                    month = arr[1];
                    day = parseInt(arr[0], 10) + 1;
                    year = arr[2];
                    modifiedDate = day + "-" + month + "-" + year;

                    $(document).ready(function () {
                        $.ajax({
                            type: "POST",
                            url: "../Webservices/WebMethods.asmx/GetEmployeeDetail",
                            data: { connectionString: ControlIntializer.connectionKey.value, employeeNumber: document.getElementById(GlobEmployeeNumber).value, clientCode: ddlClient.get_selectedItem().get_value(),
                                asmtId: ddAssignment.get_selectedItem().get_value(), fromDate: DateInFormat(modifiedDate), toDate: DateInFormat(modifiedDate),
                                postCode: ddlPost.get_selectedItem().get_value(), insertStatus: "COPY", areaId: ddlArea.get_selectedItem().get_value(),
                                areaInchargeNumber: VariableIntializer.SessionAreaInchargeNumber, isAreaIncharge: VariableIntializer.IsAreaIncharge, screenType: strScreenType,
                                companyCode: VariableIntializer.SessionCompanyCode, hrLocationCode: VariableIntializer.SessionHrLocationCode,
                                locationAutoId: VariableIntializer.SessionLocationAutoId, modifiedBy: VariableIntializer.SessionUserId
                            },
                            //  contentType: "application/text; charset=utf-8",
                            async: false,
                            success: OnGetEmployeeDetailComplete,
                            error: OnWSRequestFailed
                        });
                    });
                    return;
                }
                break;
            case "ShiftCode":
                if (keyId == 46) { //delete Key Pressed
                    strScheduleRosterAutoId = "HFSchRosterAutoID" + columnIndex;
                    GlobEmployeeSchRosterAutoID = getClientId(obj, strScheduleRosterAutoId);

                    if (document.getElementById(GlobEmployeeSchRosterAutoID).value != "0") {
                        schRosterAutoId = document.getElementById(GlobEmployeeSchRosterAutoID).value;
                        fromDate = DateInFormat(document.getElementById(dutyDate).innerText);
                        maxDate = DateInFormat(document.getElementById(dutyDate).innerText);
                        employeeNumber = document.getElementById(GlobEmployeeNumber).value;
                        strPatternPosition = document.getElementById(GlobPatternPosition).value;
                        if (ddlAttendanceType.get_selectedItem().get_value() == "Act") {
                            if (ControlIntializer.HFActualDutyReplacement.value == "1") {
                                alert(VariableIntializer.Deletenotallowedpleaseaddreplacementduty);
                                return;
                            }
                        }


                        var returnValue = confirm(VariableIntializer.MsgConfirmDelete);
                        if (returnValue) {
                            globCopyStatus = "1";


                            $(document).ready(function () {
                                $.ajax({
                                    type: "POST",
                                    url: "../Webservices/WebMethods.asmx/DeleteSchedule",
                                    data: { strCon: ControlIntializer.connectionKey.value, scheduleRosterAutoID: schRosterAutoId, employeeNumber: employeeNumber,
                                        fromDate: fromDate, toDate: maxDate, clientCode: ddlClient.get_selectedItem().get_value(), asmtId: ddAssignment.get_selectedItem().get_value(),
                                        postCode: ddlPost.get_selectedItem().get_value(), shiftPatternCode: document.getElementById(GlobShiftPatternCode).value,
                                        patternPosition: strPatternPosition, rowNumber: document.getElementById(GlobRowNumber).innerText, attendanceType: ddlAttendanceType.get_selectedItem().get_value()
                                    },
                                    //  contentType: "application/text; charset=utf-8",
                                    async: false,
                                    success: OnDeleteRecordsComplete,
                                    error: OnWSRequestFailed
                                });
                            });
                            HideDivs();

                        }


                    }
                }
                if (keyId == 45) { // Insert Key Pressed to copy to next day
                    if (document.getElementById(savedShiftPatternCode).value === "") {
                        if (CheckValidShiftPattern() === false) {

                            document.getElementById(GlobShiftPatternCode).value = "";
                        }
                    }
                    var arr = document.getElementById(dutyDate).innerText.split("-");

                    month = arr[1];
                    day = parseInt(arr[0], 10) + 1;
                    year = arr[2];
                    modifiedDate = day + "-" + month + "-" + year;

                    $(document).ready(function () {
                        $.ajax({
                            type: "POST",
                            url: "../Webservices/WebMethods.asmx/GetEmployeeDetail",
                            data: { connectionString: ControlIntializer.connectionKey.value, employeeNumber: document.getElementById(GlobEmployeeNumber).value, clientCode: ddlClient.get_selectedItem().get_value(),
                                asmtId: ddAssignment.get_selectedItem().get_value(), fromDate: DateInFormat(modifiedDate), toDate: DateInFormat(modifiedDate),
                                postCode: ddlPost.get_selectedItem().get_value(), insertStatus: "COPY", areaId: ddlArea.get_selectedItem().get_value(),
                                areaInchargeNumber: VariableIntializer.SessionAreaInchargeNumber, isAreaIncharge: VariableIntializer.IsAreaIncharge, screenType: strScreenType,
                                companyCode: VariableIntializer.SessionCompanyCode, hrLocationCode: VariableIntializer.SessionHrLocationCode,
                                locationAutoId: VariableIntializer.SessionLocationAutoId, modifiedBy: VariableIntializer.SessionUserId
                            },
                            //  contentType: "application/text; charset=utf-8",
                            async: false,
                            success: OnGetEmployeeDetailComplete,
                            error: OnWSRequestFailed
                        });
                    });
                    HideDivs();

                    return;
                }
                if (keyId == 13) //select
                {
                    if (document.getElementById(savedShiftPatternCode).value === "") {
                        if (CheckValidShiftPattern() === false) {

                            document.getElementById(GlobShiftPatternCode).value = "";
                        }
                    }
                    $(document).ready(function () {
                        $.ajax({
                            type: "POST",
                            url: "../Webservices/WebMethods.asmx/GetEmployeeDetail",
                            data: { connectionString: ControlIntializer.connectionKey.value, employeeNumber: document.getElementById(GlobEmployeeNumber).value, clientCode: ddlClient.get_selectedItem().get_value(),
                                asmtId: ddAssignment.get_selectedItem().get_value(), fromDate: DateInFormat(document.getElementById(dutyDate).innerText), toDate: DateInFormat(document.getElementById(dutyDate).innerText),
                                postCode: ddlPost.get_selectedItem().get_value(), insertStatus: "SINGLE", areaId: ddlArea.get_selectedItem().get_value(),
                                areaInchargeNumber: VariableIntializer.SessionAreaInchargeNumber, isAreaIncharge: VariableIntializer.IsAreaIncharge, screenType: strScreenType,
                                companyCode: VariableIntializer.SessionCompanyCode, hrLocationCode: VariableIntializer.SessionHrLocationCode,
                                locationAutoId: VariableIntializer.SessionLocationAutoId, modifiedBy: VariableIntializer.SessionUserId
                            },
                            // contentType: "application/text; charset=utf-8",
                            async: false,
                            success: OnGetEmployeeDetailComplete,
                            error: OnWSRequestFailed
                        });
                    });

                    HideDivs();
                    return;
                }

                break;
            case "ShiftPatternCode":
                if (ddlAttendanceType.get_selectedItem().get_value() == 'Sch') {
                    if (keyId == 13 || keyId == 9) { //Enter Key Pressed
                        if (ControlIntializer.LBShiftPatterns.length != 0) {

                            var elList = ControlIntializer.LBShiftPatterns;
                            var el = GlobShiftPatternCode;
                            if (document.getElementById(savedShiftPatternCode).value == "") {
                                if (elList.selectedIndex >= 0) {
                                    document.getElementById(el).value = elList.options[elList.selectedIndex].text;
                                    document.getElementById(el).focus();
                                    ControlIntializer.DivShiftPatterns.style.display = "none";
                                }
                            }
                            var validPatternflag = 0;
                            for (var i = 0; i < elList.length; i++) {
                                if (elList.options[i].text.toLowerCase() == document.getElementById(GlobShiftPatternCode).value.toLowerCase()) {
                                    if (keyId == 13) {
                                        validPatternflag = 1;
                                        ControlIntializer.HFRowIndex.value = "";
                                        SaveDataPatternWise(obj);

                                    }
                                    HideDivs();
                                    return;
                                } else {
                                    validPatternflag = 0;

                                }
                            }
                            if (validPatternflag == 0) {
                                alert('Invalid ShiftPattern ');
                                return;
                            }
                        }
                    } else {
                        return;
                    }
                }
            default:
                break;
        }
    });
}

function CheckValidShiftPattern() {

    if (ddlAttendanceType.get_selectedItem().get_value() == 'Act') {
        return true;
    } else {
        var elList = ControlIntializer.LBShiftPatterns;
        var validPatternflag = 0;
        for (var i = 0; i < elList.length; i++) {
            if (elList.options[i].text.toLowerCase() == document.getElementById(GlobShiftPatternCode).value.toLowerCase()) {
                validPatternflag = 1;
                break;
            } else {
                validPatternflag = 0;

            }
        }
        if (validPatternflag == 0) {
            return false;
        } else {
            return true;
        }
    }
}
// This function is called when enter key is pressed on the Shift PatternCode/Shift PatternCode Sequence
function SaveDataPatternWise(obj) {
    InitalizeControls();
    if (document.getElementById(GlobEmployeeNumber).value == "") {
        alert(VariableIntializer.EmployeecannotbeleftBlank);
        return;
    }

    if (document.getElementById(GlobShiftPatternCode).value != "") {

        $(document).ready(function () {
            $.ajax({
                type: "POST",
                url: "../Webservices/WebMethods.asmx/InsertData",
                data: { comnnectionString: ControlIntializer.connectionKey.value, locationAutoId: VariableIntializer.SessionLocationAutoId, clientCode: ddlClient.get_selectedItem().get_value(),
                    asmtId: ddAssignment.get_selectedItem().get_value(), fromDate: DateInFormat(ControlIntializer.HFFromDate.value), toDate: DateInFormat(ControlIntializer.HFMaxDate.value),
                    employeeNumber: document.getElementById(GlobEmployeeNumber).value, shiftPatternCode: document.getElementById(GlobShiftPatternCode).value,
                    patternPositioon: document.getElementById(GlobPatternPosition).value, rowNumber: document.getElementById(GlobRowNumber).innerText, post: ddlPost.get_selectedItem().get_value(),
                    attendanceType: ddlAttendanceType.get_selectedItem().get_value(), weekNo: ddlWeek.get_selectedItem().get_value(), sessionId: ControlIntializer.HFCurrentSessionID.value,
                    modifiedBy: VariableIntializer.SessionUserId, clientName: ddlClient.get_selectedItem().get_text(), assignmentName: ddAssignment.get_selectedItem().get_text(),
                    postName: ddlPost.get_selectedItem().get_text(), areaId: ddlArea.get_selectedItem().get_value(),
                    areaInchargeNumber: VariableIntializer.SessionAreaInchargeNumber, isAreaIncharge: VariableIntializer.IsAreaIncharge
                },
                ////contentType: "application/text; charset=utf-8",
                async: false,
                success: OnInsertRecordsComplete,
                error: OnWSRequestFailed
            });
        });
    }
}


function OnInsertRecordsComplete(result) {
    HideDivs();
    var j = 0;
    ControlIntializer.spanErrorMessage.innerHTML = "";
    ControlIntializer.spanErrorMessage.innerHTML = result.documentElement.textContent;

    var radWindowMessage = ControlIntializer.RadWindowMessage;
    if (document.getElementById('lblMsgID' + j).innerHTML == "1") { //INSERT Successfull Without any Exception

        radWindowMessage.close();
        EnableProceedAndClick();
    }
    else if (document.getElementById('lblMsgID' + j).innerHTML == "5") {

        radWindowMessage.show();
        if (document.getElementById('HFIsDuplicateExists0') == "[object]") {

            ControlIntializer.btnOverWrite.style.display = "none";
            ControlIntializer.btnCheckAll.style.display = "none";
            ControlIntializer.btnUnCheckAll.style.display = "none";

            if (document.getElementById('HFIsDuplicateExists0').value == "1") {
                ControlIntializer.btnOverWrite.style.display = 'block';
                ControlIntializer.btnCheckAll.style.display = "block";
                // ControlIntializer.btnOverWrite.focus();
                //$('#btnOverWrite').focus();
            }
            else {
                ControlIntializer.btnOverWrite.style.display = "none";
                ControlIntializer.btnCheckAll.style.display = "none";
                ControlIntializer.btnUnCheckAll.style.display = "none";
                ControlIntializer.btnOverWrite.style.display = 'none';
            }
        }
        else {
            ControlIntializer.btnOverWrite.style.display = "none";
            ControlIntializer.btnCheckAll.style.display = "none";
            ControlIntializer.btnUnCheckAll.style.display = "none";
        }
    }


}


//
// This function is used to check all CHECK BOX when duplicate recors Div appears
function CheckAllMultiRecord(status) {
    var totalCount = document.getElementById('totalDuplicatedCount0').value;
    for (var i = 0; i < totalCount; i++) {
        if (document.getElementById('chk' + i) == "[object]") {
            if (document.getElementById('chk' + i).checked == false) {
                if (status == "preferred") {
                    if (document.getElementById('HFIsnotapreferedday' + i).value == "1") {
                        document.getElementById('chk' + i).checked = true;

                    } else {
                        document.getElementById('chk' + i).checked = false;
                    }
                } else {
                    document.getElementById('chk' + i).checked = true;
                }
            }
        }
    }
    if (status == "preferred") {
        OverWriteMultiRecord();
    }
    else {
        ControlIntializer.btnUnCheckAll.style.display = "none";

        ControlIntializer.btnUnCheckAll.style.display = 'block';
        ControlIntializer.btnCheckAll.style.display = 'none';
    }

}

// This function is used to uncheck all CHECK BOX when duplicate recors Div appears
function UnCheckAllMultiRecord() {
    var totalCount = document.getElementById('totalDuplicatedCount0').value;
    for (var i = 0; i < totalCount; i++) {
        if (document.getElementById('chk' + i) == "[object]") {
            if (document.getElementById('chk' + i).checked == true) {
                document.getElementById('chk' + i).checked = false;
            }
        }
    }
    ControlIntializer.btnCheckAll.style.display = "none";
    ControlIntializer.btnUnCheckAll.style.display = "none";
    ControlIntializer.btnCheckAll.style.display = 'block';
}

function ShortCutOverWriteRecord() {

    CheckAllMultiRecord("preferred");
}

// This function is used to overwrite multiple records
function OverWriteMultiRecord() {
    InitalizeControls();
    try {
        var i;
        var xmlString = "";
        var overwriteStatus = 0;
        var employeeNumber = "";
        employeeNumber = document.getElementById(GlobEmployeeNumber).value;
        for (i = 0; i < parseInt(document.getElementById('totalDuplicatedCount0').value); i++) {
            var k = parseInt(i);

            if (document.getElementById('chk' + parseInt(i)) == '[object]') {

                var overwriteChecked = document.getElementById('chk' + parseInt(i)).checked;
                if (overwriteChecked == true) {
                    var shiftPatternCode = document.getElementById(GlobShiftPatternCode).value
                    var rowNumber = document.getElementById('HFRowNumberToOverWrite' + parseInt(i)).value;
                    employeeNumber = document.getElementById('HFEmployeeNumberToOverWrite' + parseInt(i)).value;

                    var patternPosition = document.getElementById('HFDuplicatePatternPosition' + parseInt(i)).value;

                    GlobOverwriteStatus = 1;
                    xmlString = xmlString + "<Record>";
                    xmlString = xmlString + "<DutyDate>" + DateInFormat(document.getElementById('HFDutyDateToOverWrite' + parseInt(i)).value) + "</DutyDate>";
                    xmlString = xmlString + "<ShiftCode>" + document.getElementById('HFShiftCodeToOverWrite' + parseInt(i)).value + "</ShiftCode>";
                    xmlString = xmlString + "<PatternPosition>" + patternPosition + "</PatternPosition>";
                    xmlString = xmlString + "<ShiftPatternCode>" + shiftPatternCode + "</ShiftPatternCode>";
                    xmlString = xmlString + "<FromTimeToOverwrite>" + document.getElementById('HFTimeFromToOverwrite' + parseInt(i)).value + "</FromTimeToOverwrite>";
                    xmlString = xmlString + "<ToTimeToOverwrite>" + document.getElementById('HFToTimeToOverwrite' + parseInt(i)).value + "</ToTimeToOverwrite>";
                    xmlString = xmlString + "<ScheduleRosterAutoIDToOverwrite>" + document.getElementById('HFDuplicateSchRosterAutoIDToOverWrite' + parseInt(i)).value + "</ScheduleRosterAutoIDToOverwrite>";
                    xmlString = xmlString + "<DupSchRosterAutoID>" + document.getElementById('HFDuplicateSchRosterAutoID' + parseInt(i)).value + "</DupSchRosterAutoID>";
                    xmlString = xmlString + "<SoNo>" + document.getElementById('HFSoNo' + parseInt(i)).value + "</SoNo>";
                    xmlString = xmlString + "<SoLineNo>" + document.getElementById('HFSoLineNo' + parseInt(i)).value + "</SoLineNo>";
                    xmlString = xmlString + "<SoRank>" + document.getElementById('HFSoRank' + parseInt(i)).value + "</SoRank>";
                    xmlString = xmlString + "<PostAutoID>" + document.getElementById('HFPostAutoID' + parseInt(i)).value + "</PostAutoID>";
                    xmlString = xmlString + "<RowNumber>" + rowNumber + "</RowNumber>";
                    xmlString = xmlString + "<RowId>" + i + "</RowId>";
                    xmlString = xmlString + "</Record>";
                    overwriteStatus = 1;
                }
                else {
                    GlobOverwriteStatus = 0;
                }
            }


        }
        xmlString = "<root>" + xmlString + "</root>";
        if (overwriteStatus == 1) {

            $(document).ready(function () {
                $.ajax({
                    type: "POST",
                    url: "../Webservices/WebMethods.asmx/OverwriteSchedule",
                    data: { comnnectionString: ControlIntializer.connectionKey.value, clientCode: ddlClient.get_selectedItem().get_value(), asmtId: ddAssignment.get_selectedItem().get_value(),
                        postCode: ddlPost.get_selectedItem().get_value(), employeeNumber: employeeNumber, weekNumber: ddlWeek.get_selectedItem().get_value(),
                        locationAutoId: VariableIntializer.SessionLocationAutoId, modifiedBy: VariableIntializer.SessionUserId,
                        scheduleToOverwriteXml: xmlString, attendanceType: ddlAttendanceType.get_selectedItem().get_value()
                    },

                    async: false,
                    success: OnSucessfulOverwrite,
                    error: OnWSRequestFailed
                });
            });
        }
        else {
        }

    }
    catch (Error) {
        return;
    }
}

function OnSucessfulOverwrite(result) {
    var radWindowMessage = ControlIntializer.RadWindowMessage;

    if (result.documentElement.textContent != "") {
        ControlIntializer.spanErrorMessage.innerHTML = result.documentElement.textContent;
        radWindowMessage.show();
        return;
    }

    radWindowMessage.close();
    ControlIntializer.spanErrorMessage.innerHTML = "";
    EnableProceedAndClick();
}

// This function is used to called after record has been deleted from gridview
function OnDeleteRecordsComplete(strOutput) {
    var arrsplit = new Array;
    arrsplit = strOutput.documentElement.textContent.split(",");
    if (arrsplit[0] == "2") {
        alert(VariableIntializer.AuthorizedRotaCannotbeDeleted);
        return false;
    }
    /* ================================================================================================*/

    try {
        var columnIndex;
        var strReversedString = GlobEmployeeShiftCode.split('').reverse().join('');
        columnIndex = strReversedString.substring(0, 2);
        if (isNaN(columnIndex)) {
            columnIndex = strReversedString.substring(0, 1);
        }
        else {
            columnIndex = columnIndex.toString().split('').reverse().join('');
        }

        globCopyStatus = "0";
        var strShiftCode = "txtEmpShiftDutyDate" + columnIndex;
        var strTimeFrom = "txtTimeFrom" + columnIndex;
        var strTimeTo = "txtTimeTo" + columnIndex;
        var strScheduleRosterAutoId = "HFSchRosterAutoID" + columnIndex;
        GlobEmployeeShiftCode = getClientId(GlobObject, strShiftCode);
        GlobEmployeeTimeFrom = getClientId(GlobObject, strTimeFrom);
        GlobEmployeeTimeTo = getClientId(GlobObject, strTimeTo);
        GlobEmployeeSchRosterAutoID = getClientId(GlobObject, strScheduleRosterAutoId);
        document.getElementById(GlobEmployeeSchRosterAutoID).value = "";
        document.getElementById(GlobEmployeeShiftCode).value = "";
        document.getElementById(GlobEmployeeTimeFrom).value = "";
        document.getElementById(GlobEmployeeTimeTo).value = "";
        document.getElementById(getClientId(GlobObject, strShiftCode)).focus();
        var sch = arrsplit[2];
        var arrRow = new Array();
        arrRow = GlobRowNumber.split("_");
        var rowNum = arrRow[1].substring(3, 5) - 1;

        var reqSch = document.getElementById('gvScheduleRoster_ctl01_lblReqSch' + columnIndex).innerText;
        var arr = new Array();
        arr = reqSch.trim().split("/");


        if (parseFloat(sch) == parseFloat("0.0")) {
            document.getElementById('gvScheduleRoster_ctl01_reqDiv' + columnIndex).style.backgroundColor = "gray";
        }
        else if (parseFloat(arr[0].trim()) == parseFloat(sch)) {
            document.getElementById('gvScheduleRoster_ctl01_reqDiv' + columnIndex).style.backgroundColor = "green";
        }
        else if (parseFloat(arr[0].trim()) < parseFloat(sch)) {
            document.getElementById('gvScheduleRoster_ctl01_reqDiv' + columnIndex).style.backgroundColor = "red";
        }
        else if (parseFloat(arr[0].trim()) > parseFloat(sch)) {
            document.getElementById('gvScheduleRoster_ctl01_reqDiv' + columnIndex).style.backgroundColor = "yellow";
        }
        if (ControlIntializer.HFSoType.value.toLowerCase() == "FSO".toLowerCase()) {
            document.getElementById('gvScheduleRoster_ctl01_lblReqSch' + columnIndex).innerText = sch + "/" + sch;
            document.getElementById('gvScheduleRoster_ctl01_reqDiv' + columnIndex).style.backgroundColor = "green";
        }
        else {
            document.getElementById('gvScheduleRoster_ctl01_lblReqSch' + columnIndex).innerText = arr[0].trim() + "/" + sch;
        }

        document.getElementById('gvScheduleRoster_ctl01_HFReqSch' + columnIndex).value = document.getElementById('gvScheduleRoster_ctl01_lblReqSch' + columnIndex).innerText;
    }
    catch (Error) {
        EnableProceedAndClick();
    }
    if (document.getElementById(GlobShiftPatternCode) == "[object]") {
        document.getElementById(GlobShiftPatternCode).disabled = false;
    }
    ControlIntializer.divShift.style.display = "none";
}

function SaveData() {
    InitalizeControls();
    var strPatternPosition = document.getElementById(GlobPatternPosition).value;
    var strShiftPatternCode = document.getElementById(GlobShiftPatternCode).value;
    var schRosterAutoId = document.getElementById(GlobEmployeeSchRosterAutoID).value;
    if (document.getElementById(GlobEmployeeSchRosterAutoID).value == "") {
        schRosterAutoId = "0";
    }

    var timeFrom;
    var timeTo;
    var shiftCode;
    var varDutyDate;

    if (GlobRightClickWeekOfClick == "1") {
        var columnIndex = parseInt(ControlIntializer.MouseClickColumnID.value) - 1;
        var strDutyDate = "lblHeaderDutyDate" + columnIndex;
        var dutyDate = 'gvScheduleRoster_ctl01_' + strDutyDate;

        varDutyDate = DateInFormat(document.getElementById(dutyDate).innerText);

        timeFrom = "00:00";
        timeTo = "00:00";
        shiftCode = "0";

    } else {
        timeFrom = document.getElementById(GlobEmployeeTimeFrom).value;
        timeTo = document.getElementById(GlobEmployeeTimeTo).value;
        shiftCode = document.getElementById(GlobEmployeeShiftCode).value;
        varDutyDate = DateInFormat(document.getElementById(GlobEmployeeDutyDate).innerText);
    }
    GlobRightClickWeekOfClick = "0";
    $.ajax({
        type: "POST",
        url: "../Webservices/WebMethods.asmx/InsertDataOfDate",
        data: { connectionString: ControlIntializer.connectionKey.value, clientCode: ddlClient.get_selectedItem().get_value(), asmtId: ddAssignment.get_selectedItem().get_value(),
            postCode: ddlPost.get_selectedItem().get_value(), employeeNumber: document.getElementById(GlobEmployeeNumber).value,
            dutyDate: varDutyDate, shiftCode: shiftCode,
            weekNo: ddlWeek.get_selectedItem().get_value(), shiftPatternCode: strShiftPatternCode, patternPosition: strPatternPosition,
            timeFrom: timeFrom, timeTo: timeTo, scheduleRosterAutoId: schRosterAutoId,
            rowNumber: document.getElementById(GlobRowNumber).innerText, screenType: ddlAttendanceType.get_selectedItem().get_value(),
            fromDate: DateInFormat(ControlIntializer.HFFromDate.value), toDate: DateInFormat(ControlIntializer.HFMaxDate.value),
            currentSessionId: ControlIntializer.HFCurrentSessionID.value, locationAutoId: VariableIntializer.SessionLocationAutoId, modifiedBy: VariableIntializer.SessionUserId,
            clientName: ddlClient.get_selectedItem().get_text(), assignmentName: ddAssignment.get_selectedItem().get_text(), postName: ddlPost.get_selectedItem().get_text()
        },

        async: false,
        success: OnInsertDataOfDateComplete,
        error: OnWSRequestFailed
    });
}

var controlFocus;
function OnInsertDataOfDateComplete(result) {
    ControlIntializer.spanErrorMessage.innerHTML = "";
    ControlIntializer.spanErrorMessage.innerHTML = result.documentElement.textContent;

    var radWindowMessage = ControlIntializer.RadWindowMessage;
    var j = 0;

    var totalCount = document.getElementById('totalDuplicatedCount' + j).value;
    if (document.getElementById('HFIsDuplicateExists0') == "[object]") {

        ControlIntializer.btnOverWrite.style.display = "none";
        ControlIntializer.btnCheckAll.style.display = "none";
        ControlIntializer.btnUnCheckAll.style.display = "none";

        if (document.getElementById('HFIsDuplicateExists0').value == "1") {
            radWindowMessage.show();
            ControlIntializer.btnOverWrite.style.display = 'block';
            ControlIntializer.btnCheckAll.style.display = "block";

        }
        else {
            ControlIntializer.btnOverWrite.style.display = "none";
            ControlIntializer.btnCheckAll.style.display = "none";
            ControlIntializer.btnUnCheckAll.style.display = "none";
            radWindowMessage.close();
            ControlIntializer.btnOverWrite.style.display = 'none';
        }
    }
    else {
        ControlIntializer.btnOverWrite.style.display = "none";
        ControlIntializer.btnCheckAll.style.display = "none";
        ControlIntializer.btnUnCheckAll.style.display = "none";
    }



    if (totalCount > 0) {
        if (document.getElementById('lblMsgID' + j)) {
        //if (document.getElementById('lblMsgID' + j) == '[object]' || document.getElementById('lblMsgID' + j) == [Object, XMLDocument]) {
            if (document.getElementById('lblMsgID' + j).innerHTML == '5') {
                //document.getElementById('tr' + j).style.display = "block"; //mmm over write message
                radWindowMessage.show();
            }
            else if (document.getElementById('lblMsgID' + j).innerHTML == "1") {

                try {
                    document.getElementById(GlobEmployeeShiftCode).value = document.getElementById('HFShiftCodeToOverWrite' + j).value;
                    document.getElementById(GlobEmployeeTimeFrom).value = document.getElementById('HFTimeFromToOverwrite' + j).value;
                    document.getElementById(GlobEmployeeTimeTo).value = document.getElementById('HFToTimeToOverwrite' + j).value;
                    document.getElementById(GlobEmployeeDetails).innerText = "";
                    document.getElementById(GlobEmployeeDetails).innerText = document.getElementById(GlobEmployeeTimeFrom).value + '-' + document.getElementById(GlobEmployeeTimeTo).value;
                }
                catch (error) { }

                if (document.getElementById('lblMsgShiftDuplicate' + j).innerHTML == 'WeekOffAndDutyConflicts') {
                    EnableProceedAndClick();
                    return;
                }

                if (ddlAttendanceType.get_selectedItem().get_value() == 'Act') {
                    if (document.getElementById('HFOT' + j).value > 0) {
                        OTReason('DT0002');
                    }
                }
                document.getElementById('tr' + j).style.display = "none";
                try {
                    var columnIndex;
                    var strReversedString;
                    strReversedString = GlobEmployeeShiftCode.split('').reverse().join('');
                    columnIndex = strReversedString.substring(0, 2);
                    if (isNaN(columnIndex)) {
                        columnIndex = strReversedString.substring(0, 1);
                    }
                    else {
                        columnIndex = columnIndex.toString().split('').reverse().join('');
                    }
                    var nextColumnIndex;
                    if (globCopyStatus == "1") {
                        nextColumnIndex = parseInt(columnIndex) + 1;
                    }
                    else {
                        nextColumnIndex = columnIndex;
                    }

                    var sch = document.getElementById('HFSch' + j).value;
                    var arrRow = new Array();
                    arrRow = GlobRowNumber.split("_");
                    var rowNum = arrRow[1].substring(3, 5) - 1;

                    var reqSch = document.getElementById('gvScheduleRoster_ctl01_lblReqSch' + nextColumnIndex).innerText;
                    var arr = new Array();
                    arr = reqSch.trim().split("/");
                    if (parseFloat(sch) == parseFloat("0.0")) {
                        document.getElementById('gvScheduleRoster_ctl01_reqDiv' + nextColumnIndex).style.backgroundColor = "gray";
                    }
                    else if (parseFloat(arr[0].trim()) == parseFloat(sch)) {

                        document.getElementById('gvScheduleRoster_ctl01_reqDiv' + nextColumnIndex).style.backgroundColor = "green";
                    }
                    else if (parseFloat(arr[0].trim()) < parseFloat(sch)) {
                        document.getElementById('gvScheduleRoster_ctl01_reqDiv' + nextColumnIndex).style.backgroundColor = "red";
                    }
                    else if (parseFloat(arr[0].trim()) > parseFloat(sch)) {
                        document.getElementById('gvScheduleRoster_ctl01_reqDiv' + nextColumnIndex).style.backgroundColor = "yellow";
                    }

                    if (ControlIntializer.HFSoType.value.toLowerCase() == "FSO".toLowerCase()) {
                        document.getElementById('gvScheduleRoster_ctl01_lblReqSch' + nextColumnIndex).innerText = sch + "/" + sch;
                        document.getElementById('gvScheduleRoster_ctl01_reqDiv' + nextColumnIndex).style.backgroundColor = "green";
                    }
                    else {
                        document.getElementById('gvScheduleRoster_ctl01_lblReqSch' + nextColumnIndex).innerText = arr[0].trim() + "/" + sch;
                    }
                    document.getElementById('gvScheduleRoster_ctl01_HFReqSch' + nextColumnIndex).value = document.getElementById('gvScheduleRoster_ctl01_lblReqSch' + nextColumnIndex).innerText;
                    
                    var columnIndexDuplicate;
                    if (globCopyStatus == "1") {
                        strReversedString = GlobEmployeeShiftCode.split('').reverse().join('');
                        columnIndexDuplicate = strReversedString.substring(0, 2);
                        if (isNaN(columnIndexDuplicate)) {
                            columnIndexDuplicate = strReversedString.substring(0, 1);
                        }
                        else {
                            columnIndexDuplicate = columnIndexDuplicate.toString().split('').reverse().join('');
                        }
                        columnIndexDuplicate = (parseInt(columnIndexDuplicate) + 1);
                        var strScheduleRosterAutoId = "HFSchRosterAutoID" + columnIndexDuplicate;
                        GlobEmployeeSchRosterAutoID = getClientId(GlobObject, strScheduleRosterAutoId);

                        var strShiftCode = "txtEmpShiftDutyDate" + columnIndexDuplicate;
                        var strTimeFrom = "txtTimeFrom" + columnIndexDuplicate;
                        var strTimeTo = "txtTimeTo" + columnIndexDuplicate;
                        var empDetails = "lblDutyDate" + columnIndexDuplicate;
                        GlobEmployeeDetails = getClientId(GlobObject, empDetails);

                        GlobEmployeeShiftCode = getClientId(GlobObject, strShiftCode);
                        GlobEmployeeTimeFrom = getClientId(GlobObject, strTimeFrom);
                        GlobEmployeeTimeTo = getClientId(GlobObject, strTimeTo);

                        document.getElementById(GlobEmployeeShiftCode).value = document.getElementById('HFShiftCodeToOverWrite' + j).value;
                        document.getElementById(GlobEmployeeTimeFrom).value = document.getElementById('HFTimeFromToOverwrite' + j).value;
                        document.getElementById(GlobEmployeeTimeTo).value = document.getElementById('HFToTimeToOverwrite' + j).value;
                        document.getElementById(GlobEmployeeDetails).innerText = document.getElementById(GlobEmployeeTimeFrom).value + '-' + document.getElementById(GlobEmployeeTimeTo).value;

                    }

                    if ((parseInt(columnIndex) + 1) < 33) {
                        if (globCopyStatus == "1") {

                            columnIndex = columnIndexDuplicate;
                        }
                        else {
                            columnIndex = parseInt(columnIndex) + 1;
                        }

                        var strShiftCode = "txtEmpShiftDutyDate" + (parseInt(columnIndex));
                        controlFocus = getClientId(GlobObject, strShiftCode);
                        document.getElementById(getClientId(GlobObject, strShiftCode)).focus();
                    }
                    if (document.getElementById(GlobEmployeeSchRosterAutoID) || document.getElementById(GlobEmployeeSchRosterAutoID) == "[Object HTMLInputElement]") {

                        document.getElementById(GlobEmployeeSchRosterAutoID).value = document.getElementById('HFDuplicateSchRosterAutoIDToOverWrite' + j).value;
                    }
                }
                catch (error) {
                }
            }
            else if (document.getElementById('lblMsgShiftDuplicate' + j).innerHTML == Converted) {
                document.getElementById('tr' + j).style.display = "block";
                radWindowMessage.show();
                ControlIntializer.btnOverWrite.style.display = "none";
                ControlIntializer.btnCheckAll.style.display = "none";
                ControlIntializer.btnUnCheckAll.style.display = "none";

            }
            else {
                radWindowMessage.close();
                ControlIntializer.btnOverWrite.style.display = "none";
                ControlIntializer.btnCheckAll.style.display = "none";
                ControlIntializer.btnUnCheckAll.style.display = "none";

            }
        }

    }

}

function LoadScheduleDetailsOnClientClick(strObject) {
    try {

        InitalizeControls();
        var cellOtherAssignmentAutoId;
        if (strObject == 'Back') {
            cellOtherAssignmentAutoId = ControlIntializer.lblOldAsmtCode.innerText;
        }
        else if (strObject == "PostSearch") {
            var ddlPostSearch = ControlIntializer.ddlPostSearch;
            cellOtherAssignmentAutoId = ddlPostSearch.get_selectedItem().get_value();
            ControlIntializer.lblOldAsmtCode.innerText = ddlPost.get_selectedItem().get_value();
            ddlPostSearch.clearSelection();
        }
        else {
            var gvScheduleRoster = ControlIntializer.gvScheduleRoster;
            var rowClientId = gvScheduleRoster.rows[parseInt(ControlIntializer.MouseClickRowID.value) + 1].cells[0].childNodes[0];
            var columnIndex = parseInt(ControlIntializer.MouseClickColumnID.value) - 1;
            var otherAssignmentAutoId = "lblOtherAssignmentAutoId" + columnIndex;
            cellOtherAssignmentAutoId = document.getElementById(getClientId(rowClientId, otherAssignmentAutoId)).innerText;
            ControlIntializer.lblOldAsmtCode.innerText = ddlPost.get_selectedItem().get_value();
        }

        var arr = new Array;
        arr = cellOtherAssignmentAutoId.split("^");
        if (arr[1] == "0") {
            return false;
        }
        if (cellOtherAssignmentAutoId == "-1") {
            return false;
        }

        if (cellOtherAssignmentAutoId != "") {

            $(document).ready(function () {
                $.ajax({
                    type: "POST",
                    url: "../Webservices/WebMethods.asmx/GetAssignmentClientAndPostBasedOnAsmtAutoId",
                    data: { connectionString: ControlIntializer.connectionKey.value, otherAssignmentDetail: cellOtherAssignmentAutoId },
                    /////contentType: "application/text; charset=utf-8",
                    async: false,
                    success: function (result) { OnGetAssignmentClientAndPostBasedOnAsmtAutoIdComplete(result, ""); },
                    error: OnWSRequestFailed
                });
            });
        }
    }
    catch (error) { return false; }
    return false;
}

function LoadScheduleDetailsOnEmployeeSearchClick(cellOtherAssignmentAutoId, dutydate) {
    InitalizeControls();
    try {
        ControlIntializer.hfEmployeeSearchFinishStatus.value = "";
        var arr = new Array;
        arr = cellOtherAssignmentAutoId.split("^");
        if (arr[1] == "0") {
            return false;
        }
        if (cellOtherAssignmentAutoId == "-1") {
            return false;
        }

        if (cellOtherAssignmentAutoId != "") {

            ControlIntializer.hfEmployeeSearchDutyDate.value = dutydate;
            $(document).ready(function () {
                $.ajax({
                    type: "POST",
                    url: "../Webservices/WebMethods.asmx/GetAssignmentClientAndPostBasedOnAsmtAutoId",
                    data: { connectionString: ControlIntializer.connectionKey.value, otherAssignmentDetail: cellOtherAssignmentAutoId },
                    /////contentType: "application/text; charset=utf-8",
                    async: false,
                    success: function (result) { OnGetAssignmentClientAndPostBasedOnAsmtAutoIdComplete(result, dutydate); },
                    error: OnWSRequestFailed
                });
            });
        }
    }
    catch (error) { return false; }

}


function OnGetAssignmentClientAndPostBasedOnAsmtAutoIdComplete(result, dutydate) {
    globPost = "";
    var xmlDoc = jQuery.parseXML(result.documentElement.textContent);
    ControlIntializer.hfEmployeeSearchPostCode.value = $(xmlDoc).find('PostDetail').text();
    ControlIntializer.hfEmployeeSearchAsmtId.value = $(xmlDoc).find('AsmtId').text();

    var radWindowEmployeeSearch = ControlIntializer.RadWindowEmployeeSearch;
    radWindowEmployeeSearch.close();
    ControlIntializer.hfEmployeeSearchClientCode.value = $(xmlDoc).find('ClientCode').text();

    if (dutydate != "") {
        var arr = dutydate.split(" ");
        var strMonthName;
        var strDay, strYear;

        strMonthName = arr[1];
        strDay = arr[0];
        strYear = arr[2];
        var monthNumber;
        if (strMonthName.toUpperCase() == VariableIntializer.January.toUpperCase() || strMonthName.toUpperCase() == "JAN" || strMonthName.toUpperCase() == VariableIntializer.January.substring(0, 3).toUpperCase()) {

            monthNumber = 1;
        }
        else if (strMonthName.toUpperCase() == VariableIntializer.February.toUpperCase() || strMonthName.toUpperCase() == "FEB" || strMonthName.toUpperCase() == VariableIntializer.February.substring(0, 3).toUpperCase()) {
            monthNumber = 2;
        }
        else if (strMonthName.toUpperCase() == VariableIntializer.March.toUpperCase() || strMonthName.toUpperCase() == "MAR" || strMonthName.toUpperCase() == VariableIntializer.March.substring(0, 3).toUpperCase()) {
            monthNumber = 3;

        }
        else if (strMonthName.toUpperCase() == VariableIntializer.April.toUpperCase() || strMonthName.toUpperCase() == "APR" || strMonthName.toUpperCase() == VariableIntializer.April.substring(0, 3).toUpperCase()) {
            monthNumber = 4;
        }
        else if (strMonthName.toUpperCase() == VariableIntializer.May.toUpperCase() || strMonthName.toUpperCase() == "MAY" || strMonthName.toUpperCase() == VariableIntializer.May.substring(0, 3).toUpperCase()) {
            monthNumber = 5;
        }
        else if (strMonthName.toUpperCase() == VariableIntializer.June.toUpperCase() || strMonthName.toUpperCase() == "JUN" || strMonthName.toUpperCase() == VariableIntializer.June.substring(0, 3).toUpperCase()) {
            monthNumber = 6;
        }
        else if (strMonthName.toUpperCase() == VariableIntializer.July.toUpperCase() || strMonthName.toUpperCase() == "JUL" || strMonthName.toUpperCase() == VariableIntializer.July.substring(0, 3).toUpperCase()) {
            monthNumber = 7;
        }
        else if (strMonthName.toUpperCase() == VariableIntializer.August.toUpperCase() || strMonthName.toUpperCase() == "AUG" || strMonthName.toUpperCase() == VariableIntializer.August.substring(0, 3).toUpperCase()) {
            monthNumber = 8;
        }
        else if (strMonthName.toUpperCase() == VariableIntializer.September.toUpperCase() || strMonthName.toUpperCase() == "SEP" || strMonthName.toUpperCase() == VariableIntializer.September.substring(0, 3).toUpperCase()) {
            monthNumber = 9;
        }
        else if (strMonthName.toUpperCase() == VariableIntializer.October.toUpperCase() || strMonthName.toUpperCase() == "OCT" || strMonthName.toUpperCase() == VariableIntializer.October.substring(0, 3).toUpperCase()) {
            monthNumber = 10;
        }
        else if (strMonthName.toUpperCase() == VariableIntializer.November.toUpperCase() || strMonthName.toUpperCase() == "NOV" || strMonthName.toUpperCase() == VariableIntializer.November.substring(0, 3).toUpperCase()) {
            monthNumber = 11;
        }
        else if (strMonthName.toUpperCase() == VariableIntializer.December.toUpperCase() || strMonthName.toUpperCase() == "DEC" || strMonthName.toUpperCase() == VariableIntializer.December.substring(0, 3).toUpperCase()) {
            monthNumber = 12;
        }
        var itemMonth = ddlMonth.findItemByValue(monthNumber);
        itemMonth.select();
    }
    else {
        FillClient();

    }
}







