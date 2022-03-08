using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAKLXU_HFT_2021221.Repository
{
    public interface IRepository<T> where T:class
    {
        //base CRUD methods

        // create
        void Insert(T entity);
        // read: 2
        T GetOne(int id);
        IQueryable<T> GetAll();
        //update is class specified (later)
        //delete
        void Remove(/*T entity*/int id);

    }
}
