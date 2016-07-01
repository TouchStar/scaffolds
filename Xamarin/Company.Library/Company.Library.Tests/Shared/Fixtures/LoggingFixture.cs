// -----------------------------------------------------------------------------
// Copyright (C) Company Pty Ltd
// All Rights Reserved.
// 
// Notes:
//
// -----------------------------------------------------------------------------
using System;

//using log4net.Config;
//using log4net.Appender;

public class LoggingFixture : IDisposable
{
    static bool initialised = false;

    public LoggingFixture()
    {
        if (!initialised) { 
            //LogManager.Builder = new LoggerBuilder_log4net ();			
            initialised = true;
        }
    }

    public void Setup()
    {
#if !__MonoCS__ // Disable for VS.
        //Logger_log4net.DisableAppender("ConsoleAppender");
#endif
    }
    
    public void Dispose()
    {
    }
}

