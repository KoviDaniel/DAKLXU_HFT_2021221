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

        public void CarUpdate(/*int id,*/ Car newCar)
        {
            //var car = GetOne(id);
            //car.BrandId = newCar.BrandId;
            //car.RentCarID = newCar.RentCarID;         
            //car.Model = newCar.Model;
            //car.RentPrice = newCar.RentPrice;
            //car.Colour = newCar.Colour;
            //car.CarInsurance = newCar.CarInsurance;
            //car.RunnedKM = newCar.RunnedKM;
            //ctx.SaveChanges();

            var old = GetOne(newCar.CarID);
            foreach (var prop in old.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(newCar));
                }
            }
            ctx.SaveChanges();
        }

        // from Repository class
        public override Car GetOne(int id)
        {
            return GetAll().SingleOrDefault(car => car.CarID == id);
        }
    }
}
