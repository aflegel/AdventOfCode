using Xunit;
using AdventOfCode.Y2021;
using FluentAssertions;

namespace AdventOfCode.Y2021Tests;

public class Day09Tests
{
	private readonly string input = @"2199943210
3987894921
9856789892
8767896789
9899965678";

	[Fact]
	public void Part1SouldMatchExampleCount()
	{
		var day = new Day09(input);

		var answer = day.Part1();

		answer.Should().Be("15");
	}

	[Fact]
	public void Part2SouldMatchExampleCount()
	{
		var day = new Day09(input);

		var answer = day.Part2();

		answer.Should().Be("1134");
	}
}
