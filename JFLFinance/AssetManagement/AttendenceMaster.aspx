<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="AttendenceMaster.aspx.cs" Inherits="AssetManagement_AttendenceMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style type="text/css">
body
{
    margin: 0;
    padding: 0;
    height: 100%;
}
.modal
{
    display: none;
    position: absolute;
    top: 0px;
    left: 0px;
    background-color: black;
    z-index: 100;
    opacity: 0.8;
    filter: alpha(opacity=60);
    -moz-opacity: 0.8;
    min-height: 100%;
}
#divImage
{
   display: none;
    z-index: 1000;
    position: fixed;
    top: 0;
    left: 0;
    background-color: whitesmoke;
    height: 415px;
    width: 310px;
    padding: 3px;
    border: solid 1px black;
}
</style>
  <script type="text/javascript">
      function LoadDiv(url) {
          var img = new Image();
          var bcgDiv = document.getElementById("divBackground");
          var imgDiv = document.getElementById("divImage");
          var imgFull = document.getElementById("imgFull");
          var imgLoader = document.getElementById("imgLoader");
          imgLoader.style.display = "block";
          img.onload = function () {
              imgFull.src = img.src;
              imgFull.style.display = "block";
              imgLoader.style.display = "none";
          };
          img.src = url;
          var width = document.body.clientWidth;
          if (document.body.clientHeight > document.body.scrollHeight) {
              bcgDiv.style.height = document.body.clientHeight + "px";
          }
          else {
              bcgDiv.style.height = document.body.scrollHeight + "px";
          }
          imgDiv.style.left = (width - 650) / 2 + "px";
          imgDiv.style.top = "20px";
          bcgDiv.style.width = "100%";

          bcgDiv.style.display = "block";
          imgDiv.style.display = "block";
          return false;
      }
      function HideDiv() {
          var bcgDiv = document.getElementById("divBackground");
          var imgDiv = document.getElementById("divImage");
          var imgFull = document.getElementById("imgFull");
          if (bcgDiv != null) {
              bcgDiv.style.display = "none";
              imgDiv.style.display = "none";
              imgFull.style.display = "none";
          }
      }
