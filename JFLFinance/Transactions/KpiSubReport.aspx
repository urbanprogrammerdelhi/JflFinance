<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KpiSubReport.aspx.cs" Inherits="KPIAdmin_KpiSubReport" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        html, body, form
        {
            height: 100%;
            margin: 0px;
            padding: 0px;
        }
        
        .classImage
        {
            background: url(../Images/Excel.png);
        }
        
        .link
        {
            background-color: Gray;
            font-size: 10pt;
            font-weight: bold;
            font-family: Arial;
            color: Blue;
        }
    </style>
    <script type="text/javascript">
        

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptManager EnablePartialRendering="true" EnableScriptGlobalization="true"
        ScriptMode="Release" EnableScriptLocalization="true" ID="script" runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/javaScript/validation.js" />
            <asp:ScriptReference Path="~/javaScript/jquery-1.8.1.min.js" />
        </Scripts>
    </telerik:RadScriptManager>
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">

            function SetTarget(objName) {
                if (objName == 'btnViewMore') {
                    document.forms[0].target = "_blank";
                }
                else {
                    document.forms[0].target = "";
                }
            }



            //            function PrintRadGrid(radGrid) {
            //                setTimeout(function () {
            //                    var radGridId = $find(radGrid);
            //                    var previewWnd = window.open('about:blank', '', 'height=0, width=0, status=no, resizable=no, scrollbars=yes, toolbar=no,location=no, menubar=no', false);
            //                    var sh = '<%= ClientScript.GetWebResourceUrl(gvKPI.GetType(),String.Format("Telerik.Web.UI.Skins.{0}.Grid.{0}.css",gvKPI.Skin)) %>';
            //                    var styleStr = "<html><head><link href = '" + sh + "' rel='stylesheet' type='text/css'></link></head>";
            //                    //var styleStr = "<html><head><link href='../css/StyleSheet.css' rel='stylesheet' type='text/css'></link></head>";
            //                    //var htmlcontent = styleStr + "<body>" + radGrid.get_element().outerHTML + "</body></html>";
            //                    var htmlcontent = styleStr + "<body>" + $find(radGrid).get_element().outerHTML + "</body></html>";
            //                    previewWnd.document.open();
            //                    previewWnd.document.write(htmlcontent);
            //                    previewWnd.document.close();
            //                    previewWnd.print();
            //                    previewWnd.close();
            //                    radGridId.get_masterTableView().fireCommand("EnablePaging", "");
            //                }, 100);
            //            }



            function getOuterHTML(obj) {
                if (typeof (obj.outerHTML) == "undefined") {
                    var divWrapper = document.createElement("div");
                    var copyOb = obj.cloneNode(true);
                    divWrapper.appendChild(copyOb);
                    return divWrapper.innerHTML
                }
                else {
                    return obj.outerHTML;
                }
            }
            var pageSize;
            var PageCount;
            function PrintRadGrid() {
                var radGrid = $find('<%= gvKPI.ClientID %>');

                pageSize = radGrid.MasterTableView.PageSize;
                PageCount = radGrid.MasterTableView.PageCount;
                var previewWindow = window.open('about:blank', '', '', false);
                var styleSheet = '<%= Telerik.Web.SkinRegistrar.GetWebResourceUrl(this, gvKPI.GetType(), String.Format("Telerik.Web.UI.Skins.{0}.Grid.{0}.css", gvKPI.Skin)) %>';
                var baseStyleSheet = '<%= Telerik.Web.SkinRegistrar.GetWebResourceUrl(this, gvKPI.GetType(), "Telerik.Web.UI.Skins.Grid.css") %>';
                var htmlContent = "<html><head><link href = '" + styleSheet + "' rel='stylesheet' type='text/css'></link>";

                htmlContent += "<link href = '" + baseStyleSheet + "' rel='stylesheet' type='text/css'></link></head>";
                htmlContent = htmlContent + "<body>" + getOuterHTML(radGrid.get_element()) + "</body></html>";
                previewWindow.document.open();
                previewWindow.document.write(htmlContent);
                previewWindow.document.close();
                previewWindow.print();

                if (!$telerik.isChrome) {
                    previewWindow.close();
                }
                radGrid.get_masterTableView().fireCommand("EnablePaging", "");
                // revertBackGridPaging();
            }

            function revertBackGridPaging() {
                var grid = $find("<%= gvKPI.ClientID %>");
                grid.MasterTableView.beginUpdate();
                grid.MasterTableView.set_pageSize(pageSize);
                grid.MasterTableView.endUpdate();
            }

