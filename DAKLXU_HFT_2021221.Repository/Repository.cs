using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAKLXU_HFT_2021221.Repository
{
    //base repository class 
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected DbContext ctx;
        public Repository(DbContext ctx) {
            this.ctx = ctx;
        }

        public IQueryable<T> GetAll()
        {
            return this.ctx.Set<T>();
        }

        public abstract T GetOne(int id);

        public void Insert(T entity)
        {
            this.ctx.Set<T>().Add(entity);
            this.ctx.SaveChanges();
        }

        public void Remove(T entity)
        {
            this.ctx.Set<T>().Remove(entity);
            this.ctx.SaveChanges();
        }
    }
}
