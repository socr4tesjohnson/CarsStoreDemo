using Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public class CarsContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarColor> CarColors { get; set; }
        public DbSet<CarMake> CarMakes { get; set; }
        public DbSet<CarType> CarTypes { get; set; }

        public CarsContext(DbContextOptions<CarsContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarColor>()
                .HasData(new CarColor()
                {
                    Id = 1,
                    Description = "White"
                },
                new CarColor()
                {
                    Id = 2,
                    Description = "Black"
                },
                new CarColor()
                {
                    Id = 3,
                    Description = "Silver"
                },
                new CarColor()
                {
                    Id = 4,
                    Description = "Red"
                });

            modelBuilder.Entity<CarMake>()
                .HasData(new CarMake()
                {
                    Id = 1,
                    Description = "Ford"
                },
                new CarMake()
                {
                    Id = 2,
                    Description = "Tesla"
                },
                new CarMake()
                {
                    Id = 3,
                    Description = "Dodge"
                },
                new CarMake()
                {
                    Id = 4,
                    Description = "BMW"
                });

            modelBuilder.Entity<CarType>()
                .HasData(new CarType()
                {
                    Id = 1,
                    Description = "SUV"
                },
                new CarType()
                {
                    Id = 2,
                    Description = "Sedan"
                },
                new CarType()
                {
                    Id = 3,
                    Description = "Truck"
                },
                new CarType()
                {
                    Id = 4,
                    Description = "Convertible"
                });


            base.OnModelCreating(modelBuilder);
        }

    }
}
