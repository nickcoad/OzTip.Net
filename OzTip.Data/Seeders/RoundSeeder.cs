using System;
using System.Collections.Generic;
using OzTip.Models;

namespace OzTip.Data.Seeders
{
    public static class RoundSeeder
    {
        public static void Seed(OzTipContext context)
        {
            var newRounds = new List<Round>
            {
                new Round
                {
                    SeasonId = 1,
                    Name = "Round 1",
                    Start = DateTime.Now,
                    End = DateTime.Now,
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                },
                new Round
                {
                    SeasonId = 1,
                    Name = "Round 2",
                    Start = DateTime.Now,
                    End = DateTime.Now,
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                },
                new Round
                {
                    SeasonId = 1,
                    Name = "Round 3",
                    Start = DateTime.Now,
                    End = DateTime.Now,
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                },
                new Round
                {
                    SeasonId = 1,
                    Name = "Round 4",
                    Start = DateTime.Now,
                    End = DateTime.Now,
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                },
                new Round
                {
                    SeasonId = 1,
                    Name = "Round 5",
                    Start = DateTime.Now,
                    End = DateTime.Now,
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                },
                new Round
                {
                    SeasonId = 1,
                    Name = "Round 6",
                    Start = DateTime.Now,
                    End = DateTime.Now,
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                },
                new Round
                {
                    SeasonId = 1,
                    Name = "Round 7",
                    Start = DateTime.Now,
                    End = DateTime.Now,
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                },
                new Round
                {
                    SeasonId = 1,
                    Name = "Round 8",
                    Start = DateTime.Now,
                    End = DateTime.Now,
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                },
                new Round
                {
                    SeasonId = 1,
                    Name = "Round 9",
                    Start = DateTime.Now,
                    End = DateTime.Now,
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                },
                new Round
                {
                    SeasonId = 1,
                    Name = "Round 10",
                    Start = DateTime.Now,
                    End = DateTime.Now,
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                },
                new Round
                {
                    SeasonId = 1,
                    Name = "Round 11",
                    Start = DateTime.Now,
                    End = DateTime.Now,
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                },
                new Round
                {
                    SeasonId = 1,
                    Name = "Round 12",
                    Start = DateTime.Now,
                    End = DateTime.Now,
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                },
                new Round
                {
                    SeasonId = 1,
                    Name = "Round 13",
                    Start = DateTime.Now,
                    End = DateTime.Now,
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                },
                new Round
                {
                    SeasonId = 1,
                    Name = "Round 14",
                    Start = DateTime.Now,
                    End = DateTime.Now,
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                },
                new Round
                {
                    SeasonId = 1,
                    Name = "Round 15",
                    Start = DateTime.Now,
                    End = DateTime.Now,
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                },
                new Round
                {
                    SeasonId = 1,
                    Name = "Round 16",
                    Start = DateTime.Now,
                    End = DateTime.Now,
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                },
                new Round
                {
                    SeasonId = 1,
                    Name = "Round 17",
                    Start = DateTime.Now,
                    End = DateTime.Now,
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                },
                new Round
                {
                    SeasonId = 1,
                    Name = "Round 18",
                    Start = DateTime.Now,
                    End = DateTime.Now,
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                },
                new Round
                {
                    SeasonId = 1,
                    Name = "Round 1",
                    Start = DateTime.Now,
                    End = DateTime.Now,
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                },
                new Round
                {
                    SeasonId = 1,
                    Name = "Round 19",
                    Start = DateTime.Now,
                    End = DateTime.Now,
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                },
                new Round
                {
                    SeasonId = 1,
                    Name = "Round 20",
                    Start = DateTime.Now,
                    End = DateTime.Now,
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                },
                new Round
                {
                    SeasonId = 1,
                    Name = "Round 21",
                    Start = DateTime.Now,
                    End = DateTime.Now,
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                },
                new Round
                {
                    SeasonId = 1,
                    Name = "Round 22",
                    Start = DateTime.Now,
                    End = DateTime.Now,
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                },
                new Round
                {
                    SeasonId = 1,
                    Name = "Round 23",
                    Start = DateTime.Now,
                    End = DateTime.Now,
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                }
            };

            context.Rounds.AddRange(newRounds);
        }
    }
}
