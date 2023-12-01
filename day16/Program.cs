string[] lines = System.IO.File.ReadAllLines(@"input2.txt");
Dictionary<string, int> flow_rates = new Dictionary<string, int>();
Dictionary<string, List<string>> tunnel_leads_to = new Dictionary<string, List<string>>();
// Sort information from file
foreach (var line in lines)
{
    // Remove first letter
    string new_line = line.Substring(1);
    // Find valves by finding upper case letters
    string uppercase = string.Concat(new_line.Where(c => c >= 'A' && c <= 'Z'));
    var valve = uppercase.Substring(0, 2);
    List<string> tunnels = new List<string>();
    for (var i = 3; i < uppercase.Length + 1; i += 2)
    {
        string tunnel_to_valve = uppercase[i - 1].ToString() + uppercase[i].ToString();
        tunnels.Add(tunnel_to_valve);
    }
    tunnel_leads_to.Add(valve, tunnels);
    // Find flow rate
    var splitted_line = line.Split(";");
    var split = splitted_line[0].Split("=");
    var flow_rate = Int32.Parse(split[1]);
    flow_rates.Add(valve, flow_rate);
}

var count = 0;
var pressure = 0;
var start = flow_rates.Keys.First();
List<string> queue = new List<string>() { start };
foreach (var child in tunnel_leads_to[queue[0]])
{
    queue.Add(child);
}
queue.RemoveAt(0);


//     while (count <= 1)
//     {

//     }
