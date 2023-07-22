<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="standardShift.aspx.cs" Inherits="Masters_standardShift" Title="<%$ Resources:Resource, AppTitle %>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
        <ContentTemplate>
            <table width="100%" border="0" cellpadding="3" cellspacing="0">
                <tr>
                    <td align="left">
                        <asp:Label ID="Label12" runat="server" Text="<%$ Resources:Resource, Branch %>" CssClass="cssLable"></asp:Label>
                        <asp:DropDownList ID="ddlBranch" AutoPostBack="false" runat="server" CssClass="cssDropDown" Width="250px">
                        </asp:DropDownList>
                        <asp:Button ID="btnShiftPatternCopyToBranch" Width="100px" runat="server" CssClass="cssButton" ToolTip="<%$ Resources:Resource, Copy %>" Text="<%$ Resources:Resource, Copy %>" OnClick="btnShiftPatternCopyToBranch_Click" />
                    </td>
                    <td align="right">
                        <asp:Button ID="btnShiftPattern" Width="100px" runat="server" CssClass="cssButton" Visible="false" ToolTip="<%$ Resources:Resource, ShiftPattern %>" Text="<%$ Resources:Resource, ShiftPattern %>" OnClick="btnShiftPattern_Click" />                    
                    </td>
                </tr>
            </table>
            <asp:GridView ID="gvStandardShift" Width="100%" CssClass="GridViewStyle" PageSize="15"
                runat="server" AllowPaging="true" CellPadding="1" GridLines="None" DataKeyNames="ShiftCode"
                AutoGenerateColumns="False" OnRowCancelingEdit="gvStandardShift_RowCancelingEdit"
                OnRowCommand="gvStandardShift_RowCommand" OnRowDataBound="gvStandardShift_RowDataBound"
                OnRowDeleting="gvStandardShift_RowDeleting" OnRowEditing="gvStandardShift_RowEditing"
                OnRowUpdating="gvStandardShift_RowUpdating" ShowFooter="True" OnPageIndexChanging="gvStandardShift_PageIndexChanging">
                <FooterStyle CssClass="GridViewFooterStyle" />
                <RowStyle CssClass="GridViewRowStyle" />
                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                <PagerStyle CssClass="GridViewPagerStyle" />
                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                <HeaderStyle CssClass="GridViewHeaderStyle" />
                <Columns>
                    <asp:TemplateField HeaderText="<%$Resources:Resource,SerialNumber %>" HeaderStyle-Width="50px"
                        FooterStyle-Width="50px" ItemStyle-Width="50px" HeaderStyle-CssClass="cssLabelHeader">
                        <ItemTemplate>
                            <asp:Label ID="lblSerialNo" CssClass="cssLable" runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$Resources:Resource,ShiftCode %>" HeaderStyle-Width="150px"
                        FooterStyle-Width="150px" ItemStyle-Width="150px">
                        <EditItemTemplate>
                            <asp:Label ID="lblShiftCode" CssClass="cssLable" runat="server" Text='<%# Eval("ShiftCode") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblShiftCode" CssClass="cssLable" Width="100px" runat="server" Text='<%# Bind("ShiftCode") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtShiftCode" Width="100px" MaxLength="1" ValidationGroup="AddNew"
                                CssClass="csstxtbox" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvShiftCode" runat="server" ControlToValidate="txtShiftCode"
                                ErrorMessage="*" SetFocusOnError="True" ValidationGroup="AddNew" Display="Dynamic"></asp:RequiredFieldValidator>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$Resources:Resource,StartTime %>" HeaderStyle-Width="180px"
                        FooterStyle-Width="180px" ItemStyle-Width="180px">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtStartTime" Width="180px" MaxLength="5" ValidationGroup="Edit"
                                CssClass="csstxtbox" runat="server" Text='<%# String.Format("{0:HH:mm}",Eval("StartTime"))%>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvStartTime" runat="server" ControlToValidate="txtStartTime"
                                ValidationGroup="Edit" ErrorMessage="*" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblStartTime" CssClass="cssLable" runat="server" Text='<%# String.Format("{0:HH:mm}",Eval("StartTime"))%>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtStartTime" Width="180px" MaxLength="5" ValidationGroup="AddNew"
                                CssClass="csstxtbox" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvStartTime" runat="server" ControlToValidate="txtStartTime"
                                ValidationGroup="AddNew" ErrorMessage="*" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$Resources:Resource,EndTime %>" HeaderStyle-Width="180px"
                        FooterStyle-Width="180px" ItemStyle-Width="180px">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtEndTime" Width="180px" MaxLength="5" ValidationGroup="Edit" CssClass="csstxtbox"
                                runat="server" Text='<%# String.Format("{0:HH:mm}",Eval("EndTime"))%>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvEndTime" runat="server" ControlToValidate="txtEndTime"
                                ValidationGroup="Edit" ErrorMessage="*" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblEndTime" CssClass="cssLable" runat="server" Text='<%# String.Format("{0:HH:mm}",Eval("EndTime"))%>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtEndTime" Width="180px" MaxLength="5" ValidationGroup="AddNew"
                                CssClass="csstxtbox" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvEndTime" runat="server" ControlToValidate="txtEndTime"
                                ValidationGroup="AddNew" ErrorMessage="*" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$Resources:Resource,ShiftMinutes %>" HeaderStyle-Width="180px"
                        FooterStyle-Width="180px" ItemStyle-Width="180px">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtShiftMinutes" Width="180px" Text='<%# Bind("ShiftMinutes") %>' CssClass="csstxtbox" runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblShiftMinutes" CssClass="cssLable" runat="server" Text='<%# Bind("ShiftMinutes") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtShiftMinutes" Width="180px" Text="0" CssClass="csstxtbox" runat="server"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblgvhdrDescription" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, Description %>"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblgvDescription" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Description").ToString()%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox Width="180px" ID="txtDescription" CssClass="csstxtbox" runat="server"
                                Text='<%# DataBinder.Eval(Container.DataItem, "Description").ToString()%>'></asp:TextBox>
                            <%-- <asp:RequiredFieldValidator ID="rfvDescription" ValidationGroup="vgCEdit" ControlToValidate="txtDescription"
                                runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>--%>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox Width="180px" ID="txtDescription" CssClass="csstxtbox" runat="server"></asp:TextBox>
                            <%-- <asp:RequiredFieldValidator ID="rfvDescription" ValidationGroup="vgCFooter" ControlToValidate="txtDescription"
                                runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>--%>
                        </FooterTemplate>
                        <%--<ItemStyle Width="300px" />
                        <HeaderStyle Width="300px" />
                        <FooterStyle Width="300px" />--%>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="<%$Resources:Resource,EditColName %>" HeaderStyle-Width="100px"
                        FooterStyle-Width="100px" ItemStyle-Width="100px">
                        <EditItemTemplate>
                            <asp:ImageButton ID="ImgBtnUpdate" ToolTip="<%$Resources:Resource,Update %>" ImageUrl="~/Images/save.gif"
                                CssClass="csslnkButton" runat="server" CommandName="Update" ValidationGroup="Edit" />
                            <asp:ImageButton ID="ImgBtnCancel" ToolTip="<%$Resources:Resource,Cancel %>" ImageUrl="~/Images/Cancel.gif"
                                CssClass="csslnkButton" runat="server" CausesValidation="False" CommandName="Cancel" />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgBtnEdit" ToolTip="<%$Resources:Resource,Edit %>" ImageUrl="~/Images/Edit.gif"
                                CssClass="csslnkButton" runat="server" CausesValidation="False" CommandName="Edit" />
                            <asp:ImageButton ID="ImgBtnDelete" ToolTip="<%$Resources:Resource,Delete %>" ImageUrl="~/Images/Delete.gif"
                                runat="server" CssClass="csslnkButton" CausesValidation="False" CommandName="Delete" />
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:ImageButton ID="ImgBtnAddNew" runat="server" ToolTip="<%$Resources:Resource,Save %>"
                                CssClass="cssImgButton" ValidationGroup="AddNew" CommandName="AddNew" ImageUrl="../Images/AddNew.gif" />
                            <asp:ImageButton ID="ImgBtnReset" ToolTip="<%$Resources:Resource,Reset %>" runat="server"
                                CssClass="cssImgButton" CommandName="Reset" CausesValidation="False" ImageUrl="../Images/Reset.gif" />
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Label EnableViewState="false" ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg"></asp:Label>
        </ContentTemplate>
    </Ajax:UpdatePanel>
</asp:Content>
