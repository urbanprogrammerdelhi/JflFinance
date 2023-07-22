<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="CreateCCH.aspx.cs" Inherits="Search_CreateCCH" Title="<%$ Resources:Resource, AppTitle %>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
                <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
                    <ContentTemplate>
                                    <asp:LinkButton ID="lnkbtnLocSelect" runat="server" Text="Search"></asp:LinkButton></span></h2>
                                    <br>
                                    <table border="0" cellpadding="1" cellspacing="1" width="100%">
                                        <tr>
                                            <td align="right" width="120px">
                                                <asp:Label Style="width: 100px" CssClass="cssLable" ID="lblSearchCode" runat="server"
                                                    Text="Enter SearchCode"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtSearchCode" CssClass="csstxtbox" Width="170px" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label Style="width: 100px" CssClass="cssLable" ID="Label1" runat="server" Text="Enter ObjectName"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtObjectName" CssClass="csstxtbox" Width="170px" runat="server"></asp:TextBox>
                                                <asp:Button ID="btnGetObject" runat="server" Text="OK" CssClass="cssButton" OnClick="btnGetObject_Click" />
                                                <a onclick='opensearch();'>
                                                    <img src="../Images/icosearch.gif" /></a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" colspan="2">
                                                <asp:GridView ID="gvCCH" CssClass="GridViewStyle" runat="server" ShowHeader="true"
                                                    Visible="true" CellPadding="3" GridLines="None" AutoGenerateColumns="False">
                                                    <RowStyle CssClass="GridViewRowStyle" />
                                                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblgvHdrFldName" Width="120px" CssClass="cssLabelHeader" runat="server"
                                                                    Text="Field Name"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgvCCHFldName" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FldName").ToString()%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblgvHdrInput" Width="20px" CssClass="cssLabelHeader" runat="server"
                                                                    Text="Input"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="chInput" runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblgvHdrOutput" Width="20px" CssClass="cssLabelHeader" runat="server"
                                                                    Text="Output"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="chOutput" runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblgvHdrReturnFld" Width="20px" CssClass="cssLabelHeader" runat="server"
                                                                    Text="Return"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <input type="radio" name="ReturnRadio" value="<%# DataBinder.Eval(Container.DataItem, "FldName").ToString()%>"
                                                                    onclick="getReturnFieldName('1','<%# DataBinder.Eval(Container.DataItem, "FldName").ToString()%>')" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblgvHdrReturnFld2" Width="20px" CssClass="cssLabelHeader" runat="server"
                                                                    Text="Return2"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <input type="radio" name="ReturnRadio2" value="<%# DataBinder.Eval(Container.DataItem, "FldName").ToString()%>"
                                                                    onclick="getReturnFieldName('2','<%# DataBinder.Eval(Container.DataItem, "FldName").ToString()%>')" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                        
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblgvHdrDataType" Width="30px" CssClass="cssLabelHeader" runat="server"
                                                                    Text="DataType"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lblgvCCHdataType" CssClass="cssLable" Text='<%# DataBinder.Eval(Container.DataItem, "FldDataType").ToString()%>' ></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td align="left">
                                                <asp:Button runat="server" ID="btnApply" CssClass="cssButton" Visible="false" Text="Apply"
                                                    OnClick="btnApply_Click" />
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" colspan="2">
                                                <br>
                                                <asp:Label EnableViewState="false" ID="lblErrorMsg" Text="" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                                <asp:HiddenField ID="txtReturnFld" runat="server" />
                                                <asp:HiddenField ID="txtReturnFld2" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                    </ContentTemplate>
                </Ajax:UpdatePanel>
    <script language="javascript" type="text/javascript" src="../PageJS/CreateCCH.js"></script>
    <script type="text/javascript">

        function ControlInitializer() {
            this.txtReturnFld = document.getElementById('<% =txtReturnFld.ClientID %>');
            this.txtReturnFld2 = document.getElementById('<% =txtReturnFld2.ClientID %>');
            
        }
</script>
</asp:Content>
