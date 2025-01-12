using Xunit;
using AdventOfCode.Y2024;
using FluentAssertions;

namespace AdventOfCode.Y2024Tests;

public class Day21Tests
{
	private readonly string input = @"029A
980A
179A
456A
379A".ReplaceLineEndings("\n");

	[Fact]
	public void Part1ShouldMatchExampleCount()
	{
		var day = new Day21(input);

		var answer = day.Part1();

		answer.Should().Be("126384");
	}

	[Fact]
	public void Part2ShouldMatchExampleCount()
	{
		var day = new Day21(input);

		var answer = day.Part2();

		answer.Should().Be("0");
	}
}
