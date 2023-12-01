string[] lines = System.IO.File.ReadAllLines(@"input.txt");
List<(decimal x, decimal y)> rocks_position = new List<(decimal, decimal)>();
(decimal x, decimal y) rock = (0, 0);
// Find rock positions
foreach (var line in lines)
{
    string[] item = line.Split("->");
    var splitted_item = item[0].Split(",");
    rock.x = decimal.Parse(splitted_item[0]);
    rock.y = decimal.Parse(splitted_item[1]);
    rocks_position.Add(rock);
    for (var i = 0; i < item.Length - 1; i++)
    {
        var first = item[i].Split(",");
        var second = item[i + 1].Split(",");
        decimal range_x = decimal.Parse(first[0].Trim()) - decimal.Parse(second[0].Trim());
        decimal range_y = decimal.Parse(first[1].Trim()) - decimal.Parse(second[1].Trim());
        decimal count = 0;
        if (range_x == 0)
        {
            count = range_y;
        }
        else
        {
            count = range_x;
        }
        for (var j = 1; j < Math.Abs(count) + 1; j++)
        {
            if (count < 0)
            {

                if (range_x == 0)
                {
                    rock.y = rock.y + 1;
                }
                else
                {
                    rock.x = rock.x + 1;
                }
            }
            else
            {
                if (range_x == 0)
                {
                    rock.y = rock.y - 1;
                }
                else
                {
                    rock.x = rock.x - 1;
                }
            }
            rocks_position.Add(rock);
        }
    }
}

// Find last rock
decimal y_pos = 0;
foreach (var item in rocks_position)
{
    if (item.y > y_pos)
    {
        y_pos = item.y;
    }
}
// Part 2: Add rocks at highest y+2
y_pos += 2;
var k = 0;
(decimal x, decimal y) sand = (500, 0);
(decimal x, decimal y) sand_new_position = (0, 0);
while (sand_new_position != (-1, -1))
{
    sand_new_position = MoveSand.move_sand(rocks_position, sand, y_pos);
    rocks_position.Add(sand_new_position);
    k++;
}
Console.WriteLine($"The number of sand which come to rest before sand starts flowing into the abyss below is {k - 1}.");
//Console.WriteLine($"The number of units with sand which come to rest is {k}.");