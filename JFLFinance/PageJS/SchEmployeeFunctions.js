/*
This js file contains functions related to employee operations in scheduling grid 
*/


//=======================================
// Function To Search Employee Number in the dropDown
//=======================================
function SearchEmployeeName(obj, controlType) {
    InitalizeControls();
    $(document).ready(function() {
        var elEmployee;
        var employeeName;
        var keyId = (window.event) ? event.keyCode : event.which;
        if (controlType == "Number") {

            elEmployee = ControlIntializer.search_txtEmployeeNumber;
            employeeName = elEmployee;
        } else {
            elEmployee = ControlIntializer.search_txtEmployeeName;
            employeeName = elEmployee;
        }
        if (elEmployee.value == "") {
            return;
        }
        var elList = ControlIntializer.lstBox_Employees;
        var elEmpList = ControlIntializer.ddlEmployees;

        var lyr = ControlIntializer.divEmployeeList;
        var coors = findPos(elEmployee);
        lyr.style.top = coors[1] - 58 + 'px';
        lyr.style.left = coors[0] - 115 + 'px';
        ControlIntializer.divEmployeeList.style.display = "block";
        if (keyId == 38 || keyId == 40) {

            elList._getGroupElement().focus();
            return;
        } else if (keyId == 0 && elList.length > 0) /////// on blur
        {
            ControlIntializer.divEmployeeList.style.display = "none";
            if (elList.selectedIndex > -1) {
                ControlIntializer.search_txtEmployeeNumber.value = elList.get_selectedItem().get_value();
                ControlIntializer.search_txtEmployeeName.value = elList.get_selectedItem().get_text();
            }
            return;
        } else {
            var items = elList.get_items();
            items.clear();

            var number;
            var name;
            for (var i = 0; i < elEmpList.get_items().get_count(); i++) {
                number = elEmpList.get_items().getItem(i).get_value();
                name = elEmpList.get_items().getItem(i).get_text();
                var item;
                if (controlType == "Number") {
                    if (number.substring(0, elEmployee.value.length).toLowerCase() == elEmployee.value.toLowerCase()) {
                        item = new window.Telerik.Web.UI.RadListBoxItem();
                        item.set_text(name);
                        item.set_value(number);
                        elList.get_items().add(item);
                    }
                } else {
                    if (name.substring(0, elEmployee.value.length).toLowerCase() == elEmployee.value.toLowerCase()) {
                        item = new window.Telerik.Web.UI.RadListBoxItem();
                        item.set_text(name);
                        item.set_value(number);
                        elList.get_items().add(item);
                    }
                }

            }
        }
    });
}

function func_SelectEmployee(obj) {
    $(document).ready(function () {
        var elList = ControlIntializer.lstBox_Employees;
        try {
            ControlIntializer.search_txtEmployeeNumber.value = elList.get_selectedItem().get_value();
            ControlIntializer.search_txtEmployeeName.value = elList.get_selectedItem().get_text();
        }
        catch (error){}
        ControlIntializer.divEmployeeList.style.display = "none";
    });
}

function SearchEmployee(obj) {

    InitalizeControls();
    $(document).ready(function () {
        var keyId = (window.event) ? event.keyCode : event.which;
        var strEmployee = "txtEmpNumberDutyDate";
        var strEmployeeName = "txtEmpNameDutyDate";
        var elEmployee = getClientId(obj, strEmployee);
        var employeeName = getClientId(obj, strEmployeeName);
        GlobEmployeeNumber = elEmployee;
        GlobEmployeeName = employeeName;

        var elList = ControlIntializer.LBEmployeeList;
        var elEmpList = ControlIntializer.ddlEmployees;

        var lyr = ControlIntializer.divEmployeeContainer;
        var coors = findPos(document.getElementById(elEmployee));
        lyr.style.top = coors[1] + 20 + 'px';
        lyr.style.left = coors[0] + 'px';
        ControlIntializer.divEmployeeContainer.style.display = "block";
        if (keyId == 38 || keyId == 40) {
            elList._getGroupElement().focus();
            return;
        } else {
            elList.length = 0;
            var j = 0;
            var items = elList.get_items();
            items.clear();
            var number;
            var name;
            for (i = 0; i < elEmpList.get_items().get_count(); i++) {
                name = elEmpList.get_items().getItem(i).get_text();
                number = elEmpList.get_items().getItem(i).get_value();
                if (name.substring(0, document.getElementById(employeeName).value.length).toLowerCase() == document.getElementById(employeeName).value.toLowerCase()) {
                    var item = new window.Telerik.Web.UI.RadListBoxItem();
                    item.set_text(name);
                    item.set_value(number);
                    elList.get_items().add(item);
                }
            }
        }
    });
}


