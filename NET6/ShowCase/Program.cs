using StringLibraries;

int row = 0;

do
{
    if (row == 0 || row >= 25)
    {
        ResetConsole();
    }
    string? input = Console.ReadLine();

    if (string.IsNullOrEmpty(input)) break;
    Console.WriteLine($"Input: {input} {"첫글자가 영문대문자인가? ",30}: " +
                      $"{(input.StartsWithUpper() ? "Yes" : "No")}{Environment.NewLine}");
    row += 3;
} while (true);
return;

void ResetConsole()
{
    if (row > 0)
    {
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
    Console.Clear();
    Console.WriteLine($"{Environment.NewLine}엔터 키만 누르면 종료 :{Environment.NewLine}");
    row = 3;
}
