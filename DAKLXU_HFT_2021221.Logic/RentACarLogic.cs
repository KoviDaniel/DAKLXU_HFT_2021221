using DAKLXU_HFT_2021221.Models;
using DAKLXU_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAKLXU_HFT_2021221.Logic
{
    public class RentACarLogic : IRentACarLogic
    {
        #region CTOR & REPO (rentACarRepo)
        IRentACarRepository rentACarRepo;
        public RentACarLogic(IRentACarRepository rentACarRepo)
        {
            this.rentACarRepo = rentACarRepo;
        }
        #endregion

        //read, create, delete
        public RentACar GetOne(int id) {
            if (id < 1) throw new ArgumentException("Invalid ID [RentACarLogic]");
            return rentACarRepo.GetOne(id);
        }
        public List<RentACar> GetAll() {
            return rentACarRepo.GetAll().ToList();
        }
        public void Insert(RentACar newRentACar) {
            if (newRentACar == null) throw new ArgumentNullException("Null rent-a-car");
            if (newRentACar.RentName == null) throw new ArgumentNullException("Rent name can't be null");
            if (newRentACar.RentName == "") throw new ArgumentException("Rent name can't be empty string");
            if (newRentACar.Rating == null) throw new ArgumentNullException("Rating can't be null");
            if (newRentACar.Rating < 0 && newRentACar.Rating > 5) throw new ArgumentOutOfRangeException("Rating must be between 0 and 5");
            rentACarRepo.Insert(newRentACar);
        }
        public void Remove(RentACar rentACar) {
            if (rentACar == null) throw new ArgumentNullException("Null rent-a-car");
            rentACarRepo.Remove(rentACar);
        }

       

        public void RentACarUpdate(int id, RentACar newRent) {
            if (id < 1) throw new ArgumentException("Invalid ID");
            if (newRent == null) throw new ArgumentNullException("Null Rent-A-Car");
            rentACarRepo.RentACarUpdate(id, newRent);
        }

        //NON-CRUD METHODS

        /// <summary>
        /// Return with a collection of cars ordered by runned km from the choosen Rent-A-Car 
        /// </summary>
        /// <param name="id">Rent-A-Car ID</param>
        /// <returns>Collection of cars</returns>
        public IEnumerable<Car> MostRunnedKM(int id) {
            var car = from rent in rentACarRepo.GetOne(id).Cars
                      orderby rent.RunnedKM
                      select rent;
            return car;
        }

        public IEnumerable<KeyValuePair<string, double>> GroupByModels(int id) {
            return from x in rentACarRepo.GetOne(id).Cars
                   group x by x.Brand.BrandName into grp
                   select new KeyValuePair<string, double>
                   (grp.Key, grp.Sum(e => e.RentPrice));
        }
    }
}
