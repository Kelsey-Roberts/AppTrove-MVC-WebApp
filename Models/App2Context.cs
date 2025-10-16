using AppTroveV1.Models;
using Microsoft.EntityFrameworkCore;

namespace AppTroveV1.Models
{
    public class App2Context: DbContext
    {
        public App2Context(DbContextOptions<App2Context> options) : base(options) { }

        public DbSet<App> Apps { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<App>().HasData(
                new App
                {
                    AppId = 1,
                    Name = "Angry Birds",
                    Price = 0,
                    Publisher = "Rovio Entertainment"
                },
                new App
                {
                    AppId = 2,
                    Name = "Summoner's War",
                    Price = 0,
                    Publisher = "Com2Us"
                },
                  new App
                  {
                      AppId = 3,
                      Name = "Pokemon Go",
                      Price = 0,
                      Publisher = "Niantic"
                  },
                  new App
                  {
                      AppId = 4,
                      Name = "Genshin Impact",
                      Price = 0,
                      Publisher = "Mihoyo"
                  },
                  new App
                  {
                      AppId = 5,
                      Name = "Paprika Recipe Manager 3",
                      Price = 4.99,
                      Publisher = "Hindsight Labs LLC"
                  },
                  new App
                  {
                      AppId = 6,
                      Name = "RadarScope",
                      Price = 9.99,
                      Publisher = "Base Velocity, LLC"
                  }

                );
        }
    }
}

