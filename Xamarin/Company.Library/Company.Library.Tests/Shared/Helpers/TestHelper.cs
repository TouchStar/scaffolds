using System;
using System.IO;

public class TestHelper
{
    public static string SharedTestDataFolder
	{
		get {
			string path = Directory.GetCurrentDirectory();
			return Path.GetFullPath(Path.Combine(path, @"..\..\..\..\Company.Library.Tests\Shared\Data\"));
		}
	}
}