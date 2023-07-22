<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="ContractDetails.aspx.cs" Inherits="Sales_ContractDetails" Title="<%$ Resources:Resource, AppTitle %>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <table width="960px" border="0" cellpadding="1" cellspacing="0">
        <tr>
            <td>
                <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div style="width: 100%;">
                            <div class="squarebox">
                                <div class="squareboxgradientcaption" style="height: 15px; cursor: pointer;" ">
                                    <div style="float: left; width: 930px;">
                                        <tt style="text-align: center;">
                                            <asp:Label ID="Label13" CssClass="squareboxgradientcaption" runat="server" Text="<%$Resources:Resource,qubicDetail %>"></asp:Label></tt></div>
                                    <div style="float: right; vertical-align: middle">
                                        
                                    </div>
                                </div>
                                <div class="squareboxcontent">
                                    <table border="0">
                                        <tr>
                                            <td>
                                                <asp:Panel ID="PanelAssignmentDetails" Width="910px" GroupingText="<%$Resources:Resource,qubicDetail %>" BorderWidth="0px" runat="server">
                                                    <table border="0" width="900px">
                                                        <tr>
                                                            <td align="right" style="width:150px">
                                                                <asp:Label ID="lblFixContractNumber" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,ContractNumber %>"></asp:Label>
                                                            </td>
                                                            <td align="left" style="width:150px">
                                                                <asp:TextBox ID="txtContractNumber" CssClass="csstxtboxReadonly" Width="120px" runat="server"></asp:TextBox>
                                                                <asp:HiddenField ID="hfAmendNo" runat="server" />
                                                            </td>
                                                            <td align="right" style="width:100px">
                                                                <asp:Label ID="lblFixClientCode" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,ClientCode %>"></asp:Label>
                                                            </td>
                                                            <td align="left" style="width:150px">
                                                                <asp:TextBox ID="txtClientCode" CssClass="csstxtboxReadonly" Width="120px" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td align="right" style="width:150px;">
                                                                <asp:Label ID="lblFixClientName" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,ClientName %>"></asp:Label>
                                                            </td>
                                                            <td align="left" style="width:200px">
                                                                <asp:TextBox runat="server" CssClass="csstxtboxReadonly" Width="200px" ID="txtClientName"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4"></td>
                                                            <td align="right" style="width:150px">
                                                                <asp:Label ID="lblFixClientRegNo" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,ClientRegNo %>"></asp:Label>
                                                            </td>
                                                            <td align="left" style="width:200px">
                                                                <asp:TextBox runat="server" CssClass="csstxtbox" Width="200px" ID="txtClientRegNo"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table border="0" width="890px">
                                                        <tr>
                                                            <td style="height:2px"></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="height:2px; background-color:Gray;"></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="height:2px"></td>
                                                        </tr>
                                                    </table>
                                                    <table border="0" width="900px">
                                                        <tr>
                                                            <td align="right" style="width:200px"><asp:CheckBox ID="cbPerimInternalArea" Text="<%$ Resources:Resource, PerimInternalArea %>" TextAlign="Left" runat="server" /></td>
                                                            <td align="left" style="width:100px"></td>
                                                            <td align="right" style="width:200px"><asp:CheckBox ID="cbAccessExitControle" Text="<%$ Resources:Resource, AccessExitControl %>" TextAlign="Left" runat="server" /></td>
                                                            <td align="left" style="width:100px"></td>
                                                            <td align="right" style="width:200px"><asp:CheckBox ID="cbPassSystemadmin" Text="<%$ Resources:Resource, PassSystemAdmin %>" TextAlign="Left" runat="server" /></td>
                                                            <td align="left" style="width:100px"></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right"><asp:CheckBox ID="cbScreeningServices" Text="<%$ Resources:Resource, ScreeningServices %>" TextAlign="Left" runat="server" /></td>
                                                            <td align="left"></td>
                                                            <td align="right"><asp:CheckBox ID="cbResponseServices" Text="<%$ Resources:Resource, ResponseServices %>" TextAlign="Left" runat="server" /></td>
                                                            <td align="left"></td>
                                                            <td align="right"><asp:CheckBox ID="cbOtherGuardingServices" Text="<%$ Resources:Resource, OtherGuardingServices %>" TextAlign="Left" runat="server" /></td>
                                                            <td align="left"></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right"><asp:CheckBox ID="cbTechnicalServices" Text="<%$ Resources:Resource, TechnicalServices %>" TextAlign="Left" runat="server" /></td>
                                                            <td align="left"></td>
                                                            <td align="right">
                                                                <asp:Label ID="lblFixTechnicalServicesIncomePerMonth" Text="<%$ Resources:Resource, IncomeOrMonth %>" runat="server" CssClass="cssLabel"></asp:Label>
                                                                <asp:Label ID="lblIncomeMonthCurr" runat="server" CssClass="cssLabel"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="txtTechnicalServicesIncomePerMonth" MaxLength="12" Width="100px" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                                            </td>
                                                            <td align="right"></td>
                                                            <td align="left"></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right"><asp:CheckBox ID="cbSafetyServices" Text="<%$ Resources:Resource, SafetyServices %>" TextAlign="Left" runat="server" /></td>
                                                            <td align="left"></td>
                                                            <td align="right">
                                                                <asp:Label ID="lblFixSafetyServicesIncomePerMonth" Text="<%$ Resources:Resource, IncomeOrMonth %>" runat="server" CssClass="cssLabel"></asp:Label>
                                                                <asp:Label ID="lblIncomeMonthCurr1" runat="server" CssClass="cssLabel"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="txtSafetyServicesIncomePerMonth" MaxLength="12" Width="100px" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                                            </td>
                                                            <td align="right"></td>
                                                            <td align="left"></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right"><asp:CheckBox ID="cbOtherServices" Text="<%$ Resources:Resource, OtherServices %>" TextAlign="Left" runat="server" /></td>
                                                            <td align="left"></td>
                                                            <td align="right">
                                                                <asp:Label ID="lblFixOtherServicesIncomePerMonth" Text="<%$ Resources:Resource, IncomeOrMonth %>" runat="server" CssClass="cssLabel"></asp:Label>
                                                                <asp:Label ID="lblIncomeMonthCurr2" runat="server" CssClass="cssLabel"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="txtOtherServicesIncomePerMonth" MaxLength="12" Width="100px" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                                            </td>
                                                            <td align="right"></td>
                                                            <td align="left"></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right"><asp:CheckBox ID="cbNuclearRiskCovered" Text="<%$ Resources:Resource, NuclearRiskCovered %>" TextAlign="Left" runat="server" /></td>
                                                            <td align="left"></td>
                                                            <td align="right">
                                                                <asp:Label ID="lblFixNuclearIncident" Text="<%$ Resources:Resource, AnyOneIncident %>" runat="server" CssClass="cssLabel"></asp:Label>
                                                                <asp:Label ID="lblanyoneincCurr1" runat="server" CssClass="cssLabel"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="txtNuclearIncident" MaxLength="12" Width="100px" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                                            </td>
                                                            <td align="right">
                                                                <asp:Label ID="lblFixNuclearAggregate" Text="<%$ Resources:Resource, InTheAggregate %>" runat="server" CssClass="cssLabel"></asp:Label>
                                                                <asp:Label ID="lblInAggCurr1" runat="server" CssClass="cssLabel"></asp:Label> 
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="txtNuclearAggregate" MaxLength="12" Width="100px" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right"><asp:CheckBox ID="cbConsquentialLosses" Text="<%$ Resources:Resource, ConsquentialLosses %>" TextAlign="Left" runat="server" /></td>
                                                            <td align="left"></td>
                                                            <td align="right">
                                                                <asp:Label ID="lblFixConsquentialLossesIncident" Text="<%$ Resources:Resource, AnyOneIncident %>" runat="server" CssClass="cssLabel"></asp:Label>
                                                                <asp:Label ID="lblanyoneincCurr2" runat="server" CssClass="cssLabel"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="txtConsquentialLossesIncident" MaxLength="12" Width="100px" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                                            </td>
                                                            <td align="right">
                                                                <asp:Label ID="lblFixConsquentialLossesAggregate" Text="<%$ Resources:Resource, InTheAggregate %>" runat="server" CssClass="cssLabel"></asp:Label>
                                                                <asp:Label ID="lblInAggCurr2" runat="server" CssClass="cssLabel"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="txtConsquentialLossesAggregate" MaxLength="12" Width="100px" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="lblFixGeneralClaimsAnyOne" Text="<%$ Resources:Resource, GeneralClaimsAnyOne %>" runat="server" CssClass="cssLabel"></asp:Label>
                                                                <asp:Label ID="lblGenClaimCurr" runat="server" CssClass="cssLabel"></asp:Label>
                                                                 
                                                            </td>
                                                            
                                                            <td align="left">
                                                                <asp:TextBox ID="txtGeneralClaimsAnyOne" MaxLength="12" Width="100px" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                                            </td>
                                                            <td align="right">
                                                                <asp:Label ID="lblFixGeneralClaimsAggregate" Text="<%$ Resources:Resource, InTheAggregate %>" runat="server" CssClass="cssLabel"></asp:Label>
                                                                <asp:Label ID="lblInAggCurr3" runat="server" CssClass="cssLabel"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="txtGeneralClaimsAggregate" MaxLength="12" Width="100px" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                                            </td>
                                                            <td align="right">
                                                                <asp:CheckBox ID="cbThirdPartyIndemnity" Text="<%$ Resources:Resource, ThirdPartyIndemnity %>" TextAlign="Left" runat="server" />
                                                            </td>
                                                            <td align="left">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6">
                                                                <table border="0" width="890px">
                                                                    <tr>
                                                                        <td style="height:2px"></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="height:2px; background-color:Gray;"></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="height:2px"></td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:CheckBox ID="cbForceMajeureClause" Text="<%$ Resources:Resource, ForceMajeureClause %>" TextAlign="Left" runat="server" />
                                                            </td>
                                                            <td align="left"></td>
                                                            <td align="right">
                                                                <asp:CheckBox ID="cbHighRiskContract" Text="<%$ Resources:Resource, HighRiskContract %>" TextAlign="Left" runat="server" />
                                                            </td>
                                                            <td align="left"></td>
                                                            <td align="right">
                                                                <asp:CheckBox ID="cbPersonsMoreThenFiveThousand" Text="<%$ Resources:Resource, GreaterThen5000Persons %>" TextAlign="Left" runat="server" />
                                                            </td>
                                                            <td align="left"></td>
                                                        </tr>
                                                    </table>
                                                    
                                                    <table border="0" width="900px">
                                                        <tr>
                                                            <td align="right" style="width:200px">
                                                                <asp:Label ID="lblFixJurisdiction" Text="<%$ Resources:Resource, Jurisdiction %>" runat="server" CssClass="cssLabel"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="txtJurisdiction" MaxLength="100" Width="700px" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right" style="width:200px">
                                                                <asp:Label ID="lblFixApplicaleLaw" Text="<%$ Resources:Resource, ApplicableLaw %>" runat="server" CssClass="cssLabel"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="txtApplicaleLaw" MaxLength="100" Width="700px" runat="server" CssClass="csstxtbox"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                                <table border="0" width="890px">
                                                                    <tr>
                                                                        <td style="height:2px"></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="height:2px; background-color:Gray;"></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="height:2px"></td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" style="text-align:center">
                                                                <asp:Button ID="btnSave" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource, Save %>" OnClick="btnSave_Click" />
                                                                <asp:Button ID="btnEdit" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource, Edit %>" OnClick="btnEdit_Click" />
                                                                <asp:Button ID="btnUpdate" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource, Update %>" OnClick="btnUpdate_Click" />
                                                                <asp:Button ID="btnDelete" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource, Delete %>" OnClick="btnDelete_Click" />
                                                                <asp:Button ID="btnCancel" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource, Cancel %>" OnClick="btnCancel_Click" />
                                                                <asp:ImageButton ID="imgBack" runat="server" ImageUrl="../Images/go_Back.gif" ToolTip="<%$ Resources:Resource, ContractMaster %>" OnClick="imgBack_Click" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" style="text-align:center">
                                                                <asp:Label EnableViewState="false" ID="lblErrorMsg" Text="" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            
                        </div>
                    </ContentTemplate>
                </Ajax:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>