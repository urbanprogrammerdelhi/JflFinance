// Create DIVs for each level of CSS POP-UP Window
document.write('<div id="jsHTML0"></div>')
document.write('<div id="jsHTML1"></div>')
document.write('<div id="jsHTML2"></div>')
document.write('<div id="jsHTML3"></div>')
document.write('<div id="jsHTML4"></div>')
var IE = document.all;
	
function openCSSPopupByName(fileName, fLeft, fTop, fwidth, fheight, wName, depth)
{
	if (!depth) 
	{ 
	    depth=0; 
	}
	jsDiv 	= wName + 'xCSS';
	jsFrame = wName + 'xFRM';
	// Create dynamic DIV
	
	createPopUpDiv(jsDiv, jsFrame, wName, depth, fileName);

	// Initialize DIV variables 
	var _pLayer=document.getElementById(jsDiv).style;
	var _pFrame=document.getElementById(jsFrame);
	if (_pLayer.display == "none") 
	{
		// Capture browser window size
		if (IE) {
			screenWidth = (document.body.clientWidth + 20);
			screenHeight = (document.body.clientHeight);
		} else {
			screenWidth = self.innerWidth;
			screenHeight= self.innerHeight;
		}
		// Evaluate left position for the current browser width
			if (fLeft != 0) {
				leftPos = fLeft;
			} else {
				leftPos = ((screenWidth/2) -  (fwidth/2));
			}
			if (fTop != 0) {
				topPos = fTop;
			} else {
				topPos  = ((screenHeight/2) - (fheight/2)-30); //30 value draws the display up
			}
		// Create opaque page background
			if(IE){
				document.getElementById('container').style.filter="Alpha(Opacity=10)";
			} else {
				document.getElementById('container').setAttribute("style","-moz-opacity:.1;");
			}
		// Draw pop-up DIV & call file in IFRAME
			_pLayer.left=leftPos+'px';
			_pLayer.top=topPos+'px';
			_pFrame.src=fileName;
			_pFrame.width=fwidth;
			_pFrame.height=fheight;
			_pLayer.display="block";
			document.getElementById('jsHTML'+depth).style.display='block';
			//document.location.href="#top";
	} else {
			if(IE)
				document.getElementById('container').style.filter="Alpha(Opacity=100)";
			else
				document.getElementById('container').setAttribute("style","-moz-opacity:1;"); 
			document.getElementById('jsHTML'+depth).innerHTML = '';
			document.getElementById('jsHTML'+depth).style.display='none';
			_pLayer.display="none";
	}
}

//-----------------------------End opening css window when open the window---------------


function createPopUpDiv(jsDiv, jsFrame, divName, depth, fName) 
{
	if (fName != "1")
	{   // File Name MUST be 1 to close the CSS Window 
	    popupHTML='<div id="' + jsDiv + '" style="position: absolute; border: 2px solid #0066CC; display: none; background-color: #0066CC; z-index:200;"> \
		<div style="background-color: #6699FF; text-align: right;"><a href=javascript:openCSSPopupByName(1,1,1,1,1,"'+ divName +'",'+ depth +'); style="color: #fff;"><img src="../images/Delete.gif" /></a></div>\
		<iframe name="' + jsFrame + '" id="' + jsFrame + '" frameborder="0" src="">Please wait...</iframe><br>\
		<div style="background-color: #6699FF; text-align: right;"><a href=javascript:openCSSPopupByName(1,1,1,1,1,"'+ divName +'",'+ depth +'); style="color: #fff;">Close</a></div>\
		</div>'
	    document.getElementById('jsHTML'+depth).innerHTML = popupHTML;
	}
}



function InvokePop(StrUrl,StrTitle,WinHeight,WinWidth)
{
        //val = document.getElementById(fname).value;
        // to handle in IE 7.0     
        if (window.showModalDialog) 
        {    
            windsize="dialogHeight:" + WinHeight + "px;dialogWidth:" + WinWidth + "px;resizable:yes;center:yes;"          
            retVal = window.showModalDialog(StrUrl ,StrTitle,windsize);
        } 
        // to handle in Firefox
        else 
        {     
            windsize='height=' + WinHeight + ',width=' + WinWidth + ',resizable=yes,modal=yes'
            retVal = window.open(StrUrl,StrTitle,windsize);
            retVal.focus();            
        }          
}

function ReverseString()
{
         var originalString = document.getElementById('txtReverse').value;
         var reversedString = Reverse(originalString);
         RetrieveControl();
         // to handle in IE 7.0
         if (window.showModalDialog)
         {              
              window.returnValue = reversedString;
              window.close();
         }
         // to handle in Firefox
         else
         {
              if ((window.opener != null) && (!window.opener.closed)) 
              {               
                // Access the control.        
                window.opener.document.getElementById(ctr[1]).value = reversedString; 
              }
              window.close();
         }
}
 
function Reverse(str)
{
   var revStr = ""; 
   for (i=str.length - 1 ; i > - 1 ; i--)
   { 
      revStr += str.substr(i,1); 
   } 
   return revStr;
}
 