//=======================================
//Function Used to select EmployeeNumber After Searchin Drop Down
//=======================================
function SelectEmployee(obj) {

    var el = GlobEmployeeNumber;
    var employeeNameClientId = GlobEmployeeName;
    var elList = ControlIntializer.LBEmployeeList;
    if (elList.get_selectedItem() != null) {
        document.getElementById(el).value = elList.get_selectedItem().get_value();
        document.getElementById(employeeNameClientId).value = elList.get_selectedItem().get_text();

        ControlIntializer.divEmployeeList.style.display = "none";
        document.getElementById(el).focus();
        ControlIntializer.divEmployeeContainer.style.display = "none";
        GlobEmployeeName = getClientId(document.getElementById(el), "txtEmpNameDutyDate");
        GlobEmployeeDesgDesc = getClientId(document.getElementById(el), "txtEmpDesignationDesc");
        GlobShiftPatternCode = getClientId(document.getElementById(el), "txtShiftPatternCode");
        GlobPatternPosition = getClientId(document.getElementById(el), "txtPatternPosition");
        globBorrowedEmployeeStatus = getClientId(document.getElementById(el), "hfBorrowedEmployeeStatus");
        var screenType;
        if (ddlAttendanceType.get_selectedItem().get_value() == 'Act') {
            screenType = 'ACT';
        } else {
            screenType = 'SCH';
        }

        $(document).ready(function() {
            $.ajax({
                type: "GET",
                url: "../Webservices/WebMethods.asmx/GetEmployeeDetail",
                data: {
                    connectionString: ControlIntializer.connectionKey.value,
                    employeeNumber: document.getElementById(el).value,
                    clientCode: ddlClient.get_selectedItem().get_value(),
                    asmtId: ddAssignment.get_selectedItem().get_value(),
                    fromDate: DateInFormat(ControlIntializer.HFFromDate.value),
                    toDate: DateInFormat(ControlIntializer.HFToDate.value),
                    postCode: ddlPost.get_selectedItem().get_value(),
                    insertStatus: "GETEMP",
                    areaId: ddlArea.get_selectedItem().get_value(),
                    areaInchargeNumber: VariableIntializer.SessionAreaInchargeNumber,
                    isAreaIncharge: VariableIntializer.IsAreaIncharge,
                    screenType: screenType,
                    companyCode: VariableIntializer.SessionCompanyCode,
                    hrLocationCode: VariableIntializer.SessionHrLocationCode,
                    locationAutoId: VariableIntializer.SessionLocationAutoId,
                    modifiedBy: VariableIntializer.SessionUserId
                },
                contentType: "application/text; charset=utf-8",
                async: false,
                success: OnGetEmployeeDetailComplete,
                error: OnWSRequestFailed
            });
        });
        return;
    }
}

//=======================================
// Function used After GetEmpDetails Function Is Called to Get Employee Details
//=======================================

