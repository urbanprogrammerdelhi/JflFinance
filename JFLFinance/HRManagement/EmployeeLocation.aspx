<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="EmployeeLocation.aspx.cs" Inherits="Masters_EmployeeLocation" Title="<%$ Resources:Resource, AppTitle %>" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellpadding="1" cellspacing="0">
        <tr>
            <td align="center">
                <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table width="950" border="0">
                            <tr>
                                <td width="200">
                                    <asp:DropDownList AutoPostBack="true" ID="ddlSearchBy" Width="200px" runat="server"
                                        CssClass="cssDropDown" OnSelectedIndexChanged="ddlSearchBy_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td width="230">
                                    <asp:TextBox ID="txtSearch" Visible="false" Width="200px" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                    <asp:TextBox ID="txtSearchDate" Visible="false" Width="200px" CssClass="csstxtbox"
                                        runat="server"></asp:TextBox>
                                    <asp:HyperLink ID="imgSearchGrid" Style="vertical-align: middle;" Visible="false"
                                        runat="server" ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                                    <asp:HiddenField ID="hfSearchText" runat="server" />
                                </td>
                                <td align="left">
                                    <asp:Button ID="Button1" CssClass="cssButton" runat="server" Text="<%$Resources:Resource,Search %>"
                                        OnClick="btnSearch_Click" />
                                </td>
                                <td>
                                    <asp:Button ID="btnViewAll" Visible="false" CssClass="cssButton" runat="server" Text="<%$Resources:Resource,ViewAll %>"
                                        OnClick="btnViewAll_Click" />
                                </td>
                            </tr>
                        </table>
                        <table border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td>
                                    <asp:Panel ID="Panel1" BorderWidth="1px" runat="server" Width="950px" Height="415px"
                                        ScrollBars="Auto" CssClass="ScrollBar">
                                        <asp:GridView Width="950px" ID="gvEmployeeLocation" runat="server" PageSize="15"
                                            AllowPaging="True" ShowFooter="True" AutoGenerateColumns="False" OnRowEditing="gvEmployeeLocation_RowEditing"
                                            OnRowUpdating="gvEmployeeLocation_RowUpdating" OnRowCancelingEdit="gvEmployeeLocation_RowCancelingEdit"
                                            OnRowDataBound="gvEmployeeLocation_RowDataBound" OnPageIndexChanging="gvEmployeeLocation_PageIndexChanging">
                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                            <RowStyle CssClass="GridViewRowStyle" />
                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,SerialNumber %>" HeaderStyle-Width="20px"
                                                    FooterStyle-Width="20px" ItemStyle-Width="20px">
                                                    <%--<HeaderTemplate>
                                                        <asp:Label ID="lblHeaderSerial" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,SerialNumber %>"></asp:Label>
                                                    </HeaderTemplate>--%>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSerial" CssClass="cssLable" runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Company Name" Visible="False">
                                                    <%--<HeaderTemplate>
                                                        <asp:Label ID="lblHeaderCompany" CssClass="cssLabelHeader" runat="server" Text="Company Name"></asp:Label>
                                                    </HeaderTemplate>--%>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCompanyDesc" CssClass="cssLable" runat="server" Text='<%# Bind("CompanyDesc") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblCompanyDesc" CssClass="cssLable" runat="server" Text='<%# Eval("CompanyDesc") %>'></asp:Label>
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,EmployeeNumber %>" HeaderStyle-Width="40px"
                                                    FooterStyle-Width="40px" ItemStyle-Width="40px">
                                                    <%--<HeaderTemplate>
                                                        <asp:Label ID="lblHeaderEmployeeNumber" CssClass="cssLabelHeader" runat="server"
                                                            Text="<%$ Resources:Resource,EmployeeNumber %>"></asp:Label>
                                                    </HeaderTemplate>--%>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEmployeeNumber" CssClass="cssLable" runat="server" Text='<%# Bind("EmployeeNumber") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblEmployeeNumber" CssClass="cssLable" runat="server" Text='<%# Eval("EmployeeNumber") %>'></asp:Label>
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,EmployeeName %>" HeaderStyle-Width="100px"
                                                    FooterStyle-Width="100px" ItemStyle-Width="100px">
                                                    <%--<HeaderTemplate>
                                                        <asp:Label ID="lblHeaderName" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,EmployeeName %>"></asp:Label>
                                                    </HeaderTemplate>--%>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblName" CssClass="cssLable" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblName" CssClass="cssLable" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="LocationAutoID" Visible="False">
                                                    <%--<HeaderTemplate>
                                                        <asp:Label ID="lblHeaderLocationAutoID" CssClass="cssLabelHeader" runat="server"
                                                            Text="LocationAutoID"></asp:Label>
                                                    </HeaderTemplate>--%>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblLocationAutoID" CssClass="cssLable" runat="server" Text='<%# Bind("LocationAutoID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblLocationAutoID" CssClass="cssLable" runat="server" Text='<%# Eval("LocationAutoID") %>'></asp:Label>
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,Location %>" HeaderStyle-Width="100px"
                                                    FooterStyle-Width="100px" ItemStyle-Width="100px">
                                                    <%--<HeaderTemplate>
                                                        <asp:Label ID="lblHeaderLocationDesc" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,Location %>"></asp:Label>
                                                    </HeaderTemplate>--%>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblLocationDesc" CssClass="cssLable" runat="server" Text='<%# Bind("LocationDesc") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblLocationDesc" CssClass="cssLable" runat="server" Text='<%# Eval("LocationDesc") %>'></asp:Label>
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,EffectiveFrom %>" HeaderStyle-Width="80px"
                                                    FooterStyle-Width="80px" ItemStyle-Width="80px">
                                                    <%--<HeaderTemplate>
                                                        <asp:Label ID="lblHeaderEffectiveFrom" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,EffectiveFrom %>"></asp:Label>
                                                    </HeaderTemplate>--%>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEffectiveFrom" CssClass="cssLable" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("EffectiveFrom")) %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblEffectiveFrom" CssClass="cssLable" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("EffectiveFrom")) %>'></asp:Label>
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,EffectiveTo %>" Visible="False"
                                                    HeaderStyle-Width="150px" FooterStyle-Width="150px" ItemStyle-Width="150px">
                                                    <%--<HeaderTemplate>
                                                        <asp:Label ID="lblHeaderEffectiveTo" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,EffectiveTo %>"></asp:Label>
                                                    </HeaderTemplate>--%>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEffectiveTo" CssClass="cssLable" runat="server" Text='<%# Bind("EffectiveTo") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox Width="100px" ID="txtEffectiveTo" CssClass="csstxtbox" runat="server"
                                                            Text='<%# Bind("EffectiveTo") %>'></asp:TextBox>
                                                        <asp:HyperLink Style="vertical-align: top;" ID="imgEffectiveToDate" runat="server"
                                                            ImageUrl="../Images/pdate.gif"></asp:HyperLink>
                                                        <asp:RequiredFieldValidator ID="reqEffectiveTo" ErrorMessage="*" SetFocusOnError="true"
                                                            runat="server" ControlToValidate="txtEffectiveTo"></asp:RequiredFieldValidator>
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,Comment %>" 
                                                    HeaderStyle-Width="150px" FooterStyle-Width="150px" ItemStyle-Width="150px">
                                                    <%--<HeaderTemplate>
                                                        <asp:Label ID="lblHeaderEffectiveTo" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,EffectiveTo %>"></asp:Label>
                                                    </HeaderTemplate>--%>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblComment" CssClass="cssLable" runat="server" Text='<%# Bind("Comment") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox Width="140px" ID="txtComment" CssClass="csstxtbox" runat="server" Text='<%# Bind("Comment") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="150px" FooterStyle-Width="150px"
                                                    ItemStyle-Width="150px">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblHeaderFutureLocation" CssClass="cssLabelHeader" runat="server"
                                                            Text="<%$ Resources:Resource,FutureLocation %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblFutureLocation" CssClass="cssLable" runat="server" />
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:DropDownList Width="145px" ID="cmbFutureLocation" CssClass="csstxtbox" runat="server" />
                                                        <asp:CompareValidator ID="comFutureLocation" ErrorMessage="*" SetFocusOnError="true"
                                                            ValueToCompare='<%# Bind("LocationAutoID") %>' Operator="NotEqual" ControlToValidate="cmbFutureLocation"
                                                            runat="server" />
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="50px" FooterStyle-Width="50px" ItemStyle-Width="50px">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblHeaderAction" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,Action %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <EditItemTemplate>
                                                        <asp:ImageButton ID="ImgbtnUpdate" runat="server" CssClass="cssImgButton" CommandName="Update"
                                                            CausesValidation="True" ToolTip="<%$ Resources:Resource, Update %>" ImageUrl="../Images/Save.gif" />
                                                        <asp:ImageButton ID="ImgbtnCancel" runat="server" CssClass="cssImgButton" CommandName="Cancel"
                                                            ToolTip="<%$ Resources:Resource, Cancel %>" CausesValidation="false" ImageUrl="../Images/Cancel.gif" />
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ImgbtnEdit" runat="server" CssClass="cssImgButton" CommandName="Edit"
                                                            ToolTip="<%$ Resources:Resource, Edit %>" ImageUrl="../Images/Edit.gif" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </asp:Panel>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label EnableViewState="false" ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </Ajax:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
