using Microsoft.EntityFrameworkCore;
using SeriesAPI.Data;
using SeriesAPI.Entities;
using SeriesAPI.Interfaces;
using System.Linq.Expressions;
using Dapper;

namespace SeriesAPI.Repositories
{
    
    public class Repository<T> : IRepository<T> where T : Entity
    {
        public APIContext Context;
        public Repository(APIContext context)
        {
            Context = context;
        }
        public void Insert(T entidade)      //C
        {
            Context.Set<T>().Add(entidade);
            Context.SaveChanges();
        }
                                            //R            
        public List<T> GetAll() => Context.Set<T>().ToList();
        public T? GetById(int id) => Context.Set<T>().FirstOrDefault(_ => _.Id == id);
        public T? GetByWhere(Expression<Func<T, bool>> where) => Context.Set<T>().Where(where).FirstOrDefault();
        public C GetBySQL<C>(String sql) => Context.Database.GetDbConnection().QuerySingle<C>(sql);

        public void Update(T entidade)      //U
        {
            Context.Set<T>().Update(entidade);
            Context.SaveChanges();
        }

        public void Delete(T entidade)      //D
        {
            Context.Set<T>().Remove(entidade);
            Context.SaveChanges();
        }
        
        

                
       
    }
}

