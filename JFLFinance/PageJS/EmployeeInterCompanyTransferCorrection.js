function DoCorrection() {
    var cb = $("#ctl00_ContentPlaceHolder1_CBCompany").is(':checked');
    if (cb === false) {
        if (($("#ctl00_ContentPlaceHolder1_CBHrLocation").is(':checked') === true || $("#ctl00_ContentPlaceHolder1_CBLocation").is(':checked') === true)) //|| ($("#ctl00_ContentPlaceHolder1_CBHrLocation").is(':checked') == false && $("#ctl00_ContentPlaceHolder1_CBLocation").is(':checked') == true)) 
        {
            CorrectEmployeeLocationRelatedDetails();
        } else {
            var checkBoxMessage = confirm("Are you sure you want to Continue");
            if (checkBoxMessage === true) {
                CorrectEmployeeJobRelatedDetails();
            }
        }
    } else {
        CorrectEmployeeCompanyRelatedDetails();
    }

}

function ShowMessage(strMessage) {
    var arr = new Array();
    arr = strMessage.split(",");
    $('#ctl00_ContentPlaceHolder1_CBAreaID').prop('checked', false);
    $('#ctl00_ContentPlaceHolder1_CBRole').prop('checked', false);
    $('#ctl00_ContentPlaceHolder1_CBDesignation').prop('checked', false);
    $('#ctl00_ContentPlaceHolder1_CBCompany').prop('checked', false);
    $('#ctl00_ContentPlaceHolder1_CBLocation').prop('checked', false);
    $('#ctl00_ContentPlaceHolder1_CBHrLocation').prop('checked', false);
    $('#ctl00_ContentPlaceHolder1_CBCategory').prop('checked', false);
    $('#ctl00_ContentPlaceHolder1_CBDepartment').prop('checked', false);
    $('#ctl00_ContentPlaceHolder1_CBJobType').prop('checked', false);
    $('#ctl00_ContentPlaceHolder1_CBJobClass').prop('checked', false);
    if (arr[1] == "FALSE") {
        alert(arr[0]);
        location.reload(true);
        return;
    } else {
        if ($("#ctl00_ContentPlaceHolder1_CBAreaID").is(':checked') === false
        && ($("#ctl00_ContentPlaceHolder1_CBRole").is(':checked') === false)
        && ($("#ctl00_ContentPlaceHolder1_CBDesignation").is(':checked') === false)
        && ($("#ctl00_ContentPlaceHolder1_CBCompany").is(':checked') === false)
        && ($("#ctl00_ContentPlaceHolder1_CBLocation").is(':checked') === false)
        && ($("#ctl00_ContentPlaceHolder1_CBHrLocation").is(':checked') === false)
         && ($("#ctl00_ContentPlaceHolder1_CBCategory").is(':checked') === false)
         && ($("#ctl00_ContentPlaceHolder1_CBDepartment").is(':checked') === false)
         && ($("#ctl00_ContentPlaceHolder1_CBJobType").is(':checked') === false)
          && ($("#ctl00_ContentPlaceHolder1_CBJobClass").is(':checked') === false)) {

            ($("#ctl00_ContentPlaceHolder1_lblErrorMsg")).text(arr[0]);
            if (arr[0] === 'Record Updated Successfully') {
                ($("#ctl00_ContentPlaceHolder1_lblErrorMsg")).show();
            }
            else {
                ($("#ctl00_ContentPlaceHolder1_lblErrorMsg")).hide();
            }
            setTimeout(function () {
                location.reload(true);
            }, 1000);
            ($("#ctl00_ContentPlaceHolder1_lblErrorMsg")).show();
        } else if (($("#ctl00_ContentPlaceHolder1_CBCompany").is(':checked') === true) && ($("#ctl00_ContentPlaceHolder1_CBLocation").is(':checked') === true) && ($("#ctl00_ContentPlaceHolder1_CBHrLocation").is(':checked') === true)) {
            ($("#ctl00_ContentPlaceHolder1_lblErrorMsg")).text(arr[0]);
            setTimeout(function () {
                location.reload(true);
            }, 1000);
        }
    }

}


function GetEmployeeHistoryDetail(strEmployeeNumber, strCompany, locationAutoId, strGetField, employeeName, companyDesc, locationDesc, hrLocationDesc, designationDesc, categoryDesc, departmentDesc, jobClassDesc, jobTypeDesc, roleDesc, areaDesc) {

    var url = "GetEmployeeHistroyDetailAjax.aspx";
    url = url + "?EmployeeNumber=" +encodeURIComponent(strEmployeeNumber);
    url = url + "&Company=" + encodeURIComponent(strCompany);
    url = url + "&LocationAutoID=" + encodeURIComponent(locationAutoId);
    url = url + "&GetField=" +encodeURIComponent( strGetField);
    url = url + "&EmployeeName=" + encodeURIComponent(employeeName);
    url = url + "&CompanyDesc=" + encodeURIComponent(companyDesc);
    url = url + "&HrLocationDesc=" + encodeURIComponent(hrLocationDesc);
    url = url + "&LocationDesc=" + encodeURIComponent(locationDesc);
    url = url + "&DesignationDesc=" + encodeURIComponent(designationDesc);
    url = url + "&CategoryDesc=" + encodeURIComponent(categoryDesc);
    url = url + "&JobTypeDesc=" + encodeURIComponent(jobTypeDesc);
    url = url + "&JobClassDesc=" + encodeURIComponent(jobClassDesc);
    url = url + "&RoleDesc=" + encodeURIComponent(roleDesc);
    url = url + "&AreaDesc=" + encodeURIComponent(areaDesc);
    Request(url);
}

