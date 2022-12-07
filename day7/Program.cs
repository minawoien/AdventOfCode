string[] lines = System.IO.File.ReadAllLines(@"input.txt");
string current = "";
List<List<string>> list = new List<List<string>>();
List<string> folder = new List<string>();
Dictionary<string, int> values = new Dictionary<string, int>();
foreach (var line in lines)
{
    var item = line.Split(" ");
    // Check if it moves into a folder or out of a folder
    if (item[1] == "cd")
    {
        // Chek if it moves into a folder
        if (item[2] != "..")
        {
            // Add the folder to the list of all folders and reset it
            // Find the current path and add it to the folder list
            list.Add(folder);
            folder = new List<string>();
            current = current + "/" + item[2];
            folder.Add(current);
        }
        else
        {
            // If it moves out of a folder it removes the last folder from the path
            int i = current.LastIndexOf("/");
            current = current[0..i];
        }
    }
    // If the folder contains another folder it gets added to the folders list
    else if (item[0] == "dir")
    {
        folder.Add(current + "/" + item[1]);
    }
    // If the item is a file, the file size gets added to the folders list
    else if (item[0] != "$")
    {
        if (item[0] != "dir")
        {
            folder.Add(item[0]);
        }
    }
}
list.Add(folder);
list.Reverse();
// Loop trough the folders in the list containing folders
foreach (var item in list)
{
    int size = 0;
    current = "";
    int x = 0;
    for (var i = 0; i < item.Count; i++)
    {
        // Set the current folder
        // Convert the file sizes to int and find the sum of it
        current = item[0];
        if (Int32.TryParse(item[i], out x))
        {
            size += Int32.Parse(item[i]);
        }
        // If the items is folder names, and it is not the current folder, 
        // the sum of this folders size get added to the sum
        else if (i != 0)
        {
            size += values[item[i]];
        }
    }
    // Add the current folder and its size to a dict
    values.Add(current, size);
}
// Find the sum of the folders with a size less than 100000
int result = 0;
foreach (var item in values)
{
    if (item.Value < 100000)
    {
        result += item.Value;
    }
}
Console.WriteLine($"The sum of the sizes of the directories with a total size of at most 100000 is {result}");

// Part two
// Sort the value dict and convert it to a list to find the total size of the outermost directory
// Find the required size to be deleted
var sizes = values.OrderBy(key => key.Value).ToList();
sizes.Reverse();
int disk_space = 70000000;
int needed_space = 30000000;
int required = needed_space - (disk_space - sizes[0].Value);

// Find the the directories that are high enough, and find the smallest of them.
List<int> highEnough = new List<int>();
foreach (var item in values)
{
    if (item.Value > required)
    {
        highEnough.Add(item.Value);
    }
}
highEnough.Sort();
Console.WriteLine($"The total size of the smallest directory that would free up enough space is {highEnough[0]}");
