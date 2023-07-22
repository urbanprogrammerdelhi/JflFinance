<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="EmployeeMaster.aspx.cs" EnableViewState="true" Inherits="Masters_EmployeeMaster" Title="<%$ Resources:Resource, AppTitle %>" %>
<%@ MasterType TypeName="MasterPage" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
              <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                                <div class="squareboxgradientcaption" style="height: 25px;">
                                    <asp:Label ID="Label6" runat="server" Text="<%$Resources:Resource,PersonalDetail1 %>"></asp:Label>
                                </div>
                                <div>
                                    <ajaxToolkit:TabContainer Style="text-align: left;" runat="server" ID="EmpDetails"
                                        ActiveTabIndex="0" OnActiveTabChanged="EmpDetails_ActiveTabChanged" AutoPostBack="true">
                                        <AjaxToolKit:TabPanel Style="text-align: left;" ID="PanelEmployeeDetails" runat="server"
                                            HeaderText="<%$Resources:Resource,employeeDetails %>" TabIndex="0">
                                            <ContentTemplate>
                                                <asp:Panel ID="Panel1" Font-Bold="True" ForeColor="Red" GroupingText="<%$ Resources:Resource,PersonalDetails %>"
                                                    runat="server">
                                                    <table align="center" width="100%" border="0" cellspacing="0px" cellpadding="0px">
                                                        <tr>
                                                            <td style="text-align: right;" nowrap="nowrap">
                                                                <asp:Label ID="lblEmployee" Width="100px" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,EmployeeNumber %>"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left;" nowrap="nowrap">
                                                                <asp:TextBox ID="lblEmployeeNumber" AutoPostBack="True" CssClass="csstxtbox" MaxLength="16"
                                                                    runat="server" Font-Bold="True" OnTextChanged="lblEmployeeNumber_TextChanged"></asp:TextBox>
                                                                <asp:Label ID="Label8" Width="40px" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,OldEmpNo %>"></asp:Label>
                                                                <asp:TextBox ID="txtEmpNoOld" AutoPostBack="True" CssClass="csstxtbox" MaxLength="6" runat="server" OnTextChanged="txtEmpNoOld_TextChanged" Style="width: 60px;" Font-Bold="True"></asp:TextBox>
                                                            </td>
                                                            <td style="text-align: right;">
                                                                <asp:Label ID="lblFirstName" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,FirstName %>"></asp:Label>
                                                            </td>
                                                                <td style="text-align: left;">
                                                                <asp:TextBox ID="txtFirstName" MaxLength="49" CssClass="csstxtboxRequired" ValidationGroup="NewEmployee"
                                                                    AutoPostBack="True" runat="server"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RFVFirstName" ValidationGroup="NewEmployee" ControlToValidate="txtFirstName"  Display="Dynamic" runat="server" Text="*"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td style="text-align: right;">
                                                                <asp:Label ID="lblLastName" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,LastName %>"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left;">
                                                                <asp:TextBox ID="txtLastName" MaxLength="49" CssClass="csstxtboxRequired" ValidationGroup="NewEmployee"
                                                                    runat="server"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RFVLastName" ValidationGroup="NewEmployee" Display="Dynamic"
                                                                    ControlToValidate="txtLastName" runat="server" Text="*"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: right;">
                                                                <asp:Label ID="lblDOB" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,DateOfBirth %>"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left;">
                                                                <asp:TextBox ID="txtDateOfBirth" AutoPostBack="True" OnTextChanged="txtDateOfBirth_TextChanged"
                                                                    runat="server" ValidationGroup="NewEmployee" CssClass="csstxtboxRequired"></asp:TextBox>
                                                                <asp:ImageButton ID="imgDOB" Style="vertical-align: middle" runat="server" ImageUrl="~/Images/pdate.gif">
                                                                </asp:ImageButton>
                                                                <AjaxToolKit:CalendarExtender ID="CalendarExtender2" Format="dd-MMM-yyyy" runat="server"
                                                                    TargetControlID="txtDateOfBirth" PopupButtonID="imgDOB" Enabled="True">
                                                                </AjaxToolKit:CalendarExtender>
                                                                <asp:RequiredFieldValidator ID="RFVDOB" ValidationGroup="NewEmployee" Display="Dynamic"
                                                                    ControlToValidate="txtDateOfBirth" runat="server" Text="*"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td style="text-align: right;">
                                                                <asp:Label ID="lblHeight" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,Height %>"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left;">
                                                                <asp:DropDownList ID="ddlheightfeet" Width="70px" CssClass="csstxtboxRequired" runat="server">
                                                                 
                                                                    <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                                    <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                                    <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                                                     <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:HiddenField ID="hfdob" runat="server" Visible="false" />
                                                                 <asp:Label ID="Label2" runat="server" CssClass="cssLable" Font-Bold="True" Text="<%$ Resources:Resource,Feet %>"></asp:Label>
                                                                  <asp:DropDownList ID="ddlheightinch" Width="70px" CssClass="csstxtboxRequired" runat="server">
                                                                    
                                                                    <asp:ListItem Text="0" Value="0"></asp:ListItem>
                                                                    <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                                    <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                                     <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                                       <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                                    <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                                    <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                                                     <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                                                       <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                                                    <asp:ListItem Text="9" Value="9"></asp:ListItem>
                                                                    <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                                                     <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                                                </asp:DropDownList>
                                                                 <asp:Label ID="Label4" runat="server" CssClass="cssLable" Font-Bold="True" Text="<%$ Resources:Resource,Inches %>"></asp:Label>
                                                            </td>
                                                            <td style="text-align: right;">
                                                                <asp:Label ID="lblWeight" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,Weight %>"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left;">
                                                                <asp:TextBox ID="txtWeight" MaxLength="6" CssClass="csstxtbox" ValidationGroup="NewEmployee"
                                                                    runat="server"></asp:TextBox>
                                                                <asp:Label ID="Label3" runat="server" CssClass="cssLable" Font-Bold="True" Text="<%$ Resources:Resource,Kg %>"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: right;">
                                                                <asp:Label ID="lblMaritalStatus" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,Married %>"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left;">
                                                                <asp:DropDownList ID="ddlMaritalStatus" Width="130px" CssClass="csstxtboxRequired" runat="server">
                                                                    <asp:ListItem Text="Yes" Value="True"></asp:ListItem>
                                                                    <asp:ListItem Text="No" Value="False"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="text-align: right;">
                                                                <asp:Label ID="lblGender" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,Gender %>"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left;">
                                                                <asp:DropDownList ID="ddlSex" Width="130px" CssClass="csstxtboxRequired" runat="server">
                                                                    <asp:ListItem Text="Male" Value="M"></asp:ListItem>
                                                                    <asp:ListItem Text="Female" Value="F"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="text-align: right;">
                                                                <asp:Label ID="lblVagitarian" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,Vegitarian %>"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left;">
                                                                <asp:DropDownList ID="ddlVegitarian" Width="130px" CssClass="csstxtboxRequired" runat="server">
                                                                    <asp:ListItem Text="No" Value="False"></asp:ListItem>
                                                                    <asp:ListItem Text="Yes" Value="True"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                           <tr>
                                                            <td style="text-align: right;">
                                                                <asp:Label ID="lblBloodgroup" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,BloodGroup %>"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left;">
                                                               <asp:TextBox ID="txtbloodgroup" MaxLength="50" CssClass="csstxtbox" ValidationGroup="NewEmployee"
                                                                    Style="width: 125px;" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="text-align: right; vertical-align: top;">
                                                                <asp:Label ID="lblDisability" CssClass="cssLable" Style="width: 130px;" runat="server"
                                                                    Text="<%$ Resources:Resource,Disability %>"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left; width: 220px; vertical-align: top;">
                                                                <asp:TextBox ID="txtDisability" MaxLength="50" CssClass="csstxtbox" ValidationGroup="NewEmployee"
                                                                    Style="width: 125px;" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="text-align: right; vertical-align: top;">
                                                                <asp:Label ID="lblIdentificationmark" CssClass="cssLable" Style="width: 100px;" runat="server"
                                                                    Text="<%$ Resources:Resource,IdentificationMark %>"></asp:Label>
                                                            </td>
                                                             <td style="text-align: left; width: 220px; vertical-align: top;">
                                                                <asp:TextBox ID="txtidentificationmark" MaxLength="50" CssClass="csstxtbox" ValidationGroup="NewEmployee"
                                                                    Style="width: 125px;" runat="server"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: right;">
                                                                <asp:Label ID="lblSmoker" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,Smoker %>"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left;">
                                                                <asp:DropDownList ID="ddlSmoker" Width="130px" CssClass="csstxtboxRequired" runat="server">
                                                                    <asp:ListItem Text="Yes" Value="True"></asp:ListItem>
                                                                    <asp:ListItem Text="No" Value="False"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="text-align: right; vertical-align: top;">
                                                                <asp:Label ID="lblContactNo" CssClass="cssLable" Style="width: 100px;" runat="server"
                                                                    Text="<%$ Resources:Resource,ContactNo %>"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left; width: 220px; vertical-align: top;">
                                                                <asp:TextBox ID="txtContactNo" MaxLength="50" CssClass="csstxtbox" ValidationGroup="NewEmployee"
                                                                    Style="width: 125px;" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="text-align: right; vertical-align: top;">
                                                                <asp:Label ID="lblAddress" CssClass="cssLable" Style="width: 100px;" runat="server"
                                                                    Text="<%$ Resources:Resource,Remarks %>"></asp:Label>
                                                            </td>
                                                            <td rowspan="2" style="text-align: left; width: 220px;">
                                                                <asp:TextBox ID="txtAddress" runat="server" ValidationGroup="NewEmployee" Width="130px"
                                                                    CssClass="csstxtbox" Height="60px" TextMode="MultiLine" onkeypress="if(this.value.length>=100) return false;"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: right; vertical-align: top;">
                                                                <asp:Label ID="lblNationality" CssClass="cssLable" Style="width: 100px;" runat="server"
                                                                    Text="<%$ Resources:Resource,Nationality %>"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left; width: 220px; vertical-align: top;">
                                                                <asp:DropDownList ID="ddlNationality" CssClass="csstxtboxRequired" Width="130px" runat="server">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="text-align: right; vertical-align: top;" align="left">
                                                                <asp:Label ID="lblReligion" CssClass="cssLable" Style="width: 100px;" runat="server"
                                                                    Text="<%$ Resources:Resource,Religion %>"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left; width: 220px; vertical-align: top;">
                                                                <asp:DropDownList ID="ddlReligion" CssClass="csstxtboxRequired" Width="130px" runat="server">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: right; vertical-align: top;">
                                                                <asp:Label ID="lblState" CssClass="cssLable" Style="width: 100px;" runat="server"
                                                                    Text="<%$ Resources:Resource,State %>"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left; width: 220px; vertical-align: top;">
                                                                <asp:TextBox ID="txtState" MaxLength="50" CssClass="csstxtbox" ValidationGroup="NewEmployee"
                                                                    Style="width: 125px;" runat="server"></asp:TextBox>
                                                            </td>
                                                             <td style="text-align: right; vertical-align: top;">
                                                                <asp:Label ID="lblMilitary" CssClass="cssLable" runat="server" Style="width: 100px;" Text="<%$ Resources:Resource,MilitaryStatus %>"></asp:Label>
                                                            </td>
                                                                <td style="text-align: left; width: 220px; vertical-align: top;">
                                                                <asp:DropDownList ID="ddlMilitary" CssClass="csstxtboxRequired" Style="width: 80px;" runat="server"
                                                                   >
                                                                    <asp:ListItem Value="True"></asp:ListItem>
                                                                    <asp:ListItem Value="False"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td colspan="2">
                                                                <asp:Button ID="btnMultilingual" CssClass="cssButton" runat="server" Style="display: none;"
                                                                    OnClick="btnMultilingual_Click" Text="<%$ Resources:Resource,MultilingualEntry %>" />
                                                                <asp:Button ID="Button3" runat="server" Style="display: none" />
                                                                <asp:Panel ID="Panel6" BackColor="White" CssClass="ScrollBar" runat="server" Height="105px"
                                                                    Width="420px" Style="display: none;">
                                                                    <AjaxToolKit:ModalPopupExtender ID="MPEmployeeDetail" runat="server" TargetControlID="Button3"
                                                                        PopupControlID="Panel6" X="250" Y="50" BackgroundCssClass="modalBackground" DynamicServicePath=""
                                                                        Enabled="True">
                                                                    </AjaxToolKit:ModalPopupExtender>
                                                                    <div style="width: 400px;">
                                                                            <div class="squareboxgradientcaption" style="height: 20px; cursor: pointer;" ">
                                                                                    <asp:Label ID="Label7" runat="server" Text="<%$ Resources:Resource,PersonalDetail1 %>"></asp:Label>
                                                                            </div>
                                                                            <div class="squareboxcontent">
                                                                                <table border="0">
                                                                                    <tr>
                                                                                        <td style="text-align: right;">
                                                                                            <asp:Label ID="lblFirstName1" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,FirstName %>"></asp:Label>
                                                                                        </td>
                                                                                        <td style="text-align: left;">
                                                                                            <asp:TextBox ID="txtOtherLanguageFirstName" MaxLength="49" CssClass="csstxtboxRequired"
                                                                                                runat="server"></asp:TextBox>
                                                                                            <asp:HiddenField ID="HFOtherLanguageFirstName" runat="server" />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="text-align: right;">
                                                                                            <asp:Label ID="Label1" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,LastName %>"></asp:Label>
                                                                                        </td>
                                                                                        <td style="text-align: left;">
                                                                                            <asp:TextBox ID="txtOtherLanguageLastName" MaxLength="49" CssClass="csstxtboxRequired"
                                                                                                runat="server"></asp:TextBox>
                                                                                            <asp:HiddenField ID="HFOtherLanguageLastName" runat="server" />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="2">
                                                                                            <asp:Button ID="btnOk" CssClass="cssButton" OnClick="btnOk_Click" runat="server"
                                                                                                Text="<%$ Resources:Resource,OK %>" />
                                                                                            <asp:Button ID="btnCancel" CssClass="cssButton" OnClick="btnCancel_Click" runat="server"
                                                                                                Text="<%$ Resources:Resource,Cancel %>" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                         </div>
                                                                    </div>
                                                                </asp:Panel>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>   
                                                <asp:Panel ID="Panel3" ForeColor="Red" Font-Bold="True" GroupingText="<%$ Resources:Resource,JobRelatedDetail %>"
                                                    runat="server">
                                                    <table align="center" width="100%" border="0" cellspacing="0px" cellpadding="1px">
                                                        <tr>
                                                            <td style="text-align: right; width: 100px;" nowrap="nowrap">
                                                                <asp:Label ID="lblPrevExp" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,PreviousExp %>"
                                                                    Style="width: 100px;"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left; width: 220px;">
                                                                <asp:TextBox ID="txtPrevExp" MaxLength="6" CssClass="csstxtbox" runat="server" Style="width: 100px;"></asp:TextBox>
                                                                <asp:Label ID="Label5" runat="server" CssClass="cssLable" Font-Bold="True" Text="<%$ Resources:Resource,Months %>"></asp:Label>
                                                            </td>
                                                            <td style="text-align: right; width: 100px;" nowrap="nowrap">
                                                                <asp:Label ID="lblDOJ" CssClass="cssLable" runat="server" Style="width: 100px;" Text="<%$ Resources:Resource,JoiningDate %>"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left; width: 220px;">
                                                                <asp:TextBox ID="txtDateOfJoining" runat="server" OnTextChanged="txtDateOfJoining_TextChanged"
                                                                    ValidationGroup="NewEmployee" CssClass="csstxtboxRequired" AutoPostBack="True"
                                                                    Style="width: 100px;"></asp:TextBox>
                                                                <asp:ImageButton ID="imgDate" Style="vertical-align: middle" runat="server" ImageUrl="~/Images/pdate.gif">
                                                                </asp:ImageButton>
                                                                <AjaxToolKit:CalendarExtender ID="CalendarExtender1" Format="dd-MMM-yyyy" runat="server"
                                                                    TargetControlID="txtDateOfJoining" PopupButtonID="imgDate" PopupPosition="TopRight"
                                                                    Enabled="True">
                                                                </AjaxToolKit:CalendarExtender>
                                                                <asp:RequiredFieldValidator ID="RFVDateOfJoining" ValidationGroup="NewEmployee" Display="Dynamic"
                                                                    runat="server" Text="*" ControlToValidate="txtDateOfJoining"></asp:RequiredFieldValidator>
                                                            </td>
                                                        <td style="text-align: right; width: 100px;" nowrap="nowrap">
                                                                <asp:Label ID="lblDepartment" CssClass="cssLable" runat="server" Style="width: 100px;"
                                                                    Text="<%$ Resources:Resource,Department %>"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left; width: 220px;">
                                                                <asp:DropDownList ID="ddlDepartment" CssClass="csstxtboxRequired" Style="width: 110px;"
                                                                    runat="server">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: right; width: 100px;" nowrap="nowrap">
                                                                <asp:Label ID="lblDesignation" CssClass="cssLable" runat="server" Style="width: 100px;"
                                                                    Text="<%$ Resources:Resource,DesignationDescription %>"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left; width: 220px;">
                                                                <asp:DropDownList ID="ddlDesignation" CssClass="csstxtboxRequired" Style="width: 186px;" OnSelectedIndexChanged="ddlDesignation_SelectedIndexChanged" AutoPostBack="true"
                                                                    runat="server" Width="154px">
                                                                </asp:DropDownList>
                                                            </td>
                                                              <td style="text-align: right; width: 100px;" nowrap="nowrap">
                                                                <asp:Label ID="Label11" CssClass="cssLable" runat="server" Style="width: 100px;"
                                                                    Text="<%$ Resources:Resource,Grade %>"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left; width: 220px;">
                                                                <asp:DropDownList ID="ddlGrade" CssClass="csstxtboxRequired" Style="width: 186px;" runat="server"  OnClientClick="javascript:ToggleValidator()"  AutoPostBack="true" OnSelectedIndexChanged="ddlGrade_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="text-align: right; width: 100px;" nowrap="nowrap">
                                                                <asp:Label ID="lblCategory" CssClass="cssLable" runat="server" Style="width: 100px;"
                                                                    Text="<%$ Resources:Resource,CategoryDescription %>"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left; width: 220px;">
                                                                <asp:DropDownList ID="ddlCategory" CssClass="csstxtboxRequired" Style="width: 186px;" runat="server"  OnClientClick="javascript:ToggleValidator()"  AutoPostBack="true" OnSelectedIndexChanged="ddlcategory_selectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                        
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: right; width: 100px;">
                                                                <asp:Label ID="lblJobType" CssClass="cssLable" runat="server" Style="width: 100px;"
                                                                    Text="<%$ Resources:Resource,JobType %>"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left; width: 220px;">
                                                                <asp:DropDownList ID="ddlJobType" CssClass="csstxtboxRequired" Style="width: 186px;" runat="server">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="text-align: right; width: 100px;">
                                                                <asp:Label ID="lblJobClass" CssClass="cssLable" runat="server" Style="width: 100px;"
                                                                    Text="<%$ Resources:Resource,JobClass %>"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left; width: 125px;">
                                                                <asp:DropDownList ID="ddlJobClass" CssClass="csstxtboxRequired" Style="width: 186px;" runat="server">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="text-align: right; width: 100px;">
                                                                <asp:Label ID="lblRole" CssClass="cssLable" runat="server" Style="width: 100px;"
                                                                    Text="<%$ Resources:Resource,Role %>"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left; width: 125px;">
                                                                <asp:DropDownList ID="ddlRole" CssClass="cssDropDown" Style="width: 186px;" runat="server">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: right; width: 100px;">
                                                                <asp:Label ID="lblAreaID" CssClass="cssLable" runat="server" Style="width: 100px;"
                                                                    Text="<%$ Resources:Resource,AreaId %>"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left; width: 220px;">
                                                                <asp:DropDownList ID="ddlAreaId" CssClass="csstxtboxRequired" Style="width: 186px;" runat="server"
                                                                    AutoPostBack="True" OnSelectedIndexChanged="ddlAreaId_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="text-align: right; width: 100px;">
                                                                <asp:Label ID="lblOtEntit" runat="server" CssClass="cssLabel" Style="width: 100px;"
                                                                    Text="<%$ Resources:Resource,OTEntitlement %>"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left; width: 125px;">
                                                                <asp:CheckBox ID="chkOTEntitlement" runat="server" CssClass="cssCheckBox" />
                                                            </td>
                                                            <td style="text-align: right; width: 100px;">
                                                                <asp:Label ID="lblOTValidity" CssClass="cssLable" runat="server" Style="width: 100px;"
                                                                    Text="<%$ Resources:Resource,OTValidity %>"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left; width: 180px;">
                                                                <asp:TextBox ID="txtOtValidity" runat="server" OnTextChanged="txtOtValidity_TextChanged"
                                                                    ValidationGroup="NewEmployee" CssClass="csstxtboxRequired" AutoPostBack="True"
                                                                    Style="width: 100px;"></asp:TextBox>
                                                                <asp:ImageButton ID="ImgValid" Style="vertical-align: middle" runat="server" ImageUrl="~/Images/pdate.gif">
                                                                </asp:ImageButton>
                                                                <AjaxToolKit:CalendarExtender ID="CalendarExtender3" Format="dd-MMM-yyyy" runat="server"
                                                                    TargetControlID="txtOtValidity" PopupButtonID="ImgValid" PopupPosition="TopRight"
                                                                    Enabled="True">
                                                                </AjaxToolKit:CalendarExtender>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: right; width: 100px;">
                                                                <asp:Label ID="lblStatus" CssClass="cssLable" runat="server" Style="width: 100px;"
                                                                    Text="<%$ Resources:Resource,Status %>"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left; width: 220px;">
                                                                <asp:TextBox ID="txtStatus" CssClass="csstxtbox" runat="server" MaxLength="20"></asp:TextBox>
                                                            </td>
                                                            <td style="text-align: right; width: 100px;">
                                                                <asp:Label ID="Label10" CssClass="cssLable" runat="server" Style="width: 100px;"
                                                                    Text="<%$ Resources:Resource,StatusDesc %>"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left; width: 125px;">
                                                                <asp:TextBox ID="txtStatusDesc" CssClass="csstxtbox" runat="server" MaxLength="255"></asp:TextBox>
                                                            </td>
                                                            <td style="text-align: right; width: 170px;">
                                                                <asp:Label ID="lblStatusFrmDate" CssClass="cssLable" runat="server" Style="width: 100px;"
                                                                    Text="<%$ Resources:Resource,WEFDate %>"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left; width: 185px;">
                                                                <asp:TextBox ID="txtWeFDate" runat="server" OnTextChanged="txtWeFDate_TextChanged"
                                                                    ValidationGroup="NewEmployee" CssClass="csstxtboxRequired" AutoPostBack="True"
                                                                    Style="width: 100px;"></asp:TextBox>
                                                                <asp:ImageButton ID="ImgWEF" Style="vertical-align: middle" runat="server" ImageUrl="~/Images/pdate.gif">
                                                                </asp:ImageButton>
                                                                <AjaxToolKit:CalendarExtender ID="CalendarExtender4" Format="dd-MMM-yyyy" runat="server"
                                                                    TargetControlID="txtWeFDate" PopupButtonID="ImgWEF" PopupPosition="TopRight"
                                                                    Enabled="True">
                                                                </AjaxToolKit:CalendarExtender>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: right; width: 100px;">
                                                                <asp:Label ID="lblScaleCode" CssClass="cssLable" runat="server" Style="width: 100px;"
                                                                    Text="<%$ Resources:Resource,ScaleCode %>"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left; width: 220px;">
                                                                <asp:TextBox ID="txtScaleCode" CssClass="csstxtbox" runat="server" MaxLength="20"></asp:TextBox>
                                                            </td>
                                                            <td style="text-align: right; width: 100px;">
                                                                <asp:Label ID="lblScaleDesc" runat="server" CssClass="cssLabel" Text="<%$ Resources:Resource,ScaleDesc %>"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left; width: 125px;">
                                                                <asp:TextBox ID="txtScaleDesc" CssClass="csstxtbox" runat="server" MaxLength="255"></asp:TextBox>
                                                            </td>
                                                            <td style="text-align: right; width: 100px;">
                                                                <asp:Label ID="lblAreaInchargeName" runat="server" CssClass="cssLabel" Text="<%$ Resources:Resource,AreaIncharge %>"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left; width: 350px;">
                                                                <asp:TextBox CssClass="csstxtboxReadonly" ID="txtAreaInchargeName" runat="server"
                                                                    ReadOnly="True"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                                <asp:Panel ID="Panel4" ForeColor="Red" Font-Bold="True" GroupingText="<%$ Resources:Resource,CostToCompany %>" runat="server">
                                                    <table align="left" width="100%" border="0" cellspacing="0px" cellpadding="1px">
                                                        <tr>
                                                            <td style="text-align: right; width: 100px;">
                                                                <asp:Label ID="lblWageRate" CssClass="cssLable" runat="server" Style="width: 110px;"
                                                                    Text="<%$ Resources:Resource,wageRate %>"></asp:Label>
                                                                <asp:Label ID="lblDefaultCurrency" CssClass="cssLabel" runat="server"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left; width: 200px;">
                                                                <asp:TextBox ID="txtWageRate" runat="server" CssClass="csstxtboxRequired" MaxLength="8"
                                                                    ValidationGroup="NewEmployee" Style="width: 90px;" onChange="javascript:CheckMax(this)"></asp:TextBox>
                                                                <asp:RangeValidator ID="rvWageRate" Type="Double" runat="server" ControlToValidate="txtWageRate"
                                                                    MinimumValue=".0" MaximumValue="99999999" ValidationGroup="NewEmployee" ErrorMessage="*"></asp:RangeValidator>
                                                                <asp:RequiredFieldValidator ID="RFVtxtWageRate" ValidationGroup="NewEmployee" Display="Dynamic"
                                                                    runat="server" Text="*" ControlToValidate="txtWageRate"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td style="text-align: right; width: 90px;">
                                                                <asp:Label ID="lblCurrency" CssClass="cssLable" runat="server" Style="width: 100px;"
                                                                    Text="<%$ Resources:Resource,currency %>"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left; width: 180px;">
                                                                <asp:DropDownList ID="ddlCurrency" CssClass="cssDropDown" Style="width: 110px;" runat="server">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="text-align: right; width: 90px;">
                                                                <asp:Label ID="Label9" CssClass="cssLable" runat="server" Style="width: 100px;" Text="<%$ Resources:Resource,ContractDays %>"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left; width: 180px;">
                                                                <asp:DropDownList ID="ddlContractDays" CssClass="cssDropDown" Style="width: 110px;"
                                                                    runat="server">
                                                                    <asp:ListItem Text="1" Value="1" Selected="True"></asp:ListItem>
                                                                    <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                                    <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                                    <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                                    <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                                    <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                                                    <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: right; width: 100px;">
                                                                <asp:Label ID="lblContractedHrs" CssClass="cssLable" runat="server" Style="width: 110px;"
                                                                    Text="<%$ Resources:Resource,ContractHours %>"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left; width: 200px;">
                                                                <asp:TextBox ID="txtContractedHrs" runat="server" CssClass="csstxtboxRequired" MaxLength="5"
                                                                    Style="width: 90px;"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ValidationGroup="NewEmployee"
                                                                    Display="Dynamic" runat="server" Text="*" ControlToValidate="txtContractedHrs" ></asp:RequiredFieldValidator>
                                                                <asp:RangeValidator ID="rvContractedHrs" runat="server" ErrorMessage="*" Type="Double"
                                                                    MinimumValue="0" MaximumValue="24" ValidationGroup="NewEmployee" ControlToValidate="txtContractedHrs"></asp:RangeValidator>
                                                            </td>
                                                            <td style="text-align: right; width: 90px;">
                                                                <asp:Label ID="lblAtRate" CssClass="cssLable" runat="server" Style="width: 100px;"
                                                                    Text="@"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left; width: 180px;">
                                                                <asp:DropDownList ID="ddlContHrsFreqency" CssClass="csstxtboxRequired" Style="width: 140px;"
                                                                    runat="server">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                                <center>
                                                    <asp:Button ID="btnSubmit" CssClass="cssButton" runat="server" ValidationGroup="NewEmployee"
                                                        Text="<%$ Resources:Resource,Submit %>" OnClick="btnSubmit_Click" OnClientClick="javascript:HideButton()" />
                                                    <asp:Button ID="btnClear" CssClass="cssButton" runat="server" Text="<%$ Resources:Resource,AddNew %>"
                                                        OnClick="btnClear_Click" />
                                                    <asp:Button ID="btnContactDetails" CssClass="cssButton" runat="server" Text="<%$ Resources:Resource,ContactDetails %>"
                                                        OnClick="btnContactDetails_Click" />
                                                    <asp:Button ID="btnCompensationDetails" Width="200px" CssClass="cssButton" runat="server"
                                                        Text="<%$ Resources:Resource,compensationDetail %>" OnClick="btnCompensationDetails_Click" />
                                                    <asp:Button ID="btnTrainingDetails" Width="120px" CssClass="cssButton" runat="server"
                                                        Text="<%$ Resources:Resource,Training %>" OnClick="btnTrainingDetails_Click" />
                                                    <asp:HiddenField ID="HFEmployeeAutoGenerateStatus" runat="server" />
                                                </center>
                                            </ContentTemplate>
                                        </AjaxToolKit:TabPanel>
                                        <AjaxToolKit:TabPanel Style="text-align: left;" ID="EmpConstraint" runat="server" HeaderText="<%$Resources:Resource,EmployeeConstraint %>"
                                            TabIndex="1" Height="420px">
                                            <ContentTemplate>
                                                <table align="center" width="900px" border="0" cellspacing="0px" cellpadding="0px">
                                                    <tr>
                                                        <td style="text-align: right; width: 120px" nowrap="nowrap">
                                                            <asp:Label ID="lblEmployeeCon" Width="100px" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,EmployeeNumber %>"></asp:Label>
                                                            &nbsp;
                                                        </td>
                                                        <td style="text-align: left; width: 150px" nowrap="nowrap">
                                                            <asp:TextBox ID="txtEmployeeNumberCon" AutoPostBack="True" Enabled="false" CssClass="csstxtbox"
                                                                MaxLength="6" runat="server" Font-Bold="True"></asp:TextBox>
                                                        </td>
                                                        <td style="text-align: left; width: 75px" nowrap="nowrap">
                                                            <asp:Label ID="lblEmployeeName" Width="100px" CssClass="cssLable" runat="server"
                                                                Text="<%$ Resources:Resource,EmployeeName %>"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left; width: 350px" nowrap="nowrap">
                                                            <asp:TextBox ID="txtEmployeeNameCon" Width="275px" AutoPostBack="True" Enabled="false"
                                                                CssClass="csstxtbox" MaxLength="6" runat="server" Font-Bold="True"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4" style="text-align: right;">
                                                            <asp:Label ID="lblEmpConstraintErrorMsg" runat="server" CssClass="csslblErrMsg" EnableViewState="false"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <asp:GridView Width="900px" ID="gvEmployeeConstraint" CssClass="GridViewStyle" runat="server"
                                                    ShowFooter="true" ShowHeader="true" Visible="true" AllowPaging="true" PageSize="15"
                                                    CellPadding="1" GridLines="None" AutoGenerateColumns="False" OnRowDeleting="gvEmployeeConstraint_RowDeleting"
                                                    OnRowDataBound="gvEmployeeConstraint_RowDataBound" OnRowCancelingEdit="gvEmployeeConstraint_RowCancelingEdit"
                                                    OnRowUpdating="gvEmployeeConstraint_RowUpdating" OnRowEditing="gvEmployeeConstraint_RowEditing"
                                                    OnRowCommand="gvEmployeeConstraint_RowCommand" OnPageIndexChanging="gvEmployeeConstraint_PageIndexChanging">
                                                    <FooterStyle CssClass="GridViewFooterStyle" />
                                                    <RowStyle CssClass="GridViewRowStyle" />
                                                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                    <PagerStyle CssClass="GridViewPagerStyle" />
                                                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblaction" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, EditColName %>"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="ImgbtnDelete" runat="server" CssClass="cssImgButton" CommandName="Delete"
                                                                    ToolTip="<%$ Resources:Resource, Delete %>" ImageUrl="../Images/Delete.gif" />
                                                                <asp:LinkButton Visible="false" runat="server" ID="lnkbtnDelete" CssClass="csslnkButton"
                                                                    Text="<%$ Resources:Resource, Delete %>" CommandName="Delete"></asp:LinkButton>
                                                                &nbsp;
                                                                <asp:ImageButton ID="ImgbtnEdit" runat="server" CssClass="cssImgButton" CommandName="Edit"
                                                                    ToolTip="<%$ Resources:Resource, Edit %>" ImageUrl="../Images/Edit.gif" />
                                                                <asp:LinkButton Visible="false" runat="server" ID="lnkbtnEdit" CssClass="csslnkButton"
                                                                    Text="<%$ Resources:Resource, Edit %>" CommandName="Edit"></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:ImageButton ID="ImgbtnUpdate" runat="server" CssClass="cssImgButton" CommandName="Update"
                                                                    ValidationGroup="vgCEdit" ToolTip="<%$ Resources:Resource, Update %>" ImageUrl="../Images/Save.gif" />
                                                                <asp:LinkButton Visible="false" runat="server" ID="lnkbtnUpdate" CssClass="csslnkButton"
                                                                    ValidationGroup="vgCEdit" Text="<%$ Resources:Resource, Update %>" CommandName="Update"></asp:LinkButton>
                                                                &nbsp;
                                                                <asp:ImageButton ID="ImgbtnCancel" runat="server" CssClass="cssImgButton" CommandName="Cancel"
                                                                    ToolTip="<%$ Resources:Resource, Cancel %>" ImageUrl="../Images/Cancel.gif" />
                                                                <asp:LinkButton Visible="false" runat="server" ID="lnkbtnCancel" CssClass="csslnkButton"
                                                                    Text="<%$ Resources:Resource, Cancel %>" CommandName="Cancel"></asp:LinkButton>
                                                            </EditItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:ImageButton ID="ImgbtnAdd" runat="server" CssClass="cssImgButton" CommandName="Add"
                                                                    ToolTip="<%$Resources:Resource,Save %>" ValidationGroup="vgCFooter" ImageUrl="../Images/AddNew.gif" />
                                                                <asp:LinkButton Visible="false" runat="server" ID="lnkbtnAdd" CssClass="csslnkButton"
                                                                    Text="<%$ Resources:Resource, AddNew %>" ValidationGroup="vgCFooter" CommandName="Add"></asp:LinkButton>
                                                                &nbsp;
                                                                <asp:ImageButton ID="ImgbtnReset" runat="server" CssClass="cssImgButton" CommandName="Reset"
                                                                    ToolTip="<%$ Resources:Resource, Reset %>" ImageUrl="../Images/Reset.gif" />
                                                                <asp:LinkButton Visible="false" runat="server" ID="lnkbtnReset" CssClass="csslnkButton"
                                                                    Text="<%$ Resources:Resource, Reset %>" CommandName="Reset"></asp:LinkButton>
                                                            </FooterTemplate>
                                                            <ItemStyle Width="100px" />
                                                            <HeaderStyle Width="100px" />
                                                            <FooterStyle Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblgvhdrSerialNo" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,SerialNumber %>"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSerialNo" CssClass="cssLabel" runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle Width="50px" />
                                                            <HeaderStyle Width="50px" />
                                                            <FooterStyle Width="50px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="<%$Resources:Resource,ConstraintType %>">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblConstraintType" runat="server" CssClass="cssLabel" Text='<%# DataBinder.Eval(Container.DataItem, "ConstraintTypeDesc").ToString()%>'></asp:Label>
                                                                <asp:HiddenField ID="HFConstraintTypeAutoID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "ConstraintTypeAutoID").ToString()%>' />
                                                                <asp:HiddenField ID="HFEmployeeConstraintAutoID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "EmployeeConstraintAutoID").ToString()%>' />
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:DropDownList ID="ddlConstraintType" runat="server" CssClass="cssDropDown" AutoPostBack="true"
                                                                    OnSelectedIndexChanged="ddlConstraintType_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                                <asp:HiddenField ID="HFConstraintTypeAutoID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "ConstraintTypeAutoID").ToString()%>' />
                                                                <asp:HiddenField ID="HFEmployeeConstraintAutoID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "EmployeeConstraintAutoID").ToString()%>' />
                                                            </EditItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:DropDownList ID="ddlConstraintType" AutoPostBack="true" OnSelectedIndexChanged="ddlConstraintType_SelectedIndexChanged"
                                                                    runat="server" CssClass="cssDropDown">
                                                                </asp:DropDownList>
                                                            </FooterTemplate>
                                                            <ItemStyle Width="100px" />
                                                            <HeaderStyle Width="100px" />
                                                            <FooterStyle Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="<%$Resources:Resource,Description %>">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblConstraintDesc" runat="server" CssClass="cssLabel" Text='<%# DataBinder.Eval(Container.DataItem, "ConstraintDesc").ToString()%>'></asp:Label>
                                                                <asp:HiddenField ID="HFConstraintCode" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "ConstraintCode").ToString()%>' />
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:DropDownList ID="ddlConstraintDesc" Width="250px" AutoPostBack="true" OnSelectedIndexChanged="ddlConstraintDesc_SelectedIndexChanged"
                                                                    runat="server" CssClass="cssDropDown">
                                                                </asp:DropDownList>
                                                                <asp:HiddenField ID="HFConstraintCode" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "ConstraintCode").ToString()%>' />
                                                                <asp:HiddenField ID="HFConstraintAutoID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "ConstraintAutoID").ToString()%>' />
                                                            </EditItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:DropDownList ID="ddlConstraintDesc" Width="250px" AutoPostBack="true" OnSelectedIndexChanged="ddlConstraintDesc_SelectedIndexChanged"
                                                                    runat="server" CssClass="cssDropDown">
                                                                </asp:DropDownList>
                                                            </FooterTemplate>
                                                            <ItemStyle Width="300px" />
                                                            <HeaderStyle Width="300px" />
                                                            <FooterStyle Width="300px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="<%$Resources:Resource,Value %>">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblValue" runat="server" CssClass="cssLabel" Text='<%# DataBinder.Eval(Container.DataItem, "Value").ToString()%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:DropDownList ID="ddlValue" Style="display: none;" Width="150px" runat="server"
                                                                    CssClass="cssDropDown">
                                                                </asp:DropDownList>
                                                                <asp:TextBox ID="txtValue" Width="150px" runat="server" CssClass="csstxtbox" Text='<%# DataBinder.Eval(Container.DataItem, "Value").ToString()%>'></asp:TextBox>
                                                            </EditItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:DropDownList ID="ddlValue" Style="display: none;" Width="150px" runat="server"
                                                                    CssClass="cssDropDown">
                                                                </asp:DropDownList>
                                                                <asp:TextBox ID="txtValue" Width="150px" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="<%$Resources:Resource,Remarks %>">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRemarks" runat="server" CssClass="cssLabel" Text='<%# DataBinder.Eval(Container.DataItem, "Remarks").ToString()%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="txtRemarks" Width="150px" runat="server" CssClass="csstxtbox" Text='<%# DataBinder.Eval(Container.DataItem, "Remarks").ToString()%>'></asp:TextBox>
                                                            </EditItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:TextBox ID="txtRemarks" Width="150px" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </ContentTemplate>
                                        </AjaxToolKit:TabPanel>
                                        <AjaxToolKit:TabPanel Style="text-align: left;" ID="PanelEmployeePreferances" runat="server"
                                            HeaderText="<%$Resources:Resource,EmployeePreferances %>" TabIndex="2">
                                            <ContentTemplate>
                                                <asp:Panel ID="pnlEmpPreferances" runat="server" ScrollBars="Auto" Height="420px">
                                                    <table align="center" width="900px" border="0px" cellspacing="0px" cellpadding="0px">
                                                        <tr>
                                                            <td style="text-align: right; width: 120px" nowrap="nowrap">
                                                                <asp:Label ID="lblEmployeeEmployeePreferances" Width="100px" CssClass="cssLable"
                                                                    runat="server" Text="<%$ Resources:Resource,EmployeeNumber %>"></asp:Label>
                                                                &nbsp;
                                                            </td>
                                                            <td style="text-align: left; width: 150px" nowrap="nowrap">
                                                                <asp:TextBox ID="txtEmployeeNumberEmployeePreferances" AutoPostBack="True" Enabled="false"
                                                                    CssClass="csstxtbox" MaxLength="6" runat="server" Font-Bold="True"></asp:TextBox>
                                                            </td>
                                                            <td style="text-align: left; width: 75px" nowrap="nowrap">
                                                                <asp:Label ID="lblEmployeeNameEmployeePreferances" Width="100px" CssClass="cssLable"
                                                                    runat="server" Text="<%$ Resources:Resource,EmployeeName %>"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left; width: 350px" nowrap="nowrap">
                                                                <asp:TextBox ID="txtEmployeeNameEmployeePreferances" Width="275px" AutoPostBack="True"
                                                                    Enabled="false" CssClass="csstxtbox" MaxLength="6" runat="server" Font-Bold="True"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <asp:GridView ID="gvEmployeePreferances" Width="700px" runat="server" AllowPaging="True"
                                                        OnRowDataBound="gvEmployeePreferances_RowDataBound" AutoGenerateColumns="False"
                                                        OnRowCommand="gvEmployeePreferances_RowCommand" OnRowEditing="gvEmployeePreferances_OnRowEditing"
                                                        OnRowCancelingEdit="gvEmployeePreferances_OnRowCancelingEdit" OnRowUpdating="gvEmployeePreferances_RowUpdating"
                                                        OnRowDeleting="gvEmployeePreferances_RowDeleting" ShowFooter="True" PageSize="15">
                                                        <FooterStyle CssClass="GridViewFooterStyle" />
                                                        <RowStyle CssClass="GridViewRowStyle" />
                                                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                        <PagerStyle CssClass="GridViewPagerStyle" />
                                                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                        <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="<%$ Resources:Resource,EditColName %>">
                                                                <EditItemTemplate>
                                                                    <asp:ImageButton ID="ImgbtnUpdate" ToolTip="<%$Resources:Resource,Update %>" ImageUrl="~/Images/save.gif"
                                                                        CssClass="csslnkButton" runat="server" CommandName="Update" CommandArgument='<%# Container.DataItemIndex %>' />
                                                                    <asp:ImageButton ID="ImageButton2Tran" ToolTip="<%$Resources:Resource,Cancel %>"
                                                                        ImageUrl="~/Images/Cancel.gif" CssClass="csslnkButton" runat="server" CausesValidation="False"
                                                                        CommandName="Cancel" />
                                                                </EditItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:ImageButton ID="lbADD" runat="server" ToolTip="<%$Resources:Resource,Save %>"
                                                                        CssClass="cssImgButton" CommandName="AddNew" ImageUrl="../Images/AddNew.gif" />
                                                                    <asp:ImageButton ID="lbReset" ToolTip="<%$Resources:Resource,Reset %>" runat="server"
                                                                        CssClass="cssImgButton" CommandName="Reset" ImageUrl="../Images/Reset.gif" />
                                                                </FooterTemplate>
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="IBEdit" ToolTip="<%$Resources:Resource,Edit %>" ImageUrl="~/Images/Edit.gif"
                                                                        CssClass="csslnkButton" runat="server" CausesValidation="False" CommandName="Edit" />
                                                                    <asp:ImageButton ID="IBDelete" ToolTip="<%$Resources:Resource,Delete %>" ImageUrl="~/Images/Delete.gif"
                                                                        runat="server" CssClass="csslnkButton" CausesValidation="False" CommandName="Delete" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="<%$Resources:Resource,ClientCode %>" HeaderStyle-Width="150px"
                                                                HeaderStyle-CssClass="cssLabel">
                                                                <FooterTemplate>
                                                                    <asp:DropDownList ID="ddlFooterEmpPrefClients" CssClass="cssDropDown" Width="150px"
                                                                        runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlFooterEmpPrefClients_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                </FooterTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblClientName" runat="server" Text='<%# Bind("ClientName") %>'></asp:Label>
                                                                    <asp:HiddenField ID="HFClientCode" runat="server" Value='<%#Bind("ClientCode") %>' />
                                                                    <asp:HiddenField ID="hfAsmtCode" runat="server" Value='<%# Bind("AsmtCode") %>' />
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:DropDownList ID="ddlEmpPrefClients" Enabled="false" CssClass="cssDropDown" Width="150px"
                                                                        runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlEmpPrefClients_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                    <asp:HiddenField ID="HFClientCode" runat="server" Value='<%#Bind("ClientCode") %>' />
                                                                    <asp:HiddenField ID="hfAsmtCode" runat="server" Value='<%# Bind("AsmtCode") %>' />
                                                                </EditItemTemplate>
                                                                <HeaderStyle CssClass="cssLabelHeader" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="<%$Resources:Resource,AsmtId %>" HeaderStyle-Width="160px">
                                                                <FooterTemplate>
                                                                    <asp:DropDownList ID="ddlFooterEmpPrefAsmtCode" CssClass="cssDropDown" Width="160px"
                                                                        AutoPostBack="true" OnSelectedIndexChanged="ddlFooterEmpPrefAsmtCode_SelectedIndexChanged"
                                                                        runat="server">
                                                                    </asp:DropDownList>
                                                                </FooterTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblAsmtdesc" runat="server" Text='<%# Bind("AsmtDetail") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:DropDownList ID="ddlEmpPrefAsmtCode" Enabled="false" CssClass="cssDropDown"
                                                                        Width="160px" runat="server">
                                                                    </asp:DropDownList>
                                                                </EditItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="ShiftPref" HeaderStyle-Width="80px" Visible="false">
                                                                <FooterTemplate>
                                                                    <asp:DropDownList ID="ddlFooterShiftPref" AutoPostBack="true" CssClass="cssDropDown"
                                                                        Width="80px" runat="server">
                                                                        <asp:ListItem Text="ALL" Value="" Selected="True"></asp:ListItem>
                                                                        <asp:ListItem Text="Day Shift" Value="D"></asp:ListItem>
                                                                        <asp:ListItem Text="Night Shift" Value="N"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:HiddenField ID="HFDayShiftTimeFrom" runat="server" Value='<%# Bind("DayShiftTimeFrom") %>' />
                                                                    <asp:HiddenField ID="HFDayShiftTimeTo" runat="server" Value='<%# Bind("DayShiftTimeTo") %>' />
                                                                    <asp:HiddenField ID="HFNightShiftTimeFrom" runat="server" Value='<%# Bind("NightShiftTimeFrom") %>' />
                                                                    <asp:HiddenField ID="HFNightShiftTimeTo" runat="server" Value='<%# Bind("NightShiftTimeTo") %>' />
                                                                </FooterTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblShiftPref" runat="server" Text='<%# Bind("ShiftPref") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:DropDownList ID="ddlShiftPref" CssClass="cssDropDown" Width="80px" runat="server">
                                                                        <asp:ListItem Text="ALL" Value="" Selected="True"></asp:ListItem>
                                                                        <asp:ListItem Text="Day Shift" Value="D"></asp:ListItem>
                                                                        <asp:ListItem Text="Night Shift" Value="N"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:HiddenField ID="HFShiftPrefCode" runat="server" Value='<%# Bind("ShiftPrefCode") %>' />
                                                                    <asp:HiddenField ID="HFDayShiftTimeFrom" runat="server" Value='<%# Bind("DayShiftTimeFrom") %>' />
                                                                    <asp:HiddenField ID="HFDayShiftTimeTo" runat="server" Value='<%# Bind("DayShiftTimeTo") %>' />
                                                                    <asp:HiddenField ID="HFNightShiftTimeFrom" runat="server" Value='<%# Bind("NightShiftTimeFrom") %>' />
                                                                    <asp:HiddenField ID="HFNightShiftTimeTo" runat="server" Value='<%# Bind("NightShiftTimeTo") %>' />
                                                                </EditItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Sun">
                                                                <FooterTemplate>
                                                                    <asp:CheckBox ID="CBSun" runat="server" Checked="true" CssClass="cssCheckBox" />
                                                                </FooterTemplate>
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="CBSun" Enabled="false" CssClass="cssCheckBox" runat="server" Checked='<%# bool.Parse(DataBinder.Eval(Container.DataItem, "Sun").ToString())%>' />
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:CheckBox ID="CBSun" CssClass="cssCheckBox" runat="server" Checked='<%# bool.Parse(DataBinder.Eval(Container.DataItem, "Sun").ToString())%>' />
                                                                </EditItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Mon">
                                                                <FooterTemplate>
                                                                    <asp:CheckBox ID="CBMon" runat="server" Checked="true" CssClass="cssCheckBox" />
                                                                </FooterTemplate>
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="CBMon" Enabled="false" CssClass="cssCheckBox" runat="server" Checked='<%# bool.Parse(DataBinder.Eval(Container.DataItem, "Mon").ToString())%>' />
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:CheckBox ID="CBMon" CssClass="cssCheckBox" runat="server" Checked='<%# bool.Parse(DataBinder.Eval(Container.DataItem, "Mon").ToString())%>' />
                                                                </EditItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Tue">
                                                                <FooterTemplate>
                                                                    <asp:CheckBox ID="CBTue" runat="server" Checked="true" CssClass="cssCheckBox" />
                                                                </FooterTemplate>
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="CBTue" Enabled="false" CssClass="cssCheckBox" runat="server" Checked='<%# bool.Parse(DataBinder.Eval(Container.DataItem, "Tue").ToString())%>' />
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:CheckBox ID="CBTue" CssClass="cssCheckBox" runat="server" Checked='<%# bool.Parse(DataBinder.Eval(Container.DataItem, "Tue").ToString())%>' />
                                                                </EditItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Wed">
                                                                <FooterTemplate>
                                                                    <asp:CheckBox ID="CBWed" runat="server" Checked="true" CssClass="cssCheckBox" />
                                                                </FooterTemplate>
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="CBWed" Enabled="false" CssClass="cssCheckBox" runat="server" Checked='<%# bool.Parse(DataBinder.Eval(Container.DataItem, "Wed").ToString())%>' />
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:CheckBox ID="CBWed" CssClass="cssCheckBox" runat="server" Checked='<%# bool.Parse(DataBinder.Eval(Container.DataItem, "Wed").ToString())%>' />
                                                                </EditItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Thu">
                                                                <FooterTemplate>
                                                                    <asp:CheckBox ID="CBThu" runat="server" Checked="true" CssClass="cssCheckBox" />
                                                                </FooterTemplate>
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="CBThu" Enabled="false" CssClass="cssCheckBox" runat="server" Checked='<%# bool.Parse(DataBinder.Eval(Container.DataItem, "Thu").ToString())%>' />
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:CheckBox ID="CBThu" CssClass="cssCheckBox" runat="server" Checked='<%# bool.Parse(DataBinder.Eval(Container.DataItem, "Thu").ToString())%>' />
                                                                </EditItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Fri">
                                                                <FooterTemplate>
                                                                    <asp:CheckBox ID="CBFri" runat="server" Checked="true" CssClass="cssCheckBox" />
                                                                </FooterTemplate>
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="CBFri" Enabled="false" CssClass="cssCheckBox" runat="server" Checked='<%# bool.Parse(DataBinder.Eval(Container.DataItem, "Fri").ToString())%>' />
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:CheckBox ID="CBFri" CssClass="cssCheckBox" runat="server" Checked='<%# bool.Parse(DataBinder.Eval(Container.DataItem, "Fri").ToString())%>' />
                                                                </EditItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Sat">
                                                                <FooterTemplate>
                                                                    <asp:CheckBox ID="CBSat" runat="server" Checked="true" CssClass="cssCheckBox" />
                                                                </FooterTemplate>
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="CBSat" Enabled="false" CssClass="cssCheckBox" runat="server" Checked='<%# bool.Parse(DataBinder.Eval(Container.DataItem, "Sat").ToString())%>' />
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:CheckBox ID="CBSat" CssClass="cssCheckBox" runat="server" Checked='<%# bool.Parse(DataBinder.Eval(Container.DataItem, "Sat").ToString())%>' />
                                                                </EditItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Minimum Shift(Weekly)" Visible="false">
                                                                <FooterTemplate>
                                                                    <asp:TextBox ID="txtMinShft" runat="server" MaxLength="5" CssClass="csstxtbox"></asp:TextBox>
                                                                    <asp:RangeValidator ID="rngVal4" ControlToValidate="txtMinShft" runat="server" CssClass="csslblErrMsg"
                                                                        Width="20px" SetFocusOnError="true" ErrorMessage="*" MinimumValue="0" MaximumValue="99999"></asp:RangeValidator>
                                                                    <asp:RegularExpressionValidator runat="server" ID="rxvtxtMinShft" ControlToValidate="txtMinShft"
                                                                        SetFocusOnError="true" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                                                                </FooterTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblMinShft" runat="server" CssClass="cssLabel" Text='<%#  Eval("MinShiftWkly") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtMinShft" MaxLength="5" runat="server" CssClass="csstxtbox" Text='<%# Eval("MinShiftWkly")%>'></asp:TextBox>
                                                                    <asp:RangeValidator ID="rngVal3" ControlToValidate="txtMinShft" runat="server" CssClass="csslblErrMsg"
                                                                        Width="20px" SetFocusOnError="true" ErrorMessage="*" MinimumValue="0" MaximumValue="99999"></asp:RangeValidator>
                                                                    <asp:RegularExpressionValidator runat="server" ID="rxvtxtMinShftFtr" ControlToValidate="txtMinShft"
                                                                        SetFocusOnError="true" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                                                                </EditItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Maximum Shift(Weekly)" Visible="false">
                                                                <FooterTemplate>
                                                                    <asp:TextBox ID="txtMaxShft" MaxLength="5" runat="server" CssClass="csstxtbox" Visible="false"></asp:TextBox>
                                                                    <asp:RangeValidator ID="rngVal2" ControlToValidate="txtMaxShft" runat="server" CssClass="csslblErrMsg"
                                                                        Width="20px" SetFocusOnError="true" ErrorMessage="*" MinimumValue="0" MaximumValue="99999"></asp:RangeValidator>
                                                                    <asp:RegularExpressionValidator runat="server" ID="rxvtxtMaxShft" ControlToValidate="txtMaxShft"
                                                                        SetFocusOnError="true" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                                                                </FooterTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblMaxShft" runat="server" CssClass="cssLabel" Text='<%# Eval("MaxShiftWkly") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtMaxShft" MaxLength="5" runat="server" CssClass="csstxtbox" Text='<%# Eval("MaxShiftWkly") %>'
                                                                        Visible="false"></asp:TextBox>
                                                                    <asp:RangeValidator ID="rngVal1" ControlToValidate="txtMaxShft" runat="server" CssClass="csslblErrMsg"
                                                                        Width="20px" SetFocusOnError="true" ErrorMessage="*" MinimumValue="0" MaximumValue="99999"></asp:RangeValidator>
                                                                    <asp:RegularExpressionValidator runat="server" ID="rxvtxtMaxShftFtr" ControlToValidate="txtMaxShft"
                                                                        SetFocusOnError="true" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                                                                </EditItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </asp:Panel>
                                                <asp:Label ID="lblEmployeePreferances" EnableViewState="false" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                            </ContentTemplate>
                                        </AjaxToolKit:TabPanel>
                                        <AjaxToolKit:TabPanel Style="text-align: left;" ID="PanelBarredAssignments" runat="server"
                                            HeaderText="<%$Resources:Resource,BarredAssignments %>" TabIndex="3" Height="420px">
                                            <ContentTemplate>
                                                <div class="squareboxgradientcaption" style="height: 25px;">
                                                    <asp:Label ID="Label14" runat="server" Text="<%$Resources:Resource,BarredAssignments %>"></asp:Label>
                                                </div>
                                                <div>
                                                    <table align="center" width="100%" border="0" cellspacing="0px" cellpadding="0px">
                                                        <tr>
                                                            <td style="text-align: right; width: 120px" nowrap="nowrap">
                                                                <asp:Label ID="lblEmployeeBarredAssignments" Width="100px" CssClass="cssLable" runat="server"
                                                                    Text="<%$ Resources:Resource,EmployeeNumber %>"></asp:Label>
                                                                &nbsp;
                                                            </td>
                                                            <td style="text-align: left; width: 150px" nowrap="nowrap">
                                                                <asp:TextBox ID="txtEmployeeNumberBarredAssignments" AutoPostBack="True" Enabled="false"
                                                                    CssClass="csstxtbox" MaxLength="6" runat="server" Font-Bold="True"></asp:TextBox>
                                                            </td>
                                                            <td style="text-align: left; width: 75px" nowrap="nowrap">
                                                                <asp:Label ID="lblEmployeeNameBarredAssignments" Width="100px" CssClass="cssLable"
                                                                    runat="server" Text="<%$ Resources:Resource,EmployeeName %>"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left; width: 350px" nowrap="nowrap">
                                                                <asp:TextBox ID="txtEmployeeNameBarredAssignments" Width="275px" AutoPostBack="True"
                                                                    Enabled="false" CssClass="csstxtbox" MaxLength="6" runat="server" Font-Bold="True"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <asp:GridView ID="gvBarredAssignments" Width="860px" runat="server" AllowPaging="True"
                                                        OnRowDataBound="gvBarredAssignments_RowDataBound" AutoGenerateColumns="False"
                                                        OnRowCommand="gvBarredAssignments_RowCommand" OnRowEditing="gvBarredAssignments_OnRowEditing"
                                                        OnRowUpdating="gvBarredAssignments_OnRowUpdating" OnRowCancelingEdit="gvBarredAssignments_OnRowCancelingEdit"
                                                        OnRowDeleting="gvBarredAssignments_RowDeleting" ShowFooter="True" PageSize="15">
                                                        <FooterStyle CssClass="GridViewFooterStyle" />
                                                        <RowStyle CssClass="GridViewRowStyle" />
                                                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                        <PagerStyle CssClass="GridViewPagerStyle" />
                                                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                        <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="<%$Resources:Resource,SerialNumber %>" HeaderStyle-Width="35px">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblSerialNo" CssClass="cssLable" runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="cssLabelHeader" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="<%$Resources:Resource,ClientCode %>" HeaderStyle-Width="150px">
                                                                <FooterTemplate>
                                                                    <asp:DropDownList ID="ddlClients" CssClass="cssDropDown" Width="150px" runat="server"
                                                                        AutoPostBack="true" OnSelectedIndexChanged="ddlFooterClients_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                </FooterTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblClientName" runat="server" Text='<%# Bind("ClientName") %>'></asp:Label>
                                                                    <asp:HiddenField ID="HFBarredAutoID" runat="server" Value='<%#Bind("BarredAutoID") %>' />
                                                                    <asp:HiddenField ID="hfAsmtCode" runat="server" Value='<%# Bind("AsmtID") %>' />
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:DropDownList ID="ddlClients" CssClass="cssDropDown" Width="150px" runat="server"
                                                                        AutoPostBack="true" OnSelectedIndexChanged="ddlClients_SelectedIndexChanged"
                                                                        Enabled="false">
                                                                    </asp:DropDownList>
                                                                    <asp:HiddenField ID="HFClientCode" runat="server" Value='<%#Bind("ClientCode") %>' />
                                                                    <asp:HiddenField ID="hfEditAsmtCode" runat="server" Value='<%# Bind("AsmtID") %>' />
                                                                    <asp:HiddenField ID="HFBarredAutoID" runat="server" Value='<%#Bind("BarredAutoID") %>' />
                                                                </EditItemTemplate>
                                                                <HeaderStyle CssClass="cssLabelHeader" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="<%$Resources:Resource,AsmtId %>" HeaderStyle-Width="120px">
                                                                <FooterTemplate>
                                                                    <asp:DropDownList ID="ddlAsmt" CssClass="cssDropDown" Width="120px" runat="server"
                                                                        AutoPostBack="true" OnSelectedIndexChanged="ddlAsmt_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                </FooterTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblAsmtdesc" runat="server" Text='<%# Bind("AsmtAddress") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:DropDownList ID="ddlAsmt" CssClass="cssDropDown" Width="120px" runat="server"
                                                                        Enabled="false">
                                                                    </asp:DropDownList>
                                                                </EditItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="<%$Resources:Resource,EffectiveFrom %>" HeaderStyle-Width="120px">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblEffectiveFrom" runat="server" CssClass="cssLabel" Text='<%# String.Format("{0:dd-MMM-yyyy}" ,Eval("EffectiveFrom")) %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtEffectiveFrom" Width="80px" CssClass="csstxtbox" runat="server"
                                                                        Text='<%# String.Format("{0:dd-MMM-yyyy}" ,Eval("EffectiveFrom")) %>' AutoPostBack="True"
                                                                        OnTextChanged="txtEffectiveFrom_TextChanged" Enabled="false"></asp:TextBox>
                                                                    <asp:ImageButton ID="imgEffectiveFrom" Style="vertical-align: middle" CausesValidation="true"
                                                                        runat="server" ImageUrl="~/Images/pdate.gif"></asp:ImageButton>
                                                                    <AjaxToolKit:CalendarExtender ID="CalendarExtender144" Format="dd-MMM-yyyy" runat="server"
                                                                        TargetControlID="txtEffectiveFrom" PopupButtonID="imgEffectiveFrom" PopupPosition="BottomLeft">
                                                                    </AjaxToolKit:CalendarExtender>
                                                                </EditItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:TextBox ID="txtFooterEffectiveFrom" Width="80px" CssClass="csstxtbox" runat="server"
                                                                        AutoPostBack="True" OnTextChanged="txtFooterEffectiveFrom_TextChanged" Enabled="false"></asp:TextBox>
                                                                    <asp:ImageButton ID="imgFooterEffectiveFrom" Style="vertical-align: middle" CausesValidation="true"
                                                                        runat="server" ImageUrl="~/Images/pdate.gif"></asp:ImageButton>
                                                                    <AjaxToolKit:CalendarExtender ID="CalendarExtender143" Format="dd-MMM-yyyy" runat="server"
                                                                        TargetControlID="txtFooterEffectiveFrom" PopupButtonID="imgFooterEffectiveFrom"
                                                                        PopupPosition="BottomLeft">
                                                                    </AjaxToolKit:CalendarExtender>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="<%$Resources:Resource,EffectiveTo %>" HeaderStyle-Width="120px">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblEffectiveTo" runat="server" CssClass="cssLabel" Text='<%# String.Format("{0:dd-MMM-yyyy}" ,Eval("EffectiveTo")) %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtEffectiveTo" Width="80px" CssClass="csstxtbox" runat="server"
                                                                        Text='<%# String.Format("{0:dd-MMM-yyyy}" ,Eval("EffectiveTo")) %>' AutoPostBack="True"
                                                                        OnTextChanged="txtEffectiveTo_TextChanged" Enabled="false"></asp:TextBox>
                                                                    <asp:ImageButton ID="imgEffectiveTo" Style="vertical-align: middle" CausesValidation="true"
                                                                        runat="server" ImageUrl="~/Images/pdate.gif"></asp:ImageButton>
                                                                    <AjaxToolKit:CalendarExtender ID="CalendarExtender142" Format="dd-MMM-yyyy" runat="server"
                                                                        TargetControlID="txtEffectiveTo" PopupButtonID="imgEffectiveTo" PopupPosition="BottomLeft">
                                                                    </AjaxToolKit:CalendarExtender>
                                                                </EditItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:TextBox ID="txtFooterEffectiveTo" Width="80px" CssClass="csstxtbox" runat="server"
                                                                        AutoPostBack="True" OnTextChanged="txtFooterEffectiveTo_TextChanged" Enabled="false"></asp:TextBox>
                                                                    <asp:ImageButton ID="imgFooterEffectiveTo" Style="vertical-align: middle" CausesValidation="true"
                                                                        runat="server" ImageUrl="~/Images/pdate.gif"></asp:ImageButton>
                                                                    <AjaxToolKit:CalendarExtender ID="CalendarExtender141" Format="dd-MMM-yyyy" runat="server"
                                                                        TargetControlID="txtFooterEffectiveTo" PopupButtonID="imgFooterEffectiveTo" PopupPosition="BottomLeft">
                                                                    </AjaxToolKit:CalendarExtender>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="<%$Resources:Resource,BarredBy %>" HeaderStyle-Width="100px">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblBarredBy" CssClass="cssLabel" runat="server" Text='<%# ResourceValueOfKey_Get(DataBinder.Eval(Container.DataItem, "BarredBy").ToString())%>'></asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:HiddenField ID="HFBarredBy" runat="server" Value='<%# Bind("BarredBy") %>' />
                                                                    <asp:DropDownList ID="ddlBarredBy" Width="80px" runat="server" CssClass="csstxtboxRequired">
                                                                        <asp:ListItem Text="<%$Resources:Resource,Employee %>" Value="Employee"></asp:ListItem>
                                                                        <asp:ListItem Text="<%$Resources:Resource,Customer %>" Value="Customer"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </EditItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:DropDownList ID="ddlBarredBy" Width="80px" runat="server" CssClass="csstxtboxRequired">
                                                                        <asp:ListItem Text="<%$Resources:Resource,Employee %>" Value="Employee"></asp:ListItem>
                                                                        <asp:ListItem Text="<%$Resources:Resource,Customer %>" Value="Customer"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="<%$Resources:Resource,Reason %>" HeaderStyle-Width="100px">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblReason" CssClass="cssLabel" runat="server" Text='<%# Bind("ReasonDesc") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:HiddenField ID="HFReason" runat="server" Value='<%# Bind("ReasonAutoID") %>' />
                                                                    <asp:DropDownList ID="ddlReason" Width="100px" runat="server" CssClass="csstxtboxRequired">
                                                                    </asp:DropDownList>
                                                                </EditItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:DropDownList ID="ddlReason" Width="100px" runat="server" CssClass="csstxtboxRequired">
                                                                    </asp:DropDownList>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="<%$Resources:Resource,EditColName %>">
                                                                <EditItemTemplate>
                                                                    <asp:ImageButton ID="ImgbtnUpdateTran" ToolTip="<%$Resources:Resource,Update %>"
                                                                        ImageUrl="~/Images/save.gif" CssClass="csslnkButton" runat="server" CommandName="Update"
                                                                        ValidationGroup="Edit" />
                                                                    <asp:ImageButton ID="ImageButton2Tran" ToolTip="<%$Resources:Resource,Cancel %>"
                                                                        ImageUrl="~/Images/Cancel.gif" CssClass="csslnkButton" runat="server" CausesValidation="False"
                                                                        CommandName="Cancel" />
                                                                </EditItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:ImageButton ID="ImgbtnAddAsmt" CommandName="AddNewAsmt" runat="server" ToolTip="<%$Resources:Resource,Save %>"
                                                                        CssClass="cssImgButton" ImageUrl="../Images/AddNew.gif" />
                                                                    &nbsp;
                                                                    <asp:ImageButton ID="ImgbtnReset" ToolTip="<%$Resources:Resource,Reset %>" runat="server"
                                                                        CssClass="cssImgButton" CommandName="Reset" ImageUrl="../Images/Reset.gif" />
                                                                </FooterTemplate>
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="IsDeleteAsmt" ToolTip="<%$Resources:Resource,Delete %>" ImageUrl="~/Images/Delete.gif"
                                                                        runat="server" CssClass="csslnkButton" CausesValidation="False" CommandName="Delete" />
                                                                    <asp:ImageButton ID="ImgbtnEdit" ToolTip="<%$Resources:Resource,Edit %>" ImageUrl="~/Images/Edit.gif"
                                                                        CssClass="csslnkButton" runat="server" CausesValidation="False" CommandName="Edit" />
                                                                </ItemTemplate>
                                                                <FooterStyle Width="60px" />
                                                                <HeaderStyle Width="60px" CssClass="cssLabelHeader" />
                                                                <ItemStyle Width="60px" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                    <asp:Label ID="lblBarredAsmtErrMsg" EnableViewState="false" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                                </div>
                                            </ContentTemplate>
                                        </AjaxToolKit:TabPanel>
                                        <AjaxToolKit:TabPanel Style="text-align: left;" ID="EmpAdditionalDetail" runat="server" Visible="false" HeaderText="<%$Resources:Resource,EmployeeAdditonalDetails %>"
                                            TabIndex="4" Height="420px">
                                            <ContentTemplate>
                                                <table align="center" width="900px" border="0px" cellspacing="0px" cellpadding="0px">
                                                    <tr>
                                                        <td style="text-align: right; width: 120px" nowrap="nowrap">
                                                            <asp:Label ID="lblEmpAdd" Width="100px" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,EmployeeNumber %>"></asp:Label>
                                                            &nbsp;
                                                        </td>
                                                        <td style="text-align: left; width: 150px" nowrap="nowrap">
                                                            <asp:TextBox ID="txtEmpAdd" AutoPostBack="True" Enabled="False" CssClass="csstxtbox"
                                                                MaxLength="6" runat="server" Font-Bold="True"></asp:TextBox>
                                                        </td>
                                                        <td style="text-align: left; width: 75px" nowrap="nowrap">
                                                            <asp:Label ID="lblEmpName" Width="100px" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,EmployeeName %>"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left; width: 350px" nowrap="nowrap">
                                                            <asp:TextBox ID="txtEmpName" Width="275px" AutoPostBack="True" Enabled="False" CssClass="csstxtbox"
                                                                MaxLength="6" runat="server" Font-Bold="True"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4" style="text-align: right;">
                                                            <asp:Label ID="lblErrorAddEmp" runat="server" CssClass="csslblErrMsg" EnableViewState="False"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <asp:Panel ID="panelAdditional" CssClass="cssLabelHeader" runat="server" GroupingText="Additional Details"
                                                    Width="900px">
                                                    <table width="100%">
                                                        <tr>
                                                            <td style="width: 100px; text-align: right">
                                                                <asp:Label ID="lblRate" runat="server" CssClass="cssLabel" Text="<%$ Resources:Resource,Rate %>"></asp:Label>
                                                            </td>
                                                            <td style="width: 180px; text-align: left">
                                                                <asp:TextBox ID="txtRate" runat="server" CssClass="csstxtbox" Width="100px"></asp:TextBox>
                                                                <asp:RangeValidator runat="server" ControlToValidate="txtRate" ID="valtxtRate" ErrorMessage="(Numeric)"
                                                                    Type="Double" SetFocusOnError="True" Width="50px"></asp:RangeValidator>
                                                            </td>
                                                            <td style="width: 100px; text-align: right">
                                                                <asp:Label ID="lblJobCode" runat="server" CssClass="cssLabel" Text="<%$ Resources:Resource,JobCode %>"></asp:Label>
                                                            </td>
                                                            <td align="left" style="width: 125px; text-align: left">
                                                                <asp:TextBox ID="txtJobCode" runat="server" CssClass="csstxtbox" MaxLength="20"></asp:TextBox>
                                                            </td>
                                                            <td style="width: 100px; text-align: right">
                                                                <asp:Label ID="lblAddType" runat="server" CssClass="cssLabel" Text="<%$ Resources:Resource,AdditionalType %>"></asp:Label>
                                                            </td>
                                                            <td align="left" style="width: 125px; text-align: left">
                                                                <asp:TextBox ID="txtAddType" runat="server" CssClass="csstxtbox" MaxLength="255"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 100px; text-align: right">
                                                                <asp:Label ID="lblOTdayCode" runat="server" CssClass="cssLabel" Text="<%$ Resources:Resource,OTDayCode %>"></asp:Label>
                                                            </td>
                                                            <td style="width: 180px; text-align: left">
                                                                <asp:TextBox ID="txtOTdayCode" runat="server" CssClass="csstxtbox" Width="100px"
                                                                    MaxLength="20"></asp:TextBox>
                                                            </td>
                                                            <td style="width: 100px; text-align: right">
                                                                <asp:Label ID="lblOtDayDesc" runat="server" CssClass="cssLabel" Text="<%$ Resources:Resource,OTDayDesc %>"></asp:Label>
                                                            </td>
                                                            <td style="width: 125px; text-align: left">
                                                                <asp:TextBox ID="txtOtDayDesc" runat="server" CssClass="csstxtbox" Width="120px"
                                                                    MaxLength="255"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 100px; text-align: right">
                                                                <asp:Label ID="lblOTNghtCode" runat="server" CssClass="cssLabel" Text="<%$ Resources:Resource,OTNghtCode %>"></asp:Label>
                                                            </td>
                                                            <td style="width: 125px; text-align: left">
                                                                <asp:TextBox ID="txtOTNghtCode" runat="server" CssClass="csstxtbox" Width="100px"
                                                                    MaxLength="20"></asp:TextBox>
                                                            </td>
                                                            <td style="width: 100px; text-align: right">
                                                                <asp:Label ID="lblOTNghtDesc" runat="server" CssClass="cssLabel" Text="<%$ Resources:Resource,OTNghtDesc %>"></asp:Label>
                                                            </td>
                                                            <td style="width: 125px; text-align: left">
                                                                <asp:TextBox ID="txtOTNghtDesc" runat="server" CssClass="csstxtbox" Width="120px"
                                                                    MaxLength="255"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 100px; text-align: right">
                                                                <asp:Label ID="lblWthExtra" runat="server" CssClass="cssLabel" Text="<%$ Resources:Resource,WithoutExtra %>"></asp:Label>
                                                            </td>
                                                            <td style="width: 180px; text-align: left">
                                                                <asp:CheckBox ID="chkWthExtra" runat="server" CssClass="cssCheckBox" />
                                                            </td>
                                                            <td style="width: 100px; text-align: right">
                                                                <asp:Label ID="lblMoneyExtra" runat="server" CssClass="cssLabel" Text="<%$ Resources:Resource,MoneyExtraType %>"></asp:Label>
                                                            </td>
                                                            <td align="left" style="width: 125px; text-align: left">
                                                                <asp:TextBox ID="txtMoneyExtra" runat="server" CssClass="csstxtbox" MaxLength="255"></asp:TextBox>
                                                            </td>
                                                            <td style="width: 100px; text-align: right">
                                                                <asp:Label ID="lblTotal" runat="server" CssClass="cssLabel" Text="<%$ Resources:Resource,Total %>"></asp:Label>
                                                            </td>
                                                            <td align="left" style="width: 195px; text-align: left">
                                                                <asp:TextBox ID="txtTotal" runat="server" CssClass="csstxtbox" MaxLength="20"></asp:TextBox>
                                                                <asp:DropDownList ID="ddlTotal" runat="server" CssClass="csstxtboxRequired">
                                                                    <asp:ListItem Text="Sum" Value="S" Selected="True"></asp:ListItem>
                                                                    <asp:ListItem Text="Per" Value="P"></asp:ListItem>
                                                                    <asp:ListItem Text="Qty" Value="Q"></asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:RangeValidator runat="server" ControlToValidate="txtTotal" ID="RangeValidator1"
                                                                    ErrorMessage="(Numeric)" Type="Double" SetFocusOnError="True" Width="50px"></asp:RangeValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 100px; text-align: right">
                                                                <asp:Label ID="lblWorkHrs" runat="server" CssClass="cssLabel" Text="<%$ Resources:Resource,WorkHrs %>"></asp:Label>
                                                            </td>
                                                            <td style="width: 180px; text-align: left">
                                                                <asp:TextBox ID="txtWorkHrs" runat="server" CssClass="csstxtbox" MaxLength="20"></asp:TextBox>
                                                                <asp:RangeValidator runat="server" ControlToValidate="txtWorkHrs" ID="RangeValidator2"
                                                                    ErrorMessage="(Numeric)" Type="Double" SetFocusOnError="True" Width="50px"></asp:RangeValidator>
                                                            </td>
                                                            <td style="width: 100px; text-align: right">
                                                                <asp:Label ID="lblSymbol" runat="server" CssClass="cssLabel" Text="<%$ Resources:Resource,Symbol %>"></asp:Label>
                                                            </td>
                                                            <td align="left" style="width: 125px; text-align: left">
                                                                <asp:TextBox ID="txtSymbol" runat="server" CssClass="csstxtbox" MaxLength="255"></asp:TextBox>
                                                            </td>
                                                            <td style="width: 100px; text-align: right">
                                                                <asp:Label ID="lblTime" runat="server" CssClass="cssLabel" Text="<%$ Resources:Resource,Time %>"></asp:Label>
                                                            </td>
                                                            <td style="width: 180px; text-align: left">
                                                                <asp:TextBox ID="txtTime" runat="server" CssClass="csstxtbox" MaxLength="20"></asp:TextBox>
                                                                <asp:RangeValidator runat="server" ControlToValidate="txtTime" ID="RangeValidator3"
                                                                    ErrorMessage="(Numeric)" Type="Double" SetFocusOnError="True" Width="50px"></asp:RangeValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6">
                                                                <table width="100%">
                                                                    <tr align="center">
                                                                        <td style="width: 50%" align="right">
                                                                            <asp:Button ID="btnSubmitAdd" CssClass="cssButton" runat="server" ValidationGroup="NewEmployee"
                                                                                Text="<%$ Resources:Resource,Submit %>" OnClick="btnSubmitAdd_Click" />
                                                                        </td>
                                                                        <td style="width: 50%" align="left">
                                                                            <asp:Button ID="btnDelete" CssClass="cssButton" runat="server" Text="<%$ Resources:Resource,Delete %>"
                                                                                OnClick="btnDelete_Click" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </ContentTemplate>
                                        </AjaxToolKit:TabPanel>
                                        <AjaxToolKit:TabPanel Style="text-align: left;" ID="Employeeworkhistory" runat="server"
                                            HeaderText="<%$Resources:Resource,EmployeeWorkHistory %>" TabIndex="5" Height="420px">
                                            <ContentTemplate>
                                                <table align="center" width="900px" border="0px" cellspacing="0px" cellpadding="0px">
                                                    <tr>
                                                        <td style="text-align: right; width: 120px" nowrap="nowrap">
                                                            <asp:Label ID="lblEmpHistoryEmployeeNumber" Width="100px" CssClass="cssLable" runat="server"
                                                                Text="<%$ Resources:Resource,EmployeeNumber %>"></asp:Label>
                                                            &nbsp;
                                                        </td>
                                                        <td style="text-align: left; width: 150px" nowrap="nowrap">
                                                            <asp:TextBox ID="txtEmpHistoryEmployeeNumber" Enabled="false" CssClass="csstxtbox"
                                                                MaxLength="6" runat="server" Font-Bold="True"></asp:TextBox>
                                                        </td>
                                                        <td style="text-align: left; width: 75px" nowrap="nowrap">
                                                            <asp:Label ID="lblEmpHistoryEmployeeName" Width="100px" CssClass="cssLable" runat="server"
                                                                Text="<%$ Resources:Resource,EmployeeName %>"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left; width: 200px" nowrap="nowrap">
                                                            <asp:TextBox ID="txtEmpHistoryEmployeeName" Width="200px" Enabled="false" CssClass="csstxtbox"
                                                                MaxLength="6" runat="server" Font-Bold="True"></asp:TextBox>
                                                        </td>
                                                        <td align="right" style="width:150px;">
                                                            <asp:Label ID="lblConfirmDuty" Width="100px" CssClass="cssLable" runat="server" Visible="false" Text="<%$ Resources:Resource, ConfirmDuty %>"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="ddlConfirmDuty" runat="server" Width="200px" MaxHeight="350px" CssClass="csstxtboxRequired" Visible= "false"
                                                                AutoPostBack="true" Filter="StartsWith" OnSelectedIndexChanged="ddlConfirmDuty_SelectedIndexChanged">
                                                                    <asp:ListItem Text="<%$Resources:Resource, All %>" Value="All"  Selected="true" />
                                                                    <asp:ListItem Text="<%$Resources:Resource, Confirmed %>" Value="1" />
                                                                    <asp:ListItem Text="<%$Resources:Resource, NotConfirmed %>" Value="0" />
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <asp:Label ID="lblErrorEmpWorkHistory" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                                <br />
                                                <asp:Panel Width="100%" Height="200px" ID="Panel5" runat="server" ScrollBars="Both">
                                                    <asp:GridView Width="910px" ID="gvEmployeeWorkHistory" CssClass="GridViewStyle" runat="server"
                                                        AllowPaging="True" PageSize="15" CellPadding="1" GridLines="None" AutoGenerateColumns="False">
                                                        <RowStyle CssClass="GridViewRowStyle" />
                                                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                        <PagerStyle CssClass="GridViewPagerStyle" />
                                                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                        <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="<%$ Resources:Resource,ClientName %>">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblClientName" CssClass="cssLabel" runat="server" Text='<%# Bind("ClientName") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                                                                <ItemStyle Width="200px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="<%$ Resources:Resource,AssignmentNumber %>">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblAsmtNo" CssClass="cssLabel" runat="server" Text='<%# Bind("AsmtNo") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                                                                <ItemStyle Width="200px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="<%$ Resources:Resource,StartDate %>">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblStartDate" CssClass="cssLabel" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}" ,Eval("StartDate")) %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="cssLabelHeader" Width="150px" />
                                                                <ItemStyle Width="150px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="<%$ Resources:Resource,LastWorkingDate %>">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblLastWorkingDate" CssClass="cssLabel" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}" ,Eval("LastWorkingDate")) %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="cssLabelHeader" Width="150px" />
                                                                <ItemStyle Width="150px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="<%$ Resources:Resource,DutyCount %>">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblShifts" CssClass="cssLabel" runat="server" Text='<%# Bind("Shifts") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                                                                <ItemStyle Width="100px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="<%$ Resources:Resource,TotalHours %>">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblTotalHours" CssClass="cssLabel" runat="server" Text='<%# Bind("TotalHours") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                                                                <ItemStyle Width="100px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="<%$ Resources:Resource,ConfirmDuty %>">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblConfirmStatus" CssClass="cssLabel" runat="server" Text='<%# GetGlobalResourceObject("Resource", Eval("ConfirmStatus").ToString()) %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                                                                <ItemStyle Width="100px" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </asp:Panel>
                                            </ContentTemplate>
                                        </AjaxToolKit:TabPanel>
                                        <AjaxToolKit:TabPanel Style="text-align: left;" ID="EmpIdDetails" runat="server"
                                            HeaderText="<%$Resources:Resource,IdDetails %>" TabIndex="6">
                                            <ContentTemplate>
                                              <asp:Panel  ScrollBars="Auto" ID="OtherDetail" Font-Bold="True" ForeColor="Red" GroupingText="<%$ Resources:Resource,IdDetails %>" Height="420px" runat="server">
                                                        <asp:GridView Width="1500px"  ID="gvOtherDetails"  CssClass="GridViewStyle" runat="server"
                                                            ShowFooter="True" AllowPaging="True" PageSize="5" CellPadding="1" GridLines="None"
                                                            AutoGenerateColumns="False" OnRowDataBound="gvOtherDetails_RowDataBound" OnRowCommand="gvOtherDetails_OnRowCommand"
                                                            OnRowDeleting="gvOtherDetails_OnRowDeleting" OnRowEditing="gvOtherDetails_OnRowEditing" OnPageIndexChanging="gvOtherDetails_PageIndexChanging"
                                                            OnRowUpdating="gvOtherDetails_OnRowUpdating" OnRowCancelingEdit="gvOtherDetails_OnRowCancelingEdit">
                                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                                            <RowStyle CssClass="GridViewRowStyle" />
                                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,EditColName %>">
                                                                    <EditItemTemplate>
                                                                        <asp:ImageButton ID="ImgbtnUpdateTran" ToolTip="<%$Resources:Resource,Update %>"
                                                                            ImageUrl="~/Images/save.gif" CssClass="csslnkButton"  runat="server" CommandName="Update"
                                                                            ValidationGroup="Edit" />
                                                                        &nbsp;
                                                                        <asp:ImageButton ID="ImageButton2Tran" ToolTip="<%$Resources:Resource,Cancel %>"
                                                                            ImageUrl="~/Images/Cancel.gif" CssClass="csslnkButton" runat="server" CausesValidation="False"
                                                                            CommandName="Cancel" />
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:ImageButton ID="lbADD" runat="server" ToolTip="<%$Resources:Resource,Save %>"
                                                                            CssClass="cssImgButton" ValidationGroup="AddNewID" CommandName="AddNew" ImageUrl="../Images/AddNew.gif" />
                                                                        &nbsp;
                                                                        <asp:ImageButton ID="lbReset" ToolTip="<%$Resources:Resource,Reset %>" runat="server"
                                                                            CssClass="cssImgButton" CommandName="Reset" ImageUrl="../Images/Reset.gif" />
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="IBEditTran" ToolTip="<%$Resources:Resource,Edit %>" ImageUrl="~/Images/Edit.gif"
                                                                            CssClass="csslnkButton" ValidationGroup="EditID" runat="server" CausesValidation="False"
                                                                            CommandName="Edit" />
                                                                        &nbsp;
                                                                        <asp:ImageButton ID="IBDeleteTran" ToolTip="<%$Resources:Resource,Delete %>" ImageUrl="~/Images/Delete.gif"
                                                                            runat="server" CssClass="csslnkButton" CausesValidation="False" CommandName="Delete" />
                                                                    </ItemTemplate>
                                                                    <FooterStyle Width="100px" />
                                                                    <HeaderStyle Width="100px" CssClass="cssLabelHeader" />
                                                                    <ItemStyle Width="100px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,IDType %>">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblIDTypeDesc" CssClass="cssLabel" runat="server" Text='<%# Bind("IDTypeDesc") %>'></asp:Label>
                                                                        <asp:HiddenField ID="HFIDType" Value='<%# Bind("IDType") %>' runat="server" />

                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:DropDownList ID="ddlNewIDType" CssClass="cssDropDown" Width="85%" runat="server">
                                                                        </asp:DropDownList>
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:HiddenField ID="PassportId" runat="server" Value='<%#Bind("PassportId") %>' />
                                                                        <asp:Label ID="Label3" CssClass="cssLabel" runat="server" Text='<%# Bind("IDTypeDesc") %>'></asp:Label>
                                                                        <asp:HiddenField ID="HFIDType" Value='<%# Bind("IDType") %>' runat="server" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                                                                    <ItemStyle Width="200px" />
                                                                    <FooterStyle Width="200px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,IDNumber %>">
                                                                    <EditItemTemplate>
                                                                     
                                                                        <asp:TextBox ID="txtIDNumber" CssClass="csstxtbox" ValidationGroup="EditID" runat="server" Text='<%# Bind("IDNumber") %>' MaxLength="16"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtIDNumber"
                                                                            ErrorMessage="" SetFocusOnError="True" ValidationGroup="EditID" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox ID="txtNewIDNumber" CssClass="csstxtbox" ValidationGroup="AddNewID" runat="server" MaxLength="16"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNewIDNumber"
                                                                            ErrorMessage="" SetFocusOnError="True" ValidationGroup="AddNewID" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                          <asp:HiddenField ID="hfidno" runat="server" Value='<%# Bind("IDNumber") %>' />
                                                                        <asp:Label ID="Label41" CssClass="cssLabel" runat="server" Text='<%# Bind("IDNumber") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                                                                    <ItemStyle Width="200px" />
                                                                    <FooterStyle Width="200px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,DateOfIssue %>">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtDateOfIssue" Width="100px" CssClass="csstxtbox" runat="server" Enabled="true"
                                                                            Text='<%# String.Format("{0:dd-MMM-yyyy}" ,Eval("DateOfIssue")) %>' 
                                                                            OnTextChanged="txtDateOfIssue_TextChanged"></asp:TextBox>
                                                                        <asp:ImageButton ID="imgDateOfIssue" Style="vertical-align: middle" CausesValidation="true"
                                                                            runat="server" ImageUrl="~/Images/pdate.gif"></asp:ImageButton>
                                                                        <AjaxToolKit:CalendarExtender ID="CalendarExtender14" Format="dd-MMM-yyyy" runat="server"
                                                                            TargetControlID="txtDateOfIssue" PopupButtonID="imgDateOfIssue" PopupPosition="TopRight">
                                                                        </AjaxToolKit:CalendarExtender>
                                                                      <%--  <asp:RequiredFieldValidator ID="rfvDateOfIssue" runat="server" ControlToValidate="txtDateOfIssue"
                                                                            ErrorMessage="" SetFocusOnError="True" ValidationGroup="Edit">*</asp:RequiredFieldValidator>--%>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox ID="txtNewDateOfIssue" Width="100px" CssClass="csstxtbox"  Enabled="true"
                                                                            runat="server" OnTextChanged="txtNewDateOfIssue_TextChanged"></asp:TextBox>
                                                                        <asp:ImageButton ID="imgNewDateOfIssue" Style="vertical-align: middle" CausesValidation="true"
                                                                            runat="server" ImageUrl="~/Images/pdate.gif"></asp:ImageButton>
                                                                        <AjaxToolKit:CalendarExtender ID="CalendarExtender13" Format="dd-MMM-yyyy" runat="server"
                                                                            TargetControlID="txtNewDateOfIssue" PopupButtonID="imgNewDateOfIssue" PopupPosition="TopRight">
                                                                        </AjaxToolKit:CalendarExtender>
                                                                        <%--<asp:RequiredFieldValidator ID="rfvNewDateOfIssue" runat="server" ControlToValidate="txtNewDateOfIssue"
                                                                            ErrorMessage="" SetFocusOnError="True" ValidationGroup="AddNew">*</asp:RequiredFieldValidator>--%>
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label42" CssClass="cssLabel" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}" ,Eval("DateOfIssue")) %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                                                                    <ItemStyle Width="200px" />
                                                                    <FooterStyle Width="200px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,DateOfExpiry %>">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtDateOfExpiry" Width="100px" CssClass="csstxtbox" runat="server" 
                                                                            Text='<%# String.Format("{0:dd-MMM-yyyy}" ,Eval("DateOfExpiry")) %>'  Enabled="true"
                                                                            OnTextChanged="txtDateOfExpiry_TextChanged"></asp:TextBox>
                                                                        <asp:ImageButton ID="imgDateOfExpiry" Style="vertical-align: middle" CausesValidation="true"
                                                                            runat="server" ImageUrl="~/Images/pdate.gif"></asp:ImageButton>
                                                                        <AjaxToolKit:CalendarExtender ID="CalendarExtender12" Format="dd-MMM-yyyy" runat="server"
                                                                            TargetControlID="txtDateOfExpiry" PopupButtonID="imgDateOfExpiry" PopupPosition="TopRight">
                                                                        </AjaxToolKit:CalendarExtender>
                                                                       <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator41" runat="server" ControlToValidate="txtDateOfExpiry"
                                                                            ErrorMessage="" SetFocusOnError="True" ValidationGroup="Edit">*</asp:RequiredFieldValidator>--%>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox ID="txtNewDateOfExpiry" Width="100px" CssClass="csstxtbox" 
                                                                            runat="server"  OnTextChanged="txtNewDateOfExpiry_TextChanged"></asp:TextBox>
                                                                        <asp:ImageButton ID="imgNewDateOfExpiry" Style="vertical-align: middle" CausesValidation="true"
                                                                            runat="server" ImageUrl="~/Images/pdate.gif"></asp:ImageButton>
                                                                        <AjaxToolKit:CalendarExtender ID="CalendarExtender11" Format="dd-MMM-yyyy" runat="server"
                                                                            TargetControlID="txtNewDateOfExpiry" PopupButtonID="imgNewDateOfExpiry" PopupPosition="TopRight">
                                                                        </AjaxToolKit:CalendarExtender>
                                                                       <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator34" runat="server" ControlToValidate="txtNewDateOfExpiry"
                                                                            ErrorMessage="" SetFocusOnError="True" ValidationGroup="AddNew">*</asp:RequiredFieldValidator>--%>
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label44" CssClass="cssLabel" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}" ,Eval("DateOfExpiry")) %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                                                                    <ItemStyle Width="200px" />
                                                                    <FooterStyle Width="200px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,IssuingAuthority %>">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtIssuingAuthority" CssClass="csstxtbox" ValidationGroup="EditID" runat="server" Text='<%# Bind("IssuingAuthority") %>'></asp:TextBox>
                                                                   <asp:RequiredFieldValidator ID="RequiredFieldValidator34" runat="server" ControlToValidate="txtIssuingAuthority"
                                                                            ErrorMessage="" SetFocusOnError="True" ValidationGroup="EditID" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                                          </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox ID="txtNewIssuingAuthority" CssClass="csstxtbox" ValidationGroup="AddNewID"
                                                                            runat="server"></asp:TextBox>
                                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator34" runat="server" ControlToValidate="txtNewIssuingAuthority"
                                                                            ErrorMessage="" SetFocusOnError="True" ValidationGroup="AddNewID" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label45" CssClass="cssLabel" runat="server" Text='<%# Bind("IssuingAuthority") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                                                                    <ItemStyle Width="200px" />
                                                                    <FooterStyle Width="200px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,PlaceofBirth %>">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtPlaceofBirth" CssClass="csstxtbox" ValidationGroup="EditID" runat="server" Text='<%# Bind("PlaceofBirth") %>'></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator46" runat="server" ControlToValidate="txtPlaceofBirth"
                                                                            ErrorMessage="" SetFocusOnError="True" ValidationGroup="EditID" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox ID="txtNewPlaceofBirth" CssClass="csstxtbox" ValidationGroup="AddNewID"
                                                                            runat="server"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator38" runat="server" ControlToValidate="txtNewPlaceofBirth"
                                                                            ErrorMessage="" SetFocusOnError="True" ValidationGroup="AddNewID" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label46" CssClass="cssLabel" runat="server" Text='<%# Bind("PlaceofBirth") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                                                                    <ItemStyle Width="200px" />
                                                                    <FooterStyle Width="200px" />
                                                                </asp:TemplateField>
                                                                 <asp:TemplateField HeaderText="<%$ Resources:Resource,Remarks %>">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtRemarks" CssClass="csstxtbox" runat="server" Text='<%# Bind("Remarks") %>'
                                                                            AutoPostBack="True" OnTextChanged="txtRemarks_TextChanged"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        
                                                                        <asp:TextBox ID="txtNewRemarks" CssClass="csstxtbox" runat="server"
                                                                            AutoPostBack="True" OnTextChanged="txtNewRemarks_TextChanged"></asp:TextBox>
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label47" CssClass="cssLabel" runat="server" Text='<%# Bind("Remarks") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                                                                    <ItemStyle Width="200px" />
                                                                    <FooterStyle Width="200px" />
                                                                </asp:TemplateField>
                                                                  <asp:TemplateField HeaderText="Upload Document">
                                                                    <ItemTemplate>
                                                                         <asp:ImageButton ID="lnkbtnUpload" ImageUrl="~/Images/uploaddoc.png" OnClick="lnkbtnUpload_Click"
                                                                          runat="server" />