function CorrectLocation(employeeNumber, companyCode, newHrLocation, newLocationAutoId, oldLocationAutoId, newDesinationCode, newCategoryCode, newJobTypeCode, newDepartmentCode, newJobClassCode, correctionDate, newRole, newAreaCode) {

        var url = "CorrectEmployeeLocationDetailsAjax.aspx";
        url = url + "?CompanyCode=" + encodeURIComponent(companyCode);
        url = url + "&HrLocation=" + encodeURIComponent(newHrLocation);
        url = url + "&NewLocationAutoID=" + encodeURIComponent(newLocationAutoId);
        url = url + "&OldLocationAutoID=" + encodeURIComponent(oldLocationAutoId);
        url = url + "&NewDesinationCode=" + encodeURIComponent(newDesinationCode);
        url = url + "&NewCategoryCode=" + encodeURIComponent(newCategoryCode);
        url = url + "&NewJobClassCode=" + encodeURIComponent(newJobClassCode);
        url = url + "&NewJobTypeCode=" + encodeURIComponent(newJobTypeCode);
        url = url + "&NewRoleCode=" + encodeURIComponent(newRole);
        url = url + "&NewAreaCode=" +encodeURIComponent( newAreaCode);
        url = url + "&NewDepartmentCode=" + encodeURIComponent(newDepartmentCode);
        url = url + "&EmployeeNumber=" + encodeURIComponent(employeeNumber);
        url = url + "&CorrectionDate=" + encodeURIComponent(correctionDate);
        Request(url);
    }

