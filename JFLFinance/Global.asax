<%@ Application Language="C#" %>
<script RunAt="server">

    void Application_BeginRequest(Object sender, EventArgs e)
    {
        string culture = null;
        if (HttpContext.Current.Request.Cookies["language"] != null)
        {
            HttpCookie httpCookie = Request.Cookies.Get("language");
            if (httpCookie != null) culture = httpCookie.Value;
        }
        else
        {
            culture = "en-US";
        }
        if (culture != null)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(culture);
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture(culture);
        }

        System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.Calendar = new System.Globalization.GregorianCalendar();
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator = ",";
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = ".";

        //CommonLibrary.Session.UserInformation uInfo = new CommonLibrary.Session.UserInformation();
        //uInfo.languageCode = culture;

    }
    void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on application startup

    }

    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown


    }
    // Loging unhandled error in application and redirect to Error page.    
    void Application_Error(object sender, EventArgs e)
    {
        // Code that runs when an unhandled error occurs

        ExceptionLog();
        //Server.Transfer("~/UserManagement/ErrorPage.aspx");



    }

    void Session_Start(object sender, EventArgs e)
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e)
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

        //HttpCookie myCookie = new HttpCookie("language");
        //myCookie.Expires = DateTime.Now.AddDays(-1d);
        //Response.Cookies.Add(myCookie);

    }


    /// <summary>
    /// To Make a Log Entry into Data Base if any Exception occurs 
    /// </summary>
    void ExceptionLog()
    {
        if (HttpContext.Current.Session != null)
        {
            var ds = new System.Data.DataSet();
            var objEx = new BL.ExceptionLogs();
            if (Server.GetLastError() != null && Server.GetLastError().InnerException != null)
            {
                objEx.ExceptionLog(Server.GetLastError().InnerException.ToString() + Environment.NewLine + "Stack Trace: " + Server.GetLastError().StackTrace, "System");
            }
            ds.Dispose();
        }
    }

    /// <summary>
    /// Fires on every request from the browser
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Application_AuthenticateRequest(object sender, EventArgs e)
    {
        // look if any security information exists for this request
        if (HttpContext.Current.User != null)
        {
            // see if this user is authenticated, any authenticated cookie (ticket) exists for this user
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                // see if the authentication is done using FormsAuthentication
                if (HttpContext.Current.User.Identity is FormsIdentity)
                {
                    // Get the roles stored for this request from the ticket
                    // get the identity of the user
                    var identity = (FormsIdentity)HttpContext.Current.User.Identity;
                    // get the forms authetication ticket of the user
                    FormsAuthenticationTicket ticket = identity.Ticket;
                    // get the roles stored as UserData into the ticket 
                    string[] roles = ticket.UserData.Split(',');
                    // create generic principal and assign it to the current request
                    HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(identity, roles);
                }
            }
        }
    }
       
</script>
