function SelectClient(ClientName, ddAssignmentId, txtAsmtCodeId, txtAsmtStartDateId, txtAsmtEndDateId, txtAdjFromDateId, txtAdjTodateId) {
    var ClCode = $("#" + ClientName).val();
    GetAsmtsAjax(ddAssignmentId, txtAsmtCodeId, txtAsmtStartDateId, txtAsmtEndDateId, ClCode, txtAdjFromDateId, txtAdjTodateId);

}
/*
function SelectAsmt(AsmtName, txtASmtCode) {
    document.getElementById(txtASmtCode).value = document.getElementById(AsmtName).value;

}

function getEmpName(Id, FromDate, ToDate) {
    //  var date1 = "1-"+ document.getElementById('<% =ddlMonth.ClientID %>').value + "-" + document.getElementById('<% =txtYear.ClientID %>').value;
    var str = GetEmpName(document.getElementById(Id).value, document.getElementById('<% =txtAsmtCode.ClientID %>').value, document.getElementById(FromDate).value, document.getElementById(ToDate).value);
}

function ShowEmpAjax(str) {
    var pos1 = 0;
    pos1 = str.substring(2, 200).indexOf(",");
    if (str.substring(2, pos1 + 2) == "Invalid") {
        alert(str.substring(2, 200));
        document.getElementById('<% =txtEmpNo.ClientID %>').focus();
        return false;
    }
    else {
        document.getElementById('<% =txtEmpname.ClientID %>').value = str.substring(2, pos1 + 2);
        document.getElementById('<% =txtHrs.ClientID %>').focus();
    }

}


function setDutyDate(ID, txtYearId, ddlMonthId) {

    var strDate = $("#" + ID).val();
    var DatePat = /^(\d{1,2})-(\w{3})-(\d{4})$/;
    var DayPat = /^(\d{1,2})$/;
    var leapYear = parseInt($("#"+ txtYearId).val()) % 4;
    var currentMonth = $("#"+ ddlMonthId).val().toUpperCase();
    if (strDate == "") {
        return false;
    }

    if (strDate.charAt(1) == "-")
    { var matchDayArray = strDate.substring(0, 1).match(DayPat); }
    else
    { var matchDayArray = strDate.substring(0, 2).match(DayPat); }


    if (matchDayArray == null) {
        alert("Invalid date Format! please enter 'dd-MMM-yyyy' format");
        $("#" + ID).focus();
        return false;
    }
    else if (currentMonth == "JAN" && strDate.substring(0, 2) > 31) {
        alert("Invalid Date! please enter correct Date!");
        $("#" + ID).focus();
        return false;
    }
    else if (currentMonth == "FEB" && leapYear != "0" && strDate.substring(0, 2) > 28) {
        alert("Invalid Date! please enter correct Date!");
        $("#" + ID).focus();
        return false;
    }
    else if (currentMonth == "FEB" && leapYear == "0" && strDate.substring(0, 2) > 29) {
        alert("Invalid Date! please enter correct Date!");
        $("#" + ID).focus();
        return false;
    }
    else if (currentMonth == "MAR" && strDate.substring(0, 2) > 31) {
        alert("Invalid Date! please enter correct Date!");
        $("#" + ID).focus();
        return false;
    }
    else if (currentMonth == "APR" && strDate.substring(0, 2) > 30) {
        alert("Invalid Date! please enter correct Date!");
        $("#" + ID).focus();
        return false;
    }
    else if (currentMonth == "MAY" && strDate.substring(0, 2) > 31) {
        alert("Invalid Date! please enter correct Date!");
        $("#" + ID).focus();
        return false;
    }
    else if (currentMonth == "JUN" && strDate.substring(0, 2) > 30) {
        alert("Invalid Date! please enter correct Date!");
        $("#" + ID).focus();
        return false;
    }
    else if (currentMonth == "JUL" && strDate.substring(0, 2) > 31) {
        alert("Invalid Date! please enter correct Date!");
        $("#" + ID).focus();
        return false;
    }
    else if (currentMonth == "AUG" && strDate.substring(0, 2) > 31) {
        alert("Invalid Date! please enter correct Date!");
        $("#" + ID).focus();
        return false;
    }
    else if (currentMonth == "SEP" && strDate.substring(0, 2) > 30) {
        alert("Invalid Date! please enter correct Date!");
        $("#" + ID).focus();
        return false;
    }
    else if (currentMonth == "OCT" && strDate.substring(0, 2) > 31) {
        alert("Invalid Date! please enter correct Date!");
        $("#" + ID).focus();
        return false;
    }
    else if (currentMonth == "NOV" && strDate.substring(0, 2) > 30) {
        alert("Invalid Date! please enter correct Date!");
        $("#" + ID).focus();
        return false;
    }
    else if (currentMonth == "DEC" && strDate.substring(0, 2) > 31) {
        alert("Invalid Date! please enter correct Date!");
        $("#" + ID).focus();
        return false;
    }



    if ($("#" + ID).val().length <= 2) {
        document.getElementById(ID).value = strDate + "-" + document.getElementById('<% =ddlMonth.ClientID %>').value + "-" + document.getElementById('<% =txtYear.ClientID %>').value;
    }
    else {

        var matchArray = strDate.match(DatePat);
        if (matchArray == null) {
            alert("Invalid date Format! please enter 'dd-MMM-yyyy' format");
            $("#" + ID).focus();
            return false;
        }
        // check month
        for (var i = 1; i <= strDate.length; i++) {

            if (strDate.charAt(i) == "-") {
                var varmonth = strDate.substring(i + 1, i + 4);
                if (varmonth.toUpperCase() == "JAN" || varmonth.toUpperCase() == "FEB" || varmonth.toUpperCase() == "MAR" || varmonth.toUpperCase() == "APR" || varmonth.toUpperCase() == "MAY" || varmonth.toUpperCase() == "JUN" || varmonth.toUpperCase() == "JUL" || varmonth.toUpperCase() == "AUG" || varmonth.toUpperCase() == "SEP" || varmonth == "Oct" || varmonth.toUpperCase() == "NOV" || varmonth.toUpperCase() == "DEC") {
                    document.getElementById('<% =ddlMonth.ClientID %>').value = varmonth;
                    i = i + 4;
                    while (i < strDate.length) {
                        if (strDate.charAt(i) == "-") {
                            document.getElementById('<% =txtYear.ClientID %>').value = strDate.substring(i + 1, i + 5); ;
                            i = strDate.length;
                        }
                        i = i + 1;
                    }

                    i = strDate.length;
                }
                else {
                    alert("Invalid Month! please enter correct month");
                    $("#" + ID).focus();
                    return false;
                }
            }

        }
    }
}
*/