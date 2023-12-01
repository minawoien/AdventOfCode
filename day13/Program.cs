using System.Text.Json;
var lines = File.ReadAllLines("input2.txt").ToArray();
int index = 0;
for (var i = 0; i < lines.Length; i += 3)
{
    index++;
    // Use of JSON deserialize because of the input's format
    var left = JsonSerializer.Deserialize<JsonElement>(lines[i]);
    var right = JsonSerializer.Deserialize<JsonElement>(lines[i + 1]);
    Console.WriteLine(left.GetType());
    Console.WriteLine(right.GetType());


    if (Compare(left.GetArrayLength(), right.GetArrayLength()))
    {
        Console.WriteLine($"Index {index} are in correct order");
    }
    for (var j = 0; j < right.GetArrayLength(); j++)
    {
        if (Compare(left[j].GetInt32(), right[j].GetInt32()))
        {
            Console.WriteLine($"Index {index} are in correct order");
            break;
        }
    }
}

static bool Compare(int left, int right)
{
    if (left < right)
    {
        return true;
    }
    return false;
}