function OnGetEmployeeDetailComplete(str) {
    if (str.documentElement.textContent == "") {
        EnableProceedAndClick();
        return false;
    }
    var arr = new Array;
    arr = str.documentElement.textContent.split(",");

    if (arr[10] == "1") {
        InitalizeControls();
        if (ddlAttendanceType.get_selectedItem().get_value() == "Sch") {
            // document.getElementById(GlobShiftPatternCode).disabled = true;
            document.getElementById(GlobShiftPatternCode).disabled = false;
            try {
                if (document.getElementById(globBorrowedEmployeeStatus).value == "") {
                    document.getElementById(globBorrowedEmployeeStatus).value = "1";
                }
            }
            catch (error) { }

        } else {
            document.getElementById(GlobShiftPatternCode).disabled = false;
        }

    }
    else {
        document.getElementById(GlobShiftPatternCode).disabled = false;
    }
    var strMsg;
    var replacedString;
    if (arr[1] == "Invalid") {


        if (arr[3] == "ENE") {
            alert(VariableIntializer.InvalidEmpCode);
            try {
                if (document.getElementById(GlobSavedEmployeeNumber).value == "") {
                    document.getElementById(GlobEmployeeNumber).value = "";
                }
                else {
                    document.getElementById(GlobEmployeeNumber).value = document.getElementById(GlobSavedEmployeeNumber).value;
                }
            }
            catch (error) { }

        }
        else if (arr[3] == "ENBL") {
            alert(VariableIntializer.Employeedutydatecannotbegreaterthandateofresignation);

            try {
                if (document.getElementById(GlobSavedEmployeeNumber).value == "") {
                    document.getElementById(GlobEmployeeNumber).value = "";
                }
                else {
                    document.getElementById(GlobEmployeeNumber).value = document.getElementById(GlobSavedEmployeeNumber).value;
                }
            }
            catch (error) { }
        }
        else if (arr[3] == "EJ") {
            alert(VariableIntializer.DutyDateCannotbelessthanjoiningdate);
            try {
                if (document.getElementById(GlobSavedEmployeeNumber).value == "") {
                    document.getElementById(GlobEmployeeNumber).value = "";
                }
                else {
                    document.getElementById(GlobEmployeeNumber).value = document.getElementById(GlobSavedEmployeeNumber).value;
                }
            }
            catch (error) { }
        }
        else if (arr[3] == "NA") {
            alert(VariableIntializer.InvalidEmpCode);
            try {
                if (document.getElementById(GlobSavedEmployeeNumber).value == "") {
                    document.getElementById(GlobEmployeeNumber).value = "";
                }
                else {
                    document.getElementById(GlobEmployeeNumber).value = document.getElementById(GlobSavedEmployeeNumber).value;
                }
            }
            catch (error) { }
        }
        else if (arr[3] == "B") {
            alert(VariableIntializer.Employeeisbarredfromthisassignment);
            try {
                if (document.getElementById(GlobSavedEmployeeNumber).value == "") {
                    document.getElementById(GlobEmployeeNumber).value = "";
                }
                else {
                    document.getElementById(GlobEmployeeNumber).value = document.getElementById(GlobSavedEmployeeNumber).value;
                }
            }
            catch (error) { }
        }
        else if (arr[3] == "MP") {
            alert(VariableIntializer.Minimumprofitabilitynotmet);
            try {
                if (document.getElementById(GlobSavedEmployeeNumber).value == "") {
                    document.getElementById(GlobEmployeeNumber).value = "";
                }
                else {
                    document.getElementById(GlobEmployeeNumber).value = document.getElementById(GlobSavedEmployeeNumber).value;
                }
            }
            catch (error) { }
        }
        else if (arr[3] == "IA") {
            alert(VariableIntializer.EmployeeDoesnotbelongstothisArea);
        }
        else if (arr[3] == "M") {
            var arrSkills = new Array;
            arrSkills = arr[4].split("/");
            strMsg = VariableIntializer.FollowingMandatoryskillsdoesnotmatch;
            strMsg = strMsg + "\n";
            for (var i = 0; i < parseInt(arrSkills.length); i++) {
                strMsg = strMsg + arrSkills[i] + ",";
            }
            replacedString = strMsg.replace("RefresherTrainingPending", VariableIntializer.RefresherTrainingPending);
            alert(replacedString);
            try {
                if (document.getElementById(GlobSavedEmployeeNumber).value == "") {
                    document.getElementById(GlobEmployeeNumber).value = "";
                }
                else {
                    document.getElementById(GlobEmployeeNumber).value = document.getElementById(GlobSavedEmployeeNumber).value;
                }
            }
            catch (error) { }
        }
        else {
            alert(VariableIntializer.InvalidEmpCode);
            try {
                if (document.getElementById(GlobSavedEmployeeNumber).value == "") {
                    document.getElementById(GlobEmployeeNumber).value = "";
                }
                else {
                    document.getElementById(GlobEmployeeNumber).value = document.getElementById(GlobSavedEmployeeNumber).value;
                }
            }
            catch (error) { }
        }
        document.getElementById(GlobEmployeeNumber).focus();
        ControlIntializer.divEmployeeContainer.style.display = "none";
        return false;
    }
    else {
        var status;
        status = "";
        var reqMandatoryStatus = "";
        if (arr[6] != 'SINGLE' && arr[6] != 'COPY') {

            if (arr[4] == "3") {
                alert(VariableIntializer.Trainingisingraceperiod);

            }
            if (arr[4] == "0") {
                status = confirm(VariableIntializer.EmployeeSkillsDoesNotMatchWithRequiredSkillsDoYouWantToContinue);
                reqMandatoryStatus = "1";
                if (!status) {
                    document.getElementById(GlobEmployeeNumber).focus();
                    ControlIntializer.divEmployeeContainer.style.display = "none";
                    status = "";
                    return false;
                }
                status = "";
            }
            if (arr[4] == "1") {
                var arrSkills = new Array;
                arrSkills = arr[9].split("/");
                strMsg = VariableIntializer.FollowingMandatoryskillsdoesnotmatch;
                strMsg = strMsg + "\n";
                for (var i = 0; i < parseInt(arrSkills.length); i++) {

                    strMsg = strMsg + arrSkills[i] + ",";

                }
                replacedString = strMsg.replace("RefresherTrainingPending", VariableIntializer.RefresherTrainingPending);
                alert(replacedString);
                try {
                    if (document.getElementById(GlobSavedEmployeeNumber).value == "") {
                        document.getElementById(GlobEmployeeNumber).value = "";
                    }
                    else {
                        document.getElementById(GlobEmployeeNumber).value = document.getElementById(GlobSavedEmployeeNumber).value;
                    }
                }
                catch (error) { }
                document.getElementById(GlobEmployeeNumber).focus();
                document.getElementById('divEmployeeContainer').style.display = "none";
                return false;
            }
            if (arr[8] != "OK") {
                status = confirm(VariableIntializer.EmployeePayRateIsGreaterThanSaleOrderPayRateDoYouWantToContinue);
                if (!status) {
                    document.getElementById(GlobEmployeeNumber).focus();
                    try {
                        if (document.getElementById(GlobSavedEmployeeNumber).value == "") {
                            document.getElementById(GlobEmployeeNumber).value = "";
                        }
                        else {
                            document.getElementById(GlobEmployeeNumber).value = document.getElementById(GlobSavedEmployeeNumber).value;
                        }
                    }
                    catch (error) { }
                    ControlIntializer.divEmployeeContainer.style.display = "none";
                    status = "";
                    return false;
                }
                else {

                    if (arr[11] != "OK") {
                        if (arr[11] != "MinimumProfitabilityMismatch") {
                            status = confirm(VariableIntializer.OptimumProfitabilityMismatch);
                            if (!status) {
                                document.getElementById(GlobEmployeeNumber).focus();
                                try {
                                    if (document.getElementById(GlobSavedEmployeeNumber).value == "") {
                                        document.getElementById(GlobEmployeeNumber).value = "";
                                    }
                                    else {
                                        document.getElementById(GlobEmployeeNumber).value = document.getElementById(GlobSavedEmployeeNumber).value;
                                    }
                                }
                                catch (error) { }
                                ControlIntializer.divEmployeeContainer.style.display = "none";
                                status = "";
                                return false;
                            }

                        }


                    }
                    document.getElementById(GlobEmployeeNumber).style.color = "red";
                    document.getElementById(GlobEmployeeName).style.color = "red";
                    document.getElementById(GlobEmployeeDesgDesc).value = arr[2];
                    document.getElementById(GlobEmployeeDesgDesc).style.color = "red";
                    document.getElementById(GlobPatternPosition).style.color = "red";
                    document.getElementById(GlobShiftPatternCode).style.color = "red";
                    document.getElementById(GlobPatternPosition).focus();
                    // "2" when user clicks YES
                    var strScreenType;
                    if (ddlAttendanceType.get_selectedItem().get_value() == 'Act') {
                        strScreenType = 'ACT';
                    }
                    else {
                        strScreenType = 'SCH';
                    }
                }
                status = "";
            }
            if (arr[11] == "MinimumProfitabilityMismatch") {
                status = confirm(VariableIntializer.Minimumprofitabilitynotmet);
                if (!status) {
                    document.getElementById(GlobEmployeeNumber).focus();
                    try {
                        if (document.getElementById(GlobSavedEmployeeNumber).value == "") {
                            document.getElementById(GlobEmployeeNumber).value = "";
                        }
                        else {
                            document.getElementById(GlobEmployeeNumber).value = document.getElementById(GlobSavedEmployeeNumber).value;
                        }
                    }
                    catch (error) { }
                    ControlIntializer.divEmployeeContainer.style.display = "none";
                    status = "";
                    return false;
                }
            }
            if (arr[7] != "" && reqMandatoryStatus != "1") {
                status = confirm(VariableIntializer.EmployeeSkillsDoesNotMatchWithRequiredSkillsDoYouWantToContinue);
                if (!status) {
                    document.getElementById(GlobEmployeeNumber).focus();
                    ControlIntializer.divEmployeeContainer.style.display = "none";
                    status = "";
                    return false;
                }
                status = "";

            }
        }
        try {
        document.getElementById(GlobEmployeeName).value = arr[1];
        
            document.getElementById(GlobEmployeeDesgDesc).value = arr[2];
            if (arr[6] != 'SINGLE') {
                if (arr[6] != 'COPY') {
                    //document.getElementById(getClientId(document.getElementById(GlobEmployeeNumber), "txtShiftPatternCode")).select();
                    document.getElementById(GlobPatternPosition).focus();
                }
            }
        }
        catch (error) { }

        ControlIntializer.divEmployeeContainer.style.display = "none";
        globCopyStatus = "0";
        if (arr[6] == 'SINGLE') {
            SaveData();
        }
        else if (arr[6] == 'COPY') {
            if (document.getElementById(GlobEmployeeSchRosterAutoID).value != "") {
                globCopyStatus = "1";
                CopyData(document.getElementById(GlobEmployeeSchRosterAutoID).value);
            }
        }

    }
    return false;
}


