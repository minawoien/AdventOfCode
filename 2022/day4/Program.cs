int count = 0;
int newCount = 0;
string[] lines = System.IO.File.ReadAllLines(@"input.txt");
foreach (var item in lines)
{
    var ranges = item.Split(",");
    var first = ranges[0].Split("-");
    var second = ranges[1].Split("-");
    int[] firstRange = Enumerable.Range(Int32.Parse(first[0]), Int32.Parse(first[1]) - Int32.Parse(first[0]) + 1).ToArray();
    int[] secondRange = Enumerable.Range(Int32.Parse(second[0]), Int32.Parse(second[1]) - Int32.Parse(second[0]) + 1).ToArray();
    if (firstRange.All(secondRange.Contains) || secondRange.All(firstRange.Contains))
    {
        count += 1;

    }
    if (firstRange.Intersect(secondRange).Any())
    {
        newCount += 1;
    }
}

Console.WriteLine($" In {count} assignment pairs does one range fully contain the other");
Console.WriteLine($" In {newCount} assignment pairs do the ranges overlap");