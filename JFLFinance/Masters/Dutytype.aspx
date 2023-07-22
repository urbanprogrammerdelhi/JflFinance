<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="Dutytype.aspx.cs" Inherits="Masters_Dutytype" Title="<%$ Resources:Resource, AppTitle %>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
                <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:GridView Width="100%" ID="gvDutytype" PageSize="15" CssClass="GridViewStyle"
                            runat="server" ShowFooter="True" AllowPaging="True" CellPadding="1" DataKeyNames="DutytypeCode"
                            AutoGenerateColumns="False" OnRowCommand="gvDutytype_RowCommand" OnRowEditing="gvDutytype_RowEditing"
                            OnRowUpdating="gvDutytype_RowUpdating" OnSelectedIndexChanged="gvDutytype_SelectedIndexChanged"
                            OnDataBound="gvDutytype_DataBound" OnRowCancelingEdit="gvDutytype_RowCancelingEdit"
                            OnRowDeleting="gvDutytype_RowDeleting" OnPageIndexChanging="gvDutytype_PageIndexChanging"
                            OnRowDataBound="gvDutytype_RowDataBound">
                            <FooterStyle CssClass="GridViewFooterStyle" />
                            <RowStyle CssClass="GridViewRowStyle" />
                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                            <PagerStyle CssClass="GridViewPagerStyle" />
                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                            <Columns>
                                <asp:TemplateField HeaderText="<%$ Resources:Resource,SerialNumber %>" HeaderStyle-Width="50px"
                                    FooterStyle-Width="50px" ItemStyle-Width="50px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSerialNo" CssClass="cssLable" runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="cssLabelHeader" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$ Resources:Resource,DutytypeCode %>" HeaderStyle-Width="200px"
                                    FooterStyle-Width="200px" ItemStyle-Width="200px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblEditDutytypeCode" CssClass="cssLable" runat="server" Text='<%# Eval("DutytypeCode") %>'></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblDutytypeCode" Width="180px" CssClass="cssLable" runat="server"
                                            Text='<%# Bind("DutytypeCode") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="cssLabelHeader" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$ Resources:Resource,DutytypeDesc %>" HeaderStyle-Width="300px"
                                    FooterStyle-Width="600px" ItemStyle-Width="600px">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtDutytypeDesc" ValidationGroup="Edit" Width="280px" MaxLength="50"
                                            CssClass="csstxtbox" runat="server" Text='<%# Bind("DutytypeDesc") %>'></asp:TextBox>&nbsp;
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDutytypeDesc"
                                            Display="Dynamic" ErrorMessage="" SetFocusOnError="True" ValidationGroup="Edit">*</asp:RequiredFieldValidator>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" CssClass="cssLable" runat="server" Text='<%# Bind("DutytypeDesc") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtNewDutytypeDesc" ValidationGroup="AddNew" Width="280px"
                                            MaxLength="50" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNewDutytypeDesc"
                                            Display="Dynamic" ErrorMessage="" ValidationGroup="AddNew">*</asp:RequiredFieldValidator>
                                    </FooterTemplate>
                                    <HeaderStyle CssClass="cssLabelHeader" />
                                </asp:TemplateField>
                                                
                                <asp:TemplateField HeaderText="<%$ Resources:Resource,IsBillable %>" HeaderStyle-Width="100px"
                                    FooterStyle-Width="200px" ItemStyle-Width="100px">
                                    <EditItemTemplate>
                                        <asp:CheckBox ID="chkIsBillable" ValidationGroup="AddNew" CssClass="csstxtbox" Checked='<%# Bind("IsBillable") %>'  runat="server" />&nbsp;
                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="chkIsBillable"
                                            Display="Dynamic" ErrorMessage="" SetFocusOnError="True" ValidationGroup="Edit">*</asp:RequiredFieldValidator>--%>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblIsBillable" Width="80px" CssClass="cssLable" runat="server"
                                            Text='<%# Bind("IsBillable") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:CheckBox ID="chkNewIsBillable" ValidationGroup="AddNew" CssClass="csstxtbox"  runat="server" />
                                    </FooterTemplate>
                                    <HeaderStyle CssClass="cssLabelHeader" />
                                </asp:TemplateField>
                                                
                                <asp:TemplateField HeaderText="<%$ Resources:Resource,IsActive %>" HeaderStyle-Width="100px"
                                    FooterStyle-Width="200px" ItemStyle-Width="100px">
                                    <EditItemTemplate>
                                        <asp:CheckBox ID="chkIsActive" Checked='<%# Bind("IsActive") %>' ValidationGroup="AddNew" CssClass="csstxtbox"  runat="server" />&nbsp;
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblIsActive" Width="80px" CssClass="cssLable" runat="server"
                                            Text='<%# Bind("IsActive") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:CheckBox ID="chkNewIsActive" ValidationGroup="AddNew" CssClass="csstxtbox"  runat="server" />
                                    </FooterTemplate>
                                    <HeaderStyle CssClass="cssLabelHeader" />
                                </asp:TemplateField>
                                                
                                <asp:TemplateField HeaderText="<%$ Resources:Resource,IsDefault %>" HeaderStyle-Width="100px"
                                    FooterStyle-Width="200px" ItemStyle-Width="100px">
                                    <EditItemTemplate>
                                        <asp:CheckBox ID="chkIsDefault" Checked='<%# Bind("IsDefault") %>' ValidationGroup="AddNew" CssClass="csstxtbox"  runat="server" />&nbsp;
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblIsDefault" Width="80px" CssClass="cssLable" runat="server"
                                            Text='<%# Bind("IsDefault") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:CheckBox ID="chkNewIsDefault" ValidationGroup="AddNew" CssClass="csstxtbox" runat="server" />
                                    </FooterTemplate>
                                    <HeaderStyle CssClass="cssLabelHeader" />
                                </asp:TemplateField>
                                                                                                                                                
                                <asp:TemplateField HeaderText="<%$ Resources:Resource,EditColName %>">
                                    <EditItemTemplate>
                                        <asp:ImageButton ID="ImgbtnUpdateDT" ToolTip="<%$Resources:Resource,Update %>"
                                            ImageUrl="~/Images/save.gif" CssClass="csslnkButton" runat="server" CommandName="Update"
                                            ValidationGroup="Edit" />
                                        <asp:ImageButton ID="ImageButton2Qual" ToolTip="<%$Resources:Resource,Cancel %>"
                                            ImageUrl="~/Images/Cancel.gif" CssClass="csslnkButton" runat="server" CausesValidation="False"
                                            CommandName="Cancel" />
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="IBEditDT" ToolTip="<%$Resources:Resource,Edit %>" ImageUrl="~/Images/Edit.gif"
                                            CssClass="csslnkButton" ValidationGroup="Edit" runat="server" CausesValidation="False"
                                            CommandName="Edit" />
                                        <%--<asp:ImageButton ID="IBDeleteDT" ToolTip="<%$Resources:Resource,Delete %>" ImageUrl="~/Images/Delete.gif"
                                            runat="server" CssClass="csslnkButton" CausesValidation="False" CommandName="Delete" />--%>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:ImageButton ID="lbADD" runat="server" ToolTip="<%$Resources:Resource,Save %>"
                                            CssClass="cssImgButton" ValidationGroup="AddNew" CommandName="AddNew" ImageUrl="../Images/AddNew.gif" />
                                        <asp:ImageButton ID="lbReset" ToolTip="<%$Resources:Resource,Reset %>" runat="server"
                                            CssClass="cssImgButton" CommandName="Reset" ImageUrl="../Images/Reset.gif" />
                                    </FooterTemplate>
                                    <FooterStyle Width="100px" />
                                    <HeaderStyle Width="100px" CssClass="cssLabelHeader" />
                                    <ItemStyle Width="100px" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    <asp:Label EnableViewState="false" ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg"></asp:Label>
                    </ContentTemplate>
                </Ajax:UpdatePanel>
</asp:Content>
