<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="Designation.aspx.cs" Inherits="Masters_Designation" Title="<%$ Resources:Resource, AppTitle %>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Button ID="btnExport" Visible="true" CssClass="cssButton" runat="server" Text="<%$Resources:Resource,ExporttoExcel %>" OnClick="btnExport_Click" />
            <asp:GridView Width="100%" ID="gvDesignation" runat="server" CellPadding="1" PageSize="10"
                ShowFooter="True" AutoGenerateColumns="False" OnRowCommand="gvDesignation_RowCommand"
                OnRowDeleting="gvDesignation_RowDeleting" OnRowEditing="gvDesignation_RowEditing"
                OnRowUpdating="gvDesignation_RowUpdating" OnRowCancelingEdit="gvDesignation_RowCancelingEdit"
                AllowPaging="True" OnPageIndexChanging="gvDesignation_PageIndexChanging" OnRowDataBound="gvDesignation_RowDataBound">
                <FooterStyle CssClass="GridViewFooterStyle" />
                <RowStyle CssClass="GridViewRowStyle" />
                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                <PagerStyle CssClass="GridViewPagerStyle" />
                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                <HeaderStyle CssClass="GridViewHeaderStyle" />
                <Columns>
                    <asp:TemplateField HeaderStyle-Width="50px" FooterStyle-Width="50px" ItemStyle-Width="50px">
                        <HeaderTemplate>
                            <asp:Label ID="lblHeaderSerial" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, SerialNumber %>"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblSerial" CssClass="cssLable" runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="200px" FooterStyle-Width="200px" ItemStyle-Width="200px">
                        <HeaderTemplate>
                            <asp:Label ID="lblHeaderDesignationCode" CssClass="cssLabelHeader" runat="server"
                                Text="<%$ Resources:Resource, DesignationCode %>"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                           <%-- <asp:Label ID="Label2" CssClass="cssLable" runat="server" Text='<%# Bind("DesignationCode") %>'></asp:Label>--%>
                            <asp:LinkButton ID="lnkDesignation" runat="server" CssClass="cssLable" Text='<%# Bind("DesignationCode") %>' OnClick="lnkDesignation_Click"></asp:LinkButton>

                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label ID="lblDesignation" CssClass="cssLable" runat="server" Text='<%# Eval("DesignationCode") %>'></asp:Label>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox Width="180px" ID="txtDesignationCodeNew" MaxLength="16" ValidationGroup="AddNew" CssClass="csstxtbox"
                                runat="server" Text='<%# Bind("DesignationCode") %>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3"  ValidationGroup="AddNew" runat="server" ControlToValidate="txtDesignationCodeNew" Display="Dynamic" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="600px" FooterStyle-Width="600px" ItemStyle-Width="600px">
                        <HeaderTemplate>
                            <asp:Label ID="lblHeaderDesignationDesc" CssClass="cssLabelHeader" runat="server"
                                Text="<%$ Resources:Resource, DesignationDescription %>"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" CssClass="cssLable" runat="server" Text='<%# Bind("DesignationDesc") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox Width="580px" ID="txtDesignationDesc" MaxLength="50" CssClass="csstxtbox" ValidationGroup="vgEdit"
                                runat="server" Text='<%# Bind("DesignationDesc") %>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="vgEdit" runat="server"
                                ControlToValidate="txtDesignationDesc" Display="Dynamic" ErrorMessage="*"
                                SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox Width="580px" ID="txtDesignationDescNew" MaxLength="50" ValidationGroup="AddNew" CssClass="csstxtbox"
                                runat="server" Text='<%# Bind("DesignationDesc") %>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="AddNew"
                                runat="server" ControlToValidate="txtDesignationDescNew" Display="Dynamic" ErrorMessage="*"
                                SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="100px" FooterStyle-Width="100px" ItemStyle-Width="100px">
                        <HeaderTemplate>
                            <asp:Label ID="lblHeaderAction" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, EditColName %>"></asp:Label>
                        </HeaderTemplate>
                        <EditItemTemplate>
                            <asp:ImageButton ID="ImgbtnUpdate" runat="server" CssClass="cssImgButton" CommandName="Update"
                                ValidationGroup="vgEdit" ToolTip="<%$ Resources:Resource, Update %>" ImageUrl="../Images/Save.gif" />
                            <asp:ImageButton ID="ImgbtnCancel" runat="server" CssClass="cssImgButton" CommandName="Cancel"
                                ToolTip="<%$ Resources:Resource, Cancel %>" ImageUrl="../Images/Cancel.gif" />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgbtnDelete" runat="server" CssClass="cssImgButton" CommandName="Delete"
                                ToolTip="<%$ Resources:Resource, Delete %>" ImageUrl="../Images/Delete.gif" />
                            <asp:ImageButton ID="ImgbtnEdit" runat="server" CssClass="cssImgButton" CommandName="Edit"
                                ToolTip="<%$ Resources:Resource, Edit %>" ImageUrl="../Images/Edit.gif" />
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:ImageButton ID="ImgbtnAdd" runat="server" CssClass="cssImgButton" CommandName="Add"
                                ToolTip="<%$Resources:Resource,Save %>" ValidationGroup="AddNew" ImageUrl="../Images/AddNew.gif" />
                            <asp:ImageButton ID="ImgbtnReset" runat="server" CssClass="cssImgButton" CommandName="Reset"
                                ToolTip="<%$ Resources:Resource, Reset %>" ImageUrl="../Images/Reset.gif" />
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Label EnableViewState="false" ID="lblErrorMsg" Text="" runat="server" CssClass="csslblErrMsg"></asp:Label>
            <br />
            <br />
            <div id="divGrade" runat="server" visible="false">
                 <div style="color:red;font-size:large"> <asp:Label ID="lblDesignationDesc" runat="server"   Text="<%$ Resources:Resource, DesignationCode %>"></asp:Label>:
                <asp:Label ID="lblDesignationName" runat="server"></asp:Label></div>
              
                     <asp:GridView Width="100%" ID="gvGrade" runat="server" CellPadding="1" PageSize="10"
                ShowFooter="True" AutoGenerateColumns="False" OnRowCommand="gvGrade_RowCommand"
                OnRowDeleting="gvGrade_RowDeleting" OnRowEditing="gvGrade_RowEditing"
                OnRowUpdating="gvGrade_RowUpdating" OnRowCancelingEdit="gvGrade_RowCancelingEdit"
                AllowPaging="True" OnPageIndexChanging="gvGrade_PageIndexChanging" OnRowDataBound="gvGrade_RowDataBound">
                <FooterStyle CssClass="GridViewFooterStyle" />
                <RowStyle CssClass="GridViewRowStyle" />
                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                <PagerStyle CssClass="GridViewPagerStyle" />
                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                <HeaderStyle CssClass="GridViewHeaderStyle" />
                <Columns>
                    <asp:TemplateField HeaderStyle-Width="50px" FooterStyle-Width="50px" ItemStyle-Width="50px">
                        <HeaderTemplate>
                            <asp:Label ID="lblHeaderSerial1" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, SerialNumber %>"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblSerial1" CssClass="cssLable" runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                          <asp:TemplateField HeaderStyle-Width="200px" FooterStyle-Width="200px" ItemStyle-Width="200px">
                        <HeaderTemplate>
                            <asp:Label ID="lblHeaderDescCode1" CssClass="cssLabelHeader" runat="server"
                                Text="<%$ Resources:Resource, DesignationCode %>"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblDesignationCode" CssClass="cssLable" runat="server" Text='<%# Bind("DesignationCode") %>'></asp:Label>
                         </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label ID="lblDesignationCode" CssClass="cssLable" runat="server" Text='<%# Eval("DesignationCode") %>'></asp:Label>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lblDesignationCode" CssClass="cssLable" runat="server" Text='<%# Bind("DesignationCode") %>'></asp:Label>
                                  </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="200px" FooterStyle-Width="200px" ItemStyle-Width="200px">
                        <HeaderTemplate>
                            <asp:Label ID="lblHeaderGradeCode1" CssClass="cssLabelHeader" runat="server"
                                Text="<%$ Resources:Resource, GradeCode %>"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblGradeCode" CssClass="cssLable" runat="server" Text='<%# Bind("GradeCode") %>'></asp:Label>
                         </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label ID="lblGradeCode" CssClass="cssLable" runat="server" Text='<%# Eval("GradeCode") %>'></asp:Label>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox Width="180px" ID="txtGradeCode" MaxLength="16" ValidationGroup="AddNewGrade" CssClass="csstxtbox"
                                runat="server" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3"  ValidationGroup="AddNewGrade" runat="server" ControlToValidate="txtGradeCode" Display="Dynamic" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="600px" FooterStyle-Width="600px" ItemStyle-Width="600px">
                        <HeaderTemplate>
                            <asp:Label ID="lblHeaderGradeDesc1" CssClass="cssLabelHeader" runat="server"
                                Text="<%$ Resources:Resource, GradeDesc %>"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblGradeDesc" CssClass="cssLable" runat="server" Text='<%# Bind("GradeDesc") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox Width="580px" ID="txtGradeDesc" MaxLength="50" CssClass="csstxtbox" ValidationGroup="EditGrade"
                                runat="server" Text='<%# Bind("GradeDesc") %>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="EditGrade" runat="server"
                                ControlToValidate="txtGradeDesc" Display="Dynamic" ErrorMessage="*"
                                SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox Width="580px" ID="txtGradeDesc" MaxLength="50" ValidationGroup="AddNewGrade" CssClass="csstxtbox"
                                runat="server" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="AddNewGrade"
                                runat="server" ControlToValidate="txtGradeDesc" Display="Dynamic" ErrorMessage="*"
                                SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="100px" FooterStyle-Width="100px" ItemStyle-Width="100px">
                        <HeaderTemplate>
                            <asp:Label ID="lblHeaderAction1" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, EditColName %>"></asp:Label>
                        </HeaderTemplate>
                        <EditItemTemplate>
                            <asp:ImageButton ID="ImgbtnUpdate" runat="server" CssClass="cssImgButton" CommandName="Update"
                                ValidationGroup="EditGrade" ToolTip="<%$ Resources:Resource, Update %>" ImageUrl="../Images/Save.gif" />
                            <asp:ImageButton ID="ImgbtnCancel" runat="server" CssClass="cssImgButton" CommandName="Cancel"
                                ToolTip="<%$ Resources:Resource, Cancel %>" ImageUrl="../Images/Cancel.gif" />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgbtnDelete" runat="server" CssClass="cssImgButton" CommandName="Delete"
                                ToolTip="<%$ Resources:Resource, Delete %>" ImageUrl="../Images/Delete.gif" />
                            <asp:ImageButton ID="ImgbtnEdit" runat="server" CssClass="cssImgButton" CommandName="Edit"
                                ToolTip="<%$ Resources:Resource, Edit %>" ImageUrl="../Images/Edit.gif" />
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:ImageButton ID="ImgbtnAdd" runat="server" CssClass="cssImgButton" CommandName="Add"
                                ToolTip="<%$Resources:Resource,Save %>" ValidationGroup="AddNewGrade" ImageUrl="../Images/AddNew.gif" />
                            <asp:ImageButton ID="ImgbtnReset" runat="server" CssClass="cssImgButton" CommandName="Reset"
                                ToolTip="<%$ Resources:Resource, Reset %>" ImageUrl="../Images/Reset.gif" />
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
                <asp:HiddenField ID="hfDesignationcode" runat="server" />
                  <asp:Label EnableViewState="false" ID="lblErrormsg1" Text="" runat="server" CssClass="csslblErrMsg"></asp:Label>
            </div>
        </ContentTemplate>
    </Ajax:UpdatePanel>
</asp:Content>
