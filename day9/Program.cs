string[] lines = System.IO.File.ReadAllLines(@"input.txt");
(int x, int y) head = (0, 0);
(int x, int y) tail = (0, 0);
Dictionary<(int, int), int> path = new Dictionary<(int, int), int>();

int count = 1;
path.Add(tail, 1);

for (var i = 0; i < lines.Length; i++)
{
    var command = lines[i].Split(" ");
    int move = Int32.Parse(command[1]);
    if (command[0] == "R")
    {
        for (var j = 0; j < move; j++)
        {
            head.y++;
            if (need_to_move(head, tail))
            {
                tail = head;
                tail.y--;
                if (!(path.ContainsKey(tail)))
                {
                    path.Add(tail, 1);
                    count++;
                }
            }
        }
    }
    else if (command[0] == "U")
    {
        for (var j = 0; j < move; j++)
        {
            head.x--;
            if (need_to_move(head, tail))
            {
                tail = head;
                tail.x++;
                if (!(path.ContainsKey(tail)))
                {
                    path.Add(tail, 1);
                    count++;
                }
            }
        }
    }
    else if (command[0] == "L")
    {
        for (var j = 0; j < move; j++)
        {
            head.y--;
            if (need_to_move(head, tail))
            {
                tail = head;
                tail.y++;
                if (!(path.ContainsKey(tail)))
                {
                    path.Add(tail, 1);
                    count++;
                }
            }
        }
    }
    else
    {
        for (var j = 0; j < move; j++)
        {
            head.x++;
            if (need_to_move(head, tail))
            {
                tail = head;
                tail.x--;
                if (!(path.ContainsKey(tail)))
                {
                    path.Add(tail, 1);
                    count++;
                }
            }
        }
    }
}
Console.WriteLine($"The number of positions the tail of the rope visit at least once is {count}");

static bool need_to_move((int x, int y) head, (int x, int y) tail)
{
    // On top
    if (head == tail) { return false; }
    // Left
    if (head.y == tail.y - 1 && head.x == tail.x) { return false; }
    // Right
    if (head.y == tail.y + 1 && head.x == tail.x) { return false; }
    // Under
    if (head.y == tail.y && head.x == tail.x + 1) { return false; }
    // Under left
    if (head.y == tail.y - 1 && head.x == tail.x + 1) { return false; }
    // Under right
    if (head.y == tail.y + 1 && head.x == tail.x + 1) { return false; }
    // Over
    if (head.y == tail.y && head.x == tail.x - 1) { return false; }
    // Over left
    if (head.y == tail.y - 1 && head.x == tail.x - 1) { return false; }
    // Over right
    if (head.y == tail.y + 1 && head.x == tail.x - 1) { return false; }
    return true;
}

// Part 2
var visitedLocations = new HashSet<(int x, int y)>() { (0, 0) };
int size = 10;
(int x, int y)[] rope = new (int x, int y)[size];
for (int i = 0; i < size; i++)
{
    rope[i] = (0, 0);
}
foreach (var line in lines)
{
    var command = line.Split(" ");
    var direction = command[0];
    int move = Int32.Parse(command[1]);
    for (var i = 0; i < move; i++)
    {
        // Move head
        var xdir = direction == "R" ? 1 : direction == "L" ? -1 : 0;
        var ydir = direction == "U" ? 1 : direction == "D" ? -1 : 0;
        rope[0].x += xdir;
        rope[0].y += ydir;
        // Move the tail
        for (var j = 0; j < size - 1; j++)
        {
            var front = rope[j];
            var behind = rope[j + 1];
            decimal xdiff = rope[j].x - rope[j + 1].x;
            decimal ydiff = rope[j].y - rope[j + 1].y;
            // Check if the tail needs to move in y direction
            if (xdiff == 0 && Math.Abs(ydiff) > 1)
            {
                behind.y += Decimal.ToInt32(Math.Floor(ydiff / 2));
            }
            // Check if the tail needs to move in x direction
            else if (ydiff == 0 && Math.Abs(xdiff) > 1)
            {
                behind.x += Decimal.ToInt32(Math.Floor(xdiff / 2));
            }
            // Check if the tail needs to move in both directions
            else if (Math.Abs(xdiff) > 1 || Math.Abs(ydiff) > 1)
            {
                if (xdiff > 0) { behind.x++; }
                else { behind.x--; }
                if (ydiff > 0) { behind.y++; }
                else { behind.y--; }
            }
            rope[j + 1] = behind;
            if (j == size - 2)
            {
                visitedLocations.Add(behind);
            }
        }
    }
}
Console.WriteLine($"The number of positions the tail visit at least once is {visitedLocations.Count}");