<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="AreaMaster.aspx.cs" Inherits="Sales_AreaMaster" Title="<%$ Resources:Resource, AppTitle %>" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<script type="text/javascript" language="javascript">
    function OpenSearch(obj) {

        var FrmChild = window.showModalDialog('../Search/SearchEmployeeNumber.aspx', null, 'status:off;center:yes;scroll:no;dialogWidth:860px;help:no;');
        if (FrmChild != null) {
            document.getElementById(obj).value = FrmChild;
        }
        else {
            return false;
        }
    }
</script>
<Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
    <ContentTemplate>
        <div class="squareboxgradientcaption" style="height: 25px;">
            <asp:Label ID="Label2" runat="server" Text="<%$Resources:Resource,AreaMasterDetail %>"></asp:Label>
        </div>
        <div>
            <asp:GridView ID="gvAreaMaster" Width="100%" AllowPaging="True" PageSize="15" CssClass="GridViewStyle"
                runat="server" CellPadding="1" GridLines="None" AutoGenerateColumns="False" ShowFooter="True"
                OnRowCancelingEdit="gvAreaMaster_RowCancelingEdit" OnRowCommand="gvAreaMaster_RowCommand"
                OnRowDataBound="gvAreaMaster_RowDataBound" OnRowDeleting="gvAreaMaster_RowDeleting"
                OnRowEditing="gvAreaMaster_RowEditing" OnRowUpdating="gvAreaMaster_RowUpdating"
                DataKeyNames="AreaID" OnPageIndexChanging="gvAreaMaster_PageIndexChanging">
                <FooterStyle CssClass="GridViewFooterStyle" />
                <RowStyle CssClass="GridViewRowStyle" />
                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                <PagerStyle CssClass="GridViewPagerStyle" />
                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                <HeaderStyle CssClass="GridViewHeaderStyle" />
                <Columns>
                    <asp:TemplateField HeaderText="<%$ Resources:Resource,EditColName %>">
                        <EditItemTemplate>
                            <asp:ImageButton ID="ImgbtnUpdateAreaMaster" ToolTip="<%$Resources:Resource,Update %>"
                                ImageUrl="~/Images/save.gif" CssClass="csslnkButton" runat="server" CommandName="Update"
                                ValidationGroup="Edit" />
                            &nbsp;
                            <asp:ImageButton ID="ImgbtnCancelAreaMaster" ToolTip="<%$Resources:Resource,Cancel %>"
                                ImageUrl="~/Images/Cancel.gif" CssClass="csslnkButton" runat="server" CausesValidation="False"
                                CommandName="Cancel" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:ImageButton ID="lbADD" runat="server" ToolTip="<%$Resources:Resource,Save %>"
                                CssClass="cssImgButton" ValidationGroup="AddNew" CommandName="AddNew" ImageUrl="../Images/AddNew.gif" />
                            &nbsp;
                            <asp:ImageButton ID="lbReset" ToolTip="<%$Resources:Resource,Reset %>" runat="server"
                                CssClass="cssImgButton" CommandName="Reset" ImageUrl="../Images/Reset.gif" />
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:ImageButton ID="IBEditAreaMaster" ToolTip="<%$Resources:Resource,Edit %>" ImageUrl="~/Images/Edit.gif"
                                CssClass="csslnkButton" ValidationGroup="Edit" runat="server" CausesValidation="False"
                                CommandName="Edit" />
                            &nbsp;
                            <asp:ImageButton ID="IBDeleteAreaMaster" ToolTip="<%$Resources:Resource,Delete %>"
                                ImageUrl="~/Images/Delete.gif" runat="server" CssClass="csslnkButton" CausesValidation="False"
                                CommandName="Delete" />
                        </ItemTemplate>
                        <FooterStyle Width="80px" />
                        <HeaderStyle Width="80px" CssClass="cssLabelHeader" />
                        <ItemStyle Width="80px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:Resource,SerialNumber %>">
                        <ItemTemplate>
                            <asp:Label ID="lblSerialNo" runat="server"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="50px" />
                        <HeaderStyle Width="50px" />
                        <FooterStyle Width="50px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:Resource,AreaID %>">
                        <FooterTemplate>
                            <asp:TextBox ID="txtNewAreaID" CssClass="csstxtbox" Width="85%" ValidationGroup="AddNew"
                                MaxLength="16" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage=""
                                Text="*" Display="Dynamic" ControlToValidate="txtNewAreaID" ValidationGroup="AddNew"></asp:RequiredFieldValidator>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="lblAreaID" CssClass="cssLable" runat="server" Text='<%# Bind("AreaID") %>'
                                OnClick="lblAreaID_Click"></asp:LinkButton>
                        </ItemTemplate>
                        <HeaderStyle Width="200px" />
                        <FooterStyle Width="200px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:Resource,AreaDesc %>">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtAreaDesc" MaxLength="100" CssClass="csstxtbox" runat="server"
                                Text='<%# Bind("AreaDesc") %>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage=""
                                Text="*" Display="Dynamic" ControlToValidate="txtAreaDesc" ValidationGroup="Edit"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" CssClass="cssLable" runat="server" Text='<%# Bind("AreaDesc") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtNewAreaDesc" CssClass="csstxtbox" Width="85%" ValidationGroup="AddNew"
                                MaxLength="100" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage=""
                                Text="*" Display="Dynamic" ControlToValidate="txtNewAreaDesc" ValidationGroup="AddNew"></asp:RequiredFieldValidator>
                        </FooterTemplate>
                        <%-- <HeaderStyle Width="200px" />
                <FooterStyle Width="200px" />--%>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <asp:Label ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg" EnableViewState="False"></asp:Label>
        <br />
        <asp:Panel ID="PanelAreaInch" runat="server" Visible="false">
            <div class="squareboxgradientcaption" style="height: 25px;">
                <asp:Label ID="Label1" runat="server" Text="<%$Resources:Resource,AreaInchargeDetail %>"></asp:Label>
            </div>
            <div>
                <asp:GridView ID="gvAreaIncharge" Width="100%" AllowPaging="True" PageSize="5" CssClass="GridViewStyle"
                    runat="server" CellPadding="1" GridLines="None" AutoGenerateColumns="False" ShowFooter="True"
                    OnPageIndexChanging="gvAreaIncharge_PageIndexChanging" OnRowCommand="gvAreaIncharge_RowCommand"
                    OnRowDataBound="gvAreaIncharge_RowDataBound" OnRowDeleting="gvAreaIncharge_RowDeleting"
                    OnRowEditing="gvAreaIncharge_RowEditing" OnRowCancelingEdit="gvAreaIncharge_RowCancelingEdit"
                    OnRowUpdating="gvAreaIncharge_RowUpdating">
                    <FooterStyle CssClass="GridViewFooterStyle" />
                    <RowStyle CssClass="GridViewRowStyle" />
                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                    <PagerStyle CssClass="GridViewPagerStyle" />
                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                    <Columns>
                        <asp:TemplateField HeaderText="<%$ Resources:Resource,EditColName %>">
                            <FooterTemplate>
                                <asp:ImageButton ID="lbADD" runat="server" ToolTip="<%$Resources:Resource,Save %>"
                                    CssClass="cssImgButton" ValidationGroup="AddNewAreaInch" CommandName="AddNewAreaInch"
                                    ImageUrl="../Images/AddNew.gif" />
                                &nbsp;
                                <asp:ImageButton ID="lbReset" ToolTip="<%$Resources:Resource,Reset %>" runat="server"
                                    CssClass="cssImgButton" CommandName="Reset" ImageUrl="../Images/Reset.gif" />
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:ImageButton ID="IBEditAreaIncharge" ToolTip="<%$Resources:Resource, Edit %>"
                                    ImageUrl="~/Images/Edit.gif" runat="server" CssClass="csslnkButton" CausesValidation="False"
                                    CommandName="Edit" />
                                <%--<asp:ImageButton ID="IBDeleteAreaIncharge" ToolTip="<%$Resources:Resource,Delete %>"
                                    ImageUrl="~/Images/Delete.gif" runat="server" CssClass="csslnkButton" CausesValidation="False"
                                    CommandName="Delete" />--%>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:ImageButton ID="ImgbtnUpdate" runat="server" CssClass="cssImgButton" ValidationGroup="update"
                                    CausesValidation="True" CommandName="Update" ToolTip="<%$ Resources:Resource, Update %>"
                                    ImageUrl="../Images/Save.gif" />
                                <asp:ImageButton ID="ImgbtnCancel" runat="server" CssClass="cssImgButton" CausesValidation="False"
                                    CommandName="Cancel" ToolTip="<%$ Resources:Resource, Cancel %>" ImageUrl="../Images/Cancel.gif" />
                            </EditItemTemplate>
                            <FooterStyle Width="80px" />
                            <HeaderStyle Width="80px" CssClass="cssLabelHeader" />
                            <ItemStyle Width="80px" VerticalAlign="Middle" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$ Resources:Resource,SerialNumber %>">
                            <ItemTemplate>
                                <asp:Label ID="lblSerialNo" CssClass="cssLabel" runat="server"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle Width="50px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$ Resources:Resource,AreaID %>">
                            <ItemTemplate>
                                <asp:Label ID="lblAreaID" CssClass="cssLabel" runat="server" Text='<%# Bind("AreaID") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Label ID="lblAreaID" CssClass="cssLabel" runat="server" Text='<%# Bind("AreaID") %>'></asp:Label>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lblNewAreaID" runat="server" Text=""></asp:Label>
                                <%-- <asp:DropDownList ID="ddlNewAreaID" Width="100px" CssClass="cssDropDown" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlNewAreaID_SelectedIndexChanged">
                                        </asp:DropDownList>--%>
                            </FooterTemplate>
                            <FooterStyle Width="100px" />
                            <ItemStyle Width="100px" />
                            <HeaderStyle Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$ Resources:Resource,AreaDesc %>">
                            <FooterTemplate>
                                <asp:Label ID="lblNewAreaDesc" Font-Bold="true" CssClass="cssLabel" runat="server"
                                    Text=""></asp:Label>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblAreaDesc" CssClass="cssLable" runat="server" Text='<%# Bind("AreaDesc") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Label ID="lblAreaDesc" CssClass="cssLable" runat="server" Text='<%# Bind("AreaDesc") %>'></asp:Label>
                            </EditItemTemplate>
                            <FooterStyle Width="200px" />
                            <ItemStyle Width="200px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$ Resources:Resource,EmployeeNumber %>">
                            <FooterTemplate>
                                <asp:TextBox ID="txtNewEmployeeNumber" MaxLength="16" CssClass="csstxtbox" runat="server"
                                    Width="60px" Text="" OnTextChanged="txtNewEmployeeNumber_TextChanged"></asp:TextBox>
                                <asp:ImageButton ID="imgSearch" AlternateText="<%$ Resources:Resource,SearchEmployee %>"
                                    runat="server" ImageUrl="~/Images/icosearch.gif" ToolTip="" Width="15px" />
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblEmployeeNumber" CssClass="cssLable" runat="server" Text='<%# Bind("AreaIncharge") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Label ID="lblEmployeeNumber" CssClass="cssLable" runat="server" Text='<%# Bind("AreaIncharge") %>'></asp:Label>
                            </EditItemTemplate>
                            <FooterStyle Width="120px" />
                            <ItemStyle Width="120px" />
                            <HeaderStyle Width="120px" Wrap="False" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$ Resources:Resource,EmployeeName %>">
                            <FooterTemplate>
                                <asp:Label ID="lblNewEmployeeName" Font-Bold="true" CssClass="cssLabel" runat="server"
                                    Text=""></asp:Label>
                                <asp:HiddenField ID="hdEmpDOJ" runat="server" />        <%--Added by  on 6-Jun-2013--%>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label3" CssClass="cssLabel" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Label ID="Label3" CssClass="cssLabel" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                            </EditItemTemplate>
                            <FooterStyle Width="250px" />
                            <ItemStyle Width="250px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$ Resources:Resource,EffectiveFrom %>">
                            <FooterTemplate>
                                <asp:TextBox Width="80px" ID="txtEffectiveFrom" CssClass="csstxtbox" runat="server"
                                    Text=""></asp:TextBox>
                                <AjaxToolKit:CalendarExtender ID="CalendarExtender2" Format="dd-MMM-yyyy" runat="server"
                                    TargetControlID="txtEffectiveFrom" PopupPosition="TopLeft" />
                                <asp:RequiredFieldValidator ID="reqEffectiveFrom" SetFocusOnError="true" Display="Dynamic"
                                    ErrorMessage="*" runat="server" ValidationGroup="AddNewAreaInch" ControlToValidate="txtEffectiveFrom"></asp:RequiredFieldValidator>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblEffectiveFrom" Width="90px" CssClass="cssLable" runat="server"
                                    Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("EffectiveFrom")) %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>

                            <%--    <asp:Label ID="lblEffectiveFrom" Width="90px" CssClass="cssLable" runat="server"
                                    Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("EffectiveFrom")) %>'></asp:Label>--%>
                                                                    
                                <asp:TextBox Width="80px" ID="txtEffectiveFrom" CssClass="csstxtbox" runat="server"
                                    Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("EffectiveFrom")) %>'></asp:TextBox>
                                <AjaxToolKit:CalendarExtender ID="CalendarExtender3" Format="dd-MMM-yyyy" runat="server"
                                    TargetControlID="txtEffectiveFrom" PopupPosition="TopLeft" />
                                <asp:RequiredFieldValidator ID="reqEffectiveFrom" SetFocusOnError="true" Display="Dynamic"
                                    ErrorMessage="*" runat="server" ValidationGroup="AddNewAreaInch" ControlToValidate="txtEffectiveFrom"></asp:RequiredFieldValidator>


                            </EditItemTemplate>
                            <FooterStyle Width="100px" />
                            <ItemStyle Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$ Resources:Resource,EffectiveTo %>">
                            <FooterTemplate>
                                <asp:Label ID="lblNewEffectiveTo" Font-Bold="true" CssClass="cssLabel" runat="server"
                                    Text=""></asp:Label>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:HiddenField ID="hfAreaInchargeAutoID" runat="server" Value='<%# Bind("AreaInchargeAutoID") %>' />
                                <asp:Label ID="lblEffectiveTo" CssClass="cssLable" Width="90px" runat="server" Text='<%#String.Format("{0:dd-MMM-yyyy}",Eval("EffectiveTo")) %> '></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:HiddenField ID="hfAreaInchargeAutoID" runat="server" Value='<%# Bind("AreaInchargeAutoID") %>' />
                                <asp:TextBox Width="80px" ID="txtEffectiveTo" ValidationGroup="update" CssClass="csstxtbox"
                                    runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("EffectiveTo")) %>'></asp:TextBox>
                                <AjaxToolKit:CalendarExtender ID="CalendarExtender2" PopupPosition="Left" Format="dd-MMM-yyyy"
                                    runat="server" TargetControlID="txtEffectiveTo" />
