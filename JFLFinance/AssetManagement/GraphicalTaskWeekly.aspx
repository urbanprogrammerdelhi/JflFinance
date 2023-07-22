<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="GraphicalTaskWeekly.aspx.cs" Inherits="AssetManagement_GraphicalTaskWeekly" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server"></asp:Content>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script>
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
    <script src="JS/canvasjs.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function openModal() {
            $('#myModal').modal('show');
        }
    </script>
    <style type="text/css">
        .gridcss {
            background: #D3E8F4;
            font-weight: bold;
            color: White;
        }

        .loading {
            font-family: Arial;
            font-size: 10pt;
            border: 5px solid #67CFF5;
            width: 200px;
            height: 100px;
            display: none;
            position: fixed;
            background-color: White;
            z-index: 999;
        }
    </style>        
    <script type="text/javascript">
        var wDate1 = '<%= wDate1 %>'; var wDate2 = '<%= wDate2 %>'; var wDate3 = '<%= wDate3 %>'; var wDate4 = '<%= wDate4 %>'; var wDate5 = '<%= wDate5 %>'; var wDate6 = '<%= wDate6 %>'; var wDate7 = '<%= wDate7 %>'; var wDate8 = '<%= wDate7 %>';
        var wPend1 = <%= wPend1 %>; var wPend2 = <%= wPend2 %>; var wPend3 = <%= wPend3 %>; var wPend4 = <%= wPend4 %>; var wPend5 = <%= wPend5 %>; var wPend6 = <%= wPend6 %>; var wPend7 = <%= wPend7 %>; var wPend8 = <%= wPend7 %>;
        var wComp1 = <%= wComp1 %>; var wComp2 = <%= wComp2 %>; var wComp3 = <%= wComp3 %>; var wComp4 = <%= wComp4 %>; var wComp5 = <%= wComp5 %>; var wComp6 = <%= wComp6 %>; var wComp7 = <%= wComp7 %>; var wComp8 = <%= wComp7 %>;        
        
        window.onload = function () {                                
            var chart = new CanvasJS.Chart("chartContainer",
            {                         
                data: [
                {                        
                    type: "column",
                    click: onClick,
                    dataPoints: [                            
                        { y: wComp1, label: wDate1+", Completed" },
                        { y: wComp2, label: wDate2+", Completed" },
                        { y: wComp3, label: wDate3+", Completed" },
                        { y: wComp4, label: wDate4+", Completed" },                            
                        { y: wComp5, label: wDate5+", Completed" },
                        { y: wComp6, label: wDate6+", Completed" },
                        { y: wComp7, label: wDate7+", Completed" }
                    ]
                },{
                    type: "column",
                    click: onClick,
                    dataPoints: [
                        { y: wPend1, label: wDate1+", Pending" },
                        { y: wPend2, label: wDate2+", Pending" },                    
                        { y: wPend3, label: wDate3+", Pending" },
                        { y: wPend4, label: wDate4+", Pending" },
                        { y: wPend5, label: wDate5+", Pending" },
                        { y: wPend6, label: wDate6+", Pending" },
                        { y: wPend7, label: wDate7+", Pending" }
                    ]
                },{
                    type: "scatter",
                    click: onClick,
                    dataPoints: [
                        { label: wDate1 },
                        { label: wDate2 },                    
                        { label: wDate3 },
                        { label: wDate4 },
                        { label: wDate5 },
                        { label: wDate6 },
                        { label: wDate7 }
                    ]
                }]
            });
            chart.render();
            
            function onClick(e) {
                var id=e.dataPoint.label+','+e.dataPoint.y;
                document.getElementById('<%=hdnTaskDateStatus.ClientID%>').value=id;
                var btnGraph = document.getElementById('<%=btnGraph.ClientID%>');
                btnGraph.click();
            }   
        }                
    </script>    

    <div>
        <input type="button" runat="server" id="btnGraph" onserverclick="btnGraph_Click" style="display: none" />
        <asp:HiddenField ID="hdnTaskDateStatus" runat="server" />
        <table align="left" width="100%" border="0" cellspacing="0px" cellpadding="0px">
            <%--<tr style="background-color: #2E6293;">
                <td></td>
                <td colspan="2" style="text-align: right;">
                    <asp:RadioButton ID="rdoWeek" GroupName="Group1" Text="7 Days Report" Value="Weekly" runat="server" Style="color: white;" />
                </td>
                <td></td>
                <td colspan="4">
                    <asp:RadioButton ID="rdoMonth" GroupName="Group1" Text="30 Days Report" Value="Monthly" runat="server" Style="color: white" />
                </td>
            </tr>--%>
            <tr style="background-color: #D3E8F4">
                <td style="text-align: right;">
                    <asp:Label ID="lblClientCode" CssClass="cssLable" runat="server" Width="80px" Text="<%$ Resources:Resource,ClientCode %>"></asp:Label>
                </td>
                <td style="text-align: left;">
                    <asp:DropDownList ID="ddlClientCode" runat="server" CssClass="csstxtbox" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="ddlClientCode_SelectedIndexChanged"></asp:DropDownList>
                </td>
                <td style="text-align: right;">
                    <asp:Label ID="lblSiteId" CssClass="cssLable" runat="server" Width="35px" Text="<%$ Resources:Resource,AsmtId %>"></asp:Label>
                </td>
                <td style="text-align: left;">
                    <asp:DropDownList ID="ddlSiteId" runat="server" CssClass="csstxtbox" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="ddlSiteId_SelectedIndexChanged"></asp:DropDownList>
                </td>
                <td style="text-align: right;">
                    <asp:Label ID="lblPostCode" CssClass="cssLable" runat="server" Width="50px" Text="<%$ Resources:Resource,PostCode %>"></asp:Label>
                </td>
                <td style="text-align: left;">
                    <asp:DropDownList ID="ddlPostCode" runat="server" CssClass="csstxtbox" Width="150px" AutoPostBack="true" OnSelectedIndexChanged="ddlPostCode_SelectedIndexChanged"></asp:DropDownList>
                </td>
                <td style="text-align: right;">
                    <asp:Label ID="lblActivewef" CssClass="cssLable" Width="55px" runat="server" Text="Date"></asp:Label>
                </td>
                <td style="text-align: left;">
                    <asp:TextBox ID="txtDate" Width="95px" CssClass="csstxtbox" runat="server" OnTextChanged="txtDate_TextChanged" AutoPostBack="true"></asp:TextBox>
                    <asp:ImageButton ID="ImageButton1" Style="vertical-align: middle" runat="server" ImageUrl="~/Images/pdate.gif" Enabled="true"></asp:ImageButton>
                    <AjaxToolKit:CalendarExtender ID="CalendarExtender5" Format="dd-MMM-yyyy" runat="server"
                        TargetControlID="txtDate" PopupButtonID="ImageButton1" Enabled="True"></AjaxToolKit:CalendarExtender>
                </td>
                <%--<td style="text-align: right;">
                    <asp:Label ID="Label4" CssClass="cssLable" Width="45px" runat="server" Text="To Date" Visible="true"></asp:Label>
                </td>
                <td style="text-align: left;">
                    <asp:TextBox ID="txtToDate2" Width="85px" CssClass="csstxtbox" runat="server" OnTextChanged="txtToDate_TextChanged" AutoPostBack="true" Visible="true"></asp:TextBox>
                    <asp:ImageButton ID="ImageButton2" Style="vertical-align: middle" runat="server" ImageUrl="~/Images/pdate.gif" Enabled="true" Visible="true"></asp:ImageButton>
                    <AjaxToolKit:CalendarExtender ID="CalendarExtender1" Format="dd-MMM-yyyy" runat="server"
                        TargetControlID="txtToDate" PopupButtonID="ImageButton2" Enabled="True"></AjaxToolKit:CalendarExtender>
                </td>--%>
            </tr>
            <tr>
                <td>
                    <br />
                </td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td style="text-align: left;">
                    <asp:Image ID="img1" runat="server" Height="18px" ImageUrl="~/AssetManagement/Images/ImgCompleted.png" Width="46px" /></td>
                <td style="text-align: left; color: black; font-weight: 500">Completed</td>
                <td style="text-align: left;">
                    <asp:Image ID="Image1" runat="server" Height="18px" ImageUrl="~/AssetManagement/Images/ImgPending.png" Width="46px" /></td>
                <td style="text-align: left; color: black; font-weight: 500">Pending</td>
            </tr>
            <tr style="visibility: hidden">
                <td style="text-align: right;">
                    <asp:Label ID="Label1" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,Status %>"></asp:Label>
                    <asp:TextBox ID="txtToDate" Width="85px" CssClass="csstxtbox" runat="server" OnTextChanged="txtToDate_TextChanged" AutoPostBack="true" Visible="true"></asp:TextBox>
                </td>
                <td style="text-align: left;">
                    <asp:DropDownList ID="ddlStatus" runat="server" CssClass="csstxtbox" Width="100px" AutoPostBack="true" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged">
                        <asp:ListItem Text="All" Value="All"></asp:ListItem>
                        <asp:ListItem Text="Pending" Value="Pending"></asp:ListItem>
                        <asp:ListItem Text="Completed" Value="Completed"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
    </div>
    <div>
        <br />
    </div>
    <asp:Panel ID="chart" runat="server" Style="margin-left: 0px; margin-top: 90px">
        <div id="chartContainer" style="width: 100%"></div>
    </asp:Panel>
    <table width="100%" align="left">
        <tr>
            <td style="background-color: #9b062e">
                <asp:Label ID="lblNodata" runat="server" Text="Record Not Available!!!" ForeColor="white" Style="margin-left: 5px" />
            </td>
        </tr>
    </table>
    <!-- Popup -->
    <div class="modal fade" id="myModal" role="dialog">        
        <div class="modal-dialog modal-lg">
            <div class="modal-content">                
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <center>
                        <asp:Label ID="lblPopHeader" runat="server" Style="font-weight: bold;" />
                    </center>
                </div>
                <div class="modal-body">
                    <asp:GridView Width="100%" ID="gvdata" CssClass="GridViewStyle" runat="server" ShowFooter="True" AllowPaging="True" PageSize="10" CellPadding="1"
                        GridLines="None" AutoGenerateColumns="False" OnRowDataBound="gvdata_RowDataBound" OnPageIndexChanging="gvdata_PageIndexChanging">
                        <AlternatingRowStyle BackColor="White" />
                        <EditRowStyle BackColor="#DBDDF8" />
                        <%--<FooterStyle BackColor="#D3E8F4" Font-Bold="True" ForeColor="White" />--%>
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
                                    <asp:Label ID="lblSerialNo" CssClass="cssLable" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Post" HeaderStyle-ForeColor="White" HeaderStyle-Width="170px">
                                <ItemTemplate>
                                    <asp:HiddenField ID="hfPostId" runat="server" Value='<%# Bind("PostId") %>' />
                                    <asp:LinkButton ID="lnkView" Width="170px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("Post") %>' CommandName="Post" OnClick="lnkView_Click"></asp:LinkButton>
                                </ItemTemplate>
                                <HeaderStyle CssClass="cssLabelHeader" Width="170px" />
                                <ItemStyle Width="170px" />
                                <FooterStyle Width="170px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="No. of Task" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <asp:Label ID="lblPost" Width="100px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("NoofPost") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                                <ItemStyle Width="100px" />
                                <FooterStyle Width="100px" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <table align="left" width="100%" border="0" cellspacing="0px" cellpadding="0px">
                        <tr style="background-color: #D3E8F4">
                            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                            <td style="text-align: left;">
                                <asp:Label ID="lblHpost" CssClass="cssLable" runat="server" Text="Total Post" Font-Size="10" Style="color: black;" Font-Bold="true"></asp:Label>
                            </td>
                            <td style="text-align: left;" colspan="2">
                                <asp:Label ID="lblTpost" CssClass="cssLable" runat="server" Font-Size="10" Style="color: black;" Font-Bold="true"></asp:Label>
                            </td>
                            <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                        </tr>
                    </table>
                    <br />
                    <br />
                    <asp:GridView Width="100%" ID="data" CssClass="GridViewStyle" runat="server" ShowFooter="True" AllowPaging="True" PageSize="100" CellPadding="1"
                        GridLines="None" AutoGenerateColumns="False" OnRowDataBound="data_RowDataBound" OnPageIndexChanging="data_PageIndexChanging">
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
                            <asp:TemplateField HeaderText="<%$Resources:Resource,SerialNumber %>" HeaderStyle-Width="30px" HeaderStyle-ForeColor="White"
                                FooterStyle-Width="30px" ItemStyle-Width="30px" HeaderStyle-CssClass="cssLabelHeader">
                                <ItemTemplate>
                                    <asp:Label ID="lblSerial" CssClass="cssLable" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="TaskList" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <asp:Label ID="lblTaskList" Width="120px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("TaskList") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="cssLabelHeader" Width="120px" />
                                <ItemStyle Width="120px" />
                                <FooterStyle Width="120px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Site" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <asp:Label ID="lblSite" Width="40px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("Site") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="cssLabelHeader" Width="40px" />
                                <ItemStyle Width="40px" />
                                <FooterStyle Width="40px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Performer" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <asp:Label ID="lblPerformer" Width="120px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("Performer") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="cssLabelHeader" Width="120px" />
                                <ItemStyle Width="120px" />
                                <FooterStyle Width="120px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Post" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <asp:Label ID="lblPost" Width="100px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("Post") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                                <ItemStyle Width="100px" />
                                <FooterStyle Width="100px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="AssetName" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <asp:Label ID="lblAssetName" Width="100px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("AssetName") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                                <ItemStyle Width="100px" />
                                <FooterStyle Width="100px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="TaskName" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <asp:Label ID="lblTaskName" Width="140px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("TaskName") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="cssLabelHeader" Width="140px" />
                                <ItemStyle Width="140px" />
                                <FooterStyle Width="140px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="DutyDate" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <asp:Label ID="lblDutyDate" Width="70px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("DutyDate") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="cssLabelHeader" Width="70px" />
                                <ItemStyle Width="70px" />
                                <FooterStyle Width="70px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Time Slot" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <asp:Label ID="lblTime" Width="70px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("Time") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="cssLabelHeader" Width="70px" />
                                <ItemStyle Width="70px" />
                                <FooterStyle Width="70px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Status" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <asp:Label ID="lblStatus" Width="60px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="cssLabelHeader" Width="60px" />
                                <ItemStyle Width="60px" />
                                <FooterStyle Width="60px" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-primary" data-dismiss="modal">close</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

