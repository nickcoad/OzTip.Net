using System;
using OzTip.Data;
using OzTip.Models;

namespace OzTip.FixtureImporter.Seeders
{
    public static class VenueSeeder
    {
        public static void Seed(OzTipContext context)
        {
            var venue = new Venue
            {
                Name = "Venue Placeholder"
            };

            context.Venues.Add(venue);
        }
    }
}
