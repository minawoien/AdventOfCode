string datastream = System.IO.File.ReadAllText(@"input.txt");
int start_of_packet = Charnumb.NumberOfChar(datastream, 4);
int start_of_message = Charnumb.NumberOfChar(datastream, 14);
Console.WriteLine($"The number of characters that needs to be processed before the first start-of-packet marker is detected is {start_of_packet}");
Console.WriteLine($"The number of characters that needs to be processed before the first start-of-message marker is detected is {start_of_message}");
