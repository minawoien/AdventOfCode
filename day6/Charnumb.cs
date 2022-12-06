static class Charnumb
{
    public static int NumberOfChar(string datastream, int distinct_char)
    {
        string marker = "";
        for (var i = 0; i < datastream.Length; i++)
        {
            if (marker.Contains(datastream[i]))
            {
                int index = marker.IndexOf(datastream[i]);
                marker = marker.Remove(0, index + 1);
            }
            marker += datastream[i];
            if (marker.Length >= distinct_char)
            {
                return i;
            }
        }
        return 0;
    }
}