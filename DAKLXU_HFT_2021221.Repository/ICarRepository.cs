using DAKLXU_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAKLXU_HFT_2021221.Repository
{
    public interface ICarRepository : IRepository<Car>
    {
        //Updates

        void CarUpdate(/*int id,*/ Car newCar);
    }
}
