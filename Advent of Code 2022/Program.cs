using Advent_of_Code_2022;
using Advent_of_Code_2022.Code;
using Figgle;

// Stores a dictionary for fast access to every single day. Maps the day to the function's Main().
Dictionary<int, Func<string[], string>> Days = new() {
    { 1, (string[] input) => new Day_1(input).Main() },
    { 2, (string[] input) => new Day_2(input).Main() },
    { 3, (string[] input) => new Day_3(input).Main() },
    { 4, (string[] input) => new Day_4(input).Main() },
    { 5, (string[] input) => new Day_5(input).Main() },
    { 6, (string[] input) => new Day_6(input).Main() },
    { 7, (string[] input) => new Day_7(input).Main() },
    { 8, (string[] input) => new Day_8(input).Main() },
    { 9, (string[] input) => new Day_9(input).Main() },
    { 10, (string[] input) => new Day_10(input).Main() },
};

string? ans;
int day = -1;

// Assures session cookie exists
if (!Data.SessionCookieExists) {
    Console.Write($"Session cookie does not exist.\nPlease add it to: {Data.SessionCookieDir}\nOr, paste it here: ");
    string? Cookie = Console.ReadLine();
    if (Cookie is null || Cookie == "") return;
    File.WriteAllText(Data.SessionCookieDir, Cookie.Trim());
    Console.Clear();
}


Console.CursorVisible = false;
bool LoopCondition = true;
while (LoopCondition) {
    do {
        // Get the day
        Console.Write($"{FiggleFonts.LilDevil.Render("Advent     Of")}{FiggleFonts.Ghost.Render("Code     2022")}\nLeave blank for latest day.\nType 'E' or 'Exit' to Exit\nDays: 1 - {Days.Keys.Max()} avaliable.\nDay: ");
        ans = Console.ReadLine();
        
        if (ans is not null && (ans.ToUpper() == "E" || ans.ToUpper() == "EXIT"))
            return;
        
        day = GetDay(ans);
        Console.Clear();
    } while (day == -1);

    // Get Data
    string[] data = await Data.GetDataAsync(2022, day);

    // Failure
    if (data == Data.FailedString) {
        Console.WriteLine("Failed to get the data from the remote server");
        Console.ReadLine();
        continue;
    }

    // Get the result/answer from that day
    Console.WriteLine($"{FiggleFonts.Alligator3.Render($"D a y   {day}")}");
    Console.WriteLine($"{Days[day](data)}"); // I want everything to happen after the ASCII render
    Console.ReadLine();
    Console.Clear();
}
/// Gets the day from the input. Retuns -1 if invalid. Blank returns last day.
int GetDay(string? input) {
    if (input is null) return -1;
    if (input == "") return Days.Last().Key;
    if (int.TryParse(input, out day) && day > 0 && day <= Days.Last().Key) return day;
    return -1;
}