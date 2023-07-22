<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="PaySum_Greece.aspx.cs" Inherits="Transactions_PaySum_Greece" Title="<%$ Resources:Resource, AppTitle %>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg"></asp:Label>
    <Ajax:UpdatePanel ID="UpdatePanel1" runat="server">
     <ContentTemplate>
       <br />
       <br />
            <asp:Panel ID="Panel1" runat="server">
                <table>
                    <tr>
                        <tr>
                            <td align="center" colspan="2">
                                <Ajax:UpdateProgress ID="UpdateProgress1" runat="server">
                                    <ProgressTemplate>
                                        processing......
                                        <img id="imgspin" runat="server" alt="" src="../Images/spinner.gif" />
                                    </ProgressTemplate>
                                </Ajax:UpdateProgress>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <asp:Label ID="Label3" runat="server" CssClass="csslblErrMsg" EnableViewState="false"></asp:Label>
                            </td>
                        </tr>
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
                            <asp:Button ID="btnPaySum" runat="server" CssClass="cssButton" Text="Export To Text"
                                OnClick="btnPaySum_OnClick" />
                        </td>
                    </tr>
                  
                </table>
            </asp:Panel>
            <asp:Panel ID="Panel2" runat="server">
                <table>
                    <tr>
                        <td>
                            <dx:ASPxGridView ID="ASPxGridView1" runat="server" Width="950px" AutoGenerateColumns="False">
                                <Settings ShowFilterRow="True" ShowGroupPanel="True" ShowFilterRowMenu="True" ShowHeaderFilterButton="True"
                                    ShowHorizontalScrollBar="True" />
                                <SettingsPager AlwaysShowPager="True" PageSize="15">
                                </SettingsPager>
                                <Columns>
                                    <dx:GridViewCommandColumn ShowClearFilterButton="true" VisibleIndex="0" FixedStyle="Left" Width="30px">
                                    </dx:GridViewCommandColumn>
                                         <dx:GridViewDataTextColumn Caption="<%$ Resources:Resource, EmployeeNumber %>"
                                        CellStyle-CssClass="cssLable" FieldName="EmployeeNumber" FixedStyle="Left" VisibleIndex="4"
                                        Width="70px">
                                        <CellStyle HorizontalAlign="Left" CssClass="cssLable">
                                        </CellStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="<%$ Resources:Resource, EmployeeName %>" CellStyle-CssClass="cssLable"
                                        FieldName="Name" FixedStyle="Left" VisibleIndex="5" Width="210px">
                                        <Settings AllowAutoFilter="True" AllowHeaderFilter="True" AllowSort="True" FilterMode="DisplayText" />
                                        <CellStyle HorizontalAlign="Left" CssClass="cssLable">
                                        </CellStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="<%$ Resources:Resource, TOTALHOURSWITHOUTTHEREDCOLUMNS %>" CellStyle-CssClass="cssLable"
                                        Width="250px"   FieldName="TOTAL HOURS WITHOUT THE RED COLUMNS" VisibleIndex="6">
                                        <Settings AllowHeaderFilter="False" />
                                        <CellStyle CssClass="cssLable">
                                        </CellStyle>
                                        <PropertiesTextEdit DisplayFormatString="{0:n2}">
                                        </PropertiesTextEdit>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="<%$ Resources:Resource, Day %>"
                                        CellStyle-CssClass="cssLable" Width="40px"   FieldName="DAY" VisibleIndex="7">
                                        <Settings AllowHeaderFilter="false" />
                                        <CellStyle CssClass="cssLable">
                                        </CellStyle>
                                        <PropertiesTextEdit DisplayFormatString="{0:n2}">
                                        </PropertiesTextEdit>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="<%$ Resources:Resource, Night %>" CellStyle-CssClass="cssLable"
                                        Width="40px" FieldName="NIGHT" VisibleIndex="8">
                                        <Settings AllowHeaderFilter="False" />
                                        <CellStyle CssClass="cssLable">
                                        </CellStyle>
                                        <PropertiesTextEdit DisplayFormatString="{0:n2}">
                                        </PropertiesTextEdit>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="<%$ Resources:Resource, DAYHOLIDAY %>" CellStyle-CssClass="cssLable"
                                       Width="80px"     FieldName="DAY HOLIDAY" VisibleIndex="9">
                                        <Settings AllowHeaderFilter="False" />
                                        <CellStyle CssClass="cssLable">
                                        </CellStyle>
                                        <PropertiesTextEdit DisplayFormatString="{0:n2}">
                                        </PropertiesTextEdit>
                                    </dx:GridViewDataTextColumn>
                                      <dx:GridViewDataTextColumn Caption="<%$ Resources:Resource, NIGHTHOLIDAY %>" CellStyle-CssClass="cssLable"
                                        FieldName="NIGHT HOLIDAY" VisibleIndex="9">
                                        <Settings AllowHeaderFilter="False" />
                                        <CellStyle CssClass="cssLable">
                                        </CellStyle>
                                        <PropertiesTextEdit DisplayFormatString="{0:n2}">
                                        </PropertiesTextEdit>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="<%$ Resources:Resource, SUMOVERTIME %>"
                                        CellStyle-CssClass="cssLable" FieldName="SUM OVERTIME" VisibleIndex="10" Width="130px">
                                        <Settings AllowHeaderFilter="False" />
                                        <CellStyle CssClass="cssLable">
                                        </CellStyle>
                                        <PropertiesTextEdit DisplayFormatString="{0:n2}">
                                        </PropertiesTextEdit>
                                    </dx:GridViewDataTextColumn>

                                    <dx:GridViewDataTextColumn Caption="<%$ Resources:Resource, DAYOVERTIME %>"
                                        CellStyle-CssClass="cssLable" FieldName="DAY OVERTIME" VisibleIndex="11" Width="130px">
                                        <Settings AllowHeaderFilter="False" />
                                        <CellStyle CssClass="cssLable">
                                        </CellStyle>
                                        <PropertiesTextEdit DisplayFormatString="{0:n2}">
                                        </PropertiesTextEdit>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="<%$ Resources:Resource, NIGHTOVERTIME %>"
                                        CellStyle-CssClass="cssLable" FieldName="NIGHT OVERTIME" VisibleIndex="11" Width="130px">
                                        <Settings AllowHeaderFilter="False" />
                                        <CellStyle CssClass="cssLable">
                                        </CellStyle>
                                        <PropertiesTextEdit DisplayFormatString="{0:n2}">
                                        </PropertiesTextEdit>
                                    </dx:GridViewDataTextColumn>

                                    <dx:GridViewDataTextColumn Caption="<%$ Resources:Resource, DAYHOLIDAYOVERTIME %>" CellStyle-CssClass="cssLable"
                                        Width="140px"    FieldName="DAY HOLIDAY OVERTIME" VisibleIndex="12">
                                        <Settings AllowHeaderFilter="False" />
                                        <CellStyle CssClass="cssLable">
                                        </CellStyle>
                                        <PropertiesTextEdit DisplayFormatString="{0:n2}">
                                        </PropertiesTextEdit>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="<%$ Resources:Resource, NIGHTHOLIDAYOVERTIME %>"
                                        CellStyle-CssClass="cssLable" FieldName="NIGHT HOLIDAY OVERTIME" VisibleIndex="13"
                                        Width="160px">
                                        <Settings AllowHeaderFilter="False" />
                                        <CellStyle CssClass="cssLable">
                                        </CellStyle>
                                        <PropertiesTextEdit DisplayFormatString="{0:n2}">
                                        </PropertiesTextEdit>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="<%$ Resources:Resource, SUMOVERTIMEOVERFIRST20 %>"
                                        CellStyle-CssClass="cssLable" FieldName="SUM OVERTIME OVER FIRST 20" VisibleIndex="14"
                                        Width="230px">
                                        <Settings AllowHeaderFilter="False" />
                                        <CellStyle CssClass="cssLable">
                                        </CellStyle>
                                        <PropertiesTextEdit DisplayFormatString="{0:n2}">
                                        </PropertiesTextEdit>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="<%$ Resources:Resource, DAYOVERTIMEOVERFIRST20 %>"
                                        CellStyle-CssClass="cssLable" Width="230px"    FieldName="DAY OVERTIME OVER FIRST 20" VisibleIndex="15" >
                                        <Settings AllowHeaderFilter="False" />
                                        <CellStyle CssClass="cssLable">
                                        </CellStyle>
                                        <PropertiesTextEdit DisplayFormatString="{0:n2}">
                                        </PropertiesTextEdit>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="<%$ Resources:Resource, DAYHOLIDAYOVERTIMEOVERFIRST20 %>"
                                        CellStyle-CssClass="cssLable" Width="230px"   FieldName="NIGHT OVERTIME OVER FIRST 20" VisibleIndex="16">
                                        <Settings AllowHeaderFilter="False" />
                                        <CellStyle CssClass="cssLable">
                                        </CellStyle>
                                        <PropertiesTextEdit DisplayFormatString="{0:n2}">
                                        </PropertiesTextEdit>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="<%$ Resources:Resource, DAYHOLIDAYOVERTIMEOVERFIRST20 %>"
                                        CellStyle-CssClass="cssLable" Width="230px"   FieldName="DAY HOLIDAY OVERTIME OVER FIRST 20" VisibleIndex="17" >
                                        <Settings AllowHeaderFilter="False" />
                                        <CellStyle CssClass="cssLable">
                                        </CellStyle>
                                        <PropertiesTextEdit DisplayFormatString="{0:n2}">
                                        </PropertiesTextEdit>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="<%$ Resources:Resource, NIGHTHOLIDAYOVERTIMEOVERFIRST20 %>"
                                        CellStyle-CssClass="cssLable"  Width="250px" FieldName="NIGHT HOLIDAY OVERTIME OVER FIRST 20" VisibleIndex="18">
                                        <Settings AllowHeaderFilter="False" />
                                        <CellStyle CssClass="cssLable">
                                        </CellStyle>
                                        <PropertiesTextEdit DisplayFormatString="{0:n2}">
                                        </PropertiesTextEdit>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="<%$ Resources:Resource, SUMOVERTIMENODECIMAL %>" CellStyle-CssClass="cssLable"
                                        FieldName="SUM OVERTIME NO DECIMAL"  Width="200px"   VisibleIndex="19">
                                        <Settings AllowHeaderFilter="False" />
                                        <CellStyle CssClass="cssLable">
                                        </CellStyle>
                                        <PropertiesTextEdit DisplayFormatString="{0:n2}">
                                        </PropertiesTextEdit>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="<%$ Resources:Resource, SUMOVERTIMEALL %>"
                                        CellStyle-CssClass="cssLable" Width="150px" FieldName="SUM OVERTIME ALL" VisibleIndex="14"
                                        >
                                        <Settings AllowHeaderFilter="False" />
                                        <CellStyle CssClass="cssLable">
                                        </CellStyle>
                                        <PropertiesTextEdit DisplayFormatString="{0:n2}">
                                        </PropertiesTextEdit>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="<%$ Resources:Resource, LeaveHours %>"
                                        CellStyle-CssClass="cssLable" FieldName="LEAVES HOURS" VisibleIndex="15" Width="120px">
                                        <Settings AllowHeaderFilter="False" />
                                        <CellStyle CssClass="cssLable">
                                        </CellStyle>
                                        <PropertiesTextEdit DisplayFormatString="{0:n2}">
                                        </PropertiesTextEdit>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="<%$ Resources:Resource, ToTalHrs %>"
                                        CellStyle-CssClass="cssLable" FieldName="TOTAL HOURS" VisibleIndex="16">
                                        <Settings AllowHeaderFilter="False" />
                                        <CellStyle CssClass="cssLable">
                                        </CellStyle>
                                        <PropertiesTextEdit DisplayFormatString="{0:n2}">
                                        </PropertiesTextEdit>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="<%$ Resources:Resource, DAYSOFSICKLEAVES %>"
                                        CellStyle-CssClass="cssLable" FieldName="DAYS OF SICK LEAVES" VisibleIndex="17" Width="135px">
                                        <Settings AllowHeaderFilter="False" />
                                        <CellStyle CssClass="cssLable">
                                        </CellStyle>
                                        <PropertiesTextEdit DisplayFormatString="{0:n2}">
                                        </PropertiesTextEdit>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="<%$ Resources:Resource, LeaveDays %>"
                                        CellStyle-CssClass="cssLable" FieldName="NUMBER OF DAYS LEAVES" VisibleIndex="18">
                                        <Settings AllowHeaderFilter="False" />
                                        <CellStyle CssClass="cssLable">
                                        </CellStyle>
                                        <PropertiesTextEdit DisplayFormatString="{0:n2}">
                                        </PropertiesTextEdit>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="<%$ Resources:Resource, ELECTIONDAYS %>" CellStyle-CssClass="cssLable"
                                        FieldName="ELECTION DAYS" VisibleIndex="19">
                                        <Settings AllowHeaderFilter="False" />
                                        <CellStyle CssClass="cssLable">
                                        </CellStyle>
                                        <PropertiesTextEdit DisplayFormatString="{0:n2}">
                                        </PropertiesTextEdit>
                                    </dx:GridViewDataTextColumn>
                                </Columns>
                            </dx:ASPxGridView>
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
