<%@ Page Title="<%$ Resources:Resource, AppTitle %>" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="ShiftWiseSchandActual.aspx.cs" Inherits="Transactions_ShiftWiseSchandActual" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="squareboxgradientcaption" style="height: 20px;">
                <asp:Label ID="Label2" runat="server" Text="<%$Resources:Resource,Dashboard %>"></asp:Label>
            </div>
            <div style="overflow: auto;">
                <table width="100%">
                    <tr>
                        <td align="right">
                            <asp:Label runat="server" ID="lblArea" Text="<%$Resources:Resource,Area %>" CssClass="cssLabel"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList runat="server" ID="ddlAreaID" CssClass="cssDropDown" AutoPostBack="true"
                                Width="229px" OnSelectedIndexChanged="ddlAreaID_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td align="right">
                            <asp:Label Width="50px" ID="lblhdrDutyDate" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource,DutyDate  %>"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtDutyDate" CssClass="csstxtbox" runat="server"></asp:TextBox>
                            <asp:HyperLink Style="vertical-align: top;" ID="HlimgDutyDate"
                                runat="server" Height="19px" Width="20px" ImageUrl="../Images/pdate.gif"></asp:HyperLink>
                            <AjaxToolKit:CalendarExtender ID="CEDutyDate" Format="dd-MMM-yyyy" runat="server"
                                TargetControlID="txtDutyDate" PopupButtonID="HlimgDutyDate" Enabled="True"></AjaxToolKit:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label Width="50px" ID="lblfixClientName" CssClass="cssLabel" runat="server"
                                Text="<%$ Resources:Resource, Client %>"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList AutoPostBack="true" CssClass="cssDropDown" Width="380px" ID="ddlClientCode"
                                runat="server" OnSelectedIndexChanged="ddlClientCode_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td align="right">
                            <asp:Label Width="50px" ID="lblAssmtId" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource,AsmtId  %>"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlAsmtId" Width="400px" CssClass="cssDropDown" runat="server"
                                AutoPostBack="True" OnSelectedIndexChanged="ddlAsmtId_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label Width="50px" ID="lblShift" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource,Shift  %>"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlShift" Width="200px" CssClass="cssDropDown" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td colspan="2" align="center">
                            <asp:Button ID="btnView" runat="server" CssClass="cssButton" Text="<%$Resources:Resource,View %>" OnClick="btnView_Click" />
                        </td>
                    </tr>
                </table>
                <div class="mydiv">
                    <a href="#" style="color: #444444; font-size: 18px; font-weight: 400; line-height: 32.4px;">Required</a>
                    <table style="width: 100%; margin-left: 15px;" cellpadding="0">
                        <tr>
                            <td>Employee Count:
                                <asp:Label ID="lblReqEmpCount" runat="server" CssClass="cssLabelHeader"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Total Hours:
                                <asp:Label ID="lblReqHrs" runat="server" CssClass="cssLabelHeader"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="mydiv">
                    <a href="#" style="color: #444444; font-size: 18px; font-weight: 400; line-height: 32.4px;">Scheduled</a>
                    <table style="width: 100%; margin-left: 15px;" cellpadding="0">
                        <tr>
                            <td>Employee Count:
                                <asp:Label ID="lblSchEmpCount" runat="server" CssClass="cssLabelHeader"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Total Hours:
                                <asp:Label ID="lblSchHrs" runat="server" CssClass="cssLabelHeader"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="mydiv">
                    <a href="#" style="color: #444444; font-size: 18px; font-weight: 400; line-height: 32.4px;">Actuals</a>
                    <table style="width: 100%; margin-left: 15px;" cellpadding="0">
                        <tr>
                            <td>Employee Count:
                                <asp:Label ID="lblActEmpCount" runat="server" CssClass="cssLabelHeader"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Total Hours:
                                <asp:Label ID="lblActHrs" runat="server" CssClass="cssLabelHeader"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
                <table class="GridViewHeaderStyle" style="width: 100%">
                    <%-- <tr>
                        <td align="right" style="width:25%">Scheduled Employee Count</td>
                        <td align="left" style="width:25%">: <asp:Label ID="lblSchEmpCount" runat="server" CssClass="cssLabelHeader"></asp:Label></td>
                        <td align="right" style="width:25%">Actual On Duty Employee Count</td>
                        <td align="left" style="width:25%">: <asp:Label ID="lblActEmpCount" runat="server" CssClass="cssLabelHeader"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right" style="width:25%">Scheduled Hours</td>
                        <td align="left" style="width:25%">: <asp:Label ID="lblSchHrs" runat="server" CssClass="cssLabelHeader"></asp:Label></td>
                        <td align="right" style="width:25%">Actual Hours</td>
                        <td align="left" style="width:25%">: <asp:Label ID="lblActHrs" runat="server" CssClass="cssLabelHeader"></asp:Label></td>
                    </tr>--%>
                    <tr>
                        <td align="center" colspan="2" style="width: 50%">Scheduled</td>
                        <td align="center" colspan="2" style="width: 50%">Actual Duty</td>
                    </tr>
                </table>
                <asp:GridView Width="100%" ID="gvSchActual" Style="min-width: 940px;" CssClass="GridViewStyle" runat="server"
                    ShowFooter="true" ShowHeader="true" Visible="true" CellPadding="1" GridLines="None"
                    AutoGenerateColumns="False" OnRowDataBound="gvSchActual_RowDataBound">
                    <FooterStyle CssClass="GridViewFooterStyle" />
                    <RowStyle CssClass="GridViewRowStyle" />
                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                    <PagerStyle CssClass="GridViewPagerStyle" />
                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="lblgvhdrSerialNo" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,SerialNumber %>"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblSerialNo" CssClass="cssLabel" runat="server"></asp:Label>
                            </ItemTemplate>
                            <FooterStyle Width="50px" />
                            <HeaderStyle Width="50px" />
                            <ItemStyle Width="50px" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="lblgvhdrSchEmployeeNumber" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, EmployeeNumber %>"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblgvSchEmployeeNumber" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SchEmployeeNumber").ToString()%>'></asp:Label>
                            </ItemTemplate>
                            <FooterStyle Width="100px" />
                            <HeaderStyle Width="100px" />
                            <ItemStyle Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="lblgvhdrSchEmployeeName" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, EmployeeName %>"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblgvSchEmployeeName" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SchEmployeeName").ToString()%>'></asp:Label>
                            </ItemTemplate>
                            <FooterStyle Width="150px" />
                            <HeaderStyle Width="150px" />
                            <ItemStyle Width="150px" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="lblgvhdrSchShiftTime" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, Time %>"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblgvSchShiftTime" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SchShiftTime").ToString()%>'></asp:Label>
                            </ItemTemplate>
                            <FooterStyle Width="200px" />
                            <HeaderStyle Width="200px" />
                            <ItemStyle Width="200px" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="lblgvhdrActEmployeeNumber" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, EmployeeNumber %>"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblgvActEmployeeNumber" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ActEmployeeNumber").ToString()%>'></asp:Label>
                            </ItemTemplate>
                            <FooterStyle Width="100px" />
                            <HeaderStyle Width="100px" />
                            <ItemStyle Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="lblgvhdrActEmployeeName" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, EmployeeName %>"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblgvActEmployeeName" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ActEmployeeName").ToString()%>'></asp:Label>
                            </ItemTemplate>
                            <FooterStyle Width="150px" />
                            <HeaderStyle Width="150px" />
                            <ItemStyle Width="150px" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="lblgvhdrActShiftTime" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, Time %>"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblgvActShiftTime" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ActShiftTime").ToString()%>'></asp:Label>
                            </ItemTemplate>
                            <FooterStyle Width="200px" />
                            <HeaderStyle Width="200px" />
                            <ItemStyle Width="200px" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <asp:Label EnableViewState="false" ID="lblErrorMsg" Text="" runat="server" CssClass="csslblErrMsg"></asp:Label>
        </ContentTemplate>
    </Ajax:UpdatePanel>
    <style>
        .mydiv {
            border-top-color: #444444;
            border-top-width: thick;
            border-top-style: solid;
            box-shadow: 0 1px 4px rgba(0, 0, 0, 0.3), 0 0 40px rgba(0, 0, 0, 0.1) inset;
            height: 100px;
            margin: 10px;
            width: 30%;
            float: left;

            padding: 4px;Border-radius: 6px;
        }
    </style>
</asp:Content>

