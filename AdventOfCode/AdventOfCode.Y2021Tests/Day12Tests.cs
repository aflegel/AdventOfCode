﻿using Xunit;
using AdventOfCode.Y2021;
using FluentAssertions;

namespace AdventOfCode.Y2021Tests;

public class Day12Tests
{
	private readonly string input = @"start-A
start-b
A-c
A-b
b-d
A-end
b-end";

	private readonly string input2 = @"dc-end
HN-start
start-kj
dc-start
dc-HN
LN-dc
HN-end
kj-sa
kj-HN
kj-dc";

	private readonly string input3 = @"fs-end
he-DX
fs-he
start-DX
pj-DX
end-zg
zg-sl
zg-pj
pj-he
RW-he
fs-DX
pj-RW
zg-RW
start-pj
he-WI
zg-he
pj-fs
start-RW";

	[Fact]
	public void Part1SouldMatchExampleCount()
	{
		var day = new Day12(input);

		var answer = day.Part1();

		answer.Should().Be("10");
	}

	[Fact]
	public void Part1SouldMatchExampleCount2()
	{
		var day = new Day12(input2);

		var answer = day.Part1();

		answer.Should().Be("19");
	}

	[Fact]
	public void Part1SouldMatchExampleCount3()
	{
		var day = new Day12(input3);

		var answer = day.Part1();

		answer.Should().Be("226");
	}

	[Fact]
	public void Part2SouldMatchExampleCount()
	{
		var day = new Day12(input);

		var answer = day.Part2();

		answer.Should().Be("36");
	}

	[Fact]
	public void Part2SouldMatchExampleCount2()
	{
		var day = new Day12(input2);

		var answer = day.Part2();

		answer.Should().Be("103");
	}

	[Fact]
	public void Part2SouldMatchExampleCount3()
	{
		var day = new Day12(input3);

		var answer = day.Part2();

		answer.Should().Be("3509");
	}
}