<%--                                                                    <asp:RequiredFieldValidator ID="reqEffectiveTo" ValidationGroup="update" SetFocusOnError="true"
                                    Display="Dynamic" ErrorMessage="*" runat="server" ControlToValidate="txtEffectiveTo"></asp:RequiredFieldValidator>
--%>                                                                </EditItemTemplate>
                            <FooterStyle Width="100px" />
                            <ItemStyle Width="100px" />
                        </asp:TemplateField>
                        <%-- <asp:TemplateField HeaderText="<%$ Resources:Resource,AreaIncharge %>">
                            <FooterTemplate>
                                <asp:Label ID="lblNewFutureIncharge" Font-Bold="true" CssClass="cssLabel" runat="server"
                                    Text=""></asp:Label>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblFutureIncharge" CssClass="cssLable" Width="90px" runat="server"></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtNewAreaIncharge" MaxLength="16" CssClass="csstxtbox" runat="server"
                                    Width="80px" Text="" OnTextChanged="txtNewAreaIncharge_TextChanged" AutoPostBack="true"></asp:TextBox>
                                <asp:ImageButton ID="imgAISearch" AlternateText="<%$ Resources:Resource,SearchEmployee %>"
                                    runat="server" ImageUrl="~/Images/icosearch.gif" ToolTip="" />
                            </EditItemTemplate>
                            <FooterStyle Width="100px" />
                            <ItemStyle Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$ Resources:Resource,EmployeeName %>">
                            <FooterTemplate>
                                <asp:Label ID="lblNewFutureInchargeName" Font-Bold="true" CssClass="cssLabel" runat="server"
                                    Text=""></asp:Label>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblFutureInchargeName" CssClass="cssLabel" runat="server" Text=""></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Label ID="lblNewAreaInchargeName" CssClass="cssLabel" runat="server" Text=""></asp:Label>
                            </EditItemTemplate>
                            <FooterStyle Width="250px" />
                            <ItemStyle Width="250px" />
                        </asp:TemplateField>--%>
                    </Columns>
                </asp:GridView>
            </div>
        </asp:Panel>
        <asp:Button ID="btnPostBack" BackColor="white" BorderWidth="0" runat="server" OnClick="btnPostBack_Click" />
        <asp:HiddenField ID="hfAreaID" runat="server" />
    </ContentTemplate>
</Ajax:UpdatePanel>
</asp:Content>
