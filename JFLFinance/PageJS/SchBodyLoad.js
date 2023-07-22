/*
    This file contains javascript functions which are used whaen page is loaded first time (functions which are executed on body load event).
      
*/

function FillWeekDropDown() {

    var objVariableIntializer = new window.VariableInitialization();
    var objControlIntializer = new window.ControlsInitialization();
    InitalizeControlsAndVariables(objControlIntializer, objVariableIntializer);
    $(document).ready(function () {
        $.ajax({
            type: "POST",
            url: "../Webservices/WebMethods.asmx/GetWeek",
            data: { connectionString: ControlIntializer.connectionKey.value, locationAutoId: VariableIntializer.SessionLocationAutoId, month: ddlMonth.get_selectedItem().get_value(), year: txtYear.get_value() },
            ////contentType: "application/text; charset=utf-8",
            dataType: 'xml',
            async: false,
            success: OnGetWeek,
            error: OnWSRequestFailed
        });
    });
}

function OnGetWeek(result) {
    //var xmlDoc = jQuery.parseXML(result.text);
    var xmlDoc = jQuery.parseXML(result.documentElement.textContent);
    var selectedDate = 0;
    var l = 0;
    var multilingualStartDate;
    var multilingualStartMonth;
    var multilingualEndMonth;
    ddlWeek.clearItems();
    //$('#' + ddlWeek.id).empty();

    if (xmlDoc) {
        $(xmlDoc).find('Table').each(function () {
            comboItem = new window.Telerik.Web.UI.RadComboBoxItem();
            var arr = new Array;
            arr = $(this).find('StartDate').text().split(" ");
            var arr1 = new Array;
            arr1 = $(this).find('EndDate').text().split(" ");

            switch (arr[1].toUpperCase()) {
                case "JAN":
                    multilingualStartMonth = VariableIntializer.January;
                    break;
                case "FEB":
                    multilingualStartMonth = VariableIntializer.February;
                    break;
                case "MAR":
                    multilingualStartMonth = VariableIntializer.March;
                    break;
                case "APR":
                    multilingualStartMonth = VariableIntializer.April;
                    break;
                case "MAY":
                    multilingualStartMonth = VariableIntializer.May;
                    break;
                case "JUN":
                    multilingualStartMonth = VariableIntializer.June;
                    break;
                case "JUL":
                    multilingualStartMonth = VariableIntializer.July;
                    break;
                case "AUG":
                    multilingualStartMonth = VariableIntializer.August;
                    break;
                case "SEP":
                    multilingualStartMonth = VariableIntializer.September;
                    break;
                case "OCT":
                    multilingualStartMonth = VariableIntializer.October;
                    break;
                case "NOV":
                    multilingualStartMonth = VariableIntializer.November;
                    break;
                case "DEC":
                    multilingualStartMonth = VariableIntializer.December;
                    break;
                default:
                    break;
            }

            switch (arr1[1].toUpperCase()) {
                case "JAN":
                    multilingualEndMonth = VariableIntializer.January;
                    break;
                case "FEB":
                    multilingualEndMonth = VariableIntializer.February;
                    break;
                case "MAR":
                    multilingualEndMonth = VariableIntializer.March;
                    break;
                case "APR":
                    multilingualEndMonth = VariableIntializer.April;
                    break;
                case "MAY":
                    multilingualEndMonth = VariableIntializer.May;
                    break;
                case "JUN":
                    multilingualEndMonth = VariableIntializer.June;
                    break;
                case "JUL":
                    multilingualEndMonth = VariableIntializer.July;
                    break;
                case "AUG":
                    multilingualEndMonth = VariableIntializer.August;
                    break;
                case "SEP":
                    multilingualEndMonth = VariableIntializer.September;
                    break;
                case "OCT":
                    multilingualEndMonth = VariableIntializer.October;
                    break;
                case "NOV":
                    multilingualEndMonth = VariableIntializer.November;
                    break;
                case "DEC":
                    multilingualEndMonth = VariableIntializer.December;
                    break;
                default:
                    break;
            }

            var startDate = new Date($(this).find('StartDate').text());
            var endDate = new Date($(this).find('EndDate').text());
            multilingualStartDate = $(this).find('WeekNumber').text() + "[" + arr[0] + "-" + multilingualStartMonth + "-" + arr[2] + "--" + arr1[0] + "-" + multilingualEndMonth + "-" + arr1[2] + "]";
            comboItem.set_text(multilingualStartDate);
            comboItem.set_value($(this).find('WeekNumber').text());
            ddlWeek.get_items().add(comboItem);

            if (ControlIntializer.hfEmployeeSearchClientCode.value != "") {
                var compareDate = new Date(ControlIntializer.hfEmployeeSearchDutyDate.value);
                if (compareDate >= startDate && compareDate <= endDate) {
                    selectedDate = parseInt(l);
                }
            }

            l = l + 1;
        });       //// loop end


        ddlWeek.get_items().getItem(selectedDate).select();
        globClientCode = "";
        var arr = new Array;
        arr = ddlWeek.get_selectedItem().get_text().split('[');
        var arr2 = new Array;
        arr2 = arr[1].split('--');

        ControlIntializer.HFFromDate.value = DateInFormat(arr2[0]);
        ControlIntializer.HFToDate.value = DateInFormat(arr2[1].replace("]", ""));
        ControlIntializer.HFMultilingualFromDate.value = arr2[0];
        ControlIntializer.HFMultilingualToDate.value = arr2[1].replace("]", "");

        var totalItems = ddlWeek.get_items().get_count();
        var lastItem = ddlWeek.get_items().getItem(parseInt(totalItems) - 1).get_text();
        var lastArray = new Array;

        lastArray = lastItem.split('[');
        var lastArray1 = new Array;
        lastArray1 = lastArray[1].split('--');
        ControlIntializer.HFMaxDate.value = DateInFormat(lastArray1[1].replace("]", ""));
        FillArea();

    } ///// if (xmlDoc)
}


