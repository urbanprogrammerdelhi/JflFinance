<%@ Page Title="<%$ Resources:Resource, AppTitle %>" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master"
    AutoEventWireup="true" CodeFile="ClientPostOTFactor.aspx.cs" Inherits="Sales_ClientPostOTFactor" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellpadding="3" cellspacing="0">
        <%-- <tr>
            <td align="right">
                <asp:ImageButton ID="imgBack" runat="server" ImageUrl="../Images/go_Back.gif" ToolTip="<%$ Resources:Resource, Client %>"
                    OnClick="imgBack_Click" />
            </td>
        </tr>--%>
        <tr>
            <td>
                <Ajax:UpdatePanel runat="server" ID="up2" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table>
                            <%-- <tr>
                                <td align="right">
                                    <asp:Label runat="server" ID="lblArea" Text="<%$Resources:Resource,Area %>" CssClass="cssLabel"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList runat="server" ID="ddlAreaID" CssClass="cssDropDown" AutoPostBack="true"
                                        Width="125px" OnSelectedIndexChanged="ddlAreaID_SelectedIndexChanged" Height="17px">
                                    </asp:DropDownList>
                                </td>
                            </tr>--%>
                            <tr>
                                <td align="right" width="200">
                                    <asp:Label ID="lblhdrClient" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, Client %>"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtClientCode" runat="server" CssClass="csstxtbox" OnTextChanged="txtClientCode_TextChanged"
                                        Visible="false"></asp:TextBox>
                                    <%--<asp:Image ID="ImgClientCode_CCH" runat="server" ImageUrl="~/Images/icosearch.gif" />--%>
                                    <asp:DropDownList ID="ddlClient" runat="server" CssClass="cssDropDown" AutoPostBack="true"
                                        Width="280" OnSelectedIndexChanged="ddlClient_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="200">
                                    <asp:Label ID="lblhdrAsmt" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, Asmt %>"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlAsmt" runat="server" CssClass="cssDropDown" AutoPostBack="true"
                                        Width="280" OnSelectedIndexChanged="ddlAsmt_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="200">
                                    <asp:CheckBox ID="CBLastAmendment" runat="server" Checked="true" Text="Last Amendment"
                                        AutoPostBack="true" OnCheckedChanged="CBLastAmendment_CheckedChanged" />
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </Ajax:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td align="center">
                <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Always">
                    <ContentTemplate>
                        <table border="0" cellpadding="1" cellspacing="0" style="width: 100%">
                            <tr>
                                <td>
                                    <asp:Panel ID="Panel1" BorderWidth="1px" runat="server" Width="1000px" Height="350px"
                                        ScrollBars="Auto" CssClass="ScrollBar">
                                        <asp:HiddenField runat="server" ID="hfAsmtId" Value="" />
                                        <asp:HiddenField runat="server" ID="hfClientCode" Value="" />
                                        <asp:GridView Width="980px" ID="gvPost" CssClass="GridViewStyle" runat="server" ShowFooter="true"
                                            ShowHeader="true" Visible="true" AllowPaging="true" PageSize="15" CellPadding="1"
                                            GridLines="None" AutoGenerateColumns="False" OnRowCommand="gvPost_RowCommand"
                                            OnRowEditing="gvPost_RowEditing" OnRowCancelingEdit="gvPost_RowCancelingEdit"
                                            OnRowUpdating="gvPost_RowUpdating" OnRowDeleting="gvPost_RowDeleting" OnRowDataBound="gvPost_RowDataBound"
                                            OnPageIndexChanging="gvPost_PageIndexChanging">
                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                            <RowStyle CssClass="GridViewRowStyle" />
                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                                            <Columns>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvhdrSerialNo" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,SerialNumber %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSerialNo" CssClass="cssLabel" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                                        <asp:HiddenField ID="hfPostAutoID" runat="server" Value='<%# Eval("PostAutoId")%>' />
                                                    </ItemTemplate>
                                                    <ItemStyle Width="10px" />
                                                    <HeaderStyle Width="10px" />
                                                    <FooterStyle Width="10px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvhdrAmendNo" CssClass="cssLabelHeader" runat="server" Text="Amend No"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAmendNo" CssClass="cssLabel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AmendNo").ToString()%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblAmendNo" CssClass="cssLabel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AmendNo").ToString()%>'></asp:Label>
                                                    </EditItemTemplate>
                                                    <ItemStyle Width="10px" />
                                                    <HeaderStyle Width="10px" />
                                                    <FooterStyle Width="10px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvhdrClientCode" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, ClientCode %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvClientCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ClientCode").ToString()%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblgvClientCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ClientCode").ToString()%>'></asp:Label>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblgvClientCode" CssClass="cssLable" runat="server" Text=''></asp:Label>
                                                    </FooterTemplate>
                                                    <ItemStyle Width="80px" />
                                                    <HeaderStyle Width="80px" />
                                                    <FooterStyle Width="80px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvhdrAsmtId" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, AsmtId %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvAsmtId" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AsmtId").ToString()%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblgvAsmtId" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AsmtId").ToString()%>'></asp:Label>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblgvAsmtId" CssClass="cssLable" runat="server" Text=''></asp:Label>
                                                    </FooterTemplate>
                                                    <ItemStyle Width="90px" />
                                                    <HeaderStyle Width="90px" />
                                                    <FooterStyle Width="90px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvhdrPostCode" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, PostCode %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvPostCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"PostCode").ToString() %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblgvPostCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"PostCode").ToString() %>'></asp:Label>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox Width="70px" ID="txtPostCode" CssClass="csstxtbox" runat="server" ReadOnly="true"></asp:TextBox>
                                                        <%--<asp:RequiredFieldValidator ID="rfvPostCode" ValidationGroup="vgHrFooter" ControlToValidate="txtPostCode"
                                                            runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>--%>
                                                    </FooterTemplate>
                                                    <ItemStyle Width="90px" />
                                                    <HeaderStyle Width="90px" />
                                                    <FooterStyle Width="90px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvhdrShrtPostCode" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, ShortPostDesc %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvShrtPostCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"PostAutoId").ToString() %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label Width="70px" ID="lblgvShrtPostCode" CssClass="cssLable" runat="server"
                                                            Text='<%# DataBinder.Eval(Container.DataItem,"PostAutoId").ToString() %>'></asp:Label>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox Width="70px" ID="txtShrtPostCode" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvShrtPostCode" ValidationGroup="vgHrFooter" ControlToValidate="txtShrtPostCode"
                                                            runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                    </FooterTemplate>
                                                    <ItemStyle Width="90px" />
                                                    <HeaderStyle Width="90px" />
                                                    <FooterStyle Width="90px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvhdrPostDesc" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, PostDesc %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvPostDesc" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"PostDesc").ToString() %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox Width="180px" ID="txtPostDesc" CssClass="csstxtbox" runat="server" ReadOnly="true"
                                                            Text='<%# DataBinder.Eval(Container.DataItem, "PostDesc").ToString()%>'></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvPostDesc" ValidationGroup="vgHrEdit" ControlToValidate="txtPostDesc"
                                                            runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <%--<asp:TextBox Width="160px" ID="txtPostDesc" CssClass="csstxtbox" Style="position: absolute"
                                                            runat="server"></asp:TextBox>--%>
                                                        <asp:DropDownList runat="server" ID="ddlPost" CssClass="cssDropDown" AutoPostBack="true"
                                                            Width="180px" OnSelectedIndexChanged="ddlPost_SelectedIndexChanged" />
                                                        <asp:RequiredFieldValidator ID="rfvPostDesc" ValidationGroup="vgHrFooter" ControlToValidate="ddlPost"
                                                            runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                    </FooterTemplate>
                                                    <ItemStyle Width="210px" />
                                                    <HeaderStyle Width="210px" />
                                                    <FooterStyle Width="210px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvhdrPhone" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, Phone %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvPostPhone" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Phone").ToString() %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox Width="130px" ID="txtPostPhone" CssClass="csstxtbox" runat="server"
                                                            Text='<%# DataBinder.Eval(Container.DataItem, "Phone").ToString()%>'></asp:TextBox>
                                                        <%--<asp:RequiredFieldValidator ID="rfvPostDesc" ValidationGroup="vgHrEdit" ControlToValidate="txtPostDesc" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>--%>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox Width="130px" ID="txtPostPhone" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                                        <%-- <asp:RequiredFieldValidator ID="rfvPostPhone" ValidationGroup="vgHrFooter" ControlToValidate="txtPostPhone"
                                                            runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>--%>
                                                    </FooterTemplate>
                                                    <ItemStyle Width="150px" />
                                                    <HeaderStyle Width="150px" />
                                                    <FooterStyle Width="150px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="100px" FooterStyle-Width="100px" ItemStyle-Width="100px"
                                                    Visible="false">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvhdrPostNo" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, PostPositionNo %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvPostNo" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"PostPositionNo").ToString() %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox Width="90px" ID="txtPostNo" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PostPositionNo").ToString()%>'></asp:TextBox>
                                                        <%--<asp:RequiredFieldValidator ID="rfvPostDesc" ValidationGroup="vgHrEdit" ControlToValidate="txtPostDesc" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>--%>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox Width="90px" ID="txtPostNo" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                                        <%--<asp:RequiredFieldValidator ID="rfvPostNo" ValidationGroup="vgHrFooter" ControlToValidate="txtPostNo" runat="server" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator>--%>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="180px" ItemStyle-Width="180px" FooterStyle-Width="180px">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblhdrEffectiveFrom" CssClass="cssLabel" runat="server" Text="Effective From"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEffectiveFrom" Width="80px" CssClass="cssLabel" runat="server"
                                                            Text='<%# String.Format("{0:dd-MMM-yyyy}", Eval("EffectiveFrom"))%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblEffectiveFrom" Width="80px" CssClass="cssLabel" runat="server"
                                                            Text='<%# String.Format("{0:dd-MMM-yyyy}", Eval("EffectiveFrom"))%>'></asp:Label>
                                                        <%--<asp:TextBox ID="txtEditEffectiveFrom" CssClass="csstxtbox" runat="server" Width="90px"
                                                            Text='<%# String.Format("{0:dd-MMM-yyyy}", Eval("EffectiveFrom"))%>' AutoPostBack="true">
                                                            
                                                        </asp:TextBox>
                                                        <AjaxToolKit:CalendarExtender ID="CalendarExtender4" Format="dd-MMM-yyyy" runat="server"
                                                            TargetControlID="txtEditEffectiveFrom" PopupButtonID="IMGDate" />--%>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtftrEffectiveFrom" CssClass="csstxtbox" runat="server" Width="90px"
                                                            AutoPostBack="true" OnTextChanged="txtftrEffectiveFrom_TextChanged" Enabled="false">
                                                        </asp:TextBox>
                                                        <asp:ImageButton ID="IMGEffectiveFrom" Style="vertical-align: middle" CausesValidation="true"
                                                            runat="server" ImageUrl="~/Images/pdate.gif"></asp:ImageButton>
                                                        <AjaxToolKit:CalendarExtender ID="CalendarExtender5" Format="dd-MMM-yyyy" runat="server"
                                                            TargetControlID="txtftrEffectiveFrom" PopupButtonID="IMGEffectiveFrom" />
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="180px" ItemStyle-Width="180px" FooterStyle-Width="180px">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblhdrEffectiveTo" CssClass="cssLabel" runat="server" Text="Effective To"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEffectiveTo" Width="80px" CssClass="cssLabel" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}", Eval("EffectiveTo"))%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtEditEffectiveTo" CssClass="csstxtbox" runat="server" Width="90px"
                                                            Text='<%# String.Format("{0:dd-MMM-yyyy}", Eval("EffectiveTo"))%>' AutoPostBack="true"
                                                            Enabled="false">
                                                            <%--OnTextChanged="txtEditEffectiveFrom_TextChanged"--%>
                                                        </asp:TextBox>
                                                        <asp:ImageButton ID="IMGEditEffectiveTo" Style="vertical-align: middle" CausesValidation="true"
                                                            runat="server" ImageUrl="~/Images/pdate.gif"></asp:ImageButton>
                                                        <AjaxToolKit:CalendarExtender ID="CalendarExtender2" Format="dd-MMM-yyyy" runat="server"
                                                            TargetControlID="txtEditEffectiveTo" PopupButtonID="IMGEditEffectiveTo" />
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtftrEffectiveTo" CssClass="csstxtbox" runat="server" Width="90px"
                                                            AutoPostBack="true" OnTextChanged="txtftrEffectiveTo_TextChanged" Enabled="false">

                                                        </asp:TextBox>
                                                        <asp:ImageButton ID="IMGEffectiveTo" Style="vertical-align: middle" CausesValidation="true"
                                                            runat="server" ImageUrl="~/Images/pdate.gif"></asp:ImageButton>
                                                        <AjaxToolKit:CalendarExtender ID="CalendarExtender2" Format="dd-MMM-yyyy" runat="server"
                                                            TargetControlID="txtftrEffectiveTo" PopupButtonID="IMGEffectiveTo" />
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="100px" FooterStyle-Width="100px" ItemStyle-Width="100px">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvhdrElementCode" CssClass="cssLabelHeader" runat="server" Text=" Element Code"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvElementCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"ElementCode").ToString() %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox Width="90px" ID="txtEditElementCode" CssClass="csstxtbox" runat="server"
                                                            Text='<%# DataBinder.Eval(Container.DataItem, "ElementCode").ToString()%>' MaxLength="50"></asp:TextBox>
                                                        <%--<asp:RequiredFieldValidator ID="rfvPostDesc" ValidationGroup="vgHrEdit" ControlToValidate="txtPostDesc" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>--%>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox Width="90px" ID="txtElementCode" CssClass="csstxtbox" runat="server"
                                                            MaxLength="50"></asp:TextBox>
                                                        <%--<asp:RequiredFieldValidator ID="rfvPostNo" ValidationGroup="vgHrFooter" ControlToValidate="txtPostNo" runat="server" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator>--%>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                    <%--adding new field in page as per kamal sir comments by  on 04/11/2014------------------------------------%>

                                    <asp:TemplateField HeaderStyle-Width="100px" FooterStyle-Width="100px" ItemStyle-Width="100px">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvhdrPayrollCode" CssClass="cssLabelHeader" runat="server" Text=" Payroll Code"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvPayrollCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"PayrollCode").ToString() %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox Width="90px" ID="txtEditPayrollCode" CssClass="csstxtbox" runat="server"
                                                            Text='<%# DataBinder.Eval(Container.DataItem, "PayrollCode").ToString()%>' MaxLength="50"></asp:TextBox>
                                                        <%--<asp:RequiredFieldValidator ID="rfvPostDesc" ValidationGroup="vgHrEdit" ControlToValidate="txtPostDesc" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>--%>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox Width="90px" ID="txtPayrollCode" CssClass="csstxtbox" runat="server"
                                                            MaxLength="50"></asp:TextBox>
                                                        <%--<asp:RequiredFieldValidator ID="rfvPostNo" ValidationGroup="vgHrFooter" ControlToValidate="txtPostNo" runat="server" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator>--%>
                                                    </FooterTemplate>
                                                </asp:TemplateField>

                                    <%--Field Add Ends-----------------------------------------------------------------------------------------------%>
                                                <asp:TemplateField HeaderStyle-Width="150px" FooterStyle-Width="150px" ItemStyle-Width="150px">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvhdrOTFactor" CssClass="cssLabelHeader" runat="server" Text="OTFactor(Minutes)"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvOTFactor" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"OTFactor").ToString()%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox Width="50px" ID="txtEditOtFactor" CssClass="csstxtbox" MaxLength="4"
                                                            runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "OTFactor").ToString()%>'></asp:TextBox>
                                                        <asp:RangeValidator ID="rvEditOTFactor" runat="server" Type="Integer" MinimumValue="0"
                                                            MaximumValue="1440" ControlToValidate="txtEditOtFactor" ErrorMessage="*" ValidationGroup="vgHrEdit" />
                                                        <asp:RequiredFieldValidator ID="rfvEditOTFactor" ValidationGroup="vgHrEdit" ControlToValidate="txtEditOtFactor"
                                                            runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox Width="60px" ID="txtOtFactor" CssClass="csstxtbox" runat="server" MaxLength="4"></asp:TextBox>
                                                        <asp:RangeValidator ID="rvOTFactor" runat="server" Type="Integer" MinimumValue="0"
                                                            MaximumValue="1440" ControlToValidate="txtOtFactor" ErrorMessage="*" ValidationGroup="vgHrFooter" />
                                                        <asp:RequiredFieldValidator ID="rfvOTFactor" ValidationGroup="vgHrFooter" ControlToValidate="txtOtFactor"
                                                            runat="server" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="180px" FooterStyle-Width="180px" ItemStyle-Width="180px">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblaction" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, EditColName %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="imgbtnDelete" runat="server" CssClass="cssImgButton" CommandName="Delete"
                                                            ToolTip="<%$ Resources:Resource, Delete %>" ImageUrl="../Images/Delete.gif" Visible="false" />
                                                        <asp:LinkButton Visible="false" runat="server" ID="lnkbtnDelete" CssClass="csslnkButton"
                                                            Text="<%$ Resources:Resource, Delete %>" CommandName="Delete"></asp:LinkButton>
                                                        &nbsp;
                                                        <asp:ImageButton ID="imgbtnEdit" runat="server" CssClass="cssImgButton" CommandName="Edit"
                                                            ToolTip="<%$ Resources:Resource, Edit %>" ImageUrl="../Images/Edit.gif" />
                                                        <asp:LinkButton runat="server" ID="lnkbtnEdit" CssClass="csslnkButton" Text="<%$ Resources:Resource, Edit %>"
                                                            CommandName="Edit" Visible="false"></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:ImageButton ID="imgbtnUpdate" runat="server" CssClass="cssImgButton" CommandName="Update"
                                                            ValidationGroup="vgHrEdit" ToolTip="<%$ Resources:Resource, Update %>" ImageUrl="../Images/Save.gif" />
                                                        <asp:LinkButton runat="server" ID="lnkbtnUpdate" CssClass="csslnkButton" ValidationGroup="vgHrEdit"
                                                            Text="<%$ Resources:Resource, Update %>" CommandName="Update" Visible="false"></asp:LinkButton>
                                                        &nbsp;
                                                        <asp:ImageButton ID="ImgbtnCancel" runat="server" CssClass="cssImgButton" CommandName="Cancel"
                                                            ToolTip="<%$ Resources:Resource, Cancel %>" ImageUrl="../Images/Cancel.gif" />
                                                        <asp:LinkButton runat="server" ID="lnkbtnCancel" CssClass="csslnkButton" Text="<%$ Resources:Resource, Cancel %>"
                                                            CommandName="Cancel" Visible="false"></asp:LinkButton>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:ImageButton ID="imgbtnAdd" runat="server" CssClass="cssImgButton" CommandName="Add"
                                                            ValidationGroup="vgHrFooter" ToolTip="<%$Resources:Resource,Save %>" ImageUrl="../Images/AddNew.gif" />
                                                        <asp:LinkButton Visible="false" runat="server" ID="lnkbtnAdd" CssClass="csslnkButton"
                                                            ValidationGroup="vgHrFooter" Text="<%$ Resources:Resource, AddNew %>" CommandName="Add"></asp:LinkButton>
                                                        &nbsp;
                                                        <%-- <asp:ImageButton ID="ImgbtnReset" runat="server" CssClass="cssImgButton" CommandName="Reset"
                                                            ToolTip="<%$ Resources:Resource, Reset %>" ImageUrl="../Images/Reset.gif" />
                                                        <asp:LinkButton Visible="false" runat="server" ID="lnkbtnReset" CssClass="csslnkButton"
                                                            Text="<%$ Resources:Resource, Reset %>" CommandName="Reset"></asp:LinkButton>--%>
                                                    </FooterTemplate>
                                                    <FooterStyle Width="180px" />
                                                    <HeaderStyle Width="180px" />
                                                    <ItemStyle Width="180px" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Label EnableViewState="false" ID="lblErrorMsg" Text="" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </Ajax:UpdatePanel>
            </td>
        </tr>
    </table>
    <script language="javascript" type="text/javascript">

        window.onbeforeunload = CallParentWindowFunction;
        function CallParentWindowFunction() {

            if (window.opener != null) {
                window.opener.ParentWindowFunction();
            }
        }
    </script>
</asp:Content>
