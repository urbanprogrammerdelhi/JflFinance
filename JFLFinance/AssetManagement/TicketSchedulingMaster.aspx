<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="TicketSchedulingMaster.aspx.cs" Inherits="AssetManagement_TicketSchedulingMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <asp:HiddenField ID="hfClientCode" runat="server" />
           <asp:HiddenField ID="hfAsmtID" runat="server" />
  <asp:HiddenField ID="hfTicketNo" runat="server" />
     <div class="squareboxgradientcaption" style="height: 25px; background-color: #2E6293;">
        <asp:Label ID="Label1" CssClass="cssLabelHeader" Style="font-size: medium;" runat="server" Text="Ticket Detail" ForeColor="White"></asp:Label>
    </div>
             <center>  <b> <asp:Label ID="lblTicket" runat="server"  Text="Ticket No : " CssClass="cssLabel" style="font-size:x-large;color:black;font-weight:900;"></asp:Label>   <asp:Label ID="lblTicketNo" runat="server"   CssClass="cssLabel" style="font-size:x-large;color:black;font-weight:900"></asp:Label></b></center>
                 <br /> 
                <br />
         <table align="center" width="100%" border="0" cellspacing="0px" cellpadding="0px">
                    <tr>
                        <td rowspan="6" id="spanImage" runat="server">
                            <%--  <asp:Image ID="ImageBox" runat="server" Height="120px" ImageUrl="~/Images/NoImageAvailable.jpg" Style="margin-top: 6px; margin-left: 12px;" Width="210px" Visible="true" />--%>
                            <asp:ImageButton ID="ImageBox" runat="server" ImageUrl="~/Images/NoImageAvailable.jpg"
                                Width="120px" Height="150px" Style="cursor: pointer; margin-top: 6px; margin-left: 12px;" OnClientClick="return LoadDiv(this.src);" />

                            <%--   <asp:FileUpload ID="FileUploadAsset" Width="230px" CssClass="csstxtbox" runat="server" />
                    <asp:RegularExpressionValidator ID="uplValidator" runat="server"
                        ControlToValidate="FileUploadAsset" SetFocusOnError="True" ErrorMessage="* .bmp, .gif, .png, .jpeg and .jpg formats are allowed" Style="color: red;"
                        ValidationExpression="(.+\.([Bb][Mm][Pp])|.+\.([Gg][Ii][Ff])|.+\.([Pp][Nn][Gg])|.+\.([Jj][Pp][Ee][Gg])|.+\.([Jj][Pp][Gg]))">
                    </asp:RegularExpressionValidator>
                    <asp:Button ID="btnUpload" CssClass="cssButton" Style="margin-left: 65px;" runat="server" Text="<%$ Resources:Resource,Upload %>" OnClick="btnUpload_Click" />
                    <asp:Label ID="lblImageUrl" Visible="false" runat="server" CssClass="csslblErrMsg"></asp:Label>--%>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right;">
                         <asp:Label ID="lblClientName" CssClass="cssLable" runat="server" Text="Restaurant Name -" style="color:#2E6293;font-size:large;font-weight:600" Width="200px"></asp:Label>
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="txtClientName" CssClass="cssLabel" runat="server" Width="500px" style="color:#ED1D22;font-size:large;font-weight:500"></asp:Label>
                        </td>
                          <td style="text-align: right;">
                            <asp:Label ID="lblDOC" CssClass="cssLable" runat="server" Text="Date of creation -" style="color:#2E6293;font-size:large;font-weight:600"></asp:Label>
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="txtDOC" CssClass="cssLabel" runat="server" style="color:#ED1D22;font-size:large;font-weight:500"></asp:Label>
                        </td>
                      
                    </tr>
                    <tr>
                        <td style="text-align: right;">
                            <asp:Label ID="lblSiteName" CssClass="cssLable" runat="server" Text="Restaurant Address -" style="color:#2E6293;font-size:large;font-weight:600"></asp:Label>
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="txtSiteName" CssClass="cssLabel" runat="server" Width="500px" style="color:#ED1D22;font-size:large;font-weight:500"></asp:Label>
                        </td>
                        
                        <td style="text-align: right;" nowrap="nowrap">
                            <asp:Label ID="lblSummary" Width="180px" CssClass="cssLable" runat="server" Text="Summary of Issues -" style="color:#2E6293;font-size:large;font-weight:600"></asp:Label>
                        </td>
                        <td style="text-align: left;" nowrap="nowrap">
                            <asp:Label ID="txtSummary" CssClass="cssLabel" runat="server" Width="500px" style="color:#ED1D22;font-size:large;font-weight:500"></asp:Label>
                        </td>
                       
                    </tr>
                    <tr>
                         <td style="text-align: right;">
                            <asp:Label ID="lblDesc" CssClass="cssLable" runat="server" Text="Desscription of Issues -" style="color:#2E6293;font-size:large;font-weight:600"></asp:Label>
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="txtDesc" CssClass="cssLabel" runat="server" Width="500px" style="color:#ED1D22;font-size:large;font-weight:500"></asp:Label>
                        </td>
                        <td style="text-align: right;">
                            <asp:Label ID="lblSeverity" CssClass="cssLable" runat="server" Text="Severity -" style="color:#2E6293;font-size:large;font-weight:600"></asp:Label>
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="txtSeverity" CssClass="cssLabel" runat="server" Width="500px" style="color:#ED1D22;font-size:large;font-weight:500"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right;">
                            <asp:Label ID="lblCommecialValue" CssClass="cssLable" runat="server" Text="Commercial Value -" style="color:#2E6293;font-size:large;font-weight:600"></asp:Label>
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="txtCommercialValue" CssClass="cssLabel" runat="server" Width="500px" style="color:#ED1D22;font-size:large;font-weight:500"></asp:Label>
                        </td>
                        <td style="text-align: right;">
                            <asp:Label ID="lblStatus" CssClass="cssLable" runat="server" Text="Status -" style="color:#2E6293;font-size:large;font-weight:600"></asp:Label>
                        </td>
                        <td>
                                                <asp:Label ID="txtStatus" CssClass="cssLabel" runat="server" Width="500px" style="color:#ED1D22;font-size:large;font-weight:500"></asp:Label>   
                        </td>
                       
                    </tr>
                </table>

                  <div >

    <%--   <center>     <asp:Button ID="btnUpdate" runat="server" Text="<%$ Resources:Resource,Update %>"  CssClass="cssButton" OnClick="btnUpdate_Click" Visible="false"/>
                         <asp:Button ID="btnBack" runat="server" Text="<%$ Resources:Resource,Back %>"  CssClass="cssButton" OnClick="btnBack_Click"/></center>--%>
                      &nbsp;</div>
                <br />
                 <asp:Label EnableViewState="false" ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg"></asp:Label>
      
    <div class="squareboxgradientcaption" style="height: 25px; background-color: #D3E8F4;">
        <asp:Label ID="Label2" CssClass="cssLabelHeader" Style="font-size: medium;" runat="server" Text="<%$ Resources:Resource, Schedule %>"></asp:Label>

    </div>
   
    <table border="0" width="80%" class="table table-hover">
     
        <tr>
            <td align="right" style="width: 200px">
                <asp:Label ID="lblHdrEmployeeNumber" runat="server" CssClass="cssLabelHeader" Text="Employee Number :" style="color:#2E6293;font-size:large;font-weight:600"></asp:Label>
            </td>
            <td align="left" style="width: 200px">
                <asp:Label ID="lblSchEmployeeNumber" runat="server" CssClass="cssLabel" style="color:#ED1D22;font-size:large;font-weight:500"></asp:Label>
            </td>
            <td align="right" style="width: 200px">
                <asp:Label ID="lblHdrEmployeeName" runat="server" CssClass="cssLabelHeader" Text="Employee Name : " style="color:#2E6293;font-size:large;font-weight:600"></asp:Label>
            </td>
            <td align="left" style="width:200px">
                <asp:Label ID="lblSchEmployeeName" runat="server" CssClass="cssLabel" style="color:#ED1D22;font-size:large;font-weight:500"></asp:Label>
            </td>
            <td align="center">
                <asp:Button ID="btnSaveSchedule" runat="server" Text="<%$Resources:Resource,Schedule %>" CssClass="cssButton" OnClick="btnSaveSchedule_Click" />
                <asp:Button ID="btnBack" runat="server" Text="<%$Resources:Resource,Back %>" CssClass="cssButton" OnClick="btnBack_Click" style="margin-left:20px"/>
            </td>
        </tr>
        </table>

    <div class="squareboxgradientcaption" style="height: 25px; background-color: #D3E8F4;">
        <asp:Label ID="Label3" CssClass="cssLabelHeader" Style="font-size: medium;" runat="server" Text="<%$ Resources:Resource,EmployeeSearch %>"></asp:Label>
    </div>
        <asp:GridView Width="100%" ID="gvSelectEmployee" CssClass="GridViewStyle" runat="server" ShowFooter="True" AllowPaging="True" PageSize="10" CellPadding="1" GridLines="None"
            AutoGenerateColumns="False" OnPageIndexChanging="gvSelectEmployee_PageIndexChanging" >
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
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Label ID="lblaction" runat="server" CssClass="cssLabelHeader" Text="<%$ Resources:Resource, Select %>" ForeColor="White"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:RadioButton ID="rbSelectEmployee" AutoPostBack="true" runat="server" OnCheckedChanged="rbSelectEmployee_CheckedChanged" onclick="checkRadioBtn(this);" />
                    </ItemTemplate>
                    <HeaderStyle CssClass="cssLabelHeader" Width="50px" />
                    <ItemStyle Width="50px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:Resource,EmployeeNumber %>" HeaderStyle-ForeColor="White">
                    <ItemTemplate>
                        <asp:Label ID="lblEmployeeNumber" Width="100px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("EmployeeNumber") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                    <ItemStyle Width="100px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:Resource,EmployeeName %>" HeaderStyle-ForeColor="White">
                    <ItemTemplate>
                        <asp:Label ID="lblEmployeeName" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("EmployeeName") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                    <ItemStyle Width="200px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:Resource,Designation %>" HeaderStyle-ForeColor="White">
                    <ItemTemplate>
                        <asp:Label ID="lblDesignation" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("Designation") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                    <ItemStyle Width="200px" />
                </asp:TemplateField>
               
            </Columns>
        </asp:GridView>
        <asp:Label ID="lblError" runat="server" style="color:red"></asp:Label>

 

    <script type="text/javascript">
        function checkRadioBtn(id) {
            var gv = document.getElementById('<%=gvSelectEmployee.ClientID %>');

        for (var i = 1; i < gv.rows.length; i++) {
            var radioBtn = gv.rows[i].cells[0].getElementsByTagName("input");

            // Check if the id not same
            if (radioBtn[0] != null && radioBtn[0].id != id.id) {
                radioBtn[0].checked = false;
            }
        }
        return;
    }
</script>
</asp:Content>

