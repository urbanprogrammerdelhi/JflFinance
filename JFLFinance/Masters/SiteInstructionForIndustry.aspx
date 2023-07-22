<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="SiteInstructionForIndustry.aspx.cs" Inherits="Masters_SiteInstructionForIndustry" Title="<%$ Resources:Resource, AppTitle %>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
        <ContentTemplate>
            <table width="100%" border="0" cellpadding="0" cellspacing="0" >
                <tr style="visibility:hidden;">
                    <td width="140" nowrap="nowrap" align="right">
                        <asp:Label ID="lblIndustryType" Width="140px" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,IndustryType%>"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:HiddenField ID="hfLocationAutoID" runat="server"/>
                        <asp:DropDownList ID="ddlIndustryType" AutoPostBack="true" Width="220" CssClass="cssDropDown"
                            runat="server" OnSelectedIndexChanged="ddlIndustryType_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>                    
            <div class="squareboxgradientcaption" style="height: 20px;">
                <asp:Label ID="lblDivHdr1" runat="server" Text="<%$Resources:Resource,SiteInstructionForIndustry %>"></asp:Label>
            </div>
            <div>
                <asp:GridView Width="100%" ID="gvSiteInstruction" CssClass="GridViewStyle" runat="server"
                    ShowFooter="True" AllowPaging="True" AllowSorting="true" PageSize="6" CellPadding="1"
                    GridLines="None" AutoGenerateColumns="False" OnPageIndexChanging="gvSiteInstruction_PageIndexChanging"
                    OnRowCancelingEdit="gvSiteInstruction_RowCancelingEdit" OnRowCommand="gvSiteInstruction_RowCommand"
                    OnRowDataBound="gvSiteInstruction_RowDataBound" OnRowUpdating="gvSiteInstruction_RowUpdating"
                    DataKeyNames="SiteInstruction" OnRowEditing="gvSiteInstruction_RowEditing" OnSorting="gvSiteInstruction_Sorting" OnRowDeleting="gvSiteInstruction_RowDeleting">
                    <FooterStyle CssClass="GridViewFooterStyle" />
                    <RowStyle CssClass="GridViewRowStyle" />
                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                    <PagerStyle CssClass="GridViewPagerStyle" />
                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                    <Columns>
                        <asp:TemplateField HeaderText="<%$ Resources:Resource,EditColName %>">
                            <EditItemTemplate>
                                <asp:ImageButton ID="ImgbtnUpdate" ToolTip="<%$Resources:Resource,Update %>"
                                    ImageUrl="~/Images/save.gif" CssClass="csslnkButton" runat="server" CommandName="Update"
                                    ValidationGroup="EditSiteInstruction" />
                                &nbsp;
                                <asp:ImageButton ID="ImageButton2Tran" ToolTip="<%$Resources:Resource,Cancel %>"
                                    ImageUrl="~/Images/Cancel.gif" CssClass="csslnkButton" runat="server" CausesValidation="False"
                                    CommandName="Cancel" />
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:ImageButton ID="lbADD" runat="server" ToolTip="<%$Resources:Resource,Save %>"
                                    CssClass="cssImgButton" ValidationGroup="AddNewSiteInstruction" CommandName="AddNew"
                                    ImageUrl="../Images/AddNew.gif" />
                                &nbsp;
                                <asp:ImageButton ID="lbReset" ToolTip="<%$Resources:Resource,Reset %>" runat="server"
                                    CssClass="cssImgButton" CommandName="Reset" ImageUrl="../Images/Reset.gif" />
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:ImageButton ID="IBEdit" ToolTip="<%$Resources:Resource,Edit %>" ImageUrl="~/Images/Edit.gif"
                                    CssClass="csslnkButton" ValidationGroup="EditSiteInstruction" runat="server" CausesValidation="False"
                                    CommandName="Edit" />
                                &nbsp;
                                <asp:ImageButton ID="IBDeleteSiteInstruction"
                                    ToolTip="<%$Resources:Resource,Delete %>" ImageUrl="~/Images/Delete.gif"
                                    runat="server" CssClass="csslnkButton" CausesValidation="False" CommandName="Delete"
                                        />
                            </ItemTemplate>
                            <FooterStyle Width="100px" />
                            <HeaderStyle Width="100px" CssClass="cssLabelHeader" />
                            <ItemStyle Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$ Resources:Resource,SerialNumber %>">
                            <ItemTemplate>
                                <asp:Label ID="lblSerialNo" runat="server"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="50px" />
                            <ItemStyle Width="50px" />
                            <FooterStyle Width="50px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Row ID" Visible="false" >
                            <EditItemTemplate> 
                                <asp:Label ID="lblRowID"  CssClass="cssLabel" runat="server" Text='<%# Bind("RowID") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblRowID" CssClass="cssLabel" runat="server" Text='<%# Bind("RowID") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="600px" />
                            <ItemStyle Width="600px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-Width="200px" FooterStyle-Width="200px"
                            ItemStyle-Width="200px">
                            <HeaderTemplate>
                                <asp:Label ID="lblInstructionType" CssClass="cssLabelHeader" runat="server"
                                    Text="<%$Resources:Resource,InstructionType%>"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblInstructionType" CssClass="cssLable" runat="server" Text='<%# Bind("ItemDesc") %>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList Width="180px" ID="ddlInstructionType" Height="20px" CssClass="csstxtbox" runat="server" />
                                <asp:HiddenField ID="hfInstructionType" runat="server" value='<%# Bind("InstructionTypeID") %>'/>                                                                
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:DropDownList Width="180px" ID="ddlInstructionType" Height="20px" CssClass="csstxtbox" runat="server" />
                            </FooterTemplate>
                        </asp:TemplateField>                                                                                                                 
                        <asp:TemplateField HeaderText="<%$Resources:resource,Instruction %>" SortExpression="SiteInstruction">
                            <EditItemTemplate> 
                                <asp:TextBox ID="txtSiteInstruction" Width="600px" MaxLength="255" CssClass="csstxtbox"  Text='<%# Bind("SiteInstruction") %>'
                                    runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2"  runat="server" ControlToValidate="txtSiteInstruction"
                                    ErrorMessage="" ValidationGroup="EditSiteInstruction" Display="Dynamic" SetFocusOnError="True">*</asp:RequiredFieldValidator>                                                                                                                                        
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblSiteInstruction" CssClass="cssLabel" runat="server" Text='<%# Bind("SiteInstruction") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtNewSiteInstruction" Width="600px" MaxLength="255" CssClass="csstxtbox"
                                    runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1"  runat="server" ControlToValidate="txtNewSiteInstruction"
                                    ErrorMessage="" ValidationGroup="AddNewSiteInstruction" Display="Dynamic" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                            </FooterTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="600px" />
                            <ItemStyle Width="670px" />
                            <FooterStyle Width="670px" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <asp:Label ID="lblError" runat="server" Text="" EnableViewState="false" CssClass="csslblErrMsg"></asp:Label>
            <asp:Label ID="Label1" EnableViewState="false" CssClass="csslblErrMsg" runat="server" Text=""></asp:Label>
            <asp:Label ID="lblErrorMsg" runat="server" EnableViewState="false" CssClass="csslblErrMsg"></asp:Label>
            <asp:HiddenField ID="hfInstructionType" runat="server"/>
            <asp:HiddenField ID="hfMessageDisable" runat="server" Value="<%$Resources:Resource,Disable %>" />
            <asp:HiddenField ID="hfMessageUpdate" runat="server" Value="<%$Resources:Resource,Update %>" />
            <asp:HiddenField ID="hfResult" runat="server" />
        </ContentTemplate>
    </Ajax:UpdatePanel>
</asp:Content>                       