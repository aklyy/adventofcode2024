

string[] input = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.txt"));

List<Int32> firstList = new List<Int32>();
List<Int32> secondList = new List<Int32>();

foreach (string line in input)
{
    string[] tokens = line.Split();
    firstList.Add(Int32.Parse(tokens[0]));
    secondList.Add(Int32.Parse(tokens[3]));
}

firstList.Sort();
secondList.Sort();

Int32 totalDistance = 0;
for (int i = 0; i < firstList.Count; i++)
{
    totalDistance += Math.Abs(firstList[i] - secondList[i]);
}

Console.WriteLine("Part 1: " + totalDistance);

int simillarityScore = firstList
    .Sum(first => first * secondList.Count(second => second == first));

Console.WriteLine("Part 2: " + simillarityScore);



