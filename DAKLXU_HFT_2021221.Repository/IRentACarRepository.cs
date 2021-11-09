using DAKLXU_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAKLXU_HFT_2021221.Repository
{
    public interface IRentACarRepository : IRepository<RentACar>
    {
        //update
        void ChangeRentName(int id, string newRentName);

        void ChangeRating(int id, int newrating);
        void ChangeCarsCollection(int id, ICollection<Car> newCars);
    }
}
