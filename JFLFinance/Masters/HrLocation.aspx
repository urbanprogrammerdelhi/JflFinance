<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="HrLocation.aspx.cs" Inherits="Masters_HrLocation" Title="<%$ Resources:Resource, AppTitle %>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:ImageButton ID="imgBack" runat="server" ImageUrl="../Images/go_Back.gif" ToolTip="<%$ Resources:Resource, MainMenu %>"
                OnClick="imgBack_Click" />
                <asp:GridView Width="1100px" ID="gvHrLocation" CssClass="GridViewStyle" runat="server"
                    ShowFooter="true" ShowHeader="true" Visible="true" AllowPaging="true" PageSize="15"
                    CellPadding="1" GridLines="None" AutoGenerateColumns="False" OnRowCommand="gvHrLocation_RowCommand"
                    OnRowEditing="gvHrLocation_RowEditing" OnRowCancelingEdit="gvHrLocation_RowCancelingEdit"
                    OnRowUpdating="gvHrLocation_RowUpdating" OnRowDeleting="gvHrLocation_RowDeleting"
                    OnRowDataBound="gvHrLocation_RowDataBound" OnPageIndexChanging="gvHrLocation_PageIndexChanging">
                    <FooterStyle CssClass="GridViewFooterStyle" />
                    <RowStyle CssClass="GridViewRowStyle" />
                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                    <PagerStyle CssClass="GridViewPagerStyle" />
                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                    <Columns>
                        <asp:TemplateField HeaderStyle-Width="50px" FooterStyle-Width="50px" ItemStyle-Width="50px">
                            <HeaderTemplate>
                                <asp:Label ID="lblgvhdrSerialNo" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,SerialNumber %>"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblSerialNo" CssClass="cssLabel" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-Width="150px" FooterStyle-Width="150px" ItemStyle-Width="150px">
                            <HeaderTemplate>
                                <asp:Label ID="lblgvhdrCompanyCode" CssClass="cssLabelHeader" runat="server" Text="<% $ Resources:Resource, CompanyCode%>"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblgvCompanyCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CompanyCode").ToString()%>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Label ID="lblgvCompanyCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CompanyCode").ToString()%>'></asp:Label>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lblgvCompanyCode" CssClass="cssLable" runat="server" Text=""></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-Width="200px" FooterStyle-Width="200px" ItemStyle-Width="200px">
                            <HeaderTemplate>
                                <asp:Label ID="lblgvhdrCompanyDesc" CssClass="cssLabelHeader" runat="server" Text="<% $ Resources:Resource, CompanyDescription%>"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblgvCompanyDesc" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CompanyDesc").ToString()%>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Label ID="lblgvCompanyDesc" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CompanyDesc").ToString()%>'></asp:Label>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:DropDownList Width="180px" ID="ddlCompany" CssClass="cssDropDown" runat="server"
                                    OnSelectedIndexChanged="ddlCompany_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvddlCompany"  ValidationGroup="vgHrFooter" ControlToValidate="ddlCompany"
                                    runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-Width="150px" FooterStyle-Width="150px" ItemStyle-Width="150px">
                            <HeaderTemplate>
                                <asp:Label ID="lblgvhdrHrLocationCode" CssClass="cssLabelHeader" runat="server" Text="<% $ Resources:Resource, HrLocationCode%>"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblgvHrLocationCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "HrLocationCode").ToString()%>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Label ID="lblgvHrLocationCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "HrLocationCode").ToString()%>'></asp:Label>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox Width="130px" ID="txtHrLocationCode" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvHrLocationCode" ValidationGroup="vgHrFooter" ControlToValidate="txtHrLocationCode"
                                    runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-Width="200px" FooterStyle-Width="200px" ItemStyle-Width="200px">
                            <HeaderTemplate>
                                <asp:Label ID="lblgvhdrHrLocationDesc" CssClass="cssLabelHeader" runat="server" Text="<% $ Resources:Resource, HrLocationDescription%>"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblgvHrLocationDesc" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "HrLocationDesc").ToString()%>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox Width="180px" ID="txtHrLocationDesc" CssClass="csstxtbox" runat="server"
                                    Text='<%# DataBinder.Eval(Container.DataItem, "HrLocationDesc").ToString()%>'></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvHrLocationDesc" ValidationGroup="vgHrEdit" ControlToValidate="txtHrLocationDesc"
                                    runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox Width="180px" ID="txtHrLocationDesc" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvHrLocationDesc" ValidationGroup="vgHrFooter" ControlToValidate="txtHrLocationDesc"
                                    runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-Width="250px" FooterStyle-Width="250px" ItemStyle-Width="250px">
                            <HeaderTemplate>
                                <asp:Label ID="lblgvhdrHrLocationAdd" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, HrLocationAddress %>"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblgvHrLocationAdd" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "HrLocationAddress").ToString()%>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox Width="230px" ID="txtHrLocationAddress" CssClass="csstxtbox" runat="server"
                                    Text='<%# DataBinder.Eval(Container.DataItem, "HrLocationAddress").ToString()%>'></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvHrLocationAddress" ValidationGroup="vgHrEdit"
                                    ControlToValidate="txtHrLocationAddress" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox Width="230px" ID="txtHrLocationAddress" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvHrLocationAddress" ValidationGroup="vgHrFooter"
                                    ControlToValidate="txtHrLocationAddress" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-Width="100px" FooterStyle-Width="100px" ItemStyle-Width="100px">
                            <HeaderTemplate>
                                <asp:Label ID="lblaction" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, EditColName %>"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:ImageButton ID="ImgbtnDelete" runat="server" CssClass="cssImgButton" CommandName="Delete"
                                    ToolTip="<%$ Resources:Resource, Delete %>" ImageUrl="../Images/Delete.gif" />
                                <asp:LinkButton Visible="false" runat="server" ID="lnkbtnDelete" CssClass="csslnkButton"
                                    Text="<%$ Resources:Resource, Delete %>" CommandName="Delete"></asp:LinkButton>
                                &nbsp;
                                <asp:ImageButton ID="ImgbtnEdit" runat="server" CssClass="cssImgButton" CommandName="Edit"
                                    ToolTip="<%$ Resources:Resource, Edit %>" ImageUrl="../Images/Edit.gif" />
                                <asp:LinkButton Visible="false" runat="server" ID="lnkbtnEdit" CssClass="csslnkButton"
                                    Text="<%$ Resources:Resource, Edit %>" CommandName="Edit"></asp:LinkButton>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:ImageButton ID="ImgbtnUpdate" runat="server" CssClass="cssImgButton" CommandName="Update"
                                    ValidationGroup="vgHrEdit" ToolTip="<%$ Resources:Resource, Update %>" ImageUrl="../Images/Save.gif" />
                                <asp:LinkButton Visible="false" runat="server" ID="lnkbtnUpdate" CssClass="csslnkButton"
                                    ValidationGroup="vgHrEdit" Text="<%$ Resources:Resource, Update %>" CommandName="Update"></asp:LinkButton>
                                &nbsp;
                                <asp:ImageButton ID="ImgbtnCancel" runat="server" CssClass="cssImgButton" CommandName="Cancel"
                                    ToolTip="<%$ Resources:Resource, Cancel %>" ImageUrl="../Images/Cancel.gif" />
                                <asp:LinkButton Visible="false" runat="server" ID="lnkbtnCancel" CssClass="csslnkButton"
                                    Text="<%$ Resources:Resource, Cancel %>" CommandName="Cancel"></asp:LinkButton>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:ImageButton ID="ImgbtnAdd" runat="server" CssClass="cssImgButton" CommandName="Add"
                                    ValidationGroup="vgHrFooter" ToolTip="<%$Resources:Resource,Save %>" ImageUrl="../Images/AddNew.gif" />
                                <asp:LinkButton Visible="false" runat="server" ID="lnkbtnAdd" CssClass="csslnkButton"
                                    ValidationGroup="vgHrFooter" Text="<%$ Resources:Resource, AddNew %>" CommandName="Add"></asp:LinkButton>
                                &nbsp;
                                <asp:ImageButton ID="ImgbtnReset" runat="server" CssClass="cssImgButton" CommandName="Reset"
                                    ToolTip="<%$ Resources:Resource, Reset %>" ImageUrl="../Images/Reset.gif" />
                                <asp:LinkButton Visible="false" runat="server" ID="lnkbtnReset" CssClass="csslnkButton"
                                    Text="<%$ Resources:Resource, Reset %>" CommandName="Reset"></asp:LinkButton>
                            </FooterTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            <asp:Label EnableViewState="false" ID="lblErrorMsg" Text="" runat="server" CssClass="csslblErrMsg"></asp:Label>
        </ContentTemplate>
    </Ajax:UpdatePanel>
</asp:Content>
