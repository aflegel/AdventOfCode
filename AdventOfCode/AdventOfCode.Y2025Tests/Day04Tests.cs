using AdventOfCode.Y2025;
using FluentAssertions;
using Xunit;

namespace AdventOfCode.Y2025Tests;

public class Day04Tests
{
	private readonly string input = @"..@@.@@@@.
@@@.@.@.@@
@@@@@.@.@@
@.@@@@..@.
@@.@@@@.@@
.@@@@@@@.@
.@.@.@.@@@
@.@@@.@@@@
.@@@@@@@@.
@.@.@@@.@.";

	[Fact]
	public void Part1ShouldMatchExampleCount()
	{
		var day = new Day04(input);

		var answer = day.Part1();

		answer.Should().Be("13");
	}

	[Fact]
	public void Part2ShouldMatchExampleCount()
	{
		var day = new Day04(input);

		var answer = day.Part2();

		answer.Should().Be("43");
	}
}