function CorrectEmployeeLocationRelatedDetails() {
    var employeeNumber = $("#ctl00_ContentPlaceHolder1_lblEmpNumber").text();
    var hrLocation = $("#ctl00_ContentPlaceHolder1_ddlHrLocation").val();
    var company = $("#ctl00_ContentPlaceHolder1_ddlCompany").val();
    var locationAutoId = $("#ctl00_ContentPlaceHolder1_ddlLocation").val();
    var employeeName = $("#ctl00_ContentPlaceHolder1_lblEmpName").text();
    var companyDesc = $("#ctl00_ContentPlaceHolder1_lblCurrentCompany").text();
    var locationDesc = $("#ctl00_ContentPlaceHolder1_lblCurrentLocation").text();
    var hrLocationDesc = $("#ctl00_ContentPlaceHolder1_lblCurrentHrLocation").text();
    var departmentDesc = $("#ctl00_ContentPlaceHolder1_lblCurrentDepartment").text();
    var designationDesc = $("#ctl00_ContentPlaceHolder1_lblCurrentDesignation").text();
    var categoryDesc = $("#ctl00_ContentPlaceHolder1_lblCurrentCategory").text();
    var jobTypeDesc = "";
    var jobClassDesc = "";
    var roleDesc = "";
    var areaDesc = "";

    if (($("#ctl00_ContentPlaceHolder1_CBHrLocation").is(':checked') === true || $("#ctl00_ContentPlaceHolder1_CBLocation").is(':checked') === true) && $("#ctl00_ContentPlaceHolder1_CBCompany").is(':checked') === false) {
        if ($("#ctl00_ContentPlaceHolder1_HFOldAreaCount").val() < 1 || $("#ctl00_ContentPlaceHolder1_HFOldRoleCount").val() < 1 || $("#ctl00_ContentPlaceHolder1_HFOldCompanyCount").val() < 1 || $("#ctl00_ContentPlaceHolder1_HFOldLocationCount").val() < 1 || $("#ctl00_ContentPlaceHolder1_HFOldHrLocationCount").val() < 1 || $("#ctl00_ContentPlaceHolder1_HFOldDesignationCount").val() < 1 || $("#ctl00_ContentPlaceHolder1_HFOldCategoryCount").val() < 1 || $("#ctl00_ContentPlaceHolder1_HFOldDepartmentCount").val() < 1 || $("#ctl00_ContentPlaceHolder1_HFOldJobTypeCount").val() < 1 || $("#ctl00_ContentPlaceHolder1_HFOldJobClassCount").val() < 1) {

            if ($("#ctl00_ContentPlaceHolder1_HFOldCompanyCount").val() > 1) {
                alert("Correction Not Possible Employee doest not exist in the selected HrLocation/Location");
            }
        } else if (
        $("#ctl00_ContentPlaceHolder1_HFOldCompanyCount").val() > 1 || $("#ctl00_ContentPlaceHolder1_HFOldLocationCount").val() > 1 || $("#ctl00_ContentPlaceHolder1_HFOldHrLocationCount").val() > 1 || $("#ctl00_ContentPlaceHolder1_HFOldDesignationCount").val() > 1 || $("#ctl00_ContentPlaceHolder1_HFOldCategoryCount").val() > 1 || $("#ctl00_ContentPlaceHolder1_HFOldDepartmentCount").val() > 1 || $("#ctl00_ContentPlaceHolder1_HFOldJobTypeCount").val() > 1 || $("#ctl00_ContentPlaceHolder1_HFOldJobClassCount").val() > 1) {
            if ($("#ctl00_ContentPlaceHolder1_HFOldCompanyCount").val() > 1) {
                GetEmployeeHistoryDetail(employeeNumber, company, locationAutoId,
                    "Company", employeeName, companyDesc, locationDesc, hrLocationDesc,
                designationDesc, categoryDesc, departmentDesc, jobClassDesc,
                jobTypeDesc, roleDesc, areaDesc);

            } else if ($("#ctl00_ContentPlaceHolder1_HFOldHrLocationCount").val() > 1) {
                GetEmployeeHistoryDetail(employeeNumber, company, locationAutoId,
                    "HrLocation", employeeName, companyDesc, locationDesc, hrLocationDesc,
                designationDesc, categoryDesc, departmentDesc, jobClassDesc, jobTypeDesc,
                roleDesc, areaDesc);
            } else if ($("#ctl00_ContentPlaceHolder1_HFOldLocationCount").val() > 1) {
                GetEmployeeHistoryDetail(employeeNumber, company, locationAutoId,
                    "Location", employeeName, companyDesc, locationDesc, hrLocationDesc,
                designationDesc, categoryDesc, departmentDesc, jobClassDesc, jobTypeDesc,
                roleDesc, areaDesc);

            } else if ($("#ctl00_ContentPlaceHolder1_HFOldDesignationCount").val() > 1) {
                GetEmployeeHistoryDetail(employeeNumber, company, locationAutoId,
                    "Designation", employeeName, companyDesc, locationDesc, hrLocationDesc,
                designationDesc, categoryDesc, departmentDesc, jobClassDesc, jobTypeDesc,
                roleDesc, areaDesc);

            } else if ($("#ctl00_ContentPlaceHolder1_HFOldCategoryCount").val() > 1) {
                GetEmployeeHistoryDetail(employeeNumber, company, locationAutoId,
                    "Category", employeeName, companyDesc, locationDesc, hrLocationDesc,
                designationDesc, categoryDesc, departmentDesc, jobClassDesc, jobTypeDesc,
                roleDesc, areaDesc);

            } else if ($("#ctl00_ContentPlaceHolder1_HFOldDepartmentCount").val() > 1) {
                GetEmployeeHistoryDetail(employeeNumber, company, locationAutoId,
                    "Department", employeeName, companyDesc, locationDesc, hrLocationDesc,
                designationDesc, categoryDesc, departmentDesc, jobClassDesc, jobTypeDesc,
                roleDesc, areaDesc);

            } else if ($("#ctl00_ContentPlaceHolder1_HFOldJobClassCount").val() > 1) {
                GetEmployeeHistoryDetail(employeeNumber, company, locationAutoId,
                    "JobClass", employeeName, companyDesc, locationDesc, hrLocationDesc,
                designationDesc, categoryDesc, departmentDesc, jobClassDesc, jobTypeDesc,
                roleDesc, areaDesc);

            } else if ($("#ctl00_ContentPlaceHolder1_HFOldJobTypeCount").val() > 1) {
                GetEmployeeHistoryDetail(employeeNumber, company, locationAutoId,
                    "Jobtype", employeeName, companyDesc, locationDesc, hrLocationDesc,
                designationDesc, categoryDesc, departmentDesc, jobClassDesc, jobTypeDesc,
                roleDesc, areaDesc);

            } else if ($("#ctl00_ContentPlaceHolder1_HFOldRoleCount").val() > 1) {
                GetEmployeeHistoryDetail(employeeNumber, company, locationAutoId,
                    "Role", employeeName, companyDesc, locationDesc, hrLocationDesc,
                designationDesc, categoryDesc, departmentDesc, jobClassDesc, jobTypeDesc,
                roleDesc, areaDesc);

            } else if ($("#ctl00_ContentPlaceHolder1_HFOldAreaCount").val() > 1) {
                GetEmployeeHistoryDetail(employeeNumber, company, locationAutoId,
                    "AreaID", employeeName, companyDesc, locationDesc, hrLocationDesc,
                designationDesc, categoryDesc, departmentDesc, jobClassDesc, jobTypeDesc,
                roleDesc, areaDesc);

            }
        } else if ($("#ctl00_ContentPlaceHolder1_HFOldAreaCount").val() == 1 && ($("#ctl00_ContentPlaceHolder1_HFOldAreaCount").val() == 1) && ($("#ctl00_ContentPlaceHolder1_HFOldCompanyCount").val() == 1) && ($("#ctl00_ContentPlaceHolder1_HFOldHrLocationCount").val() == 1) && ($("#ctl00_ContentPlaceHolder1_HFOldLocationCount").val() == 1) && ($("#ctl00_ContentPlaceHolder1_HFOldDesignationCount").val() == 1) && ($("#ctl00_ContentPlaceHolder1_HFOldCategoryCount").val() == 1) && ($("#ctl00_ContentPlaceHolder1_HFOldDepartmentCount").val() == 1) && ($("#ctl00_ContentPlaceHolder1_HFOldJobTypeCount").val() == 1) && ($("#ctl00_ContentPlaceHolder1_HFOldJobClassCount").val() == 1)) {
            var companyCode = company;
            var newHrLocation = hrLocation;
            var newLocationAutoId = locationAutoId;
            var oldLocationAutoId = ($("#ctl00_ContentPlaceHolder1_hfLocationAutoID").val());
            var correctionDate = $("#ctl00_ContentPlaceHolder1_txtEffectiveFromHrLocation").val();
            var newDesignationCode = $("#ctl00_ContentPlaceHolder1_ddlDesignation").val();
            var newCategoryCode = $("#ctl00_ContentPlaceHolder1_ddlCategory").val();
            var newDepartmentCode = $("#ctl00_ContentPlaceHolder1_ddlDepartment").val();
            var newJobTypeCode = $("#ctl00_ContentPlaceHolder1_ddlJobType").val();
            var newJobClassCode = $("#ctl00_ContentPlaceHolder1_ddlJobClass").val();
            var newRoleCode = $("#ctl00_ContentPlaceHolder1_ddlRole").val();
            var newAreaCode = $("#ctl00_ContentPlaceHolder1_ddlAreaID").val();

            CorrectLocation(employeeNumber, companyCode, newHrLocation, newLocationAutoId, oldLocationAutoId, newDesignationCode, newCategoryCode, newDepartmentCode, newJobTypeCode, newJobClassCode, correctionDate, newRoleCode, newAreaCode);
        }

    }
}