<%--                                                                        <asp:LinkButton ID="lnkbtnUpload" runat="server"  OnClick="lnkbtnUpload_Click" Text='<%$ Resources:Resource, UploadDocument%>'></asp:LinkButton>--%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                   <asp:Label ID="lblErrorMsgID" EnableViewState="False" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                             </asp:Panel>
                                            </ContentTemplate>
                                        </AjaxToolKit:TabPanel>
                                        <ajaxToolkit:TabPanel Style="text-align: left;" ID="EmployeeBankDetail" runat="server" HeaderText="<%$Resources:Resource,EmployeeBankDetail %>" TabIndex="7" Height="420px">
                                          <ContentTemplate>
                                              <asp:Panel  ScrollBars="Auto" ID="PanelBankDetails" Font-Bold="True" ForeColor="Red" GroupingText="<%$ Resources:Resource,EmployeeBankDetail %>" Height="420px" runat="server">
                                                <asp:GridView Width="125%"  ID="gvEmployeeBankDetail"  CssClass="GridViewStyle" runat="server" ShowFooter="True" AllowPaging="True" PageSize="10" CellPadding="1" GridLines="None"
                                                            AutoGenerateColumns="False" OnRowDataBound="gvEmployeeBankDetail_RowDataBound" OnRowCommand="gvEmployeeBankDetail_RowCommand"
                                                            OnRowDeleting="gvEmployeeBankDetail_RowDeleting" OnRowEditing="gvEmployeeBankDetail_OnRowEditing" OnPageIndexChanging="gvEmployeeBankDetail_PageIndexChanging"
                                                            OnRowUpdating="gvEmployeeBankDetail_RowUpdating" OnRowCancelingEdit="gvEmployeeBankDetail_OnRowCancelingEdit">
                                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                                            <RowStyle CssClass="GridViewRowStyle" />
                                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,EditColName%>">
                                                                    <EditItemTemplate>
                                                                        <asp:ImageButton ID="ImgbtnUpdateTran" ToolTip="<%$Resources:Resource,Update %>"
                                                                            ImageUrl="~/Images/save.gif" CssClass="csslnkButton"   runat="server" CommandName="Update"
                                                                            ValidationGroup="Editbank" />
                                                                       
                                                                        <asp:ImageButton ID="ImageButton2Tran" ToolTip="<%$Resources:Resource,Cancel %>"
                                                                            ImageUrl="~/Images/Cancel.gif" CssClass="csslnkButton" runat="server" CausesValidation="False"
                                                                            CommandName="Cancel" />
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:ImageButton ID="lbADD" runat="server" ToolTip="<%$Resources:Resource,Save %>"
                                                                            CssClass="cssImgButton"  ValidationGroup="Bank" CommandName="AddNew" ImageUrl="../Images/AddNew.gif" />
                                                                       
                                                                        <asp:ImageButton ID="lbReset" ToolTip="<%$Resources:Resource,Reset %>" runat="server"
                                                                            CssClass="cssImgButton" CommandName="Reset" ImageUrl="../Images/Reset.gif" />
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="IBEditTran" ToolTip="<%$Resources:Resource,Edit %>" ImageUrl="~/Images/Edit.gif"
                                                                            CssClass="csslnkButton" ValidationGroup="Edit" runat="server" CausesValidation="False"
                                                                            CommandName="Edit" />
                                                                        &nbsp;
                                                                        <asp:ImageButton ID="IBDeleteTran" ToolTip="<%$Resources:Resource,Delete %>" ImageUrl="~/Images/Delete.gif"
                                                                            runat="server" CssClass="csslnkButton" CausesValidation="False" CommandName="Delete" />
                                                                    </ItemTemplate>
                                                                    <FooterStyle Width="120px" />
                                                                    <HeaderStyle Width="120px" CssClass="cssLabelHeader" />
                                                                    <ItemStyle Width="120px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,BankName %>">
                                                                    <EditItemTemplate>
                                                                        <asp:HiddenField ID="BankDetailID" runat="server" Value='<%# Bind("BankDetailId") %>' />
                                                                        <asp:TextBox ID="txtEditBankName" MaxLength="100" ValidationGroup="Editbank" CssClass="csstxtbox" runat="server" Text='<%# Bind("BankName") %>'></asp:TextBox>
                                                                         <asp:RequiredFieldValidator ID="rfvtxtEditBankName" runat="server" ControlToValidate="txtEditBankName"
                                                                           ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Editbank"></asp:RequiredFieldValidator>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:HiddenField ID="hidBankDetail" runat="server" Value="0" />
                                                                        <asp:TextBox ID="txtNewBankName" MaxLength="100" ValidationGroup="Bank" CssClass="csstxtbox" runat="server"  ></asp:TextBox>
                                                                         <asp:RequiredFieldValidator ID="rfvtxtEditBankName" runat="server" ControlToValidate="txtNewBankName"
                                                                           ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Bank"></asp:RequiredFieldValidator>
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                           <asp:HiddenField ID="ID" runat="server" Value='<%# Bind("BankDetailId") %>' />
                                                                        <asp:Label ID="lblBankName" CssClass="cssLabel" runat="server" Text='<%# Bind("BankName") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                                                                    <ItemStyle Width="200px" />
                                                                    <FooterStyle Width="200px" />
                                                                </asp:TemplateField>
                                                                  <asp:TemplateField HeaderText="<%$ Resources:Resource,BranchName %>">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtEditBranchName" MaxLength="100" ValidationGroup="Editbank" CssClass="csstxtbox" runat="server" Text='<%# Bind("Branch") %>'></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="rftxtEditBranchName" runat="server" ControlToValidate="txtEditBranchName"
                                                                           ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Editbank"></asp:RequiredFieldValidator>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox ID="txtNewBranchName" MaxLength="100" ValidationGroup="Bank" CssClass="csstxtbox" runat="server" ></asp:TextBox>
                                                                         <asp:RequiredFieldValidator ID="rftxtNewBranchName" runat="server" ControlToValidate="txtNewBranchName"
                                                                           ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Bank"></asp:RequiredFieldValidator>
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblBranchName" CssClass="cssLabel" runat="server" Text='<%# Bind("Branch") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                                                                    <ItemStyle Width="200px" />
                                                                    <FooterStyle Width="200px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,State1 %>">
                                                                    <EditItemTemplate>
                                                                        <asp:HiddenField ID="StateId" runat="server" Value='<%# Bind("StateId") %>' />
                                                                          <asp:DropDownList ID="ddlNewState" AutoPostBack="true"  OnSelectedIndexChanged="ddlEditState_SelectedIndexChanged "   ValidationGroup="Bank" CssClass="cssDropDown" Width="85%" runat="server">
                                                                        </asp:DropDownList>   
                                                                        <asp:RequiredFieldValidator ID="rfvddlNewState" runat="server" ControlToValidate="ddlNewState"
                                                                           ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Edit"></asp:RequiredFieldValidator>
                                                                     
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:DropDownList ID="ddlNewState" AutoPostBack="true"  OnSelectedIndexChanged="ddlNewState_SelectedIndexChanged" ValidationGroup="Bank" CssClass="cssDropDown"  runat="server">
                                                                        </asp:DropDownList>   
                                                                       
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                         <asp:Label ID="txtEditState" CssClass="cssLabel" runat="server" Text='<%# Bind("StateName") %>'></asp:Label>  
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="cssLabelHeader" Width="170px" />
                                                                    <ItemStyle Width="170px" />
                                                                    <FooterStyle Width="170px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,District %>"> 
                                                                    <EditItemTemplate>
                                                                       
                                                                    <asp:HiddenField ID="DistrictId" runat="server" Value='<%# Bind("DistrictId") %>' />
                                                                         <asp:DropDownList ID="ddlNewDistrict" CssClass="dropdown"  runat="server"></asp:DropDownList>
                                                                      
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                         <asp:DropDownList ID="ddlNewDistrict" CssClass="dropdown"  runat="server"></asp:DropDownList>
                                                                       
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                         
                                                                      <asp:Label ID="txtEditDistrictName" CssClass="cssLabel" runat="server" Text='<%# Bind("DistrictName") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="cssLabelHeader" Width="170px" />
                                                                    <ItemStyle Width="170px" />
                                                                    <FooterStyle Width="170px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,IFSCCode %>">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtEditIFSCCode" MaxLength="20" ValidationGroup="Editbank" Width="140px" CssClass="csstxtbox" runat="server" Text='<%# Bind("IFSCCode") %>'></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="rftxtEditIFSCCode" runat="server" ControlToValidate="txtEditIFSCCode"
                                                                           ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Editbank"></asp:RequiredFieldValidator>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox ID="txtNewIFSCCode" MaxLength="20" Width="140px" CssClass="csstxtbox" ValidationGroup="Bank"
                                                                            runat="server" ></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="rftxtEditIFSCCode" runat="server" ControlToValidate="txtNewIFSCCode"
                                                                           ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Bank"></asp:RequiredFieldValidator>
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label44" CssClass="cssLabel" runat="server" Text='<%# Bind("IFSCCode") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="cssLabelHeader" Width="170px" />
                                                                    <ItemStyle Width="170px" />
                                                                    <FooterStyle Width="170px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,AccountNumber %>">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtEditAccountNumber" MaxLength="32" ValidationGroup="Editbank" CssClass="csstxtbox" runat="server" Text='<%# Bind("AccountNumber") %>'></asp:TextBox>
                                                                          <asp:RequiredFieldValidator ID="rftxtEditAccountNumber" runat="server" ControlToValidate="txtEditAccountNumber"
                                                                           ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Editbank"></asp:RequiredFieldValidator>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox ID="txtNewAccountNumber" MaxLength="32" CssClass="csstxtbox" ValidationGroup="Bank"
                                                                            runat="server"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="rftxtNewAccountNumber" runat="server" ControlToValidate="txtNewAccountNumber"
                                                                           ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Bank"></asp:RequiredFieldValidator>
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label45" CssClass="cssLabel" runat="server" Text='<%# Bind("AccountNumber") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                                                                    <ItemStyle Width="200px" />
                                                                    <FooterStyle Width="200px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,AccountName %>">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtEditAccountName" CssClass="csstxtbox" ValidationGroup="Editbank" runat="server" Text='<%# Bind("AccountName") %>' MaxLength="100"></asp:TextBox>
                                                                         <asp:RequiredFieldValidator ID="rftxttxtEditAccountNamer" runat="server" ControlToValidate="txtEditAccountName"
                                                                           ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Editbank"></asp:RequiredFieldValidator>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox ID="txtNewAccountName" CssClass="csstxtbox" ValidationGroup="Bank"  runat="server" MaxLength="100"></asp:TextBox>
                                                                         <asp:RequiredFieldValidator ID="rftxtxtNewAccountName" runat="server" ControlToValidate="txtNewAccountName"
                                                                           ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Bank"></asp:RequiredFieldValidator>
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblAccountName" CssClass="cssLabel" runat="server" Text='<%# Bind("AccountName") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                                                                    <ItemStyle Width="200px" />
                                                                    <FooterStyle Width="200px" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>  
                                                <asp:Label ID="lblbankmsg" EnableViewState="False" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                                </asp:Panel>
                                            </ContentTemplate>
                                        </ajaxToolkit:TabPanel>
                                        <ajaxToolkit:TabPanel Style="text-align: left;" ID="EmployeeFamilyDetail" runat="server"
                                            HeaderText="<%$Resources:Resource,EmployeeFamilyDetail %>" TabIndex="8" Height="420px">
                                            <ContentTemplate>
                                                <asp:Panel ID="Panel7" Font-Bold="True" ForeColor="Red" ScrollBars="Auto" GroupingText="<%$ Resources:Resource,EmployeeFamilyDetail %>"
                                                    runat="server">
                                                     <asp:GridView Width="100%"  ID="gvEmployeeFamilyDetail"  CssClass="GridViewStyle" runat="server" ShowFooter="True" AllowPaging="True" PageSize="10" CellPadding="1" GridLines="None"
                                                            AutoGenerateColumns="False" OnRowDataBound="gvEmployeeFamilyDetail_RowDataBound" OnRowCommand="gvEmployeeFamilyDetail_RowCommand"
                                                            OnRowDeleting="gvEmployeeFamilyDetail_RowDeleting" OnRowEditing="gvEmployeeFamilyDetail_OnRowEditing" OnPageIndexChanging="gvEmployeeFamilyDetail_PageIndexChanging"
                                                            OnRowUpdating="gvEmployeeFamilyDetail_RowUpdating" OnRowCancelingEdit="gvEmployeeFamilyDetail_OnRowCancelingEdit">
                                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                                            <RowStyle CssClass="GridViewRowStyle" />
                                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,EditColName %>">
                                                                    <EditItemTemplate>
                                                                        <asp:ImageButton ID="ImgbtnUpdateTran" ToolTip="<%$Resources:Resource,Update %>"
                                                                            ImageUrl="~/Images/save.gif" CssClass="csslnkButton"  runat="server" CommandName="Update"
                                                                            ValidationGroup="Edit" />
                                                                       
                                                                        <asp:ImageButton ID="ImageButton2Tran" ToolTip="<%$Resources:Resource,Cancel %>"
                                                                            ImageUrl="~/Images/Cancel.gif" CssClass="csslnkButton" runat="server" CausesValidation="False"
                                                                            CommandName="Cancel" />
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:ImageButton ID="lbADD" runat="server" ToolTip="<%$Resources:Resource,Save %>"
                                                                            CssClass="cssImgButton"  ValidationGroup="Family" CommandName="AddNew" ImageUrl="../Images/AddNew.gif" />
                                                                        &nbsp;
                                                                        <asp:ImageButton ID="lbReset" ToolTip="<%$Resources:Resource,Reset %>" runat="server"
                                                                            CssClass="cssImgButton" CommandName="Reset" ImageUrl="../Images/Reset.gif" />
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="IBEditTran" ToolTip="<%$Resources:Resource,Edit %>" ImageUrl="~/Images/Edit.gif"
                                                                            CssClass="csslnkButton" ValidationGroup="Family" runat="server" CausesValidation="False"
                                                                            CommandName="Edit" />
                                                                        <asp:ImageButton ID="IBDeleteTran" ToolTip="<%$Resources:Resource,Delete %>" ImageUrl="~/Images/Delete.gif"
                                                                            runat="server" CssClass="csslnkButton" CausesValidation="False" CommandName="Delete" />
                                                                    </ItemTemplate>
                                                                    <FooterStyle Width="100px" />
                                                                    <HeaderStyle Width="100px" CssClass="cssLabelHeader" />
                                                                    <ItemStyle Width="100px" />
                                                                </asp:TemplateField>
                                                                 
                                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,Relation%>">
                                                                    
                                                                    <EditItemTemplate>
                                                                        <asp:HiddenField ID="FamilyDetailID" runat="server" Value='<%# Bind("FamilyID") %>' />
                                                                         <asp:HiddenField ID="hfeditrelation" runat="server" Value='<%# Bind("Relation") %>' />
                                                                        <asp:DropdownList ID="ddlNewRelation" AutoPostBack="true" OnSelectedIndexChanged="ddlEditRelation_SelectedIndexChanged" CssClass="dropdown" runat="server" >
                                                                             <asp:ListItem Text="Mother" Value="Mother" />
                                                                             <asp:ListItem Text="Father" Value="Father" />
                                                                              <asp:ListItem Text="Spouse" Value="Spouse" />
                                                                              <asp:ListItem Text="Children" Value="Children" />
                                                                                 <asp:ListItem Text="Nominee" Value="Nominee" />
                                                                        </asp:DropdownList>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:HiddenField ID="HidFamilyDetailID" runat="server" Value="0" />
                                                                        <asp:DropdownList ID="ddlNewRelation" AutoPostBack="true" OnSelectedIndexChanged="ddlNewRelation_SelectedIndexChanged"  CssClass="dropdown" runat="server"  >
                                                                             <asp:ListItem Text="Mother" Value="Mother" />
                                                                             <asp:ListItem Text="Father" Value="Father" />
                                                                              <asp:ListItem Text="Spouse" Value="Spouse" />
                                                                              <asp:ListItem Text="Children" Value="Children" />
                                                                                <asp:ListItem Text="Nominee" Value="Nominee" />
                                                                        </asp:DropdownList>
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                           <asp:HiddenField ID="ID" runat="server" Value='<%# Bind("FamilyID") %>' />
                                                                        <asp:Label ID="lblRelation" CssClass="cssLabel" runat="server" Text='<%# Bind("Relation") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="cssLabelHeader" Width="150px" />
                                                                    <ItemStyle Width="150px" />
                                                                    <FooterStyle Width="150px" />
                                                                </asp:TemplateField>
                                                                 <asp:TemplateField HeaderText="<%$ Resources:Resource,RelationName %>">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtRelationName" Width="80px" MaxLength="100" CssClass="csstxtbox" runat="server" Text='<%# Bind("RelationName") %>'></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="rftxtEditRelName" runat="server" ControlToValidate="txtRelationName"
                                                                           ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Edit"></asp:RequiredFieldValidator>
                                                                        
                                                              
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox ID="txtRelationName" MaxLength ="100" Width="80px" CssClass="csstxtbox" ValidationGroup="Family" runat="server" ></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="rftxtNewRelNam" runat="server" ControlToValidate="txtRelationName"
                                                                           ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Family"></asp:RequiredFieldValidator>
                                                                        
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblRelName" CssClass="cssLabel" runat="server" Text='<%# Bind("RelationName") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="cssLabelHeader" Width="150px" />
                                                                    <ItemStyle Width="150px" />
                                                                    <FooterStyle Width="150px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,DOB %>">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtEditDOB" Width="90px" CssClass="csstxtbox" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("DOB")) %>'></asp:TextBox>
                                                                        
                                                                        <asp:RequiredFieldValidator ID="rftxtEditDOB" runat="server" ControlToValidate="txtEditDOB"
                                                                           ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Edit"></asp:RequiredFieldValidator>
                                                                         <asp:ImageButton ID="ImageButton2" Style="vertical-align: middle" runat="server" ImageUrl="~/Images/pdate.gif">
                                                                </asp:ImageButton>
                                                                <AjaxToolKit:CalendarExtender ID="CalendarExtender5" Format="dd-MMM-yyyy" runat="server" TargetControlID="txtEditDOB" PopupButtonID="ImageButton2" Enabled="True" PopupPosition="TopRight" >
                                                                </AjaxToolKit:CalendarExtender>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox ID="txtNewDOB" Width="90px" CssClass="csstxtbox" ValidationGroup="Family" runat="server" ></asp:TextBox>
                                                                        
                                                                        <asp:RequiredFieldValidator ID="rftxtNewDOB" runat="server" ControlToValidate="txtNewDOB"
                                                                           ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Family"></asp:RequiredFieldValidator>
                                                                         <asp:ImageButton ID="ImageButton1" Style="vertical-align: middle" runat="server" ImageUrl="~/Images/pdate.gif">
                                                                </asp:ImageButton>
                                                                        <AjaxToolKit:CalendarExtender ID="CalendarExtender5" Format="dd-MMM-yyyy" runat="server"
                                                                    TargetControlID="txtNewDOB" PopupButtonID="ImageButton1" Enabled="True"  >
                                                                </AjaxToolKit:CalendarExtender>
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDOB" CssClass="cssLabel" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("DOB")) %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="cssLabelHeader" Width="150px" />
                                                                    <ItemStyle Width="150px" />
                                                                    <FooterStyle Width="150px" />
                                                                </asp:TemplateField>
                                                                  <asp:TemplateField HeaderText="<%$ Resources:Resource,Gender %>">
                                                                    <EditItemTemplate>
                                                                        <asp:HiddenField ID="hfeditgender" runat="server" Value='<%# Bind("Gender") %>' />
                                                                     <%-- <asp:Label ID="EditGender" CssClass="cssLabel" Visible="false" runat="server" Text='<%# Bind("Gender") %>'></asp:Label>--%>
                                                                    <asp:DropDownList ID="ddlgender" Width="80px" CssClass="csstxtboxRequired" runat="server" >
                                                                    <asp:ListItem Text="Male" Value="Male" ></asp:ListItem>
                                                                    <asp:ListItem Text="Female" Value="Female" ></asp:ListItem>
                                                                </asp:DropDownList>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                      <asp:DropDownList ID="ddlgender" Width="80px" CssClass="csstxtboxRequired" runat="server" Enabled="false">
                                                                   <asp:ListItem Text="Female" Value="Female">  </asp:ListItem>   
                                                                             <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                                                                
                                                                           </asp:DropDownList>

                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                       <%-- <asp:RadioButton ID="rbviMale" GroupName="gender" Visible="false" runat="server" Text="Male"  /><asp:RadioButton ID="rbviFemale" Visible="false" GroupName="gender" runat="server" Text="Female" />--%>
                                                                        <asp:Label ID="lblGender" CssClass="cssLabel" runat="server" Text='<%# Bind("Gender") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="cssLabelHeader" Width="150px" />
                                                                    <ItemStyle Width="150px" />
                                                                    <FooterStyle Width="150px" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView> 
                            </asp:Panel>

                            <asp:Label ID="lblFamily" EnableViewState="False" runat="server" CssClass="csslblErrMsg"></asp:Label>
                            
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>
                                  </ajaxToolkit:TabContainer>
                                     <asp:Button ID="Button1" CssClass="cssButton" runat="server" Text="<%$ Resources:Resource,Back %>"
                                                        OnClick="btnBack_Click" />
                                    <asp:Button ID="ViewReportEmp" CssClass="cssButton" runat="server" Text="<%$ Resources:Resource,ViewReport %>" OnClick="ViewReportEmp_Click" />
                                     <asp:Button ID="btnNext" CssClass="cssButton" runat="server" Text="<%$ Resources:Resource,Next %>"
                                                        OnClick="btnNext_Click" />
                                </div>
                        <Ajax:UpdateProgress ID="UpdateProgress1" runat="server">
                            <ProgressTemplate>
                                <div style="position: absolute; top: 0; left: 0; width: 100%; height: 100%; text-align: center;" class="modalBackground">
                                    <img id="imgspin" runat="server" style="position: absolute; top: 50%; left: 50%" alt="" src="../Images/spinner.gif" />
                                </div>
                            </ProgressTemplate>
                        </Ajax:UpdateProgress>
                    </ContentTemplate>
               </asp:UpdatePanel>
        <asp:Label ID="lblErrorMsg" EnableViewState="False" runat="server" CssClass="csslblErrMsg"></asp:Label>
      <asp:HiddenField ID="IDBankDetail" runat="server" Value="0" />
       <asp:HiddenField ID="IDFamily" runat="server" Value="0" />
    <script language="javascript" type="text/javascript">
        function HideButton() {
            if (document.getElementById('<%=txtFirstName.ClientID %>').value != "" && document.getElementById('<%=txtLastName.ClientID %>').value != "" && document.getElementById('<%=txtDateOfBirth.ClientID %>').value != "" && document.getElementById('<%=txtAddress.ClientID %>').value != "" && document.getElementById('<%=txtDateOfJoining.ClientID %>').value != "" && document.getElementById('<%=txtWageRate.ClientID %>').value != "" && document.getElementById('<%=txtContractedHrs.ClientID %>').value >= 1 && document.getElementById('<%=txtContractedHrs.ClientID %>').value <= 24) {
                document.getElementById('<%=btnSubmit.ClientID %>').style.display = 'none';
            }
        }

        var ZeroNotAllowed = '<%= Resources.Resource.ZeroNotAllowed %>';
        //var valueInvalid = '<%= Resources.Resource.MsgWageRateValue %>';
        function CheckMax(obj) {
            //var num = document.getElementById('<%=txtWageRate.ClientID %>').value;
            var num = parseFloat(document.getElementById('<%=txtWageRate.ClientID %>').value); //read the textbox value
            num = num.toFixed(2);
            if (num <= "0.00") {
                //alert(valueInvalid);
                alert(ZeroNotAllowed);
                document.getElementById('<%=txtWageRate.ClientID %>').value = '';
                document.getElementById('<%=txtWageRate.ClientID %>').focus();
                return false;
            }
            return true;
        }

        function ToggleValidator() {
            var ddlCategory = document.getElementById("<%=ddlCategory.ClientID%>");
            var RFVtxtWageRate = document.getElementById("<%=RFVtxtWageRate.ClientID%>");
            var RequiredFieldValidator11 = document.getElementById("<%=RequiredFieldValidator11.ClientID%>");
            if (ddlCategory.SelectedValue == "IND") {
                ValidatorEnable(RFVtxtWageRate, false);
                ValidatorEnable(RequiredFieldValidator11, false);
            } else {
                ValidatorEnable(RFVtxtWageRate, true);
                ValidatorEnable(RequiredFieldValidator11, true);
            }
        }

</script>
  
</asp:Content>
