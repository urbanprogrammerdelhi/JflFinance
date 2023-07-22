<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dashBoard.aspx.cs" Inherits="Testpages_dashBoard"
    MasterPageFile="~/MasterPage/MasterPage.master" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
       
            <asp:Panel ID="PanelMonth" Width="800px" BorderWidth="0px" runat="server">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label ID="Label20" runat="server" Text="<%$ Resources:Resource, Month %>" CssClass="cssLable"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlMonth" runat="server" CssClass="cssDropDown" Width="150px"
                                        >
                                        <asp:ListItem Text="<%$ Resources:Resource,January%>" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="<%$ Resources:Resource,February%>" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="<%$ Resources:Resource,March%>" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="<%$ Resources:Resource,April%>" Value="4"></asp:ListItem>
                                        <asp:ListItem Text="<%$ Resources:Resource,May%>" Value="5"></asp:ListItem>
                                        <asp:ListItem Text="<%$ Resources:Resource,June%>" Value="6"></asp:ListItem>
                                        <asp:ListItem Text="<%$ Resources:Resource,July%>" Value="7"></asp:ListItem>
                                        <asp:ListItem Text="<%$ Resources:Resource,August%>" Value="8"></asp:ListItem>
                                        <asp:ListItem Text="<%$ Resources:Resource,September%>" Value="9"></asp:ListItem>
                                        <asp:ListItem Text="<%$ Resources:Resource,October%>" Value="10"></asp:ListItem>
                                        <asp:ListItem Text="<%$ Resources:Resource,November%>" Value="11"></asp:ListItem>
                                        <asp:ListItem Text="<%$ Resources:Resource,December%>" Value="12"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:TextBox ID="txtYear" runat="server" Width="50px" CssClass="csstxtbox"  MaxLength="4"
                                        OnKeyUp="javascript:validateNumeric(this);" ></asp:TextBox>
                                    <AjaxToolKit:MaskedEditExtender runat="server" ID="MaskedEditExtender2" TargetControlID="txtyear"
                                        Mask="9999" MaskType="Number" ClearTextOnInvalid="false" InputDirection="LeftToRight" />
                                    <AjaxToolKit:MaskedEditValidator runat="server" ID="MaskedEditValidator" IsValidEmpty="false"
                                       MinimumValue="1753" MinimumValueMessage="Year should be greater than equal to 1753" ControlExtender="MaskedEditExtender2" ControlToValidate="txtYear" ErrorMessage="enter valid year"
                                        MaximumValue='9998' MaximumValueMessage="Year should be less than equal to 9998" EmptyValueMessage="Number is required" />
                                </td>
                            </tr>
                            <tr>
                            <td>
                            <asp:HiddenField ID="hfstartdate" runat="server" />
                             <asp:HiddenField ID="hfenddate" runat="server" />
                            </td>
                            </tr>
                            
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="PanelButton" Width="800px" BorderWidth="0px" runat="server">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td width="300px">
                                </td>
                                <td align="left" width="400px">
                                    <asp:Button ID="btnViewReport" runat="server" Text="<%$Resources:Resource,ViewReport %>"
                                        CssClass="cssButton" OnClick="btnViewReport_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center">
                                    <asp:Label ID="lblErrorMsg" EnableViewState="false" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                     <asp:Label ID="scheduleAnalysis" runat="server" Text="Employee Schedule analysis"
            CssClass=" cssLable"></asp:Label>
        <asp:GridView Width="500" ID="gvEmployees" CssClass="GridViewStyle" runat="server"
            ShowHeader="true" Visible="true" AutoGenerateColumns="false" AllowPaging="false"
            CellPadding="1" GridLines="Vertical">
            <FooterStyle CssClass="GridViewFooterStyle" />
            <RowStyle CssClass="GridViewRowStyle" />
            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
            <PagerStyle CssClass="GridViewPagerStyle" />
            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
            <HeaderStyle CssClass="GridViewHeaderStyle" />
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Label ID="gvHdrSchedulableEmployees" runat="server" CssClass=" cssLabelHeader"
                            Text="Schedulable Employees"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div style="text-align: center">
                            <asp:LinkButton ID="gvSchedulableEmployees" runat="server" CssClass=" cssLabel" Text='<%# DataBinder.Eval(Container.DataItem, "EmployeeCount").ToString()%>'
                                OnClientClick="javascript:openpage('0','1');" ></asp:LinkButton>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Label ID="gvHdrScheduledEmployees" runat="server" CssClass=" cssLabelHeader"
                            Text="Scheduled Employees"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div style="text-align: center">
                            <asp:LinkButton ID="gvScheduledEmployees" runat="server" CssClass=" cssLabel" Text='<%# DataBinder.Eval(Container.DataItem, "ScheduledEmployeeCount").ToString()%>'
                                OnClientClick="javascript:openpage('0','2');" ></asp:LinkButton>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Label ID="gvHdrNotScheduledEmployees" runat="server" CssClass=" cssLabelHeader"
                            Text="Employees Not Scheduled"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div style="text-align: center">
                            <asp:LinkButton ID="gvNotScheduledEmployees" runat="server" CssClass=" cssLabel"
                                Text='<%# DataBinder.Eval(Container.DataItem, "NotScheduledEmployeeCount").ToString()%>'
                                OnClientClick="javascript:openpage('0','3');" ></asp:LinkButton>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Label ID="gvRequiredHrs" runat="server" CssClass=" cssLabelHeader" Text="Required Hours"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div style="text-align: center">
                            <asp:Label ID="gvRequiredHrs" runat="server" CssClass=" cssLabel" Text='<%# DataBinder.Eval(Container.DataItem, "RequiredEmployeeCount").ToString()%>'></asp:Label>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <br />
    <br />
    <div>
        <asp:Label ID="lblSchAct" runat="server" Text="Schedule Vs Actual" CssClass=" cssLable"></asp:Label>
        <asp:GridView Width="700" ID="gvScheduleVsActual" CssClass="GridViewStyle" runat="server"
            ShowHeader="true" Visible="true" AutoGenerateColumns="false" AllowPaging="false"
            CellPadding="1" GridLines="Vertical" OnRowDataBound="gvScheduleVsActual_RowDataBound" >
            <FooterStyle CssClass="GridViewFooterStyle" />
            <RowStyle CssClass="GridViewRowStyle" />
            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
            <PagerStyle CssClass="GridViewPagerStyle" />
            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
            <HeaderStyle CssClass="GridViewHeaderStyle" />
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Label ID="gvHdrParameter" runat="server" CssClass=" cssLabelHeader" Text=""></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div style="text-align: left">
                            <asp:Label ID="gvlblParameter" runat="server" CssClass=" cssLabel" Text='<%# DataBinder.Eval(Container.DataItem, "Parameter").ToString()%>'></asp:Label>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Label ID="gvHdrScheduledCount" runat="server" CssClass=" cssLabelHeader" Text="Scheduled (Emp Count)"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div style="text-align: center">
                            <asp:LinkButton ID="gvScheduledEmpCount" runat="server" CssClass=" cssLabel" Text='<%# DataBinder.Eval(Container.DataItem, "ScheduledEmployeeCount").ToString()%>'></asp:LinkButton>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Label ID="gvHdrActulaEmpCount" runat="server" CssClass=" cssLabelHeader" Text="Actual (Emp Count)"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div style="text-align: center">
                            <asp:LinkButton ID="gvActualEmpCount" runat="server" CssClass=" cssLabel" Text='<%# DataBinder.Eval(Container.DataItem, "ActualEmployeeCount").ToString()%>'></asp:LinkButton>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <div id="drilldown" runat="server" visible="false" style="position: absolute; top: 1%;
        bottom: 50%; overflow: auto; width: 700px; height: 480px">
    </div>
    <script language="javascript" type="text/javascript" >
        function openpage(id1, id) {
            
            var startdate = document.getElementById("<%= hfstartdate.ClientID %>").value;
            var enddate = document.getElementById("<%= hfenddate.ClientID %>").value;
        var pageName = "../Testpages/grid.aspx?id1=" + id1 + "&id=" + id + "&startdate=" + startdate + "&enddate=" + enddate;
            var winW = 750;
            var winH = 500;
            var winX = (screen.availWidth - winW) / 2;
            var winY = (screen.availHeight - winH) / 2;
            var features = 'left=' + winX + ',top=' + winY + ',height=' + winH + ',' + 'width=' + winW + ',status=yes,' + 'toolbar=no,menubar=no,location=no';
            window.open(pageName, 'grid',features);
        }
    </script>
</asp:Content>
