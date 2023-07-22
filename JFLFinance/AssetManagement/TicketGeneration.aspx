<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="TicketGeneration.aspx.cs" Inherits="AssetManagement_TicketGeneration" %>

<asp:Content ID="content1" ContentPlaceHolderID="contentplaceholder1" runat="server">
    <asp:Panel ID="UpdatePanel1" runat="server">
        <style type="text/css">
            .Labels {
                color: black;
                font-size: small;
            }
        </style>
        <table align="center" width="70%" frame="border" cellspacing="20px" cellpadding="20px">
            <tr style="height: 40px; text-decoration: solid">
                <td>
                    <p style="background-color: #2E6293; height: 30px; color: white; font-size:large">Generate Ticket</p>
                </td>
                <td colspan="2">
                    <p style="background-color: #2E6293; height: 30px;"></p>
                </td>
            </tr>
            <tr style="height: 40px; text-decoration: solid">
                <td style="text-align: right;" class="auto-style1">
                    <asp:Label ID="Label7" CssClass="Labels" runat="server" Text="Company"></asp:Label>
                </td>
                <td style="text-align: left;" class="auto-style1" colspan="2">
                    <asp:DropDownList ID="ddlCompany" runat="server" CssClass="cssDropDown" AutoPostBack="true" Width="250px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr style="height: 40px; text-decoration: solid">
                <td style="text-align: right;" class="auto-style1">
                    <asp:Label ID="Label1" CssClass="Labels" runat="server" Text="Restaurant Code"></asp:Label>
                </td>
                <td style="text-align: left;" class="auto-style1" colspan="2">
                    <asp:DropDownList ID="ddlClientCode" runat="server" CssClass="cssDropDown" AutoPostBack="true" Width="250px"
                        OnSelectedIndexChanged="ddlClientCode_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr style="height: 40px; text-decoration: solid">
                <td style="text-align: right;">
                    <asp:Label ID="Label16" CssClass="Labels" runat="server" Text="Restaurant Address"></asp:Label>
                </td>
                <td style="text-align: left;" colspan="2">
                    <asp:DropDownList ID="ddlRestAddress" runat="server" CssClass="cssDropDown" AutoPostBack="true" Width="250px" Visible="false">
                    </asp:DropDownList>
                    <asp:Label ID="txtRestAddress" runat="server" CssClass="csstxtbox" Width="250px"></asp:Label>
                </td>
            </tr>
            <tr style="height: 40px; text-decoration: solid">
                <td style="text-align: right;" class="auto-style1">
                    <asp:Label ID="Label5" CssClass="Labels" runat="server" Text="Asset Category"></asp:Label>
                </td>
                <td style="text-align: left;" class="auto-style1" colspan="2">
                    <asp:DropDownList ID="ddlAssetCategory" runat="server" CssClass="cssDropDown" AutoPostBack="true" Width="250px"
                        OnSelectedIndexChanged="ddlAssetCategory_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr style="height: 40px; text-decoration: solid">
                <td style="text-align: right;" class="auto-style1">
                    <asp:Label ID="Label6" CssClass="Labels" runat="server" Text="Asset Sub-Category"></asp:Label>
                </td>
                <td style="text-align: left;" class="auto-style1" colspan="2">
                    <asp:DropDownList ID="ddlAssetSubCategory" runat="server" CssClass="cssDropDown" AutoPostBack="true" Width="250px"
                        OnSelectedIndexChanged="ddlAssetSubCategory_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr style="height: 40px; text-decoration: solid">
                <td style="text-align: right;" class="auto-style1">
                    <asp:Label ID="Label8" CssClass="Labels" runat="server" Text="Asset Name"></asp:Label>
                </td>
                <td style="text-align: left;" class="auto-style1" colspan="2">
                    <asp:DropDownList ID="ddlAssetName" runat="server" CssClass="cssDropDown" AutoPostBack="true" Width="250px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr style="height: 40px; text-decoration: solid">
                <td style="text-align: right;">
                    <asp:Label ID="Label17" runat="server" CssClass="Labels" Text="Summary of Issues"></asp:Label>
                </td>
                <td style="text-align: left;" colspan="2">
                    <asp:TextBox ID="txtSummary" runat="server" CssClass="csstxtbox" MaxLength="150" Width="250px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvtxtSummary" runat="server" ControlToValidate="txtSummary" Display="Dynamic" Font-Bold="true" ForeColor="Red" Text="*" ValidationGroup="New"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr style="height: 40px; text-decoration: solid">
                <td style="text-align: right;">
                    <asp:Label ID="Label2" runat="server" CssClass="Labels" Text="Description"></asp:Label>
                </td>
                <td style="text-align: left;" colspan="2">
                    <asp:TextBox TextMode="MultiLine" ID="txtDescription" runat="server" CssClass="csstxtbox" MaxLength="200" Width="450px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDescription" Display="Dynamic" Font-Bold="true" ForeColor="Red" Text="*" ValidationGroup="New"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr style="height: 40px; text-decoration: solid">
                <td style="text-align: right;">
                    <asp:Label ID="Label3" runat="server" CssClass="Labels" Text="Commercial Value"></asp:Label>
                </td>
                <td style="text-align: left;" colspan="2">
                    <asp:TextBox ID="txtValue" runat="server" CssClass="csstxtbox" MaxLength="15" Width="250px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtValue" Display="Dynamic" Font-Bold="true" ForeColor="Red" Text="*" ValidationGroup="New"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr style="height: 40px; text-decoration: solid">
                <td style="text-align: right;">
                    <asp:Label ID="Label4" runat="server" CssClass="Labels" Text="Severity"></asp:Label>
                </td>
                <td style="text-align: center;" colspan="2">
                    <asp:RadioButtonList ID="ddlSeverity" runat="server" RepeatDirection="Horizontal" Width="250px">
                        <asp:ListItem Selected="True" Value="High" Text="High"></asp:ListItem>
                        <asp:ListItem Text="Medium" Value="Medium"></asp:ListItem>
                        <asp:ListItem Text="Low" Value="Low"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr style="height: 40px; text-decoration: solid">
                <td style="text-align: right;" class="auto-style1">
                    <asp:Label ID="Label9" runat="server" CssClass="Labels">Attachment&nbsp;</asp:Label>
                </td>
                <td style="text-align: right;" class="auto-style1" colspan="2">
                    <br />
                    <asp:FileUpload ID="imgFile" runat="server" accept=".png,.jpg,.jpeg,.gif" />
                    <asp:RegularExpressionValidator ID="RegExValFileUploadFileType" runat="server"
                        ControlToValidate="imgFile"
                        ErrorMessage="Only .jpg,.png,.jpeg,.gif Files are allowed" Font-Bold="True"
                        Font-Size="Small" ForeColor="Red"
                        ValidationExpression="(.*?)\.(jpg|jpeg|png|gif|JPG|JPEG|PNG|GIF)$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr style="height: 40px; text-decoration: solid">
                <td style="text-align: center;">&nbsp;</td>
                <td style="text-align: left;" colspan="2">
                    <asp:Button ID="btnGenerateTicket" runat="server" CssClass="cssButton" OnClick="btnGenerateTicket_Click" Text="Generate Ticket" ValidationGroup="New" />
                     <asp:Button ID="btnViewAll" runat="server" CssClass="cssButton" OnClick="btnViewAll_Click" Text="View All Ticket"  />
                     <asp:Button ID="btnSchedule" runat="server" CssClass="cssButton" OnClick="btnSchedule_Click" Text="Schedule Ticket"  />
                </td>
            </tr>
        </table>
        <%--<div style="margin-left: 400px; margin-top: 30px;">               
            </div>--%>
        <asp:Label ID="lblMsg" runat="server" Style="color: red; font-size: larger;" Font-Bold="true"></asp:Label>
    </asp:Panel>
</asp:Content>




