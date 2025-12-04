using AdventOfCode.Y2022;
using FluentAssertions;
using Xunit;

namespace AdventOfCode.Y2022Tests;

public class Day01Tests
{
	private readonly string input = @"1000
2000
3000

4000

5000
6000

7000
8000
9000

10000";

	[Fact]
	public void Part1ShouldMatchExampleCount()
	{
		var day = new Day01(input);

		var answer = day.Part1();

		answer.Should().Be("24000");
	}

	[Fact]
	public void Part2ShouldMatchExampleCount()
	{
		var day = new Day01(input);

		var answer = day.Part2();

		answer.Should().Be("45000");
	}
}
