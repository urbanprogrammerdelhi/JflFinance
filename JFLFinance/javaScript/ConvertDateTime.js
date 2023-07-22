// JScript File
//
function Timevalnum(id)
{
	var mikExp = /[0-9:]/;
	var strPass = document.getElementById(id).value;
	var strLength = strPass.length;
	var lchar = document.getElementById(id).value.charAt((strLength) - 1);
	for (var i=0; i<= strLength-1; i++)
	{
		lchar = document.getElementById(id).value.charAt(i);
		if(lchar.search(mikExp) == -1)
		{
		document.getElementById(id).value = "" + (strPass.substring(0, i) + strPass.substring((i+1), strPass.length));
		i--;
		}
	strPass = document.getElementById(id).value;
	strLength = strPass.length;
	}
	if(document.getElementById(id).value.length > 2 && document.getElementById(id).value.charAt(2) != ":")
	{
		if(document.getElementById(id).value.length >= 4)
		{
			document.getElementById(id).value = document.getElementById(id).value.substring(0, 2) + ":" + document.getElementById(id).value.substring(2,4);
		}
		else
		{
			document.getElementById(id).value = document.getElementById(id).value.substring(0, 2) + ":" + document.getElementById(id).value.substring(2,3);
		}
	}
}

function validateWeek(id)
{
	var mikExp = /[1-5]/;
	var strPass = document.getElementById(id).value;
	var strLength = strPass.length;
	var lchar = document.getElementById(id).value.charAt((strLength) - 1);
	var mchar
	for (var i=0; i<= strLength-1; i++)
	{
		lchar = document.getElementById(id).value.charAt(i);
		if(lchar.search(mikExp) == -1)
		{
		document.getElementById(id).value = "" + (strPass.substring(0, i) + strPass.substring((i+1), strPass.length));
		i--;
		}
	strPass = document.getElementById(id).value;
	strLength = strPass.length;
	}

	for (var j=0; j<= strLength-1; j++)
	{
		lchar = document.getElementById(id).value.charAt(j);
		for (var k=0; k<= strLength-1; k++)
		{
			mchar = document.getElementById(id).value.charAt(k);
			if(k != j)
			{
				if(lchar == mchar)
				{
					document.getElementById(id).value = "" + (strPass.substring(0, k) + strPass.substring((k+1), strPass.length));
					k--;
					j--;
				}
			}
		}
	strPass = document.getElementById(id).value;
	strLength = strPass.length;
	}
}

function IsValidTime(id)
{
	// Checks if time is in HH:MM format.
	var timeStr = document.getElementById(id).value;

	if (timeStr.length == 4 && document.getElementById(id).value.charAt(2) != ":" && document.getElementById(id).value.charAt(3) != ":") {
	    document.getElementById(id).value = timeStr.substring(0, 2) + ":" + timeStr.substring(2, 4);
	    timeStr = timeStr.substring(0, 2) + ":" + timeStr.substring(2, 4);
	}

	if (document.getElementById(id).value.charAt(1) != ":" && document.getElementById(id).value.charAt(2) != ":") {
	    if (timeStr.length == 1) {
	        timeStr = "0" + timeStr + ":00";
	        document.getElementById(id).value = timeStr;
	    }
	    if (timeStr.length == 2 && document.getElementById(id).value < 24) {
	        timeStr = timeStr + ":00";
	        document.getElementById(id).value = timeStr;
	    }

	}
	
	
	//var timePat = /^([0-1][0-9]|[0-2][0-3]):([0-5][0-9])$/;
	var timePat = /^(\d{2}):(\d{2})$/;
	if (document.getElementById(id).value != "")
	{
	var matchArray = timeStr.match(timePat);
	if (matchArray == null)
	{
		alert("Time is not in a valid format.");
		globalObj = document.getElementById(id);
		setTimeout("javascript:globalObj.focus();javascript:globalObj.select();",100);
		document.getElementById(id).value = "";
		return false;
	}
	hour = matchArray[1];
	minute = matchArray[2];

	if (hour < 0  || hour > 23)
	{
		alert("Hour must be between (0 to 23)");
		globalObj = document.getElementById(id);
		setTimeout("javascript:globalObj.focus();javascript:globalObj.select();",100);
		document.getElementById(id).value = "";
		return false;
	}
	if (minute<0 || minute > 59)
	{
		alert ("Minute must be between 0 to 59.");
		globalObj = document.getElementById(id);
		setTimeout("javascript:globalObj.focus();javascript:globalObj.select();",100);
		document.getElementById(id).value = "";
		return false;
	}
	return true;
	}
	return false;
}

//To get the Diffrence of FromTime (HH:MM) and EndTime (HH:MM) in Minutes
function GetTimeDiffInMin(FromTimeId, EndTimeId, ResultDiffrenceId)
{
    if(IsValidTime(FromTimeId) != false && IsValidTime(EndTimeId) != false)
    {
        var strFromTime = document.getElementById(FromTimeId).value;
        var strEndTime = document.getElementById(EndTimeId).value;
        var TimeFormat = 'dd-NNN-yyyy HH:mm';
        var tmpFT = '01-Jan-2009 '+ strFromTime;
        var tmpET = '01-Jan-2009 '+ strEndTime;
        //********  compareTwoDates ****************
        //  -1 if either of the dates is in an invalid format
        //   1 if date1 is greater than date2
        //   2 if date2 is greater than date1
        //   0 if date2 is equal to date1
        if(compareTwoDates(tmpFT, TimeFormat, tmpET, TimeFormat) == -1)
        {alert("-1 if either of the dates is in an invalid format");}
        else if(compareTwoDates(tmpFT, TimeFormat, tmpET, TimeFormat) == 0 || compareTwoDates(tmpFT, TimeFormat, tmpET, TimeFormat) == 1)
        {//Date(year,month,day,hour,minutes,seconds)
            var dtFT = new Date(2009,01,01,strFromTime.substring(0,2),strFromTime.substring(3,5),00);
            var dtET = new Date(2009,01,02,strEndTime.substring(0,2),strEndTime.substring(3,5),00);
            var strminutes = Math.floor(Math.abs(dtET - dtFT) / (1000 * 60));
            document.getElementById(ResultDiffrenceId).value = strminutes;
        }
        else if(compareTwoDates(tmpFT, TimeFormat, tmpET, TimeFormat) == 2)
        {//Date(year,month,day,hour,minutes,seconds)
            var dtFT = new Date(2009,01,01,strFromTime.substring(0,2),strFromTime.substring(3,5),00);
            var dtET = new Date(2009,01,01,strEndTime.substring(0,2),strEndTime.substring(3,5),00);
            var strminutes = Math.floor(Math.abs(dtET.getTime() - dtFT.getTime()) / (1000 * 60));
            document.getElementById(ResultDiffrenceId).value = strminutes;
        }
    }
    else
    {document.getElementById(ResultDiffrenceId).value = "0";}
}