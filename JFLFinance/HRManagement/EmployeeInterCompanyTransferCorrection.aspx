<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="EmployeeInterCompanyTransferCorrection.aspx.cs" Inherits="HRManagement_EmployeeInterCompanyTransferCorrection"
    Title="<%$Resources:Resource,AppTitle %>" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
        <ContentTemplate>
                                <div class="squareboxgradientcaption" style="height: 20px;">
                                    <table width="100%" border="0">
                                        <tr>
                                            <td align="right" style="width:20%">
                                                <asp:Label ID="Label10" runat="server" Text="<%$ Resources:Resource,EmployeeNumber %>"></asp:Label>
                                            </td>
                                            <td align="left" style="width:30%; padding-left:10px;">
                                                <asp:Label ID="lblEmpNumber" Font-Bold="true" runat="server"></asp:Label>
                                            </td>
                                            <td align="right" style="width:20%">
                                                <asp:Label ID="Label16" runat="server" Text="<%$ Resources:Resource,EmployeeName %>"></asp:Label>
                                            </td>
                                            <td align="left" style="width:30%; padding-left:10px;">
                                                <asp:Label ID="lblEmpName" Font-Bold="true" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                </br>
                                <div class="squareboxgradientcaption" style="height: 20px;">
                                    <table width="100%" border="0">
                                        <tr>
                                            <td align="center" style="width:40%">
                                                <asp:Label ID="Label1" runat="server" Text="<%$Resources:Resource,CurrentEmployeeDetail %>"></asp:Label>
                                            </td>
                                            <td align="center" style="width:60%">
                                                <asp:Label ID="Label8" runat="server" Text="<%$Resources:Resource,FutureEmployeeDetail %>"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div>
                                    <table width="100%" border="0">
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="Label11" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,Company %>"></asp:Label>
                                            </td>
                                            <td align="left" style="padding-left:5px;">
                                                <asp:Label ID="lblCurrentCompany" CssClass="cssLable" Font-Bold="true" runat="server"></asp:Label>
                                            </td>
                                            <td align="right" style="width: 200px;">
                                                <asp:Label ID="Label2" CssClass="cssLable" Width="100px" runat="server" Text="<%$ Resources:Resource,Company %>"></asp:Label>
                                            </td>
                                            <td align="left" style="width: 250px;">
                                                <asp:DropDownList ID="ddlCompany" CssClass="cssDropDown" runat="server" Width="250px"
                                                    OnSelectedIndexChanged="DdlCompany_SelectedIndexChanged" AutoPostBack="True">
                                                </asp:DropDownList>
                                            </td>
                                            <td align="left" style="width: 20px;">
                                                <asp:CheckBox ID="CBCompany" runat="server" AutoPostBack="true" OnCheckedChanged="CBCompany_CheckedChanged" Enabled="False" /> <%--Added Enabled="False" For Bug #1113 & Bug #1727--%>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtEffectiveFromCompany" AutoPostBack="true" CssClass="csstxtbox"
                                                    ValidationGroup="Correction" runat="server" Width="90px" Text="" OnTextChanged="TxtEffectiveFromCompany_TextChanged"></asp:TextBox>
                                                <asp:HyperLink Style="vertical-align: middle;" ID="imgEffectiveFromCompany" runat="server"
                                                    ImageUrl="~/Images/pdate.gif" ></asp:HyperLink>
                                                <AjaxToolKit:CalendarExtender ID="CalendarExtender1" Format="dd-MMM-yyyy" runat="server"
                                                    TargetControlID="txtEffectiveFromCompany" PopupButtonID="imgEffectiveFromCompany">
                                                </AjaxToolKit:CalendarExtender>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEffectiveFromCompany"
                                                    Display="Dynamic" ValidationGroup="Correction" Text="*" SetFocusOnError="true"
                                                    ErrorMessage=""></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="Label12" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,HrLocation %>"></asp:Label>
                                            </td>
                                            <td align="left" style="padding-left:5px;">
                                                <asp:Label ID="lblCurrentHrLocation" CssClass="cssLable" Font-Bold="true" runat="server"></asp:Label>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="Label4" CssClass="cssLable" Width="100px" runat="server" Text="<%$ Resources:Resource,HrLocation %>"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlHrLocation" CssClass="cssDropDown" Width="250px" runat="server"
                                                    AutoPostBack="True" OnSelectedIndexChanged="DdlHrLocation_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                            <td align="left" style="width: 20px;">
                                                <asp:CheckBox ID="CBHrLocation" runat="server" AutoPostBack="True" OnCheckedChanged="CBHrLocation_CheckedChanged" Enabled="False" /> <%--Added Enabled="False" For Bug #1113 & Bug #1727--%>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtEffectiveFromHrLocation" AutoPostBack="true" CssClass="csstxtbox"
                                                    ValidationGroup="Correction" runat="server" Width="90px" Text="" OnTextChanged="TxtEffectiveFromHrLocation_TextChanged"></asp:TextBox>
                                                <asp:HyperLink Style="vertical-align: middle;" ID="imgEffectiveFromHrLocation" runat="server"
                                                    ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                                                <AjaxToolKit:CalendarExtender ID="CalendarExtender3" Format="dd-MMM-yyyy" runat="server"
                                                    TargetControlID="txtEffectiveFromHrLocation" PopupButtonID="imgEffectiveFromHrLocation">
                                                </AjaxToolKit:CalendarExtender>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEffectiveFromHrLocation"
                                                    Display="Dynamic" ValidationGroup="Correction" Text="*" SetFocusOnError="true"
                                                    ErrorMessage=""></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="Label15" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,Location %>"></asp:Label>
                                            </td>
                                            <td align="left" style="padding-left:5px;">
                                                <asp:Label ID="lblCurrentLocation" CssClass="cssLable" Font-Bold="true" runat="server"></asp:Label>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="Label14" CssClass="cssLable" Width="100px" runat="server" Text="<%$ Resources:Resource,Location %>"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlLocation" CssClass="cssDropDown" Width="250px" runat="server"
                                                    AutoPostBack="True" OnSelectedIndexChanged="DdlLocation_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                            <td align="left" style="width: 20px;">
                                                <asp:CheckBox ID="CBLocation" runat="server" AutoPostBack="True" OnCheckedChanged="CBLocation_CheckedChanged" Enabled="False"/> <%--Added Enabled="False" For Bug #1113 & Bug #1727--%>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtEffectiveFromLocation" AutoPostBack="true" CssClass="csstxtbox"
                                                    ValidationGroup="Correction" runat="server" Width="90px" Text="" OnTextChanged="TxtEffectiveFromLocation_TextChanged"></asp:TextBox>
                                                <asp:HyperLink Style="vertical-align: middle;" ID="imgEffectiveFromLocation" runat="server"
                                                    ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                                                <AjaxToolKit:CalendarExtender ID="CalendarExtender4" Format="dd-MMM-yyyy" runat="server"
                                                    TargetControlID="txtEffectiveFromLocation" PopupButtonID="imgEffectiveFromLocation">
                                                </AjaxToolKit:CalendarExtender>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtEffectiveFromLocation"
                                                    Display="Dynamic" ValidationGroup="Correction" Text="*" SetFocusOnError="true"
                                                    ErrorMessage=""></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="Label18" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,DesignationDescription %>"></asp:Label>
                                            </td>
                                            <td align="left" style="padding-left:5px;">
                                                <asp:Label ID="lblCurrentDesignation" CssClass="cssLable" Font-Bold="true" runat="server"></asp:Label>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="Label20" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,DesignationDescription %>"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlDesignation" CssClass="cssDropDown" Width="250px" runat="server" OnSelectedIndexChanged="ddlDesignation_SelectedIndexChanged"
                                                    AutoPostBack="True">
                                                </asp:DropDownList>
                                            </td>
                                            <td align="left" style="width: 20px;">
                                                <asp:CheckBox ID="CBDesignation" runat="server" AutoPostBack="True" OnCheckedChanged="CBDesignation_CheckedChanged" />
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtEffectiveFromDesignation" AutoPostBack="true" CssClass="csstxtbox"
                                                    ValidationGroup="Correction" runat="server" Width="90px" Text="" OnTextChanged="TxtEffectiveFromDesignation_TextChanged"></asp:TextBox>
                                                <asp:HyperLink Style="vertical-align: middle;" ID="imgEffectiveFromDesignation" runat="server"
                                                    ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                                                <AjaxToolKit:CalendarExtender ID="CalendarExtender5" Format="dd-MMM-yyyy" runat="server"
                                                    TargetControlID="txtEffectiveFromDesignation" PopupButtonID="imgEffectiveFromDesignation">
                                                </AjaxToolKit:CalendarExtender>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator51" runat="server" ControlToValidate="txtEffectiveFromDesignation"
                                                    Display="Dynamic" ValidationGroup="Correction" Text="*" SetFocusOnError="true"
                                                    ErrorMessage=""></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                         <tr>
                                            <td align="right">
                                                <asp:Label ID="Label17" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,Grade %>"></asp:Label>
                                            </td>
                                            <td align="left" style="padding-left:5px;">
                                                <asp:Label ID="lblCurrentGrade" CssClass="cssLable" Font-Bold="true" runat="server"></asp:Label>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="Label22" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,Grade %>"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlGrade" CssClass="cssDropDown" Width="250px" runat="server"
                                                    AutoPostBack="True">
                                                </asp:DropDownList>
                                            </td>
                                            <td align="left" style="width: 20px;">
                                                <asp:CheckBox ID="CBGrade" runat="server" AutoPostBack="True" OnCheckedChanged="CBGrade_CheckedChanged" />
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtEffectiveFromGrade" AutoPostBack="true" CssClass="csstxtbox"
                                                    ValidationGroup="Correction" runat="server" Width="90px" Text="" OnTextChanged="txtEffectiveFromGrade_TextChanged"></asp:TextBox>
                                                <asp:HyperLink Style="vertical-align: middle;" ID="imgEffectiveFromGrade" runat="server"
                                                    ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                                                <AjaxToolKit:CalendarExtender ID="CalendarExtender12" Format="dd-MMM-yyyy" runat="server"
                                                    TargetControlID="txtEffectiveFromGrade" PopupButtonID="imgEffectiveFromGrade">
                                                </AjaxToolKit:CalendarExtender>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtEffectiveFromGrade"
                                                    Display="Dynamic" ValidationGroup="Correction" Text="*" SetFocusOnError="true"
                                                    ErrorMessage=""></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="LabelDept" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,Department %>"></asp:Label>
                                            </td>
                                            <td align="left" style="padding-left:5px;">
                                                <asp:Label ID="lblCurrentDepartment" CssClass="cssLable" Font-Bold="true" runat="server"></asp:Label>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="LabelDepartment" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,Department %>"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlDepartment" CssClass="cssDropDown" Width="250px" runat="server"
                                                    AutoPostBack="True">
                                                </asp:DropDownList>
                                            </td>
                                            <td align="left" style="width: 20px;">
                                                <asp:CheckBox ID="CBDepartment" runat="server" AutoPostBack="True" OnCheckedChanged="CBDepartment_CheckedChanged" />
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtEffectiveFromDepartment" AutoPostBack="true" CssClass="csstxtbox"
                                                    ValidationGroup="Correction" runat="server" Width="90px" Text="" OnTextChanged="TxtEffectiveFromDepartment_TextChanged"></asp:TextBox>
                                                <asp:HyperLink Style="vertical-align: middle;" ID="imgEffectiveFromDepartment" runat="server"
                                                    ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                                                <AjaxToolKit:CalendarExtender ID="CalendarExtender6" Format="dd-MMM-yyyy" runat="server"
                                                    TargetControlID="txtEffectiveFromDepartment" PopupButtonID="imgEffectiveFromDepartment">
                                                </AjaxToolKit:CalendarExtender>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorDept" runat="server" ControlToValidate="txtEffectiveFromDepartment"
                                                    Display="Dynamic" ValidationGroup="Correction" Text="*" SetFocusOnError="true"
                                                    ErrorMessage=""></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="Label21" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,CategoryDescription %>"></asp:Label>
                                            </td>
                                            <td align="left" style="padding-left:5px;">
                                                <asp:Label ID="lblCurrentCategory" CssClass="cssLable" Font-Bold="true" runat="server"></asp:Label>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="Label24" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,CategoryDescription %>"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlCategory" CssClass="cssDropDown" Width="250px" runat="server"
                                                    AutoPostBack="True">
                                                </asp:DropDownList>
                                            </td>
                                            <td align="left" style="width: 20px;">
                                                <asp:CheckBox ID="CBCategory" runat="server" AutoPostBack="True" OnCheckedChanged="CBCategory_CheckedChanged" />
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtEffectiveFromCategory" AutoPostBack="true" CssClass="csstxtbox"
                                                    ValidationGroup="Correction" runat="server" Width="90px" Text="" OnTextChanged="TxtEffectiveFromCategory_TextChanged"></asp:TextBox>
                                                <asp:HyperLink Style="vertical-align: middle;" ID="imgEffectiveFromCategory" runat="server"
                                                    ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                                                <AjaxToolKit:CalendarExtender ID="CalendarExtender7" Format="dd-MMM-yyyy" runat="server"
                                                    TargetControlID="txtEffectiveFromCategory" PopupButtonID="imgEffectiveFromCategory">
                                                </AjaxToolKit:CalendarExtender>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtEffectiveFromCategory"
                                                    Display="Dynamic" ValidationGroup="Correction" Text="*" SetFocusOnError="true"
                                                    ErrorMessage=""></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="Label7" CssClass="cssLable" runat="server" Width="150px" Text="<%$ Resources:Resource,JobType %>"></asp:Label>
                                            </td>
                                            <td align="left" style="padding-left:5px;">
                                                <asp:Label ID="lblCurrentJobType" CssClass="cssLable" Font-Bold="true" runat="server"></asp:Label>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="Label5" CssClass="cssLable" runat="server" Width="150px" Text="<%$ Resources:Resource,JobType %>"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlJobType" CssClass="cssDropDown" Width="250px" runat="server"
                                                    AutoPostBack="True">
                                                </asp:DropDownList>
                                            </td>
                                            <td align="left" style="width: 20px;">
                                                <asp:CheckBox ID="CBJobType" runat="server" AutoPostBack="True" OnCheckedChanged="CBJobType_CheckedChanged" />
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtEffectiveFromJobType" AutoPostBack="true" CssClass="csstxtbox"
                                                    ValidationGroup="Correction" runat="server" Width="90px" Text="" OnTextChanged="TxtEffectiveFromJobType_TextChanged"></asp:TextBox>
                                                <asp:HyperLink Style="vertical-align: middle;" ID="imgEffectiveFromJobType" runat="server"
                                                    ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                                                <AjaxToolKit:CalendarExtender ID="CalendarExtender8" Format="dd-MMM-yyyy" runat="server"
                                                    TargetControlID="txtEffectiveFromJobType" PopupButtonID="imgEffectiveFromJobType">
                                                </AjaxToolKit:CalendarExtender>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtEffectiveFromJobType"
                                                    Display="Dynamic" ValidationGroup="Correction" Text="*" SetFocusOnError="true"
                                                    ErrorMessage=""></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="Label9" CssClass="cssLable" runat="server" Width="150px" Text="<%$ Resources:Resource,JobClass %>"></asp:Label>
                                            </td>
                                            <td align="left" style="padding-left:5px;">
                                                <asp:Label ID="lblCurrentJobClass" CssClass="cssLable" Font-Bold="true" runat="server"></asp:Label>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="Label6" CssClass="cssLable" runat="server" Width="150px" Text="<%$ Resources:Resource,JobClass %>"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlJobClass" CssClass="cssDropDown" Width="250px" runat="server"
                                                    AutoPostBack="True">
                                                </asp:DropDownList>
                                            </td>
                                            <td align="left" style="width: 20px;">
                                                <asp:CheckBox ID="CBJobClass" runat="server" AutoPostBack="True" OnCheckedChanged="CBJobClass_CheckedChanged" />
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtEffectiveFromJobClass" AutoPostBack="true" CssClass="csstxtbox"
                                                    ValidationGroup="Correction" runat="server" Width="90px" Text="" OnTextChanged="TxtEffectiveFromJobClass_TextChanged"></asp:TextBox>
                                                <asp:HyperLink Style="vertical-align: middle;" ID="imgEffectiveFromJobClass" runat="server"
                                                    ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                                                <AjaxToolKit:CalendarExtender ID="CalendarExtender9" Format="dd-MMM-yyyy" runat="server"
                                                    TargetControlID="txtEffectiveFromJobClass" PopupButtonID="imgEffectiveFromJobClass">
                                                </AjaxToolKit:CalendarExtender>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtEffectiveFromJobClass"
                                                    Display="Dynamic" ValidationGroup="Correction" Text="*" SetFocusOnError="true"
                                                    ErrorMessage=""></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="Label13" CssClass="cssLable" runat="server" Width="150px" Text="<%$Resources:Resource,Role %>"></asp:Label>
                                            </td>
                                            <td align="left" style="padding-left:5px;">
                                                <asp:Label ID="lblCurrentRole" CssClass="cssLable" Font-Bold="true" runat="server"></asp:Label>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="Label3" CssClass="cssLable" runat="server" Width="150px" Text="<%$Resources:Resource,Role %>"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlRole" CssClass="cssDropDown" Width="250px" runat="server"
                                                    AutoPostBack="True">
                                                </asp:DropDownList>
                                            </td>
                                            <td align="left" style="width: 20px;">
                                                <asp:CheckBox ID="CBRole" runat="server" AutoPostBack="True" OnCheckedChanged="CBRole_CheckedChanged" />
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtEffectiveFromRole" AutoPostBack="true" CssClass="csstxtbox" ValidationGroup="Correction"
                                                    runat="server" Width="90px" Text="" OnTextChanged="TxtEffectiveFromRole_TextChanged"></asp:TextBox>
                                                <asp:HyperLink Style="vertical-align: middle;" ID="ImgEffectiveFromRole" runat="server"
                                                    ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                                                <AjaxToolKit:CalendarExtender ID="CalendarExtender10" Format="dd-MMM-yyyy" runat="server"
                                                    TargetControlID="txtEffectiveFromRole" PopupButtonID="ImgEffectiveFromRole">
                                                </AjaxToolKit:CalendarExtender>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator91" runat="server" ControlToValidate="txtEffectiveFromRole"
                                                    Display="Dynamic" ValidationGroup="Correction" Text="*" SetFocusOnError="true"
                                                    ErrorMessage=""></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="LblAreaID" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,AreaID %>"></asp:Label>
                                            </td>
                                            <td align="left" style="padding-left:5px;">
                                                <asp:Label ID="lblCurrentAreaID" CssClass="cssLable" Font-Bold="true" runat="server"></asp:Label>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="Lbl2AreaID" CssClass="cssLable" runat="server" Width="150px" Text="<%$ Resources:Resource,AreaID %>"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlAreaID" CssClass="cssDropDown" Width="250px" runat="server"
                                                    AutoPostBack="True">
                                                </asp:DropDownList>
                                            </td>
                                            <td align="left" style="width: 20px;">
                                                <asp:CheckBox ID="CBAreaID" runat="server" AutoPostBack="True" OnCheckedChanged="CBAreaID_CheckedChanged" />
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtEffectiveFromAreaID" AutoPostBack="true" CssClass="csstxtbox"
                                                    ValidationGroup="Correction" runat="server" Width="90px" Text="" OnTextChanged="TxtEffectiveFromAreaID_TextChanged"></asp:TextBox>
                                                <asp:HyperLink Style="vertical-align: middle;" ID="imgEffectiveFromAreaID" runat="server"
                                                    ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                                                <AjaxToolKit:CalendarExtender ID="CalendarExtender11" Format="dd-MMM-yyyy" runat="server"
                                                    TargetControlID="txtEffectiveFromAreaID" PopupButtonID="imgEffectiveFromAreaID">
                                                </AjaxToolKit:CalendarExtender>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorAreaID" runat="server" ControlToValidate="txtEffectiveFromAreaID"
                                                    Display="Dynamic" ValidationGroup="Correction" Text="*" SetFocusOnError="true"
                                                    ErrorMessage=""></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblEffectiveTo" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,EffectiveTo %>"></asp:Label>
                                            </td>
                                            <td valign="middle" align="left">
                                                <asp:TextBox ID="txtEffectiveTo" AutoPostBack="true" CssClass="csstxtbox" ValidationGroup="Update"
                                                    runat="server" Width="90px" Text="" OnTextChanged="TxtEffectiveTo_TextChanged"></asp:TextBox>
                                                <AjaxToolKit:CalendarExtender ID="CalendarExtender2" Format="dd-MMM-yyyy" runat="server"
                                                    TargetControlID="txtEffectiveTo" PopupButtonID="imgDate">
                                                </AjaxToolKit:CalendarExtender>
                                                <asp:HyperLink Style="vertical-align: middle;" ID="imgDate" runat="server" ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEffectiveTo"
                                                    Display="Dynamic" ValidationGroup="Update" Text="*" SetFocusOnError="true" ErrorMessage=""></asp:RequiredFieldValidator>
                                            </td>
                                            <td colspan="4">

                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <asp:HiddenField ID="hfCompanyCode" runat="server" />
                                                <asp:HiddenField ID="hfHrLocationCode" runat="server" />
                                                <asp:HiddenField ID="hfLocationCode" runat="server" />
                                                <asp:HiddenField ID="hfDesignationCode" runat="server" />
                                                    <asp:HiddenField ID="hfGradeCode" runat="server" />
                                                <asp:HiddenField ID="hfCategoryCode" runat="server" />
                                                <asp:HiddenField ID="hfJobClassCode" runat="server" />
                                                <asp:HiddenField ID="hfJobTypeCode" runat="server" />
                                                <asp:HiddenField ID="hfRoleCode" runat="server" />
                                                <asp:HiddenField ID="hfDesiEffectiveFrom" runat="server" />
                                                <asp:HiddenField ID="hflocationEffectiveFrom" runat="server" />
                                                <asp:HiddenField ID="hfCatEffectiveFrom" runat="server" />
                                                <asp:HiddenField ID="hfCompEffectiveFrom" runat="server" />
                                                <asp:HiddenField ID="hfRoleEffectiveFrom" runat="server" />
                                                <asp:HiddenField ID="hfLocationAutoID" runat="server" />
                                                <asp:HiddenField ID="hfEmpJobClassEffectiveFrom" runat="server" />
                                                <asp:HiddenField ID="hfEmpJobTypeEffectiveFrom" runat="server" />
                                                <asp:HiddenField ID="hfAreaID" runat="server" />
                                                <asp:HiddenField ID="hfAreaEffectiveFrom" runat="server" />
                                                <asp:HiddenField ID="hfDepartmentCode" runat="server" />
                                                <asp:HiddenField ID="hfDeptEffectiveFrom" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6" align="center">
                                                <asp:Button ID="btnUpdate" CssClass="cssButton" ValidationGroup="Update" runat="server"
                                                    OnClick="BtnUpdate_Click" Text="<%$Resources:Resource,Update %>" />
                                                <asp:Button ID="btnRollback" CssClass="cssButton" ValidationGroup="Update" runat="server"
                                                    OnClick="BtnRollback_Click" Text="<%$Resources:Resource,Rollback %>" />
                                                <asp:Button ID="btnCorrection" CssClass="cssButton" ValidationGroup="Correction"
                                                    runat="server" Text="Correction" />
                                                <asp:Button ID="btnCancel" CssClass="cssButton" runat="server" OnClick="BtnCancel_Click"
                                                    Text="<%$Resources:Resource,Cancel %>" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <asp:HiddenField ID="HFEffectiveFromCompany" runat="server" />
                                                <asp:HiddenField ID="HFEffectiveFromHrLocation" runat="server" />
                                                <asp:HiddenField ID="HFEffectiveFromLocation" runat="server" />
                                                <asp:HiddenField ID="HFEffectiveFromCategory" runat="server" />
                                                <asp:HiddenField ID="HFEffectiveFromDesignation" runat="server" />
                                                 <asp:HiddenField ID="HFEffectiveFromGrade" runat="server" />
                                                <asp:HiddenField ID="HFEffectiveFromJobType" runat="server" />
                                                <asp:HiddenField ID="HFEffectiveFromJobClass" runat="server" />
                                                <asp:HiddenField ID="HFEffectiveFromRole" runat="server" />
                                                <asp:HiddenField ID="HFGridViewRowIndex" runat="server" />
                                                <asp:HiddenField ID="HFCompanyCount" runat="server" />
                                                <asp:HiddenField ID="HFHrLocationCount" runat="server" />
                                                <asp:HiddenField ID="HFLocationCount" runat="server" />
                                                <asp:HiddenField ID="HFCategoryCount" runat="server" />
                                                <asp:HiddenField ID="HFDesignationCount" runat="server" />
                                                <asp:HiddenField ID="HFJobTypeCount" runat="server" />
                                                <asp:HiddenField ID="HFJobClassCount" runat="server" />
                                                <asp:HiddenField ID="HFRoleCount" runat="server" />
                                                <asp:HiddenField ID="HFOldCompanyCount" runat="server" />
                                                <asp:HiddenField ID="HFOldHrLocationCount" runat="server" />
                                                <asp:HiddenField ID="HFOldLocationCount" runat="server" />
                                                <asp:HiddenField ID="HFOldCategoryCount" runat="server" />
                                                <asp:HiddenField ID="HFOldDesignationCount" runat="server" />
                                                <asp:HiddenField ID="HFOldJobTypeCount" runat="server" />
                                                <asp:HiddenField ID="HFOldJobClassCount" runat="server" />
                                                <asp:HiddenField ID="HFOldRoleCount" runat="server" />
                                                <asp:HiddenField ID="HFOperationType" runat="server" />
                                                <asp:HiddenField ID="HFCheckedCount" runat="server" />
                                                <asp:HiddenField ID="HFEffectiveFromArea" runat="server" />
                                                <asp:HiddenField ID="HFAreaCount" runat="server" />
                                                <asp:HiddenField ID="HFOldAreaCount" runat="server" />
                                                <asp:HiddenField ID="HFEffectiveFromDepartment" runat="server" />
                                                <asp:HiddenField ID="HFDepartmentCount" runat="server" />
                                                <asp:HiddenField ID="HFOldDepartmentCount" runat="server" />
                                                <asp:Label ID="lblErrorMsg" EnableViewState="true" CssClass="csslblErrMsg" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                      <asp:Panel ID="Panel6" BackColor="white" ScrollBars="none" CssClass="ScrollBar" runat="server"
                             Height="400" Width="750" Style="border: 1px; border-style: solid;
                            border-color: Red">
                            <asp:Button ID="btn1" runat="server" Style="display: none" />
                            <AjaxToolKit:ModalPopupExtender ID="MPE" runat="server" TargetControlID="btn1"
                                PopupControlID="Panel6" BackgroundCssClass="modalBackground" ></AjaxToolKit:ModalPopupExtender>
                            <Ajax:UpdatePanel runat="server" ID="UpdatePanel2" UpdateMode="Conditional">
                                <ContentTemplate>
                                        <asp:GridView ID="gvErrorMessage" PageSize="5" Width="100%" runat="server" AllowPaging="false"
                                             AutoGenerateColumns="False" CellPadding="1" OnRowDataBound="GvErrorMessage_RowDataBound"
                                            CssClass="GridViewStyle" >
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
                                                        <asp:HiddenField ID="HFMessageID" runat="server" Value='<%# Bind("MessageID") %>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="70px" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                   <asp:Button ID="btnDeleteRota" CssClass="cssButton" runat="server" Text="<%$ Resources:Resource ,Delete %>" OnClick="BtnDeleteRota_Click" />
                                   <asp:Button ID="btnClose" CssClass="cssButton" runat="server" Text="<%$ Resources:Resource ,Close %>" OnClick="BtnClose_Click" />
                                </ContentTemplate>
                            </Ajax:UpdatePanel>
                      </asp:Panel>
        </ContentTemplate>
    </Ajax:UpdatePanel>

    <%--<script language ="javascript" src="../javaScript/jquery-1.8.1.min.js" type ="text/javascript"></script>--%>
    <script language="javascript" type="text/javascript" src="../javaScript/jquery-1.11.3.min.js"></script>
    <script language="javascript" src="../PageJS/EmployeeInterCompanyTransferCorrection.js" type="text/javascript"></script>
</asp:Content>
