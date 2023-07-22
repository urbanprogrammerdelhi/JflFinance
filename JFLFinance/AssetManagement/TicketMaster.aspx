<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="TicketMaster.aspx.cs" Inherits="AssetManagement_TicketMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        body {
            margin: 0;
            padding: 0;
            height: 100%;
        }

        .modal {
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

        #divImage {
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
    <%--<Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">--%>
    <contenttemplate>
            <asp:Panel ID="pnlTicetMaster" runat="server" Visible="true">                
              
                     <table align="left" width="90%" border="0" cellspacing="0px" cellpadding="0px"  >
                    <tr style="background-color: #D3E8F4">
                        <td style="text-align: right;">
                            <asp:Label ID="lblClientCode" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,Status %>" ForeColor="black"></asp:Label>
                        </td>
                        <td style="text-align: left;">
                            <asp:DropDownList ID="ddlStatusMain" runat="server" CssClass="csstxtbox" Width="150px" AutoPostBack="true" OnSelectedIndexChanged="ddlStatusMain_SelectedIndexChanged1" >
                                <asp:ListItem Text="ALL" Value="ALL"></asp:ListItem>
                                <asp:ListItem Text="NEW" Value="NEW"></asp:ListItem>
                                <asp:ListItem Text="Approved" Value="Approved"></asp:ListItem>
                                <asp:ListItem Text="Reject" Value="Reject"></asp:ListItem>
                                <asp:ListItem Text="Closed" Value="Closed"></asp:ListItem>
                            </asp:DropDownList>
                          <%--  <asp:TextBox ID="txtStatusMain" runat="server" AutoPostBack="true" CssClass="csstxtbox" MaxLength="15" OnTextChanged="txtTicketNo_TextChanged" Width="150px" Font-Bold="True" Font-Size="Medium" ReadOnly="True">ALL</asp:TextBox>--%>
                        </td>
                        <td style="text-align: right;">
                            <asp:Label ID="lblPostCode" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,TicketNo %>" ForeColor="black"></asp:Label>
                        </td>
                        <td style="text-align: left;">
                            <asp:TextBox ID="txtTicketNo" MaxLength="15" Width="150px" CssClass="csstxtbox"
                                runat="server" OnTextChanged="txtTicketNo_TextChanged" AutoPostBack="true"></asp:TextBox>
                        </td>
                        <td style="text-align: right;">
                            <asp:Label ID="lblSiteId" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,UserID %>" ForeColor="black"></asp:Label>
                        </td>
                        <td style="text-align: left;">
                            <asp:TextBox ID="txtUserId" MaxLength="30" Width="150px" CssClass="csstxtbox"
                                runat="server" OnTextChanged="txtUserId_TextChanged" AutoPostBack="true"></asp:TextBox>
                        </td>
                        
                        <%-- <td style="text-align: right;">
                    <asp:Label ID="lblActivewef" CssClass="cssLable" Style="width: 100px;" runat="server" Text="From Date"></asp:Label>
                </td>
                 <td style="text-align: left;">
                    <asp:TextBox ID="txtFromDate" MaxLength="50" Width="150px" CssClass="csstxtbox" 
                        runat="server" OnTextChanged="txtFromDate_TextChanged" AutoPostBack="true"></asp:TextBox>
                    <asp:ImageButton ID="ImageButton2" Style="vertical-align: middle" runat="server" ImageUrl="~/Images/pdate.gif" Enabled="true"></asp:ImageButton>
                    <AjaxToolKit:CalendarExtender ID="CalendarExtender1" Format="dd-MMM-yyyy" runat="server"
                        TargetControlID="txtFromDate" PopupButtonID="ImageButton2" Enabled="True"></AjaxToolKit:CalendarExtender>                   
                </td>--%>
                        <td style="text-align: right;">
                            <asp:Label ID="Label2" CssClass="cssLable" Style="width: 100px;" runat="server" Text="From Date" ForeColor="black"></asp:Label>
                        </td>
                        <td style="text-align: left;">
                            <asp:TextBox ID="txtDate" MaxLength="50" Width="80px" CssClass="csstxtbox"
                                runat="server" OnTextChanged="txtDate_TextChanged" AutoPostBack="true"></asp:TextBox>
                            <asp:ImageButton ID="ImageButton1" Style="vertical-align: middle" runat="server" ImageUrl="~/Images/pdate.gif" Enabled="true" BorderStyle="None"></asp:ImageButton>
                            <AjaxToolKit:CalendarExtender ID="CalendarExtender5" Format="dd-MMM-yyyy" runat="server"
                                TargetControlID="txtDate" PopupButtonID="ImageButton1" Enabled="True"></AjaxToolKit:CalendarExtender>
                        </td>
                        <td style="text-align: right;">
                            <asp:Label ID="Label3" CssClass="cssLable" Style="width: 100px;" runat="server" Text="To Date" ForeColor="black"></asp:Label>
                        </td>
                        <td style="text-align: left;">
                            <asp:TextBox ID="txtToDate" MaxLength="50" Width="80px" CssClass="csstxtbox"
                                runat="server" OnTextChanged="txtToDate_TextChanged" AutoPostBack="true"></asp:TextBox>
                            <asp:ImageButton ID="ImageButton4" Style="vertical-align: middle" runat="server" ImageUrl="~/Images/pdate.gif" Enabled="true"></asp:ImageButton>
                            <AjaxToolKit:CalendarExtender ID="CalendarExtender3" Format="dd-MMM-yyyy" runat="server"
                                TargetControlID="txtToDate" PopupButtonID="ImageButton4" Enabled="True"></AjaxToolKit:CalendarExtender>
                        </td>
                         <%--  <td style="text-align: left;">
                           <asp:Button ID="btnsearchticket" runat="server" Text="Search Ticket" CssClass="cssButton" />
                        </td>--%>
                    </tr>
                </table>
                <br />
                <table align="left" width="90%" border="0" cellspacing="0px" cellpadding="0px" style="margin-top:10px">
                    <tr>
                        <td style="text-align: right;">
                            <asp:ImageButton ID="imgbtnTotalticket" runat="server" Height="80px" ImageUrl="~/Images/tTicket.png" Width="91px" OnClick="imgbtnTotalticket_Click"/>
                        </td>
                        <td style="text-align: center;">
                            <asp:Label ID="tTicketlbl" runat="server" Text="Total Ticket" /><br />
                            <asp:Label ID="tTicketValuelbl" runat="server" Text="-" Font-Bold="true" ForeColor="Black" />
                        </td>

                        <td style="text-align: right;">
                            <asp:ImageButton ID="imgbtnNewticket" runat="server" Height="80px" ImageUrl="~/Images/nTicket.png" Width="91px" OnClick="imgbtnNewticket_Click"/>
                        </td>
                        <td style="text-align: center;">
                            <asp:Label ID="nTicketlbl" runat="server" Text="New Ticket" /><br />
                            <asp:Label ID="nTicketValuelbl" runat="server" Text="-" Font-Bold="true" ForeColor="Black" />
                        </td>

                        <td style="text-align: right;">
                            <asp:ImageButton ID="imgbtnApprovedticket" runat="server" Height="80px" ImageUrl="~/Images/aTicket.png" Width="91px" onclick="imgbtnApprovedticket_Click"/>
                        </td>
                        <td style="text-align: center;">
                            <asp:Label ID="aTicketlbl" runat="server" Text="Approve Ticket" /><br />
                            <asp:Label ID="aTicketValuelbl" runat="server" Text="-" Font-Bold="true" ForeColor="Black" />
                        </td>

                        <td style="text-align: right;">
                            <asp:ImageButton ID="imgbtnCloseticket" runat="server" Height="80px" ImageUrl="~/Images/cticket.png" Width="91px" onclick="imgbtnCloseticket_Click1"/>
                        </td>
                        <td style="text-align: center;">
                            <asp:Label ID="cTicketlbl" runat="server" Text="Close Ticket" /><br />
                            <asp:Label ID="cTicketValuelbl" runat="server" Text="-" Font-Bold="true" ForeColor="Black" />
                        </td>

                        <td style="text-align: right;">
                            <asp:ImageButton ID="imgbtnRejectticket" runat="server" Height="80px" ImageUrl="~/Images/Oticket.png" Width="91px" onclick="imgbtnRejectticket_Click"/>
                        </td>
                        <td style="text-align: center;">
                            <asp:Label ID="rTicketlbl" runat="server" Text="Reject Ticket" /><br />
                            <asp:Label ID="rTicketValuelbl" runat="server" Text="-" Font-Bold="true" ForeColor="Black" />
                        </td>
                    </tr>
                </table>
                      
                <br />
                <br />
                              
                <br />
                <br />
                <asp:UpdatePanel ID="pnlGrd" runat="server" UpdateMode="Conditional" align="left" width="90%" border="0" cellspacing="0px" cellpadding="0px">
                    <ContentTemplate>
                        <br />
                            <br /> <br />
                          
                        <asp:GridView ID="gvTicketMaster" Width="90%" CssClass="GridViewStyle" PageSize="10" runat="server" AllowPaging="True" CellPadding="4" 
                            GridLines="None" AutoGenerateColumns="False" OnRowDataBound="gvTicketMaster_RowDataBound" showFooter="True" 
                            OnPageIndexChanging="gvTicketMaster_PageIndexChanging" ForeColor="#333333">
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
                            
                                 <asp:TemplateField HeaderText="<%$Resources:Resource,SerialNumber %>" HeaderStyle-Width="50px" HeaderStyle-ForeColor="White"
                        FooterStyle-Width="50px" ItemStyle-Width="50px" HeaderStyle-CssClass="cssLabelHeader">
                        <ItemTemplate>
                            <asp:Label ID="lblSerialNo" CssClass="cssLabel" runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$ Resources:Resource,TicketNo %>" HeaderStyle-Width="300px"
                                    FooterStyle-Width="300px" ItemStyle-Width="300px">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lblTicketNo" CssClass="cssLabel" CausesValidation="false" runat="server" Text='<%# Bind("AssetWONo") %>' OnClick="lblTicketNo_Click"></asp:LinkButton>
                                    </ItemTemplate>
                                    <HeaderStyle Width="300px" />
                                    <ItemStyle Width="300px" />
                                    <FooterStyle Width="300px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$Resources:Resource,Status %>" HeaderStyle-Width="300px"
                                    FooterStyle-Width="300px" ItemStyle-Width="300px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTicketStatus" CssClass="cssLable" runat="server" Text='<%# Bind("WOstatus") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterStyle Width="300px" />
                                    <HeaderStyle Width="300px" />
                                    <ItemStyle Width="300px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$Resources:Resource,UserID %>" HeaderStyle-Width="400px"
                                    FooterStyle-Width="400px" ItemStyle-Width="400px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUserID" CssClass="cssLable" runat="server" Text='<%# Bind("UserId") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterStyle Width="400px" />
                                    <HeaderStyle Width="400px" />
                                    <ItemStyle Width="400px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$Resources:Resource,DateOfCreation %>" HeaderStyle-Width="300px"
                                    FooterStyle-Width="300px" ItemStyle-Width="300px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDate" CssClass="cssLable" runat="server" Text='<%# Bind("Date") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterStyle Width="300px" />
                                    <HeaderStyle Width="300px" />
                                    <ItemStyle Width="300px" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <br />
                <table align="left" width="90%" border="0" cellspacing="0px" cellpadding="0px">
                    <tr>
                        <td style="background-color: #9b062e">
                            <asp:Label ID="lblmsg" runat="server" Text="Ticket Not Available!!!" ForeColor="white" Font-Size="Small" Style="margin-left: 1px" />
                        </td>
                        <td>
                            <asp:Button ID="btnExport" runat="server" CssClass="cssButton" ToolTip="<%$ Resources:Resource, ExporttoExcel %>"
                    Text=" <%$ Resources:Resource, ExporttoExcel %>" OnClick="btnExport_Click"  />
                              <asp:Button ID="btnGenerateTicket" runat="server" CssClass="cssButton"  Text="Generate Ticket" OnClick="btnGenerateTicket_Click"/>
                   
                     <asp:Button ID="btnSchedule" runat="server" CssClass="cssButton" OnClick="btnSchedule_Click" Text="Schedule Ticket"  />
                        </td>
                    </tr>
                </table>
                
                <asp:HiddenField ID="hfstatus" runat="server" />
            </asp:Panel>
            <br />
            <asp:Panel ID="pnlTicketDetail" runat="server" Visible="false">
                <center>
                    <b>
                        <asp:Label ID="lblTicket" runat="server" Text="Ticket No : " CssClass="cssLabel" Style="font-size:x-large; color: black; font-weight: 900"></asp:Label>
                        <asp:Label ID="lblTicketNo" runat="server" CssClass="cssLabel" Style="font-size: x-large; color: black; font-weight: 900; text-decoration:dotted "></asp:Label></b></center>
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
                        <td style="text-align: left;">
                            <asp:DropDownList ID="ddlStatus" Width="150px" CssClass="cssDropDown" runat="server" style="color:#ED1D22;font-size:large;font-weight:500">
                                <asp:ListItem Text="Approved" Value="Approved"></asp:ListItem>
                                <asp:ListItem Text="Reject" Value="Reject"></asp:ListItem>
                            </asp:DropDownList>
                              <asp:Label ID="lblStatus1" CssClass="cssLabel" runat="server" Width="500px" style="color:#ED1D22;font-size:large;font-weight:500" Visible="false"></asp:Label>
                        </td>
                    </tr>
                </table>
                <div>
                    <center>
                        <asp:Button ID="btnUpdate" runat="server" Text="<%$ Resources:Resource,Update %>" CssClass="cssButton" OnClick="btnUpdate_Click1" />
                        <asp:Button ID="btnBack" runat="server" Text="<%$ Resources:Resource,Back %>" CssClass="cssButton" OnClick="btnBack_Click" />
                    </center>
                    &nbsp;
                </div>
                <br />
                <asp:Label EnableViewState="false" ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg"></asp:Label>
            </asp:Panel>
            <div id="divBackground" class="modal"></div>
            <div id="divImage">
                <center>
                    <table style="height: 90%; width: 100%">
                        <tr>
                            <td align="right" valign="right">
                                <asp:ImageButton ID="btnCancel" runat="server" OnClientClick="HideDiv()" ImageUrl="~/Images/cancel (2).png" />
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
        </contenttemplate>
    <%--</Ajax:UpdatePanel>--%>
</asp:Content>
