﻿<%@ Application Language="C#" %>

<script runat="server">
    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup
        // if there is a database bound, check to make sure it has the proper tables
        if (CurrentEnvironment.hasDbConnection)
        {
            CurrentEnvironment.CheckDBstructure();
            
        }
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    {
        Exception lastError = Server.GetLastError();
        Console.WriteLine("Unhandled exception: " + lastError.Message + lastError.StackTrace);
        CurrentEnvironment.KillApp();

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

    }
       
</script>
