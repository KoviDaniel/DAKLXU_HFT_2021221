using DAKLXU_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAKLXU_HFT_2021221.Repository
{
    public class CarRepository : Repository<Car>, ICarRepository
    {
        public CarRepository(DbContext ctx) : base(ctx) { }

        // from Repository class
        public override Car GetOne(int id)
        {
            return GetAll().SingleOrDefault(car => car.CarID == id);
        }

        //from ICarRepository interface

        public void ChangeCarInsurance(int id, bool newCarInsurance)
        {
            var car = GetOne(id);
            if (car == null) throw new InvalidOperationException("Car not found!");
            car.CarInsurance = newCarInsurance;
            ctx.SaveChanges();
        }

        public void ChangeColour(int id, string newColour)
        {
            var car = GetOne(id);
            if (car == null) throw new InvalidOperationException("Car not found!");
            car.Colour = newColour;
            ctx.SaveChanges();
        }

        public void ChangeModel(int id, string newModel)
        {
            var car = GetOne(id);
            if (car == null) throw new InvalidOperationException("Car not found!");
            car.Model = newModel;
            ctx.SaveChanges();
        }

        public void ChangeRenPrice(int id, int newRentPrice)
        {
            var car = GetOne(id);
            if (car == null) throw new InvalidOperationException("Car not found!");
            car.RentPrice = newRentPrice;
            ctx.SaveChanges();
        }

        public void ChangeRunnedKM(int id, int newRunnedKM)
        {
            var car = GetOne(id);
            if (car == null) throw new InvalidOperationException("Car not found!");
            car.RunnedKM = newRunnedKM;
            ctx.SaveChanges();
        }
    }
}
