<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="CreateShiftPatternSeq.aspx.cs" Inherits="Transactions_CreateShiftPatternSeq"
    Title="Shift Pattern Seq" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <Ajax:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional">
        <ContentTemplate>
            <div>
                    <div class="squareboxgradientcaption" style="height: 20px;">
                                <asp:Label ID="Label6" runat="server" Text="Create Shift Pattern"></asp:Label>
                    </div>
                    <div>
                                    <asp:Panel ID="PnlAsmtPost" Visible="true" Width="100%" runat="server" ScrollBars="Vertical"
                                        Height="150px" GroupingText="<%$Resources:Resource,AsssignmentSitePostDetails %>">
                                        <asp:GridView ID="gvSitepost" runat="server" Width="100%" AllowPaging="false" AutoGenerateColumns="False"
                                            CellPadding="1" CssClass="GridViewStyle" GridLines="None" PageSize="6" ShowFooter="true"
                                            ShowHeader="true" Visible="true">
                                            <RowStyle CssClass="GridViewRowStyle" />
                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                                            <Columns>
                                                <asp:TemplateField FooterStyle-Width="50" HeaderStyle-Width="50" ItemStyle-Width="50">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblSlno" runat="server" CssClass="cssLableRequired" Text="<%$ Resources:Resource,SerialNumber %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSlno" runat="server" CssClass="cssLable" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="50px">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblSitepost" runat="server" CssClass="cssLableRequired" Text="<%$ Resources:Resource,SitePost%>"
                                                            Width="90px"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSitepost" runat="server" CssClass="cssLabel" Text='<%# Eval("sitepost")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="50px">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblPdlineNo" runat="server" CssClass="cssLableRequired" Text="<%$ Resources:Resource,SoLineNo%>"
                                                            Width="90px"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPdlineNo" runat="server" CssClass="cssLabel" Text='<%# Eval("SoLineNo")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="50px">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblShift" runat="server" CssClass="cssLableRequired" Text="<%$ Resources:Resource,Shift%>"
                                                            Width="60px"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkShift" runat="server" CommandName="shiftclick" Text='<%# Eval("Shift")%>'></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="50px">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblWefStartDate" runat="server" CssClass="cssLableRequired" Text="<%$ Resources:Resource,TimeFrom%>"
                                                            Width="90px"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblWefStartDate" runat="server" CssClass="cssLabel" Text='<%# String.Format("{0:HH:mm}",Eval("EffectiveFrom")) %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="50px">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblWefEndDate" runat="server" CssClass="cssLableRequired" Text="<%$ Resources:Resource,TimeTo%>"
                                                            Width="90px"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblWefEndDate" runat="server" CssClass="cssLabel" Text='<%# String.Format("{0:HH:mm}",Eval("EffectiveTo")) %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </asp:Panel>
                        <asp:Label ID="lblErrorMsg" EnableViewState="false" Text="" runat="server" CssClass="csslblErrMsg"></asp:Label>
                        <asp:HiddenField ID="HFSearchPatternCode" runat="server" />
                                    <asp:Panel ID="PanelAsmtShiftPattern" Visible="true " Height="190px" Width="100%"
                                        ScrollBars="Vertical" runat="server" GroupingText="<%$Resources:Resource,AssignmentShiftPattern %>">
                                        <asp:GridView ID="gvAsmtSftPattern" runat="server" Width="100%" AllowPaging="true"
                                            AutoGenerateColumns="False" CellPadding="1" CssClass="GridViewStyle" GridLines="None"
                                            OnRowDeleting="gvAsmtSftPattern_RowDeleting" PageSize="4" RowStyle-VerticalAlign="Bottom"
                                            ShowFooter="true" ShowHeader="true" Visible="true" OnRowCancelingEdit="gvAsmtSftPattern_RowCancelingEdit"
                                            OnRowUpdating="gvAsmtSftPattern_RowUpdating" OnRowCommand="gvAsmtSftPattern_RowCommand"
                                            OnRowDataBound="gvAsmtSftPattern_RowDataBound" OnRowEditing="gvAsmtSftPattern_RowEditing"
                                            OnPageIndexChanging="gvAsmtSftPattern_PageIndex" EmptyDataText="No " >
                                            <RowStyle CssClass="GridViewRowStyle" />
                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                            <Columns>
                                                <asp:TemplateField ItemStyle-Width="50" HeaderStyle-Width="50" FooterStyle-Width="50">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblSlno" CssClass="cssLableRequired" runat="server" Text="<%$ Resources:Resource,SerialNumber %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSlno" CssClass="cssLable" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterStyle Width="50px" />
                                                    <HeaderStyle Width="50px" />
                                                    <ItemStyle Width="50px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="50px">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblShiftPatternCode" Width="150px" CssClass="cssLableRequired" runat="server"
                                                            Text="PatternCode"></asp:Label>
                                                        <asp:TextBox ID="txtSearchShiftPatternCode" runat="server" CssClass="csstxtboxSearch"
                                                            AutoPostBack="true" OnTextChanged="txtSearchShiftPatternCode_TextChanged"></asp:TextBox>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lnkShiftPattern" runat="server" Text='<%# Eval("ShiftPatternID")%>'></asp:Label>
                                                        <asp:Label ID="lblShiftPatternCode" Width="150px" viCssClass="cssLabel" Visible="false"
                                                            runat="server" Text='<%# Eval("ShiftPatternCode")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lnkShiftPattern" runat="server" Text='<%# Eval("ShiftPatternID")%>'></asp:Label>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtShiftPatternID" runat="server" Width="100px" MaxLength="16" CssClass="csstxtbox"></asp:TextBox>
                                                    </FooterTemplate>
                                                    <HeaderStyle Width="50px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="180px">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblShiftPattern" Width="180px" CssClass="cssLableRequired" runat="server"
                                                            Text="<%$ Resources:Resource,ShiftPattern%>"></asp:Label>
                                                        <asp:CheckBox ID="chkShowAllPatterns" runat="server" CssClass="cssCheckBox" AutoPostBack="true"
                                                            Text="Show All" OnCheckedChanged="chkShowAllPatterns_CheckedChanged" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblShiftPattern" Width="300px" CssClass="cssLabel" runat="server"
                                                            Text='<%# Eval("ShiftPattern")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtShiftPattern" runat="server" Width="300px" CssClass="csstxtbox"
                                                            Text='<%# Eval("ShiftPattern")%>' AutoPostBack="True" OnTextChanged="txtShiftPattern_TextChanged"></asp:TextBox>
                                                        <asp:TextBox ID="txtShiftPatternCode" runat="server" Visible="false" CssClass="csstxtbox"></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtShiftPattern" runat="server" Width="100px" CssClass="csstxtbox"
                                                            OnTextChanged="txtShiftPatternNew_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                        <asp:TextBox ID="txtShiftPatternCode" runat="server" Width="200px" CssClass="csstxtbox"></asp:TextBox>
                                                    </FooterTemplate>
                                                    <HeaderStyle Width="180px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="60px">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblHdrAction" CssClass="cssLableRequired" runat="server" Text="<%$ Resources:Resource,Action%>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <EditItemTemplate>
                                                        <asp:ImageButton ID="ImgbtnUpdate" ToolTip="<%$Resources:Resource,Update %>" ImageUrl="~/Images/save.gif"
                                                            CssClass="csslnkButton" runat="server" CommandName="Update" ValidationGroup="Edit" />
                                                        &nbsp;
                                                        <asp:ImageButton ID="IMGCancel" ToolTip="<%$Resources:Resource,Cancel %>" ImageUrl="~/Images/Cancel.gif"
                                                            CssClass="csslnkButton" runat="server" CausesValidation="False" CommandName="Cancel" />
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="IBEditTran" ToolTip="<%$Resources:Resource,Edit %>" ImageUrl="~/Images/Edit.gif"
                                                            CssClass="csslnkButton" ValidationGroup="Edit" runat="server" CausesValidation="False"
                                                            CommandName="Edit" />
                                                        <asp:ImageButton ID="ImgbtnDelete" runat="server" CssClass="cssImgButton" CommandName="Delete"
                                                            ToolTip="Delete" ImageUrl="../Images/Delete.gif" />
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:ImageButton ID="ImgbtnAdd" runat="server" CssClass="cssImgButton" CommandName="Add"
                                                            ToolTip="<%$ Resources:Resource, Save %>" ValidationGroup="vgCFooter" Height="16px"
                                                            Width="16px" ImageUrl="../Images/AddNew.gif" />
                                                        <asp:ImageButton ID="ImgbtnReset" runat="server" CssClass="cssImgButton" CommandName="Reset"
                                                            ToolTip="<%$ Resources:Resource, Reset %>" Height="15px" Width="15px" ImageUrl="../Images/Reset.gif" />
                                                    </FooterTemplate>
                                                    <HeaderStyle Width="60px" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </asp:Panel>
                        <%--Changes Done on 19th May 2011 Starts--%>
                                    <asp:Panel ID="PanelPatternSequence" Visible="true " Height="250px" Width="800px"
                                        ScrollBars="Vertical" runat="server" GroupingText="<%$Resources:Resource,PatternSequence %>">
                                        <table border="0">
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lblPatternSeqCode" runat="server" CssClass="cssLabel" Text="<%$Resources:Resource,PatternSeqCode %>"></asp:Label>
                                                </td>
                                                <td>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblExistingPatternSeqCode" runat="server" CssClass="cssLabel" Text="<%$Resources:Resource,existingPatternSeqCode %>"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:TextBox ID="txtPatternSeqCode" runat="server" CssClass="csstxtbox" Width="150px"
                                                        MaxLength="16"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rq" runat="server" ControlToValidate="txtPatternSeqCode" ErrorMessage="*" SetFocusOnError="true" ValidationGroup="SaveSeq"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="drpExistingPatternSeqCode" CssClass="cssDropDown" Width="150px"
                                                        runat="server" AutoPostBack="true" OnSelectedIndexChanged="drpPatternSeq_SelectedIndexChange">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:ListBox ID="lbShiftPatternCode" SelectionMode="Multiple" runat="server" Width="150px"
                                                        Height="140px"></asp:ListBox>
                                                </td>
                                                <td>
                                                    <table border="0">
                                                     <%--   <tr>
                                                            <td>
                                                                <asp:Button ID="btnLockUnlockSeq" runat="server" Text="<%$Resources:Resource,LockUnlockSeq %>"
                                                                    Width="80px" CssClass="cssButton" />
                                                            </td>
                                                        </tr>--%>
                                                        <tr>
                                                            <td>
                                                                <asp:Button ID="btnAdd" runat="server" Text="<%$Resources:Resource,Addnxt %>" Width="80px"
                                                                    CssClass="cssButton" OnClick="btnAdd_Click" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Button ID="btnRemove" runat="server" Text="<%$Resources:Resource,Removenxt %>"
                                                                    Width="80px" CssClass="cssButton" OnClick="btnRemove_Click" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td>
                                                    <asp:ListBox ID="lbShiftPatternSeq" SelectionMode="Multiple" runat="server" Width="150px"
                                                        Height="140px"></asp:ListBox>
                                                </td>
                                                <td>
                                                    <table border="0">
                                                        <tr>
                                                            <td>
                                                                <asp:ImageButton ID="btnUp" runat="server" CssClass="cssButton" Width="30px" OnClick="btnUp_Click"
                                                                    ImageUrl="~/Images/UpArrow.jpg" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:ImageButton ID="btnDown" runat="server" CssClass="cssButton" Width="30px" OnClick="btnDown_Click"
                                                                    ImageUrl="~/Images/DownArrow.jpg" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btnNewSeq" runat="server" Text="New Sequence" CssClass="cssButton"
                                                        OnClick="btnNewSeq_Click" />
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnSaveSeq" runat="server" Text="<%$Resources:Resource,SaveSeq %>" ValidationGroup="SaveSeq"
                                                        CssClass="cssButton" OnClick="btnSaveSeq_Click" />
                                                    <asp:Button ID="btnUpdateSeq" runat="server" Text="<%$Resources:Resource,UpdateSeq %>"
                                                        CssClass="cssButton" OnClick="btnUpdateSeq_Click" />
                                                    <asp:Button ID="btnDeleteSeq" runat="server" Text="<%$Resources:Resource,DeleteSeq %>"
                                                        CssClass="cssButton" OnClick="btnDeleteSeq_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                        <%--Changes Done By Manish gupta on 19th May 2011 Ends--%>
                        <table>
                            <tr>
                                <td>
                                    <asp:Panel ID="Panel6" BackColor="white" ScrollBars="Auto" CssClass="ScrollBar" runat="server"
                                        Height="200" Width="600" Style="display: none;">
                                        <asp:Button ID="Button3" runat="server" Style="display: none" />
                                        <AjaxToolKit:ModalPopupExtender ID="MPEDupShift" runat="server" TargetControlID="Button3"
                                            PopupControlID="Panel6" BackgroundCssClass="modalBackground" />
                                        <table>
                                            <tr>
                                                <td>
                                                    <Ajax:UpdatePanel ID="upDupChar" runat="server" UpdateMode="Conditional">
                                                        <ContentTemplate>
                                                            <asp:GridView ID="gvDuplicateShift" runat="server" Width="350px" AllowPaging="false"
                                                                AutoGenerateColumns="false" CellPadding="1" CssClass="GridViewStyle" GridLines="None"
                                                                PageSize="6" RowStyle-VerticalAlign="Bottom" ShowFooter="true" ShowHeader="true"
                                                                Visible="true" OnRowDataBound="gvDuplicateShift_RowDataBound">
                                                                <RowStyle CssClass="GridViewRowStyle" />
                                                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                                <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="<%$Resources:Resource,DuplicateShift %>">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblShift" CssClass="cssLabel" runat="server" Text='<%# Eval("Shift")%>'></asp:Label>
                                                                            <asp:HiddenField ID="HFPosition" runat="server" Value='<%# Eval("Position") %>' />
                                                                            <asp:HiddenField ID="HFCharPosition" runat="server" Value='<%# Eval("CharPosition") %>' />
                                                                            <asp:HiddenField ID="HFPatternCode" runat="server" Value='<%# Eval("CharPosition") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="<%$ Resources:Resource,SitePost%>">
                                                                        <ItemTemplate>
                                                                            <asp:DropDownList ID="ddlPDLineNo" Width="180px" CssClass="cssDropDown" runat="server">
                                                                            </asp:DropDownList>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </ContentTemplate>
                                                    </Ajax:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btnSavePattern" runat="server" Text="<%$Resources:Resource,Save %>"
                                                        CssClass="cssButton" OnClick="btnSavePattern_Click" />
                                                </td>
                                                <td align="left">
                                                    <asp:Button ID="btnCancel" runat="server" Text="<%$Resources:Resource,Close %>" CssClass="cssButton"
                                                        OnClick="btnCancel_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="lblPatternID" Visible="false" runat="server" Text="<%$Resources:Resource,PatternID %>"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtPatternID" CssClass="csstxtbox" Visible="false" runat="server"
                                        ValidationGroup="vgPatternid"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvShiftPattern" Width="3px" ValidationGroup="vgPatternid"
                                        SetFocusOnError="true" Visible="false" ControlToValidate="TxtPatternID" runat="server"
                                        ErrorMessage="*"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtPattern" Enabled="true" AutoPostBack="true" CssClass="csstxtbox"
                                        runat="server" Visible="false" OnTextChanged="TxtPattern_TextChanged"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Width="3px" ValidationGroup="vgPatternid"
                                        SetFocusOnError="true" Visible="false" ControlToValidate="TxtPattern" runat="server"
                                        ErrorMessage="*"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextPatternSave" Enabled="false" Visible="false" CssClass="csstxtbox"
                                        runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Width="3px" ValidationGroup="vgPatternid"
                                        SetFocusOnError="true" ControlToValidate="TextPatternSave" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                    <asp:HiddenField ID="HFPatternSave" runat="server" Value="" />
                                </td>
                                <td>
                                    <asp:Button ID="btnPatternSave" Visible="false" ValidationGroup="vgPatternid" runat="server"
                                        Text="<%$Resources:Resource,SavePattern %>" CssClass="cssButton" OnClick="btnPatternSave_Click" />
                                </td>
                                <td>
                                    <asp:Button ID="btnClear" runat="server" Visible="false" Text="<%$Resources:Resource,Clear %>"
                                        CssClass="cssButton" OnClick="btnClear_Click" />
                                </td>
                                <td>
                                    <asp:HiddenField ID="Hid_Shift" runat="server" />
                                    <asp:HiddenField ID="HFShiftPattern" runat="server" />
                                    <asp:HiddenField ID="HFAsmtCode" runat="server" />
                                    <asp:HiddenField ID="HFClientCode" runat="server" />
                                    <asp:HiddenField ID="HFAsmtID" runat="server" />
                                    <asp:HiddenField ID="HFPostCode" runat="server" />
                                    <asp:HiddenField ID="HFSystemparameter" runat="server" />
                                    <asp:HiddenField ID="HFShiftCode" runat="server" />
                                    <asp:HiddenField ID="HFSoLineNo" runat="server" />
                                    <asp:HiddenField ID="HFShowAllPatterns" runat="server" />
                                </td>
                                <%--                     <asp:Button ID="btnRefreshSequence" runat="server" OnClick="btnRefreshSequence_Click" style="display:none" />--%>
                            </tr>
                        </table>
                    </div>
            </div>
        </ContentTemplate>
    </Ajax:UpdatePanel>
    <script language="javascript" type="text/javascript">
//        window.onunload = CallParentWindowFunction;

        function CallParentWindowFunction() {

//            window.opener.ParentWindowFunction1();
//            window.close();
//            return false;

        }
        function OpenLockUnlockScreen(AsmtCode) {
            var pageName = "../Transactions/LockUnlockSeq.aspx?AsmtCode=" + AsmtCode;
            window.showModalDialog(pageName, 'search', "dialogHeight:650px; dialogWidth: 1030px;scroll:no");
        }
    </script>
</asp:Content>
