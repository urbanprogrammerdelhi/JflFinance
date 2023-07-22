<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="EmployeeDetail.aspx.cs" Inherits="HRManagement_EmployeeDetail" Title="<%$ Resources:Resource, AppTitle %>" %>

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
                                        CssClass="cssDropDown" OnSelectedIndexChanged="ddlSearchBy_SelectedIndexChanged">
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
                                    <asp:LinkButton ID="lbtnAddNew" runat="server" Text="<%$Resources:Resource,AddNew %>"
                                        CssClass="cssLable" Style="font-weight: bold; font-size: 16px;" OnClick="lbAddNew_Click"></asp:LinkButton>
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
                        <table border="0" width="100%" cellpadding="1" cellspacing="0">
                            <tr>
                                <td>
                                    <asp:Panel ID="Panel1" BorderWidth="1px" runat="server" Width="100%" Height="430px"
                                        ScrollBars="Auto" CssClass="ScrollBar">
                                        <asp:GridView ID="gvEmployeeDetail" PageSize="14" Width="100%" runat="server" AllowPaging="True"
                                            AutoGenerateColumns="False" CellPadding="1" CssClass="GridViewStyle" OnRowCommand="gvEmployeeDetail_RowCommand"
                                            OnDataBound="gvEmployeeDetail_DataBound" OnRowDataBound="gvEmployeeDetail_RowDataBound"
                                            OnPageIndexChanging="gvEmployeeDetail_PageIndexChanging">
                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                            <RowStyle CssClass="GridViewRowStyle" />
                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource ,EmployeeNumber %>">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lblEmployeeNumber" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EmployeeNumber").ToString()%>'
                                                            OnClick="lblEmployeeNumber_Click"></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="70px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,FirstName %>">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblFirstName" CssClass="cssLabel" Width="100px" runat="server" Text='<%# Bind("FirstName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="80px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,LastName %>">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label2" CssClass="cssLabel" Width="170px" runat="server" Text='<%# Bind("LastName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="170px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource ,DesignationDescription %>">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDesignationDesc" CssClass="cssLabel" Width="120px" runat="server"
                                                            Text='<%# Bind("DesignationDesc") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="120" />
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="<%$ Resources:Resource ,Grade %>">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGradeDesc" CssClass="cssLabel" Width="120px" runat="server"
                                                            Text='<%# Bind("GradeDesc") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="120" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource ,CategoryDescription %>">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCategoryDesc" CssClass="cssLabel" runat="server" Width="80" Text='<%# Bind("CategoryDesc") %>'></asp:Label>
                                                        <asp:Label ID="lblCategoryCode" Visible="false" runat="server" Text='<%# Bind("CategoryCode") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="80" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,JoiningDate %>">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDateOfJoining" CssClass="cssLabel" Width="85px" runat="server"
                                                            Text='<%#String.Format("{0:d-MMM-yyyy}",Eval("DateOfJoining")) %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="85px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,ReHireDate %>">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblReHireDate" CssClass="cssLabel" Width="85px" runat="server" Text='<%#String.Format("{0:d-MMM-yyyy}",Eval("ReHireDate")) %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="85px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,status %>">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEmpStatus" CssClass="cssLabel" Width="60px" runat="server" Text='<%# Bind("EmpStatus") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="60px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$Resources:Resource,TerminateEmployee %>">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="lbTerminateEmployee" ToolTip="<%$Resources:Resource,TerminateEmployee %>"
                                                            OnClick="lbTerminateEmployee_Click" ImageUrl="~/Images/TerminateEmp.gif" CausesValidation="False"
                                                            runat="server" CommandName="TerminateEmployee" Visible="false" />
                                                        <asp:CheckBox ID="chkTerminateEmployee" AutoPostBack="true" runat="server" OnCheckedChanged="OnCheckedChanged_chkTerminateEmployee" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <PagerTemplate>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/firstpage.gif"
                                                                CommandArgument="First" CommandName="Page" />
                                                            <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/prevpage.gif"
                                                                CommandArgument="Prev" CommandName="Page" />
                                                            <asp:Label ID="lblpage" ForeColor="Black" runat="server" Text="<%$Resources:Resource,Page %>"></asp:Label>
                                                            <asp:DropDownList ID="ddlPages" CssClass="cssDropDown" runat="server" AutoPostBack="True"
                                                                OnSelectedIndexChanged="ddlPages_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                            <asp:Label ID="lblOf" ForeColor="Black" runat="server" Text="<%$Resources:Resource,Of %>"></asp:Label>
                                                            <asp:Label ID="lblPageCount" ForeColor="Black" runat="server"></asp:Label>
                                                            <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Images/nextpage.gif"
                                                                CommandArgument="Next" CommandName="Page" />
                                                            <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/Images/lastpage.gif"
                                                                CommandArgument="Last" CommandName="Page" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </PagerTemplate>
                                        </asp:GridView>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </Ajax:UpdatePanel>
                <asp:Button ID="lbAddNew" CssClass="cssButton" runat="server" Text="<%$Resources:Resource,AddNew %>"
                    OnClick="lbAddNew_Click" />
                <asp:Button ID="lbReHire" CssClass="cssButton" runat="server" Text="<%$Resources:Resource,EmployeeReHire %>"
                    OnClick="lbReHire_Click" />
                <asp:Button ID="btnBulkTermination" runat="server" CssClass="cssButton" Text="Terminate"
                    OnClick="btnBulkTermination_Click" Visible="true" />
                <asp:Panel ID="Panel6" BackColor="white" ScrollBars="none" CssClass="ScrollBar" runat="server"
                    Visible="false" Height="400" Width="750" Style="border: 1px; border-style: solid;
                    border-color: Red">
                    <asp:Button ID="btn1" runat="server" Style="display: none" />
                    <AjaxToolKit:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="btn1"
                        PopupControlID="Panel6" BackgroundCssClass="modalBackground" />
                    <Ajax:UpdatePanel runat="server" ID="UpdatePanel2" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div id="Div1" runat="server">
                                <table>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label5" runat="server" Text="<%$Resources:Resource,Reason %>"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlReason" CssClass="cssDropDown" Width="180px" runat="server"
                                                AutoPostBack="True" OnSelectedIndexChanged="ddlReason_SelectedIndexChanged">
                                                <asp:ListItem Selected="True" Text="<%$Resources:Resource,Employer%>" Value="<%$Resources:Resource,Employer%>"></asp:ListItem>
                                                <asp:ListItem Text="<%$Resources:Resource,Employee%>" Value="<%$Resources:Resource,Employee%>"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label7" runat="server" Text="<%$Resources:Resource,TerminationReason %>"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlTerminationReason" CssClass="cssDropDown" Width="180px"
                                                runat="server">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label9" runat="server" Text="<%$Resources:Resource, TerminationDate%>"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtResignationDate" CssClass="csstxtbox" runat="server" Width="180px"
                                                ValidationGroup="TerminateEmployee" Style="width: 80px;" AutoPostBack="true"
                                                Text=""></asp:TextBox>
                                            <asp:HyperLink ID="ImgResignationDate" Style="vertical-align: middle;" runat="server"
                                                ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                                            <AjaxToolKit:CalendarExtender ID="CalendarExtender1" Format="dd-MMM-yyyy" runat="server"
                                                TargetControlID="txtResignationDate" PopupButtonID="ImgResignationDate">
                                            </AjaxToolKit:CalendarExtender>
                                            <asp:RequiredFieldValidator ID="RFVResignationDate" ValidationGroup="TerminateEmployee"
                                                Display="Dynamic" ControlToValidate="txtResignationDate" runat="server" ErrorMessage=""
                                                Text="*" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label11" runat="server" Text="<%$Resources:Resource,Remark %>"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtRemarks" CssClass="csstxtbox" Width="173px" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label12" runat="server" Text="<%$Resources:Resource,SuitableForRehire %>"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlSuitable4ReHire" CssClass="cssDropDown" Width="180px" runat="server">
                                                <asp:ListItem Selected="True" Value="True" Text="<%$Resources:Resource,Yes %>"></asp:ListItem>
                                                <asp:ListItem Value="False" Text="<%$Resources:Resource,No %>"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                                <asp:Label ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg" EnableViewState="true"></asp:Label>
                                <asp:GridView ID="gvErrorMessage" PageSize="5" Width="650px" runat="server" AllowPaging="True"
                                     AutoGenerateColumns="False" CellPadding="1"
                                    CssClass="GridViewStyle" OnPageIndexChanging="gvErrorMessage_PageIndexChanging">
                                    <FooterStyle CssClass="GridViewFooterStyle" />
                                    <RowStyle CssClass="GridViewRowStyle" />
                                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                    <PagerStyle CssClass="GridViewPagerStyle" />
                                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource ,EmployeeNumber %>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblEmployeeNumber_msg" CssClass="cssLable" runat="server" Text='<%# Bind("EmployeeNumber") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle Width="70px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource ,LastTransactionDate %>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTransactiondate_msg" CssClass="cssLable" runat="server" Text='<%#String.Format("{0:d-MMM-yyyy}",Eval("MaxTransactionDate")) %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle Width="70px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource ,TransactionDesc %>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblReason" CssClass="cssLable" runat="server" Text='<%# Bind("MessageString") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle Width="70px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource ,Action %>">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="msgId" runat="server" Value='<%# Bind("MessageId") %>' />
                                                <asp:LinkButton ID="btnAction" CssClass="cssLable" runat="server" OnClick="btnAction_OnClick"
                                                    Text='<%# Bind("comment")  %>'></asp:LinkButton>
                                            </ItemTemplate>
                                            <HeaderStyle Width="70px" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <asp:Button ID="btnApply" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource ,Apply %>"
                                    OnClick="btnApply_Click" ValidationGroup="TerminateEmployee" />
                                <asp:Button ID="btnClose" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource ,Close %>"
                                    OnClick="btnClose_Click" />
                            </div>
                            <asp:Label ID="lblErrorMsg1" runat="server" CssClass="csslblErrMsg" EnableViewState="False"></asp:Label>
                        </ContentTemplate>
                    </Ajax:UpdatePanel>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>
