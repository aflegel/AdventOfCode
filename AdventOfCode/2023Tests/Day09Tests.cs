using Xunit;
using AdventOfCode.Y2023;
using FluentAssertions;

namespace AdventOfCode.Y2023Tests;

public class Day09Tests
{
	private readonly string input = @"0 3 6 9 12 15
1 3 6 10 15 21
10 13 16 21 30 45".ReplaceLineEndings("\n");

	[Fact]
	public void Part1ShouldMatchExampleCount()
	{
		var day = new Day09(input);

		var answer = day.Part1();

		answer.Should().Be("114");
	}

	[Fact]
	public void Part2ShouldMatchExampleCount()
	{
		var day = new Day09(input);

		var answer = day.Part2();

		answer.Should().Be("2");
	}
}
