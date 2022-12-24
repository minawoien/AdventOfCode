string data = System.IO.File.ReadAllText(@"input.txt");
List<(int x, int y)> rock_top = new List<(int, int)> { (0, 0), (1, 0), (2, 0), (3, 0), (4, 0), (5, 0), (6, 0) };
int count_rocks = 0;
int change = 0;
List<(int x, int y)> rock = get_next(rock_top, 0);
while (count_rocks != -1)
{
    var returned = pattern(data, rock_top, count_rocks, change, rock);
    change = returned.Item2;
    count_rocks = returned.Item1;
    rock = returned.Item3;
}
foreach (var item in rock_top)
{
    Console.WriteLine(item);
}
var tower_hight = rock_top.Select(tuple => tuple.y).Max();
Console.WriteLine($"The tower of rocks' hight after 2022 rocks have stopped falling is {tower_hight}");

static List<(int, int)> next_coordinates(int i, string data, List<(int x, int y)> rock, List<(int, int)> rock_top)
{
    // Check if the rock can move left
    if (data[i] == '<' && rock.Select(tuple => tuple.x).Min() > 0)
    {
        if (!(rock.Any(a => rock_top.Contains((a.x - 1, a.y)))))
        {
            rock = rock.Select(item => (item.x - 1, item.y)).ToList();
        }
    }
    // Check if the rock can move right
    else if (data[i] == '>' && rock.Select(tuple => tuple.x).Max() < 6)
    {
        if (!(rock.Any(a => rock_top.Contains((a.x + 1, a.y)))))
        {
            rock = rock.Select(item => (item.x + 1, item.y)).ToList();
        }
    }
    return rock;
}

static List<(int, int)> get_next(List<(int x, int y)> rock_top, int type)
{
    List<(int x, int y)> rock = new List<(int, int)>() { };
    int y_top = rock_top.Select(tuple => tuple.y).Max();
    if (type == 0) // Type -
    {
        rock.Add((2, y_top + 4));
        rock.Add((3, y_top + 4));
        rock.Add((4, y_top + 4));
        rock.Add((5, y_top + 4));
    }
    else if (type == 1) // Type +
    {
        rock.Add((3, y_top + 4));
        rock.Add((2, y_top + 5));
        rock.Add((3, y_top + 5));
        rock.Add((4, y_top + 5));
        rock.Add((3, y_top + 6));
    }

    else if (type == 2) // Type L
    {
        rock.Add((2, y_top + 4));
        rock.Add((3, y_top + 4));
        rock.Add((4, y_top + 4));
        rock.Add((4, y_top + 5));
        rock.Add((4, y_top + 6));
    }
    else if (type == 3) // Type I
    {
        rock.Add((2, y_top + 4));
        rock.Add((2, y_top + 5));
        rock.Add((2, y_top + 6));
        rock.Add((2, y_top + 7));
    }
    else if (type == 4) // Type o
    {
        rock.Add((2, y_top + 4));
        rock.Add((3, y_top + 4));
        rock.Add((2, y_top + 5));
        rock.Add((3, y_top + 5));
    }
    return rock;
}

static (int, int, List<(int x, int y)>) pattern(string data, List<(int, int)> rock_top, int count_rocks, int change, List<(int x, int y)> rock)
{
    bool rest = false;
    for (var i = 0; i < data.Length; i++)
    {
        // Stop when 2022 rocks have stopped
        if (count_rocks == 2022)
        {
            return (-1, change, rock);
        }
        // Move to one side
        rock = next_coordinates(i, data, rock, rock_top);
        if (rest)
        {
            count_rocks += 1;
            rest = false;
            foreach (var item in rock)
            {
                rock_top.Add(item);
            }
            change += 1;
            if (change > 4)
            {
                change = 0;
            }
            rock = get_next(rock_top, change);
        }
        else
        {
            // Move rock one down
            rock = rock.Select(item => (item.x, item.y - 1)).ToList();
            try
            {
                // Find the next position for the rock to see if the rock can move there
                List<(int x, int y)> next_rock = next_coordinates(i + 1, data, rock, rock_top);
                foreach (var stone in next_rock)
                {
                    if (rock_top.Contains((stone.x, stone.y - 1)))
                    {
                        rest = true;
                    }
                }
            }
            catch { }
        }
    }
    return (count_rocks, change, rock);
}