string[] lines = System.IO.File.ReadAllLines(@"input.txt");
int x = 1;
int past_x = 1;
int count = 0;
int past_cycle = 1;
int cycle_count = 1;
int sum = 0;
List<int> check = new List<int>() { 20, 60, 100, 140, 180, 220 };
List<string> CTR = new List<string>();
(int, int, int) sprite = (0, 1, 2);
string row = "";
foreach (var line in lines)
{
    foreach (var number in check)
    {
        if (cycle_count == number)
        {
            sum += number * x;
        }
        else if (cycle_count > number && past_cycle < number)
        {
            sum += number * past_x;
        }
    }
    if (!(line == "noop"))
    {
        var item = line.Split(" ");
        for (var i = 0; i < 2; i++)
        {
            if (count == sprite.Item1 || count == sprite.Item2 || count == sprite.Item3)
            {
                row += "#";
            }
            else
            {
                row += ".";
            }
            count++;
            if (count == 40)
            {
                count = 0;
                CTR.Add(row);
                row = "";
            }
        }
        past_x = x;
        x += Int32.Parse(item[1]);
        sprite.Item1 = x - 1;
        sprite.Item2 = x;
        sprite.Item3 = x + 1;
        past_cycle = cycle_count;
        cycle_count += 2;

    }
    else
    {
        if (count == sprite.Item1 || count == sprite.Item2 || count == sprite.Item3)
        {
            row += "#";
        }
        else
        {
            row += ".";
        }
        count++;
        if (count == 40)
        {
            count = 0;
            CTR.Add(row);
            row = "";
        }
        past_cycle = cycle_count;
        cycle_count++;
    }
}
Console.WriteLine($"Sum {sum}");
foreach (var line in CTR)
{
    Console.WriteLine(line);
}