function CorrectEmployeeCompanyRelatedDetails() {
    var sList = "";
    $('input[type=checkbox]').each(function () {
        var sThisVal = (this.checked ? "1" : "0");
        sList += (sList === "" ? sThisVal : "," + sThisVal);
    });
    var company = $("#ctl00_ContentPlaceHolder1_ddlCompany").val();
    var hrLocation = $("#ctl00_ContentPlaceHolder1_ddlHrLocation").val();
    var locationAutoId = $("#ctl00_ContentPlaceHolder1_ddlLocation").val();
    var employeeNumber = $("#ctl00_ContentPlaceHolder1_lblEmpNumber").text();
    var employeeName = $("#ctl00_ContentPlaceHolder1_lblEmpName").text();
    var companyDesc = $("#ctl00_ContentPlaceHolder1_lblCurrentCompany").text();
    var hrLocationDesc = $("#ctl00_ContentPlaceHolder1_lblCurrentHrLocation").text();
    var locationDesc = $("#ctl00_ContentPlaceHolder1_lblCurrentLocation").text();
    var designationDesc = $("#ctl00_ContentPlaceHolder1_lblCurrentDesignation").text();
    var categoryDesc = $("#ctl00_ContentPlaceHolder1_lblCurrentCategory").text();
    var departmentDesc = $("#ctl00_ContentPlaceHolder1_lblCurrentDepartment").text();

    var jobTypeDesc = "";
    var jobClassDesc = "";
    var roleDesc = "";
    var areaDesc = "";

    if ($("#ctl00_ContentPlaceHolder1_HFOldAreaCount").val() > 1 || $("#ctl00_ContentPlaceHolder1_HFOldRoleCount").val() > 1 || $("#ctl00_ContentPlaceHolder1_HFOldCompanyCount").val() > 1 || $("#ctl00_ContentPlaceHolder1_HFOldLocationCount").val() > 1 || $("#ctl00_ContentPlaceHolder1_HFOldHrLocationCount").val() > 1 || $("#ctl00_ContentPlaceHolder1_HFOldDesignationCount").val() > 1 || $("#ctl00_ContentPlaceHolder1_HFOldCategoryCount").val() > 1 || $("#ctl00_ContentPlaceHolder1_HFOldDepartmentCount").val() > 1 || $("#ctl00_ContentPlaceHolder1_HFOldJobTypeCount").val() > 1 || $("#ctl00_ContentPlaceHolder1_HFOldJobClassCount").val() > 1) {
        if ($("#ctl00_ContentPlaceHolder1_HFOldCompanyCount").val() > 1) {
            GetEmployeeHistoryDetail(employeeNumber, company, locationAutoId, "Company", employeeName,
            companyDesc, locationDesc, hrLocationDesc, designationDesc, categoryDesc, departmentDesc,
            jobClassDesc, jobTypeDesc, roleDesc, areaDesc);
        } else if ($("#ctl00_ContentPlaceHolder1_HFOldHrLocationCount").val() > 1) {
            GetEmployeeHistoryDetail(employeeNumber, company, locationAutoId,
                "HrLocation", employeeName, companyDesc, locationDesc, hrLocationDesc,
            designationDesc, categoryDesc, departmentDesc, jobClassDesc, jobTypeDesc,
            roleDesc, areaDesc);
        } else if ($("#ctl00_ContentPlaceHolder1_HFOldLocationCount").val() > 1) {
            GetEmployeeHistoryDetail(employeeNumber, company, locationAutoId,
                "Location", employeeName, companyDesc, locationDesc, hrLocationDesc,
            designationDesc, categoryDesc, departmentDesc, jobClassDesc, jobTypeDesc,
            roleDesc, areaDesc);

        } else if ($("#ctl00_ContentPlaceHolder1_HFOldDesignationCount").val() > 1) {
            GetEmployeeHistoryDetail(employeeNumber, company, locationAutoId,
                "Designation", employeeName, companyDesc, locationDesc, hrLocationDesc,
            designationDesc, categoryDesc, departmentDesc, jobClassDesc, jobTypeDesc,
            roleDesc, areaDesc);

        } else if ($("#ctl00_ContentPlaceHolder1_HFOldCategoryCount").val() > 1) {
            GetEmployeeHistoryDetail(employeeNumber, company, locationAutoId,
                "Category", employeeName, companyDesc, locationDesc, hrLocationDesc,
            designationDesc, categoryDesc, departmentDesc, jobClassDesc, jobTypeDesc,
            roleDesc, areaDesc);

        } else if ($("#ctl00_ContentPlaceHolder1_HFOldDepartmentCount").val() > 1) {
            GetEmployeeHistoryDetail(employeeNumber, company, locationAutoId,
                "Department", employeeName, companyDesc, locationDesc, hrLocationDesc,
            designationDesc, categoryDesc, departmentDesc, jobClassDesc, jobTypeDesc,
            roleDesc, areaDesc);

        } else if ($("#ctl00_ContentPlaceHolder1_HFOldJobClassCount").val() > 1) {
            GetEmployeeHistoryDetail(employeeNumber, company, locationAutoId,
                "JobClass", employeeName, companyDesc, locationDesc, hrLocationDesc,
            designationDesc, categoryDesc, departmentDesc, jobClassDesc, jobTypeDesc,
            roleDesc, areaDesc);

        } else if ($("#ctl00_ContentPlaceHolder1_HFOldJobTypeCount").val() > 1) {
            GetEmployeeHistoryDetail(employeeNumber, company, locationAutoId,
                "Jobtype", employeeName, companyDesc, locationDesc, hrLocationDesc,
            designationDesc, categoryDesc, departmentDesc, jobClassDesc, jobTypeDesc,
            roleDesc, areaDesc);

        } else if ($("#ctl00_ContentPlaceHolder1_HFOldRoleCount").val() > 1) {
            GetEmployeeHistoryDetail(employeeNumber, company, locationAutoId,
                "Role", employeeName, companyDesc, locationDesc, hrLocationDesc,
            designationDesc, categoryDesc, departmentDesc, jobClassDesc, jobTypeDesc,
            roleDesc, areaDesc);

        } else if ($("#ctl00_ContentPlaceHolder1_HFOldAreaCount").val() > 1) {
            GetEmployeeHistoryDetail(employeeNumber, company, locationAutoId,
                "AreaID", employeeName, companyDesc, locationDesc, hrLocationDesc,
            designationDesc, categoryDesc, departmentDesc, jobClassDesc, jobTypeDesc,
            roleDesc, areaDesc);

        }
    } else if ($("#ctl00_ContentPlaceHolder1_HFOldAreaCount").val() == 1 && ($("#ctl00_ContentPlaceHolder1_HFOldAreaCount").val() == 1) && ($("#ctl00_ContentPlaceHolder1_HFOldCompanyCount").val() == 1) && ($("#ctl00_ContentPlaceHolder1_HFOldHrLocationCount").val() == 1) && ($("#ctl00_ContentPlaceHolder1_HFOldLocationCount").val() == 1) && ($("#ctl00_ContentPlaceHolder1_HFOldDesignationCount").val() == 1) && ($("#ctl00_ContentPlaceHolder1_HFOldCategoryCount").val() == 1) && ($("#ctl00_ContentPlaceHolder1_HFOldDepartmentCount").val() == 1) && ($("#ctl00_ContentPlaceHolder1_HFOldJobTypeCount").val() == 1) && ($("#ctl00_ContentPlaceHolder1_HFOldJobClassCount").val() == 1)) {

        var oldDesignationCode = $("#hfDesignationCode").val();
        var oldCategoryCode = $("#hfCategoryCode").val();
        var oldJobTypeCode = $("#hfJobTypeCode").val();
        var oldAreaCode = $("#hfAreaID").val();
        var oldRoleCode = $("#hfRoleCode").val();
        var oldDepartmentCode = $("#hfDepartmentCode").val();
        var oldJobClassCode = $("#hfJobClassCode").val();
        var oldCompanyCode = $("#hfCompanyCode").val();
        var oldCompanyCorrectionDate = $("#ctl00_ContentPlaceHolder1_HFEffectiveFromCompany").val();
        var newDesinationCode = $("#ctl00_ContentPlaceHolder1_ddlDesignation").val();
        var newCategoryCode = $("#ctl00_ContentPlaceHolder1_ddlCategory").val();
        var newJobTypeCode = $("#ctl00_ContentPlaceHolder1_ddlJobType").val();
        var newRoleCode = $("#ctl00_ContentPlaceHolder1_ddlRole").val();
        var newAreaCode = $("#ctl00_ContentPlaceHolder1_ddlAreaID").val();
        var newDepartmentCode = $("#ctl00_ContentPlaceHolder1_ddlDepartment").val();
        var newJobClassCode = $("#ctl00_ContentPlaceHolder1_ddlJobClass").val();
        var newCompanyCode = company;
        var newCompanyCorrectionDate = $("#ctl00_ContentPlaceHolder1_txtEffectiveFromCompany").val();
        var newHrLocation = hrLocation;
        var oldHrLocationCode = $("#hfHrLocationCode").val();
        var newLocationAutoId = locationAutoId;
        var oldLocationAutoId = $("#hfLocationAutoID").val();
        CorrectCompany(employeeNumber, oldCompanyCode, newCompanyCode, oldCompanyCorrectionDate, newCompanyCorrectionDate,
        oldHrLocationCode, newHrLocation, oldLocationAutoId, newLocationAutoId, oldDesignationCode, newDesinationCode,
        oldCategoryCode, newCategoryCode, oldDepartmentCode, newDepartmentCode, oldJobTypeCode, newJobTypeCode, oldJobClassCode,
        newJobClassCode, oldRoleCode, newRoleCode, oldAreaCode, newAreaCode);
    } else {
        alert("Correction Not Possible Employee doest not exist in the selected Company");
    }

}

