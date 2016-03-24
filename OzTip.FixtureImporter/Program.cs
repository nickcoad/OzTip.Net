using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Reflection.Emit;
using System.Threading;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;
using OzTip.Data;
using OzTip.Data.Seeders;
using OzTip.Models;
using TableParser;

namespace OzTip.FixtureImporter
{
    class Program
    {
        // If modifying these scopes, delete your previously saved credentials
        // at ~/.credentials/calendar-dotnet-quickstart.json
        static readonly string[] Scopes = { CalendarService.Scope.CalendarReadonly };
        private const string ApplicationName = "OzTip Fixture Importer";

        static void Main()
        {
            Database.SetInitializer(new DefaultInitializer());

            UserCredential credential;

            using (var stream =
                new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
            {
                var credPath = Environment.GetFolderPath(
                    Environment.SpecialFolder.Personal);
                credPath = Path.Combine(credPath, ".credentials/calendar-dotnet-quickstart.json");

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            // Create Google Calendar API service.
            var service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            var calendarListRequest = service.CalendarList.List();
            var calendarListResponse = calendarListRequest.Execute();

            var calendars = calendarListResponse.Items;

            if (calendars == null || calendars.Count == 0)
            {
                Console.WriteLine("No calendars found.");
                Console.Read();

                return;
            }
                
            Console.WriteLine("---");
            Console.WriteLine("Select the calendar that you would like to import the fixture from:");

            for (var i = 0; i < calendars.Count; i++)
            {
                var calendar = calendars[i];
                Console.WriteLine("{0}: {1}", i, calendar.Summary);
            }

            Console.WriteLine("---");

            int calendarSelection;

            do
            {
                Console.Write("Enter your selection then press ENTER: ");
            } while (!int.TryParse(Console.ReadLine(), out calendarSelection) || (calendarSelection < 0 || calendarSelection > calendars.Count));
            
            // Define parameters of request.
            var request = service.Events.List(calendars[calendarSelection].Id);
            request.TimeMin = new DateTime(2016, 1, 1, 0, 0, 0);
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.MaxResults = 100;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            // List events.
            var events = request.Execute();
            Console.WriteLine("{0} events found.", events.Items.Count);
            Console.ReadLine();

            Console.WriteLine("Upcoming events:");
            
            var teamRepo = new RepositoryBase<Team>();
            var teams = teamRepo.Get();

            var roundRepo = new RepositoryBase<Round>();
            var rounds = roundRepo.Get();
            
            if (events.Items != null && events.Items.Count > 0)
            {
                var games = events.Items;
                var newGames = new List<Game>();
                
                foreach (var game in games)
                {
                    var teamCodeRegex = new Regex("([A-Z]{3})");
                    var team1Code = teamCodeRegex.Matches(game.Summary)[0].Value;
                    var team2Code = teamCodeRegex.Matches(game.Summary)[1].Value;
                    
                    var when = game.Start.DateTime.ToString();
                    if (string.IsNullOrEmpty(when))
                    {
                        when = game.Start.Date;
                    }

                    var homeTeam = teams.Single(te => te.Code == team1Code);
                    var awayTeam = teams.Single(te => te.Code == team2Code);

                    var homeScore = new Score
                    {
                        TeamId = homeTeam.Id,
                        Team = homeTeam,
                        IsHome = true
                    };

                    var awayScore = new Score
                    {
                        TeamId = awayTeam.Id,
                        Team = awayTeam,
                        IsHome = false
                    };

                    var gameRound = rounds.First(ro => ro.Start <= game.Start.DateTime.Value && ro.End >= game.Start.DateTime.Value);

                    var newGame = new Game
                    {
                        RoundId = gameRound.Id,
                        Round = gameRound,
                        Scores = new List<Score> { homeScore, awayScore },
                        Start = game.Start.DateTime.Value.ToLocalTime(),
                        End = game.End.DateTime.Value.ToLocalTime()
                    };

                    newGames.Add(newGame);
                    
                    Console.WriteLine(game.Start.DateTime);
                    //Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}",
                    //    game.Start.DateTime.Value.ToShortDateString(),
                    //    game.End.DateTime.Value.ToShortDateString(),
                    //    homeTeam.ShortName,
                    //    awayTeam.ShortName);

                    //Console.WriteLine("{0} ({1}) {2}", gameSummary, when, game.Start.TimeZone);
                }

                Console.Write(newGames.ToStringTable(
                    ga => ga.Round.Name,
                    ga => ga.Start,
                    ga => ga.End,
                    ga => ga.HomeTeam.ShortName,
                    ga => ga.AwayTeam.ShortName
                ));
            }
            else
            {
                Console.WriteLine("No upcoming events found.");
            }

            var seasonRepo = new RepositoryBase<Season>();
            var seasons = seasonRepo.Get();
            var userRepo = new RepositoryBase<User>();
            var users = userRepo.Get();
            
            foreach (var season in seasons)
            {
                Console.WriteLine(season.Name);
            }
            Console.Read();

        }
    }
}
