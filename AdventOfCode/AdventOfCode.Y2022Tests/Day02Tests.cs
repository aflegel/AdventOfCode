using AdventOfCode.Y2022;
using FluentAssertions;
using Xunit;

namespace AdventOfCode.Y2022Tests;

public class Day02Tests
{
	private readonly string input = @"A Y
B X
C Z";

	[Fact]
	public void Part1ShouldMatchExampleCount()
	{
		var day = new Day02(input);

		var answer = day.Part1();

		answer.Should().Be("15");
	}

	[Fact]
	public void Part2ShouldMatchExampleCount()
	{
		var day = new Day02(input);

		var answer = day.Part2();

		answer.Should().Be("12");
	}
}
