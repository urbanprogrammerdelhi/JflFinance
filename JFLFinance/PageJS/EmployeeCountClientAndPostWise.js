//$(document).ready(OnLoad());
function OnLoad() {
    $(document).ready(function () {
        var a = new window.ControlInitializer();
        GetEmployeeCountClientWiseAndpostWise();
    });
}

function OnWSRequestFailed(error) {
    alert(error);
}
function OnGetEmployeeCountClientAndPostWiseComplete(result) {
    var a = new window.ControlInitializer();
    a.spanEmployeeCount.innerHTML = '';
                        var res1 = result;
                        var xmlDocDate = new ActiveXObject("Microsoft.XMLDOM");
                        xmlDocDate.async = "false";
                        xmlDocDate.loadXML(res1);
                        var nodesDate = xmlDocDate.selectSingleNode("NewDataSet");
                        var asmtcDate = nodesDate.selectNodes("Table");

                        var xmlDocCount = new ActiveXObject("Microsoft.XMLDOM");
                        xmlDocCount.async = "false";
                        xmlDocCount.loadXML(res1);
                        var nodesCount = xmlDocCount.selectSingleNode("NewDataSet");
                        var asmtcCount = nodesCount.selectNodes("Table");
                        // 
                        var l = 0;
                        var strTable;
                        strTable = "<table border='1' cellpadding=0 cellspacing=0 style='font-size:11px; border-color:grey' > ";
                        strTable = strTable + "<tr style='background-color:#B7CEEC' >";
                        for (var myasmt = asmtcDate.nextNode(); myasmt; myasmt = asmtcDate.nextNode()) {
                            if (l == '0') {
                                strTable = strTable + "<td>" + a.DateRange + "</td><td align='center'>";
                            }
                            else {
                                strTable = strTable + "<td align='center'>";
                            }
                            strTable = strTable + xmlDocDate.getElementsByTagName("DutyDate")[l].firstChild.nodeValue + "</td>";
                            l++;
                        }

                        l = 0;
                        strTable = strTable + "<tr>";
                        for (var myasmt = asmtcCount.nextNode(); myasmt; myasmt = asmtcCount.nextNode()) {
                            if (l == '0') {
                                strTable = strTable + "<td>" + a.Total + "</td><td align='center' style='font-weight'>";
                            }
                            else {
                                strTable = strTable + "<td align='center' style='font-weight'>";
                            }
                            strTable = strTable + "<table border='0' cellpadding=0 cellspacing=0 style='font-size:11px; border-color:grey' > ";
                            strTable = strTable + "<tr>";
                            strTable = strTable + "<td  style='background-color:Yellow' >" + "Customer Total" + "</td><td style='background-color:Orange' >" + "Post Total" + "</td>";

                            strTable = strTable + "</tr>";
                            strTable = strTable + "<tr>";
                            strTable = strTable + "<td style='background-color:Yellow' >" + xmlDocCount.getElementsByTagName("TotalEmployeeCountClientWise")[l].firstChild.nodeValue + "</td><td style='background-color:Orange'>" + xmlDocCount.getElementsByTagName("TotalEmployeeCountPostWise")[l].firstChild.nodeValue + "</td>";
                            strTable = strTable + "</tr>";
                            strTable = strTable + "</table>";
                            strTable = strTable + "</td>";
                            //  strTable = strTable + xmlDocCount.getElementsByTagName("ClientPostTotal")[l].firstChild.nodeValue + "</td>";
                            l++;
                        }
                        strTable = strTable + "</tr>";
                        strTable = strTable + "</table>";
                        document.getElementById('spanEmployeeCount').innerHTML = strTable;
                    
}
function GetEmployeeCountClientAndPostWise() {
    var a = new window.ControlInitializer();
    if (a.HFAsmtCode.value !== "" && a.HFPost.value !== "") {
        //var a = new window.ControlInitializer();
        window.WebMethods.GetEmployeeCountClientAndPostWise(
            (a.HFConnectionString).value,
            (a.HFCompanyCode).value,
            (a.HFHrLocationCode).value,
            (a.HFLocationCode).value,
            (a.HFAttendanceType).value,
            (a.HFPost).value,
            (a.HFFromDate).value,
            (a.HFToDate).value,
            (a.HFAsmtCode).value,
            (a.HFClientCode).value, OnGetEmployeeCountClientAndPostWiseComplete, OnWSRequestFailed)
    }
}
function OnGetEmployeeCountClientWiseAndpostWiseComplete(result) {
    var a = new window.ControlInitializer();
    a.spanShowEmployeeCountClientAndPostWise.innerHTML = '';
    var res1 = result;
    var xmlDocDate = new ActiveXObject("Microsoft.XMLDOM");
    xmlDocDate.async = "false";
    xmlDocDate.loadXML(res1);
    var nodesDate = xmlDocDate.selectSingleNode("NewDataSet");
    var asmtcDate = nodesDate.selectNodes("Table");

    var xmlDocCount = new ActiveXObject("Microsoft.XMLDOM");
    xmlDocCount.async = "false";
    xmlDocCount.loadXML(res1);
    var nodesCount = xmlDocCount.selectSingleNode("NewDataSet");
    var asmtcCount = nodesCount.selectNodes("Table");
    var l = 0;
    var strTable;
    strTable = "<table border='1' cellpadding=0 cellspacing=0 style='font-size:11px; border-color:grey' > ";
    strTable = strTable + "<tr style='background-color:#B7CEEC' >";
    for (var myasmt = asmtcDate.nextNode(); myasmt; myasmt = asmtcDate.nextNode()) {
        if (l == '0') {
            strTable = strTable + "<td>" + a.DateRange + "</td><td align='center'>";
        }
        else {
            strTable = strTable + "<td align='center'>";
        }
        strTable = strTable + xmlDocDate.getElementsByTagName("DutyDate")[l].firstChild.nodeValue + "</td>";
        l++;
    }

    l = 0;
    strTable = strTable + "<tr>";
    for (var myasmt = asmtcCount.nextNode(); myasmt; myasmt = asmtcCount.nextNode()) {
        if (l == '0') {
            strTable = strTable + "<td>" + a.Total + "</td><td align='center' style='font-weight'>";
        }
        else {
            strTable = strTable + "<td align='center' style='font-weight'>";
        }
        strTable = strTable + "<table border='0' cellpadding=0 cellspacing=0 style='font-size:11px; border-color:grey' > ";
        strTable = strTable + "<tr>";
        if (a.HFAttendanceType.value == "Sch") {


            strTable = strTable + "<td  style='background-color:Yellow' >" + "Required" + "</td><td style='background-color:Orange' >" + "Scheduled" + "</td>";
        }
        else {

            strTable = strTable + "<td  style='background-color:Yellow' >" + "Required" + "</td><td style='background-color:Orange' >" + "Actual" + "</td>";
        }
        strTable = strTable + "</tr>";
        strTable = strTable + "<tr>";
        strTable = strTable + "<td style='background-color:Yellow' >" + xmlDocCount.getElementsByTagName("ClientTotal")[l].firstChild.nodeValue + "</td><td style='background-color:Orange'>" + xmlDocCount.getElementsByTagName("PostTotal")[l].firstChild.nodeValue + "</td>";
        strTable = strTable + "</tr>";
        strTable = strTable + "</table>";
        strTable = strTable + "</td>";
        l++;
    }
    strTable = strTable + "</tr>";
    strTable = strTable + "</table>";
     a.spanShowEmployeeCountClientAndPostWise.innerHTML = strTable;
        GetEmployeeCountClientAndPostWise();
}

function GetEmployeeCountClientWiseAndpostWise() {
    $(document).ready(function () {
        var a = new window.ControlInitializer();
        if (a.HFAsmtCode.value !== "" && a.HFPost.value !== "") {
            callwebservice();

        }
    });
}
function callwebservice() {

    $(document).ready(function () {
        var a = new window.ControlInitializer();
        window.WebMethods.GetEmployeeCountClientWiseAndpostWise(
          (a.HFConnectionString).value,
            (a.HFCompanyCode).value,
            (a.HFHrLocationCode).value,
            (a.HFLocationCode).value,
            (a.HFAttendanceType).value,
            (a.HFPost).value,
            (a.HFFromDate).value,
            (a.HFToDate).value,
            (a.HFAsmtCode).value,
            (a.HFClientCode).value, OnGetEmployeeCountClientWiseAndpostWiseComplete, OnWSRequestFailed)
    });
}