namespace ServiceLibrary;

public static class PriceSnapshotValidator
{
    public static string[] SymbolsToReject = new string[] { "APLT", "NLB", "AC" };

    public static void Validate(string? name, string?[] symbols)
    {
        if (string.IsNullOrEmpty(name) || !symbols.Any() && symbols.Where(s => s.Length < 3).Any())
        {
            throw new ArgumentNullException(nameof(name));
        }

        for (int i = 0; i < symbols.Length; i++)
        {
            if (SymbolsToReject.Contains(symbols[i]))
            {
                throw new Exception($"This symbol has been blacklisted {symbols[i]}.");
            }
        }
    }
}

