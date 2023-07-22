<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="EmpPersonalDetails.aspx.cs" Inherits="HRManagement_EmpPersonalDetails" Title="Untitled Page" %>

<%--<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Src="../MS_Control/MultipleSelection.ascx" TagName="MultipleSelection" TagPrefix="uc1" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="Label1" runat="server" Text="<%$ Resources:Resource, EmployeePersonalDetails %>"></asp:Label>

    <%--<script language ="javascript" src="../javaScript/jquery-1.8.1.min.js" type ="text/javascript"></script>--%>
    <script language="javascript" type="text/javascript" src="../javaScript/jquery-1.11.3.min.js"></script>
    <script type="text/javascript" language="javascript" src="../PageJS/EmpPersonalDetails.js"></script>

<asp:Panel ID="PanelLocation" Width="800px" BorderWidth="0px" runat="server">
<table width="800px" border="0" cellpadding="1" cellspacing="0">
<tr>
<td align="right" style="width: 200px">
    <asp:Label ID="Label9" runat="server" Text="<%$Resources:Resource,HrLocation %>"
        CssClass="cssLable"></asp:Label>
</td>
<td align="left" colspan="3">
    <asp:DropDownList ID="ddlDivision" AutoPostBack="true" runat="server" CssClass="cssDropDown"
        Width="350px" OnSelectedIndexChanged="ddlDivision_SelectedIndexChanged">
    </asp:DropDownList>
</td>
</tr>
<tr>
<td align="right" style="width: 200px">
    <asp:Label ID="Label10" runat="server" Text="<%$Resources:Resource,Branch %>" CssClass="cssLable"></asp:Label>
</td>
<td align="left" colspan="4">
    <uc1:MultipleSelection ID="msddlBranch" runat="server" />
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="PanelAreaID" Width="800px" BorderWidth="0px" runat="server">
<table width="800px" border="0" cellpadding="1" cellspacing="0">
    <tr>
        <td align="right" style="width: 200px">
            <asp:Label ID="Label2" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource, AreaID %>"></asp:Label>
        </td>
        <td align="left" colspan="3">
            <asp:DropDownList CssClass="cssDropDown" AutoPostBack="true" Width="150px" ID="DDLAreaID"
                runat="server">
            </asp:DropDownList>
        </td>
    </tr>
</table>
</asp:Panel>
<asp:Panel ID="PanelButton" Width="800px" BorderWidth="0px" runat="server">
<table width="800px" border="0" cellpadding="1" cellspacing="0">                         
<tr>
<td style="width: 400px">
<dx:ASPxButton runat="server" ID="button1" ClientInstanceName="button1" Text="<%$ Resources:Resource, ShowCustomizationWindow %>"
    UseSubmitBehavior="False" AutoPostBack="False">
    <ClientSideEvents Click="button1_Click" />
