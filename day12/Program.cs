string[] lines = System.IO.File.ReadAllLines(@"input.txt");
(int x, int y, int value) start = (0, 0, 0);
(int x, int y) end = (0, 0);
List<List<(int x, int y, int height)>> map = new List<List<(int x, int y, int height)>>();
for (var y = 0; y < lines.Length; y++)
{
    List<(int x, int y, int height)> row_map = new List<(int x, int y, int height)>();
    for (var x = 0; x < lines[y].Length; x++)
    {
        if (lines[y][x] == 'S')
        {
            start = (x, y, char.ToUpper('a') - 64);
            row_map.Add((x, y, char.ToUpper('a') - 64));
        }
        else if (lines[y][x] == 'E')
        {
            end = (x, y);
            row_map.Add((x, y, char.ToUpper('z') - 64));
        }
        else
        {
            row_map.Add((x, y, char.ToUpper(lines[y][x]) - 64));
        }
    }
    map.Add(row_map);
}

// Part 1, start at S and move to E
// Part 2 start at E and move to first a

// Create a queue containing positions and distance, and add the start position to it
var queue = new Queue<(int, int, int)>();
//queue.Enqueue((start.x, start.y, 0)); // Part 1
queue.Enqueue((end.x, end.y, 0)); // Part 2

// Create a hash set to avoid adding the same positions to the queue
var visited = new HashSet<(int, int)>();
//visited.Add((start.x, start.y)); // Part 1
visited.Add((end.x, end.y)); // Part 2

while (queue.Count > 0)
{
    // Remove the first position in the queue
    var (x, y, distance) = queue.Dequeue();
    // Loop trough the neighbor right, left, over and under
    foreach ((int column, int row) in new (int, int)[] { (x + 1, y), (x - 1, y), (x, y + 1), (x, y - 1) })
    {
        // Skip if the position is outside the grid
        if (row < 0 || column < 0 || row >= map.Count || column >= map[0].Count)
        {
            continue;
        }
        // Skip if the position already is visited
        if (visited.Contains((column, row)))
        {
            continue;
        }
        // Skip if the height is higher than one
        //if (map[row][column].height - map[y][x].height > 1) // Part 1
        if (map[row][column].height - map[y][x].height < -1) // Part 2
        {
            continue;
        }
        // If the neighbor is the end position, stop the loop
        //if (row == end.y && column == end.x) // Part 1
        if (map[row][column].height == 1) // Part 2
        {
            Console.WriteLine($"The distance is {distance + 1}");
            return;
        }
        // Add current neighbor to the visited list and add it to the queue
        visited.Add((column, row));
        queue.Enqueue((column, row, distance + 1));
    }
}