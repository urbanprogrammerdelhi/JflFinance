var xmlHttp1, xmlHttp2, xmlHttp3, xmlHttp4, xmlHttp5, xmlHttp6, xmlHttp7, xmlHttp8, xmlHttp9

function CorrectDesignation(strCompany, strHrLocation, LocationAutoID, strEmployeeNumber, strCorrectionDate, strOldCorrectionDate, strNewCode, strOldCode, strCorrectionField) {
    var xmlHttpGetCount
    xmlHttp1 = GetXmlHttpObject()

    if (xmlHttp1 == null) {
        alert("Browser does not support HTTP Request")
        return
    }
    var url = "CorrectEmployeeDetailsAjax.aspx"
    url = url + "?EmployeeNumber=" + strEmployeeNumber
    url = url + "&Company=" + strCompany
    url = url + "&HrLocation=" + strHrLocation
    url = url + "&LocationAutoID=" + LocationAutoID
    url = url + "&CorrectionDate=" + strCorrectionDate
    url = url + "&OldCorrectionDate=" + strOldCorrectionDate
    url = url + "&NewCode=" + strNewCode
    url = url + "&OldCode=" + strOldCode
    url = url + "&CorrectionField=" + strCorrectionField
    url = url + "&CompanyCheckStatus=" + 0
    xmlHttp1.onreadystatechange = DesignationStateChanged;
    xmlHttp1.open("POST", url, true)
    xmlHttp1.setRequestHeader("Content-Type", "application/x-www-form-urlencoded")
    xmlHttp1.send(null)
}

function DesignationStateChanged() {
    if (xmlHttp1.readyState == 4 || xmlHttp1.readyState == "complete") {

        ShowMessage(xmlHttp1.responseText)
    }
}
function CorrectCategory(strCompany, strHrLocation, LocationAutoID, strEmployeeNumber, strCorrectionDate, strOldCorrectionDate, strNewCode, strOldCode, strCorrectionField) {
    var xmlHttpGetCount
    xmlHttp2 = GetXmlHttpObject()

    if (xmlHttp2 == null) {
        alert("Browser does not support HTTP Request")
        return
    }
    var url = "CorrectEmployeeDetailsAjax.aspx"
    url = url + "?EmployeeNumber=" + strEmployeeNumber
    url = url + "&Company=" + strCompany
    url = url + "&HrLocation=" + strHrLocation
    url = url + "&LocationAutoID=" + LocationAutoID
    url = url + "&CorrectionDate=" + strCorrectionDate
    url = url + "&OldCorrectionDate=" + strOldCorrectionDate
    url = url + "&NewCode=" + strNewCode
    url = url + "&OldCode=" + strOldCode
    url = url + "&CorrectionField=" + strCorrectionField
    url = url + "&CompanyCheckStatus=" + 0
    xmlHttp2.onreadystatechange = CategoryStateChanged;
    xmlHttp2.open("POST", url, true)
    xmlHttp2.setRequestHeader("Content-Type", "application/x-www-form-urlencoded")
    xmlHttp2.send(null)
}

function CategoryStateChanged() {
    if (xmlHttp2.readyState == 4 || xmlHttp2.readyState == "complete") {

        ShowMessage(xmlHttp2.responseText)
    }
}

function CorrectDepartment(strCompany, strHrLocation, LocationAutoID, strEmployeeNumber, strCorrectionDate, strOldCorrectionDate, strNewCode, strOldCode, strCorrectionField) {
    var xmlHttpGetCount
    xmlHttp9 = GetXmlHttpObject()

    if (xmlHttp9 == null) {
        alert("Browser does not support HTTP Request")
        return
    }
    var url = "CorrectEmployeeDetailsAjax.aspx"
    url = url + "?EmployeeNumber=" + strEmployeeNumber
    url = url + "&Company=" + strCompany
    url = url + "&HrLocation=" + strHrLocation
    url = url + "&LocationAutoID=" + LocationAutoID
    url = url + "&CorrectionDate=" + strCorrectionDate
    url = url + "&OldCorrectionDate=" + strOldCorrectionDate
    url = url + "&NewCode=" + strNewCode
    url = url + "&OldCode=" + strOldCode
    url = url + "&CorrectionField=" + strCorrectionField
    url = url + "&CompanyCheckStatus=" + 0
    xmlHttp9.onreadystatechange = DepartmentStateChanged;
    xmlHttp9.open("POST", url, true)
    xmlHttp9.setRequestHeader("Content-Type", "application/x-www-form-urlencoded")
    xmlHttp9.send(null)
}
function DepartmentStateChanged() {
    if (xmlHttp9.readyState == 4 || xmlHttp9.readyState == "complete") {

        ShowMessage(xmlHttp9.responseText)
    }
}

