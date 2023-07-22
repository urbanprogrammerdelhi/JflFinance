<%@ Page Title="<%$ Resources:Resource, AppTitle %>" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="QuotationMaster.aspx.cs" Inherits="Sales_QuotationMaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="divHeader" runat="server">
      <table width="50%" border="0" cellspacing="0px" cellpadding="0px" >
        <tr>
            <td style="text-align: right;">
                <asp:Label ID="lblCompanyCode" Width="150px" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,CompanyCode %>"></asp:Label>
            </td>
            <td style="text-align: left;">
                <asp:DropDownList ID="ddlCompanyCode" runat="server" CssClass="cssDropDown" Width="150px"  AutoPostBack="true" OnSelectedIndexChanged="ddlCompanyCode_SelectedIndexChanged"></asp:DropDownList>
            </td>
            <td style="text-align: right;">
                <asp:Label ID="Label2" Width="150px" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,State %>"></asp:Label>
            </td>
            <td style="text-align: left;">
                <asp:DropDownList ID="ddlState" runat="server" CssClass="cssDropDown" Width="150px" AutoPostBack="true" OnSelectedIndexChanged="ddlState_SelectedIndexChanged"></asp:DropDownList>
            </td>
             <asp:HiddenField ID="hfAmendmentNo" runat="server" />
         </tr>
     
           <asp:HiddenField ID="hfMasterAutoId" runat="server" />
    </table>
    <br />
     
         
  
  
      <asp:GridView ID="gvQuotation" Width="100%" CssClass="GridViewStyle"
                                    runat="server" AllowPaging="True" CellPadding="3" GridLines="None" PageSize="10"
                                    AutoGenerateColumns="False" 
                                     ShowFooter="True" OnPageIndexChanging="gvQuotation_PageIndexChanging" OnRowDataBound="gvQuotation_RowDataBound">
                                    <FooterStyle CssClass="GridViewFooterStyle" />
                                    <RowStyle CssClass="GridViewRowStyle" />
                                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                    <PagerStyle CssClass="GridViewPagerStyle" />
                                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                                    <Columns>
                                     <asp:TemplateField HeaderText="S.No.">
                            <ItemTemplate>
                                <asp:Label ID="lblSerialNo" CssClass="cssLabel" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>

                            </ItemTemplate>
                            <ItemStyle Width="50px" />
                            <HeaderStyle Width="50px" />
                            <FooterStyle Width="50px" />
                        </asp:TemplateField>
                                      
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,QuotationNo %>">
                                            <ItemTemplate>
                                           
                                                <asp:HiddenField ID="hfQuotationAutoid" runat="server" Value='<%#Eval("QuotationAutoId") %>' />
                                                <asp:LinkButton ID="lnkQuotationNo" CssClass="cssLabel" runat="server" Text='<%#Eval("QuotationNo") %>' OnClick="lnkQuotationNo_Click"></asp:LinkButton>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="150px" />
                                            <ItemStyle Width="150px" />
                                            <FooterStyle Width="150px" />
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="<%$ Resources:Resource,ClientName %>">
                                            <ItemTemplate>
                                                  <asp:HiddenField ID="hfclientcode" runat="server" Value='<%#Eval("ClientCode") %>' />
                                                <asp:Label ID="lblClientNAme" CssClass="cssLabel" runat="server" Text='<%#Eval("ClientName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="300px" />
                                            <ItemStyle Width="300px" />
                                            <FooterStyle Width="300px" />
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="<%$ Resources:Resource,Status %>">
                                            <ItemTemplate>
                                                 <asp:HiddenField ID="hfstate" runat="server" Value='<%#Eval("StateName") %>' />
                                                <asp:Label ID="lblStatus" CssClass="cssLabel" runat="server" Text='<%#Eval("Status") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="150px" />
                                            <ItemStyle Width="150px" />
                                            <FooterStyle Width="150px" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
        <br />
       <center>      <asp:Button ID="btnAddnew" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource,AddNew %>"  OnClick="btnAddnew_Click"  /></center>
    <br />
        </div>
    <div id="divDesignationHeader" runat="server" visible="false">
        <br />
         <table width="100%" border="0" cellspacing="0px" cellpadding="0px" >
        <tr>
           
                  <td style="text-align: right;">
                <asp:Label ID="Label4" Width="150px" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,QuotationRefNo %>"></asp:Label>
            </td>
            <td style="text-align: left;">
                <asp:HiddenField ID="hfAutoId" runat="server" />
                <asp:TextBox ID="txtQuotationNo" runat="server" CssClass="csstxtboxReadonly" Width="150px" MaxLength="50"  ></asp:TextBox>
                   <asp:RequiredFieldValidator ID="rfvtxtQuotationNo" runat="server" ControlToValidate="txtQuotationNo" SetFocusOnError="true" ForeColor="Red" ErrorMessage="*" ValidationGroup="EditName"></asp:RequiredFieldValidator>
            </td>
              <td style="text-align: right;">
                <asp:Label ID="Label6" Width="150px" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,AmendNo %>"></asp:Label>
            </td>
            <td style="text-align: left;">
               <asp:DropDownList ID="ddlAmendNo" runat="server" CssClass="cssDropDown"  OnSelectedIndexChanged="ddlAmendNo_SelectedIndexChanged" AutoPostBack="true" Width="40px">

                </asp:DropDownList>
                  <asp:TextBox ID="txtAmendDate" runat="server" CssClass="csstxtboxReadonly" Width="80px"   ></asp:TextBox>
               <asp:HyperLink Style="vertical-align: top" ID="HlimgTerminationDate"
                                                                    runat="server" Height="19px" Width="20px" ImageUrl="../Images/pdate.gif"></asp:HyperLink>
            </td>
             <td style="text-align: right;">
                <asp:Label ID="Label5" Width="150px" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,Status %>"></asp:Label>
            </td>
            <td style="text-align: left;">
           
                  <asp:TextBox ID="txtStatus" runat="server" CssClass="csstxtboxReadonly" Width="150px" style="margin-left:5px" ></asp:TextBox>
                
            </td>
          
            
            </tr>
            
             <tr>
                   <td style="text-align: right;">
                <asp:Label ID="Label7" Width="150px" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,CompanyCode %>"></asp:Label>
            </td>
            <td style="text-align: left;">
                <asp:DropDownList ID="ddlCompanyCode1" Width="150px" runat="server" OnSelectedIndexChanged="ddlCompanyCode1_SelectedIndexChanged" AutoPostBack="true" CssClass="cssDropDown"></asp:DropDownList>
                
            </td>
           
             <td style="text-align: right;">
                <asp:Label ID="Label9" Width="150px" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,State %>"></asp:Label>
            </td>
            <td style="text-align: left;">
               <asp:DropDownList ID="ddlstate1" Width="150px" runat="server" OnSelectedIndexChanged="ddlstate1_SelectedIndexChanged" AutoPostBack="true" CssClass="cssDropDown"></asp:DropDownList>
                
            </td>
                  <td style="text-align: right;">
                <asp:Label ID="Label8" Width="150px" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,ClientCode %>"></asp:Label>
            </td>
            <td style="text-align: left;">
                <asp:HiddenField ID="hfmaxAmendNo" runat="server" />
               <asp:DropDownList ID="ddlcustomercode" runat="server" CssClass="cssDropDown" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlcustomercode_SelectedIndexChanged" AutoPostBack="true" >

                    <asp:ListItem Text="--Select--" Value="*"></asp:ListItem>
                </asp:DropDownList>
                
                <asp:TextBox ID="txtClientName" runat="server" CssClass="csstxtboxReadonly" Width="200px"  MaxLength="100"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="rfvtxtClientName" runat="server" ControlToValidate="txtClientName" SetFocusOnError="true" ForeColor="Red" ErrorMessage="*" ValidationGroup="EditName"></asp:RequiredFieldValidator>
         
                
            </td>
             </tr>
            
             </table>
        <br />
         <asp:Button ID="btnSave" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource,Save %>"  OnClick="btnSave_Click" ValidationGroup="EditName" Visible="false"/>
         <asp:Button ID="btnEdit" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource,Edit %>"  OnClick="btnEdit_Click1"/>
           <asp:Button ID="btnAuthorize" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource,Authorize %>"  OnClick="btnAuthorize_Click" Visible="false"  />
           <asp:Button ID="btnAmend" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource,Amend %>"  OnClick="btnAmend_Click" Visible="false" />
          <asp:Button ID="btnUpdate" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource,Update %>" OnClick="btnUpdate_Click" Visible="false" ValidationGroup="EditName" />
          <asp:Button ID="btncancel" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource,cancel %>"  OnClick="btncancel_Click" Visible="false" CausesValidation="false"  />
       <asp:Button ID="btnback" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource,Back %>"   OnClick="btnback_Click"  />

        
        <br />
        <br />
         <Ajax:UpdatePanel runat="server" ID="upError" UpdateMode="Always">
                                <ContentTemplate>
         <asp:Panel ScrollBars="Auto" ID="Panel2" Font-Bold="True" ForeColor="Red" Height="230px" runat="server" >
           
                                <asp:GridView ID="gvQuotationMaster" Width="100%" CssClass="GridViewStyle"
                                    runat="server" AllowPaging="True" CellPadding="3" GridLines="None" PageSize="10"
                                    AutoGenerateColumns="False" OnRowCancelingEdit="gvQuotationMaster_RowCancelingEdit"
                                    OnRowCommand="gvQuotationMaster_RowCommand" OnRowDataBound="gvQuotationMaster_RowDataBound"
                                    OnRowDeleting="gvQuotationMaster_RowDeleting" OnRowEditing="gvQuotationMaster_RowEditing" OnRowUpdating="gvQuotationMaster_RowUpdating"
                                    ShowFooter="True" OnPageIndexChanging="gvQuotationMaster_PageIndexChanging">
                                    <FooterStyle CssClass="GridViewFooterStyle" />
                                    <RowStyle CssClass="GridViewRowStyle" />
                                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                    <PagerStyle CssClass="GridViewPagerStyle" />
                                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,EditColName %>">
                                            <EditItemTemplate>
                                                <asp:ImageButton ID="ImgbtnUpdateAsset" ToolTip="<%$Resources:Resource,Update %>"
                                                    ImageUrl="~/Images/save.gif" CssClass="csslnkButton" runat="server" CommandName="Update" ValidationGroup="Edit"
                                                  />
                                                <asp:ImageButton ID="ImageButton3Asset" ToolTip="<%$Resources:Resource,Cancel %>"
                                                    ImageUrl="~/Images/Cancel.gif" CssClass="csslnkButton" runat="server" CausesValidation="False"
                                                    CommandName="Cancel" />
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="IBEditAsset" ToolTip="<%$Resources:Resource,Edit %>" ImageUrl="~/Images/Edit.gif"
                                                    CssClass="csslnkButton" runat="server" CausesValidation="False" CommandName="Edit" ValidationGroup="Edit" />
                                                <asp:ImageButton ID="IBDeleteAsset" ToolTip="<%$Resources:Resource,Delete %>" ImageUrl="~/Images/Delete.gif"
                                                    runat="server" CssClass="csslnkButton" CausesValidation="False" CommandName="Delete" />
                                                  <asp:ImageButton ID="IBConfig" ToolTip="<%$Resources:Resource,Configuration %>" ImageUrl="~/Images/gear.gif"
                                                    runat="server" CssClass="csslnkButton" CausesValidation="False" CommandName="Config" OnClick="IBConfig_Click" />
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:ImageButton ID="lbADD" runat="server" ToolTip="<%$Resources:Resource,Save %>"
                                                    CssClass="cssImgButton" ValidationGroup="Quotation" CommandName="AddNew" ImageUrl="../Images/AddNew.gif" />
                                                <asp:ImageButton ID="lbReset" ToolTip="<%$Resources:Resource,Reset %>" runat="server"
                                                    CssClass="cssImgButton" CommandName="Reset" CausesValidation="False" ImageUrl="../Images/Reset.gif" />
                                            </FooterTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="150px" />
                                            <ItemStyle Width="150px" />
                                            <FooterStyle Width="150px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,Designation %>">
                                            <EditItemTemplate>
                                                <asp:HiddenField ID="hfQuotationCostingAutoId" runat="server" Value='<%# Eval("QuotationCostingAutoId") %>' />
                                                 <asp:HiddenField ID="hfDesignationCode" runat="server" Value='<%# Eval("DesignationCode") %>' />
                                                <asp:DropDownList ID="ddlDesignation" Width="200px" CssClass="cssDropDown" runat="server"></asp:DropDownList>
                                                  <asp:CheckBox ID="ckhUpdate" Width="100px" CssClass="cssCheckBox" runat="server" Text="<%$ Resources:Resource,Update %>"></asp:CheckBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hfQuotationCostingAutoId" runat="server" Value='<%# Eval("QuotationCostingAutoId") %>' />
                                                  <asp:HiddenField ID="hfDesignationCode" runat="server" Value='<%# Eval("DesignationCode") %>' />
                                                <asp:LinkButton ID="lblDesignation" Width="200px" CssClass="cssLabel" runat="server" Text='<%# Eval("DesignationDesc") %>' ></asp:LinkButton>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:DropDownList ID="ddlDesignation" Width="200px" CssClass="cssDropDown" runat="server" OnSelectedIndexChanged="ddlDesignation_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                            </FooterTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="250px" />
                                            <ItemStyle Width="250px" />
                                            <FooterStyle Width="250px" />
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="<%$ Resources:Resource,Grade %>">
                                            <EditItemTemplate>
                                               <asp:HiddenField ID="hfGradeCode" runat="server" Value='<%# Eval("GradeCode") %>' />
                                                 <asp:DropDownList ID="ddlGrade" Width="200px" CssClass="cssDropDown" runat="server"></asp:DropDownList>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hfGradeCode" runat="server" Value='<%# Eval("GradeCode") %>' />
                                                <asp:Label ID="lblGrade" Width="200px" CssClass="cssLabel" runat="server" Text='<%# Eval("GradeDesc") %>' ></asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:DropDownList ID="ddlGrade" Width="200px" CssClass="cssDropDown" runat="server" ></asp:DropDownList>
                                            </FooterTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                                            <ItemStyle Width="200px" />
                                            <FooterStyle Width="200px" />
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="<%$ Resources:Resource,Priceperheadpermonth %>">
                                            <ItemTemplate>
                                             
                                                <asp:Label ID="lblPerheadprice" Width="200px" CssClass="cssLabel" runat="server" Text='<%# Eval("Costperhead") %>' ></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="150px" />
                                            <ItemStyle Width="150px" />
                                            <FooterStyle Width="150px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,NumberOfEmployees %>">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtNumberOfEmployees" CssClass="csstxtbox" Width="90px" runat="server"  MaxLength="5"  Text='<%# Eval("NoOfEmployee") %>' ValidationGroup="Edit"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtNumberOfEmployees" runat="server" ControlToValidate="txtNumberOfEmployees" SetFocusOnError="true" ForeColor="Red" ErrorMessage="*" ValidationGroup="Edit"></asp:RequiredFieldValidator>
                                                  </EditItemTemplate>
                                            <FooterTemplate>
                                            <asp:TextBox ID="txtNumberOfEmployees" CssClass="csstxtbox" Width="90px" runat="server" MaxLength="5"  ></asp:TextBox>
                                                  <asp:RequiredFieldValidator ID="rfvtxtNumberOfEmployees1" runat="server" ControlToValidate="txtNumberOfEmployees" SetFocusOnError="true" ForeColor="Red" ErrorMessage="*" ValidationGroup="Quotation"></asp:RequiredFieldValidator>
                                              </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbltxtNumberOfEmployees" CssClass="cssLabel" runat="server" Text='<%#Eval("NoOfEmployee") %>' ></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="150px" />
                                            <ItemStyle Width="150px" />
                                            <FooterStyle Width="150px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,Discount %>">
                                             <EditItemTemplate>
                                              
                                                <asp:TextBox ID="txtDiscount" CssClass="csstxtbox" Width="90px" runat="server"  MaxLength="15"   Text='<%# Eval("Discount") %>'></asp:TextBox>
                                                     </EditItemTemplate>
                                            <FooterTemplate>
                                            <asp:TextBox ID="txtDiscount" CssClass="csstxtbox" Width="90px" runat="server"  MaxLength="15"  ></asp:TextBox>
                                                    </FooterTemplate>
                                            <ItemTemplate>
                                               
                                                <asp:Label ID="lblDiscount" CssClass="cssLabel" runat="server" Text='<%#Eval("Discount") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                                            <ItemStyle Width="100px" />
                                            <FooterStyle Width="100px" />
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="<%$ Resources:Resource,NetPrice %>">
                                            <ItemTemplate>
                                              
                                                <asp:Label ID="lblNetPrice" Width="200px" CssClass="cssLabel" runat="server" Text='<%# Eval("NetCost") %>' ></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="150px" />
                                            <ItemStyle Width="150px" />
                                            <FooterStyle Width="150px" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <asp:Label EnableViewState="False" ID="LabelGurantee" runat="server" CssClass="csslblErrMsg"></asp:Label>
            
                            </asp:Panel>
       </ContentTemplate></Ajax:UpdatePanel>
          

   <br />
          <asp:HiddenField ID="hfAmendNo" runat="server" />
      
  
        </div>
       <asp:Label ID="lblMsg" runat="server" Style="color: red"></asp:Label>
   
     <br />
  
     <script type="text/javascript" language="javascript">

         function OpenCosting(CompanyCode, Designation, State, QuotationNo, CustomerName,GradeCode) {
             window.showModalDialog('../Sales/QuotationHeadDetail.aspx?CompanyCode=' + CompanyCode + '&Designation=' + Designation + '&State=' + State + '&QuotationNo=' + QuotationNo + '&CustomerName=' + CustomerName + '&GradeCode=' + GradeCode, null, 'status:off;center:yes;scroll:no;dialogWidth:600px;dialogheight:800px;help:no;');
           
         }
       
</script>
</asp:Content>

