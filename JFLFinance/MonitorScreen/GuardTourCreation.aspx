<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GuardTourCreation.aspx.cs"
    Inherits="MonitorScreen_GuardTourCreation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script language="javascript" src="../javaScript/validation.js" type="text/javascript"></script>
    <link rel="Stylesheet" type="text/css" href="../css/StyleSheet.css" />
    <link rel="stylesheet" type="text/css" href="../css/WRStyleSheet.css" />
    <link rel="stylesheet" type="text/css" href="../css/WRGridView.css" />
</head>
<body>
    <form id="form1" runat="server">
    <Ajax:ScriptManager ID="script" runat="server">
    </Ajax:ScriptManager>
    <Ajax:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td align="left">
                        <table border="0" width="100%" cellpadding="0" cellspacing="0">
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label7" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource,ClientCode %>"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlClientCode" AutoPostBack="true" OnSelectedIndexChanged="ddlClientCode_SelectedIndexChanged"
                                        Width="250px" CssClass="cssDropDown" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td align="right" style="width: 80px">
                                    &nbsp;
                                </td>
                                <td align="left" style="width: 20px">
                                    &nbsp;
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblGuardTourID" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource,GuardTourID %>"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlGuardTourID" AutoPostBack="true" OnSelectedIndexChanged="ddlGuardTourID_SelectedIndexChanged"
                                        Width="150px" CssClass="cssDropDown" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td align="right" style="width: 160px">
                                    <asp:Label ID="Label1" CssClass="cssLabel" Width="160px" runat="server" Text="<%$ Resources:Resource,GuardTourDescription %>"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtGuardTourDesc" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label8" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource,Asmt %>"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlAsmtCode" Width="250px" AutoPostBack="true" OnSelectedIndexChanged="ddlAsmtCode_SelectedIndexChanged"
                                        CssClass="cssDropDown" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td align="right" style="width: 80px">
                                </td>
                                <td align="left" style="width: 20px">
                                </td>
                                <td align="right" style="width: 80px">
                                    <asp:Label ID="lblStartTime" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource,StartTime %>"></asp:Label>
                                </td>
                                <td>
                                    <asp:HiddenField ID="HFStartTime" runat="server" />
                                    <asp:TextBox ID="txtStartTime" CssClass="csstxtbox" Width="40px" runat="server" ValidationGroup="Save" />
                                    <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txtStartTime"
                                        Mask="99:99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Time" AcceptAMPM="false" UserTimeFormat="None" ErrorTooltipEnabled="True" />
                                    <AjaxToolKit:MaskedEditValidator ID="MaskedEditValidator3" runat="server" ControlExtender="MaskedEditExtender3"
                                        ControlToValidate="txtStartTime" IsValidEmpty="False" Display="Dynamic" EmptyValueBlurredText="*"
                                        InvalidValueBlurredMessage="*" ValidationGroup="Save" />
                                </td>
                                <td align="right" style="width: 160px">
                                    <asp:Label ID="lblEndTime" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource,EndTime %>"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:HiddenField ID="HFEndTime" runat="server" />
                                    <asp:TextBox ID="txtEndTime" CssClass="csstxtbox" Width="40px" runat="server" ValidationGroup="Save" />
                                    <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtEndTime"
                                        Mask="99:99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Time" AcceptAMPM="false" UserTimeFormat="None" ErrorTooltipEnabled="True" />
                                    <AjaxToolKit:MaskedEditValidator ID="MaskedEditValidator1" runat="server" ControlExtender="MaskedEditExtender1"
                                        ControlToValidate="txtEndTime" IsValidEmpty="False" Display="Dynamic" EmptyValueBlurredText="*"
                                        InvalidValueBlurredMessage="*" ValidationGroup="Save" />
                                </td>
                            </tr>
                            <tr style="height:20px">
                                <td align="right">
                                    <asp:Label ID="Label9" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource,Post %>"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlPostCode" Width="250px" CssClass="cssDropDown" AutoPostBack="true"
                                        runat="server" OnSelectedIndexChanged="ddlPostCode_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td align="right" style="width: 80px">
                                    <asp:Label ID="lblSupervision" runat="server" CssClass="cssLabel" Text="<%$ Resources:Resource,Supervision %>"></asp:Label>
                                </td>
                                <td align="left" style="width: 20px" valign="top">
                                    <asp:CheckBox ID="chkSuperv1" runat="server" ToolTip="" EnableViewState="true" CssClass="cssCheckBox"
                                        Checked="false" Width="20px" />
                                </td>
                                <td align="right" style="width: 80px">
                                    <asp:Label ID="lblFromDay" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource,FromDay %>"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlFromDay" Width="120px" AutoPostBack="true" OnSelectedIndexChanged="ddlFromDay_SelectedIndexChanged"
                                        CssClass="cssDropDown" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td align="right" style="width: 160px">
                                    <asp:Label ID="lblToDay" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource,ToDay %>"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlToDay" Width="120px" CssClass="cssDropDown" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            </br>
                            <tr>
                                <td colspan="8" align="center">
                                    <table border="0">
                                        <tr>
                                            <td align="center">
                                                <asp:Button ID="btnSave" runat="server" CssClass="cssButton" Text="<%$Resources:Resource,Save %>"
                                                    OnClick="btnSave_Click" />
                                            </td>
                                            <td>
                                                <asp:Button ID="btnNewGuardTour" runat="server" CssClass="cssButton" Text="New Guard Tour"
                                                    OnClick="btnNewGuardTour_Click" />
                                            </td>
                                            <td>
                                                <asp:Button ID="btnDelete" runat="server" CssClass="cssButton" Text="<%$Resources:Resource,Delete %>"
                                                    OnClick="btnDelete_Click" />
                                            </td>
                                            <td>
                                                <asp:Button ID="btnUpdate" runat="server" CssClass="cssButton" Text="<%$Resources:Resource,Update %>"
                                                    OnClick="btnUpdate_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                <tr>
                    <td>
                        <asp:Label ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg" EnableViewState="false"></asp:Label>
                    </td>
                </tr>
                <tr align="center">
                    <td align="center">
                        <asp:GridView ID="gvGuardTour" Width="900px" CssClass="GridViewStyle" runat="server"
                            ShowFooter="true" ShowHeader="true" Visible="true" AllowPaging="true" CellPadding="3"
                            GridLines="None" AutoGenerateColumns="False" OnRowCommand="gvGuardTour_RowCommand"
                            OnRowEditing="gvGuardTour_RowEditing" OnDataBound="gvGuardTour_DataBound" OnRowUpdating="gvGuardTour_RowUpdating"
                            OnSelectedIndexChanged="gvGuardTour_SelectedIndexChanged" OnPageIndexChanging="gvGuardTour_PageIndexChanging"
                            OnRowDataBound="gvGuardTour_RowDataBound" OnRowCancelingEdit="gvGuardTour_RowCancelingEdit"
                            OnRowDeleting="gvGuardTour_RowDeleting">
                            <FooterStyle CssClass="GridViewFooterStyle" />
                            <RowStyle CssClass="GridViewRowStyle" />
                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                            <PagerStyle CssClass="GridViewPagerStyle" />
                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                            <Columns>
                                <asp:TemplateField ItemStyle-Width="10px" HeaderStyle-Width="10px" FooterStyle-Width="10px">
                                    <HeaderTemplate>
                                        <asp:Label Width="10px" ID="lblgvHdrEventSno" CssClass="cssLabelHeader" runat="server"
                                            Text="<%$ Resources:Resource,SerialNumber %>"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label Width="10px" ID="lblgvEventSno" CssClass="cssLable" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="150px" HeaderStyle-Width="150px" FooterStyle-Width="150px">
                                    <HeaderTemplate>
                                        <asp:Label ID="lblgvHdrGTourID" CssClass="cssLabelHeader" runat="server" Text="Guard TourID"> </asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblgvGTourID" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "GTourID").ToString()%>'> </asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblgvGTourID" CssClass="cssLable" runat="server"> </asp:Label>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-Width="100px" FooterStyle-Width="50px">
                                    <HeaderTemplate>
                                        <asp:Label ID="lblgvHdrTagID" CssClass="cssLabelHeader" runat="server" Text="TagID"> </asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblgvTagID" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PostTagID").ToString()%>'> </asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:Label ID="lblgvTagID" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PostTagID").ToString()%>'> </asp:Label>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtTagID" Width="100px" Enabled="false" ReadOnly="true" CssClass="csstxtboxReadonly"
                                            runat="server"></asp:TextBox>
                                        <%--Text='<%# DataBinder.Eval(Container.DataItem, "EventCode").ToString()%>'--%>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <%--//Updated By  --%>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="lblgvHdrTagDesc" CssClass="cssLabelHeader" runat="server" Text="Tag Description"> </asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblgvTagDesc" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TagDesc").ToString()%>'> </asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <%--<asp:TextBox ID="txtTagDesc" CssClass="csstxtbox" runat="server" Width="300px"
                                            Text='<%# DataBinder.Eval(Container.DataItem, "TagDesc").ToString()%>'></asp:TextBox>--%>
                                        <asp:DropDownList ID="ddlgvTagID" runat="server" Width="100px" CssClass="cssDropDown">
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <%--<asp:TextBox ID="txtNewTagDesc" Width="300px" CssClass="csstxtbox" runat="server" MaxLength="255"></asp:TextBox>--%>
                                        <asp:DropDownList ID="ddlTagID" runat="server" Width="300px" CssClass="cssDropDown">
                                        </asp:DropDownList>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="lblgvHdrScheduledTime" CssClass="cssLabelHeader" runat="server" Text="Scheduled Time"> </asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblgvScheduledTime" CssClass="cssLable" runat="server" Text='<%# String.Format("{0:HH:mm}", Eval("ScheduledTime"))%>'> </asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtScheduledTime" ValidationGroup="vg_Edit" CssClass="csstxtbox"
                                            runat="server" Width="50px" Text='<%# String.Format("{0:HH:mm}", Eval("ScheduledTime"))%>'></asp:TextBox>
                                        <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txtScheduledTime"
                                            Mask="99:99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                            MaskType="Time" AcceptAMPM="false" UserTimeFormat="TwentyFourHour" ErrorTooltipEnabled="True" />
                                        <AjaxToolKit:MaskedEditValidator ID="MaskedEditValidator3" runat="server" ControlExtender="MaskedEditExtender3"
                                            ControlToValidate="txtScheduledTime" SetFocusOnError="true" IsValidEmpty="False"
                                            Display="Dynamic" EmptyValueBlurredText="*" ValidationGroup="vg_Edit" InvalidValueBlurredMessage="*" />
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtNewScheduledTime" ValidationGroup="vg_Add" Width="50px" CssClass="csstxtbox"
                                            runat="server"></asp:TextBox>
                                        <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txtNewScheduledTime"
                                            Mask="99:99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                            MaskType="Time" AcceptAMPM="false" UserTimeFormat="TwentyFourHour" ErrorTooltipEnabled="True" />
                                        <AjaxToolKit:MaskedEditValidator ID="MaskedEditValidator3" runat="server" ControlExtender="MaskedEditExtender3"
                                            ControlToValidate="txtNewScheduledTime" SetFocusOnError="true" IsValidEmpty="False"
                                            Display="Dynamic" EmptyValueBlurredText="*" ValidationGroup="vg_Add" InvalidValueBlurredMessage="*" />
                                        <%--Text='<%# DataBinder.Eval(Container.DataItem, "EventDescription").ToString()%>'--%>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="lblgvHdrInterval" CssClass="cssLabelHeader" runat="server" Text="Interval"> </asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblgvInterval" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Interval").ToString()%>'> </asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtInterval" CssClass="csstxtbox" runat="server" Width="40px" Text='<%# DataBinder.Eval(Container.DataItem, "Interval").ToString()%>'></asp:TextBox>
                                        <%--Code Added By  --%>
                                        <AjaxToolKit:MaskedEditExtender ID="mskInt" runat="server" TargetControlID="txtInterval"
                                            MessageValidatorTip="true" OnFocusCssClass="MaskedEd   itFocus" OnInvalidCssClass="MaskedEditError"
                                            MaskType="Number" Mask="999" AcceptAMPM="false" ErrorTooltipEnabled="True" />
                                        <AjaxToolKit:MaskedEditValidator ID="mskEdVal" runat="server" ControlExtender="mskInt"
                                            ControlToValidate="txtInterval" SetFocusOnError="true" IsValidEmpty="False" MaximumValue="999"
                                            MinimumValue="1" Display="Dynamic" EmptyValueBlurredText="*" ValidationGroup="vg_Add"
                                            InvalidValueBlurredMessage="*" />
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtNewInterval" Width="40px" CssClass="csstxtbox" runat="server"
                                            MaxLength="2"></asp:TextBox>
                                        <%--Code Added By  --%>
                                        <AjaxToolKit:MaskedEditExtender ID="mskNewInterval" runat="server" TargetControlID="txtNewInterval"
                                            MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                            Mask="999" MaskType="Number" AcceptAMPM="false" ErrorTooltipEnabled="True" />
                                        <AjaxToolKit:MaskedEditValidator ID="mskValNewInterval" runat="server" ControlExtender="mskNewInterval"
                                            ControlToValidate="txtNewInterval" SetFocusOnError="true" IsValidEmpty="False"
                                            MaximumValue="999" MinimumValue="1" Display="Dynamic" EmptyValueBlurredText="*"
                                            ValidationGroup="vg_Add" InvalidValueBlurredMessage="*" />
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <%-- <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="lblgvHdrGraceTime" CssClass="cssLabelHeader" runat="server" Text="Grace Time"> </asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblgvGraceTime" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "GraceTime").ToString()%>'> </asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtGraceTime" CssClass="csstxtbox" runat="server"  Width="70px" Text='<%# DataBinder.Eval(Container.DataItem, "GraceTime").ToString()%>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtNewGraceTime" Width="70px" CssClass="csstxtbox" runat="server" MaxLength="5"></asp:TextBox>
                                    </FooterTemplate>
                                </asp:TemplateField>--%>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="lblgvHdrIntervalFeq" CssClass="cssLabelHeader" runat="server" Text="Frequency"> </asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblgvIntervalFeq" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Duration").ToString()%>'> </asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:HiddenField ID="HFDuration" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "IntervalFreq").ToString()%>' />
                                        <asp:DropDownList ID="ddlDuration" CssClass="cssDropDown" runat="server" Width="75px">
                                            <asp:ListItem Text="Hour" Value="Hrs"></asp:ListItem>
                                            <asp:ListItem Text="Minutes" Value="Min"></asp:ListItem>
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:DropDownList ID="ddlNewDuration" CssClass="cssDropDown" runat="server" Width="75px">
                                            <asp:ListItem Text="Hour" Value="Hrs"></asp:ListItem>
                                            <asp:ListItem Text="Minutes" Value="Min"></asp:ListItem>
                                        </asp:DropDownList>
                                        <%--Text='<%# DataBinder.Eval(Container.DataItem, "EventDescription").ToString()%>'--%>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="lblgvEdit" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, EditColName %>"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImgbtnDelete" runat="server" CssClass="cssImgButton" CommandName="Delete"
                                            ToolTip="<%$ Resources:Resource, Delete %>" ImageUrl="../Images/Delete.gif" />
                                        <asp:ImageButton ID="ImgbtnEdit" runat="server" CssClass="cssImgButton" CommandName="Edit"
                                            ToolTip="<%$ Resources:Resource, Edit %>" ImageUrl="../Images/Edit.gif" />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:ImageButton ID="ImgbtnUpdate" runat="server" CssClass="cssImgButton" CommandName="Update"
                                            ValidationGroup="vg_Edit" ToolTip="<%$ Resources:Resource, Update %>" ImageUrl="../Images/Save.gif" />
                                        <asp:ImageButton ID="ImgbtnCancel" runat="server" CssClass="cssImgButton" CommandName="Cancel"
                                            ToolTip="<%$ Resources:Resource, Cancel %>" ImageUrl="../Images/Cancel.gif" />
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:ImageButton ID="ImgbtnAdd" runat="server" CssClass="cssImgButton" CommandName="Add New"
                                            ToolTip="<%$Resources:Resource,Save %>" ValidationGroup="vg_Add" ImageUrl="../Images/AddNew.gif" />
                                        <asp:ImageButton ID="ImgbtnReset" runat="server" CssClass="cssImgButton" CommandName="Reset"
                                            ToolTip="<%$ Resources:Resource, Reset %>" ImageUrl="../Images/Reset.gif" />
                                    </FooterTemplate>
                                    <FooterStyle Width="60px" />
                                    <HeaderStyle Width="60px" />
                                    <ItemStyle Width="60px" />
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
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </Ajax:UpdatePanel>
    </form>
</body>
</html>
