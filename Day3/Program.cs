using System.Text.RegularExpressions;

string input = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.txt"));

string mulPattern = @"mul\((\d{1,3}),(\d{1,3})\)";

MatchCollection matches = Regex.Matches(input, mulPattern);
int result = 0;

foreach (Match match in matches)
{
    result += Convert.ToInt32(match.Groups[1].Value) * Convert.ToInt32(match.Groups[2].Value);
}

Console.WriteLine(result);

string enhancedMulPattern = @"(mul\(\d{1,3},\d{1,3}\)|don't\(\)|do\(\))";
matches = Regex.Matches(input, enhancedMulPattern);
bool enableMul = true;
result = 0;

foreach (Match match in matches)
{
    string token = match.Value;

    if(token == "don't()")
    {
        enableMul = false;
    }

    else if(token == "do()")
    {
        enableMul = true;
    }

    else if(enableMul && token.StartsWith("mul("))
    {
        Match numbersMatch = Regex.Match(token, mulPattern);

        if (numbersMatch.Success)
        {
            int num1 = int.Parse(numbersMatch.Groups[1].Value);
            int num2 = int.Parse(numbersMatch.Groups[2].Value);
            int product = num1 * num2;

            result += product;
        }
    }
}

Console.WriteLine(result);