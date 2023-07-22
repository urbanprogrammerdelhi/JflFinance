<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="UserLocationRights.aspx.cs" Inherits="UserManagement_UserLocationRights"
    Title="<%$ Resources:Resource, AppTitle %>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/jscript">
var oldgridSelectedColor;
var newgridSelectedColor = '#7ca8d3';
function CheckUncheckAll(objCheckBox)
{
    var frm = document.aspnetForm;
    var chkState=objCheckBox.checked;
    
    var mycolor;
    if (objCheckBox.checked == true) 
    {
        oldgridSelectedColor = objCheckBox.parentElement.parentElement.style.backgroundColor;
        mycolor = newgridSelectedColor;
    }
    else
    {
        mycolor = oldgridSelectedColor;
    }
    
    for(i=0; i< frm.length;i++)
        {
            e = frm.elements[i];
            if(e.type=='checkbox' && e.name.indexOf('cbCompanyCode') != -1)
            {
                e.checked= chkState ;
            }
            if(e.type=='checkbox' && e.name.indexOf('cbHrLocationCode') != -1)
            {
                e.checked= chkState ;
            }
            if(e.type=='checkbox' && e.name.indexOf('cbLocationCodeRight') != -1)
            {
                e.checked= chkState ;
                e.parentElement.parentElement.style.backgroundColor=mycolor;
            }
        }    
}

function CheckUncheckLocation(objCheckBox)
{ 
    var mycolor;
    if (objCheckBox.checked == false) 
    {
        mycolor = oldgridSelectedColor;
        objCheckBox.parentElement.parentElement.style.backgroundColor = mycolor;
    }
    else
    {
        oldgridSelectedColor = objCheckBox.parentElement.parentElement.style.backgroundColor;
        mycolor = newgridSelectedColor;
        objCheckBox.parentElement.parentElement.style.backgroundColor = mycolor;
    }
}

function CheckUncheckHrLocation(objCheckBox)
{
    var frm = document.aspnetForm;
    var chkState = objCheckBox.checked;
    
    var objgvCell = objCheckBox.parentElement.parentElement;
    var objgvRow = objgvCell.parentElement;
    var objgvTable = objgvRow.parentElement.parentElement;
    
    var intRowSpan = objgvCell.rowSpan;
    var intRowIndex = objgvRow.rowIndex;
    
    var mycolor;
    
    if (objCheckBox.checked == true) 
    {
        oldgridSelectedColor = objgvCell.style.backgroundColor;
        mycolor = newgridSelectedColor;
    }
    else
    {
        mycolor = oldgridSelectedColor;
    }

    for(j=0; j< intRowSpan; j++)
    {
          if(objgvTable.rows[intRowIndex+j].cells[0].children[0].children[0] != null)
          {
            cb = objgvTable.rows[intRowIndex+j].cells[0].children[0].children[0];
            if(cb.type=='checkbox' && cb.name.indexOf('cbLocationCodeRight') != -1)
            {
                cb.checked= chkState; 
                cb.parentElement.parentElement.style.backgroundColor=mycolor;
             }
            else if(objgvTable.rows[intRowIndex+j].cells[1].children[0].children[0] != null)
                  {
                    cb = objgvTable.rows[intRowIndex+j].cells[1].children[0].children[0];
                    if(cb.type=='checkbox' && cb.name.indexOf('cbLocationCodeRight') != -1)
                    { 
                        cb.checked= chkState; 
                        cb.parentElement.parentElement.style.backgroundColor=mycolor;
                    }
                    else if(objgvTable.rows[intRowIndex+j].cells[2].children[0].children[0] != null)
                          {
                            cb = objgvTable.rows[intRowIndex+j].cells[2].children[0].children[0];
                            if(cb.type=='checkbox' && cb.name.indexOf('cbLocationCodeRight') != -1)
                            { 
                                cb.checked= chkState; 
                                cb.parentElement.parentElement.style.backgroundColor=mycolor;
                            }
                          }
                  }
          }
    }
}

