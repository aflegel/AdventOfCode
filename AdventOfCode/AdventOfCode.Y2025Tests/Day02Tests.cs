using AdventOfCode.Y2025;
using FluentAssertions;
using Xunit;

namespace AdventOfCode.Y2025Tests;

public class Day02Tests
{
	private readonly string input = @"11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449,38593856-38593862,565653-565659,824824821-824824827,2121212118-2121212124";

	[Fact]
	public void Part1ShouldMatchExampleCount()
	{
		var day = new Day02(input);

		var answer = day.Part1();

		answer.Should().Be("1227775554");
	}

	[Fact]
	public void Part2ShouldMatchExampleCount()
	{
		var day = new Day02(input);

		var answer = day.Part2();

		answer.Should().Be("4174379265");
	}
}
