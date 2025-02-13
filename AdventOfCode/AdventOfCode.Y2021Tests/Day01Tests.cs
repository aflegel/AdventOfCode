﻿using Xunit;
using AdventOfCode.Y2021;
using FluentAssertions;

namespace AdventOfCode.Y2021Tests;

public class Day01Tests
{
	private readonly string input = @"199
200
208
210
200
207
240
269
260
263";
	
	[Fact]
	public void Part1SouldMatchExampleCount()
	{
		var day = new Day01(input);

		var answer = day.Part1();

		answer.Should().Be("7");
	}

	[Fact]
	public void Part2SouldMatchExampleCount()
	{
		var day = new Day01(input);

		var answer = day.Part2();

		answer.Should().Be("5");
	}
}
