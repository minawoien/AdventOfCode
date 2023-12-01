int sum = 0;

var values = new Dictionary<string, int>(){
    {"X", 1},
    {"Y", 2},
    {"Z", 3}
};

var roles = new Dictionary<int, string>(){
    { 3, "AX, BY, CZ"},
    { 6, "AY, BZ, CX"},
    { 0, "AZ, BX, CY"}
};

string[] lines = System.IO.File.ReadAllLines(@"input.txt");
foreach (var item in lines)
{
    var round = item.Split(" ");
    sum += values[round[1]];
    foreach (var role in roles)
    {
        if (role.Value.Contains(round[0] + round[1]))
        {
            sum += role.Key;
        }
    }
}

Console.WriteLine(sum);


// Part two
var newRoles = new Dictionary<string, int>(){
    {"X", 0},
    {"Y", 3},
    {"Z", 6}
};

int newSum = 0;
foreach (var item in lines)
{
    var round = item.Split(" ");
    int key = newRoles[round[1]];
    newSum += key;
    var pairList = roles[key].Split(",");
    foreach (var pair in pairList)
    {
        if (pair.Contains(round[0]))
        {
            var last = pair.Last().ToString();
            newSum += values[last];
        }

    }
}
Console.WriteLine(newSum);