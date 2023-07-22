<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="AssetSchedulingNew.aspx.cs" Inherits="AssetManagement_AssetSchedulingNew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <Ajax:UpdatePanel runat="server" ID="up2" UpdateMode="Conditional">
        <ContentTemplate>
            <table>
                <tr>
                    <td align="right" style="min-width: 200px">
                        <asp:Label runat="server" ID="lblArea" Text="<%$Resources:Resource,Area %>" CssClass="cssLabel"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:DropDownList runat="server" ID="ddlAreaID" CssClass="cssDropDown" AutoPostBack="true"
                            Width="200px" OnSelectedIndexChanged="ddlAreaID_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td align="right">
                        <asp:Label ID="lblhdrClient" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, Client %>"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtClientCode" runat="server" AutoPostBack="True" CssClass="csstxtbox" Width="200px" OnTextChanged="txtClientCode_TextChanged"></asp:TextBox>
                        <asp:Image ID="ImgClientCode_CCH" runat="server" ImageUrl="~/Images/icosearch.gif" />
                        <asp:DropDownList ID="ddlClient" runat="server" CssClass="cssDropDown" AutoPostBack="true"
                            Width="280px" OnSelectedIndexChanged="ddlClient_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblhdrAsmt" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, Asmt %>"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlAsmt" runat="server" CssClass="cssDropDown" AutoPostBack="true"
                            Width="200px" OnSelectedIndexChanged="ddlAsmt_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td align="right">
                        <asp:Label ID="Label1" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, PostDesc %>"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlPost" runat="server" CssClass="cssDropDown" AutoPostBack="true"
                            Width="200px">
                        </asp:DropDownList>
                    </td>
                </tr>
                 <tr>
                    <td align="right">
                        <asp:Label ID="Label4" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, Month %>"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlMonth" runat="server" CssClass="cssDropDown" AutoPostBack="true"
                            Width="100px" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged">
                            <asp:ListItem Text="January" Value="01"></asp:ListItem>
                               <asp:ListItem Text="Feburary" Value="02"></asp:ListItem>
                               <asp:ListItem Text="March" Value="03"></asp:ListItem>
                               <asp:ListItem Text="April" Value="04"></asp:ListItem>
                               <asp:ListItem Text="May" Value="05"></asp:ListItem>
                               <asp:ListItem Text="June" Value="06"></asp:ListItem>
                               <asp:ListItem Text="July" Value="07"></asp:ListItem>
                               <asp:ListItem Text="August" Value="08"></asp:ListItem>
                               <asp:ListItem Text="September" Value="09"></asp:ListItem>
                               <asp:ListItem Text="October" Value="10"></asp:ListItem>
                              <asp:ListItem Text="November" Value="11"></asp:ListItem>
                               <asp:ListItem Text="December" Value="12"></asp:ListItem>
                        </asp:DropDownList>
                          <asp:DropDownList ID="ddlYear" runat="server" CssClass="cssDropDown" AutoPostBack="true"
                            Width="90px" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                   
                     <td align="right">
                        <asp:Label ID="Label6" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, Week %>"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlWeek" runat="server" CssClass="cssDropDown" AutoPostBack="true"
                            Width="200px" OnSelectedIndexChanged="ddlWeek_SelectedIndexChanged">
                        </asp:DropDownList>
                          <asp:Button runat="server" ID="btnProceed" CssClass="cssButton" Width="150px" Text="Proceed" OnClick="btnProceed_Click" />
                         <asp:Button runat="server" ID="btnAutoFillSchedule" CssClass="cssButton" Width="250px" Text="Pick from last week schedule" OnClick="btnAutoFillSchedule_Click" Visible="false" />
                    </td>
                      <td align="center" >
                      
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label2" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, FromDate %>" Visible="false"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtServiceDate" CssClass="csstxtboxRequired" runat="server" OnTextChanged="txtServiceDate_TextChanged" AutoPostBack="true"  Visible="false"></asp:TextBox>
                        <asp:HyperLink Style="vertical-align: top;" ID="hlServiceDate" runat="server" Height="19px"  Visible="false"
                            Width="20px" ImageUrl="../Images/pdate.gif"></asp:HyperLink>
                        <AjaxToolKit:CalendarExtender ID="CEServiceDate" Format="dd-MMM-yyyy" runat="server" TargetControlID="txtServiceDate"
                            PopupButtonID="hlServiceDate" Enabled="True"></AjaxToolKit:CalendarExtender>
                    </td>
                     <td align="right">
                        <asp:Label ID="Label3" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, ToDate %>"  Visible="false"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtToDate" CssClass="csstxtboxRequired" runat="server" Visible="false"></asp:TextBox>
                        <asp:HyperLink Style="vertical-align: top;" ID="HyperLink1" runat="server" Height="19px" Visible="false"
                            Width="20px" ImageUrl="../Images/pdate.gif" ></asp:HyperLink>
                      <%--  <AjaxToolKit:CalendarExtender ID="CSToDate" Format="dd-MMM-yyyy" runat="server" TargetControlID="txtToDate"
                            PopupButtonID="HyperLink1" Enabled="True" ></AjaxToolKit:CalendarExtender>--%>
                    </td>
                   
                </tr>
                <tr>
                    <td colspan="4">
                        <br />
                        <asp:Label CssClass="cssLabel" ID="lblErrorMsg" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
            </table>
          
            <br>
            <asp:GridView ID="gvAssetScheduling" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="1" CssClass="GridViewStyle" GridLines="None" OnRowDataBound="gvAssetScheduling_RowDataBound" PageSize="10" ShowFooter="True" Width="210%"
                OnPageIndexChanging="gvAssetScheduling_PageIndexChanging" OnRowCommand="gvAssetScheduling_RowCommand">
                <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#DBDDF8" />
                    <FooterStyle BackColor="#D3E8F4" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#2E6293" Font-Bold="True" />
                    <PagerStyle BackColor="#2E6293" ForeColor="White" />
                    <RowStyle BackColor="#EFF3FB" CssClass="GridViewRowStyle" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                <Columns>
                    <asp:TemplateField Visible="false" HeaderStyle-ForeColor="White">
                        <HeaderTemplate >
                            <asp:Label ID="lblaction" runat="server" CssClass="cssLabelHeader" Text="<%$ Resources:Resource, EditColName %>"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgbtnAdd" runat="server" CommandName="Add" CssClass="cssImgButton" ImageUrl="../Images/AddNew.gif" ToolTip="<%$Resources:Resource,Save %>" ValidationGroup="vgHrFooter" />
                            &nbsp;
                            <asp:ImageButton ID="ImgbtnReset" runat="server" CommandName="Reset" CssClass="cssImgButton" ImageUrl="../Images/Reset.gif" ToolTip="<%$ Resources:Resource, Reset %>"  />
                        </ItemTemplate>
                        <HeaderStyle CssClass="cssLabelHeader" Width="80px"  />
                        <ItemStyle Width="80px" />
                        <FooterStyle Width="80px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-ForeColor="White">
                        <HeaderTemplate>
                            <table width="310px">
                                <tr>
                                    <td style="text-align: left; width: 100px;">
                                        <asp:Label ID="Label13" runat="server" Text="Asset Code"></asp:Label>
                                    </td>
                                    <td style="text-align: left; width: 100px;">
                                        <asp:Label ID="Label8" runat="server" Text="Asset Name"></asp:Label>
                                    </td>
                                    <td style="text-align: left; width: 100px;">
                                        <asp:Label ID="Label3" runat="server" Text="Service Type"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </HeaderTemplate>
                        <ItemTemplate>
                           <%-- <asp:HiddenField ID="hfAssetScheduleAutoId" runat="server" Value='<%# Bind("AssetScheduleAutoId") %>' />
                            <asp:HiddenField ID="hfAssetWoNo" runat="server" Value='<%# Bind("AssetWoNo") %>' />
                            <asp:HiddenField ID="hfAssetWoLineNo" runat="server" Value='<%# Bind("AssetWoLineNo") %>' />
                            <asp:HiddenField ID="hfFromTime" runat="server" Value='<%#String.Format("{0:HH:mm}",Eval("FromTime")) %>' />
                            <asp:HiddenField ID="hfToTime" runat="server" Value='<%#String.Format("{0:HH:mm}",Eval("ToTime")) %>' />
                            <asp:HiddenField ID="hfAssetAutoId" runat="server" Value='<%# Bind("AssetAutoId") %>' />--%>
                            <table width="310px">
                                <tr>
                                    <td style="text-align: left; width: 100px;">
                              <%--  <asp:HiddenField ID="hfAssetScheduleAutoId" runat="server" Value='<%# Bind("AssetScheduleAutoId") %>' />--%>
                                <asp:HiddenField ID="hfAssetWoNo" runat="server" Value='<%# Bind("AssetWoNo") %>' />
                                <asp:HiddenField ID="hfAssetWoLineNo" runat="server" Value='<%# Bind("AssetWoLineNo") %>' />
                                <asp:HiddenField ID="hfAssetAutoId" runat="server" Value='<%# Bind("AssetAutoId") %>' />
                                   <asp:Label ID="lblAssetCode" runat="server" CssClass="cssLabel" Style="word-break: break-all;" Text='<%# Bind("AssetCode") %>' Width="90px"></asp:Label>
                                    </td>
                                    <td style="text-align: left; width: 100px;">
                                        <asp:Label ID="lblAssetName" runat="server" CssClass="cssLabel" Style="word-break: break-all;" Text='<%# Bind("AssetName") %>' Width="90px"></asp:Label>
                                    </td>
                                    <td style="text-align: left; width: 100px;">
                                        <asp:HiddenField ID="hfAssetServiceTypeAutoId" runat="server" Value='<%# Bind("AssetServiceTypeAutoId") %>' />
                                        <asp:Label ID="lblAssetServiceTypeName" runat="server" CssClass="cssLabel" Style="word-break: break-all;" Text='<%# Bind("AssetServiceTypeName") %>' Width="90px"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                        <HeaderStyle CssClass="cssLabelHeader" Width="310px" />
                        <ItemStyle Width="310px" />
                        <FooterStyle Width="310px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-ForeColor="White">
                          <HeaderTemplate>
                            <table width="400px">
                                <tr>
                                    <td style="text-align: center; width: 500px; background-color:skyblue;color:black;border:solid 1px;" colspan="4">
                                        <asp:Label ID="lblFirstDate" runat="server" Text="Employee No"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left; width: 90px;">
                                        <asp:Label ID="lblENo" runat="server" Text="Employee No"></asp:Label>
                                    </td>
                                    <td style="text-align: left; width: 120px;">
                                        <asp:Label ID="lblEN" runat="server" Text="Employee Name"></asp:Label>
                                    </td>
                                    <td style="text-align: left; width: 70px;">
                                        <asp:Label ID="lblFD" runat="server" Text="From Time"></asp:Label>
                                    </td>
                                     <td style="text-align: left; width: 70px;">
                                        <asp:Label ID="lblTD" runat="server" Text="To Time"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </HeaderTemplate>
                           <ItemTemplate>
                                <table style="width: 100%; padding: 0; border-spacing: 0; margin: 0; border: 0;">
                                 
                                                <tr>
                                                      <td style="text-align: left; width: 90px;">
                                        <asp:TextBox ID="txt40" Width="80px" MaxLength="12" CssClass="csstxtbox" runat="server" Text='<%# Bind("40") %>' OnTextChanged="txt40_TextChanged" AutoPostBack="true" ></asp:TextBox>
                                    </td>
                                    <td style="text-align: left; width: 120px;">
                                          <asp:HiddenField ID="hfAssetId4" runat="server" Value='<%# Bind("401") %>' />
                                      <asp:TextBox ID="txt41" Width="110px" MaxLength="100" CssClass="csstxtbox" runat="server" Text='<%# Bind("41") %>'  ></asp:TextBox>
                                    </td>
                                    <td style="text-align: left; width: 70px;">
                                        <asp:HiddenField ID="hfFromTime42" runat="server" Value='<%# Bind("42") %>' />
                                          <asp:TextBox ID="txt42" Width="65px" CssClass="csstxtbox" runat="server" Text='<%# Bind("42") %>'  OnTextChanged="txt40_TextChanged" AutoPostBack="true"></asp:TextBox>
                                    </td>
                                     <td style="text-align: left; width: 70px;">
                                            <asp:HiddenField ID="hfToTime43" runat="server" Value='<%# Bind("43") %>' />
                                       <asp:TextBox ID="txt43" Width="65px" CssClass="csstxtbox" runat="server" Text='<%# Bind("43") %>' OnTextChanged="txt40_TextChanged" AutoPostBack="true" ></asp:TextBox>
                                    </td>
                                                </tr>
                                    </table>
                                                     </ItemTemplate>
                          <HeaderStyle CssClass="cssLabelHeader" Width="400px" />
                        <ItemStyle Width="400px" />
                        <FooterStyle Width="400px" />
                    </asp:TemplateField>
                      <asp:TemplateField HeaderStyle-ForeColor="White">
                          <HeaderTemplate>
                            <table width="400px">
                                <tr>
                                  <td style="text-align: center; width: 500px; background-color:skyblue;color:black;border:solid 1px;" colspan="4">
                                        <asp:Label ID="lblSecondDate" runat="server" Text="Employee No"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left; width: 90px;">
                                        <asp:Label ID="lblENo2" runat="server" Text="Employee No"></asp:Label>
                                    </td>
                                    <td style="text-align: left; width: 120px;">
                                        <asp:Label ID="lblEN2" runat="server" Text="Employee Name"></asp:Label>
                                    </td>
                                    <td style="text-align: left; width: 70px;">
                                        <asp:Label ID="lblFD2" runat="server" Text="From Time"></asp:Label>
                                    </td>
                                     <td style="text-align: left; width: 70px;">
                                        <asp:Label ID="lblTD2" runat="server" Text="To Time"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </HeaderTemplate>
                           <ItemTemplate>
                                <table style="width: 100%; padding: 0; border-spacing: 0; margin: 0; border: 0;">
                                 
                                                <tr>
                                                      <td style="text-align: left; width: 90px;">
                                        <asp:TextBox ID="txt50" Width="80px" MaxLength="12" CssClass="csstxtbox" runat="server" Text='<%# Bind("50") %>' OnTextChanged="txt50_TextChanged" AutoPostBack="true"></asp:TextBox>
                                    </td>
                                    <td style="text-align: left; width: 120px;">
                                         <asp:HiddenField ID="hfAssetId5" runat="server" Value='<%# Bind("501") %>' />
                                      <asp:TextBox ID="txt51" Width="110px" MaxLength="100" CssClass="csstxtbox" runat="server" Text='<%# Bind("51") %>'  ></asp:TextBox>
                                    </td>
                                    <td style="text-align: left; width: 70px;">
                                          <asp:HiddenField ID="hfFromTime52" runat="server" Value='<%# Bind("52") %>' />
                                          <asp:TextBox ID="txt52" Width="65px" CssClass="csstxtbox" runat="server" Text='<%# Bind("52") %>' OnTextChanged="txt50_TextChanged" AutoPostBack="true"></asp:TextBox>
                                    </td>
                                     <td style="text-align: left; width: 70px;">
                                           <asp:HiddenField ID="hfToTime53" runat="server" Value='<%# Bind("53") %>' />
                                       <asp:TextBox ID="txt53" Width="65px" CssClass="csstxtbox" runat="server" Text='<%# Bind("53") %>' OnTextChanged="txt50_TextChanged" AutoPostBack="true"></asp:TextBox>
                                    </td>
                                                </tr>
                                    </table>
                  
                                  </ItemTemplate>
                          <HeaderStyle CssClass="cssLabelHeader" Width="400px" />
                        <ItemStyle Width="400px" />
                        <FooterStyle Width="400px" />
                    </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-ForeColor="White">
                          <HeaderTemplate>
                            <table width="400px">
                                <tr>
                                    <td style="text-align: center; width: 500px; background-color:skyblue;color:black;border:solid 1px;" colspan="4">
                                        <asp:Label ID="lblThirdDate" runat="server" Text="Employee No"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left; width: 90px;">
                                        <asp:Label ID="lblENo3" runat="server" Text="Employee No"></asp:Label>
                                    </td>
                                    <td style="text-align: left; width: 120px;">
                                        <asp:Label ID="lblEN3" runat="server" Text="Employee Name"></asp:Label>
                                    </td>
                                    <td style="text-align: left; width: 70px;">
                                        <asp:Label ID="lblFD3" runat="server" Text="From Time"></asp:Label>
                                    </td>
                                     <td style="text-align: left; width: 70px;">
                                        <asp:Label ID="lblTD3" runat="server" Text="To Time"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </HeaderTemplate>
                           <ItemTemplate>
                                <table style="width: 100%; padding: 0; border-spacing: 0; margin: 0; border: 0;">
                                 
                                                <tr>
                                                      <td style="text-align: left; width: 90px;">
                                        <asp:TextBox ID="txt60" Width="80px" MaxLength="12" CssClass="csstxtbox" runat="server" Text='<%# Bind("60") %>' OnTextChanged="txt60_TextChanged" AutoPostBack="true"></asp:TextBox>
                                    </td>
                                    <td style="text-align: left; width: 120px;">
                                         <asp:HiddenField ID="hfAssetId6" runat="server" Value='<%# Bind("601") %>' />
                                      <asp:TextBox ID="txt61" Width="110px" MaxLength="100" CssClass="csstxtbox" runat="server" Text='<%# Bind("61") %>'></asp:TextBox>
                                    </td>
                                    <td style="text-align: left; width: 70px;">
                                          <asp:HiddenField ID="hfFromTime62" runat="server" Value='<%# Bind("62") %>' />
                                          <asp:TextBox ID="txt62" Width="65px" CssClass="csstxtbox" runat="server" Text='<%# Bind("62") %>' OnTextChanged="txt60_TextChanged" AutoPostBack="true" ></asp:TextBox>
                                    </td>
                                     <td style="text-align: left; width: 70px;">
                                           <asp:HiddenField ID="hfToTime63" runat="server" Value='<%# Bind("63") %>' />
                                       <asp:TextBox ID="txt63" Width="65px" CssClass="csstxtbox" runat="server" Text='<%# Bind("63") %>' OnTextChanged="txt60_TextChanged" AutoPostBack="true"></asp:TextBox>
                                    </td>
                                                </tr>
                                    </table>
                  
                                  </ItemTemplate>
                          <HeaderStyle CssClass="cssLabelHeader" Width="400px" />
                        <ItemStyle Width="400px" />
                        <FooterStyle Width="400px" />
                    </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-ForeColor="White">
                          <HeaderTemplate>
                            <table width="400px">
                                <tr>
                                   <td style="text-align: center; width: 500px; background-color:skyblue;color:black;border:solid 1px;" colspan="4">
                                        <asp:Label ID="lblFourthDate" runat="server" Text="Employee No"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left; width: 90px;">
                                        <asp:Label ID="lblENo4" runat="server" Text="Employee No"></asp:Label>
                                    </td>
                                    <td style="text-align: left; width: 120px;">
                                        <asp:Label ID="lblEN4" runat="server" Text="Employee Name"></asp:Label>
                                    </td>
                                    <td style="text-align: left; width: 70px;">
                                        <asp:Label ID="lblFD4" runat="server" Text="From Time"></asp:Label>
                                    </td>
                                     <td style="text-align: left; width: 70px;">
                                        <asp:Label ID="lblTD4" runat="server" Text="To Time"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </HeaderTemplate>
                           <ItemTemplate>
                                <table style="width: 100%; padding: 0; border-spacing: 0; margin: 0; border: 0;">
                                 
                                                <tr>
                                                      <td style="text-align: left; width: 90px;">
                                        <asp:TextBox ID="txt70" Width="80px" MaxLength="12" CssClass="csstxtbox" runat="server" Text='<%# Bind("70") %>'  OnTextChanged="txt70_TextChanged" AutoPostBack="true"></asp:TextBox>
                                    </td>
                                    <td style="text-align: left; width: 120px;">
                                         <asp:HiddenField ID="hfAssetId7" runat="server" Value='<%# Bind("701") %>' />
                                      <asp:TextBox ID="txt71" Width="110px" MaxLength="100" CssClass="csstxtbox" runat="server" Text='<%# Bind("71") %>' ></asp:TextBox>
                                    </td>
                                    <td style="text-align: left; width: 70px;">
                                          <asp:HiddenField ID="hfFromTime72" runat="server" Value='<%# Bind("72") %>' />
                                          <asp:TextBox ID="txt72" Width="65px" CssClass="csstxtbox" runat="server" Text='<%# Bind("72") %>' OnTextChanged="txt70_TextChanged" AutoPostBack="true" ></asp:TextBox>
                                    </td>
                                     <td style="text-align: left; width: 70px;">
                                           <asp:HiddenField ID="hfToTime73" runat="server" Value='<%# Bind("73") %>' />
                                       <asp:TextBox ID="txt73" Width="65px" CssClass="csstxtbox" runat="server" Text='<%# Bind("73") %>' OnTextChanged="txt70_TextChanged" AutoPostBack="true"></asp:TextBox>
                                    </td>
                                                </tr>
                                    </table>
                   
                                  </ItemTemplate>
                          <HeaderStyle CssClass="cssLabelHeader" Width="400px" />
                        <ItemStyle Width="400px" />
                        <FooterStyle Width="400px" />
                    </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-ForeColor="White">
                          <HeaderTemplate>
                            <table width="400px">
                                <tr>
                                   <td style="text-align: center; width: 500px; background-color:skyblue;color:black;border:solid 1px;" colspan="4">
                                        <asp:Label ID="lblFifthDate" runat="server" Text="Employee No"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left; width: 90px;">
                                        <asp:Label ID="lblENo5" runat="server" Text="Employee No"></asp:Label>
                                    </td>
                                    <td style="text-align: left; width: 120px;">
                                        <asp:Label ID="lblEN5" runat="server" Text="Employee Name"></asp:Label>
                                    </td>
                                    <td style="text-align: left; width: 70px;">
                                        <asp:Label ID="lblFD5" runat="server" Text="From Time"></asp:Label>
                                    </td>
                                     <td style="text-align: left; width: 70px;">
                                        <asp:Label ID="lblTD5" runat="server" Text="To Time"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </HeaderTemplate>
                           <ItemTemplate>
                                <table style="width: 100%; padding: 0; border-spacing: 0; margin: 0; border: 0;">
                                 
                                                <tr>
                                                      <td style="text-align: left; width: 90px;">
                                        <asp:TextBox ID="txt80" Width="80px" MaxLength="12" CssClass="csstxtbox" runat="server" Text='<%# Bind("80") %>' OnTextChanged="txt80_TextChanged" AutoPostBack="true"></asp:TextBox>
                                    </td>
                                    <td style="text-align: left; width: 120px;">
                                         <asp:HiddenField ID="hfAssetId8" runat="server" Value='<%# Bind("801") %>' />
                                      <asp:TextBox ID="txt81" Width="110px" MaxLength="100" CssClass="csstxtbox" runat="server" Text='<%# Bind("81") %>' ></asp:TextBox>
                                    </td>
                                    <td style="text-align: left; width: 70px;">
                                          <asp:HiddenField ID="hfFromTime82" runat="server" Value='<%# Bind("82") %>' />
                                          <asp:TextBox ID="txt82" Width="65px" CssClass="csstxtbox" runat="server" Text='<%# Bind("82") %>' OnTextChanged="txt80_TextChanged" AutoPostBack="true" ></asp:TextBox>
                                    </td>
                                     <td style="text-align: left; width: 70px;">
                                           <asp:HiddenField ID="hfToTime83" runat="server" Value='<%# Bind("83") %>' />
                                       <asp:TextBox ID="txt83" Width="65px" CssClass="csstxtbox" runat="server" Text='<%# Bind("83") %>' OnTextChanged="txt80_TextChanged" AutoPostBack="true"></asp:TextBox>
                                    </td>
                                                </tr>
                                    </table>
                   
                                  </ItemTemplate>
                          <HeaderStyle CssClass="cssLabelHeader" Width="400px" />
                        <ItemStyle Width="400px" />
                        <FooterStyle Width="400px" />
                    </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-ForeColor="White">
                          <HeaderTemplate>
                            <table width="400px">
                                <tr>
                                  <td style="text-align: center; width: 500px; background-color:skyblue;color:black;border:solid 1px;" colspan="4">
                                        <asp:Label ID="lblSixthDate" runat="server" Text="Employee No"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left; width: 90px;">
                                        <asp:Label ID="lblENo6" runat="server" Text="Employee No"></asp:Label>
                                    </td>
                                    <td style="text-align: left; width: 120px;">
                                        <asp:Label ID="lblEN6" runat="server" Text="Employee Name"></asp:Label>
                                    </td>
                                    <td style="text-align: left; width: 70px;">
                                        <asp:Label ID="lblFD6" runat="server" Text="From Time"></asp:Label>
                                    </td>
                                     <td style="text-align: left; width: 70px;">
                                        <asp:Label ID="lblTD6" runat="server" Text="To Time"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </HeaderTemplate>
                           <ItemTemplate>
                                <table style="width: 100%; padding: 0; border-spacing: 0; margin: 0; border: 0;">
                                 
                                                <tr>
                                                      <td style="text-align: left; width: 90px;">
                                        <asp:TextBox ID="txt90" Width="80px" MaxLength="12" CssClass="csstxtbox" runat="server" Text='<%# Bind("90") %>' OnTextChanged="txt90_TextChanged" AutoPostBack="true" ></asp:TextBox>
                                    </td>
                                    <td style="text-align: left; width: 120px;">
                                         <asp:HiddenField ID="hfAssetId9" runat="server" Value='<%# Bind("901") %>' />
                                      <asp:TextBox ID="txt91" Width="110px" MaxLength="100" CssClass="csstxtbox" runat="server" Text='<%# Bind("91") %>'></asp:TextBox>
                                    </td>
                                    <td style="text-align: left; width: 70px;">
                                          <asp:HiddenField ID="hfFromTime92" runat="server" Value='<%# Bind("92") %>' />
                                          <asp:TextBox ID="txt92" Width="65px" CssClass="csstxtbox" runat="server" Text='<%# Bind("92") %>' OnTextChanged="txt90_TextChanged" AutoPostBack="true" ></asp:TextBox>
                                    </td>
                                     <td style="text-align: left; width: 70px;">
                                           <asp:HiddenField ID="hfToTime93" runat="server" Value='<%# Bind("93") %>' />
                                       <asp:TextBox ID="txt93" Width="65px" CssClass="csstxtbox" runat="server" Text='<%# Bind("93") %>' OnTextChanged="txt90_TextChanged" AutoPostBack="true" ></asp:TextBox>
                                    </td>
                                                </tr>
                                    </table>
                   
                                  </ItemTemplate>
                          <HeaderStyle CssClass="cssLabelHeader" Width="400px" />
                        <ItemStyle Width="400px" />
                        <FooterStyle Width="400px" />
                    </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-ForeColor="White">
                          <HeaderTemplate>
                            <table width="400px">
                                <tr>
                                 <td style="text-align: center; width: 500px; background-color:skyblue;color:black;border:solid 1px;" colspan="4">
                                        <asp:Label ID="lblSeventhDate" runat="server" Text="Employee No"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left; width: 90px;">
                                        <asp:Label ID="lblENo7" runat="server" Text="Employee No"></asp:Label>
                                    </td>
                                    <td style="text-align: left; width: 120px;">
                                        <asp:Label ID="lblEN7" runat="server" Text="Employee Name"></asp:Label>
                                    </td>
                                    <td style="text-align: left; width: 70px;">
                                        <asp:Label ID="lblFD7" runat="server" Text="From Time"></asp:Label>
                                    </td>
                                     <td style="text-align: left; width: 70px;">
                                        <asp:Label ID="lblTD7" runat="server" Text="To Time"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </HeaderTemplate>
                           <ItemTemplate>
                                <table style="width: 100%; padding: 0; border-spacing: 0; margin: 0; border: 0;">
                                 
                                                <tr>
                                                      <td style="text-align: left; width: 90px;">
                                        <asp:TextBox ID="txt100" Width="80px" MaxLength="12" CssClass="csstxtbox" runat="server" Text='<%# Bind("100") %>' OnTextChanged="txt100_TextChanged" AutoPostBack="true"></asp:TextBox>
                                    </td>
                                    <td style="text-align: left; width: 120px;">
                                         <asp:HiddenField ID="hfAssetId10" runat="server" Value='<%# Bind("1001") %>' />
                                      <asp:TextBox ID="txt101" Width="110px" MaxLength="100" CssClass="csstxtbox" runat="server" Text='<%# Bind("101") %>' ></asp:TextBox>
                                    </td>
                                    <td style="text-align: left; width: 70px;">
                                          <asp:HiddenField ID="hfFromTime102" runat="server" Value='<%# Bind("102") %>' />
                                          <asp:TextBox ID="txt102" Width="65px" CssClass="csstxtbox" runat="server" Text='<%# Bind("102") %>' OnTextChanged="txt100_TextChanged" AutoPostBack="true" ></asp:TextBox>
                                    </td>
                                     <td style="text-align: left; width: 70px;">
                                           <asp:HiddenField ID="hfToTime103" runat="server" Value='<%# Bind("103") %>' />
                                       <asp:TextBox ID="txt103" Width="65px" CssClass="csstxtbox" runat="server" Text='<%# Bind("103") %>' OnTextChanged="txt100_TextChanged" AutoPostBack="true"></asp:TextBox>
                                    </td>
                                                </tr>
                                    </table>
                  
                                  </ItemTemplate>
                          <HeaderStyle CssClass="cssLabelHeader" Width="400px" />
                        <ItemStyle Width="400px" />
                        <FooterStyle Width="400px" />
                    </asp:TemplateField>

                     
                </Columns>

            </asp:GridView>
          
            </br>
        </ContentTemplate>
    </Ajax:UpdatePanel>
</asp:Content>



