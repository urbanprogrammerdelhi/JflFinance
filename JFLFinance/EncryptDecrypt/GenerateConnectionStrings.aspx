<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GenerateConnectionStrings.aspx.cs"
    Inherits="EncryptDecrypt.GenerateConnectionStrings"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script language="javascript" type="text/javascript" src="../javaScript/gvExtFunctionality.js"></script>
    <script language="javascript" type="text/javascript" src="../javaScript/validation.js"></script>
    <link rel="stylesheet" type="text/css" href="../css/WRStyleSheet.css" />
    <link rel="stylesheet" type="text/css" href="../css/WRGridView.css" />
    <link rel="shortcut icon" type="image/x-icon" href="../ifm.ico" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:LinkButton ID="lbtnBack" runat="server" CssClass="btn btn-primary btn-xs" Width="100px" Text="<%$ Resources:Resource, Back %>" OnClick="lbtnBack_Click"></asp:LinkButton>
        <table width="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td align="center">
                    <asp:FileUpload ID="FileUploadControl" CssClass="cssButton" size="60" runat="server" />
                </td>
                <td align="left">
                    <asp:Button runat="server" CssClass="cssButton" ID="UploadButton" Text="Read File" OnClick="UploadButton_Click" />
                </td>
            </tr>
        </table>
                    <Ajax:ScriptManager ID="ToolkitScriptManager1" EnablePageMethods="true" runat="server"
                        AsyncPostBackTimeout="0" EnableScriptGlobalization="true" EnablePartialRendering="true" ScriptMode="Debug">
                    </Ajax:ScriptManager>
                    <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
                        <ContentTemplate>
                                        <asp:Panel ID="Panel1" BorderWidth="0px" runat="server" Width="100%">
                                            <asp:GridView Width="100%" ID="gvConn" CssClass="GridViewStyle" runat="server"
                                                ShowFooter="true" ShowHeader="true" Visible="true" AllowPaging="true" PageSize="15"
                                                CellPadding="1" GridLines="None" AutoGenerateColumns="False" OnRowCommand="gvConn_RowCommand"
                                                OnRowUpdating="gvConn_RowUpdating" OnRowDeleting="gvConn_RowDeleting" OnRowEditing="gvConn_RowEditing"
                                                OnRowCancelingEdit="gvConn_RowCancelingEdit" OnRowDataBound="gvConn_RowDataBound"
                                                OnPageIndexChanging="gvConn_PageIndexChanging">
                                                <FooterStyle CssClass="GridViewFooterStyle" />
                                                <RowStyle CssClass="GridViewRowStyle" />
                                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                <PagerStyle CssClass="GridViewPagerStyle" />
                                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblgvhdrSerialNo" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,SerialNumber %>"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSerialNo" CssClass="cssLabel" runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="50px" />
                                                        <HeaderStyle Width="50px" />
                                                        <FooterStyle Width="50px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblgvhdrCountry" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, Country %>"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblgvhdrCountry" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Country").ToString()%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox Width="100px" ID="txtCountry" CssClass="csstxtbox" Text='<%# DataBinder.Eval(Container.DataItem, "Country").ToString()%>'
                                                                MaxLength="35" runat="server"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvCountry" ValidationGroup="vgCEdit" ControlToValidate="txtCountry"
                                                                runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                        </EditItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:TextBox Width="100px" ID="txtCountry" CssClass="csstxtbox" MaxLength="35" runat="server"
                                                                Text=""></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvCountry" ValidationGroup="vgCFooter" ControlToValidate="txtCountry"
                                                                runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                        </FooterTemplate>
                                                        <ItemStyle Width="120px" />
                                                        <HeaderStyle Width="120px" />
                                                        <FooterStyle Width="120px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblgvhdrKey" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, Key %>"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblgvKey" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Key").ToString()%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox Width="100px" ID="txtKey" CssClass="csstxtbox" runat="server" MaxLength="25"
                                                                Text='<%# DataBinder.Eval(Container.DataItem, "Key").ToString()%>'></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvKey" ValidationGroup="vgCEdit" ControlToValidate="txtKey"
                                                                runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                        </EditItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:TextBox Width="100px" ID="txtKey" CssClass="csstxtbox" runat="server" MaxLength="25"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvKey" ValidationGroup="vgCFooter" ControlToValidate="txtKey"
                                                                runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                        </FooterTemplate>
                                                        <ItemStyle Width="120px" />
                                                        <HeaderStyle Width="120px" />
                                                        <FooterStyle Width="120px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblgvhdrServer" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, Server %>"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <table>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblhdrServer" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, Server %>"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblgvServer" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Server").ToString()%>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblgvhdrDataBase" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, DataBase %>"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblgvDataBase" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DataBase").ToString()%>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblgvhdrUid" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, UserId %>"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblgvUid" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Uid").ToString()%>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblgvhdrPWD" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, Password %>"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <%--<asp:Label ID="lblgvPWD" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PWD").ToString()%>'></asp:Label>--%>
			                                                            <asp:HiddenField ID="HiddenFieldPWD" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "PWD").ToString()%>' />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <table>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblhdrServer" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, Server %>"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox Width="180px" ID="txtServer" CssClass="csstxtbox" runat="server" MaxLength="100" Text='<%# DataBinder.Eval(Container.DataItem, "Server").ToString()%>'></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="rfvServer" ValidationGroup="vgCEdit" ControlToValidate="txtServer" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblgvhdrDataBase" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, DataBase %>"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox Width="180px" ID="txtDataBase" CssClass="csstxtbox" runat="server" MaxLength="100" Text='<%# DataBinder.Eval(Container.DataItem, "DataBase").ToString()%>'></asp:TextBox>
			                                                            <asp:RequiredFieldValidator ID="rfvDataBase" ValidationGroup="vgCEdit" ControlToValidate="txtDataBase" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblgvhdrUid" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, UserId %>"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox Width="180px" ID="txtUid" CssClass="csstxtbox" runat="server" MaxLength="100" Text='<%# DataBinder.Eval(Container.DataItem, "Uid").ToString()%>'></asp:TextBox>
			                                                            <asp:RequiredFieldValidator ID="rfvUid" ValidationGroup="vgCEdit" ControlToValidate="txtUid" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblgvhdrPWD" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, Password %>"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox Width="180px" ID="txtPWD" TextMode="Password" CssClass="csstxtbox" runat="server" MaxLength="100" Text='<%# DataBinder.Eval(Container.DataItem, "PWD").ToString()%>'></asp:TextBox>
			                                                            <asp:RequiredFieldValidator ID="rfvPWD" ValidationGroup="vgCEdit" ControlToValidate="txtPWD" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </EditItemTemplate>
                                                        <FooterTemplate>
                                                            <table>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblhdrServer" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, Server %>"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox Width="180px" ID="txtServer" CssClass="csstxtbox" runat="server" MaxLength="100"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="rfvServer" ValidationGroup="vgCFooter" ControlToValidate="txtServer" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblgvhdrDataBase" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, DataBase %>"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox Width="180px" ID="txtDataBase" CssClass="csstxtbox" runat="server" MaxLength="100"></asp:TextBox>
			                                                            <asp:RequiredFieldValidator ID="rfvDataBase" ValidationGroup="vgCFooter" ControlToValidate="txtDataBase" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblgvhdrUid" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, UserId %>"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox Width="180px" ID="txtUid" CssClass="csstxtbox" runat="server" MaxLength="100"></asp:TextBox>
			                                                            <asp:RequiredFieldValidator ID="rfvUid" ValidationGroup="vgCFooter" ControlToValidate="txtUid" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblgvhdrPWD" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, Password %>"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox Width="180px" ID="txtPWD" TextMode="Password" CssClass="csstxtbox" runat="server" MaxLength="100"></asp:TextBox>
			                                                            <asp:RequiredFieldValidator ID="rfvPWD" ValidationGroup="vgCFooter" ControlToValidate="txtPWD" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </FooterTemplate>
                                                        <ItemStyle Width="300px" />
                                                        <HeaderStyle Width="300px" />
                                                        <FooterStyle Width="300px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblgvhdrSSRSDomain" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, SSRS %>"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <table>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblgvhdrSSRSDomain" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, DomainName %>"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblgvSSRSDomain" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SSRSDomain").ToString()%>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblgvhdrDomainUid" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, UserId %>"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblgvSSRSUserName" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SSRSUserName").ToString()%>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblgvhdrDomainPWD" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, Password %>"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:HiddenField ID="HiddenFieldSSRSPWD" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "SSRSPWD").ToString()%>' />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <table>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblgvhdrSSRSDomain" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, DomainName %>"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox Width="180px" ID="txtSSRSDomain" CssClass="csstxtbox" runat="server" MaxLength="100" Text='<%# DataBinder.Eval(Container.DataItem, "SSRSDomain").ToString()%>'></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblgvhdrDomainUid" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, UserId %>"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox Width="180px" ID="txtSSRSUserName" CssClass="csstxtbox" runat="server" MaxLength="100" Text='<%# DataBinder.Eval(Container.DataItem, "SSRSUserName").ToString()%>'></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblgvhdrDomainPWD" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, Password %>"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox Width="180px" ID="txtSSRSPWD" TextMode="Password" CssClass="csstxtbox" runat="server" MaxLength="100" Text='<%# DataBinder.Eval(Container.DataItem, "SSRSPWD").ToString()%>'></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            
                                                        </EditItemTemplate>
                                                        <FooterTemplate>
                                                            <table>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblgvhdrSSRSDomain" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, DomainName %>"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox Width="160px" ID="txtSSRSDomain" CssClass="csstxtbox" runat="server" MaxLength="50"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblgvhdrDomainUid" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, UserId %>"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox Width="160px" ID="txtSSRSUserName" CssClass="csstxtbox" runat="server" MaxLength="50"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblgvhdrDomainPWD" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, Password %>"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox Width="180px" ID="txtSSRSPWD" TextMode="Password" CssClass="csstxtbox" runat="server" MaxLength="100"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            
                                                        </FooterTemplate>
                                                        <ItemStyle Width="400px" />
                                                        <HeaderStyle Width="400px" />
                                                        <FooterStyle Width="400px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblgvhdrEncriptKey" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, EncriptKey %>"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblgvEncriptKey" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EncriptKey").ToString()%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox Width="180px" ID="txtEncriptKey" CssClass="csstxtbox" runat="server"
                                                                MaxLength="100" Text='<%# DataBinder.Eval(Container.DataItem, "EncriptKey").ToString()%>'></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvEncriptKey" ValidationGroup="vgCEdit" ControlToValidate="txtEncriptKey"
                                                                runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                        </EditItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:TextBox Width="180px" ID="txtEncriptKey" CssClass="csstxtbox" runat="server"
                                                                MaxLength="100"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvEncriptKey" ValidationGroup="vgCFooter" ControlToValidate="txtEncriptKey"
                                                                runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                        </FooterTemplate>
                                                        <ItemStyle Width="200px" />
                                                        <HeaderStyle Width="200px" />
                                                        <FooterStyle Width="200px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblaction" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, EditColName %>"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="ImgbtnDelete" runat="server" CssClass="cssImgButton" CommandName="Delete"
                                                                ToolTip="<%$ Resources:Resource, Delete %>" ImageUrl="../Images/Delete.gif" />
                                                            &nbsp;
                                                            <asp:ImageButton ID="ImgbtnEdit" runat="server" CssClass="cssImgButton" CommandName="Edit"
                                                                ToolTip="<%$ Resources:Resource, Edit %>" ImageUrl="../Images/Edit.gif" />
                                                            &nbsp;
                                                            <asp:ImageButton ID="ImgbtnValidate" runat="server" CssClass="cssImgButton" CommandName="Verify"
                                                                ToolTip="<%$ Resources:Resource, Verify %>" ImageUrl="../Images/Tick.Png" />
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:ImageButton ID="ImgbtnUpdate" runat="server" CssClass="cssImgButton" CommandName="Update"
                                                                ValidationGroup="vgCEdit" ToolTip="<%$ Resources:Resource, Update %>" ImageUrl="../Images/Save.gif" />
                                                            &nbsp;
                                                            <asp:ImageButton ID="ImgbtnCancel" runat="server" CssClass="cssImgButton" CommandName="Cancel"
                                                                ToolTip="<%$ Resources:Resource, Cancel %>" ImageUrl="../Images/Cancel.gif" />
                                                        </EditItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:ImageButton ID="ImgbtnAdd" runat="server" CssClass="cssImgButton" CommandName="Add"
                                                                ToolTip="<%$Resources:Resource,Save %>" ValidationGroup="vgCFooter" ImageUrl="../Images/AddNew.gif" />
                                                            &nbsp;
                                                            <asp:ImageButton ID="ImgbtnReset" runat="server" CssClass="cssImgButton" CommandName="Reset"
                                                                ToolTip="<%$ Resources:Resource, Reset %>" ImageUrl="../Images/Reset.gif" />
                                                            &nbsp;
                                                            <asp:ImageButton ID="ImgbtnValidate" runat="server" CssClass="cssImgButton" CommandName="Verify"
                                                                ToolTip="<%$ Resources:Resource, Verify %>" ValidationGroup="vgCFooter" ImageUrl="../Images/Tick.Png" />
                                                        </FooterTemplate>
                                                        <ItemStyle Width="150px" />
                                                        <HeaderStyle Width="150px" />
                                                        <FooterStyle Width="150px" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                            <asp:Button runat="server" ID="btnSubmit" CssClass="cssButton" Width="250px" Text="Generate Connection"
                                                OnClick="btnSubmit_Click" />
                                            <asp:Button runat="server" ID="btnPwd" CssClass="cssButton" Width="250px" Text="Generate Password"
                                                OnClick="btnPwd_Click" />
                                            <asp:Button runat="server" ID="btnSave" CssClass="cssButton" Width="250px" Text="Save For the Current Site"
                                                OnClick="btnSave_Click" />
                                            <div style="margin:25px;">
                                                <asp:TextBox EnableViewState="false" Width="800px" ID="txtOutputpwd" Text="" runat="server" CssClass="csslblErrMsg"></asp:TextBox>
                                                <br />
                                                <asp:TextBox EnableViewState="false" Width="800px" Height="150px" TextMode="Multiline" ID="txtOutput" Text="" runat="server" CssClass="csslblErrMsg"></asp:TextBox>
                                            </div>
                                        </asp:Panel>
                                    <div align="center">
                                        <asp:Label EnableViewState="false" ID="lblErrorMsg" Text="" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                    </div>
                        </ContentTemplate>
                    </Ajax:UpdatePanel>

    </div>
    </form>
</body>
</html>
