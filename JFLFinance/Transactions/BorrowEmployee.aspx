<%@ Page Title="<%$ Resources:Resource, AppTitle %>" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master"
    AutoEventWireup="true" CodeFile="BorrowEmployee.aspx.cs" Inherits="Transactions_BorrowEmployee" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="950px" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td align="center">
                <div style="width: 950px;">
                    <div class="squarebox">
                        <div class="squareboxgradientcaption" style="height: 15px; cursor: pointer;" ">
                            <div style="float: left; width: 930px;">
                                <table border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="height: 12px; width: 33%">
                                        </td>
                                        <td style="height: 12px; width: 33%" align="center">
                                            <asp:Label ID="Label1" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, RequestForm %>"></asp:Label>
                                        </td>
                                        <td style="width: 33%" align="right">
                                            <Ajax:UpdatePanel runat="server" ID="upRequestStatus" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <asp:Label Width="130px" ID="lblfixStatus" CssClass="cssLabelHeader" runat="server"
                                                        Text="<%$ Resources:Resource, Status %>"></asp:Label>
                                                    <asp:Label Width="130px" Style="font-weight: bold;" ID="txtStatus" CssClass="csstxtboxReadonly"
                                                        runat="server"></asp:Label>
                                                    <asp:HiddenField runat="server" ID="hfStatus" Value="" />
                                                </ContentTemplate>
                                                <Triggers>
                                                    <Ajax:AsyncPostBackTrigger ControlID="btnCreate" EventName="Click" />
                                                    <Ajax:AsyncPostBackTrigger ControlID="btnUpdate" EventName="Click" />
                                                    <Ajax:AsyncPostBackTrigger ControlID="btnDelete" EventName="Click" />
                                                    <Ajax:AsyncPostBackTrigger ControlID="btnSend" EventName="Click" />
                                                    <Ajax:AsyncPostBackTrigger ControlID="txtRequestNo" EventName="TextChanged" />
                                                </Triggers>
                                            </Ajax:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div class="squareboxcontent">
                            <div id="Div2" style="overflow: auto; width: 969px; height: 230px">
                                <Ajax:UpdatePanel runat="server" ID="UpdatePanel2" UpdateMode="Always">
                                    <ContentTemplate>
                                        <asp:Panel ID="Panel1" runat="server" GroupingText="<%$ Resources:Resource, RequestForm %>"
                                            Style="width: 940px">
                                            <table border="0" cellpadding="0" cellspacing="0" style="width: 940px">
                                                <tr>
                                                    <td align="right" style="width: 150px">
                                                        <asp:Label ID="lblRequestNo" Text="<%$Resources:Resource,requestnumber%>" runat="server"
                                                            CssClass="cssLabel" Width="150px"></asp:Label>
                                                    </td>
                                                    <td align="left" style="width: 300px">
                                                        <asp:TextBox ID="txtRequestNo" runat="server" CssClass="csstxtboxReadonly" Enabled="true"
                                                            Width="260px" OnTextChanged="txtRequestNo_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                        <asp:ImageButton ID="ibtnSearch" runat="server" ImageUrl="~/Images/search.png" OnClick="ibtnSearch_Click" />
                                                    </td>
                                                    <td colspan="2">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="width: 150px">
                                                        <asp:Label ID="Label2" runat="server" Text="<%$Resources:Resource,Division%>" CssClass="cssLabel"></asp:Label>
                                                    </td>
                                                    <td align="left" style="width: 300px">
                                                        <asp:Label ID="lblDivision" runat="server" Text="" CssClass="cssLabel"></asp:Label>
                                                    </td>
                                                    <td align="right" style="width: 150px">
                                                        <asp:Label ID="Label3" runat="server" Text="<%$Resources:Resource,Location%>" CssClass="cssLabel"></asp:Label>
                                                    </td>
                                                    <td align="left" style="width: 300px">
                                                        <asp:Label ID="lblLocation" runat="server" Text="" CssClass="cssLabel"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="width: 150px">
                                                        <asp:Label ID="Label6" runat="server" Text="<%$Resources:Resource,Area%>" CssClass="cssLabel"></asp:Label>*
                                                    </td>
                                                    <td align="left" style="width: 300px">
                                                        <telerik:RadComboBox ID="ddlFromArea" runat="server" Width="280px" MaxHeight="350px"
                                                            AutoPostBack="true" Filter="StartsWith" OnSelectedIndexChanged="ddlFromArea_SelectedIndexChanged">
                                                        </telerik:RadComboBox>
                                                    </td>
                                                    <td align="right" style="width: 150px">
                                                        <asp:Label ID="Label8" runat="server" Text="<%$Resources:Resource,Client%>" CssClass="cssLabel"></asp:Label>*
                                                    </td>
                                                    <td align="left" style="width: 300px">
                                                        <telerik:RadComboBox ID="ddlFromClient" runat="server" Width="280px" MaxHeight="350px"
                                                            AutoPostBack="true" Filter="StartsWith" OnSelectedIndexChanged="ddlFromClient_SelectedIndexChanged">
                                                        </telerik:RadComboBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="width: 150px">
                                                        <asp:Label ID="Label7" runat="server" Text="<%$Resources:Resource,Asmt%>" CssClass="cssLabel"></asp:Label>*
                                                    </td>
                                                    <td align="left" style="width: 300px">
                                                        <telerik:RadComboBox ID="ddlFromAsmt" runat="server" Width="280px" MaxHeight="350px"
                                                            AutoPostBack="true" Filter="StartsWith" OnSelectedIndexChanged="ddlFromAsmt_SelectedIndexChanged">
                                                        </telerik:RadComboBox>
                                                    </td>
                                                    <td align="right" style="width: 150px">
                                                        <asp:Label ID="Label9" runat="server" Text="<%$Resources:Resource,Post%>" CssClass="cssLabel"></asp:Label>*
                                                    </td>
                                                    <td align="left" style="width: 300px">
                                                        <telerik:RadComboBox ID="ddlFromPost" runat="server" Width="280px" MaxHeight="350px"
                                                            AutoPostBack="true" Filter="StartsWith" OnSelectedIndexChanged="ddlFromPost_SelectedIndexChanged">
                                                        </telerik:RadComboBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="width: 150px">
                                                        <asp:Label ID="Label12" runat="server" Text="<%$Resources:Resource,SoRank%>" CssClass="cssLabel"></asp:Label>*
                                                    </td>
                                                    <td align="left" style="width: 300px">
                                                        <telerik:RadComboBox ID="ddlFromSoRank" runat="server" Width="280px" MaxHeight="350px"
                                                            Filter="StartsWith">
                                                        </telerik:RadComboBox>
                                                    </td>
                                                    <td colspan="2">
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <asp:Panel ID="Panel2" runat="server" GroupingText="<%$ Resources:Resource, RequestTo %>"
                                            Style="width: 940px">
                                            <table border="0" cellpadding="0" cellspacing="0" style="width: 940px">
                                                <tr>
                                                    <td align="right" style="width: 150px">
                                                        <asp:Label ID="Label4" runat="server" Text="<%$Resources:Resource,Division%>" CssClass="cssLabel"></asp:Label>*
                                                    </td>
                                                    <td align="left" style="width: 300px">
                                                        <telerik:RadComboBox ID="ddlToDivision" runat="server" Width="280px" MaxHeight="350px"
                                                            AutoPostBack="true" Filter="StartsWith" OnSelectedIndexChanged="ddlToDivision_SelectedIndexChanged">
                                                        </telerik:RadComboBox>
                                                    </td>
                                                    <td align="right" style="width: 150px">
                                                        <asp:Label ID="Label5" runat="server" Text="<%$Resources:Resource,Location%>" CssClass="cssLabel"></asp:Label>*
                                                    </td>
                                                    <td align="left" style="width: 300px">
                                                        <telerik:RadComboBox ID="ddlToLocation" runat="server" Width="280px" MaxHeight="350px"
                                                            AutoPostBack="true" Filter="StartsWith" OnSelectedIndexChanged="ddlToLocation_SelectedIndexChanged">
                                                        </telerik:RadComboBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="width: 150px">
                                                        <asp:Label ID="Label10" runat="server" Text="<%$Resources:Resource,Area%>" CssClass="cssLabel"></asp:Label>*
                                                    </td>
                                                    <td align="left" style="width: 300px">
                                                        <telerik:RadComboBox ID="ddlToArea" runat="server" Width="280px" MaxHeight="350px"
                                                            Filter="StartsWith">
                                                        </telerik:RadComboBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <table border="0" cellpadding="0" cellspacing="0" style="width: 940px">
                                            <tr>
                                                <td align="right" colspan="4">
                                                    <asp:Button ID="btnCreate" runat="server" CssClass="cssButton" Style="margin-right: 10px;"
                                                        Text="<%$Resources:Resource,Create%>" OnClick="btnCreate_Click" />
                                                    <asp:Button ID="btnUpdate" runat="server" CssClass="cssButton" Style="margin-right: 10px;"
                                                        Text="<%$Resources:Resource,Update%>" OnClick="btnUpdate_Click" Visible="false" />
                                                    <asp:Button ID="btnDelete" runat="server" CssClass="cssButton" Style="margin-right: 10px;"
                                                        Text="<%$Resources:Resource,Delete%>" OnClick="btnDelete_Click" />
                                                    <asp:Button ID="btnSend" runat="server" CssClass="cssButton" Style="margin-right: 10px;"
                                                        Text="<%$Resources:Resource,SendRequest %>" OnClick="btnSend_Click" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="4">
                                                    <asp:Label runat="server" ID="lblError" CssClass="csslblErrMsg"></asp:Label>
                                                    <asp:HiddenField ID="hfAllowBorrowEmployee" runat="server" />
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </Ajax:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <br />
            </td>
        </tr>
        <tr>
            <td align="center">
                <div style="width: 950px;">
                    <div class="squarebox">
                        <div class="squareboxgradientcaption" style="height: 15px; cursor: pointer;" ">
                            <div style="float: left; width: 930px;">
                                <table border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="height: 12px; width: 33%">
                                        </td>
                                        <td style="height: 12px; width: 33%" align="center">
                                            <asp:Label ID="Label11" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, Details %>"></asp:Label>
                                        </td>
                                        <td style="width: 33%" align="right">
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div class="squareboxcontent">
                            <div id="Div1" style="overflow: auto; width: 969px; height: 230px">
                                <Ajax:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Always">
                                    <ContentTemplate>
                                        <table border="0" cellpadding="0" cellspacing="0" style="width: 940px">
                                            <tr>
                                                <td align="left">
                                                    <asp:Panel ID="PnlRequest" BorderWidth="0px" runat="server" Width="940px" ScrollBars="Auto">
                                                        <asp:GridView runat="server" ID="gvRequest" Width="900px" CssClass="GridViewStyle"
                                                            ShowFooter="true" ShowHeader="true" AllowPaging="true" CellPadding="0" GridLines="None"
                                                            AutoGenerateColumns="False" PageIndex="0" PageSize="10" OnRowDataBound="gvRequest_RowDataBound"
                                                            OnRowCommand="gvRequest_RowCommand" OnRowEditing="gvRequest_RowEditing" OnRowCancelingEdit="gvRequest_RowCancelingEdit"
                                                            OnRowUpdating="gvRequest_RowUpdating" OnRowDeleting="gvRequest_RowDeleting" OnPageIndexChanging="gvRequest_PageIndexChanging">
                                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                                            <RowStyle CssClass="GridViewRowStyle" />
                                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                            <Columns>
                                                                <asp:TemplateField ItemStyle-Width="10px" HeaderStyle-Width="10px" FooterStyle-Width="10px">
                                                                    <HeaderTemplate>
                                                                        <asp:Label Width="10px" ID="lblgvHdrSoNo" CssClass="cssLabelHeader" runat="server"
                                                                            Text="<%$ Resources:Resource,SerialNumber %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label Width="10px" ID="lblgvSNo" CssClass="cssLable" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-Width="100px" FooterStyle-Width="100px">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="gvHdrlblNoOfPerson" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,NoPost %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblNoOfPerson" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "NoOfPerson").ToString()%>'> </asp:Label>
                                                                        <asp:HiddenField ID="hfRequestLineNo" EnableViewState="false" runat="server" Value='<%#Eval("RequestLineNo")%>' />
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtNoOfPerson" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "NoOfPerson").ToString()%>'></asp:TextBox>
                                                                        <asp:HiddenField ID="hfRequestLineNo" EnableViewState="false" runat="server" Value='<%#Eval("RequestLineNo")%>' />
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox ID="txtNoOfPerson" CssClass="csstxtbox" runat="server" MaxLength="3"
                                                                            Width="50px"></asp:TextBox>
                                                                        <asp:RangeValidator Width="30px" ID="RVNoOfPerson" CssClass="csslblErrMsg" runat="server"
                                                                            SetFocusOnError="true" Type="Integer" ErrorMessage="Number" MaximumValue="999"
                                                                            MinimumValue="0" ControlToValidate="txtNoOfPerson"></asp:RangeValidator>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-Width="150px" HeaderStyle-Width="150px" FooterStyle-Width="150px">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="gvHdrlblFromDate" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,FromDate %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblFromDate" CssClass="cssLable" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("FromDate")) %>'> </asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Width="80px" ID="txtFromDate" CssClass="csstxtbox" runat="server" ValidationGroup="VGEdit"
                                                                            AutoPostBack="true" Text='<%#String.Format("{0:dd-MMM-yyyy}",Eval("FromDate")) %>'
                                                                            OnTextChanged="txtFromDate_TextChanged"></asp:TextBox>
                                                                        <asp:Image ID="imgFromDate" runat="server" Style="vertical-align: middle;" ImageUrl="~/Images/pdate.gif" />
                                                                        <AjaxToolKit:CalendarExtender Format="dd-MMM-yyyy" ID="CalExtEFromDate" runat="server"
                                                                            TargetControlID="txtFromDate" PopupButtonID="imgFromDate" />
                                                                        <asp:RequiredFieldValidator ID="RfvFromDate" runat="server" ControlToValidate="txtFromDate"
                                                                            ErrorMessage="*" ValidationGroup="VGEdit" ForeColor="Red" SetFocusOnError="true" />
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox ID="txtFromDate" ValidationGroup="VGAdd" Width="80px" runat="server"
                                                                            CssClass="csstxtbox" OnTextChanged="txtFromDate_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                                        <asp:Image ID="imgFromDate" runat="server" Style="vertical-align: middle;" ImageUrl="~/Images/pdate.gif" />
                                                                        <AjaxToolKit:CalendarExtender Format="dd-MMM-yyyy" ID="CalExtFromDate" runat="server"
                                                                            TargetControlID="txtFromDate" PopupButtonID="imgFromDate" />
                                                                        <asp:RequiredFieldValidator ID="RfvFromDate" runat="server" ControlToValidate="txtFromDate"
                                                                            ErrorMessage="*" ValidationGroup="VGAdd" ForeColor="Red" SetFocusOnError="true" />
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-Width="150px" HeaderStyle-Width="150px" FooterStyle-Width="150px">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="gvHdrlblToDate" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,ToDate %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblToDate" CssClass="cssLable" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("ToDate")) %>'> </asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Width="80px" ID="txtToDate" CssClass="csstxtbox" runat="server" ValidationGroup="VGEdit"
                                                                            AutoPostBack="true" Text='<%#String.Format("{0:dd-MMM-yyyy}",Eval("ToDate")) %>'
                                                                            OnTextChanged="txtToDate_TextChanged"></asp:TextBox>
                                                                        <asp:Image ID="imgToDate" runat="server" Style="vertical-align: middle;" ImageUrl="~/Images/pdate.gif" />
                                                                        <AjaxToolKit:CalendarExtender Format="dd-MMM-yyyy" ID="CalExtEToDate" runat="server"
                                                                            TargetControlID="txtToDate" PopupButtonID="imgToDate" />
                                                                        <asp:RequiredFieldValidator ID="RfvToDate" runat="server" ControlToValidate="txtToDate"
                                                                            ErrorMessage="*" ValidationGroup="VGEdit" ForeColor="Red" SetFocusOnError="true" />
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox ID="txtToDate" ValidationGroup="VGAdd" Width="80px" runat="server" CssClass="csstxtbox"
                                                                            OnTextChanged="txtToDate_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                                        <asp:Image ID="imgToDate" runat="server" Style="vertical-align: middle;" ImageUrl="~/Images/pdate.gif" />
                                                                        <AjaxToolKit:CalendarExtender Format="dd-MMM-yyyy" ID="CalExtToDate" runat="server"
                                                                            TargetControlID="txtToDate" PopupButtonID="imgToDate" />
                                                                        <asp:RequiredFieldValidator ID="RfvToDate" runat="server" ControlToValidate="txtToDate"
                                                                            ErrorMessage="*" ValidationGroup="VGAdd" ForeColor="Red" SetFocusOnError="true" />
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-Width="100px" FooterStyle-Width="100px">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="gvHdrlblFromTime" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,FromTime %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblFromTime" CssClass="cssLable" runat="server" Text='<%# String.Format("{0:HH:mm}",Eval("FromTime"))%>'> </asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtFromTime" CssClass="csstxtbox" runat="server" MaxLength="5" Width="50px"
                                                                            Text='<%# String.Format("{0:HH:mm}",Eval("FromTime"))%>' ValidationGroup="VGEdit"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RfvFromTime" runat="server" ControlToValidate="txtFromTime"
                                                                            ErrorMessage="*" ForeColor="Red" SetFocusOnError="true" ValidationGroup="VGEdit" />
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox ID="txtFromTime" Width="50px" runat="server" CssClass="csstxtbox" MaxLength="5"
                                                                            Text="00:00" ValidationGroup="VGAdd" />
                                                                        <asp:RequiredFieldValidator ID="RfvFromTime" runat="server" ControlToValidate="txtFromTime"
                                                                            ErrorMessage="*" ForeColor="Red" SetFocusOnError="true" ValidationGroup="VGAdd" />
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-Width="100px" FooterStyle-Width="100px">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="gvHdrlblToTime" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,ToTime %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblToTime" CssClass="cssLable" runat="server" Text='<%# String.Format("{0:HH:mm}",Eval("ToTime"))%>'> </asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtToTime" CssClass="csstxtbox" runat="server" MaxLength="5" Width="50px"
                                                                            Text='<%# String.Format("{0:HH:mm}",Eval("ToTime"))%>' ValidationGroup="VGEdit"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RfvToTime" runat="server" ControlToValidate="txtToTime"
                                                                            ErrorMessage="*" ForeColor="Red" SetFocusOnError="true" ValidationGroup="VGEdit" />
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox ID="txtToTime" Width="50px" runat="server" CssClass="csstxtbox" MaxLength="5"
                                                                            Text="00:00" ValidationGroup="VGAdd" />
                                                                        <asp:RequiredFieldValidator ID="RfvToTime" runat="server" ControlToValidate="txtToTime"
                                                                            ErrorMessage="*" ForeColor="Red" SetFocusOnError="true" ValidationGroup="VGAdd" />
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-Width="150px" HeaderStyle-Width="150px" FooterStyle-Width="150px">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="gvHdrlblDesignation" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,Designation %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDesignationDesc" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DesignationDesc").ToString()%>'> </asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:HiddenField runat="server" ID="hfDesignationCode" Value='<%# DataBinder.Eval(Container.DataItem, "DesignationCode").ToString()%>' />
                                                                        <telerik:RadComboBox ID="ddlDesignation" runat="server" Width="140px" MaxHeight="350px"
                                                                            Filter="StartsWith">
                                                                        </telerik:RadComboBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <telerik:RadComboBox ID="ddlDesignation" runat="server" Width="140px" MaxHeight="350px"
                                                                            Filter="StartsWith">
                                                                        </telerik:RadComboBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="gvlblEdit" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, EditColName %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="ImgbtnDelete" runat="server" CssClass="cssImgButton" CommandName="Delete"
                                                                            ToolTip="<%$ Resources:Resource, Delete %>" ImageUrl="../Images/Delete.gif" />
                                                                        <asp:ImageButton ID="ImgbtnEdit" runat="server" CssClass="cssImgButton" CommandName="Edit"
                                                                            ToolTip="<%$ Resources:Resource, Edit %>" ImageUrl="../Images/Edit.gif" />
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:ImageButton ID="ImgbtnUpdate" runat="server" CssClass="cssImgButton" CommandName="Update"
                                                                            ValidationGroup="VGEdit" ToolTip="<%$ Resources:Resource, Update %>" ImageUrl="../Images/Save.gif" />
                                                                        <asp:ImageButton ID="ImgbtnCancel" runat="server" CssClass="cssImgButton" CommandName="Cancel"
                                                                            ToolTip="<%$ Resources:Resource, Cancel %>" ImageUrl="../Images/Cancel.gif" />
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:ImageButton ID="ImgbtnAdd" runat="server" CssClass="cssImgButton" CommandName="Add"
                                                                            ToolTip="<%$Resources:Resource,Save %>" ValidationGroup="VGAdd" ImageUrl="../Images/AddNew.gif" />
                                                                        <asp:ImageButton ID="ImgbtnReset" runat="server" CssClass="cssImgButton" CommandName="Reset"
                                                                            ToolTip="<%$ Resources:Resource, Reset %>" ImageUrl="../Images/Reset.gif" />
                                                                    </FooterTemplate>
                                                                    <FooterStyle Width="60px" />
                                                                    <HeaderStyle Width="60px" />
                                                                    <ItemStyle Width="60px" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    </br>
                                                    <asp:Panel ID="PnlEmployeeAssign" runat="server" BorderWidth="0px" Width="940px"
                                                        ScrollBars="Auto">
                                                        <asp:GridView runat="server" ID="gvEmpAssign" Width="900px" CssClass="GridViewStyle"
                                                            ShowFooter="true" ShowHeader="true" Visible="false" CellPadding="3" AllowPaging="true"
                                                            PageSize="10" PageIndex="0" GridLines="None" AutoGenerateColumns="False" OnPageIndexChanging="gvEmpAssign_OnPageIndexChanging">
                                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                                            <RowStyle CssClass="GridViewRowStyle" />
                                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                            <Columns>
                                                                <asp:TemplateField ItemStyle-Width="10px" HeaderStyle-Width="10px">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="gvHdrlblSoNo" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,SerialNumber %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="gvlblSno" CssClass="cssLable" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="gvHdrlblRequestLineNo" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,RequestLineNo %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="gvlblRequestLineNo" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RequestLineNo").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="gvHdrlblRequestSubLineNo" CssClass="cssLabelHeader" runat="server"
                                                                            Text="<%$ Resources:Resource,RequestSubLineNo%>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="gvlblRequestSubLineNo" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RequestSubLineNo").ToString()%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="gvHdrlblEmployeeNumber" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,EmployeeNumber %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="gvlblEmployeeNumber" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EmployeeNumber").ToString()%>'> </asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="gvHdrlblDutyDate" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,DutyDate %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="gvlblDutyDate" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DutyDate")%>'> </asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="gvHdrlblFromTime" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,FromTime %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="gvlblFromTime" CssClass="cssLable" runat="server" Text='<%# String.Format("{0:HH:mm}",Eval("FromTime"))%>'> </asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="gvHdrlblToTime" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,ToTime %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="gvlblToTime" CssClass="cssLable" runat="server" Text='<%# String.Format("{0:HH:mm}",Eval("ToTime"))%>'> </asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-Width="100px" FooterStyle-Width="100px">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="gvHdrlblDesignationDesc" CssClass="cssLabelHeader" runat="server"
                                                                            Text="<%$ Resources:Resource,Designation %>"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="gvlblDesignationDesc" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DesignationDesc").ToString()%>'> </asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </Ajax:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
