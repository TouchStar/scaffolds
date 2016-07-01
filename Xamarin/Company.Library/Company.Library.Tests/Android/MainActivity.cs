// -----------------------------------------------------------------------------
// Copyright (C) Company Pty Ltd
// All Rights Reserved.
// 
// Notes:
//
// -----------------------------------------------------------------------------
using System.Reflection;
using Android.App;
using Android.OS;
using Xunit.Runners.UI;
using Android.Content.PM;

namespace Company.Library.Android
{    	
	[Activity(Label = "Company.Library xUnit Runner", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : RunnerActivity
    {
        public static MainActivity TestActivity = null;

        protected override void OnCreate(Bundle bundle)
        {
			AddTestAssembly(Assembly.GetExecutingAssembly());

			//LoggerBuilder_log4net.ConfigureFromXMLFile("log4netconfig.xml");

			Runner.MainActivity = this;
            TestActivity = this;

            base.OnCreate(bundle);
        }
    }
}

