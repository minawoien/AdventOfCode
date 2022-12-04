
List<int> list = new List<int>();
int sum = 0;

// Loop trough the file, convert to int and sum the numbers
// When it is a break, the sum is added to an empty list and the sum is reset
string[] lines = System.IO.File.ReadAllLines(@"input.txt");
foreach (var item in lines)
{
    if (item != "")
    {
        int intItem = Int32.Parse(item);
        sum += intItem;
    }
    else
    {
        list.Add(sum);
        sum = 0;
    }
}

// Total Calories the Elf carrying the most Calories
Console.WriteLine(list.Max());

// Sorting the list to find the top three Elves carrying the most Calories
list.Sort();
list.Reverse();

// The calories the top three Elves carry in total
Console.WriteLine(list[0] + list[1] + list[2]);

