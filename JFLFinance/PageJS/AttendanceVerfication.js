
function HideDivs() {
    var a = new ControlInitializer();
    a.nextProcesses.style.display = "none";

}

function BeginProcess(param) {
    // Create an iframe.
    var a = new ControlInitializer();
    var iframe;
    if (document.getElementById("iframe1") === null) {
        iframe = document.createElement("iframe");
        iframe.id = "iframe1";
    }
    else {
        iframe = document.getElementById("iframe1");
    }
    iframe.style.display = "block";

    // Point the iframe to the location of the long running process. PRP - paysum readinessprocess, PR - Process Rota, SPP - send paysum to payroll, VP - view payroll

    if (a.ddlBR.value !== "") {
        if (param === "PRP" || param === "PR" || param === "SPP") {
            if (param === "PR" && a.RotaAuthorizeStatus.value.toUpperCase() === "TRUE") {
                alert('locked');
                return;
            }
            else if (param == "PRP" && a.RotaAuthorizeStatus.value.toUpperCase() == "TRUE") {
                a.nextProcesses.style.display = "block";
                return;
            }
            else if (param == "SPP" && a.PaysumProcessStatus.value.toUpperCase() == "TRUE") {
                alert('locked');
                return;
            }
            else if (param == "SPP" && a.RotaAuthorizeStatus.value.toUpperCase() != "TRUE") {
                alert('paysum is not ready');
                return;
            }
            
            iframeLoading();
            iframe.src = "AttendanceVarificationProcesses.aspx?ptype=" + param + "&BR=" + a.ddlBR.value + "&fdate=" + a.FromDate.value + "&tdate=" + a.ToDate.value;


            if (iframe.attachEvent) {
                iframe.attachEvent("onload", function () {
                    iframeLoadingComplete(param);
                });
            } else {
                iframe.onload = function () {
                    iframeLoadingComplete(param);
                };
            }
            
//            iframe.onload = function () {
//                iframeLoadingComplete(param);
//            };
            if (param === "PR") {
                iframe.style.display = "none";
            }
        }
        else if (param == "AU") {
            iframe.src = "RotaAuthorize.aspx";
        }
        else if (param == "VP") {
            iframeLoading();
            iframe.src = "Paysum_ISR.aspx?BR=" + a.ddlBR.value + "&fdate=" + a.FromDate.value + "&tdate=" + a.ToDate.value;

            if (iframe.attachEvent) {
                iframe.attachEvent("onload", function () {
                    iframeLoadingComplete(param);
                });
            } else {
                iframe.onload = function () {
                    iframeLoadingComplete(param);
                };
            }
//            iframe.onload = function () {
//                iframeLoadingComplete(param);
//            };
        }
        iframe.style.width = "1000px";
        iframe.style.height = "350px";
        iframe.style.borderStyle = "none";
        iframe.style.frameBorder = "none";       
    }
    // Add the iframe to the DOM.  The process
    //  will begin execution at this point.
    document.body.appendChild(iframe);
}

function UpdateProgress(PercentComplete, Message) {
    var a = new ControlInitializer();
    try {
        if (PercentComplete === 0) {

            a.ActiveProcess.innerText = Message;
        }

        if (PercentComplete == 1) {
            a.ActiveProcess.innerText.innerText = Message;
            a.nextProcesses.style.display = "block";
        }
        if (PercentComplete == 10000) {
            a.nextProcesses.style.display = "block";
            a.ActiveProcess.innerText = Message;
            iframe.style.display = "none";
        }
    }
    catch (error) { }
}

function iframeLoadingComplete(param) {
    var a = new ControlInitializer();
    a.loadingFrame.style.display = "none";
    //// refresh periods colour
    if (param == 'PR' || param == 'SPP') {
        a.btnRefreshPeriod.click(a.btnRefreshPeriod);
    }

}

function iframeLoading() {
    var a = new ControlInitializer();
    a.loadingFrame.style.display = "block";
}