string[] lines = System.IO.File.ReadAllLines(@"input2.txt");
List<Char> signs = new List<Char>() { '<', '>', 'v', '^' };
List<List<(int x, int y, char sign)>> map = new List<List<(int, int, char)>>();
for (var y = 1; y < lines.Length - 1; y++)
{
    List<(int x, int y, char sign)> row_map = new List<(int x, int y, char sign)>();
    for (var x = 1; x < lines[y].Length - 1; x++)
    {
        row_map.Add((x - 1, y - 1, lines[y][x]));
    }
    map.Add(row_map);
}
(int x, int y) position = (0, -1);
(int x, int y) end_position = (map[0].Count - 1, map.Count);
Console.WriteLine($"Start: {position}");
Console.WriteLine($"End: {end_position}");
foreach (var row in map)
{
    foreach (var item in row)
    {
        Console.WriteLine(item);
    }
}

// Create a queue for the positions and minute, add the first position to the queue
var queue = new Queue<(int, int, int)>();
queue.Enqueue((position.x, position.y, 0));

// Create a hash set to avoid adding the same positions to the queue
var visited = new HashSet<(int, int)>();
visited.Add(position);

while (queue.Count > 0)
{
    // Remove the first position in the queue
    var (x, y, distance) = queue.Dequeue();
    // Loop trough the neighbor right, left, over and under
    // column: new x, row: new y

    foreach ((int column, int row) in new (int, int)[] { (x + 1, y), (x - 1, y), (x, y + 1), (x, y - 1) })
    {
        if (row == end_position.y && column == end_position.x)
        {
            Console.WriteLine("END");
            return;
        }
        if (row < 0 || column < 0 || row >= map.Count || column >= map[0].Count)
        {
            continue;
        }
        //! remove?
        if (visited.Contains((column, row)))
        {
            continue;
        }
        if (signs.Contains(map[row][column].sign))
        {
            continue;
        }
        Console.WriteLine(map[row][column]);
    }
}


// static (int, int) move_position((int x, int y) position, List<(int x, int y, char sign)> map)
// {
//     var position_map = map.Select(item => (item.x, item.y)).ToList();
//     if (!(position_map.Contains((position.x + 1, position.y))))
//     {
//         Console.WriteLine("move right");
//         position = (position.x + 1, position.y);
//     }
//     else if (!(position_map.Contains((position.x, position.y + 1))))
//     {
//         Console.WriteLine("move down");
//         position = (position.x, position.y + 1);
//     }
//     else if (!(position_map.Contains((position.x, position.y - 1))))
//     {
//         Console.WriteLine("move up");
//         position = (position.x, position.y - 1);
//     }
//     else if (!(position_map.Contains((position.x - 1, position.y))))
//     {
//         Console.WriteLine("move left");
//         position = (position.x - 1, position.y);
//     }
//     else
//     {
//         Console.WriteLine("dont move");
//     }
//     Console.WriteLine(position);

//     return position;
// }


static List<List<(int x, int y, char sign)>> move_blizzard(List<List<(int x, int y, char sign)>> map)
{
    List<List<(int x, int y, char sign)>> new_map = new List<List<(int x, int y, char sign)>>();
    foreach (var row_map in map)
    {
        var map_right = row_map.Select(item => (item.x + 1, item.y, item.sign)).Where(item => item.sign == '>').ToList();
        var map_down = row_map.Select(item => (item.x, item.y + 1, item.sign)).Where(item => item.sign == 'v').ToList();
        var map_up = row_map.Select(item => (item.x, item.y - 1, item.sign)).Where(item => item.sign == '^').ToList();
        var map_left = row_map.Select(item => (item.x - 1, item.y, item.sign)).Where(item => item.sign == '<').ToList();
        List<(int x, int y, char sign)> new_row_map = new List<(int x, int y, char sign)>();
        new_row_map.AddRange(map_right);
        new_row_map.AddRange(map_down);
        new_row_map.AddRange(map_up);
        new_row_map.AddRange(map_left);
        new_map.Add(new_row_map);
    }

    return new_map;
}
