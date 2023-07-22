<%--<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="true" CodeFile="DefineWeekOff_AnEmp.aspx.cs"
    Inherits="Transactions_DefineWeekOff_AnEmp" Title="<%$ Resources:Resource, AppTitle %>" %>--%>

<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterSearch.master" AutoEventWireup="true"
    CodeFile="SchEmpWiseDefineWeekOff_AnEmp.aspx.cs" Inherits="Transactions_SchEmpWiseDefineWeekOff_AnEmp"
    Title="<%$ Resources:Resource, AppTitle %>" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td align="center">
                <div style="width: 960px;">
                    <div class="squarebox">
                        <div class="squareboxgradientcaption" style="height: 15px; cursor: pointer;" ">
                            <div style="float: left; width: 940px;">
                                <tt style="text-align: center;">
                                    <asp:Label ID="Label2" CssClass="squareboxgradientcaption" runat="server" Text="<%$ Resources:Resource, WeekOff %>"></asp:Label></tt></div>
                        </div>
                        <div class="squareboxcontent">
                            <Ajax:UpdatePanel runat="server" ID="upgvWeekOff" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:HiddenField ID="HFRotaAuthStatus" runat="server" />
                                    <%--Code Added By Manish  Ticket No: 150565 ModifiedDate: 01-Apr-2010--%>
                                    <table border="0" width="100%" style="text-align: left;">
                                        <tr>
                                            <td>
                                                <%--ENd Of Code Added By Manish  Ticket No: 150565 ModifiedDate: 01-Apr-2010--%>
                                                <asp:GridView ID="gvWeekOff" Width="880px" CssClass="GridViewStyle" runat="server"
                                                    AllowPaging="true" PageSize="15" CellPadding="0" CellSpacing="0" GridLines="None"
                                                    AutoGenerateColumns="false" ShowFooter="false" OnRowCommand="gvWeekOff_RowCommand"
                                                    OnRowDataBound="gvWeekOff_RowDataBound" OnPageIndexChanging="gvWeekOff_PageIndexChanging"
                                                    OnDataBound="gvWeekOff_DataBound">
                                                    <FooterStyle CssClass="GridViewFooterStyle" />
                                                    <RowStyle CssClass="GridViewRowStyle" />
                                                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                    <PagerStyle CssClass="GridViewPagerStyle" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                    <Columns>
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
                                                                    <%--<asp:Label ID="lblWarning" CssClass="cssLabel" BorderColor="DarkRed" runat="server" Text="Save your Changes Before Moving to next page"></asp:Label>--%>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </PagerTemplate>
                                                </asp:GridView>
                                                <%--Code Added By Manish  Ticket No: 150565 ModifiedDate: 01-Apr-2010--%>
                                            </td>
                                        </tr>
                                    </table>
                                    <%--End OF Code Added By Manish  Ticket No: 150565 ModifiedDate: 01-Apr-2010--%>
                                    <asp:Button ID="btnAdd" CssClass="cssSaveButton" runat="server" ToolTip="<%$ Resources:Resource, Save %>"
                                        Text="<%$ Resources:Resource, Save %>" OnClick="btnAdd_Click" />
                                    <asp:Label EnableViewState="false" ID="lblErrorMsg" Text="" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                </ContentTemplate>
                            </Ajax:UpdatePanel>
                        </div>
                    </div>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <%-- Added By Manish  Ticket No :146829 Modified Date : 03 mar 2010--%>
                <asp:Panel ID="Panel6" BackColor="white" ScrollBars="none" CssClass="ScrollBar" runat="server"
                    Height="400" Width="600" Style="display: none;">
                    <asp:Button ID="Button3" runat="server" Style="display: none" />
                    <AjaxToolKit:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="Button3"
                        PopupControlID="Panel6" X="50" Y="50" BackgroundCssClass="modalBackground" />
                    <Ajax:UpdatePanel runat="server" ID="UpdatePanel2" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:GridView ID="gvLeaveDetails" AutoGenerateColumns="false" runat="server">
                                <FooterStyle CssClass="GridViewFooterStyle" />
                                <RowStyle CssClass="GridViewRowStyle" />
                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                <PagerStyle CssClass="GridViewPagerStyle" HorizontalAlign="Left" VerticalAlign="Middle" />
                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                <HeaderStyle CssClass="GridViewHeaderStyle" />
                                <Columns>
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
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="Label1" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, EmployeeNumber %>"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblEmployeeNumber" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EmployeeNumber").ToString()%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="200px" />
                                        <HeaderStyle Width="200px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="Label2" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, DutyDate %>"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblDutyDate" CssClass="cssLable" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("DutyDate"))%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="300px" />
                                        <HeaderStyle Width="300px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="Label34" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, Reason %>"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblMessage" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Message").ToString()%>'></asp:Label>
                                            <%--<asp:HiddenField ID="HFMessageID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "MessageId").ToString()%>' />--%>
                                        </ItemTemplate>
                                        <ItemStyle Width="350px" />
                                        <HeaderStyle Width="350px" />
                                    </asp:TemplateField>
                                    <%-- <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="Label34" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, Leave_Code %>"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblMessage" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "LeaveCode").ToString()%>'></asp:Label>
                                           <asp:HiddenField ID="HFMessageID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "MessageId").ToString()%>' />
                                        </ItemTemplate>
                                        <ItemStyle Width="350px" />
                                        <HeaderStyle Width="350px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="Label34" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, Leave_Desc %>"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblMessage" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "LeaveDesc").ToString()%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="350px" />
                                        <HeaderStyle Width="350px" />
                                    </asp:TemplateField>--%>
                                </Columns>
                            </asp:GridView>
                        </ContentTemplate>
                    </Ajax:UpdatePanel>
                    <asp:Label EnableViewState="false" ID="lblErroMsg1" Text="" runat="server" CssClass="csslblErrMsg"></asp:Label>
                    <asp:Button ID="btnOk" OnClientClick="CallParentWindowFunction()" runat="server"
                        CssClass="cssButton" Text="<%$Resources:Resource,Ok %>" OnClick="btnOk_Click" />
                </asp:Panel>
                <%--END OF Added By Manish  Ticket No :146829 Modified Date : 03 mar 2010--%>
            </td>
        </tr>
    </table>

    <script language="javascript" type="text/javascript">
        window.onunload = CallParentWindowFunction;
        //Added By Manish  Ticket No :146829 Modified Date : 03 mar 2010
        function CallParentWindowFunction() {
            window.opener.ParentWindowFunction1();
            return false;
        }
        //END OF Added By Manish  Ticket No :146829 Modified Date : 03 mar 2010


    </script>
    <script language="javascript" src="../javaScript/validation.js" type="text/javascript"></script>
</asp:Content>
