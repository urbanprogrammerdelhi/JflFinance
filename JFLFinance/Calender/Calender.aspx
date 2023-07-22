<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Calender.aspx.cs" Inherits="Calender" Title="<%$ Resources:Resource, AppTitle %>" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server"></head>
	<body>
		<form id="Form1" method="post" runat="server">
			<table style="height:220px;" cellspacing="0" cellpadding="0" width="100%" border="0">
				<tr style="height:20px">
				<td style="vertical-align:middle;background-color:Gray;" align="center">
								<asp:dropdownlist id="CboMonth" runat="server" Width="100px" CssClass="cssDropDown" AutoPostBack="True" onselectedindexchanged="CboMonth_SelectedIndexChanged">
										<asp:ListItem Value="1">Jan</asp:ListItem>
										<asp:ListItem Value="2">Feb</asp:ListItem>
										<asp:ListItem Value="3">Mar</asp:ListItem>
										<asp:ListItem Value="4">Apr</asp:ListItem>
										<asp:ListItem Value="5">May</asp:ListItem>
										<asp:ListItem Value="6">Jun</asp:ListItem>
										<asp:ListItem Value="7">Jul</asp:ListItem>
										<asp:ListItem Value="8">Aug</asp:ListItem>
										<asp:ListItem Value="9">Sep</asp:ListItem>
										<asp:ListItem Value="10">Oct</asp:ListItem>
										<asp:ListItem Value="11">Nov</asp:ListItem>
										<asp:ListItem Value="12">Dec</asp:ListItem>
									</asp:dropdownlist>&nbsp;
									<asp:dropdownlist id="CboYear" runat="server" Width="70px" CssClass="cssDropDown" AutoPostBack="True" onselectedindexchanged="CboYear_SelectedIndexChanged"></asp:dropdownlist>&nbsp;
				</td>
				</tr>
				
				<tr style="height:170px;">
					<td style="vertical-align:top;" align="center">
					        <asp:calendar id="CdrDatePicker" runat="server" ToolTip="Select Date" Width="220px" CssClass="cssDatePickerBase"
							ShowNextPrevMonth="true" FirstDayOfWeek="Sunday" NextMonthText=" " PrevMonthText=" " Height="180px" 
							DayNameFormat="Shortest" 
							onselectionchanged="CdrDatePicker_SelectionChanged" BackColor="White" BorderColor="#999999" 
							CellPadding="4" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" NextPrevFormat="ShortMonth" OnVisibleMonthChanged="CdrDatePicker_VisibleMonthChanged">
							<TodayDayStyle CssClass="cssDatePickerToday" BackColor="#CCCCCC" ForeColor="Black"></TodayDayStyle>
							<SelectorStyle CssClass="cssDatePickerSelector" BackColor="#CCCCCC"></SelectorStyle>
							<DayStyle CssClass="cssDatePickerDay"></DayStyle>
							<NextPrevStyle CssClass="cssDatePickerNextPrev" VerticalAlign="Bottom"></NextPrevStyle>
							<DayHeaderStyle Font-Bold="True" CssClass="cssDatePickerDayHeader" BackColor="#CCCCCC" Font-Size="7pt"></DayHeaderStyle>
							<SelectedDayStyle CssClass="cssDatePickerSelectedDay" BackColor="#666666" Font-Bold="True" ForeColor="White"></SelectedDayStyle>
							<TitleStyle CssClass="cssDatePickerTitle" BackColor="gray" BorderColor="Black" Font-Bold="True"></TitleStyle>
							<WeekendDayStyle CssClass="cssDatePickerWeekend" BackColor="#E0E0E0"></WeekendDayStyle>
							<OtherMonthDayStyle CssClass="cssDatePickerOtherMonthDay" ForeColor="#c9c9c9"></OtherMonthDayStyle>
						</asp:calendar>
				    </td>
				</tr>
				<tr style="height:1px;">
					<td>
						<table id="TblTimeControl" style="height:100%" cellspacing="0" cellpadding="0" width="100%" border="0" runat="server">
							<tr>
								<td style="vertical-align:middle;" align="center">
									<asp:LinkButton ID="hlSelectDate" Runat="server" CssClass="Hover" Font-Underline="True" onclick="hlSelectDate_Click"></asp:LinkButton>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</html>

