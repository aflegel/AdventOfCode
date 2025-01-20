using Xunit;
using AdventOfCode.Y2021;
using FluentAssertions;

namespace AdventOfCode.Y2021Tests;

public class Day17Tests
{
	private readonly string input = @"target area: x=20..30, y=-10..-5";

	[Fact]
	public void Part1SouldMatchExampleCountA()
	{
		var day = new Day17(input);

		var answer = day.Part1();

		answer.Should().Be("45");
	}

	[Fact]
	public void Part2SouldMatchExampleCountH()
	{
		var day = new Day17(input);

		var answer = day.Part2();

		answer.Should().Be("112");
	}
}
