using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAKLXU_HFT_2021221.Models;

namespace DAKLXU_HFT_2021221.Data
{
    public class XYZDbContext : DbContext
    {
        //Constructor
        public XYZDbContext() {
            this.Database.EnsureCreated();
        }
        public XYZDbContext(DbContextOptions<XYZDbContext> options) : base(options) { }


        public virtual DbSet<Brand> Brand { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<RentACar> RentCar { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            if (!optionsBuilder.IsConfigured) {
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CarDb.mdf;Integrated Security=True; MultipleActiveResultSets=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
           
            //Base elements 
            Brand vw = new Brand() { BrandID = 1, BrandName = "Volkswagen"};
            Brand audi = new Brand() { BrandID = 2, BrandName = "Audi"};
            Brand ford = new Brand() { BrandID = 3, BrandName = "Ford"};
            Brand bmw = new Brand() { BrandID = 4, BrandName = "BMW"};
            Brand fiat = new Brand() { BrandID = 5, BrandName = "Fiat"};
            Brand tesla = new Brand() { BrandID = 6, BrandName = "Tesla"};

            RentACar rent1 = new RentACar() { RentCarID = 1, RentName = "R3nt-4-C4r"};
            RentACar rent2 = new RentACar() { RentCarID = 2, RentName = "Józsi bácsi autókölcsönzője"};

            Car vw1 = new Car()
            {
                CarID = 1,
                BrandId = vw.BrandID,
                RentCarID = rent1.RentCarID,
                RentPrice = 15000,
                Model = "Volkswagen T5",
                Colour = "Dark-blue",
                CarInsurance = true,
                RunnedKM = 100000
            };
            Car audi1 = new Car()
            {
                CarID = 2,
                BrandId = audi.BrandID,
                RentCarID = rent2.RentCarID,
                RentPrice = 16700,
                Model = "Audi A4",
                Colour = "Gray",
                CarInsurance = true,
                RunnedKM = 104050
            };
            Car fiat1 = new Car()
            {
                CarID = 3,
                BrandId = fiat.BrandID,
                RentCarID = rent2.RentCarID,
                RentPrice = 5000,
                Model = "Fiat Multipla",
                Colour = "Red",
                CarInsurance = false,
                RunnedKM = 10405
            };
            Car ford1 = new Car()
            {
                CarID = 4,
                BrandId = ford.BrandID,
                RentCarID = rent1.RentCarID,
                RentPrice = 7500,
                Model = "Ford C-Max",
                Colour = "Green",
                CarInsurance = true,
                RunnedKM = 104035
            };
            Car ford2 = new Car()
            {
                CarID = 5,
                BrandId = ford.BrandID,
                RentCarID = rent1.RentCarID,
                RentPrice = 10000,
                Model = "Ford Escort",
                Colour = "Blue",
                CarInsurance = true,
                RunnedKM = 200000
            };
            Car bmw1 = new Car()
            {
                CarID = 6,
                BrandId = bmw.BrandID,
                RentCarID = rent2.RentCarID,
                RentPrice = 15000,
                Model = "BMW 324",
                Colour = "Grey",
                CarInsurance = true,
                RunnedKM = 69420
            };
            Car tesla1 = new Car()
            {
                CarID = 7,
                BrandId = tesla.BrandID,
                RentCarID = rent1.RentCarID,
                RentPrice = 50000,
                Model = "Tesla Cybertruck",
                Colour = "Grey",
                CarInsurance = true,
                RunnedKM = 40467
            };


            //Connections
            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasOne(car => car.Brand)
                    .WithMany(brand => brand.Cars)
                    .HasForeignKey(car => car.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });
            modelBuilder.Entity<Car>(entity => {
                entity.HasOne(car => car.RentACar)
                    .WithMany(rent => rent.Cars)
                    .HasForeignKey(car => car.RentCarID)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            //insert elements
            modelBuilder.Entity<Brand>().HasData(vw, audi, ford, bmw, fiat, tesla);
            modelBuilder.Entity<RentACar>().HasData(rent1, rent2);
            modelBuilder.Entity<Car>().HasData(vw1, audi1, fiat1, ford1, ford2, bmw1, tesla1);
           
        }
    }
}
