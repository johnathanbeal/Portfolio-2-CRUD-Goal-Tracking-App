using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoalsApplicationMark1.Models;

namespace GoalsApplicationMark1.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Add(T goalTaskEpic);
        void Remove(int id);

        void Update(T goalTaskEpic);

        T FindByID(int id);

        IEnumerable<T> FindAll();


    }
}