function CorrectJobType(strCompany, strHrLocation, LocationAutoID, strEmployeeNumber, strCorrectionDate, strOldCorrectionDate, strNewCode, strOldCode, strCorrectionField) {
    var xmlHttpGetCount
    xmlHttp3 = GetXmlHttpObject()

    if (xmlHttp3 == null) {
        alert("Browser does not support HTTP Request")
        return
    }
    var url = "CorrectEmployeeDetailsAjax.aspx"
    url = url + "?EmployeeNumber=" + strEmployeeNumber
    url = url + "&Company=" + strCompany
    url = url + "&HrLocation=" + strHrLocation
    url = url + "&LocationAutoID=" + LocationAutoID
    url = url + "&CorrectionDate=" + strCorrectionDate
    url = url + "&OldCorrectionDate=" + strOldCorrectionDate
    url = url + "&NewCode=" + strNewCode
    url = url + "&OldCode=" + strOldCode
    url = url + "&CorrectionField=" + strCorrectionField
    url = url + "&CompanyCheckStatus=" + 0
    xmlHttp3.onreadystatechange = JobTypeStateChanged;
    xmlHttp3.open("POST", url, true)
    xmlHttp3.setRequestHeader("Content-Type", "application/x-www-form-urlencoded")
    xmlHttp3.send(null)
}

function JobTypeStateChanged() {
    if (xmlHttp3.readyState == 4 || xmlHttp3.readyState == "complete") {

        ShowMessage(xmlHttp3.responseText)
    }
}

function CorrectJobClass(strCompany, strHrLocation, LocationAutoID, strEmployeeNumber, strCorrectionDate, strOldCorrectionDate, strNewCode, strOldCode, strCorrectionField) {
    var xmlHttpGetCount
    xmlHttp4 = GetXmlHttpObject()

    if (xmlHttp4 == null) {
        alert("Browser does not support HTTP Request")
        return
    }
    var url = "CorrectEmployeeDetailsAjax.aspx"
    url = url + "?EmployeeNumber=" + strEmployeeNumber
    url = url + "&Company=" + strCompany
    url = url + "&HrLocation=" + strHrLocation
    url = url + "&LocationAutoID=" + LocationAutoID
    url = url + "&CorrectionDate=" + strCorrectionDate
    url = url + "&OldCorrectionDate=" + strOldCorrectionDate
    url = url + "&NewCode=" + strNewCode
    url = url + "&OldCode=" + strOldCode
    url = url + "&CorrectionField=" + strCorrectionField
    url = url + "&CompanyCheckStatus=" + 0
    xmlHttp4.onreadystatechange = JobClassStateChanged;
    xmlHttp4.open("POST", url, true)
    xmlHttp4.setRequestHeader("Content-Type", "application/x-www-form-urlencoded")
    xmlHttp4.send(null)
}

function JobClassStateChanged() {
    if (xmlHttp4.readyState == 4 || xmlHttp4.readyState == "complete") {

        ShowMessage(xmlHttp4.responseText)
    }
}


function CorrectRole(strCompany, strHrLocation, LocationAutoID, strEmployeeNumber, strCorrectionDate, strOldCorrectionDate, strNewCode, strOldCode, strCorrectionField) {
    var xmlHttpGetCount
    xmlHttp8 = GetXmlHttpObject()

    if (xmlHttp8 == null) {
        alert("Browser does not support HTTP Request")
        return
    }
    var url = "CorrectEmployeeDetailsAjax.aspx"
    url = url + "?EmployeeNumber=" + strEmployeeNumber
    url = url + "&Company=" + strCompany
    url = url + "&HrLocation=" + strHrLocation
    url = url + "&LocationAutoID=" + LocationAutoID
    url = url + "&CorrectionDate=" + strCorrectionDate
    url = url + "&OldCorrectionDate=" + strOldCorrectionDate
    url = url + "&NewCode=" + strNewCode
    url = url + "&OldCode=" + strOldCode
    url = url + "&CorrectionField=" + strCorrectionField
    url = url + "&CompanyCheckStatus=" + 0
    xmlHttp8.onreadystatechange = RoleStateChanged;
    xmlHttp8.open("POST", url, true)
    xmlHttp8.setRequestHeader("Content-Type", "application/x-www-form-urlencoded")
    xmlHttp8.send(null)
}

