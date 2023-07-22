<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="TimeSheetReport.aspx.cs" Inherits="Transactions_TimeSheetReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" language="javascript">

        function grid_CustomizationWindowCloseUp(s, e) {
            UpdateButtonText();
        }

        function button1_Click(s, e) {


            if (grid.IsCustomizationWindowVisible())
                grid.HideCustomizationWindow();
            else
                grid.ShowCustomizationWindow();
            UpdateButtonText();
        }

    
    </script>
    <div style="width:1300px; height:420px"> 
    <dx:ASPxGridView ID="TimeSheetExcel" ClientInstanceName="TimeSheetExcel" 
            runat="server" AutoGenerateColumns="False"
        onheaderfilterfillitems="grid_HeaderFilterFillItems" Width="1200px" 
            Settings-ShowVerticalScrollBar="false" >
        <Settings ShowFilterRow="True"  />
        <SettingsPager  PageSize="10"  />
        
        <ClientSideEvents CustomizationWindowCloseUp="grid_CustomizationWindowCloseUp" />
     <Columns>
                    <%-- <dx:GridViewCommandColumn VisibleIndex="0" FixedStyle="Left" Width="30px">
                                        <ClearFilterButton Visible="True">
                                        </ClearFilterButton>
                                    </dx:GridViewCommandColumn>--%>
                                    
                                  <%--  <dx:GridViewDataColumn Caption="<%$Resources:Resource,Company %>" CellStyle-CssClass="cssLable"
                                        FieldName="CompanyDesc" FixedStyle="Left" VisibleIndex="1" Width="90px">
                                        <CellStyle HorizontalAlign="Left" CssClass="cssLable" >
                                        </CellStyle>
                                    </dx:GridViewDataColumn>--%>

                                     <dx:GridViewDataColumn Caption="<%$Resources:Resource,LocationDesc %>" CellStyle-CssClass="cssLable"
                                        FieldName="LocationDesc" FixedStyle="Left" VisibleIndex="1" Width="70px">
                                        <CellStyle HorizontalAlign="Left" CssClass="cssLable" >
                                        </CellStyle>
                                    </dx:GridViewDataColumn>
                            
                                     <dx:GridViewDataColumn Caption="<%$Resources:Resource,EmployeeNumber %>" CellStyle-CssClass="cssLable"
                                        FieldName="EmployeeNumber" FixedStyle="Left" VisibleIndex="3" Width="60px">
                                        <CellStyle HorizontalAlign="Left" CssClass="cssLable" >
                                        </CellStyle>
                                    </dx:GridViewDataColumn>

                                     <dx:GridViewDataColumn Caption="<%$Resources:Resource,EmployeeName %>" CellStyle-CssClass="cssLable"
                                        FieldName="Name" FixedStyle="Left" VisibleIndex="4" Width="100px">
                                        <CellStyle HorizontalAlign="Left" CssClass="cssLable" >
                                        </CellStyle>
                                    </dx:GridViewDataColumn>

                                    <dx:GridViewDataColumn Caption="<%$Resources:Resource, ClientName %>" CellStyle-CssClass="cssLable"
                                        FieldName="ClientName" FixedStyle="Left" VisibleIndex="5" Width="170px">
                                        <CellStyle HorizontalAlign="Left" CssClass="cssLable" >
                                        </CellStyle>
                                    </dx:GridViewDataColumn>

                                     <dx:GridViewDataColumn Caption="<%$Resources:Resource, AsmtAddress %>" CellStyle-CssClass="cssLable"
                                        FieldName="AsmtAddress" FixedStyle="Left" VisibleIndex="6" Width="170px">
                                        <CellStyle HorizontalAlign="Left" CssClass="cssLable" >
                                        </CellStyle>
                                         </dx:GridViewDataColumn>

                                     <dx:GridViewDataColumn Caption="<%$Resources:Resource, SitePost %>" CellStyle-CssClass="cssLable"
                                        FieldName="PostDesc" FixedStyle="Left" VisibleIndex="7" Width="250px">
                                        <CellStyle HorizontalAlign="Left" CssClass="cssLable"  >
                                        </CellStyle>
                                    </dx:GridViewDataColumn>

                                    <dx:GridViewDataTextColumn Caption="<%$Resources:Resource, DutyDate %>" CellStyle-CssClass="cssLable"
                                        FieldName="DutyDate" FixedStyle="Left" VisibleIndex="8" Width="70px">
                                        <CellStyle HorizontalAlign="Left" CssClass="cssLable" >
                                        </CellStyle>
                                        <PropertiesTextEdit DisplayFormatString ="dd-MMM-yyyy"></PropertiesTextEdit>
                                    </dx:GridViewDataTextColumn>

                                    <dx:GridViewDataColumn Caption="<%$Resources:Resource, ShiftCode %>" CellStyle-CssClass="cssLable"
                                        FieldName="ShiftCode" FixedStyle="Left" VisibleIndex="9" Width="20px">
                                        <CellStyle HorizontalAlign="Left" CssClass="cssLable" >
                                        </CellStyle>
                                    </dx:GridViewDataColumn>

                                    <dx:GridViewDataTextColumn Caption="<%$Resources:Resource, InTime %>" CellStyle-CssClass="cssLable"
                                        FieldName="InTime" FixedStyle="Left" VisibleIndex="10" Width="20px">
                                        <CellStyle HorizontalAlign="Left" CssClass="cssLable" >
                                        </CellStyle>
                                        <PropertiesTextEdit DisplayFormatString ="hh:mm"></PropertiesTextEdit>
                                    </dx:GridViewDataTextColumn>

                                     <dx:GridViewDataTextColumn Caption="<%$Resources:Resource, OutTime %>" CellStyle-CssClass="cssLable"
                                        FieldName="OutTime" FixedStyle="Left" VisibleIndex="11" Width="20px">
                                        <CellStyle HorizontalAlign="Left" CssClass="cssLable" >
                                        </CellStyle>
                                        <PropertiesTextEdit DisplayFormatString ="hh:mm"></PropertiesTextEdit>
                                    </dx:GridViewDataTextColumn>

                                     <dx:GridViewDataTextColumn Caption="<%$Resources:Resource, WorkingHours %>" CellStyle-CssClass="cssLable"
                                        FieldName="WorkingHrs" FixedStyle="Left" VisibleIndex="12" Width="20px">
                                        <CellStyle HorizontalAlign="Left" CssClass="cssLable" >
                                        </CellStyle>
                                        <PropertiesTextEdit DisplayFormatString="{0:n2}"></PropertiesTextEdit>
                                    </dx:GridViewDataTextColumn>

                                    <dx:GridViewDataColumn Caption="<%$Resources:Resource, AreaDesc %>" CellStyle-CssClass="cssLable"
                                        FieldName="AreaDesc" FixedStyle="Left" VisibleIndex="13" Width="70px">
                                        <CellStyle HorizontalAlign="Left" CssClass="cssLable" >
                                        </CellStyle>
                                    </dx:GridViewDataColumn>

                                     <dx:GridViewDataColumn Caption="<%$Resources:Resource, CategoryDescription %>" CellStyle-CssClass="cssLable"
                                        FieldName="CategoryDesc" FixedStyle="Left" VisibleIndex="14" Width="70px">
                                        <CellStyle HorizontalAlign="Left" CssClass="cssLable" >
                                        </CellStyle>
                                    </dx:GridViewDataColumn>              
     
     
     </Columns>
    </dx:ASPxGridView>    
    <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server">
    </dx:ASPxGridViewExporter>
    <table>
        <tr>
            <td align="left">
                <asp:Button ID="Button1" runat="server" Text="Export to Excel" CssClass="cssButton"
                    OnClick="btn_submit" />
                <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="cssButton"
                    OnClick="btn_Back" />
            </td>
        </tr>
    </table>
    </div>
     <asp:Label ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg" Text=""></asp:Label>
   

    
   <%-- <asp:Button ID="Button2" runat="server" Text="<%$ Resources:Resource, ExporttoExcel %>" OnClick="btn_submit" />--%>
     <script type="text/javascript" language="javascript">


         function UpdateButtonText() {
             var text = grid.IsCustomizationWindowVisible() ? "Hide" : "Show";
             text += " Customization Window";
             button1.SetText(text);
         }
    
    </script>
</asp:Content>
