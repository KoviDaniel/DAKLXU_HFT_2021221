using DAKLXU_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAKLXU_HFT_2021221.Logic
{
    public interface IRentACarLogic
    {
        //read, create, delete
        RentACar GetOne(int id);
        List<RentACar> GetAll();
        void Insert(RentACar newRentACar);
        void Remove(/*RentACar rentACar*/int id);

        //update

        void RentACarUpdate(int id, RentACar newRent);

        //NON-CRUD METHODS
        IEnumerable<Car> MostRunnedKM(int id);
        IEnumerable<KeyValuePair<string, double>> GroupByModels(int id); 
    }
}
