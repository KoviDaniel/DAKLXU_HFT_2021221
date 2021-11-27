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

        void BrandUpdate(int id, Brand newBrand);

        //NON-CRUD METHODS

        IEnumerable<Car> CarOrderByPrice(int id);
        IEnumerable<Car> CarsOrderbyKM(int id);
        IEnumerable<RentACar>/*RentACar*/ MostValuableCarOwner(int id);
    }
}
