using System.Text.RegularExpressions;

string input = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.txt"));

string pattern = @"mul\((\d{1,3}),(\d{1,3})\)";

MatchCollection matches = Regex.Matches(input, pattern);
int result = 0;

foreach (Match match in matches)
{
    Console.WriteLine(match.Value);
    result += Convert.ToInt32(match.Groups[1].Value) * Convert.ToInt32(match.Groups[2].Value);
}

Console.WriteLine(result);