function RoleStateChanged() {
    if (xmlHttp8.readyState == 4 || xmlHttp8.readyState == "complete") {

        ShowMessage(xmlHttp8.responseText)
    }
}




function CorrectAreaID(strCompany, strHrLocation, LocationAutoID, strEmployeeNumber, strCorrectionDate, strOldCorrectionDate, strNewCode, strOldCode, strCorrectionField) {
    var xmlHttpGetCount
    xmlHttp9 = GetXmlHttpObject()

    if (xmlHttp9 == null) {
        alert("Browser does not support HTTP Request")
        return
    }
    var url = "CorrectEmployeeDetailsAjax.aspx"
    url = url + "?EmployeeNumber=" + strEmployeeNumber
    url = url + "&Company=" + strCompany
    url = url + "&HrLocation=" + strHrLocation
    url = url + "&LocationAutoID=" + LocationAutoID
    url = url + "&CorrectionDate=" + strCorrectionDate
    url = url + "&OldCorrectionDate=" + strOldCorrectionDate
    url = url + "&NewCode=" + strNewCode
    url = url + "&OldCode=" + strOldCode
    url = url + "&CorrectionField=" + strCorrectionField
    url = url + "&CompanyCheckStatus=" + 0
    xmlHttp9.onreadystatechange = AreaIDStateChanged;
    xmlHttp9.open("POST", url, true)
    xmlHttp9.setRequestHeader("Content-Type", "application/x-www-form-urlencoded")
    xmlHttp9.send(null)
}

function AreaIDStateChanged() {
    if (xmlHttp9.readyState == 4 || xmlHttp9.readyState == "complete") {

        ShowMessage(xmlHttp9.responseText)
    }
}




function GetEmployeeHistroyDetail(strEmployeeNumber, strCompany, LocationAutoID, strGetField, EmployeeName, CompanyDesc, LocationDesc, HrLocationDesc, DesignationDesc, CategoryDesc, DepartmentDesc, JobClassDesc, JobTypeDesc, RoleDesc, AreaDesc) {
    var xmlHttpGetCount
    xmlHttp5 = GetXmlHttpObject()

    if (xmlHttp5 == null) {
        alert("Browser does not support HTTP Request")
        return
    }
    var url = "GetEmployeeHistroyDetailAjax.aspx"
    url = url + "?EmployeeNumber=" + strEmployeeNumber
    url = url + "&Company=" + strCompany
    url = url + "&LocationAutoID=" + LocationAutoID
    url = url + "&GetField=" + strGetField
    url = url + "&EmployeeName=" + EmployeeName
    url = url + "&CompanyDesc=" + CompanyDesc
    url = url + "&HrLocationDesc=" + HrLocationDesc
    url = url + "&LocationDesc=" + LocationDesc
    url = url + "&DesignationDesc=" + DesignationDesc
    url = url + "&CategoryDesc=" + CategoryDesc
    url = url + "&DepartmentDesc=" + DepartmentDesc
    url = url + "&JobTypeDesc=" + JobTypeDesc
    url = url + "&JobClassDesc=" + JobClassDesc
    url = url + "&RoleDesc=" + RoleDesc
    url = url + "&AreaDesc=" + AreaDesc
    xmlHttp5.onreadystatechange = EmployeeHistroyDetailStateChanged;
    xmlHttp5.open("POST", url, true)
    xmlHttp5.setRequestHeader("Content-Type", "application/x-www-form-urlencoded")
    xmlHttp5.send(null)

}
function EmployeeHistroyDetailStateChanged() {
    if (xmlHttp5.readyState == 4 || xmlHttp5.readyState == "complete") {

        ShowEmployeeHistroyMessage(xmlHttp5.responseText)
    }
}

