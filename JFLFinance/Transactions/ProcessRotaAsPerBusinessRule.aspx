<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="ProcessRotaAsPerBusinessRule.aspx.cs" Inherits="Transactions_ProcessRotaAsPerBusinessRule" %>
<%--<%@ Register Assembly="DropCheck" Namespace="xMilk" TagPrefix="cc1" %>
<%@ Register Src="../MS_Control/MultipleSelection.ascx" TagName="MultipleSelection"
    TagPrefix="uc1" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <Ajax:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table>
                <tr>
                    <td>
                        <table>
                            <tr>
                                <td colspan="4">
                                    <asp:Label ID="lblPageHeading" runat="server" CssClass="cssLabelHeader" Text="Process Rota"></asp:Label>
                                    <br />
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblSelectingBR" Text="Select Rule" runat="server" CssClass="cssLabel"></asp:Label>
                                </td>
                                <td colspan="3">
                                    <asp:DropDownList ID="ddlBR" runat="server" Width="300px" AutoPostBack="true" OnSelectedIndexChanged="ddlBR_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblPeriod" Text="<%$ Resources:Resource, Period %>" runat="server"
                                        CssClass="cssLabel"></asp:Label>
                                </td>
                                <td colspan="3">
                                    <asp:DropDownList ID="ddlPeriodCollection" runat="server" Width="180px" Height="22px"
                                        CssClass="cssDropDown">
                                    </asp:DropDownList>
                                    <asp:Button ID="btnProceed" runat="server" CssClass="cssButton" Text="Process" OnClick="btnProceed_Click" />
                                    <asp:LinkButton ID="btnAddPeriodCollection" runat="server" CssClass="csslnkButton"
                                        Text="Add Period Collection" Visible="false" OnClick="btnAddPeriodCollection_Click"></asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:Button ID="btnGeneratePaysum" runat="server" CssClass="cssButton" Text="Generate Paysum"
                                        OnClick="btnGeneratePaysum_Click" />
                                    &nbsp;
                                    <asp:LinkButton ID="btnFinalPaysum" runat="server" CssClass="csslnkButton" Text="Send Paysum to Payroll"
                                        OnClick="btnFinalPaysum_Click"></asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <asp:Label ID="lblErrorMsg" runat="server" Width="250px" CssClass="csslblErrMsg"></asp:Label>
                                    <td align="left" colspan="2">
                                        <br>
                                        <asp:Label EnableViewState="false" ID="Label1" Text="" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                        <br>
                                        <Ajax:UpdateProgress ID="UpdateProgress1" runat="server">
                                            <ProgressTemplate>
                                                Please wait.....<img alt="" src="../Images/spinner.gif" />
                                            </ProgressTemplate>
                                        </Ajax:UpdateProgress>
                                    </td>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </Ajax:UpdatePanel>
</asp:Content>
