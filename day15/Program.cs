string[] lines = System.IO.File.ReadAllLines(@"input.txt");
int row_numb = 2000000;
int higher_limit = 4000000;
int lower_limit = 0;
Dictionary<(int x, int y), (int x, int y)> sensors_near_row = new Dictionary<(int, int), (int, int)>();
Dictionary<int, int> signals_on_row = new Dictionary<int, int>();
List<(int, int)> signals = new List<(int, int)>();
foreach (var line in lines)
{
    var splitted_line = line.Split(":");
    (int x, int y) sensor = get_values(splitted_line[0]);
    (int x, int y) closest_beacon = get_values(splitted_line[1]);
    sensors_near_row.Add(sensor, closest_beacon);
}
foreach (var line in sensors_near_row)
{
    calculate_distance(line.Key, line.Value, signals_on_row, row_numb, signals, lower_limit, higher_limit);
}
Console.WriteLine($"In the row where y=2000000, the number of positions that can not contain a beacon is {signals_on_row.Keys.Max() - signals_on_row.Keys.Min()}");

static void calculate_distance((int x, int y) sensor, (int x, int y) beacon, Dictionary<int, int> signals_on_row, int row_numb, List<(int, int)> signals, int lower_limit, int higher_limit)
{
    var addition = Math.Abs(sensor.x - beacon.x) + Math.Abs(sensor.y - beacon.y);
    var count = 0;
    for (var j = sensor.y; j < sensor.y + addition + 1; j++)
    {

        if (j == row_numb)
        {
            for (var i = sensor.x - addition + count; i < sensor.x + addition + 1 - count; i++)
            {

                if (!(signals_on_row.ContainsKey(i))) { signals_on_row.Add(i, 1); }
            }
        }
        count++;
    }
    count = 0;
    for (var j = sensor.y - 1; j > sensor.y - addition - 1; j -= 1)
    {
        if (j == row_numb)
        {
            for (var i = sensor.x - addition + count + 1; i < sensor.x + addition - count; i++)
            {

                if (!(signals_on_row.ContainsKey(i))) { signals_on_row.Add(i, 1); }
            }
        }
        count++;
    }
}

static (int, int) get_values(string line)
{
    var items = line.Split(" ");
    var item_x = items[items.Length - 2].Replace(",", "").Split("=");
    var x = Int32.Parse(item_x[1]);
    var y = Int32.Parse(items[items.Length - 1].Split("=")[1]);
    return (x, y);
}