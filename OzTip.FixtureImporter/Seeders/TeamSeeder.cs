using System.Collections.Generic;
using OzTip.Data;
using OzTip.Models;

namespace OzTip.FixtureImporter.Seeders
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
                    IsCurrent = true
                },
                new Team
                {
                    Code = "COL",
                    LongName = "Collingwood Magpies",
                    ShortName = "Collingwood",
                    Stub = "collingwood-magpies",
                    IsCurrent = true
                },
                new Team
                {
                    Code = "CAR",
                    LongName = "Carlton Blues",
                    ShortName = "Carlton",
                    Stub = "carlton-blues",
                    IsCurrent = true
                },
                new Team
                {
                    Code = "HAW",
                    LongName = "Hawthorn Hawks",
                    ShortName = "Hawthorn",
                    Stub = "hawthorn-hawks",
                    IsCurrent = true
                },
                new Team
                {
                    Code = "WCE",
                    LongName = "West Coast Eagles",
                    ShortName = "Eagles",
                    Stub = "west-coast-eagles",
                    IsCurrent = true
                },
                new Team
                {
                    Code = "SYD",
                    LongName = "Sydney Swans",
                    ShortName = "Swans",
                    Stub = "sydney-swans",
                    IsCurrent = true
                },
                new Team
                {
                    Code = "KAN",
                    LongName = "North Melbourne Kangaroos",
                    ShortName = "Kangaroos",
                    Stub = "north-melbourne-kangaroos",
                    IsCurrent = true
                },
                new Team
                {
                    Code = "WBD",
                    LongName = "Western Bulldogs",
                    ShortName = "Bulldogs",
                    Stub = "western-bulldogs",
                    IsCurrent = true
                },
                new Team
                {
                    Code = "ADE",
                    LongName = "Adelaide Crows",
                    ShortName = "Crows",
                    Stub = "adelaide-crows",
                    IsCurrent = true
                },
                new Team
                {
                    Code = "POR",
                    LongName = "Port Adelaide Power",
                    ShortName = "Port Power",
                    Stub = "port-adelaide-power",
                    IsCurrent = true
                },
                new Team
                {
                    Code = "RIC",
                    LongName = "Richmond Tigers",
                    ShortName = "Tigers",
                    Stub = "richmond-tigers",
                    IsCurrent = true
                },
                new Team
                {
                    Code = "FRE",
                    LongName = "Fremantle Dockers",
                    ShortName = "Fremantle",
                    Stub = "fremantle-dockers",
                    IsCurrent = true
                },
                new Team
                {
                    Code = "GEE",
                    LongName = "Geeling Cats",
                    ShortName = "Cats",
                    Stub = "geelong-cats",
                    IsCurrent = true
                },
                new Team
                {
                    Code = "BRI",
                    LongName = "Brisbane Lions",
                    ShortName = "Brisbane",
                    Stub = "brisbane-lions",
                    IsCurrent = true
                },
                new Team
                {
                    Code = "STK",
                    LongName = "St Kilda Saints",
                    ShortName = "Saints",
                    Stub = "st-kilda-saints",
                    IsCurrent = true
                },
                new Team
                {
                    Code = "MEL",
                    LongName = "Melbourne Demons",
                    ShortName = "Demons",
                    Stub = "melbourne-demons",
                    IsCurrent = true
                },
                new Team
                {
                    Code = "GWS",
                    LongName = "Greater Western Sydney Giants",
                    ShortName = "Giants",
                    Stub = "gws-giants",
                    IsCurrent = true
                },
                new Team
                {
                    Code = "GCS",
                    LongName = "Gold Coast Suns",
                    ShortName = "Gold Coast",
                    Stub = "gold-coast-suns",
                    IsCurrent = true
                }

            };

            context.Teams.AddRange(teams);
        }
    }
}
