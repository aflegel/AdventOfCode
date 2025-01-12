using System.CommandLine;
using System.CommandLine.NamingConventionBinder;

namespace AdventOfCode.Cli;

public static class FluentHandlerExtensions
{
	public static RootCommand WithHandler(this RootCommand command, Action action)
	{
		command.Handler = CommandHandler.Create(action);
		return command;
	}

	public static RootCommand WithHandler<T>(this RootCommand command, Action<T> action)
	{
		command.Handler = CommandHandler.Create(action);
		return command;
	}

	public static RootCommand WithHandler<T1, T2>(this RootCommand command, Action<T1, T2> action)
	{
		command.Handler = CommandHandler.Create(action);
		return command;
	}

	public static RootCommand WithHandler<T1, T2, T3>(this RootCommand command, Action<T1, T2, T3> action)
	{
		command.Handler = CommandHandler.Create(action);
		return command;
	}

	public static RootCommand WithHandler<T1, T2, T3, T4>(this RootCommand command, Action<T1, T2, T3, T4> action)
	{
		command.Handler = CommandHandler.Create(action);
		return command;
	}

	public static RootCommand WithHandler<T1, T2, T3, T4, T5>(this RootCommand command, Action<T1, T2, T3, T4, T5> action)
	{
		command.Handler = CommandHandler.Create(action);
		return command;
	}

	public static RootCommand WithHandler<T1, T2, T3, T4, T5, T6>(this RootCommand command, Action<T1, T2, T3, T4, T5, T6> action)
	{
		command.Handler = CommandHandler.Create(action);
		return command;
	}

	public static RootCommand WithHandler<T1, T2, T3, T4, T5, T6, T7>(this RootCommand command, Action<T1, T2, T3, T4, T5, T6, T7> action)
	{
		command.Handler = CommandHandler.Create(action);
		return command;
	}

	public static RootCommand WithHandler<T1, T2, T3, T4, T5, T6, T7, T8>(this RootCommand command, Action<T1, T2, T3, T4, T5, T6, T7, T8> action)
	{
		command.Handler = CommandHandler.Create(action);
		return command;
	}

	public static RootCommand WithHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this RootCommand command, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action)
	{
		command.Handler = CommandHandler.Create(action);
		return command;
	}

	public static RootCommand WithHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this RootCommand command, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action)
	{
		command.Handler = CommandHandler.Create(action);
		return command;
	}

	public static RootCommand WithHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this RootCommand command, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action)
	{
		command.Handler = CommandHandler.Create(action);
		return command;
	}

	public static RootCommand WithHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this RootCommand command, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action)
	{
		command.Handler = CommandHandler.Create(action);
		return command;
	}

	public static RootCommand WithHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this RootCommand command, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action)
	{
		command.Handler = CommandHandler.Create(action);
		return command;
	}

	public static RootCommand WithHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this RootCommand command, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action)
	{
		command.Handler = CommandHandler.Create(action);
		return command;
	}

	public static RootCommand WithHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this RootCommand command, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action)
	{
		command.Handler = CommandHandler.Create(action);
		return command;
	}

	public static RootCommand WithHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this RootCommand command, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> action)
	{
		command.Handler = CommandHandler.Create(action);
		return command;
	}
}
