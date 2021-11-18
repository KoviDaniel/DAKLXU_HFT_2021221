﻿using DAKLXU_HFT_2021221.Models;
using DAKLXU_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAKLXU_HFT_2021221.Logic
{
    public class BrandLogic : IBrandLogic
    {
        #region CTOR & REPO (brandRepo)
        IBrandRepository brandRepo;
        public BrandLogic(IBrandRepository brandRepo)
        {
            this.brandRepo = brandRepo;
        }
        #endregion

        //read, create, delete
        public Brand GetOne(int id) {
            if (id < 1) throw new ArgumentException("Invalid ID");
            return brandRepo.GetOne(id);
        }
        public List<Brand> GetAll() {
            return brandRepo.GetAll().ToList();
        }
        public void Insert(Brand newBrand) {
            if (newBrand == null) throw new ArgumentNullException("Null brand (INSERT)");
            if (newBrand.BrandName == null) throw new ArgumentNullException("Brand name can't be null");
            brandRepo.Insert(newBrand);
        }
        public void Remove(Brand brand) {
            if (brand == null) throw new ArgumentNullException("Null brand (REMOVE)");
            brandRepo.Remove(brand);
        }
        //update
        /*public void ChangeBrandName(int id, string newBrandName) { 
            if(id < 1) throw new ArgumentException("Invalid ID");
            if (newBrandName == null) throw new ArgumentNullException("new brand name can't be null");
            brandRepo.ChangeBrandName(id, newBrandName);
        }

        public void ChangeCarsCollection(int id, ICollection<Car> newCars) {
            if (id < 1) throw new ArgumentException("Invalid ID");
            if (newCars == null) throw new ArgumentNullException("Null cars collection");
            brandRepo.ChangeCarsCollection(id, newCars);
        }*/

        public void BrandUpdate(int id, Brand newBrand) {
            if (id < 1) throw new ArgumentException("Invalid ID");
            if (newBrand == null) throw new ArgumentNullException("Null brand");
            brandRepo.BrandUpdate(id, newBrand);
        }
        //NON-CRUD METHODS

        public IEnumerable<Car> MostValuableCar(int id) {
            var car = from brand in brandRepo.GetAll()
                      where brand.BrandID == id
                      select brand.Cars.Max(c=>c.RentPrice);
            return (IEnumerable<Car>)car;
        }

        public IEnumerable<Car> CarsOrderbyKM(int id) {
            var cars = from car in brandRepo.GetOne(id).Cars
                       orderby car.RunnedKM descending
                       select car;
            return cars;
        }

        public IEnumerable<RentACar> MostValuableCarOwner(int id) {
            var owner = MostValuableCar(id).First().RentACar;
            return (IEnumerable<RentACar>)owner;
        }
    }
}
