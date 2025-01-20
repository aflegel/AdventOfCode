using Xunit;
using AdventOfCode.Y2021;
using FluentAssertions;

namespace AdventOfCode.Y2021Tests;

public class Day06Tests
{
	private readonly string input = @"3,4,3,1,2";

	[Fact]
	public void Part1SouldMatchExampleCount()
	{
		var day = new Day06(input);

		var answer = day.Part1();

		answer.Should().Be("5934");
	}

	[Fact]
	public void Part2SouldMatchExampleCount()
	{
		var day = new Day06(input);

		var answer = day.Part2();

		answer.Should().Be("26984457539");
	}
}
