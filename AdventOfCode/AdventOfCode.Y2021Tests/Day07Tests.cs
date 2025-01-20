using Xunit;
using AdventOfCode.Y2021;
using FluentAssertions;

namespace AdventOfCode.Y2021Tests;

public class Day07Tests
{
	private readonly string input = @"16,1,2,0,4,2,7,1,2,14";

	[Fact]
	public void Part1SouldMatchExampleCount()
	{
		var day = new Day07(input);

		var answer = day.Part1();

		answer.Should().Be("37");
	}

	[Fact]
	public void Part2SouldMatchExampleCount()
	{
		var day = new Day07(input);

		var answer = day.Part2();

		answer.Should().Be("168");
	}
}
