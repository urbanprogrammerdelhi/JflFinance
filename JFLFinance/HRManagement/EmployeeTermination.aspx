<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="EmployeeTermination.aspx.cs" Inherits="HRManagement_EmployeeTermination"
    Title="<%$ Resources:Resource, AppTitle %>" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td colspan="4" align="center">
                
                
                <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table border="0" width="100%" cellpadding="1" cellspacing="0">
                            <tr>
                                <td align="right">
                                    <asp:ImageButton ID="imgBack" runat="server" ImageUrl="../Images/go_Back.gif" ToolTip="<%$ Resources:Resource, back %>"
                                        OnClick="imgBack_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div style="width: 950px;">
                                        <div class="squarebox">
                                            <div class="squareboxgradientcaption" style="height: 15px; cursor: pointer;" ">
                                                <div style="float: left; width:930;">
                                                    <tt style="text-align: center;">
                                                        <asp:Label ID="Label13" CssClass="squareboxgradientcaption" runat="server" Text="<%$Resources:Resource,EmployeeDetail %>"></asp:Label></tt></div>
                                            </div>
                                            <div class="squareboxcontent">
                                                <table>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="Label1" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,EmployeeNumber %>"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblEmployeeNumber" runat="server" Font-Bold="True"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="Label2" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,FirstName %>"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblFirstName" CssClass="cssLabel" Font-Bold="true" runat="server"
                                                                Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="Label4" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,LastName %>"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblLastName" CssClass="cssLabel" Font-Bold="true" runat="server" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="Label3" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,DateOfBirth %>"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblDateOfBirth" CssClass="cssLabel" Font-Bold="true" runat="server"
                                                                Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="Label6" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,DesignationDescription %>"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblDesignationDescription" CssClass="cssLabel" Font-Bold="true" runat="server"
                                                                Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="Label8" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,CategoryDescription %>"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblCategoryDescription" CssClass="cssLabel" Font-Bold="true" runat="server"
                                                                Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="Label10" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,JoiningDate %>"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblJoiningDate" CssClass="cssLabel" Font-Bold="true" runat="server"
                                                                Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>
                                        
                                    </div>
                                </td>
                            </tr>
                        </table>
                        <table border="0" width="100%" cellpadding="1" cellspacing="0">
                            <tr>
                                <td>
                                    <div style="width: 950px;">
                                        <div class="squarebox">
                                            <div class="squareboxgradientcaption" style="height: 15px; cursor: pointer;" ">
                                                <div style="float: left; width:930;">
                                                    <tt style="text-align: center;">
                                                        <asp:Label ID="Label14" CssClass="squareboxgradientcaption" runat="server" Text="<%$Resources:Resource,terminationdetail %>"></asp:Label></tt></div>
                                            </div>
                                            <div class="squareboxcontent">
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
                                                            <asp:Label ID="Label9" runat="server" Text="<%$Resources:Resource, Date%>"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtResignationDate" CssClass="csstxtbox" runat="server" Width="180px"
                                                                ValidationGroup="TerminateEmployee" Style="width: 80px;" AutoPostBack="true"
                                                                Text=""></asp:TextBox>
                                                            <asp:HyperLink ID="imgResignationDate" Style="vertical-align: middle;" runat="server"
                                                                ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                                                            <asp:RequiredFieldValidator ID="RFVResignationDate"  ValidationGroup="TerminateEmployee"
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
                                                <asp:Label ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg" EnableViewState="False"></asp:Label>
                                                <asp:HiddenField ID="hfTotalExpTillDate" runat="server" />
                                            </div>
                                        </div>
                                        
                                    </div>
                                    <asp:Button ID="btnTerminateEmployee" CssClass="cssButton" runat="server" Text="<%$Resources:Resource,Apply %>"
                                        OnClick="btnTerminateEmployee_Click" ValidationGroup="TerminateEmployee" />
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </Ajax:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
