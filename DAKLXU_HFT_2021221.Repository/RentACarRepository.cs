using DAKLXU_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAKLXU_HFT_2021221.Repository
{
    public class RentACarRepository : Repository<RentACar>, IRentACarRepository
    {
        public RentACarRepository(DbContext ctx) : base(ctx) { }

        /*public void ChangeCarsCollection(int id, ICollection<Car> newCars)
        {
            var rentACar = GetOne(id);
            if (rentACar == null) throw new InvalidOperationException("Rent-a-car not found!");
            rentACar.Cars = newCars;
            ctx.SaveChanges();
        }

        public void ChangeRating(int id, int newRating)
        {
            var rent = GetOne(id);
            if (rent == null) throw new InvalidOperationException("Rent-a-car not found!");
            rent.Rating = newRating;
            ctx.SaveChanges();
        }

        public void ChangeRentName(int id, string newRentName)
        {
            var rent = GetOne(id);
            if (rent == null) throw new InvalidOperationException("Rent-a-car not found!");
            rent.RentName = newRentName;
            ctx.SaveChanges();
        }*/

        public void RentACarUpdate(int id, RentACar newRent) {
            var rentToUpdate = GetOne(id);
            rentToUpdate.RentName = newRent.RentName;
            rentToUpdate.Rating = newRent.Rating;
            rentToUpdate.Cars = newRent.Cars;
            ctx.SaveChanges();
        }

        public override RentACar GetOne(int id)
        {
            return GetAll().SingleOrDefault(rent => rent.RentCarID == id);
        }
    }
}
