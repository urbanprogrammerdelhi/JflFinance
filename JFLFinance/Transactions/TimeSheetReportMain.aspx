<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TimeSheetReportMain.aspx.cs" Inherits="Transactions_TimeSheetReportMain" 
MasterPageFile="~/MasterPage/MasterPage.master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel ID="Panel1" runat="server" GroupingText="<%$Resources:Resource,TimeSheet %> ">
        <table>
            <tr>
                <td>
                <asp:Label ID="lblArea" runat="server" CssClass="cssLabel" EnableViewState="false" Text="<%$Resources:Resource,AreaID %> "></asp:Label>
                </td>
                <td>
                <asp:DropDownList ID="DDLAreaID" runat="server" AutoPostBack="true"  CssClass="cssDropDown" OnSelectedIndexChanged="ddlAreaID_SelectedIndexChanged">
                </asp:DropDownList>
                </td>
            </tr>
            
            <tr>
                <td>
                <asp:Label ID="LabelEmpNumber" runat="server" CssClass="cssLabel" EnableViewState="false" Text="<%$Resources:Resource,EmployeeNumber %> "></asp:Label>
                </td>
                <td>
                <asp:DropDownList ID="ddlEmployeeNumber" runat="server" AutoPostBack="true"  CssClass="cssDropDown">
                </asp:DropDownList>
                </td>
            </tr>
            
            
            <tr>
                <td align="left">
                    <asp:Label ID="Label5" runat="server" Text="<%$Resources:Resource,FromDate %>" CssClass="cssLable"></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox CssClass="csstxtboxSmall" Text="" ID="txtFromDate" runat="server" AutoPostBack="false"></asp:TextBox>
                        <asp:HyperLink ID="ImgFromDate" Style="vertical-align: middle;" runat="server" ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                        <AjaxToolKit:CalendarExtender ID="CalendarExtender2" Format="dd-MMM-yyyy" runat="server"
                            TargetControlID="txtFromDate" PopupButtonID="ImgFromDate">
                        </AjaxToolKit:CalendarExtender>
                </td>
            </tr>

            <tr>
                <td align="left">
                    <asp:Label ID="LabelToDate" runat="server" Text="<%$Resources:Resource,ToDate %>" CssClass="cssLable"></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox CssClass="csstxtboxSmall" Text="" ID="txtToDate" runat="server" AutoPostBack="false"></asp:TextBox>
                        <asp:HyperLink ID="ImgToDate" Style="vertical-align: middle;" runat="server" ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                        <AjaxToolKit:CalendarExtender ID="CalendarExtender1" Format="dd-MMM-yyyy" runat="server"
                            TargetControlID="txtToDate" PopupButtonID="ImgToDate">
                        </AjaxToolKit:CalendarExtender>
                </td>
            </tr>
         
            <tr>
               
                <td>
                    <asp:Button ID="btnGenerateData" runat="server" CssClass="cssButton" OnClientClick="javascript:process();" OnClick="btnGenerateData_Click"
                        Text="View" />
                </td>
            </tr>
            <tr>
                <td align="center" colspan="4">
                    <asp:Label ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg" EnableViewState="false"></asp:Label>
                    <div id="processDiv" style="position: absolute; top: 0; left: 0; width: 100%; height: 100%; text-align: center; display:none">
                        <img id="imgspin" runat="server" style="position: absolute; top: 50%; left: 50%"
                            alt="" src="../Images/spinner.gif" />
                    </div>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <script language="javascript" type="text/javascript">

        function process() {
            document.getElementById('processDiv').style.display = "block";
        }
    </script>
</asp:Content>
