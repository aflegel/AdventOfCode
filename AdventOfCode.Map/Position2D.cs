namespace AdventOfCode.Map;

public enum Direction
{
	Up,
	UpRight,
	UpLeft,
	Down,
	DownRight,
	DownLeft,
	Left,
	Right
}

public static class DirectionExtensions
{
	public static bool IsOpposite(this Direction a, Direction b) => a switch
	{
		Direction.Up => b == Direction.Down,
		Direction.UpLeft => b == Direction.DownRight,
		Direction.UpRight => b == Direction.DownLeft,
		Direction.Down => b == Direction.Up,
		Direction.DownLeft => b == Direction.UpRight,
		Direction.DownRight => b == Direction.UpLeft,
		Direction.Left => b == Direction.Right,
		Direction.Right => b == Direction.Left,
		_ => false
	};
}

public record Position2D(int X, int Y) : IComparable<Position2D>
{
	public static Position2D operator -(Position2D a, Position2D b) => new(a.X - b.X, a.Y - b.Y);
	public static Position2D operator +(Position2D a, Position2D b) => new(a.X + b.X, a.Y + b.Y);

	public static Position2D operator *(Position2D a, int b) => new(a.X * b, a.Y * b);
	public static Position2D operator /(Position2D a, int b) => new(a.X / b, a.Y / b);

	public static Position2D FromString(string input)
	{
		var origin = input.Split(",");
		return new Position2D(int.Parse(origin[0]), int.Parse(origin[1]));
	}

	public Position2D Move(Direction direction) => Move(direction, 1);

	public Position2D Move(Direction direction, int distance) => this + direction switch
	{
		Direction.Up => new Position2D(0, -1),
		Direction.Down => new Position2D(0, 1),
		Direction.Left => new Position2D(-1, 0),
		Direction.Right => new Position2D(1, 0),
		Direction.UpLeft => new Position2D(-1, -1),
		Direction.UpRight => new Position2D(1, -1),
		Direction.DownLeft => new Position2D(-1, 1),
		Direction.DownRight => new Position2D(1, 1),
		_ => throw new ArgumentOutOfRangeException(nameof(direction)),
	} * distance;

	public int Steps => Math.Abs(X) + Math.Abs(Y);

	public override string ToString() => $"{X},{Y}";

	public int CompareTo(Position2D? other) => other is not null ? other.X == X ? other.Y.CompareTo(Y) : other.X.CompareTo(X) : -1;
	public int CompareTo(object? obj) => obj is Position2D pos ? CompareTo(pos) : -1;
}
