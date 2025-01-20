using Xunit;
using AdventOfCode.Y2021;
using FluentAssertions;

namespace AdventOfCode.Y2021Tests;

public class Day10Tests
{
	private readonly string input = @"[({(<(())[]>[[{[]{<()<>>
[(()[<>])]({[<{<<[]>>(
{([(<{}[<>[]}>{[]{[(<()>
(((({<>}<{<{<>}{[]{[]{}
[[<[([]))<([[{}[[()]]]
[{[{({}]{}}([{[{{{}}([]
{<[[]]>}<{[{[{[]{()[[[]
[<(<(<(<{}))><([]([]()
<{([([[(<>()){}]>(<<{{
<{([{{}}[<[[[<>{}]]]>[]]";

	[Fact]
	public void Part1SouldMatchExampleCount()
	{
		var day = new Day10(input);

		var answer = day.Part1();

		answer.Should().Be("26397");
	}

	[Fact]
	public void Part2SouldMatchExampleCount()
	{
		var day = new Day10(input);

		var answer = day.Part2();

		answer.Should().Be("288957");
	}
}