function CheckUncheckCompany(objCheckBox)
{
    var frm1 = document.aspnetForm;
    var chkState1 = objCheckBox.checked;
    
    var objgvCell1 = objCheckBox.parentElement.parentElement;
    var objgvRow1 = objgvCell1.parentElement;
    var objgvTable1 = objgvRow1.parentElement.parentElement;
    
    var intRowSpan1 = objgvCell1.rowSpan;
    var intRowIndex1 = objgvRow1.rowIndex;
    

    for(k=0; k< intRowSpan1; k++)
    {
          if(objgvTable1.rows[intRowIndex1+k].cells[0].children[0].children[0] != null)
          {
            cb = objgvTable1.rows[intRowIndex1+k].cells[0].children[0].children[0];
            if(cb.type=='checkbox' && (cb.name.indexOf('cbHrLocationCode') != -1))
            {
                cb.checked= chkState1;
                CheckUncheckHrLocation(cb);
             }
             else if (cb.type=='checkbox' && cb.name.indexOf('cbLocationCodeRight') == -1)
             {
                 if(objgvTable1.rows[intRowIndex1+k].cells[1].children[0].children[0] != null)
                 {
                        cb = objgvTable1.rows[intRowIndex1+k].cells[1].children[0].children[0];
                        if(cb.type=='checkbox' && (cb.name.indexOf('cbHrLocationCode') != -1))
                        { 
                           cb.checked= chkState1;
                           CheckUncheckHrLocation(cb);
                        }
                 }
             }
          }
    }
}
    </script>

    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td align="center">
                
                
                <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table border="0" style="margin: 0; width: 100%" cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="height: 20px;" class="cssLabelHeaderBackground">
                                    <table style="width:100%;">
                                        <tr>
                                            <td align="left">
                                                <div id="divheader" >
                                                    <asp:Label ID="lblUserIDhdr" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, UserID %>"></asp:Label>:&nbsp;
                                                    <asp:Label Style="text-align: left;" CssClass="cssLabelHeader" Width="150px" ID="lblUserID" runat="server" Text=""></asp:Label>&nbsp;
                                                    <asp:Label ID="lblUserNamehdr" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, UserName %>"></asp:Label>:&nbsp;
                                                    <asp:Label Style="text-align: left;" CssClass="cssLabelHeader" Width="150px" ID="lblUserName" runat="server" Text=""></asp:Label>
                                                </div>
                                            </td>
                                            <td align="right">
                                                <asp:Button ID="btnBack" runat="server" ToolTip="<%$ Resources:Resource, UserDetail %>" Text="<%$ Resources:Resource, BtnBack %>" CssClass="cssButton" OnClick="btnBack_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div id="divDetails" class="section" style="height:420px;">
                                    <asp:GridView Width="100%" ID="gvUserLocRights" CssClass="GridViewStyle" runat="server"
                                        ShowFooter="true" ShowHeader="true" Visible="true" CellPadding="1" GridLines="None"
                                        AutoGenerateColumns="False" OnRowCommand="gvUserLocRights_RowCommand" OnRowDataBound="gvUserLocRights_RowDataBound">
                                        <FooterStyle CssClass="GridViewFooterStyle" />
                                        <RowStyle CssClass="GridViewRowStyle" />
                                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                        <PagerStyle CssClass="GridViewPagerStyle" />
                                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                        <HeaderStyle CssClass="GridViewHeaderStyle" />
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblgvhdrCompanyDesc" CssClass="cssLabelHeader" runat="server" Text="<% $ Resources:Resource, CompanyDescription%>"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="cbCompanyCode" runat="server" CssClass="cssCheckBox" Text='<%# DataBinder.Eval(Container.DataItem, "CompanyCode").ToString()%>'
                                                        onclick="javascript:CheckUncheckCompany(this);" />
                                                    <asp:Label ID="lblgvCompanyDesc" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CompanyDesc").ToString()%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblgvhdrHrLocationDesc" CssClass="cssLabelHeader" runat="server" Text="<% $ Resources:Resource, HrLocationDescription%>"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="cbHrLocationCode" runat="server" CssClass="cssCheckBox" Text='<%# DataBinder.Eval(Container.DataItem, "HrLocationCode").ToString()%>'
                                                        onclick="javascript:CheckUncheckHrLocation(this);" />
                                                    <asp:Label ID="lblgvHrLocationDesc" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "HrLocationDesc").ToString()%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="cbAllLocationRight" runat="server" CssClass="cssCheckBox" Text="<% $ Resources:Resource, LocationDescription%>"
                                                        onclick="javascript:CheckUncheckAll(this);" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="cbLocationCodeRight" runat="server" CssClass="cssCheckBox" Checked='<%# bool.Parse(DataBinder.Eval(Container.DataItem, "Right").ToString())%>'
                                                        Text='<%# DataBinder.Eval(Container.DataItem, "LocationCode").ToString()%>' onclick="javascript:CheckUncheckLocation(this);" />
                                                    <asp:Label ID="lblgvLocationDesc" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "LocationDesc").ToString()%>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Button ID="btnAdd" CssClass="cssSaveButton" runat="server" ToolTip="<%$ Resources:Resource, Save %>" Text="<%$ Resources:Resource, Save %>" CommandName="Save" />
                                                    <asp:ImageButton Visible="false" ID="ImgbtnAdd" runat="server" CssClass="cssImgButton" CommandName="Save"
                                                        ToolTip="<%$ Resources:Resource, Save %>" ImageUrl="../Images/AddNew.gif" />
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    </div>
                                </td>
                            </tr>
                           <%-- <tr>
                                <td align="right" style="height: 20px;" class="cssLabelHeaderBackground">
                                    <asp:Button ID="btnNext" runat="server" ToolTip="<%$ Resources:Resource, UserScreenRights %>" Text="<%$ Resources:Resource, btnNext %>" CssClass="cssButton" OnClick="btnNext_Click" />
                                </td>
                            </tr>--%>
                            <tr>
                                <td>
                                    <asp:Label ID="lblErrorMsg" CssClass="csslblErrMsg" Text="" EnableViewState="false" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </Ajax:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