function FillArea() {

    $.ajax({
        type: "POST",
        url: "../Webservices/WebMethods.asmx/GetAllArea",
        data: { connectionString: ControlIntializer.connectionKey.value, locationAutoId: VariableIntializer.SessionLocationAutoId, employeeNumber: VariableIntializer.SessionAreaInchargeNumber, isAreaIncharge: VariableIntializer.IsAreaIncharge, fromDate: DateInFormat(ControlIntializer.HFFromDate.value), toDate: DateInFormat(ControlIntializer.HFToDate.value) },
        ////contentType: "application/text; charset=utf-8",
        dataType: 'xml',
        async: false,
        success: OnGetAllArea,
        error: OnWSRequestFailed
    });

}


function OnGetAllArea(result) {
    var xmlDoc = jQuery.parseXML(result.documentElement.textContent);
    ddlArea.clearItems();
    var comboItem1 = new window.Telerik.Web.UI.RadComboBoxItem();
    comboItem1.set_text(VariableIntializer.All);
    comboItem1.set_value("All");
    ddlArea.get_items().add(comboItem1);

    if (xmlDoc && $(xmlDoc).find('Table').text().length > 0) {
        $(xmlDoc).find('Table').each(function () {
            comboItem = new window.Telerik.Web.UI.RadComboBoxItem();
            comboItem.set_text($(this).find('AreaDesc').text());
            comboItem.set_value($(this).find('AreaID').text());
            ddlArea.get_items().add(comboItem);
        });

        ddlArea.get_items().getItem(0).select();
        FillClient();
    }
    else {
        comboItem = new window.Telerik.Web.UI.RadComboBoxItem();
        comboItem.set_text(VariableIntializer.NoDataToShow);
        comboItem.set_value("");
        ddlArea.get_items().add(comboItem);
    }
}


function FillClient() {

    ddlClient.clearItems();
    var comboItem = new window.Telerik.Web.UI.RadComboBoxItem();
    comboItem.set_text(" ");
    comboItem.set_value(" ");
    ddlClient.get_items().add(comboItem);
    ddlClient.clearSelection();

    ddAssignment.clearItems();
    comboItem = new window.Telerik.Web.UI.RadComboBoxItem();
    comboItem.set_text(" ");
    comboItem.set_value(" ");
    ddAssignment.get_items().add(comboItem);
    ddAssignment.clearSelection();

    ddlPost.clearItems();
    comboItem = new window.Telerik.Web.UI.RadComboBoxItem();
    comboItem.set_text(" ");
    comboItem.set_value(" ");
    ddlPost.get_items().add(comboItem);
    ddlPost.clearSelection();
    comboItem = ddlClient.findItemByValue(" ");
    if (comboItem) {
        ddlClient.get_items().remove(comboItem);
    }
    comboItem = ddAssignment.findItemByValue(" ");
    if (comboItem) {
        ddAssignment.get_items().remove(comboItem);
    }
    comboItem = ddlPost.findItemByValue(" ");
    if (comboItem) {
        ddlPost.get_items().remove(comboItem);
    }

    InitalizeControls();
    if (ControlIntializer.gvScheduleRoster == '[object]') {

        ControlIntializer.gvScheduleRoster.style.display = 'none';
    }

    var areaId;
    try {
        areaId = ddlArea.get_selectedItem().get_value();
    }
    catch (error) { areaId = "ALL"; }

    $.ajax({
        type: "POST",
        url: "../Webservices/WebMethods.asmx/GetAllClients",
        data: { strCon: ControlIntializer.connectionKey.value, locationAutoId: VariableIntializer.SessionLocationAutoId, areaId: areaId, clientCode: "", employeeNumber: VariableIntializer.SessionAreaInchargeNumber, isAreaIncharge: VariableIntializer.IsAreaIncharge, fromDate: DateInFormat(ControlIntializer.HFFromDate.value), toDate: DateInFormat(ControlIntializer.HFToDate.value) },
        ////contentType: "application/text; charset=utf-8",
        dataType: 'xml',
        async: false,
        success: OnGetAllClients,
        error: OnWSRequestFailed
    });


}


