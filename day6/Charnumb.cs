static class Charnumb
{
    public static int NumberOfChar(string line, int distinct_char)
    {
        string word = "";
        int count = 0;
        foreach (var letter in line)
        {
            if (word.Contains(letter))
            {
                int index = word.IndexOf(letter);
                word = word.Remove(0, index + 1);
            }
            word += letter;
            count += 1;

            // For part 1, change to 4 instead of 14
            if (word.Length >= distinct_char)
            {
                break;
            }
        }
        return count;
    }
}