</script>
     <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
        <ContentTemplate>
               <asp:Panel ID="pnlTicetMaster" runat="server" Visible="true" >
                      <center>     <b><asp:Label ID="Label1" runat="server"   CssClass="cssLabel" style="font-size:larger;color:black;font-weight:900" Text="Employee Attendence Details" ></asp:Label></b>  </center> 
       
                   <br />
                    <table align="center" width="100%" border="0" cellspacing="0px" cellpadding="0px">
             <tr>
              
                <td style="text-align: right;">
                    <asp:Label ID="lblClientCode" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,ClientCode %>" ></asp:Label>
                </td>
                <td style="text-align: left;">
                     <asp:DropDownList ID="ddlClientCode" runat="server" CssClass="csstxtbox" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="ddlClientCode_SelectedIndexChanged"></asp:DropDownList>
                </td>
                <td style="text-align: right;">
                    <asp:Label ID="lblSiteId" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,AsmtId %>"></asp:Label>
                </td>
                <td style="text-align: left;">
                    <asp:DropDownList ID="ddlSiteId" runat="server" CssClass="csstxtbox" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="ddlSiteId_SelectedIndexChanged"></asp:DropDownList>
                </td>
                <td style="text-align: right;">
                    <asp:Label ID="lblPostCode" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,PostCode %>"></asp:Label>
                </td>
                <td style="text-align: left;">
                       <asp:DropDownList ID="ddlPostCode" runat="server" CssClass="csstxtbox" Width="180px" AutoPostBack="true" OnSelectedIndexChanged="ddlPostCode_SelectedIndexChanged1"></asp:DropDownList>
                </td>
                  <td style="text-align: right;">
                    <asp:Label ID="lblActivewef" CssClass="cssLable" Style="width: 100px;" runat="server" Text="From Date"></asp:Label>
                </td>
                  <td style="text-align: left;">
                    <asp:TextBox ID="txtDate" MaxLength="50" Width="80px" CssClass="csstxtbox" 
                        runat="server" OnTextChanged="txtDate_TextChanged1" AutoPostBack="true"></asp:TextBox>
                    <asp:ImageButton ID="ImageButton1" Style="vertical-align: middle" runat="server" ImageUrl="~/Images/pdate.gif" Enabled="true"></asp:ImageButton>
                    <AjaxToolKit:CalendarExtender ID="CalendarExtender5" Format="dd-MMM-yyyy" runat="server"
                        TargetControlID="txtDate" PopupButtonID="ImageButton1" Enabled="True"></AjaxToolKit:CalendarExtender>
                   
                </td>
                  <td style="text-align: right;">
                    <asp:Label ID="Label3" CssClass="cssLable" Style="width: 100px;" runat="server" Text="To Date"></asp:Label>
                </td>
                  <td style="text-align: left;">
                    <asp:TextBox ID="txtToDate" MaxLength="50" Width="80px" CssClass="csstxtbox" 
                        runat="server" OnTextChanged="txtToDate_TextChanged" AutoPostBack="true"></asp:TextBox>
                    <asp:ImageButton ID="ImageButton2" Style="vertical-align: middle" runat="server" ImageUrl="~/Images/pdate.gif" Enabled="true"></asp:ImageButton>
                    <AjaxToolKit:CalendarExtender ID="CalendarExtender1" Format="dd-MMM-yyyy" runat="server"
                        TargetControlID="txtToDate" PopupButtonID="ImageButton2" Enabled="True"></AjaxToolKit:CalendarExtender>
                   
                </td>
                  <td style="text-align: right;">
                    <asp:Label ID="Label2" CssClass="cssLable" Style="width: 100px;" runat="server" Text="Employee Number"></asp:Label>
                </td>
                  <td style="text-align: left;">
                    <asp:TextBox ID="txtEmpNo" MaxLength="15" Width="120px" CssClass="csstxtbox" 
                        runat="server" OnTextChanged="txtEmpNo_TextChanged" AutoPostBack="true"></asp:TextBox>
                 
                   
                </td>
            </tr>
               </table>
                   <br />
                   <div id="divGV" runat="server">
            <asp:GridView ID="gvAttendence" Width="60%" CssClass="GridViewStyle" PageSize="10"
                runat="server" AllowPaging="true" CellPadding="1" GridLines="None"
                AutoGenerateColumns="False" 
                ShowFooter="True" OnPageIndexChanging="gvAttendence_PageIndexChanging" OnRowDataBound="gvAttendence_RowDataBound" >
              <AlternatingRowStyle BackColor="White" />
                            <EditRowStyle BackColor="#DBDDF8" />
                            <FooterStyle BackColor="#D3E8F4" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#2E6293" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2E6293" ForeColor="White" />
                            <RowStyle BackColor="#EFF3FB" CssClass="GridViewRowStyle" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                <Columns>
                     <asp:TemplateField HeaderText="<%$Resources:Resource,SerialNumber %>" HeaderStyle-Width="80px" HeaderStyle-ForeColor="White"
                        FooterStyle-Width="80px" ItemStyle-Width="80px" HeaderStyle-CssClass="cssLabelHeader">
                        <ItemTemplate>
                            <asp:Label ID="lblSerialNo" CssClass="cssLable" runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                   <asp:TemplateField HeaderText="<%$ Resources:Resource,EmployeeNumber %>" HeaderStyle-ForeColor="White">
                    <ItemTemplate>                           
                             <asp:Label ID="lblTicketStatus" CssClass="cssLable" runat="server" Text='<%# Bind("EmployeeNumber") %>'></asp:Label>
                        </ItemTemplate>
                     <HeaderStyle CssClass="cssLabelHeader" Width="300px" />
                        <ItemStyle Width="300px" />
                        <FooterStyle Width="300px" />
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="<%$ Resources:Resource,EmployeeName %>" HeaderStyle-ForeColor="White">
                    <ItemTemplate>                           
                             <asp:Label ID="lblEmployeeName" CssClass="cssLable" runat="server" Text='<%# Bind("Employeename") %>'></asp:Label>
                        </ItemTemplate>
                     <HeaderStyle CssClass="cssLabelHeader" Width="300px" />
                        <ItemStyle Width="300px" />
                        <FooterStyle Width="300px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$Resources:Resource,Post %>" HeaderStyle-Width="300px" HeaderStyle-ForeColor="White"
                        FooterStyle-Width="300px" ItemStyle-Width="300px">
                       <ItemTemplate>
                            <asp:Label ID="lblPost" CssClass="cssLable" runat="server" Text='<%# Bind("Post") %>'></asp:Label>
                       </ItemTemplate>
                   </asp:TemplateField>
                     <asp:TemplateField HeaderText="<%$Resources:Resource,Status %>" HeaderStyle-Width="300px" HeaderStyle-ForeColor="White"
                        FooterStyle-Width="300px" ItemStyle-Width="300px">
                       <ItemTemplate>
                            <asp:Label ID="lblStatus" CssClass="cssLable" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                       </ItemTemplate>
                   </asp:TemplateField>
                     <asp:TemplateField HeaderText="<%$Resources:Resource,Date %>" HeaderStyle-Width="300px" HeaderStyle-ForeColor="White"
                        FooterStyle-Width="300px" ItemStyle-Width="300px">
                       <ItemTemplate>
                            <asp:Label ID="lblDate" CssClass="cssLable" runat="server" Text='<%# Bind("Date") %>'></asp:Label>
                       </ItemTemplate>
                   </asp:TemplateField>
                     <asp:TemplateField HeaderText="<%$Resources:Resource,Time %>" HeaderStyle-Width="300px" HeaderStyle-ForeColor="White"
                        FooterStyle-Width="300px" ItemStyle-Width="300px">
                       <ItemTemplate>
                            <asp:Label ID="lblTime" CssClass="cssLable" runat="server" Text='<%# Bind("Time") %>'></asp:Label>
                       </ItemTemplate>
                   </asp:TemplateField>
                    <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:Label ID="lblgvhdrEmployeeImage" CssClass="cssLabelHeader" runat="server" Text="Employee Image"></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                        <%--        <img alt="" id="imgEmpImage" height="150" width="150" runat="server" src='<%# DataBinder.Eval(Container.DataItem, "ImageBase64String").ToString()%>' />--%>
                                                  <asp:ImageButton ID="imgEmpImage" runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "ImageBase64String").ToString()%>'
                Width="100px" Height="100px" Style="cursor: pointer" OnClientClick="return LoadDiv(this.src);" />
                                                 
                                            </ItemTemplate>
                                            <ItemStyle Width="100px" />
                                            <HeaderStyle Width="150px" />
                                        </asp:TemplateField>
                 <%--     <asp:TemplateField>
        <ItemTemplate>
          <asp:Image ID="Image1" Height = "100" Width = "100" runat="server"
             ImageUrl = '' />
        </ItemTemplate>
    </asp:TemplateField>--%>
                </Columns>
            </asp:GridView>
                       </div>
                   <asp:HiddenField ID="hfstatus" runat="server" />
       </asp:Panel>
        <div id="divBackground" class="modal">
</div>
<div id="divImage">
<center><table style="height: 90%; width: 100%">
     <tr>
        <td align="right" valign="right">
            <asp:ImageButton id="btnCancel"  runat="server" OnClientClick="HideDiv()" ImageUrl="~/Images/cancel (2).png" />
        </td>
    </tr>
    <tr>
        <td valign="middle" align="center">

            <img id="imgLoader" alt="" src="images/loader.gif" />
            <img id="imgFull" alt="" src="" style="display: none; height: 370px; width: 300px" />
        </td>
    </tr>
  
   <%-- <tr>
        <td align="center" valign="bottom">
            <input id="btnClose" type="button" value="Close" class="cssButton" onclick="HideDiv()" />
        </td>
    </tr>--%>
</table>
    </center>
</div>
        </ContentTemplate>
    </Ajax:UpdatePanel>
     <asp:Button ID="btnExport" runat="server" CssClass="cssButton" ToolTip="<%$ Resources:Resource, ExporttoExcel %>"
                                                    Text=" <%$ Resources:Resource, ExporttoExcel %>" OnClick="btnExport_Click" />
    
</asp:Content>