function OnGetAllClients(result) {
    var xmlDoc = jQuery.parseXML(result.documentElement.textContent);
    var selectedComboFlag = 0;

    if (xmlDoc) {
        $(xmlDoc).find('Table').each(function () {
            comboItem = new window.Telerik.Web.UI.RadComboBoxItem();
            comboItem.set_text($(this).find('ClientCodeName').text());
            comboItem.set_value($(this).find('ClientCode').text());
            ddlClient.get_items().add(comboItem);
            //// set specific client select, if client information is available in hidden field 
            if (ControlIntializer.hfParentClientCode.value != "") {
                if ($(this).find('ClientCode').text() == ControlIntializer.hfParentClientCode.value) {
                    selectedComboFlag = 1;
                    try {
                        comboItem.select();
                    }
                    catch (error) { }
                }
            }
        });


        if (ControlIntializer.hfEmployeeSearchClientCode.value != "" && ddlClient.get_items().get_count() > 0) {
            try {
                var item = ddlClient.findItemByValue(ControlIntializer.hfEmployeeSearchClientCode.value);
                item.select();
                ControlIntializer.hfEmployeeSearchClientCode.value = "";
                selectedComboFlag = 1
            }
            catch (error) {
                ControlIntializer.hfEmployeeSearchClientCode.value = "";
                globPost = "";
            }
        }
        else {
            if (selectedComboFlag == 0 && ddlClient.get_items().get_count() > 0) {
                ddlClient.get_items().getItem(0).select();
            }
        }

        //// Call method to fill assignment dropdown list 
        if (ddlClient.get_items().get_count() > 0) {
            FillAssignments();
        }
    }
    else {
        comboItem = new window.Telerik.Web.UI.RadComboBoxItem();
        comboItem.set_text(" ");
        comboItem.set_value(" ");
        ddlClient.get_items().add(comboItem);
        ddAssignment.get_items().add(comboItem);
        ddlPost.get_items().add(comboItem);
        ddlClient.clearSelection();
        ddAssignment.clearSelection();
        ddlPost.clearSelection();
        DisableProceedButton();
    }
}


function FillAssignments() {
    if (ddlClient.get_items().get_count() != 0) {
        ddAssignment.clearItems();
        var areaId;
        try {
            areaId = ddlArea.get_selectedItem().get_value();
        }
        catch (error) { areaId = "ALL"; }
        try {

            $.ajax({
                type: "POST",
                url: "../Webservices/WebMethods.asmx/GetAllAssignments",
                data: { strCon: ControlIntializer.connectionKey.value, locationAutoId: VariableIntializer.SessionLocationAutoId, clientCode: ddlClient.get_selectedItem().get_value(), fromDate: DateInFormat(ControlIntializer.HFFromDate.value), toDate: DateInFormat(ControlIntializer.HFToDate.value), employeeNumber: VariableIntializer.SessionAreaInchargeNumber, isAreaIncharge: VariableIntializer.IsAreaIncharge, areaId: areaId },
                ////contentType: "application/text; charset=utf-8",
                dataType: 'xml',
                async: false,
                success: OnGetAllAssignments,
                error: OnWSRequestFailed
            });
        }
        catch (error) {
            ddAssignment.clearSelection();
        }
    }
}

function OnGetAllAssignments(result) {
    var xmlDoc = jQuery.parseXML(result.documentElement.textContent);
    var selectedComboFlag = 0;
    ddAssignment.clearItems();

    if (xmlDoc) {
        $(xmlDoc).find('Table').each(function () {
            comboItem = new window.Telerik.Web.UI.RadComboBoxItem();
            comboItem.set_text($(this).find('AsmtDetail').text());
            comboItem.set_value($(this).find('AsmtCode').text());
            ddAssignment.get_items().add(comboItem);
            //// set specific assignment select, if assignment information is available in hidden field 
            if (ControlIntializer.hfParentAsmtID.value != "") {
                if ($(this).find('AsmtCode').text() == ControlIntializer.hfParentAsmtID.value) {
                    selectedComboFlag = 1;
                    try {
                        comboItem.select();
                    }
                    catch (error) { }
                }
            }
        });

        if (ControlIntializer.hfEmployeeSearchAsmtId.value != "" && ddAssignment.get_items().get_count() > 0) {
            try {
                var item = ddAssignment.findItemByValue(ControlIntializer.hfEmployeeSearchAsmtId.value);
                item.select();
                ControlIntializer.hfEmployeeSearchAsmtId.value = "";
                selectedComboFlag = 1
            }
            catch (error) {
                ControlIntializer.hfEmployeeSearchAsmtId.value = "";
            }
        }
        else {
            if (selectedComboFlag == 0 && ddAssignment.get_items().get_count() > 0) {
                ddAssignment.get_items().getItem(0).select();
            }
        }

        //// Call method to fill post dropdown list 
        if (ddAssignment.get_items().get_count() > 0) {
            GetPost(ddAssignment.get_selectedItem().get_value());
        }

    }
    else {
        comboItem = new window.Telerik.Web.UI.RadComboBoxItem();
        comboItem.set_text(VariableIntializer.NoDataToShow);
        comboItem.set_value(VariableIntializer.NoDataToShow);
        ddAssignment.get_items().add(comboItem);
        ddlPost.get_items().add(comboItem);
        ddAssignment.clearSelection();
        ddlPost.clearSelection();
        DisableProceedButton();
    }
}


