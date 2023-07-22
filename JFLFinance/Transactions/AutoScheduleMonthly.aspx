<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="AutoScheduleMonthly.aspx.cs" Inherits="Transactions_AutoScheduleMonthly"
    Title="<%$ Resources:Resource, AutoSchedule %>" %>

<%@ Register Src="../MS_Control/MultipleSelection.ascx" TagName="MultipleSelection"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table border="0">
        <tr>
            <td align="right" style="width: 200px">
                <asp:Label ID="lblClientName" runat="server" Text="<%$ Resources:Resource, ClientName %>"
                    CssClass="cssLable"></asp:Label>
            </td>
            <td align="left">
                <table>
                    <tr>
                        <td>
                            <uc1:MultipleSelection ID="ddlClient" runat="server" />
                        </td>
                        <td>
                            <asp:Button ID="btnGoClient" runat="server" Text="<%$ Resources:Resource, Go %>"
                                OnClick="btnGoClient_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 200px">
                <asp:Label ID="lblAsmt" runat="server" Text="<%$ Resources:Resource, Asmt %>" CssClass="cssLable"></asp:Label>
            </td>
            <td align="left">
                <table>
                    <tr>
                        <td>
                            <uc1:MultipleSelection ID="ddlAsmt" runat="server" />
                        </td>
                        <td>
                            <asp:Button ID="btnGoAsmt" runat="server" Text="<%$ Resources:Resource, Go %>" OnClick="btnGoAsmt_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 200px" align="right">
                <asp:Label ID="lblPost" runat="server" Text="<%$Resources:Resource,Post %>" CssClass="cssLable"></asp:Label>
            </td>
            <td align="left">
                <uc1:MultipleSelection ID="ddlPost" runat="server" />
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 200px">
                <asp:Label ID="lblYear" runat="server" Text="<%$ Resources:Resource, Year %>" CssClass="cssLable"></asp:Label>
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlYear" runat="server" CssClass="cssDropDown" Width="350px">
                    <asp:ListItem Text="2011" Value="2011"></asp:ListItem>
                    <asp:ListItem Text="2012" Value="2012"></asp:ListItem>
                    <asp:ListItem Text="2013" Value="2013"></asp:ListItem>
                    <asp:ListItem Text="2014" Value="2014"></asp:ListItem>
                    <asp:ListItem Text="2015" Value="2015"></asp:ListItem>
                    <asp:ListItem Text="2016" Value="2016"></asp:ListItem>
                    <asp:ListItem Text="2017" Value="2017"></asp:ListItem>
                    <asp:ListItem Text="2018" Value="2018"></asp:ListItem>
                    <asp:ListItem Text="2019" Value="2019"></asp:ListItem>
                    <asp:ListItem Text="2020" Value="2020"></asp:ListItem>
                    <asp:ListItem Text="2021" Value="2021"></asp:ListItem>
                    <asp:ListItem Text="2022" Value="2022"></asp:ListItem>
                    <asp:ListItem Text="2023" Value="2023"></asp:ListItem>
                    <asp:ListItem Text="2024" Value="2024"></asp:ListItem>
                    <asp:ListItem Text="2025" Value="2025"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 200px">
                <asp:Label ID="lblMonth" runat="server" Text="<%$ Resources:Resource, Month %>" CssClass="cssLable"></asp:Label>
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlMonth" runat="server" CssClass="cssDropDown" Width="350px">
                    <asp:ListItem Text="JANUARY" Value="1"></asp:ListItem>
                    <asp:ListItem Text="FEBRUARY" Value="2"></asp:ListItem>
                    <asp:ListItem Text="MARCH" Value="3"></asp:ListItem>
                    <asp:ListItem Text="APRIL" Value="4"></asp:ListItem>
                    <asp:ListItem Text="MAY" Value="5"></asp:ListItem>
                    <asp:ListItem Text="JUNE" Value="6"></asp:ListItem>
                    <asp:ListItem Text="JULY" Value="7"></asp:ListItem>
                    <asp:ListItem Text="AUGUST" Value="8"></asp:ListItem>
                    <asp:ListItem Text="SEPTEMBER" Value="9"></asp:ListItem>
                    <asp:ListItem Text="OCTOBER" Value="10"></asp:ListItem>
                    <asp:ListItem Text="NOVEMBER" Value="11"></asp:ListItem>
                    <asp:ListItem Text="DECEMBER" Value="12"></asp:ListItem>
                </asp:DropDownList>
                <asp:HiddenField ID="key" runat="server" />
            </td>
        </tr>
    </table>
    <asp:UpdatePanel ID="updatePannel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:MultiView ID="mvvProcess" runat="server" ActiveViewIndex="0">
                <asp:View ID="vLaunch" runat="server">
                    <asp:Button ID="btnProceed" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource, Proceed %>"
                        OnClick="btnProceed_Click" />&nbsp;
                    <asp:Button ID="btnAutoSchedule" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource, AutoSchedule %>"
                        OnClick="btnAutoSchedule_Click" />
                    <asp:Panel ID="Panel1" BorderWidth="1px" runat="server" Width="950px" Height="250px"
                        ScrollBars="Auto" CssClass="ScrollBar">
                        <asp:GridView Width="900px" ID="gvEmployeeAutoSchedule" CssClass="GridViewStyle"
                            runat="server" ShowFooter="False" ShowHeader="true" Visible="true" AllowPaging="true"
                            PageSize="1000" CellPadding="1" GridLines="None" AutoGenerateColumns="False"
                            OnRowDataBound="gvEmployeeAutoSchedule_RowDataBound" OnPageIndexChanging="gvEmployeeAutoSchedule_PageIndexChanging">
                            <FooterStyle CssClass="GridViewFooterStyle" />
                            <RowStyle CssClass="GridViewRowStyle" />
                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                            <PagerStyle CssClass="GridViewPagerStyle" />
                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                            <Columns>
                                <asp:TemplateField HeaderStyle-Width="30px" FooterStyle-Width="30px" ItemStyle-Width="30px">
                                    <HeaderTemplate>
                                        <asp:Label ID="lblgvhdrSerialNo" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,SerialNumber %>"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblSerialNo" CssClass="cssLabel" runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-Width="50px" FooterStyle-Width="50px" ItemStyle-Width="50px">
                                    <HeaderTemplate>
                                        <asp:Label ID="lblCheck" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,Check %>"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbCheck" CssClass="cssCheckBox" runat="server" Checked="true" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-Width="60px" FooterStyle-Width="60px" ItemStyle-Width="60px">
                                    <HeaderTemplate>
                                        <asp:Label ID="lblEmployeeNumber" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,EmployeeNumber %>"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblEmployeeNumber" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EmployeeNumber").ToString()%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-Width="150px" FooterStyle-Width="150px" ItemStyle-Width="150px">
                                    <HeaderTemplate>
                                        <asp:Label ID="lblEmployeeName" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,EmployeeName %>"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblEmployeeName" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EmployeeName").ToString()%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-Width="150px" FooterStyle-Width="150px" ItemStyle-Width="150px">
                                    <HeaderTemplate>
                                        <asp:Label ID="lblAssignment" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,Assignment %>"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblAssignment" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Assignment").ToString()%>'></asp:Label>
                                        <asp:HiddenField ID="hfAsmtCode" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "AsmtCode").ToString()%>' />
                                        <asp:HiddenField ID="hfRowNumber" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "RowNumber").ToString()%>' />
                                        <asp:HiddenField ID="hfSchRosterAutoId" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "SchRosterAutoId").ToString()%>' />
                                        <asp:HiddenField ID="hfClientCode" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "ClientCode").ToString()%>' />
                                        <asp:HiddenField ID="hfSoNo" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "SoNo").ToString()%>' />
                                        <asp:HiddenField ID="hfSoLineNo" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "SoLineNo").ToString()%>' />
                                        <asp:HiddenField ID="hfSoRank" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "SoRank").ToString()%>' />
                                        <asp:HiddenField ID="hfPostAutoId" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "PostAutoID").ToString()%>' />
                                        <asp:HiddenField ID="hfPatternPosition" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "PatternPosition").ToString()%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--                            <asp:TemplateField HeaderStyle-Width="200px" FooterStyle-Width="200px" ItemStyle-Width="200px">
                                <HeaderTemplate>
                                    <asp:Label ID="lblSiteName" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,Post %>"></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblSiteName" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Site").ToString()%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                                --%>
                                <asp:TemplateField HeaderStyle-Width="100px" FooterStyle-Width="100px" ItemStyle-Width="100px">
                                    <HeaderTemplate>
                                        <asp:Label ID="lblDutyDate" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,DutyDate %>"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblDutyDate" CssClass="cssLable" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("DutyDate"))%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-Width="150px" FooterStyle-Width="150px" ItemStyle-Width="150px">
                                    <HeaderTemplate>
                                        <asp:Label ID="lblSequence" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,Sequence %>"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblSequence" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Sequence").ToString()%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Label ID="lblMessage" runat="server" CssClass="csslblErrMsg" Text='<%# DataBinder.Eval(Container.DataItem, "MessageString").ToString()%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--<asp:TemplateField HeaderStyle-Width="100px" FooterStyle-Width="100px" ItemStyle-Width="100px">
                                <HeaderTemplate>
                                    <asp:Label ID="lblaction" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, EditColName %>"></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImgbtnEdit" runat="server" CssClass="cssImgButton" CommandName="Edit"
                                        ToolTip="<%$ Resources:Resource, Edit %>" ImageUrl="../Images/Edit.gif" />
                                    <asp:ImageButton runat="server" ID="lnkbtnDelete" CssClass="csslnkButton" ToolTip="<%$ Resources:Resource, Delete %>"
                                        CommandName="Delete" ImageUrl="../Images/Delete.gif"></asp:ImageButton>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                    <asp:TextBox ID="txt1" runat="server" Visible="false"></asp:TextBox>
                </asp:View>
                <asp:View ID="vProgress" runat="server">
                    <div style="position: absolute; top: 0; left: 0; width: 100%; height: 100%; text-align: center;"
                        class="modalBackground">
                        <img id="Image1" runat="server" style="position: absolute; top: 50%; left: 50%" alt=""
                            src="../Images/spinner.gif" />
                        <asp:Label ID="Label1" runat="server" Text="Starting" Style="position: absolute;
                            top: 52%; left: 54%"></asp:Label>
                    </div>
                    <asp:Timer ID="timUpdate" runat="server" Enabled="False" Interval="1000" OnTick="timUpdate_Tick">
                    </asp:Timer>
                </asp:View>
            </asp:MultiView>
        </ContentTemplate>
    </asp:UpdatePanel>
   
    
</asp:Content>
