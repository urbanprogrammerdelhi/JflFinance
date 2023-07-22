<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="EmployeeReHire.aspx.cs" Inherits="HRManagement_EmployeeReHire" Title="<%$ Resources:Resource, AppTitle %>" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table border="0" width="100%" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <asp:DropDownList AutoPostBack="true" ID="ddlSearchBy" Width="200px" runat="server"
                                        Style="vertical-align: top" CssClass="cssDropDown">
                                    </asp:DropDownList>
                                    <asp:TextBox ID="txtSearch" Width="200px" CssClass="csstxtbox" Style="vertical-align: top"
                                        runat="server"></asp:TextBox>
                                    <asp:Button ID="Button1" CssClass="cssButton" runat="server" Text="<%$Resources:Resource,Search %>"
                                        OnClick="btnSearch_Click" />
                                    <asp:Button ID="btnViewAll" CssClass="cssButton" runat="server" Text="<%$Resources:Resource,ViewAll %>"
                                        OnClick="btnViewAll_Click" />
                                    <img src="../Images/spacer.gif" width="200px" id="imgspace" height="1px" />
                                    <asp:ImageButton ID="imgBack" runat="server" ImageUrl="../Images/go_Back.gif" ToolTip="<%$ Resources:Resource, back %>"
                                        OnClick="imgBack_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:MultiView ID="MultiViewShowDetail" ActiveViewIndex="0" runat="server">
                                        <asp:View ID="ViewShowDetail" runat="server">
                                            <%--<asp:Panel ID="Panel1" BorderWidth="1px" runat="server" Width="100%" Height="450px"
                                                ScrollBars="Auto">--%>
                                                <asp:GridView ID="gvEmployeeReHire" PageSize="15" Width="100%" runat="server" AllowPaging="True"
                                                    AutoGenerateColumns="False" CellPadding="1" CssClass="GridViewStyle" OnRowDataBound="gvEmployeeReHire_RowDataBound"
                                                    OnPageIndexChanging="gvEmployeeReHire_PageIndexChanging">
                                                    <FooterStyle CssClass="GridViewFooterStyle" />
                                                    <RowStyle CssClass="GridViewRowStyle" />
                                                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                    <PagerStyle CssClass="GridViewPagerStyle" />
                                                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="<%$ Resources:Resource ,EmployeeNumber %>">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblEmployeeNumber" CssClass="cssLabel" Width="150px" runat="server"
                                                                    Text='<%# Bind("EmployeeNumber") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="150px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,FirstName %>">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblFirstName" CssClass="cssLabel" Width="160px" runat="server" Text='<%# Bind("FirstName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="160px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,LastName %>">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblLastname" CssClass="cssLabel" Width="160px" runat="server" Text='<%# Bind("LastName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="160px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="<%$ Resources:Resource ,DesignationDescription %>">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDesignationDesc" CssClass="cssLabel" Width="200px" runat="server"
                                                                    Text='<%# Bind("DesignationDesc") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="200px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="<%$ Resources:Resource ,CategoryDescription %>">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCategoryDesc" CssClass="cssLabel" runat="server" Width="200px"
                                                                    Text='<%# Bind("CategoryDesc") %>'></asp:Label>
                                                                <asp:Label ID="lblCategoryCode" Visible="false" runat="server" Text='<%# Bind("CategoryCode") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="200px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="<%$ Resources:Resource ,DepartmentDesc %>">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDepartmentDesc" CssClass="cssLabel" runat="server" Width="200px"
                                                                    Text='<%# Bind("DepartmentName") %>'></asp:Label>
                                                                <asp:Label ID="lblDepartmentCode" Visible="false" runat="server" Text='<%# Bind("DepartmentCode") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="200px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,JoiningDate %>">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDateOfJoining" CssClass="cssLabel" Width="100px" runat="server"
                                                                    Text='<%#String.Format("{0:d-MMM-yyyy}",Eval("DateOfJoining")) %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,ResignationDate %>">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDateOfResignation" CssClass="cssLabel" Width="150px" runat="server"
                                                                    Text='<%#String.Format("{0:d-MMM-yyyy}",Eval("DateOfResignation")) %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="150px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,TerminationReason %>">
                                                            <HeaderStyle Width="280px" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblResignationTerminationStatus" CssClass="cssLabel" Width="280px"
                                                                    runat="server" Text='<%# Bind("ResignationTerminationStatus") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,SuitableForRehire %>">
                                                            <HeaderStyle Width="280px" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSuitableForRehire" CssClass="cssLabel" Width="280px" runat="server"
                                                                    Text='<%# Bind("SuitableForRehire") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="<%$ Resources:Resource ,EditColName %>">
                                                            <ItemTemplate>
                                                                <%--<asp:LinkButton ID="lblSelect" runat="server" CausesValidation="False" CommandName="Select"
                                                                    OnClick="lbSelect_Click" Text="Select"></asp:LinkButton>--%>
                                                                <asp:ImageButton ID="lblSelect" ToolTip="<%$Resources:Resource,Select %>" ImageUrl="~/Images/SelectEmp.Gif"
                                                                    CssClass="csslnkButton" runat="server" CausesValidation="False" CommandName="Select"
                                                                    OnClick="lbSelect_Click" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            <%--</asp:Panel>--%>
                                        </asp:View>
                                    </asp:MultiView>
                                    <asp:MultiView ID="MultiView1" runat="server">
                                        <asp:View ID="View1" runat="server">
                                                    <div class="squareboxgradientcaption" style="height: 20px;">
                                                                <asp:Label ID="Label12" runat="server" Text="<%$Resources:Resource,EmployeeDetail %>"></asp:Label>
                                                    </div>
                                                    <div>
                                                        <table width="100%">
                                                            <tr>
                                                                <td align="right">
                                                                    <asp:Label ID="Label1" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,EmployeeNumber %>"></asp:Label>
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Label ID="lblEmpNumber" CssClass="cssLable" Font-Bold="true" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    <asp:Label ID="Label9" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,FirstName %>"></asp:Label>
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Label ID="lblEmpFirstName" CssClass="cssLable" Font-Bold="true" runat="server"
                                                                        Text=""></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    <asp:Label ID="Label7" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,LastName %>"></asp:Label>
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Label ID="lblEmpLastName" CssClass="cssLable" Font-Bold="true" runat="server"
                                                                        Text=""></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    <asp:Label ID="Label18" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,DesignationDescription %>"></asp:Label>
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Label ID="lblDesignation" CssClass="cssLable" Font-Bold="true" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    <asp:Label ID="Label21" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,CategoryDescription %>"></asp:Label>
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Label ID="lblCategory" CssClass="cssLable" Font-Bold="true" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    <asp:Label ID="Label15" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,Department %>"></asp:Label>
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Label ID="lblDepartment" CssClass="cssLable" Font-Bold="true" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    <asp:Label ID="Label8" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,JoiningDate %>"></asp:Label>
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Label ID="lblEmpDateOfJoining" CssClass="cssLable" Font-Bold="true" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    <asp:Label ID="Label10" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,ResignationDate %>"></asp:Label>
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Label ID="lblEmpDateOfResignation" CssClass="cssLable" Font-Bold="true" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    <asp:Label ID="Label13" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,SuitableForRehire %>"></asp:Label>
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Label ID="lblEmpSuitableForRehire" CssClass="cssLable" Font-Bold="true" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    <asp:Label ID="Label3" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,JoiningDate %>"></asp:Label>
                                                                </td>
                                                                <td valign="middle" align="left">
                                                                    <asp:TextBox ID="txtDateOfJoining" AutoPostBack="true" CssClass="csstxtbox" runat="server"
                                                                        OnTextChanged="txtDateOfJoining_OnTextChanged" Width="90px" Text=""></asp:TextBox>
                                                                    <asp:HyperLink Style="vertical-align: middle;" ID="imgDate" runat="server" ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                                                                    <AjaxToolKit:CalendarExtender ID="CalendarExtender2" Format="dd-MMM-yyyy" runat="server"
                                                                        TargetControlID="txtDateOfJoining" PopupButtonID="imgDate">
                                                                    </AjaxToolKit:CalendarExtender>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <asp:Label ID="lblErrorMsg" EnableViewState="false" CssClass="csslblErrMsg" runat="server"></asp:Label>
                                                    </div>
                                                    <div class="squareboxgradientcaption" style="height: 20px; ">
                                                                <asp:Label ID="Label11" runat="server" Text="<%$Resources:Resource,EmployeeRehire %>"></asp:Label>
                                                    </div>
                                                    <div>
                                                        <table width="100%">
                                                            <tr>
                                                                <td align="right">
                                                                    <asp:Label ID="Label2" CssClass="cssLable" Width="100px" runat="server" Text="<%$ Resources:Resource,Company %>"></asp:Label>
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="ddlCompany" CssClass="cssDropDown" runat="server" Width="250px"
                                                                        AutoPostBack="true" OnSelectedIndexChanged="ddlCompany_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right" style="height: 22px">
                                                                    <asp:Label ID="Label4" CssClass="cssLable" Width="100px" runat="server" Text="<%$ Resources:Resource,HrLocation %>"></asp:Label>
                                                                </td>
                                                                <td align="left" style="height: 22px">
                                                                    <asp:DropDownList ID="ddlHrLocation" CssClass="cssDropDown" Width="250px" runat="server"
                                                                        AutoPostBack="True" OnSelectedIndexChanged="ddlHrLocation_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    <asp:Label ID="Label14" CssClass="cssLable" Width="100px" runat="server" Text="<%$ Resources:Resource,Location %>"></asp:Label>
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="ddlLocation" CssClass="cssDropDown" Width="250px" runat="server"
                                                                        AutoPostBack="True" OnSelectedIndexChanged="ddlLocation_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    <asp:Label ID="Label20" CssClass="cssLable" Width="150px" runat="server" Text="<%$ Resources:Resource,DesignationDescription %>"></asp:Label>
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="ddlDesignation" CssClass="cssDropDown" Width="250px" runat="server"
                                                                        AutoPostBack="True">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    <asp:Label ID="Label24" CssClass="cssLable" Width="150px" runat="server" Text="<%$ Resources:Resource,CategoryDescription %>"></asp:Label>
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="ddlCategory" CssClass="cssDropDown" Width="250px" runat="server"
                                                                        AutoPostBack="True">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    <asp:Label ID="Label16" CssClass="cssLable" Width="150px" runat="server" Text="<%$ Resources:Resource,Department %>"></asp:Label>
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="ddlDepartment" CssClass="cssDropDown" Width="250px" runat="server"
                                                                        AutoPostBack="True">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                             <tr>
                                                                <td align="right">
                                                                    <asp:Label ID="Lbl2AreaID" CssClass="cssLable" runat="server" Width="150px" Text="<%$ Resources:Resource,AreaID %>"></asp:Label>
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="ddlAreaID" CssClass="cssDropDown" Width="250px" runat="server"
                                                                        AutoPostBack="True">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    <asp:Label ID="Label5" CssClass="cssLable" runat="server" Width="150px" Text="<%$ Resources:Resource,JobType %>"></asp:Label>
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="ddlJobType" CssClass="cssDropDown" Width="250px" runat="server"
                                                                        AutoPostBack="True">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    <asp:Label ID="Label6" CssClass="cssLable" runat="server" Width="150px" Text="<%$ Resources:Resource,JobClass %>"></asp:Label>
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="ddlJobClass" CssClass="cssDropDown" Width="250px" runat="server"
                                                                        AutoPostBack="True">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    <asp:Label ID="Label17" CssClass="cssLable" runat="server" Width="150px" Text="<%$Resources:Resource,Role %>"></asp:Label>
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="ddlRole" CssClass="cssDropDown" Width="250px" runat="server">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                           
                                                            <tr>
                                                                <td align="right">
                                                                    <asp:Label ID="lblremark" CssClass="cssLable" runat="server" Width="150px" Text="<%$ Resources:Resource,remark %>"></asp:Label>
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtRemark" runat="server" CssClass="csstxtbox" Width="250px" Rows="2"
                                                                        MaxLength="150"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" align="center">
                                                                    <asp:Button ID="btnUpdate" CssClass="cssButton" ValidationGroup="Update" runat="server"
                                                                        OnClick="btnUpdate_Click" Text="<%$Resources:Resource,Update %>" />
                                                                    <asp:Button ID="btnCancel" CssClass="cssButton" runat="server" OnClick="btnCancel_Click"
                                                                        Text="<%$Resources:Resource,Cancel %>" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                        </asp:View>
                                    </asp:MultiView>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </Ajax:UpdatePanel>
            </td>
        </tr>
    </table>

</asp:Content>