function CorrectCompany(EmployeeNumber, OldCompanyCode, NewCompanyCode, OldCompanyCorrectionDate, NewCorrectionDate, OldHrLocationCode, NewHrLocation, OldLocationAutoID, NewLocationAutoID, OldDesignationCode, NewDesinationCode, OldCategoryCode, NewCategoryCode, OldDepartmentCode, NewDepartmentCode, OldJobTypeCode, NewJobTypeCode, OldJobClassCode, NewJobClassCode, OldRoleCode, NewRoleCode, OldAreaCode, NewAreaCode) {
    var xmlHttpGetCount
    xmlHttp6 = GetXmlHttpObject()

    if (xmlHttp6 == null) {
        alert("Browser does not support HTTP Request")
        return
    }
    var url = "CorrectEmployeeDetailsAjax.aspx"
    url = url + "?OldCompanyCode=" + OldCompanyCode
    url = url + "&NewCompanyCode=" + NewCompanyCode
    url = url + "&OldCompanyCorrectionDate=" + OldCompanyCorrectionDate
    url = url + "&NewCorrectionDate=" + NewCorrectionDate
    url = url + "&OldHrLocationCode=" + OldHrLocationCode
    url = url + "&NewHrLocation=" + NewHrLocation
    url = url + "&OldLocationAutoID=" + OldLocationAutoID
    url = url + "&NewLocationAutoID=" + NewLocationAutoID
    url = url + "&OldDesignationCode=" + OldDesignationCode
    url = url + "&NewDesinationCode=" + NewDesinationCode
    url = url + "&OldCategoryCode=" + OldCategoryCode
    url = url + "&NewCategoryCode=" + NewCategoryCode
    url = url + "&OldJobTypeCode=" + OldJobTypeCode
    url = url + "&NewJobTypeCode=" + NewJobTypeCode
    url = url + "&OldJobClassCode=" + OldJobClassCode
    url = url + "&NewJobClassCode=" + NewJobClassCode

    url = url + "&OldDepartmentCode=" + OldDepartmentCode
    url = url + "&NewDepartmentCode=" + NewDepartmentCode

    url = url + "&OldRoleCode=" + OldRoleCode
    url = url + "&NewRoleCode=" + NewRoleCode
    url = url + "&OldAreaCode=" + OldAreaCode
    url = url + "&NewAreaCode=" + NewAreaCode
    url = url + "&EmployeeNumber=" + EmployeeNumber
    url = url + "&CompanyCheckStatus=" + 1
    xmlHttp6.onreadystatechange = CorrectCompanyStateChanged;
    xmlHttp6.open("POST", url, true)
    xmlHttp6.setRequestHeader("Content-Type", "application/x-www-form-urlencoded")
    xmlHttp6.send(null)
}

function CorrectCompanyStateChanged() {
    if (xmlHttp6.readyState == 4 || xmlHttp6.readyState == "complete") {

        ShowMessage(xmlHttp6.responseText)
    }
}

function CorrectLocation(EmployeeNumber, CompanyCode, NewHrLocation, NewLocationAutoID, OldLocationAutoID, NewDesinationCode, NewCategoryCode, NewJobTypeCode, NewDepartmentCode, NewJobClassCode, CorrectionDate, NewRole, NewAreaCode) {
    var xmlHttpGetCount
    xmlHttp7 = GetXmlHttpObject()

    if (xmlHttp7 == null) {
        alert("Browser does not support HTTP Request")
        return
    }
    var url = "CorrectEmployeeLocationDetailsAjax.aspx"
    url = url + "?CompanyCode=" + CompanyCode
    url = url + "&HrLocation=" + NewHrLocation
    url = url + "&NewLocationAutoID=" + NewLocationAutoID
    url = url + "&OldLocationAutoID=" + OldLocationAutoID

    url = url + "&NewDesinationCode=" + NewDesinationCode
    url = url + "&NewCategoryCode=" + NewCategoryCode
    url = url + "&NewJobClassCode=" + NewJobClassCode
    url = url + "&NewJobTypeCode=" + NewJobTypeCode
    url = url + "&NewRoleCode=" + NewRole
    url = url + "&NewAreaCode=" + NewAreaCode

    url = url + "&NewDepartmentCode=" + NewDepartmentCode

    url = url + "&EmployeeNumber=" + EmployeeNumber
    url = url + "&CorrectionDate=" + CorrectionDate
    xmlHttp7.onreadystatechange = CorrectLocationStateChanged;
    xmlHttp7.open("POST", url, true)
    xmlHttp7.setRequestHeader("Content-Type", "application/x-www-form-urlencoded")
    xmlHttp7.send(null)
}

function CorrectLocationStateChanged() {
    if (xmlHttp7.readyState == 4 || xmlHttp7.readyState == "complete") {

        ShowMessage(xmlHttp7.responseText)
    }
}
function GetXmlHttpObject() {
    var objXMLHttp = null
    if (window.XMLHttpRequest) {
        objXMLHttp = new XMLHttpRequest()
    }
    else if (window.ActiveXObject) {
        objXMLHttp = new ActiveXObject("Microsoft.XMLHTTP")
    }
    return objXMLHttp
}