function CorrectEmployeeJobRelatedDetails() {
    var sList = "";
    $('input[type=checkbox]').each(function() {
        var sThisVal = (this.checked ? "1" : "0");
        sList += (sList === "" ? sThisVal : "," + sThisVal);
    });

    var company = $("#ctl00_ContentPlaceHolder1_ddlCompany").val();
    var hrLocation = $("#ctl00_ContentPlaceHolder1_ddlHrLocation").val();
    var locationAutoId = $("#ctl00_ContentPlaceHolder1_ddlLocation").val();
    var employeeNumber = $("#ctl00_ContentPlaceHolder1_lblEmpNumber").text();
    var count = 0;

    if ($("#ctl00_ContentPlaceHolder1_CBDesignation").is(':checked') === true) {
        count = count + 1;
    }
    if ($("#ctl00_ContentPlaceHolder1_CBCategory").is(':checked') === true) {
        count = count + 1;
    }
    if ($("#ctl00_ContentPlaceHolder1_CBDepartment").is(':checked') === true) {
        count = count + 1;
    }
    if ($("#ctl00_ContentPlaceHolder1_CBJobType").is(':checked') === true) {
        count = count + 1;
    }
    if ($("#ctl00_ContentPlaceHolder1_CBJobClass").is(':checked') === true) {
        count = count + 1;
    }
    if ($("#ctl00_ContentPlaceHolder1_CBRole").is(':checked') === true) {
        count = count + 1;
    }
    if ($("#ctl00_ContentPlaceHolder1_CBAreaID").is(':checked') === true) {
        count = count + 1;
    }
    if ($("#ctl00_ContentPlaceHolder1_CBDesignation").is(':checked') === true) {

        var OldCorrectionDate = $("#ctl00_ContentPlaceHolder1_HFEffectiveFromDesignation").val();
        var oldDesignationCode = $("#ctl00_ContentPlaceHolder1_hfDesignationCode").val();
        var CorrectionDate = $("#ctl00_ContentPlaceHolder1_txtEffectiveFromDesignation").val();
        var newDesignationCode = $("#ctl00_ContentPlaceHolder1_ddlDesignation").val(); //$("#ctl00_ContentPlaceHolder1_ddlDesignation option:selected").text();
        CorrectDesignation(company, hrLocation, locationAutoId, employeeNumber, CorrectionDate, OldCorrectionDate, newDesignationCode, oldDesignationCode, 'Designation');
        $("#ctl00_ContentPlaceHolder1_CBDesignation").is(':checked') === false;

    }
    if ($("#ctl00_ContentPlaceHolder1_CBCategory").is(':checked') === true) {
        var OldCorrectionDate = $("#ctl00_ContentPlaceHolder1_HFEffectiveFromCategory").val();
        var oldCategoryCode = $("#ctl00_ContentPlaceHolder1_hfCategoryCode").val();
        var CorrectionDate = $("#ctl00_ContentPlaceHolder1_txtEffectiveFromCategory").val();
        var newCategoryCode = $("#ctl00_ContentPlaceHolder1_ddlCategory").val();
        CorrectCategory(company, hrLocation, locationAutoId, employeeNumber, CorrectionDate, OldCorrectionDate, newCategoryCode, oldCategoryCode, 'Category');
        $("#ctl00_ContentPlaceHolder1_CBCategory").is(':checked') === false;
    }

    if ($("#ctl00_ContentPlaceHolder1_CBDepartment").is(':checked') == true) {
        var OldCorrectionDate = $("#ctl00_ContentPlaceHolder1_HFEffectiveFromDepartment").val();
        var CorrectionDate = $("#ctl00_ContentPlaceHolder1_txtEffectiveFromDepartment").val();
        var oldDepartmentCode = $("#ctl00_ContentPlaceHolder1_hfDepartmentCode").val();
        var newDepartmentCode = $("#ctl00_ContentPlaceHolder1_ddlDepartment").val(); //$("ddlDepartment option:selected").text();
        CorrectDepartment(company, hrLocation, locationAutoId, employeeNumber, CorrectionDate, OldCorrectionDate, newDepartmentCode, oldDepartmentCode, 'Department');
        $("#ctl00_ContentPlaceHolder1_CBDepartment").is(':checked') == false;
    }

    if ($("#ctl00_ContentPlaceHolder1_CBJobType").is(':checked') == true) {
        var OldCorrectionDate = $("#ctl00_ContentPlaceHolder1_HFEffectiveFromJobType").val();
        var CorrectionDate = $("#ctl00_ContentPlaceHolder1_txtEffectiveFromJobType").val();
        var oldJobTypeCode = $("#ctl00_ContentPlaceHolder1_hfJobTypeCode").val();
        var newJobTypeCode = $("#ctl00_ContentPlaceHolder1_ddlJobType").val(); //("ddlJobType option:selected").text();
        CorrectJobType(company, hrLocation, locationAutoId, employeeNumber, CorrectionDate, OldCorrectionDate, newJobTypeCode, oldJobTypeCode, 'JobType');
        $("#ctl00_ContentPlaceHolder1_CBJobType").is(':checked') == false;
    }

    if ($("#ctl00_ContentPlaceHolder1_CBJobClass").is(':checked') == true) {
        var OldCorrectionDate = $("#ctl00_ContentPlaceHolder1_HFEffectiveFromJobClass").val();
        var CorrectionDate = $("#ctl00_ContentPlaceHolder1_txtEffectiveFromJobClass").val();
        var oldJobClassCode = $("#ctl00_ContentPlaceHolder1_hfJobClassCode").val();
        var newJobClassCode = $("#ctl00_ContentPlaceHolder1_ddlJobClass").val(); //("ddlJobClass option:selected").text();
        CorrectJobClass(company, hrLocation, locationAutoId, employeeNumber, CorrectionDate, OldCorrectionDate, newJobClassCode, oldJobClassCode, 'JobClass');
        $("#ctl00_ContentPlaceHolder1_CBJobClass").is(':checked') == false;
    }

    if ($("#ctl00_ContentPlaceHolder1_CBRole").is(':checked') == true) {
        var OldCorrectionDate = $("#ctl00_ContentPlaceHolder1_HFEffectiveFromRole").val();
        var CorrectionDate = $("#ctl00_ContentPlaceHolder1_txtEffectiveFromRole").val();
        var oldRoleCode = $("#ctl00_ContentPlaceHolder1_hfRoleCode").val();
        var newRoleCode = $("#ctl00_ContentPlaceHolder1_ddlRole").val(); //("ddlRole option:selected").text();
        CorrectRole(company, hrLocation, locationAutoId, employeeNumber, CorrectionDate, OldCorrectionDate, newRoleCode, oldRoleCode, 'Role');
        $("#ctl00_ContentPlaceHolder1_CBRole").is(':checked') == false;
    }
    if ($("#ctl00_ContentPlaceHolder1_CBAreaID").is(':checked') == true) {
        var OldCorrectionDate = $("#ctl00_ContentPlaceHolder1_HFEffectiveFromArea").val();
        var CorrectionDate = $("#ctl00_ContentPlaceHolder1_txtEffectiveFromAreaID").val();
        var oldAreaCode = $("#ctl00_ContentPlaceHolder1_hfAreaID").val();
        var newAreaCode = $("#ctl00_ContentPlaceHolder1_ddlAreaID").val(); //("ddlAreaID option:selected").text();
        CorrectAreaID(company, hrLocation, locationAutoId, employeeNumber, CorrectionDate, OldCorrectionDate, newAreaCode, oldAreaCode, 'AreaID');
        $("#ctl00_ContentPlaceHolder1_CBAreaID").is(':checked') == false
    }
}

