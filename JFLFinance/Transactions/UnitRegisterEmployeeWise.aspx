<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UnitRegisterEmployeeWise.aspx.cs" Inherits="Transactions_UnitRegisterEmployeeWise" MasterPageFile="~/MasterPage/MasterPage.master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<asp:Label ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg"></asp:Label>
    <Ajax:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <br />
            <br />
            <asp:Panel ID="Panel1" runat="server">
                <table>
                        
                        <tr>
                            <td>
                            <asp:Label ID="lblSelectType" runat="server" CssClass="cssLabel" EnableViewState="false" Text="Select Report Type"></asp:Label>
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
                                    OnClick="btnGenerateData_Click" /><%--OnClick="btnGenerateData_OnClick"--%>
                            </td>
                        </tr>
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

                </table>
            </asp:Panel>
            <asp:Panel ID="Panel2" runat="server">
                <table>
                    <tr>
                        <td>
                            <br />
                            <br />
                            <dxp:ASPxPivotGrid ID="grid" ClientInstanceName="grid"   
                             Width="950px" runat="server" EnableCallBacks="true" >
                            <OptionsPager AllButton-Visible="true"></OptionsPager>
                            <Fields> 
                            <dxp:PivotGridField Caption="<%$ Resources:Resource, Post %>" AreaIndex="0" GroupInterval="Default" CellStyle-CssClass="cssLable" FieldName="Post" Visible="True" Area="RowArea" TotalCellFormat-FormatType="Custom" TotalsVisibility="AutomaticTotals"></dxp:PivotGridField>
                            <dxp:PivotGridField Caption="<%$ Resources:Resource, Shift %>" AreaIndex="1" GroupInterval="Default" CellStyle-CssClass="cssLable" FieldName="Shift" Visible="True" Area="RowArea" TotalsVisibility="AutomaticTotals"></dxp:PivotGridField>
                            <dxp:PivotGridField Caption="<%$ Resources:Resource, Type %>" AreaIndex="2" GroupInterval="Default" CellStyle-CssClass="cssLable" FieldName="Type" Visible="True" Area="RowArea" ></dxp:PivotGridField>
                            <dxp:PivotGridField CellStyle-CssClass="cssLable" Caption="Employee" AreaIndex="3" FieldName="EmployeeName" Visible="True" Area="RowArea" TotalValueFormat-FormatType="None"></dxp:PivotGridField>
                            <dxp:PivotGridField CellStyle-CssClass="cssLable" FieldName="Duty_Date" AreaIndex="4" Visible="True" Area="ColumnArea"  ValueTotalStyle-Wrap="False" ValueStyle-Wrap="False" CellFormat-FormatType="Custom"></dxp:PivotGridField>
                            <dxp:PivotGridField Caption="Date" CellStyle-CssClass="cssLable" AreaIndex="5" FieldName="Day_Date" Visible="True" Area="ColumnArea" TotalCellFormat-FormatType="Custom" TotalsVisibility="None" ></dxp:PivotGridField>
                                
                            <dxp:PivotGridField CellStyle-CssClass="cssLable" Caption="Hours" AreaIndex="6" FieldName="Hours" Visible="True" Area="DataArea" ValueTotalStyle-Wrap="False" ValueStyle-Wrap="False" CellFormat-FormatType="Custom"></dxp:PivotGridField>
                            <%--<dxp:PivotGridField CellStyle-CssClass="cssLable" FieldName="Price_Hours" AreaIndex="7" Caption="Price Hour" Visible="True" Area="RowArea" ValueTotalStyle-Wrap="False" ValueStyle-Wrap="False" CellFormat-FormatType="Custom"></dxp:PivotGridField>--%>
                            <dxp:PivotGridField CellStyle-CssClass="cssLable" Caption="Total Price" AreaIndex="8" FieldName="Total_Price" Visible="True" Area="RowArea" ValueTotalStyle-Wrap="False" ValueStyle-Wrap="False" CellFormat-FormatType="Custom"></dxp:PivotGridField>
                            </Fields>
                            
                            </dxp:ASPxPivotGrid>
                         
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <dxp:ASPxPivotGridExporter Id="ASPxPivotGridExporter" runat="server" ASPxPivotGridID="ASPxPivotGrid1" ></dxp:ASPxPivotGridExporter>

                            <%--<dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" GridViewID="ASPxPivotGrid1" FileName="UnitBreakUp" >
                            </dx:ASPxGridViewExporter>--%>
                            
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
    <script language="javascript" type="text/javascript">
        trialNode.innerHTML = "";
        var Page;
        var postBackElement;
        function pageLoad() {
            Page = Sys.WebForms.PageRequestManager.getInstance();
            Page.add_beginRequest(OnBeginRequest);
            Page.add_endRequest(endRequest);
        }

        function OnBeginRequest(sender, args) {
            postBackElement = args.get_postBackElement();
            postBackElement.disabled = true;

        }

        function endRequest(sender, args) {
            postBackElement.disabled = false;
            document.body.childNodes[0].innerHTML = "";

        }      


    </script>

</asp:Content>
