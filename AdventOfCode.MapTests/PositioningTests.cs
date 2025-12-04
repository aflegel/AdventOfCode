using Xunit;
using FluentAssertions;
using AdventOfCode.Map;
using System.Collections.Generic;

namespace AdventOfCode.MapTests;

public class PositioningTests
{
	private readonly string input = @"MMMSXXMASM
MSAMXMSMSA
AMXSXMAAMM
MSAMASMSMX
XMASAMXAMM
XXAMMXXAMA
SMSMSASXSS
SAXAMASAAA
MAMMMXMMMM
MXMXAXMASX";

	[Fact]
	public void ShouldNotReturnOutOfBounds()
	{
		var map = Map2D<char>.FromString(input);
		var testPos = new Position2D(0, 0);

		var adj = map.GetAdjacent(testPos);
		var expected = new List<Position2D>() { new(1, 0), new(1, 1), new(0, 1) };
		adj.Should().BeEquivalentTo(expected);

		var orth = map.GetOrthogonal(testPos);
		expected = [new(1, 0), new(0, 1)];
		orth.Should().BeEquivalentTo(expected);

		var diag = map.GetDiagonal(testPos);
		expected = [new(1, 1)];
		diag.Should().BeEquivalentTo(expected);
	}

	[Fact]
	public void ShouldReturnAllRelevant()
	{
		var map = Map2D<char>.FromString(input);
		var testPos = new Position2D(5, 5);

		var adj = map.GetAdjacent(testPos);
		var expected = new List<Position2D>() { new(4, 5), new(4, 4), new(5, 4), new(6, 4), new(6, 5), new(6, 6), new(5, 6), new(4, 6) };
		adj.Should().BeEquivalentTo(expected);

		var orth = map.GetOrthogonal(testPos);
		expected = [new(4, 5), new(6, 5), new(5, 4), new(5, 6)];
		orth.Should().BeEquivalentTo(expected);

		var diag = map.GetDiagonal(testPos);
		expected = [new(4, 4), new(6, 6), new(4, 6), new(6, 4)];
		diag.Should().BeEquivalentTo(expected);
	}

	[Fact]
	public void ShouldReturnAllCustom()
	{
		var map = Map2D<char>.FromString(input);
		var testPos = new Position2D(5, 5);

		var adj = map.GetAdjacents(testPos, [Direction.DownLeft, Direction.Right]);
		var expected = new List<Position2D>() { new(4, 6), new(6, 5) };
		adj.Should().BeEquivalentTo(expected);
	}
}
