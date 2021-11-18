using DAKLXU_HFT_2021221.Models;
using DAKLXU_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAKLXU_HFT_2021221.Logic
{
    public class CarLogic : ICarLogic
    {
        #region CTOR & REPO (carRepo, brandRepo, rentRepo)
        ICarRepository carRepo;

        public CarLogic(ICarRepository carRepo)
        {
            this.carRepo = carRepo;
        }
        #endregion

        //read, create, delete
        public Car GetOne(int id) {
            if (id < 1) throw new ArgumentException("Invalid ID");
            return carRepo.GetOne(id);
        }
        public List<Car> GetAll() {
            return carRepo.GetAll().ToList();
        }

        public void Insert(Car newCar) {
            if (newCar == null) throw new ArgumentNullException("Null car (INSERT)");
            if (newCar.Model == null) throw new ArgumentNullException("Invalid model name");
            if (newCar.Model == "") throw new ArgumentException("Model can't be empty string");
            if (newCar.RentPrice < 0) throw new ArgumentOutOfRangeException("Rent price can't be less then null");
            if (newCar.Colour == null) throw new ArgumentNullException("Colour can't be null");
            if (newCar.RunnedKM < 0) throw new ArgumentOutOfRangeException("Runned KM can't be less then null");
            if (newCar.RunnedKM == null) newCar.RunnedKM = 0;
            carRepo.Insert(newCar);
        }
        public void Remove(Car car) {
            if (car == null) throw new ArgumentNullException("Null car (DELETE)");
            carRepo.Remove(car);
        }

       
        public void CarUpdate(int id, Car newCar) {
            if (id < 1) throw new ArgumentException("Invalid ID");
            if (newCar == null) throw new ArgumentNullException("Null car");
            carRepo.CarUpdate(id, newCar);
        }

 
    }
}
