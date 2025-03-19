string[] input = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.txt"));

static bool IsSequenceSafe(int[] sequence)
{
    if (sequence.Length < 2) return false;

    bool xorCheck = sequence[0] > sequence[1];

    for (int i = 0; i < sequence.Length - 1; i++)
    {
        if (xorCheck ^ (sequence[i] > sequence[i + 1])) return false;
        int diff = Math.Abs(sequence[i] - sequence[i + 1]);
        if (diff > 3 || diff == 0) return false;
    }

    return true;
}


int result = input.Count(line =>
{
    if (string.IsNullOrWhiteSpace(line) || line.Split().Length < 2)
        return false;

    int[] levels = line.Split().Select(int.Parse).ToArray();

    for (int i = 0; i < levels.Length; i++)
    {
        if (IsSequenceSafe(levels))
            return true;
    }
    return false;
});


Console.WriteLine(result);


result = input.Count(line =>
{
    if (string.IsNullOrWhiteSpace(line) || line.Split().Length < 2) return false;
    int[] levels = line.Split().Select(int.Parse).ToArray();

    for (int i = 0; i < levels.Length; i++)
    {
        int[] newSequence = levels.Take(i).Concat(levels.Skip(i + 1)).ToArray();
        if (IsSequenceSafe(newSequence))
            return true;
    }

    return false;
});

Console.WriteLine(result);