// This function is used to fill all post of the assignment in drop down
function GetPost(asmtId) {
    ddlPost.clearItems();
    try {

        $.ajax({
            type: "POST",
            url: "../Webservices/WebMethods.asmx/GetAllPostOfAssignment",
            data: { strComnnectionString: ControlIntializer.connectionKey.value, clientCode: ddlClient.get_selectedItem().get_value(), AsmtId: asmtId, locationAutoID: VariableIntializer.SessionLocationAutoId, fromDate: DateInFormat(ControlIntializer.HFFromDate.value), toDate: DateInFormat(ControlIntializer.HFToDate.value) },
            ////contentType: "application/text; charset=utf-8",
            dataType: 'xml',
            async: false,
            success: OnGetAllPostWSRequestComplete,
            error: OnWSRequestFailed
        });
    }
    catch (error) {
        ddlPost.clearSelection();
    }
    //Added by  on 1-May-2013 for Hide Shift Detail Div
    ControlIntializer.divShowShiftDet.style.display = "none";
}

// This function is used to fill all post of the assignment in drop down when     GetPost function has executed successfully
function OnGetAllPostWSRequestComplete(result) {
    InitalizeControls();
    if (ControlIntializer.gvScheduleRoster == '[object]') {
        ControlIntializer.gvScheduleRoster.style.display = 'none';
    }
    ControlIntializer.HFRowIndex.value = "";

    var xmlDoc = jQuery.parseXML(result.documentElement.textContent);
    var selectedComboFlag = 0;
    ddlPost.clearItems();
    ddlPost.clearSelection();

    if (xmlDoc) {
        $(xmlDoc).find('Table').each(function () {
            comboItem = new window.Telerik.Web.UI.RadComboBoxItem();
            comboItem.set_text($(this).find('Post').text());
            comboItem.set_value($(this).find('PostAutoID').text());
            ddlPost.get_items().add(comboItem);
            //// set specific post select, if post information is available in hidden field 
            if (ControlIntializer.hfParentPostCode.value != "" && ControlIntializer.hfParentPostCode.value.indexOf('^') > -1) {
                if ($(this).find('PostAutoID').text() == ControlIntializer.hfParentPostCode.value) {
                    selectedComboFlag = 1;
                    try {
                        comboItem.select();
                    }
                    catch (error) { }
                }
            }
        });

        if (ControlIntializer.hfEmployeeSearchPostCode.value != "" && ddlPost.get_items().get_count() > 0) {
            try {
                var item = ddlPost.findItemByValue(ControlIntializer.hfEmployeeSearchPostCode.value);
                item.select();
                ControlIntializer.hfEmployeeSearchPostCode.value = "";
                selectedComboFlag = 1
            }
            catch (error) {
                ControlIntializer.hfEmployeeSearchPostCode.value = "";
            }
        }
        else {
            if (selectedComboFlag == 0 && ddlPost.get_items().get_count() > 0) {
                ddlPost.get_items().getItem(0).select();
            }
        }

        //// Enable proceed button 
        if (ddlPost.get_items().get_count() > 0) {
            EnableProceedButton();
        }

    }
    else {
        comboItem = new window.Telerik.Web.UI.RadComboBoxItem();
        comboItem.set_text(VariableIntializer.NoDataToShow);
        comboItem.set_value(VariableIntializer.NoDataToShow);
        ddlPost.get_items().add(comboItem);
        ddlPost.clearSelection();
        DisableProceedButton();
    }
}

function LegendClientShow(sender, eventArgs) {
    InitalizeControls();
    $(document).ready(function () {
        $.ajax({
            type: "GET",
            url: "../Webservices/WebMethods.asmx/GetLegends",
            data: { connectionString: ControlIntializer.connectionKey.value, companyCode: VariableIntializer.SessionCompanyCode },
            // contentType: "application/text; charset=utf-8",
            dataType: 'xml',
            async: false,
            success: OnGetLegendsComplete,
            error: OnWSRequestFailed
        });

    });
}

function OnGetLegendsComplete(result) {
    ControlIntializer.spanLegends.innerHTML = result.documentElement.textContent;
    ControlIntializer.spanLegends.style.display = 'block';
}

