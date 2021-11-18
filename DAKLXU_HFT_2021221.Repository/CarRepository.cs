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

        public void CarUpdate(int id, Car newCar)
        {
            var car = GetOne(id);
            //car.BrandId = newCar.BrandId;
           // car.Brand = newCar.Brand;
            //car.RentCarID = newCar.RentCarID;
           // car.RentACar = newCar.RentACar;
            car.Model = newCar.Model;
            car.RentPrice = newCar.RentPrice;
            car.Colour = newCar.Colour;
            car.CarInsurance = newCar.CarInsurance;
            car.RunnedKM = newCar.RunnedKM;
        }

        // from Repository class
        public override Car GetOne(int id)
        {
            return GetAll().SingleOrDefault(car => car.CarID == id);
        }




       /* public void ChangeCarInsurance(int id, bool newCarInsurance)
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

        public void ChangeRentPrice(int id, int newRentPrice)
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

        public void ChangeBrandId(int id, int newId)
        {
            var car = GetOne(id);
            if (car == null) throw new InvalidOperationException("Car not found!");
            car.BrandId = newId;
            ctx.SaveChanges();
        }

        public void ChangeRentACarId(int id, int newId)
        {
            var car = GetOne(id);
            if (car == null) throw new InvalidOperationException("Car not found!");
            car.RentCarID = newId;
            ctx.SaveChanges();
        }

        public void ChangeBrand(int id, Brand newBrand)
        {
            var car = GetOne(id);
            if (car == null) throw new InvalidOperationException("Car not found!");
            car.Brand = newBrand;
            car.BrandId = newBrand.BrandID;
            ctx.SaveChanges();
        }

        public void ChangeRentACar(int id, RentACar newRentACar)
        {
            var car = GetOne(id);
            if (car == null) throw new InvalidOperationException("Car not found!");
            car.RentACar = newRentACar;
            car.RentCarID = newRentACar.RentCarID;
            ctx.SaveChanges();
        }*/
    }
}
