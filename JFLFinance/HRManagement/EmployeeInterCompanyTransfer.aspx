<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="EmployeeInterCompanyTransfer.aspx.cs" Inherits="HRManagement_EmployeeInterCompanyTransfer"
    Title="<%$ Resources:Resource, AppTitle %>" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td colspan="4" align="center">
                <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table width="100%" border="0">
                            <tr>
                                <td align="right">
                                    <asp:Label runat="server" ID="lblArea" Text="<%$Resources:Resource,Area %>" CssClass="cssLabel"></asp:Label>
                                </td>
                                <td align="left" style="width:180px;">
                                    <asp:DropDownList runat="server" ID="ddlAreaID" CssClass="cssDropDown" AutoPostBack="true"
                                        Width="180px" OnSelectedIndexChanged="ddlAreaID_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td align="right">
                                    <asp:DropDownList AutoPostBack="true" ID="ddlSearchBy" Width="180px" runat="server"
                                        CssClass="cssDropDown">
                                    </asp:DropDownList>
                                </td>
                                <td align="left"  style="width:180px;">
                                    <asp:TextBox ID="txtSearch" Visible="false" Width="150px" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                    <asp:TextBox ID="txtSearchDate" Visible="false" Width="150px" CssClass="csstxtbox"
                                        runat="server"></asp:TextBox>
                                    <asp:HyperLink ID="imgSearchGrid" Style="vertical-align: middle;" Visible="false"
                                        runat="server" ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                                    <asp:HiddenField ID="hfSearchText" runat="server" />
                                </td>
                                <td align="left">
                                    <asp:Button ID="Button1" CssClass="cssButton" runat="server" Text="<%$Resources:Resource,Search %>"
                                        OnClick="btnSearch_Click" />
                                </td>
                                <td align="left">
                                    <asp:Button ID="btnViewAll" Visible="false" CssClass="cssButton" runat="server" Text="<%$Resources:Resource,ViewAll %>"
                                        OnClick="btnViewAll_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label runat="server" CssClass="cssLabel" ID="Label1" Text="<%$Resources:Resource,View %>"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList runat="server" ID="ddlEmployeeGetType" CssClass="cssDropDown" AutoPostBack="true"
                                        Width="180px" OnSelectedIndexChanged="ddlEmployeeGetType_SelectedIndexChanged">
                                        <asp:ListItem Text="<%$Resources:Resource,LastAmendment %>" Value="L" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="<%$Resources:Resource,AsOnDate %>" Value="A"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtAsOnDate" Visible="false" Width="160px" CssClass="csstxtbox"
                                        runat="server" Enabled="False"></asp:TextBox> <%--Added Enabled="False" By  on 3-Nov-2014 Bug #1615--%> 
                                    <asp:HyperLink ID="HLAsOnDate" Style="vertical-align: middle;" runat="server" ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                                    <AjaxToolKit:CalendarExtender ID="CalendarExtender2" Format="dd-MMM-yyyy" runat="server"
                                        TargetControlID="txtAsOnDate" PopupButtonID="HLAsOnDate">
                                    </AjaxToolKit:CalendarExtender>
                                     <asp:Button ID="btnGetEmployeeBasedOnStatus" CssClass="cssButton" runat="server"
                                        Text="<%$Resources:Resource,ViewDetails %>" OnClick="btnGetEmployeeBasedOnStatus_Click" />
                                </td>
                            </tr>
                        </table>
                        <table border="0" width="100%" cellpadding="3" cellspacing="0">
                            <tr>
                                <td>
                                    <asp:Panel ID="Panel1" BorderWidth="1px" runat="server" Width="100%" Height="480px"
                                        ScrollBars="Horizontal" CssClass="ScrollBar">
                                        <asp:GridView ID="gvEmpInterCompanyTransfer" Width="100%" PageSize="12" CssClass="GridViewStyle"
                                            runat="server" AllowPaging="True" CellPadding="1" GridLines="None" AutoGenerateColumns="False"
                                            OnRowDataBound="gvEmpInterCompanyTransfer_RowDataBound" OnPageIndexChanging="gvEmpInterCompanyTransfer_PageIndexChanging">
                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                            <RowStyle CssClass="GridViewRowStyle" />
                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource, Sno %>" HeaderStyle-Width="20px"
                                                    FooterStyle-Width="20px" ItemStyle-Width="20px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSerialNo" CssClass="cssLable" Width="35px" runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle CssClass="cssLabelHeader" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,EmployeeNumber %>" HeaderStyle-Width="60px"
                                                    FooterStyle-Width="60px" ItemStyle-Width="60px">
                                                    <ItemTemplate>
                                                        <%--<asp:Label ID="Label2" runat="server" Text='<%# Bind("EmployeeNumber") %>'></asp:Label>--%>
                                                        <asp:Label ID="lblEmployeeNumber" CssClass="cssLable" runat="server" Text='<%# Bind("EmployeeNumber") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle CssClass="cssLabelHeader" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource, EmployeeName %>" HeaderStyle-Width="200px"
                                                    FooterStyle-Width="200px" ItemStyle-Width="200px">
                                                    <ItemTemplate>
                                                        <%--<asp:Label ID="Label3" runat="server" Text='<%# Bind("EmployeeName") %>'></asp:Label>--%>
                                                        <asp:Label ID="lblEmployeeName" CssClass="cssLable" runat="server" Text='<%# Bind("EmployeeName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle CssClass="cssLabelHeader" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,CompanyDescription %>" HeaderStyle-Width="250px"
                                                    FooterStyle-Width="250px" Visible="false" ItemStyle-Width="250px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCompanyDesc" CssClass="cssLable" runat="server" Text='<%# Bind("CompanyDesc") %>'></asp:Label>
                                                        <%--<asp:Label ID="Label4" runat="server" Text='<%# Bind("CompanyDesc") %>'></asp:Label>--%>
                                                        <asp:Label ID="lblCompanyCode" Visible="false" runat="server" Text='<%# Bind("CompanyCode") %>'></asp:Label>
                                                        <asp:Label ID="lblLocationAutoID" Visible="false" runat="server" Text='<%# Bind("LocationAutoID") %>'></asp:Label>
                                                        <asp:Label ID="lblCompEffectiveFrom" runat="server" Text='<%# Bind("HrEmpCompEffectiveFrom") %>'
                                                            Visible="false"></asp:Label><br />
                                                    </ItemTemplate>
                                                    <HeaderStyle CssClass="cssLabelHeader" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,HrLocation %>" HeaderStyle-Width="100px"
                                                    FooterStyle-Width="100px" ItemStyle-Width="100px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblHrLocationDesc" CssClass="cssLable" runat="server" Text='<%# Bind("HrLocationDesc") %>'></asp:Label>
                                                        <asp:Label ID="lblHrLocationCode" Visible="false" runat="server" Text='<%# Bind("HrLocationCode") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle CssClass="cssLabelHeader" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,Location %>" HeaderStyle-Width="100px"
                                                    FooterStyle-Width="100px" ItemStyle-Width="100px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblLocationDesc" CssClass="cssLable" runat="server" Text='<%# Bind("LocationDesc") %>'></asp:Label>
                                                        <asp:Label ID="lblLocationCode" Visible="false" runat="server" Text='<%# Bind("LocationCode") %>'></asp:Label>
                                                        <asp:Label ID="lbllocationEffectiveFrom" runat="server" Text='<%# Bind("EmpLocationEffectiveFrom") %>'
                                                            Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle CssClass="cssLabelHeader" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,Designation %>" HeaderStyle-Width="100px"
                                                    FooterStyle-Width="100px" ItemStyle-Width="100px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDesignationDesc" CssClass="cssLable" runat="server" Text='<%# Bind("DesignationDesc") %>'></asp:Label>
                                                        <asp:Label ID="lblDesignationCode" Visible="false" runat="server" Text='<%# Bind("DesignationCode") %>'></asp:Label>
                                                        <asp:Label ID="lblDesiEffectiveFrom" runat="server" Text='<%# Bind("HrEmpDesigEffectiveFrom") %>'
                                                            Visible="false"></asp:Label>
                                                        <asp:Label ID="lblJobClassCode" Visible="false" runat="server" Text='<%# Bind("JobClassCode") %>'></asp:Label>
                                                        <asp:Label ID="lblJobTypeCode" Visible="false" runat="server" Text='<%# Bind("JobTypeCode") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle CssClass="cssLabelHeader" />
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="<%$ Resources:Resource,Grade %>" HeaderStyle-Width="100px"
                                                    FooterStyle-Width="100px" ItemStyle-Width="100px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGradeDesc" CssClass="cssLable" runat="server" Text='<%# Bind("GradeDesc") %>'></asp:Label>
                                                        <asp:Label ID="lblGradeCode" Visible="false" runat="server" Text='<%# Bind("GradeCode") %>'></asp:Label>
                                                        <asp:Label ID="lblGradeEffectiveFrom" runat="server" Text='<%# Bind("HrEmpGradeEffectiveFrom") %>'
                                                            Visible="false"></asp:Label>
                                                      
                                                    </ItemTemplate>
                                                    <HeaderStyle CssClass="cssLabelHeader" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,Category %>" HeaderStyle-Width="100px"
                                                    FooterStyle-Width="100px" ItemStyle-Width="100px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCategoryDesc" CssClass="cssLable" runat="server" Text='<%# Bind("CategoryDesc") %>'></asp:Label>
                                                        <asp:Label ID="lblCategoryCode" Visible="false" runat="server" Text='<%# Bind("CategoryCode") %>'></asp:Label>
                                                        <asp:Label ID="lblCatEffectiveFrom" runat="server" Text='<%# Bind("HrEmpCatEffectiveFrom") %>'
                                                            Visible="false"></asp:Label>
                                                        <asp:Label ID="lblEmpJobTypeEffectiveFrom" runat="server" Text='<%# Bind("HrEmpJobTypeEffectiveFrom") %>'
                                                            Visible="false"></asp:Label>
                                                        <asp:Label ID="lblEmpJobClassEffectiveFrom" runat="server" Text='<%# Bind("HrEmpJobClassEffectiveFrom") %>'
                                                            Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle CssClass="cssLabelHeader" />
                                                </asp:TemplateField>
                                                
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,Department %>" HeaderStyle-Width="100px"
                                                    FooterStyle-Width="100px" ItemStyle-Width="100px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDepDesc" CssClass="cssLable" runat="server" Text='<%# Bind("DepartmentName") %>'></asp:Label>
                                                        <asp:Label ID="lblDepCode" Visible="false" runat="server" Text='<%# Bind("DepartmentCode") %>'></asp:Label>
                                                        <asp:Label ID="lblDepEffectiveFrom" runat="server" Text='<%# Bind("HrEmpDepEffectiveFrom") %>'
                                                            Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle CssClass="cssLabelHeader" />
                                                </asp:TemplateField>


                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,AreaID %>" HeaderStyle-Width="100px"
                                                    FooterStyle-Width="100px" ItemStyle-Width="100px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAreaDesc" CssClass="cssLable" runat="server" Text='<%# Bind("AreaDesc") %>'></asp:Label>
                                                        <asp:Label ID="lblAreaID" Visible="false" runat="server" Text='<%# Bind("AreaID") %>'></asp:Label>
                                                        <asp:Label ID="lblAreaEffectiveFrom" runat="server" Text='<%# Bind("HrEmpAreaEffectiveFrom") %>'
                                                            Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle CssClass="cssLabelHeader" />
                                                </asp:TemplateField>
                                                
                                                
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,EditColName %>">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="IBEditTran" ToolTip="<%$ Resources:Resource,Edit %>" ImageUrl="~/Images/Edit.gif"
                                                            CssClass="csslnkButton" runat="server" CausesValidation="False" OnClick="IBEditTran_Click" />
                                                    </ItemTemplate>
                                                    <FooterStyle Width="50px" />
                                                    <HeaderStyle Width="50px" CssClass="cssLabelHeader" />
                                                    <ItemStyle Width="50px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$Resources:Resource,Correction %>">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="IBCorrect" ToolTip="<%$ Resources:Resource,Correction %>" ImageUrl="~/Images/Edit.gif"
                                                            CssClass="csslnkButton" runat="server" CausesValidation="False" OnClick="IBCorrect_Click" />
                                                    </ItemTemplate>
                                                    <FooterStyle Width="50px" />
                                                    <HeaderStyle Width="50px" CssClass="cssLabelHeader" />
                                                    <ItemStyle Width="50px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Roll Back" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="IBRollBack" ToolTip="<%$ Resources:Resource,Edit %>" ImageUrl="~/Images/Edit.gif"
                                                            CssClass="csslnkButton" runat="server" CausesValidation="False" OnClick="IBRollBack_Click" />
                                                    </ItemTemplate>
                                                    <FooterStyle Width="50px" />
                                                    <HeaderStyle Width="50px" CssClass="cssLabelHeader" />
                                                    <ItemStyle Width="50px" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                        <%-- <asp:MultiView ID="MultiViewFutureDetails" runat="server">
                            <asp:View ID="ViewFutureDetails" runat="Server">
                                <table border="0px" width="100%" style="text-align: right;">
                                    <tr>
                                        <td>
                                            <asp:ImageButton ID="imgBack" runat="server" ImageUrl="../Images/go_Back.gif" ToolTip="<%$ Resources:Resource, Home %>"
                                                OnClick="imgBack_Click" />
                                        </td>
                                    </tr>
                                </table>
                              
                            </asp:View>
                        </asp:MultiView>--%>
                    </ContentTemplate>
                </Ajax:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
