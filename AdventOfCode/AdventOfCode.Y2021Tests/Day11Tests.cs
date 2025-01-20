using Xunit;
using AdventOfCode.Y2021;
using FluentAssertions;

namespace AdventOfCode.Y2021Tests;

public class Day11Tests
{
	private readonly string input = @"5483143223
2745854711
5264556173
6141336146
6357385478
4167524645
2176841721
6882881134
4846848554
5283751526";

	[Fact]
	public void Part1SouldMatchExampleCount()
	{
		var day = new Day11(input);

		var answer = day.Part1();

		answer.Should().Be("1656");
	}

	[Fact]
	public void Part2SouldMatchExampleCount()
	{
		var day = new Day11(input);

		var answer = day.Part2();

		answer.Should().Be("195");
	}
}
