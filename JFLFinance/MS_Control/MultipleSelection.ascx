<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MultipleSelection.ascx.cs" Inherits="MultipleSelection" %>
<%@ Register Assembly="CheckBoxListExCtrl" Namespace="CheckBoxListExCtrl" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>

<div>
            <cc2:HoverMenuExtender ID="HoverMenuExtender1"
                         runat="server" 
                         TargetControlID="MultiSelectDDL" 
                         PopupControlID="PanelPopUp" 
                         PopupPosition="bottom" 
                         OffsetX="0"  
                         PopDelay="25" HoverCssClass="popupHover" >
            </cc2:HoverMenuExtender>      

           <asp:DropDownList ID="MultiSelectDDL" CssClass="ddlMenu regularText" runat="server">
                <asp:ListItem Value="all">Select</asp:ListItem>  
            </asp:DropDownList>
                 
            <asp:Panel ID="PanelPopUp"  CssClass="popupMenu" runat="server" style=""   >
             <cc1:CheckBoxListExCtrl ID="CheckBoxListExCtrl1" CssClass="regularText"  runat="server" >
                    <%--<asp:ListItem Value="d1">Dummy 1</asp:ListItem>
                    <asp:ListItem Value="d2">Dummy 2</asp:ListItem>
                    <asp:ListItem Value="d3">Dummy 3</asp:ListItem>
                    <asp:ListItem Value="d4">Dummy 4</asp:ListItem>
                    <asp:ListItem Value="d5">Dummy 5</asp:ListItem>
                    <asp:ListItem Value="d6">Dummy 6</asp:ListItem>
                    <asp:ListItem Value="d7">Dummy 7</asp:ListItem>
                    <asp:ListItem Value="d8">Dummy 8</asp:ListItem>--%>
            </cc1:CheckBoxListExCtrl>
            </asp:Panel>
            <asp:HiddenField ID="hf_checkBoxValue" runat="server" />
            <asp:HiddenField ID="hf_checkBoxText" runat="server" />
            <asp:HiddenField ID="hf_checkBoxSelIndex" runat="server" />
        </div>   
<div id="ie6SelectTooltip" style="display:none;position:absolute;padding:1px;border:1px solid #333333;background-color:#fffedf;font-size:smaller;z-index: 99;"></div>