function SearchPostID(sender) {

    $.ajax({
        type: "POST",
        url: "../Webservices/WebMethods.asmx/SearchPostID",
        data: { strComnnectionString: ControlIntializer.connectionKey.value, strLocationAutoId: VariableIntializer.SessionLocationAutoId, strFromDate: DateInFormat(ControlIntializer.HFFromDate.value),
            strToDate: DateInFormat(ControlIntializer.HFToDate.value), strAreaId: ddlArea.get_selectedItem().get_value(), strAreaIncharge: VariableIntializer.SessionAreaInchargeNumber,
            strIsAreaIncharge: VariableIntializer.IsAreaIncharge
        },
        // contentType: "application/text; charset=utf-8",
        dataType: 'xml',
        async: false,
        success: function (result) { OnGetPostIDComplete(result.documentElement.textContent, sender); },
        error: OnWSRequestFailed
    });

}

function OnGetPostIDComplete(result, sender) {

    if (sender.get_items().get_count() == 0) {
        var xmlDoc = jQuery.parseXML(result.documentElement.textContent);
        if (xmlDoc && $(xmlDoc).find('Table').text().length > 0) {
            $(xmlDoc).find('Table').each(function () {
                var comboItem = new window.Telerik.Web.UI.RadComboBoxItem();
                comboItem.set_text($(this).find('Post').text());
                comboItem.set_value($(this).find('PostDetails').text());
                sender.get_items().add(comboItem);
            });
        }
        else {
            var comboItemSelect = new window.Telerik.Web.UI.RadComboBoxItem();
            comboItemSelect.set_text("Select");
            comboItemSelect.set_value("-1");
            sender.get_items().add(comboItemSelect);
        }
    }
}


function SearchShiftDetails() {
    InitalizeControls();
    $(document).ready(function () {
        var selectPost = ddlPost.get_selectedItem().get_value();
        var arr = new Array();
        arr = selectPost.split("^");
        $.ajax({
            type: "POST",
            url: "../Webservices/WebMethods.asmx/GetPostWiseShiftDetail",
            data: { connectionString: ControlIntializer.connectionKey.value, soNo: arr[2], soLineNo: arr[3], soAmendNo: arr[4] },
            // contentType: "application/text; charset=utf-8",
            dataType: 'xml',
            async: false,
            success: OnGetPostWiseShiftDetailSuccess,
            error: OnWSRequestFailed
        });
    });
}

// Function used for get the Shift Details post wise.
function OnGetPostWiseShiftDetailSuccess(result) {
    ControlIntializer.spnShiftDetail.innerHTML = "";
    ControlIntializer.divShowShiftDet.style.display = "block";
    if (result.documentElement.textContent != "" && result.documentElement.textContent != "No Shift Found") {
        ControlIntializer.spnShiftDetail.innerHTML = result.documentElement.textContent;
    }
    else {
        ControlIntializer.spnShiftDetail.innerHTML = "No Shift Found";
    }
}
/*===================================================================*/

function SearchEmployeeSchedule() {

    ControlIntializer.btnFillEmployee.click();
    var radWindowEmployeeSearch = ControlIntializer.RadWindowEmployeeSearch;
    radWindowEmployeeSearch.show();
}

function SearchEmployeeScheduleOnChange() {

    try {

        $.ajax({
            type: "POST",
            url: "../Webservices/WebMethods.asmx/GetEmployeeSchedule",
            data: { strCon: ControlIntializer.connectionKey.value, intLocationAutoId: VariableIntializer.SessionLocationAutoId,
                strEmployeeNumber: ControlIntializer.search_txtEmployeeNumber.value, strFromDate: DateInFormat(ControlIntializer.RadWindowEmployeeSearch_C_txtFromDate.value),
                strToDate: DateInFormat(ControlIntializer.RadWindowEmployeeSearch_C_txtToDate.value), strAttendanceType: ddlAttendanceType.get_selectedItem().get_value(),
                strAreaId: ddlArea.get_selectedItem().get_value(), strAreaIncharge: VariableIntializer.SessionAreaInchargeNumber, strIsAreaIncharge: VariableIntializer.IsAreaIncharge
            },
            ////contentType: "application/text; charset=utf-8",
            dataType: 'xml',
            async: false,
            success: OnGetScheduleComplete,
            error: OnWSRequestFailed
        });
    }
    catch (error) { }
}

function OnEmployeeSearchSelectedIndexChanged() {
    InitalizeControls();
    SearchEmployeeScheduleOnChange();
}

