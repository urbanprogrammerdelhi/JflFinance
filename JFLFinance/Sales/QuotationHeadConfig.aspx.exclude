<%@ Page Title="<%$ Resources:Resource, AppTitle %>" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="QuotationHeadConfig.aspx.cs" Inherits="Sales_QuotationHeadConfig" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     
    <table width="50%" border="0" cellspacing="0px" cellpadding="0px" >
        <tr>
            <td style="text-align: right;">
                <asp:Label ID="lblCompanyCode" Width="150px" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,CompanyCode %>"></asp:Label>
            </td>
            <td style="text-align: left;">
                <asp:DropDownList ID="ddlCompanyCode" runat="server" CssClass="cssDropDown" Width="150px" OnSelectedIndexChanged="ddlCompanyCode_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
            </td>
            <td style="text-align: right;">
                <asp:Label ID="Label1" Width="150px" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,DesignationCode %>"></asp:Label>
            </td>
            <td style="text-align: left;">
                <asp:DropDownList ID="ddlDesignation" runat="server" CssClass="cssDropDown" Width="150px" OnSelectedIndexChanged="ddlDesignation_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
            </td>

        </tr>
        <tr>
               <td style="text-align: right;">
                <asp:Label ID="Label11" Width="150px" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,GradeCode %>"></asp:Label>
            </td>
            <td style="text-align: left;">
                <asp:DropDownList ID="ddlGrade" runat="server" CssClass="cssDropDown" Width="150px" OnSelectedIndexChanged="ddlGrade_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
            </td>
            <td style="text-align: right;">
                <asp:Label ID="Label2" Width="150px" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,State %>"></asp:Label>
            </td>
            <td style="text-align: left;">
                <asp:DropDownList ID="ddlState" runat="server" CssClass="cssDropDown" Width="150px" OnSelectedIndexChanged="ddlState_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
            </td>
            

        </tr>
        <tr>
            <td style="text-align: right;">
                <asp:Label ID="Label12" Width="150px" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,FromDay %>"></asp:Label>
            </td>
            <td style="text-align: left;">
                <asp:DropDownList ID="ddlfromday" runat="server" CssClass="cssDropDown" Width="150px" >
                    <asp:ListItem Text="Monday" Value="Monday"></asp:ListItem>
                       <asp:ListItem Text="Tuesday" Value="Tuesday"></asp:ListItem>
                       <asp:ListItem Text="Wednesday" Value="Wednesday"></asp:ListItem>
                       <asp:ListItem Text="Thrusday" Value="Thrusday"></asp:ListItem>
                       <asp:ListItem Text="Friday" Value="Friday"></asp:ListItem>
                       <asp:ListItem Text="Saturday" Value="Saturday"></asp:ListItem>
                       <asp:ListItem Text="Sunday" Value="Sunday"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="text-align: right;">
                <asp:Label ID="Label13" Width="150px" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,ToDay %>"></asp:Label>
            </td>
            <td style="text-align: left;">
               <asp:DropDownList ID="ddlToday" runat="server" CssClass="cssDropDown" Width="150px">
                      <asp:ListItem Text="Monday" Value="Monday"></asp:ListItem>
                       <asp:ListItem Text="Tuesday" Value="Tuesday" ></asp:ListItem>
                       <asp:ListItem Text="Wednesday" Value="Wednesday"></asp:ListItem>
                       <asp:ListItem Text="Thrusday" Value="Thrusday"></asp:ListItem>
                       <asp:ListItem Text="Friday" Value="Friday"></asp:ListItem>
                       <asp:ListItem Text="Saturday" Value="Saturday"></asp:ListItem>
                       <asp:ListItem Text="Sunday" Value="Sunday" Selected="True"></asp:ListItem>
                </asp:DropDownList>      </td>

        </tr>
        </table>
    <asp:Panel ID="Panel1" Font-Bold="True" ForeColor="Red" GroupingText="<%$ Resources:Resource,HeadCodeDesc %>"  runat="server">
       <table width="50%" border="0" cellspacing="0px" cellpadding="0px" >
        <tr>
            <td style="text-align: right;">
                <asp:Label ID="Label14" Width="150px" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,Sequence %>"></asp:Label>
            </td>
            <td style="text-align: left;">
                <asp:TextBox ID="txtSequenceNo" runat="server" CssClass="csstxtbox" Width="150px" MaxLength="6" ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvtxtSequenceNo" Font-Bold="true" ValidationGroup="HeadConfig" ControlToValidate="txtSequenceNo" Display="Dynamic" runat="server" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>

            </td>
            <td style="text-align: right;">
                <asp:Label ID="Label3" Width="150px" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,FormatCode %>"></asp:Label>
            </td>
            <td style="text-align: left;">
                <asp:TextBox ID="txtFormatCode" runat="server" CssClass="csstxtbox" Width="150px" MaxLength="50"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvtxtFormatCode" Font-Bold="true" ValidationGroup="HeadConfig" ControlToValidate="txtFormatCode" Display="Dynamic" runat="server" Text="*" ForeColor="Red" ></asp:RequiredFieldValidator>
            </td>
           
        </tr>
        <tr>
             <td style="text-align: right;">
                <asp:Label ID="Label4" Width="150px" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,HeadCode %>"></asp:Label>
            </td>
            <td style="text-align: left;">
                <asp:TextBox ID="txtHeadcode" runat="server" CssClass="csstxtbox" Width="150px" MaxLength="50"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvtxtHeadcode" Font-Bold="true" ValidationGroup="HeadConfig" ControlToValidate="txtHeadcode" Display="Dynamic" runat="server" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td style="text-align: right;">
                <asp:Label ID="Label5" Width="150px" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,HeadCodeDesc %>"></asp:Label>
            </td>
            <td style="text-align: left;">
                <asp:TextBox ID="txtHeadCodeDesc" runat="server" CssClass="csstxtbox" Width="150px" MaxLength="100"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvtxtHeadCodeDesc" Font-Bold="true" ValidationGroup="HeadConfig" ControlToValidate="txtHeadCodeDesc" Display="Dynamic" runat="server" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
           
        </tr>
        <tr>
             <td style="text-align: right;">
                <asp:Label ID="Label6" Width="150px" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,HeadCodeType %>"></asp:Label>
            </td>
            <td style="text-align: left;">
                <asp:DropDownList ID="ddlHeadCodeType" runat="server" CssClass="cssDropDown" OnSelectedIndexChanged="ddlHeadCodeType_SelectedIndexChanged" AutoPostBack="true" Width="150px">
                    <asp:ListItem Text="Head" Value="Head"></asp:ListItem>
                    <asp:ListItem Text="Group Head" Value="GroupHead"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="text-align: right;">
                <asp:Label ID="Label7" Width="150px" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,HeadCodeValueType %>"></asp:Label>
            </td>
            <td style="text-align: left;">
                <asp:DropDownList ID="ddlHeadCodeValueType" runat="server" CssClass="cssDropDown" OnSelectedIndexChanged="ddlHeadCodeValueType_SelectedIndexChanged" AutoPostBack="true" Width="150px">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvddlHeadCodeValueType" Font-Bold="true" ValidationGroup="HeadConfig" ControlToValidate="ddlHeadCodeValueType" Display="Dynamic" runat="server" Text="*" ForeColor="Red" InitialValue="--Select--"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr id="trheadcodevalue" runat="server" visible="false">
            <td style="text-align: right;">
                <asp:Label ID="Label8" Width="150px" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,HeadCodeValue %>"></asp:Label>
            </td>
            <td style="text-align: left;">
                <asp:TextBox ID="txtHeadCodeValue" runat="server" CssClass="csstxtbox" Width="150px" MaxLength="15"> 
                </asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvtxtHeadCodeValue" Font-Bold="true" ValidationGroup="HeadConfig" ControlToValidate="txtHeadCodeValue" Display="Dynamic" runat="server" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr id="trheadcodevalueperof" runat="server" visible="false">
            <td style="text-align: right;">
                <asp:Label ID="Label9" Width="150px" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,HeadCodeValuperof %>"></asp:Label>
            </td>
            <td style="text-align: left;">
                <asp:DropDownList ID="ddlHeadCodeValuperof" runat="server" CssClass="cssDropDown" Width="150px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr id="trgroupheadcodeformula" runat="server" visible="false">
            <td style="text-align: right;">
                <asp:Label ID="Label10" Width="150px" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,GroupHeadCodeFormula %>"></asp:Label>
            </td>
           <td style="text-align: left;">
                <asp:DropDownList ID="ddlGroupHeadCodeFormula" runat="server" CssClass="cssDropDown" Width="150px">
                </asp:DropDownList>
            </td>
               <td style="text-align: left;">
                <asp:Button ID="btnSum" runat="server" Text="+" Width="30px" OnClick="btnSum_Click" />
                <asp:Button ID="btnSub" runat="server" Text="-" Width="30px" OnClick="btnSub_Click" style="margin-left:10px" />
                   <asp:Button ID="btnAdd" runat="server" Text="Add >" Width="80px" OnClick="btnAdd_Click"  style="margin-left:10px" />
                    <asp:Button ID="btnRemove" runat="server" Text="< Remove" Width="80px" OnClick="btnRemove_Click" style="margin-left:10px" />
            </td>
            <td style="text-align: left;">
                <asp:ListBox ID="listBoxFormula" runat="server" Width="150px" SelectionMode="Multiple"></asp:ListBox>
            </td>
        </tr>
       
    </table>
         </asp:Panel>
       <asp:HiddenField ID="hfAutoID" runat="server" Value="0" />
     <asp:HiddenField ID="hfFormula" runat="server"  />
    <br />
    <asp:Button ID="btnSave" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource,Save %>"  OnClick="btnSave_Click" ValidationGroup="HeadConfig" />
    <asp:Button ID="btnAddnew" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource,AddNew %>"  OnClick="btnAddnew_Click"  Visible="false" />
      <asp:Button ID="btnUpdate" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource,Update %>"  OnClick="btnUpdate_Click" ValidationGroup="HeadConfig" Visible="false" />
      <asp:Button ID="btnView" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource,ViewCosting %>"  OnClick="btnView_Click" Visible="false"  />
     <asp:Button ID="btnCalculate" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource,Calculate %>"  OnClick="btnCalculate_Click" Visible="false"  />
         <asp:Button ID="btnAmend" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource,Amend %>"  OnClick="btnAmend_Click" Visible="false"  />
      <asp:Button ID="btnBack" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource,Back %>"  OnClick="btnBack_Click" Visible="false"  />
    <br />
    <br />
    <asp:Label ID="lblmsg" runat="server" Style="color: red"></asp:Label>
    <br />
    <div>
          <asp:GridView ID="gvQuotationHead" Width="100%" CssClass="GridViewStyle"
                                    runat="server" AllowPaging="True" CellPadding="3" GridLines="None"
                                    AutoGenerateColumns="False" PageSize="10"
                                    OnRowCommand="gvQuotationHead_RowCommand" OnRowDataBound="gvQuotationHead_RowDataBound"
                                    ShowFooter="True" OnPageIndexChanging="gvQuotationHead_PageIndexChanging" OnRowEditing="gvQuotationHead_RowEditing">
                                    <FooterStyle CssClass="GridViewFooterStyle" />
                                    <RowStyle CssClass="GridViewRowStyle" />
                                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                    <PagerStyle CssClass="GridViewPagerStyle" />
                                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                                    <Columns>
                          <asp:TemplateField HeaderText="<%$ Resources:Resource,SerialNumber %>" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblSerialNo" CssClass="cssLable" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="50px" />
                         <HeaderStyle CssClass="cssLabelHeader" Width="50px" />
                            <FooterStyle Width="50px" />
                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,CompanyCode %>" Visible="false">
                                             <ItemTemplate>
                                                       <asp:HiddenField ID="hfStatus" runat="server" Value='<%# Bind("Staus") %>' />
                                      
                                                <asp:Label ID="lblCompanyCode" CssClass="cssLable" runat="server" Text='<%# Bind("CompanyCode") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                                            <ItemStyle Width="100px" />
                                            <FooterStyle Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,DesignationCode %>" Visible="false">
                                            <ItemTemplate>
                                                    <asp:HiddenField ID="hfDesignationCode" runat="server" Value='<%# Bind("DesignationCode") %>' />
                                                 <asp:HiddenField ID="hfGradeCode" runat="server" Value='<%# Bind("GradeCode") %>' />
                                                <asp:Label ID="lblDesignationCode" CssClass="cssLabel" runat="server" Text='<%# Bind("DesignationDesc") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                                            <ItemStyle Width="100px" />
                                            <FooterStyle Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,State %>" Visible="false">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hfStateId" runat="server" Value='<%# Bind("State") %>' />
                                                <asp:Label ID="lblStateId" CssClass="cssLabel" runat="server" Text='<%# Bind("StateName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                                            <ItemStyle Width="100px" />
                                            <FooterStyle Width="100px" />
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="<%$ Resources:Resource,Sequence %>">
                                            <ItemTemplate>
                                                       <asp:HiddenField ID="hfQuotationHeadAutoId" runat="server" Value='<%# Bind("QuotationHeadAutoId") %>' />
                                                <asp:Label ID="lblSequence" CssClass="cssLabel" runat="server" Text='<%# Bind("SequenceNo") %>' Style="word-break: break-all;"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="50px" />
                                            <ItemStyle Width="50px" />
                                            <FooterStyle Width="50px" />
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="<%$ Resources:Resource,FromDay %>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFromDay" CssClass="cssLabel" runat="server" Text='<%# Bind("FromDay") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                                            <ItemStyle Width="100px" />
                                            <FooterStyle Width="100px" />
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="<%$ Resources:Resource,ToDay %>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblToday" CssClass="cssLabel" runat="server" Text='<%# Bind("ToDay") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                                            <ItemStyle Width="100px" />
                                            <FooterStyle Width="100px" />
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="<%$ Resources:Resource,FormatCode %>">
                                            <ItemTemplate>
                                                  <asp:Label ID="lblFormatCode" CssClass="cssLabel" runat="server" Text='<%# Bind("FormatCode") %>' Style="word-break: break-all;"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                                            <ItemStyle Width="100px" />
                                            <FooterStyle Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,HeadCode %>">
                                            <ItemTemplate>
                                                 <asp:Label ID="lblHeadCode" CssClass="cssLabel" runat="server" Text='<%# Bind("HeadCode") %>' Style="word-break: break-all;"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                                            <ItemStyle Width="100px" />
                                            <FooterStyle Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,HeadCodeDesc %>">
                                            <ItemTemplate>
                                               <asp:Label ID="lblHeadCodeDesc" CssClass="cssLabel" runat="server" Text='<%# Bind("HeadCodeDesc") %>' Style="word-break: break-all;"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                                            <ItemStyle Width="100px" />
                                            <FooterStyle Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,HeadCodeType %>">
                                           <ItemTemplate>
                                                 <asp:Label ID="lblHeadCodeType" CssClass="cssLabel" runat="server" Text='<%# Bind("HeadCodeType") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                                            <ItemStyle Width="100px" />
                                            <FooterStyle Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,HeadCodeValueType %>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblHeadCodeValueType" CssClass="cssLabel" runat="server" Text='<%# Bind("HeadCodeValueType") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                                            <ItemStyle Width="100px" />
                                            <FooterStyle Width="100px" />
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="<%$ Resources:Resource,HeadCodeValue %>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblHeadCodeValue" CssClass="cssLabel" runat="server" Text='<%# Bind("HeadCodeValue") %>' Style="word-break: break-all;"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                                            <ItemStyle Width="100px" />
                                            <FooterStyle Width="100px" />
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="<%$ Resources:Resource,HeadCodeValuperof %>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblHeadCodeValueperof" CssClass="cssLabel" runat="server" Text='<%# Bind("HeadCodeValueperof") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                                            <ItemStyle Width="100px" />
                                            <FooterStyle Width="100px" />
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="<%$ Resources:Resource,GroupHeadCodeFormula %>">
                                            <ItemTemplate>
                                                  <asp:Label ID="lblGroupHeadCodeFormula" CssClass="cssLabel" runat="server" Text='<%# Bind("GroupHeadFormula") %>' Style="word-break: break-all;"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                                            <ItemStyle Width="100px" />
                                            <FooterStyle Width="100px" />
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="<%$ Resources:Resource,EditColName %>">
                                            <ItemTemplate>
                                                  <asp:ImageButton ID="btnEdit" ToolTip="<%$Resources:Resource,Edit %>" ImageUrl="~/Images/Edit.gif"
                                                    CssClass="csslnkButton"  runat="server" CausesValidation="False" OnClick="btnEdit_Click" />
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="40px" />
                                            <ItemStyle Width="40px" />
                                            <FooterStyle Width="40px" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
    </div>
</asp:Content>