// This function is called when user click on the ? symbol on the gridview which shows the Employee skill search.
function SearchEmployeeSkillWise(strEmployee) {
    var elPd = ddlPost.get_selectedItem().get_value(); //document.getElementById('hidPdLineNo' + i).value;
    var elEmp = strEmployee;
    var clientCode = ddlClient.get_selectedItem().get_value();
    var clientName = ddlClient.get_selectedItem().get_text();
    var asmtId = ddAssignment.get_selectedItem().get_value();
    var asmtName = ddAssignment.get_selectedItem().get_text();
    var postName = ddlPost.get_selectedItem().get_text();

    //Area ID Added to search on selected Area
    var pageName = "../search/EmployeeWiseAdvanceSearch.aspx?PostCode=" + encodeURIComponent(elPd) + "&FromDate=" + DateInFormat(ControlIntializer.HFFromDate.value) + "&ToDate=" + DateInFormat(ControlIntializer.HFToDate.value) + "&ControlId=" + elEmp + "&AttendanceType=" + ddlAttendanceType.get_selectedItem().get_value() + "&AreaID=" + ddlArea.get_selectedItem().get_value() + "&ClientCode=" + clientCode + "&ClientName=" + encodeURIComponent(clientName) + "&AsmtID=" + asmtId + "&AsmtName=" + encodeURIComponent(asmtName) + "&PostName=" + encodeURIComponent(postName);
    var winW = 1300;
    var winH = 600;
    var winX = (screen.availWidth - winW) / 2;
    var winY = (screen.availHeight - winH) / 2;
    var features = 'left=' + winX + ',top=' + winY + ',height=' + winH + ',' + 'width=' + winW + ',status=yes,' + 'toolbar=no,menubar=no,location=no';
    window.open(pageName, 'Search', features);
}