function RetrieveControl()
{
        //Retrieve the query string 
        queryStr = window.location.search.substring(1); 
        // Seperate the control and its value
        ctrlArray = queryStr.split("&"); 
        ctrl1 = ctrlArray[0]; 
        //Retrieve the control passed via querystring 
        ctr = ctrl1.split("=");
}

//function ClsoePopup()
//{
//    
//    
//}


//function InvokePopForCtrolPassing(fname)
//{
//        val = document.getElementById(fname).value;
//        // to handle in IE 7.0           
//        if (window.showModalDialog) 
//        {       

//        
//            retVal = window.showModalDialog("PopupWin.aspx?Control1=" + fname + "&ControlVal=" + val ,'Show Popup Window',"dialogHeight:90px,dialogWidth:250px,resizable:yes,center:yes,");
//            document.getElementById(fname).value = retVal;
//        } 
//        // to handle in Firefox
//        else 
//        {      
//            retVal = window.open("PopupWin.aspx?Control1="+fname + "&ControlVal=" + val,'Show Popup Window','height=90,width=250,resizable=yes,modal=yes');
//            retVal.focus();            
//        }          
//}



///////
/// fucntion to fill dropndown using inner HTML
// without using XML and fixed column Code
///////////

//// how you can call a Inner HTNL to select option
//function changeText()
//{
//    var inner = "<option value='1'>First</option> <option value='2'>Second</option>"; 
//    select_innerHTML(document.getElementById("DropDownList1"),inner);	
//}
//// sample data input


///use for list assignment in dropdown AJAX
var xmlHttp3,StrDropDownID;

function GetAsmtsAjax(DropDownID,ClCode,FromDate,ToDate)
{
    StrDropDownID=DropDownID;
    var url="AJAX_Command.aspx?CommandName=ClientAssignmentInDropdown"
    url=url+"&ClCode="+ClCode
    url=url+"&FromDate="+FromDate
    url=url+"&ToDate="+ToDate   
    CallURLForAJAX(url);
 
}



function GetXmlHttpObject()
{ 
    var objXMLHttp=null
    if (window.XMLHttpRequest)
    {
        objXMLHttp=new XMLHttpRequest() 
    }
    else if (window.ActiveXObject)
    {
        objXMLHttp=new ActiveXObject("Microsoft.XMLHTTP")
    }
    return objXMLHttp
}



function CallURLForAJAX(url)
{
    var xmlHttpGetCount
    xmlHttp3=GetXmlHttpObject()

    if (xmlHttp3==null)
    {
        alert ("Browser does not support HTTP Request")
        return
    }

    xmlHttp3.onreadystatechange=stateChanged;
    xmlHttp3.open("POST",url,true)
    xmlHttp3.setRequestHeader("Content-Type", "application/x-www-form-urlencoded" )
    xmlHttp3.send(null)
 
}


function stateChanged()
{ 
    if (xmlHttp3.readyState==4 || xmlHttp3.readyState=="complete")
	{ 
	     var outPut1=xmlHttp3.responseText; 
        select_innerHTML(document.getElementById(StrDropDownID),outPut1);	

	}
} 

/// based method for converting inner HTML to a proper nodes of dropdown list

function select_innerHTML(objeto,innerHTML)
{
/******
// To dropdown Inner HTML updates
*******/
    objeto.innerHTML = ""
    var selTemp = document.createElement("micoxselect")
    var opt;
    selTemp.id="micoxselect1"
    document.body.appendChild(selTemp)
    selTemp = document.getElementById("micoxselect1")
    selTemp.style.display="none"
    
    if(innerHTML.toLowerCase().indexOf("<option")<0){//se não é option eu converto
        innerHTML = "<option>" + innerHTML + "</option>"
    }
    
    innerHTML = innerHTML.toLowerCase().replace(/<option/g,"<span").replace(/<\/option/g,"</span")
    selTemp.innerHTML = innerHTML
      
    
    for(var i=0;i<selTemp.childNodes.length;i++)
    {
        var spantemp = selTemp.childNodes[i];
  
        if(spantemp.tagName)
        {     
            opt = document.createElement("OPTION")
    
           if(document.all)
            { //IE
                objeto.add(opt)
            }
            else
            {
                objeto.appendChild(opt)
            }   
    
           //getting attributes
           for(var j=0; j<spantemp.attributes.length ; j++)
           {
            var attrName = spantemp.attributes[j].nodeName;
            var attrVal = spantemp.attributes[j].nodeValue;
            if(attrVal)
            {
                 try
                 {
                    opt.setAttribute(attrName,attrVal);
                    opt.setAttributeNode(spantemp.attributes[j].cloneNode(true));
                 }
                 catch(e)
                 {}
            }
           }
           //getting styles
           if(spantemp.style)
           {
             for(var y in spantemp.style)
                {
                 try{opt.style[y] = spantemp.style[y];}catch(e){}
                }
           }
       //value and text
       opt.value = spantemp.getAttribute("value")
       opt.text = spantemp.innerHTML
       //IE
       opt.selected = spantemp.getAttribute('selected');
       opt.className = spantemp.className;
  } 
 }    
 document.body.removeChild(selTemp)
 selTemp = null
}

