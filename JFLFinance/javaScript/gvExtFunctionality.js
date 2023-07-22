// JScript File
var oldgridSelectedColor;
function setMouseOverColor(element) 
{
    oldgridSelectedColor = element.style.backgroundColor;
    //element.style.backgroundColor='yellow';

    element.style.backgroundColor = '#c0c0c0'; /*'#F7DA7E'; '#EDDA74'; '#c0c0c0';*/
    element.style.cursor='hand';
    //element.style.textDecoration='underline';
    element.style.textDecoration='none';
}
function setMouseOutColor(element) 
{
    element.style.backgroundColor=oldgridSelectedColor;
    element.style.textDecoration='none';
}




///Gridview column Resize

  /*

Table Resizing code

*/

/*
Global constants to store elements that may be resized but we
could probably place these into custom table attributes instead.
*/
var sResizableElement = "TH";    // This MUST be upper case
var iResizeThreshold = 8;
var iEdgeThreshold = 8;
var iSizeThreshold = 20;
var sVBarID = "VBar";

/*
Global variables to store position and distance moved but we
could probably place these into custom table attributes instead.
*/
var oResizeTarget = null;
var iStartX = null;
var iEndX = null;
var iSizeX = null;

/*
Helper Functions
*/

/*
Creates the VBar on document load
*/

    function TableResize_CreateVBar()
{
    // Returns a reference to the resizer VBar for the table
    var objItem = document.getElementById(sVBarID);

    // Check if the item doesn't yet exist
    if (!objItem) 
    {        
        // and Create the item if necessary
        objItem = document.createElement("SPAN");

        // Setup the bar
        objItem.id = sVBarID;
        objItem.style.position = "absolute";
        objItem.style.top = "0px";
        objItem.style.left = "0px";
        objItem.style.height = "0px";
        objItem.style.width = "2px";
        objItem.style.background = "silver";
        objItem.style.borderLeft = "1px solid black";
        objItem.style.display = "none"; 

        // Add the bar to the document
        document.body.appendChild(objItem);
    }
}

//window.attachEvent("onload", TableResize_CreateVBar);

/*
Returns a valid resizable element, even if it contains another element 
which was actually clicked otherwise it returns the top body element.
*/
function TableResize_GetOwnerHeader(objReference) 
{
    var oElement = objReference;

    while (oElement != null && oElement.tagName != null && oElement.tagName != "BODY") 
    {
        if (oElement.tagName.toUpperCase() == sResizableElement) 
        {
            return oElement;
        }

        oElement = oElement.parentElement;
    }

    // The TH wasn't found
    return null;
}

/*
Find cell at column iCellIndex in the first row of the table 
needed because you can only resize a column from the first row.
by using this, we can resize from any cell in the table if we want to.
*/
function TableResize_GetFirstColumnCell(objTable, iCellIndex) 
{
    var oHeaderCell = objTable.rows(0).cells(iCellIndex);

    return oHeaderCell;
}

/*
Clean up - clears out the tracking information if we're not resizing.
*/
function TableResize_CleanUp() 
{
    // Void the Global variables and hide the resizer VBar.
    var oVBar = document.getElementById(sVBarID);

    if (oVBar)
    {
        oVBar.runtimeStyle.display = "none";
    }

    iEndX = null;
    iSizeX = null;
    iStartX = null;
    oResizeTarget = null;
    oAdjacentCell = null;

    return true;
}

/*
Main Functions
*/

/*
MouseMove event.
On resizable table This checks if you are in an allowable 'resize start' position. 
It also puts the vertical bar (visual feedback) directly under the mouse cursor. 
The vertical bar may NOT be currently visible, that depnds on if you're resizing.
*/
function TableResize_OnMouseMove(objTable) 
{
    // Change cursor and store cursor position for resize indicator on column
    var objTH = TableResize_GetOwnerHeader(event.srcElement);

    if (!objTH)
        return;

    var oVBar = document.getElementById(sVBarID);

    if (!oVBar)
        return;

    var oAdjacentCell = objTH.nextSibling;

    // Show the resize cursor if we are within the edge threshold.
    if ((event.offsetX >= (objTH.offsetWidth - iEdgeThreshold)) && (oAdjacentCell != null)) 
    {
        objTH.runtimeStyle.cursor = "e-resize";
    } 
    else 
    {
        if(objTH.style.cursor) 
        {
            objTH.runtimeStyle.cursor = objTH.style.cursor;
        } 
        else 
        {
            objTH.runtimeStyle.cursor = "";
        }
    }

    // We want to keep the right cursor if resizing and 
    // don't want resizing to select any text elements...
    if (oVBar.runtimeStyle.display == "inline") 
    {
        // We have to add the body.scrollLeft in case the table is wider than the view window
        // where the table is entirely within the screen this value should be zero...
        oVBar.runtimeStyle.left = window.event.clientX + document.body.scrollLeft;

        document.selection.empty();
    }

    return true;
}

