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
                    Number = 1,
                    Start = new DateTime(2016, 3, 24, 19, 20, 0, DateTimeKind.Local),
                    End = new DateTime(2016, 3, 28, 17, 20, 0, DateTimeKind.Local),
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                },
                new Round
                {
                    SeasonId = 1,
                    Name = "Round 2",
                    Number = 2,
                    Start = new DateTime(2016, 4, 1, 19, 50, 0, DateTimeKind.Local),
                    End = new DateTime(2016, 4, 3, 18, 40, 0, DateTimeKind.Local),
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                },
                new Round
                {
                    SeasonId = 1,
                    Name = "Round 3",
                    Number = 3,
                    Start = new DateTime(2016, 4, 8, 19, 50, 0, DateTimeKind.Local),
                    End = new DateTime(2016, 4, 10, 18, 40, 0, DateTimeKind.Local),
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                },
                new Round
                {
                    SeasonId = 1,
                    Name = "Round 4",
                    Number = 4,
                    Start = new DateTime(2016, 4, 15, 20, 10, 0, DateTimeKind.Local),
                    End = new DateTime(2016, 4, 17, 18, 40, 0, DateTimeKind.Local),
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                },
                new Round
                {
                    SeasonId = 1,
                    Name = "Round 5",
                    Number = 5,
                    Start = new DateTime(2016, 4, 22, 19, 50, 0, DateTimeKind.Local),
                    End = new DateTime(2016, 4, 25, 17, 20, 0, DateTimeKind.Local),
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                },
                new Round
                {
                    SeasonId = 1,
                    Name = "Round 6",
                    Number = 6,
                    Start = new DateTime(2016, 4, 29, 19, 50, 0, DateTimeKind.Local),
                    End = new DateTime(2016, 5, 1, 18, 40, 0, DateTimeKind.Local),
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                },
                new Round
                {
                    SeasonId = 1,
                    Name = "Round 7",
                    Number = 7,
                    Start = new DateTime(2016, 5, 6, 19, 50, 0, DateTimeKind.Local),
                    End = new DateTime(2016, 5, 8, 18, 40, 0, DateTimeKind.Local),
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                },
                new Round
                {
                    SeasonId = 1,
                    Name = "Round 8",
                    Number = 8,
                    Start = new DateTime(2016, 5, 13, 19, 50, 0, DateTimeKind.Local),
                    End = new DateTime(2016, 5, 15, 18, 40, 0, DateTimeKind.Local),
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                },
                new Round
                {
                    SeasonId = 1,
                    Name = "Round 9",
                    Number = 9,
                    Start = new DateTime(2016, 5, 20, 19, 50, 0, DateTimeKind.Local),
                    End = new DateTime(2016, 5, 22, 18, 40, 0, DateTimeKind.Local),
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                },
                new Round
                {
                    SeasonId = 1,
                    Name = "Round 10",
                    Number = 10,
                    Start = new DateTime(2016, 5, 27, 19, 50, 0, DateTimeKind.Local),
                    End = new DateTime(2016, 5, 29, 18, 40, 0, DateTimeKind.Local),
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                },
                new Round
                {
                    SeasonId = 1,
                    Name = "Round 11",
                    Number = 11,
                    Start = new DateTime(2016, 6, 3, 19, 50, 0, DateTimeKind.Local),
                    End = new DateTime(2016, 6, 5, 18, 40, 0, DateTimeKind.Local),
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                },
                new Round
                {
                    SeasonId = 1,
                    Name = "Round 12",
                    Number = 12,
                    Start = new DateTime(2016, 6, 10, 19, 50, 0, DateTimeKind.Local),
                    End = new DateTime(2016, 6, 13, 15, 20, 0, DateTimeKind.Local),
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                },
                new Round
                {
                    SeasonId = 1,
                    Name = "Round 13",
                    Number = 13,
                    Start = new DateTime(2016, 6, 17, 19, 50, 0, DateTimeKind.Local),
                    End = new DateTime(2016, 6, 19, 18, 40, 0, DateTimeKind.Local),
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                },
                new Round
                {
                    SeasonId = 1,
                    Name = "Round 14",
                    Number = 14,
                    Start = new DateTime(2016, 6, 23, 19, 50, 0, DateTimeKind.Local),
                    End = new DateTime(2016, 6, 26, 17, 20, 0, DateTimeKind.Local),
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                },
                new Round
                {
                    SeasonId = 1,
                    Name = "Round 15",
                    Number = 15,
                    Start = new DateTime(2016, 6, 30, 20, 10, 0, DateTimeKind.Local),
                    End = new DateTime(2016, 7, 3, 17, 20, 0, DateTimeKind.Local),
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                },
                new Round
                {
                    SeasonId = 1,
                    Name = "Round 16",
                    Number = 16,
                    Start = new DateTime(2016, 7, 7, 19, 50, 0, DateTimeKind.Local),
                    End = new DateTime(2016, 7, 10, 18, 40, 0, DateTimeKind.Local),
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                },
                new Round
                {
                    SeasonId = 1,
                    Name = "Round 17",
                    Number = 17,
                    Start = new DateTime(2016, 7, 14, 19, 20, 0, DateTimeKind.Local),
                    End = new DateTime(2016, 7, 17, 18, 40, 0, DateTimeKind.Local),
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                },
                new Round
                {
                    SeasonId = 1,
                    Name = "Round 18",
                    Number = 18,
                    Start = new DateTime(2016, 7, 22, 19, 50, 0, DateTimeKind.Local),
                    End = new DateTime(2016, 7, 24, 18, 40, 0, DateTimeKind.Local),
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                },
                new Round
                {
                    SeasonId = 1,
                    Name = "Round 19",
                    Number = 19,
                    Start = new DateTime(2016, 7, 29, 19, 50, 0, DateTimeKind.Local),
                    End = new DateTime(2016, 7, 31, 18, 40, 0, DateTimeKind.Local),
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                },
                new Round
                {
                    SeasonId = 1,
                    Name = "Round 20",
                    Number = 20,
                    Start = new DateTime(2016, 8, 5, 19, 50, 0, DateTimeKind.Local),
                    End = new DateTime(2016, 8, 7, 18, 40, 0, DateTimeKind.Local),
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                },
                new Round
                {
                    SeasonId = 1,
                    Name = "Round 21",
                    Number = 21,
                    Start = new DateTime(2016, 8, 12, 19, 50, 0, DateTimeKind.Local),
                    End = new DateTime(2016, 8, 14, 18, 40, 0, DateTimeKind.Local),
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                },
                new Round
                {
                    SeasonId = 1,
                    Name = "Round 22",
                    Number = 22,
                    Start = new DateTime(2016, 8, 19, 20, 10, 0, DateTimeKind.Local),
                    End = new DateTime(2016, 8, 21, 19, 20, 0, DateTimeKind.Local),
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                }
            };

            context.Rounds.AddRange(newRounds);
        }
    }
}
