using DAKLXU_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAKLXU_HFT_2021221.Repository
{
    public class BrandRepository : Repository<Brand>, IBrandRepository
    {
        public BrandRepository(DbContext ctx) : base(ctx) { }

        //IBrandRepository interface
        /*public void ChangeBrandName(int id, string newBrandName)
        {
            var brand = GetOne(id);
            if (brand == null) throw new InvalidOperationException("Brand not found!");
            brand.BrandName = newBrandName;
            ctx.SaveChanges();
        }

        public void ChangeCarsCollection(int id, ICollection<Car> newCars)
        {
            var brand = GetOne(id);
            if (brand == null) throw new InvalidOperationException("Brand not found!");
            brand.Cars = newCars;
            ctx.SaveChanges();
        }*/

        public void BrandUpdate(int id, Brand newBrand) {
            var brandToUpdate = GetOne(id);
            brandToUpdate.BrandName = newBrand.BrandName;
            brandToUpdate.Cars = newBrand.Cars;
            ctx.SaveChanges();
        }

        //Repository class 
        public override Brand GetOne(int id)
        {
            return GetAll().SingleOrDefault(brand => brand.BrandID == id);
        }
    }
}
