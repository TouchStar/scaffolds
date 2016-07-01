// -----------------------------------------------------------------------------
// Copyright (C) Company Pty Ltd
// All Rights Reserved.
// 
// Notes:
//
// -----------------------------------------------------------------------------
using System;
using System.Diagnostics;

using Xunit;
using Xunit.Abstractions;
using NUnit.Framework;
using Assert=Xunit.Assert;
using System.IO;
using System.Text;
using System.Threading;

#if _ANDROID_
using Android.App;
#endif

#if !__MonoCS__ // Dummy TestAttribute to disable nunit under visual studio.
class TestAttribute : Attribute { }
#endif

#if !AUTOBUILD
public class _Playground_ : IClassFixture<LoggingFixture>
{
	private ITestOutputHelper Output { get; set; }

#if __MonoCS__ && !__MOBILE__
	[SetUp]
	public void Setup ()
	{
		var fixture = new LoggingFixture ();
		fixture.Setup();
	}
	public _Playground_() { Output = new ConsoleOutputter(); }
#endif        
    public _Playground_(ITestOutputHelper output, LoggingFixture fixture) {
        this.Output = output;
		fixture.Setup();
	}

    [Fact][Test]
    public void BuildInfo()
    {
        Output.WriteLine("BuildMachine:  " + Company.Library.Build.Info.BuildMachine);
        Output.WriteLine("BuildDate:     " + Company.Library.Build.Info.BuildDate);
        Output.WriteLine("BuildNumber:   " + Company.Library.Build.Info.BuildNumber);

        Output.WriteLine("RepoRevision:  " + Company.Library.Build.Info.RepoRevision);
        Output.WriteLine("RepoGitCommit: " + Company.Library.Build.Info.RepoGitCommit);
        Output.WriteLine("RepoBranch:    " + Company.Library.Build.Info.RepoBranch);
        Output.WriteLine("RepoTag:       " + Company.Library.Build.Info.RepoTag);
    }
}
#endif
