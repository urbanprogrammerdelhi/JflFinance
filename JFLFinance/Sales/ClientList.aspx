<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="ClientList.aspx.cs" Inherits="Sales_ClientList" Title="<%$ Resources:Resource, AppTitle %>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <dx:ASPxGridView ID="ASPxGridView1" runat="server" Width="950px" 
        AutoGenerateColumns="False">
        <Settings ShowFilterRow="True" ShowGroupPanel="True" ShowFilterRowMenu="True" ShowHeaderFilterButton="True" />
        <Columns>
            <dx:GridViewCommandColumn ShowClearFilterButton="true" VisibleIndex="0">
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn FieldName="Location" Caption="Location" VisibleIndex="1">
                <CellStyle HorizontalAlign="Left">
                </CellStyle>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="ClientCode" Caption="Client Code"
                VisibleIndex="2">
                <CellStyle HorizontalAlign="Left">
                </CellStyle>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="ClientName" Caption="Client Name"
                VisibleIndex="3">
                <CellStyle HorizontalAlign="Left">
                </CellStyle>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="AsmtId" Caption="Assignment ID"
                VisibleIndex="4">
                <CellStyle HorizontalAlign="Left">
                </CellStyle>
            </dx:GridViewDataTextColumn>            
            <dx:GridViewDataTextColumn FieldName="AsmtAddress" Caption="Asmt Address"
                VisibleIndex="5">
                <CellStyle HorizontalAlign="Left">
                </CellStyle>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="SoStatus" Caption="SO Status"
                VisibleIndex="6">
                <CellStyle HorizontalAlign="Left">
                </CellStyle>
            </dx:GridViewDataTextColumn>
        </Columns>
    </dx:ASPxGridView>
    <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server">
    </dx:ASPxGridViewExporter>
    
    <asp:Button ID="ExportToExcel" CssClass="cssButton" runat="server" Text="Export To Excel"
        OnClick="ExportToExcel_Click" />
</asp:Content>
