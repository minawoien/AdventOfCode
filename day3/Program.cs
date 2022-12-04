int sum = 0;

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
            if (Char.IsUpper(letter))
            {
                sum += System.Convert.ToInt32(letter) - 38;
            }
            else
            {
                sum += System.Convert.ToInt32(letter) - 96;
            }
            break;
        }
    }
}

Console.WriteLine($"Sum of the items that appears in both compartments of each rucksack is {sum}.");

// Part two
int newSum = 0;
List<Char> type = new List<Char>();
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
    foreach (var letter in type)
    {
        if (Char.IsUpper(letter))
        {
            newSum += System.Convert.ToInt32(letter) - 38;
        }
        else
        {
            newSum += System.Convert.ToInt32(letter) - 96;
        }
    }
    type = new List<Char>();
}

Console.WriteLine($"The som of the item type that corresponds to the badges of each three-Elf group is {newSum}.");

