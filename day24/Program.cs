string[] lines = System.IO.File.ReadAllLines(@"input2.txt");
List<(int x, int y, char sign)> map = new List<(int, int, char)>() { (1, -1, '.') };
for (var y = 0; y < lines.Length; y++)
{
    for (var x = 0; x < lines[y].Length; x++)
    {
        if (lines[y][x] != '.')
        {
            map.Add((x, y, lines[y][x]));
        }
    }
}
int x_length = lines[0].Length - 1;
int y_length = lines.Length - 1;
(int x, int y) position = (1, 0);
(int x, int y) end_position = (x_length - 1, y_length);
int minute = 0;
Console.WriteLine($"Start: {position}");
Console.WriteLine($"End: {end_position}");

while (position != end_position)
{
    map = move_blizzard(map, x_length, y_length);
    position = move_position(position, map);
    minute += 1;
}
Console.WriteLine(minute);

static (int, int) move_position((int x, int y) position, List<(int x, int y, char sign)> map)
{
    var position_map = map.Select(item => (item.x, item.y)).ToList();
    if (!(position_map.Contains((position.x + 1, position.y))))
    {
        Console.WriteLine("move right");
        position = (position.x + 1, position.y);
    }
    else if (!(position_map.Contains((position.x, position.y + 1))))
    {
        Console.WriteLine("move down");
        position = (position.x, position.y + 1);
    }
    else if (!(position_map.Contains((position.x, position.y - 1))))
    {
        Console.WriteLine("move up");
        position = (position.x, position.y - 1);
    }
    else if (!(position_map.Contains((position.x - 1, position.y))))
    {
        Console.WriteLine("move left");
        position = (position.x - 1, position.y);
    }
    else
    {
        Console.WriteLine("dont move");
    }
    Console.WriteLine(position);

    return position;
}


static List<(int x, int y, char sign)> move_blizzard(List<(int x, int y, char sign)> map, int x_length, int y_length)
{
    var wall = map.Select(item => item).Where(item => item.sign == '#').ToList();
    var map_right = map.Select(item => (item.x + 1, item.y, item.sign)).Where(item => item.sign == '>').ToList();
    var map_down = map.Select(item => (item.x, item.y + 1, item.sign)).Where(item => item.sign == 'v').ToList();
    var map_up = map.Select(item => (item.x, item.y - 1, item.sign)).Where(item => item.sign == '^').ToList();
    var map_left = map.Select(item => (item.x - 1, item.y, item.sign)).Where(item => item.sign == '<').ToList();
    map = new List<(int x, int y, char sign)>() { (1, -1, '.') };
    map.AddRange(wall);
    map.AddRange(map_right);
    map.AddRange(map_down);
    map.AddRange(map_up);
    map.AddRange(map_left);
    map = move_from_wall(map, x_length, y_length);
    return map;
}

static List<(int x, int y, char sign)> move_from_wall(List<(int x, int y, char sign)> map, int x_length, int y_length)
{
    List<(int x, int y, char sign)> move_map = new List<(int x, int y, char sign)>();
    foreach (var move in map)
    {
        var y = move.y;
        var x = move.x;
        if (move.sign != '#')
        {
            if (move.y == y_length)
            {
                y = 1;
            }
            else if (move.x == x_length)
            {
                x = 1;
            }
            else if (move.x == 0)
            {
                x = x_length - 1;
            }
            else if (move.y == 0)
            {
                y = y_length - 1;
            }
        }
        move_map.Add((x, y, move.sign));
    }
    return move_map;
}