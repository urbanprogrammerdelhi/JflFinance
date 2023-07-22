<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="ContractMaster.aspx.cs" Inherits="Sales_ContractMaster" Title="<%$ Resources:Resource, AppTitle %>" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<script type="text/javascript" language="javascript">
    function OpenContractUpload() {
        var ClientCode = document.getElementById('<%=txtClientCode.ClientID %>').value;
        var Status = document.getElementById('<%=lblStatus.ClientID %>').innerHTML;
        var ContractNumber = document.getElementById('<%=txtContractNumber.ClientID %>').value;
        var AmendmentNo = document.getElementById('<%=ddlAmendementNumber.ClientID %>').options(document.getElementById('<%=ddlAmendementNumber.ClientID %>').selectedIndex).value;
        var PageName = "ContractUpload.aspx?ContractNumber=" + ContractNumber + "&AmendmentNo=" + AmendmentNo + "&ClientCode=" + ClientCode + "&Status=" + Status;
        window.open(PageName, null, 'status=off,center=yes,scroll=no,Width=800px,help=no');
    }
</script>
    <asp:UpdatePanel ID="up1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table border="0" width="100%">
                <tr>
                    <td align="right" style="width:100px">
                        <asp:Label ID="lblArea" runat="server" CssClass="cssLabel" Text="<%$Resources:Resource,Area %>"></asp:Label>
                    </td>
                    <td align="left"style="width:200px">
                        <asp:DropDownList ID="ddlAreaID" runat="server" AutoPostBack="true" 
                            CssClass="cssDropDown" OnSelectedIndexChanged="ddlAreaID_SelectedIndexChanged" Width="180px">
                        </asp:DropDownList>
                    </td>
                    <td align="right" style="width:100px">
                        <asp:Label ID="lblCustomerCode" runat="server" CssClass="cssLabel" Text="<%$ Resources:Resource, ClientName %>"></asp:Label>
                    </td>
                    <td align="left" style="width:300px">
                        <asp:ImageButton ID="imgSearch" runat="server" AlternateText="SearchClient" 
                            ImageUrl="~/Images/icosearch.gif" Style="display: none;" ToolTip="" />
                        <asp:DropDownList ID="ddlClient" runat="server" AutoPostBack="true" 
                            CssClass="cssDropDown" OnSelectedIndexChanged="ddlClient_SelectedIndexChanged" 
                            Width="280px">
                        </asp:DropDownList>
                    </td>
                    <td align="right" style="width:100px">
                        <asp:Label ID="lblClientCode" runat="server" CssClass="cssLabel" 
                            Text="<%$ Resources:Resource, ClientCode %>"></asp:Label>
                    </td>
                    <td style="width:150px">
                        <asp:TextBox ID="txtClientCode" runat="server" AutoPostBack="true" CssClass="csstxtbox" MaxLength="16" OnTextChanged="txtClientCode_TextChanged" Width="90px"></asp:TextBox>
                        <asp:Label ID="lblClientName" runat="server" CssClass="cssLabel" 
                            Style="display: none;" Text="<%$Resources:Resource,ClientName %>" Visible="false"></asp:Label>
                        <asp:Label ID="lblCustomerName" runat="server" CssClass="csstxtboxReadonly" 
                            Font-Bold="true" Style="display: none;" Text="" Visible="false"></asp:Label>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="up2" runat="server" UpdateMode="Always">
        <ContentTemplate>
        <AjaxToolKit:TabContainer runat="server" ID="TabContract" ActiveTabIndex="0" AutoPostBack="false">
            <AjaxToolKit:TabPanel ID="tpContractsList" runat="server" HeaderText="<%$ Resources:Resource, ContractsList %>">
                <ContentTemplate>
                    <asp:UpdatePanel ID="upContractList" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <table border="0">
                                <tr>
                                    <td>
                                        <asp:DropDownList ID="ddlSearchBy" runat="server" AutoPostBack="true" CssClass="cssDropDown" OnSelectedIndexChanged="ddlSearchBy_SelectedIndexChanged" Width="200px">
                                            <asp:ListItem Selected="True" Text="<%$Resources:Resource, ContractNo%>" Value="ContractNumber"></asp:ListItem>
                                            <asp:ListItem Text="<%$Resources:Resource, StartDate%>" Value="StartDate"></asp:ListItem>
                                            <asp:ListItem Text="<%$Resources:Resource, EndDate%>" Value="EndDate"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSearchContract" runat="server" CssClass="csstxtbox" Visible="false" Width="200px"></asp:TextBox>
                                        <asp:TextBox ID="txtSearchDate" runat="server" CssClass="csstxtbox" Visible="false" Width="200px"></asp:TextBox>
                                        <asp:HyperLink ID="imgSearchGrid" runat="server" ImageUrl="~/Images/pdate.gif" Style="vertical-align: middle;" Visible="false"></asp:HyperLink>
                                        <asp:HiddenField ID="hfSearchText" runat="server" />
                                    </td>
                                    <td>
                                        <asp:Button ID="btnSearch" runat="server" CssClass="cssButton" OnClick="btnSearch_Click" Text="<%$Resources:Resource,Search %>" />
                                    </td>
                                    <td>
                                        <asp:Button ID="btnViewAll" runat="server" CssClass="cssButton" OnClick="btnViewAll_Click" Text="<%$Resources:Resource,ViewAll %>" Visible="false" />
                                    </td>
                                </tr>
                            </table>
                            <asp:GridView ID="gvLOIReceived" runat="server" AllowPaging="true" AllowSorting="true" AutoGenerateColumns="False" CellPadding="1" 
                                CssClass="GridViewStyle" GridLines="None" OnPageIndexChanging="gvLOIReceived_PageIndexChanging" 
                                OnRowDataBound="gvLOIReceived_RowDataBound" OnSorting="gvLOIReceived_Sorting" PageSize="6" Width="100%">
                                <FooterStyle CssClass="GridViewFooterStyle" />
                                <RowStyle CssClass="GridViewRowStyle" />
                                <SelectedRowStyle CssClass="GridViewSelectedRowStyleContarct"/>
                                <PagerStyle CssClass="GridViewPagerStyle" />
                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                <HeaderStyle CssClass="GridViewHeaderStyle" />
                                <Columns>
                                    <asp:TemplateField HeaderText="<%$ Resources:Resource,ContractNo%>" 
                                        SortExpression="ContractNumber">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbContractNumberGrid" runat="server" CausesValidation="false" 
                                                CssClass="csslnkButton" OnClick="lbContractNumberGrid_Click" 
                                                Text='<%# Bind("ContractNumber") %>'></asp:LinkButton>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                                        <ItemStyle Width="200px" />
                                        <FooterStyle Width="200px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$ Resources:Resource,MContractNo%>" 
                                        SortExpression="MContractNumber">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMContractNo" runat="server" CssClass="cssLabel" 
                                                Text='<%# Bind("MContractNumber") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                                        <ItemStyle Width="200px" />
                                        <FooterStyle Width="200px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$ Resources:Resource,AmendmentNo %>" 
                                        SortExpression="AmendmentNo" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAmendNoGrid" runat="server" CssClass="cssLabel" 
                                                Text='<%# Bind("AmendmentNo") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                                        <ItemStyle Width="200px" />
                                        <FooterStyle Width="200px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$ Resources:Resource,StartDate %>" 
                                        SortExpression="StartDate">
                                        <ItemTemplate>
                                            <asp:Label ID="lblLOIStartDateGrid" runat="server" CssClass="cssLabel" 
                                                Text='<%#String.Format("{0:d-MMM-yyyy}",Eval("StartDate")) %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="cssLabelHeader" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$ Resources:Resource,EndDate %>" 
                                        SortExpression="EndDate">
                                        <ItemTemplate>
                                            <asp:Label ID="lblLOIEndDateGrid" runat="server" CssClass="cssLabel" 
                                                Text='<%#String.Format("{0:d-MMM-yyyy}",Eval("EndDate")) %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="cssLabelHeader" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:Label ID="lblErrorMsgGrid1" runat="server" CssClass="csslblErrMsg" EnableViewState="false" Text=""></asp:Label>
                         </ContentTemplate>
                    </asp:UpdatePanel>
                </ContentTemplate>
            </AjaxToolKit:TabPanel>
            <AjaxToolKit:TabPanel ID="tpNewContract" runat="server" HeaderText="<%$ Resources:Resource, Contract %>">
                <ContentTemplate>
                    <Ajax:UpdatePanel runat="server" ID="upContractLoi" UpdateMode="Always" >
                        <ContentTemplate>
                            <div id="DivPanelContractHeader" runat="server" >
                                <table border="0" width="100%">
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label1" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,ContractNo %>"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <%--<asp:Label ID="lblContractNumber" CssClass="cssLabel" Font-Bold="true" Width="120px" runat="server"></asp:Label>--%>
                                            <asp:TextBox ID="txtContractNumber" CssClass="csstxtboxReadonly" Font-Bold="true" Width="120px" runat="server" ReadOnly="true"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="Server" ID="RfvContractNumber" ErrorMessage=""  ValidationGroup="Save" ControlToValidate="txtContractNumber"> </asp:RequiredFieldValidator>
                                            <asp:Label ID="LabelStarContractNo" CssClass="cssLabel" ForeColor="Red" runat="server" Text="*"></asp:Label>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label20" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,AmendmentNo %>"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlAmendementNumber" CssClass="cssDropDown" Width="80px" runat="server"
                                                AutoPostBack="True" OnSelectedIndexChanged="ddlAmendementNumber_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label10" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,WEFDate %>"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtWEF" Enabled="false" runat="server" CssClass="csstxtbox" Style="width: 90px;"
                                                AutoPostBack="true" Text=""></asp:TextBox>
                                            <asp:HyperLink ID="imgWEF" Visible="true" Style="vertical-align: top;" runat="server"
                                                ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                                            <AjaxToolKit:CalendarExtender ID="CalendarExtender6" Format="dd-MMM-yyyy" runat="server"
                                                TargetControlID="txtWEF" PopupButtonID="imgWEF" Enabled="True">
                                            </AjaxToolKit:CalendarExtender>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label25" CssClass="cssLabel" Visible="false" runat="server" Text="<%$Resources:Resource,ShortCloseDate %>"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtSCD" Enabled="false" Visible="false" runat="server" CssClass="csstxtbox"
                                                Style="width: 100px;" AutoPostBack="true" Text=""></asp:TextBox>
                                            <asp:HyperLink ID="imgSCD" Visible="false" Style="vertical-align: middle;" runat="server"
                                                ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                                            <AjaxToolKit:CalendarExtender ID="CalendarExtender7" Format="dd-MMM-yyyy" runat="server"
                                                TargetControlID="txtSCD" PopupButtonID="imgSCD" Enabled="True">
                                            </AjaxToolKit:CalendarExtender>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label7" CssClass="cssLabelHeader" runat="server" Text="<%$Resources:Resource,Status %>"></asp:Label>
                                            <asp:Label ID="lblStatus" CssClass="csstxtboxReadonly" Font-Bold="true" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div id="DivPanelLOIReceived" runat="server">
                                <div style="height:20px; background-color:silver; text-align:center;">
                                    <asp:Label ID="Label19" runat="server" Text="LOI Received"></asp:Label>
                                </div>
                                <div>
                                    <table border="0" width="100%">
                                        <tr>
                                            <td align="right" width="150px">
                                                <asp:Label ID="Label6" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,LOIDate %>"></asp:Label>
                                            </td>
                                            <td align="left" width="150px">
                                                <asp:TextBox ID="txtLOIDate" runat="server" CssClass="csstxtbox" Style="width: 90px;"
                                                    AutoPostBack="true" Text=""></asp:TextBox>
                                                <asp:HyperLink ID="ImgLOIDate" Style="vertical-align: middle;" runat="server" ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                                                <AjaxToolKit:CalendarExtender ID="CalendarExtender1" Format="dd-MMM-yyyy" runat="server"
                                                    TargetControlID="txtLOIDate" PopupButtonID="imgLOIDate" />
                                            </td>
                                            <td align="right" width="150px">
                                                <asp:Label ID="Label11" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,LOIStartDate %>"></asp:Label>
                                            </td>
                                            <td align="left" width="150px">
                                                <asp:TextBox ID="txtLOIStartDate" runat="server" CssClass="csstxtbox" Style="width: 90px;"
                                                    AutoPostBack="true" Text=""></asp:TextBox>
                                                <asp:HyperLink ID="imgLOIStartDate" Style="vertical-align: middle;" runat="server"
                                                    ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                                                <AjaxToolKit:CalendarExtender ID="CalendarExtender2" Format="dd-MMM-yyyy" runat="server"
                                                    TargetControlID="txtLOIStartDate" PopupButtonID="imgLOIStartDate" />
                                            </td>
                                            <td align="right" width="150px">
                                                <asp:Label ID="Label12" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,LOIEndDate %>"></asp:Label>
                                            </td>
                                            <td align="left" width="150px">
                                                <asp:TextBox ID="txtLOIEndDate" runat="server" CssClass="csstxtbox" Style="width: 90px;"
                                                    AutoPostBack="true" Text=""></asp:TextBox>
                                                <asp:HyperLink ID="ImgLOIEndDate" Style="vertical-align: middle;" runat="server"
                                                    ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                                                        <AjaxToolKit:CalendarExtender ID="CalendarExtender3" Format="dd-MMM-yyyy" runat="server"
                                                    TargetControlID="txtLOIEndDate" PopupButtonID="ImgLOIEndDate" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="Label4" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,IssuingAuthority %>"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtIssuingAuthority" CssClass="csstxtbox" Width="180px" runat="server"
                                                    MaxLength="50"></asp:TextBox>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="Label5" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,DeliveryDate %>"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtDeliveryDate" runat="server" CssClass="csstxtbox" Style="width: 90px;"
                                                    AutoPostBack="true" Text=""></asp:TextBox>
                                                <asp:HyperLink ID="ImgDeliveryDate" Style="vertical-align: middle;" runat="server"
                                                    ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                                                <AjaxToolKit:CalendarExtender ID="CalendarExtender4" Format="dd-MMM-yyyy" runat="server"
                                                    TargetControlID="txtDeliveryDate" PopupButtonID="ImgDeliveryDate" />
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="Label8" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,DeliveryTo %>"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtDeliveryTo" CssClass="csstxtbox" Width="180px" runat="server"
                                                    MaxLength="50"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" nowrap="nowrap">
                                                <asp:Label ID="Label9" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,ExpectedSigningDate %>"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtExpectedSignDate" runat="server" CssClass="csstxtbox" Style="width: 90px;"
                                                    AutoPostBack="true" Text=""></asp:TextBox>
                                                <asp:HyperLink ID="imgExpectedSignDate" Style="vertical-align: middle;" runat="server"
                                                    ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                                                    <AjaxToolKit:CalendarExtender ID="CalendarExtender5" Format="dd-MMM-yyyy" runat="server"
                                                    TargetControlID="txtExpectedSignDate" PopupButtonID="imgExpectedSignDate" />

                                            </td>
                                            <%--<td align="right" nowrap="nowrap">
                                                <asp:Label ID="Label21" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,ContractPaperSigned %>"></asp:Label>
                                            </td>--%>
                                            <td align="center" colspan="2">
                                                <asp:CheckBox ID="cbContractPaperDelivered" Text="<%$Resources:Resource,ContractPaperSigned %>" TextAlign="Left"  runat="server" AutoPostBack="True" OnCheckedChanged="cbContractPaperDelivered_CheckedChanged" />
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="Label3" CssClass="cssLabel" Visible="false" runat="server" Text="<%$Resources:Resource,AmendmentNo %>"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtAmendmentNo" Visible="false" ReadOnly="true" CssClass="csstxtbox"
                                                    Width="55px" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <div id="DivPanelContractPaperReceived" runat="server">
                                <div style="height:20px; background-color:silver; text-align:center;">
                                    <asp:Label ID="Label2" runat="server" Text="<%$Resources:Resource,ContractPaper %>"></asp:Label>
                                </div>
                                <div>
                                    <table border="0" width="100%">
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="Label16" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,ContractSignDate %>"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtContractSignDate" runat="server" CssClass="csstxtbox" Style="width: 90px;"
                                                    AutoPostBack="true" Text=""></asp:TextBox>
                                                <asp:HyperLink ID="imgContractSignDate" Style="vertical-align: middle;" runat="server"
                                                    ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                                                <AjaxToolKit:CalendarExtender ID="ceContractSignDate" Format="dd-MMM-yyyy" runat="server"
                                                    TargetControlID="txtContractSignDate" PopupButtonID="imgContractSignDate" />
                                                        <%--Manish To display * infront of mandatory Fileds --%>
                                                        <asp:RequiredFieldValidator runat="Server" ID="RfvContractSignDate" ErrorMessage="" 
                                                        ControlToValidate="txtContractSignDate"> </asp:RequiredFieldValidator>
                                                        <%--Ajay To display * infront of mandatory Fileds Permanently - Israel Requirement--%>
                                                        <asp:Label ID="LabelStarContractSignDate" CssClass="cssLabel" ForeColor="Red" runat="server" Text="*"></asp:Label>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="Label17" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,ContractStartDate %>"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtContractStartDate" runat="server" CssClass="csstxtbox" Style="width: 90px;"
                                                    AutoPostBack="true" Text="" 
                                                    ontextchanged="txtContractStartDate_TextChanged"></asp:TextBox>
                                                <asp:HyperLink ID="imgContractStartDate" Style="vertical-align: middle;" runat="server"
                                                    ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                                                <AjaxToolKit:CalendarExtender ID="ceContractStartDate" Format="dd-MMM-yyyy" runat="server"
                                                    TargetControlID="txtContractStartDate" PopupButtonID="imgContractStartDate" />
                                                        <%--Manish To display * infront of mandatory Fileds --%>
                                                        <asp:RequiredFieldValidator runat="Server" ID="RfvContractStartDate" ErrorMessage="" 
                                                        ControlToValidate="txtContractStartDate"> </asp:RequiredFieldValidator>
                                                        <%--Ajay To display * infront of mandatory Fileds Permanently - Israel Requirement--%>
                                                        <asp:Label ID="LabelStarContractStartDate" CssClass="cssLabel" ForeColor="Red" runat="server" Text="*"></asp:Label>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="Label18" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,ContractEndDate %>"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtContractEndDate" runat="server" CssClass="csstxtbox" Style="width: 90px;"
                                                    AutoPostBack="true" Text="" ontextchanged="txtContractEndDate_TextChanged"></asp:TextBox>
                                                <asp:HyperLink ID="imgContractEndDate" Style="vertical-align: middle;" runat="server"
                                                    ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                                                <AjaxToolKit:CalendarExtender ID="ceContractEndDate" Format="dd-MMM-yyyy" runat="server"
                                                    TargetControlID="txtContractEndDate" PopupButtonID="imgContractEndDate" />
                                                        <%--Manish To display * infront of mandatory Fileds --%>
                                                    <asp:RequiredFieldValidator runat="Server" ID="RfvContractEndDate" ErrorMessage="" 
                                                        ControlToValidate="txtContractEndDate"> </asp:RequiredFieldValidator>
                                                    <%--Ajay To display * infront of mandatory Fileds Permanently - Israel Requirement--%>
                                                    <asp:Label ID="LabelStarContractEndDate" CssClass="cssLabel" ForeColor="Red" runat="server" Text="*"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td td align="right" width="150px" style="height: 23px" >
                                                <asp:Label ID="Label13" runat="server" CssClass="cssLabel" Text="<%$Resources:Resource,MContractNo %>"></asp:Label>
                                            </td>
                                            <td align="left" style="height: 23px">
                                                <asp:TextBox ID="txtManualContractNo" CssClass="csstxtbox" runat="server" MaxLength="35"  Width="180px"></asp:TextBox>
                                                    <%--Manish To display * infront of mandatory Fileds --%>
                                                                
                                                <%--Ajay To display * infront of mandatory Fileds Permanently - Israel Requirement--%>
                                                <asp:Label ID="LabelStarManualContractNo" CssClass="cssLabel" ForeColor="Red" runat="server" Text="*"></asp:Label>
                                                <asp:RequiredFieldValidator runat="Server" ID="RfvManualContractNo" ErrorMessage="" 
                                                        ControlToValidate="txtManualContractNo"> </asp:RequiredFieldValidator>
                                            </td>
                                            <td align="right" style="height: 23px">
                                                <asp:Label ID="Label14" runat="server" CssClass="cssLabel" Text="<%$Resources:Resource,ClientSigningAuthority %>"></asp:Label>
                                            </td>
                                            <td align="left" style="height: 23px" >
                                                <asp:TextBox ID="txtClientSigningAuthority" CssClass="csstxtbox" runat="server" MaxLength="50"  Width="180px"></asp:TextBox>
                                                    <%--Manish To display * infront of mandatory Fileds --%>
                                                               
                                                    <%--Ajay To display * infront of mandatory Fileds Permanently - Israel Requirement--%>
                                                    <asp:Label ID="LabelStarClientSigningAuthority" CssClass="cssLabel" ForeColor="Red" runat="server" Text="*"></asp:Label>
                                                    <asp:RequiredFieldValidator runat="Server" ID="RfvClientSigningAuthority" ErrorMessage=""
                                                        ControlToValidate="txtClientSigningAuthority"> </asp:RequiredFieldValidator>
                                            </td>
                                            <td align="right" style="height: 23px" >
                                                <asp:Label ID="Label15" runat="server" CssClass="cssLabel" Text="<%$Resources:Resource,DesignationOfAuthority %>"></asp:Label>
                                            </td>
                                            <td  align="left" style="height: 23px" >
                                                <asp:TextBox ID="txtDesignationAuthority" CssClass="csstxtbox" runat="server" MaxLength="50" Width="180px"></asp:TextBox>
                                                <%--Manish To display * infront of mandatory Fileds --%>
                                                               
                                                    <%--Ajay To display * infront of mandatory Fileds Permanently - Israel Requirement--%>
                                                    <asp:Label ID="LabelStarDesignationAuthority" CssClass="cssLabel" ForeColor="Red" runat="server" Text="*"></asp:Label>
                                                    <asp:RequiredFieldValidator runat="Server" ID="RfvDesignationAuthority" ErrorMessage="" 
                                                        ControlToValidate="txtDesignationAuthority"> </asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="Label22" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource, ContractValue%>"></asp:Label>
                                                <asp:Label ID="lblDefaultCurrency" CssClass="cssLabel" runat="server"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtContractValue" Enabled="false" CssClass="csstxtbox" Style="font-weight: bold" Width="100px" runat="server" MaxLength="16"></asp:TextBox>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblContractReviewDate" runat="server" CssClass="cssLabel" Text="<%$Resources:Resource,ContractReviewDate %>"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtContractReviewDate" runat="server" CssClass="csstxtbox" 
                                                    Style="width: 90px;" AutoPostBack="true" Text="" 
                                                    ontextchanged="txtContractReviewDate_TextChanged"></asp:TextBox>
                                                <asp:HyperLink ID="imgContractReviewDate" Style="vertical-align: middle;" runat="server" ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                                                <AjaxToolKit:CalendarExtender ID="ceContractReviewDate" Format="dd-MMM-yyyy" runat="server" TargetControlID="txtContractReviewDate" PopupButtonID="imgContractReviewDate" />
                                                <asp:RequiredFieldValidator runat="Server" ID="RfvContractReviewDate" ErrorMessage="" ControlToValidate="txtContractReviewDate"> </asp:RequiredFieldValidator>
                                                <asp:Label ID="LabelStarContractReviewDate" CssClass="cssLabel" ForeColor="Red" runat="server" Text="*"></asp:Label>
                                            </td>
                                            <td colspan="2"></td>
                                        </tr>
                                    </table>
                                </div>
                                <div style="height:20px; background-color:silver; text-align:center;">
                                    <asp:Label ID="Label23" runat="server" Text="<%$Resources:Resource,OtherDetails %>"></asp:Label>
                                </div>
                                <div>
                                    <table border="0" width="100%">
                                        <tr>
                                            <td colspan="2" align="right">
                                                <asp:CheckBox runat="server" TextAlign="Left" ID="cbIfWeCanTerminate" Text="<%$Resources:Resource, IfWeCanTerminate%>"/>
                                            </td>
                                             <td align="right">
                                                <asp:Label ID="Label28" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource, NoticePeriodToTerminateInDays%>"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtNoticePeriodDaysToTerminate" CssClass="csstxtbox" MaxLength="5"  Width="90px" runat="server"></asp:TextBox>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="Label31" runat="server" CssClass="cssLabel" Text="<%$Resources:Resource,NoticToClientToRenewalInDays %>"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtClientNoticeToRenewalInDays" CssClass="csstxtbox" runat="server" MaxLength="5" Text="" Width="100px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" colspan="2">
                                                <asp:CheckBox runat="server" TextAlign="Left" ID="cbIsAutoRenewal" Text="<%$Resources:Resource, IsAutoRenewal%>"/>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="Label27" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource, RenewalInMonths%>"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtRenewalInMonths" CssClass="csstxtbox" Style="font-weight: bold" Width="100px" runat="server" MaxLength="3"></asp:TextBox>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="Label32" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource, Insurance%>"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtInsurance" CssClass="csstxtbox" runat="server" MaxLength="15" Text=""></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" colspan="2">
                                                <asp:CheckBox runat="server" TextAlign="Left" ID="cbIsLimitedWarranty" Text="<%$Resources:Resource, IsLimitedWarranty%>"/>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="Label29" runat="server" CssClass="cssLabel" Text="<%$Resources:Resource,TotalWarrantyAmount %>"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtTotalWarrantyAmount" CssClass="csstxtbox" runat="server" MaxLength="20" Text="" Width="100px"></asp:TextBox>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblContractAlert" runat="server" CssClass="cssLabel" Text="<%$Resources:Resource,ContractPriorAlert %>"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtContractAlert" CssClass="csstxtbox" runat="server" MaxLength="50" Enabled="false" Text='<%# Bind("ParamValue") %>' Width="43px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" colspan="2">
                                                <asp:CheckBox runat="server" TextAlign="Left" ID="cbIsScanCopyExists" Text="<%$Resources:Resource, IsScanCopyExists%>"/>
                                            </td>
                                            <td align="center" colspan="2">
                                                <asp:Button ID="btnUpload" CssClass="cssButton" runat="server" Text="<%$Resources:Resource,UploadDownload %>" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <div id="DivButtonContainer" runat="server">
                                <table border="0">
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnAddNew" Visible="false" runat="server" CssClass="cssButton" Text="<%$Resources:Resource,AddNew %>"
                                                OnClick="btnAddNew_Click" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnAmend" ValidationGroup="Amend" CssClass="cssButton" Visible="false"
                                                runat="server" Text="<%$Resources:Resource,Amend %>" OnClick="btnAmend_Click" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnAuthorize" runat="server" CssClass="cssButton" Visible="false"
                                                Text="<%$Resources:Resource,Authorize %>" OnClick="btnAuthorize_Click"  CausesValidation="false"/>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnSave" ValidationGroup="Save" CssClass="cssButton" runat="server"
                                                Visible="false" Text="<%$Resources:Resource,Save %>" OnClick="btnSave_Click" CausesValidation="false" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnUpdate" ValidationGroup="Save" CssClass="cssButton" runat="server"
                                                Visible="false" Text="<%$Resources:Resource,Update %>" OnClick="btnUpdate_Click" CausesValidation="false" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnEdit" ValidationGroup="Save" CssClass="cssButton" runat="server"
                                                Visible="false" Text="<%$Resources:Resource,Edit %>" OnClick="btnEdit_Click" CausesValidation="false" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnDelete" runat="server" Visible="false" CssClass="cssButton" Text="<%$Resources:Resource,Delete %>"
                                                OnClick="btnDelete_Click" CausesValidation="false" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnShortClose" runat="server" Visible="false" CssClass="cssButton"
                                                Text="<%$Resources:Resource,ShortClosed %>" OnClick="btnShortClose_Click" CausesValidation="false" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnCancel" runat="server" Visible="false" CssClass="cssButton" Text="<%$Resources:Resource,Cancel %>"
                                                OnClick="btnCancel_Click"  CausesValidation="false"/>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnViewSO" Visible="false" runat="server" CssClass="cssButton" Text="<%$Resources:Resource,ViewSO %>"
                                                OnClick="btnViewSO_Click" CausesValidation="false" />
                                            </td>
                                            <td>
                                            <asp:Button ID="btnViewCubicDetails" runat="server" CssClass="cssButton" style="display:none;" Text="<%$Resources:Resource,qubicDetail %>"
                                                OnClick="btnViewCubicDetails_Click" CausesValidation="false" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnCreateSaleOrder" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource, CreateSaleOrder %>" OnClick="btnCreateSaleOrder_Click" CausesValidation="false" />
                                            <asp:HiddenField runat="server" ID="hfContractNumber" />
                                            <asp:HiddenField runat="server" ID="hfMaxAmendmentNumber" />
                                            <asp:HiddenField runat="server" ID="HFOldContractEndDate" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="11">
                                            <asp:Label ID="lblErrorMsgGrid" runat="server" CssClass="csslblErrMsg" EnableViewState="false" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </ContentTemplate>
                    </Ajax:UpdatePanel>
                </ContentTemplate>
            </AjaxToolKit:TabPanel>
            <AjaxToolKit:TabPanel ID="tpSaleOrder" runat="server" HeaderText="<%$ Resources:Resource, SaleOrderDetails %>">
                <ContentTemplate>
                    <Ajax:UpdatePanel runat="server" ID="upSaleOrder" UpdateMode="Always">
                        <ContentTemplate>
                            <asp:GridView Width="100%" ID="gvViewSO" AllowPaging="True" CssClass="GridViewStyle"
                                runat="server" CellPadding="1" GridLines="None" AutoGenerateColumns="False" AllowSorting="True"
                                PageSize="4" OnSorting="gvViewSO_Sorting" OnPageIndexChanging="gvViewSO_PageIndexChanging">
                                <FooterStyle CssClass="GridViewFooterStyle" />
                                <RowStyle CssClass="GridViewRowStyle" />
                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                <PagerStyle CssClass="GridViewPagerStyle" />
                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                <HeaderStyle CssClass="GridViewHeaderStyle" />
                                <Columns>
                                    <asp:TemplateField HeaderText="<%$Resources:Resource,SONo %>" SortExpression="SoNo">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbSaleOrderNo" CssClass="cssLink" runat="server" Text='<%# Bind("SoNo") %>'
                                                OnClick="lbSaleOrderNo_Click"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$Resources:Resource,Location %>" SortExpression="LocationDesc">
                                        <ItemTemplate>
                                            <asp:Label ID="Label2" CssClass="cssLabel" runat="server" Text='<%# Bind("LocationDesc") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$Resources:Resource,SOStatus %>" SortExpression="SoStatus">
                                        <ItemTemplate>
                                            <asp:Label ID="Label3" CssClass="cssLabel" runat="server" Text='<%# Bind("SoStatus") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$Resources:Resource,SoType %>" SortExpression="SoType">
                                        <ItemTemplate>
                                            <asp:Label ID="Label4" runat="server" CssClass="cssLabel" Text='<%# Bind("SoType") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$Resources:Resource,TerminationDate %>" SortExpression="SoTerminationDate">
                                        <ItemTemplate>
                                            <asp:Label ID="Label5" CssClass="cssLabel" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("SoTerminationDate")) %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$Resources:Resource,TerminatedBy %>" SortExpression="SoTerminatedBy">
                                        <ItemTemplate>
                                            <asp:Label ID="Label6" runat="server" CssClass="cssLabel" Text='<%# Bind("SoTerminatedBy") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$Resources:Resource,TerminationReason %>" SortExpression="SoTerminationReason">
                                        <ItemTemplate>
                                            <asp:Label ID="Label7" CssClass="cssLabel" runat="server" Text='<%# Bind("SoTerminationReason") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </ContentTemplate>
                    </Ajax:UpdatePanel>  
                </ContentTemplate>
            </AjaxToolKit:TabPanel>
        </AjaxToolKit:TabContainer>
        </ContentTemplate>
    </asp:UpdatePanel>

<script type="text/javascript" language="javascript">
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

    }

</script>

</asp:Content>
