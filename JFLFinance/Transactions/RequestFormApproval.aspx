<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RequestFormApproval.aspx.cs" Inherits="Transactions_RequestFormApproval" MasterPageFile="~/MasterPage/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="950px" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <div style="width: 950px;">
                    <div class="squarebox">
                        <div class="squareboxgradientcaption" style="height: 15px; cursor: pointer;" ">
                            <div style="float: left; width: 930px;">
                                <table border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="height: 12px; width: 33%">
                                        </td>
                                        <td style="height: 12px; width: 33%" align="center">
                                            <asp:Label ID="Label2" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, RequestForm %>"></asp:Label>
                                        </td>
                                         <td style="width: 33%" align="right">
                                            <Ajax:UpdatePanel runat="server" ID="upRequestStatus" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <asp:Label Width="130px" ID="lblfixStatus" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, Status %>"></asp:Label>
                                                    <asp:Label Width="130px" Style="font-weight: bold;" ID="lblStatus" CssClass="csstxtboxReadonly" runat="server"></asp:Label>
                                                    <asp:HiddenField runat="server" ID="hfStatus" Value=""/>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <Ajax:AsyncPostBackTrigger ControlID="btnAccept" EventName="Click" />
                                                    <Ajax:AsyncPostBackTrigger ControlID="btnReject" EventName="Click" />
                                                    <Ajax:AsyncPostBackTrigger ControlID="txtRequestNo" EventName="TextChanged" />
                                                </Triggers>
                                            </Ajax:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div class="squareboxcontent">
                            <div id="Div2" style="overflow: auto; width: 969px; height: 180px">
                                <Ajax:UpdatePanel runat="server" ID="UpdatePanel2" UpdateMode="Always">
                                    <ContentTemplate>
                                        <table border="0" cellpadding="0" cellspacing="0" width="940px">
                                            <tr>
                                                <td align="right" style="width: 150px">
                                                    <asp:Label ID="lblRequestNo" Text="<%$Resources:Resource,requestnumber%>" runat="server" CssClass="cssLabel"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 300px">
                                                    <asp:TextBox ID="txtRequestNo" Width="260px" runat="server" CssClass="csstxtboxReadonly" OnTextChanged="txtRequestNo_TextChanged" AutoPostBack="true"> </asp:TextBox>
                                                    <asp:ImageButton ID="ibtnSearch" runat="server" ImageUrl="~/Images/search.png" Style="height: 16px" />
                                                </td>
                                                <td align="right" colspan="2">
                                                </td>
                                            </tr>
                                        </table>
                                        <asp:Panel ID="Panel2" GroupingText="<%$Resources:Resource,RequestedBy%>" BorderWidth="0px" runat="server" Width="950px" ScrollBars="Auto" CssClass="ScrollBar">
                                        <table border="0" cellpadding="0" cellspacing="0" width="940px">
                                            <tr>
                                                <td align="right" style="width: 150px">
                                                    <asp:Label ID="Label3" runat="server" Text="<%$Resources:Resource,Division%>" CssClass="cssLabel"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 300px">
                                                    <asp:TextBox ID="txtDivision" Width="250px" runat="server" CssClass="csstxtbox"> </asp:TextBox>
                                                </td>
                                                <td align="right" style="width: 150px">
                                                    <asp:Label ID="Label4" runat="server" Text="<%$Resources:Resource,Location%>" CssClass="cssLabel"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 300px">
                                                    <asp:TextBox ID="txtLocation" Width="250px" runat="server" CssClass="csstxtbox"> </asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" style="width: 150px">
                                                    <asp:Label ID="Label7" runat="server" Text="<%$Resources:Resource,AreaId%>" CssClass="cssLabel"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 300px">
                                                    <asp:TextBox ID="txtAreaId" Width="50px" runat="server" CssClass="csstxtbox"> </asp:TextBox>
                                                </td>
                                                <td align="right" style="width: 150px">
                                                    <asp:Label ID="lblClient" runat="server" Text="<%$Resources:Resource,ClientName%>" CssClass="cssLabel"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 300px">
                                                    <asp:TextBox ID="txtClientCode" Width="50px" runat="server" CssClass="csstxtbox"> </asp:TextBox>
                                                    <asp:TextBox ID="txtClientName" Width="192px" runat="server" CssClass="csstxtbox"> </asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" style="width: 150px">
                                                    <asp:Label ID="lblAssgn" runat="server" Text="<%$Resources:Resource,Assignment%>" CssClass="cssLabel"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 300px">
                                                    <asp:TextBox ID="txtAsmtId" Width="50px" runat="server" CssClass="csstxtbox"> </asp:TextBox>
                                                    <asp:TextBox ID="txtAsmtAddress" Width="192px" runat="server" CssClass="csstxtbox"> </asp:TextBox>
                                                </td>
                                                <td align="right" style="width: 150px">
                                                    <asp:Label ID="lblSite" runat="server" Text="<%$Resources:Resource,Post%>" CssClass="cssLabel"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 300px">
                                                    <asp:TextBox ID="txtPostDesc" Width="250px" runat="server" CssClass="csstxtbox"> </asp:TextBox>
                                                    <asp:HiddenField ID="hfPostAutoId" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" style="width: 150px">
                                                    <asp:Label ID="Label5" runat="server" Text="<%$Resources:Resource,SoRank%>" CssClass="cssLabel"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 300px">
                                                    <asp:TextBox ID="txtSoRank" Width="200px" runat="server" CssClass="csstxtbox"> </asp:TextBox>
                                                </td>
                                                <td colspan="2"></td>
                                            </tr>
                                            <tr>
                                                <td align="right" style="width: 150px">
                                                    <asp:Label ID="lblRequestedBy" runat="server" Text="<%$Resources:Resource,UserId%>" CssClass="cssLabel"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 300px">
                                                    <asp:TextBox ID="txtRequestedBy" Width="250px" runat="server" CssClass="csstxtbox"> </asp:TextBox>
                                                </td>
                                                <td align="right" style="width: 150px">
                                                    <asp:Label ID="Label6" runat="server" Text="<%$Resources:Resource,Date%>" CssClass="cssLabel"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 300px">
                                                    <asp:TextBox ID="txtRequestedDate" Width="250px" runat="server" CssClass="csstxtbox"> </asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" align="center">
                                                    <asp:Label runat="server" ID="lblError" CssClass="csslblErrMsg" EnableViewState="true"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" align="right">
                                                    <asp:Button ID="btnCloseRequest" runat="server" CssClass="cssButton" Text="<%$Resources:Resource,CloseRequest%>" OnClick="btnCloseRequest_Click" />
                                                    &nbsp;&nbsp;&nbsp;
                                                    <asp:Button ID="btnAccept" runat="server" CssClass="cssButton" Text="<%$Resources:Resource,Accept%>" OnClick="btnAccept_Click" />
                                                    &nbsp;&nbsp;&nbsp;
                                                    <asp:Button ID="btnReject" runat="server" CssClass="cssButton" Text="<%$Resources:Resource,Reject%>" OnClick="btnReject_Click" />
                                                    &nbsp;&nbsp;&nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                        </asp:Panel>
                                    </ContentTemplate>
                                </Ajax:UpdatePanel>
                            </div>
                        </div>
                    </div>
                    
                </div>
                        <div style="width: 98%;">
                            <div class="squarebox">
                                <div class="squareboxgradientcaption" style="height: 15px; cursor: pointer;" ">
                                    <div style="float: left; width: 900px;">
                                        <tt style="text-align: center;">
                                            <asp:Label ID="Label1" Style="text-align: center;" CssClass="squareboxgradientcaption" runat="server" Text="<%$Resources:Resource,RequestDetail%>"></asp:Label></tt>
                                    </div>
                                </div>
                                <div class="squareboxcontent">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Panel ID="Panel1" BorderWidth="0px" runat="server" Width="960px" Height="240px"
                                                    ScrollBars="Auto" CssClass="ScrollBar">
                                                    <Ajax:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Always">
                                                    <ContentTemplate>
                                                    <asp:GridView runat="server" ID="gvRequest" Width="100%" CssClass="GridViewStyle"
                                                        ShowHeader="true" AllowPaging="true" PageSize="5" CellPadding="3" GridLines="None"
                                                        AutoGenerateColumns="False" OnRowEditing="gvRequest_OnRowEditing" OnRowUpdating="gvRequest_RowUpdating"
                                                        OnPageIndexChanging="gvRequest_PageIndexChanging" OnRowCancelingEdit="gvRequest_RowCancelingEdit" 
                                                        OnRowCommand="gvRequest_RowCommand" OnRowDataBound="gvRequest_RowDataBound">   
                                                        <FooterStyle CssClass="GridViewFooterStyle" />
                                                        <RowStyle CssClass="GridViewRowStyle" />
                                                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                        <PagerStyle CssClass="GridViewPagerStyle" />
                                                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                        <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                        <Columns>
                                                            <asp:TemplateField ItemStyle-Width="10px" HeaderStyle-Width="10px" FooterStyle-Width="10px">
                                                                <HeaderTemplate>
                                                                    <asp:Label Width="10px" ID="lblgvHdrSoNo" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,SerialNumber %>"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label Width="10px" ID="lblgvItSno" CssClass="cssLable" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="30px" HeaderStyle-Width="30px" FooterStyle-Width="30px">
                                                                <HeaderTemplate>
                                                                    <asp:Label Width="50px" ID="lblgvHdrLineNo" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,RequestLineNo %>"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label Width="50px" ID="lblgvLineNo" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RequestLineNo").ToString()%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-Width="80px" FooterStyle-Width="60px">
                                                                <HeaderTemplate>
                                                                    <asp:Label Width="80px" ID="lblgvHdrSLineNo" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,RequestSubLineNo %>"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label Width="80px" ID="lblgvSLineNo" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RequestSubLineNo").ToString()%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="120px" HeaderStyle-Width="120px" FooterStyle-Width="120px">
                                                                <HeaderTemplate>
                                                                    <asp:Label Width="110px" ID="lblgvHdrEmpNo" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,EmployeeNumber %>"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblgvEmpNo" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EmployeeNumber").ToString()%>'> </asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:Label ID="lblgvEmpNo" style ="display:none;" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EmployeeNumber").ToString()%>'> </asp:Label>
                                                                    <asp:TextBox ID="txtgvEmpNo" Width="80px" onkeydown="javascript:FunctionCallOnKeyDown('EmployeeNumber',this)" CssClass="csstxtbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EmployeeNumber").ToString()%>'></asp:TextBox>
                                                                    <asp:ImageButton ID="iBtnEmpSearch" runat="server" CommandName="EmployeeSearch" ImageUrl="~/Images/search.png" Style="height: 16px" />
                                                                    <asp:HiddenField ID="hfEmployeeNumber" runat="server" Value='<%# Eval("EmployeeNumber")%>' />
                                                                </EditItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="150px" HeaderStyle-Width="150px" FooterStyle-Width="150px">
                                                                <HeaderTemplate>
                                                                    <asp:Label Width="150px" ID="lblgvHdrEmpNo" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,EmployeeName %>"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblgvEmpName" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EmployeeName").ToString()%>'> </asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:Label ID="txtgvEmpName" CssClass="csstxtbox" Width="200px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EmployeeName").ToString()%>'></asp:Label>
                                                                </EditItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-Width="100px" FooterStyle-Width="100px">
                                                                <HeaderTemplate>
                                                                    <asp:Label Width="100px" ID="lblgvHdrDutyDate" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,DutyDate %>"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblgvDutyDate" CssClass="cssLable" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("DutyDate")) %>'> </asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="70px" HeaderStyle-Width="70px" FooterStyle-Width="70px">
                                                                <HeaderTemplate>
                                                                    <asp:Label Width="50px" ID="lblgvHdrShiftFrom" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,TimeFrom %>"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblgvShifFrom" CssClass="cssLable" runat="server" Width = "70px" Text='<%# String.Format("{0:HH:mm}",Eval("FromTime"))%>'> </asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="70px" HeaderStyle-Width="70px" FooterStyle-Width="70px">
                                                                <HeaderTemplate>
                                                                    <asp:Label Width="50px" ID="lblgvHdrShiftTo" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,TimeTo %>"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblgvShifTo" CssClass="cssLable" runat="server" Text='<%# String.Format("{0:HH:mm}",Eval("ToTime"))%>'> </asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-Width="100px" FooterStyle-Width="100px">
                                                                <HeaderTemplate>
                                                                    <asp:Label Width="100px" ID="lblgvHdrRank" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,Designation %>"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblgvRank" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DesignationDesc").ToString()%>'> </asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblgvEdit" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, EditColName %>"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="ImgbtnEdit" runat="server" CssClass="cssImgButton" CommandName="Edit" ToolTip="<%$ Resources:Resource, Edit %>" ImageUrl="../Images/Edit.gif" />
                                                                    <asp:ImageButton ID="ImgbtnCopytoAll" runat="server" CssClass="cssImgButton" CommandName="Copy" ToolTip="CopyToAll" ImageUrl="../Images/Tick.Png" />
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:ImageButton ID="ImgbtnUpdate" runat="server" CssClass="cssImgButton" CommandName="Update" ValidationGroup="vg_Edit" ToolTip="<%$ Resources:Resource, Update %>" ImageUrl="../Images/Save.gif" />
                                                                    <asp:ImageButton ID="ImgbtnCancel" runat="server" CssClass="cssImgButton" CommandName="Cancel" ToolTip="<%$ Resources:Resource, Cancel %>" ImageUrl="../Images/Cancel.gif" />
                                                                </EditItemTemplate>
                                                                <FooterStyle Width="60px" />
                                                                <HeaderStyle Width="60px" />
                                                                <ItemStyle Width="60px" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                    </ContentTemplate>
                                                    </Ajax:UpdatePanel>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            
                        </div>
                <Ajax:UpdatePanel ID="UPUnScheduledEmp" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div id="DIVUnScheduledEmployees" runat="server" style="width: 560px; height: 300px; display: none; overflow: scroll; border: 1px; 
                            border-top: 1px; border-style: solid; border-color: Red; position: absolute; background: white; left: 180px; top: 150px;">
                            <a href="javascript:CloseUnSchEmpDiv('DIVUnScheduledEmployees')">Close</a>
                            <asp:GridView ID="gvUnScheduledEmployees" runat="server" CssClass="GridViewStyle" AllowPaging="true" PageSize="10" ShowHeader="true" AutoGenerateColumns="false"
                                OnPageIndexChanging="gvUnScheduledEmployees_PageIndexChanging">
                                <Columns>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="200">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblHdrEmployeeNo" CssClass="cssLabel" runat="server" Text="Employee No."></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lnkEmpNo" onclick="javascript:AssignToSelectedTextBox(this);" Style="cursor: hand" runat="server" CommandName="Empclick" Text='<%# Eval("EmployeeNumber")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="200">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblhdrEmployeeName" CssClass="cssLabel" runat="server" Text="Employee Name"></asp:Label>
                                            <asp:TextBox ID="txtSearchEmpName" runat="server" CssClass="csstxtbox" Width="150px" AutoPostBack="true" OnTextChanged="txtSearchEmpName_TextChanged"></asp:TextBox>
                                            <asp:ImageButton ID="imgBtnEmpDetail" runat="server" Style="vertical-align: bottom" CssClass="" ToolTip="view EmployeeList" ImageUrl="~/Images/more.gif" OnClick="imgBtnEmpDetail_OnClick" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblEmpName" Style="width: 250px" runat="server" CssClass="cssLable" Text='<%#Bind("EmployeeName") %>' ToolTip="<%$ Resources:Resource, EmployeeName %>"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="250">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblhdrDesignation" CssClass="cssLabel" runat="server" Text="Designation"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblDesignation" Style="width: 250px" runat="server" CssClass="cssLable" Text='<%#Bind("DesignationDesc") %>' ToolTip="<%$ Resources:Resource, Designation %>"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:Button ID="btnUnScheduledEmp" runat="server" OnClick="btnUnScheduledEmp_OnClick" Style="display: none" />
                        </div>
                    </ContentTemplate>
                </Ajax:UpdatePanel>
            </td>
        </tr>
    </table>
    <script language="javascript" type="text/javascript">
        var GlobEmployeeNumber;
        var strEmployeeNumber;

        var strEmpNumber = "txtgvEmpNo";

        function SearchEmployee(obj) {
            var strEmployeeName = "txtgvEmpNo";
            var el_Employee = getClientId(obj, strEmployee);
            var EmployeeNameClientID = getClientId(obj, strEmployeeName);
            GlobEmployeeNumber = el_Employee;
            GlobEmployeeName = EmployeeNameClientID;
        }
        function CloseUnSchEmpDiv(obj) {
            document.getElementById('<%=DIVUnScheduledEmployees.ClientID %>').style.display = "none";
        }

        function AssignToSelectedTextBox(obj) {
            if (GlobEmployeeNumber != '') {
                document.getElementById(GlobEmployeeNumber).value = document.getElementById(obj.id).innerText;
                document.getElementById('<%=DIVUnScheduledEmployees.ClientID %>').style.display = "none";
            }
        }
        function GetUnSchEmp(strEmpClientID) {
            GlobEmployeeNumber = strEmpClientID;
            document.getElementById('<%=btnUnScheduledEmp.ClientID %>').click();
        }
        var GlobEmployeeName; var GlobEmployeeDesgDesc;
        function FunctionCallOnKeyDown(elName, obj) {
            if (window.event.keyCode == 120) {
                GlobEmployeeNumber = getClientId(obj, strEmpNumber);
                GetUnSchEmp(GlobEmployeeNumber);
                return;
            }
        }
        function FunctionCallsearchemployee(elName, obj) {
            GlobEmployeeNumber = obj;
                //GetUnSchEmp(GlobEmployeeNumber);
                return;
        }

        //============================
        //Function Used to Get The Client ID Of Control
        //=======================================
        function getClientId(obj, cId) {
            var arr = new Array;
            var clId = "";  // clientId
            arr = obj.id.split("_");
            for (i = 0; i < arr.length - 1; i++) {
                clId = clId + arr[i] + "_";
            }
            clId = clId + cId;
            return clId
        }
    </script>
</asp:Content>
