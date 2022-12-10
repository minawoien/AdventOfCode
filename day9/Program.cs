string[] lines = System.IO.File.ReadAllLines(@"input2.txt");
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
        Console.WriteLine($"Before, Head: {head}, Tail: {tail}");
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
        Console.WriteLine($"After, Head: {head}, Tail: {tail}");
    }
    else if (command[0] == "U")
    {
        Console.WriteLine($"Before, Head: {head}, Tail: {tail}");
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
        Console.WriteLine($"After, Head: {head}, Tail: {tail}");
    }
    else if (command[0] == "L")
    {
        Console.WriteLine($"Before, Head: {head}, Tail: {tail}");
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
        Console.WriteLine($"After, Head: {head}, Tail: {tail}");
    }
    else
    {
        Console.WriteLine($"Before, Head: {head}, Tail: {tail}");
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
        Console.WriteLine($"After, Head: {head}, Tail: {tail}");
    }
}
Console.WriteLine($"Tailed has moved: {count} places");

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