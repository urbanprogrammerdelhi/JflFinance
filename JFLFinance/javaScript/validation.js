// JScript File
// handle enter,tab,space on key press
function TextBox_onkeyDown(strTextBoxID) {
    if (window.event.keyCode == 13 || window.event.keyCode == 32 || window.event.keyCode == 9) {
        __doPostBack(strTextBoxID, '');
        return false;
    }
}

//*******************Validate Given Object String With Given Expression
function validateStringWithExpression(Obj, strExpression) {
    var mikExp = strExpression;
    var strPass = Obj.value;
    var strLength = strPass.length;
    var lchar = Obj.value.charAt((strLength) - 1);
    for (var i = 0; i <= strLength - 1; i++) {
        lchar = Obj.value.charAt(i);
        if (lchar.search(mikExp) == -1) {
            Obj.value = "" + (strPass.substring(0, i) + strPass.substring((i + 1), strPass.length));
            i--;
        }

        strPass = Obj.value;
        strLength = strPass.length;
    }
}
//********************Validate Numeric Data
function validateNumeric(val) {
    var mikExp = /[0-9]/;
    var strPass = document.getElementById(val).value;
    var strLength = strPass.length;
    var lchar = document.getElementById(val).value.charAt((strLength) - 1);
    for (var i = 0; i <= strLength - 1; i++) {
        lchar = document.getElementById(val).value.charAt(i);
        if (lchar.search(mikExp) == -1) {
            document.getElementById(val).value = "" + (strPass.substring(0, i) + strPass.substring((i + 1), strPass.length));
            i--;
        }
        strPass = document.getElementById(val).value;
        strLength = strPass.length;
    }
   
}
//****************Validation String data
function validateString(val) {
    var mikExp = /[a-z\A-Z0-9\ \,\.\_]/;
    var strPass = val.value;
    var strLength = strPass.length;
    var lchar = val.value.charAt((strLength) - 1);
    for (var i = 0; i <= strLength - 1; i++) {
        lchar = val.value.charAt(i);
        if (lchar.search(mikExp) == -1) {
            val.value = "" + (strPass.substring(0, i) + strPass.substring((i + 1), strPass.length));
            i--;
        }
        strPass = val.value;
        strLength = strPass.length;
    } 
}
//****************Validation Code String data
function validateCode(val) {
    var mikExp = /[a-z\A-Z0-9\-\_]/;
    var strPass = val.value;
    var strLength = strPass.length;
    var lchar = val.value.charAt((strLength) - 1);
    for (var i = 0; i <= strLength - 1; i++) {
        lchar = val.value.charAt(i);
        if (lchar.search(mikExp) == -1) {
            val.value = "" + (strPass.substring(0, i) + strPass.substring((i + 1), strPass.length));
            i--;
        }
        strPass = val.value;
        strLength = strPass.length;
    }
}
//***************************************************
function calendarPicker(strTxtRef) {
    window.open('../Calender/Calender.aspx?field=' + strTxtRef + '', 'calendarPopup', 'titlebar=no,left=470,top=100,width=240,height=230,resizable=no');
}
//******************************************************
function expandSection(id) {
    var mySection = document.getElementById(id);
    if (mySection.style.display == "none") {
        mySection.style.display = "block";
        /*    mySection.parentElement.style.width = "800";*/
    }
    else {
        mySection.style.display = "none";
        /*	mySection.parentElement.style.width = "200";*/
    }
}

function validateFloat(val) {
    var mikExp = /[0-9\.]/;
    var strPass = document.getElementById(val).value;
    var strLength = strPass.length;
    var lchar = document.getElementById(val).value.charAt((strLength) - 1);
    for (var i = 0; i <= strLength - 1; i++) {
        lchar = document.getElementById(val).value.charAt(i);
        if (lchar.search(mikExp) == -1) {
            document.getElementById(val).value = "" + (strPass.substring(0, i) + strPass.substring((i + 1), strPass.length));
            i--;
        }
        strPass = document.getElementById(val).value;
        strLength = strPass.length;
    }
}
/* function to hide label after X interval*/
function Timerf(strControlID) {
    var t = setTimeout("HideCtrls('" + strControlID + "')", 6000);
}
function HideCtrls(strControlID) {
    //alert(document.getElementById(strControlID).innerText);
    document.getElementById(strControlID).innerText = '';
    document.getElementById(strControlID).style.display = 'none';

}
//------------------------------------------------------   
function showhideDiv(imgobj, objid) {
    var obj = document.getElementById(objid);
    if (obj != null) {
        var expand = (obj.style.display == "none");
        if (expand) {
            obj.style.display = "block";
        }
        else {
            obj.style.display = "none";
        }
    }
    var expand1 = (imgobj.src.indexOf("expand.gif") > 0);
    imgobj.src = imgobj.src
        .split(expand1 ? "expand.gif" : "collapse.gif")
        .join(expand1 ? "collapse.gif" : "expand.gif");
}
/*------------------------------------------------*/

// not animated collapse/expand
function togglePannelStatus(content) {
    var expand = (content.style.display == "none");
    content.style.display = (expand ? "block" : "none");
    toggleChevronIcon(content);
}

