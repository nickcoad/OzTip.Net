using System;
using OzTip.Models;

namespace OzTip.Data.Seeders
{
    public static class SeasonSeeder
    {
        public static void Seed(OzTipContext context)
        {
            var season = new Season
            {
                Name = "AFL Premiership Season 2016",
                Start = DateTime.Now,
                End = DateTime.Now,
                Created = DateTime.Now,
                Updated = DateTime.Now
            };

            context.Seasons.Add(season);
        }
    }
}
