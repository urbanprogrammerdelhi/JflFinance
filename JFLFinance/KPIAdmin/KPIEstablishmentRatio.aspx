<%@ Page Language="C#"  MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="KPIEstablishmentRatio.aspx.cs" Inherits="KPIAdmin_KPIEstablishmentRatio" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

   <div class="squareboxcontent">
                                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                   
                                                  <%-- OnPageIndexChanging="KPIEstablishment_PageIndexChanging" OnRowCommand="KPIEstablishment_RowCommand"
                                                        OnRowDataBound="KPIEstablishment_RowDataBound" OnRowDeleting="KPIEstablishment_RowDeleting"
                                                        OnRowEditing="KPIEstablishment_RowEditing" OnRowCancelingEdit="KPIEstablishment_RowCancelingEdit"
                                                        OnRowUpdating="KPIEstablishment_RowUpdating"--%>
                                                    
                                                    <asp:GridView Width="100%" ID="KPIEstablishment" AllowPaging="True" PageSize="12" CssClass="GridViewStyle"
                                                        runat="server" CellPadding="1" GridLines="None" AutoGenerateColumns="False" ShowFooter="True"
                                                        OnPageIndexChanging="KPIEstablishment_PageIndexChanging" OnRowCommand="KPIEstablishment_RowCommand"
                                                        OnRowEditing="KPIEstablishment_RowEditing" OnRowCancelingEdit="KPIEstablishment_RowCancelingEdit" OnRowDeleting="KPIEstablishment_RowDeleting"
                                                        OnRowUpdating="KPIEstablishment_RowUpdating"  >
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
                                                                        CssClass="cssImgButton" ValidationGroup="AddNewAreaInch" CommandName="AddNew"
                                                                        ImageUrl="../Images/AddNew.gif" />
                                                                    &nbsp;
                                                                    <asp:ImageButton ID="lbReset" ToolTip="<%$Resources:Resource,Reset %>" runat="server"
                                                                        CssClass="cssImgButton" CommandName="Reset" ImageUrl="../Images/Reset.gif" />
                                                                </FooterTemplate>
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="IBEdit" ToolTip="<%$Resources:Resource, Edit %>"
                                                                        ImageUrl="~/Images/Edit.gif" runat="server" CssClass="csslnkButton" CausesValidation="False"
                                                                        CommandName="Edit" />
                                                                    <asp:ImageButton ID="IBDeleteAreaIncharge" ToolTip="<%$Resources:Resource,Delete %>"
                                                                        ImageUrl="~/Images/Delete.gif" runat="server" CssClass="csslnkButton" CausesValidation="False"
                                                                        CommandName="Delete" />
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
                                                          
                                                          
                                                            <asp:TemplateField HeaderText="<%$ Resources:Resource,Branch %>">
                                                                
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblbranch" CssClass="cssLable" runat="server" Text='<%# Bind("LocationDesc") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:Label ID="lblbranch" CssClass="cssLable" runat="server" Text='<%# Bind("LocationDesc") %>'></asp:Label>
                                                                </EditItemTemplate>
                                                                <FooterStyle Width="200px" />
                                                                <ItemStyle Width="200px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="<%$ Resources:Resource,TotalEstablishment %>">
                                                                <FooterTemplate>
                                                                    <asp:TextBox ID="txtTotalEstablishment" MaxLength="6" CssClass="csstxtbox" runat="server"
                                                                        Width="60px" Text=""></asp:TextBox>
                                                                        <AjaxToolKit:FilteredTextBoxExtender ID="ajkTotalEstablishment" runat="server" FilterType="Numbers"
                                                                         TargetControlID="txtTotalEstablishment" />
                                                                            <asp:RequiredFieldValidator ID="reqTotalEstablishment"  Display="Dynamic"
                                                                        ErrorMessage="*" runat="server" ValidationGroup="AddNewAreaInch" ForeColor="Red" ControlToValidate="txtTotalEstablishment"></asp:RequiredFieldValidator>
                                                           </FooterTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblTotalEstablishment" CssClass="cssLable" runat="server" Text='<%# Bind("TotalEstablishment") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                 <%--   <asp:Label ID="lblTotalEstablishment" CssClass="cssLable" runat="server" Text='<%# Bind("TotalEstablishment") %>'></asp:Label>--%>
                                                                   <asp:TextBox Width="80px" ID="txtTotalEstablishment" CssClass="csstxtbox" runat="server" MaxLength="6"
                                                                        Text='<%# DataBinder.Eval(Container.DataItem, "TotalEstablishment").ToString()%>'></asp:TextBox>
                                                                        <AjaxToolKit:FilteredTextBoxExtender ID="ajkTotalEstablishment" runat="server" FilterType="Numbers"
                                                                         TargetControlID="txtTotalEstablishment" />

                                                                          <asp:RequiredFieldValidator ID="reqTotalEstablishment"  Display="Dynamic"
                                                                        ErrorMessage="*" runat="server" ValidationGroup="AddNewAreaInch" ForeColor="Red" ControlToValidate="txtTotalEstablishment"></asp:RequiredFieldValidator>
                                                                </EditItemTemplate>
                                                                <FooterStyle Width="120px" />
                                                                <ItemStyle Width="120px" />
                                                                <HeaderStyle Width="120px" Wrap="False" />
                                                            </asp:TemplateField>
                                                         
                                                            <asp:TemplateField HeaderText="<%$ Resources:Resource,EffectiveFrom %>">
                                                                <FooterTemplate>
                                                                    <asp:TextBox Width="80px" ID="txtEffectiveFrom" CssClass="csstxtbox" runat="server" 
                                                                        Text="" ></asp:TextBox>
                                                                  <AjaxToolKit:CalendarExtender ID="CalendarExtender" Format="-yyyy" runat="server"
                                                                        TargetControlID="txtEffectiveFrom" PopupPosition="TopLeft" />
                                                                    <asp:RequiredFieldValidator ID="reqEffectiveFrom"  Display="Dynamic"
                                                                        ErrorMessage="*" runat="server" ValidationGroup="AddNewAreaInch" ForeColor="Red" ControlToValidate="txtEffectiveFrom"></asp:RequiredFieldValidator>
                                                                   
                                                                </FooterTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblEffectiveFrom" Width="90px" CssClass="cssLable" runat="server"
                                                                        Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("FromDate")) %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>

                                                                  <asp:Label ID="lblEffectiveFrom" Width="90px" CssClass="cssLable" runat="server"
                                                                        Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("FromDate")) %>'></asp:Label>
                                                                </EditItemTemplate>
                                                                <FooterStyle Width="100px" />
                                                                <ItemStyle Width="100px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="<%$ Resources:Resource,EffectiveTo %>">
                                                              
                                                                <ItemTemplate>
                                                                   
                                                                    <asp:Label ID="lblEffectiveTo" CssClass="cssLable" Width="90px" runat="server" Text='<%#String.Format("{0:dd-MMM-yyyy}",Eval("Todate")) %> '></asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:Label ID="lblEffectiveTo" CssClass="cssLable" Width="90px" runat="server" Text='<%#String.Format("{0:dd-MMM-yyyy}",Eval("Todate")) %> '></asp:Label>
                                                                </EditItemTemplate>
                                                                <FooterStyle Width="100px" />
                                                                <ItemStyle Width="100px" />
                                                            </asp:TemplateField>
                                                        
                                                        </Columns>
                                                    </asp:GridView>
                                                    <%--/asp:Panel>--%>
                                                </td>
                                            </tr>
                                            <tr>
                                            <td>
                                             <asp:Label ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg" EnableViewState="False"></asp:Label>
                                            <br />
                                            
                                            </td>
                                            </tr>
                                        </table>
                                        <%-- </div>
                            </div>--%>
                                    </div>



</asp:Content>