//            function SplitterLoaded(splitter, arg) {
//                var pane = splitter.getPaneById('<%= Radpane51.ClientID %>');
//                var height = pane.getContentElement().scrollHeight;
//                splitter.set_height(height);
//                pane.set_height(height);
//            }  


        </script>
    </telerik:RadCodeBlock>
    <telerik:RadSplitter ID="RadSplitter2" LiveResize="true" runat="server" Orientation="Vertical"
        Height="100%" Width="100%" >
        <telerik:RadPane ID="Radpane1" ShowContentDuringLoad="false" Scrolling="Both" Width="250px"
            Font-Names="Arial" Font-Size="7pt" MinWidth="100" MaxWidth="350" runat="server"
            Collapsed="true">
            <table>
                <tr>
                    <td>
                        <telerik:RadListBox ID="radGridColumn" Width="230px" Height="400px" runat="server"
                            CheckBoxes="true" AutoPostBack="true">
                        </telerik:RadListBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnHideShow" CssClass="cssButton" runat="server" Text="Hide/Show"
                            OnClientClick="SetTarget('btnHideShow')" OnClick="btnHideShow_Click" />
                    </td>
                </tr>
            </table>
        </telerik:RadPane>
        <telerik:RadSplitBar ID="Radsplitbar4" runat="server" CollapseMode="Forward" />
        <telerik:RadPane ID="Radpane51" ShowContentDuringLoad="true" Scrolling="Both" runat="server"
            Font-Names="Arial" Font-Size="8pt" Collapsed="true">
            <asp:Panel ID="pnlGrid" Width="100%" runat="server" GroupingText="Report" CssClass="cssLable"
                Font-Names="Arial" Font-Size="8pt">
                <table>
                    <tr>
                        <td align="left">
                            <asp:Panel ID="pnlExcel" runat="server" BackImageUrl="~/Images/panev.gif" BorderWidth="1pt"
                                BorderColor="LightBlue" BorderStyle="Solid">
                                <table width="100%">
                                    <tr>
                                        <td align="left" style="width: 3%;">
                                            <asp:ImageButton ID="ImgExcel" ImageUrl="~/Images/Excel.png" ToolTip="Export To Excel"
                                                OnClick="Button1_Click" runat="server" CssClass="ImageButtons" />
                                        </td>
                                        <td align="left" style="width: 97%;">
                                            <asp:ImageButton ID="imgPrint" ImageUrl="~/Images/printer.png" ToolTip="Print" OnClick="lnkPrint_Click"
                                                runat="server" CssClass="ImageButtons" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <telerik:RadAjaxPanel ID="ajxPanelGrid" runat="server">
                                <%-- --%>
                                <telerik:RadGrid ID="gvKPI" runat="server" Width="100%" AllowFilteringByColumn="true"
                                    OnNeedDataSource="gvKPI_NeedDataSource" OnColumnCreated="gvKPI_OnColumnCreated"
                                    ClientSettings-AllowColumnsReorder="true" ViewStateMode="Enabled" AllowSorting="True"
                                    AutoGenerateColumns="true" AllowPaging="true" PageSize="10" MasterTableView-ShowGroupFooter="true"
                                    ClientSettings-AllowDragToGroup="true" ClientSettings-AllowGroupExpandCollapse="true"
                                    OnItemCommand="gvKPI_OnItemCommand" GroupingSettings-ShowUnGroupButton="true"
                                    GroupingEnabled="true" ShowGroupPanel="True" GridLines="None" Skin="Office2007"
                                    OnPreRender="gvKPI_PreRender">
                                    <PagerStyle Mode="NextPrevAndNumeric"></PagerStyle>
                                    <%--Added For Export--%>
                                    <ExportSettings IgnorePaging="true" ExportOnlyData="true" HideStructureColumns="true">
                                        <Excel Format="ExcelML" FileExtension="xls"></Excel>
                                    </ExportSettings>
                                    <MasterTableView AllowMultiColumnSorting="false" Font-Size="8" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left">
                                        <%--<CommandItemSettings ShowRefreshButton="False" ShowAddNewRecordButton="false" ShowExportToExcelButton="False"
                                            ExportToExcelText="Export to Excel." />--%>
                                    </MasterTableView>
                                </telerik:RadGrid>
                            </telerik:RadAjaxPanel>
                            <asp:LinkButton ID="btnViewMore" runat="server" Text="More Detail.." Font-Italic="true"
                                OnClientClick="SetTarget('btnViewMore')" OnClick="btnViewMore_Click" />
                            <asp:Label ID="lblError" Style="display: none" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </telerik:RadPane>
    </telerik:RadSplitter>
    </form>
</body>
</html>
