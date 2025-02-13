using Xunit;
using AdventOfCode.Y2024;
using FluentAssertions;

namespace AdventOfCode.Y2024Tests;

public class Day11Tests
{
	private readonly string input = @"125 17";

	[Fact]
	public void Part1ShouldMatchExampleCount()
	{
		var day = new Day11(input);

		var answer = day.Part1();

		answer.Should().Be("55312");
	}

	[Fact]
	public void Part2ShouldMatchExampleCount()
	{
		var day = new Day11(input);

		var answer = day.Part2();

		answer.Should().Be("65601038650482");
	}
}
