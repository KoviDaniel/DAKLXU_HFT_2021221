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
        }
    }
}