function OnGetScheduleComplete(result) {

    ControlIntializer.spanEmployeeSchedule.innerHTML = "";
    var xmlDoc = jQuery.parseXML(result.documentElement.textContent);
    var l = 0;

    var strTable;
    strTable = "<table border='0' cellpadding=0 cellspacing=1 style='font-size:11px' > ";
    strTable = strTable + "<tr style='background-color:#B7CEEC' >";
    strTable = strTable + "<td width=150px>Location</td>";
    strTable = strTable + "<td width=150px>Customer</td>";
    strTable = strTable + "<td width=100px>AsmtID</td>";
    strTable = strTable + "<td width=50px>PostCode</td>";
    strTable = strTable + "<td width=80px>DutyDate</td>";
    strTable = strTable + "<td width=30px>Shift</td>";
    strTable = strTable + "<td width=40px>From</td>";
    strTable = strTable + "<td width=40px>To</td>";
    strTable = strTable + "<td width=40px>Hrs</td>";
    strTable = strTable + "</tr><tr>";

    var arr = new Array;
    var tMin = 0;
    var strJavascriptFunctionName;

    if (xmlDoc) {
        $(xmlDoc).find('Table').each(function () {
            strTable = strTable + "<tr><td>";
            strTable = strTable + $(this).find('LocationDesc').text() + "</td><td>";
            strTable = strTable + $(this).find('ClientCode').text() + "</td><td>";
            if ($(this).find('PostDetail').text().length > 0) {
                strJavascriptFunctionName = "javascript:LoadScheduleDetailsOnEmployeeSearchClick('" + $(this).find('PostDetail').text() + "','" + $(this).find('DutyDate').text() + "');";
                strTable = strTable + '<a Style="cursor: pointer" onclick="' + strJavascriptFunctionName + '">';
            }

            strTable = strTable + $(this).find('AsmtID').text() + "</a></td><td>";
            strTable = strTable + $(this).find('PostCodeDesc').text() + "</td><td>";
            strTable = strTable + $(this).find('DutyDate').text() + "</td><td>";
            strTable = strTable + $(this).find('ShiftCode').text() + "</td><td>";
            strTable = strTable + $(this).find('TimeFrom').text() + "</td><td>";
            strTable = strTable + $(this).find('TimeTo').text() + "</td><td>";
            strTable = strTable + $(this).find('DutyHours').text() + "</td></tr>";

            arr = $(this).find('DutyHours').text().split(":");
            tMin = tMin + parseInt(arr[0] * 60) + parseInt(arr[1]);
        });

        var totHours = parseInt(tMin / 60);
        var totMinutes = tMin % 60;

        if (totHours < 10)
        { totHours = "0" + totHours; }
        if (totMinutes < 10)
        { totMinutes = "0" + totMinutes; }

        strTable = strTable + "<tr><td colspan=8><b>Total Hours</b></td><td><b>" + totHours + ":" + totMinutes + "</b></td></tr>";
        strTable = strTable + "</table>";
        ControlIntializer.spanEmployeeSchedule.innerHTML = strTable;
    }

}



function ClientDropDownOpening(sender, eventArgs) {
    InitalizeControls();
    $(document).ready(function () {
        try {
            globalClientCode = ddlClient.get_selectedItem().get_value();
        } catch (error) {
            ControlIntializer.btnProceed.set_enabled(false);

        }
    });
}

function AssignmentDropDownOpening(sender, eventArgs) {
    $(document).ready(function () {
        try {
            globalAsmtId = ddAssignment.get_selectedItem().get_value();
        } catch (error) {
        }
    });
}

function PostDropDownOpening(sender, eventArgs) {
    $(document).ready(function () {
        try {
            globalPostCode = ddlPost.get_selectedItem().get_value();
        } catch (error) {
        }
    });
}

function AreaOnClientDropDownOpening(sender, eventArgs) {
    $(document).ready(function () {
        try {
            ControlIntializer.hfAreaOldValue.value = ddlArea.get_selectedItem().get_value();
        } catch (error) {
        }
    });
}

function AreaOnClientSelectedIndexChanged(sender, eventArgs) {
    $(document).ready(function () {
        ControlIntializer.hfAreaNewValue.value = ddlArea.get_selectedItem().get_value();
        ControlIntializer.LBShiftPatterns.length = 0;
        ControlIntializer.HFNumberOfRowsInGrid.value = "";
        try {
            ControlIntializer.hfParentClientCode.value = ddlClient.get_selectedItem().get_value();
            ControlIntializer.hfParentAsmtID.value = ddAssignment.get_selectedItem().get_value();
            ControlIntializer.hfParentPostCode.value = ddlPost.get_selectedItem().get_value();
        } catch (error) {
        }
        if (sender.get_items().get_count() != 0) {
            FillClient();
        }
    });
}

function ClientSelectedIndexChanged(sender, eventArgs) {
    $(document).ready(function () {
        try {
            var keyId = (window.event) ? event.keyCode : event.which;
            if (keyId == 13 || keyId == 9) {
                ControlIntializer.LBShiftPatterns.length = 0;
                ControlIntializer.HFNumberOfRowsInGrid.value = "";
                FillAssignments();
            }
        } catch (error) {
        }
    });
}