// This function is used to show all employee and all the skills defined in sale order which are matching and which are not matching
function AllSkillMatchMismatch() {
    var postCode = ddlPost.get_selectedItem().get_value();
    var pageName = "../Transactions/SkillMatchMismatch.aspx?AsmtCode=" + ddAssignment.get_selectedItem().get_value() + "&PostCode=" + encodeURIComponent(postCode) + "&FromDate=" + DateInFormat(ControlIntializer.HFFromDate.value) + "&ToDate=" + DateInFormat(ControlIntializer.HFToDate.value) + "&AreaID=" + ddlArea.get_selectedItem().get_value();
    var winW = 1600;
    var winH = 600;
    var winX = (screen.availWidth - winW) / 2;
    var winY = (screen.availHeight - winH) / 2;
    var features = 'left=' + winX + ',top=' + winY + ',height=' + winH + ',' + 'width=' + winW + ',status=yes,' + 'toolbar=no,menubar=no,location=no';
    window.open(pageName, 'Search', features);
}

function GetUnSchEmp(strEmpClientId) {
    InitalizeControls();
    GlobEmployeeNumber = strEmpClientId;
    ControlIntializer.HFUnSchEmployeeClickStatus.value = "1";
    ControlIntializer.btnUnScheduledEmp.click();
    var radWindowBorrow = ControlIntializer.RadWindowBorrow;
    radWindowBorrow.Show();
}

