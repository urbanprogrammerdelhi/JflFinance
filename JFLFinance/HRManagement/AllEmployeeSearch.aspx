<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="AllEmployeeSearch.aspx.cs" EnableEventValidation="false" Inherits="HRManagement_AllEmployeeSearch"
    Title="<%$Resources:Resource,SearchEmployee %>" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <Ajax:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel Width="950px" ID="Panel1" Font-Bold="true" ForeColor="red" Height="450px"
                GroupingText="<%$Resources:Resource,SearchEmployee %>" runat="server" ScrollBars="none">
                <table align="center" width="950px" border="0px" cellspacing="0px" cellpadding="0px">
                    <tr>
                        <td style="width: 120px" align="left">
                            <asp:Label ID="lblEmployeeNo" runat="server" CssClass="cssLabel" Text="<%$Resources:Resource,EmployeeNumber %>"></asp:Label>
                        </td>
                        <td style="width: 120px" align="left">
                            <asp:DropDownList ID="ddlEmpNoOP" runat="server" CssClass="cssDropDown">
                                <asp:ListItem Text="<%$Resources:Resource,ExactSame %>" Value="Like"></asp:ListItem>
                                <asp:ListItem Text="<%$Resources:Resource,Apart %>" Value="%Like%"></asp:ListItem>
                                <asp:ListItem Text="<%$Resources:Resource,StartWith %>" Value="Like%"></asp:ListItem>
                                <asp:ListItem Text="<%$Resources:Resource,ExactSame %>" Value="%Like"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="width: 200px" align="left">
                            <asp:TextBox ID="txtEmpNo" runat="server" CssClass="csstxtbox"></asp:TextBox>
                        </td>
                        <td style="width: 20px">
                            &nbsp;
                        </td>
                        <td align="left" style="width: 100px">
                            <asp:Label ID="lblEmpName" runat="server" CssClass="cssLabel" Text="<%$Resources:Resource,EmployeeName %>"></asp:Label>
                        </td>
                        <td style="width: 100px" align="left">
                            <asp:DropDownList ID="ddlEmployeeNameOP" runat="server" CssClass="cssDropDown">
                                <asp:ListItem Text="<%$Resources:Resource,Apart %>" Value="%Like%"></asp:ListItem>
                                <asp:ListItem Text="<%$Resources:Resource,ExactSame %>" Value="Like"></asp:ListItem>
                                <asp:ListItem Text="<%$Resources:Resource,StartWith %>" Value="Like%"></asp:ListItem>
                                <asp:ListItem Text="<%$Resources:Resource,ExactSame %>" Value="%Like"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtEmployeeName" runat="server" CssClass="csstxtbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="lblEmpDesignation" runat="server" CssClass="cssLabel" Text="<%$Resources:Resource,Designation %>"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlDesignationOP" runat="server" CssClass="cssDropDown">
                                <asp:ListItem Text="<%$Resources:Resource,Apart %>" Value="%Like%"></asp:ListItem>
                                <asp:ListItem Text="<%$Resources:Resource,ExactSame %>" Value="Like"></asp:ListItem>
                                <asp:ListItem Text="<%$Resources:Resource,StartWith %>" Value="Like%"></asp:ListItem>
                                <asp:ListItem Text="<%$Resources:Resource,EndWith %>" Value="%Like"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtEmpDesignation" runat="server" CssClass="csstxtbox"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td align="left">
                            <asp:Label ID="lblDateOfJoining" runat="server" CssClass="cssLabel" Text="<%$Resources:Resource,DateOfJoining %>"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtDateOfJoining" runat="server" CssClass="csstxtbox" Enabled="false"
                                Width="62px"></asp:TextBox>
                            <asp:HyperLink ID="ImgDateOfJoin" Style="vertical-align: middle;" runat="server"
                                ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                            <AjaxToolKit:CalendarExtender ID="CalendarExtender1" Format="dd-MMM-yyyy" runat="server"
                                TargetControlID="txtDateOfJoining" PopupButtonID="ImgDateOfJoin">
                            </AjaxToolKit:CalendarExtender>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:DropDownList ID="ddlIDType" runat="server" CssClass="cssDropDown" Width="120px">
                            </asp:DropDownList>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlIDTypeOP" runat="server" CssClass="cssDropDown" AutoPostBack="true"
                                OnSelectedIndexChanged="ddlIDTypeOP_SelectedIndexChanged">
                                <asp:ListItem Text="<%$Resources:Resource,Apart %>" Value="%Like%"></asp:ListItem>
                                <asp:ListItem Text="<%$Resources:Resource,ExactSame %>" Value="Like"></asp:ListItem>
                                <asp:ListItem Text="<%$Resources:Resource,StartWith %>" Value="Like%"></asp:ListItem>
                                <asp:ListItem Text="<%$Resources:Resource,ExactSame %>" Value="%Like"></asp:ListItem>
                                <asp:ListItem Text="<%$Resources:Resource,DateOfIssue %>" Value="IssueDate"></asp:ListItem>
                                <asp:ListItem Text="<%$Resources:Resource,IssueDateBetween %>" Value="IssueDateBetween"></asp:ListItem>
                                <asp:ListItem Text="<%$Resources:Resource,DateOfExpiry %>" Value="ExpiryDate"></asp:ListItem>
                                <asp:ListItem Text="<%$Resources:Resource,ExpiryDateBetween %>" Value="ExpiryDateBetween"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtIDType" runat="server" CssClass="csstxtbox"></asp:TextBox>
                            <asp:TextBox ID="txtStartDate" Visible="false" runat="server" CssClass="csstxtbox"
                                Enabled="false" Width="62px"></asp:TextBox>
                            <asp:HyperLink ID="ImgStartDate" Style="vertical-align: middle;" runat="server" Visible="false"
                                ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                            <AjaxToolKit:CalendarExtender ID="CalendarExtender2" Format="dd-MMM-yyyy" runat="server"
                                TargetControlID="txtStartDate" PopupButtonID="ImgStartDate">
                            </AjaxToolKit:CalendarExtender>
                            <asp:TextBox ID="txtEndDate" Visible="false" runat="server" CssClass="csstxtbox"
                                Enabled="false" Width="62px"></asp:TextBox>
                            <asp:HyperLink ID="ImgEndDate" Style="vertical-align: middle;" runat="server" Visible="false"
                                ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                            <AjaxToolKit:CalendarExtender ID="CalendarExtender3" Format="dd-MMM-yyyy" runat="server"
                                TargetControlID="txtEndDate" PopupButtonID="ImgEndDate">
                            </AjaxToolKit:CalendarExtender>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td align="left">
                            <asp:Label ID="lblHrLocation" runat="server" CssClass="cssLabel" Text="<%$Resources:Resource,HrLocation %>"></asp:Label>
                        </td>
                        <td colspan="2" align="left">
                            <asp:DropDownList ID="ddlDivision" runat="server" CssClass="cssDropDown" Width="160px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" align="right">
                            <asp:Button ID="btnSearch" runat="server" CssClass="cssButton" Text="<%$Resources:Resource,Search %>"
                                OnClick="btnSearch_Click" />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td colspan="3" align="left">
                            <asp:Button ID="btnViewAll" runat="server" CssClass="cssButton" Text="<%$Resources:Resource,ViewAll %>"
                                OnClick="btnViewAll_Click" />
                        </td>
                    </tr>
                </table>
                <table width="950px" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td align="left">
                            <Ajax:UpdatePanel runat="server" ID="UpdatePanel2" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:Panel ID="p1" runat="server" Style="width: 948px; height: 320px" ScrollBars="Auto">
                                        <asp:GridView ID="gvEmployeeList" runat="server" CssClass="GridViewStyle" ShowFooter="false"
                                            AllowPaging="true" PageSize="15" ShowHeader="true" CellPadding="1" GridLines="None"
                                            OnPageIndexChanging="gvEmployeeList_PageIndexChanging" AutoGenerateColumns="False"
                                            OnRowDataBound="gvEmployeeList_RowDataBound" OnRowCommand="gvEmployeeList_RowCommand"
                                            OnSelectedIndexChanged="gvEmployeeList_SelectedIndexChanged">
                                            <RowStyle CssClass="GridViewRowStyle" />
                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                                            <Columns>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvhdrSerialNo" CssClass="cssLabelHeader" runat="server" Text="<%$Resources:Resource,SerialNumber %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSerialNo" CssClass="cssLabel" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvhdrEmpNo" CssClass="cssLabelHeader" runat="server" Text="<%$Resources:Resource,EmployeeNumber %>"></asp:Label>
                                                        <asp:ImageButton ID="ImgSortEmpNoA" runat="server" ImageUrl="~/Images/collapse.gif"
                                                            Style="height: 14px" CommandName="EmpNoASC" />
                                                        <asp:ImageButton ID="ImgSortEmpNoD" runat="server" Visible="false" ImageUrl="~/Images/expand.gif"
                                                            CommandName="EmpNoDESC" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEmpNo" Width="55px" CssClass="cssLabel" runat="server" Text='<%# Eval("EmployeeNumber") %>'
                                                            ToolTip="<%$Resources:Resource,EmployeeNumber %>"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvhdrEmpStatus" CssClass="cssLabelHeader" runat="server" Text="<%$Resources:Resource,status %>"></asp:Label>
                                                        <asp:ImageButton ID="ImgSortEmpStatusA" runat="server" ImageUrl="~/Images/collapse.gif"
                                                            Style="height: 14px" CommandName="EmpStatusASC" />
                                                        <asp:ImageButton ID="ImgSortEmpStatusD" runat="server" Visible="false" ImageUrl="~/Images/expand.gif"
                                                            CommandName="EmpStatusDESC" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEmpNoStatus" Width="60px" CssClass="cssLabel" runat="server" Text='<%# Eval("EmpStatus") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvhdrEmpName" CssClass="cssLabelHeader" runat="server" Text="<%$Resources:Resource,EmployeeName %>"></asp:Label>
                                                        <asp:ImageButton ID="ImgSortEmpNameA" runat="server" ImageUrl="~/Images/collapse.gif"
                                                            Style="height: 14px" CommandName="ASC" />
                                                        <asp:ImageButton ID="ImgSortEmpNameD" runat="server" Visible="false" ImageUrl="~/Images/expand.gif"
                                                            CommandName="DESC" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEmpName" Width="190px" CssClass="cssLabel" runat="server" Text='<%# Eval("EmployeeName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvhdrEmpDesg" CssClass="cssLabelHeader" runat="server" Text="<%$Resources:Resource,Designation %>"></asp:Label>
                                                        <asp:ImageButton ID="ImgSortEmpDesgA" runat="server" ImageUrl="~/Images/collapse.gif"
                                                            Style="height: 14px" CommandName="EmpDesgASC" />
                                                        <asp:ImageButton ID="ImgSortEmpDesgD" runat="server" Visible="false" ImageUrl="~/Images/expand.gif"
                                                            CommandName="EmpDesgDESC" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEmpDesg" Width="140px" CssClass="cssLabel" runat="server" Text='<%# Eval("DesignationDesc") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvhdrDateOfjoin" CssClass="cssLabelHeader" runat="server" Text="<%$Resources:Resource,DateOfJoining %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDateOfjoin" Width="80px" CssClass="cssLabel" runat="server" Text='<%# String.Format("{0:d-MMM-yyyy}",Eval("DateOfJoining")) %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvhdrDOB" CssClass="cssLabelHeader" runat="server" Text="<%$Resources:Resource,DateOfBirth %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDateOfBirth" CssClass="cssLabel" runat="server" Text='<%# String.Format("{0:d-MMM-yyyy}",Eval("DateOfBirth")) %>'
                                                            Width="80px"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvhdrEmpLocation" CssClass="cssLabelHeader" runat="server" Text="<%$Resources:Resource,Location %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEmpLocation" Width="70px" CssClass="cssLabel" runat="server" Text='<%# Eval("LocationCode") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvhdrIdType" CssClass="cssLabelHeader" runat="server" Text="<%$Resources:Resource,IDType %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblIdType" Width="110px" CssClass="cssLabel" runat="server" Text='<%# Eval("IdType") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvhdrIdTypeValue" CssClass="cssLabelHeader" runat="server" Text="<%$Resources:Resource,Value %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblIdNumber" Width="110px" CssClass="cssLabel" runat="server" Text='<%# Eval("IdNumber") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvhdrDateOfIssue" CssClass="cssLabelHeader" runat="server" Text='<%$Resources:Resource,DateOfIssue %>'></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDateOfIssue" Width="80px" CssClass="cssLabel" runat="server" Text='<%# String.Format("{0:d-MMM-yyyy}",Eval("DateOfIssue")) %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvhdrDateOfExpire" CssClass="cssLabelHeader" runat="server" Text='<%$Resources:Resource,DateOfExpiry %>'></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDateOfExpire" Width="80px" CssClass="cssLabel" runat="server" Text='<%# String.Format("{0:d-MMM-yyyy}", Eval("DateOfExpiry")) %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </asp:Panel>
                                    <table width="100%">
                                        <tr>
                                            <td>
                                                <asp:GridView ID="gvEmpInfo" runat="server" Width="950px" CssClass="GridViewStyle" ShowFooter="false"
                                                    AllowPaging="true" PageSize="15" ShowHeader="true" CellPadding="1" GridLines="None"
                                                    AutoGenerateColumns="False">
                                                    <RowStyle CssClass="GridViewRowStyle" />
                                                    <PagerStyle CssClass="GridViewPagerStyle" />
                                                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblgvhdrSerialNo" CssClass="cssLabelHeader" runat="server" Text="<%$Resources:Resource,SerialNumber %>"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSerialNo" CssClass="cssLabel" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblgvhdrEmpNo" CssClass="cssLabelHeader" runat="server" Text="<%$Resources:Resource,EmployeeNumber %>"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblEmpNo" Width="55px" CssClass="cssLabel" runat="server" Text='<%# Eval("EmployeeNumber") %>'
                                                                    ToolTip="<%$Resources:Resource,EmployeeNumber %>"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblgvhdrEmpStatus" CssClass="cssLabelHeader" runat="server" Text="<%$Resources:Resource,DutyDate %>"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDutyDate" Width="60px" CssClass="cssLabel" runat="server" Text='<%# string.Format("{0:dd-MMM-yyyy}",Eval("DutyDate")) %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblgvhdrEmpName" CssClass="cssLabelHeader" runat="server" Text="<%$Resources:Resource,AsmtCode %>"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblAsmtCode" Width="190px" CssClass="cssLabel" runat="server" Text='<%# Eval("AsmtCode") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblgvhdrEmpDesg" CssClass="cssLabelHeader" runat="server" Text="<%$Resources:Resource,ClientCode %>"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblClientCode" Width="140px" CssClass="cssLabel" runat="server" Text='<%# Eval("ClientCode") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                         <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblgvhdrEmpDesg" CssClass="cssLabelHeader" runat="server" Text="<%$Resources:Resource,ClientName %>"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblClientName" Width="140px" CssClass="cssLabel" runat="server" Text='<%# Eval("ClientName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:Label EnableViewState="false" ID="lblErrorMsg" Text="" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                </ContentTemplate>
                            </Ajax:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </ContentTemplate>
    </Ajax:UpdatePanel>
</asp:Content>