function ClientDropDownClosed(sender, eventArgs) {
    $(document).ready(function () {
        try {
            var keyId = (window.event) ? event.keyCode : event.which;
            if (keyId != 13 && keyId != 9) {
                if (ddlClient.get_selectedItem().get_value() != globalClientCode) {
                    ControlIntializer.LBShiftPatterns.length = 0;
                    ControlIntializer.HFNumberOfRowsInGrid.value = "";
                    FillAssignments();
                }
                globalClientCode = "";
            }
        } catch (error) {
        }
    });
}

function AssignmentOnClientSelectedIndexChanged(sender, eventArgs) {
    $(document).ready(function () {
        var keyId = (window.event) ? event.keyCode : event.which;
        if (keyId == 13 || keyId == 9) {
            ControlIntializer.LBShiftPatterns.length = 0;
            ControlIntializer.HFNumberOfRowsInGrid.value = "";
            try {
                if (sender.get_items().get_count() != 0) {
                    GetPost(sender.get_selectedItem().get_value());
                }
            } catch (error) {
                ddlPost.clearSelection();
            }
        }
    });
}

function AssignmentOnClientDropDownClosed(sender, eventArgs) {
    $(document).ready(function () {
        try {
            var keyId = (window.event) ? event.keyCode : event.which;
            if (keyId != 13 && keyId != 9) {
                if (sender.get_selectedItem().get_value() != globalAsmtId) {
                    ControlIntializer.LBShiftPatterns.length = 0;
                    ControlIntializer.HFNumberOfRowsInGrid.value = "";
                    try {
                        if (sender.get_items().get_count() != 0) {
                            GetPost(sender.get_selectedItem().get_value());
                        }
                    } catch (error) {
                        ddlPost.clearSelection();
                    }
                }
                globalAsmtId = "";
            }
        } catch (error) {
        }
    });
}

function PostOnClientSelectedIndexChanged(sender, eventArgs) {
    InitalizeControls();
    $(document).ready(function () {
        try {
            if (sender.get_selectedItem().get_value() != globalPostCode) {
                ControlIntializer.LBShiftPatterns.length = 0;
                ControlIntializer.HFNumberOfRowsInGrid.value = "";
                ControlIntializer.HFRowIndex.Value = "";
                EnableProceedButton();
                ControlIntializer.divShowShiftDet.style.display = "none";
            }
            globalPostCode = "";
        } catch (error) {
        }
    });
}

function AttendanceOnClientSelectedIndexChanged(sender, eventArgs) {
    $(document).ready(function () {
        try {
            EnableProceedButton();
            ControlIntializer.HFRowIndex.value = "";
            ControlIntializer.HFNumberOfRowsInGrid.value = "";
            GlobalOldShiftPatternObject = "";
            if (ddlAttendanceType.get_selectedItem().get_value() == "Sch") {
                ddlScheduleType.findItemByValue("Weekly").select();
                ddlScheduleType.disable();
            }
            else {
                ddlScheduleType.enable();
            }
        }
        catch (error) { }
    });

}


function ddlPostSearchOnClientKeyPressing(sender, eventArgs) {
    $(document).ready(function () {
        if (sender.get_items().get_count() == 0) {
            SearchPostID(sender);
        }
    });
}

function ddlPostSearchClientSelectedIndexChanged(sender, eventArgs) {
    $(document).ready(function () {
        GlobalOldShiftPatternObject = "";
        ControlIntializer.LBShiftPatterns.length = 0;
        LoadScheduleDetailsOnClientClick("PostSearch");
    });
}


function WeekOnClientDropDownOpening(sender, eventArgs) {
    InitalizeControls();
    $(document).ready(function () {
        try {
            ControlIntializer.hfOldWeek.value = ddlWeek.get_selectedItem().get_value();
        } catch (error) {
            ControlIntializer.btnProceed.set_enabled(false);
        }
    });
}

function MonthOnClientSelectedIndexChanged(sender, eventArgs) {

    InitalizeControls();
    $(document).ready(function () {
        ControlIntializer.LBShiftPatterns.length = 0;
        ControlIntializer.HFNumberOfRowsInGrid.value = "";
        GlobalOldShiftPatternObject = "";
        try {
            ControlIntializer.hfParentClientCode.value = ddlClient.get_selectedItem().get_value();
            ControlIntializer.hfParentAsmtID.value = ddAssignment.get_selectedItem().get_value();
            ControlIntializer.hfParentPostCode.value = ddlPost.get_selectedItem().get_value();
        } catch (error) {
        }

        if (sender.get_id() == "ddlWeek") {

            if (ControlIntializer.hfOldWeek.value == ddlWeek.get_selectedItem().get_value()) {
                return;
            }

        }
        EnableProceedButton();
        if (sender.get_id() == "ddlWeek") {
            var arr = new Array;
            arr = ddlWeek.get_selectedItem().get_text().split('[');
            var arr1 = new Array;
            arr1 = arr[1].split('--');
            ControlIntializer.HFFromDate.value = arr1[0];
            ControlIntializer.HFToDate.value = arr1[1].replace("]", "");

            ControlIntializer.HFMultilingualFromDate.value = arr1[0];
            ControlIntializer.HFMultilingualToDate.value = arr1[1].replace("]", "");

            var totalItems = ddlWeek.get_items().get_count();
            var lastItem = ddlWeek.get_items().getItem(parseInt(totalItems) - 1).get_text();
            var lastArray = new Array;

            lastArray = lastItem.split('[');
            var lastArray1 = new Array;
            lastArray1 = lastArray[1].split('--');
            ControlIntializer.HFMaxDate.value = lastArray1[1].replace("]", "");
            FillArea();
        } else {

            FillWeekDropDown();
            return;
        }
    });
}

