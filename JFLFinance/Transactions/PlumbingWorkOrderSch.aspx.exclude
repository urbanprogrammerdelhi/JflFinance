<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="PlumbingWorkOrderSch.aspx.cs" Inherits="Transactions_PlumbingWorkOrderSch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:HiddenField ID="hfWorkOrderAutoId" runat="server" Value='<%# Bind("WorkOrderAutoId") %>' />
    <div class="squareboxgradientcaption" style="height: 25px; background-color: silver;">
        <asp:Label ID="Label1" CssClass="cssLabelHeader" Style="font-size: medium;" runat="server" Text="<%$ Resources:Resource,OrderDetail %>"></asp:Label>
    </div>
    <table border="0" width="100%" class="table table-hover">
        <tr>
            <td align="right" style="width: 150px">
                <asp:Label ID="lblHdrWorkOrderNo" runat="server" CssClass="cssLabelHeader" Text="<%$ Resources:Resource, OrderNo %>"></asp:Label>
            </td>
            <td align="left" style="width: 150px">
                <asp:Label ID="lblWorkOrderNo" runat="server" CssClass="cssLabel" Text=""></asp:Label>
            </td>
            <td align="right" style="width: 150px">
                <asp:Label ID="lblHdrOrderDate" runat="server" CssClass="cssLabelHeader" Text="<%$ Resources:Resource, OrderDate %>"></asp:Label>
            </td>
            <td align="left" style="width: 150px">
                <asp:Label ID="lblOrderDate" runat="server" CssClass="cssLabel" Text=""></asp:Label>
            </td>
            <td align="right" style="width: 150px">
                <asp:Label ID="lblHdrStatus" runat="server" CssClass="cssLabelHeader" Text="<%$ Resources:Resource, OrderStatus %>"></asp:Label>
            </td>
            <td align="left" style="width: 150px">
                <asp:Label ID="lblStatus" runat="server" CssClass="cssLabel" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 150px">
                <asp:Label ID="lblHdrPreferredDate" runat="server" CssClass="cssLabelHeader" Text="<%$ Resources:Resource, PreferredDate %>"></asp:Label>
            </td>
            <td align="left" style="width: 150px">
                <asp:Label ID="lblPreferredDate" runat="server" CssClass="cssLabel" Text=""></asp:Label>
            </td>
            <td align="right" style="width: 150px">
                <asp:Label ID="lblHdrTimeSlot" runat="server" CssClass="cssLabelHeader" Text="<%$ Resources:Resource, PreferredTimeSlot %>"></asp:Label>
            </td>
            <td align="left" style="width: 150px">
                <asp:Label ID="lblTimeSlot" runat="server" CssClass="cssLabel" Text=""></asp:Label>
            </td>
            <td align="right" style="width: 150px">
                <asp:Label ID="lblHdrPrice" runat="server" CssClass="cssLabelHeader" Text="<%$ Resources:Resource, PlumbingPrice %>"></asp:Label>
            </td>
            <td align="left" style="width: 150px">
                <asp:Label ID="lblPrice" runat="server" CssClass="cssLabel" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 150px">
                <asp:Label ID="lblHdrService" runat="server" CssClass="cssLabelHeader" Text="<%$ Resources:Resource, Service %>"></asp:Label>
            </td>
            <td align="left" colspan="5">
                <asp:Label ID="lblService" runat="server" CssClass="cssLabel" Text=""></asp:Label>
                <asp:HiddenField ID="hfServiceAutoId" runat="server" Value="" />
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 150px">
                <asp:Label ID="lblHdrClientCode" runat="server" CssClass="cssLabelHeader" Text="<%$ Resources:Resource, ClientCode %>"></asp:Label>
            </td>
            <td align="left" style="width: 150px">
                <asp:Label ID="lblClientCode" runat="server" CssClass="cssLabel" Text=""></asp:Label>
            </td>
            <td align="right" style="width: 150px">
                <asp:Label ID="lblHdrClientName" runat="server" CssClass="cssLabelHeader" Text="<%$ Resources:Resource, ClientName %>"></asp:Label>
            </td>
            <td align="left" colspan="3">
                <asp:Label ID="lblClientName" runat="server" CssClass="cssLabel" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 150px">
                <asp:Label ID="lblHdrAddress" runat="server" CssClass="cssLabelHeader" Text="<%$ Resources:Resource, Address %>"></asp:Label>
            </td>
            <td align="left" colspan="5">
                <asp:Label ID="lblAddress" runat="server" CssClass="cssLabel" Text=""></asp:Label>
                <asp:HiddenField ID="hfAddress" runat="server" Value="" />
            </td>
        </tr>
        <%--<tr>
            <td colspan="6"></td>
        </tr>--%>
    </table>
    <div class="squareboxgradientcaption" style="height: 25px; background-color: silver;">
        <asp:Label ID="Label2" CssClass="cssLabelHeader" Style="font-size: medium;" runat="server" Text="<%$ Resources:Resource, Schedule %>"></asp:Label>
    </div>
    <table border="0" width="100%" class="table table-hover">
        <tr>
            <td align="right" style="width: 150px">
                <asp:Label ID="lblHdrEmployeeNumber" runat="server" CssClass="cssLabelHeader" Text="<%$ Resources:Resource, EmployeeNumber %>"></asp:Label>
            </td>
            <td align="left" style="width: 150px">
                <asp:Label ID="lblSchEmployeeNumber" runat="server" CssClass="cssLabel"></asp:Label>
            </td>
            <td align="right" style="width: 150px">
                <asp:Label ID="lblHdrEmployeeName" runat="server" CssClass="cssLabelHeader" Text="<%$ Resources:Resource, EmployeeName %>"></asp:Label>
            </td>
            <td align="left" style="width: 150px">
                <asp:Label ID="lblSchEmployeeName" runat="server" CssClass="cssLabel"></asp:Label>
            </td>
            <td align="center">
                <asp:Button ID="btnSaveSchedule" runat="server" Text="<%$Resources:Resource,Schedule %>" CssClass="cssButton" OnClick="btnSaveSchedule_Click" />
            </td>
        </tr>
        </table>

    <div class="squareboxgradientcaption" style="height: 25px; background-color: silver;">
        <asp:Label ID="Label3" CssClass="cssLabelHeader" Style="font-size: medium;" runat="server" Text="<%$ Resources:Resource,EmployeeSearch %>"></asp:Label>
    </div>
        <asp:GridView Width="100%" ID="gvSelectEmployee" CssClass="GridViewStyle" runat="server" ShowFooter="True" AllowPaging="True" PageSize="10" CellPadding="1" GridLines="None"
            AutoGenerateColumns="False" OnPageIndexChanging="gvSelectEmployee_PageIndexChanging" >
            <FooterStyle CssClass="GridViewFooterStyle" />
            <RowStyle CssClass="GridViewRowStyle" />
            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
            <PagerStyle CssClass="GridViewPagerStyle" />
            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
            <HeaderStyle CssClass="GridViewHeaderStyle" />
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Label ID="lblaction" runat="server" CssClass="cssLabelHeader" Text="<%$ Resources:Resource, Select %>"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:RadioButton ID="rbSelectEmployee" AutoPostBack="true" runat="server" OnCheckedChanged="rbSelectEmployee_CheckedChanged" onclick="checkRadioBtn(this);" />
                    </ItemTemplate>
                    <HeaderStyle CssClass="cssLabelHeader" Width="50px" />
                    <ItemStyle Width="50px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:Resource,EmployeeNumber %>">
                    <ItemTemplate>
                        <asp:Label ID="lblEmployeeNumber" Width="100px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("EmployeeNumber") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                    <ItemStyle Width="100px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:Resource,EmployeeName %>">
                    <ItemTemplate>
                        <asp:Label ID="lblEmployeeName" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("EmployeeName") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                    <ItemStyle Width="200px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:Resource,Designation %>">
                    <ItemTemplate>
                        <asp:Label ID="lblDesignation" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("Designation") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                    <ItemStyle Width="200px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:Resource,ConstraintDesc %>">
                    <ItemTemplate>
                        <asp:Label ID="lblConstraintDesc" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("ConstraintDesc") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                    <ItemStyle Width="200px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:Resource,ConstraintValue %>">
                    <ItemTemplate>
                        <asp:Label ID="lblConstraintValue" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("ConstraintValue") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                    <ItemStyle Width="100px" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:Label ID="lblError" runat="server"></asp:Label>

    <%--    Scheduling Ver1
        <table border="0" width="100%" class="table table-hover">
        <tr>
            <td align="right" style="width: 150px">
                <asp:Label ID="lblHdrEmployeeNumber" runat="server" CssClass="cssLabelHeader" Text="<%$ Resources:Resource, EmployeeNumber %>"></asp:Label>
            </td>
            <td align="left" style="width: 150px">
                <asp:TextBox ID="txtEmployeeNumber" Width="100px" runat="server" CssClass="searchtextbox" Text="" OnTextChanged="txtEmployeeNumber_TextChanged" MaxLength="12"></asp:TextBox>
                <AjaxToolKit:AutoCompleteExtender ServiceMethod="SearchEmployeeNumber" MinimumPrefixLength="2" CompletionInterval="100"
                    EnableCaching="false" CompletionSetCount="10" TargetControlID="txtEmployeeNumber" OnClientItemSelected = "ClientItemSelected"
                    ID="AceEmployeeNumber" runat="server" FirstRowSelected="true">
                </AjaxToolKit:AutoCompleteExtender>
                 <asp:HiddenField ID="hfEmployeeName" runat="server" />
            </td>
            <td align="right" style="width: 150px">
                <asp:Label ID="lblHdrEmployeeName" runat="server" CssClass="cssLabelHeader" Text="<%$ Resources:Resource, EmployeeName %>"></asp:Label>
            </td>
            <td align="left" style="width: 150px">
                <asp:TextBox ID="txtEmployeeName" Width="200px" runat="server" CssClass="searchtextbox" MaxLength="100" Text="" OnTextChanged="txtEmployeeName_TextChanged"></asp:TextBox>
                <AjaxToolKit:AutoCompleteExtender ServiceMethod="SearchEmployeeName" MinimumPrefixLength="2" CompletionInterval="100"
                    EnableCaching="false" CompletionSetCount="10" TargetControlID="txtEmployeeName" OnClientItemSelected = "ClientItemSelected"
                    ID="AceEmployeeName" runat="server" FirstRowSelected="true">
                </AjaxToolKit:AutoCompleteExtender>
                <asp:HiddenField ID="hfEmployeeNumber" runat="server" />
            </td>
            <td align="right" style="width: 150px">
                <asp:Label ID="lblHdrDesignation" runat="server" CssClass="cssLabelHeader" Text="<%$ Resources:Resource, Designation %>"></asp:Label>
            </td>
            <td align="left" style="width: 150px">
                <asp:Label ID="lblDesignation" runat="server" CssClass="cssLabel" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 150px">
                <asp:Label ID="lblHdrEmpTimeSlot" runat="server" CssClass="cssLabelHeader" Text="<%$ Resources:Resource, TimeSlot %>"></asp:Label>
            </td>
            <td align="center" style="width: 150px">
                <asp:CheckBox ID="cbTimeSlot1" runat="server" Text="" />
            </td>
            <td align="center" style="width: 150px">
                <asp:CheckBox ID="cbTimeSlot2" runat="server" Text="" />
            </td>
            <td align="center" style="width: 150px">
                <asp:CheckBox ID="cbTimeSlot3" runat="server" Text="" />
            </td>
            <td align="center" style="width: 150px">
                <asp:CheckBox ID="cbTimeSlot4" runat="server" Text="" />
            </td>
            <td align="center" style="width: 150px">
                
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 150px">
                <asp:Label ID="lblRemarks" runat="server" CssClass="cssLabelHeader" Text="<%$ Resources:Resource, Remarks %>"></asp:Label>
            </td>
             <td align="left" colspan="4">
                 <asp:TextBox ID="txtRemarks" runat="server" CssClass="csstxtbox" TextMode="MultiLine" MaxLength="1000" Width="700px" Text=""></asp:TextBox>
            </td>
             <td align="center" style="width: 150px">
                <asp:Button ID="btnSaveSchedule" runat="server" Text="<%$Resources:Resource,Schedule %>" CssClass="cssButton" OnClick="btnSaveSchedule_Click" />
            </td>
        </tr>
    </table>
    <asp:Label ID="lblError" runat="server"></asp:Label>
    --%>

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

