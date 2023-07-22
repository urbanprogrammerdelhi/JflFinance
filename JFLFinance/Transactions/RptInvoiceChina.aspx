<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="RptInvoiceChina.aspx.cs" Inherits="Transactions_RptInvoiceChina" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<%@ Register Src="../MS_Control/MultipleSelection.ascx" TagName="MultipleSelection"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table id="Table1" width="100%" border="0" cellpadding="3" cellspacing="0" runat="server">
        <tr>
            <td align="left">
                <div id="Div1" runat="server" style="width: 100%;">
                    <div class="squarebox">
                        <div class="squareboxgradientcaption" style="height: 15px; cursor: pointer;" ">
                            <div style="float: left; width: 100%;">
                                <tt style="text-align: center;">
                                    <asp:Label ID="Label5" CssClass="squareboxgradientcaption" runat="server" Text="<%$Resources:Resource,Invoice %>"></asp:Label></tt>
                            </div>
                        </div>
                        <div id="Div2" class="squareboxcontent" style="text-align: left; width: 100%" runat="server">
                            <table id="Table2" border="0" cellpadding="1" cellspacing="0" style="width: 100%"
                                runat="server">
                                <tr>
                                    <td align="right" style="width: 80px">
                                        <asp:Label ID="Label4" runat="server" Text="<%$Resources:Resource,FromDate %>" CssClass="cssLable"></asp:Label>
                                    </td>
                                    <td style="width: 10px">&nbsp;
                                    </td>
                                    <td align="left">
                                        <asp:TextBox CssClass="csstxtboxSmall" Text="" ID="txtFromDate" runat="server" AutoPostBack="false"></asp:TextBox>
                                        <asp:HyperLink ID="ImgFromDate" Style="vertical-align: middle;" runat="server" ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                                        <AjaxToolKit:CalendarExtender ID="CalendarExtender2" Format="dd-MMM-yyyy" runat="server"
                                            TargetControlID="txtFromDate" PopupButtonID="ImgFromDate">
                                        </AjaxToolKit:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 80px">
                                        <asp:Label ID="Label1" runat="server" Text="<%$Resources:Resource,ToDate %>" CssClass="cssLable"></asp:Label>
                                    </td>
                                    <td style="width: 10px">&nbsp;
                                    </td>
                                    <td align="left">
                                        <asp:TextBox CssClass="csstxtboxSmall" Text="" ID="txtToDate" runat="server" AutoPostBack="false"></asp:TextBox>
                                        <asp:HyperLink ID="ImgToDate" Style="vertical-align: middle;" runat="server" ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                                        <AjaxToolKit:CalendarExtender ID="CalendarExtender3" Format="dd-MMM-yyyy" runat="server"
                                            TargetControlID="txtToDate" PopupButtonID="ImgToDate">
                                        </AjaxToolKit:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 80px">
                                        <asp:Label ID="Label3" runat="server" Text="<%$Resources:Resource,ClientName %>"
                                            CssClass="cssLable"></asp:Label>
                                    </td>
                                    <td style="width: 10px">&nbsp;
                                    </td>
                                    <td align="left">
                                        <%--<asp:DropDownList CssClass="cssDropDown" ID="ddlClient" Width="500" OnSelectedIndexChanged="ddlClient_SelectedIndexChanged"
                                            runat="server" AutoPostBack="true">
                                        </asp:DropDownList>--%>
                                        <telerik:RadComboBox ID="ddlClient" runat="server" Width="500px" MaxHeight="350px"
                                            CheckedItemsTexts="DisplayAllInInput" CheckBoxes="true"
                                            EmptyMessage="Please Select" AllowCustomText="true" EnableCheckAllItemsCheckBox="true"
                                            OnSelectedIndexChanged="ddlClient_SelectedIndexChanged" AutoPostBack="true">
                                        </telerik:RadComboBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 80px">
                                        <asp:Label ID="Label2" runat="server" Text="<%$Resources:Resource,SoNo %>" CssClass="cssLable"></asp:Label>
                                    </td>
                                    <td style="width: 10px">&nbsp;
                                    </td>
                                    <%-- <td align="left">
                                        <uc1:MultipleSelection ID="msddlSo" Width="500" runat="server" />
                                    </td>--%>
                                    <td align="left">
                                        <%-- <asp:DropDownList CssClass="cssDropDown" ID="msddlSo" Width="500" 
                                            runat="server" AutoPostBack="true">
                                        </asp:DropDownList>--%>
                                        <telerik:RadComboBox ID="msddlSo" runat="server" Width="500px" MaxHeight="350px"
                                            CheckedItemsTexts="DisplayAllInInput" CheckBoxes="true"
                                            EmptyMessage="Please Select" AllowCustomText="true" EnableCheckAllItemsCheckBox="true"
                                            AutoPostBack="true">
                                        </telerik:RadComboBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 80px">
                                        <asp:Label ID="Label6" runat="server" Text="<%$Resources:Resource,Company%>" CssClass="cssLable"></asp:Label>
                                    </td>
                                    <td style="width: 10px">&nbsp;
                                    </td>
                                    <td align="left">
                                        <asp:TextBox CssClass="normtext" ID="txtCompanyName" Text=""
                                            Width="300" runat="server" AutoPostBack="false" Visible="false"></asp:TextBox>
                                        <%--<telerik:RadComboBox ID="ddlsubcompany" runat="server" Width="500px" MaxHeight="350px"
                                            CheckedItemsTexts="DisplayAllInInput" CheckBoxes="false"
                                            EmptyMessage="Please Select" AllowCustomText="true" EnableCheckAllItemsCheckBox="true"
                                            OnSelectedIndexChanged="ddlsubcompany_SelectedIndexChanged" AutoPostBack="true">
                                        </telerik:RadComboBox>--%>
                                        <telerik:RadComboBox ID="ddlsubcompany" runat="server" Width="500px" MaxHeight="350px"
                                            CheckedItemsTexts="DisplayAllInInput" CheckBoxes="false"  ChangeTextOnKeyBoardNavigation="false"
                                            EmptyMessage="Please Select" AllowCustomText="false" EnableCheckAllItemsCheckBox="true"
                                            OnSelectedIndexChanged="ddlsubcompany_SelectedIndexChanged" AutoPostBack="true">
                                        </telerik:RadComboBox>



                                       <%-- <asp:TextBox CssClass="normtext" ID="txtCompanyName" Text="<% $Resources:Resource,CompanyNameValue %>"
                                            Width="500" runat="server" AutoPostBack="false"></asp:TextBox>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 80px">
                                        <asp:Label ID="Label7" runat="server" Text="<%$Resources:Resource,BankName%>" CssClass="cssLable"></asp:Label>
                                    </td>
                                    <td style="width: 10px">&nbsp;
                                    </td>
                                    <td align="left">
                                        <%--<telerik:RadComboBox ID="ddlbankname" runat="server" Width="500px" MaxHeight="350px"
                                            CheckedItemsTexts="DisplayAllInInput" CheckBoxes="false"
                                            EmptyMessage="Please Select" AllowCustomText="true" EnableCheckAllItemsCheckBox="true"
                                            OnSelectedIndexChanged="ddlbankname_SelectedIndexChanged" AutoPostBack="true">
                                        </telerik:RadComboBox>--%>
                                        <telerik:RadComboBox ID="ddlbankname" runat="server" Width="500px" MaxHeight="350px"
                                            CheckedItemsTexts="DisplayAllInInput" CheckBoxes="false"
                                            EmptyMessage="Please Select" AllowCustomText="false" EnableCheckAllItemsCheckBox="true"
                                            OnSelectedIndexChanged="ddlbankname_SelectedIndexChanged" AutoPostBack="true">
                                        </telerik:RadComboBox>

                                        <asp:TextBox CssClass="normtext" ID="txtBankName" Text=""
                                            Width="300" runat="server" AutoPostBack="false" Visible="false"></asp:TextBox>

                                        <%--<asp:TextBox CssClass="normtext" ID="txtBankName" Text="<% $Resources:Resource,BankAccountNameValue %>"
                                            Width="500" runat="server" AutoPostBack="false"></asp:TextBox>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 80px">
                                        <asp:Label ID="Label8" runat="server" Text="<%$Resources:Resource,BankAccountNumber%>"
                                            CssClass="cssLable"></asp:Label>
                                    </td>
                                    <td style="width: 10px">&nbsp;
                                    </td>
                                    <td align="left">
                                        <%--<asp:TextBox CssClass="normtext" ID="txtBankAccountNumber" Text="000000501510030487"
                                            Width="500" runat="server" AutoPostBack="false"></asp:TextBox>--%>
                                        <asp:TextBox CssClass="normtext" ID="txtBankAccountNumber" Width="500" runat="server"
                                            AutoPostBack="false"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 80px">
                                        <asp:Label ID="Label9" runat="server" Text="<%$Resources:Resource,Remarks%>" CssClass="cssLable"></asp:Label>
                                    </td>
                                    <td style="width: 10px">&nbsp;
                                    </td>
                                    <td align="left">
                                        <asp:TextBox CssClass="normtext" ID="txtRemarks" Text="" Width="500" runat="server"
                                            AutoPostBack="false"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <asp:Label ID="lblErrorMsg" EnableViewState="false" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right"></td>
                                    <td style="width: 10px">&nbsp;
                                    </td>
                                    <td align="left">
                                        <asp:Button ID="btnProceed" runat="server" Text="<%$Resources:Resource,Proceed %>"
                                            CssClass="cssButton" OnClick="btnProceed_Click" />
                                        <asp:Button ID="btnExport" runat="server" Visible="false" Text="Export" CssClass="cssButton" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
