<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="TaskMaster.aspx.cs" Inherits="AssetManagement_TaskMaster" %>

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
     <asp:Panel ID="pnlTaskMaster" runat="server"  >
            <center>  <b><asp:Label ID="lblTicketNo" runat="server"   CssClass="cssLabel" style="font-size:larger;color:black;font-weight:900" Text="Task Details" ></asp:Label></b></center>
                  <br />
        <table align="center" width="100%" border="0" cellspacing="0px" cellpadding="0px">
             <tr>
              
                <td style="text-align: right;">
                    <asp:Label ID="lblClientCode" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,ClientCode %>" ></asp:Label>
                </td>
                <td style="text-align: left;">
                     <asp:DropDownList ID="ddlClientCode" runat="server" CssClass="csstxtbox" Width="250px" AutoPostBack="true" OnSelectedIndexChanged="ddlClientCode_SelectedIndexChanged"></asp:DropDownList>
                </td>
                <td style="text-align: right;">
                    <asp:Label ID="lblSiteId" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,AsmtId %>"></asp:Label>
                </td>
                <td style="text-align: left;">
                    <asp:DropDownList ID="ddlSiteId" runat="server" CssClass="csstxtbox" Width="250px" AutoPostBack="true" OnSelectedIndexChanged="ddlSiteId_SelectedIndexChanged"></asp:DropDownList>
                </td>
                <td style="text-align: right;">
                    <asp:Label ID="lblPostCode" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,PostCode %>"></asp:Label>
                </td>
                <td style="text-align: left;">
                       <asp:DropDownList ID="ddlPostCode" runat="server" CssClass="csstxtbox" Width="250px" AutoPostBack="true" OnSelectedIndexChanged="ddlPostCode_SelectedIndexChanged"></asp:DropDownList>
                </td>
                  <td style="text-align: right;">
                    <asp:Label ID="lblActivewef" CssClass="cssLable" Style="width: 100px;" runat="server" Text="Date" ></asp:Label>
                </td>
                  <td style="text-align: left;">
                    <asp:TextBox ID="txtDate" MaxLength="50" Width="150px" CssClass="csstxtbox" 
                        runat="server" OnTextChanged="txtDate_TextChanged" AutoPostBack="true"></asp:TextBox>
                    <asp:ImageButton ID="ImageButton1" Style="vertical-align: middle" runat="server" ImageUrl="~/Images/pdate.gif" Enabled="true"></asp:ImageButton>
                    <AjaxToolKit:CalendarExtender ID="CalendarExtender5" Format="dd-MMM-yyyy" runat="server"
                        TargetControlID="txtDate" PopupButtonID="ImageButton1" Enabled="True"></AjaxToolKit:CalendarExtender>
                   
                </td>
                  <td style="text-align: right;">
                    <asp:Label ID="Label4" CssClass="cssLable" Style="width: 100px;" runat="server" Text="To Date"  Visible="false"></asp:Label>
                </td>
                   <td style="text-align: left;">
                    <asp:TextBox ID="txtToDate" MaxLength="50" Width="150px" CssClass="csstxtbox" 
                        runat="server" OnTextChanged="txtToDate_TextChanged" AutoPostBack="true" Visible="false"></asp:TextBox>
                    <asp:ImageButton ID="ImageButton2" Style="vertical-align: middle" runat="server" ImageUrl="~/Images/pdate.gif" Enabled="true" Visible="false"></asp:ImageButton>
                    <AjaxToolKit:CalendarExtender ID="CalendarExtender1" Format="dd-MMM-yyyy" runat="server"
                        TargetControlID="txtToDate" PopupButtonID="ImageButton2" Enabled="True"></AjaxToolKit:CalendarExtender>
                   
                </td>
            </tr>
               </table>

    <br />
            <asp:GridView ID="gvTaskMaster" Width="70%" CssClass="GridViewStyle" PageSize="20"
                runat="server" AllowPaging="true" CellPadding="1" GridLines="None"
                AutoGenerateColumns="False"
                ShowFooter="True" OnPageIndexChanging="gvTaskMaster_PageIndexChanging" OnRowDataBound="gvTaskMaster_RowDataBound">
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
                   <asp:TemplateField HeaderText="<%$ Resources:Resource,AsmtId %>" HeaderStyle-ForeColor="White">
                    <ItemTemplate>  
                          <asp:HiddenField ID="hfAssetAutoID1" runat="server" Value='<%# Bind("AssetAutoID") %>' />
                                <asp:HiddenField ID="hfAssetScheduleAutoId" runat="server" Value='<%# Bind("AssetScheduleAutoId") %>' />                 
                            <asp:Label ID="lblSiteId" CssClass="cssLabel" runat="server"  Text='<%# Bind("Site") %>'></asp:Label>
                        </ItemTemplate>
                     <HeaderStyle CssClass="cssLabelHeader" Width="150px" />
                        <ItemStyle Width="150px" />
                        <FooterStyle Width="150px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$Resources:Resource,Performer %>" HeaderStyle-Width="300px"
                        FooterStyle-Width="300px" ItemStyle-Width="300px">
                       <ItemTemplate>
                            <asp:Label ID="lblPerformer" CssClass="cssLabel" runat="server"  Text='<%# Bind("Performer") %>'></asp:Label>                        
                       </ItemTemplate>
                   </asp:TemplateField>
                      <asp:TemplateField HeaderText="<%$Resources:Resource,AssetName %>" HeaderStyle-Width="300px"
                        FooterStyle-Width="300px" ItemStyle-Width="300px">
                       <ItemTemplate>
                           
                            <asp:Label ID="lblAssetName" CssClass="cssLabel" runat="server"  Text='<%# Bind("AssetName") %>'></asp:Label>                        
                       </ItemTemplate>
                   </asp:TemplateField>
                     <asp:TemplateField HeaderText="<%$Resources:Resource,TaskList %>" HeaderStyle-Width="300px"
                        FooterStyle-Width="300px" ItemStyle-Width="300px">
                       <ItemTemplate>
                           <asp:HiddenField ID="hfAutoId" runat="server" Value='<%# Bind("TaskListID") %>' />
                            <asp:Label ID="lblTasklist" CssClass="cssLabel" runat="server"  Text='<%# Bind("TaskList") %>'></asp:Label>                        
                       </ItemTemplate>
                   </asp:TemplateField>
                      <asp:TemplateField HeaderText="<%$Resources:Resource,Date %>" HeaderStyle-Width="300px"
                        FooterStyle-Width="300px" ItemStyle-Width="300px">
                       <ItemTemplate>
                         
                            <asp:Label ID="lblDate" CssClass="cssLabel" runat="server"  Text='<%# Bind("DutyDate") %>'></asp:Label>                        
                       </ItemTemplate>
                   </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$Resources:Resource,ViewDetails %>" HeaderStyle-Width="100px"
                        FooterStyle-Width="100px" ItemStyle-Width="100px">
                       <ItemTemplate>
                            <asp:Button ID="btnView" CssClass="cssButton" runat="server"  Text="<%$Resources:Resource,ViewTasks %>" OnClick="btnView_Click"></asp:Button>                        
                       </ItemTemplate>
                   </asp:TemplateField>
                </Columns>
            </asp:GridView>
                   <asp:HiddenField ID="hfstatus" runat="server" />
           <asp:Button ID="btnExport" runat="server" CssClass="cssButton" ToolTip="<%$ Resources:Resource, ExporttoExcel %>"
                                                    Text=" <%$ Resources:Resource, ExporttoExcel %>" OnClick="btnExport_Click" />
       </asp:Panel>
        

    <asp:Panel ID="pnlDailyTask" runat="server"  >
          <center>  <b><asp:Label ID="Label1" runat="server"   CssClass="cssLabel" style="font-size:larger;color:black;font-weight:900" Text="<%$ Resources:Resource,DailyTaskUpdate %>" ></asp:Label></b></center>
       
         <b><asp:Label ID="Label2" runat="server"   CssClass="cssLabel" style="font-size:larger;color:black;font-weight:900" Text="<%$ Resources:Resource,DailyTAskNeedToPerform %>" ></asp:Label></b>
        <asp:HiddenField id="hfPerformerName" runat="server" />
        <br />
    <asp:GridView ID="gvDailyTask" Width="50%" CssClass="GridViewStyle"
                                    runat="server" AllowPaging="true" CellPadding="3" GridLines="None"
                                    AutoGenerateColumns="False" OnRowCancelingEdit="gvDailyTask_RowCancelingEdit"
                                     OnRowDataBound="gvDailyTask_RowDataBound"
                                     OnRowEditing="gvDailyTask_RowEditing" OnRowUpdating="gvDailyTask_RowUpdating"
                                    ShowFooter="true" OnPageIndexChanging="gvDailyTask_PageIndexChanging" PageSize="10">
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
                                    <asp:TemplateField HeaderText="S.No." HeaderStyle-CssClass="cssLabelHeader" HeaderStyle-Width="50px"
                                            FooterStyle-Width="50px" ItemStyle-Width="50px">
                                     <ItemTemplate>
                                <asp:Label ID="lblSerialNo" CssClass="cssLable" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                    </ItemTemplate>
                                    </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$Resources:Resource,CheckListItems %>" HeaderStyle-CssClass="cssLabelHeader" HeaderStyle-Width="150px"
                                            FooterStyle-Width="150px" ItemStyle-Width="150px">
                                            <EditItemTemplate>
                                                <asp:Label ID="lblTaskName" Width="150px" CssClass="cssLable" runat="server" Text='<%# Eval("CheckListItem") %>'></asp:Label>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblTaskName" CssClass="cssLable" Width="150px" runat="server" Text='<%# Bind("CheckListItem") %>'></asp:Label>
                                            </ItemTemplate>
                                         
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,Status %>" HeaderStyle-CssClass="cssLabelHeader" HeaderStyle-Width="150px"
                                            FooterStyle-Width="150px" ItemStyle-Width="150px">
                                            <EditItemTemplate>
                                                <asp:DropDownList ID="ddlStatus" runat="server" Width="150px"  CssClass="cssDropDown">
                                                    <asp:ListItem Text="Pending" Value="Pending"></asp:ListItem>
                                                    <asp:ListItem Text="Completed" Value="Completed"></asp:ListItem>
                                                </asp:DropDownList>
                                                  </EditItemTemplate>
                                              <ItemTemplate>
                                                 <asp:Label ID="lblStatus" CssClass="cssLable" Width="150px" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$Resources:Resource,EditColName %>" HeaderStyle-CssClass="cssLabelHeader" HeaderStyle-Width="50px"
                                            FooterStyle-Width="50px" ItemStyle-Width="50px">
                                            <EditItemTemplate>
                                                <asp:ImageButton ID="ImgbtnUpdate" ToolTip="<%$Resources:Resource,Update %>"
                                                    ImageUrl="~/Images/save.gif" CssClass="csslnkButton" runat="server" CommandName="Update"
                                                    ValidationGroup="EditWarranty" />
                                                <asp:ImageButton ID="ImageButtonCancel" ToolTip="<%$Resources:Resource,Cancel %>"
                                                    ImageUrl="~/Images/Cancel.gif" CssClass="csslnkButton" runat="server" CausesValidation="False"
                                                    CommandName="Cancel" />
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="IBEdit" ToolTip="<%$Resources:Resource,Edit %>" ImageUrl="~/Images/Edit.gif"
                                                    CssClass="csslnkButton" runat="server" CausesValidation="False" CommandName="Edit" />
                                           
                                            </ItemTemplate>
                                          
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="View Task Image" HeaderStyle-Width="150px"
                        FooterStyle-Width="150px" ItemStyle-Width="150px">
                       <ItemTemplate>
                            <asp:Button ID="btnImage" CssClass="cssButton" runat="server"  Text="View Image" OnClick="btnImage_Click"></asp:Button>                        
                       </ItemTemplate>
                   </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
        <asp:HiddenField ID="hfTaskAutoId" runat="server" />
        <asp:HiddenField ID="hfAsmtId" runat="server" />
          <asp:HiddenField ID="hfAssetAutoId" runat="server" />
          <asp:HiddenField ID="hfAutoAssetID" runat="server" />
        <br /> 
          <asp:Label EnableViewState="false" ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg"></asp:Label>
         <br />
        <br />
       <asp:Button ID="btnBack" runat="server" Text="<%$ Resources:Resource,Back %>"  CssClass="cssButton" OnClick="btnBack_Click"/>
      
    </asp:Panel>

    <asp:Panel ID="pnlTaskImage" runat="server" Visible="false" >
         <b><asp:Label ID="Label3" runat="server"   CssClass="cssLabel" style="font-size:larger;color:black;font-weight:900" Text="View Task Image" ></asp:Label></b>
        <br />
        <br />
        <br />
    <asp:GridView ID="gvImage" Width="6%" CssClass="GridViewStyle"
                                    runat="server" AllowPaging="true" CellPadding="3" GridLines="None"
                                    AutoGenerateColumns="False"
                                           ShowFooter="true" OnPageIndexChanging="gvImage_PageIndexChanging" PageSize="5">
                                    <FooterStyle CssClass="GridViewFooterStyle" />
                                    <RowStyle CssClass="GridViewRowStyle" />
                                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                    <PagerStyle CssClass="GridViewPagerStyle" />
                                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                                    <Columns>

                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:Label ID="lblgvhdrEmployeeImage" CssClass="cssLabelHeader" runat="server" Text="Task Image"></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>
<%--                                                <img alt="" id="imgEmpImage" height="300" width="300" runat="server" src='<%# DataBinder.Eval(Container.DataItem, "ImageBase64String").ToString()%>' />--%>
                                                 <asp:ImageButton ID="imgEmpImage" runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "ImageBase64String").ToString()%>'
                Width="100px" Height="100px" Style="cursor: pointer" OnClientClick="return LoadDiv(this.src);" />
                                            </ItemTemplate>
                                            <ItemStyle Width="50px" />
                                            <HeaderStyle Width="50px" />
                                        </asp:TemplateField>

                                    </Columns>
                                </asp:GridView>
      
       
          <asp:Label EnableViewState="false" ID="Label5" runat="server" CssClass="csslblErrMsg"></asp:Label>
       <asp:HiddenField ID="hfImageAutoId" runat="server" Value="0" />
        <br />
       <asp:Button ID="btnbacktaskList" runat="server" Text="<%$ Resources:Resource,Back %>"  CssClass="cssButton" OnClick="btnbacktaskList_Click"/>
      
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
   
</asp:Content>

