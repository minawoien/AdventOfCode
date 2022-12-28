string[] lines = System.IO.File.ReadAllLines(@"input.txt");
Dictionary<(int, int), int> visible = new Dictionary<(int, int), int>();
for (var i = 1; i < lines.Length - 1; i++)
{
    for (var j = 1; j < lines[i].Length - 1; j++)
    {
        // Check over
        int count = 0;
        for (var k = 0; k < i; k++)
        {
            if (lines[i][j] > lines[k][j])
            {
                count += 1;
            }
        }
        if (count == i)
        {
            int tree = (int)Char.GetNumericValue(lines[i][j]);
            try
            {
                visible.Add((i, j), tree);
            }
            catch { }
        }
        // Check under
        count = 0;
        for (var k = i + 1; k < lines.Length; k++)
        {
            if (lines[i][j] > lines[k][j])
            {
                count += 1;
            }
        }
        if (count == lines.Length - (i + 1))
        {
            int tree = (int)Char.GetNumericValue(lines[i][j]);
            try
            {
                visible.Add((i, j), tree);
            }
            catch { }
        }
        // Check left
        count = 0;
        for (var k = 0; k < j; k++)
        {
            if (lines[i][j] > lines[i][k])
            {
                count += 1;
            }
        }
        if (count == j)
        {
            int tree = (int)Char.GetNumericValue(lines[i][j]);
            try
            {
                visible.Add((i, j), tree);
            }
            catch { }
        }
        // Check right
        count = 0;
        for (var k = j + 1; k < lines[i].Length; k++)
        {
            if (lines[i][j] > lines[i][k])
            {
                count += 1;
            }
        }
        if (count == lines[i].Length - (j + 1))
        {
            int tree = (int)Char.GetNumericValue(lines[i][j]);
            try
            {
                visible.Add((i, j), tree);
            }
            catch { }
        }
    }
}

// Add frame
for (var i = 0; i < lines.Length; i += lines.Length - 1)
{
    for (var j = 0; j < lines[i].Length; j++)
    {
        int line = (int)Char.GetNumericValue(lines[i][j]);
        visible.Add((i, j), line);
    }
}

for (var i = 1; i < lines.Length - 1; i += 1)
{
    for (var j = 0; j < lines[i].Length; j += lines[i].Length - 1)
    {
        int line = (int)Char.GetNumericValue(lines[i][j]);
        visible.Add((i, j), line);
    }
}

Console.WriteLine($"Threes visible from outside the grid is {visible.Count()}");


// Part 2

List<int> scenic_scores = new List<int>();
// The possible places for the three house is inside the frame
// as the view is zero for at least one side on the frame
for (var i = 1; i < lines.Length - 1; i++)
{
    for (var j = 1; j < lines[i].Length - 1; j++)
    {
        int right = 0;
        int left = 0;
        int up = 0;
        int down = 0;
        // Look right
        for (var k = j + 1; k < lines[i].Length; k++)
        {
            right++;
            if (lines[i][j] <= lines[i][k])
            {
                break;
            }
        }
        // Look left
        for (var k = j - 1; k > -1; k--)
        {
            left++;
            if (lines[i][j] <= lines[i][k])
            {
                break;
            }
        }
        // Look up
        for (var k = i - 1; k > -1; k--)
        {
            up++;
            if (lines[i][j] <= lines[k][j])
            {
                break;
            }
        }
        // Look down
        for (var k = i + 1; k < lines.Length; k++)
        {
            down++;
            if (lines[i][j] <= lines[k][j])
            {
                break;
            }
        }
        scenic_scores.Add(left * right * up * down);
    }
}

Console.WriteLine($"The highest scenic score possible for any tree is {scenic_scores.Max()}");