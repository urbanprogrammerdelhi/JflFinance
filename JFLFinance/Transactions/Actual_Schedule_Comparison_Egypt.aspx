
<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="Actual_Schedule_Comparison_Egypt.aspx.cs" Inherits="Transactions_Actual_Schedule_Comparison_Egypt"
     Title="<%$ Resources:Resource, AppTitle %>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg"></asp:Label>
    <Ajax:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table>
            <tr>
            <td>
                        <Ajax:UpdateProgress ID="UpdateProgress1" runat="server">
                            <ProgressTemplate>
                                Please wait.....<img alt="" src="../Images/spinner.gif" />
                            </ProgressTemplate>
                        </Ajax:UpdateProgress>
            </td>
            </tr> 
            </table>
            <asp:Panel ID="Panel1" runat="server">
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="<%$Resources:Resource,FromDate %>" CssClass="cssLable"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TxtFDate" Width="88px" runat="server" CssClass="csstxtbox"></asp:TextBox>
                            <asp:HyperLink ID="ImgFDate" runat="server" ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                        </td>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="<%$Resources:Resource,ToDate %>" CssClass="cssLable"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TxtTDate" Width="88px" runat="server" CssClass="csstxtbox"></asp:TextBox>
                            <asp:HyperLink ID="ImgTDate" runat="server" ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                        </td>
                        <td>
                            <asp:Button ID="btnGenerateData" runat="server" CssClass="cssButton" Text="View"
                                OnClick="btnGenerateData_OnClick" />
                        </td>
                          <td>
                            <asp:Button ID="btnProcessData" runat="server" CssClass="cssButton" Text="Process"
                                OnClick="btnProcessData_OnClick" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="Panel2" runat="server">
                <table>
                    <tr>
                        <td>
                            <dx:ASPxGridView ID="ASPxGridView1" runat="server" Width="950px" 
                                AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                                <Settings ShowFilterRow="True" ShowGroupPanel="True" ShowFilterRowMenu="True" ShowHeaderFilterButton="True"
                                    ShowHorizontalScrollBar="True" />
                                <SettingsPager AlwaysShowPager="True">
                                </SettingsPager>
                                <Columns>
                                    <dx:GridViewDataTextColumn Caption="<%$ Resources:Resource, ScheduleClientCode %>"
                                        CellStyle-CssClass="cssLable" FieldName="Schedule ClientCode" 
                                        VisibleIndex="0">
                                        <CellStyle CssClass="cssLable">
                                        </CellStyle>
                                    </dx:GridViewDataTextColumn> 
                                    <dx:GridViewDataTextColumn CellStyle-CssClass="cssLable" Caption="<%$ Resources:Resource, ScheduleClientName %>"
                                        FieldName="Schedule ClientName" VisibleIndex="1">
                                        <CellStyle CssClass="cssLable">
                                        </CellStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn CellStyle-CssClass="cssLable" Caption="<%$ Resources:Resource, ScheduleAssigtCd %>"
                                        FieldName="Schedule AssigtCd" VisibleIndex="2">
                                        <CellStyle CssClass="cssLable">
                                        </CellStyle>
                                    </dx:GridViewDataTextColumn>
                                                                   <dx:GridViewDataTextColumn
                                        CellStyle-CssClass="cssLable" FieldName="Actual ClientCode" Caption="<%$ Resources:Resource, ActualClientCode %>"
                                        VisibleIndex="3">
                                        <CellStyle CssClass="cssLable" HorizontalAlign="Left">
                                        </CellStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn CellStyle-CssClass="cssLable" Caption="<%$ Resources:Resource, ActualClientName %>"
                                        FieldName="Actual ClientName" VisibleIndex="4">
                                        <CellStyle CssClass="cssLable" HorizontalAlign="Left">
                                        </CellStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn CellStyle-CssClass="cssLable" Caption="<%$ Resources:Resource, ActualAssigtCd %>"
                                        FieldName="Actual AssigtCd" VisibleIndex="5">
                                        <CellStyle CssClass="cssLable" HorizontalAlign="Left">
                                        </CellStyle>
                                    </dx:GridViewDataTextColumn>
                               <dx:GridViewDataTextColumn FieldName="Schedule Emp" Caption="<%$ Resources:Resource, scheduleemp %> " VisibleIndex="6">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="Actual Emp" Caption="<%$ Resources:Resource, ActualEmp %>" VisibleIndex="7">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="Schedule TotalShift" Caption="<%$ Resources:Resource, ScheduleTotalShift %> " VisibleIndex="8">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="Actual TotalShift" Caption="<%$ Resources:Resource, ActualTotalShift %> " VisibleIndex="9">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="Schedule TotalBlankShift" Caption="<%$ Resources:Resource, ScheduleTotalBlankShift %> "
                                        VisibleIndex="10">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="Actual TotalBlankShift" Caption="<%$ Resources:Resource, ActualTotalBlankShift %> "
                                        VisibleIndex="11">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="Schedule TotalNetDays" Caption="<%$ Resources:Resource, ScheduleTotalNetDays %> "
                                        VisibleIndex="12">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="Actual TotalNetDays" Caption="<%$ Resources:Resource, ActualTotalNetDays %> " VisibleIndex="13">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="Schedule TotalWorkedhrs" Caption="<%$ Resources:Resource, ScheduleTotalWorkedhrs %> "
                                        VisibleIndex="14">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="Actual TotalWorkedhrs" Caption="<%$ Resources:Resource, ActualTotalWorkedhrs %> "
                                        VisibleIndex="15">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="Schedule TotalPen" Caption="<%$ Resources:Resource, ScheduleTotalPen %> " VisibleIndex="16">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="Actual TotalPen" Caption="<%$ Resources:Resource, ActualTotalPen %> " VisibleIndex="17">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="Schedule TotalHoliday" Caption="<%$ Resources:Resource, ScheduleTotalHoliday %> "
                                        VisibleIndex="18">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="Actual TotalHoliday" Caption="<%$ Resources:Resource, ActualTotalHoliday %> " VisibleIndex="19">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="Schedule TotalAL" Caption="<%$ Resources:Resource, ScheduleTotalAL %> " VisibleIndex="20">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="Actual TotalAL" Caption="<%$ Resources:Resource, ActualTotalAL %> " VisibleIndex="21">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="Schedule TotalSL" Caption="<%$ Resources:Resource, ScheduleTotalSL %> " VisibleIndex="22">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="Actual TotalTotalSLAL" Caption="<%$ Resources:Resource, ActualTotalSL %> "
                                        VisibleIndex="23">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="Schedule TotalML" Caption="<%$ Resources:Resource, ScheduleTotalML %> " VisibleIndex="24">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="Actual TotalML" Caption="<%$ Resources:Resource, ActualTotalML %> " VisibleIndex="25">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="Schedule TotalM" Caption="<%$ Resources:Resource, ScheduleTotalM %> " VisibleIndex="26">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="Actual TotalM" Caption="<%$ Resources:Resource, ActualTotalM %> " VisibleIndex="27"> 
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="Schedule TotalUAl" Caption="<%$ Resources:Resource, ScheduleTotalUAl %> " VisibleIndex="28">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="Actual TotalUAl" Caption="<%$ Resources:Resource, ActualTotalUAl %> " VisibleIndex="29">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="Schedule TotalWO" Caption="<%$ Resources:Resource, ScheduleTotalWO %> " VisibleIndex="30">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="Actual TotalWO" Caption="<%$ Resources:Resource, ActualTotalWO %> " VisibleIndex="31">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="Schedule TotalMc" Caption="<%$ Resources:Resource, ScheduleTotalMc %> " VisibleIndex="32">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="Actual TotalMc" Caption="<%$ Resources:Resource, ActualTotalMc %> " VisibleIndex="33">
                                    </dx:GridViewDataTextColumn>
                                </Columns>
                            </dx:ASPxGridView>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                ConnectionString="Data Source=GCTEST;Initial Catalog=Egypt_Auth;Persist Security Info=True;User ID=sa;Password=gci@test123" 
                                ProviderName="System.Data.SqlClient" 
                                SelectCommand="SELECT * FROM [mstschedulevsactual]"></asp:SqlDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" GridViewID="ASPxGridView1">
                            </dx:ASPxGridViewExporter>
                        </td>
                    </tr>
                 
                </table>
            </asp:Panel>
        </ContentTemplate>
    </Ajax:UpdatePanel>
       <table>
       <tr>
                        <td align="left">
                            <asp:Button ID="Button1" runat="server" Text="Export to Excel" CssClass="cssButton"
                                OnClick="btn_submit" />
                        </td>
                    </tr>
        </table>
</asp:Content>