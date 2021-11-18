using DAKLXU_HFT_2021221.Models;
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
            if (newBrand.BrandName == "") throw new ArgumentException("Brand name can't be empty string");
            brandRepo.Insert(newBrand);
        }
        public void Remove(Brand brand) {
            if (brand == null) throw new ArgumentNullException("Null brand (REMOVE)");
            brandRepo.Remove(brand);
        }
        

        public void BrandUpdate(int id, Brand newBrand) {
            if (id < 1) throw new ArgumentException("Invalid ID");
            if (newBrand == null) throw new ArgumentNullException("Null brand");
            brandRepo.BrandUpdate(id, newBrand);
        }
        //NON-CRUD METHODS

        /// <summary>
        /// Cars from the choosen brand ordered by price descending
        /// </summary>
        /// <param name="id">Brand ID</param>
        /// <returns>Collection of cars</returns>
        public IEnumerable<Car> CarOrderByPrice(int id) {
            var cars = from car in brandRepo.GetOne(id).Cars
                       orderby car.RentPrice descending
                       select car;
               
            return cars;
        }

        /// <summary>
        /// Cars from the choosen brand ordered by runned km descending
        /// </summary>
        /// <param name="id">Brand ID</param>
        /// <returns>Collection of cars</returns>
        public IEnumerable<Car> CarsOrderbyKM(int id) {
            var cars = from car in brandRepo.GetOne(id).Cars
                       orderby car.RunnedKM descending
                       select car;
            return cars;
        }

        /// <summary>
        /// Returns with the most valuable car owner from the choosen brand
        /// </summary>
        /// <param name="id">Brand ID</param>
        /// <returns>Car owner</returns>
        public IEnumerable<RentACar> MostValuableCarOwner(int id) {

            var owners = from cars in brandRepo.GetOne(id).Cars
                         let x = brandRepo.GetOne(id).Cars.Max(c => c.RentPrice)
                         where cars.RentPrice == x
                         select cars.RentACar;
            return owners;
        }
    }
}
