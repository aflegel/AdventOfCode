using AdventOfCode.Y2025;
using FluentAssertions;
using Xunit;

namespace AdventOfCode.Y2025Tests;

public class Day05Tests
{
	private readonly string input = @"3-5
10-14
16-20
12-18

1
5
8
11
17
32";

	[Fact]
	public void Part1ShouldMatchExampleCount()
	{
		var day = new Day05(input);

		var answer = day.Part1();

		answer.Should().Be("3");
	}

	[Fact]
	public void Part2ShouldMatchExampleCount()
	{
		var day = new Day05(input);

		var answer = day.Part2();

		answer.Should().Be("14");
	}
}
