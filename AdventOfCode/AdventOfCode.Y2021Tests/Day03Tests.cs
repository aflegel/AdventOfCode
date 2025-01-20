using Xunit;
using AdventOfCode.Y2021;
using FluentAssertions;

namespace AdventOfCode.Y2021Tests;

public class Day03Tests
{
	private readonly string input = @"00100
11110
10110
10111
10101
01111
00111
11100
10000
11001
00010
01010";

	[Fact]
	public void Part1SouldMatchExampleCount()
	{
		var day = new Day03(input);

		var answer = day.Part1();

		answer.Should().Be("198");
	}

	[Fact]
	public void Part2SouldMatchExampleCount()
	{
		var day = new Day03(input);

		var answer = day.Part2();

		answer.Should().Be("230");
	}
}
