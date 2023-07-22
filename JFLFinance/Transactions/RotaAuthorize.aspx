<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="RotaAuthorize.aspx.cs" Inherits="Transactions_RotaAuthorize" Title="<%$ Resources:Resource, AppTitle %>" %>
    <%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
                <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
                    <ContentTemplate>
                                <div class="squareboxgradientcaption" style="height:20px;">
                                            <asp:Label ID="Label5" runat="server" Text="<%$ Resources:Resource, RotaAuthorize %>"></asp:Label>
                                </div>
                                <div>
                                    <table border="0" cellpadding="1" cellspacing="1" style="width: 700px">
                                        <tr>
                                            <td align="right" style="height: 27px; width:20%" >
                                                <asp:Label Style="width: 100px" CssClass="cssLable" ID="Label3" runat="server" Text="<%$ Resources:Resource, HrLocation %>"></asp:Label>
                                            </td>
                                            <td align="left" style="height: 27px; width:40%">
                                                <telerik:RadComboBox ID="ddlHrLocation" runat="server" Width="250px" MaxHeight="250px" EmptyMessage="Please Select"
                                                                     CheckBoxes="False" EnableCheckAllItemsCheckBox="False" EnableLoadOnDemand="true" 
                                                                     OnSelectedIndexChanged="ddlHrLocation_SelectedIndexChanged" /> 
                                         
                                                <%--<asp:DropDownList ID="ddlHrLocation" runat="server" CssClass="cssDropDown" Width="250"
                                                    OnSelectedIndexChanged="ddlHrLocation_SelectedIndexChanged" AutoPostBack="true">
                                                </asp:DropDownList>--%>
                                            </td>
                                            <td align="left" style="height: 27px; width:40%">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" style="height: 27px; width:20%" >
                                                <asp:Label Style="width: 100px" CssClass="cssLable" ID="Label1" runat="server" Text="<%$ Resources:Resource, Location %>"></asp:Label>
                                            </td>
                                            <td align="left" style="height: 27px; width:40%">
                                                <telerik:RadComboBox ID="ddlLocation" runat="server" Width="250px" MaxHeight="250px" EmptyMessage="Please Select"
                                                                     CheckBoxes="False" EnableCheckAllItemsCheckBox="False" EnableLoadOnDemand="true" 
                                                                     OnSelectedIndexChanged="ddlLocation_SelectedIndexChanged" AutoPostBack="True"/>
                                                <%--<asp:DropDownList ID="ddlLocation" runat="server" CssClass="cssDropDown" Width="250"
                                                    OnSelectedIndexChanged="ddlLocation_SelectedIndexChanged" AutoPostBack="true">
                                                </asp:DropDownList>--%>
                                            </td>
                                            <td align="left" style="height: 27px; width:40%">
                                                &nbsp;
                                            </td>
                                        </tr>
                                         <%--<tr>
                                            <td align="right" style="height: 27px; width:20%" >
                                                <asp:Label Style="width: 100px" CssClass="cssLable" ID="Label4" runat="server" Text="<%$ Resources:Resource, Paysum %>"></asp:Label>
                                            </td>
                                            <td align="left" style="height: 27px; width:40%">
                                                <asp:DropDownList ID="ddlPaysumCode" runat="server" CssClass="cssDropDown" Width="250"
                                                    OnSelectedIndexChanged="ddlPaysumCode_SelectedIndexChanged" AutoPostBack="true">
                                                </asp:DropDownList>
                                            </td>
                                            <td align="left" style="height: 27px; width:40%">
                                                &nbsp;
                                            </td>
                                        </tr>--%>
                                        <tr>
                                            <td align="right" style="height: 27px">
                                                <asp:Label Style="width: 100px" CssClass="cssLable" ID="Label2" runat="server" Text="<%$ Resources:Resource, SelectPeriod %>"></asp:Label>
                                            </td>
                                            <td align="left" style="height: 27px">
                                                <asp:DropDownList ID="ddlPayPeriod" runat="server" CssClass="cssDropDown" Width="250"
                                                    OnSelectedIndexChanged="ddlPayPeriod_SelectedIndexChanged" AutoPostBack="true">
                                                </asp:DropDownList>
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblModifiedBy" runat="server" Text=""></asp:Label>
                                                <label>/</label>
                                                <asp:Label ID="lblModifiedDate" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td align="left">
                                                <asp:Button ID="btnAuthorizePre" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource, Authorize %>"
                                                    OnClientClick="javascript:onRotaAutorize()" />
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" colspan="3">
                                                <asp:Label EnableViewState="false" ID="lblErrorMsg" Text="" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                    </ContentTemplate>
                </Ajax:UpdatePanel>
               <asp:Button ID="btnAuthorize" runat="server" CssClass="cssButton" Style="display: none"
                    OnClick="btnAuthorize_Click" Text="<%$ Resources:Resource, Authorize %>" />
    <script language="javascript" type="text/javascript">
        var MakeSureLeavesHolidaysUptodate = '<%= Resources.Resource.MakeSureLeavesHolidaysUptodate %>';

        function onRotaAutorize() {
            var returnValue = confirm(MakeSureLeavesHolidaysUptodate);
            if (returnValue) {
                document.getElementById('<%=btnAuthorize.ClientID %>').click();
            }
        }
        
    </script>
</asp:Content>
