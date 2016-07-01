using System;

using Xunit.Abstractions;

public class ConsoleOutputter : ITestOutputHelper
{
	public void WriteLine (string message)
	{
		Console.WriteLine(message);
	}

	public void WriteLine (string format, params object[] args)
	{
		Console.WriteLine(format, args);
	}
}

