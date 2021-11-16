using DAKLXU_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAKLXU_HFT_2021221.Logic
{
    public interface IBrandLogic
    {
        //read, create, delete
        Brand GetOne(int id);
        List<Brand> GetAll();
        void Insert(Brand newBrand);
        void Remove(Brand brand);

        //update
        /*void ChangeBrandName(int id, string newBrandName);
        void ChangeCarsCollection(int id, ICollection<Car> newCars);*/

        void BrandUpdate(int id, Brand newBrand);

        //NON-CRUD METHODS
    }
}
