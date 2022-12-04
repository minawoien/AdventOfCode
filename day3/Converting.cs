static class Converting
{
    public static int ConvertToInt(List<Char> letters)
    {
        int sum = 0;
        foreach (var letter in letters)
        {
            if (Char.IsUpper(letter))
            {
                sum += System.Convert.ToInt32(letter) - 38;
            }
            else
            {
                sum += System.Convert.ToInt32(letter) - 96;
            }
        }
        return sum;
    }
}