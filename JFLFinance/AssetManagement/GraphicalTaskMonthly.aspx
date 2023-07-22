<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="GraphicalTaskMonthly.aspx.cs" Inherits="AssetManagement_GraphicalTaskMonthly" %>

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
        var Date1 = '<%= Date1 %>'; var Date2 = '<%= Date2 %>'; var Date3 = '<%= Date3 %>'; var Date4 = '<%= Date4 %>'; var Date5 = '<%= Date5 %>'; var Date6 = '<%= Date6 %>'; var Date7 = '<%= Date7 %>'; var Date8 = '<%= Date8 %>'; var Date9 = '<%= Date9 %>'; var Date10 = '<%= Date10 %>';
        var Date11 = '<%= Date11 %>'; var Date12 = '<%= Date12 %>'; var Date13 = '<%= Date13 %>'; var Date14 = '<%= Date14 %>'; var Date15 = '<%= Date15 %>'; var Date16 = '<%= Date16 %>'; var Date17 = '<%= Date17 %>'; var Date18 = '<%= Date18 %>'; var Date19 = '<%= Date19 %>'; var Date20 = '<%= Date20 %>';
        var Date21 = '<%= Date21 %>'; var Date22 = '<%= Date22 %>'; var Date23 = '<%= Date23 %>'; var Date24 = '<%= Date24 %>'; var Date25 = '<%= Date25 %>'; var Date26 = '<%= Date26 %>'; var Date27 = '<%= Date27 %>'; var Date28 = '<%= Date28 %>'; var Date29 = '<%= Date29 %>'; var Date30 = '<%= Date30 %>';
        
        var Pend1 = <%= Pend1 %>; var Pend2 = <%= Pend2 %>; var Pend3 = <%= Pend3 %>; var Pend4 = <%= Pend4 %>; var Pend5 = <%= Pend5 %>; var Pend6 = <%= Pend6 %>; var Pend7 = <%= Pend7 %>; var Pend8 = <%= Pend8 %>; var Pend9 = <%= Pend9 %>; var Pend10 = <%= Pend10 %>;
        var Pend11 = <%= Pend11 %>; var Pend12 = <%= Pend12 %>; var Pend13 = <%= Pend13 %>; var Pend14 = <%= Pend14 %>; var Pend15 = <%= Pend15 %>; var Pend16 = <%= Pend16 %>; var Pend17 = <%= Pend17 %>; var Pend18 = <%= Pend18 %>; var Pend19 = <%= Pend19 %>; var Pend20 = <%= Pend20 %>;
        var Pend21 = <%= Pend21 %>; var Pend22 = <%= Pend22 %>; var Pend23 = <%= Pend23 %>; var Pend24 = <%= Pend24 %>; var Pend25 = <%= Pend25 %>; var Pend26 = <%= Pend26 %>; var Pend27 = <%= Pend27 %>; var Pend28 = <%= Pend28 %>; var Pend29 = <%= Pend29 %>; var Pend30 = <%= Pend30 %>;
        
        var Comp1 = <%= Comp1 %>; var Comp2 = <%= Comp2 %>; var Comp3 = <%= Comp3 %>; var Comp4 = <%= Comp4 %>; var Comp5 = <%= Comp5 %>; var Comp6 = <%= Comp6 %>; var Comp7 = <%= Comp7 %>; var Comp8 = <%= Comp8 %>; var Comp9 = <%= Comp9 %>; var Comp10 = <%= Comp10 %>;
        var Comp11 = <%= Comp11 %>; var Comp12 = <%= Comp12 %>; var Comp13 = <%= Comp13 %>; var Comp14 = <%= Comp14 %>; var Comp15 = <%= Comp15 %>; var Comp16 = <%= Comp16 %>; var Comp17 = <%= Comp17 %>; var Comp18 = <%= Comp18 %>; var Comp19 = <%= Comp19 %>; var Comp20 = <%= Comp20 %>;
        var Comp21 = <%= Comp21 %>; var Comp22 = <%= Comp22 %>; var Comp23 = <%= Comp23 %>; var Comp24 = <%= Comp24 %>; var Comp25 = <%= Comp25 %>; var Comp26 = <%= Comp26 %>; var Comp27 = <%= Comp27 %>; var Comp28 = <%= Comp28 %>; var Comp29 = <%= Comp29 %>; var Comp30 = <%= Comp30 %>;
        
        window.onload = function () {                                
            var chart = new CanvasJS.Chart("chartContainer",
            {                         
                data: [
                {                        
                    type: "column",
                    click: onClick,
                    dataPoints: [                            
                        { y: Comp1, label: Date1+", Completed" },{ y: Comp2, label: Date2+", Completed" },{ y: Comp3, label: Date3+", Completed" },
                        { y: Comp4, label: Date4+", Completed" },{ y: Comp5, label: Date5+", Completed" },{ y: Comp6, label: Date6+", Completed" },
                        { y: Comp7, label: Date7+", Completed" },{ y: Comp8, label: Date8+", Completed" },{ y: Comp9, label: Date9+", Completed" },
                        { y: Comp10, label: Date10+", Completed" },{ y: Comp11, label: Date11+", Completed" },{ y: Comp12, label: Date12+", Completed" },
                        { y: Comp13, label: Date13+", Completed" },{ y: Comp14, label: Date14+", Completed" },{ y: Comp15, label: Date15+", Completed" },
                        { y: Comp16, label: Date16+", Completed" },{ y: Comp17, label: Date17+", Completed" },{ y: Comp18, label: Date18+", Completed" },
                        { y: Comp19, label: Date19+", Completed" },{ y: Comp20, label: Date20+", Completed" },{ y: Comp21, label: Date21+", Completed" },
                        { y: Comp22, label: Date22+", Completed" },{ y: Comp23, label: Date23+", Completed" },{ y: Comp24, label: Date24+", Completed" },
                        { y: Comp25, label: Date25+", Completed" },{ y: Comp26, label: Date26+", Completed" },{ y: Comp27, label: Date27+", Completed" },
                        { y: Comp28, label: Date28+", Completed" },{ y: Comp29, label: Date29+", Completed" },{ y: Comp30, label: Date30+", Completed" }
                    ]
                },{
                    type: "column",
                    click: onClick,
                    dataPoints: [
                        { y: Pend1, label: Date1+", Pending" },{ y: Pend2, label: Date2+", Pending" },{ y: Pend3, label: Date3+", Pending" },
                        { y: Pend4, label: Date4+", Pending" },{ y: Pend5, label: Date5+", Pending" },{ y: Pend6, label: Date6+", Pending" },
                        { y: Pend7, label: Date7+", Pending" },{ y: Pend8, label: Date8+", Pending" },{ y: Pend9, label: Date9+", Pending" },
                        { y: Pend10, label: Date10+", Pending" },{ y: Pend11, label: Date11+", Pending" },{ y: Pend12, label: Date12+", Pending" },
                        { y: Pend13, label: Date13+", Pending" },{ y: Pend14, label: Date14+", Pending" },{ y: Pend15, label: Date15+", Pending" },
                        { y: Pend16, label: Date16+", Pending" },{ y: Pend17, label: Date17+", Pending" },{ y: Pend18, label: Date18+", Pending" },
                        { y: Pend19, label: Date19+", Pending" },{ y: Pend20, label: Date20+", Pending" },{ y: Pend21, label: Date21+", Pending" },
                        { y: Pend22, label: Date22+", Pending" },{ y: Pend23, label: Date23+", Pending" },{ y: Pend24, label: Date24+", Pending" },
                        { y: Pend25, label: Date25+", Pending" },{ y: Pend26, label: Date26+", Pending" },{ y: Pend27, label: Date27+", Pending" },
                        { y: Pend28, label: Date28+", Pending" },{ y: Pend29, label: Date29+", Pending" },{ y: Pend30, label: Date30+", Pending" }
                    ]
                }
                ,{
                    type: "scatter",
                    click: onClick,
                    dataPoints: [
                        { label: Date1 },{ label: Date2 },{ label: Date3 },{ label: Date4 },{ label: Date5 },{ label: Date6 },{ label: Date7 },{ label: Date8 },
                        { label: Date9 },{ label: Date10 },{ label: Date11 },{ label: Date12 },{ label: Date13 },{ label: Date14 },{ label: Date15 },{ label: Date16 },
                        { label: Date17 },{ label: Date18 },{ label: Date19 },{ label: Date20 },{ label: Date21 },{ label: Date22 },{ label: Date23 },{ label: Date24 },
                        { label: Date25 },{ label: Date26 },{ label: Date27 },{ label: Date28 },{ label: Date29 },{ label: Date30 }
                    ]
                }
                ]
            });
            chart.render();
            
            function onClick(e) {
                var id=e.dataPoint.label+','+e.dataPoint.y;
                //alert(id);
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
        <div id="chartContainer" style="width: 200%"></div>
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
                                <asp:Label ID="lblHpost" CssClass="cssLable" runat="server" Text="Total Task" Font-Size="10" Style="color: black;" Font-Bold="true"></asp:Label>
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

