string[] lines = System.IO.File.ReadAllLines(@"input.txt");

List<string> one = new List<string>() { "P", "V", "Z", "W", "D", "T" };
List<string> two = new List<string>() { "D", "J", "F", "V", "W", "S", "L" };
List<string> three = new List<string>() { "H", "B", "T", "V", "S", "L", "M", "Z" };
List<string> four = new List<string>() { "J", "S", "R" };
List<string> five = new List<string>() { "W", "L", "M", "F", "G", "B", "Z", "C" };
List<string> six = new List<string>() { "B", "G", "R", "Z", "H", "V", "W", "Q" };
List<string> seven = new List<string>() { "N", "D", "B", "C", "P", "J", "V" };
List<string> eight = new List<string>() { "Q", "B", "T", "P" };
List<string> nine = new List<string>() { "C", "R", "Z", "G", "H" };

List<List<string>> list = new List<List<string>>() { one, two, three, four, five, six, seven, eight, nine };

List<int> Commands = new List<int>();

for (var i = 10; i < lines.Length; i++)
{
    lines[i] = lines[i].Replace("move ", "");
    lines[i] = lines[i].Replace("from ", ",");
    lines[i] = lines[i].Replace("to ", ",");
    var commands = lines[i].Split(",");
    foreach (var com in commands)
    {
        Commands.Add(Int32.Parse(com));
    }
}

for (var i = 0; i < Commands.Count; i = i + 3)
{
    for (var j = 0; j < Commands[0 + i]; j++)
    {
        // For part 1, remove (+j) to insert at index 0 every time
        list[Commands[2 + i] - 1].Insert(0 + j, list[Commands[1 + i] - 1][0]);
        list[Commands[1 + i] - 1].Remove(list[Commands[1 + i] - 1][0]);
    }
}

foreach (var i in list)
{
    Console.WriteLine(i[0]);
}
