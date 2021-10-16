using DAKLXU_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAKLXU_HFT_2021221.Repository
{
    class BrandRepository : Repository<Brand>, IBrandRepository
    {
        public BrandRepository(DbContext ctx) : base(ctx) { }

        //IBrandRepository interface
        public void ChangeBrandName(int id, string newBrandName)
        {
            var brand = GetOne(id);
            if (brand == null) throw new InvalidOperationException("Brand not found!");
        }

        //Repository class 
        public override Brand GetOne(int id)
        {
            return GetAll().SingleOrDefault(brand => brand.BrandID == id);
        }
    }
}
