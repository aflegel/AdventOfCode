using Xunit;
using AdventOfCode.Y2024;
using FluentAssertions;

namespace AdventOfCode.Y2024Tests;

public class Day06Tests
{
	private readonly string input = @"....#.....
.........#
..........
..#.......
.......#..
..........
.#..^.....
........#.
#.........
......#...";

	[Fact]
	public void Part1ShouldMatchExampleCount()
	{
		var day = new Day06(input);

		var answer = day.Part1();

		answer.Should().Be("41");
	}

	[Fact]
	public void Part2ShouldMatchExampleCount()
	{
		var day = new Day06(input);

		var answer = day.Part2();

		answer.Should().Be("6");
	}
}
