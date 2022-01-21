using SeriesAPI.Entities;
using System.Linq.Expressions;

namespace SeriesAPI.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        //Create
        void Insert(T entidade);

        //Read
        List<T> GetAll();                   
        T? GetById(int id);                  
        T? GetByWhere (Expression<Func<T, bool>> where);
        C GetBySQL<C>(String sql);

        //Update
        void Update(T entidade);

        //Delete
        void Delete(T entidade);            
    }
}
