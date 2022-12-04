int sum = 0;
List<Char> type = new List<Char>();
string[] lines = System.IO.File.ReadAllLines(@"input.txt");
foreach (var rucksacks in lines)
{
    // Split into compartments
    var first = rucksacks.Substring(0, (int)(rucksacks.Length / 2));
    var last = rucksacks.Substring((int)(rucksacks.Length / 2), (int)(rucksacks.Length / 2));
    foreach (var letter in first)
    {
        if (last.Contains(letter))
        {
            if (!(type.Contains(letter)))
            {
                type.Add(letter);
            }
        }
    }
    sum += Converting.ConvertToInt(type);
    type = new List<Char>();
}

Console.WriteLine($"Sum of the items that appears in both compartments of each rucksack is {sum}.");

// Part two
int newSum = 0;
for (var i = 0; i <= lines.Length - 1; i = i + 3)
{
    foreach (var letter in lines[i])
    {
        if (lines[i + 1].Contains(letter) & lines[i + 2].Contains(letter))
        {
            if (!(type.Contains(letter)))
            {
                type.Add(letter);
            }
        }
    }
    newSum += Converting.ConvertToInt(type);
    type = new List<Char>();
}

Console.WriteLine($"The sum of the item type that corresponds to the badges of each three-Elf group is {newSum}.");

