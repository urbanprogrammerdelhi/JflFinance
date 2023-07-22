<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="EmployeeMasterDetail.aspx.cs" Inherits="HRManagement_EmployeeMasterDetail"
    Title="<%$ Resources:Resource, AppTitle %>" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="squareboxgradientcaption" style="height: 25px;">
        <asp:Label ID="Label14" runat="server" Text="<%$Resources:Resource,PersonalDetail1 %>"></asp:Label>
    </div>
    <div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <AjaxToolKit:TabContainer Style="text-align: left;" runat="server" ID="EmpDetails"
                    ActiveTabIndex="0" OnActiveTabChanged="EmpDetails_ActiveTabChanged" AutoPostBack="true">
                    <AjaxToolKit:TabPanel Style="text-align: left;" ID="PanelEmployeeDetails" runat="server"
                        HeaderText="<%$Resources:Resource,EmployeeDetail %>" TabIndex="0">
                        <ContentTemplate>
                            <asp:Panel ID="Panel1" Font-Bold="True" runat="server" ForeColor="Red" GroupingText="<%$ Resources:Resource,EmployeeDetail %>">
                                <table width="100%" cellpadding="0px" cellspacing="1px" style="border-collapse: separate;">
                                    <tr>
                                        <td style="vertical-align: top; min-width: 290px;">
                                            <div>
                                                <div class="squareboxgradientcaption" style="height: 20px;">
                                                    <asp:Label ID="Label2" runat="server" Text="<%$ Resources:Resource,EmployeeDetail %>"></asp:Label>
                                                </div>
                                                <div>
                                                    <table cellspacing="0" cellpadding="5px">
                                                        <tr>
                                                            <td colspan="2" align="center">
                                                                <table>
                                                                    <tr>
                                                                        <td style="text-align: center; background-image: url(../Images/EmployeeImages/empbgimage2.jpg); background-repeat: no-repeat; vertical-align: top; width: 150px; height: 175px;">
                                                                            <asp:UpdatePanel ID="upempimg" runat="server" UpdateMode="Conditional">
                                                                                <ContentTemplate>
                                                                                    <%--<asp:Image ID="ImageBox1" runat="server" ImageUrl="~/Images/EmployeeImages/EmpNoImage.jpg" Width="146px" Height="150px" />--%>
                                                                                    <asp:Image ID="ImageBox" runat="server" Height="150px" Style="margin-top: 3px;" Width="146px" />
                                                                                    <asp:Label ID="lblEmployeeNumberViewEmployeejobDetail" runat="server" CssClass="cssLable" Font-Bold="true" Style="padding-top: 5px;" Text=""></asp:Label>
                                                                                </ContentTemplate>
                                                                                <Triggers>
                                                                                    <asp:PostBackTrigger ControlID="btnUpload" />
                                                                                </Triggers>
                                                                            </asp:UpdatePanel>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: right;">
                                                                <asp:Label ID="Label1" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,EmployeeName %>"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left;">
                                                                <asp:Label ID="lblName" Font-Bold="True" CssClass="cssLable" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: right;">
                                                                <asp:Label ID="Label6" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,JoiningDate %>"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left;">
                                                                <asp:Label ID="lblDateOfJoining" Font-Bold="True" runat="server" CssClass="cssLabel"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: right;" nowrap="nowrap">
                                                                <asp:Label ID="Label8" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,DesignationDescription %>"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left;">
                                                                <asp:Label ID="lblDesignationView" Font-Bold="True" runat="server" CssClass="cssLabel"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: right;" nowrap="nowrap">
                                                                <asp:Label ID="Label9" CssClass="cssLable" runat="server" Style="width: 100px;" Text="<%$ Resources:Resource,CategoryDescription %>"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left;">
                                                                <asp:Label ID="lblCategoryView" Font-Bold="True" runat="server" CssClass="cssLabel"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: right;">
                                                                <asp:Label ID="Label10" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,JobType %>"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left;">
                                                                <asp:Label ID="lblJobTypeView" Font-Bold="True" runat="server" CssClass="cssLabel"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: right;">
                                                                <asp:Label ID="Label11" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,JobClass %>"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left;">
                                                                <asp:Label ID="lblJobClassView" Font-Bold="True" runat="server" CssClass="cssLabel"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" style="text-align: left;">
                                                                <asp:FileUpload ID="FileUploadEmployee" Width="230px" CssClass="csstxtbox" runat="server" />
                                                                <asp:Button ID="btnUpload" CssClass="cssButton" runat="server" Text="<%$ Resources:Resource,Upload %>" OnClick="btnUpload_Click" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </div>

                                            <asp:Button ID="btnUploadDownload" CssClass="cssButton" runat="server" Text="<%$ Resources:Resource,UploadDownload %>" />
                                        </td>
                                        <td style="vertical-align: top;">
                                            <asp:UpdatePanel ID="up1" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <div class="squareboxgradientcaption" style="height: 20px;">
                                                        <asp:Label ID="lblEmployeeSkills" runat="server" Text="<%$Resources:Resource,EmployeeSkills %>"></asp:Label>
                                                    </div>
                                                    <div>
                                                        <asp:GridView ID="gvSkills" runat="server" AllowPaging="True" AutoGenerateColumns="False" OnRowCommand="gvSkills_RowCommand" OnRowDataBound="gvSkills_RowDataBound" OnRowDeleting="gvSkills_RowDeleting" PageSize="5" ShowFooter="True" Width="100%">
                                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                                            <RowStyle CssClass="GridViewRowStyle" />
                                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderStyle-Width="35px" HeaderText="<%$Resources:Resource,SerialNumber %>">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblSerialNo" runat="server" CssClass="cssLable"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="cssLabelHeader" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="100%" HeaderText="<%$Resources:Resource,Skills %>">
                                                                    <FooterTemplate>
                                                                        <asp:DropDownList ID="ddlNewSkills" runat="server" CssClass="cssDropDown" Width="100%">
                                                                        </asp:DropDownList>
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:HiddenField ID="hfSkillCode" runat="server" Value='<%# Bind("SkillCode") %>' />
                                                                        <asp:Label ID="lblskilldesc" runat="server" Text='<%# Bind("SkillDesc") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="cssLabelHeader" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="<%$Resources:Resource,EditColName %>">
                                                                    <FooterTemplate>
                                                                        <asp:ImageButton ID="ImgbtnAddSkill" runat="server" CommandName="AddNewSkill" CssClass="cssImgButton" ImageUrl="../Images/AddNew.gif" ToolTip="<%$Resources:Resource,Save %>" />
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="IBDeleteSkill" runat="server" CausesValidation="False" CommandName="Delete" CssClass="csslnkButton" ImageUrl="~/Images/Delete.gif" ToolTip="<%$Resources:Resource,Delete %>" />
                                                                    </ItemTemplate>
                                                                    <FooterStyle Width="100px" />
                                                                    <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                                                                    <ItemStyle Width="100px" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                        <asp:Label ID="lblSkillErrMsg" runat="server" CssClass="csslblErrMsg" EnableViewState="false"></asp:Label>
                                                    </div>
                                                    <br />
                                                    <div class="squareboxgradientcaption" style="height: 20px;">
                                                        <asp:Label ID="Label7" runat="server" Text="<%$Resources:Resource,EmployeeTraining %>"></asp:Label>
                                                    </div>
                                                    <div>
                                                        <asp:GridView ID="gvTraining" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="EmployeeNumber,TrainingCode,TrainingDate" Enabled="false" OnPageIndexChanging="gvTraining_PageIndexChanging" OnRowCancelingEdit="gvTraining_RowCancelingEdit" OnRowCommand="gvTraining_RowCommand1" OnRowDataBound="gvTraining_RowDataBound1" OnRowDeleting="gvTraining_RowDeleting" OnRowEditing="gvTraining_RowEditing1" OnRowUpdating="gvTraining_RowUpdating" PageSize="5" ShowFooter="true" Width="100%">
                                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                                            <RowStyle CssClass="GridViewRowStyle" />
                                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="<%$Resources:Resource,SerialNumber %>">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblSerialNo" runat="server" CssClass="cssLabel" Width="35px"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle Width="35px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="250px" HeaderText="<%$Resources:Resource,TrainingDesc %>">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblTrainingDesc" runat="server" CssClass="cssLabel" Text='<%# Bind("TrainingDesc") %>' Width="150px"></asp:Label>
                                                                        <asp:Label ID="lblTrainingCode" runat="server" Text='<%# Bind("TrainingCode") %>' Visible="false"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:DropDownList ID="ddlNewTrainingDesc" runat="server" CssClass="cssDropDown" Width="97%">
                                                                        </asp:DropDownList>
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="label56" runat="server" CssClass="cssLabel" Text='<%# Bind("TrainingDesc") %>' Width="250px"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle Width="250px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="<%$Resources:Resource,Duration %>">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtDuration" runat="server" CssClass="csstxtbox" MaxLength="3" Text='<%# Bind("DurationDays") %>' Width="40px"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatortxtDuration" runat="server" ControlToValidate="txtDuration" ErrorMessage="" SetFocusOnError="True" ValidationGroup="Edit">*</asp:RequiredFieldValidator>
                                                                        <asp:RangeValidator ID="rvtxtDuration" runat="server" ControlToValidate="txtDuration" ErrorMessage="*" MaximumValue="999" MinimumValue="1" SetFocusOnError="true" ValidationGroup="Edit"></asp:RangeValidator>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox ID="txtNewDuration" runat="server" CssClass="csstxtbox" MaxLength="3" ValidationGroup="AddNew" Width="40px"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatortxtNewDuration" runat="server" ControlToValidate="txtNewDuration" Display="Dynamic" ErrorMessage="" SetFocusOnError="True" ValidationGroup="AddNew">*</asp:RequiredFieldValidator>
                                                                        <asp:RangeValidator ID="rvtxtNewDuration" runat="server" ControlToValidate="txtNewDuration" ErrorMessage="*" MaximumValue="999" MinimumValue="1" SetFocusOnError="true" ValidationGroup="AddNew"></asp:RangeValidator>
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label5" runat="server" CssClass="cssLabel" Text='<%# Bind("DurationDays") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle Width="60px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,TrainingDate %>">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="txtEditTrainingDate" runat="server" CssClass="cssLabel" Text='<%#String.Format("{0:d-MMM-yyyy}",Eval("TrainingDate")) %>' Width="80px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox ID="txtNewTrainingDate" runat="server" AutoPostBack="True" CssClass="csstxtbox" OnTextChanged="txtNewTrainingDate_TextChanged" ValidationGroup="AddNew" Width="80px"></asp:TextBox>
                                                                        <asp:ImageButton ID="imgNewTrainingDate" runat="server" CausesValidation="true" ImageUrl="~/Images/pdate.gif" Style="vertical-align: middle" />
                                                                        <AjaxToolKit:CalendarExtender ID="CalendarExtenderNewTrainingDate" runat="server" Format="dd-MMM-yyyy" PopupButtonID="imgNewTrainingDate" PopupPosition="TopRight" TargetControlID="txtNewTrainingDate" />
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="LabelItemTrainingDate" runat="server" CssClass="cssLabel" Text='<%# String.Format("{0:dd-MMM-yyyy}" ,Eval("TrainingDate")) %>' Width="80px"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                                                                    <ItemStyle Width="200px" />
                                                                    <FooterStyle Width="200px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,ValidTillDate %>">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtEditValidTillDate" runat="server" AutoPostBack="True" CssClass="csstxtbox" OnTextChanged="txtEditValidTillDate_TextChanged" Text='<%# String.Format("{0:dd-MMM-yyyy}" ,Eval("ValidTillDate")) %>' Width="80px"></asp:TextBox>
                                                                        <asp:ImageButton ID="imgEditValidTillDate" runat="server" CausesValidation="true" ImageUrl="~/Images/pdate.gif" Style="vertical-align: middle" />
                                                                        <AjaxToolKit:CalendarExtender ID="CalendarExtenderEditValidTillDate" runat="server" Format="dd-MMM-yyyy" PopupButtonID="imgEditValidTillDate" PopupPosition="TopRight" TargetControlID="txtEditValidTillDate" />
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox ID="txtNewValidTillDate" runat="server" AutoPostBack="True" CssClass="csstxtbox" OnTextChanged="txtNewValidTillDate_TextChanged" ValidationGroup="AddNew" Width="80px"></asp:TextBox>
                                                                        <asp:ImageButton ID="imgNewValidTillDate" runat="server" CausesValidation="true" ImageUrl="~/Images/pdate.gif" Style="vertical-align: middle" />
                                                                        <AjaxToolKit:CalendarExtender ID="CalendarExtenderNewValidTillDate" runat="server" Format="dd-MMM-yyyy" PopupButtonID="imgNewValidTillDate" PopupPosition="TopRight" TargetControlID="txtNewValidTillDate" />
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="LabelItemValidTillDate" runat="server" CssClass="cssLabel" Text='<%# String.Format("{0:dd-MMM-yyyy}" ,Eval("ValidTillDate")) %>' Width="80px"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                                                                    <ItemStyle Width="200px" />
                                                                    <FooterStyle Width="200px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="<%$Resources:Resource,EditColName %>">
                                                                    <EditItemTemplate>
                                                                        <asp:ImageButton ID="ImgbtnUpdateTran" runat="server" CausesValidation="false" CommandName="Update" CssClass="csslnkButton" ImageUrl="~/Images/save.gif" ToolTip="<%$Resources:Resource,Update %>" />
                                                                        <asp:ImageButton ID="ImageButton2Tran" runat="server" CausesValidation="False" CommandName="Cancel" CssClass="csslnkButton" ImageUrl="~/Images/Cancel.gif" ToolTip="<%$Resources:Resource,Cancel %>" />
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:ImageButton ID="ImgbtnAddTran" runat="server" CommandName="AddNew" CssClass="cssImgButton" ImageUrl="../Images/AddNew.gif" ToolTip="<%$Resources:Resource,Save %>" />
                                                                        <asp:ImageButton ID="ImgbtnResetTran" runat="server" CommandName="Reset" CssClass="cssImgButton" ImageUrl="../Images/Reset.gif" ToolTip="<%$Resources:Resource,Reset %>" />
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="IBEditTran" runat="server" CausesValidation="False" CommandName="Edit" CssClass="csslnkButton" ImageUrl="~/Images/Edit.gif" ToolTip="<%$Resources:Resource,Edit %>" />
                                                                        <asp:ImageButton ID="IBDeleteTran" runat="server" CausesValidation="False" CommandName="Delete" CssClass="csslnkButton" ImageUrl="~/Images/Delete.gif" ToolTip="<%$Resources:Resource,Delete %>" />
                                                                    </ItemTemplate>
                                                                    <FooterStyle Width="100px" />
                                                                    <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                                                                    <ItemStyle Width="100px" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                        <asp:Label ID="lblErrorMsgTraining" runat="server" CssClass="csslblErrMsg" EnableViewState="false"></asp:Label>
                                                    </div>
                                                    <br />
                                                    <div class="squareboxgradientcaption" style="height: 20px;">
                                                        <asp:Label ID="Label12" runat="server" Text="<%$Resources:Resource,EmployeeQualification %>"></asp:Label>
                                                    </div>
                                                    <div>
                                                        <asp:GridView ID="gvQualification" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="EmployeeNumber,QualificationCode" OnPageIndexChanging="gvQualification_PageIndexChanging" OnRowCancelingEdit="gvQualification_RowCancelingEdit" OnRowCommand="gvQualification_RowCommand" OnRowDataBound="gvQualification_RowDataBound" OnRowDeleting="gvQualification_RowDeleting" PageSize="5" ShowFooter="True" Width="100%">
                                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                                            <RowStyle CssClass="GridViewRowStyle" />
                                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderStyle-Width="35px" HeaderText="<%$Resources:Resource,SerialNumber %>">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblSerialNo" runat="server" CssClass="cssLable"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="cssLabelHeader" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="100%" HeaderText="<%$Resources:Resource,QualificationDesc %>">
                                                                    <FooterTemplate>
                                                                        <asp:DropDownList ID="ddlNewQualificationDesc" runat="server" CssClass="cssDropDown" Width="100%">
                                                                        </asp:DropDownList>
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label2" runat="server" CssClass="cssLabel" Text='<%# Bind("QualificationDesc") %>'></asp:Label>
                                                                        <asp:Label ID="lblQualificationCode" runat="server" Text='<%# Bind("QualificationCode") %>' Visible="false"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="cssLabelHeader" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="<%$Resources:Resource,EditColName %>">
                                                                    <FooterTemplate>
                                                                        <asp:ImageButton ID="ImgbtnAddQual" runat="server" CommandName="AddNewQualification" CssClass="cssImgButton" ImageUrl="../Images/AddNew.gif" ToolTip="<%$Resources:Resource,Save %>" />
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="IBDeleteQual" runat="server" CausesValidation="False" CommandName="Delete" CssClass="csslnkButton" ImageUrl="~/Images/Delete.gif" ToolTip="<%$Resources:Resource,Delete %>" />
                                                                    </ItemTemplate>
                                                                    <FooterStyle Width="100px" />
                                                                    <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                                                                    <ItemStyle Width="100px" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                        <asp:Label ID="lblErrorMsgQualification" runat="server" CssClass="csslblErrMsg" EnableViewState="false"></asp:Label>
                                                    </div>
                                                    <br />
                                                    <div class="squareboxgradientcaption" style="height: 20px;">
                                                        <asp:Label ID="Label13" runat="server" Text="<%$Resources:Resource,EmployeeLanguage %>"></asp:Label>
                                                    </div>
                                                    <div>
                                                        <asp:GridView ID="gvlanguage" runat="server" AllowPaging="true" AutoGenerateColumns="False" OnPageIndexChanging="gvlanguage_PageIndexChanging" OnRowCancelingEdit="gvlanguage_RowCancelingEdit" OnRowCommand="gvlanguage_RowCommand" OnRowDataBound="gvlanguage_RowDataBound" OnRowDeleting="gvlanguage_RowDeleting" OnRowEditing="gvlanguage_RowEditing" OnRowUpdating="gvlanguage_RowUpdating" PageSize="5" ShowFooter="true" Width="100%">
                                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                                            <RowStyle CssClass="GridViewRowStyle" />
                                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="<%$Resources:Resource,SerialNumber %>">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblSerialNo" runat="server"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle Width="35px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="<%$Resources:Resource,LanguageDesc %>">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="Label2" runat="server" CssClass="cssLabel" Text='<%# Eval("languageDesc") %>'></asp:Label>
                                                                        <asp:Label ID="lblLanguageCodeEdit" runat="server" Text='<%# Bind("languageCode") %>'></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label2" runat="server" CssClass="cssLabel" Text='<%# Bind("languageDesc") %>'></asp:Label>
                                                                        <asp:Label ID="lblLanguageCode" runat="server" Text='<%# Bind("languageCode") %>' Visible="false"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:DropDownList ID="ddlNewLanguageDesc" runat="server" CssClass="cssDropDown" Width="222px">
                                                                        </asp:DropDownList>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="<%$Resources:Resource,Proficiency %>">
                                                                    <EditItemTemplate>
                                                                        <asp:DropDownList ID="ddlProficiency" runat="server" CssClass="cssDropDown">
                                                                            <asp:ListItem Selected="True" Text="<%$Resources:Resource,Beginner %>" Value="Beginner"></asp:ListItem>
                                                                            <asp:ListItem Text="<%$Resources:Resource,Intermediate %>" Value="Intermediate"></asp:ListItem>
                                                                            <asp:ListItem Text="<%$Resources:Resource,Expert %>" Value="Expert"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label3" runat="server" CssClass="cssLabel" Text='<%#Bind("Proficiency") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:DropDownList ID="ddlNewProficiency" runat="server" CssClass="cssDropDown">
                                                                            <asp:ListItem Selected="True" Text="<%$Resources:Resource,Beginner %>" Value="Beginner"></asp:ListItem>
                                                                            <asp:ListItem Text="<%$Resources:Resource,Intermediate %>" Value="Intermediate"></asp:ListItem>
                                                                            <asp:ListItem Text="<%$Resources:Resource,Expert %>" Value="Expert"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="<%$Resources:Resource,MotherTongue %>">
                                                                    <EditItemTemplate>
                                                                        &nbsp;<asp:CheckBox ID="cbMotherTongue" runat="server" Checked='<%# Bind("MotherTongue") %>' CssClass="cssCheckBox" />
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label4" runat="server" CssClass="cssLabel" Text='<%# Bind("MotherTongue") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:CheckBox ID="cbNewMotherTongue" runat="server" CssClass="cssCheckBox" />
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="<%$Resources:Resource,EditColName %>">
                                                                    <EditItemTemplate>
                                                                        <asp:ImageButton ID="imgbtnUpdateLang" runat="server" CommandName="Update" CssClass="csslnkButton" ImageUrl="~/Images/save.gif" ToolTip="<%$Resources:Resource,Update %>" />
                                                                        <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False" CommandName="Cancel" CssClass="csslnkButton" ImageUrl="~/Images/Cancel.gif" ToolTip="<%$Resources:Resource,Cancel %>" />
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:ImageButton ID="ImgbtnAddNewlang" runat="server" CommandName="AddNewLanguage" CssClass="cssImgButton" ImageUrl="../Images/AddNew.gif" ToolTip="<%$Resources:Resource,Save %>" />
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="IBEditLang" runat="server" CausesValidation="False" CommandName="Edit" CssClass="csslnkButton" ImageUrl="~/Images/Edit.gif" ToolTip="<%$Resources:Resource,Edit %>" />
                                                                        <asp:ImageButton ID="IBDeleteLang" runat="server" CausesValidation="False" CommandName="Delete" CssClass="csslnkButton" ImageUrl="~/Images/Delete.gif" ToolTip="<%$Resources:Resource,Delete %>" />
                                                                    </ItemTemplate>
                                                                    <FooterStyle Width="100px" />
                                                                    <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                                                                    <ItemStyle Width="100px" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                        <asp:Label ID="lblErrorMsgLanguage" runat="server" CssClass="csslblErrMsg" EnableViewState="false"></asp:Label>
                                                    </div>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </ContentTemplate>
                    </AjaxToolKit:TabPanel>
                    <AjaxToolKit:TabPanel Style="text-align: left;" ID="EmployeeItemIssue" runat="server"
                        HeaderText="<%$Resources:Resource,EmployeeItemIssuing %>" TabIndex="0">
                        <ContentTemplate>
                            <asp:Panel ID="Panel2" Font-Bold="True" ScrollBars="Auto" ForeColor="Red" GroupingText="<%$ Resources:Resource,EmployeeItemIssuing %>"
                                Height="420px" runat="server">
                                <asp:GridView Width="100%" ID="gvEmployeeItemIssuing" CssClass="GridViewStyle" runat="server" ShowFooter="True" AllowPaging="True" PageSize="10" CellPadding="1" GridLines="None"
                                    AutoGenerateColumns="False" OnRowDataBound="gvEmployeeItemIssuing_RowDataBound" OnRowCommand="gvEmployeeItemIssuing_RowCommand"
                                    OnRowDeleting="gvEmployeeItemIssuing_RowDeleting" OnRowEditing="gvEmployeeItemIssuing_OnRowEditing" OnPageIndexChanging="gvEmployeeItemIssuing_PageIndexChanging"
                                    OnRowUpdating="gvEmployeeItemIssuing_RowUpdating" OnRowCancelingEdit="gvEmployeeItemIssuing_OnRowCancelingEdit">
                                    <FooterStyle CssClass="GridViewFooterStyle" />
                                    <RowStyle CssClass="GridViewRowStyle" />
                                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                    <PagerStyle CssClass="GridViewPagerStyle" />
                                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,EditColName %>">
                                            <EditItemTemplate>
                                                <asp:ImageButton ID="ImgbtnUpdateTran" ToolTip="<%$Resources:Resource,Update %>"
                                                    ImageUrl="~/Images/save.gif" CssClass="csslnkButton" runat="server" CommandName="Update" ValidationGroup="EditIssue" />

                                                <asp:ImageButton ID="ImageButton2Tran" ToolTip="<%$Resources:Resource,Cancel %>"
                                                    ImageUrl="~/Images/Cancel.gif" CssClass="csslnkButton" runat="server" CausesValidation="False"
                                                    CommandName="Cancel" />
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:ImageButton ID="lbADD" runat="server" ToolTip="<%$Resources:Resource,Save %>"
                                                    CssClass="cssImgButton" ValidationGroup="Item" CommandName="AddNew" ImageUrl="../Images/AddNew.gif" />

                                                <asp:ImageButton ID="lbReset" ToolTip="<%$Resources:Resource,Reset %>" runat="server"
                                                    CssClass="cssImgButton" CommandName="Reset" ImageUrl="../Images/Reset.gif" />
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="IBEditTran" ToolTip="<%$Resources:Resource,Edit %>" ImageUrl="~/Images/Edit.gif"
                                                    CssClass="csslnkButton" runat="server" CausesValidation="False"
                                                    CommandName="Edit" />

                                                <asp:ImageButton ID="IBDeleteTran" ToolTip="<%$Resources:Resource,Delete %>" ImageUrl="~/Images/Delete.gif"
                                                    runat="server" CssClass="csslnkButton" CausesValidation="False" CommandName="Delete" />
                                            </ItemTemplate>
                                            <FooterStyle Width="100px" />
                                            <HeaderStyle Width="100px" CssClass="cssLabelHeader" />
                                            <ItemStyle Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,Issuedby %>">
                                            <EditItemTemplate>
                                                <asp:HiddenField ID="ItemDetailID" runat="server" Value='<%# Bind("ItemIssuingID") %>' />
                                                <asp:TextBox ID="txtEditIssuedby" ValidationGroup="EditIssue" CssClass="csstxtbox" runat="server" Text='<%# Bind("Issuedby") %>' MaxLength="100"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RFVIssuedby" ValidationGroup="EditIssue" Display="Dynamic"
                                                    ControlToValidate="txtEditIssuedby" runat="server" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:HiddenField ID="hidItemDetail" runat="server" Value="0" />
                                                <asp:TextBox ID="txtNewIssuedby" CssClass="csstxtbox" runat="server" ValidationGroup="Item" MaxLength="100"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RFVNewIssuedby" ValidationGroup="Item" Display="Dynamic"
                                                    ControlToValidate="txtNewIssuedby" runat="server" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:HiddenField ID="ID" runat="server" Value='<%# Bind("ItemIssuingID") %>' />
                                                <asp:Label ID="lblIssuedby" CssClass="cssLabel" runat="server" Text='<%# Bind("Issuedby") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                                            <ItemStyle Width="200px" />
                                            <FooterStyle Width="200px" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,Group %>">
                                            <EditItemTemplate>

                                                <asp:HiddenField ID="GroupID" runat="server" Value='<%# Bind("ItemGroupName") %>' />
                                                <asp:DropDownList ID="ddlNewGroupID" AutoPostBack="true" OnSelectedIndexChanged="ddlEditGroupID_SelectedIndexChanged" CssClass="cssDropDown" Width="80%" runat="server">
                                                </asp:DropDownList>

                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:DropDownList ID="ddlNewGroupID" AutoPostBack="true" OnSelectedIndexChanged="ddlNewGroupID_SelectedIndexChanged" CssClass="cssDropDown" Width="80%" runat="server">
                                                </asp:DropDownList>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblGroupID" CssClass="cssLabel" runat="server" Text='<%# Bind("ItemGroupName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                                            <ItemStyle Width="200px" />
                                            <FooterStyle Width="200px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,SubGroup %>">
                                            <EditItemTemplate>
                                                <asp:HiddenField ID="SubgroupId" runat="server" Value='<%# Bind("ItemSubGroupName") %>' />
                                                <asp:DropDownList ID="ddlNewSubgroupId" AutoPostBack="true" CssClass="dropdown" runat="server" OnSelectedIndexChanged="ddlEditSubGroupID_SelectedIndexChanged" Width="80%"></asp:DropDownList>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:DropDownList ID="ddlNewSubgroupId" AutoPostBack="true" CssClass="dropdown" runat="server" OnSelectedIndexChanged="ddlNewSubGroupID_SelectedIndexChanged" Width="80%"></asp:DropDownList>

                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblSubgroupId" CssClass="cssLabel" runat="server" Text='<%# Bind("ItemSubGroupName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                                            <ItemStyle Width="200px" />
                                            <FooterStyle Width="200px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,Item%>">
                                            <EditItemTemplate>
                                                <asp:HiddenField ID="hfitems" runat="server" Value='<%# Bind("ItemName") %>' />
                                                <asp:DropDownList ID="ddlNewItem" runat="server" CssClass="dropdown" Width="80%"></asp:DropDownList>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:DropDownList ID="ddlNewItem" runat="server" CssClass="dropdown" Width="80%"></asp:DropDownList>

                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblItem" CssClass="cssLabel" runat="server" Text='<%# Bind("ItemName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                                            <ItemStyle Width="200px" />
                                            <FooterStyle Width="200px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,Quantity %>">
                                            <EditItemTemplate>

                                                <asp:TextBox ID="txtQuantity" ValidationGroup="EditIssue" Width="80px" CssClass="csstxtbox" runat="server" Text='<%# Bind("Quantity") %>' MaxLength="5"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RFVQuantity" ValidationGroup="EditIssue" Display="Dynamic"
                                                    ControlToValidate="txtQuantity" runat="server" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </EditItemTemplate>
                                            <FooterTemplate>

                                                <asp:TextBox ID="txtQuantity" CssClass="csstxtbox" Width="80px" runat="server" ValidationGroup="Item" MaxLength="5"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RFVNewQuantity" ValidationGroup="Item" Display="Dynamic"
                                                    ControlToValidate="txtQuantity" runat="server" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </FooterTemplate>
                                            <ItemTemplate>

                                                <asp:Label ID="lblQuantity" CssClass="cssLabel" runat="server" Text='<%# Bind("Quantity") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                                            <ItemStyle Width="200px" />
                                            <FooterStyle Width="200px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$Resources:Resource,IssueingDate%>">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtEditIssueingDate" CssClass="csstxtbox" Width="90px" ValidationGroup="EditIssue" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("IssueingDate")) %>'></asp:TextBox>
                                                <asp:ImageButton ID="imgIssueingDate" Style="vertical-align: middle" runat="server" ImageUrl="~/Images/pdate.gif"></asp:ImageButton>
                                                <AjaxToolKit:CalendarExtender ID="CalendarExtender2" Format="dd-MMM-yyyy" runat="server"
                                                    TargetControlID="txtEditIssueingDate" PopupButtonID="imgIssueingDate" Enabled="True"></AjaxToolKit:CalendarExtender>
                                                <asp:RequiredFieldValidator ID="RFVDOB" ValidationGroup="EditIssue" Display="Dynamic"
                                                    ControlToValidate="txtEditIssueingDate" runat="server" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtNewIssueingDate" CssClass="csstxtbox" ValidationGroup="Item" Width="90px"
                                                    runat="server"></asp:TextBox>
                                                <asp:ImageButton ID="imgIssueingDate" Style="vertical-align: middle" runat="server" ImageUrl="~/Images/pdate.gif"></asp:ImageButton>
                                                <AjaxToolKit:CalendarExtender ID="CalendarExtender3" Format="dd-MMM-yyyy" runat="server"
                                                    TargetControlID="txtNewIssueingDate" PopupButtonID="imgIssueingDate" Enabled="True"></AjaxToolKit:CalendarExtender>
                                                <asp:RequiredFieldValidator ID="RFVNewIssueingDate" ValidationGroup="Item" Display="Dynamic"
                                                    ControlToValidate="txtNewIssueingDate" runat="server" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblIssueingDate" CssClass="cssLabel" runat="server"
                                                    Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("IssueingDate")) %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="250px" />
                                            <ItemStyle Width="250px" />
                                            <FooterStyle Width="250px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,ValidityDate %>">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtEditValidityDate" CssClass="csstxtbox" runat="server" Width="90px" Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("ValidityDate")) %>' ValidationGroup="EditIssue"></asp:TextBox>
                                                <asp:ImageButton ID="imgValidityDate1" Style="vertical-align: middle" runat="server" ImageUrl="~/Images/pdate.gif"></asp:ImageButton>
                                                <AjaxToolKit:CalendarExtender ID="CalendarExtender1" Format="dd-MMM-yyyy" runat="server"
                                                    TargetControlID="txtEditValidityDate" PopupButtonID="imgValidityDate1" Enabled="True"></AjaxToolKit:CalendarExtender>
                                                <asp:RequiredFieldValidator ID="RFVIssueingDate" ValidationGroup="EditIssue" Display="Dynamic"
                                                    ControlToValidate="txtEditValidityDate" runat="server" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>

                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtNewValidityDate" CssClass="csstxtbox" ValidationGroup="Item" Width="90px"
                                                    runat="server"></asp:TextBox>
                                                <asp:ImageButton ID="imgValidityDate" Style="vertical-align: middle" runat="server" ImageUrl="~/Images/pdate.gif"></asp:ImageButton>
                                                <AjaxToolKit:CalendarExtender ID="CalendarExtender1" Format="dd-MMM-yyyy" runat="server"
                                                    TargetControlID="txtNewValidityDate" PopupButtonID="imgValidityDate" Enabled="True"></AjaxToolKit:CalendarExtender>
                                                <asp:RequiredFieldValidator ID="RFVIssueingDate" ValidationGroup="Item" Display="Dynamic"
                                                    ControlToValidate="txtNewValidityDate" runat="server" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>

                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label45" CssClass="cssLabel" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("ValidityDate")) %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="250px" />
                                            <ItemStyle Width="250px" />
                                            <FooterStyle Width="250px" />
                                        </asp:TemplateField>

                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
                            <asp:Label ID="lblItem" EnableViewState="False" runat="server" CssClass="csslblErrMsg"></asp:Label>
                            <%-- <asp:Button ID="Button2" CssClass="cssButton" runat="server" Text="Back" OnClick="Button1_Click" />--%>
                        </ContentTemplate>
                    </AjaxToolKit:TabPanel>
                    <AjaxToolKit:TabPanel Style="text-align: left;" ID="EmployeeReferenceDetails" runat="server"
                        HeaderText="<%$Resources:Resource,EmployeeReferenceDetails %>" TabIndex="0">
                        <ContentTemplate>
                            <asp:Panel ID="Panel3" Font-Bold="True" ScrollBars="Auto" ForeColor="Red" GroupingText="<%$ Resources:Resource,EmployeeReferenceDetails%>"
                                Height="420px" runat="server">
                                <asp:GridView Width="100%" ID="gvEmployeeReferenceDetails" CssClass="GridViewStyle" runat="server" ShowFooter="True" AllowPaging="True" PageSize="10" CellPadding="1" GridLines="None"
                                    AutoGenerateColumns="False" OnRowDataBound="gvEmployeeReferenceDetails_RowDataBound" OnRowCommand="gvEmployeeReferenceDetails_RowCommand"
                                    OnRowDeleting="gvEmployeeReferenceDetails_RowDeleting" OnRowEditing="gvEmployeeReferenceDetails_OnRowEditing" OnPageIndexChanging="gvEmployeeReferenceDetails_PageIndexChanging"
                                    OnRowUpdating="gvEmployeeReferenceDetails_RowUpdating" OnRowCancelingEdit="gvEmployeeReferenceDetails_OnRowCancelingEdit">
                                    <FooterStyle CssClass="GridViewFooterStyle" />
                                    <RowStyle CssClass="GridViewRowStyle" />
                                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                    <PagerStyle CssClass="GridViewPagerStyle" />
                                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,EditColName %>">
                                            <EditItemTemplate>
                                                <asp:ImageButton ID="ImgbtnUpdateTran" ToolTip="<%$Resources:Resource,Update %>"
                                                    ImageUrl="~/Images/save.gif" CssClass="csslnkButton" runat="server" ValidationGroup="EditRD" CommandName="Update" />

                                                <asp:ImageButton ID="ImageButton2Tran" ToolTip="<%$Resources:Resource,Cancel %>"
                                                    ImageUrl="~/Images/Cancel.gif" CssClass="csslnkButton" runat="server" CausesValidation="False"
                                                    CommandName="Cancel" />
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:ImageButton ID="lbADD" runat="server" ToolTip="<%$Resources:Resource,Save %>"
                                                    CssClass="cssImgButton" ValidationGroup="NewRD" CommandName="AddNew" ImageUrl="../Images/AddNew.gif" />
                                                &nbsp;
                                    <asp:ImageButton ID="lbReset" ToolTip="<%$Resources:Resource,Reset %>" runat="server"
                                        CssClass="cssImgButton" CommandName="Reset" ImageUrl="../Images/Reset.gif" />
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="IBEditTran" ToolTip="<%$Resources:Resource,Edit %>" ImageUrl="~/Images/Edit.gif"
                                                    CssClass="csslnkButton" runat="server" CausesValidation="False"
                                                    CommandName="Edit" />

                                                <asp:ImageButton ID="IBDeleteTran" ToolTip="<%$Resources:Resource,Delete %>" ImageUrl="~/Images/Delete.gif"
                                                    runat="server" CssClass="csslnkButton" CausesValidation="False" CommandName="Delete" />
                                            </ItemTemplate>
                                            <FooterStyle Width="100px" />
                                            <HeaderStyle Width="100px" CssClass="cssLabelHeader" />
                                            <ItemStyle Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,Name %>">
                                            <EditItemTemplate>
                                                <asp:HiddenField ID="hfRefernceID" runat="server" Value='<%# Bind("RefernceID") %>' />
                                                <asp:TextBox ID="txtEditName" CssClass="csstxtbox" ValidationGroup="Edit" runat="server" Text='<%# Bind("Name") %>' MaxLength="100"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtEditName" runat="server" ControlToValidate="txtEditName"
                                                    ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="EditRD"></asp:RequiredFieldValidator>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:HiddenField ID="hidrefenceID" runat="server" Value="0" />
                                                <asp:TextBox ID="txtNewName" CssClass="csstxtbox" ValidationGroup="Item" runat="server" MaxLength="100"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtNewName" runat="server" ControlToValidate="txtNewName"
                                                    ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="NewRD"></asp:RequiredFieldValidator>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hfRefernceID" runat="server" Value='<%# Bind("RefernceID") %>' />
                                                <asp:Label ID="lblName" CssClass="cssLabel" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                                            <ItemStyle Width="200px" />
                                            <FooterStyle Width="200px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,Designation %>">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtEditDesignation" CssClass="csstxtbox" runat="server" Text='<%# Bind("Designation") %>' MaxLength="100"  ></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtEditDesignation" runat="server" ControlToValidate="txtEditDesignation"
                                                    ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="EditRD"></asp:RequiredFieldValidator>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtNewDesignation" CssClass="csstxtbox" runat="server" Text='<%# Bind("Designation") %>' MaxLength="100" ></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtNewDesignation" runat="server" ControlToValidate="txtNewDesignation"
                                                    ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="NewRD"></asp:RequiredFieldValidator>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblDesignation" CssClass="cssLabel" runat="server" Text='<%# Bind("Designation") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                                            <ItemStyle Width="200px" />
                                            <FooterStyle Width="200px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,Area %>">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtEditArea" CssClass="csstxtbox" runat="server" Text='<%# Bind("Area") %>' MaxLength="100"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtEditArea" runat="server" ControlToValidate="txtEditArea"
                                                    ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="EditRD"></asp:RequiredFieldValidator>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtNewArea" CssClass="csstxtbox" runat="server" MaxLength="100"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtNewArea" runat="server" ControlToValidate="txtNewArea"
                                                    ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="NewRD"></asp:RequiredFieldValidator>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblArea" CssClass="cssLabel" runat="server" Text='<%# Bind("Area") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                                            <ItemStyle Width="200px" />
                                            <FooterStyle Width="200px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,Organization %>">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtOrganization" CssClass="csstxtbox" runat="server" Text='<%# Bind("Organization") %>' MaxLength="100"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvOrganization" ForeColor="Red" ValidationGroup="EditRD" Display="Dynamic" ControlToValidate="txtOrganization" runat="server" Text="*"></asp:RequiredFieldValidator>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtOrganization" CssClass="csstxtbox" runat="server" MaxLength="100"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvOrganizationnew" ForeColor="Red" ValidationGroup="NewRD" Display="Dynamic" ControlToValidate="txtOrganization" runat="server" Text="*"></asp:RequiredFieldValidator>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblOrganization" CssClass="cssLabel" runat="server" Text='<%# Bind("Organization") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                                            <ItemStyle Width="200px" />
                                            <FooterStyle Width="200px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$Resources:Resource,Mobile%>">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtEditMobile" CssClass="csstxtbox" runat="server" Text='<%# Bind("Mobile") %>' MaxLength="10" Width="100px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RFVtxtNewMobile" ValidationGroup="EditRD" Display="Dynamic" SetFocusOnError="True" ForeColor="Red"
                                                    ControlToValidate="txtEditMobile" runat="server" Text="*"></asp:RequiredFieldValidator>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtNewMobile" CssClass="csstxtbox" runat="server" MaxLength="10" Width="100px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RFVtxtNewMobile" ValidationGroup="NewRD" Display="Dynamic" SetFocusOnError="True" ForeColor="Red"
                                                    ControlToValidate="txtNewMobile" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblMobile" CssClass="cssLabel" runat="server" Text='<%# Bind("Mobile") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                                            <ItemStyle Width="100px" />
                                            <FooterStyle Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,RelationshipRefernce %>">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtEditRelationshipRefernce" CssClass="csstxtbox" runat="server" Text='<%# Bind("RelationshipRefernce") %>' MaxLength="100" Width="125px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rftxtEditRelationshipRefernce" ValidationGroup="EditRD" Display="Dynamic" ControlToValidate="txtEditRelationshipRefernce" runat="server" SetFocusOnError="True" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtNewRelationshipRefernce" CssClass="csstxtbox" runat="server" MaxLength="100" Width="125px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rftxtNewRelationshipRefernce" ValidationGroup="NewRD" Display="Dynamic" ControlToValidate="txtNewRelationshipRefernce" runat="server" SetFocusOnError="True" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblRelationshipRefernce" CssClass="cssLabel" runat="server" Text='<%# Bind("RelationshipRefernce") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="130px" />
                                            <ItemStyle Width="130px" />
                                            <FooterStyle Width="130px" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
                            <asp:Label ID="lblreference" EnableViewState="False" runat="server" CssClass="csslblErrMsg"></asp:Label>
                           
                        </ContentTemplate>
                    </AjaxToolKit:TabPanel>
                    <AjaxToolKit:TabPanel Style="text-align: left;" ID="EmployeeEducational" runat="server"
                        HeaderText="<%$Resources:Resource,EmployeeEducational%>" TabIndex="0">
                        <ContentTemplate>
                            <asp:Panel ID="Panel5" Font-Bold="True" ScrollBars="Auto" ForeColor="Red" GroupingText="<%$ Resources:Resource,EmployeeEducational %>"
                                Height="420px" runat="server">
                                <asp:GridView Width="100%" ID="gvEmployeeEducational" CssClass="GridViewStyle" runat="server" ShowFooter="True" AllowPaging="True" PageSize="10" CellPadding="1" GridLines="None"
                                    AutoGenerateColumns="False" OnRowDataBound="gvEmployeeEducational_RowDataBound" OnRowCommand="gvEmployeeEducational_RowCommand"
                                    OnRowDeleting="gvEmployeeEducational_RowDeleting" OnRowEditing="gvEmployeeEducational_OnRowEditing" OnPageIndexChanging="gvEmployeeEducational_PageIndexChanging"
                                    OnRowUpdating="gvEmployeeEducational_RowUpdating" OnRowCancelingEdit="gvEmployeeEducational_OnRowCancelingEdit">
                                    <FooterStyle CssClass="GridViewFooterStyle" />
                                    <RowStyle CssClass="GridViewRowStyle" />
                                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                    <PagerStyle CssClass="GridViewPagerStyle" />
                                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,EditColName %>">
                                            <EditItemTemplate>
                                                <asp:ImageButton ID="ImgbtnUpdateTran" ToolTip="<%$Resources:Resource,Update %>"
                                                    ImageUrl="~/Images/save.gif" CssClass="csslnkButton" runat="server" CommandName="Update"
                                                    ValidationGroup="EditEdu" />
                                                <asp:ImageButton ID="ImageButton2Tran" ToolTip="<%$Resources:Resource,Cancel %>"
                                                    ImageUrl="~/Images/Cancel.gif" CssClass="csslnkButton" runat="server" CausesValidation="False"
                                                    CommandName="Cancel" />
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:ImageButton ID="lbADD" runat="server" ToolTip="<%$Resources:Resource,Save %>"
                                                    CssClass="cssImgButton" ValidationGroup="EDU" CommandName="AddNew" ImageUrl="../Images/AddNew.gif" />
                                                <asp:ImageButton ID="lbReset" ToolTip="<%$Resources:Resource,Reset %>" runat="server"
                                                    CssClass="cssImgButton" CommandName="Reset" ImageUrl="../Images/Reset.gif" />
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="IBEditTran" ToolTip="<%$Resources:Resource,Edit %>" ImageUrl="~/Images/Edit.gif"
                                                    CssClass="csslnkButton" runat="server" CausesValidation="False"
                                                    CommandName="Edit" />
                                                <asp:ImageButton ID="IBDeleteTran" ToolTip="<%$Resources:Resource,Delete %>" ImageUrl="~/Images/Delete.gif"
                                                    runat="server" CssClass="csslnkButton" CausesValidation="False" CommandName="Delete" />
                                            </ItemTemplate>
                                            <FooterStyle Width="100px" />
                                            <HeaderStyle Width="100px" CssClass="cssLabelHeader" />
                                            <ItemStyle Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,Class %>">
                                            <EditItemTemplate>
                                                <asp:HiddenField ID="EducationID" runat="server" Value='<%# Bind("EducationID") %>' />
                                                <asp:TextBox ID="txtEditClass" CssClass="csstxtbox" Width="100px" runat="server" Text='<%# Bind("Class") %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvEditClass" runat="server" ControlToValidate="txtEditClass"
                                                    ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="EditEdu"></asp:RequiredFieldValidator>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:HiddenField ID="NewEducationID" runat="server" Value="0" />
                                                <asp:TextBox ID="txtNewClass" CssClass="csstxtbox" Width="100px" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvNewClass" runat="server" ControlToValidate="txtNewClass"
                                                    ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="EDU"></asp:RequiredFieldValidator>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:HiddenField ID="EducationID" runat="server" Value='<%# Bind("EducationID") %>' />
                                                <asp:Label ID="lblClass" CssClass="cssLabel" runat="server" Text='<%# Bind("Class") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="150px" />
                                            <ItemStyle Width="150px" />
                                            <FooterStyle Width="150px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,QualificationDesc %>">
                                            <EditItemTemplate>
                                                <asp:HiddenField ID="hfqualificationcode" runat="server" Value='<%# Bind("QualificationCode") %>' />
                                                <asp:DropDownList ID="ddlQualificationDesc" runat="server" CssClass="cssDropDown" Width="200px"></asp:DropDownList>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:DropDownList ID="ddlQualificationDesc" runat="server" CssClass="cssDropDown" Width="200px"></asp:DropDownList>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblQualificationDesc" runat="server" CssClass="cssLabel" Text='<%# Bind("QualificationDesc") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="250px" />
                                            <ItemStyle Width="250px" />
                                            <FooterStyle Width="250px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,Specialization %>">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtEditSpecialization" CssClass="csstxtbox" runat="server" Text='<%# Bind("Specialization") %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvEditSpecilization" runat="server" ControlToValidate="txtEditSpecialization"
                                                    ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="EditEdu"></asp:RequiredFieldValidator>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtNewSpecialization" CssClass="csstxtbox" runat="server" Text='<%# Bind("Specialization") %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvNewSpecialization" runat="server" ControlToValidate="txtNewSpecialization"
                                                    ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="EDU"></asp:RequiredFieldValidator>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblSpecialization" CssClass="cssLabel" runat="server" Text='<%# Bind("Specialization") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                                            <ItemStyle Width="200px" />
                                            <FooterStyle Width="200px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,Grade%>">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtEditGrade" Width="100px" CssClass="csstxtbox" runat="server" Text='<%# Bind("Grade") %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvNewItem" runat="server" ControlToValidate="txtEditGrade"
                                                    ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="EditEdu"></asp:RequiredFieldValidator>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtNewGrade" Width="100px" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvNewItem" runat="server" ControlToValidate="txtNewGrade"
                                                    ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="EDU"></asp:RequiredFieldValidator>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblGrade" CssClass="cssLabel" runat="server" Text='<%# Bind("Grade") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="150px" />
                                            <ItemStyle Width="150px" />
                                            <FooterStyle Width="150px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,University%>">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtUniversity" CssClass="csstxtbox" runat="server" Text='<%# Bind("University") %>' MaxLength="100"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvUniversity" runat="server" ControlToValidate="txtUniversity"
                                                    ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="EditEdu"></asp:RequiredFieldValidator>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtUniversity" CssClass="csstxtbox" runat="server" MaxLength="100"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvUniversityNew" runat="server" ControlToValidate="txtUniversity"
                                                    ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="EDU"></asp:RequiredFieldValidator>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblUniversity" CssClass="cssLabel" runat="server" Text='<%# Bind("University") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="250px" />
                                            <ItemStyle Width="250px" />
                                            <FooterStyle Width="250px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$Resources:Resource,Yearofcompletion%>">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtEditYearofcompletion" Width="90px" CssClass="csstxtbox" runat="server" MaxLength="4" Text='<%# Bind("Yearofcompletion") %>'></asp:TextBox>
                                               <%-- <asp:ImageButton ID="imgtxtEditYearofcompletion" Style="vertical-align: middle" runat="server" ImageUrl="~/Images/pdate.gif"></asp:ImageButton>
                                                <AjaxToolKit:CalendarExtender ID="CalendarExtender2" Format="dd-MMM-yyyy" runat="server"
                                                    TargetControlID="txtEditYearofcompletion" PopupButtonID="imgtxtEditYearofcompletion" Enabled="True"></AjaxToolKit:CalendarExtender>--%>
                                                <asp:RequiredFieldValidator ID="RFVDOB" ValidationGroup="EditEdu" Display="Dynamic"
                                                    ControlToValidate="txtEditYearofcompletion" runat="server" Text="*"></asp:RequiredFieldValidator>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtNewYearofcompletion" Width="90px" CssClass="csstxtbox" runat="server" MaxLength="4"></asp:TextBox>
                                               <%-- <asp:ImageButton ID="imgNewYearofcompletion" Style="vertical-align: middle" runat="server" ImageUrl="~/Images/pdate.gif"></asp:ImageButton>
                                                <AjaxToolKit:CalendarExtender ID="CalendarExtender3" Format="yyyy" runat="server"
                                                    TargetControlID="txtNewYearofcompletion" PopupButtonID="imgNewYearofcompletion" Enabled="True"></AjaxToolKit:CalendarExtender>--%>
                                                <asp:RequiredFieldValidator ID="RFVNewimgNewYearofcompletion" ValidationGroup="EDU" Display="Dynamic"
                                                    ControlToValidate="txtNewYearofcompletion" runat="server" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblYearofcompletion" CssClass="cssLabel" runat="server"
                                                    Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("Yearofcompletion")) %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="150px" />
                                            <ItemStyle Width="150px" />
                                            <FooterStyle Width="150px" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
                            <asp:Label ID="lblEducation" EnableViewState="False" runat="server" CssClass="csslblErrMsg"></asp:Label>
                        </ContentTemplate>
                    </AjaxToolKit:TabPanel>
                    <AjaxToolKit:TabPanel Style="text-align: left;" ID="EmployeeExperience" runat="server" HeaderText="<%$Resources:Resource,EmployeeExperience %>" TabIndex="0">
                        <ContentTemplate>
                            <asp:Panel ID="Panel4" Font-Bold="True" ScrollBars="Auto" ForeColor="Red" GroupingText="<%$ Resources:Resource,EmployeeExperience%>"
                                Height="420px" runat="server">
                                <asp:GridView Width="100%" ID="gvEmployeeExperience" CssClass="GridViewStyle" runat="server" ShowFooter="True" AllowPaging="True" PageSize="10" CellPadding="1" GridLines="None"
                                    AutoGenerateColumns="False" OnRowDataBound="gvEmployeeExperience_RowDataBound" OnRowCommand="gvEmployeeExperience_RowCommand"
                                    OnRowEditing="gvEmployeeExperience_OnRowEditing" OnPageIndexChanging="gvEmployeeExperience_PageIndexChanging"
                                    OnRowUpdating="gvEmployeeExperience_RowUpdating" OnRowCancelingEdit="gvEmployeeExperience_OnRowCancelingEdit" OnRowDeleting="gvEmployeeExperience_RowDeleting">
                                    <FooterStyle CssClass="GridViewFooterStyle" />
                                    <RowStyle CssClass="GridViewRowStyle" />
                                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                    <PagerStyle CssClass="GridViewPagerStyle" />
                                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,EditColName %>">
                                            <EditItemTemplate>
                                                <asp:ImageButton ID="ImgbtnUpdateTran" ToolTip="<%$Resources:Resource,Update %>"
                                                    ImageUrl="~/Images/save.gif" CssClass="csslnkButton" runat="server" ValidationGroup="EditExperience" CommandName="Update" />
                                                <asp:ImageButton ID="ImageButton2Tran" ToolTip="<%$Resources:Resource,Cancel %>"
                                                    ImageUrl="~/Images/Cancel.gif" CssClass="csslnkButton" runat="server" CausesValidation="False"
                                                    CommandName="Cancel" />
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:ImageButton ID="lbADD" runat="server" ToolTip="<%$Resources:Resource,Save %>"
                                                    CssClass="cssImgButton" ValidationGroup="NewExperience" CommandName="AddNew" ImageUrl="../Images/AddNew.gif" />
                                                <asp:ImageButton ID="lbReset" ToolTip="<%$Resources:Resource,Reset %>" runat="server"
                                                    CssClass="cssImgButton" CommandName="Reset" ImageUrl="../Images/Reset.gif" />
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="IBEditTran" ToolTip="<%$Resources:Resource,Edit %>" ImageUrl="~/Images/Edit.gif"
                                                    CssClass="csslnkButton" runat="server" CausesValidation="False"
                                                    CommandName="Edit" />

                                                <asp:ImageButton ID="IBDeleteTran" ToolTip="<%$Resources:Resource,Delete %>" ImageUrl="~/Images/Delete.gif"
                                                    runat="server" CssClass="csslnkButton" CausesValidation="False" CommandName="Delete" />
                                            </ItemTemplate>
                                            <FooterStyle Width="105px" />
                                            <HeaderStyle Width="105px" CssClass="cssLabelHeader" />
                                            <ItemStyle Width="105px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,Designation %>">
                                            <EditItemTemplate>
                                                <asp:HiddenField ID="hfExperienceId" runat="server" Value='<%# Bind("ExperienceId") %>' />
                                              
                                                <asp:TextBox ID="txtDesignation" CssClass="csstxtbox" runat="server" MaxLength="50" Text='<%# Bind("Designation") %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtDesignation" runat="server" ControlToValidate="txtDesignation"
                                                    ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="EditExperience"></asp:RequiredFieldValidator>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                  <asp:Label ID="hfDOB" runat="server"  />
                                                <asp:HiddenField ID="hfexperienceid" runat="server" Value="0" />
                                                <asp:TextBox ID="txtDesignation" CssClass="csstxtbox" runat="server" MaxLength="50"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtDesignation" runat="server" ControlToValidate="txtDesignation"
                                                    ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="NewExperience"></asp:RequiredFieldValidator>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hfExperienceId" runat="server" Value='<%# Bind("ExperienceId") %>' />
                                                <asp:Label ID="lblDesignation" CssClass="cssLabel" runat="server" Text='<%# Bind("Designation") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                                            <ItemStyle Width="200px" />
                                            <FooterStyle Width="200px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,Department %>">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtDepartment" CssClass="csstxtbox" runat="server" MaxLength="50" Text='<%# Bind("Department") %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtDepartment" runat="server" ControlToValidate="txtDepartment"
                                                    ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="EditExperience"></asp:RequiredFieldValidator>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtDepartment" CssClass="csstxtbox" runat="server" MaxLength="50"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtDepartment" runat="server" ControlToValidate="txtDepartment"
                                                    ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="NewExperience"></asp:RequiredFieldValidator>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblDepartment" CssClass="cssLabel" runat="server" Text='<%# Bind("Department") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                                            <ItemStyle Width="200px" />
                                            <FooterStyle Width="200px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,CompanyName %>">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtCompanyName" CssClass="csstxtbox" MaxLength="50" runat="server" Text='<%# Bind("CompanyName") %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtCompanyName" runat="server" ControlToValidate="txtCompanyName"
                                                    ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="EditExperience"></asp:RequiredFieldValidator>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtCompanyName" CssClass="csstxtbox" MaxLength="50" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtCompanyName" runat="server" ControlToValidate="txtCompanyName"
                                                    ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="NewExperience"></asp:RequiredFieldValidator>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblCompanyName" CssClass="cssLabel" runat="server" Text='<%# Bind("CompanyName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                                            <ItemStyle Width="200px" />
                                            <FooterStyle Width="200px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$Resources:Resource,Address%>">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtAddress" CssClass="csstxtbox" runat="server" MaxLength="100" Text='<%# Bind("Address") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtAddress" CssClass="csstxtbox" runat="server" MaxLength="100"></asp:TextBox>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblAddress" CssClass="cssLabel" runat="server" Text='<%# Bind("Address") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                                            <ItemStyle Width="200px" />
                                            <FooterStyle Width="200px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,FromDate %>">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtFromDate" CssClass="csstxtbox" runat="server" Width="90px" Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("FromDate")) %>'>></asp:TextBox>
                                                <asp:ImageButton ID="imgFromDateEdit" Style="vertical-align: middle" runat="server" ImageUrl="~/Images/pdate.gif"></asp:ImageButton>
                                                <AjaxToolKit:CalendarExtender ID="CEFromDateEdit" Format="dd-MMM-yyyy" runat="server"
                                                    TargetControlID="txtFromDate" PopupButtonID="imgFromDateEdit" Enabled="True"></AjaxToolKit:CalendarExtender>
                                                <asp:RequiredFieldValidator ID="rfvtxtfromdate" ValidationGroup="EditExperience" Display="Dynamic" ControlToValidate="txtFromDate" runat="server" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtFromDate" CssClass="csstxtbox" runat="server" Width="90px"></asp:TextBox>
                                                <asp:ImageButton ID="imgFromDate" Style="vertical-align: middle" runat="server" ImageUrl="~/Images/pdate.gif"></asp:ImageButton>
                                                <AjaxToolKit:CalendarExtender ID="CEFromDate" Format="dd-MMM-yyyy" runat="server"
                                                    TargetControlID="txtFromDate" PopupButtonID="imgFromDate" Enabled="True"></AjaxToolKit:CalendarExtender>
                                                <asp:RequiredFieldValidator ID="rfvtxtfromdate" ValidationGroup="NewExperience" Display="Dynamic" ControlToValidate="txtFromDate" runat="server" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblfromdate" CssClass="cssLabel" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("FromDate")) %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="150px" />
                                            <ItemStyle Width="150px" />
                                            <FooterStyle Width="150px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,ToDate %>">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtToDate" CssClass="csstxtbox" Width="90px" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("ToDate")) %>'></asp:TextBox>
                                                <asp:ImageButton ID="imgToDateEdit" Style="vertical-align: middle" runat="server" ImageUrl="~/Images/pdate.gif"></asp:ImageButton>
                                                <AjaxToolKit:CalendarExtender ID="CEToDateEdit" Format="dd-MMM-yyyy" runat="server"
                                                    TargetControlID="txtToDate" PopupButtonID="imgToDateEdit" Enabled="True"></AjaxToolKit:CalendarExtender>
                                                <asp:RequiredFieldValidator ID="rfvtxtToDate" ValidationGroup="EditExperience" Display="Dynamic" ControlToValidate="txtToDate" runat="server" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>

                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtToDate" CssClass="csstxtbox" Width="90px" runat="server"></asp:TextBox>
                                                <asp:ImageButton ID="imgToDate" Style="vertical-align: middle" runat="server" ImageUrl="~/Images/pdate.gif"></asp:ImageButton>
                                                <AjaxToolKit:CalendarExtender ID="CEToDate" Format="dd-MMM-yyyy" runat="server"
                                                    TargetControlID="txtToDate" PopupButtonID="imgToDate" Enabled="True"></AjaxToolKit:CalendarExtender>
                                                <asp:RequiredFieldValidator ID="rfvtxtToDate" ValidationGroup="NewExperience" Display="Dynamic" ControlToValidate="txtToDate" runat="server" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>

                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbltodate" CssClass="cssLabel" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("ToDate")) %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="150px" />
                                            <ItemStyle Width="150px" />
                                            <FooterStyle Width="150px" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
                            <asp:Label ID="lblExperience" EnableViewState="False" runat="server" CssClass="csslblErrMsg"></asp:Label>
                             <asp:HiddenField ID="lblDOB"  runat="server" ></asp:HiddenField>
                        </ContentTemplate>
                    </AjaxToolKit:TabPanel>
                    <AjaxToolKit:TabPanel Style="text-align: left;" ID="EmployeeRefferdBy" runat="server" HeaderText="<%$Resources:Resource,EmployeeReferredBy %>" TabIndex="0">
                        <ContentTemplate>
                            <asp:Panel ID="Panel6" Font-Bold="True" ScrollBars="Auto" ForeColor="Red" GroupingText="<%$ Resources:Resource,EmployeeReferredBy%>"
                                Height="420px" runat="server">
                                <asp:GridView Width="100%" ID="gvEmpReferredBy" CssClass="GridViewStyle" runat="server" ShowFooter="True" AllowPaging="True" PageSize="10" CellPadding="1" GridLines="None"
                                    AutoGenerateColumns="False" OnRowDataBound="gvEmpReferredBy_RowDataBound" OnRowCommand="gvEmpReferredBy_RowCommand"
                                    OnRowEditing="gvEmpReferredBy_OnRowEditing" OnPageIndexChanging="gvEmpReferredBy_PageIndexChanging"
                                    OnRowUpdating="gvEmpReferredBy_RowUpdating" OnRowCancelingEdit="gvEmpReferredBy_OnRowCancelingEdit" OnRowDeleting="gvEmpReferredBy_RowDeleting">
                                    <FooterStyle CssClass="GridViewFooterStyle" />
                                    <RowStyle CssClass="GridViewRowStyle" />
                                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                    <PagerStyle CssClass="GridViewPagerStyle" />
                                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,EditColName %>">
                                            <EditItemTemplate>
                                                <asp:ImageButton ID="ImgbtnUpdateTran" ToolTip="<%$Resources:Resource,Update %>"
                                                    ImageUrl="~/Images/save.gif" CssClass="csslnkButton" runat="server" CommandName="Update" />
                                                <asp:ImageButton ID="ImageButton2Tran" ToolTip="<%$Resources:Resource,Cancel %>"
                                                    ImageUrl="~/Images/Cancel.gif" CssClass="csslnkButton" runat="server" CausesValidation="False"
                                                    CommandName="Cancel" />
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:ImageButton ID="lbADD" runat="server" ToolTip="<%$Resources:Resource,Save %>"
                                                    CssClass="cssImgButton" CommandName="AddNew" ImageUrl="../Images/AddNew.gif" />
                                                &nbsp;
                                        <asp:ImageButton ID="lbReset" ToolTip="<%$Resources:Resource,Reset %>" runat="server"
                                            CssClass="cssImgButton" CommandName="Reset" ImageUrl="../Images/Reset.gif" />
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="IBEditTran" ToolTip="<%$Resources:Resource,Edit %>" ImageUrl="~/Images/Edit.gif"
                                                    CssClass="csslnkButton" runat="server" CausesValidation="False"
                                                    CommandName="Edit" />
                                                <asp:ImageButton ID="IBDeleteTran" ToolTip="<%$Resources:Resource,Delete %>" ImageUrl="~/Images/Delete.gif"
                                                    runat="server" CssClass="csslnkButton" CausesValidation="False" CommandName="Delete" />
                                            </ItemTemplate>
                                            <FooterStyle Width="100px" />
                                            <HeaderStyle Width="100px" CssClass="cssLabelHeader" />
                                            <ItemStyle Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,EmployeeNumber %>">
                                            <EditItemTemplate>
                                                <asp:HiddenField ID="HFReferredID" runat="server" Value='<%# Bind("ReferredID") %>' />
                                                <asp:TextBox ID="txtRefererEmployeeNumber" Width="100px" CssClass="csstxtbox" runat="server" Text='<%# Bind("ReferEmployeeNumber") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:HiddenField ID="hfReferredID" runat="server" Value="0" />
                                                <asp:TextBox ID="txtRefererEmployeeNumber" Width="100px" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                                <asp:ImageButton ID="imgSearchEmp" AlternateText="<%$ Resources:Resource,SearchEmployee %>"
                                                    runat="server" ImageUrl="~/Images/icosearch.gif" ToolTip="" Width="15px" OnClick="imgSearchEmp_Click" />
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:HiddenField ID="HFReferredID" runat="server" Value='<%# Bind("ReferredID") %>' />
                                                <asp:Label ID="lblRefererEmployeeNumber" CssClass="cssLabel" runat="server" Text='<%# Bind("ReferEmployeeNumber") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                                            <ItemStyle Width="200px" />
                                            <FooterStyle Width="200px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,EmployeeName %>">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtRefererEmployeeName" CssClass="csstxtbox" runat="server" Text='<%# Bind("ReferEmployeeName") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtRefererEmployeeName" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblRefererEmployeeName" CssClass="cssLabel" runat="server" Text='<%# Bind("ReferEmployeeName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                                            <ItemStyle Width="200px" />
                                            <FooterStyle Width="200px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,Branch %>">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtLocationDesc" CssClass="csstxtbox" runat="server" Text='<%# Bind("LocationDesc") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtLocationDesc" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblLocationDesc" CssClass="cssLabel" runat="server" Text='<%# Bind("LocationDesc") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                                            <ItemStyle Width="200px" />
                                            <FooterStyle Width="200px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$Resources:Resource,Designation%>">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtDesignationDesc" CssClass="csstxtbox" runat="server" Text='<%# Bind("DesignationDesc") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtDesignationDesc" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblDesignationDesc" CssClass="cssLabel" runat="server" Text='<%# Bind("DesignationDesc") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                                            <ItemStyle Width="200px" />
                                            <FooterStyle Width="200px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,Department %>">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtDepartmentName" CssClass="csstxtbox" runat="server" Text='<%# Bind("DepartmentName") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtDepartmentName" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblDepartmentName" CssClass="cssLabel" runat="server" Text='<%# Bind("DepartmentName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                                            <ItemStyle Width="200px" />
                                            <FooterStyle Width="200px" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
                            <asp:Label ID="lblReferedBy" EnableViewState="False" runat="server" CssClass="csslblErrMsg"></asp:Label>
                        </ContentTemplate>
                    </AjaxToolKit:TabPanel>
                    <AjaxToolKit:TabPanel Style="text-align: left;" ID="EmployeePFandESI" runat="server" HeaderText="<%$Resources:Resource,EmployeePFandESI %>" TabIndex="0">
                        <ContentTemplate>
                            <asp:Panel ID="PanelESIandPF" Font-Bold="true" ForeColor="Red" GroupingText="<%$Resources:Resource,EmployeePFandESI %>" Height="420px" runat="server">
                                <table align="center" width="50%" border="0" cellspacing="0px" cellpadding="1px">
                                    <tr>
                                        <td style="text-align: center; width: 50px; font: x-large">
                                            <asp:Label ID="lblPF" runat="server" CssClass="cssLabel" Text="Provident Fund" Style="width: 110px; font-size: 15px"></asp:Label>
                                            <asp:RadioButton ID="rblPF" runat="server" GroupName="PFandESI" OnCheckedChanged="rblPF_CheckedChanged" AutoPostBack="true" />
                                        </td>
                                        <td style="text-align: center; width: 50px;">
                                            <asp:Label ID="lblESI" runat="server" CssClass="cssLabel" Text="ESI" Style="width: 110px; margin-left: -96px; font-size: 15px;"></asp:Label>
                                            <asp:RadioButton ID="rblESI" runat="server" GroupName="PFandESI" OnCheckedChanged="rblESI_CheckedChanged" AutoPostBack="true" />
                                    </tr>
                                </table>
                                <br />
                                <asp:Panel ID="EmployeeESI" Font-Bold="True" ScrollBars="Auto" ForeColor="Red" GroupingText="<%$ Resources:Resource,EmployeeESI%>"
                                    runat="server" Visible="false">
                                    <table align="left" width="100%" border="0" cellspacing="0px" cellpadding="1px">

                                        <tr>
                                            <td style="text-align: right; width: 107px;">
                                                <asp:Label ID="lblESINo" CssClass="cssLable" runat="server" Style="width: 110px;"
                                                    Text="ESI No."></asp:Label>
                                            </td>
                                            <td style="text-align: left; width: 107px;">
                                                <asp:TextBox ID="txtESINo" runat="server" CssClass="csstxtboxRequired"
                                                    Style="width: 120px;" MaxLength="50"></asp:TextBox>
                                            </td>

                                            <td style="text-align: right; width: 60px;">
                                                <asp:Label ID="lblOldESI" CssClass="cssLable" runat="server" Style="width: 110px;"
                                                    Text="Old ESI No. (if any)  "></asp:Label>
                                            </td>
                                            <td style="text-align: left; width: 50px;">
                                                <asp:TextBox ID="txtOldESI" runat="server" CssClass="csstxtbox"
                                                    Style="width: 120px;" MaxLength="50"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <br />
                                        <tr>
                                            <td></td>
                                            <td></td>
                                            <td style="text-align: left; width: 201px;">
                                                <asp:Button ID="btnupdateESI" CssClass="cssButton" runat="server" Text="Update" Visible="false" OnClick="btnupdateESI_Click" />
                                                <asp:Button ID="btnsubmitESI" CssClass="cssButton" runat="server" Text="Submit" OnClick="btnsubmitESI_Click" />
                                                <asp:Button ID="btnDeleteESI" CssClass="cssButton" runat="server" Text="Delete" Visible="false" OnClick="btnDeleteESI_Click" /></td>

                                            <td></td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="EmployeePF" Font-Bold="True" ScrollBars="Auto" ForeColor="Red" GroupingText="<%$ Resources:Resource,EmployeePF%>"
                                    runat="server" Visible="false">
                                    <table align="left" width="100%" border="0" cellspacing="0px" cellpadding="1px">

                                        <tr>
                                            <td style="text-align: right; width: 200px;">
                                                <asp:Label ID="lblUANNo" CssClass="cssLable" runat="server" Style="width: 110px;"
                                                    Text="UAN No."></asp:Label>
                                            </td>
                                            <td style="text-align: left; width: 107px;">
                                                <asp:TextBox ID="txtUANNo" runat="server" CssClass="csstxtboxRequired"
                                                    Style="width: 120px;" MaxLength="50"></asp:TextBox>

                                            </td>
                                            <td style="text-align: right; width: 50px;">
                                                <asp:Label ID="lblOldUAN" CssClass="cssLable" runat="server" Style="width: 110px;"
                                                    Text="Old UAN No.(if any)  "></asp:Label>
                                            </td>
                                            <td style="text-align: left; width: 250px;">
                                                <asp:TextBox ID="txtOldUAN" runat="server" CssClass="csstxtbox"
                                                    Style="width: 120px;" MaxLength="50"></asp:TextBox>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right; width: 140px;">
                                                <asp:Label ID="lblPFno" CssClass="cssLable" runat="server" Style="width: 110px;"
                                                    Text="PF No."></asp:Label>
                                            </td>
                                            <td style="text-align: left; width: 280px;">
                                                <asp:TextBox ID="txtregioncode" runat="server" CssClass="csstxtboxRequired"
                                                    Style="width: 40px;" MaxLength="50"></asp:TextBox>
                                                <asp:TextBox ID="txtofficecode" runat="server" CssClass="csstxtboxRequired"
                                                    Style="width: 60px;" MaxLength="50"></asp:TextBox>
                                                <asp:TextBox ID="txtestablishmentno" runat="server" CssClass="csstxtboxRequired"
                                                    Style="width: 60px;" MaxLength="7"></asp:TextBox>
                                                <asp:TextBox ID="txtextensionno" runat="server" CssClass="csstxtboxRequired"
                                                    Style="width: 30px;" MaxLength="3"></asp:TextBox>
                                                <asp:TextBox ID="txtaccountno" runat="server" CssClass="csstxtboxRequired"
                                                    Style="width: 60px;" MaxLength="7"></asp:TextBox>
                                            </td>
                                            <td style="text-align: right; width: 100px;">
                                                <asp:Label ID="lbloldPF" CssClass="cssLable" runat="server" Style="width: 110px;"
                                                    Text="Old PF No. (if any)  "></asp:Label>
                                            </td>
                                            <td style="text-align: left; width: 280px;">
                                                <asp:TextBox ID="txtregionnoold" runat="server" CssClass="csstxtbox"
                                                    Style="width: 40px;" MaxLength="50"></asp:TextBox>
                                                <asp:TextBox ID="txtofficenoold" runat="server" CssClass="csstxtbox"
                                                    Style="width: 60px;" MaxLength="50"></asp:TextBox>
                                                <asp:TextBox ID="txtestablishmentnoold" runat="server" CssClass="csstxtbox"
                                                    Style="width: 60px;" MaxLength="7"></asp:TextBox>
                                                <asp:TextBox ID="txtentensionnoold" runat="server" CssClass="csstxtbox"
                                                    Style="width: 30px;" MaxLength="3"></asp:TextBox>
                                                <asp:TextBox ID="txtaccountnoold" runat="server" CssClass="csstxtbox"
                                                    Style="width: 60px;" MaxLength="7"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <br />
                                        <tr>
                                            <td></td>
                                            <td></td>
                                            <td style="text-align: left; width: 201px;">
                                                <asp:Button ID="btnUpdatePF" CssClass="cssButton" runat="server" Text="Update" Visible="false" OnClick="btnupdateESI_Click" />
                                                <asp:Button ID="btnSubmitPF" CssClass="cssButton" runat="server" Text="Submit" OnClick="btnsubmitESI_Click" />
                                                <asp:Button ID="btnDeletePF" CssClass="cssButton" runat="server" Text="Delete" Visible="false" OnClick="btnDeleteESI_Click" /></td>
                                            <td></td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Label ID="lblPFandESI" EnableViewState="False" runat="server" CssClass="csslblErrMsg"></asp:Label>
                            </asp:Panel>
                        </ContentTemplate>
                    </AjaxToolKit:TabPanel>
                </AjaxToolKit:TabContainer>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:Button ID="Button1" CssClass="cssButton" runat="server" Text="Back" OnClick="Button1_Click" />
        <asp:Button ID="btnBack" CssClass="cssButton" runat="server" Text="<%$ Resources:Resource,EmployeeList %>" OnClick="btnBack_Click" />
        <asp:HiddenField ID="IDItemIssueing" runat="server" Value="0" />
        <asp:HiddenField ID="IDVerification" runat="server" Value="0" />
        <asp:HiddenField ID="HfCompanyCode" runat="server" Value="0" />
        <asp:HiddenField ID="HfHrLocation" runat="server" Value="0" />
        <script type="text/javascript" language="javascript">
            function OpenEmployeeDocumnetUpload() {
                var EmployeeNumber = document.getElementById('<%=lblEmployeeNumberViewEmployeejobDetail.ClientID %>').innerHTML;

                var PageName = "EmployeeDocumentUpload.aspx?EmployeeNumber=" + EmployeeNumber;
                window.open(PageName, null, 'status=off,center=yes,scroll=no,Width=800px,help=no');
            }
        </script>
    </div>
</asp:Content>
