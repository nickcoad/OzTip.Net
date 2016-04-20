using System;
using System.Collections.Generic;
using OzTip.Data;
using OzTip.Models;

namespace OzTip.Web.Seeders
{
    public static class VenueSeeder
    {
        public static void Seed(OzTipContext context)
        {
            var venues = new List<Venue>
            {
                new Venue()
                {
                    Name = "Venue 1",
                    Stub = "venue-1",
                    TimeZone = "Australia/Hobart",
                    IsCurrent = true
                },
                new Venue()
                {
                    Name = "Venue 2",
                    Stub = "venue-2",
                    TimeZone = "Australia/Melbourne",
                    IsCurrent = true
                }
            };

            context.Venues.AddRange(venues);
        }
    }
}
