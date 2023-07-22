<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="InstaOrderGeneration.aspx.cs" Inherits="Transactions_InstaOrderGeneration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <Ajax:UpdatePanel runat="server" ID="up2" UpdateMode="Conditional">
        <ContentTemplate>
          <table >
                <tr>
                    <td align="right">
                     <b>   <asp:Label ID="Label18" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, SearchCustomer %>" style="font-size:x-large;color:blue;font-weight:800"></asp:Label></b>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label runat="server" ID="Label13" Text="Enter Mobile No." CssClass="cssLabel"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtSearchMobile" runat="server" CssClass="csstxtbox" Width="200px" MaxLength="10"></asp:TextBox>
                         <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ValidationExpression="^[0-9]{10,15}$" ControlToValidate="txtSearchMobile" ErrorMessage="Please Enter Numeric Value" SetFocusOnError="true" ForeColor="Red"></asp:RegularExpressionValidator>
             <td align="left"> <asp:Button ID="btnSearch" runat="server" CssClass="cssButton" OnClick="btnSearch_Click" Text="<%$ Resources:Resource, Search %>" CausesValidation="false" style="margin-left:10px"/></td>
                    
              
                    </td>
                    <td>
                    <asp:Label ID="lblCustMsg" CssClass="cssLabel" runat="server" style="color:red;font-size:large;margin-left:10px"></asp:Label>
                      </td>
                       </tr>
              <tr>
                  
              </tr>
            
                 <tr>
                    <td align="right">
                     <b>   <asp:Label ID="Label17" CssClass="cssLabel" runat="server" Text="Customer Detail" style="font-size:x-large;color:blue;font-weight:800"></asp:Label></b>
                  
                
                    </td>
                </tr>
                <br />

                 <tr>
                    <td align="right">
                        <asp:Label ID="Label11" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, FirstName %>"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtFirstName" runat="server"  CssClass="csstxtbox" Width="200px" MaxLength="30"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="rfName" runat="server" ControlToValidate="txtFirstName" SetFocusOnError="true" ForeColor="red">Please Enter First Name</asp:RequiredFieldValidator>
               
                        <asp:RegularExpressionValidator ID="revFirstname" runat="server" ValidationExpression="^[a-zA-Z ]+$" ControlToValidate="txtFirstName" ErrorMessage="Please Enter Alphabets" SetFocusOnError="true" ForeColor="Red"></asp:RegularExpressionValidator></div>
                       </td>
                </tr>
                  <tr>
                    <td align="right">
                        <asp:Label ID="Label12" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, LastName %>"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtLastName" runat="server"  CssClass="csstxtbox" Width="200px" MaxLength="30"></asp:TextBox>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtLastName" SetFocusOnError="true" ForeColor="red">Please Enter Last Name</asp:RequiredFieldValidator>
                
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationExpression="^[a-zA-Z ]+$" ControlToValidate="txtLastName" ErrorMessage="Please Enter Alphabets" SetFocusOnError="true" ForeColor="Red"></asp:RegularExpressionValidator></div>
                      </td>
                </tr>
                 <tr>
                    <td align="right">
                        <asp:Label ID="Label15" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, Mobile %>"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:HiddenField ID="hfMobile" runat="server" Value="0" />
                        <asp:TextBox ID="txtMobile" runat="server"  CssClass="csstxtbox" Width="200px" MaxLength="10"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtMobile" SetFocusOnError="true" ForeColor="red">Please Enter Mobile No</asp:RequiredFieldValidator>
           
                        <asp:RegularExpressionValidator ID="revPhone" runat="server" ValidationExpression="^[0-9]{10,15}$" ControlToValidate="txtMobile" ErrorMessage="Please Enter Numeric Value" SetFocusOnError="true" ForeColor="Red"></asp:RegularExpressionValidator>
                
                    </td>
                </tr>
                 <tr>
                    <td align="right">
                        <asp:Label ID="Label14" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, EmailID %>"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtEmail" runat="server"  CssClass="csstxtbox" Width="200px" MaxLength="100"></asp:TextBox>
                         <asp:RegularExpressionValidator ID="revemail" runat="server" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail" ErrorMessage="Please Enter Valid EmailId" SetFocusOnError="true" ForeColor="Red"></asp:RegularExpressionValidator>
                
                    </td>
                </tr>


                 
                  <tr>
                    <td align="right">
                        <asp:Label ID="Label2" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, HouseNo %>"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtHouseNo" runat="server"  CssClass="csstxtbox" Width="200px" MaxLength="50"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtHouseNo" SetFocusOnError="true" ForeColor="red">Please Enter House No</asp:RequiredFieldValidator>
            
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label6" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, ISLocation %>"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtISLocation" runat="server"  CssClass="csstxtbox" Width="200px" MaxLength="100"></asp:TextBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtISLocation" SetFocusOnError="true" ForeColor="red">Please Enter Location</asp:RequiredFieldValidator>
            
                      
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label7" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, Landmark %>"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtLandmark" runat="server"  CssClass="csstxtbox" Width="200px" MaxLength="100"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtLandmark" SetFocusOnError="true" ForeColor="red">Please Enter Landmark</asp:RequiredFieldValidator>
            
                    </td>
                </tr>
                  <tr>
                  
                    <td align="right" style="min-width: 200px">
                        <asp:Label runat="server" ID="Label8" Text="<%$Resources:Resource,City %>" CssClass="cssLabel"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:DropDownList runat="server" ID="ddlCity" CssClass="cssDropDown" 
                            Width="200px" >
                         <asp:ListItem Text="Ghaziabad" Value="1" />
                              <asp:ListItem Text="Noida" Value="2" />
                          
                        </asp:DropDownList>
                    </td>
                    </tr>
                 <tr>
                    <td align="right">
                        <asp:Label ID="Label9" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, Pincode %>"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtPincode" runat="server"  CssClass="csstxtbox" Width="200px" MaxLength="6"></asp:TextBox>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtPincode" SetFocusOnError="true" ForeColor="red">Please Enter PinCode</asp:RequiredFieldValidator>
            
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ValidationExpression="^[0-9]{6}$" ControlToValidate="txtPincode" ErrorMessage="Please Enter Numeric Value" SetFocusOnError="true" ForeColor="Red"></asp:RegularExpressionValidator>
            
                
                    </td>
                </tr>
                  <tr>
                    <td align="right">
                     <b>   <asp:Label ID="Label16" CssClass="cssLabel" runat="server" Text="Service Detail" style="font-size:x-large;color:blue;;font-weight:800"></asp:Label></b>
                  
                
                    </td>
                </tr>
                <br />

                <tr>

                    <td align="right" style="min-width: 200px">
                        <asp:Label runat="server" ID="lblArea" Text="<%$Resources:Resource,SelectService %>" CssClass="cssLabel"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:DropDownList runat="server" ID="ddlservice" CssClass="cssDropDown" AutoPostBack="true"
                            Width="200px" OnSelectedIndexChanged="ddlservice_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    </tr>
                  <tr id="PlumbingSubservice" runat="server" visible="false">
                    <td align="right" style="min-width: 200px">
                        <asp:Label runat="server" ID="Label3" Text="<%$Resources:Resource,SelectPlumbingSubService %>" CssClass="cssLabel"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:DropDownList runat="server" ID="ddlPlumbingSubService" CssClass="cssDropDown" AutoPostBack="true"
                            Width="200px" OnSelectedIndexChanged="ddlPlumbingSubService_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    </tr>
                <tr>
                  
                    <td align="right" style="min-width: 200px">
                        <asp:Label runat="server" ID="Label4" Text="<%$Resources:Resource,SelectSubService %>" CssClass="cssLabel"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:DropDownList runat="server" ID="ddlSubService" CssClass="cssDropDown" AutoPostBack="true" OnSelectedIndexChanged="ddlSubService_SelectedIndexChanged"
                            Width="200px">
                        </asp:DropDownList>
                    </td>
                    </tr>
                 <tr>
                  
                    <td align="right" style="min-width: 200px">
                        <asp:Label runat="server" ID="Label5" Text="<%$Resources:Resource,Unit %>" CssClass="cssLabel"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:DropDownList runat="server" ID="ddlUnit" CssClass="cssDropDown" AutoPostBack="true"
                            Width="200px" OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged">
                         <asp:ListItem Text="1" Value="1" />
                              <asp:ListItem Text="2" Value="2" />
                              <asp:ListItem Text="3" Value="3" />
                              <asp:ListItem Text="4" Value="4" />
                              <asp:ListItem Text="5" Value="5" />
                        </asp:DropDownList>
                    </td>
                    </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblhdrClient" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, Rate %>"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtRate" runat="server" Enabled="false" CssClass="csstxtbox" Width="200px"></asp:TextBox>
                      
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblhdrAsmt" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, Date %>"></asp:Label>
                    </td>
                    <td align="left">
                       <asp:TextBox ID="txtDate" runat="server" Enabled="false" CssClass="csstxtbox" Width="200px" OnTextChanged="txtDate_TextChanged" AutoPostBack="true"></asp:TextBox>
                          <asp:HyperLink Style="vertical-align: top;" ID="HyperLink1" runat="server" Height="19px"
                            Width="20px" ImageUrl="../Images/pdate.gif"></asp:HyperLink>
                        <AjaxToolKit:CalendarExtender ID="CalendarExtender1" Format="dd-MMM-yyyy" runat="server" TargetControlID="txtDate"
                            PopupButtonID="HyperLink1" Enabled="True"></AjaxToolKit:CalendarExtender>
                    </td>
                    </tr>
                 <tr>
                    <td align="right">
                        <asp:Label ID="Label1" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, Time %>"></asp:Label>
                    </td>
                    <td align="left">
 <asp:RadioButtonList ID="rblTimeSlot" runat="server"  Width="500px" RepeatDirection="Horizontal"></asp:RadioButtonList>
                      
                    </td>
                </tr>
                
                <%--  <tr style="margin-left:2000px !important">
                    <td align="right" >
                     <b>   <asp:Label ID="Label11" style="font-size:x-large;color:blue;" runat="server" Text="<%$ Resources:Resource, NetPrice %>"></asp:Label> : </b>
                    </td>
                    <td align="left">
                      <b>  <asp:Label ID="Label12" runat="server"   Width="200px" style="font-size:x-large;color:blue;"></asp:Label></b>
                    </td>
                </tr>--%>
                
               
            </table>
            
                     <b>   <asp:Label ID="Label10" style="font-size:x-large;color:blueviolet;margin-left:190px" runat="server" Text="<%$ Resources:Resource, NetPrice %>"></asp:Label> : </b>
                   
                      <b>  <asp:Label ID="lblPrice" runat="server"   Width="200px" style="font-size:x-large;color:blueviolet;"></asp:Label></b>
            <br/>
                    <asp:Button ID="btnsubmit" runat="server" CssClass="cssButton" OnClick="btnsubmit_Click" style="margin-left:190px" Text="<%$ Resources:Resource, Submit %>" Width="150px" />
            <br />
            <b>
                <br />
            <asp:Label ID="lblMsg" runat="server" style="font-size:large;color:red" Width="1000px"></asp:Label>
            </b>
                  
            </br/>

           </ContentTemplate>
    </Ajax:UpdatePanel>
</asp:Content>

