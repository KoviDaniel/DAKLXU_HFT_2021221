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
        /*IBrandRepository brandRepo;
        IRentACarRepository rentRepo;*/
        public CarLogic(ICarRepository carRepo/*, IBrandRepository brandRepo,IRentACarRepository rentRepo*/)
        {
            this.carRepo = carRepo;
            /*this.brandRepo = brandRepo;
            this.rentRepo = rentRepo;*/
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

        //update
        /* public void ChangeCarInsurance(int id, bool newCarInsurance) {
             if (id < 1) throw new ArgumentException("Invalid ID");
             carRepo.ChangeCarInsurance(id, newCarInsurance);
         }
         public void ChangeColour(int id, string newColour) {
             if (id < 1) throw new ArgumentException("Invalid ID");
             if (newColour == null) throw new ArgumentNullException("new colour can't be null");
             carRepo.ChangeColour(id, newColour);
         }
         public void ChangeModel(int id, string newModel) {
             if (id < 1) throw new ArgumentException("Invalid ID");
             if (newModel == null) throw new ArgumentNullException("new model can't be null");
             carRepo.ChangeModel(id, newModel);
         }
         public void ChangeRentPrice(int id, int newRentPrice) {
             if (id < 1) throw new ArgumentException("Invalid ID");
             if (newRentPrice < 0) throw new ArgumentException("Rent price can't be less then zero");
             carRepo.ChangeRentPrice(id, newRentPrice);
         }
         public void ChangeRunnedKM(int id, int newRunnedKM) {
             if (id < 1) throw new ArgumentException("Invalid ID");
             if (newRunnedKM < 0) throw new ArgumentException("Runned kilometer can't be less then zero");
             carRepo.ChangeRunnedKM(id, newRunnedKM);
         }


         public void ChangeBrandId(int id, int newId) {
             if (id < 1 || newId < 1) throw new ArgumentException("Invalid ID");
             carRepo.ChangeBrand(id, brandRepo.GetOne(newId));
         }
         public void ChangeRentACarId(int id, int newId) {
             if (id < 1 || newId < 1) throw new ArgumentException("Invalid ID");
             carRepo.ChangeRentACar(id, rentRepo.GetOne(newId));
         }
         public void ChangeBrand(int id, Brand newBrand) {
             if (id < 1) throw new ArgumentException("Invalid ID");
             if (newBrand == null) throw new ArgumentNullException("Brand is null");
             carRepo.ChangeBrand(id, newBrand);
         }
         public void ChangeRentACar(int id, RentACar newRentACar) {
             if (id < 1) throw new ArgumentException("Invalid ID");
             if (newRentACar == null) throw new ArgumentNullException("Rent-a-car is null");
             carRepo.ChangeRentACar(id, newRentACar);
         }*/
        public void CarUpdate(int id, Car newCar) {
            if (id < 1) throw new ArgumentException("Invalid ID");
            if (newCar == null) throw new ArgumentNullException("Null car");
            carRepo.CarUpdate(id, newCar);
        }

        //NON-CRUD METHODS
        //no non-crud method
    }
}
