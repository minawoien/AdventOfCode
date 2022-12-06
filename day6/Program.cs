string[] lines = System.IO.File.ReadAllLines(@"input.txt");
foreach (var line in lines)
{
    int start_of_packet = Charnumb.NumberOfChar(line, 4);
    int start_of_message = Charnumb.NumberOfChar(line, 14);
    Console.WriteLine($"The number of characters that needs to be processed before the first start-of-packet marker is detected is {start_of_packet}");
    Console.WriteLine($"The number of characters that needs to be processed before the first start-of-message marker is detected is {start_of_message}");
}