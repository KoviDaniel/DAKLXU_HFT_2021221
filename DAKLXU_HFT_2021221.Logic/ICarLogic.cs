using DAKLXU_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAKLXU_HFT_2021221.Logic
{
    public interface ICarLogic
    {
        //read, create, delete
        Car GetOne(int id);
        List<Car> GetAll();
        void Insert(Car newCar);
        void Remove(Car car);

        //update
        void ChangeCarInsurance(int id, bool newCarInsurance);
        void ChangeColour(int id, string newColour);
        void ChangeModel(int id, string newModel);
        void ChangeRentPrice(int id, int newRentPrice);
        void ChangeRunnedKM(int id, int newRunnedKM);

        //NON-CRUD METHODS
    }
}