function BorrowUnSchEmpDiv(obj) {
    InitalizeControls();
    ControlIntializer.HFUnSchEmployeeClickStatus.value = "1";
    ControlIntializer.btnBorrowedEmp.click();
}

function AssignToSelectedTextBox(obj) {
    InitalizeControls();
    if (GlobEmployeeNumber != '') {

        document.getElementById(GlobEmployeeNumber).value = document.getElementById(obj.id).innerText;
        var radWindowBorrow = ControlIntializer.RadWindowBorrow;
        radWindowBorrow.close();

        $(document).ready(function () {
            $.ajax({
                type: "GET",
                url: "../Webservices/WebMethods.asmx/GetEmployeeDetail",
                data: { connectionString: ControlIntializer.connectionKey.value, employeeNumber: document.getElementById(GlobEmployeeNumber).value, clientCode: ddlClient.get_selectedItem().get_value(),
                    asmtId: ddAssignment.get_selectedItem().get_value(), fromDate: DateInFormat(ControlIntializer.HFFromDate.value), toDate: DateInFormat(ControlIntializer.HFToDate.value),
                    postCode: ddlPost.get_selectedItem().get_value(), insertStatus: "GETTEMP", areaId: ddlArea.get_selectedItem().get_value(),
                    areaInchargeNumber: VariableIntializer.SessionAreaInchargeNumber, isAreaIncharge: VariableIntializer.IsAreaIncharge, screenType: ddlAttendanceType.get_selectedItem().get_value(),
                    companyCode: VariableIntializer.SessionCompanyCode, hrLocationCode: VariableIntializer.SessionHrLocationCode,
                    locationAutoId: VariableIntializer.SessionLocationAutoId, modifiedBy: VariableIntializer.SessionUserId
                },
                contentType: "application/text; charset=utf-8",
                async: false,
                success: OnGetEmployeeDetailComplete,
                error: OnWSRequestFailed
            });
        });

    }
}

function ListOfEmployeeGet(obj) {
    InitalizeControls();
    ControlIntializer.HFUnSchEmployeeClickStatus.value = "1";
    ControlIntializer.btnUnScheduledEmp.click();
}