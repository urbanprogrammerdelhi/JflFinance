<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="RptGroup_AttendanceKenya.aspx.cs" Inherits="Transactions_RptGroup_AttendanceKenya"
    Title="<%$ Resources:Resource, AppTitle %>" %>

<%--<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel ID="Panel1" runat="server" GroupingText="">
        <table>
            <tr>
                <td align="left" style="width: 200px">
                    <asp:Label ID="Label9" runat="server" Text="<%$Resources:Resource,HrLocation %>"
                        CssClass="cssLable"></asp:Label>
                </td>
                <td align="left" colspan="3">
                    <asp:DropDownList ID="ddlDivision" AutoPostBack="true" runat="server" CssClass="cssDropDown"
                        Width="350px" OnSelectedIndexChanged="ddlDivision_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="left" style="width: 200px">
                    <asp:Label ID="Label10" runat="server" Text="<%$Resources:Resource,Branch %>" CssClass="cssLable"></asp:Label>
                </td>
                <td align="left" colspan="4">
                    <telerik:RadComboBox ID="ddlBranch" runat="server" Width="250px" MaxHeight="350px"
                        CheckBoxes="true" EnableCheckAllItemsCheckBox="true" AutoPostBack="true" Filter="StartsWith">
                        <%--OnSelectedIndexChanged="ddlAsmtName_SelectedIndexChanged"--%>
                    </telerik:RadComboBox>
                    <%-- <asp:DropDownList ID="ddlBranch" AutoPostBack="false" runat="server" CssClass="cssDropDown"
                                        Width="350px">
                                    </asp:DropDownList>--%>
                    <%--<uc1:MultipleSelection ID="msddlBranch" runat="server" />--%>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblCategory" runat="server" Text="<%$Resources:Resource,Category %>"
                        CssClass="cssLable"></asp:Label>
                </td>
                <td>
                    <telerik:RadComboBox ID="DDLCategory" runat="server" Width="250px" MaxHeight="350px"
                        CheckBoxes="true" EnableCheckAllItemsCheckBox="true" AutoPostBack="true" Filter="StartsWith">
                        <%--OnSelectedIndexChanged="ddlAsmtName_SelectedIndexChanged"--%>
                    </telerik:RadComboBox>
                    <%-- <asp:DropDownList Width="120px" ID="DDLCategory" runat="server" CssClass="cssDropDown">
                    </asp:DropDownList>--%>
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
                    <asp:Label ID="LabelToDate" runat="server" Text="<%$Resources:Resource,ToDate %>"
                        CssClass="cssLable"></asp:Label>
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
                    <asp:Button ID="btnGenerateData" runat="server" CssClass="cssButton" OnClientClick="javascript:process();"
                        OnClick="btnGenerateData_Click" Text="View" />
                </td>
            </tr>
            <tr>
                <td align="center" colspan="4">
                    <asp:Label ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg" EnableViewState="false"></asp:Label>
                    <div id="processDiv" style="position: absolute; top: 0; left: 0; width: 100%; height: 100%;
                        text-align: center; display: none">
                        <img id="imgspin" runat="server" style="position: absolute; top: 50%; left: 50%"
                            alt="" src="../Images/spinner.gif" />
                    </div>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td colspan="4">
                    <dx:ASPxGridView ID="musterRoll" runat="server" Width="950px" EnableViewState="false"
                        AutoGenerateColumns="True">
                        <Settings ShowFilterRow="True" ShowGroupPanel="True" ShowFilterRowMenu="True" ShowHeaderFilterButton="True"
                            ShowHorizontalScrollBar="True" />
                        <SettingsPager AlwaysShowPager="True" PageSize="10">
                        </SettingsPager>
                    </dx:ASPxGridView>
                    <dx:ASPxGridViewExporter ExportedRowType="Selected" GridViewID="musterRoll" ID="exportGrid"
                        runat="server">
                    </dx:ASPxGridViewExporter>
                    <dx:ASPxButton ID="btnExport" runat="server" OnClick="btnExport_Click" CssClass="cssButton"
                        Text="<%$Resources:Resource,ExporttoExcel %>" Width="166px">
                    </dx:ASPxButton>
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
