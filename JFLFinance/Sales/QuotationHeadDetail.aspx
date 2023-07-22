<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="QuotationHeadDetail.aspx.cs" Inherits="Sales_QuotationHeadDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
     <div style="margin-right:20px" >
                <table width="50%" border="0" cellspacing="0px" cellpadding="0px"  >
             <tr>
                   <td style="text-align: right;">
                <asp:Label ID="Label7" Width="100px" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,CompanyCode %>"></asp:Label>
            </td>
            <td style="text-align: left;">
                 <asp:TextBox ID="txtcompanycode" runat="server" CssClass="csstxtboxReadonly" Width="150px" style="margin-left:5px"  ></asp:TextBox>
                
            </td>
           
             <td style="text-align: right;">
                <asp:Label ID="Label9" Width="100px" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,State %>"></asp:Label>
            </td>
            <td style="text-align: left;">
                 <asp:TextBox ID="txtstate" runat="server" CssClass="csstxtboxReadonly" Width="150px" style="margin-left:5px"  ></asp:TextBox>
                
            </td>
                 
             </tr>
                     <tr>
             <td style="text-align: right;">
                <asp:Label ID="Label2" Width="100px" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,Designation %>"></asp:Label>
            </td>
            <td style="text-align: left;">
              
                <asp:TextBox ID="txtDesignation" runat="server" CssClass="csstxtboxReadonly" Width="150px" style="margin-left:5px"   ></asp:TextBox>
              </td>
                  <td style="text-align: right;">
                <asp:Label ID="Label4" Width="100px" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,QuotationRefNo %>"></asp:Label>
            </td>
            <td style="text-align: left;">
              
                <asp:TextBox ID="txtQuotationNo" runat="server" CssClass="csstxtboxReadonly" Width="150px" style="margin-left:5px"   ></asp:TextBox>
             
              </td>
           
            </tr>
                    <tr>
                         <td style="text-align: right;">
                <asp:Label ID="Label8" Width="100px" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,CustomerName %>"></asp:Label>
            </td>
            <td style="text-align: left;">
                     <asp:TextBox ID="txtClientName" runat="server" CssClass="csstxtboxReadonly" Width="200px" style="margin-left:5px"  ></asp:TextBox>
                    </td>
                          <td style="text-align: right;">
                <asp:Label ID="Label3" Width="100px" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,Grade %>"></asp:Label>
            </td>
            <td style="text-align: left;">
                     <asp:TextBox ID="txtGrade" runat="server" CssClass="csstxtboxReadonly" Width="150px" style="margin-left:5px"  ></asp:TextBox>
                    </td>

                    </tr>
            
             </table>
         </div>
        <br />
        <div style="margin-left:10px" >

                        <table width="100%" cellspacing="0px" cellpadding="0px" style="border: solid 1px;">
                            <tr style="background-color: gray; color: white; height: 50px">
                                <td style="text-align: left; width: 400px">
                                    <asp:Label ID="lblCompanyCode" runat="server" Text="<%$ Resources:Resource,Description %>"></asp:Label>
                                </td>
                                <td style="text-align: left; width: 200px">
                                    <asp:Label ID="Label11" runat="server" Text="<%$ Resources:Resource,Percentage %>"></asp:Label>
                                </td>
                                <td style="text-align: right; width: 200px">
                                    <asp:Label ID="lblHeading" runat="server" ></asp:Label>
                                </td>
                            </tr>
                            <tr style="background-color: #585655; color: white; height: 30px">
                                <td style="text-align: left; width: 400px">
                                    <asp:Label ID="Label1" runat="server" Text="<%$ Resources:Resource,DutyDays %>"></asp:Label>
                                </td>
                                <td style="text-align: left; width: 200px"></td>
                                <td style="text-align: right; width: 200px">
                                    <asp:Label ID="lblDutyDays" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
        <div style="margin-left:10px" >
            <asp:Repeater ID="rptCosting" runat="server" OnItemDataBound="rptCosting_ItemDataBound">
                <HeaderTemplate>
                     </HeaderTemplate>
                <ItemTemplate>
                    <div id="div1" runat="server">
                        <table width="100%" cellspacing="0px" cellpadding="0px" style="border: solid 1px;">
                            <tr>
                                <asp:HiddenField ID="hfHeadType" runat="server" Value='<%# Eval("HeadCodeType") %>' />
                                <td style="text-align: left; width: 400px">
                                    <asp:Label ID="lblHeadcode" runat="server" Text='<%# Eval("HeadCodeDesc") %>' />
                                </td>
                                <td style="text-align: left; width: 200px">
                                    <asp:Label ID="lblValue" runat="server" Text='<%# Eval("HeadCodeValue") %>' />
                                </td>
                                <td style="text-align: right; width: 200px">
                                    <asp:Label ID="lblHeadCodeValue" runat="server" Text='<%# Eval("HeadCodeCalculatedValue") %>' />
                                </td>
                            </tr>
                        </table>
                    </div>
                </ItemTemplate>
                <FooterTemplate>
                </FooterTemplate>
            </asp:Repeater>
        </div>
  
    <br />
   
         
    <asp:HiddenField ID="hfComapnyCode" runat="server" />
    <asp:HiddenField ID="hfDesignation" runat="server" />
      <asp:HiddenField ID="hfGradeCode" runat="server" />
    <asp:HiddenField ID="hfState" runat="server" />
</asp:Content>