</dx:ASPxButton>
</td>
<td align="left" style="width: 400px">
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
<dx:ASPxGridView ID="grid" ClientInstanceName="grid" runat="server" AutoGenerateColumns="False"
Width="100%">
<Settings ShowFilterRow="True" ShowHorizontalScrollBar="True"/>
<SettingsBehavior ColumnResizeMode="Control" />
<SettingsCustomizationWindow Enabled="False" Height="250px" Width="160px" PopupHorizontalOffset="50"
PopupVerticalOffset="50"  />
<ClientSideEvents  CustomizationWindowCloseUp="grid_CustomizationWindowCloseUp" />
<Columns>
    <dx:GridViewCommandColumn VisibleIndex="0" ShowClearFilterButton="true" FixedStyle="Left" Width="30px">
    </dx:GridViewCommandColumn>
                                    
    <dx:GridViewDataTextColumn Caption="<%$ Resources:Resource, EmployeeNumber %>"
        CellStyle-CssClass="cssLable" FieldName="EmployeeNumber" FixedStyle="Left" VisibleIndex="1"
        Width="70px">
        <HeaderStyle Font-Size="Small" />
        <CellStyle HorizontalAlign="Left" CssClass="cssLable">
        </CellStyle>
    </dx:GridViewDataTextColumn>
    <dx:GridViewDataTextColumn Caption="<%$ Resources:Resource, FirstName %>" CellStyle-CssClass="cssLable"
        FieldName="FirstName" FixedStyle="Left" VisibleIndex="2" Width="140px">
        <CellStyle HorizontalAlign="Left" CssClass="cssLable">
        </CellStyle>
    </dx:GridViewDataTextColumn>
    <dx:GridViewDataTextColumn Caption="<%$ Resources:Resource, LastName %>" CellStyle-CssClass="cssLable"
        FieldName="LastName" FixedStyle="Left" VisibleIndex="3" Width="140px">
        <CellStyle HorizontalAlign="Left" CssClass="cssLable">
        </CellStyle>
    </dx:GridViewDataTextColumn>
    <dx:GridViewDataTextColumn Caption="<%$ Resources:Resource, DateOfBirth %>" 
        CellStyle-CssClass="cssLable" FieldName="DateOfBirth"  VisibleIndex="4"
        Width="90px" >
                                        
            <PropertiesTextEdit DisplayFormatString ="dd-MMM-yyyy">
        </PropertiesTextEdit>
            <Settings AllowAutoFilter="True" AllowHeaderFilter="False" 
                ShowFilterRowMenu="True" />
        <CellStyle HorizontalAlign="Left" CssClass="cssLable">
        </CellStyle>
    </dx:GridViewDataTextColumn>
    <dx:GridViewDataTextColumn Caption="<%$ Resources:Resource, DateOfJoining %>" CellStyle-CssClass="cssLable"
        FieldName="DateOfJoining" VisibleIndex="5" Width="90px">
        <Settings AllowAutoFilter="True" AllowHeaderFilter="False" AllowSort="True" 
            FilterMode="DisplayText" ShowFilterRowMenu="True" ShowInFilterControl="True" />
            <PropertiesTextEdit DisplayFormatString ="dd-MMM-yyyy">
        </PropertiesTextEdit>
        <CellStyle HorizontalAlign="Left" CssClass="cssLable">
        </CellStyle>
    </dx:GridViewDataTextColumn>
    <dx:GridViewDataTextColumn Caption="<%$ Resources:Resource, Nationality %>" CellStyle-CssClass="cssLable"
        FieldName="Nationality" VisibleIndex="6" Width="80px">
        <Settings AllowHeaderFilter="False" />
        <CellStyle HorizontalAlign="Left" CssClass="cssLable">
        </CellStyle>
    </dx:GridViewDataTextColumn>
                                    
    <dx:GridViewDataTextColumn Caption="<%$ Resources:Resource, IdentificationNo %>" CellStyle-CssClass="cssLable"
        FieldName="IDNumber" VisibleIndex="7" Width="120px">
        <Settings AllowHeaderFilter="False" />
        <CellStyle HorizontalAlign="Left" CssClass="cssLable">
        </CellStyle>
    </dx:GridViewDataTextColumn>
                                    
                                    
    <dx:GridViewDataTextColumn Caption="<%$ Resources:Resource, HomeState %>"
        CellStyle-CssClass="cssLable" FieldName="HomeState" VisibleIndex="8" Width="80px">
        <Settings AllowHeaderFilter="False" />
        <CellStyle HorizontalAlign="Left" CssClass="cssLable">
        </CellStyle>
                                        
    </dx:GridViewDataTextColumn>
    <dx:GridViewDataTextColumn Caption="<%$ Resources:Resource, ContactNo %>" CellStyle-CssClass="cssLable"
        FieldName="ContactNo" VisibleIndex="9" Width="80px">
        <Settings AllowHeaderFilter="False" />
        <CellStyle CssClass="cssLable">
        </CellStyle>
                                        
    </dx:GridViewDataTextColumn>
    <dx:GridViewDataTextColumn Caption="<%$ Resources:Resource, MaritalStatus %>" CellStyle-CssClass="cssLable"
        FieldName="MaritalStatus" VisibleIndex="10" Width="80px">
        <Settings AllowHeaderFilter="False" />
        <CellStyle HorizontalAlign="Left" CssClass="cssLable">
        </CellStyle>
                                        
    </dx:GridViewDataTextColumn>
    <dx:GridViewDataTextColumn Caption="<%$ Resources:Resource, Address %>"
        CellStyle-CssClass="cssLable" FieldName="Address" VisibleIndex="11" Width="130px">
        <Settings AllowHeaderFilter="False" />
        <CellStyle HorizontalAlign="Left" CssClass="cssLable">
        </CellStyle>
                                        
    </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn Caption="<%$ Resources:Resource, City %>"
        CellStyle-CssClass="cssLable" FieldName="City" VisibleIndex="12" Width="130px">
        <Settings AllowHeaderFilter="False" />
        <CellStyle HorizontalAlign="Left" CssClass="cssLable">
        </CellStyle>
                                        
    </dx:GridViewDataTextColumn>

    <dx:GridViewDataTextColumn Caption="<%$ Resources:Resource, State %>"
        CellStyle-CssClass="cssLable" FieldName="State" VisibleIndex="13" Width="130px">
        <Settings AllowHeaderFilter="False" />
        <CellStyle HorizontalAlign="Left" CssClass="cssLable">
        </CellStyle>
                                        
    </dx:GridViewDataTextColumn>

        <dx:GridViewDataTextColumn Caption="<%$ Resources:Resource, ZIP %>"
        CellStyle-CssClass="cssLable" FieldName="ZIPCODE" VisibleIndex="14" Width="130px">
        <Settings AllowHeaderFilter="False" />
        <CellStyle HorizontalAlign="Left" CssClass="cssLable">
        </CellStyle>
                                        
    </dx:GridViewDataTextColumn>

        <dx:GridViewDataTextColumn Caption="<%$ Resources:Resource, Phone1 %>"
        CellStyle-CssClass="cssLable" FieldName="Phone1" VisibleIndex="15" Width="130px">
        <Settings AllowHeaderFilter="False" />
        <CellStyle HorizontalAlign="Left" CssClass="cssLable">
        </CellStyle>
                                        
    </dx:GridViewDataTextColumn>

    <dx:GridViewDataTextColumn Caption="<%$ Resources:Resource, Phone2 %>"
        CellStyle-CssClass="cssLable" FieldName="Phone2" VisibleIndex="16" Width="130px">
        <Settings AllowHeaderFilter="False" />
        <CellStyle HorizontalAlign="Left" CssClass="cssLable">
        </CellStyle>
                                        
    </dx:GridViewDataTextColumn>

        <dx:GridViewDataTextColumn Caption="<%$ Resources:Resource, MobileNumber %>"
        CellStyle-CssClass="cssLable" FieldName="MobileNumber" VisibleIndex="17" Width="130px">
        <Settings AllowHeaderFilter="False" />
        <CellStyle HorizontalAlign="Left" CssClass="cssLable">
        </CellStyle>
                                        
    </dx:GridViewDataTextColumn>

        <dx:GridViewDataTextColumn Caption="<%$ Resources:Resource, Email %>"
        CellStyle-CssClass="cssLable" FieldName="EMail" VisibleIndex="18" Width="130px">
        <Settings AllowHeaderFilter="False" />
        <CellStyle HorizontalAlign="Left" CssClass="cssLable">
        </CellStyle>
                                        
    </dx:GridViewDataTextColumn>


    <dx:GridViewDataTextColumn Caption="<%$ Resources:Resource, Height %>"
        CellStyle-CssClass="cssLable" FieldName="Height" VisibleIndex="19" Width="80px">
        <Settings AllowHeaderFilter="False" />
        <CellStyle HorizontalAlign="Right" CssClass="cssLable">
        </CellStyle>
        <PropertiesTextEdit DisplayFormatString="{0:n2}">
        </PropertiesTextEdit>
    </dx:GridViewDataTextColumn>
    <dx:GridViewDataTextColumn Caption="<%$ Resources:Resource, Weight %>" CellStyle-CssClass="cssLable"
        FieldName="Weight" VisibleIndex="20" Width="80px">
        <Settings AllowHeaderFilter="False" />
        <CellStyle CssClass="cssLable">
        </CellStyle>
        <PropertiesTextEdit DisplayFormatString="{0:n2}">
        </PropertiesTextEdit>
    </dx:GridViewDataTextColumn>
    <dx:GridViewDataTextColumn Caption="<%$ Resources:Resource, Smoker %>"
        CellStyle-CssClass="cssLable" FieldName="Smoker" VisibleIndex="21"
        Width="80px">
        <Settings AllowHeaderFilter="False" />
        <CellStyle HorizontalAlign="Left" CssClass="cssLable">
        </CellStyle>
                                        
    </dx:GridViewDataTextColumn>
    <dx:GridViewDataTextColumn Caption="<%$ Resources:Resource, PrevTotalExp %>"
        CellStyle-CssClass="cssLable" FieldName="PrevTotalExp" VisibleIndex="22"
        Width="135px">
        <Settings AllowHeaderFilter="False" />
        <CellStyle CssClass="cssLable">
        </CellStyle>
        <PropertiesTextEdit DisplayFormatString="{0:n2}">
        </PropertiesTextEdit>
    </dx:GridViewDataTextColumn>
    <dx:GridViewDataTextColumn Caption="<%$ Resources:Resource, Gender %>"
        CellStyle-CssClass="cssLable" FieldName="Gender" VisibleIndex="23" Width="80px">
        <Settings AllowHeaderFilter="False" />
        <CellStyle HorizontalAlign="Left" CssClass="cssLable">
        </CellStyle>
                                        
    </dx:GridViewDataTextColumn>
    <dx:GridViewDataTextColumn Caption="<%$ Resources:Resource, DesignationDesc %>"
        CellStyle-CssClass="cssLable" FieldName="DesignationDesc" VisibleIndex="24">
        <Settings AllowHeaderFilter="False" />
        <CellStyle HorizontalAlign="Left" CssClass="cssLable">
        </CellStyle>
                                        
    </dx:GridViewDataTextColumn>
    <dx:GridViewDataTextColumn Caption="<%$ Resources:Resource, Category %>"
        CellStyle-CssClass="cssLable" FieldName="CategoryDesc" VisibleIndex="25" Width="135px">
        <Settings AllowHeaderFilter="False" />
        <CellStyle HorizontalAlign="Left" CssClass="cssLable">
        </CellStyle>
                                        
    </dx:GridViewDataTextColumn>
    <dx:GridViewDataTextColumn Caption="<%$ Resources:Resource, ResignationDate %>"
        CellStyle-CssClass="cssLable" FieldName="DateOfResignation" VisibleIndex="26">
        <Settings AllowHeaderFilter="False" />
        <CellStyle HorizontalAlign="Left" CssClass="cssLable">
        </CellStyle>
                                        
                                        
    </dx:GridViewDataTextColumn>
    <dx:GridViewDataTextColumn Caption="<%$ Resources:Resource, TerminationReason %>" CellStyle-CssClass="cssLable"
        FieldName="TerminationReason" VisibleIndex="27" Width= "120px">
        <Settings AllowHeaderFilter="False" />
        <CellStyle HorizontalAlign="Left" CssClass="cssLable">
        </CellStyle>
                                       
                                        
    </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn Caption="<%$ Resources:Resource, JobClassCode %>" CellStyle-CssClass="cssLable"
        FieldName="JobClassCode" VisibleIndex="27" Width= "120px">
        <Settings AllowHeaderFilter="False" />
        <CellStyle HorizontalAlign="Left" CssClass="cssLable">
        </CellStyle>
                                                                            
    </dx:GridViewDataTextColumn>

        <dx:GridViewDataTextColumn Caption="<%$ Resources:Resource, AreaID %>" CellStyle-CssClass="cssLable"
        FieldName="AreaID" VisibleIndex="27" Width= "120px">
        <Settings AllowHeaderFilter="False" />
        <CellStyle HorizontalAlign="Left" CssClass="cssLable">
        </CellStyle>
                                                                            
    </dx:GridViewDataTextColumn>

        <dx:GridViewDataTextColumn Caption="<%$ Resources:Resource, AreaDesc %>" CellStyle-CssClass="cssLable"
        FieldName="AreaDesc" VisibleIndex="27" Width= "120px">
        <Settings AllowHeaderFilter="False" />
        <CellStyle HorizontalAlign="Left" CssClass="cssLable">
        </CellStyle>
                                                                            
    </dx:GridViewDataTextColumn>

        <dx:GridViewDataTextColumn Caption="<%$ Resources:Resource, wageRate %>" CellStyle-CssClass="cssLable"
        FieldName="WageRate" VisibleIndex="27" Width= "120px">
        <Settings AllowHeaderFilter="False" />
        <CellStyle HorizontalAlign="Left" CssClass="cssLable">
        </CellStyle>
                                                                            
    </dx:GridViewDataTextColumn>

    <dx:GridViewDataTextColumn Caption="<%$ Resources:Resource, ContractHours %>" CellStyle-CssClass="cssLable"
        FieldName="ContractHours" VisibleIndex="27" Width= "120px">
        <Settings AllowHeaderFilter="False" />
        <CellStyle HorizontalAlign="Left" CssClass="cssLable">
        </CellStyle>
                                                                            
    </dx:GridViewDataTextColumn>

        <dx:GridViewDataTextColumn Caption="<%$ Resources:Resource, ContractDays %>" CellStyle-CssClass="cssLable"
        FieldName="ContractDays" VisibleIndex="27" Width= "120px">
        <Settings AllowHeaderFilter="False" />
        <CellStyle HorizontalAlign="Left" CssClass="cssLable">
        </CellStyle>
                                                                            
    </dx:GridViewDataTextColumn>

    <dx:GridViewDataTextColumn Caption="<%$ Resources:Resource, CompanyCode %>"
        CellStyle-CssClass="cssLable" FieldName="CompanyCode"  VisibleIndex="1"
        Width="70px">
        <HeaderStyle Font-Size="Small" />
        <CellStyle HorizontalAlign="Left" CssClass="cssLable">
        </CellStyle>
    </dx:GridViewDataTextColumn>

        <dx:GridViewDataTextColumn Caption="<%$ Resources:Resource, CompanyDescription %>"
        CellStyle-CssClass="cssLable" FieldName="CompanyDesc"  VisibleIndex="1"
        Width="70px">
        <HeaderStyle Font-Size="Small" />
        <CellStyle HorizontalAlign="Left" CssClass="cssLable">
        </CellStyle>
    </dx:GridViewDataTextColumn>

    <dx:GridViewDataTextColumn Caption="<%$ Resources:Resource, LocationCode %>"
        CellStyle-CssClass="cssLable" FieldName="LocationCode"  VisibleIndex="1"
        Width="70px">
        <HeaderStyle Font-Size="Small" />
        <CellStyle HorizontalAlign="Left" CssClass="cssLable">
        </CellStyle>
    </dx:GridViewDataTextColumn>

        <dx:GridViewDataTextColumn Caption="<%$ Resources:Resource, LocationDescription %>"
        CellStyle-CssClass="cssLable" FieldName="LocationDesc"  VisibleIndex="1"
        Width="70px">
        <HeaderStyle Font-Size="Small" />
        <CellStyle HorizontalAlign="Left" CssClass="cssLable">
        </CellStyle>
    </dx:GridViewDataTextColumn>
                                
        <dx:GridViewDataTextColumn Caption="<%$ Resources:Resource, DepartmentCode %>" CellStyle-CssClass="cssLable"
        FieldName="DepartmentCode" VisibleIndex="27" Width= "120px">
        <Settings AllowHeaderFilter="False" />
        <CellStyle HorizontalAlign="Left" CssClass="cssLable">
        </CellStyle>
        </dx:GridViewDataTextColumn>

        <dx:GridViewDataTextColumn Caption="<%$ Resources:Resource, DepartmentName %>" CellStyle-CssClass="cssLable"
        FieldName="DepartmentName" VisibleIndex="27" Width= "120px">
        <Settings AllowHeaderFilter="False" />
        <CellStyle HorizontalAlign="Left" CssClass="cssLable">
        </CellStyle>
        </dx:GridViewDataTextColumn>

        <dx:GridViewDataTextColumn Caption="<%$ Resources:Resource, JobTypeCode %>" CellStyle-CssClass="cssLable"
        FieldName="JobTypeCode" VisibleIndex="27" Width= "120px">
        <Settings AllowHeaderFilter="False" />
        <CellStyle HorizontalAlign="Left" CssClass="cssLable">
        </CellStyle>
        </dx:GridViewDataTextColumn>

        <dx:GridViewDataTextColumn Caption="<%$ Resources:Resource, JobTypeDesc %>" CellStyle-CssClass="cssLable"
        FieldName="JobTypeDesc" VisibleIndex="27" Width= "120px">
        <Settings AllowHeaderFilter="False" />
        <CellStyle HorizontalAlign="Left" CssClass="cssLable">
        </CellStyle>
        </dx:GridViewDataTextColumn>



</Columns>
    
</dx:ASPxGridView>
    <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server">
    </dx:ASPxGridViewExporter>
    <asp:Button ID="Button2" runat="server" Text="<%$ Resources:Resource, ExporttoExcel %>" OnClick="btn_submit" />
</asp:Content>