/*
MouseDown event. 
This fills the globals with tracking information, and displays the 
vertical bar. This is only done if you are allowed to start resizing.
*/
function TableResize_OnMouseDown(objTable) 
{
    // Record start point and show vertical bar resize indicator
    var oTargetCell = event.srcElement;

    if (!oTargetCell)
        return;

    var oVBar = document.getElementById(sVBarID);

    if (!oVBar)
        return;

    if (oTargetCell.parentElement.tagName.toUpperCase() == sResizableElement)
    {
        oTargetCell = oTargetCell.parentElement;
    }

    var oHeaderCell = TableResize_GetFirstColumnCell(objTable, oTargetCell.cellIndex);

    if ((oHeaderCell.tagName.toUpperCase() == sResizableElement) && (oTargetCell.runtimeStyle.cursor == "e-resize")) 
    {        
        iStartX = event.screenX;
        oResizeTarget = oHeaderCell;

        // Mark the table with the resize attribute and show the resizer VBar.
        // We also capture all events on the table we are resizing because Internet 
        // Explorer sometimes forgets to bubble some events up. 
        // Now all events will be fired on the table we are resizing.
        objTable.setAttribute("Resizing", "true");
        objTable.setCapture();

        // Set up the VBar for display

        // We have to add the body.scrollLeft in case the table is wider than the view window
        // where the table is entriely within the screen this value should be zero...
        oVBar.runtimeStyle.left = window.event.clientX + document.body.scrollLeft;

        oVBar.runtimeStyle.top = objTable.parentElement.offsetTop + objTable.offsetTop;;
        oVBar.runtimeStyle.height = objTable.parentElement.clientHeight;
        oVBar.runtimeStyle.display = "inline";
    }

    return true;
}

/*
MouseUp event. 
This finishes the resize.
*/
function TableResize_OnMouseUp(objTable) 
{
    // Resize the column and its adjacent sibling if position and size are within threshold values
    var oAdjacentCell = null;
    var iAdjCellOldWidth = 0;
    var iResizeOldWidth = 0;

    if (iStartX != null && oResizeTarget != null) 
    {
        iEndX = event.screenX;
        iSizeX = iEndX - iStartX;

        // Mark the table with the resize attribute for not resizing
        objTable.setAttribute("Resizing", "false");

        if ((oResizeTarget.offsetWidth + iSizeX) >= iSizeThreshold) 
        {
            if (Math.abs(iSizeX) >= iResizeThreshold) 
            {
                if (oResizeTarget.nextSibling != null) 
                {
                    oAdjacentCell = oResizeTarget.nextSibling;
                    iAdjCellOldWidth = (oAdjacentCell.offsetWidth);
                } 
                else 
                {
                    oAdjacentCell = null;
                }

                iResizeOldWidth = (oResizeTarget.offsetWidth);
                oResizeTarget.style.width = iResizeOldWidth + iSizeX;

                if ((oAdjacentCell != null) && (oAdjacentCell.tagName.toUpperCase() == sResizableElement)) 
                {
                    oAdjacentCell.style.width = (((iAdjCellOldWidth - iSizeX) >= iSizeThreshold)?(iAdjCellOldWidth - iSizeX):(oAdjacentCell.style.width = iSizeThreshold))
                }
            }
        } 
        else 
        {
            oResizeTarget.style.width = iSizeThreshold;
        }
    }

    // Clean up the VBar and release event capture.
    TableResize_CleanUp();
    objTable.releaseCapture();

    return true;
}

/*code modified by   on 27-Apr-2010*/
/*Purpose: To change color code of the Link Button on which the Mouse is Set over*/

function MenuBtnMouseOver(element) {
    
    document.getElementById(element).style.backgroundImage = "url(../Images/buttoncolorchangeImg.bmp)";
    
}
function MenuBtnMouseOut(element) {

    document.getElementById(element).style.backgroundImage = "url(../Images/buttonImg.bmp)";
    

}
/*end of code modified by   on 27-Apr-2010*/