function GetEmployeeCountClientWiseAndpostWise() {
    if (ddlPost.get_selectedItem().get_value() != "") {
        var strPageName = "../Transactions/EmployeeCountClientAndPostWise.aspx?ConnectionString=" + ControlIntializer.connectionKey.value +
                "&CompanyCode=" + VariableIntializer.SessionCompanyCode +
                "&HrLocationCode=" + VariableIntializer.SessionHrLocationCode +
                "&LocationCode=" + VariableIntializer.SessionLocationCode +
                "&AttendanceType=" + ddlAttendanceType.get_selectedItem().get_value() +
                "&Post=" + encodeURIComponent(ddlPost.get_selectedItem().get_value()) +
                "&FromDate=" + DateInFormat(ControlIntializer.HFFromDate.value) +
                "&ToDate=" + DateInFormat(ControlIntializer.HFToDate.value) +
                "&AsmtCode=" + ddAssignment.get_selectedItem().get_value() +
                "&ClientCode=" + ddlClient.get_selectedItem().get_value();
        refreshStatus = "";
        window.radopen(strPageName, "RadWindow");
    }
}

function SaleOrderConstraint() {

    var postDetails = ddlPost.get_selectedItem().get_value();
    var arr = new Array;
    arr = postDetails.split("^");
    window.showModalDialog('../Sales/SOLineSkillSet.aspx?LocationAutoID=' + VariableIntializer.SessionLocationAutoId + '&SoNo=' + arr[2] + '&SOAmendNO=' + arr[4] + '&SOLineNo=' + arr[3] + '&SOStatus=' + "AUTHORIZED" + '&IsMAXSOAmendNo=' + "MAX" + '&Checked=' + "True", null, 'status:off;center:yes;scroll:no;dialogWidth:1200px;dialogheight:600px;help:no;');
}

function SaleOrderDeployment() {

    $.ajax({
        type: "GET",
        url: "../Webservices/WebMethods.asmx/ShowSaleOrderDeployment",
        data: { connectionString: ControlIntializer.connectionKey.value, locationAutoId: VariableIntializer.SessionLocationAutoId, clientCode: ddlClient.get_selectedItem().get_value(),
            asmtId: ddAssignment.get_selectedItem().get_value(), post: ddlPost.get_selectedItem().get_value()
        },
        ////contentType: "application/text; charset=utf-8",
        dataType: 'xml',
        async: false,
        success: OnSaleOrderDeploymentRequestComplete,
        error: OnWSRequestFailed
    });
}

function OnSaleOrderDeploymentRequestComplete(result) {
    var xmlDoc = jQuery.parseXML(result.documentElement.textContent);
    window.showModalDialog('../Sales/SOLineDeptShifts.aspx?LocationAutoID=' + VariableIntializer.SessionLocationAutoId + '&SoNo=' + $(xmlDoc).find('SoNo').text() +
                            '&SOAmendNO=' + $(xmlDoc).find('SoAmendNo').text() + '&SOLineNo=' + $(xmlDoc).find('SoLineNo').text() + '&SOStatus=' + "AUTHORIZED" +
                            '&IsMAXSOAmendNo=' + "MAX" + '&Hours=' + $(xmlDoc).find('DeploymentPattern').text() + '&NoOfPost=' + $(xmlDoc).find('NoOfPost').text() +
                            '&ChargeRatePerHrs=' + $(xmlDoc).find('ChargeRatePerHour').text() + '&PayRatePerHrs=' + $(xmlDoc).find('MinWages').text() +
                            '&OtherAllowances=' + $(xmlDoc).find('OtherAllowances').text() + '&IsAllowanceBillable=' + $(xmlDoc).find('IsAllowanceBillable').text() +
                            '&RemainingDays=' + $(xmlDoc).find('RemainingDays').text() + '&BillingPattern=' + $(xmlDoc).find('SoType').text() +
                            '&Checked=' + $(xmlDoc).find('Active').text() + '&IsBillable=' + $(xmlDoc).find('Billable').text(), null,
                            'status:off;center:yes;scroll:no;dialogWidth:1250px;dialogheight:550px;help:no;');
}
