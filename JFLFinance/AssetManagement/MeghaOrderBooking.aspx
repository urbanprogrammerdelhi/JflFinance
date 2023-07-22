<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="MeghaOrderBooking.aspx.cs" Inherits="AssetManagement_MeghaOrderBooking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <Ajax:UpdatePanel runat="server" ID="up2" UpdateMode="Conditional">
        <ContentTemplate>
          <table >
                <tr>
                    <td align="right">
                     <b>   <asp:Label ID="Label18" CssClass="cssLabel" runat="server" Text="Search Customer" style="font-size:xx-large;color:red;font-weight:800"></asp:Label></b>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label runat="server" ID="Label13" Text="Customer Id" CssClass="cssLabel" style="color:blue;font-size:large;font-weight:600"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtSearchMobile" runat="server" CssClass="csstxtbox" Width="200px" MaxLength="50"></asp:TextBox>
                    
                          
              
                    </td>
                    <td>
                  
                      </td>
                       </tr>
              <tr>
                   <td align="right"> 
                 <asp:Button ID="btnSearch" runat="server" CssClass="cssButton" OnClick="btnSearch_Click" Text="<%$ Resources:Resource, Search %>" CausesValidation="false" style="margin-left:10px"/></td>
                  <td>    <asp:Label ID="lblCustMsg" CssClass="cssLabel" runat="server" style="color:red;font-size:large;margin-left:10px;font-weight:600"></asp:Label></td>
              </tr>
            <br />
                 <tr>
                     <br />
                    <td align="right">
                     <b>   <asp:Label ID="Label17" CssClass="cssLabel" runat="server" Text="Customer Detail" style="font-size:xx-large;color:green;font-weight:800"></asp:Label></b>
                  
                
                    </td>
                </tr>
                <caption>
                    <br />
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label11" runat="server" CssClass="cssLabel" Text="Customer Name" style="color:blue;font-size:large;font-weight:600"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtName" runat="server" CssClass="csstxtbox" MaxLength="50" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfName" runat="server" ControlToValidate="txtName" ForeColor="red" SetFocusOnError="true">Please Enter Customer Name</asp:RequiredFieldValidator>
                          <%--  <asp:RegularExpressionValidator ID="revFirstname" runat="server" ControlToValidate="txtName" ErrorMessage="Please Enter Alphabets" ForeColor="Red" SetFocusOnError="true" ValidationExpression="^[a-zA-Z ]+$"></asp:RegularExpressionValidator>
                          --%>  </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label12" runat="server" CssClass="cssLabel" Text="Customer Address" style="color:blue;font-size:large;font-weight:600"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtAddress" runat="server" CssClass="csstxtbox" MaxLength="500" Width="200px" TextMode="MultiLine"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAddress" ForeColor="red" SetFocusOnError="true">Please Enter Customer Address</asp:RequiredFieldValidator>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label15" runat="server" CssClass="cssLabel" Text="Customer Mobile No." style="color:blue;font-size:large;font-weight:600"></asp:Label>
                        </td>
                        <td align="left">
                            
                            <asp:TextBox ID="txtMobile" runat="server" CssClass="csstxtbox" MaxLength="10" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtMobile" ForeColor="red" SetFocusOnError="true">Please Enter Customer Mobile No</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revPhone" runat="server" ControlToValidate="txtMobile" ErrorMessage="Please Enter Numeric Value" ForeColor="Red" SetFocusOnError="true" ValidationExpression="^[0-9]{10,15}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label14" runat="server" CssClass="cssLabel" Text="Query Type" style="color:blue;font-size:large;font-weight:600"></asp:Label>
                        </td>
                        <td align="left">
                        <asp:DropDownList ID="ddlQuerytype" runat="server" CssClass="cssDropDown" Width="200px">
                               <asp:ListItem Text="Breakdown" Value="Breakdown"></asp:ListItem>
                               <asp:ListItem Text="Quaterly Service" Value="Quaterly Service"></asp:ListItem>
                            <asp:ListItem Text="Enquiry" Value="Enquiry"></asp:ListItem>
                               <asp:ListItem Text="Service Request" Value="Service Request"></asp:ListItem>
                        </asp:DropDownList>   
                        </td>
                    </tr>
                    </caption>
                </caption>
                
               
            </table>
            
                   <br/>
                    <asp:Button ID="btnsubmit" runat="server" CssClass="cssButton" OnClick="btnsubmit_Click" style="margin-left:190px" Text="<%$ Resources:Resource, Submit %>" Width="150px"  />
            <br />
            <b>
                <br />
            <asp:Label ID="lblMsg" runat="server" style="font-size:large;color:red" Width="1000px"></asp:Label>
            </b>
                  
            <br>
            <br>
            <br></br>
            <br></br>
            </br>
                  
            </br/>

           </ContentTemplate>
    </Ajax:UpdatePanel>
</asp:Content>

