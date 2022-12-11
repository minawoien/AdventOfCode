string[] lines = System.IO.File.ReadAllLines(@"input.txt");
Dictionary<int, List<double>> worry_levels = new Dictionary<int, List<double>>();
Dictionary<int, double> inspected = new Dictionary<int, double>();
int current_monkey = 0;
for (var i = 0; i < lines.Length; i += 7)
{
    // Find current monkey
    var item = lines[i].Split(" ");
    current_monkey = Int32.Parse(item[1].Remove(item[1].Length - 1, 1));

    // Find Starting items
    var start = lines[i + 1].Split(":");
    var starting_items = start[1].Split(",");
    List<double> start_items = new List<double>();
    foreach (var worry_level in starting_items)
    {
        start_items.Add(double.Parse(worry_level));
    }
    worry_levels.Add(current_monkey, start_items);
    inspected.Add(current_monkey, 0);
}

for (var j = 0; j < 10000; j++)
{
    for (var i = 0; i < lines.Length; i += 7)
    {
        double count = 0;
        // Find current monkey and its items
        var item = lines[i].Split(" ");
        current_monkey = Int32.Parse(item[1].Remove(item[1].Length - 1, 1));
        var starting_items = worry_levels[current_monkey];

        // Find operation
        var operation = lines[i + 2].Split(":");
        var ch = operation[1].Split(" ");
        double x = 0;

        // Find test
        var test = lines[i + 3].Split(" ");
        double numb = double.Parse(test[test.Length - 1]);

        // Find next monkey
        var next_true = lines[i + 4].Split(" ");
        var t_next = Int32.Parse(next_true[next_true.Length - 1]);
        var next_false = lines[i + 5].Split(" ");
        var f_next = Int32.Parse(next_false[next_false.Length - 1]);
        foreach (var worry_level in starting_items)
        {
            double new_worry = 0;
            double new_w = 0;
            if (double.TryParse(ch[5], out x))
            {
                if (ch[4] == "*") { new_worry = worry_level * double.Parse(ch[5]); }
                else { new_worry = (worry_level + double.Parse(ch[5])); }
            }
            else
            {
                if (ch[4] == "*") { new_worry = worry_level * worry_level; }
                else { new_worry = (worry_level + worry_level); }
            }
            new_w = new_worry % 9699690; // LCM of the divisors

            if (new_w % numb == 0)
            {
                worry_levels[t_next].Add(new_w);
            }
            else
            {
                worry_levels[f_next].Add(new_w);
            }
            count++;
        }
        worry_levels[current_monkey] = new List<double>();
        inspected[current_monkey] += count;
    }
}

var inspected_list = inspected.ToList();
inspected_list.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));
inspected_list.Reverse();
Console.WriteLine(inspected_list[0].Value * inspected_list[1].Value);