using DAKLXU_HFT_2021221.Models;
using DAKLXU_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAKLXU_HFT_2021221.Logic
{
    public class RentACarLogic
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
            rentACarRepo.Insert(newRentACar);
        }
        public void Remove(RentACar rentACar) {
            if (rentACar == null) throw new ArgumentNullException("Null rent-a-car");
            rentACarRepo.Remove(rentACar);
        }

        //update
        public void ChangeRating(int id, int newRating) {
            if (id < 1) throw new ArgumentException("Invalid ID");
            if (newRating < 1 || newRating > 5) throw new ArgumentOutOfRangeException("The rating is not between 1 and 5");
            rentACarRepo.ChangeRating(id, newRating);
        }
        public void ChangeRentName(int id, string newRentName) {
            if (id < 1) throw new ArgumentException("Invalid ID");
            if (newRentName == null) throw new ArgumentNullException("new rent-a-car name can't be null");
            rentACarRepo.ChangeRentName(id, newRentName);
        }
        public void ChangeCarsCollection(int id, ICollection<Car> newCars)
        {
            if (id < 1) throw new ArgumentException("Invalid ID");
            if (newCars == null) throw new ArgumentNullException("Null cars collection");
            rentACarRepo.ChangeCarsCollection(id, newCars);
        }

        //NON-CRUD METHODS
    }
}
