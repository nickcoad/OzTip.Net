using System;
using System.Collections.Generic;
using OzTip.Models;

namespace OzTip.Data.Seeders
{
    public static class TeamSeeder
    {
        public static void Seed(OzTipContext context)
        {
            var teams = new List<Team>
            {
                new Team
                {
                    Code = "ESS",
                    LongName = "Essendon Bombers",
                    ShortName = "Bombers",
                    Stub = "essendon-bombers",
                    IsCurrent = true,
                    Created = DateTime.Now,
                    Updated = DateTime.Now
                },
                new Team
                {
                    Code = "COL",
                    LongName = "Collingwood Magpies",
                    ShortName = "Collingwood",
                    Stub = "collingwood-magpies",
                    IsCurrent = true,
                    Created = DateTime.Now,
                    Updated = DateTime.Now
                },
                new Team
                {
                    Code = "CAR",
                    LongName = "Carlton Blues",
                    ShortName = "Carlton",
                    Stub = "carlton-blues",
                    IsCurrent = true,
                    Created = DateTime.Now,
                    Updated = DateTime.Now
                },
                new Team
                {
                    Code = "HAW",
                    LongName = "Hawthorn Hawks",
                    ShortName = "Hawthorn",
                    Stub = "hawthorn-hawks",
                    IsCurrent = true,
                    Created = DateTime.Now,
                    Updated = DateTime.Now
                },
                new Team
                {
                    Code = "WCE",
                    LongName = "West Coast Eagles",
                    ShortName = "Eagles",
                    Stub = "west-coast-eagles",
                    IsCurrent = true,
                    Created = DateTime.Now,
                    Updated = DateTime.Now
                },
                new Team
                {
                    Code = "SYD",
                    LongName = "Sydney Swans",
                    ShortName = "Swans",
                    Stub = "sydney-swans",
                    IsCurrent = true,
                    Created = DateTime.Now,
                    Updated = DateTime.Now
                },
                new Team
                {
                    Code = "KAN",
                    LongName = "North Melbourne Kangaroos",
                    ShortName = "Kangaroos",
                    Stub = "north-melbourne-kangaroos",
                    IsCurrent = true,
                    Created = DateTime.Now,
                    Updated = DateTime.Now
                },
                new Team
                {
                    Code = "WBD",
                    LongName = "Western Bulldogs",
                    ShortName = "Bulldogs",
                    Stub = "western-bulldogs",
                    IsCurrent = true,
                    Created = DateTime.Now,
                    Updated = DateTime.Now
                },
                new Team
                {
                    Code = "ADE",
                    LongName = "Adelaide Crows",
                    ShortName = "Crows",
                    Stub = "adelaide-crows",
                    IsCurrent = true,
                    Created = DateTime.Now,
                    Updated = DateTime.Now
                },
                new Team
                {
                    Code = "POR",
                    LongName = "Port Adelaide Power",
                    ShortName = "Port Power",
                    Stub = "port-adelaide-power",
                    IsCurrent = true,
                    Created = DateTime.Now,
                    Updated = DateTime.Now
                },
                new Team
                {
                    Code = "RIC",
                    LongName = "Richmond Tigers",
                    ShortName = "Tigers",
                    Stub = "richmond-tigers",
                    IsCurrent = true,
                    Created = DateTime.Now,
                    Updated = DateTime.Now
                },
                new Team
                {
                    Code = "FRE",
                    LongName = "Fremantle Dockers",
                    ShortName = "Fremantle",
                    Stub = "fremantle-dockers",
                    IsCurrent = true,
                    Created = DateTime.Now,
                    Updated = DateTime.Now
                },
                new Team
                {
                    Code = "GEE",
                    LongName = "Geeling Cats",
                    ShortName = "Cats",
                    Stub = "geelong-cats",
                    IsCurrent = true,
                    Created = DateTime.Now,
                    Updated = DateTime.Now
                },
                new Team
                {
                    Code = "BRI",
                    LongName = "Brisbane Lions",
                    ShortName = "Brisbane",
                    Stub = "brisbane-lions",
                    IsCurrent = true,
                    Created = DateTime.Now,
                    Updated = DateTime.Now
                },
                new Team
                {
                    Code = "STK",
                    LongName = "St Kilda Saints",
                    ShortName = "Saints",
                    Stub = "st-kilda-saints",
                    IsCurrent = true,
                    Created = DateTime.Now,
                    Updated = DateTime.Now
                },
                new Team
                {
                    Code = "MEL",
                    LongName = "Melbourne Demons",
                    ShortName = "Demons",
                    Stub = "melbourne-demons",
                    IsCurrent = true,
                    Created = DateTime.Now,
                    Updated = DateTime.Now
                },
                new Team
                {
                    Code = "GWS",
                    LongName = "Greater Western Sydney Giants",
                    ShortName = "Giants",
                    Stub = "gws-giants",
                    IsCurrent = true,
                    Created = DateTime.Now,
                    Updated = DateTime.Now
                },
                new Team
                {
                    Code = "GCS",
                    LongName = "Gold Coast Suns",
                    ShortName = "Gold Coast",
                    Stub = "gold-coast-suns",
                    IsCurrent = true,
                    Created = DateTime.Now,
                    Updated = DateTime.Now
                }

            };

            context.Teams.AddRange(teams);
        }
    }
}
