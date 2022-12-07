string[] lines = System.IO.File.ReadAllLines(@"input.txt");
var curr = "";
int sum = 0;
List<List<string>> list = new List<List<string>>();
List<string> liste = new List<string>();
foreach (var line in lines)
{
    var item = line.Split(" ");
    if (item[1] == "cd")
    {
        if (item[2] != "..")
        {
            list.Add(liste);
            liste = new List<string>();
            curr = curr + "/" + item[2];
            liste.Add(curr);
        }
        else
        {
            var i = curr.LastIndexOf("/");
            int ending = curr.Length - i;
            curr = curr[0..i];
        }
    }
    if (item[0] == "dir")
    {
        liste.Add(curr + "/" + item[1]);
    }
    if (item[0] != "$")
    {
        if (item[0] != "dir")
        {
            liste.Add(item[0]);
            sum += Int32.Parse(item[0]);
        }
    }
}
list.Add(liste);

list.Reverse();
var values = new Dictionary<string, int>();
int result = 0;
string now = "";
foreach (var item in list)
{
    int x = 0;
    for (var i = 0; i < item.Count; i++)
    {
        now = item[0];
        if (Int32.TryParse(item[i], out x))
        {
            result += Int32.Parse(item[i]);
        }
        else
        {
            if (i != 0)
            {
                result += values[item[i]];
            }
        }
    }
    values.Add(now, result);
    now = "";
    result = 0;
}

int end = 0;
foreach (var item in values)
{
    if (item.Value < 100000)
    {
        end += item.Value;
    }

}
Console.WriteLine(end);

// Part 2
List<int> sums = new List<int>();
foreach (var item in values)
{
    sums.Add(item.Value);
}
sums.Sort();
sums.Reverse();
int numb = 30000000 - (70000000 - sums[0]);
List<int> highEnough = new List<int>();
foreach (var item in values)
{

    if (item.Value > numb)
    {
        highEnough.Add(item.Value);
    }
}
highEnough.Sort();
Console.WriteLine(highEnough[0]);