// current animated collapsible panel content
var currentContent = null;

function togglePannelAnimatedStatus(content, interval, step) {
    // wait for another animated expand/collapse action to end
    if (currentContent == null) {
        currentContent = content;
        var expand = (content.style.display == "none");
        if (expand)
            content.style.display = "block";
        var max_height = content.offsetHeight;

        var step_height = step + (expand ? 0 : -max_height);
        toggleChevronIcon(content);

        // schedule first animated collapse/expand event
        content.style.height = Math.abs(step_height) + "px";
        setTimeout("togglePannelAnimatingStatus("
            + interval + "," + step
            + "," + max_height + "," + step_height + ")", interval);
    }
}

//Div Functions
function togglePannelAnimatingStatus(interval, step, max_height, step_height) {
    var step_height_abs = Math.abs(step_height);

    // schedule next animated collapse/expand event
    if (step_height_abs >= step && step_height_abs <= (max_height - step)) {
        step_height += step;
        currentContent.style.height = Math.abs(step_height) + "px";
        setTimeout("togglePannelAnimatingStatus("
            + interval + "," + step
            + "," + max_height + "," + step_height + ")", interval);
    }
    // animated expand/collapse done
    else {
        if (step_height_abs < step)
            currentContent.style.display = "none";
        currentContent.style.height = "";
        currentContent = null;
    }
}

// change chevron icon into either collapse or expand
function toggleChevronIcon(content) {
    var chevron = content.parentNode
        .firstChild.childNodes[1].childNodes[0];
    var expand = (chevron.src.indexOf("expand.gif") > 0);
    chevron.src = chevron.src
        .split(expand ? "expand.gif" : "collapse.gif")
        .join(expand ? "collapse.gif" : "expand.gif");
}



function skm_LockScreen(str) {
    scroll(0, 0);
    var back = document.getElementById('skm_LockBackground');
    var pane = document.getElementById('skm_LockPane');
    var text = document.getElementById('skm_LockPaneText');

    if (back)
        back.className = 'LockBackground';
    if (pane)
        pane.className = 'LockPane';
    if (text)
        text.innerHTML = str;
}


/// **************** function added by  on 12-jan-2010 *******************************

function GetPayperiodDates(intMonth, intYear, intStartDay, intEndDay) {
    var strFromDate = "";
    var strToDate = "";

    if (intStartDay == intEndDay) {
        alert("invalid PayPeriod Date!");
    }


    var EndDate, strMonth, strPrvMonth;
    if (intMonth == 1)
    { EndDate = "31"; strMonth = "Jan"; strPrvMonth = "Dec"; }
    else if (intMonth == 2) {
        strMonth = "Feb"; strPrvMonth = "Jan";
        if (intYear % 4 == 0)
            EndDate = "29";
        else
            EndDate = "28";
    }
    else if (intMonth == 3)
    { EndDate = "31"; strMonth = "Mar"; strPrvMonth = "Feb"; }
    else if (intMonth == 4)
    { EndDate = "30"; strMonth = "Apr"; strPrvMonth = "Mar"; }
    else if (intMonth == 5)
    { EndDate = "31"; strMonth = "May"; strPrvMonth = "Apr"; }
    else if (intMonth == 6)
    { EndDate = "30"; strMonth = "Jun"; strPrvMonth = "May"; }
    else if (intMonth == 7)
    { EndDate = "31"; strMonth = "Jul"; strPrvMonth = "Jun"; }
    else if (intMonth == 8)
    { EndDate = "31"; strMonth = "Aug"; strPrvMonth = "Jul"; }
    else if (intMonth == 9)
    { EndDate = "30"; strMonth = "Sep"; strPrvMonth = "Aug"; }
    else if (intMonth == 10)
    { EndDate = "31"; strMonth = "Oct"; strPrvMonth = "Sep"; }
    else if (intMonth == 11)
    { EndDate = "30"; strMonth = "Nov"; strPrvMonth = "Oct"; }
    else if (intMonth == 12)
    { EndDate = "31"; strMonth = "Dec"; strPrvMonth = "Nov"; }



    if (intStartDay > 1 && intStartDay > intEndDay) {
        if (intMonth != 1) {
            strFromDate = intStartDay + "-" + strPrvMonth + "-" + intYear;
        }
        else {
            strFromDate = intStartDay + "-" + strPrvMonth + "-" + (intYear - 1);
        }
        strToDate = intEndDay + "-" + strMonth + "-" + intYear;
    }
    else if (intStartDay < intEndDay) {
        strFromDate = intStartDay + "-" + strMonth + "-" + intYear;
        if (intEndDay < 30 && intStartDay != 1) {
            strToDate = intEndDay + "-" + strMonth + "-" + intYear;
        }
        else {
            strToDate = EndDate + "-" + strMonth + "-" + intYear;
        }
    }

    return (strFromDate + "$" + strToDate);
}


function PageTitle(str) {
   // parent.document.getElementById('IfrmLabel').innerText = str;
}

//// ****************** end function *******************************************************