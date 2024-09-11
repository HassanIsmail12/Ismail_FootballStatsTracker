using System;
using System.Collections.Generic;

namespace FootballStatsTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Match> matches = new List<Match>();
            bool running = true;

            while (running)
            {
                DisplayMenu();
                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        AddMatch(matches);
                        break;
                    case "2":
                        ViewMatches(matches);
                        break;
                    case "3":
                        running = false;
                        break;
                    default:
                        ShowError("Invalid option. Please try again.");
                        break;
                }
            }

            ShowMessage("Thank you for using the Football Stats Tracker!");
        }

        static void DisplayMenu()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Football Stats Tracker");
            Console.WriteLine("1. Add Match");
            Console.WriteLine("2. View Matches");
            Console.WriteLine("3. Exit");
            Console.ResetColor();
            Console.Write("Choose an option: ");
        }

        static void AddMatch(List<Match> matches)
        {
            Console.Clear();
            Console.WriteLine("Add New Match");
            Console.Write("Enter the home team: ");
            string homeTeam = Console.ReadLine();

            Console.Write("Enter the away team: ");
            string awayTeam = Console.ReadLine();

            Console.Write("Enter the home team score: ");
            if (!int.TryParse(Console.ReadLine(), out int homeScore))
            {
                ShowError("Invalid score. Please enter a number.");
                return;
            }

            Console.Write("Enter the away team score: ");
            if (!int.TryParse(Console.ReadLine(), out int awayScore))
            {
                ShowError("Invalid score. Please enter a number.");
                return;
            }

            Console.Write("Enter the match date (yyyy-MM-dd): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime matchDate))
            {
                ShowError("Invalid date. Please enter the date in yyyy-MM-dd format.");
                return;
            }

            matches.Add(new Match
            {
                HomeTeam = homeTeam,
                AwayTeam = awayTeam,
                HomeScore = homeScore,
                AwayScore = awayScore,
                MatchDate = matchDate
            });

            ShowMessage("Match added successfully!");
        }

        static void ViewMatches(List<Match> matches)
        {
            Console.Clear();
            Console.WriteLine("Match Summary");
            if (matches.Count == 0)
            {
                ShowMessage("No matches to display.");
                return;
            }

            foreach (var match in matches)
            {
                Console.WriteLine($"{match.MatchDate:yyyy-MM-dd}: {match.HomeTeam} {match.HomeScore} - {match.AwayScore} {match.AwayTeam}");
            }

            ShowMessage("Press any key to return to the menu.");
            Console.ReadKey();
        }

        static void ShowMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        static void ShowError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }

    class Match
    {
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
        public DateTime MatchDate { get; set; }
    }
}
