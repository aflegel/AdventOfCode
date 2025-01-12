using System.CommandLine;
using System.CommandLine.Invocation;

namespace AdventOfCode.Cli;

public static class FluentCommandExtensions
{
	public static RootCommand WithAlias(this RootCommand command, string alias)
	{
		command.HasAlias(alias);
		return command;
	}

	public static RootCommand WithArgument(this RootCommand command, Argument argument)
	{
		command.AddArgument(argument);
		return command;
	}

	public static RootCommand WithOption(this RootCommand command, Option option)
	{
		command.AddOption(option);
		return command;
	}
}
