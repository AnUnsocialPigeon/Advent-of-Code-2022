using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2022 {
    internal class Data {
        public static string SessionCookieDir => $"{Directory.GetCurrentDirectory()}SessionCookie.txt";
        public static string SessionCookie => File.ReadAllText(SessionCookieDir);
        public static bool SessionCookieExists => File.Exists(SessionCookieDir);

        /// <summary>
        /// Gets the input from the advent of code server.
        /// </summary>
        /// <param name="year"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public static async Task<string[]> GetDataAsync(int year, int day) {
            // File Management
            string dir = $"{Directory.GetCurrentDirectory()}Input_{year}";
            string fileDir = $"{dir}/{day}.txt";
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
            if (File.Exists(fileDir)) return File.ReadAllLines(fileDir);

            // Http session creation
            var httpClient = new HttpClient();
            var url = $"https://adventofcode.com/{year}/day/{day}/input";
            httpClient.DefaultRequestHeaders.Add("Cookie", $"session={SessionCookie}");

            // Fetch Response
            var response = await httpClient.GetAsync(url);
            // Success?
            if (response.IsSuccessStatusCode) {
                string s = await response.Content.ReadAsStringAsync();
                File.WriteAllText(fileDir, s);
            }
            return FailedString;
        }

        public static readonly string[] FailedString = { "Failed" };
    }
}
