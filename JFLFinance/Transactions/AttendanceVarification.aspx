<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AttendanceVarification.aspx.cs"
    Inherits="Transactions_AttendanceVarification" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../css/WRStyleSheet.css" />
    <link rel="stylesheet" type="text/css" href="../css/WRGridView.css" />
</head>
<body onload="HideDivs();">
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="RadScriptManager1" ScriptMode="Release" runat="server">
        </asp:ScriptManager>
        <Ajax:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" margin="0">
            <ContentTemplate>
                <table>
                    <tr>
                        <td>
                            <asp:LinkButton ID="lblStep1" runat="server" Text="Attendance Verification and Process"
                                CssClass="csslnkButton" Style="background-color: #c3c3c3"></asp:LinkButton>
                            <br />
                            <asp:Image ImageUrl="~/Images/spacer.gif" ID="spacer" Height="8px" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblBRSelection" Text="Select Paysum" runat="server" CssClass="cssLabel"></asp:Label>
                                    </td>
                                    <td colspan="3">
                                        <asp:DropDownList ID="ddlBR" runat="server" Width="300px" AutoPostBack="true" onchange="HideDivs();"
                                            OnSelectedIndexChanged="ddlBR_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblPeriod" Text="<%$ Resources:Resource, Period %>" runat="server"
                                            CssClass="cssLabel"></asp:Label>
                                    </td>
                                    <td colspan="3">
                                        <asp:DropDownList ID="ddlPeriodCollection" runat="server" Width="180px" Height="22px"
                                            onchange="HideDivs();" AutoPostBack="true" OnSelectedIndexChanged="ddlPeriodCollection_SelectedIndexChanged"
                                            CssClass="cssDropDown">
                                        </asp:DropDownList>
                                        <asp:HiddenField ID="FromDate" runat="server" />
                                        <asp:HiddenField ID="ToDate" runat="server" />
                                        <asp:HiddenField ID="PaysumProcessStatus" runat="server" />
                                        <asp:HiddenField ID="RotaAuthorizeStatus" runat="server" />
                                        <asp:Button ID="btnRefreshPeriod" runat="server" Text="RefreshPeriods" OnClick="btnRefreshPeriod_Click"
                                            Style="display: none" />
                                        <input type="submit" value="Start Paysum Readyness Process" cssclass="cssButton"
                                            id="trigger" onclick="BeginProcess('PRP'); return false;" />
                                        <asp:LinkButton ID="btnAddPeriodCollection" runat="server" CssClass="csslnkButton"
                                            Text="Add Period Collection" Visible="false" OnClick="btnAddPeriodCollection_Click"></asp:LinkButton>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:Label ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </Ajax:UpdatePanel>
        <table>
            <tr>
                <td>
                    <div id="ActiveProcess" runat="server" style="height: 20px" class="csslblInfoMsg">
                    </div>
                    <div id="nextProcesses" runat="server" style="display: block">
                        <a style="text-decoration: underline; cursor: pointer" onclick="BeginProcess('AU'); return false;">
                            Authorize Rota</a> &nbsp; <a style="text-decoration: underline; cursor: pointer"
                                onclick="BeginProcess('PR'); return false;">Process Rota</a> &nbsp; <a style="text-decoration: underline;
                                    cursor: pointer" onclick="BeginProcess('VP'); return false;">View Paysum</a>&nbsp;
                        <a style="text-decoration: underline; cursor: pointer" onclick="BeginProcess('SPP'); return false;">
                            Send Paysum to Payroll</a>&nbsp;
                        <img alt="" id="loadingFrame" src="../Images/spinner.gif" style="display: none" />
                        <asp:LinkButton ID="lbtnProcessRota" runat="server" CssClass="csslnkButton" Text="Process Rota"
                            OnClick="lbtnProcessRota_Click"></asp:LinkButton>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    </form>
    <script type="text/javascript" language="javascript" src="../PageJS/AttendanceVerfication.js"></script>
    <script language="javascript" type="text/javascript">
        function ControlInitializer() {
            this.ddlBR = document.getElementById('<%=ddlBR.ClientID %>');
            this.RotaAuthorizeStatus = document.getElementById('<%=RotaAuthorizeStatus.ClientID %>');
            this.PaysumProcessStatus = document.getElementById('<%=PaysumProcessStatus.ClientID %>');
            this.FromDate = document.getElementById('<%=FromDate.ClientID %>');
            this.ToDate = document.getElementById('<%=ToDate.ClientID %>');
            this.ActiveProcess = document.getElementById('<%=ActiveProcess.ClientID %>');
            this.nextProcesses = document.getElementById('<%=nextProcesses.ClientID %>');
            this.form1 = document.getElementById('<%=form1.ClientID %>');
            this.loadingFrame = document.getElementById('loadingFrame');
            this.btnRefreshPeriod = document.getElementById('<%=btnRefreshPeriod.ClientID %>');
        } 
    </script>
    <%--<script language="javascript" type="text/javascript">
        function HideDivs() {
            document.getElementById('nextProcesses').style.display = "none";
        }

        var iframe;
        function BeginProcess(param) {
            // Create an iframe.

            if (document.getElementById("iframe1") == null) {
                iframe = document.createElement("iframe");
                iframe.id = "iframe1";
            }
            else {
                iframe = document.getElementById("iframe1");
            }

            iframe.style.display = "block";

            //  var iframe = document.getElementById("iframe1");

            // Point the iframe to the location of
            //  the long running process.
            // PRP - paysum readinessprocess
            // PR - Process Rota
            // SPP - send paysum to payroll
            // VP - view payroll


            if (document.getElementById('<%=ddlBR.ClientID %>').value) {
                if (param == "PRP" || param == "PR" || param == "SPP") {
                    if (param == "PR" && document.getElementById('<%=RotaAuthorizeStatus.ClientID %>').value.toUpperCase() == "TRUE") {
                        alert('locked');
                        return;
                    }
                    else if (param == "PRP" && document.getElementById('<%=RotaAuthorizeStatus.ClientID %>').value.toUpperCase() == "TRUE") {
                        document.getElementById('nextProcesses').style.display = "block";
                        return;
                    }
                    else if (param == "SPP" && document.getElementById('<%=PaysumProcessStatus.ClientID %>').value.toUpperCase() == "TRUE") {
                        alert('locked');
                        return;
                    }
                    else if (param == "SPP" && document.getElementById('<%=RotaAuthorizeStatus.ClientID %>').value.toUpperCase() != "TRUE") {
                        alert('paysum is not ready');
                        return;
                    }
                    iframeLoading();
                    iframe.src = "AttendanceVarificationProcesses.aspx?ptype=" + param + "&BR=" + document.getElementById('<%=ddlBR.ClientID %>').value + "&fdate=" + document.getElementById('<%=FromDate.ClientID %>').value + "&tdate=" + document.getElementById('<%=ToDate.ClientID %>').value;
                    iframe.onload = function () {
                        iframeLoadingComplete(param);
                    };
                }
                else if (param == "AU") {
                    iframe.src = "RotaAuthorize.aspx";

                }
                else if (param == "VP") {
                    iframeLoading();
                    iframe.src = "Paysum_ISR.aspx?BR=" + document.getElementById('<%=ddlBR.ClientID %>').value + "&fdate=" + document.getElementById('<%=FromDate.ClientID %>').value + "&tdate=" + document.getElementById('<%=ToDate.ClientID %>').value;
                    iframe.onload = function () {
                        iframeLoadingComplete(param);
                    };
                }
                iframe.style.width = "1000px";
                iframe.style.height = "350px";
                iframe.style.borderStyle = "none";
                iframe.style.frameBorder = "none";

            }
            else {
                // business rule not selected
            }

            // Add the iframe to the DOM.  The process
            //  will begin execution at this point.
            document.body.appendChild(iframe);

        }


        function UpdateProgress(PercentComplete, Message) {


            try {
                if (PercentComplete == 0) {

                    document.getElementById('ActiveProcess').innerText = Message;
                }

                if (PercentComplete == 1) {
                    document.getElementById('ActiveProcess').innerText = Message;
                    document.getElementById('nextProcesses').style.display = "block";
                }
                if (PercentComplete == 10000) {
                    document.getElementById('nextProcesses').style.display = "block";
                    document.getElementById('ActiveProcess').innerText = Message;
                    iframe.style.display = "none";
                }
            }
            catch (error) { }


        }

        function iframeLoadingComplete(param) {
            document.getElementById('loadingFrame').style.display = "none";

            //// refresh periods colour
            if (param == 'PR' || param == 'SPP') {
                document.getElementById('<%=
                .ClientID %>').click(document.getElementById('<%=btnRefreshPeriod.ClientID %>'));
            }

        }
        function iframeLoading() {
            document.getElementById('loadingFrame').style.display = "block";

        }
    
    </script>--%>
</body>
</html>
