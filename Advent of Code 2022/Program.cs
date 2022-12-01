using Advent_of_Code_2022;
using Advent_of_Code_2022.Code;
using Figgle;

// Stores a dictionary for fast access to every single day. Maps the day to the function's Main().
Dictionary<int, Func<string[], string>> Days = new() {
    { 1, (string[] input) => new Day_1(input).Main() },
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

do {
    // Get the day
    Console.Write($"{FiggleFonts.SBlood.Render("Advent Of")}{FiggleFonts.SBlood.Render("Code 2022")}\nLeave blank for latest day.\nDays: 1 - {Days.Keys.Max()} avaliable.\nDay: ");
    ans = Console.ReadLine();
    day = GetDay(ans);

    Console.Clear();
} while (day == -1);


// Get Data
string[] data = await Data.GetDataAsync(2022, day);

// Failure
if (data == Data.FailedString) {
    Console.WriteLine("Failed to get the data from the remote server");
    Console.ReadLine();
    return;
}

// Get the result/answer from that day
Console.WriteLine($"Answer for day {day}:\n{Days[day](data)}");
Console.ReadLine();


/// Gets the day from the input. Retuns -1 if invalid. Blank returns last day.
int GetDay(string? input) {
    if (input is null) return -1;
    if (input == "") return Days.Last().Key;
    if (int.TryParse(input, out day) && day > 0 && day <= Days.Last().Key) return day;
    return -1;
}