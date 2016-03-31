using System;
using OzTip.Data;
using OzTip.Models;

namespace OzTip.FixtureImporter.Seeders
{
    public static class SeasonSeeder
    {
        public static void Seed(OzTipContext context)
        {
            var season = new Season
            {
                Name = "AFL Premiership Season 2016",
                Start = new DateTime(2016, 3, 24, 19, 20, 0, DateTimeKind.Local),
                End = new DateTime(2016, 8, 21, 19, 20, 0, DateTimeKind.Local)
            };

            context.Seasons.Add(season);
        }
    }
}
