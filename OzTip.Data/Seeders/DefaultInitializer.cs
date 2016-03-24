using System.Data.Entity;

namespace OzTip.Data.Seeders
{
    public class DefaultInitializer : DropCreateDatabaseAlways<OzTipContext>
    {
        protected override void Seed(OzTipContext context)
        {
            SeasonSeeder.Seed(context);
            context.SaveChanges();

            RoundSeeder.Seed(context);
            context.SaveChanges();

            TeamSeeder.Seed(context);
            context.SaveChanges();

            UserSeeder.Seed(context);
            context.SaveChanges();
        }
    }
}