function ShowEmployeeHistroyMessage(strMessage) {
        var arr = new Array;
        arr = strMessage.split(",");
        var strMsg = arr[1] + "\n";
        strMsg = strMsg + arr[2] + "\n";
        strMsg = strMsg + arr[3] + "\n";
        strMsg = strMsg + arr[4] + "\n";
        strMsg = strMsg + arr[5] + "\n";
        strMsg = strMsg + arr[6] + "\n";
        strMsg = strMsg + arr[7] + "\n";
        strMsg = strMsg + arr[8] + "\n";
        strMsg = strMsg + arr[9] + "\n";
        strMsg = strMsg + "\n";
        alert(strMsg);
        location.reload(true);
    }


    function CorrectDesignation(strCompany, strHrLocation, locationAutoId, strEmployeeNumber, strCorrectionDate, strOldCorrectionDate, strNewCode, strOldCode, strCorrectionField) {

        var url = "CorrectEmployeeDetailsAjax.aspx";
        url = url + "?EmployeeNumber=" + strEmployeeNumber;
        url = url + "&Company=" + strCompany;
        url = url + "&HrLocation=" + strHrLocation;
        url = url + "&LocationAutoID=" + locationAutoId;
        url = url + "&CorrectionDate=" + encodeURIComponent(strCorrectionDate);
        url = url + "&OldCorrectionDate=" + encodeURIComponent(strOldCorrectionDate);
        url = url + "&NewCode=" + strNewCode;
        url = url + "&OldCode=" + strOldCode;
        url = url + "&CorrectionField=" + strCorrectionField;
        url = url + "&CompanyCheckStatus=" + 0;
        Request(url);
    }

    function CorrectCategory(strCompany, strHrLocation, locationAutoId, strEmployeeNumber, strCorrectionDate, strOldCorrectionDate, strNewCode, strOldCode, strCorrectionField) {

        var url = "CorrectEmployeeDetailsAjax.aspx";
        url = url + "?EmployeeNumber=" + strEmployeeNumber;
        url = url + "&Company=" + strCompany;
        url = url + "&HrLocation=" + strHrLocation;
        url = url + "&LocationAutoID=" + locationAutoId;
        url = url + "&CorrectionDate=" + encodeURIComponent(strCorrectionDate);
        url = url + "&OldCorrectionDate=" + encodeURIComponent(strOldCorrectionDate);
        url = url + "&NewCode=" + strNewCode;
        url = url + "&OldCode=" + strOldCode;
        url = url + "&CorrectionField=" + strCorrectionField;
        url = url + "&CompanyCheckStatus=" + 0;
        Request(url);
    }

    function CorrectDepartment(strCompany, strHrLocation, locationAutoId, strEmployeeNumber, strCorrectionDate, strOldCorrectionDate, strNewCode, strOldCode, strCorrectionField) {
        var url = "CorrectEmployeeDetailsAjax.aspx";
        url = url + "?EmployeeNumber=" + strEmployeeNumber;
        url = url + "&Company=" + strCompany;
        url = url + "&HrLocation=" + strHrLocation;
        url = url + "&LocationAutoID=" + locationAutoId;
        url = url + "&CorrectionDate=" + encodeURIComponent(strCorrectionDate);
        url = url + "&OldCorrectionDate=" + encodeURIComponent(strOldCorrectionDate);
        url = url + "&NewCode=" + strNewCode;
        url = url + "&OldCode=" + strOldCode;
        url = url + "&CorrectionField=" + strCorrectionField;
        url = url + "&CompanyCheckStatus=" + 0;
        Request(url);
    }

    function CorrectJobType(strCompany, strHrLocation, locationAutoId, strEmployeeNumber, strCorrectionDate, strOldCorrectionDate, strNewCode, strOldCode, strCorrectionField) {

        var url = "CorrectEmployeeDetailsAjax.aspx";
        url = url + "?EmployeeNumber=" + strEmployeeNumber;
        url = url + "&Company=" + strCompany;
        url = url + "&HrLocation=" + strHrLocation;
        url = url + "&LocationAutoID=" + locationAutoId;
        url = url + "&CorrectionDate=" + encodeURIComponent(strCorrectionDate);
        url = url + "&OldCorrectionDate=" + encodeURIComponent(strOldCorrectionDate);
        url = url + "&NewCode=" + strNewCode;
        url = url + "&OldCode=" + strOldCode;
        url = url + "&CorrectionField=" + strCorrectionField;
        url = url + "&CompanyCheckStatus=" + 0;
        Request(url);
    }

    function CorrectJobClass(strCompany, strHrLocation, locationAutoId, strEmployeeNumber, strCorrectionDate, strOldCorrectionDate, strNewCode, strOldCode, strCorrectionField) {

        var url = "CorrectEmployeeDetailsAjax.aspx";
        url = url + "?EmployeeNumber=" + strEmployeeNumber;
        url = url + "&Company=" + strCompany;
        url = url + "&HrLocation=" + strHrLocation;
        url = url + "&LocationAutoID=" + locationAutoId;
        url = url + "&CorrectionDate=" + encodeURIComponent(strCorrectionDate);
        url = url + "&OldCorrectionDate=" + encodeURIComponent(strOldCorrectionDate);
        url = url + "&NewCode=" + strNewCode;
        url = url + "&OldCode=" + strOldCode;
        url = url + "&CorrectionField=" + strCorrectionField;
        url = url + "&CompanyCheckStatus=" + 0;
        Request(url);
    }

    function CorrectRole(strCompany, strHrLocation, locationAutoId, strEmployeeNumber, strCorrectionDate, strOldCorrectionDate, strNewCode, strOldCode, strCorrectionField) {
        var url = "CorrectEmployeeDetailsAjax.aspx";
        url = url + "?EmployeeNumber=" + strEmployeeNumber;
        url = url + "&Company=" + strCompany;
        url = url + "&HrLocation=" + strHrLocation;
        url = url + "&LocationAutoID=" + locationAutoId;
        url = url + "&CorrectionDate=" + encodeURIComponent(strCorrectionDate);
        url = url + "&OldCorrectionDate=" + encodeURIComponent(strOldCorrectionDate);
        url = url + "&NewCode=" + strNewCode;
        url = url + "&OldCode=" + strOldCode;
        url = url + "&CorrectionField=" + strCorrectionField;
        url = url + "&CompanyCheckStatus=" + 0;
        Request(url);
    }

    function CorrectAreaID(strCompany, strHrLocation, locationAutoId, strEmployeeNumber, strCorrectionDate, strOldCorrectionDate, strNewCode, strOldCode, strCorrectionField) {

        var url = "CorrectEmployeeDetailsAjax.aspx";
        url = url + "?EmployeeNumber=" + strEmployeeNumber;
        url = url + "&Company=" + strCompany;
        url = url + "&HrLocation=" + strHrLocation;
        url = url + "&LocationAutoID=" + locationAutoId;
        url = url + "&CorrectionDate=" + encodeURIComponent(strCorrectionDate);
        url = url + "&OldCorrectionDate=" + encodeURIComponent(strOldCorrectionDate);
        url = url + "&NewCode=" + strNewCode;
        url = url + "&OldCode=" + strOldCode;
        url = url + "&CorrectionField=" + strCorrectionField;
        url = url + "&CompanyCheckStatus=" + 0;
        Request(url);
    }

    function CorrectCompany(employeeNumber, oldCompanyCode, newCompanyCode, oldCompanyCorrectionDate, newCorrectionDate, oldHrLocationCode, newHrLocation, oldLocationAutoId, newLocationAutoId, oldDesignationCode, newDesinationCode, oldCategoryCode, newCategoryCode, oldDepartmentCode, newDepartmentCode, oldJobTypeCode, newJobTypeCode, oldJobClassCode, newJobClassCode, oldRoleCode, newRoleCode, oldAreaCode, newAreaCode) {
        var url = "CorrectEmployeeDetailsAjax.aspx";
        url = url + "?OldCompanyCode=" + oldCompanyCode;
        url = url + "&NewCompanyCode=" + newCompanyCode;
        url = url + "&OldCompanyCorrectionDate=" + encodeURIComponent(oldCompanyCorrectionDate);
        url = url + "&NewCorrectionDate=" + encodeURIComponent(newCorrectionDate);
        url = url + "&OldHrLocationCode=" + oldHrLocationCode;
        url = url + "&NewHrLocation=" + newHrLocation;
        url = url + "&OldLocationAutoID=" + oldLocationAutoId;
        url = url + "&NewLocationAutoID=" + newLocationAutoId;
        url = url + "&OldDesignationCode=" + oldDesignationCode;
        url = url + "&NewDesinationCode=" + newDesinationCode;
        url = url + "&OldCategoryCode=" + oldCategoryCode;
        url = url + "&NewCategoryCode=" + newCategoryCode;
        url = url + "&OldJobTypeCode=" + oldJobTypeCode;
        url = url + "&NewJobTypeCode=" + newJobTypeCode;
        url = url + "&OldJobClassCode=" + oldJobClassCode;
        url = url + "&NewJobClassCode=" + newJobClassCode;
        url = url + "&OldDepartmentCode=" + oldDepartmentCode;
        url = url + "&NewDepartmentCode=" + newDepartmentCode;
        url = url + "&OldRoleCode=" + oldRoleCode;
        url = url + "&NewRoleCode=" + newRoleCode;
        url = url + "&OldAreaCode=" + oldAreaCode;
        url = url + "&NewAreaCode=" + newAreaCode;
        url = url + "&EmployeeNumber=" + employeeNumber;
        url = url + "&CompanyCheckStatus=" + 1;
        Request(url);
    }

    function Request(url) {
        var httpRequest;
        if (window.XMLHttpRequest) { // Mozilla, Safari, ...
            httpRequest = new XMLHttpRequest();
        } else if (window.ActiveXObject) { // IE
            httpRequest = new ActiveXObject("Microsoft.XMLHTTP");
        } else {
            return false;
        }
        var readyStateChange = function () {
            if (httpRequest.readyState == 4) {
                ShowMessage(httpRequest.responseText);
            }
        };

        if (navigator.appName == 'Microsoft Internet Explorer') {
            httpRequest.onreadystatechange = readyStateChange;

        } else {
            httpRequest.onload = readyStateChange;
        }
        httpRequest.open('GET', url, true);
        httpRequest.send(null);
    }