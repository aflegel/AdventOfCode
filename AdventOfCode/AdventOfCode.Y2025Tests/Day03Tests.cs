using AdventOfCode.Y2025;
using FluentAssertions;
using Xunit;

namespace AdventOfCode.Y2025Tests;

public class Day03Tests
{
	private readonly string input = @"987654321111111
811111111111119
234234234234278
818181911112111";

	[Fact]
	public void Part1ShouldMatchExampleCount()
	{
		var day = new Day03(input);

		var answer = day.Part1();

		answer.Should().Be("357");
	}

	[Fact]
	public void Part2ShouldMatchExampleCount()
	{
		var day = new Day03(input);

		var answer = day.Part2();

		answer.Should().Be("3121910778619");
	}
}
