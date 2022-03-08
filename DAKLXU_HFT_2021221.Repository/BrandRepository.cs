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

        public void BrandUpdate(/*int id,*/ Brand newBrand) {
            //var brandToUpdate = GetOne(id);
            //brandToUpdate.BrandName = newBrand.BrandName;
            //brandToUpdate.Cars = newBrand.Cars;
            //ctx.SaveChanges();

            var old = GetOne(newBrand.BrandID);
            foreach (var prop in old.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(newBrand));
                }
            }
            ctx.SaveChanges();
        }

        //Repository class 
        public override Brand GetOne(int id)
        {
            return GetAll().SingleOrDefault(brand => brand.BrandID == id);
        }
    }
}
