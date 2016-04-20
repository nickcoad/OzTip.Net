using System;
using System.Collections.Generic;
using OzTip.Data;
using OzTip.Models;

namespace OzTip.Web.Seeders
{
    public static class GameSeeder
    {
        public static void Seed(OzTipContext context)
        {
            var games = new List<Game>
            {
                new Game()
                {
                    RoundId = 1,
                    VenueId = 2,
                    Start = DateTime.Now.AddDays(-3),
                    End = DateTime.Now.AddHours(2).AddDays(-3)
                },
                new Game()
                {
                    RoundId = 1,
                    VenueId = 1,
                    Start = DateTime.Now.AddDays(-2),
                    End = DateTime.Now.AddHours(2).AddDays(-2)
                },
                new Game()
                {
                    RoundId = 1,
                    VenueId = 2,
                    Start = DateTime.Now.AddDays(-1),
                    End = DateTime.Now.AddHours(2).AddDays(-1)
                },
                new Game()
                {
                    RoundId = 1,
                    VenueId = 1,
                    Start = DateTime.Now,
                    End = DateTime.Now.AddHours(2)
                },
                new Game()
                {
                    RoundId = 1,
                    VenueId = 2,
                    Start = DateTime.Now.AddDays(1),
                    End = DateTime.Now.AddHours(2).AddDays(1)
                },
                new Game()
                {
                    RoundId = 1,
                    VenueId = 1,
                    Start = DateTime.Now.AddDays(2),
                    End = DateTime.Now.AddHours(2).AddDays(2)
                },
                new Game()
                {
                    RoundId = 1,
                    VenueId = 2,
                    Start = DateTime.Now.AddDays(3),
                    End = DateTime.Now.AddHours(2).AddDays(3)
                },
                new Game()
                {
                    RoundId = 1,
                    VenueId = 1,
                    Start = DateTime.Now.AddDays(4),
                    End = DateTime.Now.AddHours(2).AddDays(4)
                },
                new Game()
                {
                    RoundId = 2,
                    VenueId = 2,
                    Start = DateTime.Now.AddDays(5),
                    End = DateTime.Now.AddHours(2).AddDays(5)
                },
                new Game()
                {
                    RoundId = 2,
                    VenueId = 1,
                    Start = DateTime.Now.AddDays(6),
                    End = DateTime.Now.AddHours(2).AddDays(6)
                },
                new Game()
                {
                    RoundId = 2,
                    VenueId = 2,
                    Start = DateTime.Now.AddDays(7),
                    End = DateTime.Now.AddHours(2).AddDays(7)
                },
                new Game()
                {
                    RoundId = 2,
                    VenueId = 1,
                    Start = DateTime.Now.AddDays(8),
                    End = DateTime.Now.AddHours(2).AddDays(8)
                },
                new Game()
                {
                    RoundId = 2,
                    VenueId = 2,
                    Start = DateTime.Now.AddDays(9),
                    End = DateTime.Now.AddHours(2).AddDays(9)
                },
                new Game()
                {
                    RoundId = 2,
                    VenueId = 1,
                    Start = DateTime.Now.AddDays(10),
                    End = DateTime.Now.AddHours(2).AddDays(10)
                },
                new Game()
                {
                    RoundId = 2,
                    VenueId = 2,
                    Start = DateTime.Now.AddDays(11),
                    End = DateTime.Now.AddHours(2).AddDays(11)
                },
                new Game()
                {
                    RoundId = 2,
                    VenueId = 1,
                    Start = DateTime.Now.AddDays(12),
                    End = DateTime.Now.AddHours(2).AddDays(12)
                }
            };

            context.Games.AddRange(games);
        }
    }
}
