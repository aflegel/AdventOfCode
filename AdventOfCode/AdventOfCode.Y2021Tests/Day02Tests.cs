using Xunit;
using AdventOfCode.Y2021;
using FluentAssertions;

namespace AdventOfCode.Y2021Tests;

public class Day02Tests
{
	private readonly string input = @"forward 5
down 5
forward 8
up 3
down 8
forward 2";

	[Fact]
	public void Part1SouldMatchExampleCount()
	{
		var day = new Day02(input);

		var answer = day.Part1();

		answer.Should().Be("150");
	}

	[Fact]
	public void Part2SouldMatchExampleCount()
	{
		var day = new Day02(input);

		var answer = day.Part2();

		answer.Should().Be("900");
	}
}
