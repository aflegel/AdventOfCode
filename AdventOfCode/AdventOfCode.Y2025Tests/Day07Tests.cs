using AdventOfCode.Core;
using AdventOfCode.Y2025;
using FluentAssertions;
using Xunit;

namespace AdventOfCode.Y2025Tests;

public class Day07Tests
{
	private readonly string input = @".......S.......
...............
.......^.......
...............
......^.^......
...............
.....^.^.^.....
...............
....^.^...^....
...............
...^.^...^.^...
...............
..^...^.....^..
...............
.^.^.^.^.^...^.
...............";

	[Fact]
	public void Part1ShouldMatchExampleCount()
	{
		var day = new Day07(input);

		var answer = day.Part1();

		answer.Should().Be("21");
	}

	[Fact]
	public void Part2ShouldMatchExampleCount()
	{
		var day = new Day07(input);

		var answer = day.Part2();

		answer.Should().Be("40");
	}
}
