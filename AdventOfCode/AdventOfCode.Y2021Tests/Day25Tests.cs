using AdventOfCode.Y2021;
using FluentAssertions;
using Xunit;

namespace AdventOfCode.Y2021Tests;

public class Day25Tests
{

	private readonly string input = @"v...>>.vv>
.vv>>.vv..
>>.>v>...v
>>v>>.>.v.
v>v.vv.v..
>.>>..v...
.vv..>.>v.
v.v..>>v.v
....v..v.>";

	[Fact]
	public void Part1SouldMatchExampleCount()
	{
		var day2 = new Day25(input);

		var answer = day2.Part1();

		answer.Should().Be("58");
	}

	[Fact]
	public void Part2SouldMatchExampleCount()
	{
// Day 25 does not have a Part 2
	}
}
